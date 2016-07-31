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
    public partial class CurrentQueriesPanel : UserControl
    {
        ServerManager myServer;
        private string queriesQuery = "SELECT SESSION_SPID, COMMAND_CPU_TIME_MS, COMMAND_ELAPSED_TIME_MS, COMMAND_READ_KB, COMMAND_WRITE_KB, COMMAND_TEXT FROM $system.DISCOVER_COMMANDS WHERE COMMAND_ELAPSED_TIME_MS > 0 ORDER BY COMMAND_CPU_TIME_MS DESC";

        public CurrentQueriesPanel(ServerManager server)
        {
            InitializeComponent();
            this.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
| System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            myServer = server;
            QueriesDataGrid.CellFormatting +=
            new System.Windows.Forms.DataGridViewCellFormattingEventHandler(
            this.QueriesDataGrid_CellFormatting);
        }

        private void QueriesDataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.QueriesDataGrid.Columns[e.ColumnIndex].Name == "COMMAND_ELAPSED_TIME_MS" || this.QueriesDataGrid.Columns[e.ColumnIndex].Name == "COMMAND_CPU_TIME_MS")
            {
                if (e.Value != null)
                {
                    double TimeElapsed;
                    TimeElapsed = Convert.ToDouble(e.Value);
                    TimeSpan t = TimeSpan.FromMilliseconds(TimeElapsed);
                    e.Value = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                t.Hours,
                t.Minutes,
                t.Seconds,
                t.Milliseconds);
                }
            }
            if (this.QueriesDataGrid.Columns[e.ColumnIndex].Name == "COMMAND_READ_KB" || this.QueriesDataGrid.Columns[e.ColumnIndex].Name == "COMMAND_WRITE_KB")
            {
                string CommandReadWriteKb;
                CommandReadWriteKb = Convert.ToString(e.Value);
                e.Value = string.Format("{0}KB", CommandReadWriteKb);
            }
        }

        private void refreshQueriesTable()
        {
            QueriesDataGrid.DataSource = myServer.ASMan.DataTableFromQuery(queriesQuery);
            foreach (DataGridViewTextBoxColumn col in QueriesDataGrid.Columns)
            {
                col.ToolTipText = ActivityViewer.ProgramManager.GetToolTipText(col.HeaderText);
            }
            QueriesDataGrid.AutoResizeColumns();
        }

        private void QueriesRefreshTimer_Tick(object sender, EventArgs e)
        {
            refreshQueriesTable();
        }

        private void CurrentQueriesPanel_VisibleChanged(object sender, EventArgs e)
        {

            if (this.Visible)
            {
                if (myServer.dataRefreshInterval != 0)
                {
                    QueriesRefreshTimer.Interval = myServer.dataRefreshInterval;
                    QueriesRefreshTimer.Start();
                }
                refreshQueriesTable();
                QueriesDataGrid.AutoResizeColumns();
            }
            else
            {
                if (myServer.dataRefreshInterval != 0)
                    QueriesRefreshTimer.Stop();
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshButton.Enabled = false;
            CancelButton.Enabled = false;
            QueriesDataGrid.Enabled = false;
            refreshQueriesTable();
            QueriesDataGrid.Enabled = true;
            RefreshButton.Enabled = true;
            CancelButton.Enabled = true;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            myServer.ASMan.CancelSession((int)QueriesDataGrid.CurrentRow.Cells["SESSION_SPID"].Value);
        }

        private void QueriesDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            QueriesDataGrid.ContextMenuStrip = contextMenuStrip1;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyToClipboard();
        }

        private void CopyToClipboard()
        {

            if (this.QueriesDataGrid.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                //Copy to clipboard
                Clipboard.SetDataObject(this.QueriesDataGrid.CurrentRow.Cells["COMMAND_TEXT"].Value);
            }
        }

        private void SaveCommandText_Click(object sender, EventArgs e)
        {

        }

        private void saveCommandTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XMLA|*.xmla|MDX|*.mdx|DMX|*.dmx|All Files|*.*";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = sfd.FileName;
                BinaryWriter bw = new BinaryWriter(File.Create(path));
                if (this.QueriesDataGrid.GetCellCount(DataGridViewElementStates.Selected) > 0)
                {
                    bw.Write(this.QueriesDataGrid.CurrentRow.Cells["COMMAND_TEXT"].Value.ToString());
                    bw.Close();
                }

            }
            
        }
    }
}
