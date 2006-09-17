using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace QueryExPlus
{
	/// <summary>
	/// Query Options
	/// </summary>
	internal class SqlQueryOptons : IQueryOptions
	{
		#region Private Fields

		private int _RowCount = 0 ;
		private int _TextSize = 2147483647;            
		private int _ExecutionTimeout = 0 ;            
		private string _BatchSeparator = "GO";            
		private bool _NoCount;            
		private bool _NoExec;            
		private bool _ParseOnly;            
		private bool _Concat_Null_Yields_Null = true;            
		private bool _ArithAbort = true;
		private int _Lock_Timeout = -1;
		private int _Query_Governor_Cost_Limit = 0;
		private string _Deadlock_Priority = "NORMAL";
		private string _Transaction_Isolation_Level = "READ COMMITTED";
		private bool _Ansi_Nulls = true;
		private bool _Ansi_Warnings = true;
		private bool _Ansi_Padding = true;
		private bool _Cursor_Close_On_Commit;            
		private bool _Quoted_Identifier = true;            
		private bool _Implicit_Transactions;            
		private bool _Ansi_Null_Dflt_On = true;

		private bool _ShowPlanText= false;
		private bool _StatisticsTime= false;
		private bool _StatisticsIo = false;

		#endregion

		#region Constructor

		public SqlQueryOptons()
		{
		}

		#endregion

		#region Public Properties

		public int RowCount
		{
			get { return _RowCount; }
			set { _RowCount = value; }
		}

		public int TextSize
		{
			get { return _TextSize; }
			set { _TextSize = value; }
		}

		public int ExecutionTimeout
		{
			get { return _ExecutionTimeout; }
			set { _ExecutionTimeout = value; }
		}

		public string BatchSeparator
		{
			get { return _BatchSeparator; }
			set { _BatchSeparator = value; }
		}

		public bool NoCount
		{
			get { return _NoCount; }
			set { _NoCount = value; }
		}

		public bool NoExec
		{
			get { return _NoExec; }
			set { _NoExec = value; }
		}

		public bool ParseOnly
		{
			get { return _ParseOnly; }
			set { _ParseOnly = value; }
		}

		public bool Concat_Null_Yields_Null
		{
			get { return _Concat_Null_Yields_Null; }
			set { _Concat_Null_Yields_Null = value; }
		}

		public bool ArithAbort
		{
			get { return _ArithAbort; }
			set { _ArithAbort = value; }
		}

		public int Lock_Timeout
		{
			get { return _Lock_Timeout; }
			set { _Lock_Timeout = value; }
		}

		public int Query_Governor_Cost_Limit
		{
			get { return _Query_Governor_Cost_Limit; }
			set { _Query_Governor_Cost_Limit = value; }
		}

		public string Deadlock_Priority
		{
			get { return _Deadlock_Priority; }
			set { _Deadlock_Priority = value; }
		}

		public string Transaction_Isolation_Level
		{
			get { return _Transaction_Isolation_Level; }
			set { _Transaction_Isolation_Level = value; }
		}

		public bool Ansi_Nulls
		{
			get { return _Ansi_Nulls; }
			set { _Ansi_Nulls = value; }
		}

		public bool Ansi_Warnings
		{
			get { return _Ansi_Warnings; }
			set { _Ansi_Warnings = value; }
		}

		public bool Ansi_Padding
		{
			get { return _Ansi_Padding; }
			set { _Ansi_Padding = value; }
		}

		public bool Cursor_Close_On_Commit
		{
			get { return _Cursor_Close_On_Commit; }
			set { _Cursor_Close_On_Commit = value; }
		}

		public bool Quoted_Identifier
		{
			get { return _Quoted_Identifier; }
			set { _Quoted_Identifier = value; }
		}

		public bool Implicit_Transactions
		{
			get { return _Implicit_Transactions; }
			set { _Implicit_Transactions = value; }
		}

		public bool Ansi_Null_Dflt_On
		{
			get { return _Ansi_Null_Dflt_On; }
			set { _Ansi_Null_Dflt_On = value; }
		}


		public bool ShowPlanText
		{
			get { return _ShowPlanText; }
			set { _ShowPlanText = value; }
		}

		public bool StatisticsTime
		{
			get { return _StatisticsTime; }
			set { _StatisticsTime = value; }
		}

		public bool StatisticsIo
		{
			get { return _StatisticsIo; }
			set { _StatisticsIo = value; }
		}

		#endregion

		#region Interface Definition

		public void ApplyToConnection(IDbConnection connection)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(string.Format(" SET ROWCOUNT {0}", _RowCount));
			sb.Append(string.Format(" SET TEXTSIZE {0}", _TextSize));
			sb.Append(string.Format(" SET NOCOUNT {0}", _NoCount ? "ON": "OFF"));
			sb.Append(string.Format(" SET CONCAT_NULL_YIELDS_NULL {0}", _Concat_Null_Yields_Null ? "ON": "OFF"));
			sb.Append(string.Format(" SET ARITHABORT {0}", _ArithAbort ? "ON": "OFF"));
			sb.Append(string.Format(" SET LOCK_TIMEOUT {0}", _Lock_Timeout));
			sb.Append(string.Format(" SET QUERY_GOVERNOR_COST_LIMIT {0}", _Query_Governor_Cost_Limit));
			sb.Append(string.Format(" SET DEADLOCK_PRIORITY {0}", _Deadlock_Priority));
			sb.Append(string.Format(" SET TRANSACTION ISOLATION LEVEL {0}", _Transaction_Isolation_Level));
			sb.Append(string.Format(" SET ANSI_NULLS {0}", _Ansi_Nulls ? "ON": "OFF"));
			sb.Append(string.Format(" SET ANSI_NULL_DFLT_ON {0}", _Ansi_Null_Dflt_On ? "ON": "OFF"));
			sb.Append(string.Format(" SET ANSI_PADDING {0}", _Ansi_Padding ? "ON": "OFF"));
			sb.Append(string.Format(" SET ANSI_WARNINGS {0}", _Ansi_Warnings ? "ON": "OFF"));
			sb.Append(string.Format(" SET CURSOR_CLOSE_ON_COMMIT {0}", _Cursor_Close_On_Commit ? "ON": "OFF"));
			sb.Append(string.Format(" SET IMPLICIT_TRANSACTIONS {0}", _Implicit_Transactions ? "ON": "OFF"));
			sb.Append(string.Format(" SET QUOTED_IDENTIFIER {0}", _Quoted_Identifier ? "ON": "OFF"));
			
			SqlCommand cmd = new SqlCommand(sb.ToString(), (SqlConnection) connection);
			cmd.ExecuteNonQuery();
		}

		public void SetupBatch(IDbConnection connection)
		{
			StringBuilder sb = new StringBuilder();
			if (_NoExec)
				sb.Append(" SET NOEXEC ON");
			if (_ParseOnly)
				sb.Append(" SET PARSEONLY ON");
			if (_StatisticsIo)
				sb.Append(" SET STATISTICS IO ON");
			if (_StatisticsTime)
				sb.Append(" SET STATISTICS TIME ON");
			if (_ShowPlanText)
				sb.Append(" SET SHOWPLAN_TEXT ON");
			
			SqlCommand cmd = new SqlCommand(sb.ToString(), (SqlConnection) connection);
			cmd.ExecuteNonQuery();
		}

		public void ResetBatch(IDbConnection connection)
		{
			StringBuilder sb = new StringBuilder();
			if (_NoExec)
				sb.Append(" SET NOEXEC OFF");
			if (_ParseOnly)
				sb.Append(" SET PARSEONLY OFF");
			if (_StatisticsIo)
				sb.Append(" SET STATISTICS IO OFF");
			if (_StatisticsTime)
				sb.Append(" SET STATISTICS TIME OFF");
			if (_ShowPlanText)
				sb.Append(" SET SHOWPLAN_TEXT OFF");
			
			SqlCommand cmd = new SqlCommand(sb.ToString(), (SqlConnection) connection);
			cmd.ExecuteNonQuery();
		}

		public DialogResult ShowForm()
		{
			SqlQueryOptionsForm f = new SqlQueryOptionsForm();

			#region Store To Form

			f.txtBatchSeparator.Text = this.BatchSeparator;
			f.txtExecutionTimeout.Value= this.ExecutionTimeout;
			f.txtRowcount.Value= this.RowCount;
			f.txtTextSize.Value = this.TextSize;
			
			f.chkNoCount.Checked = this.NoCount;
			f.chkNoExec.Checked = this.NoExec;
			f.chkParseOnly.Checked = this.ParseOnly;
			f.chkConcatNullYieldsNull.Checked = this.Concat_Null_Yields_Null;
			f.chkArithAbort.Checked = this.ArithAbort;
			f.chkShowPlanText.Checked = this.ShowPlanText;
			f.chkStatisticsTime.Checked = this.StatisticsTime;
			f.chkStatisticsIo.Checked = this.StatisticsIo;
			
			f.cboTransactionIsolation.Text = this.Transaction_Isolation_Level;
			f.cboDeadlockPriority.Text = this.Deadlock_Priority;
			f.txtLockTimeout.Value = this.Lock_Timeout;
			f.txtQueryGovernorCostLimit.Value = this.Query_Governor_Cost_Limit;

			f.chkQuotedIdentifier.Checked = this.Quoted_Identifier;
			f.chkAnsiNullDflt.Checked = this.Ansi_Null_Dflt_On;
			f.chkImplicitTransactions.Checked = this.Implicit_Transactions;
			f.chkCursorCloseOnCommit.Checked = this.Cursor_Close_On_Commit;
			f.chkAnsiPadding.Checked = this.Ansi_Padding;
			f.chkAnsiWarnings.Checked = this.Ansi_Warnings;
			f.chkAnsiNulls.Checked = this.Ansi_Nulls;		
			#endregion
			
			DialogResult res = f.ShowDialog();
			if (res == DialogResult.OK)
			{
				#region Read From Form

				this.BatchSeparator = f.txtBatchSeparator.Text;
				this.ExecutionTimeout= (int) (f.txtExecutionTimeout.Value);
				this.RowCount= (int) (f.txtRowcount.Value);
				this.TextSize= (int) (f.txtTextSize.Value);

				this.NoCount = f.chkNoCount.Checked;
				this.NoExec = f.chkNoExec.Checked;
				this.ParseOnly = f.chkParseOnly.Checked;
				this.Concat_Null_Yields_Null = f.chkConcatNullYieldsNull.Checked;
				this.ArithAbort = f.chkArithAbort.Checked;
				this.ShowPlanText = f.chkShowPlanText.Checked;
				this.StatisticsTime = f.chkStatisticsTime.Checked;
				this.StatisticsIo = f.chkStatisticsIo.Checked;
				
				this.Transaction_Isolation_Level = f.cboTransactionIsolation.Text;
				this.Deadlock_Priority = f.cboDeadlockPriority.Text;
				this.Lock_Timeout = (int) f.txtLockTimeout.Value;
				this.Query_Governor_Cost_Limit = (int) f.txtQueryGovernorCostLimit.Value;

				this.Quoted_Identifier = f.chkQuotedIdentifier.Checked;
				this.Ansi_Null_Dflt_On = f.chkAnsiNullDflt.Checked;
				this.Implicit_Transactions = f.chkImplicitTransactions.Checked;
				this.Cursor_Close_On_Commit = f.chkCursorCloseOnCommit.Checked;
				this.Ansi_Padding = f.chkAnsiPadding.Checked;
				this.Ansi_Warnings = f.chkAnsiWarnings.Checked;
				this.Ansi_Nulls = f.chkAnsiNulls.Checked;		
				#endregion
			}
			return res;
		}
		#endregion
	}
}
