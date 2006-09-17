using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace QueryExPlus
{
	/// <summary>
	/// Summary description for SqlQueryOptionsForm.
	/// </summary>
	public class SqlQueryOptionsForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button cmdResetToDefault_General;
		internal System.Windows.Forms.TextBox txtBatchSeparator;
		private System.Windows.Forms.Button cmdOk;
		private System.Windows.Forms.Button cmdCancel;
		internal System.Windows.Forms.NumericUpDown txtRowcount;
		internal System.Windows.Forms.NumericUpDown txtTextSize;
		internal System.Windows.Forms.NumericUpDown txtExecutionTimeout;
		internal System.Windows.Forms.CheckBox chkNoCount;
		internal System.Windows.Forms.CheckBox chkStatisticsTime;
		internal System.Windows.Forms.CheckBox chkShowPlanText;
		internal System.Windows.Forms.CheckBox chkArithAbort;
		internal System.Windows.Forms.CheckBox chkConcatNullYieldsNull;
		internal System.Windows.Forms.CheckBox chkParseOnly;
		internal System.Windows.Forms.CheckBox chkNoExec;
		internal System.Windows.Forms.CheckBox chkStatisticsIo;
		private System.Windows.Forms.Button cmdResetToDefault_Advanced;
		private System.Windows.Forms.Label label9;
		internal System.Windows.Forms.ComboBox cboTransactionIsolation;
		internal System.Windows.Forms.ComboBox cboDeadlockPriority;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		internal System.Windows.Forms.NumericUpDown txtLockTimeout;
		internal System.Windows.Forms.NumericUpDown txtQueryGovernorCostLimit;
		private System.Windows.Forms.Label label12;
		internal System.Windows.Forms.CheckBox chkQuotedIdentifier;
		internal System.Windows.Forms.CheckBox chkAnsiNullDflt;
		internal System.Windows.Forms.CheckBox chkImplicitTransactions;
		internal System.Windows.Forms.CheckBox chkCursorCloseOnCommit;
		internal System.Windows.Forms.CheckBox chkAnsiPadding;
		internal System.Windows.Forms.CheckBox chkAnsiWarnings;
		internal System.Windows.Forms.CheckBox chkAnsiNulls;
		private System.Windows.Forms.CheckBox chkAnsiDefaults;
		private System.Windows.Forms.Button cmdResetToDefault_ANSI;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SqlQueryOptionsForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SqlQueryOptionsForm));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.txtRowcount = new System.Windows.Forms.NumericUpDown();
			this.cmdResetToDefault_General = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtBatchSeparator = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtTextSize = new System.Windows.Forms.NumericUpDown();
			this.txtExecutionTimeout = new System.Windows.Forms.NumericUpDown();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.txtQueryGovernorCostLimit = new System.Windows.Forms.NumericUpDown();
			this.label12 = new System.Windows.Forms.Label();
			this.txtLockTimeout = new System.Windows.Forms.NumericUpDown();
			this.label11 = new System.Windows.Forms.Label();
			this.cboTransactionIsolation = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.cmdResetToDefault_Advanced = new System.Windows.Forms.Button();
			this.chkStatisticsIo = new System.Windows.Forms.CheckBox();
			this.chkNoExec = new System.Windows.Forms.CheckBox();
			this.chkParseOnly = new System.Windows.Forms.CheckBox();
			this.chkConcatNullYieldsNull = new System.Windows.Forms.CheckBox();
			this.chkArithAbort = new System.Windows.Forms.CheckBox();
			this.chkShowPlanText = new System.Windows.Forms.CheckBox();
			this.chkStatisticsTime = new System.Windows.Forms.CheckBox();
			this.chkNoCount = new System.Windows.Forms.CheckBox();
			this.cboDeadlockPriority = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.chkAnsiNulls = new System.Windows.Forms.CheckBox();
			this.chkImplicitTransactions = new System.Windows.Forms.CheckBox();
			this.chkAnsiNullDflt = new System.Windows.Forms.CheckBox();
			this.chkQuotedIdentifier = new System.Windows.Forms.CheckBox();
			this.chkAnsiDefaults = new System.Windows.Forms.CheckBox();
			this.chkCursorCloseOnCommit = new System.Windows.Forms.CheckBox();
			this.chkAnsiPadding = new System.Windows.Forms.CheckBox();
			this.chkAnsiWarnings = new System.Windows.Forms.CheckBox();
			this.cmdOk = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdResetToDefault_ANSI = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtRowcount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTextSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtExecutionTimeout)).BeginInit();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtQueryGovernorCostLimit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLockTimeout)).BeginInit();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Location = new System.Drawing.Point(6, 7);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(394, 337);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.txtRowcount);
			this.tabPage1.Controls.Add(this.cmdResetToDefault_General);
			this.tabPage1.Controls.Add(this.label7);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.label6);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.txtBatchSeparator);
			this.tabPage1.Controls.Add(this.label8);
			this.tabPage1.Controls.Add(this.txtTextSize);
			this.tabPage1.Controls.Add(this.txtExecutionTimeout);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(386, 311);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "General";
			// 
			// txtRowcount
			// 
			this.txtRowcount.Location = new System.Drawing.Point(160, 48);
			this.txtRowcount.Maximum = new System.Decimal(new int[] {
																		2147483647,
																		0,
																		0,
																		0});
			this.txtRowcount.Name = "txtRowcount";
			this.txtRowcount.Size = new System.Drawing.Size(100, 20);
			this.txtRowcount.TabIndex = 14;
			// 
			// cmdResetToDefault_General
			// 
			this.cmdResetToDefault_General.Location = new System.Drawing.Point(256, 280);
			this.cmdResetToDefault_General.Name = "cmdResetToDefault_General";
			this.cmdResetToDefault_General.Size = new System.Drawing.Size(112, 23);
			this.cmdResetToDefault_General.TabIndex = 13;
			this.cmdResetToDefault_General.Text = "Reset to Default";
			this.cmdResetToDefault_General.Click += new System.EventHandler(this.cmdResetToDefault_General_Click);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 224);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(344, 16);
			this.label7.TabIndex = 12;
			this.label7.Text = "Specify a word or character that can be used to separate batches.";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 168);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(344, 16);
			this.label5.TabIndex = 9;
			this.label5.Text = "An execution time-out of 0 indicates an unlimited wait (no time-out).";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(32, 192);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(120, 23);
			this.label6.TabIndex = 7;
			this.label6.Text = "Execution time-out:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(344, 32);
			this.label3.TabIndex = 6;
			this.label3.Text = "Specify the maximum size of text and ntext data returned from a SELECT statement." +
				"";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(344, 32);
			this.label2.TabIndex = 3;
			this.label2.Text = "Specify the maximum number of rows to return before the server stops processing y" +
				"our query.";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "SET ROWCOUNT:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(32, 128);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(120, 23);
			this.label4.TabIndex = 1;
			this.label4.Text = "SET TEXTSIZE:";
			// 
			// txtBatchSeparator
			// 
			this.txtBatchSeparator.Location = new System.Drawing.Point(160, 248);
			this.txtBatchSeparator.Name = "txtBatchSeparator";
			this.txtBatchSeparator.TabIndex = 8;
			this.txtBatchSeparator.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(32, 248);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(120, 23);
			this.label8.TabIndex = 7;
			this.label8.Text = "Batch separator:";
			// 
			// txtTextSize
			// 
			this.txtTextSize.Location = new System.Drawing.Point(160, 128);
			this.txtTextSize.Maximum = new System.Decimal(new int[] {
																		2147483647,
																		0,
																		0,
																		0});
			this.txtTextSize.Name = "txtTextSize";
			this.txtTextSize.Size = new System.Drawing.Size(100, 20);
			this.txtTextSize.TabIndex = 14;
			// 
			// txtExecutionTimeout
			// 
			this.txtExecutionTimeout.Location = new System.Drawing.Point(160, 192);
			this.txtExecutionTimeout.Maximum = new System.Decimal(new int[] {
																				2147483647,
																				0,
																				0,
																				0});
			this.txtExecutionTimeout.Name = "txtExecutionTimeout";
			this.txtExecutionTimeout.Size = new System.Drawing.Size(100, 20);
			this.txtExecutionTimeout.TabIndex = 14;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.txtQueryGovernorCostLimit);
			this.tabPage2.Controls.Add(this.label12);
			this.tabPage2.Controls.Add(this.txtLockTimeout);
			this.tabPage2.Controls.Add(this.label11);
			this.tabPage2.Controls.Add(this.cboTransactionIsolation);
			this.tabPage2.Controls.Add(this.label9);
			this.tabPage2.Controls.Add(this.cmdResetToDefault_Advanced);
			this.tabPage2.Controls.Add(this.chkStatisticsIo);
			this.tabPage2.Controls.Add(this.chkNoExec);
			this.tabPage2.Controls.Add(this.chkParseOnly);
			this.tabPage2.Controls.Add(this.chkConcatNullYieldsNull);
			this.tabPage2.Controls.Add(this.chkArithAbort);
			this.tabPage2.Controls.Add(this.chkShowPlanText);
			this.tabPage2.Controls.Add(this.chkStatisticsTime);
			this.tabPage2.Controls.Add(this.chkNoCount);
			this.tabPage2.Controls.Add(this.cboDeadlockPriority);
			this.tabPage2.Controls.Add(this.label10);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(386, 311);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Advanced";
			// 
			// txtQueryGovernorCostLimit
			// 
			this.txtQueryGovernorCostLimit.Location = new System.Drawing.Point(232, 192);
			this.txtQueryGovernorCostLimit.Maximum = new System.Decimal(new int[] {
																					  2147483647,
																					  0,
																					  0,
																					  0});
			this.txtQueryGovernorCostLimit.Name = "txtQueryGovernorCostLimit";
			this.txtQueryGovernorCostLimit.Size = new System.Drawing.Size(100, 20);
			this.txtQueryGovernorCostLimit.TabIndex = 20;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(16, 192);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(224, 23);
			this.label12.TabIndex = 19;
			this.label12.Text = "SET QUERY_GOVERNOR_COST_LIMIT:";
			// 
			// txtLockTimeout
			// 
			this.txtLockTimeout.Location = new System.Drawing.Point(232, 168);
			this.txtLockTimeout.Maximum = new System.Decimal(new int[] {
																		   2147483647,
																		   0,
																		   0,
																		   0});
			this.txtLockTimeout.Minimum = new System.Decimal(new int[] {
																		   1,
																		   0,
																		   0,
																		   -2147483648});
			this.txtLockTimeout.Name = "txtLockTimeout";
			this.txtLockTimeout.Size = new System.Drawing.Size(100, 20);
			this.txtLockTimeout.TabIndex = 18;
			this.txtLockTimeout.Value = new System.Decimal(new int[] {
																		 1,
																		 0,
																		 0,
																		 -2147483648});
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(16, 168);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(120, 23);
			this.label11.TabIndex = 17;
			this.label11.Text = "SET LOCK TIMEOUT:";
			// 
			// cboTransactionIsolation
			// 
			this.cboTransactionIsolation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTransactionIsolation.Items.AddRange(new object[] {
																		 "READ COMMITTED",
																		 "READ UNCOMMITTED",
																		 "REPEATABLE READ",
																		 "SERIALIZABLE"});
			this.cboTransactionIsolation.Location = new System.Drawing.Point(232, 120);
			this.cboTransactionIsolation.Name = "cboTransactionIsolation";
			this.cboTransactionIsolation.Size = new System.Drawing.Size(144, 21);
			this.cboTransactionIsolation.TabIndex = 16;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(16, 120);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(232, 16);
			this.label9.TabIndex = 15;
			this.label9.Text = "SET TRANSACTION ISOLATION LEVEL:";
			// 
			// cmdResetToDefault_Advanced
			// 
			this.cmdResetToDefault_Advanced.Location = new System.Drawing.Point(256, 280);
			this.cmdResetToDefault_Advanced.Name = "cmdResetToDefault_Advanced";
			this.cmdResetToDefault_Advanced.Size = new System.Drawing.Size(112, 23);
			this.cmdResetToDefault_Advanced.TabIndex = 14;
			this.cmdResetToDefault_Advanced.Text = "Reset to Default";
			this.cmdResetToDefault_Advanced.Click += new System.EventHandler(this.cmdResetToDefault_Advanced_Click);
			// 
			// chkStatisticsIo
			// 
			this.chkStatisticsIo.Location = new System.Drawing.Point(232, 88);
			this.chkStatisticsIo.Name = "chkStatisticsIo";
			this.chkStatisticsIo.Size = new System.Drawing.Size(144, 24);
			this.chkStatisticsIo.TabIndex = 7;
			this.chkStatisticsIo.Text = "SET STATISTICS IO";
			// 
			// chkNoExec
			// 
			this.chkNoExec.Location = new System.Drawing.Point(16, 40);
			this.chkNoExec.Name = "chkNoExec";
			this.chkNoExec.Size = new System.Drawing.Size(216, 24);
			this.chkNoExec.TabIndex = 6;
			this.chkNoExec.Text = "SET NOEXEC";
			this.chkNoExec.CheckedChanged += new System.EventHandler(this.chkNoExec_CheckedChanged);
			// 
			// chkParseOnly
			// 
			this.chkParseOnly.Location = new System.Drawing.Point(16, 64);
			this.chkParseOnly.Name = "chkParseOnly";
			this.chkParseOnly.Size = new System.Drawing.Size(216, 24);
			this.chkParseOnly.TabIndex = 5;
			this.chkParseOnly.Text = "SET PARSEONLY";
			this.chkParseOnly.CheckedChanged += new System.EventHandler(this.chkParseOnly_CheckedChanged);
			// 
			// chkConcatNullYieldsNull
			// 
			this.chkConcatNullYieldsNull.Location = new System.Drawing.Point(16, 88);
			this.chkConcatNullYieldsNull.Name = "chkConcatNullYieldsNull";
			this.chkConcatNullYieldsNull.Size = new System.Drawing.Size(216, 24);
			this.chkConcatNullYieldsNull.TabIndex = 4;
			this.chkConcatNullYieldsNull.Text = "SET CONCAT_NULL_YIELDS_NULL";
			// 
			// chkArithAbort
			// 
			this.chkArithAbort.Location = new System.Drawing.Point(232, 16);
			this.chkArithAbort.Name = "chkArithAbort";
			this.chkArithAbort.Size = new System.Drawing.Size(128, 24);
			this.chkArithAbort.TabIndex = 3;
			this.chkArithAbort.Text = "SET ARITHABORT";
			// 
			// chkShowPlanText
			// 
			this.chkShowPlanText.Location = new System.Drawing.Point(232, 40);
			this.chkShowPlanText.Name = "chkShowPlanText";
			this.chkShowPlanText.Size = new System.Drawing.Size(152, 24);
			this.chkShowPlanText.TabIndex = 2;
			this.chkShowPlanText.Text = "SET SHOWPLAN_TEXT";
			this.chkShowPlanText.CheckedChanged += new System.EventHandler(this.chkShowPlanText_CheckedChanged);
			// 
			// chkStatisticsTime
			// 
			this.chkStatisticsTime.Location = new System.Drawing.Point(232, 64);
			this.chkStatisticsTime.Name = "chkStatisticsTime";
			this.chkStatisticsTime.Size = new System.Drawing.Size(144, 24);
			this.chkStatisticsTime.TabIndex = 1;
			this.chkStatisticsTime.Text = "SET STATISTICS TIME";
			// 
			// chkNoCount
			// 
			this.chkNoCount.Location = new System.Drawing.Point(16, 16);
			this.chkNoCount.Name = "chkNoCount";
			this.chkNoCount.Size = new System.Drawing.Size(216, 24);
			this.chkNoCount.TabIndex = 0;
			this.chkNoCount.Text = "SET NOCOUNT";
			// 
			// cboDeadlockPriority
			// 
			this.cboDeadlockPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboDeadlockPriority.Items.AddRange(new object[] {
																	 "Normal",
																	 "Low"});
			this.cboDeadlockPriority.Location = new System.Drawing.Point(232, 144);
			this.cboDeadlockPriority.Name = "cboDeadlockPriority";
			this.cboDeadlockPriority.Size = new System.Drawing.Size(144, 21);
			this.cboDeadlockPriority.TabIndex = 16;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(16, 144);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(232, 16);
			this.label10.TabIndex = 15;
			this.label10.Text = "SET DEADLOCK_PRIORITY:";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.cmdResetToDefault_ANSI);
			this.tabPage3.Controls.Add(this.chkAnsiNulls);
			this.tabPage3.Controls.Add(this.chkImplicitTransactions);
			this.tabPage3.Controls.Add(this.chkAnsiNullDflt);
			this.tabPage3.Controls.Add(this.chkQuotedIdentifier);
			this.tabPage3.Controls.Add(this.chkAnsiDefaults);
			this.tabPage3.Controls.Add(this.chkCursorCloseOnCommit);
			this.tabPage3.Controls.Add(this.chkAnsiPadding);
			this.tabPage3.Controls.Add(this.chkAnsiWarnings);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(386, 311);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "ANSI";
			// 
			// chkAnsiNulls
			// 
			this.chkAnsiNulls.Location = new System.Drawing.Point(232, 96);
			this.chkAnsiNulls.Name = "chkAnsiNulls";
			this.chkAnsiNulls.Size = new System.Drawing.Size(144, 24);
			this.chkAnsiNulls.TabIndex = 4;
			this.chkAnsiNulls.Text = "SET ANSI_NULLS";
			this.chkAnsiNulls.CheckedChanged += new System.EventHandler(this.ChkANSI_CheckedChanged);
			// 
			// chkImplicitTransactions
			// 
			this.chkImplicitTransactions.Location = new System.Drawing.Point(24, 96);
			this.chkImplicitTransactions.Name = "chkImplicitTransactions";
			this.chkImplicitTransactions.Size = new System.Drawing.Size(208, 24);
			this.chkImplicitTransactions.TabIndex = 3;
			this.chkImplicitTransactions.Text = "SET IMPLICIT_TRANSACTIONS";
			this.chkImplicitTransactions.CheckedChanged += new System.EventHandler(this.ChkANSI_CheckedChanged);
			// 
			// chkAnsiNullDflt
			// 
			this.chkAnsiNullDflt.Location = new System.Drawing.Point(24, 72);
			this.chkAnsiNullDflt.Name = "chkAnsiNullDflt";
			this.chkAnsiNullDflt.Size = new System.Drawing.Size(208, 24);
			this.chkAnsiNullDflt.TabIndex = 2;
			this.chkAnsiNullDflt.Text = "SET ANSI_NULL_DFLT_ON";
			this.chkAnsiNullDflt.CheckedChanged += new System.EventHandler(this.ChkANSI_CheckedChanged);
			// 
			// chkQuotedIdentifier
			// 
			this.chkQuotedIdentifier.Location = new System.Drawing.Point(24, 48);
			this.chkQuotedIdentifier.Name = "chkQuotedIdentifier";
			this.chkQuotedIdentifier.Size = new System.Drawing.Size(208, 24);
			this.chkQuotedIdentifier.TabIndex = 1;
			this.chkQuotedIdentifier.Text = "SET QUOTED_IDENTIFIER";
			this.chkQuotedIdentifier.CheckedChanged += new System.EventHandler(this.ChkANSI_CheckedChanged);
			// 
			// chkAnsiDefaults
			// 
			this.chkAnsiDefaults.Location = new System.Drawing.Point(8, 16);
			this.chkAnsiDefaults.Name = "chkAnsiDefaults";
			this.chkAnsiDefaults.Size = new System.Drawing.Size(144, 24);
			this.chkAnsiDefaults.TabIndex = 0;
			this.chkAnsiDefaults.Text = "SET ANSI DEFAULTS";
			this.chkAnsiDefaults.ThreeState = true;
			this.chkAnsiDefaults.CheckStateChanged += new System.EventHandler(this.chkAnsiDefaults_CheckStateChanged);
			// 
			// chkCursorCloseOnCommit
			// 
			this.chkCursorCloseOnCommit.Location = new System.Drawing.Point(24, 120);
			this.chkCursorCloseOnCommit.Name = "chkCursorCloseOnCommit";
			this.chkCursorCloseOnCommit.Size = new System.Drawing.Size(224, 24);
			this.chkCursorCloseOnCommit.TabIndex = 3;
			this.chkCursorCloseOnCommit.Text = "SET CURSOR_CLOSE_ON_COMMIT";
			this.chkCursorCloseOnCommit.CheckedChanged += new System.EventHandler(this.ChkANSI_CheckedChanged);
			// 
			// chkAnsiPadding
			// 
			this.chkAnsiPadding.Location = new System.Drawing.Point(232, 48);
			this.chkAnsiPadding.Name = "chkAnsiPadding";
			this.chkAnsiPadding.Size = new System.Drawing.Size(144, 24);
			this.chkAnsiPadding.TabIndex = 3;
			this.chkAnsiPadding.Text = "SET ANSI_PADDING";
			this.chkAnsiPadding.CheckedChanged += new System.EventHandler(this.ChkANSI_CheckedChanged);
			// 
			// chkAnsiWarnings
			// 
			this.chkAnsiWarnings.Location = new System.Drawing.Point(232, 72);
			this.chkAnsiWarnings.Name = "chkAnsiWarnings";
			this.chkAnsiWarnings.Size = new System.Drawing.Size(144, 24);
			this.chkAnsiWarnings.TabIndex = 3;
			this.chkAnsiWarnings.Text = "SET ANSI_WARNINGS";
			this.chkAnsiWarnings.CheckedChanged += new System.EventHandler(this.ChkANSI_CheckedChanged);
			// 
			// cmdOk
			// 
			this.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.cmdOk.Location = new System.Drawing.Point(232, 352);
			this.cmdOk.Name = "cmdOk";
			this.cmdOk.TabIndex = 1;
			this.cmdOk.Text = "OK";
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(320, 352);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 2;
			this.cmdCancel.Text = "Cancel";
			// 
			// cmdResetToDefault_ANSI
			// 
			this.cmdResetToDefault_ANSI.Location = new System.Drawing.Point(256, 280);
			this.cmdResetToDefault_ANSI.Name = "cmdResetToDefault_ANSI";
			this.cmdResetToDefault_ANSI.Size = new System.Drawing.Size(112, 23);
			this.cmdResetToDefault_ANSI.TabIndex = 15;
			this.cmdResetToDefault_ANSI.Text = "Reset to Default";
			this.cmdResetToDefault_ANSI.Click += new System.EventHandler(this.cmdResetToDefault_ANSI_Click);
			// 
			// SqlQueryOptionsForm
			// 
			this.AcceptButton = this.cmdOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(402, 384);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOk);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SqlQueryOptionsForm";
			this.Tag = "Query Options";
			this.Text = "SqlQueryOptionsForm";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtRowcount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTextSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtExecutionTimeout)).EndInit();
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtQueryGovernorCostLimit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLockTimeout)).EndInit();
			this.tabPage3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void cmdResetToDefault_General_Click(object sender, System.EventArgs e)
		{
			txtRowcount.Value = 0;
			txtTextSize.Value= 2147483647;
			txtExecutionTimeout.Value= 0;
			txtBatchSeparator.Text = "GO";
		}

		private void cmdResetToDefault_Advanced_Click(object sender, System.EventArgs e)
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

		private void chkParseOnly_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chkParseOnly.Checked)
			{
				chkNoCount.Checked = false;
				chkNoCount.Enabled = false;
				chkNoExec.Checked = false;
				chkNoExec.Enabled = false;
				chkArithAbort.Checked = false;
				chkArithAbort.Enabled = false;
				chkShowPlanText.Checked= false;
				chkShowPlanText.Enabled = false;
				chkStatisticsIo.Checked= false;
				chkStatisticsIo.Enabled = false;
				chkStatisticsTime.Checked= false;
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

		private void chkNoExec_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chkNoExec.Checked)
			{
				chkNoCount.Checked = false;
				chkNoCount.Enabled = false;
				chkParseOnly.Checked = false;
				chkParseOnly.Enabled = false;
				chkArithAbort.Checked = false;
				chkArithAbort.Enabled = false;
				chkShowPlanText.Checked= false;
				chkShowPlanText.Enabled = false;
				chkStatisticsIo.Checked= false;
				chkStatisticsIo.Enabled = false;
				chkStatisticsTime.Checked= false;
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

		private void chkShowPlanText_CheckedChanged(object sender, System.EventArgs e)
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
				chkStatisticsIo.Checked= false;
				chkStatisticsIo.Enabled = false;
				chkStatisticsTime.Checked= false;
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

		private void ChkANSI_CheckedChanged(object sender, System.EventArgs e)
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

		private void chkAnsiDefaults_CheckStateChanged(object sender, System.EventArgs e)
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

		private void cmdResetToDefault_ANSI_Click(object sender, System.EventArgs e)
		{
				chkQuotedIdentifier.Checked = true;
				chkAnsiNullDflt.Checked = true;
				chkImplicitTransactions.Checked = false;
				chkCursorCloseOnCommit.Checked = false;
				chkAnsiPadding.Checked = true;
				chkAnsiWarnings.Checked = true;
				chkAnsiNulls.Checked = true;		
		}
	}
}
