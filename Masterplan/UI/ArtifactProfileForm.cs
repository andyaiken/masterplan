using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class ArtifactProfileForm : Form
	{
		public ArtifactProfileForm(Artifact artifact)
		{
			InitializeComponent();

			fArtifact = artifact;

			// Populate tiers
			foreach (Tier tier in Enum.GetValues(typeof(Tier)))
				TierBox.Items.Add(tier);

			NameBox.Text = fArtifact.Name;
			TierBox.SelectedItem = fArtifact.Tier;
		}

		public Artifact Artifact
		{
			get { return fArtifact; }
		}
		Artifact fArtifact = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fArtifact.Name = NameBox.Text;
			fArtifact.Tier = (Tier)TierBox.SelectedItem;
		}
	}
}
