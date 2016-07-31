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

namespace Microsoft.AnalysisServices.Samples.ActivityViewer.Panels
{
    public partial class SnapshotObjectsPanel : UserControl
    {
        ServerManager myServer;
        DataTable wholeTable;

        private string objectsQuery = "SELECT OBJECT_CPU_TIME_MS,OBJECT_READS, OBJECT_AGGREGATION_HIT, OBJECT_ID, OBJECT_PARENT_PATH FROM $SYSTEM.DISCOVER_OBJECT_ACTIVITY ORDER BY OBJECT_READS DESC";

        public SnapshotObjectsPanel(ServerManager server)
        {
            InitializeComponent();
            myServer = server;
            this.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
| System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        }

        private void refreshObjectsTable()
        {
            wholeTable = myServer.ASMan.DataTableFromQuery(objectsQuery);
            ApplyFilter();
        }

        private void ObjectsRefreshTimer_Tick(object sender, EventArgs e)
        {
            refreshObjectsTable();
        }

        private void SnapshotObjectsPanel_VisibleChanged(object sender, EventArgs e)
        {

            if (this.Visible)
            {
                if (myServer.dataRefreshInterval != 0)
                {
                    ObjectsRefreshTimer.Interval = myServer.dataRefreshInterval;
                    ObjectsRefreshTimer.Start();
                }
                refreshObjectsTable();
                ObjectsDataGrid.AutoResizeColumns();
            }
            else
            {
                if (myServer.dataRefreshInterval != 0)
                    ObjectsRefreshTimer.Stop();
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            refreshObjectsTable();
        }

        private void ApplyFilter()
        {
            DataTable newTable = new DataTable();

            foreach(DataColumn dc in wholeTable.Columns)
                newTable.Columns.Add(dc.ColumnName);

            foreach (DataRow dr in wholeTable.Rows)
                if (((string)dr["OBJECT_ID"]).IndexOf(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    newTable.Rows.Add(dr.ItemArray);

            ObjectsDataGrid.DataSource = newTable;
            foreach (DataGridViewTextBoxColumn col in ObjectsDataGrid.Columns)
            {
                col.ToolTipText = ActivityViewer.ProgramManager.GetToolTipText(col.HeaderText);
            }
            ObjectsDataGrid.AutoResizeColumns();

        }

        private void FilterTextBox_TextChanged(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(FilterTextBox.Text))
                ApplyFilter();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void FilterTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                ApplyFilter();
        }
   }
}
