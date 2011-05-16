using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using QueryExPlus.Properties;

namespace QueryExPlus
{
    public partial class MainForm : Form
    {
        ServerList serverList = new ServerList();
        private EditManager editManager1 = EditManager.GetEditManager();

        public MainForm() : this(new string[0])
        {
        }

        public MainForm(string[] args)
        {
            if (Settings.Default.MaximizeMainWindow)
                this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            AttachEditManager();
            LoadServerList();
            LoadMRU();
            if (args.Length > 0)
            {
                ConnectionSettings conSettings = LoadSettingsFromArgs(args);
                if (conSettings != null)
                {
                    IQueryForm qf = DoConnect(conSettings);
                    if (qf != null)
                    {
                        CommandLineParams cmdLine = new CommandLineParams(args);
                        if (cmdLine["i"] != null)
                            qf.Open(cmdLine["i"]);
                    }
                }
            }
            EnableControls();
            this.Show();
            DoConnect();
        }

        private void LoadMRU()
        {
            mruMenuManager1.Filenames = Settings.Default.MRUFiles;
        }

        private ConnectionSettings LoadSettingsFromArgs(string[] args)
        {
            ConnectionSettings conSettings = null;
            CommandLineParams cmdLine = new CommandLineParams(args);
            if (cmdLine["cn"] != null)
            {
                if (serverList.IndexOf(cmdLine["cn"]) >= 0)
                {
                    conSettings = serverList.Items[serverList.IndexOf(cmdLine["CN"])];
                    return conSettings;
                }
            } else if (cmdLine["s"] != null)
            {
                conSettings = new ConnectionSettings();
                conSettings.Type = ConnectionSettings.ConnectionType.SqlConnection;
                conSettings.SqlServer = cmdLine["s"];
            } else if (cmdLine["os"] != null)
            {
                conSettings = new ConnectionSettings();
                conSettings.Type = ConnectionSettings.ConnectionType.Oracle;
                conSettings.OracleDataSource = cmdLine["os"];               
            }
            
            if (conSettings != null)
            {
                if (cmdLine["e"] != null)
                    conSettings.Trusted = true;
                else
                {
                    if (cmdLine["u"] != null) conSettings.LoginName = cmdLine["u"];
                    if (cmdLine["p"] != null) conSettings.Password = cmdLine["p"];
                }
                    
            }
            return conSettings;
        }

        private void AttachEditManager()
        {
            editManager1.MenuItemCopy = copyToolStripMenuItem;
            editManager1.MenuItemCopyWithHeaders = copyWithHeadersToolStripMenuItem;
            editManager1.MenuItemCut = cutToolStripMenuItem;
            editManager1.MenuItemEdit = editToolStripMenuItem1;
            editManager1.MenuItemPaste = pasteToolStripMenuItem;
            editManager1.MenuItemSelectAll = selectAllToolStripMenuItem;
            editManager1.MenuItemUndo = undoToolStripMenuItem;
        }

