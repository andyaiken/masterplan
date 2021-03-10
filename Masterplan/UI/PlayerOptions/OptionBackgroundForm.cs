using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class OptionBackgroundForm : Form
	{
		public OptionBackgroundForm(PlayerBackground bg)
		{
			InitializeComponent();

			fBackground = bg.Copy();

			NameBox.Text = fBackground.Name;
			SkillBox.Text = fBackground.AssociatedSkills;
			FeatBox.Text = fBackground.RecommendedFeats;
			DetailsBox.Text = fBackground.Details;
		}

		public PlayerBackground Background
		{
			get { return fBackground; }
		}
		PlayerBackground fBackground = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fBackground.Name = NameBox.Text;
			fBackground.AssociatedSkills = SkillBox.Text;
			fBackground.RecommendedFeats = FeatBox.Text;
			fBackground.Details = DetailsBox.Text;
		}
	}
}
