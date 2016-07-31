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
using Microsoft.AnalysisServices.Samples.ActivityViewer;
using System.Threading;

namespace Microsoft.AnalysisServices.Samples.ActivityViewer
{

    public partial class ActivityViewerForm : Form
    {
        /// <summary>
        /// The program manager object for this program
        /// </summary>
        /// making it static to be accessible anywhere...seems to work, not too sure about it
        internal static ProgramManager pm;

        public ActivityViewerForm()
        {
            pm = new ProgramManager();
            InitializeComponent();
            //install any servers loaded in initialization into the UI
            pm.InitializeProgram();
            foreach (ServerManager sm in pm.servers)
                InstallExistingServer(sm);

            foreach (DataGridViewTextBoxColumn col in ConnectionDataGrid.Columns)
            {
                if (col.HeaderText == "Connection")
                    col.ToolTipText = "Name of the server connection";
                else if (col.HeaderText == "IO Read KB")
                    col.ToolTipText = "Size of distinct input/output reads measured in KB for this connection";
                else if (col.HeaderText == "IO Write KB")
                    col.ToolTipText = "Size of distinct input/output writes measured in KB for this connection";
                else if (col.HeaderText == "Memory")
                    col.ToolTipText = "Size of the memory currently used by session";
                else if (col.HeaderText == "CPU")
                    col.ToolTipText = "Size of CPU usage consumed by the user";
            }

            EditInstanceOverview.Enabled = false;
            DeleteInstanceOverview.Enabled = false;
            AllAlertsDetailsButton.Enabled = false;

            AllAlertsTimer.Start();
        }

        /// <summary>
        /// Installs a new server into the program with the given connection string
        /// </summary>
        /// <param name="connectionString">The connection string to connect to server with</param>
        public void InstallNewServer(string connectionString)
        {
            ServerManager sm = new ServerManager(connectionString);

            ServerControl newTab = new ServerControl(sm);
            pm.AddServer(newTab.serverMan);
            newTab.serverMan.Connect();

            //Add the new tab and connect to the server
            ConnectionDataGrid.Rows.Add(GetServerRow(sm));
            MainTabControl.TabPages.Add(newTab);
        }

        /// <summary>
        /// Installs an existing Servermanager into the UI
        /// </summary>
        /// <param name="sm">The ServerManager to install</param>
        public void InstallExistingServer(ServerManager sm)
        {
            ServerControl newTab = new ServerControl(sm);

            //add tab and list box items
            ConnectionDataGrid.Rows.Add(GetServerRow(sm));
            MainTabControl.TabPages.Add(newTab);
        }

        private static object[] GetServerRow(ServerManager sm)
        {
            DataTable theData = sm.ASMan.DataTableFromQuery("SELECT SESSION_CPU_TIME_MS, SESSION_USED_MEMORY, SESSION_READ_KB, SESSION_WRITE_KB from $System.DISCOVER_SESSIONS");
            object[] row = new object[5];
            row[0] = sm.Name;
            row[1] = (int)0;
            row[2] = (decimal)0;
            row[3] = (decimal)0;
            row[4] = (decimal)0;

            foreach (DataRow urow in theData.Rows)
                {
                    row[1] = (int)row[1] + (int)urow["SESSION_USED_MEMORY"];
                    row[2] = (decimal)row[2] + (decimal)urow["SESSION_CPU_TIME_MS"];
                    row[3] = (decimal)row[3] + (decimal)urow["SESSION_READ_KB"];
                    row[4] = (decimal)row[4] + (decimal)urow["SESSION_WRITE_KB"];
                }

            return row;
        }

        /// <summary>
        /// Callback function for New Instance button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewInstanceOverview_Click(object sender, EventArgs e)
        {
            NewInstanceForm newInstancePopup = new NewInstanceForm(this);
            newInstancePopup.ShowDialog();
        }

