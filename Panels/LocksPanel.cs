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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Microsoft.AnalysisServices.Samples.ActivityViewer.Panels
{
    public partial class LocksPanel : UserControl
    {
        ServerManager myServer;
        private string lockQuery = "select * from $System.discover_locks ORDER BY LOCK_CREATION_TIME DESC";
        
        public LocksPanel(ServerManager server)
        {
            InitializeComponent();
            myServer = server;
            this.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
| System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        }

        private void refreshLockTable()
        {
            LockDataGrid.DataSource = myServer.ASMan.DataTableFromQuery(lockQuery);
            foreach (DataGridViewTextBoxColumn col in LockDataGrid.Columns)
            {
                col.ToolTipText = ActivityViewer.ProgramManager.GetToolTipText(col.HeaderText);
            }
            LockDataGrid.AutoResizeColumns();
        }

        private void LockRefreshTimer_Tick(object sender, EventArgs e)
        {
            refreshLockTable();
        }

        private void LocksPanel_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (myServer.dataRefreshInterval != 0)
                {
                    LockRefreshTimer.Interval = myServer.dataRefreshInterval;
                    LockRefreshTimer.Start();
                }
                refreshLockTable();
                LockDataGrid.AutoResizeColumns();
            }
            else
            {
                if (myServer.dataRefreshInterval != 0)
                    LockRefreshTimer.Stop();
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            refreshLockTable();

        } 
    }
}
