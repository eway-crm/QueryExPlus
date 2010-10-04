using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Text;

namespace QueryExPlus
{
    class OdbcClient  : DbClient
    {
        public OdbcClient(ConnectionSettings settings)
            : base(settings)
        {}

        public OdbcConnection Connection
        {
            get { return (OdbcConnection) connection; }
        }

        protected override IDbConnection GetDbConnection()
        {
            OdbcConnection con = new OdbcConnection(GenerateConnectionString());
            con.InfoMessage += new OdbcInfoMessageEventHandler(con_InfoMessage);
            return con;
        }

        void con_InfoMessage(object sender, OdbcInfoMessageEventArgs e)
        {
            OnInfoMessage(sender, new InfoMessageEventArgs(e.Message, ""));
        }

        protected override string GenerateConnectionString()
        {
            OdbcConnectionStringBuilder csb = new OdbcConnectionStringBuilder();
            csb.ConnectionString = conSettings.OdbcConnectionString;
            
            return csb.ConnectionString; // connectString.ToString();
        }

        protected override IDbCommand GetDbCommand(string query)
        {
            OdbcCommand cmd = ((OdbcConnection)connection).CreateCommand();
            cmd.CommandText = query;
            return cmd;
        }

        public override QueryOptions GetDefaultOptions()
        {
            return new ODBCQueryOptions();
        }

        protected override IDbDataAdapter GetDataAdapter(IDbCommand command)
        {
            return new OdbcDataAdapter((OdbcCommand) command);
        }

        public override void ApplyQueryOptions()
        {
            return;
/*
            StringBuilder sb = new StringBuilder();
            SqlQueryOptons sqo = ((SqlQueryOptons) queryOptions);
            sb.Append(string.Format(" SET ROWCOUNT {0}", sqo.RowCount));
            sb.Append(string.Format(" SET TEXTSIZE {0}", sqo.TextSize));
            sb.Append(string.Format(" SET NOCOUNT {0}", sqo.NoCount ? "ON" : "OFF"));
            sb.Append(string.Format(" SET CONCAT_NULL_YIELDS_NULL {0}", sqo.Concat_Null_Yields_Null ? "ON" : "OFF"));
            sb.Append(string.Format(" SET ARITHABORT {0}", sqo.ArithAbort ? "ON" : "OFF"));
            sb.Append(string.Format(" SET LOCK_TIMEOUT {0}", sqo.Lock_Timeout));
            sb.Append(string.Format(" SET QUERY_GOVERNOR_COST_LIMIT {0}", sqo.Query_Governor_Cost_Limit));
            sb.Append(string.Format(" SET DEADLOCK_PRIORITY {0}", sqo.Deadlock_Priority));
            sb.Append(string.Format(" SET TRANSACTION ISOLATION LEVEL {0}", sqo.Transaction_Isolation_Level));
            sb.Append(string.Format(" SET ANSI_NULLS {0}", sqo.Ansi_Nulls ? "ON" : "OFF"));
            sb.Append(string.Format(" SET ANSI_NULL_DFLT_ON {0}", sqo.Ansi_Null_Dflt_On ? "ON" : "OFF"));
            sb.Append(string.Format(" SET ANSI_PADDING {0}", sqo.Ansi_Padding ? "ON" : "OFF"));
            sb.Append(string.Format(" SET ANSI_WARNINGS {0}", sqo.Ansi_Warnings ? "ON" : "OFF"));
            sb.Append(string.Format(" SET CURSOR_CLOSE_ON_COMMIT {0}", sqo.Cursor_Close_On_Commit ? "ON" : "OFF"));
            sb.Append(string.Format(" SET IMPLICIT_TRANSACTIONS {0}", sqo.Implicit_Transactions ? "ON" : "OFF"));
            sb.Append(string.Format(" SET QUOTED_IDENTIFIER {0}", sqo.Quoted_Identifier ? "ON" : "OFF"));

            ExecuteOnWorker(sb.ToString(), 5);
*/
        }

    }
}
