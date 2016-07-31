namespace Microsoft.AnalysisServices.Samples.ActivityViewer
{
    partial class DeleteErrorForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DeleteErrorOKButton = new System.Windows.Forms.Button();
            this.DeleteErrorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DeleteErrorOKButton
            // 
            this.DeleteErrorOKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteErrorOKButton.Location = new System.Drawing.Point(105, 56);
            this.DeleteErrorOKButton.Name = "DeleteErrorOKButton";
            this.DeleteErrorOKButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteErrorOKButton.TabIndex = 0;
            this.DeleteErrorOKButton.TabStop = false;
            this.DeleteErrorOKButton.Text = "OK";
            this.DeleteErrorOKButton.UseVisualStyleBackColor = true;
            this.DeleteErrorOKButton.Click += new System.EventHandler(this.DeleteErrorOKButton_Click);
            // 
            // DeleteErrorLabel
            // 
            this.DeleteErrorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteErrorLabel.AutoSize = true;
            this.DeleteErrorLabel.Location = new System.Drawing.Point(55, 24);
            this.DeleteErrorLabel.Name = "DeleteErrorLabel";
            this.DeleteErrorLabel.Size = new System.Drawing.Size(175, 13);
            this.DeleteErrorLabel.TabIndex = 1;
            this.DeleteErrorLabel.Text = "Please select an instance to delete.";
            // 
            // DeleteErrorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 106);
            this.Controls.Add(this.DeleteErrorLabel);
            this.Controls.Add(this.DeleteErrorOKButton);
            this.Name = "DeleteErrorForm";
            this.Text = "Delete Error";
            this.Load += new System.EventHandler(this.DeleteErrorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DeleteErrorOKButton;
        private System.Windows.Forms.Label DeleteErrorLabel;
    }
}