using System;
using System.Collections.Generic;

using Masterplan.Tools;

namespace Masterplan.Data
{
	/// <summary>
	/// Interface for project issues.
	/// </summary>
	public interface IIssue
	{
		/// <summary>
		/// Gets the reason for the issue.
		/// </summary>
		string Reason { get; }
	}

	/// <summary>
	/// Class representing an issue with a plot point's difficulty level.
	/// </summary>
	[Serializable]
	public class DifficultyIssue : IIssue
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="point">The point.</param>
		public DifficultyIssue(PlotPoint point)
		{
			fPoint = point;
		}

		/// <summary>
		/// Gets the plot point.
		/// </summary>
		public PlotPoint Point
		{
			get { return fPoint; }
		}
		PlotPoint fPoint = null;

		/// <summary>
		/// Gets the reason for the issue.
		/// </summary>
		public string Reason
		{
			get
			{
				if (fPoint.State != PlotPointState.Normal)
					return "";

				if (fPoint.Element == null)
					return "";

				string name = "game element";
				if (fPoint.Element is Encounter)
					name = "encounter";
				if (fPoint.Element is TrapElement)
				{
					TrapElement te = fPoint.Element as TrapElement;
					name = (te.Trap.Type == TrapType.Trap) ? "trap" : "hazard";
				}
				if (fPoint.Element is SkillChallenge)
					name = "skill challenge";
				if (fPoint.Element is Quest)
					name = "quest";

				int level = Workspace.GetPartyLevel(fPoint);

				Difficulty diff = fPoint.Element.GetDifficulty(level, Session.Project.Party.Size);
				switch (diff)
				{
					case Difficulty.Trivial:
						return "This " + name + " is too easy for a party of level " + level + ".";
					case Difficulty.Extreme:
						return "This " + name + " is too difficult for a party of level " + level + ".";
				}

				return "";
			}
		}

