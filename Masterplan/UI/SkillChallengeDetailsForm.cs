using System;
using System.IO;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class SkillChallengeDetailsForm : Form
	{
		public SkillChallengeDetailsForm(SkillChallenge sc)
		{
			InitializeComponent();

			fChallenge = sc.Copy() as SkillChallenge;

			Browser.DocumentText = HTML.SkillChallenge(fChallenge, false, true, DisplaySize.Small);
		}

		SkillChallenge fChallenge = null;

		private void PlayerViewBtn_Click(object sender, EventArgs e)
		{
			if (Session.PlayerView == null)
				Session.PlayerView = new PlayerViewForm(this);

			Session.PlayerView.ShowSkillChallenge(fChallenge);
		}

		private void ExportHTML_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.FileName = fChallenge.Name;
			dlg.Filter = Program.HTMLFilter;

			if (dlg.ShowDialog() == DialogResult.OK)
				File.WriteAllText(dlg.FileName, Browser.DocumentText);
		}
	}
}
