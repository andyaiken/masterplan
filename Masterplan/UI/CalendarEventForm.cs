using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class CalendarEventForm : Form
	{
		public CalendarEventForm(CalendarEvent ce, Calendar calendar)
		{
			InitializeComponent();

			fEvent = ce.Copy();
			fCalendar = calendar;

			foreach (MonthInfo mi in fCalendar.Months)
				MonthBox.Items.Add(mi);

			NameBox.Text = fEvent.Name;
			DayBox.Value = fEvent.DayIndex + 1;

			MonthInfo month = fCalendar.FindMonth(fEvent.MonthID);
			MonthBox.SelectedItem = month;
		}

		public CalendarEvent Event
		{
			get { return fEvent; }
		}
		CalendarEvent fEvent = null;

		Calendar fCalendar = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fEvent.Name = NameBox.Text;
			fEvent.DayIndex = (int)DayBox.Value - 1;

			MonthInfo mi = MonthBox.SelectedItem as MonthInfo;
			fEvent.MonthID = mi.ID;
		}

		private void MonthBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			MonthInfo mi = MonthBox.SelectedItem as MonthInfo;
			DayBox.Maximum = mi.DayCount;
		}
	}
}
