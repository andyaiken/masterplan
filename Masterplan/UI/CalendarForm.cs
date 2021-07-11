using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class CalendarForm : Form
	{
		#region EventSorter

		class EventSorter : IComparer
		{
			public EventSorter(Calendar c)
			{
				fCalendar = c;
			}

			Calendar fCalendar = null;

			public int Compare(object x, object y)
			{
				ListViewItem lvi_x = x as ListViewItem;
				ListViewItem lvi_y = y as ListViewItem;

				CalendarEvent ce_x = lvi_x.Tag as CalendarEvent;
				CalendarEvent ce_y = lvi_y.Tag as CalendarEvent;

				if ((ce_x == null) || (ce_y == null))
					return 0;

				MonthInfo mi_x = fCalendar.FindMonth(ce_x.MonthID);
				MonthInfo mi_y = fCalendar.FindMonth(ce_y.MonthID);

				int month_x = fCalendar.Months.IndexOf(mi_x);
				int month_y = fCalendar.Months.IndexOf(mi_y);

				int result = month_x.CompareTo(month_y);
				if (result == 0)
				{
					result = ce_x.DayIndex.CompareTo(ce_y.DayIndex);
				}

				return result;
			}
		}

		#endregion

		public CalendarForm(Calendar calendar)
		{
			InitializeComponent();

			fCalendar = calendar.Copy();

			Application.Idle += new EventHandler(Application_Idle);
			EventList.ListViewItemSorter = new EventSorter(fCalendar);
			SeasonList.ListViewItemSorter = new EventSorter(fCalendar);

			NameBox.Text = fCalendar.Name;
			YearBox.Value = fCalendar.CampaignYear;
			DetailsBox.Text = fCalendar.Details;

			update_months();
			update_days();
			update_seasons();
			update_events();
			update_satellites();
		}

		~CalendarForm()
		{
			Application.Idle -= Application_Idle;
		}

		#region Properties

		public Calendar Calendar
		{
			get { return fCalendar; }
		}
		Calendar fCalendar = null;

		public MonthInfo SelectedMonth
		{
			get
			{
				if (MonthList.SelectedItems.Count != 0)
					return MonthList.SelectedItems[0].Tag as MonthInfo;

				return null;
			}
		}

		public DayInfo SelectedDay
		{
			get
			{
				if (DayList.SelectedItems.Count != 0)
					return DayList.SelectedItems[0].Tag as DayInfo;

				return null;
			}
		}

		#endregion

		void Application_Idle(object sender, EventArgs e)
		{
			MonthRemoveBtn.Enabled = (SelectedMonth != null);
			MonthEditBtn.Enabled = (SelectedMonth != null);
			MonthUpBtn.Enabled = ((SelectedMonth != null) && (fCalendar.Months.IndexOf(SelectedMonth) != 0));
			MonthDownBtn.Enabled = ((SelectedMonth != null) && (fCalendar.Months.IndexOf(SelectedMonth) != fCalendar.Months.Count - 1));

			DayRemoveBtn.Enabled = (SelectedDay != null);
			DayEditBtn.Enabled = (SelectedDay != null);
			DayUpBtn.Enabled = ((SelectedDay != null) && (fCalendar.Days.IndexOf(SelectedDay) != 0));
			DayDownBtn.Enabled = ((SelectedDay != null) && (fCalendar.Days.IndexOf(SelectedDay) != fCalendar.Days.Count - 1));

			SeasonAddBtn.Enabled = (fCalendar.Months.Count != 0);
			SeasonRemoveBtn.Enabled = (SelectedSeason != null);
			SeasonEditBtn.Enabled = (SelectedSeason != null);

			EventAddBtn.Enabled = (fCalendar.Months.Count != 0);
			EventRemoveBtn.Enabled = (SelectedEvent != null);
			EventEditBtn.Enabled = (SelectedEvent != null);

			SatelliteRemoveBtn.Enabled = (SelectedSatellite != null);
			SatelliteEditBtn.Enabled = (SelectedSatellite != null);

			OKBtn.Enabled = ((fCalendar.Months.Count != 0) && (fCalendar.Days.Count != 0));
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fCalendar.Name = NameBox.Text;
			fCalendar.CampaignYear = (int)YearBox.Value;
			fCalendar.Details = DetailsBox.Text;
		}

		#region Months

		private void MonthAddBtn_Click(object sender, EventArgs e)
		{
			MonthInfo mi = new MonthInfo();
			mi.Name = "New Month";

			MonthForm dlg = new MonthForm(mi);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fCalendar.Months.Add(dlg.MonthInfo);

				update_months();
				update_seasons();
				update_events();
			}
		}

		private void MonthRemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedMonth != null)
			{
				fCalendar.Months.Remove(SelectedMonth);

				update_months();
				update_seasons();
				update_events();
			}
		}

		private void MonthEditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedMonth != null)
			{
				int index = fCalendar.Months.IndexOf(SelectedMonth);

				MonthForm dlg = new MonthForm(SelectedMonth);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fCalendar.Months[index] = dlg.MonthInfo;

					update_months();
					update_seasons();
					update_events();
				}
			}
		}

		private void MonthUpBtn_Click(object sender, EventArgs e)
		{
			if (SelectedMonth != null)
			{
				int index = fCalendar.Months.IndexOf(SelectedMonth);
				if (index == 0)
					return;

				MonthInfo tmp = fCalendar.Months[index - 1];
				fCalendar.Months[index - 1] = SelectedMonth;
				fCalendar.Months[index] = tmp;

				update_months();
				update_seasons();
				update_events();

				MonthList.Items[index - 1].Selected = true;
			}
		}

		private void MonthDownBtn_Click(object sender, EventArgs e)
		{
			if (SelectedMonth != null)
			{
				int index = fCalendar.Months.IndexOf(SelectedMonth);
				if (index == fCalendar.Months.Count - 1)
					return;

				MonthInfo tmp = fCalendar.Months[index + 1];
				fCalendar.Months[index + 1] = SelectedMonth;
				fCalendar.Months[index] = tmp;

				update_months();
				update_seasons();
				update_events();

				MonthList.Items[index + 1].Selected = true;
			}
		}

		void update_months()
		{
			MonthList.Items.Clear();

			foreach (MonthInfo mi in fCalendar.Months)
			{
				string days = mi.DayCount.ToString();
				if ((mi.LeapModifier != 0) && (mi.LeapPeriod != 0))
				{
					int count = mi.DayCount + mi.LeapModifier;
					days += " / " + count.ToString();
				}

				ListViewItem lvi = MonthList.Items.Add(mi.Name);
				lvi.SubItems.Add(days);
				lvi.Tag = mi;
			}

			if (MonthList.Items.Count == 0)
			{
				ListViewItem lvi = MonthList.Items.Add("(no months)");
				lvi.ForeColor = SystemColors.GrayText;
			}
		}

		#endregion

		#region Days

		private void DayAddBtn_Click(object sender, EventArgs e)
		{
			DayInfo di = new DayInfo();
			di.Name = "New Day";

			DayForm dlg = new DayForm(di);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fCalendar.Days.Add(dlg.DayInfo);
				update_days();
			}
		}

		private void DayRemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedDay != null)
			{
				fCalendar.Days.Remove(SelectedDay);
				update_days();
			}
		}

		private void DayEditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedDay != null)
			{
				int index = fCalendar.Days.IndexOf(SelectedDay);

				DayForm dlg = new DayForm(SelectedDay);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fCalendar.Days[index] = dlg.DayInfo;
					update_days();
				}
			}
		}

		private void DayUpBtn_Click(object sender, EventArgs e)
		{
			if (SelectedDay != null)
			{
				int index = fCalendar.Days.IndexOf(SelectedDay);
				if (index == 0)
					return;

				DayInfo tmp = fCalendar.Days[index - 1];
				fCalendar.Days[index - 1] = SelectedDay;
				fCalendar.Days[index] = tmp;

				update_days();

				DayList.Items[index - 1].Selected = true;
			}
		}

		private void DayDownBtn_Click(object sender, EventArgs e)
		{
			if (SelectedDay != null)
			{
				int index = fCalendar.Days.IndexOf(SelectedDay);
				if (index == fCalendar.Days.Count - 1)
					return;

				DayInfo tmp = fCalendar.Days[index + 1];
				fCalendar.Days[index + 1] = SelectedDay;
				fCalendar.Days[index] = tmp;

				update_days();

				DayList.Items[index + 1].Selected = true;
			}
		}

		void update_days()
		{
			DayList.Items.Clear();

			foreach (DayInfo di in fCalendar.Days)
			{
				ListViewItem lvi = DayList.Items.Add(di.Name);
				lvi.Tag = di;
			}

			if (DayList.Items.Count == 0)
			{
				ListViewItem lvi = DayList.Items.Add("(no days)");
				lvi.ForeColor = SystemColors.GrayText;
			}
		}

		#endregion

		#region Seasons

		public CalendarEvent SelectedSeason
		{
			get
			{
				if (SeasonList.SelectedItems.Count != 0)
					return SeasonList.SelectedItems[0].Tag as CalendarEvent;

				return null;
			}
		}

		private void SeasonAddBtn_Click(object sender, EventArgs e)
		{
			CalendarEvent ce = new CalendarEvent();
			ce.Name = "New Season";
			ce.MonthID = fCalendar.Months[0].ID;

			SeasonForm dlg = new SeasonForm(ce, fCalendar);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fCalendar.Seasons.Add(dlg.Season);
				update_seasons();
			}
		}

		private void SeasonRemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedSeason != null)
			{
				fCalendar.Seasons.Remove(SelectedSeason);
				update_seasons();
			}
		}

		private void SeasonEditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedSeason != null)
			{
				int index = fCalendar.Seasons.IndexOf(SelectedSeason);

				SeasonForm dlg = new SeasonForm(SelectedSeason, fCalendar);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fCalendar.Seasons[index] = dlg.Season;
					update_seasons();
				}
			}
		}

		void update_seasons()
		{
			SeasonList.Items.Clear();

			foreach (CalendarEvent ce in fCalendar.Seasons)
			{
				MonthInfo mi = fCalendar.FindMonth(ce.MonthID);
				int day = ce.DayIndex + 1;

				ListViewItem lvi = SeasonList.Items.Add(ce.Name);
				lvi.SubItems.Add(mi.Name + " " + day);
				lvi.Tag = ce;
			}

			if (SeasonList.Items.Count == 0)
			{
				ListViewItem lvi = SeasonList.Items.Add("(no seasons)");
				lvi.ForeColor = SystemColors.GrayText;
			}

			SeasonList.Sort();
		}

		#endregion

		#region Events

		public CalendarEvent SelectedEvent
		{
			get
			{
				if (EventList.SelectedItems.Count != 0)
					return EventList.SelectedItems[0].Tag as CalendarEvent;

				return null;
			}
		}

		private void EventAddBtn_Click(object sender, EventArgs e)
		{
			CalendarEvent ce = new CalendarEvent();
			ce.Name = "New Event";
			ce.MonthID = fCalendar.Months[0].ID;

			CalendarEventForm dlg = new CalendarEventForm(ce, fCalendar);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fCalendar.Events.Add(dlg.Event);
				update_events();
			}
		}

		private void EventRemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedEvent != null)
			{
				fCalendar.Events.Remove(SelectedEvent);
				update_events();
			}
		}

		private void EventEditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedEvent != null)
			{
				int index = fCalendar.Events.IndexOf(SelectedEvent);

				CalendarEventForm dlg = new CalendarEventForm(SelectedEvent, fCalendar);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fCalendar.Events[index] = dlg.Event;
					update_events();
				}
			}
		}

		void update_events()
		{
			EventList.Items.Clear();

			foreach (CalendarEvent ce in fCalendar.Events)
			{
				MonthInfo mi = fCalendar.FindMonth(ce.MonthID);
				int day = ce.DayIndex + 1;

				ListViewItem lvi = EventList.Items.Add(ce.Name);
				lvi.SubItems.Add(mi.Name + " " + day);
				lvi.Tag = ce;
			}

			if (EventList.Items.Count == 0)
			{
				ListViewItem lvi = EventList.Items.Add("(no events)");
				lvi.ForeColor = SystemColors.GrayText;
			}

			EventList.Sort();
		}

		#endregion

		#region Satellites

		public Satellite SelectedSatellite
		{
			get
			{
				if (SatelliteList.SelectedItems.Count != 0)
					return SatelliteList.SelectedItems[0].Tag as Satellite;

				return null;
			}
		}

		private void SatelliteAddBtn_Click(object sender, EventArgs e)
		{
			Satellite s = new Satellite();
			s.Name = "New Satellite";

			SatelliteForm dlg = new SatelliteForm(s);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fCalendar.Satellites.Add(dlg.Satellite);
				update_satellites();
			}
		}

		private void SatelliteRemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedSatellite != null)
			{
				fCalendar.Satellites.Remove(SelectedSatellite);
				update_satellites();
			}
		}

		private void SatelliteEditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedSatellite != null)
			{
				int index = fCalendar.Satellites.IndexOf(SelectedSatellite);

				SatelliteForm dlg = new SatelliteForm(SelectedSatellite);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fCalendar.Satellites[index] = dlg.Satellite;
					update_satellites();
				}
			}
		}

		void update_satellites()
		{
			SatelliteList.Items.Clear();

			foreach (Satellite s in fCalendar.Satellites)
			{
				ListViewItem lvi = SatelliteList.Items.Add(s.Name);
				lvi.Tag = s;
			}

			if (SatelliteList.Items.Count == 0)
			{
				ListViewItem lvi = SatelliteList.Items.Add("(no satellites)");
				lvi.ForeColor = SystemColors.GrayText;
			}
		}

		#endregion
	}
}
