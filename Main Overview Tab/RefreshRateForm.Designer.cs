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
    public partial class RefreshRateForm
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
            this.RefreshRateLabel = new System.Windows.Forms.Label();
            this.RefreshRateComboBox = new System.Windows.Forms.ComboBox();
            this.RefreshRateOKButton = new System.Windows.Forms.Button();
            this.RefreshRateTextBox = new System.Windows.Forms.TextBox();
            this.RefreshRateCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RefreshRateLabel
            // 
            this.RefreshRateLabel.AutoSize = true;
            this.RefreshRateLabel.Location = new System.Drawing.Point(40, 16);
            this.RefreshRateLabel.Name = "RefreshRateLabel";
            this.RefreshRateLabel.Size = new System.Drawing.Size(206, 39);
            this.RefreshRateLabel.TabIndex = 0;
            this.RefreshRateLabel.Text = "Please select the automatic refresh rate \r\nfor the processing of the rules. The d" +
                "efault\r\nrate is 90 seconds.";
            this.RefreshRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RefreshRateComboBox
            // 
            this.RefreshRateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RefreshRateComboBox.FormattingEnabled = true;
            this.RefreshRateComboBox.Items.AddRange(new object[] {
            "seconds",
            "minutes",
            "hours",
            "days"});
            this.RefreshRateComboBox.Location = new System.Drawing.Point(152, 80);
            this.RefreshRateComboBox.Name = "RefreshRateComboBox";
            this.RefreshRateComboBox.Size = new System.Drawing.Size(100, 21);
            this.RefreshRateComboBox.TabIndex = 1;
            // 
            // RefreshRateOKButton
            // 
            this.RefreshRateOKButton.Location = new System.Drawing.Point(120, 128);
            this.RefreshRateOKButton.Name = "RefreshRateOKButton";
            this.RefreshRateOKButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshRateOKButton.TabIndex = 2;
            this.RefreshRateOKButton.Text = "OK";
            this.RefreshRateOKButton.UseVisualStyleBackColor = true;
            this.RefreshRateOKButton.Click += new System.EventHandler(this.RefreshRateButton_Click);
            // 
            // RefreshRateTextBox
            // 
            this.RefreshRateTextBox.Location = new System.Drawing.Point(32, 80);
            this.RefreshRateTextBox.Name = "RefreshRateTextBox";
            this.RefreshRateTextBox.Size = new System.Drawing.Size(100, 20);
            this.RefreshRateTextBox.TabIndex = 0;
            this.RefreshRateTextBox.Text = "90";
            // 
            // RefreshRateCancelButton
            // 
            this.RefreshRateCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.RefreshRateCancelButton.Location = new System.Drawing.Point(200, 128);
            this.RefreshRateCancelButton.Name = "RefreshRateCancelButton";
            this.RefreshRateCancelButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshRateCancelButton.TabIndex = 3;
            this.RefreshRateCancelButton.Text = "Cancel";
            this.RefreshRateCancelButton.UseVisualStyleBackColor = true;
            // 
            // RefreshRateForm
            // 
            this.AcceptButton = this.RefreshRateOKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.RefreshRateCancelButton;
            this.ClientSize = new System.Drawing.Size(287, 166);
            this.ControlBox = false;
            this.Controls.Add(this.RefreshRateCancelButton);
            this.Controls.Add(this.RefreshRateTextBox);
            this.Controls.Add(this.RefreshRateOKButton);
            this.Controls.Add(this.RefreshRateComboBox);
            this.Controls.Add(this.RefreshRateLabel);
            this.MaximumSize = new System.Drawing.Size(303, 202);
            this.MinimumSize = new System.Drawing.Size(303, 202);
            this.Name = "RefreshRateForm";
            this.Text = "Refresh Rate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RefreshRateLabel;
        private System.Windows.Forms.ComboBox RefreshRateComboBox;
        private System.Windows.Forms.Button RefreshRateOKButton;
        private System.Windows.Forms.TextBox RefreshRateTextBox;
        private System.Windows.Forms.Button RefreshRateCancelButton;
    }
}