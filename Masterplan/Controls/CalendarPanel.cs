using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.Controls
{
	/// <summary>
	/// Panel for displaying a Calendar object.
	/// </summary>
	public partial class CalendarPanel : UserControl
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public CalendarPanel()
		{
			InitializeComponent();

			SetStyle(ControlStyles.AllPaintingInWmPaint
				| ControlStyles.OptimizedDoubleBuffer
				| ControlStyles.ResizeRedraw
				| ControlStyles.UserPaint, true);

			fCentred.Alignment = StringAlignment.Center;
			fCentred.LineAlignment = StringAlignment.Center;
			fCentred.Trimming = StringTrimming.EllipsisWord;

			fTopRight.Alignment = StringAlignment.Far;
			fTopRight.LineAlignment = StringAlignment.Near;
			fTopRight.Trimming = StringTrimming.EllipsisWord;
		}

		#region Properties

		/// <summary>
		/// Gets or sets the calendar to display.
		/// </summary>
		[Category("Data"), Description("The calendar to display.")]
		public Calendar Calendar
		{
			get { return fCalendar; }
			set
			{
				fCalendar = value;
				Invalidate();
			}
		}
		Calendar fCalendar = null;

		/// <summary>
		/// Gets or sets the year to be displayed.
		/// </summary>
		[Category("Data"), Description("The year to be displayed.")]
		public int Year
		{
			get { return fYear; }
			set
			{
				fYear = value;
				Invalidate();
			}
		}
		int fYear = 0;

		/// <summary>
		/// Gets or sets the 0-based index of the month to be displayed.
		/// </summary>
		[Category("Data"), Description("The 0-based index of the month to be displayed.")]
		public int MonthIndex
		{
			get { return fMonthIndex; }
			set
			{
				fMonthIndex = value;
				Invalidate();
			}
		}
		int fMonthIndex = 0;

		StringFormat fCentred = new StringFormat();
		StringFormat fTopRight = new StringFormat();
		int fWeeks = 0;
		int fDayOffset = 0;

		#endregion

		#region Painting

		/// <summary>
		/// Called in response to the Paint event.
		/// </summary>
		/// <param name="e">The event data.</param>
		protected override void OnPaint(PaintEventArgs e)
		{
			Brush b = new LinearGradientBrush(ClientRectangle, Color.FromArgb(225, 225, 225), Color.FromArgb(180, 180, 180), LinearGradientMode.Vertical);
			e.Graphics.FillRectangle(b, ClientRectangle);

			if (fCalendar == null)
			{
				e.Graphics.DrawString("(no calendar)", Font, SystemBrushes.WindowText, ClientRectangle, fCentred);
				return;
			}

			analyse_month();

			#region Day headers

			Font header = new Font(Font, FontStyle.Bold);

			for (int day = 0; day != fCalendar.Days.Count; ++day )
			{
				DayInfo di = fCalendar.Days[day];

				// Draw col header cell
				RectangleF colhdr = get_rect(day, -1);
				e.Graphics.DrawString(di.Name, header, SystemBrushes.WindowText, colhdr, fCentred);
			}

			#endregion

			#region Days

			MonthInfo mi = fCalendar.Months[fMonthIndex];
			int days = mi.DayCount;
			if ((mi.LeapModifier != 0) && (mi.LeapPeriod != 0))
			{
				if (fYear % mi.LeapPeriod == 0)
					days += mi.LeapModifier;
			}

			Dictionary<int, List<PlotPoint>> plot_points = new Dictionary<int, List<PlotPoint>>();
			foreach (PlotPoint pp in Session.Project.AllPlotPoints)
			{
				if (pp.Date == null)
					continue;

				if ((pp.Date.CalendarID != fCalendar.ID) || (pp.Date.MonthID != mi.ID) || (pp.Date.Year != fYear))
					continue;

				if (!plot_points.ContainsKey(pp.Date.DayIndex))
					plot_points[pp.Date.DayIndex] = new List<PlotPoint>();

				plot_points[pp.Date.DayIndex].Add(pp);
			}

			for (int day_index = 0; day_index != days; ++day_index)
			{
				int day = day_index + 1;
				int count = get_days_so_far() + day_index;
				string str = "";
				string moons = "";

				foreach (Satellite sat in fCalendar.Satellites)
				{
					if (sat.Period == 0)
						continue;

					int phase = (count - sat.Offset) % sat.Period;
					if (phase < 0)
						phase += sat.Period;

					if (phase == 0)
					{
						// New moon
						moons += "●";
					}

					if (phase == (sat.Period / 2))
					{
						// Full moon
						moons += "○";
					}
				}

				foreach (CalendarEvent ce in fCalendar.Seasons)
				{
					if ((ce.MonthID == mi.ID) && (ce.DayIndex == day_index))
					{
						if (str != "")
							str += Environment.NewLine;

						str += "Start of " + ce.Name;
					}
				}

				foreach (CalendarEvent ce in fCalendar.Events)
				{
					if ((ce.MonthID == mi.ID) && (ce.DayIndex == day_index))
					{
						if (str != "")
							str += Environment.NewLine;

						str += ce.Name;
					}
				}

				if (plot_points.ContainsKey(day_index))
				{
					foreach (PlotPoint pp in plot_points[day_index])
					{
						if (str != "")
							str += Environment.NewLine;

						str += pp.Name;
					}
				}

				RectangleF rect = get_rect(day_index);
				e.Graphics.FillRectangle(SystemBrushes.Window, rect);

				RectangleF day_rect = new RectangleF(rect.X, rect.Y, 25, 20);
				e.Graphics.DrawString(day.ToString(), Font, SystemBrushes.WindowText, day_rect, fCentred);
				e.Graphics.DrawRectangle(Pens.Gray, day_rect.X, day_rect.Y, day_rect.Width, day_rect.Height);

				if (moons != "")
					e.Graphics.DrawString(moons, Font, SystemBrushes.WindowText, rect, fTopRight);

				if (str != "")
				{
					RectangleF info_rect = new RectangleF(rect.X, day_rect.Bottom, rect.Width, rect.Bottom - day_rect.Bottom);
					e.Graphics.DrawString(str, Font, SystemBrushes.WindowText, info_rect, fCentred);
				}

				e.Graphics.DrawRectangle(SystemPens.ControlDark, rect.X, rect.Y, rect.Width, rect.Height);
			}

			#endregion
		}

		#endregion

		void analyse_month()
		{
			fWeeks = 0;
			fDayOffset = 0;

			if (fCalendar == null)
				return;

			int days_so_far = get_days_so_far();
			fDayOffset = days_so_far % fCalendar.Days.Count;
			if (fDayOffset < 0)
				fDayOffset += fCalendar.Days.Count;

			// Count the days in the month
			MonthInfo mi = fCalendar.Months[fMonthIndex];
			int days = mi.DayCount + fDayOffset;
			if ((mi.LeapModifier != 0) && (mi.LeapPeriod != 0))
			{
				if (fYear % mi.LeapPeriod == 0)
					days += mi.LeapModifier;
			}

			// How many weeks are in this month?
			fWeeks = days / fCalendar.Days.Count;
			int left_over = days % fCalendar.Days.Count;
			if (left_over != 0)
				fWeeks += 1;
		}

		int get_days_so_far()
		{
			int days_so_far = 0;

			// Account for intervening years
			int min = Math.Min(fYear, fCalendar.CampaignYear);
			int max = Math.Max(fYear, fCalendar.CampaignYear);
			for (int year = min; year != max; ++year)
			{
				days_so_far += fCalendar.DayCount(year);
			}
			if (fYear < fCalendar.CampaignYear)
				days_so_far = -days_so_far;

			// Add days of months so far
			for (int month_index = 0; month_index != fMonthIndex; ++month_index)
			{
				MonthInfo month = fCalendar.Months[month_index];
				days_so_far += month.DayCount;
			}

			return days_so_far;
		}

		RectangleF get_rect(int day_index)
		{
			// What day of the week is this?
			int cell_index = fDayOffset + day_index;
			int day = cell_index % fCalendar.Days.Count;

			// What week of the month is this?
			int week = cell_index / fCalendar.Days.Count;

			return get_rect(day, week);
		}

		RectangleF get_rect(int day, int week)
		{
			float top_line_height = 25;

			float width = (float)ClientRectangle.Width / fCalendar.Days.Count;
			float height = (float)(ClientRectangle.Height - top_line_height) / fWeeks;

			if (week == -1)
				return new RectangleF(day * width, 0, width, top_line_height);
			else
				return new RectangleF(day * width, (week * height) + top_line_height, width, height);
		}
	}
}
