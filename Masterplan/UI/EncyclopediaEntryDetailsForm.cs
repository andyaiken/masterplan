using System;
using System.IO;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class EncyclopediaEntryDetailsForm : Form
	{
		public EncyclopediaEntryDetailsForm(EncyclopediaEntry entry)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fEntry = entry;

			update_entry();
		}

		void Application_Idle(object sender, EventArgs e)
		{
			DMBtn.Checked = fShowDMInfo;
		}

		EncyclopediaEntry fEntry = null;
		bool fShowDMInfo = false;

		private void PlayerViewBtn_Click(object sender, EventArgs e)
		{
			if (fEntry != null)
			{
				if (Session.PlayerView == null)
					Session.PlayerView = new PlayerViewForm(this);

				Session.PlayerView.ShowEncyclopediaItem(fEntry);
			}
		}

		private void DMBtn_Click(object sender, EventArgs e)
		{
			fShowDMInfo = !fShowDMInfo;
			update_entry();
		}

		void update_entry()
		{
			Browser.DocumentText = HTML.EncyclopediaEntry(fEntry, Session.Project.Encyclopedia, Session.Preferences.TextSize, fShowDMInfo, false, false, true);
		}

		private void Browser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			if (e.Url.Scheme == "picture")
			{
				e.Cancel = true;
				Guid id = new Guid(e.Url.LocalPath);

				EncyclopediaImage img = fEntry.FindImage(id);
				if (img != null)
				{
					EncyclopediaImageForm dlg = new EncyclopediaImageForm(img);
					dlg.ShowDialog();
				}
			}
		}

		private void ExportHTML_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.FileName = fEntry.Name;
			dlg.Filter = Program.HTMLFilter;

			if (dlg.ShowDialog() == DialogResult.OK)
				File.WriteAllText(dlg.FileName, Browser.DocumentText);
		}
	}
}
