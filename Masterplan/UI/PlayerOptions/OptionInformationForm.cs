using System;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class OptionInformationForm : Form
	{
		public OptionInformationForm(Pair<int, string> info)
		{
			InitializeComponent();

			fInfo = info;

			DCBox.Value = fInfo.First;
			DetailsBox.Text = fInfo.Second;
		}

		public Pair<int, string> Information
		{
			get { return fInfo; }
		}
		Pair<int, string> fInfo = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fInfo.First = (int)DCBox.Value;
			fInfo.Second = DetailsBox.Text;
		}
	}
}
