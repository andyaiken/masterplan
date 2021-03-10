using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class TokenLinkForm : Form
	{
		public TokenLinkForm(TokenLink link)
		{
			InitializeComponent();

			LinkTextBox.Items.Add("Marked");
			LinkTextBox.Items.Add("Oath");
			LinkTextBox.Items.Add("Quarry");
			LinkTextBox.Items.Add("Curse");
			LinkTextBox.Items.Add("Shroud");
			LinkTextBox.Items.Add("Dominated");
			LinkTextBox.Items.Add("Sanctioned");

			fLink = link.Copy();

			LinkTextBox.Text = fLink.Text;
		}

		public TokenLink Link
		{
			get { return fLink; }
		}
		TokenLink fLink = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fLink.Text = LinkTextBox.Text;
		}
	}
}
