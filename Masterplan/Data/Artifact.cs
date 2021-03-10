using System;
using System.Collections.Generic;

using Utils;

namespace Masterplan.Data
{
	/// <summary>
	/// Class representing a magical artifact.
	/// </summary>
	[Serializable]
	public class Artifact
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public Artifact()
		{
			AddStandardConcordanceLevels();
		}

		/// <summary>
		/// Gets or sets the unique ID of the artifact.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the name of the artifact.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// The tier for which the artifact is suitable.
		/// </summary>
		public Tier Tier
		{
			get { return fTier; }
			set {fTier = value;}
		}
		Tier fTier = Tier.Heroic;

		/// <summary>
		/// The artifact's description.
		/// </summary>
		public string Description
		{
			get { return fDescription; }
			set { fDescription = value; }
		}
		string fDescription = "";

		/// <summary>
		/// The artifact's details.
		/// </summary>
		public string Details
		{
			get { return fDetails; }
			set { fDetails = value; }
		}
		string fDetails = "";

		/// <summary>
		/// The artifact's goals.
		/// </summary>
		public string Goals
		{
			get { return fGoals; }
			set { fGoals = value; }
		}
		string fGoals = "";

		/// <summary>
		/// Roleplaying tips for the artifact.
		/// </summary>
		public string RoleplayingTips
		{
			get { return fRoleplayingTips; }
			set { fRoleplayingTips = value; }
		}
		string fRoleplayingTips = "";

		/// <summary>
		/// The artifact's enhancement / properties
		/// </summary>
		public List<MagicItemSection> Sections
		{
			get { return fSections; }
			set { fSections = value; }
		}
		List<MagicItemSection> fSections = new List<MagicItemSection>();

		/// <summary>
		/// The artifact's concordance rules.
		/// </summary>
		public List<Pair<string, string>> ConcordanceRules
		{
			get { return fConcordanceRules; }
			set { fConcordanceRules = value; }
		}
		List<Pair<string, string>> fConcordanceRules = new List<Pair<string, string>>();

		/// <summary>
		/// The artifact's concordance levels.
		/// </summary>
		public List<ArtifactConcordance> ConcordanceLevels
		{
			get { return fConcordanceLevels; }
			set { fConcordanceLevels = value; }
		}
		List<ArtifactConcordance> fConcordanceLevels = new List<ArtifactConcordance>();

		/// <summary>
		/// Adds the standard concordance levels to the artifact.
		/// </summary>
		public void AddStandardConcordanceLevels()
		{
			fConcordanceLevels.Add(new ArtifactConcordance("Pleased", "16-20"));
			fConcordanceLevels.Add(new ArtifactConcordance("Satisfied", "12-15"));
			fConcordanceLevels.Add(new ArtifactConcordance("Normal", "5-11"));
			fConcordanceLevels.Add(new ArtifactConcordance("Unsatisfied", "1-4"));
			fConcordanceLevels.Add(new ArtifactConcordance("Angered", "0 or lower"));
			fConcordanceLevels.Add(new ArtifactConcordance("Moving On", ""));
		}

		/// <summary>
		/// Creates a copy of the artifact.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public Artifact Copy()
		{
			Artifact a = new Artifact();

			a.ID = fID;
			a.Name = fName;
			a.Tier = fTier;
			a.Description = fDescription;
			a.Details = fDetails;
			a.Goals = fGoals;
			a.RoleplayingTips = fRoleplayingTips;

			a.Sections.Clear();
			foreach (MagicItemSection mis in fSections)
				a.Sections.Add(mis.Copy());

			a.ConcordanceRules.Clear();
			foreach (Pair<string, string> pair in fConcordanceRules)
			{
				Pair<string, string> rule = new Pair<string, string>(pair.First, pair.Second);
				a.ConcordanceRules.Add(rule);
			}

			a.ConcordanceLevels.Clear();
			foreach (ArtifactConcordance ac in fConcordanceLevels)
				a.ConcordanceLevels.Add(ac.Copy());

			return a;
		}

		/// <summary>
		/// Returns the name of the artifact.
		/// </summary>
		/// <returns>Returns the name of the artifact.</returns>
		public override string ToString()
		{
			return fName;
		}
	}

	/// <summary>
	/// Class representing a concordance level for an artifact.
	/// </summary>
	[Serializable]
	public class ArtifactConcordance
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public ArtifactConcordance()
		{
		}

		/// <summary>
		/// Constructor taking a name and a value range.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="value_range">The value range.</param>
		public ArtifactConcordance(string name, string value_range)
		{
			fName = name;
			fValueRange = value_range;
		}

		/// <summary>
		/// The concordance level's name.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// The concordance level's value range.
		/// </summary>
		public string ValueRange
		{
			get { return fValueRange; }
			set { fValueRange = value; }
		}
		string fValueRange = "";

		/// <summary>
		/// The concordance level's quote.
		/// </summary>
		public string Quote
		{
			get { return fQuote; }
			set { fQuote = value; }
		}
		string fQuote = "";

		/// <summary>
		/// The concordance level's description.
		/// </summary>
		public string Description
		{
			get { return fDescription; }
			set { fDescription = value; }
		}
		string fDescription = "";

		/// <summary>
		/// The concordance level's enhancements and properties.
		/// </summary>
		public List<MagicItemSection> Sections
		{
			get { return fSections; }
			set { fSections = value; }
		}
		List<MagicItemSection> fSections = new List<MagicItemSection>();

		/// <summary>
		/// Creates a copy of the artifact concordance.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public ArtifactConcordance Copy()
		{
			ArtifactConcordance ac = new ArtifactConcordance();

			ac.Name = fName;
			ac.ValueRange = fValueRange;
			ac.Quote = fQuote;
			ac.Description = fDescription;

			ac.Sections.Clear();
			foreach (MagicItemSection mis in fSections)
				ac.Sections.Add(mis.Copy());

			return ac;
		}
	}
}
