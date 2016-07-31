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
    partial class NewInstanceForm
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
            this.NewInstanceOKButton = new System.Windows.Forms.Button();
            this.NewInstanceTextBox = new System.Windows.Forms.TextBox();
            this.NewInstanceCancelButton = new System.Windows.Forms.Button();
            this.ServerNameBox = new System.Windows.Forms.TextBox();
            this.ServerNameRadioButton = new System.Windows.Forms.RadioButton();
            this.ConnectionStringRadioButton = new System.Windows.Forms.RadioButton();
            this.ConnectingLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NewInstanceOKButton
            // 
            this.NewInstanceOKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NewInstanceOKButton.Location = new System.Drawing.Point(227, 104);
            this.NewInstanceOKButton.Name = "NewInstanceOKButton";
            this.NewInstanceOKButton.Size = new System.Drawing.Size(75, 23);
            this.NewInstanceOKButton.TabIndex = 2;
            this.NewInstanceOKButton.Text = "OK";
            this.NewInstanceOKButton.UseVisualStyleBackColor = true;
            this.NewInstanceOKButton.Click += new System.EventHandler(this.NewInstanceOKButton_Click);
            // 
            // NewInstanceTextBox
            // 
            this.NewInstanceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NewInstanceTextBox.Location = new System.Drawing.Point(109, 35);
            this.NewInstanceTextBox.Multiline = true;
            this.NewInstanceTextBox.Name = "NewInstanceTextBox";
            this.NewInstanceTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.NewInstanceTextBox.Size = new System.Drawing.Size(274, 58);
            this.NewInstanceTextBox.TabIndex = 0;
            this.NewInstanceTextBox.Text = "Data Source = localhost";
            // 
            // NewInstanceCancelButton
            // 
            this.NewInstanceCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NewInstanceCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.NewInstanceCancelButton.Location = new System.Drawing.Point(308, 104);
            this.NewInstanceCancelButton.Name = "NewInstanceCancelButton";
            this.NewInstanceCancelButton.Size = new System.Drawing.Size(75, 23);
            this.NewInstanceCancelButton.TabIndex = 3;
            this.NewInstanceCancelButton.Text = "Cancel";
            this.NewInstanceCancelButton.UseVisualStyleBackColor = true;
            this.NewInstanceCancelButton.Click += new System.EventHandler(this.NewInstanceCancelButton_Click);
            // 
            // ServerNameBox
            // 
            this.ServerNameBox.Location = new System.Drawing.Point(109, 9);
            this.ServerNameBox.Name = "ServerNameBox";
            this.ServerNameBox.Size = new System.Drawing.Size(140, 20);
            this.ServerNameBox.TabIndex = 1;
            this.ServerNameBox.Text = "localhost";
            // 
            // ServerNameRadioButton
            // 
            this.ServerNameRadioButton.AutoSize = true;
            this.ServerNameRadioButton.Checked = true;
            this.ServerNameRadioButton.Location = new System.Drawing.Point(12, 9);
            this.ServerNameRadioButton.Name = "ServerNameRadioButton";
            this.ServerNameRadioButton.Size = new System.Drawing.Size(87, 17);
            this.ServerNameRadioButton.TabIndex = 4;
            this.ServerNameRadioButton.TabStop = true;
            this.ServerNameRadioButton.Text = "Server Name";
            this.ServerNameRadioButton.UseVisualStyleBackColor = true;
            this.ServerNameRadioButton.CheckedChanged += new System.EventHandler(this.ServerNameRadioButton_CheckedChanged);
            // 
            // ConnectionStringRadioButton
            // 
            this.ConnectionStringRadioButton.AutoSize = true;
            this.ConnectionStringRadioButton.Location = new System.Drawing.Point(12, 35);
            this.ConnectionStringRadioButton.Name = "ConnectionStringRadioButton";
            this.ConnectionStringRadioButton.Size = new System.Drawing.Size(79, 30);
            this.ConnectionStringRadioButton.TabIndex = 5;
            this.ConnectionStringRadioButton.Text = "Connection\r\nString";
            this.ConnectionStringRadioButton.UseVisualStyleBackColor = true;
            this.ConnectionStringRadioButton.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // ConnectingLabel
            // 
            this.ConnectingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ConnectingLabel.AutoSize = true;
            this.ConnectingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectingLabel.Location = new System.Drawing.Point(13, 114);
            this.ConnectingLabel.Name = "ConnectingLabel";
            this.ConnectingLabel.Size = new System.Drawing.Size(0, 16);
            this.ConnectingLabel.TabIndex = 6;
            // 
            // NewInstanceForm
            // 
            this.AcceptButton = this.NewInstanceOKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.NewInstanceCancelButton;
            this.ClientSize = new System.Drawing.Size(395, 139);
            this.ControlBox = false;
            this.Controls.Add(this.ConnectingLabel);
            this.Controls.Add(this.ConnectionStringRadioButton);
            this.Controls.Add(this.ServerNameRadioButton);
            this.Controls.Add(this.ServerNameBox);
            this.Controls.Add(this.NewInstanceCancelButton);
            this.Controls.Add(this.NewInstanceTextBox);
            this.Controls.Add(this.NewInstanceOKButton);
            this.MaximumSize = new System.Drawing.Size(411, 178);
            this.MinimumSize = new System.Drawing.Size(411, 178);
            this.Name = "NewInstanceForm";
            this.Text = "New Connection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NewInstanceOKButton;
        private System.Windows.Forms.TextBox NewInstanceTextBox;
        private System.Windows.Forms.Button NewInstanceCancelButton;
        private System.Windows.Forms.TextBox ServerNameBox;
        private System.Windows.Forms.RadioButton ServerNameRadioButton;
        private System.Windows.Forms.RadioButton ConnectionStringRadioButton;
        private System.Windows.Forms.Label ConnectingLabel;
    }
}