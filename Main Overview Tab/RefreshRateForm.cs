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
    public partial class RefreshRateForm : Form
    {
        int [] valueArray = new int[4] {1000, 60000, 3600000, 86400000};

        // variables used to persist the refresh rate
        private static int number = 90;
        private static int timeInterval;

        public RefreshRateForm()
        {
            InitializeComponent();
            ShowRefreshRate();
        }

        private void RefreshRateButton_Click(object sender, EventArgs e)
        {
            try
            {
                number = int.Parse(RefreshRateTextBox.Text);
                timeInterval = RefreshRateComboBox.SelectedIndex;
                ActivityViewerForm.pm.SetDataRefreshRate(number * (valueArray[RefreshRateComboBox.SelectedIndex]));
                Close();
            }
            catch
            {
                MessageBox.Show("Please enter a valid number.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowRefreshRate()
        {
            RefreshRateTextBox.Text = number.ToString();
            RefreshRateComboBox.SelectedIndex = timeInterval;
        }
    }
}
