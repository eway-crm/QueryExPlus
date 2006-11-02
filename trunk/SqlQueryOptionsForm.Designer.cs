namespace QueryExPlus
{
    partial class SqlQueryOptionsForm
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cmdResetToDefault_Advanced = new System.Windows.Forms.Button();
            this.cboDeadlockPriority = new System.Windows.Forms.ComboBox();
            this.cboTransactionIsolation = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtLockTimeout = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.txtQueryGovernorCostLimit = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.chkStatisticsIo = new System.Windows.Forms.CheckBox();
            this.chkStatisticsTime = new System.Windows.Forms.CheckBox();
            this.chkShowPlanText = new System.Windows.Forms.CheckBox();
            this.chkArithAbort = new System.Windows.Forms.CheckBox();
            this.chkConcatNullYieldsNull = new System.Windows.Forms.CheckBox();
            this.chkParseOnly = new System.Windows.Forms.CheckBox();
            this.chkNoExec = new System.Windows.Forms.CheckBox();
            this.chkNoCount = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cmdResetToDefault_ANSI = new System.Windows.Forms.Button();
            this.chkQuotedIdentifier = new System.Windows.Forms.CheckBox();
            this.chkAnsiNullDflt = new System.Windows.Forms.CheckBox();
            this.chkImplicitTransactions = new System.Windows.Forms.CheckBox();
            this.chkCursorCloseOnCommit = new System.Windows.Forms.CheckBox();
            this.chkAnsiPadding = new System.Windows.Forms.CheckBox();
            this.chkAnsiWarnings = new System.Windows.Forms.CheckBox();
            this.chkAnsiNulls = new System.Windows.Forms.CheckBox();
            this.chkAnsiDefaults = new System.Windows.Forms.CheckBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOk = new System.Windows.Forms.Button();
            tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLockTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQueryGovernorCostLimit)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(389, 312);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cmdResetToDefault_Advanced);
            this.tabPage2.Controls.Add(this.cboDeadlockPriority);
            this.tabPage2.Controls.Add(this.cboTransactionIsolation);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.txtLockTimeout);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.txtQueryGovernorCostLimit);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.chkStatisticsIo);
            this.tabPage2.Controls.Add(this.chkStatisticsTime);
            this.tabPage2.Controls.Add(this.chkShowPlanText);
            this.tabPage2.Controls.Add(this.chkArithAbort);
            this.tabPage2.Controls.Add(this.chkConcatNullYieldsNull);
            this.tabPage2.Controls.Add(this.chkParseOnly);
            this.tabPage2.Controls.Add(this.chkNoExec);
            this.tabPage2.Controls.Add(this.chkNoCount);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(381, 286);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Advanced";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cmdResetToDefault_Advanced
            // 
            this.cmdResetToDefault_Advanced.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdResetToDefault_Advanced.Location = new System.Drawing.Point(268, 247);
            this.cmdResetToDefault_Advanced.Name = "cmdResetToDefault_Advanced";
            this.cmdResetToDefault_Advanced.Size = new System.Drawing.Size(101, 23);
            this.cmdResetToDefault_Advanced.TabIndex = 16;
            this.cmdResetToDefault_Advanced.Text = "Reset to Default";
            this.cmdResetToDefault_Advanced.UseVisualStyleBackColor = true;
            this.cmdResetToDefault_Advanced.Click += new System.EventHandler(this.cmdResetToDefault_Advanced_Click);
            // 
            // cboDeadlockPriority
            // 
            this.cboDeadlockPriority.FormattingEnabled = true;
            this.cboDeadlockPriority.Items.AddRange(new object[] {
            "Normal",
            "Low"});
            this.cboDeadlockPriority.Location = new System.Drawing.Point(232, 131);
            this.cboDeadlockPriority.Name = "cboDeadlockPriority";
            this.cboDeadlockPriority.Size = new System.Drawing.Size(137, 21);
            this.cboDeadlockPriority.TabIndex = 11;
            // 
            // cboTransactionIsolation
            // 
            this.cboTransactionIsolation.FormattingEnabled = true;
            this.cboTransactionIsolation.Items.AddRange(new object[] {
            "READ COMMITTED",
            "READ UNCOMMITTED",
            "REPEATABLE READ",
            "SERIALIZABLE"});
            this.cboTransactionIsolation.Location = new System.Drawing.Point(232, 108);
            this.cboTransactionIsolation.Name = "cboTransactionIsolation";
            this.cboTransactionIsolation.Size = new System.Drawing.Size(137, 21);
            this.cboTransactionIsolation.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 116);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "SET LOCK TIMEOUT:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 139);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(149, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "SET DEADLOCK_PRIORITY:";
            // 
            // txtLockTimeout
            // 
            this.txtLockTimeout.Location = new System.Drawing.Point(232, 154);
            this.txtLockTimeout.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.txtLockTimeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.txtLockTimeout.Name = "txtLockTimeout";
            this.txtLockTimeout.Size = new System.Drawing.Size(137, 20);
            this.txtLockTimeout.TabIndex = 13;
            this.txtLockTimeout.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 161);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "SET LOCK TIMEOUT:";
            // 
            // txtQueryGovernorCostLimit
            // 
            this.txtQueryGovernorCostLimit.Location = new System.Drawing.Point(232, 176);
            this.txtQueryGovernorCostLimit.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.txtQueryGovernorCostLimit.Name = "txtQueryGovernorCostLimit";
            this.txtQueryGovernorCostLimit.Size = new System.Drawing.Size(137, 20);
            this.txtQueryGovernorCostLimit.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(209, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "SET QUERY_GOVERNOR_COST_LIMIT:";
            // 
            // chkStatisticsIo
            // 
            this.chkStatisticsIo.AutoSize = true;
            this.chkStatisticsIo.Location = new System.Drawing.Point(232, 89);
            this.chkStatisticsIo.Name = "chkStatisticsIo";
            this.chkStatisticsIo.Size = new System.Drawing.Size(126, 17);
            this.chkStatisticsIo.TabIndex = 7;
            this.chkStatisticsIo.Text = "SET STATISTICS IO";
            this.chkStatisticsIo.UseVisualStyleBackColor = true;
            // 
            // chkStatisticsTime
            // 
            this.chkStatisticsTime.AutoSize = true;
            this.chkStatisticsTime.Location = new System.Drawing.Point(232, 66);
            this.chkStatisticsTime.Name = "chkStatisticsTime";
            this.chkStatisticsTime.Size = new System.Drawing.Size(141, 17);
            this.chkStatisticsTime.TabIndex = 6;
            this.chkStatisticsTime.Text = "SET STATISTICS TIME";
            this.chkStatisticsTime.UseVisualStyleBackColor = true;
            // 
            // chkShowPlanText
            // 
            this.chkShowPlanText.AutoSize = true;
            this.chkShowPlanText.Location = new System.Drawing.Point(232, 43);
            this.chkShowPlanText.Name = "chkShowPlanText";
            this.chkShowPlanText.Size = new System.Drawing.Size(146, 17);
            this.chkShowPlanText.TabIndex = 5;
            this.chkShowPlanText.Text = "SET SHOWPLAN_TEXT";
            this.chkShowPlanText.UseVisualStyleBackColor = true;
            this.chkShowPlanText.CheckedChanged += new System.EventHandler(this.chkShowPlanText_CheckedChanged);
            // 
            // chkArithAbort
            // 
            this.chkArithAbort.AutoSize = true;
            this.chkArithAbort.Location = new System.Drawing.Point(232, 20);
            this.chkArithAbort.Name = "chkArithAbort";
            this.chkArithAbort.Size = new System.Drawing.Size(120, 17);
            this.chkArithAbort.TabIndex = 4;
            this.chkArithAbort.Text = "SET ARITHABORT";
            this.chkArithAbort.UseVisualStyleBackColor = true;
            // 
            // chkConcatNullYieldsNull
            // 
            this.chkConcatNullYieldsNull.AutoSize = true;
            this.chkConcatNullYieldsNull.Location = new System.Drawing.Point(15, 89);
            this.chkConcatNullYieldsNull.Name = "chkConcatNullYieldsNull";
            this.chkConcatNullYieldsNull.Size = new System.Drawing.Size(206, 17);
            this.chkConcatNullYieldsNull.TabIndex = 3;
            this.chkConcatNullYieldsNull.Text = "SET CONCAT_NULL_YIELDS_NULL";
            this.chkConcatNullYieldsNull.UseVisualStyleBackColor = true;
            // 
            // chkParseOnly
            // 
            this.chkParseOnly.AutoSize = true;
            this.chkParseOnly.Location = new System.Drawing.Point(15, 66);
            this.chkParseOnly.Name = "chkParseOnly";
            this.chkParseOnly.Size = new System.Drawing.Size(115, 17);
            this.chkParseOnly.TabIndex = 2;
            this.chkParseOnly.Text = "SET PARSEONLY";
            this.chkParseOnly.UseVisualStyleBackColor = true;
            this.chkParseOnly.CheckedChanged += new System.EventHandler(this.chkParseOnly_CheckedChanged);
            // 
            // chkNoExec
            // 
            this.chkNoExec.AutoSize = true;
            this.chkNoExec.Location = new System.Drawing.Point(15, 43);
            this.chkNoExec.Name = "chkNoExec";
            this.chkNoExec.Size = new System.Drawing.Size(94, 17);
            this.chkNoExec.TabIndex = 1;
            this.chkNoExec.Text = "SET NOEXEC";
            this.chkNoExec.UseVisualStyleBackColor = true;
            this.chkNoExec.CheckedChanged += new System.EventHandler(this.chkNoExec_CheckedChanged);
            // 
            // chkNoCount
            // 
            this.chkNoCount.AutoSize = true;
            this.chkNoCount.Location = new System.Drawing.Point(15, 20);
            this.chkNoCount.Name = "chkNoCount";
            this.chkNoCount.Size = new System.Drawing.Size(104, 17);
            this.chkNoCount.TabIndex = 0;
            this.chkNoCount.Text = "SET NOCOUNT";
            this.chkNoCount.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cmdResetToDefault_ANSI);
            this.tabPage3.Controls.Add(this.chkQuotedIdentifier);
            this.tabPage3.Controls.Add(this.chkAnsiNullDflt);
            this.tabPage3.Controls.Add(this.chkImplicitTransactions);
            this.tabPage3.Controls.Add(this.chkCursorCloseOnCommit);
            this.tabPage3.Controls.Add(this.chkAnsiPadding);
            this.tabPage3.Controls.Add(this.chkAnsiWarnings);
            this.tabPage3.Controls.Add(this.chkAnsiNulls);
            this.tabPage3.Controls.Add(this.chkAnsiDefaults);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(381, 286);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ANSI";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cmdResetToDefault_ANSI
            // 
            this.cmdResetToDefault_ANSI.Location = new System.Drawing.Point(268, 247);
            this.cmdResetToDefault_ANSI.Name = "cmdResetToDefault_ANSI";
            this.cmdResetToDefault_ANSI.Size = new System.Drawing.Size(101, 23);
            this.cmdResetToDefault_ANSI.TabIndex = 8;
            this.cmdResetToDefault_ANSI.Text = "Reset to Default";
            this.cmdResetToDefault_ANSI.UseVisualStyleBackColor = true;
            this.cmdResetToDefault_ANSI.Click += new System.EventHandler(this.cmdResetToDefault_ANSI_Click);
            // 
            // chkQuotedIdentifier
            // 
            this.chkQuotedIdentifier.AutoSize = true;
            this.chkQuotedIdentifier.Location = new System.Drawing.Point(28, 42);
            this.chkQuotedIdentifier.Name = "chkQuotedIdentifier";
            this.chkQuotedIdentifier.Size = new System.Drawing.Size(162, 17);
            this.chkQuotedIdentifier.TabIndex = 1;
            this.chkQuotedIdentifier.Text = "SET QUOTED_IDENTIFIER";
            this.chkQuotedIdentifier.UseVisualStyleBackColor = true;
            this.chkQuotedIdentifier.CheckedChanged += new System.EventHandler(this.ChkANSI_CheckedChanged);
            // 
            // chkAnsiNullDflt
            // 
            this.chkAnsiNullDflt.AutoSize = true;
            this.chkAnsiNullDflt.Location = new System.Drawing.Point(28, 65);
            this.chkAnsiNullDflt.Name = "chkAnsiNullDflt";
            this.chkAnsiNullDflt.Size = new System.Drawing.Size(164, 17);
            this.chkAnsiNullDflt.TabIndex = 2;
            this.chkAnsiNullDflt.Text = "SET ANSI_NULL_DFLT_ON";
            this.chkAnsiNullDflt.UseVisualStyleBackColor = true;
            this.chkAnsiNullDflt.CheckedChanged += new System.EventHandler(this.ChkANSI_CheckedChanged);
            // 
            // chkImplicitTransactions
            // 
            this.chkImplicitTransactions.AutoSize = true;
            this.chkImplicitTransactions.Location = new System.Drawing.Point(28, 88);
            this.chkImplicitTransactions.Name = "chkImplicitTransactions";
            this.chkImplicitTransactions.Size = new System.Drawing.Size(185, 17);
            this.chkImplicitTransactions.TabIndex = 3;
            this.chkImplicitTransactions.Text = "SET IMPLICIT_TRANSACTIONS";
            this.chkImplicitTransactions.UseVisualStyleBackColor = true;
            this.chkImplicitTransactions.CheckedChanged += new System.EventHandler(this.ChkANSI_CheckedChanged);
            // 
            // chkCursorCloseOnCommit
            // 
            this.chkCursorCloseOnCommit.AutoSize = true;
            this.chkCursorCloseOnCommit.Location = new System.Drawing.Point(28, 111);
            this.chkCursorCloseOnCommit.Name = "chkCursorCloseOnCommit";
            this.chkCursorCloseOnCommit.Size = new System.Drawing.Size(208, 17);
            this.chkCursorCloseOnCommit.TabIndex = 4;
            this.chkCursorCloseOnCommit.Text = "SET CURSOR_CLOSE_ON_COMMIT";
            this.chkCursorCloseOnCommit.UseVisualStyleBackColor = true;
            this.chkCursorCloseOnCommit.CheckedChanged += new System.EventHandler(this.ChkANSI_CheckedChanged);
            // 
            // chkAnsiPadding
            // 
            this.chkAnsiPadding.AutoSize = true;
            this.chkAnsiPadding.Location = new System.Drawing.Point(237, 42);
            this.chkAnsiPadding.Name = "chkAnsiPadding";
            this.chkAnsiPadding.Size = new System.Drawing.Size(130, 17);
            this.chkAnsiPadding.TabIndex = 5;
            this.chkAnsiPadding.Text = "SET ANSI_PADDING";
            this.chkAnsiPadding.UseVisualStyleBackColor = true;
            this.chkAnsiPadding.CheckedChanged += new System.EventHandler(this.ChkANSI_CheckedChanged);
            // 
            // chkAnsiWarnings
            // 
            this.chkAnsiWarnings.AutoSize = true;
            this.chkAnsiWarnings.Location = new System.Drawing.Point(237, 65);
            this.chkAnsiWarnings.Name = "chkAnsiWarnings";
            this.chkAnsiWarnings.Size = new System.Drawing.Size(141, 17);
            this.chkAnsiWarnings.TabIndex = 6;
            this.chkAnsiWarnings.Text = "SET ANSI_WARNINGS";
            this.chkAnsiWarnings.UseVisualStyleBackColor = true;
            this.chkAnsiWarnings.CheckedChanged += new System.EventHandler(this.ChkANSI_CheckedChanged);
            // 
            // chkAnsiNulls
            // 
            this.chkAnsiNulls.AutoSize = true;
            this.chkAnsiNulls.Location = new System.Drawing.Point(237, 88);
            this.chkAnsiNulls.Name = "chkAnsiNulls";
            this.chkAnsiNulls.Size = new System.Drawing.Size(116, 17);
            this.chkAnsiNulls.TabIndex = 7;
            this.chkAnsiNulls.Text = "SET ANSI_NULLS";
            this.chkAnsiNulls.UseVisualStyleBackColor = true;
            this.chkAnsiNulls.CheckedChanged += new System.EventHandler(this.ChkANSI_CheckedChanged);
            // 
            // chkAnsiDefaults
            // 
            this.chkAnsiDefaults.AutoSize = true;
            this.chkAnsiDefaults.Location = new System.Drawing.Point(17, 15);
            this.chkAnsiDefaults.Name = "chkAnsiDefaults";
            this.chkAnsiDefaults.Size = new System.Drawing.Size(134, 17);
            this.chkAnsiDefaults.TabIndex = 0;
            this.chkAnsiDefaults.Text = "SET ANSI DEFAULTS";
            this.chkAnsiDefaults.UseVisualStyleBackColor = true;
            this.chkAnsiDefaults.CheckedChanged += new System.EventHandler(this.chkAnsiDefaults_CheckStateChanged);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(314, 334);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(80, 23);
            this.cmdCancel.TabIndex = 18;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOk
            // 
            this.cmdOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdOk.Location = new System.Drawing.Point(214, 334);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(80, 23);
            this.cmdOk.TabIndex = 19;
            this.cmdOk.Text = "OK";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // SqlQueryOptionsForm
            // 
            this.AcceptButton = this.cmdOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(413, 369);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SqlQueryOptionsForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLockTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQueryGovernorCostLimit)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        internal System.Windows.Forms.CheckBox chkStatisticsIo;
        internal System.Windows.Forms.CheckBox chkStatisticsTime;
        internal System.Windows.Forms.CheckBox chkShowPlanText;
        internal System.Windows.Forms.CheckBox chkArithAbort;
        internal System.Windows.Forms.CheckBox chkConcatNullYieldsNull;
        internal System.Windows.Forms.CheckBox chkParseOnly;
        internal System.Windows.Forms.CheckBox chkNoExec;
        internal System.Windows.Forms.CheckBox chkNoCount;
        internal System.Windows.Forms.NumericUpDown txtLockTimeout;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.NumericUpDown txtQueryGovernorCostLimit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button cmdResetToDefault_Advanced;
        internal System.Windows.Forms.ComboBox cboDeadlockPriority;
        internal System.Windows.Forms.ComboBox cboTransactionIsolation;
        internal System.Windows.Forms.CheckBox chkQuotedIdentifier;
        internal System.Windows.Forms.CheckBox chkAnsiNullDflt;
        internal System.Windows.Forms.CheckBox chkImplicitTransactions;
        internal System.Windows.Forms.CheckBox chkCursorCloseOnCommit;
        internal System.Windows.Forms.CheckBox chkAnsiPadding;
        internal System.Windows.Forms.CheckBox chkAnsiWarnings;
        internal System.Windows.Forms.CheckBox chkAnsiNulls;
        private System.Windows.Forms.CheckBox chkAnsiDefaults;
        private System.Windows.Forms.Button cmdResetToDefault_ANSI;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOk;
    }
}