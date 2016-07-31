//-----------------------------------------------------------------------
//  This file is part of the Microsoft Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
// 
//  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.AnalysisServices;
using System.Data;

namespace Microsoft.AnalysisServices.Samples.ActivityViewer
{
    /// <summary>
    /// A class to hold an alert on this server with details
    /// </summary>
    public class Alert : IDisposable
    {
        /// <summary>
        /// The rule violated
        /// </summary>
        internal Rule rule;
        /// <summary>
        /// The table of rows which violated the rule
        /// </summary>
        internal DataTable table;
        /// <summary>
        /// The culprit's identity
        /// </summary>
        internal string violator;
        /// <summary>
        /// The server this alert was raised in
        /// </summary>
        internal ServerManager server;
        /// <summary>
        /// the priority of this alert
        /// </summary>
        internal int priority;

        /// <summary>
        /// Contructor for new Alert
        /// </summary>
        /// <param name="row">The culprit row</param>
        /// <param name="rule">The violated rule</param>
        /// <param name="column">The column in row containing culprit's identity</param>
        public Alert(DataRow row, Rule rule, string column)
        {
            if (rule == null || column == null || row == null)
                throw new ArgumentException("Cannot make alerts with null values");

            this.table = new DataTable();
            foreach (DataColumn col in row.Table.Columns)
                table.Columns.Add(col.ColumnName, col.DataType);
            AddRow(row);

            this.rule = rule;
            violator = row[column].ToString();
            priority = rule.priority;
        }

        /// <summary>
        /// Adds a row to this alert's violated list
        /// </summary>
        /// <param name="row">The row to add</param>
        public void AddRow(DataRow row){
            if (row == null)
                throw new ArgumentException("Cannot add null row to alert");
            foreach (DataRow drow in table.Rows)
                if (drow["SESSION_SPID"].Equals(row["SESSION_SPID"]))
                    return;

            table.Rows.Add(row.ItemArray);
        }

        /// <summary>
        /// Sets the server this alert was raised on
        /// </summary>
        /// <param name="Server">The server this alert was raised on</param>
        public void SetServer(ServerManager server)
        {
            this.server = server;
        }

