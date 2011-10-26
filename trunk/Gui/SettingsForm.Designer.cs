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
			this.cbGridDefault = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbDelimiter = new System.Windows.Forms.TextBox();
			this.tbTextDelimiter = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// saveButton
			// 
			this.saveButton.Location = new System.Drawing.Point(55, 227);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 23);
			this.saveButton.TabIndex = 0;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(185, 227);
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
			this.groupBox1.Text = "SQL";
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
			this.groupBox2.Controls.Add(this.cbGridDefault);
			this.groupBox2.Location = new System.Drawing.Point(12, 118);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(217, 72);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "General";
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
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Delimiter:";
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
			// tbDelimiter
			// 
			this.tbDelimiter.Location = new System.Drawing.Point(81, 17);
			this.tbDelimiter.Name = "tbDelimiter";
			this.tbDelimiter.Size = new System.Drawing.Size(32, 20);
			this.tbDelimiter.TabIndex = 2;
			// 
			// tbTextDelimiter
			// 
			this.tbTextDelimiter.Location = new System.Drawing.Point(81, 43);
			this.tbTextDelimiter.Name = "tbTextDelimiter";
			this.tbTextDelimiter.Size = new System.Drawing.Size(24, 20);
			this.tbTextDelimiter.TabIndex = 3;
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(412, 257);
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

	}
}