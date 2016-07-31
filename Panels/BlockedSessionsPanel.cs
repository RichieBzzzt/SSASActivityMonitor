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
using System.IO;

namespace Microsoft.AnalysisServices.Samples.ActivityViewer
{
    public partial class SnapshotBlockedSessionsPanel : UserControl
    {
        ServerManager myServer;
        private string blockedQuery = "SELECT SESSION_SPID,SESSION_USER_NAME,SESSION_START_TIME, SESSION_ELAPSED_TIME_MS, SESSION_CPU_TIME_MS,SESSION_ID FROM $SYSTEM.DISCOVER_SESSIONS WHERE SESSION_STATUS =  2ORDER BY SESSION_USER_NAME DESC";

        public SnapshotBlockedSessionsPanel(ServerManager server)
        {
            InitializeComponent();
            this.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            myServer = server;
            this.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
| System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            BlockedDataGrid.CellFormatting +=
            new System.Windows.Forms.DataGridViewCellFormattingEventHandler(
            this.BlockedDataGrid_CellFormatting);
        }

        private void BlockedDataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.BlockedDataGrid.Columns[e.ColumnIndex].Name == "SESSION_IDLE_TIME_MS")
            {
                if (e.Value != null)
                {
                    double result;
                    result = Convert.ToDouble(e.Value);
                    TimeSpan t = TimeSpan.FromMilliseconds(result);
                    e.Value = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                t.Hours,
                t.Minutes,
                t.Seconds,
                t.Milliseconds);
                }
            }
            if (this.BlockedDataGrid.Columns[e.ColumnIndex].Name == "SESSION_USED_MEMORY")
            {
                string SessionUsedMemory;
                SessionUsedMemory = Convert.ToString(e.Value);
                e.Value = string.Format("{0}KB", SessionUsedMemory);
            }
        }

        private void refreshBlockedTable()
        {
            BlockedDataGrid.DataSource = myServer.ASMan.DataTableFromQuery(blockedQuery);
            foreach (DataGridViewTextBoxColumn col in BlockedDataGrid.Columns)
            {
                col.ToolTipText = ActivityViewer.ProgramManager.GetToolTipText(col.HeaderText);

            }
        }

        private void BlockedRefreshTimer_Tick(object sender, EventArgs e)
        {
            refreshBlockedTable();
        }
        private void SnapshotBlockedSessionsPanel_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (myServer.dataRefreshInterval != 0)
                {
                    BlockedRefreshTimer.Interval = myServer.dataRefreshInterval;
                    BlockedRefreshTimer.Start();
                }
                refreshBlockedTable();
                BlockedDataGrid.AutoResizeColumns();
            }
            else
            {
                if (myServer.dataRefreshInterval != 0)
                    BlockedRefreshTimer.Stop();
            }
        }

        private void CancelBlockedSessionButton_Click(object sender, EventArgs e)
        {
            try
            {
                myServer.ASMan.CancelSession((int)BlockedDataGrid.SelectedRows[0].Cells["SESSION_SPID"].Value);
                refreshBlockedTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshBlocked_Click(object sender, EventArgs e)
        {
            RefreshBlocked.Enabled = false;
            CancelBlockedSessionButton.Enabled = false;
            refreshBlockedTable();
            RefreshBlocked.Enabled = true;
            CancelBlockedSessionButton.Enabled = true;
        }

        private void DormantDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BlockedDataGrid.ContextMenuStrip = contextMenuStrip1;
        }

        private void copyBlockedCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DormantCopyToClipboard();
        }

        private void DormantCopyToClipboard()
        {

            if (this.BlockedDataGrid.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                //Copy to clipboard
                Clipboard.SetDataObject(this.BlockedDataGrid.SelectedRows[0].Cells["SESSION_LAST_COMMAND"].Value);
            }
        }

        private void saveBlockedCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog Blockedsfd = new SaveFileDialog();
            Blockedsfd.Filter = "XMLA|*.xmla|MDX|*.mdx|DMX|*.dmx|All Files|*.*";
            if (Blockedsfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = Blockedsfd.FileName;
                BinaryWriter dormantbw = new BinaryWriter(File.Create(path));
                if (this.BlockedDataGrid.GetCellCount(DataGridViewElementStates.Selected) > 0)
                {
                    dormantbw.Write(this.BlockedDataGrid.CurrentRow.Cells["SESSION_LAST_COMMAND"].Value.ToString());
                    dormantbw.Close();
                }

            }

        }

    }
}
