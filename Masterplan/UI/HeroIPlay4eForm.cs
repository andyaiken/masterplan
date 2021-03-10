using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class HeroIPlay4eForm : Form
	{
		public HeroIPlay4eForm(string key, bool character)
		{
			InitializeComponent();

			KeyBox.Text = key;

			if (!character)
			{
				Text = "iPlay4e Campaign";
				KeyLbl.Text = "Campaign Key:";
			}
		}

		public string Key
		{
			get
			{
				return KeyBox.Text;
			}
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
		}

		private void WebsiteLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string url = "www.iplay4e.com";
			System.Diagnostics.Process.Start(url);
		}
	}
}