        /// <summary>
        /// Override ToString to give Alert context
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return rule.condition.ToString();
        }

        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            table.Dispose();
        }

        #endregion
    }

    /// <summary>
    /// Class to manage a server
    /// </summary>
    public class ServerManager : IDisposable
    {
    #region Member Variables
        /// <summary>
        /// Analysis Services Manager to talk to server
        /// </summary>
        internal ASCommands ASMan;
        /// <summary>
        /// Rule Manager on this server
        /// </summary>
        internal RuleManager RuleMan;
        /// <summary>
        /// This server's name
        /// </summary>
        internal string Name;
        /// <summary>
        /// List of Alerts on the server
        /// </summary>
        internal List<Alert> alerts = null;
        /// <summary>
        /// The refresh interval for grids on this server.  Refresh is off by default.
        /// </summary>
        internal int dataRefreshInterval;

    #endregion

    #region Constructor/Destructor

        /// <summary>
        /// Constructor  for server manager
        /// </summary>
        /// <param name="connection">The connection to the server this will manage</param>
        public ServerManager(string connection)
        {
            connection = FixProvider(connection);

            ASMan = new ASCommands(connection);
            RuleMan = new RuleManager();

            //set up rule delegates to server functions
            RuleMan.getData = new DataDel(ASMan.DiscoverSessions);
            RuleMan.kill = new ActionDel(CancelSessionForRule);
            RuleMan.alert = new ActionDel(AddAlertForRule);
            RuleMan.ruleGetData = new QueryToData(ASMan.DataTableFromQuery);

            this.alerts = new List<Alert>();
            this.Name = DataSourceFromConnString(connection);
        }

        public ServerManager(string connection, int refresh)
        {
            dataRefreshInterval = refresh;
            connection = FixProvider(connection);

            ASMan = new ASCommands(connection);
            RuleMan = new RuleManager();

            //set up rule delegates to server functions
            RuleMan.getData = new DataDel(ASMan.DiscoverSessions);
            RuleMan.kill = new ActionDel(CancelSessionForRule);
            RuleMan.alert = new ActionDel(AddAlertForRule);
            RuleMan.ruleGetData = new QueryToData(ASMan.DataTableFromQuery);

            this.alerts = new List<Alert>();
            this.Name = DataSourceFromConnString(connection);
        }

         ~ServerManager(){
             //disconnect from the server on destruction
            Disconnect();
        }

#endregion

    #region Public Methods

        /// <summary>
        /// A delegate to be called from the rules for killing sessions
        /// </summary>
        /// <param name="arg2">the Session SPID as an integer</param>
        private void CancelSessionForRule(object arg1, object arg2){
            try{
                ASMan.CancelSession((int)arg2);
            }
            catch{}
        }

        /// <summary>
        /// A delegate to be called from the rules to add an alert.
        /// Also used to clear alerts list with 2 null arguments
        /// </summary>
        /// <param name="arg1">The culprit row as a DataRow</param>
        /// <param name="arg2">the violated rule as a Rule</param>
        private void AddAlertForRule(object arg1, object arg2){
            if (arg1 == null && arg2 == null)
            {
                alerts.Clear();
                return;
            }
            try
            {
                AddAlert(new Alert((DataRow)arg1, (Rule)arg2, "SESSION_USER_NAME"));
            }
            catch { }
        }

        /// <summary>
        /// Adds an alert to this server.  Only one alert with the same violated rule and culprit session is allowed
        /// </summary>
        /// <param name="alert">The alert to attemtp to add</param>
        public void AddAlert(Alert alert)
        {
            Alert existing = alerts.Find(a => a.rule.ToString().Equals(alert.rule.ToString()) && a.violator.Equals(alert.violator));

            if (existing == null)
            {
                int index = alerts.FindLastIndex(a => a.priority == alert.priority - 1);
                alerts.Insert(index+1, alert);
                alert.SetServer(this);
            }
            else
                foreach (DataRow row in alert.table.Rows)
                    existing.AddRow(row);
        }
      
        /// <summary>
        /// Connect this server to start processing rules
        /// </summary>
        public void Connect()
        {
            ASMan.Connect();
            RuleMan.Start();
        }

        /// <summary>
        /// Disconnect this server and stop processing rules
        /// </summary>
        public void Disconnect()
        {
            RuleMan.Stop();
            ASMan.Disconnect();
        }

        /// <summary>
        /// Change the connection string on this server
        /// </summary>
        /// <param name="newString">The string to which to try to change to</param>
        public void NewConnectionString(string newString)
        {
            string oldstring = ASMan.ConnectionString;
            newString = FixProvider(newString);

            ASMan.ChangeConnectionString(newString);
            try
            {
                TestConnection();
                Name = DataSourceFromConnString(newString);
            }
            catch
            {
                ASMan.ChangeConnectionString(oldstring);
                throw;
            }
            ASMan.Reconnect();
        }

        /// <summary>
        /// Fixes the provider to be msolap in a connection string, regardless of what it was set to before or if it existed.
        /// Also formats the string to have consistent spacing.
        /// </summary>
        /// <param name="conn">The connection string to modify</param>
        /// <returns>A new connection string with msolap as the provider</returns>
        public static string FixProvider(string conn)
        {
            string[] buff = conn.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            conn = "";
            foreach(string s in buff)
                if (s.Trim().ToLowerInvariant().StartsWith("provider"))
                    conn += "";
                else if (!String.IsNullOrEmpty(s))
                {
                    string[] temp = s.Split(new char[] { '=' }, 2);
                    conn += temp[0].Trim() + " = " + temp[1].Trim() + " ; ";
                }

            conn += "Provider = msolap";

            return conn;
        }

        /// <summary>
        /// Test the connection on this server.  Will throw exception if connection is bad or if Microsoft.AnalysisServices.Samples.ActivityViewer DB is not installed on the server
        /// </summary>
        public void TestConnection()
        {
            Server test = new Server();
            test.Connect(ASMan.ConnectionString);
            
            if (double.Parse(test.Version.Substring(0,4)) < 10.0)
            {
                test.Disconnect();
                throw new ConnectionException("Server version must be at least 10.0");
            }
            test.Disconnect();
        }

        /// <summary>
        /// Parse the data source out of a connection string
        /// </summary>
        /// <param name="connString">The string to parse data source out of</param>
        /// <returns>Returns "" if string is invalid or not formatted properly</returns>
        private static string DataSourceFromConnString(string connectionString)
        {
            ConnectionInfo ci = new ConnectionInfo(connectionString);
            string dataSource = ci.Server;

            if (ci.Port != null)
                dataSource += ":" + ci.Port;
            if (ci.InstanceName != null)
                dataSource += @"\" + ci.InstanceName;

            return dataSource;
        }

    #endregion

    #region Configuration Methods

        /// <summary>
        /// Saves the data for this session to the given XmlTextWriter
        /// </summary>
        /// <param name="writer">The writer to which to write the session data</param>
        public void SaveConfigData(XmlWriter writer)
        {
            writer.WriteStartElement("Server");
            //write server information and ask RuleMan to save its rules for us
            writer.WriteElementString("String", ASMan.ConnectionString);
            RuleMan.SaveConfigData(writer);
            writer.WriteEndElement();
        }

    #endregion


        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Disconnect();
            ASMan.Dispose();
            RuleMan.Dispose();
        }

        #endregion
    }
}
