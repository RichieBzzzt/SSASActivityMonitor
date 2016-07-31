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
    partial class SnapshotCPUPanel
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
            this.CancelCPUButton = new System.Windows.Forms.Button();
            this.CPUDataGrid = new System.Windows.Forms.DataGridView();
            this.RefreshCPUTimer = new System.Windows.Forms.Timer(this.components);
            this.RefreshButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CPUDataGrid)).BeginInit();
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
            this.label1.Text = "CPU Panel";
            // 
            // CancelCPUButton
            // 
            this.CancelCPUButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelCPUButton.Location = new System.Drawing.Point(395, 409);
            this.CancelCPUButton.Name = "CancelCPUButton";
            this.CancelCPUButton.Size = new System.Drawing.Size(90, 23);
            this.CancelCPUButton.TabIndex = 2;
            this.CancelCPUButton.Text = "Cancel Session";
            this.CancelCPUButton.UseVisualStyleBackColor = true;
            this.CancelCPUButton.Click += new System.EventHandler(this.CancelCPUButton_Click);
            // 
            // CPUDataGrid
            // 
            this.CPUDataGrid.AllowUserToAddRows = false;
            this.CPUDataGrid.AllowUserToDeleteRows = false;
            this.CPUDataGrid.AllowUserToResizeRows = false;
            this.CPUDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CPUDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CPUDataGrid.Location = new System.Drawing.Point(0, 52);
            this.CPUDataGrid.Name = "CPUDataGrid";
            this.CPUDataGrid.ReadOnly = true;
            this.CPUDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CPUDataGrid.Size = new System.Drawing.Size(485, 351);
            this.CPUDataGrid.TabIndex = 0;
            // 
            // RefreshCPUTimer
            // 
            this.RefreshCPUTimer.Interval = 60000;
            this.RefreshCPUTimer.Tick += new System.EventHandler(this.RefreshCPUTimer_Tick);
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
            this.label2.Text = "Identifies the queries currently residing in the plan cache that have consumed th" +
                "e most CPU on average each time they execute with the option to cancel sessions." +
                "\r\n";
            // 
            // SnapshotCPUPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.CancelCPUButton);
            this.Controls.Add(this.CPUDataGrid);
            this.Controls.Add(this.label1);
            this.Name = "SnapshotCPUPanel";
            this.Size = new System.Drawing.Size(496, 448);
            this.VisibleChanged += new System.EventHandler(this.SnapshotCPUPanel_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.CPUDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CancelCPUButton;
        private System.Windows.Forms.DataGridView CPUDataGrid;
        private System.Windows.Forms.Timer RefreshCPUTimer;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Label label2;
    }
}
