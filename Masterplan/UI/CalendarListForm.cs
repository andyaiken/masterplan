using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class CalendarListForm : Form
	{
		public CalendarListForm()
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			update_calendars();
			update_calendar_panel();
		}

		~CalendarListForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			RemoveBtn.Enabled = (SelectedCalendar != null);
			EditBtn.Enabled = (SelectedCalendar != null);
			ExportBtn.Enabled = (SelectedCalendar != null);
			PlayerViewBtn.Enabled = (SelectedCalendar != null);
		}

		public Calendar SelectedCalendar
		{
			get
			{
				if (CalendarList.SelectedItems.Count != 0)
					return CalendarList.SelectedItems[0].Tag as Calendar;

				return null;
			}
		}

		#region Toolbar

		private void AddBtn_Click(object sender, EventArgs e)
		{
			Calendar c = new Calendar();
			c.Name = "New Calendar";

			CalendarForm dlg = new CalendarForm(c);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Session.Project.Calendars.Add(dlg.Calendar);
				Session.Modified = true;

				update_calendars();
				update_calendar_panel();
			}
		}

		private void RemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedCalendar != null)
			{
				string msg = "Are you sure you want to delete this calendar?";
				DialogResult dr = MessageBox.Show(msg, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dr == DialogResult.No)
					return;

				Session.Project.Calendars.Remove(SelectedCalendar);
				Session.Modified = true;

				update_calendars();
				update_calendar_panel();
			}
		}

		private void EditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedCalendar != null)
			{
				int index = Session.Project.Calendars.IndexOf(SelectedCalendar);

				CalendarForm dlg = new CalendarForm(SelectedCalendar);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					Session.Project.Calendars[index] = dlg.Calendar;
					Session.Modified = true;

					update_calendars();
					update_calendar_panel();
				}
			}
		}

		#endregion

		private void ExportBtn_Click(object sender, EventArgs e)
		{
			if (SelectedCalendar != null)
			{
				SaveFileDialog dlg = new SaveFileDialog();
				dlg.FileName = SelectedCalendar.Name;
				dlg.Filter = "Bitmap Image |*.bmp|JPEG Image|*.jpg|GIF Image|*.gif|PNG Image|*.png";
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					ImageFormat format = ImageFormat.Bmp;
					switch (dlg.FilterIndex)
					{
						case 1:
							format = ImageFormat.Bmp;
							break;
						case 2:
							format = ImageFormat.Jpeg;
							break;
						case 3:
							format = ImageFormat.Gif;
							break;
						case 4:
							format = ImageFormat.Png;
							break;
					}

					Bitmap bmp = Screenshot.Calendar(CalendarPnl.Calendar, CalendarPnl.MonthIndex, CalendarPnl.Year, new Size(800, 600));
					bmp.Save(dlg.FileName, format);
				}
			}
		}

		private void PlayerViewBtn_Click(object sender, EventArgs e)
		{
			if (SelectedCalendar != null)
			{
				if (Session.PlayerView == null)
					Session.PlayerView = new PlayerViewForm(this);

				Session.PlayerView.ShowCalendar(CalendarPnl.Calendar, CalendarPnl.MonthIndex, CalendarPnl.Year);
			}
		}

		private void CalendarList_SelectedIndexChanged(object sender, EventArgs e)
		{
			update_calendar_panel();
		}

		private void MonthBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			MonthInfo mi = MonthBox.SelectedItem as MonthInfo;
			int index = CalendarPnl.Calendar.Months.IndexOf(mi);
			CalendarPnl.MonthIndex = index;
		}

		private void YearBox_TextChanged(object sender, EventArgs e)
		{
			try
			{
				int year = int.Parse(YearBox.Text);
				CalendarPnl.Year = year;
			}
			catch
			{
				YearBox.Text = CalendarPnl.Year.ToString();
			}
		}

		#region Calendar toolbar

		private void MonthPrevBtn_Click(object sender, EventArgs e)
		{
			CalendarPnl.MonthIndex -= 1;
			if (CalendarPnl.MonthIndex == -1)
			{
				CalendarPnl.MonthIndex = CalendarPnl.Calendar.Months.Count - 1;
				CalendarPnl.Year -= 1;
			}

			update_calendar_panel();
		}

		private void MonthNextBtn_Click(object sender, EventArgs e)
		{
			CalendarPnl.MonthIndex += 1;
			if (CalendarPnl.MonthIndex == CalendarPnl.Calendar.Months.Count)
			{
				CalendarPnl.MonthIndex = 0;
				CalendarPnl.Year += 1;
			}

			update_calendar_panel();
		}

		private void YearPrevBtn_Click(object sender, EventArgs e)
		{
			CalendarPnl.Year -= 1;
			update_calendar_panel();
		}

		private void YearNextBtn_Click(object sender, EventArgs e)
		{
			CalendarPnl.Year += 1;
			update_calendar_panel();
		}

		#endregion

		void update_calendars()
		{
			CalendarList.Items.Clear();

			foreach (Calendar c in Session.Project.Calendars)
			{
				ListViewItem lvi = CalendarList.Items.Add(c.Name);
				lvi.SubItems.Add(c.Months.Count.ToString());
				lvi.SubItems.Add(c.DayCount(c.CampaignYear).ToString());
				lvi.Tag = c;
			}

			if (CalendarList.Items.Count == 0)
			{
				ListViewItem lvi = CalendarList.Items.Add("(no calendars)");
				lvi.ForeColor = SystemColors.GrayText;
			}
		}

		void update_calendar_panel()
		{
			NavigationToolbar.Visible = (SelectedCalendar != null);

			if (CalendarPnl.Calendar != SelectedCalendar)
			{
				CalendarPnl.Calendar = SelectedCalendar;
				if (CalendarPnl.Calendar != null)
				{
					CalendarPnl.Year = SelectedCalendar.CampaignYear;
					CalendarPnl.MonthIndex = 0;
				}

				CalendarPnl.Invalidate();
			}

			MonthBox.Items.Clear();

			if (CalendarPnl.Calendar != null)
			{
				foreach (MonthInfo mi in CalendarPnl.Calendar.Months)
					MonthBox.Items.Add(mi);

				MonthInfo current_month = CalendarPnl.Calendar.Months[CalendarPnl.MonthIndex];

				MonthBox.SelectedItem = current_month;
				YearBox.Text = CalendarPnl.Year.ToString();
			}
			else
			{
				MonthBox.Text = "";
				YearBox.Text = "";
			}
		}
	}
}