		/// <summary>
		/// [point name]: [reason]
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return fPoint.Name + ": " + Reason;
		}
	}

	/// <summary>
	/// Class representing an issue with a creature's difficulty level.
	/// </summary>
	[Serializable]
	public class CreatureIssue : IIssue
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="point">The plot point.</param>
		public CreatureIssue(PlotPoint point)
		{
			fPoint = point;
		}

		/// <summary>
		/// Gets the plot point.
		/// </summary>
		public PlotPoint Point
		{
			get { return fPoint; }
		}
		PlotPoint fPoint = null;

		/// <summary>
		/// Gets the reason for the issue.
		/// </summary>
		public string Reason
		{
			get
			{
				if (fPoint.State != PlotPointState.Normal)
					return "";

				Encounter enc = fPoint.Element as Encounter;
				if (enc == null)
					return "";

				int level = Workspace.GetPartyLevel(fPoint);

				foreach (EncounterSlot slot in enc.Slots)
				{
					int diff = slot.Card.Level - level;

					if (diff < -4)
						return slot.Card.Title + " is more than four levels lower than the party level.";

					if (diff > 5)
						return slot.Card.Title + " is more than five levels higher than the party level.";
				}

				return "";
			}
		}

		/// <summary>
		/// [point name]: [reason]
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return fPoint.Name + ": " + Reason;
		}
	}

	/// <summary>
	/// Class representing an issue with the number of skills defined for a skill challenge.
	/// </summary>
	[Serializable]
	public class SkillIssue : IIssue
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="point">The plot point.</param>
		public SkillIssue(PlotPoint point)
		{
			fPoint = point;
		}

		/// <summary>
		/// Gets the plot point.
		/// </summary>
		public PlotPoint Point
		{
			get { return fPoint; }
		}
		PlotPoint fPoint = null;

		/// <summary>
		/// Gets the reason for the issue.
		/// </summary>
		public string Reason
		{
			get
			{
				if (fPoint.State != PlotPointState.Normal)
					return "";

				SkillChallenge sc = fPoint.Element as SkillChallenge;
				if (sc == null)
					return "";

				if (sc.Skills.Count == 0)
					return "No skills are defined for this skill challenge.";

				return "";
			}
		}

		/// <summary>
		/// [point name]: [reason]
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return fPoint.Name + ": " + Reason;
		}
	}

	/// <summary>
	/// Class representing an issue with a treasure parcel being undefined.
	/// </summary>
	[Serializable]
	public class ParcelIssue : IIssue
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="parcel">The treasure parcel.</param>
		/// <param name="pp">The plot point.</param>
		public ParcelIssue(Parcel parcel, PlotPoint pp)
		{
			fParcel = parcel;
			fPoint = pp;
		}

		Parcel fParcel = null;

		/// <summary>
		/// Gets the plot point.
		/// </summary>
		public PlotPoint Point
		{
			get { return fPoint; }
		}
		PlotPoint fPoint = null;

		/// <summary>
		/// Gets the reason for the issue.
		/// </summary>
		public string Reason
		{
			get
			{
				if (fPoint.State != PlotPointState.Normal)
					return "";

				if (fParcel.Name == "")
					return "A treasure parcel in " + fPoint.Name + " is undefined.";

				return "";
			}
		}

		/// <summary>
		/// [point name]: [reason]
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return fPoint.Name + ": " + Reason;
		}
	}

	/// <summary>
	/// Class representing an issue with the number of treasure parcels in a plot.
	/// </summary>
	[Serializable]
	public class TreasureIssue : IIssue
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="name">The plot name.</param>
		/// <param name="plot">The plot.</param>
		public TreasureIssue(string name, Plot plot)
		{
			fName = name;
			fPlot = plot;
		}

		/// <summary>
		/// Gets the plot name.
		/// </summary>
		public string PlotName
		{
			get { return fName; }
		}
		string fName = "";

		/// <summary>
		/// Gets the plot.
		/// </summary>
		public Plot Plot
		{
			get { return fPlot; }
		}
		Plot fPlot = null;

		/// <summary>
		/// Gets the reason for the issue.
		/// </summary>
		public string Reason
		{
			get
			{
				int xp_gained = 0;
				int parcels_gained = 0;

				foreach (PlotPoint pp in fPlot.Points)
				{
					xp_gained += pp.GetXP();

					List<PlotPoint> points = pp.Subtree;
					foreach (PlotPoint point in points)
						parcels_gained += point.Parcels.Count;
				}

				int total_xp = Experience.GetHeroXP(Session.Project.Party.Level);
				total_xp += xp_gained / Session.Project.Party.Size;

				int final_level = Experience.GetHeroLevel(total_xp);
				int levels_gained = final_level - Session.Project.Party.Level;

				int remainder = total_xp - Experience.GetHeroXP(final_level);
				int required_xp = Experience.GetHeroXP(final_level + 1) - Experience.GetHeroXP(final_level);
				if (required_xp == 0)
					return "";

				int parcels_per_level = 10 + (Session.Project.Party.Size - 5);
				int parcels_required = parcels_per_level * levels_gained;
				parcels_required += (remainder * parcels_per_level) / required_xp;

				int delta = (int)(parcels_required * 0.3);
				int upper = parcels_required + delta;
				int lower = parcels_required - delta;

				string str = "";

				if (parcels_gained < lower)
					str = "Too few treasure parcels are available, compared to the amount of XP given.";

				if (parcels_gained > upper)
					str = "Too many treasure parcels are available, compared to the amount of XP given.";

				if (str != "")
				{
					bool has_subplots = false;
					foreach (PlotPoint pp in fPlot.Points)
					{
						if (pp.Subplot.Points.Count != 0)
						{
							has_subplots = true;
							break;
						}
					}

					str += Environment.NewLine;
					str += "This plot";
					if (has_subplots)
						str += " (and its subplots)";
					str += " should contain ";
					if (lower == upper)
						str += upper.ToString();
					else
						str += lower + " - " + upper;
					str += " parcels; currently " + parcels_gained + " are available.";
				}

				return str;
			}
		}

		/// <summary>
		/// [plot name]: [reason]
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return fName + ": " + Reason;
		}
	}
}
