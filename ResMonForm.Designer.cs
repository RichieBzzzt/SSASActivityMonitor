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

namespace Microsoft.AnalysisServices.Samples.ActivityViewer
{
    partial class ActivityViewerForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActivityViewerForm));
            this.InstanceComparisonTab = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AllAlertsGrid = new System.Windows.Forms.DataGridView();
            this.Server = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Violator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Condition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConnectionDataGrid = new System.Windows.Forms.DataGridView();
            this.Connection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Memory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IO_READ_KB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IO_WRITE_KB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllAlertsDetailsButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RefreshRateOverviewButton = new System.Windows.Forms.Button();
            this.DeleteInstanceOverview = new System.Windows.Forms.Button();
            this.EditInstanceOverview = new System.Windows.Forms.Button();
            this.NewInstanceOverview = new System.Windows.Forms.Button();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.AllAlertsTimer = new System.Windows.Forms.Timer(this.components);
            this.ConnectionRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InstanceComparisonTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AllAlertsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConnectionDataGrid)).BeginInit();
            this.MainTabControl.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // InstanceComparisonTab
            // 
            this.InstanceComparisonTab.Controls.Add(this.label4);
            this.InstanceComparisonTab.Controls.Add(this.label3);
            this.InstanceComparisonTab.Controls.Add(this.AllAlertsGrid);
            this.InstanceComparisonTab.Controls.Add(this.ConnectionDataGrid);
            this.InstanceComparisonTab.Controls.Add(this.AllAlertsDetailsButton);
            this.InstanceComparisonTab.Controls.Add(this.label2);
            this.InstanceComparisonTab.Controls.Add(this.label1);
            this.InstanceComparisonTab.Controls.Add(this.RefreshRateOverviewButton);
            this.InstanceComparisonTab.Controls.Add(this.DeleteInstanceOverview);
            this.InstanceComparisonTab.Controls.Add(this.EditInstanceOverview);
            this.InstanceComparisonTab.Controls.Add(this.NewInstanceOverview);
            this.InstanceComparisonTab.Location = new System.Drawing.Point(4, 22);
            this.InstanceComparisonTab.Name = "InstanceComparisonTab";
            this.InstanceComparisonTab.Padding = new System.Windows.Forms.Padding(3);
            this.InstanceComparisonTab.Size = new System.Drawing.Size(640, 489);
            this.InstanceComparisonTab.TabIndex = 0;
            this.InstanceComparisonTab.Text = "Overview";
            this.InstanceComparisonTab.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(16, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(595, 31);
            this.label4.TabIndex = 11;
            this.label4.Text = "Rules that can be defined under individual instances tabs can create alerts with " +
    "the option of additional details.  Refresh Rate for this window can also be conf" +
    "igured.\r\n";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(595, 22);
            this.label3.TabIndex = 10;
            this.label3.Text = " Begin by adding a new server connection using the name or connection string.  Ed" +
    "it/Remove connections as necessary.";
            // 
            // AllAlertsGrid
            // 
            this.AllAlertsGrid.AllowUserToAddRows = false;
            this.AllAlertsGrid.AllowUserToDeleteRows = false;
            this.AllAlertsGrid.AllowUserToResizeRows = false;
            this.AllAlertsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AllAlertsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AllAlertsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Server,
            this.Violator,
            this.Priority,
            this.Condition});
            this.AllAlertsGrid.Location = new System.Drawing.Point(19, 273);
            this.AllAlertsGrid.Name = "AllAlertsGrid";
            this.AllAlertsGrid.ReadOnly = true;
            this.AllAlertsGrid.RowHeadersVisible = false;
            this.AllAlertsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AllAlertsGrid.Size = new System.Drawing.Size(592, 163);
            this.AllAlertsGrid.TabIndex = 9;
            this.AllAlertsGrid.SelectionChanged += new System.EventHandler(this.AllAlertsGrid_SelectionChanged);
            this.AllAlertsGrid.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AllAlertsGrid_MouseDoubleClick);
            // 
            // Server
            // 
            this.Server.HeaderText = "Server";
            this.Server.Name = "Server";
            this.Server.ReadOnly = true;
            // 
            // Violator
            // 
            this.Violator.HeaderText = "Violator";
            this.Violator.Name = "Violator";
            this.Violator.ReadOnly = true;
            // 
            // Priority
            // 
            this.Priority.HeaderText = "Priority";
            this.Priority.Name = "Priority";
            this.Priority.ReadOnly = true;
            // 
            // Condition
            // 
            this.Condition.HeaderText = "Condition";
            this.Condition.Name = "Condition";
            this.Condition.ReadOnly = true;
            this.Condition.Width = 288;
            // 
            // ConnectionDataGrid
            // 
            this.ConnectionDataGrid.AllowUserToAddRows = false;
            this.ConnectionDataGrid.AllowUserToDeleteRows = false;
            this.ConnectionDataGrid.AllowUserToResizeRows = false;
            this.ConnectionDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectionDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConnectionDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Connection,
            this.CPU,
            this.Memory,
            this.IO_READ_KB,
            this.IO_WRITE_KB});
            this.ConnectionDataGrid.Location = new System.Drawing.Point(19, 49);
            this.ConnectionDataGrid.Name = "ConnectionDataGrid";
            this.ConnectionDataGrid.ReadOnly = true;
            this.ConnectionDataGrid.RowHeadersVisible = false;
            this.ConnectionDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ConnectionDataGrid.Size = new System.Drawing.Size(592, 121);
            this.ConnectionDataGrid.TabIndex = 8;
            this.ConnectionDataGrid.SelectionChanged += new System.EventHandler(this.ConnectionDataGrid_SelectionChanged);
            this.ConnectionDataGrid.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ConnectionDataGrid_MouseDoubleClick);
            // 
            // Connection
            // 
            this.Connection.HeaderText = "Connection";
            this.Connection.Name = "Connection";
            this.Connection.ReadOnly = true;
            this.Connection.Width = 188;
            // 
            // CPU
            // 
            this.CPU.HeaderText = "CPU";
            this.CPU.Name = "CPU";
            this.CPU.ReadOnly = true;
            // 
            // Memory
            // 
            this.Memory.HeaderText = "Memory";
            this.Memory.Name = "Memory";
            this.Memory.ReadOnly = true;
            // 
            // IO_READ_KB
            // 
            this.IO_READ_KB.HeaderText = "IO Read KB";
            this.IO_READ_KB.Name = "IO_READ_KB";
            this.IO_READ_KB.ReadOnly = true;
            // 
            // IO_WRITE_KB
            // 
            this.IO_WRITE_KB.HeaderText = "IO Write KB";
            this.IO_WRITE_KB.Name = "IO_WRITE_KB";
            this.IO_WRITE_KB.ReadOnly = true;
            // 
            // AllAlertsDetailsButton
            // 
            this.AllAlertsDetailsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AllAlertsDetailsButton.Location = new System.Drawing.Point(536, 444);
            this.AllAlertsDetailsButton.Name = "AllAlertsDetailsButton";
            this.AllAlertsDetailsButton.Size = new System.Drawing.Size(75, 23);
            this.AllAlertsDetailsButton.TabIndex = 6;
            this.AllAlertsDetailsButton.Text = "Details...";
            this.AllAlertsDetailsButton.UseVisualStyleBackColor = true;
            this.AllAlertsDetailsButton.Click += new System.EventHandler(this.AllAlertsDetailsButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "All Alerts";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(595, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Connections";
            // 
            // RefreshRateOverviewButton
            // 
            this.RefreshRateOverviewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshRateOverviewButton.Location = new System.Drawing.Point(418, 444);
            this.RefreshRateOverviewButton.Name = "RefreshRateOverviewButton";
            this.RefreshRateOverviewButton.Size = new System.Drawing.Size(112, 23);
            this.RefreshRateOverviewButton.TabIndex = 5;
            this.RefreshRateOverviewButton.Text = "Refresh Rate...";
            this.RefreshRateOverviewButton.UseVisualStyleBackColor = true;
            this.RefreshRateOverviewButton.Click += new System.EventHandler(this.RefreshRateOverviewButton_Click);
            // 
            // DeleteInstanceOverview
            // 
            this.DeleteInstanceOverview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteInstanceOverview.Location = new System.Drawing.Point(499, 176);
            this.DeleteInstanceOverview.Name = "DeleteInstanceOverview";
            this.DeleteInstanceOverview.Size = new System.Drawing.Size(112, 23);
            this.DeleteInstanceOverview.TabIndex = 3;
            this.DeleteInstanceOverview.Text = "Remove Connection";
            this.DeleteInstanceOverview.UseVisualStyleBackColor = true;
            this.DeleteInstanceOverview.Click += new System.EventHandler(this.DeleteInstanceOverview_Click);
            // 
            // EditInstanceOverview
            // 
            this.EditInstanceOverview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditInstanceOverview.Location = new System.Drawing.Point(381, 176);
            this.EditInstanceOverview.Name = "EditInstanceOverview";
            this.EditInstanceOverview.Size = new System.Drawing.Size(112, 23);
            this.EditInstanceOverview.TabIndex = 2;
            this.EditInstanceOverview.Text = "Edit Connection...";
            this.EditInstanceOverview.UseVisualStyleBackColor = true;
            this.EditInstanceOverview.Click += new System.EventHandler(this.EditInstanceOverview_Click);
            // 
            // NewInstanceOverview
            // 
            this.NewInstanceOverview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NewInstanceOverview.Location = new System.Drawing.Point(247, 176);
            this.NewInstanceOverview.Name = "NewInstanceOverview";
            this.NewInstanceOverview.Size = new System.Drawing.Size(128, 23);
            this.NewInstanceOverview.TabIndex = 1;
            this.NewInstanceOverview.Text = "Add New Connection...";
            this.NewInstanceOverview.UseVisualStyleBackColor = true;
            this.NewInstanceOverview.Click += new System.EventHandler(this.NewInstanceOverview_Click);
            // 
            // MainTabControl
            // 
            this.MainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTabControl.Controls.Add(this.InstanceComparisonTab);
            this.MainTabControl.Location = new System.Drawing.Point(9, 27);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(648, 515);
            this.MainTabControl.TabIndex = 0;
            // 
            // AllAlertsTimer
            // 
            this.AllAlertsTimer.Interval = 1000;
            this.AllAlertsTimer.Tick += new System.EventHandler(this.AllAlertsTimer_Tick);
            // 
            // ConnectionRefreshTimer
            // 
            this.ConnectionRefreshTimer.Interval = 120000;
            this.ConnectionRefreshTimer.Tick += new System.EventHandler(this.ConnectionRefreshTimer_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = this.BackColor;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(666, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // ActivityViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(666, 551);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(682, 542);
            this.Name = "ActivityViewerForm";
            this.Text = "SSAS Activity Viewer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ActivityViewerForm_FormClosed);
            this.InstanceComparisonTab.ResumeLayout(false);
            this.InstanceComparisonTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AllAlertsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConnectionDataGrid)).EndInit();
            this.MainTabControl.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage InstanceComparisonTab;
        private System.Windows.Forms.Button DeleteInstanceOverview;
        private System.Windows.Forms.Button EditInstanceOverview;
        private System.Windows.Forms.Button NewInstanceOverview;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.Button RefreshRateOverviewButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer AllAlertsTimer;
        private System.Windows.Forms.Button AllAlertsDetailsButton;
        private System.Windows.Forms.DataGridView ConnectionDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Connection;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPU;
        private System.Windows.Forms.DataGridViewTextBoxColumn Memory;
        private System.Windows.Forms.DataGridViewTextBoxColumn IO_READ_KB;
        private System.Windows.Forms.DataGridViewTextBoxColumn IO_WRITE_KB;
        private System.Windows.Forms.Timer ConnectionRefreshTimer;
        private System.Windows.Forms.DataGridView AllAlertsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Server;
        private System.Windows.Forms.DataGridViewTextBoxColumn Violator;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn Condition;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;


    }
}

