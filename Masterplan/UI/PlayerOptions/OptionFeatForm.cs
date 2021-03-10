using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class OptionFeatForm : Form
	{
		public OptionFeatForm(Feat feat)
		{
			InitializeComponent();

			Array tiers = Enum.GetValues(typeof(Tier));
			foreach (Tier tier in tiers)
				TierBox.Items.Add(tier);

			fFeat = feat.Copy();

			NameBox.Text = fFeat.Name;
			PrereqBox.Text = fFeat.Prerequisites;
			TierBox.SelectedItem = fFeat.Tier;
			BenefitBox.Text = fFeat.Benefits;
		}

		public Feat Feat
		{
			get { return fFeat; }
		}
		Feat fFeat = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fFeat.Name = NameBox.Text;
			fFeat.Prerequisites = PrereqBox.Text;
			fFeat.Tier = (Tier)TierBox.SelectedItem;
			fFeat.Benefits = BenefitBox.Text;
		}
	}
}
