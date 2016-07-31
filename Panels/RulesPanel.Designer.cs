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

namespace Microsoft.AnalysisServices.Samples.ActivityViewer.Panels
{
    partial class RulesPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RulesPanel));
            this.RulesList = new System.Windows.Forms.ListBox();
            this.DeleteRuleButton = new System.Windows.Forms.Button();
            this.EditRuleButton = new System.Windows.Forms.Button();
            this.NewRuleButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RulesList
            // 
            this.RulesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RulesList.FormattingEnabled = true;
            this.RulesList.IntegralHeight = false;
            this.RulesList.Location = new System.Drawing.Point(0, 268);
            this.RulesList.Name = "RulesList";
            this.RulesList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.RulesList.Size = new System.Drawing.Size(485, 135);
            this.RulesList.TabIndex = 0;
            this.RulesList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RulesList_MouseDoubleClick);
            this.RulesList.SelectedIndexChanged += new System.EventHandler(this.RulesList_SelectedIndexChanged);
            // 
            // DeleteRuleButton
            // 
            this.DeleteRuleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteRuleButton.Location = new System.Drawing.Point(402, 409);
            this.DeleteRuleButton.Name = "DeleteRuleButton";
            this.DeleteRuleButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteRuleButton.TabIndex = 3;
            this.DeleteRuleButton.Text = "Delete Rule";
            this.DeleteRuleButton.UseVisualStyleBackColor = true;
            this.DeleteRuleButton.Click += new System.EventHandler(this.DeleteRuleButton_Click);
            // 
            // EditRuleButton
            // 
            this.EditRuleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EditRuleButton.Location = new System.Drawing.Point(321, 409);
            this.EditRuleButton.Name = "EditRuleButton";
            this.EditRuleButton.Size = new System.Drawing.Size(75, 23);
            this.EditRuleButton.TabIndex = 2;
            this.EditRuleButton.Text = "Edit Rule...";
            this.EditRuleButton.UseVisualStyleBackColor = true;
            this.EditRuleButton.Click += new System.EventHandler(this.EditRuleButton_Click);
            // 
            // NewRuleButton
            // 
            this.NewRuleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NewRuleButton.Location = new System.Drawing.Point(240, 409);
            this.NewRuleButton.Name = "NewRuleButton";
            this.NewRuleButton.Size = new System.Drawing.Size(75, 23);
            this.NewRuleButton.TabIndex = 1;
            this.NewRuleButton.Text = "New Rule...";
            this.NewRuleButton.UseVisualStyleBackColor = true;
            this.NewRuleButton.Click += new System.EventHandler(this.NewRuleButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(316, 234);
            this.label2.TabIndex = 7;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // RulesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NewRuleButton);
            this.Controls.Add(this.EditRuleButton);
            this.Controls.Add(this.DeleteRuleButton);
            this.Controls.Add(this.RulesList);
            this.Name = "RulesPanel";
            this.Size = new System.Drawing.Size(496, 448);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox RulesList;
        private System.Windows.Forms.Button DeleteRuleButton;
        private System.Windows.Forms.Button EditRuleButton;
        private System.Windows.Forms.Button NewRuleButton;
        private System.Windows.Forms.Label label2;
    }
}
