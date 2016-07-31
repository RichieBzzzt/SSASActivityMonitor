using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// to popup when the user clicks "delete instance" but no instance is selected
namespace Microsoft.AnalysisServices.Samples.ActivityViewer
{
    public partial class DeleteErrorForm : Form
    {
        public DeleteErrorForm()
        {
            InitializeComponent();
        }

        private void DeleteErrorOKButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DeleteErrorForm_Load(object sender, EventArgs e)
        {

        }
    }
}
