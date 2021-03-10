using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class DateForm : Form
	{
		public DateForm(CalendarDate date)
		{
			InitializeComponent();

			// Populate calendar box
			foreach (Calendar c in Session.Project.Calendars)
				CalendarBox.Items.Add(c);

			fDate = date.Copy();

			Calendar cal = Session.Project.FindCalendar(fDate.CalendarID);
			if (cal != null)
			{
				CalendarBox.SelectedItem = cal;
			}
			else
			{
				CalendarBox.SelectedIndex = 0;
			}

			YearBox.Value = fDate.Year;

			MonthInfo month = SelectedCalendar.FindMonth(fDate.MonthID);
			if (month != null)
			{
				MonthBox.SelectedItem = month;
			}
			else
			{
				MonthBox.SelectedIndex = 0;
			}

			DayBox.Value = fDate.DayIndex + 1;
		}

		public CalendarDate Date
		{
			get { return fDate; }
		}
		CalendarDate fDate = null;

		public Calendar SelectedCalendar
		{
			get { return CalendarBox.SelectedItem as Calendar; }
		}

		public MonthInfo SelectedMonth
		{
			get { return MonthBox.SelectedItem as MonthInfo; }
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
			Calendar cal = CalendarBox.SelectedItem as Calendar;
			MonthInfo month = MonthBox.SelectedItem as MonthInfo;

			fDate.CalendarID = cal.ID;
			fDate.Year = (int)YearBox.Value;
			fDate.MonthID = month.ID;
			fDate.DayIndex = (int)DayBox.Value - 1;
		}

		private void CalendarBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			MonthBox.Items.Clear();
			foreach (MonthInfo month in SelectedCalendar.Months)
				MonthBox.Items.Add(month);

			YearBox.Value = SelectedCalendar.CampaignYear;
			MonthBox.SelectedIndex = 0;
		}

		private void YearBox_ValueChanged(object sender, EventArgs e)
		{
			set_days();
		}

		private void MonthBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			set_days();
		}

		void set_days()
		{
			if (SelectedMonth == null)
				return;

			// How many days in this month?
			int days = SelectedMonth.DayCount;

			int year = (int)YearBox.Value;
			if (year % SelectedMonth.LeapPeriod == 0)
				days += SelectedMonth.LeapModifier;

			DayBox.Maximum = days;
		}
	}
}