        /// <summary>
        /// Callback function for Edit Instance button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditInstanceOverview_Click(object sender, EventArgs e)
        {
            int index = ConnectionDataGrid.CurrentRow.Index;
            if (index < 0)
            {
                MessageBox.Show("Please select an instance to edit.", "Edit Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Grab server control from tab list and pass it to new form to manipulate
                ServerControl sc = (ServerControl)MainTabControl.TabPages[index+1];
                EditInstanceForm editInstancePopup = new EditInstanceForm(sc);
                
                editInstancePopup.ShowDialog();

                //Reflect changes to the ServerControl in the list box
                //ConnectionDataGrid.Rows.RemoveAt(index);
                //ConnectionDataGrid.Rows.Insert(index, GetServerRow(sc.serverMan));
                ConnectionDataGrid.Rows[index].SetValues(GetServerRow(sc.serverMan));
            }
        }

        /// <summary>
        /// Callback function for the delete instance button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteInstanceOverview_Click(object sender, EventArgs e)
        {
            //disclaimer
            if (MessageBox.Show("Removing a connection will delete any rules and alerts on it, are you sure you want to continue?", "Warning", MessageBoxButtons.YesNo).Equals(DialogResult.No))
                return;

            int index = ConnectionDataGrid.CurrentRow.Index;
            
            try
            {
                ServerControl sc = (ServerControl)MainTabControl.TabPages[index + 1];
                // checks to see if a listbox item is selected
                //remove server control from tab list and list box and its server manager from the PM
                ConnectionDataGrid.Rows.RemoveAt(index);
                MainTabControl.TabPages.RemoveAt(index +1);
                pm.RemoveServer(sc.serverMan);
            }
            catch
            {
                MessageBox.Show("Please select an instance to delete.", "Delete Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Callback function upon closing the main form.
        /// Performs program manager end routines before closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActivityViewerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //call PM termination routines before closing
            pm.TerminateProgram();
        }

        /// <summary>
        /// Calls the form to change the refresh rate for rules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshRateOverviewButton_Click(object sender, EventArgs e)
        {
            RefreshRateForm refreshRatePopup = new RefreshRateForm();
            refreshRatePopup.ShowDialog();  
        }

        /// <summary>
        /// Installs some default rules on a new connection
        /// </summary>
        /// <param name="sm">the server to install rules on</param>
        private static void InstallDefaultRules(ServerManager sm)
        {
            sm.RuleMan.AddRule("IF SESSION_CPU_TIME_MS > 10000 THEN KILL AND ALERT");
            sm.RuleMan.AddRule("IF SESSION_COMMAND_COUNT >= 100 THEN ALERT");
        }

        /// <summary>
        /// Callback funtion for alerts timer to refresh all alerts box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllAlertsTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                //gather as much state data as possible
                int selected;
                if (AllAlertsGrid.CurrentRow != null)
                    selected = AllAlertsGrid.CurrentRow.Index;
                else
                    selected = -1;

                DataGridViewColumn column = AllAlertsGrid.SortedColumn;
                bool desc = true;
                if (column != null)
                    desc = column.HeaderCell.SortGlyphDirection.Equals(SortOrder.Descending);

                //refresh the grid
                AllAlertsGrid.Rows.Clear();
                foreach (ServerManager sm in pm.servers)
                {
                    foreach (Alert a in sm.alerts)
                    {
                        AllAlertsGrid.Rows.Add(GetAlertRow(a));
                    }
                }

                //restore state it was in before refresh
                if (column != null)
                    AllAlertsGrid.Sort(column, (desc ? ListSortDirection.Descending : ListSortDirection.Ascending));
                if (selected >= 0)
                    AllAlertsGrid.CurrentCell = AllAlertsGrid.Rows[selected].Cells[0];

                
                foreach (DataGridViewTextBoxColumn col in AllAlertsGrid.Columns)
                {
                    if (col.HeaderText == "Violator")
                        col.ToolTipText = "Name of the user associated with violation of specified rule";
                    else if (col.HeaderText == "Priority")
                        col.ToolTipText = "Priority for rule condition assigned during the creation of rule";
                    else if (col.HeaderText == "Condition")
                        col.ToolTipText = "Text of rule condition that is violated";
                    else if (col.HeaderText == "Server")
                        col.ToolTipText = "Server connection associated with rule";
                }
            }
            catch { }
        }

        /// <summary>
        /// Helper function to turn an alert into a row for display
        /// </summary>
        /// <param name="alert">the alert to convert</param>
        /// <returns>an array of objects to place into a new row</returns>
        private static object[] GetAlertRow(Alert alert)
        {
            object[] row = new object[4];
            row[0] = alert.server.Name;
            row[1] = alert.violator;
            row[2] = alert.priority.ToString() + " - " + Rule.PriorityToString(alert.priority);
            row[3] = alert;

            return row;
        }

        /// <summary>
        /// Shows details about the selected alert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllAlertsDetailsButton_Click(object sender, EventArgs e)
        {
            try
            {
                ServerTab.AlertDetailForm adf = new Microsoft.AnalysisServices.Samples.ActivityViewer.ServerTab.AlertDetailForm((Alert)AllAlertsGrid.CurrentRow.Cells[3].Value);
                adf.ShowDialog();
            }
            catch { }
        }

        /// <summary>
        /// stops the timer when panel is no longer visible, and starts it again when it is.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllAlertsList_VisibleChanged(object sender, EventArgs e)
        {
            if (AllAlertsGrid.Visible)
            {
                ConnectionRefreshTimer_Tick(null, null);
                AllAlertsTimer.Start();
                ConnectionRefreshTimer.Start();
            }
            else
            {
                AllAlertsTimer.Stop();
                ConnectionRefreshTimer.Stop();
            }
        }

        /// <summary>
        /// selects tab corresponding to double clicked row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectionDataGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MainTabControl.SelectedIndex = ConnectionDataGrid.CurrentRow.Index + 1;
        }

        /// <summary>
        /// Refreshes the server metadata in the overview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectionRefreshTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < ConnectionDataGrid.Rows.Count; i++)
                ConnectionDataGrid.Rows[i].SetValues(GetServerRow(((ServerControl)MainTabControl.TabPages[i]).serverMan));
        }

        /// <summary>
        /// Lets you view details by double clicking an alert's row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllAlertsGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            AllAlertsDetailsButton_Click(null, null);
        }

        /// <summary>
        /// Callback function for exit item in menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Callback function for about item in menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Activity Viewer 2012 \n\nMaintained by Richard Lee\n"+
                            "\n\nBased on \n\nActivity Viewer 2008\n" +
                            "\nCreated by \nLuis Ballesteros\n"+
                            "Alli Curley\nMalini Jagannadhan\nMeera Srinivasan\n\n"+
                            "Microsoft Corporation","About", MessageBoxButtons.OK);
        }

        /// <summary>
        /// Disables or enables buttons depending on selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectionDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (ConnectionDataGrid.CurrentRow == null)
            {
                EditInstanceOverview.Enabled = false;
                DeleteInstanceOverview.Enabled = false;
            }
            else
            {
                EditInstanceOverview.Enabled = true;
                DeleteInstanceOverview.Enabled = true;
            }

        }

        /// <summary>
        /// Disables or enables buttons depending on selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllAlertsGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (AllAlertsGrid.CurrentRow == null)
            {
                AllAlertsDetailsButton.Enabled = false;
            }
            else
            {
                AllAlertsDetailsButton.Enabled = true;
            }

        }

    }
}
