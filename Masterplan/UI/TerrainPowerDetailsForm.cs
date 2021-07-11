using System;
using System.IO;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class TerrainPowerDetailsForm : Form
	{
		public TerrainPowerDetailsForm(TerrainPower tp)
		{
			InitializeComponent();

			fTerrainPower = tp.Copy();

			Browser.DocumentText = HTML.TerrainPower(fTerrainPower, Session.Preferences.TextSize);
		}

		TerrainPower fTerrainPower = null;

		private void PlayerViewBtn_Click(object sender, EventArgs e)
		{
			if (Session.PlayerView == null)
				Session.PlayerView = new PlayerViewForm(this);

			Session.PlayerView.ShowTerrainPower(fTerrainPower);
		}

		private void ExportHTML_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.FileName = fTerrainPower.Name;
			dlg.Filter = Program.HTMLFilter;

			if (dlg.ShowDialog() == DialogResult.OK)
				File.WriteAllText(dlg.FileName, Browser.DocumentText);
		}
	}
}
