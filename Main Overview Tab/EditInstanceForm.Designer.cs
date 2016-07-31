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
    partial class EditInstanceForm
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
            this.EditInstanceCancelButton = new System.Windows.Forms.Button();
            this.EditInstanceLabel = new System.Windows.Forms.Label();
            this.EditInstanceTextBox = new System.Windows.Forms.TextBox();
            this.EditInstanceOKButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EditInstanceCancelButton
            // 
            this.EditInstanceCancelButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EditInstanceCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.EditInstanceCancelButton.Location = new System.Drawing.Point(308, 105);
            this.EditInstanceCancelButton.Name = "EditInstanceCancelButton";
            this.EditInstanceCancelButton.Size = new System.Drawing.Size(75, 23);
            this.EditInstanceCancelButton.TabIndex = 2;
            this.EditInstanceCancelButton.Text = "Cancel";
            this.EditInstanceCancelButton.UseVisualStyleBackColor = true;
            this.EditInstanceCancelButton.Click += new System.EventHandler(this.EditInstanceCancelButton_Click);
            // 
            // EditInstanceLabel
            // 
            this.EditInstanceLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EditInstanceLabel.AutoSize = true;
            this.EditInstanceLabel.Location = new System.Drawing.Point(12, 12);
            this.EditInstanceLabel.Name = "EditInstanceLabel";
            this.EditInstanceLabel.Size = new System.Drawing.Size(91, 13);
            this.EditInstanceLabel.TabIndex = 6;
            this.EditInstanceLabel.Text = "Connection String";
            // 
            // EditInstanceTextBox
            // 
            this.EditInstanceTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EditInstanceTextBox.Location = new System.Drawing.Point(109, 12);
            this.EditInstanceTextBox.Multiline = true;
            this.EditInstanceTextBox.Name = "EditInstanceTextBox";
            this.EditInstanceTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.EditInstanceTextBox.Size = new System.Drawing.Size(274, 86);
            this.EditInstanceTextBox.TabIndex = 0;
            // 
            // EditInstanceOKButton
            // 
            this.EditInstanceOKButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EditInstanceOKButton.Location = new System.Drawing.Point(227, 105);
            this.EditInstanceOKButton.Name = "EditInstanceOKButton";
            this.EditInstanceOKButton.Size = new System.Drawing.Size(75, 23);
            this.EditInstanceOKButton.TabIndex = 1;
            this.EditInstanceOKButton.Text = "OK";
            this.EditInstanceOKButton.UseVisualStyleBackColor = true;
            this.EditInstanceOKButton.Click += new System.EventHandler(this.EditInstanceOKButton_Click);
            // 
            // EditInstanceForm
            // 
            this.AcceptButton = this.EditInstanceOKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.EditInstanceCancelButton;
            this.ClientSize = new System.Drawing.Size(395, 140);
            this.ControlBox = false;
            this.Controls.Add(this.EditInstanceCancelButton);
            this.Controls.Add(this.EditInstanceLabel);
            this.Controls.Add(this.EditInstanceTextBox);
            this.Controls.Add(this.EditInstanceOKButton);
            this.MaximumSize = new System.Drawing.Size(411, 178);
            this.MinimumSize = new System.Drawing.Size(411, 178);
            this.Name = "EditInstanceForm";
            this.Text = "Edit Connection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EditInstanceCancelButton;
        private System.Windows.Forms.Label EditInstanceLabel;
        private System.Windows.Forms.TextBox EditInstanceTextBox;
        private System.Windows.Forms.Button EditInstanceOKButton;
    }
}