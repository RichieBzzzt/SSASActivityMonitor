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
    partial class EditRuleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditRuleForm));
            this.RuleEditCancelButton = new System.Windows.Forms.Button();
            this.RuleEnter = new System.Windows.Forms.Label();
            this.EditRuleTextBox = new System.Windows.Forms.TextBox();
            this.RuleEditOKButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // RuleEditCancelButton
            // 
            this.RuleEditCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RuleEditCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.RuleEditCancelButton.Location = new System.Drawing.Point(568, 400);
            this.RuleEditCancelButton.Name = "RuleEditCancelButton";
            this.RuleEditCancelButton.Size = new System.Drawing.Size(75, 23);
            this.RuleEditCancelButton.TabIndex = 3;
            this.RuleEditCancelButton.Text = "Cancel";
            this.RuleEditCancelButton.UseVisualStyleBackColor = true;
            this.RuleEditCancelButton.Click += new System.EventHandler(this.RuleEditCancelButton_Click);
            // 
            // RuleEnter
            // 
            this.RuleEnter.AutoSize = true;
            this.RuleEnter.Location = new System.Drawing.Point(12, 274);
            this.RuleEnter.Name = "RuleEnter";
            this.RuleEnter.Size = new System.Drawing.Size(53, 13);
            this.RuleEnter.TabIndex = 14;
            this.RuleEnter.Text = "Edit Rule:";
            // 
            // EditRuleTextBox
            // 
            this.EditRuleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.EditRuleTextBox.Location = new System.Drawing.Point(71, 274);
            this.EditRuleTextBox.Multiline = true;
            this.EditRuleTextBox.Name = "EditRuleTextBox";
            this.EditRuleTextBox.Size = new System.Drawing.Size(572, 120);
            this.EditRuleTextBox.TabIndex = 0;
            // 
            // RuleEditOKButton
            // 
            this.RuleEditOKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RuleEditOKButton.Location = new System.Drawing.Point(487, 400);
            this.RuleEditOKButton.Name = "RuleEditOKButton";
            this.RuleEditOKButton.Size = new System.Drawing.Size(75, 23);
            this.RuleEditOKButton.TabIndex = 2;
            this.RuleEditOKButton.Text = "OK";
            this.RuleEditOKButton.UseVisualStyleBackColor = true;
            this.RuleEditOKButton.Click += new System.EventHandler(this.RuleEditOKButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(545, 248);
            this.textBox1.TabIndex = 15;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // EditRuleForm
            // 
            this.AcceptButton = this.RuleEditOKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.RuleEditCancelButton;
            this.ClientSize = new System.Drawing.Size(655, 435);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.RuleEditCancelButton);
            this.Controls.Add(this.RuleEnter);
            this.Controls.Add(this.EditRuleTextBox);
            this.Controls.Add(this.RuleEditOKButton);
            this.MinimumSize = new System.Drawing.Size(671, 471);
            this.Name = "EditRuleForm";
            this.Text = "Edit Rule";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RuleEditCancelButton;
        private System.Windows.Forms.Label RuleEnter;
        private System.Windows.Forms.TextBox EditRuleTextBox;
        private System.Windows.Forms.Button RuleEditOKButton;
        private System.Windows.Forms.TextBox textBox1;
    }
}