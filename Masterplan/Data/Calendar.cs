using System;
using System.Collections.Generic;

namespace Masterplan.Data
{
	/// <summary>
	/// Class representing a custom calendar.
	/// </summary>
	[Serializable]
	public class Calendar
	{
		/// <summary>
		/// Gets or sets the unique ID of the calendar.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the calendar name.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the calendar details.
		/// </summary>
		public string Details
		{
			get { return fDetails; }
			set { fDetails = value; }
		}
		string fDetails = "";

		/// <summary>
		/// Gets or sets the current year for the calendar.
		/// </summary>
		public int CampaignYear
		{
			get { return fCampaignYear; }
			set { fCampaignYear = value; }
		}
		int fCampaignYear = 1000;

		/// <summary>
		/// Gets or sets the list of months.
		/// </summary>
		public List<MonthInfo> Months
		{
			get { return fMonths; }
			set { fMonths = value; }
		}
		List<MonthInfo> fMonths = new List<MonthInfo>();

		/// <summary>
		/// Gets or sets the list of days.
		/// </summary>
		public List<DayInfo> Days
		{
			get { return fDays; }
			set { fDays = value; }
		}
		List<DayInfo> fDays = new List<DayInfo>();

		/// <summary>
		/// Gets or sets the list of seasons.
		/// </summary>
		public List<CalendarEvent> Seasons
		{
			get { return fSeasons; }
			set { fSeasons = value; }
		}
		List<CalendarEvent> fSeasons = new List<CalendarEvent>();

		/// <summary>
		/// Gets or sets the list of events.
		/// </summary>
		public List<CalendarEvent> Events
		{
			get { return fEvents; }
			set { fEvents = value; }
		}
		List<CalendarEvent> fEvents = new List<CalendarEvent>();

		/// <summary>
		/// Gets or sets the list of satellites.
		/// </summary>
		public List<Satellite> Satellites
		{
			get { return fSatellites; }
			set { fSatellites = value; }
		}
		List<Satellite> fSatellites = new List<Satellite>();

		/// <summary>
		/// Calculate the number of days in a year.
		/// </summary>
		/// <param name="year">The year.</param>
		/// <returns>Returns the number of days in the year.</returns>
		public int DayCount(int year)
		{
			int days = 0;

			foreach (MonthInfo mi in fMonths)
			{
				days += mi.DayCount;

				if ((mi.LeapModifier != 0) && (mi.LeapPeriod != 0))
				{
					if (year % mi.LeapPeriod == 0)
						days += mi.LeapModifier;
				}
			}

			return days;
		}

		/// <summary>
		/// Finds the month with the given ID.
		/// </summary>
		/// <param name="month_id">The ID of the month.</param>
		/// <returns>Returns the month if it exists; null otherwise.</returns>
		public MonthInfo FindMonth(Guid month_id)
		{
			foreach (MonthInfo mi in fMonths)
			{
				if (mi.ID == month_id)
					return mi;
			}

			return null;
		}

		/// <summary>
		/// Returns the calendar name.
		/// </summary>
		/// <returns>Returns the calendar name.</returns>
		public override string ToString()
		{
			return fName;
		}

		/// <summary>
		/// Creates a copy of the calendar.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public Calendar Copy()
		{
			Calendar c = new Calendar();

			c.ID = fID;
			c.Name = fName;
			c.Details = fDetails;
			c.CampaignYear = fCampaignYear;

			foreach (MonthInfo mi in fMonths)
				c.Months.Add(mi.Copy());

			foreach (DayInfo di in fDays)
				c.Days.Add(di.Copy());

			foreach (CalendarEvent ce in fSeasons)
				c.Seasons.Add(ce.Copy());

			foreach (CalendarEvent ce in fEvents)
				c.Events.Add(ce.Copy());

			foreach (Satellite s in fSatellites)
				c.Satellites.Add(s.Copy());

			return c;
		}
	}

	/// <summary>
	/// Class representing a month in a custom calendar.
	/// </summary>
	[Serializable]
	public class MonthInfo
	{
		/// <summary>
		/// Gets or sets the unique ID of the month.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the name of the month.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the number of days in the month.
		/// </summary>
		public int DayCount
		{
			get { return fDayCount; }
			set { fDayCount = value; }
		}
		int fDayCount = 30;

		/// <summary>
		/// Gets or sets the change to the number of days in a leap year.
		/// </summary>
		public int LeapModifier
		{
			get { return fModifier; }
			set { fModifier = value; }
		}
		int fModifier = 0;

		/// <summary>
		/// Gets or sets the frequency of leap years.
		/// </summary>
		public int LeapPeriod
		{
			get { return fPeriod; }
			set { fPeriod = value; }
		}
		int fPeriod = 4;

