namespace Microsoft.AnalysisServices.Samples.ActivityViewer
{
    partial class SnapshotBlockedSessionsPanel
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
            this.components = new System.ComponentModel.Container();
            this.BlockedDataGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RefreshBlocked = new System.Windows.Forms.Button();
            this.CancelBlockedSessionButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyBlockedCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveBlockedCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BlockedRefreshTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.BlockedDataGrid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BlockedDataGrid
            // 
            this.BlockedDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BlockedDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BlockedDataGrid.Location = new System.Drawing.Point(0, 52);
            this.BlockedDataGrid.Name = "BlockedDataGrid";
            this.BlockedDataGrid.Size = new System.Drawing.Size(485, 351);
            this.BlockedDataGrid.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Blocked Sessions Panel";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(427, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Shows the top dormant sessions and the top users of blocked sessions with the opt" +
    "ion to \r\ncancel a selected session.";
            // 
            // RefreshBlocked
            // 
            this.RefreshBlocked.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RefreshBlocked.Location = new System.Drawing.Point(0, 409);
            this.RefreshBlocked.Name = "RefreshBlocked";
            this.RefreshBlocked.Size = new System.Drawing.Size(90, 23);
            this.RefreshBlocked.TabIndex = 4;
            this.RefreshBlocked.Text = "Refresh";
            this.RefreshBlocked.UseVisualStyleBackColor = true;
            // 
            // CancelBlockedSessionButton
            // 
            this.CancelBlockedSessionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBlockedSessionButton.Location = new System.Drawing.Point(395, 409);
            this.CancelBlockedSessionButton.Name = "CancelBlockedSessionButton";
            this.CancelBlockedSessionButton.Size = new System.Drawing.Size(90, 23);
            this.CancelBlockedSessionButton.TabIndex = 5;
            this.CancelBlockedSessionButton.Text = "Cancel Session";
            this.CancelBlockedSessionButton.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyBlockedCommandToolStripMenuItem,
            this.saveBlockedCommandToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(208, 48);
            // 
            // copyBlockedCommandToolStripMenuItem
            // 
            this.copyBlockedCommandToolStripMenuItem.Name = "copyBlockedCommandToolStripMenuItem";
            this.copyBlockedCommandToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.copyBlockedCommandToolStripMenuItem.Text = "Copy Blocked Command";
            this.copyBlockedCommandToolStripMenuItem.Click += new System.EventHandler(this.copyBlockedCommandToolStripMenuItem_Click);
            // 
            // saveBlockedCommandToolStripMenuItem
            // 
            this.saveBlockedCommandToolStripMenuItem.Name = "saveBlockedCommandToolStripMenuItem";
            this.saveBlockedCommandToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.saveBlockedCommandToolStripMenuItem.Text = "Save Blocked Command";
            // 
            // BlockedRefreshTimer
            // 
            this.BlockedRefreshTimer.Interval = 60000;
            // 
            // SnapshotBlockedSessionsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CancelBlockedSessionButton);
            this.Controls.Add(this.RefreshBlocked);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BlockedDataGrid);
            this.Name = "SnapshotBlockedSessionsPanel";
            this.Size = new System.Drawing.Size(496, 448);
            this.VisibleChanged += new System.EventHandler(this.SnapshotBlockedSessionsPanel_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.BlockedDataGrid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView BlockedDataGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button RefreshBlocked;
        private System.Windows.Forms.Button CancelBlockedSessionButton;
        private SnapshotBlockedSessionsPanel snapshotBlockedSessionsPanel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyBlockedCommandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveBlockedCommandToolStripMenuItem;
        private System.Windows.Forms.Timer BlockedRefreshTimer;
    }
}
