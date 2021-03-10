using System;
using System.Drawing.Printing;
using System.Windows.Forms;

using Masterplan.Controls;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class MapPrintingForm : Form
	{
		public MapPrintingForm(MapView mapview)
		{
			InitializeComponent();

			fMapView = mapview;
			OnePageBtn.Checked = true;
		}

		MapView fMapView = null;
		PrinterSettings fSettings = new PrinterSettings();

		private void OKBtn_Click(object sender, EventArgs e)
		{
			bool poster = PosterBtn.Checked;
			MapPrinting.Print(fMapView, poster, fSettings);
		}

		private void PrintBtn_Click(object sender, EventArgs e)
		{
			PrintDialog dlg = new PrintDialog();
			dlg.AllowPrintToFile = false;
			dlg.PrinterSettings = fSettings;

			if (dlg.ShowDialog() == DialogResult.OK)
				fSettings = dlg.PrinterSettings;
		}
	}
}
