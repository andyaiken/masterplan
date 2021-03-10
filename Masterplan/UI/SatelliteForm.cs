using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class SatelliteForm : Form
	{
		public SatelliteForm(Satellite sat)
		{
			InitializeComponent();

			fSatellite = sat.Copy();

			if (fSatellite.Period == 0)
				fSatellite.Period = 1;

			NameBox.Text = fSatellite.Name;
			PeriodBox.Value = fSatellite.Period;
			OffsetBox.Value = fSatellite.Offset;
		}

		public Satellite Satellite
		{
			get { return fSatellite; }
		}
		Satellite fSatellite = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fSatellite.Name = NameBox.Text;
			fSatellite.Period = (int)PeriodBox.Value;
			fSatellite.Offset = (int)OffsetBox.Value;
		}
	}
}
