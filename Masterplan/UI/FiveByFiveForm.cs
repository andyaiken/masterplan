using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class FiveByFiveForm : Form
	{
		public FiveByFiveForm(FiveByFiveData five_by_five)
		{
			InitializeComponent();

			f5x5 = five_by_five.Copy();

			FiveByFivePanel.Data = f5x5;
		}

		public FiveByFiveData FiveByFive
		{
			get { return f5x5; }
		}
		FiveByFiveData f5x5 = null;

		public bool CreatePlot
		{
			get { return fCreatePlot; }
		}
		bool fCreatePlot = false;

		private void OKBtn_Click(object sender, EventArgs e)
		{
		}

		private void FiveByFiveForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (DialogResult == DialogResult.OK)
			{
				// Offer to create a plot
				string str = "Do you want to build a plotline from these items?";
				DialogResult dr = MessageBox.Show(str, "Masterplan", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				switch (dr)
				{
					case DialogResult.Yes:
						fCreatePlot = true;
						break;
					case DialogResult.No:
						fCreatePlot = false;
						break;
					case DialogResult.Cancel:
						e.Cancel = true;
						break;
				}
			}
		}
	}
}
