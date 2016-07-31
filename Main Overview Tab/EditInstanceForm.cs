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

namespace Microsoft.AnalysisServices.Samples.ActivityViewer
{
    public partial class EditInstanceForm : Form
    {
        ServerControl sc;

        public EditInstanceForm(ServerControl control)
        {
            sc = control;
            InitializeComponent();
            EditInstanceTextBox.Text = control.serverMan.ASMan.ConnectionString;
        }

        private void EditInstanceCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EditInstanceOKButton_Click(object sender, EventArgs e)
        {
            string newString = EditInstanceTextBox.Text;

            try
            {
                sc.serverMan.NewConnectionString(newString);
                sc.Text =  sc.Name = sc.serverMan.Name;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            Close();
        }
    }
}
