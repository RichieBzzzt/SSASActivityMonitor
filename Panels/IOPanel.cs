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
    public partial class SnapshotIOPanel : UserControl
    {
        ServerManager myServer;
        private string IOQuery = "select SESSION_SPID, SESSION_READS, SESSION_READ_KB, SESSION_WRITES, SESSION_WRITE_KB, SESSION_ID from $system.DISCOVER_SESSIONS order by SESSION_SPID";

        public SnapshotIOPanel(ServerManager server)
        {
            InitializeComponent();
            this.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
| System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            IODataGrid.CellFormatting +=
            new System.Windows.Forms.DataGridViewCellFormattingEventHandler(
            this.IODataGrid_CellFormatting);
            myServer = server;
        }

        private void IODataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (this.IODataGrid.Columns[e.ColumnIndex].Name == "SESSION_READ_KB" || this.IODataGrid.Columns[e.ColumnIndex].Name == "SESSION_WRITE_KB")
            {
                string IoReadMemory;
                IoReadMemory = Convert.ToString(e.Value);
                e.Value = string.Format("{0}KB", IoReadMemory);
            }
        }

        private void refreshIOTable()
        {
            IODataGrid.DataSource = myServer.ASMan.DataTableFromQuery(IOQuery);
            foreach (DataGridViewTextBoxColumn col in IODataGrid.Columns)
            {
                col.ToolTipText = ActivityViewer.ProgramManager.GetToolTipText(col.HeaderText);
               
            }
            IODataGrid.AutoResizeColumns();
        }

        private void IORefreshTimer_Tick(object sender, EventArgs e)
        {
            refreshIOTable();
        }

        private void SnapshotIOPanel_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (myServer.dataRefreshInterval != 0)
                {
                    IORefreshTimer.Interval = myServer.dataRefreshInterval;
                    IORefreshTimer.Start();
                }
                refreshIOTable();
                IODataGrid.AutoResizeColumns();
            }
            else
            {
                if (myServer.dataRefreshInterval != 0)
                    IORefreshTimer.Stop();
            }
        }

        private void CancelIOButton_Click(object sender, EventArgs e)
        {
            try
            {
                myServer.ASMan.CancelSession((int)IODataGrid.SelectedRows[0].Cells["SESSION_SPID"].Value);
                refreshIOTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            refreshIOTable();
        }
    }
}
