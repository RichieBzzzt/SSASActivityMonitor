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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Microsoft.AnalysisServices.Samples.ActivityViewer.ServerTab
{
    public partial class AddRuleForm : Form
    {
        Microsoft.AnalysisServices.Samples.ActivityViewer.Panels.RulesPanel parent;

        public AddRuleForm(Microsoft.AnalysisServices.Samples.ActivityViewer.Panels.RulesPanel panel)
        {
            parent = panel;
            InitializeComponent();
        }

        private void RuleAddOKButton_Click(object sender, EventArgs e)
        {
            try
            {
                int priority = 1;
                if (HighPriRadio.Checked)
                {
                    priority = 0;
                }
                else if (LowPriRadio.Checked)
                {
                    priority = 2;
                }
                parent.GuiNewRule(NewRuleTextBox.Text, priority);
                this.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void RuleAddCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
