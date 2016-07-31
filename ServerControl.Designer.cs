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
    partial class ServerControl : TabPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.AlertsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ActiveSessionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CurrentQueriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DormantSessionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BlockedSessionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CPUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LocksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rulesPanel = new Microsoft.AnalysisServices.Samples.ActivityViewer.Panels.RulesPanel(this.serverMan);
            this.locksPanel = new Microsoft.AnalysisServices.Samples.ActivityViewer.Panels.LocksPanel(this.serverMan);
            this.snapshotObjectsPanel = new Microsoft.AnalysisServices.Samples.ActivityViewer.Panels.SnapshotObjectsPanel(this.serverMan);
            this.snapshotIOPanel = new Microsoft.AnalysisServices.Samples.ActivityViewer.Panels.SnapshotIOPanel(this.serverMan);
            this.snapshotCPUPanel = new Microsoft.AnalysisServices.Samples.ActivityViewer.SnapshotCPUPanel(this.serverMan);
            this.currentQueriesPanel = new Microsoft.AnalysisServices.Samples.ActivityViewer.CurrentQueriesPanel(this.serverMan);
            this.alertsPanel = new Microsoft.AnalysisServices.Samples.ActivityViewer.CurrentStateOverviewPanel(this.serverMan);
            this.activeSessionsPanel = new Microsoft.AnalysisServices.Samples.ActivityViewer.ActiveSessionsPanel(this.serverMan);
            this.snapshotDormantSessionsPanel = new Microsoft.AnalysisServices.Samples.ActivityViewer.SnapshotDormantSessionsPanel(this.serverMan);
            this.usersPanel = new Microsoft.AnalysisServices.Samples.ActivityViewer.Panels.UsersPanel(this.serverMan);
            this.SnapshotBlockedSessionsPanel = new Microsoft.AnalysisServices.Samples.ActivityViewer.SnapshotBlockedSessionsPanel(this.serverMan);
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AlertsToolStripMenuItem,
            this.UsersToolStripMenuItem,
            this.ActiveSessionsToolStripMenuItem,
            this.CurrentQueriesToolStripMenuItem,
            this.DormantSessionsToolStripMenuItem,
            this.BlockedSessionsToolStripMenuItem,
            this.CPUToolStripMenuItem,
            this.IOToolStripMenuItem,
            this.ObjectsToolStripMenuItem,
            this.LocksToolStripMenuItem,
            this.RulesToolStripMenuItem});
            this.MenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(128, 452);
            this.MenuStrip.TabIndex = 3;
            this.MenuStrip.Text = "MenuStrip";
            this.MenuStrip.BackColor = this.BackColor;
            // 
            // AlertsToolStripMenuItem
            // 
            this.AlertsToolStripMenuItem.Name = "AlertsToolStripMenuItem";
            this.AlertsToolStripMenuItem.Size = new System.Drawing.Size(95, 19);
            this.AlertsToolStripMenuItem.Text = "Alerts";
            this.AlertsToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AlertsToolStripMenuItem.BackColor = Color.LightGray;
            this.AlertsToolStripMenuItem.Click += new System.EventHandler(this.AlertsToolStripMenuItem_Click);
            // 
            // ActiveSessionsToolStripMenuItem
            // 
            this.ActiveSessionsToolStripMenuItem.Name = "ActiveSessionsToolStripMenuItem";
            this.ActiveSessionsToolStripMenuItem.Size = new System.Drawing.Size(56, 19);
            this.ActiveSessionsToolStripMenuItem.Text = "Active Sessions";
            this.ActiveSessionsToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ActiveSessionsToolStripMenuItem.Click += new System.EventHandler(this.ActiveSessionsToolStripMenuItem_Click);
            //
            // UsersToolStripMenuItem
            //
            this.UsersToolStripMenuItem.Name = "UsersToolStripMenuItem";
            this.UsersToolStripMenuItem.Size = new System.Drawing.Size(56, 19);
            this.UsersToolStripMenuItem.Text = "Users";
            this.UsersToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UsersToolStripMenuItem.Click += new System.EventHandler(this.UsersToolStripMenuItem_Click);
            // 
            // CurrentQueriesToolStripMenuItem
            // 
            this.CurrentQueriesToolStripMenuItem.Name = "CurrentQueriesToolStripMenuItem";
            this.CurrentQueriesToolStripMenuItem.Size = new System.Drawing.Size(111, 19);
            this.CurrentQueriesToolStripMenuItem.Text = "Current Queries";
            this.CurrentQueriesToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CurrentQueriesToolStripMenuItem.Click += new System.EventHandler(this.CurrentQueriesToolStripMenuItem_Click);
            // 
            // DormantSessionsToolStripMenuItem
            // 
            this.DormantSessionsToolStripMenuItem.Name = "DormantSessionsToolStripMenuItem";
            this.DormantSessionsToolStripMenuItem.Size = new System.Drawing.Size(122, 19);
            this.DormantSessionsToolStripMenuItem.Text = "Dormant Sessions";
            this.DormantSessionsToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DormantSessionsToolStripMenuItem.Click += new System.EventHandler(this.DormantSessionsToolStripMenuItem_Click);
            // 
            // BlockedSessionsToolStripMenuItem
            // 
            this.BlockedSessionsToolStripMenuItem.Name = "BlockedSessionsToolStripMenuItem";
            this.BlockedSessionsToolStripMenuItem.Size = new System.Drawing.Size(122, 19);
            this.BlockedSessionsToolStripMenuItem.Text = "Blocked Sessions";
            this.BlockedSessionsToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BlockedSessionsToolStripMenuItem.Click += new System.EventHandler(this.BlockedSessionsToolStripMenuItem_Click);
            // 
            // CPUToolStripMenuItem
            // 
            this.CPUToolStripMenuItem.Name = "CPUToolStripMenuItem";
            this.CPUToolStripMenuItem.Size = new System.Drawing.Size(51, 19);
            this.CPUToolStripMenuItem.Text = "CPU";
            this.CPUToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CPUToolStripMenuItem.Click += new System.EventHandler(this.CPUToolStripMenuItem_Click);
            // 
            // IOToolStripMenuItem
            // 
            this.IOToolStripMenuItem.Name = "IOToolStripMenuItem";
            this.IOToolStripMenuItem.Size = new System.Drawing.Size(45, 19);
            this.IOToolStripMenuItem.Text = "I/O";
            this.IOToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.IOToolStripMenuItem.Click += new System.EventHandler(this.IOToolStripMenuItem_Click);
            // 
            // ObjectsToolStripMenuItem
            // 
            this.ObjectsToolStripMenuItem.Name = "ObjectsToolStripMenuItem";
            this.ObjectsToolStripMenuItem.Size = new System.Drawing.Size(68, 19);
            this.ObjectsToolStripMenuItem.Text = "Objects";
            this.ObjectsToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ObjectsToolStripMenuItem.Click += new System.EventHandler(this.ObjectsToolStripMenuItem_Click);
            // 
            // LocksToolStripMenuItem
            // 
            this.LocksToolStripMenuItem.Name = "LocksToolStripMenuItem";
            this.LocksToolStripMenuItem.Size = new System.Drawing.Size(58, 19);
            this.LocksToolStripMenuItem.Text = "Locks";
            this.LocksToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LocksToolStripMenuItem.Click += new System.EventHandler(this.LocksToolStripMenuItem_Click);
            // 
            // RulesToolStripMenuItem
            // 
            this.RulesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.RulesToolStripMenuItem.Name = "RulesToolStripMenuItem";
            this.RulesToolStripMenuItem.Size = new System.Drawing.Size(49, 19);
            this.RulesToolStripMenuItem.Text = "Rules";
            this.RulesToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RulesToolStripMenuItem.Click += new System.EventHandler(this.RulesToolStripMenuItem_Click);
            // 
            // rulesPanel
            // 
            this.rulesPanel.Location = new System.Drawing.Point(136, 8);
            this.rulesPanel.Name = "rulesPanel";
            this.rulesPanel.Size = new System.Drawing.Size(496, 448);
            this.rulesPanel.TabIndex = 11;
            
            // 
            // locksPanel
            // 
            this.locksPanel.Location = new System.Drawing.Point(136, 8);
            this.locksPanel.Name = "locksPanel";
            this.locksPanel.Size = new System.Drawing.Size(496, 448);
            this.locksPanel.TabIndex = 9;
            // 
            // snapshotObjectsPanel
            // 
            this.snapshotObjectsPanel.Location = new System.Drawing.Point(136, 8);
            this.snapshotObjectsPanel.Name = "snapshotObjectsPanel";
            this.snapshotObjectsPanel.Size = new System.Drawing.Size(496, 448);
            this.snapshotObjectsPanel.TabIndex = 8;
            // 
            // snapshotIOPanel
            // 
            this.snapshotIOPanel.Location = new System.Drawing.Point(136, 8);
            this.snapshotIOPanel.Name = "snapshotIOPanel";
            this.snapshotIOPanel.Size = new System.Drawing.Size(496, 448);
            this.snapshotIOPanel.TabIndex = 7;
            // 
            // snapshotCPUPanel
            // 
            this.snapshotCPUPanel.Location = new System.Drawing.Point(136, 8);
            this.snapshotCPUPanel.Name = "snapshotCPUPanel";
            this.snapshotCPUPanel.Size = new System.Drawing.Size(496, 448);
            this.snapshotCPUPanel.TabIndex = 6;
            // 
            // currentQueriesPanel
            // 
            this.currentQueriesPanel.Location = new System.Drawing.Point(136, 8);
            this.currentQueriesPanel.Name = "currentQueriesPanel";
            this.currentQueriesPanel.Size = new System.Drawing.Size(496, 448);
            this.currentQueriesPanel.TabIndex = 3;
            // 
            // alertsPanel
            // 
            this.alertsPanel.Location = new System.Drawing.Point(136, 8);
            this.alertsPanel.Name = "alertsPanel";
            this.alertsPanel.Size = new System.Drawing.Size(496, 448);
            this.alertsPanel.TabIndex = 2;
            // 
            // activeSessionsPanel
            // 
            this.activeSessionsPanel.Location = new System.Drawing.Point(136, 8);
            this.activeSessionsPanel.Name = "activeSessionsPanel";
            this.activeSessionsPanel.Size = new System.Drawing.Size(496, 448);
            this.activeSessionsPanel.TabIndex = 1;
            //
            // usersPanel
            //
            this.usersPanel.Location = new System.Drawing.Point(136, 8);
            this.usersPanel.Name = "usersPanel";
            this.usersPanel.Size = new System.Drawing.Size(496,448);
            this.usersPanel.TabIndex = 11;
            // 
            // snapshotDormantSessionsPanel
            // 
            this.snapshotDormantSessionsPanel.Location = new System.Drawing.Point(136, 8);
            this.snapshotDormantSessionsPanel.Name = "snapshotDormantSessionsPanel";
            this.snapshotDormantSessionsPanel.Size = new System.Drawing.Size(496, 448);
            this.snapshotDormantSessionsPanel.TabIndex = 4;
            // 
            // snapshotDormantSessionsPanel
            // 
            this.SnapshotBlockedSessionsPanel.Location = new System.Drawing.Point(136, 8);
            this.SnapshotBlockedSessionsPanel.Name = "SnapshotBlockedSessionsPanel";
            this.SnapshotBlockedSessionsPanel.Size = new System.Drawing.Size(496, 448);
            this.SnapshotBlockedSessionsPanel.TabIndex = 5;
            // 
            // ServerControl
            // 
            this.Controls.Add(this.MenuStrip);
            this.Name = "ServerControl";
            this.Size = new System.Drawing.Size(627, 452);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.AnalysisServices.Samples.ActivityViewer.Panels.RulesPanel rulesPanel;
        private Microsoft.AnalysisServices.Samples.ActivityViewer.Panels.LocksPanel locksPanel;
        private Microsoft.AnalysisServices.Samples.ActivityViewer.Panels.SnapshotObjectsPanel snapshotObjectsPanel;
        private Microsoft.AnalysisServices.Samples.ActivityViewer.Panels.SnapshotIOPanel snapshotIOPanel;
        private SnapshotCPUPanel snapshotCPUPanel;
        private CurrentQueriesPanel currentQueriesPanel;
        private CurrentStateOverviewPanel alertsPanel;
        private ActiveSessionsPanel activeSessionsPanel;
        private SnapshotDormantSessionsPanel snapshotDormantSessionsPanel;
        private SnapshotBlockedSessionsPanel SnapshotBlockedSessionsPanel;
        internal Microsoft.AnalysisServices.Samples.ActivityViewer.Panels.UsersPanel usersPanel;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AlertsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ActiveSessionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CurrentQueriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DormantSessionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BlockedSessionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CPUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ObjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LocksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RulesToolStripMenuItem;
    }
}