		/// <summary>
		/// Creates a copy of the MonthInfo.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public MonthInfo Copy()
		{
			MonthInfo mi = new MonthInfo();

			mi.ID = fID;
			mi.Name = fName;
			mi.DayCount = fDayCount;
			mi.LeapModifier = fModifier;
			mi.LeapPeriod = fPeriod;

			return mi;
		}

		/// <summary>
		/// Returns the month name.
		/// </summary>
		/// <returns>Returns the month name.</returns>
		public override string ToString()
		{
			return fName;
		}
	}

	/// <summary>
	/// Class representing a day in a custom calendar.
	/// </summary>
	[Serializable]
	public class DayInfo
	{
		/// <summary>
		/// Gets or sets the unique ID of the day.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the day name.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Creates a copy of the DayInfo.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public DayInfo Copy()
		{
			DayInfo di = new DayInfo();

			di.ID = fID;
			di.Name = fName;

			return di;
		}
	}

	/// <summary>
	/// Class representing a yearly event in a custom calendar.
	/// </summary>
	[Serializable]
	public class CalendarEvent
	{
		/// <summary>
		/// Gets or sets the unique ID of the event.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the name of the event.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the ID of the month the event occurs in.
		/// </summary>
		public Guid MonthID
		{
			get { return fMonthID; }
			set { fMonthID = value; }
		}
		Guid fMonthID = Guid.Empty;

		/// <summary>
		/// Gets or sets the day on which the event occurs.
		/// </summary>
		public int DayIndex
		{
			get { return fDayIndex; }
			set { fDayIndex = value; }
		}
		int fDayIndex = 1;

		/// <summary>
		/// Creates a copy of the event.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public CalendarEvent Copy()
		{
			CalendarEvent ce = new CalendarEvent();

			ce.ID = fID;
			ce.Name = fName;
			ce.MonthID = fMonthID;
			ce.DayIndex = fDayIndex;

			return ce;
		}
	}

	/// <summary>
	/// Class representing a satellite (moon etc) in a custom calendar.
	/// </summary>
	[Serializable]
	public class Satellite
	{
		/// <summary>
		/// Gets or sets the unique ID of the satellite.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the name of the satellite.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the number of days the satellite takes for a full rotation.
		/// </summary>
		public int Period
		{
			get { return fPeriod; }
			set { fPeriod = value; }
		}
		int fPeriod = 1;

		/// <summary>
		/// Gets or sets the offset for the satellite.
		/// </summary>
		public int Offset
		{
			get { return fOffset; }
			set { fOffset = value; }
		}
		int fOffset = 0;

		/// <summary>
		/// Creates a copy of the satellite.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public Satellite Copy()
		{
			Satellite s = new Satellite();

			s.ID = fID;
			s.Name = fName;
			s.Period = fPeriod;
			s.Offset = fOffset;

			return s;
		}
	}

	/// <summary>
	/// Class representing a specific date in a custom calendar.
	/// </summary>
	[Serializable]
	public class CalendarDate
	{
		/// <summary>
		/// Gets or sets the unique ID of the date.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the ID of the calendar to use.
		/// </summary>
		public Guid CalendarID
		{
			get { return fCalendarID; }
			set { fCalendarID = value; }
		}
		Guid fCalendarID = Guid.Empty;

		/// <summary>
		/// Gets or sets the calendar year.
		/// </summary>
		public int Year
		{
			get { return fYear; }
			set { fYear = value; }
		}
		int fYear = 0;

		/// <summary>
		/// Gets or sets the ID of the month.
		/// </summary>
		public Guid MonthID
		{
			get { return fMonthID; }
			set { fMonthID = value; }
		}
		Guid fMonthID = Guid.Empty;

		/// <summary>
		/// Gets or sets the 0-based index of the day.
		/// </summary>
		public int DayIndex
		{
			get { return fDayIndex; }
			set { fDayIndex = value; }
		}
		int fDayIndex = 0;

		/// <summary>
		/// Month N, Year
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			Calendar cal = Session.Project.FindCalendar(fCalendarID);
			if (cal == null)
				return "";

			MonthInfo month = cal.FindMonth(fMonthID);
			if (month == null)
				return "";

			int day = fDayIndex + 1;

			return month.Name + " " + day + ", " + fYear;
		}

		/// <summary>
		/// Creates a copy of the date.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public CalendarDate Copy()
		{
			CalendarDate cd = new CalendarDate();

			cd.ID = fID;
			cd.Year = fYear;
			cd.CalendarID = fCalendarID;
			cd.MonthID = fMonthID;
			cd.DayIndex = fDayIndex;

			return cd;
		}
	}
}
