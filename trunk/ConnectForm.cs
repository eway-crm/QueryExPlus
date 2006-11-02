using System;
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

            client = DbClientFactory.GetDBClient(conSettings);
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
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void ScreenToSettings()
        {
            if (((ConnectionSettings.ConnectionType)tabServerTypes.SelectedTab.Tag == ConnectionSettings.ConnectionType.SqlConnection &&
                 cboSqlServer.SelectedItem == null) ||
                ((ConnectionSettings.ConnectionType)tabServerTypes.SelectedTab.Tag == ConnectionSettings.ConnectionType.Oracle &&
                 cboOracleDataSource.SelectedItem == null) ||
                (ConnectionSettings.ConnectionType)tabServerTypes.SelectedTab.Tag == ConnectionSettings.ConnectionType.OleDb)
                conSettings = new ConnectionSettings();
            conSettings.Type = (ConnectionSettings.ConnectionType)tabServerTypes.SelectedTab.Tag;
            conSettings.SqlServer = cboSqlServer.Text;
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

    }
}