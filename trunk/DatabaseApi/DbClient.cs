using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace QueryExPlus
{

    #region DataClient Event Argument Classes

    public class DataReaderAvailableEventArgs : EventArgs
    {
        private IDataReader _dr;
        private bool _SkipResults = false;
        
        public IDataReader dr
        {
            get { return _dr; }
        }

        public bool SkipResults
        {
            get { return _SkipResults; }
            set { _SkipResults = value; }
        }

        public DataReaderAvailableEventArgs(IDataReader _dr)
        {
            this._dr = _dr;
        }
    }

    public class TableSchemaAvailableEventArgs : EventArgs
    {
        private DataTable _Schema;

        public DataTable Schema
        {
            get { return _Schema; }
            set { _Schema = value; }
        }

        public TableSchemaAvailableEventArgs(DataTable _Schema)
        {
            this._Schema = _Schema;
        }
    }
    
    public class DataRowAvailableEventArgs : EventArgs
    {
        public object[] DataFields;

        public DataRowAvailableEventArgs(object[] dataFields)
        {
            DataFields = dataFields;
        }
    }
    
    public class CommandDoneEventArgs : EventArgs
    {
        public int _RecordsAffected;

        public int RecordsAffected
        {
            get { return _RecordsAffected; }
        }

        public CommandDoneEventArgs(int _RecordAffected)
        {
            this._RecordsAffected = _RecordAffected;
        }
    }

    public class InfoMessageEventArgs : EventArgs
    {
        string _Message;
        string _Source;

        public string Message
        {
            get { return _Message; }
        }

        public string Source
        {
            get { return _Source; }
        }

        public InfoMessageEventArgs(string Message, string Source)
        {
            _Message = Message;
            _Source = Source;
        }
    }

    public class ErrorEventArgs : EventArgs
    {
        string _ErrorMessage;
        Exception _ex;
        bool _Cancel = true;

        public string ErrorMessage
        {
            get { return _ErrorMessage; }
        }

        public Exception ex
        {
            get { return _ex; }
        }

        public bool Cancel
        {
            get { return _Cancel; }
            set { _Cancel = value; }
        }

        public ErrorEventArgs(string errorMessage, Exception ex)
        {
            this._ErrorMessage = errorMessage;
            this._ex = ex;
        }
    }

    #endregion
    
    /// <summary>
    /// Commonn Abstraction of Database-Connection.
    /// There are different implementations for
    /// ODBC (<see cref="ODBCClient"/>), OLEDB (<see cref="OledbClient"/>), 
    /// Oracle (<see cref="OracleDbClient"/>), MsSqlServer (<see cref="SqlDbClient"/>).
    /// </summary>
    internal abstract class DbClient
    {
        public enum RunStates
        {
            Idle,
            Running,
            Cancelling
        } ;

        #region Events

        public event EventHandler<DataReaderAvailableEventArgs> DataReaderAvailable;
        public event EventHandler<TableSchemaAvailableEventArgs> TableSchemaAvailable;
        public event EventHandler<DataRowAvailableEventArgs> DataRowAvailable;
        public event EventHandler<InfoMessageEventArgs> InfoMessage;
        public event EventHandler<ErrorEventArgs> Error;
        public event EventHandler CancelDone; // and event to inform when cancel action has completed
        public event EventHandler<CommandDoneEventArgs> CommandDone;
        public event EventHandler BatchDone;

        #endregion
        
        #region Internal Variables

        protected ConnectionSettings conSettings;
        protected IDbConnection connection;
        protected IDbCommand selectCommand;
        protected QueryOptions queryOptions;
        protected bool connected = false;
        private MethodInvoker task;
        protected Thread workerThread; // the background thread for running queries
        protected RunStates runState = RunStates.Idle;
        private DataSet syncDataSet = new DataSet(); // the DataSet we're going to fill
        private string syncQuery;
        private int syncTimeOut;
        private ArrayList queries;
        private string _ErrorMessage;
        private DateTime execStartTime;
        private TimeSpan execDuration = TimeSpan.Zero;
        #endregion

        #region Constructor

        public DbClient(ConnectionSettings settings)
        {
            conSettings = settings;
            queryOptions = GetDefaultOptions();
            // Given that the ODBC classes appear to be apartment threaded, we can't just spawn
            // worker threads to execute background queries as required, since the connection will
            // have been created on a different thread.  The easiest way around this is to start a worker
            // thread now, keeping it alive for the duration of the DbClient object, and have that 
            // thread process all database commands - connections, disconnections, queries, etc.
            this.workerThread = new Thread(new ThreadStart(StartWorker));
            workerThread.Name = "DbClient Worker Thread";
            workerThread.Start();
        }

        #endregion

        #region Abstract Functions

        protected abstract IDbConnection GetDbConnection();
        protected abstract string GenerateConnectionString();

        protected abstract IDbCommand GetDbCommand(string query);
        protected abstract IDbDataAdapter GetDataAdapter(IDbCommand command);

        public abstract void ApplyQueryOptions();
        #endregion

        #region Protected Functions

        /// <summary>
        /// Start the background thread event loop
        /// </summary>
        protected void StartWorker()
        {
            do
            {
                // Wait for the host thread to wake us up.  We have to use Sleep() rather than
                // Suspend() because Suspend sometimes hogs the CPU on NT4 (bug in beta 2?)
                //Thread.CurrentThread.Suspend();
                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (System.Threading.ThreadInterruptedException)
                {
                    // the wakeup call, ie Interrupt() will throw an exception
                    // If we've been given nothing to do, it's time to exit (the form's being closed)
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
                if (task == null) break;
                // Otherwise, execute the given task
                task();
                task = null;
            } while (true);
        }

        protected void StopWorker()
        {
            WaitForWorker();
            // End the thread cleanly
            workerThread.Interrupt(); // Interrupt the thread without a task - this will end it.
            workerThread.Join(); // wait for it to end
        }

        protected void RunOnWorker(MethodInvoker method)
        {
            RunOnWorker(method, false);
        }

        protected void RunOnWorker(MethodInvoker method, bool synchronous)
        {
            if (task != null) // already doing something?
            {
                Thread.Sleep(100); // give it 100ms to finish...
                if (task != null) return; // still not finished - cannot run new task
            }
            WaitForWorker();
            task = method;
            workerThread.Interrupt();
            if (synchronous) WaitForWorker();
        }

        /// <summary>
        /// Wait for worker thread to become available
        /// </summary>
        protected void WaitForWorker()
        {
            while (workerThread.ThreadState != ThreadState.WaitSleepJoin || task != null)
            {
                Thread.Sleep(20);
                if (workerThread.ThreadState == ThreadState.Stopped)
                    break;
            }
        }

        protected void DoApplyOptionsToConnection()
        {
            queryOptions.ApplyToConnection(connection);
        }
        
        protected void DoConnect()
        {
            if (connected) return;
            try
            {
                connection = GetDbConnection();
                connection.Open();
                connected = true;
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                OnError(this, new ErrorEventArgs(e.Message, e));
            }
        }

        public string ErrorMessage
        {
            set { _ErrorMessage = value; }
            get { return _ErrorMessage; }
        }

        protected virtual void DoCancel()
        {
            if (runState == RunStates.Running)
            {
                runState = RunStates.Cancelling;
                // We have to cancel on a new thread - separate to the main worker thread (because the
                // worker thread will be busy) and separate to the main thread (as this is locked into the
                // main UI apartment, and its use could cause subsequent corruption to an ODBC connection).
                Thread cancelThread = new Thread(new ThreadStart(selectCommand.Cancel));
                cancelThread.Name = "DbClient Cancel Thread";
                cancelThread.Start();
                // wait for the command to finish: this won't take long (however the main worker thread that is
                // executing the actual command make take a while to register the cancel request & tidy up)
                cancelThread.Join();
            }
        }

        protected virtual void InformCancelDone()
        {
            WaitForWorker();
            runState = RunStates.Idle;
            if (CancelDone != null)
            {
//            if (host != null)
                //                host.Invoke(CancelDone, new object[] {this, EventArgs.Empty});
                //            else
                CancelDone(this, EventArgs.Empty);
            }
        }

        private void DoExecuteBatchesAsync()
        {
            execStartTime = DateTime.Now;
            SetupBatch();
            foreach (string query in queries)
            {
                IDataReader dr = null;
                try
                {
                    selectCommand = GetDbCommand(query);
                    selectCommand.CommandTimeout = queryOptions.ExecutionTimeout;
                    dr = selectCommand.ExecuteReader();
                    ReturnResults(dr);
                    dr.Close();
                }
                catch (Exception ex)
                {
                    ErrorEventArgs args = new ErrorEventArgs(ex.Message, ex);
                    OnError(this, args);
                    if ((ex as DbException) != null)
                    {
                        if (connection.State == ConnectionState.Open)   // do not cancel if conneciton is still open
                            args.Cancel = false;
                    }
                    if (args.Cancel)
                    {
                        break;
                    }
                }
                finally
                {
                    if (!(dr == null) && !dr.IsClosed)
                        try { dr.Close(); }
                        catch (Exception) { }

                }
            }
            ResetBatch();
            execDuration = DateTime.Now.Subtract(execStartTime);
            if (runState == RunStates.Cancelling)
            {
                return;
            }
            runState = RunStates.Idle;
            OnBatchDone(this, null);
        }
        
        private void DoExecuteSync()
        {
            // Called indirectly by Execute()
            selectCommand = GetDbCommand(syncQuery);
            selectCommand.CommandTimeout = syncTimeOut;

            IDbDataAdapter da = GetDataAdapter(selectCommand);
            try
            {
                da.Fill(syncDataSet);
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                syncDataSet = null;
            }
        }
        
        protected virtual void OnDataReaderAvailable(object sender, DataReaderAvailableEventArgs e)
        {
            if (DataReaderAvailable != null)
                DataReaderAvailable(this, e);
        }
        
        protected virtual void OnTableSchemaAvailable(object sender, TableSchemaAvailableEventArgs e)
        {
            if (TableSchemaAvailable!= null)
                TableSchemaAvailable(sender, e );
        }

        protected virtual void OnDataRowAvailable(object sender, DataRowAvailableEventArgs e)
        {
            if (DataRowAvailable != null)
                DataRowAvailable(sender, e);
        }

        protected virtual void OnInfoMessage(object sender, InfoMessageEventArgs e)
        {
            if (InfoMessage != null)
                InfoMessage(sender, e);
        }
        protected virtual void OnError(object sender, ErrorEventArgs e)
        {
            if (Error != null)
                Error(sender, e);

        }
        protected virtual void OnCancelDone(object sender, EventArgs e)
        {
            if (CancelDone != null)
                    CancelDone(sender, e);
        }
        protected virtual void OnCommandDone(object sender, CommandDoneEventArgs e)
        {
            if (CommandDone!= null)
                CommandDone(sender, e);
        }
        protected virtual void OnBatchDone(object sender, EventArgs e)
        {
            if (BatchDone != null)
                    BatchDone(sender, e);
        }
        #endregion

        #region Public Properties

        public RunStates RunState
        {
            get { return runState; }
        }

        public ConnectionSettings ConSettings
        {
            get { return conSettings; }
        }

        public QueryOptions QueryOptions
        {
            get { return queryOptions; }
        }

        public string Database
        {
            get { return connection.Database; }
            set
            {
                if (connection.Database != value)
                    connection.ChangeDatabase(value);
            }
        }

        public DateTime ExecStartTime
        {
            get { return execStartTime; }
        }

        public TimeSpan ExecDuration
        {
            get { return execDuration; }
        }
        #endregion

        #region Public Functions

        /// <summary> Release SQL connection.  This is called automatically from Dispose() </summary>
        public virtual void Disconnect()
        {
            if (runState == RunStates.Running) Cancel();
            if (connected)
                RunOnWorker(new MethodInvoker(connection.Close), true);
        }

        /// <summary> Cancels any running queries and disconnects </summary>
        public virtual void Dispose()
        {
            if (connected) Disconnect();
            StopWorker();
        }

        /// <summary> Cancel a running query; inform us when it has done cancelling</summary>
        public virtual void CancelAsync()
        {
            if (runState == RunStates.Running)
            {
                DoCancel();                    
                // Start the thread that will inform us when the cancel has completed.  This could
                // take some time if a rollback is required.
                Thread informCancelDone = new Thread(new ThreadStart(InformCancelDone));
                informCancelDone.Name = "DbClient Inform Cancel";
                informCancelDone.Start();
            }
            else
                CancelDone(this, EventArgs.Empty);
        }

        /// <summary> Cancel a running query synchronously (ie wait for it to cancel)
        /// This method is called when closing an executing query.
        /// </summary>
        public virtual void Cancel()
        {
            if (runState == RunStates.Running)
            {
                DoCancel();
                WaitForWorker();
                runState = RunStates.Idle;
            }
        }

        public bool Connect()
        {
            if (connected) return true;
            // Even though we're connecting synchronously, we have to marshal the
            // call onto the worker thread, otherwise if the connection object will be locked
            // into the main thread's apartment.
            RunOnWorker(new MethodInvoker(DoConnect), true);
            if (connected)
            {
                if (queryOptions != null)
                    ApplyQueryOptions();
            }
            return connected;
        }

        public void Execute(string query)
        {
            // If 'GO' keyword is present, separate each subquery, so they can be run separately.
            // Use Regex class, as we need a case insensitive match.

            string separator = queryOptions == null ? "GO" : queryOptions.BatchSeparator;
            Regex r = new Regex(string.Format(@"^\s*{0}\s*$", separator), RegexOptions.IgnoreCase | RegexOptions.Multiline);
            MatchCollection mc = r.Matches(query);
            queries = new ArrayList();
            int pos = 0;
            foreach (Match m in mc)
            {
                string sub = query.Substring(pos, m.Index - pos).Trim();
                if (sub.Length > 0) queries.Add(sub);
                pos = m.Index + m.Length + 1;
            }

            if (pos < query.Length)
            {
                string finalQuery = query.Substring(pos).Trim();
                if (finalQuery.Length > 0) queries.Add(finalQuery);
            }

            runState = RunStates.Running;

            RunOnWorker(new MethodInvoker(DoExecuteBatchesAsync));
            return;
        }
        
        public DataSet ExecuteOnWorker(string query, int timeout)
        {
            // Even though we just want to run a simple synchronous query, we have to marshal
            // to the worker thread, since this is the thread that created the connection.
            syncDataSet = new DataSet();
            this.syncQuery = query;
            this.syncTimeOut = timeout;
            RunOnWorker(new MethodInvoker(DoExecuteSync), true);			// true = synchronous
            if (syncDataSet == null)
                return null;
            else
                return syncDataSet;

        }

        public DbClient Clone()
        {
            return DbClientFactory.GetDBClient(conSettings.Clone());
        }

        public abstract QueryOptions GetDefaultOptions();

        #endregion

        #region Private Functions

        private void ReturnResults(IDataReader dr)
        {
            do
            {
                DataReaderAvailableEventArgs result;
                result = new DataReaderAvailableEventArgs(dr);
                OnDataReaderAvailable(this, result);
                if (!result.SkipResults)
                {
                    DataTable schema = dr.GetSchemaTable();					// for list of column names & sizes}
                    if (schema != null)
                    {
                        OnTableSchemaAvailable(this, new TableSchemaAvailableEventArgs(schema));
                        while (dr.Read())  // Read through rows in result set
                        {
                            if (runState == RunStates.Cancelling)
                                return;
                            object[] values = new object[dr.FieldCount];
                            dr.GetValues(values);
                            OnDataRowAvailable(this, new DataRowAvailableEventArgs(values));
                        }
                    }
                    OnCommandDone(this, new CommandDoneEventArgs(dr.RecordsAffected));
                    if (!dr.NextResult())
                        dr.Close();
                }
                else 
                    OnCommandDone(this, new CommandDoneEventArgs(dr.RecordsAffected));

            } while (!dr.IsClosed);
        }
        
        private void ResetBatch()
        {
            if (queryOptions != null)
                try
                {
                    queryOptions.ResetBatch(connection);
                }
                catch
                { }
        }

        private void SetupBatch()
        {
            if (queryOptions != null)
                try
                {
                    queryOptions.SetupBatch(connection);
                }
                catch
                { }
        }
        #endregion

    }
}