using System;
using System.IO;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class CreatureTemplateDetailsForm : Form
	{
		public CreatureTemplateDetailsForm(CreatureTemplate ct)
		{
			InitializeComponent();

			fTemplate = ct.Copy();

			Browser.DocumentText = HTML.CreatureTemplate(fTemplate, Session.Preferences.TextSize, false);
		}

		CreatureTemplate fTemplate = null;

		private void PlayerViewBtn_Click(object sender, EventArgs e)
		{
			if (Session.PlayerView == null)
				Session.PlayerView = new PlayerViewForm(this);

			Session.PlayerView.ShowCreatureTemplate(fTemplate);
		}

		private void ExportHTML_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.FileName = fTemplate.Name;
			dlg.Filter = Program.HTMLFilter;

			if (dlg.ShowDialog() == DialogResult.OK)
				File.WriteAllText(dlg.FileName, Browser.DocumentText);
		}
	}
}