        #region Menu and Toolbar Button Events

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoConnect();
        }        
        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoDisconnect();
        }
        private void executeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoExecuteQuery();
        }
        private void ExecutetoolStripButton_Click(object sender, EventArgs e)
        {
            DoExecuteQuery();
        }
        private void cancelExecutingQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoCancel();
        }
        private void cancelExecutingQuerytoolStripButton_Click(object sender, EventArgs e)
        {
            DoCancel();
        }
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            DoNew();
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoNew();
        }
        private void resultsInTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoResultsInText();
        }
        private void ResultsInTexttoolStripButton_Click(object sender, EventArgs e)
        {
            DoResultsInText();
        }
        private void resultsInGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoResultsInGrid();
        }
        private void resultsInGridtoolStripButton_Click(object sender, EventArgs e)
        {
            DoResultsInGrid();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoOpen();
        }
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            DoOpen();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoSave();
        }
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            DoSave();
        }
        private void hideBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoHideShowBrowser();
        }
        private void queryOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsChildActive()) GetQueryChild().ShowQueryOptions();
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoSaveAs();
        }
        private void saveResultsAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsChildActive()) GetQueryChild().SaveResults();
        }
        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsChildActive()) GetQueryChild().ShowFind();
        }
        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsChildActive()) GetQueryChild().FindNext();
        }
        //private void copyWithHeadersToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    editManager1.CopyWithHeaders();
        //}
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }
        #endregion

        #region Menu and Toolbar Button Implementations
        private void DoExecuteQuery()
        {
            if (IsChildActive()) GetQueryChild().Execute();
        }

        private void DoNew()
        {
            if (IsChildActive())
            {
                // Change the cursor to an hourglass while we're doing this, in case establishing the
                // new connection takes some time.
                Cursor oldCursor = Cursor;
                Cursor = Cursors.WaitCursor;
                IQueryForm newQF = GetQueryChild().Clone();
                if (newQF != null)																// could be null if new connection failed
                {
                    ((Form) newQF).MdiParent = this;
                    newQF.PropertyChanged += new EventHandler<EventArgs>(qf_PropertyChanged);
                    newQF.MRUFileAdded += new EventHandler<MRUFileAddedEventArgs>(qf_MRUFileAdded);
                    ((Form)newQF).Show();
                }
                Cursor = oldCursor;
            }
            else
                DoConnect();
        }

        void qf_(object sender, MRUFileAddedEventArgs e)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private IQueryForm DoConnect(ConnectionSettings conSettings)
        {
            DbClient client = DbClientFactory.GetDBClient(conSettings);
            Cursor oldCursor = Cursor;
            Cursor = Cursors.WaitCursor;

            ConnectingForm c = new ConnectingForm();
            c.Show();
            c.Refresh();

            bool success = client.Connect();
            c.Close();
            Cursor = oldCursor;

            if (!success)
            {
                MessageBox.Show("Unable to connect: " + client.ErrorMessage, "Query Express", MessageBoxButtons.OK, MessageBoxIcon.Error);
                client.Dispose();
                return null;
            }
            int settingIndex = serverList.IndexOf(client.ConSettings.Key);
            if (settingIndex >= 0)
                serverList.Items[settingIndex] = (client.ConSettings);
            else
                serverList.Add(client.ConSettings);
            SaveServerList();
            QueryForm qf = new QueryForm(client, false); //, cf.Browser, cf.LowBandwidth);
            qf.MdiParent = this;
            // This is so that we can update the toolbar and menu as the state of the QueryForm changes.
            qf.PropertyChanged += new EventHandler<EventArgs>(qf_PropertyChanged);
            qf.MRUFileAdded += new EventHandler<MRUFileAddedEventArgs>(qf_MRUFileAdded);
            qf.Show();

            return qf;
        }
        private IQueryForm DoConnect()
        {
            ConnectForm cf = new ConnectForm();

            cf.ApplyServerList(serverList);
            if (cf.ShowDialog(this) == DialogResult.OK)
            {
                int settingIndex = serverList.IndexOf(cf.DbClient.ConSettings.Key);
                if (settingIndex >= 0)
                    serverList.Items[settingIndex] = (cf.DbClient.ConSettings);
                else
                    serverList.Add(cf.DbClient.ConSettings);
                SaveServerList();
                QueryForm qf = new QueryForm(cf.DbClient, false); //, cf.Browser, cf.LowBandwidth);
                qf.MdiParent = this;
                // This is so that we can update the toolbar and menu as the state of the QueryForm changes.
                qf.PropertyChanged += new EventHandler<EventArgs>(qf_PropertyChanged);
                qf.MRUFileAdded += new EventHandler<MRUFileAddedEventArgs>(qf_MRUFileAdded);
                qf.WindowState = FormWindowState.Maximized;
                qf.Show();
                return qf;
            }
            return null;
        }

        void qf_MRUFileAdded(object sender, MRUFileAddedEventArgs e)
        {
            mruMenuManager1.Add(e.Filename);
            Settings.Default.MRUFiles = mruMenuManager1.Filenames;
            Settings.Default.Save();
        }

        private void DoDisconnect()
        {
            if (IsChildActive()) GetQueryChild().Close();
        }
        
        private void DoCancel()
        {
            if (IsChildActive()) GetQueryChild().Cancel();
        }

        private void DoResultsInText()
        {
            // Changing the value of this property will automatically invoke the QueryForm's
            // PropertyChanged event, which we've wired to EnableControls().
            if (IsChildActive()) GetQueryChild().ResultsInText = true;

        }

        private void DoResultsInGrid()
        {
            // Changing the value of this property will automatically invoke the QueryForm's
            // PropertyChanged event, which we've wired to EnableControls().
            if (IsChildActive()) GetQueryChild().ResultsInText = false;
        }

        private void DoOpen()
        {
            if (IsChildActive()) GetQueryChild().Open();
        }

        private void DoSave()
        {
            if (IsChildActive()) GetQueryChild().Save();
        }

        private void DoSaveAs()
        {
            if (IsChildActive()) GetQueryChild().SaveAs();
        }

        private void DoHideShowBrowser()
        {
            if (IsChildActive()) GetQueryChild().HideBrowser = !GetQueryChild().HideBrowser;
        }
        #endregion

        void qf_PropertyChanged(object sender, EventArgs e)
        {
            EnableControls();
        }

   		/// <summary>
		/// Enable / Disable toolbar and menu items
		/// </summary>
		void EnableControls()
		{
			IQueryForm q;
			bool active = IsChildActive();
			if (active) q = GetQueryChild(); else q = null;

			openToolStripMenuItem.Enabled = openToolStripButton.Enabled =
				saveResultsAsToolStripMenuItem.Enabled = 
				(active && q.RunState == DbClient.RunStates.Idle);

			settingsToolStripMenuItem.Enabled = newToolStripButton.Enabled =
				saveToolStripMenuItem.Enabled = saveToolStripButton.Enabled =
				saveAsToolStripMenuItem.Enabled = active;

			settingsToolStripMenuItem.Enabled = true;
			disconnectToolStripMenuItem.Enabled = (active && q.RunState != DbClient.RunStates.Cancelling);

			//miQueryOptions.Enabled = (active && q.RunState == DbClient.RunStates.Idle);
			
			executeToolStripMenuItem.Enabled = (active && q.RunState == DbClient.RunStates.Idle);

			cancelExecutingQueryToolStripMenuItem.Enabled = (active && q.RunState == DbClient.RunStates.Running);

			resultsInTextToolStripMenuItem.Enabled = 
				resultsInGridToolStripMenuItem.Enabled = active;

			resultsInTextToolStripMenuItem.Checked //= tbResultsText.Pushed 
			    = (active && q.ResultsInText);
			resultsInGridToolStripMenuItem.Checked = (active && !q.ResultsInText);

			//miNextPane.Enabled = miPrevPane.Enabled = active;

			//miHideResults.Enabled = tbHideResults.Enabled = active;
			hideBrowserToolStripMenuItem.Enabled = //tbHideBrowser.Enabled =
				(active && q.Browser != null && q.RunState == DbClient.RunStates.Idle);

			//miHideResults.Checked = tbHideResults.Pushed = (active && q.HideResults);
            hideBrowserToolStripMenuItem.Checked = //tbHideBrowser.Pushed = 
                (active && q.HideBrowser);
		
        }

        private IQueryForm GetQueryChild()
        {
            return (IQueryForm)ActiveMdiChild;
        }

        private bool IsChildActive()
        {
            return ActiveMdiChild != null;
        }
    
        private void LoadServerList()
        {
            serverList = Settings.Default.ServerList;
            if (serverList == null)
                serverList = new ServerList();
        }

        private void SaveServerList()
        {
                Settings.Default.ServerList = serverList;
                Settings.Default.Save();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.MaximizeMainWindow = this.WindowState == FormWindowState.Maximized;
            Settings.Default.Save();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            object data;
            data = e.Data.GetData(DataFormats.FileDrop);
            List<string> fileNames = new List<string>();
            foreach (string filename in (string[]) data)
            {
                FileAttributes attribs;
                attribs = System.IO.File.GetAttributes(filename);
                
                if ((attribs & FileAttributes.Directory) != FileAttributes.Directory)
                    fileNames.Add(filename);
                if (fileNames.Count > 0)
                    LoadFileNames(fileNames);
            }
        }

        private void LoadFileNames(List<string> fileNames)
        {
            foreach(string fileName in fileNames)
            {
                LoadFileName(fileName); }
        }

        private void LoadFileName(string fileName)
        {
            if (!IsChildActive())
            {
                DoConnect();
                Cursor oldCursor = Cursor;
                Cursor = Cursors.WaitCursor;
                IQueryForm newQF = GetQueryChild();
                if (newQF != null)																// could be null if new connection failed
                {
                    newQF.Open(fileName);
                    mruMenuManager1.Add(fileName);
                }
                Cursor = oldCursor;
            } else
            {
            // Change the cursor to an hourglass while we're doing this, in case establishing the
                // new connection takes some time.
                Cursor oldCursor = Cursor;
                Cursor = Cursors.WaitCursor;
                IQueryForm newQF = GetQueryChild().Clone();
                if (newQF != null)																// could be null if new connection failed
                {
                    ((Form)newQF).MdiParent = this;
                    newQF.PropertyChanged += new EventHandler<EventArgs>(qf_PropertyChanged);
                    newQF.MRUFileAdded += new EventHandler<MRUFileAddedEventArgs>(qf_MRUFileAdded);
                    newQF.Open(fileName);
                    ((Form)newQF).Show();
                    mruMenuManager1.Add(fileName);
                }
                Cursor = oldCursor;
            }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("FileDrop"))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void mruMenuManager1_MruMenuItemClick(object sender, MRUSampleControlLibrary.MruMenuItemClickEventArgs e)
        {
            LoadFileName(e.Filename);                
        }

        private void mruMenuManager1_MruMenuItemFileMissing(object sender, MRUSampleControlLibrary.MruMenuItemFileMissingEventArgs e)
        {
            e.RemoveFromMru = false;
        }

		private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Gui.SettingsForm sForm = new Gui.SettingsForm();
			sForm.ShowDialog();
		}
    }
}
