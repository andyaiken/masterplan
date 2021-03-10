using System;
using System.IO;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class MagicItemDetailsForm : Form
	{
		public MagicItemDetailsForm(MagicItem item)
		{
			InitializeComponent();

			fItem = item.Copy() as MagicItem;

			Browser.DocumentText = HTML.MagicItem(fItem, DisplaySize.Small, false, true);
		}

		MagicItem fItem = null;

		private void PlayerViewBtn_Click(object sender, EventArgs e)
		{
			if (Session.PlayerView == null)
				Session.PlayerView = new PlayerViewForm(this);

			Session.PlayerView.ShowMagicItem(fItem);
		}

		private void ExportHTML_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.FileName = fItem.Name;
			dlg.Filter = Program.HTMLFilter;

			if (dlg.ShowDialog() == DialogResult.OK)
				File.WriteAllText(dlg.FileName, Browser.DocumentText);
		}
	}
}
