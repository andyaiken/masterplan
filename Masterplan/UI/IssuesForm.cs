using System.Collections.Generic;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class IssuesForm : Form
	{
		public IssuesForm(Plot plot)
		{
			InitializeComponent();

			List<PlotPoint> points = plot.AllPlotPoints;

			List<string> lines = new List<string>();

			lines.AddRange(HTML.GetHead("Plot Design Issues", "", DisplaySize.Small));
			lines.Add("<BODY>");

			List<DifficultyIssue> difficulty_issues = new List<DifficultyIssue>();
			foreach (PlotPoint pp in points)
			{
				DifficultyIssue di = new DifficultyIssue(pp);
				if (di.Reason != "")
					difficulty_issues.Add(di);
			}
			lines.Add("<H4>Difficulty Issues</H4>");
			if (difficulty_issues.Count != 0)
			{
				foreach (DifficultyIssue issue in difficulty_issues)
				{
					lines.Add("<P>");
					lines.Add("<B>" + issue.Point + "</B>: " + issue.Reason);
					lines.Add("</P>");
				}
			}
			else
			{
				lines.Add("<P class=instruction>");
				lines.Add("(none)");
				lines.Add("</P>");
			}
			lines.Add("<HR>");

			List<CreatureIssue> creature_issues = new List<CreatureIssue>();
			foreach (PlotPoint pp in points)
			{
				if (pp.Element is Encounter)
				{
					CreatureIssue ci = new CreatureIssue(pp);
					if (ci.Reason != "")
						creature_issues.Add(ci);
				}
			}
			lines.Add("<H4>Creature Choice Issues</H4>");
			if (difficulty_issues.Count != 0)
			{
				foreach (CreatureIssue issue in creature_issues)
				{
					lines.Add("<P>");
					lines.Add("<B>" + issue.Point + "</B>: " + issue.Reason);
					lines.Add("</P>");
				}
			}
			else
			{
				lines.Add("<P class=instruction>");
				lines.Add("(none)");
				lines.Add("</P>");
			}
			lines.Add("<HR>");

			List<SkillIssue> skill_issues = new List<SkillIssue>();
			foreach (PlotPoint pp in points)
			{
				if (pp.Element is SkillChallenge)
				{
					SkillIssue si = new SkillIssue(pp);
					if (si.Reason != "")
						skill_issues.Add(si);
				}
			}
			lines.Add("<H4>Undefined Skill Challenges</H4>");
			if (skill_issues.Count != 0)
			{
				foreach (SkillIssue issue in skill_issues)
				{
					lines.Add("<P>");
					lines.Add("<B>" + issue.Point + "</B>: " + issue.Reason);
					lines.Add("</P>");
				}
			}
			else
			{
				lines.Add("<P class=instruction>");
				lines.Add("(none)");
				lines.Add("</P>");
			}
			lines.Add("<HR>");

			List<ParcelIssue> parcel_issues = new List<ParcelIssue>();
			foreach (PlotPoint pp in points)
			{
				foreach (Parcel parcel in pp.Parcels)
				{
					if (parcel.Name == "")
					{
						ParcelIssue pi = new ParcelIssue(parcel, pp);
						parcel_issues.Add(pi);
					}
				}
			}
			lines.Add("<H4>Undefined Treasure Parcels</H4>");
			if (parcel_issues.Count != 0)
			{
				foreach (ParcelIssue issue in parcel_issues)
				{
					lines.Add("<P>");
					lines.Add("<B>" + issue.Point + "</B>: " + issue.Reason);
					lines.Add("</P>");
				}
			}
			else
			{
				lines.Add("<P class=instruction>");
				lines.Add("(none)");
				lines.Add("</P>");
			}
			lines.Add("<HR>");

			List<TreasureIssue> treasure_issues = new List<TreasureIssue>();
			PlotPoint parent = Session.Project.FindParent(plot);
			string plot_name = (parent != null) ? parent.Name : Session.Project.Name;
			add_treasure_issues(plot_name, plot, treasure_issues);
			lines.Add("<H4>Treasure Allocation Issues</H4>");
			if (treasure_issues.Count != 0)
			{
				foreach (TreasureIssue issue in treasure_issues)
				{
					lines.Add("<P>");
					lines.Add("<B>" + issue.PlotName + "</B>: " + issue.Reason);
					lines.Add("</P>");
				}
			}
			else
			{
				lines.Add("<P class=instruction>");
				lines.Add("(none)");
				lines.Add("</P>");
			}

			lines.Add("</BODY>");
			lines.Add("</HTML>");

			Browser.DocumentText = HTML.Concatenate(lines);
		}

		void add_treasure_issues(string plotname, Plot plot, List<TreasureIssue> treasure_issues)
		{
			TreasureIssue ti = new TreasureIssue(plotname, plot);
			if (ti.Reason != "")
			{
				treasure_issues.Add(ti);

				foreach (PlotPoint pp in plot.Points)
					add_treasure_issues(pp.Name, pp.Subplot, treasure_issues);
			}
		}
	}
}
