namespace QueryExPlus
{
    partial class QueryOptionsForm
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
            this.cmdOk = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmdResetToDefault_General = new System.Windows.Forms.Button();
            this.txtBatchSeparator = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtExecutionTimeout = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTextSize = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRowcount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtExecutionTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTextSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRowcount)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOk
            // 
            this.cmdOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdOk.Location = new System.Drawing.Point(213, 333);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(80, 23);
            this.cmdOk.TabIndex = 22;
            this.cmdOk.Text = "OK";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(313, 333);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(80, 23);
            this.cmdCancel.TabIndex = 21;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(11, 11);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(389, 312);
            this.tabControl1.TabIndex = 20;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmdResetToDefault_General);
            this.tabPage1.Controls.Add(this.txtBatchSeparator);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txtExecutionTimeout);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtTextSize);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtRowcount);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(381, 286);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmdResetToDefault_General
            // 
            this.cmdResetToDefault_General.Location = new System.Drawing.Point(268, 247);
            this.cmdResetToDefault_General.Name = "cmdResetToDefault_General";
            this.cmdResetToDefault_General.Size = new System.Drawing.Size(101, 23);
            this.cmdResetToDefault_General.TabIndex = 12;
            this.cmdResetToDefault_General.Text = "Reset to Default";
            this.cmdResetToDefault_General.UseVisualStyleBackColor = true;
            this.cmdResetToDefault_General.Click += new System.EventHandler(this.cmdResetToDefault_General_Click);
            // 
            // txtBatchSeparator
            // 
            this.txtBatchSeparator.Location = new System.Drawing.Point(129, 206);
            this.txtBatchSeparator.Name = "txtBatchSeparator";
            this.txtBatchSeparator.Size = new System.Drawing.Size(120, 20);
            this.txtBatchSeparator.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Batch separator:";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(13, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(327, 18);
            this.label8.TabIndex = 9;
            this.label8.Text = "Specify a word or character that can be used to separate batches.";
            // 
            // txtExecutionTimeout
            // 
            this.txtExecutionTimeout.Location = new System.Drawing.Point(131, 160);
            this.txtExecutionTimeout.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.txtExecutionTimeout.Name = "txtExecutionTimeout";
            this.txtExecutionTimeout.Size = new System.Drawing.Size(120, 20);
            this.txtExecutionTimeout.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Execution time-out:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(13, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(327, 18);
            this.label6.TabIndex = 6;
            this.label6.Text = "An execution time-out of 0 indicates an unlimited wait (no time-out).";
            // 
            // txtTextSize
            // 
            this.txtTextSize.Location = new System.Drawing.Point(131, 108);
            this.txtTextSize.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.txtTextSize.Name = "txtTextSize";
            this.txtTextSize.Size = new System.Drawing.Size(120, 20);
            this.txtTextSize.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "SET TEXTSIZE:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(13, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(327, 36);
            this.label4.TabIndex = 3;
            this.label4.Text = "Specify the maximum size of text and ntext data returned from a SELECT statement." +
                "";
            // 
            // txtRowcount
            // 
            this.txtRowcount.Location = new System.Drawing.Point(131, 46);
            this.txtRowcount.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtRowcount.Name = "txtRowcount";
            this.txtRowcount.Size = new System.Drawing.Size(120, 20);
            this.txtRowcount.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "SET ROWCOUNT:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Specify the maximum number of rows to return before the server stops processing y" +
                "our query.";
            // 
            // QueryOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 367);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QueryOptionsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Query Options";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtExecutionTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTextSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRowcount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdOk;
        private System.Windows.Forms.Button cmdCancel;
        protected System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button cmdResetToDefault_General;
        internal System.Windows.Forms.TextBox txtBatchSeparator;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.NumericUpDown txtExecutionTimeout;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.NumericUpDown txtTextSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.NumericUpDown txtRowcount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}