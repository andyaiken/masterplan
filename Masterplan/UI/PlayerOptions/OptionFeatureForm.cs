using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class OptionFeatureForm : Form
	{
		public OptionFeatureForm(Feature feature)
		{
			InitializeComponent();

			fFeature = feature.Copy();

			NameBox.Text = fFeature.Name;
			DetailsBox.Text = fFeature.Details;
		}

		public Feature Feature
		{
			get { return fFeature; }
		}
		Feature fFeature = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fFeature.Name = NameBox.Text;
			fFeature.Details = DetailsBox.Text;
		}
	}
}
