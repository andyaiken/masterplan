using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class PartyForm : Form
	{
		public PartyForm(Party p)
		{
			InitializeComponent();

			fParty = p;

			SizeBox.Value = fParty.Size;
			LevelBox.Value = fParty.Level;
		}

		public Party Party
		{
			get { return fParty; }
		}
		Party fParty = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fParty.Size = (int)SizeBox.Value;
			fParty.Level = (int)LevelBox.Value;
		}
	}
}
