using System;
using System.IO;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class ArtifactDetailsForm : Form
	{
		public ArtifactDetailsForm(Artifact artifact)
		{
			InitializeComponent();

			fArtifact = artifact.Copy();

			Browser.DocumentText = HTML.Artifact(fArtifact, DisplaySize.Small, false, true);
		}

		Artifact fArtifact = null;

		private void PlayerViewBtn_Click(object sender, EventArgs e)
		{
			if (Session.PlayerView == null)
				Session.PlayerView = new PlayerViewForm(this);

			Session.PlayerView.ShowArtifact(fArtifact);
		}

		private void ExportHTML_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.FileName = fArtifact.Name;
			dlg.Filter = Program.HTMLFilter;

			if (dlg.ShowDialog() == DialogResult.OK)
				File.WriteAllText(dlg.FileName, Browser.DocumentText);
		}
	}
}
