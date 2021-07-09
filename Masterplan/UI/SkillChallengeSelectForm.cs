using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class SkillChallengeSelectForm : Form
	{
		public SkillChallengeSelectForm()
		{
			InitializeComponent();

			List<SkillChallenge> challenges = Session.SkillChallenges;

			foreach (SkillChallenge sc in challenges)
			{
				ListViewItem lvi = ChallengeList.Items.Add(sc.Name);
				lvi.SubItems.Add(sc.Info);
				lvi.Tag = sc;
			}

			Application.Idle += new EventHandler(Application_Idle);

			Browser.DocumentText = "";
			ChallengeList_SelectedIndexChanged(null, null);
		}

		void Application_Idle(object sender, EventArgs e)
		{
			OKBtn.Enabled = (SkillChallenge != null);
		}

		public SkillChallenge SkillChallenge
		{
			get
			{
				if (ChallengeList.SelectedItems.Count != 0)
					return ChallengeList.SelectedItems[0].Tag as SkillChallenge;

				return null;
			}
		}

		private void TileList_DoubleClick(object sender, EventArgs e)
		{
			if (SkillChallenge != null)
			{
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void ChallengeList_SelectedIndexChanged(object sender, EventArgs e)
		{
			string html = HTML.SkillChallenge(SkillChallenge, false, true, DisplaySize.Small);

			Browser.Document.OpenNew(true);
			Browser.Document.Write(html);
		}
	}
}
