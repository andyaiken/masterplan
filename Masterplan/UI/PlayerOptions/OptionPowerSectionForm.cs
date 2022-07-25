using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class OptionPowerSectionForm : Form
	{
		public OptionPowerSectionForm(PlayerPowerSection section)
		{
			InitializeComponent();

			HeaderBox.Items.Add(Session.I18N.Attack);
			HeaderBox.Items.Add("Trigger");
			HeaderBox.Items.Add("Effect");
			HeaderBox.Items.Add("Aftereffect");
			HeaderBox.Items.Add("Hit");
			HeaderBox.Items.Add("Miss");
			HeaderBox.Items.Add("Target");
			HeaderBox.Items.Add(Session.I18N.Prerequisite);
			HeaderBox.Items.Add("Requirement");
			HeaderBox.Items.Add(Session.I18N.Sustain);
			HeaderBox.Items.Add("Special");

			fSection = section.Copy();

			HeaderBox.Text = fSection.Header;
			DetailsBox.Text = fSection.Details;
		}

		public PlayerPowerSection Section
		{
			get { return fSection; }
		}
		PlayerPowerSection fSection = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fSection.Header = HeaderBox.Text;
			fSection.Details = DetailsBox.Text;
		}
	}
}
