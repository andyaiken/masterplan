using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class EncounterReportForm : Form
	{
		public EncounterReportForm(EncounterLog log, Encounter enc)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fReport = log.CreateReport(enc, true);
			fEncounter = enc;

			if (fEncounter.MapID == Guid.Empty)
				ReportBtn.DropDownItems.Remove(ReportMovement);

			update_report();
			update_mvp();
		}

		~EncounterReportForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			ReportTime.Checked = fReportType == ReportType.Time;
			ReportDamageEnemies.Checked = fReportType == ReportType.DamageToEnemies;
			ReportDamageAllies.Checked = fReportType == ReportType.DamageToAllies;
			ReportMovement.Checked = fReportType == ReportType.Movement;

			BreakdownIndividually.Checked = fBreakdownType == BreakdownType.Individual;
			BreakdownByController.Checked = fBreakdownType == BreakdownType.Controller;
			BreakdownByFaction.Checked = fBreakdownType == BreakdownType.Faction;
		}

		EncounterReport fReport = null;
		Encounter fEncounter = null;

		ReportType fReportType = ReportType.Time;
		BreakdownType fBreakdownType = BreakdownType.Individual;

		#region Toolbar

		private void ReportTime_Click(object sender, EventArgs e)
		{
			fReportType = ReportType.Time;
			update_report();
		}

		private void ReportDamageEnemies_Click(object sender, EventArgs e)
		{
			fReportType = ReportType.DamageToEnemies;
			update_report();
		}

		private void ReportDamageAllies_Click(object sender, EventArgs e)
		{
			fReportType = ReportType.DamageToAllies;
			update_report();
		}

		private void ReportMovement_Click(object sender, EventArgs e)
		{
			fReportType = ReportType.Movement;
			update_report();
		}

		private void BreakdownIndividually_Click(object sender, EventArgs e)
		{
			fBreakdownType = BreakdownType.Individual;
			update_report();
		}

		private void BreakdownByController_Click(object sender, EventArgs e)
		{
			fBreakdownType = BreakdownType.Controller;
			update_report();
		}

		private void BreakdownByFaction_Click(object sender, EventArgs e)
		{
			fBreakdownType = BreakdownType.Faction;
			update_report();
		}

		private void ExportBtn_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.FileName = "Encounter Report";
			dlg.Filter = Program.HTMLFilter;

			if (dlg.ShowDialog() == DialogResult.OK)
				File.WriteAllText(dlg.FileName, Browser.DocumentText);
		}

		#endregion

		void update_report()
		{
			ReportTable table = fReport.CreateTable(fReportType, fBreakdownType, fEncounter);
			Browser.DocumentText = HTML.EncounterReportTable(table, Session.Preferences.TextSize);

			Graph.ShowTable(table);
		}

		void update_mvp()
		{
			List<Guid> ids = fReport.MVPs(fEncounter);
			string mvps = "";
			foreach (Guid id in ids)
			{
				Hero hero = Session.Project.FindHero(id);
				if (hero != null)
				{
					if (mvps != "")
						mvps += ", ";

					mvps += hero.Name;
				}
			}

			if (mvps != "")
			{
				MVPLbl.Text = "MVP: " + mvps;
			}
			else
			{
				MVPLbl.Text = "(no MVP for this encounter)";
				MVPLbl.Enabled = false;
			}
		}

		private void PlayerViewBtn_Click(object sender, EventArgs e)
		{
			if (Session.PlayerView == null)
				Session.PlayerView = new PlayerViewForm(this);

			ReportTable table = fReport.CreateTable(fReportType, fBreakdownType, fEncounter);
			Session.PlayerView.ShowEncounterReportTable(table);
		}
	}
}
