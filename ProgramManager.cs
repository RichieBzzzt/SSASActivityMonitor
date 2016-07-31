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
using System.IO;
using Microsoft.AnalysisServices;
using System.Xml;

namespace Microsoft.AnalysisServices.Samples.ActivityViewer
{
    /// <summary>
    /// A manager for the Analysis Services ActivityViewer Sample Program
    /// </summary>
    public class ProgramManager
    {
        /// <summary>
        /// list of servers being used by the program
        /// </summary>
        internal List<ServerManager> servers;

        /// <summary>
        /// Construct a new instance of ProgramManager
        /// </summary>
        public ProgramManager()
        {
            servers = new List<ServerManager>();
        }

        /// <summary>
        /// Checks if the given SPID is a session being used by this application
        /// </summary>
        /// <param name="spid">The spid in question</param>
        /// <returns>Whether the spid is being used by this application</returns>
        public bool IsProgramSession(int spid)
        {
            foreach (ServerManager sm in servers)
                if (sm.ASMan.IsApplicationSession(spid))
                    return true;
            return false;
        }

        /// <summary>
        /// Called at startup to initialize previous state and set up the PM
        /// </summary>
        public void InitializeProgram()
        {
                LoadSession();
                foreach (ServerManager sm in servers)
                    try
                    {
                        sm.Connect();
                    }
                    catch
                    {
                        servers.Remove(sm);
                    }

        }

        /// <summary>
        /// Called at closing time to gracefully disconnect all servers and save state
        /// </summary>
        public void TerminateProgram()
        {

            foreach (ServerManager sm in servers)
                sm.Disconnect();
            SaveSession();
        }

        /// <summary>
        /// Save the current session to the filesystem
        /// </summary>
        private void SaveSession()
        {
            FileStream fs = new FileStream("config.xml", FileMode.Create);
            XmlTextWriter writer = new XmlTextWriter(fs,Encoding.UTF8);
            try
            {
                writer.WriteStartDocument();

                //write XML top-down through each management object
                writer.WriteStartElement("Servers");
                foreach (ServerManager sm in servers)
                    sm.SaveConfigData(writer);
                writer.WriteEndElement();
            }
            finally
            {
                writer.Flush();
                fs.Close();
            }
        }

        /// <summary>
        /// Load a previous session from a predefined configuration file
        /// </summary>
        private void LoadSession()
        {
            FileStream fs=null;
            try
            {   //try to open the file and return if the open fails
                fs = new FileStream("config.xml", FileMode.Open);
            }
            catch{
                return;
            }
            try
            {
                XmlTextReader reader = new XmlTextReader(fs);

                reader.ReadToFollowing("Servers");
                reader.ReadToDescendant("Server");
                do
                {   //read connection string for each server and try to add it to the program
                    reader.ReadToDescendant("String");
                    ServerManager newman = new ServerManager(reader.ReadElementString("String"));
                    try
                    {
                        AddServer(newman);
                    }
                    catch { }

                    //add saved rules to the server
                    while (reader.Name == "Rule")
                    {
                        Rule newRule = newman.RuleMan.AddRule(reader.ReadElementString("Rule"));
                        newRule.SetPriority(int.Parse(reader.ReadElementString("Priority")));
                    }

                } while (reader.ReadToFollowing("Server"));
            }
            catch
            {//unfortunately an error in the configuration file may cancel loading any data after that point
             //will figure this out when more familiar with parsing XML files, probably should use DOM, oh well
            }
            finally
            {
                fs.Close();
            }

        }

        /// <summary>
        /// Attempts to add a server to the program, does not allow duplicates or faulty connections
        /// </summary>
        /// <param name="server">The server to attempt to add to the program</param>
        public void AddServer(ServerManager server)
        {
            foreach (ServerManager existing in servers)//do not allow duplicates
                if (existing.ASMan.ConnectionString.Equals(server.ASMan.ConnectionString))
                    throw new ArgumentException("Server Already Exists");
            //test for a valid connection, delegate exception up if connection is bad
            server.TestConnection();
            servers.Add(server);
        }

