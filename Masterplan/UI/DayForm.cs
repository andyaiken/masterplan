using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class DayForm : Form
	{
		public DayForm(DayInfo day)
		{
			InitializeComponent();

			fDayInfo = day.Copy();

			NameBox.Text = fDayInfo.Name;
			NameBox.SelectAll();
		}

		public DayInfo DayInfo
		{
			get { return fDayInfo; }
		}
		DayInfo fDayInfo = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fDayInfo.Name = NameBox.Text;
		}
	}
}
