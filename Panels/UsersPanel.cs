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
    public partial class UsersPanel : UserControl
    {
        ServerManager myServer;
        private int nested;

        public UsersPanel(ServerManager server)
        {
            InitializeComponent();
            myServer = server;
            this.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
         | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));

            BackButton.Hide();
            CancelButton.Hide();
        }


        private void RefreshUsers()
        {
            DataTable users = myServer.ASMan.DataTableFromQuery("SELECT DISTINCT SESSION_USER_NAME from $System.DISCOVER_SESSIONS");
            DataTable table = new DataTable();

            table.Columns.Add("User");
            table.Columns.Add("Sessions");
            table.Columns.Add("Active");
            table.Columns.Add("Memory");
            table.Columns.Add("CPU");
            table.Columns.Add("Read KB");
            table.Columns.Add("Write KB");



            foreach (DataRow row in users.Rows)
            {
                object[] rowElems = new object[7];
                DataTable userInfo = myServer.ASMan.DataTableFromQuery("SELECT * from $System.discover_sessions where SESSION_USER_NAME = '" + row["SESSION_USER_NAME"] + "'");

                rowElems[0] = row["SESSION_USER_NAME"];
                rowElems[1] = userInfo.Rows.Count;
                rowElems[2] = 0;
                rowElems[3] = 0;
                rowElems[4] = (decimal)0;
                rowElems[5] = (decimal)0;
                rowElems[6] = (decimal)0;

                foreach (DataRow urow in userInfo.Rows)
                {
                    if ((int)urow["SESSION_STATUS"] == 1)
                        rowElems[2] = (int)rowElems[2] + 1;
                    rowElems[3] = (int)rowElems[3] + (int)urow["SESSION_USED_MEMORY"];
                    rowElems[4] = (decimal)rowElems[4] + (decimal)urow["SESSION_CPU_TIME_MS"];
                    rowElems[5] = (decimal)rowElems[5] + (decimal)urow["SESSION_READ_KB"];
                    rowElems[6] = (decimal)rowElems[6] + (decimal)urow["SESSION_WRITE_KB"];
                }

                table.Rows.Add(rowElems);
            }

            this.UsersGrid.DataSource = table;

            foreach (DataGridViewTextBoxColumn col in UsersGrid.Columns)
            {
                col.ToolTipText = GetToolTipText(col.HeaderText);
            }

            this.UsersGrid.AutoResizeColumns();
        }


        private void UsersPanel_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (myServer.dataRefreshInterval != 0)
                {
                    UserRefreshTimer.Interval = myServer.dataRefreshInterval;
                    UserRefreshTimer.Start();
                }

                nested = 0;
                RefreshUsers();
                UsersGrid.AutoResizeColumns();

                this.CancelButton.Hide();
                this.BackButton.Hide();
                this.DetailsButton.Show();
            }
            else
            {
                if (myServer.dataRefreshInterval != 0)
                    UserRefreshTimer.Stop();
            }
        }

        private void DrillUsers()
        {
            if (nested == 0)
            {
                nested = 1;
                this.UsersGrid.DataSource = myServer.ASMan.DataTableFromQuery("SELECT * FROM $System.DISCOVER_SESSIONS WHERE SESSION_USER_NAME = '" +
                                                    this.UsersGrid.SelectedRows[0].Cells["User"].Value + "'");
                this.UsersGrid.AutoResizeColumns();
                this.CancelButton.Show();
                this.BackButton.Show();
                this.DetailsButton.Hide();
            }
            else
            {
                nested = 0;
                this.CancelButton.Hide();
                this.BackButton.Hide();
                this.DetailsButton.Show();
                RefreshUsers();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                myServer.ASMan.CancelSession((int)this.UsersGrid.SelectedRows[0].Cells["SESSION_SPID"].Value);

                this.UsersGrid.DataSource = myServer.ASMan.DataTableFromQuery("SELECT * FROM $System.DISCOVER_SESSIONS WHERE SESSION_USER_NAME = '" +
                                                    this.UsersGrid.SelectedRows[0].Cells["SESSION_USER_NAME"].Value + "'");
                this.UsersGrid.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DetailsButton_Click(object sender, EventArgs e)
        {
            if (this.UsersGrid.CurrentRow == null)
            {
                MessageBox.Show("Please select a row to view details for");
                return;
            }
            this.DrillUsers();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.DrillUsers();
        }


        private void RecentQueriesGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.DrillUsers();
        }

        private void UserRefreshTimer_Tick(object sender, EventArgs e)
        {
            if(nested==0)
                this.RefreshUsers();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            nested = 0;
            BackButton.Hide();
            CancelButton.Hide();
            DetailsButton.Show();
            this.RefreshUsers();

        }

        private static string GetToolTipText(string header)
        {
            switch (header)
            {
                case "User":
                    return "Name of the user associated with session";
                case "Read KB":
                    return "Size of distinct reads measured in KB collected for the session";
                case "Write KB":
                    return "Size of distinct writes measured in KB collected for the session";
                case "Memory":
                    return "Size of the memory currently used by session";
                case "CPU":
                    return "Size of CPU usage consumed by the user";
                case "Active":
                    return "1 if the status of user is Active";
                case "Sessions":
                    return "Number of sessions consumed by all requests by the user";
                default:
                    return "";
            }
        }
    }
}