        /// <summary>
        /// Removes a server from the program
        /// </summary>
        /// <param name="server">The server to remove</param>
        public void RemoveServer(ServerManager server)
        {
            server.Disconnect();
            servers.Remove(server);
        }

        /// <summary>
        /// Sets the refresh rate for data in the grids
        /// </summary>
        /// <param name="intervalInMS">The new interval in milliseconds</param>
        public void SetDataRefreshRate(int intervalInMS)
        {
            foreach (ServerManager sm in servers)
                sm.RuleMan.ChangeTimer(intervalInMS);
        }

        public static string GetToolTipText(string header)
        {
            switch (header)
            {
                case "SESSION_SPID":
                    return "Session ID";
                case "SESSION_USER_NAME":
                    return "Name of the user associated with session";
                case "SESSION_START_TIME":
                    return "Time when session started";
                case "SESSION_ELAPSED_TIME_MS":
                    return "Elapsed time since start of session (in milliseconds)";
                case "SESSION_CPU_TIME_MS":
                    return "CPU time consumed by all requests during the session (in milliseconds)";
                case "COMMAND_ELAPSED_TIME_MS":
                    return "Elapsed time since start of the command (in milliseconds)";
                case "COMMAND_CPU_TIME_MS":
                    return "CPU time consumed by all requests during the command (in milliseconds)";
                case "SESSION_ID":
                    return "Session GUID";
                case "COMMAND_READ_KB":
                    return "Size of distinct reads measured in KB collected for the command";
                case "COMMAND_WRITE_KB":
                    return "Size of distinct writes measured in KB collected for the command";
                case "SESSION_READ_KB":
                    return "Size of distinct reads measured in KB collected for the session";
                case "SESSION_WRITE_KB":
                    return "Size of distinct writes measured in KB collected for the session";
                case "COMMAND_TEXT":
                    return "Text of the query for the command";
                case "SESSION_IDLE_TIME_MS":
                    return "Time that a session's status has been idle (in milliseconds)";
                case "SESSION_USED_MEMORY":
                    return "Size of the memory currently used by session";
                case "SESSION_LAST_COMMAND_END_TIME":
                    return "Time that the last command ended at";
                case "SESSION_LAST_COMMAND_CPU_TIME_MS":
                    return "CPU time consumed by all requests during last command (in milliseconds)";
                case "SESSION_READS":
                    return "Number of distinct reads collected for the session";
                case "SESSION_WRITES":
                    return "Number of distinct writes measured in the session ";
                case "OBJECT_CPU_TIME_MS":
                    return "Cumulative CPU time throughout lifetime of the command used by the object (in milliseconds)";
                case "OBJECT_READS":
                    return "Number of distinct reads collected for the object";
                case "OBJECT_AGGREGATION_HIT":
                    return "Number of queries missed and answered from aggregations";
                case "OBJECT_ID":
                    return "Object ID";
                case "OBJECT_PARENT_PATH":
                    return "Path to the object including all parent ID’s";
                case "SPID":
                    return "Session ID";
                case "LOCK_ID":
                    return "Lock ID";
                case "LOCK_TRANSACTION_ID":
                    return "Transaction ID for the lock";
                case "LOCK_OBJECT_ID":
                    return "Object ID for the lock";
                case "LOCK_STATUS":
                    return "Lock status = 1 indicates that the lock has been granted";
                case "LOCK_TYPE":
                    return "LOCK_TYPE indicates the type of lock (example: 8 is a commit read lock)";
                case "LOCK_CREATION_TIME":
                    return "Time of creation of the lock";
                case "LOCK_GRANT_TIME":
                    return "Time the lock was granted";
                default:
                    return "";
            }
        }
    }
}
