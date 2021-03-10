using System;
using System.IO;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class HeroDetailsForm : Form
	{
		public HeroDetailsForm(Hero hero)
		{
			InitializeComponent();

			fHero = hero.Copy();

			Browser.DocumentText = HTML.StatBlock(fHero, null, true, false, false, DisplaySize.Small);
		}

		Hero fHero = null;

		private void PlayerViewBtn_Click(object sender, EventArgs e)
		{
			if (Session.PlayerView == null)
				Session.PlayerView = new PlayerViewForm(this);

			Session.PlayerView.ShowHero(fHero);
		}

		private void ExportHTML_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.FileName = fHero.Name;
			dlg.Filter = Program.HTMLFilter;

			if (dlg.ShowDialog() == DialogResult.OK)
				File.WriteAllText(dlg.FileName, Browser.DocumentText);
		}
	}
}
