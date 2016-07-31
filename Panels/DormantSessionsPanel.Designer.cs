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

namespace Microsoft.AnalysisServices.Samples.ActivityViewer
{
    partial class SnapshotDormantSessionsPanel
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.DormantCancelButton = new System.Windows.Forms.Button();
            this.DormantDataGrid = new System.Windows.Forms.DataGridView();
            this.DormantRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.RefreshButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyLastCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLastCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DormantDataGrid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(490, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dormant Sessions Panel";
            // 
            // DormantCancelButton
            // 
            this.DormantCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DormantCancelButton.Location = new System.Drawing.Point(395, 409);
            this.DormantCancelButton.Name = "DormantCancelButton";
            this.DormantCancelButton.Size = new System.Drawing.Size(90, 23);
            this.DormantCancelButton.TabIndex = 2;
            this.DormantCancelButton.Text = "Cancel Session";
            this.DormantCancelButton.UseVisualStyleBackColor = true;
            this.DormantCancelButton.Click += new System.EventHandler(this.DormantCancelButton_Click);
            // 
            // DormantDataGrid
            // 
            this.DormantDataGrid.AllowUserToAddRows = false;
            this.DormantDataGrid.AllowUserToDeleteRows = false;
            this.DormantDataGrid.AllowUserToResizeRows = false;
            this.DormantDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DormantDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DormantDataGrid.Location = new System.Drawing.Point(0, 52);
            this.DormantDataGrid.Name = "DormantDataGrid";
            this.DormantDataGrid.ReadOnly = true;
            this.DormantDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DormantDataGrid.Size = new System.Drawing.Size(485, 351);
            this.DormantDataGrid.TabIndex = 0;
            this.DormantDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DormantDataGrid_CellContentClick);
            // 
            // DormantRefreshTimer
            // 
            this.DormantRefreshTimer.Interval = 60000;
            this.DormantRefreshTimer.Tick += new System.EventHandler(this.DormantRefreshTimer_Tick);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RefreshButton.Location = new System.Drawing.Point(0, 409);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(90, 23);
            this.RefreshButton.TabIndex = 1;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(0, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(490, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "Shows the top dormant sessions and the top users of dormant sessions with the opt" +
    "ion to cancel a selected session.\r\n";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyLastCommandToolStripMenuItem,
            this.saveLastCommandToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(187, 70);
            // 
            // copyLastCommandToolStripMenuItem
            // 
            this.copyLastCommandToolStripMenuItem.Name = "copyLastCommandToolStripMenuItem";
            this.copyLastCommandToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.copyLastCommandToolStripMenuItem.Text = "Copy Last Command";
            this.copyLastCommandToolStripMenuItem.Click += new System.EventHandler(this.copyLastCommandToolStripMenuItem_Click);
            // 
            // saveLastCommandToolStripMenuItem
            // 
            this.saveLastCommandToolStripMenuItem.Name = "saveLastCommandToolStripMenuItem";
            this.saveLastCommandToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveLastCommandToolStripMenuItem.Text = "Save Last Command";
            this.saveLastCommandToolStripMenuItem.Click += new System.EventHandler(this.saveLastCommandToolStripMenuItem_Click);
            // 
            // SnapshotDormantSessionsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.DormantCancelButton);
            this.Controls.Add(this.DormantDataGrid);
            this.Controls.Add(this.label1);
            this.Name = "SnapshotDormantSessionsPanel";
            this.Size = new System.Drawing.Size(496, 448);
            this.VisibleChanged += new System.EventHandler(this.SnapshotDormantSessionsPanel_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.DormantDataGrid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DormantCancelButton;
        private System.Windows.Forms.DataGridView DormantDataGrid;
        private System.Windows.Forms.Timer DormantRefreshTimer;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyLastCommandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLastCommandToolStripMenuItem;
    }
}
