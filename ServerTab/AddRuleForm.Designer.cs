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
    partial class AddRuleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddRuleForm));
            this.RuleAddCancelButton = new System.Windows.Forms.Button();
            this.RuleEnter = new System.Windows.Forms.Label();
            this.NewRuleTextBox = new System.Windows.Forms.TextBox();
            this.RuleAddOKButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LowPriRadio = new System.Windows.Forms.RadioButton();
            this.MedPriRadio = new System.Windows.Forms.RadioButton();
            this.HighPriRadio = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // RuleAddCancelButton
            // 
            this.RuleAddCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RuleAddCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.RuleAddCancelButton.Location = new System.Drawing.Point(568, 400);
            this.RuleAddCancelButton.Name = "RuleAddCancelButton";
            this.RuleAddCancelButton.Size = new System.Drawing.Size(75, 23);
            this.RuleAddCancelButton.TabIndex = 3;
            this.RuleAddCancelButton.Text = "Cancel";
            this.RuleAddCancelButton.UseVisualStyleBackColor = true;
            this.RuleAddCancelButton.Click += new System.EventHandler(this.RuleAddCancelButton_Click);
            // 
            // RuleEnter
            // 
            this.RuleEnter.AutoSize = true;
            this.RuleEnter.Location = new System.Drawing.Point(12, 274);
            this.RuleEnter.Name = "RuleEnter";
            this.RuleEnter.Size = new System.Drawing.Size(60, 13);
            this.RuleEnter.TabIndex = 10;
            this.RuleEnter.Text = "Enter Rule:";
            // 
            // NewRuleTextBox
            // 
            this.NewRuleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NewRuleTextBox.Location = new System.Drawing.Point(78, 274);
            this.NewRuleTextBox.Multiline = true;
            this.NewRuleTextBox.Name = "NewRuleTextBox";
            this.NewRuleTextBox.Size = new System.Drawing.Size(378, 120);
            this.NewRuleTextBox.TabIndex = 0;
            // 
            // RuleAddOKButton
            // 
            this.RuleAddOKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RuleAddOKButton.Location = new System.Drawing.Point(487, 400);
            this.RuleAddOKButton.Name = "RuleAddOKButton";
            this.RuleAddOKButton.Size = new System.Drawing.Size(75, 23);
            this.RuleAddOKButton.TabIndex = 2;
            this.RuleAddOKButton.Text = "OK";
            this.RuleAddOKButton.UseVisualStyleBackColor = true;
            this.RuleAddOKButton.Click += new System.EventHandler(this.RuleAddOKButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(545, 248);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(484, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Priority";
            // 
            // LowPriRadio
            // 
            this.LowPriRadio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LowPriRadio.AutoSize = true;
            this.LowPriRadio.Location = new System.Drawing.Point(487, 306);
            this.LowPriRadio.Name = "LowPriRadio";
            this.LowPriRadio.Size = new System.Drawing.Size(45, 17);
            this.LowPriRadio.TabIndex = 13;
            this.LowPriRadio.Text = "Low";
            this.LowPriRadio.UseVisualStyleBackColor = true;
            // 
            // MedPriRadio
            // 
            this.MedPriRadio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MedPriRadio.AutoSize = true;
            this.MedPriRadio.Checked = true;
            this.MedPriRadio.Location = new System.Drawing.Point(487, 330);
            this.MedPriRadio.Name = "MedPriRadio";
            this.MedPriRadio.Size = new System.Drawing.Size(62, 17);
            this.MedPriRadio.TabIndex = 14;
            this.MedPriRadio.TabStop = true;
            this.MedPriRadio.Text = "Medium";
            this.MedPriRadio.UseVisualStyleBackColor = true;
            // 
            // HighPriRadio
            // 
            this.HighPriRadio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.HighPriRadio.AutoSize = true;
            this.HighPriRadio.Location = new System.Drawing.Point(487, 354);
            this.HighPriRadio.Name = "HighPriRadio";
            this.HighPriRadio.Size = new System.Drawing.Size(47, 17);
            this.HighPriRadio.TabIndex = 15;
            this.HighPriRadio.Text = "High";
            this.HighPriRadio.UseVisualStyleBackColor = true;
            // 
            // AddRuleForm
            // 
            this.AcceptButton = this.RuleAddOKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.RuleAddCancelButton;
            this.ClientSize = new System.Drawing.Size(655, 435);
            this.Controls.Add(this.HighPriRadio);
            this.Controls.Add(this.MedPriRadio);
            this.Controls.Add(this.LowPriRadio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.RuleAddCancelButton);
            this.Controls.Add(this.RuleEnter);
            this.Controls.Add(this.NewRuleTextBox);
            this.Controls.Add(this.RuleAddOKButton);
            this.MinimumSize = new System.Drawing.Size(671, 471);
            this.Name = "AddRuleForm";
            this.Text = "New Rule";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RuleAddCancelButton;
        private System.Windows.Forms.Label RuleEnter;
        private System.Windows.Forms.TextBox NewRuleTextBox;
        private System.Windows.Forms.Button RuleAddOKButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton LowPriRadio;
        private System.Windows.Forms.RadioButton MedPriRadio;
        private System.Windows.Forms.RadioButton HighPriRadio;

    }
}