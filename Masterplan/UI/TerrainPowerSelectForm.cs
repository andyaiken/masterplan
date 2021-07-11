using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class TerrainPowerSelectForm : Form
	{
		public TerrainPowerSelectForm()
		{
			InitializeComponent();

			List<TerrainPower> challenges = Session.TerrainPowers;

			foreach (TerrainPower sc in challenges)
			{
				ListViewItem lvi = ChallengeList.Items.Add(sc.Name);
				lvi.SubItems.Add(sc.Name);
				lvi.Tag = sc;
			}

			Application.Idle += new EventHandler(Application_Idle);

			Browser.DocumentText = "";
			ChallengeList_SelectedIndexChanged(null, null);
		}

		~TerrainPowerSelectForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			OKBtn.Enabled = (TerrainPower != null);
		}

		public TerrainPower TerrainPower
		{
			get
			{
				if (ChallengeList.SelectedItems.Count != 0)
					return ChallengeList.SelectedItems[0].Tag as TerrainPower;

				return null;
			}
		}

		private void TileList_DoubleClick(object sender, EventArgs e)
		{
			if (TerrainPower != null)
			{
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void ChallengeList_SelectedIndexChanged(object sender, EventArgs e)
		{
			string html = HTML.TerrainPower(TerrainPower, Session.Preferences.TextSize);

			Browser.Document.OpenNew(true);
			Browser.Document.Write(html);
		}
	}
}
