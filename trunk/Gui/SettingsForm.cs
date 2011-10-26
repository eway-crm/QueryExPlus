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

		private void LoadSettings()
		{
			cbGridDefault.Checked = QueryExPlus.Properties.Settings.Default.ResultInGridDefault;
			cbSQLAuthDefault.Checked = QueryExPlus.Properties.Settings.Default.SQLAuthenticationDefault;
			tbDelimiter.Text = QueryExPlus.Properties.Settings.Default.Delimiter;
			tbTextDelimiter.Text = QueryExPlus.Properties.Settings.Default.TextDelimiter.ToString();
			return;
		}
		
		private void SaveSettings()
		{
			QueryExPlus.Properties.Settings.Default.ResultInGridDefault = cbGridDefault.Checked;
			QueryExPlus.Properties.Settings.Default.SQLAuthenticationDefault = cbSQLAuthDefault.Checked;

			if (tbDelimiter.Text != "")
			{
				QueryExPlus.Properties.Settings.Default.Delimiter = tbDelimiter.Text;
			}
			else
			{
				QueryExPlus.Properties.Settings.Default.Delimiter = ",";
			}
			if (tbTextDelimiter.Text.Length == 1 && tbTextDelimiter.Text != " ")
			{
				QueryExPlus.Properties.Settings.Default.TextDelimiter = char.Parse(tbTextDelimiter.Text);
			}
			else
			{
				QueryExPlus.Properties.Settings.Default.TextDelimiter = '"';
			}
			return;
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			SaveSettings();
			this.Close();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
