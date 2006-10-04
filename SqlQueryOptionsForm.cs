using System;
using System.Windows.Forms;

namespace QueryExPlus
{
    internal partial class SqlQueryOptionsForm : QueryOptionsForm
    {
        public SqlQueryOptionsForm()
        {
            InitializeComponent();
        }

        private void cmdResetToDefault_Advanced_Click(object sender, EventArgs e)
        {
            chkNoCount.Checked = false;
            chkNoExec.Checked = false;
            chkParseOnly.Checked = false;
            chkConcatNullYieldsNull.Checked = true;
            chkArithAbort.Checked = true;
            chkStatisticsTime.Checked = false;
            chkStatisticsIo.Checked = false;
            cboTransactionIsolation.Text = "READ COMMITTED";
            cboDeadlockPriority.Text = "Normal";
            txtLockTimeout.Value = -1;
            txtQueryGovernorCostLimit.Value = 0;
        }

        private void chkParseOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (chkParseOnly.Checked)
            {
                chkNoCount.Checked = false;
                chkNoCount.Enabled = false;
                chkNoExec.Checked = false;
                chkNoExec.Enabled = false;
                chkArithAbort.Checked = false;
                chkArithAbort.Enabled = false;
                chkShowPlanText.Checked = false;
                chkShowPlanText.Enabled = false;
                chkStatisticsIo.Checked = false;
                chkStatisticsIo.Enabled = false;
                chkStatisticsTime.Checked = false;
                chkStatisticsTime.Enabled = false;
            }
            else
            {
                chkNoCount.Enabled = true;
                chkNoExec.Enabled = true;
                chkArithAbort.Enabled = true;
                chkShowPlanText.Enabled = true;
                chkStatisticsIo.Enabled = true;
                chkStatisticsTime.Enabled = true;
            }

        }

        private void chkNoExec_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNoExec.Checked)
            {
                chkNoCount.Checked = false;
                chkNoCount.Enabled = false;
                chkParseOnly.Checked = false;
                chkParseOnly.Enabled = false;
                chkArithAbort.Checked = false;
                chkArithAbort.Enabled = false;
                chkShowPlanText.Checked = false;
                chkShowPlanText.Enabled = false;
                chkStatisticsIo.Checked = false;
                chkStatisticsIo.Enabled = false;
                chkStatisticsTime.Checked = false;
                chkStatisticsTime.Enabled = false;
            }
            else
            {
                chkNoCount.Enabled = true;
                chkParseOnly.Enabled = true;
                chkArithAbort.Enabled = true;
                chkShowPlanText.Enabled = true;
                chkStatisticsIo.Enabled = true;
                chkStatisticsTime.Enabled = true;
            }
        }

        private void chkShowPlanText_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPlanText.Checked)
            {
                chkNoCount.Checked = false;
                chkNoCount.Enabled = false;
                chkNoExec.Checked = false;
                chkNoExec.Enabled = false;
                chkParseOnly.Checked = false;
                chkParseOnly.Enabled = false;
                chkArithAbort.Checked = false;
                chkArithAbort.Enabled = false;
                chkStatisticsIo.Checked = false;
                chkStatisticsIo.Enabled = false;
                chkStatisticsTime.Checked = false;
                chkStatisticsTime.Enabled = false;
            }
            else
            {
                chkNoCount.Enabled = true;
                chkNoExec.Enabled = true;
                chkParseOnly.Enabled = true;
                chkArithAbort.Enabled = true;
                chkStatisticsIo.Enabled = true;
                chkStatisticsTime.Enabled = true;
            }
        }

        private void ChkANSI_CheckedChanged(object sender, EventArgs e)
        {
            if ((chkQuotedIdentifier.Checked == chkAnsiNullDflt.Checked) &&
                (chkQuotedIdentifier.Checked == chkImplicitTransactions.Checked) &&
                (chkQuotedIdentifier.Checked == chkCursorCloseOnCommit.Checked) &&
                (chkQuotedIdentifier.Checked == chkAnsiPadding.Checked) &&
                (chkQuotedIdentifier.Checked == chkAnsiWarnings.Checked) &&
                (chkQuotedIdentifier.Checked == chkAnsiNulls.Checked))
            {
                if (((CheckBox)sender).Checked)
                    chkAnsiDefaults.CheckState = CheckState.Checked;
                else
                    chkAnsiDefaults.CheckState = CheckState.Unchecked;
            }
            else
                if (chkAnsiDefaults.CheckState != CheckState.Indeterminate)
                    chkAnsiDefaults.CheckState = CheckState.Indeterminate;
        }

        private void chkAnsiDefaults_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkAnsiDefaults.CheckState == CheckState.Checked ||
                chkAnsiDefaults.CheckState == CheckState.Unchecked)
            {
                bool chk = chkAnsiDefaults.CheckState == CheckState.Checked;
                chkQuotedIdentifier.Checked = chk;
                chkAnsiNullDflt.Checked = chk;
                chkImplicitTransactions.Checked = chk;
                chkCursorCloseOnCommit.Checked = chk;
                chkAnsiPadding.Checked = chk;
                chkAnsiWarnings.Checked = chk;
                chkAnsiNulls.Checked = chk;
            }
        }

        private void cmdResetToDefault_ANSI_Click(object sender, EventArgs e)
        {
            chkQuotedIdentifier.Checked = true;
            chkAnsiNullDflt.Checked = true;
            chkImplicitTransactions.Checked = false;
            chkCursorCloseOnCommit.Checked = false;
            chkAnsiPadding.Checked = true;
            chkAnsiWarnings.Checked = true;
            chkAnsiNulls.Checked = true;
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}