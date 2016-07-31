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

namespace Microsoft.AnalysisServices.Samples.ActivityViewer
{
    public partial class CurrentStateOverviewPanel : UserControl
    {
        ServerManager myServer;

        public CurrentStateOverviewPanel(ServerManager server)
        {
            myServer = server;
            InitializeComponent();
            this.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
         | System.Windows.Forms.AnchorStyles.Left)| System.Windows.Forms.AnchorStyles.Right)));
           
            this.DetailsButton.Enabled = false;
            this.RemoveAlertButton.Enabled = false;
        }

        private void RefreshAlerts()
        {
            try
            {
                int selected;
                if (AlertGrid.CurrentRow != null)
                {
                    selected = AlertGrid.CurrentRow.Index;
                }
                else
                    selected = -1;

                DataGridViewColumn column = AlertGrid.SortedColumn;
                bool desc = true;
                if (column != null)
                    desc = column.HeaderCell.SortGlyphDirection.Equals(SortOrder.Descending);

                AlertGrid.Rows.Clear();
                foreach (Alert a in myServer.alerts)
                {
                    AlertGrid.Rows.Add(GetAlertRow(a));
                }

                if (column != null)
                    AlertGrid.Sort(column, (desc ? ListSortDirection.Descending : ListSortDirection.Ascending));
                if (selected >= 0)
                    AlertGrid.CurrentCell = AlertGrid.Rows[selected].Cells[0];

                if (AlertGrid.Rows.Count > 0)
                {
                    this.DetailsButton.Enabled = true;
                    this.RemoveAlertButton.Enabled = true;
                }

                foreach (DataGridViewTextBoxColumn col in AlertGrid.Columns)
                {
                    switch (col.HeaderText)
                    {
                        case "Violator":
                            col.ToolTipText = "Name of the user associated with violation of specified rule";
                            break;
                        case "Priority":
                            col.ToolTipText = "Priority for rule condition assigned during the creation of rule";
                            break;
                        case "Condition":
                            col.ToolTipText = "Text of rule condition that is violated";
                            break;
                        default:
                            break;
                    }
                }
            }
            catch { }
        }

        private static object[] GetAlertRow(Alert alert)
        {
            object[] row = new object[3];
            row[0] = alert.violator;
            row[1] = alert.priority.ToString() + " - " + Rule.PriorityToString(alert.priority);
            row[2] = alert;

            return row;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshAlerts();
        }

        private void RemoveAlertButton_Click(object sender, EventArgs e)
        {
            try
            {
                myServer.alerts.Remove((Alert)AlertGrid.CurrentRow.Cells[2].Value);
                AlertGrid.Rows.Remove(AlertGrid.CurrentRow);
            }
            catch
            {
            }
        }

        private void CurrentStateOverviewPanel_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                RefreshAlerts();
                AlertRefreshTimer.Start();
            }
            else
                AlertRefreshTimer.Stop();
            
        }

        private void DetailsButton_Click(object sender, EventArgs e)
        {
            try
            {
                ServerTab.AlertDetailForm adf = new Microsoft.AnalysisServices.Samples.ActivityViewer.ServerTab.AlertDetailForm((Alert)AlertGrid.CurrentRow.Cells[2].Value);
                adf.ShowDialog();
            }
            catch { }
        }

        private void AlertGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DetailsButton_Click(null, null);
        }
    }
}
