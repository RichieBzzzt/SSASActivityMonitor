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

namespace Microsoft.AnalysisServices.Samples.ActivityViewer
{
    using System;
    using System.Xml;
    using System.Data;
    using Microsoft.AnalysisServices.AdomdClient;
    using Microsoft.AnalysisServices;
    using System.Collections;
    using System.Collections.Specialized;

    /// <summary>
    /// Summary description for ASCommands.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1058:TypesShouldNotExtendCertainBaseTypes")]
    public class ASCommands : IDisposable
    {
        #region Constants
        public const string DiscoverNameConnections = "Connections";
        public const string DiscoverNameSessions = "Sessions";
        public const string DiscoverNameTransactions = "Transactions";
        public const string DiscoverNameLocks = "Locks";
        public const string DiscoverNameNone = "";
        public const string DiscoverNameTraces = "Traces";

        public const string DiscoverTypeConnections = "DISCOVER_CONNECTIONS";
        public const string DiscoverTypeSessions = "DISCOVER_SESSIONS";
        public const string DiscoverTypeTransactions = "DISCOVER_TRANSACTIONS";
        public const string DiscoverTypeLocks = "DISCOVER_LOCKS";
        public const string DiscoverTypeNone = "";
        public const string DiscoverTypeTraces = "DISCOVER_TRACES";

        #endregion

        #region Member Variables

        private AdomdConnection connection = new AdomdConnection();
        private Server serverConnection;
        private string connectionString;
        private int spid1=-1;
        private int spid2 = -1;

        #endregion

        #region Constructor/Destructor

        public ASCommands(string connection)
        {
            this.connectionString = connection;
        }

        ~ASCommands()
        {
            this.Dispose(false);
        }

        #endregion

