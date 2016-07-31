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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.AnalysisServices.Samples.ActivityViewer.ServerTab;

namespace Microsoft.AnalysisServices.Samples.ActivityViewer.Panels
{
    public partial class RulesPanel : UserControl
    {
        ServerManager myServer;

        public RulesPanel(ServerManager server)
        {
            myServer = server;
            InitializeComponent();
            this.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
| System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));

            EditRuleButton.Enabled = false;
            DeleteRuleButton.Enabled = false;
        }

        private void NewRuleButton_Click(object sender, EventArgs e)
        {
            AddRuleForm arf = new AddRuleForm(this);
            arf.ShowDialog();
        }
        
        public void GuiNewRule(string rule, int priority){
            Rule r = myServer.RuleMan.AddRule(rule);
            this.RulesList.Items.Add(r);
            r.SetPriority(priority);
        }

        public void GuiExistingRule(Rule rule)
        {
            try
            {
                this.RulesList.Items.Add(rule);
            }
            catch
            {
            }
        }

        public void EditSelectedRule(string newRuleString)
        {
            try
            {
                Rule newRule = myServer.RuleMan.AddRule(newRuleString);
                myServer.RuleMan.RemoveRule((Rule)RulesList.SelectedItem);

                RulesList.Items.Insert(RulesList.SelectedIndex, newRule);
                RulesList.Items.RemoveAt(RulesList.SelectedIndex);
            }
            catch{}
            
        }

        private void DeleteRuleButton_Click(object sender, EventArgs e)
        {
            //disclaimer
            if (MessageBox.Show("Are you sure you want to delete this rule?", "Warning", MessageBoxButtons.YesNo).Equals(DialogResult.No))
                return;

            int total = RulesList.SelectedItems.Count;
            if (total == 0)
            {
                MessageBox.Show("Please select a rule to delete.", "Delete Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            for (int c = 0; c < total;c++ )
            {
                myServer.RuleMan.RemoveRule((Rule)RulesList.SelectedItems[0]);
                RulesList.Items.Remove(RulesList.SelectedItems[0]);
            }
        }

        private void EditRuleButton_Click(object sender, EventArgs e)
        {
            int index = RulesList.SelectedIndex;
            if (index < 0)
            {
                MessageBox.Show("Please select a rule to edit.", "Edit error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            EditRuleForm erf = new EditRuleForm(this, RulesList.SelectedItem.ToString());
            erf.ShowDialog();
        }

        private void RulesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RulesList.SelectedIndex < 0)
            {
                EditRuleButton.Enabled = false;
                DeleteRuleButton.Enabled = false;
            }
            else
            {
                EditRuleButton.Enabled = true;
                DeleteRuleButton.Enabled = true;
            }
        }

        private void RulesList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditRuleButton_Click(null, null);
        }


    }
}
