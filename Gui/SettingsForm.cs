using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QueryExPlus.Gui
{
	public partial class SettingsForm : Form
	{
		public SettingsForm()
		{
			InitializeComponent();
			LoadSettings();
		}

		public DialogResult ShowDialog(IWin32Window owner)
		{
			this.Icon = ((Form) owner).Icon;
			return base.ShowDialog(owner);
		}

		private void LoadSettings()
		{
			cbGridDefault.Checked = Properties.Settings.Default.ResultInGridDefault;
			cbSQLAuthDefault.Checked = Properties.Settings.Default.SQLAuthenticationDefault;
			cbSyntaxHighlight.Checked = Properties.Settings.Default.SyntaxHighlighting;
			tbDelimiter.Text = Properties.Settings.Default.Delimiter;
			tbTextDelimiter.Text = Properties.Settings.Default.TextDelimiter.ToString();

			picBoxKeywords.BackColor = Properties.Settings.Default.ColorKeywords;
			picBoxOperators.BackColor = Properties.Settings.Default.ColorOperators;
			picBoxStrings.BackColor = Properties.Settings.Default.ColorStrings;
			picBoxNumbers.BackColor = Properties.Settings.Default.ColorNumbers;
		}
		
		private void SaveSettings()
		{
			Properties.Settings.Default.ResultInGridDefault = cbGridDefault.Checked;
			Properties.Settings.Default.SQLAuthenticationDefault = cbSQLAuthDefault.Checked;
			Properties.Settings.Default.SyntaxHighlighting = cbSyntaxHighlight.Checked;

			Properties.Settings.Default.ColorKeywords = picBoxKeywords.BackColor;
			Properties.Settings.Default.ColorOperators = picBoxOperators.BackColor;
			Properties.Settings.Default.ColorStrings = picBoxStrings.BackColor;
			Properties.Settings.Default.ColorNumbers = picBoxNumbers.BackColor;

			if (tbDelimiter.Text != "")
			{
				Properties.Settings.Default.Delimiter = tbDelimiter.Text;
			}
			else
			{
				Properties.Settings.Default.Delimiter = ",";
			}
			if (tbTextDelimiter.Text.Length == 1 && tbTextDelimiter.Text != " ")
			{
				Properties.Settings.Default.TextDelimiter = char.Parse(tbTextDelimiter.Text);
			}
			else
			{
				Properties.Settings.Default.TextDelimiter = '"';
			}
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			SaveSettings();
			DialogResult = DialogResult.OK;
			Close();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void picBoxColor_Click(object sender, EventArgs e)
		{
			colorDialog.Color = ((PictureBox) sender).BackColor;
			colorDialog.ShowDialog();
			((PictureBox) sender).BackColor = colorDialog.Color;
		}
	}
}
