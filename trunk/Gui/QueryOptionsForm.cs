using System;
using System.Windows.Forms;

namespace QueryExPlus
{
    internal partial class QueryOptionsForm : Form
    {
        public QueryOptionsForm()
        {
            InitializeComponent();
        }

        private void cmdResetToDefault_General_Click(object sender, EventArgs e)
        {
            txtRowcount.Value = 0;
            txtTextSize.Value = 2147483647;
            txtExecutionTimeout.Value = 0;
            txtBatchSeparator.Text = "GO";
        }

        internal void cmdOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}