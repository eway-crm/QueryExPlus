namespace QueryExPlus
{
    partial class ConnectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectForm));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelInstructions = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.cmdConnect = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.chkLowBandwidth = new System.Windows.Forms.CheckBox();
            this.tabServerTypes = new System.Windows.Forms.TabControl();
            this.tabSqlServer = new System.Windows.Forms.TabPage();
            this.cboSqlServer = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSqlPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSqlLoginName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbSqlUntrusted = new System.Windows.Forms.RadioButton();
            this.rbSqlTrusted = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tabODBC = new System.Windows.Forms.TabPage();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdLoad = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOleDbConnectionString = new System.Windows.Forms.TextBox();
            this.tabOracle = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtOraclePassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOracleLoginName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rbOracleUntrusted = new System.Windows.Forms.RadioButton();
            this.rbOracleTrusted = new System.Windows.Forms.RadioButton();
            this.cboOracleDataSource = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabServerTypes.SuspendLayout();
            this.tabSqlServer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabODBC.SuspendLayout();
            this.tabOracle.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(109, 91);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(133, 20);
            this.textBox1.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "&Password:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(109, 65);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(133, 20);
            this.textBox2.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "&Login name:";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(20, 42);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(151, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.Text = "S&QL Server Authentication";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(20, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(140, 17);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.Text = "&Windows Authentication";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer.Panel1.Controls.Add(this.labelInstructions);
            this.splitContainer.Panel1.Controls.Add(this.labelTitle);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer.Panel2.Controls.Add(this.cmdConnect);
            this.splitContainer.Panel2.Controls.Add(this.cmdCancel);
            this.splitContainer.Panel2.Controls.Add(this.chkLowBandwidth);
            this.splitContainer.Panel2.Controls.Add(this.tabServerTypes);
            this.splitContainer.Size = new System.Drawing.Size(493, 318);
            this.splitContainer.SplitterDistance = 66;
            this.splitContainer.SplitterWidth = 1;
            this.splitContainer.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(425, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 38);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // labelInstructions
            // 
            this.labelInstructions.AutoSize = true;
            this.labelInstructions.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.labelInstructions.Location = new System.Drawing.Point(44, 43);
            this.labelInstructions.Name = "labelInstructions";
            this.labelInstructions.Size = new System.Drawing.Size(204, 13);
            this.labelInstructions.TabIndex = 1;
            this.labelInstructions.Text = "Please enter your connection information";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(17, 13);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(187, 19);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Query ExPlus Connect";
            // 
            // cmdConnect
            // 
            this.cmdConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdConnect.BackColor = System.Drawing.SystemColors.Control;
            this.cmdConnect.Location = new System.Drawing.Point(325, 222);
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(75, 23);
            this.cmdConnect.TabIndex = 9;
            this.cmdConnect.Text = "&Connect";
            this.cmdConnect.UseVisualStyleBackColor = false;
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(406, 222);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 10;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = false;
            // 
            // chkLowBandwidth
            // 
            this.chkLowBandwidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkLowBandwidth.AutoSize = true;
            this.chkLowBandwidth.Location = new System.Drawing.Point(7, 222);
            this.chkLowBandwidth.Name = "chkLowBandwidth";
            this.chkLowBandwidth.Size = new System.Drawing.Size(98, 17);
            this.chkLowBandwidth.TabIndex = 7;
            this.chkLowBandwidth.Text = "Low bandwidth";
            this.chkLowBandwidth.UseVisualStyleBackColor = true;
            // 
            // tabServerTypes
            // 
            this.tabServerTypes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tabServerTypes.Controls.Add(this.tabSqlServer);
            this.tabServerTypes.Controls.Add(this.tabODBC);
            this.tabServerTypes.Controls.Add(this.tabOracle);
            this.tabServerTypes.Location = new System.Drawing.Point(3, 9);
            this.tabServerTypes.Name = "tabServerTypes";
            this.tabServerTypes.SelectedIndex = 0;
            this.tabServerTypes.Size = new System.Drawing.Size(487, 205);
            this.tabServerTypes.TabIndex = 8;
            // 
            // tabSqlServer
            // 
            this.tabSqlServer.Controls.Add(this.cboSqlServer);
            this.tabSqlServer.Controls.Add(this.groupBox1);
            this.tabSqlServer.Controls.Add(this.label1);
            this.tabSqlServer.Location = new System.Drawing.Point(4, 22);
            this.tabSqlServer.Name = "tabSqlServer";
            this.tabSqlServer.Padding = new System.Windows.Forms.Padding(3);
            this.tabSqlServer.Size = new System.Drawing.Size(479, 179);
            this.tabSqlServer.TabIndex = 0;
            this.tabSqlServer.Tag = "";
            this.tabSqlServer.Text = "SQL Server";
            this.tabSqlServer.UseVisualStyleBackColor = true;
            // 
            // cboSqlServer
            // 
            this.cboSqlServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSqlServer.FormattingEnabled = true;
            this.cboSqlServer.Location = new System.Drawing.Point(61, 5);
            this.cboSqlServer.Name = "cboSqlServer";
            this.cboSqlServer.Size = new System.Drawing.Size(333, 21);
            this.cboSqlServer.TabIndex = 1;
            this.cboSqlServer.SelectionChangeCommitted += new System.EventHandler(this.cboSqlServer_SelectionChangeCommitted);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtSqlPassword);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSqlLoginName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rbSqlUntrusted);
            this.groupBox1.Controls.Add(this.rbSqlTrusted);
            this.groupBox1.Location = new System.Drawing.Point(20, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 131);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connect Using:";
            // 
            // txtSqlPassword
            // 
            this.txtSqlPassword.Location = new System.Drawing.Point(109, 91);
            this.txtSqlPassword.Name = "txtSqlPassword";
            this.txtSqlPassword.PasswordChar = '*';
            this.txtSqlPassword.Size = new System.Drawing.Size(133, 20);
            this.txtSqlPassword.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "&Password:";
            // 
            // txtSqlLoginName
            // 
            this.txtSqlLoginName.Location = new System.Drawing.Point(109, 65);
            this.txtSqlLoginName.Name = "txtSqlLoginName";
            this.txtSqlLoginName.Size = new System.Drawing.Size(133, 20);
            this.txtSqlLoginName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Login name:";
            // 
            // rbSqlUntrusted
            // 
            this.rbSqlUntrusted.AutoSize = true;
            this.rbSqlUntrusted.Location = new System.Drawing.Point(20, 42);
            this.rbSqlUntrusted.Name = "rbSqlUntrusted";
            this.rbSqlUntrusted.Size = new System.Drawing.Size(151, 17);
            this.rbSqlUntrusted.TabIndex = 1;
            this.rbSqlUntrusted.Text = "S&QL Server Authentication";
            this.rbSqlUntrusted.UseVisualStyleBackColor = true;
            // 
            // rbSqlTrusted
            // 
            this.rbSqlTrusted.AutoSize = true;
            this.rbSqlTrusted.Location = new System.Drawing.Point(20, 19);
            this.rbSqlTrusted.Name = "rbSqlTrusted";
            this.rbSqlTrusted.Size = new System.Drawing.Size(140, 17);
            this.rbSqlTrusted.TabIndex = 0;
            this.rbSqlTrusted.Text = "&Windows Authentication";
            this.rbSqlTrusted.UseVisualStyleBackColor = true;
            this.rbSqlTrusted.CheckedChanged += new System.EventHandler(this.rbSqlTrusted_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Server";
            // 
            // tabODBC
            // 
            this.tabODBC.Controls.Add(this.cmdSave);
            this.tabODBC.Controls.Add(this.cmdLoad);
            this.tabODBC.Controls.Add(this.label4);
            this.tabODBC.Controls.Add(this.txtOleDbConnectionString);
            this.tabODBC.Location = new System.Drawing.Point(4, 22);
            this.tabODBC.Name = "tabODBC";
            this.tabODBC.Size = new System.Drawing.Size(479, 179);
            this.tabODBC.TabIndex = 1;
            this.tabODBC.Text = "ODBC";
            this.tabODBC.UseVisualStyleBackColor = true;
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(145, 140);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(109, 26);
            this.cmdSave.TabIndex = 3;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdLoad
            // 
            this.cmdLoad.Location = new System.Drawing.Point(20, 140);
            this.cmdLoad.Name = "cmdLoad";
            this.cmdLoad.Size = new System.Drawing.Size(109, 26);
            this.cmdLoad.TabIndex = 2;
            this.cmdLoad.Text = "Load";
            this.cmdLoad.UseVisualStyleBackColor = true;
            this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Connection String";
            // 
            // txtOleDbConnectionString
            // 
            this.txtOleDbConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOleDbConnectionString.Location = new System.Drawing.Point(20, 30);
            this.txtOleDbConnectionString.Multiline = true;
            this.txtOleDbConnectionString.Name = "txtOleDbConnectionString";
            this.txtOleDbConnectionString.Size = new System.Drawing.Size(369, 104);
            this.txtOleDbConnectionString.TabIndex = 0;
            // 
            // tabOracle
            // 
            this.tabOracle.Controls.Add(this.groupBox2);
            this.tabOracle.Controls.Add(this.cboOracleDataSource);
            this.tabOracle.Controls.Add(this.label9);
            this.tabOracle.Location = new System.Drawing.Point(4, 22);
            this.tabOracle.Name = "tabOracle";
            this.tabOracle.Padding = new System.Windows.Forms.Padding(3);
            this.tabOracle.Size = new System.Drawing.Size(479, 179);
            this.tabOracle.TabIndex = 2;
            this.tabOracle.Text = "Oracle";
            this.tabOracle.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtOraclePassword);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtOracleLoginName);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.rbOracleUntrusted);
            this.groupBox2.Controls.Add(this.rbOracleTrusted);
            this.groupBox2.Location = new System.Drawing.Point(20, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(385, 134);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connect Using:";
            // 
            // txtOraclePassword
            // 
            this.txtOraclePassword.Location = new System.Drawing.Point(109, 91);
            this.txtOraclePassword.Name = "txtOraclePassword";
            this.txtOraclePassword.PasswordChar = '*';
            this.txtOraclePassword.Size = new System.Drawing.Size(133, 20);
            this.txtOraclePassword.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "&Password:";
            // 
            // txtOracleLoginName
            // 
            this.txtOracleLoginName.Location = new System.Drawing.Point(109, 65);
            this.txtOracleLoginName.Name = "txtOracleLoginName";
            this.txtOracleLoginName.Size = new System.Drawing.Size(133, 20);
            this.txtOracleLoginName.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "&Login name:";
            // 
            // rbOracleUntrusted
            // 
            this.rbOracleUntrusted.AutoSize = true;
            this.rbOracleUntrusted.Location = new System.Drawing.Point(20, 42);
            this.rbOracleUntrusted.Name = "rbOracleUntrusted";
            this.rbOracleUntrusted.Size = new System.Drawing.Size(127, 17);
            this.rbOracleUntrusted.TabIndex = 1;
            this.rbOracleUntrusted.Text = "Oracle Authentication";
            this.rbOracleUntrusted.UseVisualStyleBackColor = true;
            // 
            // rbOracleTrusted
            // 
            this.rbOracleTrusted.AutoSize = true;
            this.rbOracleTrusted.Location = new System.Drawing.Point(20, 19);
            this.rbOracleTrusted.Name = "rbOracleTrusted";
            this.rbOracleTrusted.Size = new System.Drawing.Size(114, 17);
            this.rbOracleTrusted.TabIndex = 0;
            this.rbOracleTrusted.Text = "&Integrated Security";
            this.rbOracleTrusted.UseVisualStyleBackColor = true;
            this.rbOracleTrusted.CheckedChanged += new System.EventHandler(this.rbOracleTrusted_CheckedChanged);
            // 
            // cboOracleDataSource
            // 
            this.cboOracleDataSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboOracleDataSource.FormattingEnabled = true;
            this.cboOracleDataSource.Location = new System.Drawing.Point(88, 5);
            this.cboOracleDataSource.Name = "cboOracleDataSource";
            this.cboOracleDataSource.Size = new System.Drawing.Size(301, 21);
            this.cboOracleDataSource.TabIndex = 4;
            this.cboOracleDataSource.SelectionChangeCommitted += new System.EventHandler(this.cboOracleDataSource_SelectionChangeCommitted);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "&Data Source";
            // 
            // ConnectForm
            // 
            this.AcceptButton = this.cmdConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(493, 318);
            this.Controls.Add(this.splitContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connect to Server";
            this.Load += new System.EventHandler(this.ConnectForm_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabServerTypes.ResumeLayout(false);
            this.tabSqlServer.ResumeLayout(false);
            this.tabSqlServer.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabODBC.ResumeLayout(false);
            this.tabODBC.PerformLayout();
            this.tabOracle.ResumeLayout(false);
            this.tabOracle.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radioButton1;
      private System.Windows.Forms.RadioButton radioButton2;
      private System.Windows.Forms.SplitContainer splitContainer;
      private System.Windows.Forms.Button cmdConnect;
      private System.Windows.Forms.Button cmdCancel;
      private System.Windows.Forms.CheckBox chkLowBandwidth;
      private System.Windows.Forms.TabControl tabServerTypes;
      private System.Windows.Forms.TabPage tabSqlServer;
      private System.Windows.Forms.ComboBox cboSqlServer;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.TextBox txtSqlPassword;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.TextBox txtSqlLoginName;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.RadioButton rbSqlUntrusted;
      private System.Windows.Forms.RadioButton rbSqlTrusted;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TabPage tabODBC;
      private System.Windows.Forms.Button cmdSave;
      private System.Windows.Forms.Button cmdLoad;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.TextBox txtOleDbConnectionString;
      private System.Windows.Forms.TabPage tabOracle;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.TextBox txtOraclePassword;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.TextBox txtOracleLoginName;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.RadioButton rbOracleUntrusted;
      private System.Windows.Forms.RadioButton rbOracleTrusted;
      private System.Windows.Forms.ComboBox cboOracleDataSource;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.Label labelInstructions;
      private System.Windows.Forms.Label labelTitle;
      private System.Windows.Forms.PictureBox pictureBox1;
    }
}