        #region Public Properties

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2002:DoNotLockOnObjectsWithWeakIdentity")]
        public bool IsConnected
        {
            get
            {
                lock (this.connection)
                {
                    // return true if connection is open
                    if (this.connection != null
                        && this.connection.State == ConnectionState.Open)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public string ConnectionString
        {
            get
            {
                return this.connectionString;
            }
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            this.Dispose(true);
        }

        #endregion

        #region Public Methods

        public DataTable DataTableFromQuery(string query)
        {
            DataTable table = new DataTable();
            System.Data.OleDb.OleDbDataAdapter ole = new System.Data.OleDb.OleDbDataAdapter(query, connectionString);
            ole.Fill(table);
            return table;
        }

        public void ChangeConnectionString(string newString)
        {
            connectionString = newString;
        }

        public void Reconnect()
        {
            if (this.IsConnected)
            {
                Disconnect();
                Connect();
            }
        }



        public DataTable DiscoverTraces()
        {
            //connect to Analysis Services and execute query to Discover Connections
            return this.GetDiscoverResults(DiscoverTypeTraces);
        }

        public DataTable DiscoverConnections()
        {
            // connect to Analysis Services and execute query to Discover Connections
            return this.GetDiscoverResults(DiscoverTypeConnections);
        }

        public DataTable DiscoverConnection(long connectionId)
        {
            // connect to Analysis Services and execute query to Discover Connections

            NameValueCollection col
                = new NameValueCollection(1);
            col.Add(
                "CONNECTION_ID",
                connectionId.ToString(System.Globalization.CultureInfo.InvariantCulture));

            return this.GetDiscoverResults(DiscoverTypeConnections, col);
        }

        public DataTable DiscoverSessions()
        {
            // connect to Analysis Services and execute query to Discover Connections
            return this.GetDiscoverResults(DiscoverTypeSessions);
        }

        public DataTable DiscoverSessions(long connectionId)
        {
            // connect to Analysis Services and execute query to Discover Connections

            NameValueCollection col
                = new NameValueCollection(1);
            col.Add(
                "SESSION_CONNECTION_ID",
                connectionId.ToString(System.Globalization.CultureInfo.InvariantCulture));

            return this.GetDiscoverResults(DiscoverTypeSessions, col);
        }

        public DataTable DiscoverSession(long sessionSpid)
        {
            // connect to Analysis Services and execute query to Discover Connections

            NameValueCollection col
                = new NameValueCollection(1);
            col.Add(
                "SESSION_SPID",
                sessionSpid.ToString(System.Globalization.CultureInfo.InvariantCulture));

            return this.GetDiscoverResults(DiscoverTypeSessions, col);
        }

        public DataTable DiscoverTransactions()
        {
            // connect to Analysis Services and execute query to Discover Connections
            return this.GetDiscoverResults(DiscoverTypeTransactions);
        }

        public DataTable DiscoverTransactions(string sessionId)
        {
            if (sessionId == null)
            {
                throw new ArgumentNullException("sessionId");
            }

            // connect to Analysis Services and execute query to Discover Connections

            NameValueCollection col
                = new NameValueCollection(1);
            col.Add(
                "TRANSACTION_SESSION_ID",
                @"{" + sessionId.ToString() + @"}");

            return this.GetDiscoverResults(DiscoverTypeTransactions, col);
        }

        public DataTable DiscoverLocks()
        {
            // connect to Analysis Services and execute query to Discover Connections
            return this.GetDiscoverResults(DiscoverTypeLocks);
        }

        public DataTable DiscoverLocks(long transactionId)
        {
            // connect to Analysis Services and execute query to Discover Connections

            NameValueCollection col
                = new NameValueCollection(1);
            col.Add(
                "LOCK_TRANSACTION_ID",
                transactionId.ToString(System.Globalization.CultureInfo.InvariantCulture));

            return this.GetDiscoverResults(DiscoverTypeLocks, col);
        }

        public DataTable DiscoverLocks(string transactionId)
        {
            if (transactionId == null)
            {
                throw new ArgumentNullException("transactionId");
            }

            // connect to Analysis Services and execute query to Discover Connections

            NameValueCollection col
                = new NameValueCollection(1);
            col.Add(
                "LOCK_TRANSACTION_ID",
                @"{" + transactionId.ToString() + @"}");

            return this.GetDiscoverResults(DiscoverTypeLocks, col);
        }

        public bool IsApplicationSession(int spid)
        {
            if (this.spid1 < 0 && this.connection!=null)
            {
                DataTable table = DataTableFromQuery("Select SESSION_SPID from $system.discover_sessions where SESSION_ID = '"+this.connection.SessionID+"'");
                spid1 = (int)(table.Rows[0]["SESSION_SPID"]);
            }
            if (this.spid2 < 0 && this.serverConnection!=null)
            {
                DataTable table = DataTableFromQuery("Select SESSION_SPID from $system.discover_sessions where SESSION_ID = '"+this.serverConnection.SessionID+"'");
                spid2 = (int)(table.Rows[0]["SESSION_SPID"]);
            }

            if (spid1 == spid
                || spid2 == spid)
            {
                return true;
            }

            return false;
        }

        public void CancelConnection(int connectionId)
        {
            this.serverConnection.CancelConnection(connectionId);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters", MessageId = "Microsoft.Samples.SqlServer.ASCommands+SessionInUseException.#ctor(System.String)")]
        public void CancelSession(int sessionSpid)
        {
            if (ActivityViewerForm.pm.IsProgramSession(sessionSpid))
            {
                throw new SessionInUseException(
                       "The selected session is in use by this application and can not be cancelled.");
            }

            this.serverConnection.CancelSession(sessionSpid);
        }

        public void CancelTrace(string traceId)
        {
            this.serverConnection.Traces[traceId].Stop();
        }

        public void Connect()
        {
            this.Connect(connectionString);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2002:DoNotLockOnObjectsWithWeakIdentity"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters", MessageId = "System.ApplicationException.#ctor(System.String,System.Exception)"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes")]
        public void Connect(string connectionString)
        {
            // establish connection to the server
            try
            {
                lock (this.connection)
                {
                    if (this.connection == null || this.connection.State != ConnectionState.Open)
                    {
                        this.serverConnection = new Server();
                        this.connection = new AdomdConnection(connectionString);
                    }

                    this.serverConnection.Connect(connectionString);
                    this.connection.Open();
                    this.connectionString = connectionString;
                }
            }
            catch (System.Exception ex)
            {
                throw new ConnectionException("Error trying to open connection.", ex);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2002:DoNotLockOnObjectsWithWeakIdentity"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2200:RethrowToPreserveStackDetails")]
        public void Disconnect()
        {
            // disconnect and release reference
            if(IsConnected)
            try
            {
                lock (this.connection)
                {
                    if (this.connection != null)
                    {
                        this.connection.Close();
                    }

                    if (this.serverConnection != null)
                    {
                        this.serverConnection.Disconnect();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region Private Methods

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }

            if (this.connection != null)
            {
                this.connection.Close();
                this.connection.Dispose();
            }

            if (this.serverConnection != null)
            {
                this.serverConnection.Disconnect();
                this.serverConnection.Dispose();
            }
        }

        private DataTable GetDiscoverResults(string requestType)
        {
            return this.GetDiscoverResults(requestType, null);
        }

        private DataTable GetDiscoverResults(string requestType, NameValueCollection restrictions)
        {
            DataSet ds = null;
            AdomdRestrictionCollection col = null;

            // build collection of restrictions for the discover
            if (restrictions != null && restrictions.Count > 0)
            {
                col = new AdomdRestrictionCollection();
                NameValueCollection.KeysCollection keys = restrictions.Keys;
                for (int i = 0; i < keys.Count; i++)
                {
                    col.Add(new AdomdRestriction(keys[i], restrictions[keys[i]]));
                }
            }

            // establish connection to the server
            try
            {
                lock (this.connection)
                {
                    if (!this.IsConnected)
                    {
                        this.Connect();
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw new ConnectionException("Error trying to open connection.", ex);
            }

            // execute discover command
            try
            {
                lock (this.connection)
                {
                    ds = this.connection.GetSchemaDataSet(requestType, col);
                }
            }
            catch (System.Exception ex)
            {
                throw new ConnectionException("Error executing command on the server.", ex);
            }

            // return results of the discover
            return ds.Tables[0];
        }
        #endregion

        [Serializable]
        internal class SessionInUseException : ApplicationException
        {
            public SessionInUseException(string message)
                : base(message)
            {
            }
        }
    }
}
