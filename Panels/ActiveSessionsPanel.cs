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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Microsoft.AnalysisServices.Samples.ActivityViewer
{
    public partial class ActiveSessionsPanel : UserControl
    {
        ServerManager myServer;
        private string usersQuery = "SELECT SESSION_SPID,SESSION_USER_NAME,SESSION_START_TIME, SESSION_ELAPSED_TIME_MS, SESSION_CPU_TIME_MS,SESSION_ID FROM $SYSTEM.DISCOVER_SESSIONS WHERE SESSION_STATUS = 1 ORDER BY SESSION_USER_NAME DESC";

        public ActiveSessionsPanel(ServerManager server)
        {
            InitializeComponent();
            this.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
| System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            myServer = server;
        }

        private void refreshUsersTable()
        {
            UserDataGrid.DataSource = myServer.ASMan.DataTableFromQuery(usersQuery);
            foreach (DataGridViewTextBoxColumn col in UserDataGrid.Columns)
            {
                col.ToolTipText = ActivityViewer.ProgramManager.GetToolTipText(col.HeaderText);
                                
            }
        }

        private void UsersRefreshTimer_Tick(object sender, EventArgs e)
        {
            refreshUsersTable();
        }

        private void ActiveSessionsPanel_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (myServer.dataRefreshInterval != 0)
                {
                    UsersRefreshTimer.Interval = myServer.dataRefreshInterval;
                    UsersRefreshTimer.Start();
                }
                refreshUsersTable();
                UserDataGrid.AutoResizeColumns();
            }
            else
            {
                if (myServer.dataRefreshInterval != 0)
                UsersRefreshTimer.Stop();
            }
        }

        private void CancelUsersButton_Click(object sender, EventArgs e)
        {
            try
            {
                myServer.ASMan.CancelSession((int)UserDataGrid.SelectedRows[0].Cells["SESSION_SPID"].Value);
                refreshUsersTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            refreshUsersTable();
        }
    }
}
