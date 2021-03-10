using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class SeasonForm : Form
	{
		public SeasonForm(CalendarEvent ce, Calendar calendar)
		{
			InitializeComponent();

			fSeason = ce.Copy();
			fCalendar = calendar;

			foreach (MonthInfo mi in fCalendar.Months)
				MonthBox.Items.Add(mi);

			NameBox.Text = fSeason.Name;
			DayBox.Value = fSeason.DayIndex + 1;

			MonthInfo month = fCalendar.FindMonth(fSeason.MonthID);
			MonthBox.SelectedItem = month;
		}

		public CalendarEvent Season
		{
			get { return fSeason; }
		}
		CalendarEvent fSeason = null;

		Calendar fCalendar = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fSeason.Name = NameBox.Text;
			fSeason.DayIndex = (int)DayBox.Value - 1;

			MonthInfo mi = MonthBox.SelectedItem as MonthInfo;
			fSeason.MonthID = mi.ID;
		}

		private void MonthBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			MonthInfo mi = MonthBox.SelectedItem as MonthInfo;
			DayBox.Maximum = mi.DayCount;
		}
	}
}
