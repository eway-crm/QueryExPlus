namespace QueryExPlus.Gui
{
	partial class SettingsForm
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
			this.saveButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cbSQLAuthDefault = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cbSyntaxHighlight = new System.Windows.Forms.CheckBox();
			this.cbGridDefault = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.tbTextDelimiter = new System.Windows.Forms.TextBox();
			this.tbDelimiter = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.colorDialog = new System.Windows.Forms.ColorDialog();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.picBoxNumbers = new System.Windows.Forms.PictureBox();
			this.picBoxStrings = new System.Windows.Forms.PictureBox();
			this.picBoxOperators = new System.Windows.Forms.PictureBox();
			this.picBoxKeywords = new System.Windows.Forms.PictureBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picBoxNumbers)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picBoxStrings)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picBoxOperators)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picBoxKeywords)).BeginInit();
			this.SuspendLayout();
			// 
			// saveButton
			// 
			this.saveButton.Location = new System.Drawing.Point(55, 263);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 23);
			this.saveButton.TabIndex = 0;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.CausesValidation = false;
			this.cancelButton.Location = new System.Drawing.Point(185, 263);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cbSQLAuthDefault);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(217, 100);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Authentication";
			// 
			// cbSQLAuthDefault
			// 
			this.cbSQLAuthDefault.AutoSize = true;
			this.cbSQLAuthDefault.Location = new System.Drawing.Point(13, 20);
			this.cbSQLAuthDefault.Name = "cbSQLAuthDefault";
			this.cbSQLAuthDefault.Size = new System.Drawing.Size(189, 17);
			this.cbSQLAuthDefault.TabIndex = 0;
			this.cbSQLAuthDefault.Text = "Use SQL Authentication as default";
			this.cbSQLAuthDefault.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.cbSyntaxHighlight);
			this.groupBox2.Controls.Add(this.cbGridDefault);
			this.groupBox2.Location = new System.Drawing.Point(12, 118);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(217, 139);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "General";
			// 
			// cbSyntaxHighlight
			// 
			this.cbSyntaxHighlight.AutoSize = true;
			this.cbSyntaxHighlight.Location = new System.Drawing.Point(7, 44);
			this.cbSyntaxHighlight.Name = "cbSyntaxHighlight";
			this.cbSyntaxHighlight.Size = new System.Drawing.Size(138, 17);
			this.cbSyntaxHighlight.TabIndex = 1;
			this.cbSyntaxHighlight.Text = "Use Syntax Highlighting";
			this.cbSyntaxHighlight.UseVisualStyleBackColor = true;
			// 
			// cbGridDefault
			// 
			this.cbGridDefault.AutoSize = true;
			this.cbGridDefault.Location = new System.Drawing.Point(7, 20);
			this.cbGridDefault.Name = "cbGridDefault";
			this.cbGridDefault.Size = new System.Drawing.Size(166, 17);
			this.cbGridDefault.TabIndex = 0;
			this.cbGridDefault.Text = "Show results in grid as default";
			this.cbGridDefault.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.tbTextDelimiter);
			this.groupBox3.Controls.Add(this.tbDelimiter);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Location = new System.Drawing.Point(235, 12);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(146, 100);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "CSV";
			// 
			// tbTextDelimiter
			// 
			this.tbTextDelimiter.Location = new System.Drawing.Point(81, 43);
			this.tbTextDelimiter.Name = "tbTextDelimiter";
			this.tbTextDelimiter.Size = new System.Drawing.Size(24, 20);
			this.tbTextDelimiter.TabIndex = 3;
			// 
			// tbDelimiter
			// 
			this.tbDelimiter.Location = new System.Drawing.Point(81, 17);
			this.tbDelimiter.Name = "tbDelimiter";
			this.tbDelimiter.Size = new System.Drawing.Size(32, 20);
			this.tbDelimiter.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 47);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Text Delimiter:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Delimiter:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 23);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "SQL Keywords:";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.picBoxNumbers);
			this.groupBox4.Controls.Add(this.picBoxStrings);
			this.groupBox4.Controls.Add(this.picBoxOperators);
			this.groupBox4.Controls.Add(this.picBoxKeywords);
			this.groupBox4.Controls.Add(this.label6);
			this.groupBox4.Controls.Add(this.label5);
			this.groupBox4.Controls.Add(this.label4);
			this.groupBox4.Controls.Add(this.label3);
			this.groupBox4.Location = new System.Drawing.Point(235, 119);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(146, 138);
			this.groupBox4.TabIndex = 5;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Syntax Highlighting Colors";
			// 
			// picBoxNumbers
			// 
			this.picBoxNumbers.BackColor = System.Drawing.SystemColors.MenuText;
			this.picBoxNumbers.Location = new System.Drawing.Point(93, 93);
			this.picBoxNumbers.Name = "picBoxNumbers";
			this.picBoxNumbers.Size = new System.Drawing.Size(47, 17);
			this.picBoxNumbers.TabIndex = 11;
			this.picBoxNumbers.TabStop = false;
			this.picBoxNumbers.Click += new System.EventHandler(this.picBoxColor_Click);
			// 
			// picBoxStrings
			// 
			this.picBoxStrings.BackColor = System.Drawing.SystemColors.MenuText;
			this.picBoxStrings.Location = new System.Drawing.Point(93, 70);
			this.picBoxStrings.Name = "picBoxStrings";
			this.picBoxStrings.Size = new System.Drawing.Size(47, 17);
			this.picBoxStrings.TabIndex = 10;
			this.picBoxStrings.TabStop = false;
			this.picBoxStrings.Click += new System.EventHandler(this.picBoxColor_Click);
			// 
			// picBoxOperators
			// 
			this.picBoxOperators.BackColor = System.Drawing.SystemColors.MenuText;
			this.picBoxOperators.Location = new System.Drawing.Point(93, 44);
			this.picBoxOperators.Name = "picBoxOperators";
			this.picBoxOperators.Size = new System.Drawing.Size(47, 17);
			this.picBoxOperators.TabIndex = 9;
			this.picBoxOperators.TabStop = false;
			this.picBoxOperators.Click += new System.EventHandler(this.picBoxColor_Click);
			// 
			// picBoxKeywords
			// 
			this.picBoxKeywords.BackColor = System.Drawing.SystemColors.MenuText;
			this.picBoxKeywords.Location = new System.Drawing.Point(93, 19);
			this.picBoxKeywords.Name = "picBoxKeywords";
			this.picBoxKeywords.Size = new System.Drawing.Size(47, 17);
			this.picBoxKeywords.TabIndex = 8;
			this.picBoxKeywords.TabStop = false;
			this.picBoxKeywords.Click += new System.EventHandler(this.picBoxColor_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(35, 97);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(52, 13);
			this.label6.TabIndex = 7;
			this.label6.Text = "Numbers:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(45, 74);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(42, 13);
			this.label5.TabIndex = 6;
			this.label5.Text = "Strings:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(31, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Operators:";
			// 
			// SettingsForm
			// 
			this.AcceptButton = this.saveButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(412, 307);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.saveButton);
			this.Name = "SettingsForm";
			this.Text = "SettingsForm";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picBoxNumbers)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picBoxStrings)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picBoxOperators)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picBoxKeywords)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox cbSQLAuthDefault;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox cbGridDefault;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox tbTextDelimiter;
		private System.Windows.Forms.TextBox tbDelimiter;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox cbSyntaxHighlight;
		private System.Windows.Forms.ColorDialog colorDialog;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.PictureBox picBoxNumbers;
		private System.Windows.Forms.PictureBox picBoxStrings;
		private System.Windows.Forms.PictureBox picBoxOperators;
		private System.Windows.Forms.PictureBox picBoxKeywords;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;

	}
}