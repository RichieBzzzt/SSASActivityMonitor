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
    partial class CurrentStateOverviewPanel
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
            this.AlertRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.RemoveAlertButton = new System.Windows.Forms.Button();
            this.DetailsButton = new System.Windows.Forms.Button();
            this.AlertGrid = new System.Windows.Forms.DataGridView();
            this.Violator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Condition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AlertGrid)).BeginInit();
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
            this.label1.Text = "Alerts";
            // 
            // AlertRefreshTimer
            // 
            this.AlertRefreshTimer.Interval = 1000;
            this.AlertRefreshTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // RemoveAlertButton
            // 
            this.RemoveAlertButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveAlertButton.Location = new System.Drawing.Point(395, 409);
            this.RemoveAlertButton.Name = "RemoveAlertButton";
            this.RemoveAlertButton.Size = new System.Drawing.Size(90, 23);
            this.RemoveAlertButton.TabIndex = 2;
            this.RemoveAlertButton.Text = "Remove";
            this.RemoveAlertButton.UseVisualStyleBackColor = true;
            this.RemoveAlertButton.Click += new System.EventHandler(this.RemoveAlertButton_Click);
            // 
            // DetailsButton
            // 
            this.DetailsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DetailsButton.Location = new System.Drawing.Point(299, 409);
            this.DetailsButton.Name = "DetailsButton";
            this.DetailsButton.Size = new System.Drawing.Size(90, 23);
            this.DetailsButton.TabIndex = 1;
            this.DetailsButton.Text = "Details...";
            this.DetailsButton.UseVisualStyleBackColor = true;
            this.DetailsButton.Click += new System.EventHandler(this.DetailsButton_Click);
            // 
            // AlertGrid
            // 
            this.AlertGrid.AllowUserToAddRows = false;
            this.AlertGrid.AllowUserToDeleteRows = false;
            this.AlertGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.AlertGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AlertGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Violator,
            this.Priority,
            this.Condition});
            this.AlertGrid.Location = new System.Drawing.Point(0, 52);
            this.AlertGrid.Name = "AlertGrid";
            this.AlertGrid.ReadOnly = true;
            this.AlertGrid.RowHeadersVisible = false;
            this.AlertGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AlertGrid.Size = new System.Drawing.Size(485, 351);
            this.AlertGrid.TabIndex = 3;
            this.AlertGrid.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AlertGrid_MouseDoubleClick);
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
            this.Condition.Width = 300;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(490, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "Shows the alerts active on this connection, including the user that violated the " +
                "rule, the priority and \r\nthe rule that was violated.";
            // 
            // CurrentStateOverviewPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AlertGrid);
            this.Controls.Add(this.DetailsButton);
            this.Controls.Add(this.RemoveAlertButton);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(136, 8);
            this.Name = "CurrentStateOverviewPanel";
            this.Size = new System.Drawing.Size(496, 448);
            this.VisibleChanged += new System.EventHandler(this.CurrentStateOverviewPanel_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.AlertGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer AlertRefreshTimer;
        private System.Windows.Forms.Button RemoveAlertButton;
        private System.Windows.Forms.Button DetailsButton;
        private System.Windows.Forms.DataGridView AlertGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Violator;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn Condition;
        private System.Windows.Forms.Label label2;
    }
}
