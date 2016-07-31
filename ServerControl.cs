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
    public partial class ServerControl : TabPage
    {
        private UserControl[] panelArray;
        private ToolStripMenuItem[] toolStripMenuItem;
        internal ServerManager serverMan;

        /// <summary>
        /// Creates a new ServerControl Tab from a connection string
        /// </summary>
        /// <param name="connection">The connection string for this server tab</param>
        public ServerControl(string connection)
        {
            serverMan = new ServerManager(connection);

            InitializeComponent();
            this.Text = this.Name = serverMan.Name;

            panelArray = new UserControl[11] { alertsPanel, activeSessionsPanel,
                                              currentQueriesPanel, snapshotDormantSessionsPanel,SnapshotBlockedSessionsPanel,
                                              snapshotCPUPanel, snapshotIOPanel, snapshotObjectsPanel,
                                              locksPanel, rulesPanel, usersPanel};
            this.Controls.AddRange(panelArray);
            hideAllPanels();
            panelArray[0].Show();

            toolStripMenuItem = new ToolStripMenuItem[11] { AlertsToolStripMenuItem, ActiveSessionsToolStripMenuItem,
                                                            CurrentQueriesToolStripMenuItem, DormantSessionsToolStripMenuItem,
                                                            BlockedSessionsToolStripMenuItem,
                                                            CPUToolStripMenuItem, IOToolStripMenuItem,
                                                            ObjectsToolStripMenuItem, LocksToolStripMenuItem,
                                                            RulesToolStripMenuItem, UsersToolStripMenuItem};
        }

        /// <summary>
        /// Creates a new Server Control tab from an existing ServerManager
        /// </summary>
        /// <param name="sc">the server manager for this server control</param>
        public ServerControl(ServerManager sc)
        {
            serverMan = sc;

            InitializeComponent();
            this.Text = this.Name = sc.Name;

            foreach (Rule rule in serverMan.RuleMan.GetRules())
                rulesPanel.GuiExistingRule(rule);

            panelArray = new UserControl[11] { alertsPanel, activeSessionsPanel,
                                              currentQueriesPanel, snapshotDormantSessionsPanel, 
                                              SnapshotBlockedSessionsPanel,
                                              snapshotCPUPanel, snapshotIOPanel, snapshotObjectsPanel,
                                              locksPanel, rulesPanel, usersPanel};
            
            this.Controls.AddRange(panelArray);
            hideAllPanels();
            panelArray[0].Show();

            toolStripMenuItem = new ToolStripMenuItem[11] { AlertsToolStripMenuItem, ActiveSessionsToolStripMenuItem,
                                                            CurrentQueriesToolStripMenuItem, DormantSessionsToolStripMenuItem, 
                                                            BlockedSessionsToolStripMenuItem,
                                                            CPUToolStripMenuItem, IOToolStripMenuItem,
                                                            ObjectsToolStripMenuItem, LocksToolStripMenuItem,
                                                            RulesToolStripMenuItem, UsersToolStripMenuItem};
        }
        ~ServerControl()
        {
            if(serverMan!=null)
                serverMan.Dispose();
        }

        private void hideAllPanels()
        {
            foreach (UserControl uc in panelArray)
                uc.Visible = false;
        }

        private void hideAllColors()
        {
            foreach (ToolStripMenuItem tsmi in toolStripMenuItem)
                tsmi.BackColor = Color.Transparent;
        }

        private void AlertsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            hideAllColors();
            panelArray[0].Visible = true;
            AlertsToolStripMenuItem.BackColor = Color.LightGray;
        }

        private void ActiveSessionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            hideAllColors();
            panelArray[1].Visible = true;
            ActiveSessionsToolStripMenuItem.BackColor = Color.LightGray;
        }

        private void UsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            hideAllColors();
            panelArray[9].Visible = true;
            UsersToolStripMenuItem.BackColor = Color.LightGray;
        }
        private void CurrentQueriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            hideAllColors();
            panelArray[2].Visible = true;
            CurrentQueriesToolStripMenuItem.BackColor = Color.LightGray;
        }

        private void DormantSessionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            hideAllColors();
            panelArray[3].Visible = true;
            DormantSessionsToolStripMenuItem.BackColor = Color.LightGray;
        }

        private void BlockedSessionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            hideAllColors();
            panelArray[4].Visible = true;
            BlockedSessionsToolStripMenuItem.BackColor = Color.LightGray;
        }

        private void CPUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            hideAllColors();
            panelArray[5].Visible = true;
            CPUToolStripMenuItem.BackColor = Color.LightGray;
        }

        private void IOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            hideAllColors();
            panelArray[6].Visible = true;
            IOToolStripMenuItem.BackColor = Color.LightGray;
        }

        private void ObjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            hideAllColors();
            panelArray[7].Visible = true;
            ObjectsToolStripMenuItem.BackColor = Color.LightGray;
        }

        private void LocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            hideAllColors();
            panelArray[8].Visible = true;
            LocksToolStripMenuItem.BackColor = Color.LightGray;
        }

        private void RulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            hideAllColors();
            panelArray[9].Visible = true;
            RulesToolStripMenuItem.BackColor = Color.LightGray;
        }
    }
}
