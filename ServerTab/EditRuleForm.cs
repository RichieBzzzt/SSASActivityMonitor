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
    public partial class EditRuleForm : Form
    {
        Microsoft.AnalysisServices.Samples.ActivityViewer.Panels.RulesPanel parent;

        public EditRuleForm(Microsoft.AnalysisServices.Samples.ActivityViewer.Panels.RulesPanel panel, string rule)
        {
            parent = panel;
            InitializeComponent();
            EditRuleTextBox.Text = rule;
        }

        private void RuleEditCancelButton_Click(object sender, EventArgs e)
        {
            closingRoutine();
        }

        private void closingRoutine()
        {
            this.Close();
        }

        private void RuleEditOKButton_Click(object sender, EventArgs e)
        {
            try
            {
                parent.EditSelectedRule(EditRuleTextBox.Text);
                closingRoutine();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
