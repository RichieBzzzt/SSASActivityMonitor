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
    public partial class AlertDetailForm : Form
    {
        Alert alertRef;

        public AlertDetailForm(Alert alert)
        {
            InitializeComponent();
            DetailDataGrid.DataSource = alert.table;
            DetailDataGrid.AutoResizeColumns();
            DetailTextBox.Text = alert.rule.ToString();
            alertRef = alert;
        }

        private void DetailOKButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DetailsCancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in DetailDataGrid.SelectedRows)
                {
                    alertRef.server.ASMan.CancelSession((int)(row.Cells["SESSION_SPID"].Value));
                    alertRef.table.Rows.RemoveAt(row.Index);
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
