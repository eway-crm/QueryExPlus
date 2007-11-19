using System;
using System.IO;
using System.Windows.Forms;

namespace QueryExPlus
{
    public partial class ConnectForm : Form
    {

        DbClient client = null;

        private ConnectionSettings conSettings = new ConnectionSettings();
        
        public ConnectForm()
        {
            InitializeComponent();
            rbSqlTrusted.Checked = true;
            rbOracleUntrusted.Checked = true;
            this.ActiveControl = cboSqlServer;
        }

        /// <summary>
        /// The database client object which is used to talk to the database server.
        /// This should be queried after the form is closed (following a DialogResult.OK)
        /// </summary>
        internal DbClient DbClient
        {
            get { return client; }
        }
        
        private void rbSqlTrusted_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSqlTrusted.Checked)
            {
                txtSqlLoginName.Enabled = false;
                txtSqlPassword.Enabled = false;
            }
            else
            {
                txtSqlLoginName.Enabled = true;
                txtSqlPassword.Enabled = true;
            }
                
        }

        private void rbOracleTrusted_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOracleTrusted.Checked)
            {
                txtOracleLoginName.Enabled = false;
                txtOraclePassword.Enabled = false;
            }
            else
            {
                txtOracleLoginName.Enabled = true;
                txtOraclePassword.Enabled = true;
            }
        }
        private void cmdConnect_Click(object sender, EventArgs e)
        {
//            if (cboSqlServer.SelectedItem == null)
//                conSettings = new ConnectionSettings();
            ScreenToSettings();

            if (! DbClientFactory.ValidateSettings(conSettings))
                return;
            client = DbClientFactory.GetDBClient(conSettings);
            Cursor oldCursor = Cursor;
            Cursor = Cursors.WaitCursor;

            ConnectingForm c = new ConnectingForm();
            c.Show(this);
            c.Refresh();

            bool success = client.Connect();
            c.Close();
            Cursor = oldCursor;

            if (!success)
            {
                MessageBox.Show("Unable to connect: " + client.ErrorMessage, "Query Express", MessageBoxButtons.OK, MessageBoxIcon.Error);
                client.Dispose();
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void ScreenToSettings()
        {
            ConnectionSettings.ConnectionType connectionType = (ConnectionSettings.ConnectionType)tabServerTypes.SelectedTab.Tag;
            if ((connectionType == ConnectionSettings.ConnectionType.SqlConnection &&
                 cboSqlServer.SelectedItem == null) ||
                (connectionType == ConnectionSettings.ConnectionType.Oracle &&
                 cboOracleDataSource.SelectedItem == null) ||
                (connectionType == ConnectionSettings.ConnectionType.Odbc) ||
                (connectionType == ConnectionSettings.ConnectionType.OleDb)
                )
                conSettings = new ConnectionSettings();
            conSettings.Type = connectionType;
            conSettings.SqlServer = cboSqlServer.Text;
            conSettings.OdbcConnectionString = txtOdbcConnectionString.Text;
            conSettings.OleDbConnectionString = txtOleDbConnectionString.Text;
            conSettings.OracleDataSource = cboOracleDataSource.Text;

            if (conSettings.Type == ConnectionSettings.ConnectionType.SqlConnection)
            {
                conSettings.Trusted = rbSqlTrusted.Checked;
                if (!conSettings.Trusted)
                {
                    conSettings.LoginName = txtSqlLoginName.Text;
                    conSettings.Password = txtSqlPassword.Text;
                }
            }
            else if (conSettings.Type == ConnectionSettings.ConnectionType.Oracle)
            {
                conSettings.Trusted = rbOracleTrusted.Checked;
                if (!conSettings.Trusted)
                {
                    conSettings.LoginName = txtOracleLoginName.Text;
                    conSettings.Password = txtOraclePassword.Text;
                }
            }
        }

        private void SettingsToScreen()
        {
            switch(conSettings.Type)
            {
                case ConnectionSettings.ConnectionType.SqlConnection:
                    tabServerTypes.SelectedTab = tabSqlServer;
                    cboSqlServer.Text = conSettings.SqlServer;
                    rbSqlTrusted.Checked = conSettings.Trusted;
                    if (!conSettings.Trusted)
                    {
                        txtSqlLoginName.Text = conSettings.LoginName;
                        txtSqlPassword.Text = conSettings.Password;
                    }
                    break;
                case ConnectionSettings.ConnectionType.Odbc:
                    tabServerTypes.SelectedTab = tabODBC;
                    txtOdbcConnectionString.Text = conSettings.OdbcConnectionString;
                    break;
                case ConnectionSettings.ConnectionType.OleDb:
                    tabServerTypes.SelectedTab = tabOleDb;
                    txtOleDbConnectionString.Text = conSettings.OleDbConnectionString;
                    break;
                case ConnectionSettings.ConnectionType.Oracle:
                    tabServerTypes.SelectedTab = tabOracle;
                    cboOracleDataSource.Text = conSettings.OracleDataSource;
                    rbOracleTrusted.Checked = conSettings.Trusted;
                    if (!conSettings.Trusted)
                    {
                        txtOracleLoginName.Text = conSettings.LoginName;
                        txtOraclePassword.Text = conSettings.Password;
                    }                    
                    break;
            }
        }

        private void ConnectForm_Load(object sender, EventArgs e)
        {
            tabSqlServer.Tag = ConnectionSettings.ConnectionType.SqlConnection;
            tabODBC.Tag = ConnectionSettings.ConnectionType.Odbc;
            tabOleDb.Tag = ConnectionSettings.ConnectionType.OleDb;
            tabOracle.Tag = ConnectionSettings.ConnectionType.Oracle;
        }

        public void ApplyServerList(ServerList serverList)
        {
            foreach (ConnectionSettings conSetting in serverList.Items)
            {
                switch (conSetting.Type)
                {
                    case ConnectionSettings.ConnectionType.SqlConnection:
                        cboSqlServer.Items.Add(conSetting);
                        break;
                    case ConnectionSettings.ConnectionType.Oracle:
                        cboOracleDataSource.Items.Add(conSetting);
                        break;
                }
            }
        }

        private void cboSqlServer_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboSqlServer.SelectedItem != null)
            {
                conSettings = (ConnectionSettings) cboSqlServer.SelectedItem;
                SettingsToScreen();
            }
        }

        private void cboOracleDataSource_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboOracleDataSource.SelectedItem != null)
            {
                conSettings = (ConnectionSettings)cboOracleDataSource.SelectedItem;
                SettingsToScreen();
            }

        }

        private void cmdLoadOdbc_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd;
            ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.DefaultExt = "connectString";
            ofd.FileName = "ODBC";
            ofd.Filter = "Connection String|*.connectString|Text File|*.txt|All Files|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string s;
                    StreamReader r = null;
                    try
                    {
                        r = File.OpenText(ofd.FileName);
                        s =  r.ReadToEnd();
                    }
                    finally
                    {
                        if (r != null)
                            r.Close();
                    }
                    if (s != null)
                    {
                        txtOdbcConnectionString.Text = s;
                        cmdConnect.Focus();
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error opening file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void cmdSaveOdbc_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd;
            sfd = new System.Windows.Forms.SaveFileDialog();
            sfd.DefaultExt = "connectString";
            sfd.FileName = "ODBC";
            sfd.Filter = "Connection String|*.connectString|Text File|*.txt|All Files|*.*";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter w = null;
                try
                {
                    try
                    {
                        w = File.CreateText(sfd.FileName);
                        w.Write(txtOdbcConnectionString.Text);
                        cmdConnect.Focus();
                    }
                    finally
                    {
                        if (w != null)
                            w.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Unable to save connection string");
                }
            }
        }

        private void cmdLoadOleDb_Click(object sender, EventArgs e)
        {
            OpenFileDialog openOleDbFileDialog;
            openOleDbFileDialog = new System.Windows.Forms.OpenFileDialog();
            openOleDbFileDialog.DefaultExt = "udl";
            openOleDbFileDialog.FileName = "OleDb";
            openOleDbFileDialog.Filter = "OleDB Connection String (*.udl;*.connectString)|*.udl;*.connectString|Text File(*" +
".txt)|*.txt|All Files (*.*)|*.*";

            if (openOleDbFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string data = OleDbBrowser.GetConnectString(openOleDbFileDialog.FileName);
                    if ((data != null) && (data != string.Empty))
                    {
                        txtOleDbConnectionString.Text = data;
                        cmdConnect.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error opening file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void cmdSaveOleDb_Click(object sender, EventArgs e)
        {
            saveOleDbFileDialog = new System.Windows.Forms.SaveFileDialog();

            saveOleDbFileDialog.DefaultExt = "udl";
            saveOleDbFileDialog.FileName = "OleDb1";
            saveOleDbFileDialog.Filter = "Connection String(*.udl)|*.udl|Connection String(*.connectString)|*.connectString" +
"|Text File(*.txt)|*.txt|All Files(*.*)|*.*";

            if (saveOleDbFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string connect = txtOleDbConnectionString.Text;
                    if (saveOleDbFileDialog.FileName.ToLower().EndsWith(".udl"))
                        connect = "[oledb]\r\n"
                                + "; Everything after this line is an OLE DB initstring\r\n"
                                + connect;
                    else
                        connect = txtOleDbConnectionString.Text;
                    FileUtil.WriteToFile(saveOleDbFileDialog.FileName, connect);
                    btnConnect.Focus();
                }
                catch
                {
                    MessageBox.Show("Unable to save connection string");
                }
            }

        }
    }
}
