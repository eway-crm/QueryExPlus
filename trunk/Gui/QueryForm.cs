using System;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace QueryExPlus
{
	internal partial class QueryForm : Form, IQueryForm
	{
		#region Private Variables
		private enum ResultsTabType
		{
			Message,
			GridResults,
			InfoMessage
		}

		private const string DateTimeFormatString = "yyyy'-'MM'-'dd HH':'mm':'ss.fff";
		private static readonly int DateTimeFormatStringLength = DateTimeFormatString.Length;

		bool realFileName = false;
		string fileName;						// Filename for when query is saved
		private bool resultsInText = !Properties.Settings.Default.ResultInGridDefault;
		RichTextBox txtResultsBox;				// handle to the rich textbox used to display text results
		private bool ErrorOccured = false;
		private long rowCount;
		private string lastDatabase;
		static int untitledCount = 1;					// For default new filenames (Untited-1, Untitled-2, etc)
		int[] colWidths;
		StringBuilder textResults = new StringBuilder();
		private DateTime lastResults;

		private IBrowser browser;
		private bool hideBrowser = false;

		private string lastFindText;
		private bool matchCase;
		private int lastFindPos;
		private int lastFindRow;
		private int lastFindCol;

		private Regex regexSQLKeywords;
		MatchCollection regexWordsMatchCollection;
		private Regex regexSQLOperators;
		MatchCollection regexOperatorsMatchCollection;
		private Regex regexSQLStrings;
		MatchCollection regexStringsMatchCollection;
		private Regex regexSQLNumbers;
		MatchCollection regexNumbersMatchCollection;

		private int cursorPos;
		bool ignoreTextChanged;
		private string rtfColorDictionary;
		// DbClient dbClient;									// DbClient object used to talk to database server

		#region Properties

		/// <summary>Returns the database client object provided in construction</summary>
		public DbClient DbClient
		{
			get; set;
		}


		DataSet DSResults
		{
			get { return DbClient.DataSet; }
		}
		#endregion Properties


		#endregion

		#region Constructors

		private QueryForm()
		{
			InitializeComponent();
		}

		public QueryForm(DbClient client, bool hideBrowser)	: this()
		{
			this.DbClient = client;
			client.DataReaderAvailable += new EventHandler<DataReaderAvailableEventArgs>(client_DataReaderAvailable);
			client.TableSchemaAvailable += new EventHandler<TableSchemaAvailableEventArgs>(client_TableSchemaAvailable);
			client.DataRowAvailable += new EventHandler<DataRowAvailableEventArgs>(client_DataRowAvailable);
			client.InfoMessage += new EventHandler<InfoMessageEventArgs>(client_InfoMessage);
			client.Error += new EventHandler<ErrorEventArgs>(client_Error);
			client.CommandDone += new EventHandler<CommandDoneEventArgs>(client_CommandDone);
			client.BatchDone += new EventHandler(client_batchDone);
			client.CancelDone += new EventHandler(client_cancelDone);
			lastDatabase = client.Database;				// this is so we know when the current database changes
			FileName = "untitled" + untitledCount++.ToString() + ".sql";
			browser = DbClientFactory.GetBrowser(client);
			HideBrowser = hideBrowser;

			string[] keywordArr = Properties.Settings.Default.SQLKeyWords.Replace("\n", "").Split('\r');

			string keywordRegEx = @"(\b(";
			foreach (string keyword in keywordArr)
			{
				keywordRegEx += string.Format("{0}|", keyword);
			}
			keywordRegEx = keywordRegEx.Substring(0, keywordRegEx.Length - 1);
			keywordRegEx += @")\b)|('([^']+)?'?)";
			//This is a workaround: appending |('([^']+)?'?) gives me the thing I'm actually looking for (keywords, numbers etc) and the strings used in the text (i.e. text enclosed in ' characters.)
			//I've done this because I couldn't for the life of me figure out how to make a regex that gives me everything except those "string areas", and I was fed up with this.
			string operatorRegEx = @"(\||\+|\-|\*|\/|\(|\)|\[|\]|\{|\}|\<|\>|\=|\.|\,)|('([^']+)?'?)";
			
			regexSQLKeywords = new Regex(keywordRegEx, RegexOptions.IgnoreCase);
			regexSQLOperators = new Regex(operatorRegEx);
			regexSQLStrings = new Regex(@"('([^']+)?'?)");
			regexSQLNumbers = new Regex(@"(\b\d+\b)|('([^']+)?'?)");

			rtfColorDictionary = "{\\colortbl ;" + GetColorString(Properties.Settings.Default.ColorKeywords) +
			                     GetColorString(Properties.Settings.Default.ColorStrings) +
			                     GetColorString(Properties.Settings.Default.ColorOperators) +
			                     GetColorString(Properties.Settings.Default.ColorNumbers) + "}";
		}

		#endregion

		#region DbClient Event Handlers

		void client_DataReaderAvailable(object sender, DataReaderAvailableEventArgs e)
		{
			if (!ResultsInText)
			{
				DisplayGrid(e.dr);
				e.SkipResults = true;
			}
		}
		void client_TableSchemaAvailable(object sender, TableSchemaAvailableEventArgs e)
		{
			rowCount = 0;
			if (ResultsInText)
				DisplayTextSchema(e.Schema);
		}
		void client_DataRowAvailable(object sender, DataRowAvailableEventArgs e)
		{
			rowCount++;
			if (ResultsInText)
				DisplayTextRow(e.DataFields);
		}
		void client_CommandDone(object sender, CommandDoneEventArgs e)
		{
			if (e.RecordsAffected >= 0)
				AppendTextResults(string.Format("\r\n   ({0} row(s) affected)", e.RecordsAffected), true);
		}
		void client_batchDone(object sender, EventArgs e)
		{
			BeginInvoke(new MethodInvoker(doBatchDone));       // Do this asyncroneously. so worker thread can go back to beeing idle. We are done anyways
		}
		private void doBatchDone()
		{
			panRunStatus.Text = "Query batch completed" + (ErrorOccured ? " with errors" : ".");
			// If there were no results from query, display message to provide feedback to user
			if (!ErrorOccured)
				AppendTextResults("\r\nThe command(s) completed successfully.", true);
			if (!ResultsInText)
				tabResults.SelectedIndex = ErrorOccured ? 0 : 1;
			ShowRowCount();
			ShowExecTime();
			SetRunning(false);
			txtQuery.Focus();
		}
		void client_Error(object sender, ErrorEventArgs e)
		{
			AppendTextResults("\r\n" + e.ErrorMessage, true);
			ErrorOccured = true;
		}
		void client_InfoMessage(object sender, InfoMessageEventArgs e)
		{
			AppendTextResults("\r\n" + e.Message, true);
		}
		void client_cancelDone(object sender, EventArgs e)
		{
			BeginInvoke(new MethodInvoker(doCancelDone));      // Do this asyncroneously. so worker thread can go back to beeing idle. We are done anyways
		}
		private void doCancelDone()
		{
			SetRunning(false);
			panRunStatus.Text = "Query batch was cancelled.";
			ShowExecTime();
		}

		#endregion

		#region IQueryForm implementation

		public event EventHandler<EventArgs> PropertyChanged;
		public event EventHandler<MRUFileAddedEventArgs> MRUFileAdded;

		/// <summary>Returns false if the Open was cancelled or if the file I/O failed </summary>
		public bool Open()
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.FileName = "*.sql";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string f = openFileDialog.FileName;
				if (Path.GetExtension(f) == "") f += ".sql";
				return Open(f);
			}
			else
				return false;
		}

		/// <summary>Returns false if the Open was cancelled or if the file I/O failed </summary>
		public bool Open(string fileName)
		{
			return OpenFile(fileName);
		}

		/// <summary>Starts execution of  a query</summary>
		public void Execute()
		{
			if (RunState != DbClient.RunStates.Idle)
				return;

			if (this.DbClient.DataSet == null)
				this.DbClient.DataSet = new DataSet();
			else
				this.DbClient.DataSet.Tables.Clear();

			ErrorOccured = false;
			rowCount = 0;
			// Delete any previously defined tab pages and their child controls
			CreateResultsTextbox();

			// If the user has selected text within the query window, just execute the
			// selected text.  Otherwise, execute the contents of the whole textbox.
			string query = txtQuery.SelectedText.Length == 0 ? txtQuery.Text : txtQuery.SelectedText;
			if (query.Trim() == "") return;

			// Use the database client class to execute the query.  Create delegates which will be invoked
			// when the query completes or cancels with an error.

			if (resultsInText)
			{
				//results = new MethodInvoker (AddTextResults);
			}
			else
			{
				//results = new MethodInvoker (AddGridResults);
			}

			//			done = new MethodInvoker (QueryDone);
			//			failed = new MethodInvoker (QueryFailed);
			//			infoMessageHandler = new InfoMessageEventHandler(OnInfoMessage);
			// dbClient.Execute runs asynchronously, so control will return immediately to the calling method.

			Cursor oldCursor = Cursor;
			Cursor = Cursors.WaitCursor;
			panRunStatus.Text = "Executing Query Batch...";
			DbClient.Execute(query);		// this does the work
			SetRunning(true);
			Cursor = oldCursor;
		}

		private void CreateResultsTextbox()
		{
			tabResults.TabPages.Clear();

			TabPage tabPage = new TabPage(resultsInText ? "Results" : "Messages");
			// We'll need a rich textbox because an ordinary textbox has limited capacity
			txtResultsBox = new RichTextBox();
			txtResultsBox.AutoSize = false;
			txtResultsBox.Dock = DockStyle.Fill;
			txtResultsBox.Multiline = true;
			txtResultsBox.WordWrap = false;
			txtResultsBox.Font = new Font("Courier New", 8);
			txtResultsBox.ScrollBars = RichTextBoxScrollBars.Both;
			txtResultsBox.MaxLength = 0;
			txtResultsBox.Text = "";
			tabPage.Tag = ResultsTabType.Message;
			#region Create Context Menu
			txtResultsBox.ContextMenuStrip = EditManager.GetEditManager().GetContextMenuStrip(txtResultsBox);
			txtResultsBox.ContextMenuStrip.Opening += delegate(object o, System.ComponentModel.CancelEventArgs e) { txtResultsBox.Focus(); };
			#endregion

			tabResults.TabPages.Add(tabPage);
			tabPage.Controls.Add(txtResultsBox);

		}

		/// <summary>
		/// Cancel running operation
		/// </summary>
		public void Cancel()
		{
			panRunStatus.Text = "Cancelling...";
			DbClient.CancelAsync();
			// Control will return immediately, and CancelDone will be invoked when the cancel is complete.
			NotifyPropertyChanged();
		}

		/// <summary>Returns false if user cancelled or save failed</summary>
		public bool Save()
		{
			if (!realFileName)
				return SaveAs();
			else
				return SaveFile(FileName);
		}

		/// <summary>Returns false if user cancelled or save failed</summary>
		public bool SaveAs()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = FileName;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				FileName = saveFileDialog.FileName;
				realFileName = true;
				return SaveFile(FileName);
			}
			else return false;
		}

		/// <summary>
		/// Return a copy of the QueryForm object, with separate connection and browser objects
		/// </summary>
		public IQueryForm Clone()
		{
			// Make a copy of the QueryForm's DbClient object.  We can't use the same object
			// object because this would mean sharing the same connection, preventing concurrent queries.
			DbClient d = DbClient.Clone();
			if (d.Connect())
			{
				d.Database = DbClient.Database;
				// We have to duplicate the Browser too, since it has a reference to the DbClient object.
				//                IBrowser b = null;
				//                if (Browser != null) try { b = Browser.Clone(d); }
				//                    catch { }
				QueryForm newQF = new QueryForm(d, hideBrowser);
				newQF.ResultsInText = ResultsInText;
				return newQF;
			}
			else
			{
				MessageBox.Show("Unable to connect: " + d.ErrorMessage, "Query Express", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		/// <summary>
		/// True if results are return in the text window
		/// </summary>
		public bool ResultsInText
		{
			get { return resultsInText; }
			set
			{
				resultsInText = value;
				NotifyPropertyChanged();
			}
		}

		/// <summary>
		/// Set to true to hide the object browser
		/// </summary>
		public bool HideBrowser
		{
			get { return hideBrowser; }
			set
			{
				hideBrowser = value;
				if (browser == null && !value) return;		// Can't show browser if not available!
				hideBrowser = value;
				splitBrowser.Panel1.Visible = !value;						// show/hide the browser panel containing the treeview
				splitBrowser.Panel1Collapsed = value;
				//                splBrowser.Visible = !value;						// show/hide the splitter
				if (!value) PopulateBrowser();
				txtQuery.Focus();
				NotifyPropertyChanged();
			}
		}

		/// <summary>
		/// Returns current status of the running query
		/// </summary>
		public DbClient.RunStates RunState
		{
			get { return DbClient.RunState; }
		}
		/// <summary>
		/// Display Query Options window
		/// </summary>
		public void ShowQueryOptions()
		{
			if (ClientBusy || DbClient.QueryOptions == null)
				return;

			if (DbClient.QueryOptions.ShowForm() == DialogResult.OK)
				DbClient.ApplyQueryOptions();
		}

		public void ShowFind()
		{
			FindReplaceForm ff = new FindReplaceForm();

			DialogResult res = ff.ShowDialog();
			if (res == DialogResult.Cancel)
				return;

			lastFindText = ff.txtFind.Text;
			lastFindPos = -1;
			lastFindRow = -1;
			lastFindCol = -1;

			matchCase = ff.chkMatchCase.Checked;
			FindNext();
		}

		public void FindNext()
		{
			if (lastFindText == null || lastFindText.Length == 0)
				return;

			Control ctrl = GetActiveControl(this);
			if (ctrl is TextBoxBase)
				FindNextInTextBox((TextBoxBase)ctrl);
			else if (ctrl is DataGridView)
				FindNextInDataGrid((DataGridView)ctrl);
		}

		private void FindNextInDataGrid(DataGridView grid)
		{
			StringComparison compareType;
			compareType = matchCase
							  ? StringComparison.CurrentCulture
							  : StringComparison.CurrentCultureIgnoreCase;
			if (grid.Rows.Count == 0)
				return;
			DataGridViewCell cell;
			if (grid.SelectedCells.Count == 0)
				cell = grid.Rows[0].Cells[0];
			else
				cell = grid.SelectedCells[grid.SelectedCells.Count - 1];  // For some reason they are in reverse order, LeftTop selected item is last in the list

			int _lastRow;
			int _lastCol;
			if (grid.SelectedCells.Count == 1 && grid.SelectedCells[0].RowIndex == lastFindRow && grid.SelectedCells[0].ColumnIndex == lastFindCol)
			{
				_lastRow = lastFindRow;
				_lastCol = lastFindCol;
			}
			else if (grid.SelectedCells.Count == 0)
			{
				_lastRow = 0;
				_lastCol = -1;
			}
			else
			{
				_lastRow = grid.SelectedCells[0].RowIndex;
				_lastCol = grid.SelectedCells[0].ColumnIndex - 1;
			}
			for (int row = _lastRow; row < grid.Rows.Count; row++)
			{
				for (int col = _lastCol + 1; col < grid.Columns.Count; col++)
				{
					if (grid.Rows[row].Cells[col].FormattedValue.ToString().IndexOf(lastFindText, 0, compareType) >= 0)
					{
						//grid.SelectedCells.Clear();
						//grid.SelectedCells.Insert(0, grid.Rows[row].Cells[col]);
						grid.ClearSelection();
						grid.CurrentCell = grid.Rows[row].Cells[col];
						grid.Rows[row].Cells[col].Selected = true;
						lastFindRow = row;
						lastFindCol = col;
						return;
					}
				}
				_lastCol = -1;
			}
		}

		private void FindNextInTextBox(TextBoxBase txtBox)
		{
			StringComparison compareType;
			compareType = matchCase
											  ? StringComparison.CurrentCulture
											  : StringComparison.CurrentCultureIgnoreCase;

			int _lastFindPosition = lastFindPos == txtBox.SelectionStart &&
								   txtBox.SelectedText.Equals(lastFindText, compareType)
									   ? lastFindPos + 1
									   : txtBox.SelectionStart;

			int idx =
				txtBox.Text.IndexOf(lastFindText, _lastFindPosition,
									compareType);
			if (idx == -1)
			{
				idx = txtBox.Text.IndexOf(lastFindText, 0,
										  compareType);
			}
			if (idx >= 0)
			{
				txtBox.SelectionStart = idx;
				txtBox.SelectionLength = lastFindText.Length;
				txtBox.ScrollToCaret();
				lastFindPos = idx;
			}
		}

		public IBrowser Browser
		{
			get { return browser; }
		}
		#endregion

		#region Grid Output

		/// <summary>
		/// delegate used to call when displaying data in the grid
		/// </summary>
		/// <param name="dt"></param>
		private delegate void DisplayGridDelegate(DataTable dt);
		/// <summary>
		/// Display datatable on the grid. Should be called only from UI grid
		/// </summary>
		/// <param name="dt"></param>
		private void DisplayGrid(DataTable dt)
		{
			DataGridView dataGrid = new DataGridView();


			// Due to a bug in the grid control, we must add the grid to the tabpage before assigning a datasource.
			// This bug was introduced in Beta 1, was fixed for Beta 2, then reared its ugly head again in RTM.
			TabPage tabPage = new TabPage("Result Set " + (tabResults.TabCount).ToString());
			tabPage.Tag = ResultsTabType.GridResults;
			tabPage.Controls.Add(dataGrid);
			tabResults.TabPages.Add(tabPage);

			dataGrid.Dock = DockStyle.Fill;

			dataGrid.ReadOnly = true;
			dataGrid.AllowUserToAddRows = false;
			dataGrid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dataGrid_RowPostPaint);
			dataGrid.DataError += new DataGridViewDataErrorEventHandler(dataGrid_DataError);
			dataGrid.DataSource = dt;
			rowCount = dt.Rows.Count;

			#region Create Context Menu
			dataGrid.ContextMenuStrip = EditManager.GetEditManager().GetContextMenuStrip(dataGrid);
			dataGrid.ContextMenuStrip.Opening += delegate(object o, System.ComponentModel.CancelEventArgs e) { dataGrid.Focus(); };
			#endregion
			// The auto sizing feature is supported but SLOOOOWWWWW
			// dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
			// Instead we'll have to size each column manually.
			// A graphics object is required to measure text so we can size the grid columns correctly
			Graphics g = CreateGraphics();

			// For each column, determine the largest visible text string, and use that to size the column
			// We'll be measuring text for each row that's visible in the grid
			int maxRows = Math.Min(dataGrid.DisplayedRowCount(true), dt.Rows.Count);
			//GridColumnStylesCollection cols = ts.GridColumnStyles;
			const int margin = 6;		// allow 6 pixels per column, for grid lines and some white space
			int colNum = 0;
			if (dataGrid.Columns.Count == 1)
				dataGrid.Columns[0].Width = dataGrid.Width;
			else
				foreach (DataGridViewColumn col in dataGrid.Columns)
				{
					int maxWidth = (int)g.MeasureString(col.HeaderText, dataGrid.Font).Width + margin;
					for (int row = 0; row < maxRows; row++)
					{
						string s = dt.Rows[row][colNum, DataRowVersion.Current].ToString();
						int length = (int)g.MeasureString(s, dataGrid.Font).Width + margin;
						maxWidth = Math.Max(maxWidth, length);
					}
					// Assign length of longest string to the column width, but don't exceed width of actual grid.
					col.Width = Math.Min(dataGrid.Width, maxWidth);
					colNum++;
				}
			int headerWidth = (int)g.MeasureString(dataGrid.RowCount.ToString(), dataGrid.Font).Width + 5*margin;
			dataGrid.RowHeadersWidth = headerWidth;
			g.Dispose();
			
			// Set datetime columns to show the time as well as the date
			
			DataGridViewCellStyle dateCellStyle;
			dateCellStyle = new DataGridViewCellStyle();
			dateCellStyle.Format = DateTimeFormatString;
			foreach (DataGridViewColumn col in dataGrid.Columns)
			{
				if (dt.Columns[col.Name].DataType == typeof(DateTime))
					col.DefaultCellStyle = dateCellStyle;
			}
		}

		void dataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			return; // throw new Exception("The method or operation is not implemented.");
		}
		/// <summary>
		/// Display data to the grid
		/// </summary>
		/// <param name="dr"></param>
		private void DisplayGrid(IDataReader dr)
		{
			DataTable dt = new DataTable();
			this.DbClient.DataSet.Tables.Add(dt);

			// Assign unique name to each table, so subsequent queries don't override new tables
			dt.TableName = "QueryResult-" + this.DbClient.DataSet.Tables.Count;
			dt.BeginLoadData();
			try
			{
				dt.Load(dr);
			}
			catch (ConstraintException ex)
			{
				dt.Constraints.Clear();
				DataRow[] errorRows = dt.GetErrors();
				foreach (DataRow row in errorRows)
				{
					row.ClearErrors();
				}
			}
			dt.EndLoadData();

			if (dt.Columns.Count == 0)      // Do not display grid for commands that do not return a valid recordset (example: "use master")
				return;
			if (InvokeRequired)
			{
				BeginInvoke(new DisplayGridDelegate(DisplayGrid), new object[] { dt });
			}
			else
			{
				DisplayGrid(dt);
			}
		}

		/// <summary>
		/// Paint the row number on the row header.
		/// The using statement automatically disposes the brush.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dataGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			string t = (e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture);
			using (SolidBrush b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor))
				e.Graphics.DrawString(t,
									  e.InheritedRowStyle.Font,
									  b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
		}
		#endregion

		#region Text Output

		/// <summary>
		/// Create text headers for the table schema
		/// </summary>
		/// <param name="schema"></param>
		private void DisplayTextSchema(DataTable schema)
		{
			lastResults = DateTime.Now;
			colWidths = new int[schema.Rows.Count];
			string separator = "";
			AppendTextResults("\r\n");
			for (int col = 0; col < schema.Rows.Count; col++)
			{
				string colName = schema.Rows[col][0].ToString();
				int colSize = (int)schema.Rows[col]["ColumnSize"];
				Type dataType = (Type)schema.Rows[col]["DataType"];
				if (dataType == typeof(Guid)) colSize = Guid.NewGuid().ToString().Length;
				if (dataType == typeof(DateTime)) colSize = DateTimeFormatStringLength;
				// The column should be big enough also to accommodate the size of the column header
				colWidths[col] = Math.Min(DbClient.QueryOptions.maxTextWidth, Math.Max(colName.Length, colSize));
				if (colName.Length > DbClient.QueryOptions.maxTextWidth) colName = colName.Substring(0, DbClient.QueryOptions.maxTextWidth);
				AppendTextResults(colName.PadRight(colWidths[col]) + " ");
				separator = separator + "".PadRight(colWidths[col], '-') + " ";
			}
			AppendTextResults("\r\n" + separator + "\r\n");
		}
		/// <summary>
		/// Output a row of data in text format
		/// </summary>
		/// <param name="DataFields"></param>
		private void DisplayTextRow(object[] DataFields)
		{
			string cell = "";
			for (int col = 0; col < DataFields.Length; col++)
			{
				object data = DataFields[col];
				// Use a fixed format for dates, so we can predict its length.
				cell = data is DateTime ?
					((DateTime)data).ToString(DateTimeFormatString)
					: data.ToString();
				if (col == DataFields.Length - 1)							// if on last field, don't truncate or pad
					AppendTextResults(cell);
				else
				{
					textResults.Append(cell.PadRight(colWidths[col]).Substring(0, colWidths[col]));
					textResults.Append(" ");
				}
			}
			if (!cell.EndsWith("\r\n")) AppendTextResults("\r\n");
		}
		/// <summary>
		/// Append string to the text output, Flush after 5 seconds
		/// </summary>
		/// <param name="text"></param>
		private void AppendTextResults(string text)
		{
			AppendTextResults(text, false);
		}
		/// <summary>
		/// Append string tot he text output. Flush after 5 seconds of on demand
		/// </summary>
		/// <param name="text"></param>
		/// <param name="flush"></param>
		private void AppendTextResults(string text, bool flush)
		{
			textResults.Append(text);
			// feed results to host every 5 seconds
			if (lastResults.AddSeconds(5) < DateTime.Now)
				flush = true;

			if (flush)
			{
				AppendToTextBoxDelegate del = AppendToTextBox;
				Invoke(del, new object[] { textResults.ToString() });
				textResults = new StringBuilder();
				lastResults = DateTime.Now;
			}
		}
		/// <summary>
		/// delegate to append to the textbox on the UI thread
		/// </summary>
		/// <param name="s"></param>
		delegate void AppendToTextBoxDelegate(string s);
		/// <summary>
		/// append string to the textbox. Should be called only on the UI thread
		/// </summary>
		/// <param name="s"></param>
		private void AppendToTextBox(string s)
		{
			if (txtResultsBox == null)
				CreateResultsTextbox();
			txtResultsBox.AppendText(s);
		}

		#endregion

		#region Private Functions

		/// <summary>Returns false if user cancelled or open failed </summary>
		private bool OpenFile(string fileName)
		{
			try
			{
				string s;
				s = ReadFromFile(fileName);
				if (s != null && CloseQuery())
				{
					txtQuery.Text = s;
					txtQuery.Modified = false;
					this.FileName = fileName;
					realFileName = true;
					if (MRUFileAdded != null)
						MRUFileAdded.Invoke(this, new MRUFileAddedEventArgs(fileName));
					return true;
				}
				else
					return false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error opening file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
		}
		/// <summary>
		/// Save query to the file
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
		private bool SaveFile(string fileName)
		{
			try
			{
				WriteToFile(fileName, txtQuery.Text);
				txtQuery.Modified = false;
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error saving file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
		}
		/// <summary>
		/// Close query window
		/// </summary>
		/// <returns></returns>
		private bool CloseQuery()
		{
			// Check to see if a query is running, and warn user that the query will be cancelled.
			if (RunState != DbClient.RunStates.Idle)
				if (MessageBox.Show(FileName + " is currently executing.\nWould you like to cancel the query?",
					"Query Express", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
					// The Dispose method in DbClient will actually do the Cancel
					return false;

			// If the query text has been modified, give option of saving changes.
			// Don't nag the user in the case of simple queries of less than 30 characters.
			if (txtQuery.Modified && txtQuery.Text.Length > 30)
			{
				DialogResult dr = MessageBox.Show("Save changes to " + FileName + "?", Text,
					MessageBoxButtons.YesNoCancel);
				if (dr == DialogResult.Yes)
				{
					if (!Save()) return false;
				}
				else if (dr == DialogResult.Cancel)
					return false;
			}
			return true;
		}
		/// <summary>
		/// Returns the filename of the query displayed in the window
		/// </summary>
		private string FileName
		{
			get { return fileName; }
			set
			{
				fileName = value;
				UpdateFormText();
				NotifyPropertyChanged();
			}
		}

		protected Control GetActiveControl(Control ContainerControl)
		{
			if (ContainerControl == null || ContainerControl as ContainerControl == null)
				return ContainerControl;
			else
				return GetActiveControl(((ContainerControl)ContainerControl).ActiveControl);
		}

		/// <summary> Write a string to a file, returning true if successful </summary>
		/// <param name="fileName">Qualified filename</param>
		/// <param name="data">String data to write</param>
		private void WriteToFile(string fileName, string data)
		{
			StreamWriter w = null;
			try
			{
				w = File.CreateText(fileName);
				w.Write(data);
			}
			finally
			{
				if (w != null)
					w.Close();
			}
		}
		/// <summary>
		/// Reads the contents of a file into a string, returning true if successful.
		/// </summary>
		/// <param name="fileName">Qualified filename</param>
		private string ReadFromFile(string fileName)
		{
			StreamReader r = null;
			try
			{
				r = File.OpenText(fileName);
				return r.ReadToEnd();
			}
			finally
			{
				if (r != null)
					r.Close();
			}
		}

		/// <summary>
		/// This should be called whenever a query is started or stopped
		/// </summary>
		private void SetRunning(bool running)
		{
			if (!running) CheckDatabase();

			tmrExecTime.Enabled = running;
			NotifyPropertyChanged();
		}
		/// <summary>
		/// Check the current database - if it has changed, update controls accordingly
		/// </summary>
		private void CheckDatabase()
		{
			if (lastDatabase != DbClient.Database)
			{
				lastDatabase = DbClient.Database;
				UpdateFormText();
				PopulateBrowser();
			}
		}

		/// <summary>
		/// Display rowcount in the status bar
		/// </summary>
		private void ShowRowCount()
		{
			panRows.Text = rowCount == 0 ? "" : rowCount.ToString() + " row" + (rowCount == 1 ? "" : "s");
		}

		private void ShowExecTime()
		{
			if (DbClient.RunState == DbClient.RunStates.Running)
				panExecTime.Text = DateTime.Now.Subtract(DbClient.ExecStartTime).ToString();
			else
				panExecTime.Text = DbClient.ExecDuration.ToString();
		}

		/// <summary>
		/// Update the form's caption to show the connection & selected database 
		/// </summary>
		private void UpdateFormText()
		{
			Text = DbClient.ConSettings.Description + " - " + DbClient.Database + " - " + fileName;
		}

		/// <summary>
		/// Notify parent form of any property changes
		/// </summary>
		private void NotifyPropertyChanged()
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, EventArgs.Empty);
			}
		}

		private bool ClientBusy
		{
			get { return RunState != DbClient.RunStates.Idle; }
		}

		private void PopulateBrowser()
		{
			if (browser != null && !HideBrowser && !ClientBusy)
				try
				{
					treeView.Nodes.Clear();
					TreeNode[] tn = browser.GetObjectHierarchy();
					if (tn == null) HideBrowser = true;
					else
					{
						treeView.Nodes.AddRange(tn);
						treeView.Nodes[0].Expand();				// Expand the top level of hierarchy
						cboDatabase.Items.Clear();
						cboDatabase.Items.Add("<refresh list...>");
						string[] dbs = browser.GetDatabases();
						cboDatabase.Items.AddRange(dbs);
						try { cboDatabase.Text = DbClient.Database; }
						catch { }
					}
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine(ex.ToString());
				}

		}

		#region Methods for Saving Results

		/// <summary>
		/// Present a Save... dialog for query results and save to CSV or XML format
		/// </summary>
		public void SaveResults()
		{
			if (!ResultsInText && (DSResults.Tables.Count == 0) || ClientBusy)
				return;

			SaveFileDialog saveResultsDialog;
			saveResultsDialog = new System.Windows.Forms.SaveFileDialog();
			if (ClientBusy || (!ResultsInText && !tabResults.SelectedTab.Tag.Equals(ResultsTabType.GridResults)))
				return;
			saveResultsDialog.Filter = ResultsInText ? "Text Format|*.txt" : "CSV Format|*.csv|XML|*.xml|XSD Schema|*.xsd"
				+ "|All files|*.*";
			if (saveResultsDialog.ShowDialog() != DialogResult.OK) return;
			if (ResultsInText)
				SaveResultsText(saveResultsDialog.FileName);
			else if (System.IO.Path.GetExtension(saveResultsDialog.FileName).ToUpper() == ".XML")
				SaveResultsXml(saveResultsDialog.FileName);
			else if (System.IO.Path.GetExtension(saveResultsDialog.FileName).ToUpper() == ".XSD")
				SaveResultsXsd(saveResultsDialog.FileName);
			else
				SaveResultsCsv(saveResultsDialog.FileName);
		}

		void SaveResultsText(string fileName)
		{
			WriteToFile(fileName, txtResultsBox.Text);
		}

		void SaveResultsXml(string fileName)
		{
			DSResults.WriteXml(fileName);
		}

		// dl3bak
		void SaveResultsXsd(string fileName)
		{
			DSResults.WriteXmlSchema(fileName);
		}

		void SaveResultsCsv(string fileName)
		{
			// Save the currently selected table only
			string DL = QueryExPlus.Properties.Settings.Default.Delimiter;
			char TDL = QueryExPlus.Properties.Settings.Default.TextDelimiter;
			DataTable table = (DataTable)((DataGridView)tabResults.SelectedTab.Controls[0]).DataSource;
			System.IO.StreamWriter w;
			try { w = System.IO.File.CreateText(fileName); }
			catch (Exception e)
			{
				MessageBox.Show("Could not create file: " + fileName + "\n" + e.Message
					, "Query Express", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			using (w)
			{
				// Write a header consisting of a list of columns
				string colList = "";
				foreach (DataColumn column in table.Columns)
				{
					if (colList.Length > 0) colList += DL;
					colList += column.ColumnName;
				}
				w.WriteLine(colList);
				foreach (DataRow row in table.Rows)
				{
					string line = "";
					foreach (object cell in row.ItemArray)
					{
						if (line.Length > 0) line += DL;
						// String types may contain embedded commas, so wrap in quotes.
						if (cell is string)
							line += TDL + cell.ToString() + TDL;
						else
							line += cell.ToString();
					}
					w.WriteLine(line);
				}
			}
		}

		#endregion

		#endregion

		#region Form Events

		private void QueryForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!CloseQuery()) e.Cancel = true;
		}
		private void QueryForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			DbClient.Dispose();
		}
		private void QueryForm_Activated(object sender, EventArgs e)
		{
			NotifyPropertyChanged();
		}
		private void cboDatabase_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboDatabase.SelectedIndex == 0)
				PopulateBrowser();
			else
				DbClient.Database = cboDatabase.Text;
			CheckDatabase();
		}
		private void cboDatabase_Enter(object sender, EventArgs e)
		{
			if (ClientBusy) txtQuery.Focus();
		}

		#region Drag / Drop

		private void txtQuery_DragOver(object sender, DragEventArgs e)
		{
			//            if (e.Effect == DragDropEffects.Copy)
			//            {
			//                txtQuery.SelectionStart = txtQuery.GetCharIndexFromPosition(txtQuery.PointToClient(new Point(e.X, e.Y)));
			//                txtQuery.SelectionLength = 1;
			//            }
		}
		private void txtQuery_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(string)))
			{
				e.Effect = DragDropEffects.Copy;
			}
			else if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
		}
		private void txtQuery_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(string)))
			{
				txtQuery.SelectionStart = txtQuery.GetCharIndexFromPosition(txtQuery.PointToClient(new Point(e.X, e.Y)));
				string s = (string)e.Data.GetData(typeof(string));
				// Have the newly inserted text highlighted
				int start = txtQuery.SelectionStart;
				txtQuery.SelectedText = s;
				txtQuery.SelectionStart = start;
				txtQuery.SelectionLength = s.Length;
				txtQuery.Modified = true;
				txtQuery.Focus();
			}
			else if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				Open(((string[])e.Data.GetData(DataFormats.FileDrop))[0]);
			}
		}
		#endregion

		private void treeView_MouseDown(object sender, MouseEventArgs e)
		{
			// When right-clicking, first select the node under the mouse.
			if (e.Button == MouseButtons.Right)
			{
				TreeNode tn = treeView.GetNodeAt(e.X, e.Y);
				if (tn != null)
					treeView.SelectedNode = tn;
			}
		}
		private void treeView_MouseUp(object sender, MouseEventArgs e)
		{
			if (Browser == null) return;
			// Display a context menu if the browser has an action list for the selected node
			if (e.Button == MouseButtons.Right && treeView.SelectedNode != null)
			{
				StringCollection actions = Browser.GetActionList(treeView.SelectedNode);
				if (actions != null)
				{
					System.Windows.Forms.ContextMenu cm = new ContextMenu();
					foreach (string action in actions)
						cm.MenuItems.Add(action, new EventHandler(DoBrowserAction));
					cm.Show(treeView, new Point(e.X, e.Y));
				}
			}
		}
		private void DoBrowserAction(object sender, EventArgs e)
		{
			// This is called from the context menu activated by the TreeView's right-click
			// event handler (treeView_MouseUp) and appends text to the query textbox
			// applicable to the selected menu item.
			MenuItem mi = (MenuItem)sender;
			// Ask the browser for the text to append, applicable to the selected node and menu item text.
			string s = Browser.GetActionText(treeView.SelectedNode, mi.Text);
			if (s == null) return;
			//if (s.Length > 200) HideResults = true;
			if (txtQuery.Text != "") txtQuery.AppendText("\r\n\r\n");
			int start = txtQuery.SelectionStart;
			txtQuery.AppendText(s);
			txtQuery.SelectionStart = start;
			txtQuery.SelectionLength = s.Length;
			txtQuery.Modified = true;
			txtQuery.Focus();

		}
		private void treeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			// If a browser has been installed, see if it has a sub object hierarchy for us at the point of expansion
			if (Browser == null) return;
			TreeNode[] subtree = Browser.GetSubObjectHierarchy(e.Node);
			if (subtree != null)
			{
				e.Node.Nodes.Clear();
				e.Node.Nodes.AddRange(subtree);
			}
		}
		private void treeView_ItemDrag(object sender, ItemDragEventArgs e)
		{
			// Allow objects to be dragged from the browser to the query textbox.
			if (e.Button == MouseButtons.Left && e.Item is TreeNode)
			{
				// Ask the browser object for a string applicable to dragging onto the query window.
				string dragText = Browser.GetDragText((TreeNode)e.Item);
				// We'll use a simple string-type DataObject
				if (dragText != "")
					treeView.DoDragDrop(new DataObject(dragText), DragDropEffects.Copy);
			}
		}
		private void label1_VisibleChanged(object sender, EventArgs e)
		{
			txtQuery.Focus();
		}
		private void QueryForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Alt && e.KeyCode == Keys.X)
			{
				this.Execute();
				e.Handled = true;
			}
			// Check for Alt+Break combination (alternative shortcut for cancelling a query)
			if (e.Alt && e.KeyCode == Keys.Pause && RunState == DbClient.RunStates.Running)
			{
				Cancel();
				e.Handled = true;
			}
		}
		#endregion

		private void tmrExecTime_Tick(object sender, EventArgs e)
		{
			ShowExecTime();
		}

		[System.Runtime.InteropServices.DllImport("User32")]
		private static extern bool SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
		int WM_SETREDRAW = 0xB;
		private void FreezeDraw()
		{
			SendMessage(txtQuery.Handle, WM_SETREDRAW, 0, 0);
		}
		private void UnFreezeDraw()
		{
			SendMessage(txtQuery.Handle, WM_SETREDRAW, 1, 0);
			txtQuery.Invalidate(true);
		}

		/// <summary>
		/// Returns RTF-usable RGB notation for the color
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		private string GetColorString(Color c)
		{
			return string.Format("\\red{0}\\green{1}\\blue{2};", c.R, c.G, c.B);
		}

		/// <summary>
		/// Rebuilds the color dictionary with the currently selected colors from the settings menu and then applies it to the text once.
		/// </summary>
		public void ResetHighlightColors()
		{
			if (Properties.Settings.Default.SyntaxHighlighting)
			{
				rtfColorDictionary = "{\\colortbl ;" + GetColorString(Properties.Settings.Default.ColorKeywords) +
				                     GetColorString(Properties.Settings.Default.ColorStrings) +
				                     GetColorString(Properties.Settings.Default.ColorOperators) +
				                     GetColorString(Properties.Settings.Default.ColorNumbers) + "}";
			}
			else
			{
				rtfColorDictionary = "{\\colortbl ;" + GetColorString(Color.Black) +
				                     GetColorString(Color.Black) +
				                     GetColorString(Color.Black) +
				                     GetColorString(Color.Black) + "}";
			}
			HighlightSyntax();
		}

		private void HighlightSyntax()
		{
			//Here it happens. I'm quite aware that this is a kind of clumsy approach, but I didn't know of any better way without having to do a major rewrite.
			//Feel free to suggest improvements (or to improve it yourself, or write to your head of state, whatever you like).

			cursorPos = txtQuery.SelectionStart; //Used to save the position of the cursor, so that when the Rtf is changed the cursor does not jump to the end of the text if it wasn't already there.
			StringBuilder sb = new StringBuilder(txtQuery.Text.Replace("\\", "\\\\").Replace("\n", "\\par\r\n")); //A stringbuilder used to put together the formatted text. Starts with the plain text and replaces line breaks.

			//Get the strings and colour them first (i.e. text contained in ' characters). For each match, set the corresponding number from the color table before the match and standard color after the match.
			//Iterating through the matches in reverse order prevents the other matche-indices from being affected by the changing length of the text.
			regexStringsMatchCollection = regexSQLStrings.Matches(sb.ToString());
			for (int i = regexStringsMatchCollection.Count - 1; i >= 0; i--)
			{
				sb.Insert(regexStringsMatchCollection[i].Index + regexStringsMatchCollection[i].Length, "\\cf0 ");
				sb.Insert(regexStringsMatchCollection[i].Index, "\\cf2 ");
			}

			//Same for the keywords. But due to our workaround above, the MatchCollection also contains the strings, so we only handle the matches that don't start with the ' character.
			regexWordsMatchCollection = regexSQLKeywords.Matches(sb.ToString());
			for (int i = regexWordsMatchCollection.Count - 1; i >= 0; i--)
			{
				if (sb[regexWordsMatchCollection[i].Index] != '\'')
				{
					sb.Insert(regexWordsMatchCollection[i].Index + regexWordsMatchCollection[i].Length, "\\cf0 ");
					sb.Insert(regexWordsMatchCollection[i].Index, "\\cf1 ");
				}
			}

			//Now find operators, brackets etc. and mark them. Same procedure as above.
			regexOperatorsMatchCollection = regexSQLOperators.Matches(sb.ToString());
			for (int i = regexOperatorsMatchCollection.Count - 1; i >= 0; i--)
			{
				if (sb[regexOperatorsMatchCollection[i].Index] != '\'')
				{
					sb.Insert(regexOperatorsMatchCollection[i].Index + regexOperatorsMatchCollection[i].Length, "\\cf0 ");
					sb.Insert(regexOperatorsMatchCollection[i].Index, "\\cf3 ");
				}
			}

			//Now the same for the numbers.
			regexNumbersMatchCollection = regexSQLNumbers.Matches(sb.ToString());
			for (int i = regexNumbersMatchCollection.Count - 1; i >= 0; i--)
			{
				if (sb[regexNumbersMatchCollection[i].Index] != '\'')
				{
					sb.Insert(regexNumbersMatchCollection[i].Index + regexNumbersMatchCollection[i].Length, "\\cf0 ");
					sb.Insert(regexNumbersMatchCollection[i].Index, "\\cf4 ");
				}
			}

			//Build a new RTF string. The colortbl is created from the colours we want to use, and the newly formatted text inserted.
			string newRtf = "{\\rtf1\\ansi\\deff0{\\fonttbl{\\f0\fnil\\fcharset0 Verdana;}}"
							+ rtfColorDictionary
			                + "\\viewkind4\\uc1\\pard\\lang1031\\f0\\fs20 " + sb + "\\par}";
			ignoreTextChanged = true; //This is to prevent an infinite loop when setting the Rtf Property of txtQuery below.
			FreezeDraw(); //Don't draw this control to keep it from flickering
			txtQuery.Rtf = newRtf;
			ignoreTextChanged = false; //So that future TextChanged events won't be ignored.
			txtQuery.Select(cursorPos, 0); //Set the cursor to its last position. NOTE: this should put the cursor in the right position, but might cause the screen to scroll there. I have not yet found a way to change the RichtTextBox scroll position.
			UnFreezeDraw(); //Resume drawing the control.

			//A similar logic could be used to set fonts, bold, italic and other properties as well. Main problem is performance; With longer queries, there might be lags while typing if too much is done in the TextChanged event.
			//Apparently, every way to improve on this would require rewriting large parts.
		}

		private void txtQuery_TextChanged(object sender, EventArgs e)
		{
			if (!ignoreTextChanged && Properties.Settings.Default.SyntaxHighlighting)
			{
				HighlightSyntax();
			}
		}
	}
}