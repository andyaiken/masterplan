using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class RegenerationForm : Form
	{
		public RegenerationForm(Regeneration regen)
		{
			InitializeComponent();

			fRegeneration = regen.Copy();

			ValueBox.Value = fRegeneration.Value;
			DetailsBox.Text = fRegeneration.Details;
		}

		public Regeneration Regeneration
		{
			get { return fRegeneration; }
		}
		Regeneration fRegeneration = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fRegeneration.Value = (int)ValueBox.Value;
			fRegeneration.Details = DetailsBox.Text;
		}
	}
}
