using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class AuraForm : Form
	{
		public AuraForm(Aura aura)
		{
			InitializeComponent();

			fAura = aura.Copy();

			NameBox.Text = fAura.Name;
			KeywordBox.Text = fAura.Keywords;
			SizeBox.Value = fAura.Radius;
			DetailsBox.Text = fAura.Description;
		}

		public Aura Aura
		{
			get { return fAura; }
		}
		Aura fAura = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fAura.Name = NameBox.Text;
			fAura.Keywords = KeywordBox.Text;
			fAura.Details = SizeBox.Value + ": " + DetailsBox.Text;
		}
	}
}
