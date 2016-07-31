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
    public partial class NewInstanceForm : Form
    {
        ActivityViewerForm main;

        public NewInstanceForm(ActivityViewerForm reference)
        {
            main = reference;
            InitializeComponent();
            NewInstanceTextBox.Enabled = false;
        }

        private void NewInstanceCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NewInstanceOKButton_Click(object sender, EventArgs e)
        {
            if (ServerNameBox.Enabled == false)
            {
                ServerNameBox.Text = "";
            }
            if (NewInstanceTextBox.Enabled == false)
            {
                NewInstanceTextBox.Text = "";
            }

            string connection = this.NewInstanceTextBox.Text;
            if (String.IsNullOrEmpty(connection))
                connection = "Data Source = " + this.ServerNameBox.Text + "; Provider = msolap";
            try
            {
                ConnectingLabel.Visible = true;
                ConnectingLabel.Text = "Connecting to " + this.ServerNameBox.Text;
                Cursor.Current = Cursors.WaitCursor;
                NewInstanceOKButton.Enabled = false;
                NewInstanceCancelButton.Enabled = false;

                Application.DoEvents();
                this.Invoke((MethodInvoker)delegate()
                {
                    main.InstallNewServer(connection);
                    Application.DoEvents();
                    ConnectingLabel.Text = "Connected!";

                });
                NewInstanceOKButton.Enabled = true;
                NewInstanceCancelButton.Enabled = true;
                Cursor.Current = Cursors.Default;
                ConnectingLabel.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                NewInstanceOKButton.Enabled = true;
                NewInstanceCancelButton.Enabled = true;

                Cursor.Current = Cursors.Default;
                ConnectingLabel.Visible = false;
                return;
            }
            Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ServerNameBox.Enabled = false;
            NewInstanceTextBox.Enabled = true;
        }

        private void ServerNameRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ServerNameBox.Enabled = true;
            NewInstanceTextBox.Enabled = false;
        }


    }
}
