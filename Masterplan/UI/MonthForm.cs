using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class MonthForm : Form
	{
		public MonthForm(MonthInfo month)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fMonthInfo = month.Copy();

			NameBox.Text = fMonthInfo.Name;
			DaysBox.Value = fMonthInfo.DayCount;
			LeapModBox.Value = fMonthInfo.LeapModifier;
			LeapPeriodBox.Value = Math.Max(2, fMonthInfo.LeapPeriod);
		}

		~MonthForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			LeapPeriodLbl.Enabled = (LeapModBox.Value != 0);
			LeapPeriodBox.Enabled = (LeapModBox.Value != 0);
		}

		public MonthInfo MonthInfo
		{
			get { return fMonthInfo; }
		}
		MonthInfo fMonthInfo = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fMonthInfo.Name = NameBox.Text;
			fMonthInfo.DayCount = (int)DaysBox.Value;
			fMonthInfo.LeapModifier = (int)LeapModBox.Value;
			fMonthInfo.LeapPeriod = (int)LeapPeriodBox.Value;
		}
	}
}
