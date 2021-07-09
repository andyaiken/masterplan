using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class PowerInfoForm : Form
	{
		public PowerInfoForm(CreaturePower power)
		{
			InitializeComponent();

			NameBox.Text = power.Name;
			KeywordBox.Text = power.Keywords;
		}

		public string PowerName
		{
			get { return NameBox.Text; }
		}

		public string PowerKeywords
		{
			get { return KeywordBox.Text; }
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
		}
	}
}
