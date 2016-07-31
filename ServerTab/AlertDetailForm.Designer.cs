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

namespace Microsoft.AnalysisServices.Samples.ActivityViewer.ServerTab
{
    partial class AlertDetailForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.DetailTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DetailDataGrid = new System.Windows.Forms.DataGridView();
            this.DetailOKButton = new System.Windows.Forms.Button();
            this.DetailsCancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DetailDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Warning Rule";
            // 
            // DetailTextBox
            // 
            this.DetailTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DetailTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetailTextBox.Location = new System.Drawing.Point(12, 25);
            this.DetailTextBox.Multiline = true;
            this.DetailTextBox.Name = "DetailTextBox";
            this.DetailTextBox.ReadOnly = true;
            this.DetailTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DetailTextBox.Size = new System.Drawing.Size(844, 55);
            this.DetailTextBox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sessions with Warning";
            // 
            // DetailDataGrid
            // 
            this.DetailDataGrid.AllowUserToAddRows = false;
            this.DetailDataGrid.AllowUserToDeleteRows = false;
            this.DetailDataGrid.AllowUserToOrderColumns = true;
            this.DetailDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DetailDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DetailDataGrid.Location = new System.Drawing.Point(12, 99);
            this.DetailDataGrid.Name = "DetailDataGrid";
            this.DetailDataGrid.ReadOnly = true;
            this.DetailDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DetailDataGrid.ShowEditingIcon = false;
            this.DetailDataGrid.Size = new System.Drawing.Size(844, 125);
            this.DetailDataGrid.TabIndex = 0;
            // 
            // DetailOKButton
            // 
            this.DetailOKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DetailOKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DetailOKButton.Location = new System.Drawing.Point(782, 230);
            this.DetailOKButton.Name = "DetailOKButton";
            this.DetailOKButton.Size = new System.Drawing.Size(75, 23);
            this.DetailOKButton.TabIndex = 1;
            this.DetailOKButton.Text = "OK";
            this.DetailOKButton.UseVisualStyleBackColor = true;
            this.DetailOKButton.Click += new System.EventHandler(this.DetailOKButton_Click);
            // 
            // DetailsCancelButton
            // 
            this.DetailsCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DetailsCancelButton.Location = new System.Drawing.Point(12, 230);
            this.DetailsCancelButton.Name = "DetailsCancelButton";
            this.DetailsCancelButton.Size = new System.Drawing.Size(89, 23);
            this.DetailsCancelButton.TabIndex = 5;
            this.DetailsCancelButton.Text = "Cancel Session";
            this.DetailsCancelButton.UseVisualStyleBackColor = true;
            this.DetailsCancelButton.Click += new System.EventHandler(this.DetailsCancelButton_Click);
            // 
            // AlertDetailForm
            // 
            this.AcceptButton = this.DetailOKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.DetailOKButton;
            this.ClientSize = new System.Drawing.Size(869, 265);
            this.Controls.Add(this.DetailsCancelButton);
            this.Controls.Add(this.DetailOKButton);
            this.Controls.Add(this.DetailDataGrid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DetailTextBox);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(446, 234);
            this.Name = "AlertDetailForm";
            this.Text = "AlertDetailForm";
            ((System.ComponentModel.ISupportInitialize)(this.DetailDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DetailTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DetailDataGrid;
        private System.Windows.Forms.Button DetailOKButton;
        private System.Windows.Forms.Button DetailsCancelButton;
    }
}