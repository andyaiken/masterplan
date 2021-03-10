using System;
using System.Collections.Generic;

using Masterplan.Tools;

namespace Masterplan.Data
{
	/// <summary>
	/// Class representing a skill challenge.
	/// </summary>
	[Serializable]
	public class SkillChallenge : IElement
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		public SkillChallenge()
		{
		}

		/// <summary>
		/// Gets or sets the unique ID of the challenge.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the name of the challenge.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the level of the challenge.
		/// </summary>
		public int Level
		{
			get { return fLevel; }
			set { fLevel = value; }
		}
		int fLevel = -1;

		/// <summary>
		/// Gets or sets the challenge complexity.
		/// </summary>
		public int Complexity
		{
			get { return fComplexity; }
			set { fComplexity = value; }
		}
		int fComplexity = 1;

		/// <summary>
		/// Gets or sets the list of skills used in this challenge.
		/// </summary>
		public List<SkillChallengeData> Skills
		{
			get { return fSkills; }
			set { fSkills = value; }
		}
		List<SkillChallengeData> fSkills = new List<SkillChallengeData>();

		/// <summary>
		/// Gets or sets the victory information.
		/// </summary>
		public string Success
		{
			get { return fSuccess; }
			set { fSuccess = value; }
		}
		string fSuccess = "";

		/// <summary>
		/// Gets or sets the defeat information.
		/// </summary>
		public string Failure
		{
			get { return fFailure; }
			set { fFailure = value; }
		}
		string fFailure = "";

		/// <summary>
		/// Gets or sets custom notes.
		/// </summary>
		public string Notes
		{
			get { return fNotes; }
			set { fNotes = value; }
		}
		string fNotes = "";

        /// <summary>
        /// Gets or sets the ID of the map where the challenge takes place.
        /// </summary>
        public Guid MapID
        {
            get { return fMapID; }
            set { fMapID = value; }
        }
        Guid fMapID = Guid.Empty;

        /// <summary>
        /// Gets or sets the ID of the map area where the challenge takes place.
        /// </summary>
        public Guid MapAreaID
        {
            get { return fMapAreaID; }
            set { fMapAreaID = value; }
        }
        Guid fMapAreaID = Guid.Empty;

		/// <summary>
		/// Gets the number of successes required by the challenge.
		/// </summary>
		public int Successes
		{
			get { return GetSuccesses(fComplexity); }
		}

		/// <summary>
		/// Gets the number of successes and failures so far.
		/// </summary>
		public SkillChallengeResult Results
		{
			get
			{
				SkillChallengeResult result = new SkillChallengeResult();

				foreach (SkillChallengeData scd in fSkills)
				{
					if (scd.Results != null)
					{
						result.Successes += scd.Results.Successes;
						result.Fails += scd.Results.Fails;
					}
				}

				return result;
			}
		}

		/// <summary>
		/// Calculates the number of successes required for a challenge of the given complexity.
		/// </summary>
		/// <param name="complexity">The complexity.</param>
		/// <returns>Returns the number of successes required.</returns>
		public static int GetSuccesses(int complexity)
		{
			return (complexity + 1) * 2;
		}

		/// <summary>
		/// Level N, N successes before 3 failures
		/// </summary>
		public string Info
		{
			get
			{
				if (fLevel != -1)
				{
					return "Level " + fLevel + ", " + Successes + " successes before 3 failures";
				}
				else
				{
					return Successes + " successes before 3 failures";
				}
			}
		}

		/// <summary>
		/// Calculates the XP value of a challenge of the given level and complexity.
		/// </summary>
		/// <param name="level">The level.</param>
		/// <param name="complexity">The complexity.</param>
		/// <returns>Returns the XP value.</returns>
		public static int GetXP(int level, int complexity)
		{
			int xp = Experience.GetCreatureXP(level) * complexity;

			if (Session.Project != null)
				xp = (int)(xp * Session.Project.CampaignSettings.XP);

			return xp;
		}

		/// <summary>
		/// Calculates the XP value of the challenge.
		/// </summary>
		/// <returns>Returns the XP value.</returns>
		public int GetXP()
		{
			return GetXP(fLevel, fComplexity);
		}

		/// <summary>
		/// Calculates the difficulty of the challenge.
		/// </summary>
		/// <param name="party_level">The party level.</param>
		/// <param name="party_size">The party size.</param>
		/// <returns>Returns the difficulty.</returns>
		public Difficulty GetDifficulty(int party_level, int party_size)
		{
			if (fSkills.Count == 0)
				return Difficulty.Trivial;

			List<Difficulty> diffs = new List<Difficulty>();
			diffs.Add(AI.GetThreatDifficulty(fLevel, party_level));

			foreach (SkillChallengeData scd in fSkills)
				diffs.Add(scd.Difficulty);

			if (diffs.Contains(Difficulty.Extreme))
				return Difficulty.Extreme;

			if (diffs.Contains(Difficulty.Hard))
				return Difficulty.Hard;

			if (diffs.Contains(Difficulty.Moderate))
				return Difficulty.Moderate;

			if (diffs.Contains(Difficulty.Easy))
				return Difficulty.Easy;

			return Difficulty.Trivial;
		}

		/// <summary>
		/// Find the skill data for the given skill.
		/// </summary>
		/// <param name="skill_name">The name of the skill to look for.</param>
		/// <returns>The SkillChallengeData for the skill if found; null otherwise.</returns>
		public SkillChallengeData FindSkill(string skill_name)
		{
			foreach (SkillChallengeData scd in fSkills)
			{
				if (scd.SkillName == skill_name)
					return scd;
			}

			return null;
		}

		/// <summary>
		/// Creates a copy of the challenge.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public IElement Copy()
		{
			SkillChallenge sc = new SkillChallenge();

			sc.ID = fID;
			sc.Name = fName;
			sc.Level = fLevel;
			sc.Complexity = fComplexity;

			foreach (SkillChallengeData scd in fSkills)
				sc.Skills.Add(scd.Copy());

			sc.Success = fSuccess;
			sc.Failure = fFailure;
			sc.Notes = fNotes;
            sc.MapID = fMapID;
            sc.MapAreaID = fMapAreaID;

			return sc;
		}
	}

	/// <summary>
	/// Primary or secondary skill.
	/// </summary>
	public enum SkillType
	{
		/// <summary>
		/// Primary skill.
		/// </summary>
		Primary,

		/// <summary>
		/// Secondary skill.
		/// </summary>
		Secondary,

		/// <summary>
		/// Skill which results in automatic failure.
		/// </summary>
		AutoFail
	}

	/// <summary>
	/// Class representing a skill in a skill challenge.
	/// </summary>
	[Serializable]
	public class SkillChallengeData : IComparable<SkillChallengeData>
	{
		/// <summary>
		/// Gets or sets the name of the skill.
		/// </summary>
		public string SkillName
		{
			get { return fSkillName; }
			set { fSkillName = value; }
		}
		string fSkillName = "";

		/// <summary>
		/// Gets or sets the difficulty of the skill.
		/// </summary>
		public Difficulty Difficulty
		{
			get { return fDifficulty; }
			set { fDifficulty = value; }
		}
		Difficulty fDifficulty = Difficulty.Moderate;

		/// <summary>
		/// Gets or sets the skill's DC modifier.
		/// </summary>
		public int DCModifier
		{
			get { return fDCModifier; }
			set { fDCModifier = value; }
		}
		int fDCModifier = 0;

		/// <summary>
		/// Gets or sets the skill type (primary / secondary).
		/// </summary>
		public SkillType Type
		{
			get { return fType; }
			set { fType = value; }
		}
		SkillType fType = SkillType.Primary;

		/// <summary>
		/// Gets or sets the skill details.
		/// </summary>
		public string Details
		{
			get { return fDetails; }
			set { fDetails = value; }
		}
		string fDetails = "";

		/// <summary>
		/// Gets or sets the success information.
		/// </summary>
		public string Success
		{
			get { return fSuccess; }
			set { fSuccess = value; }
		}
		string fSuccess = "";

		/// <summary>
		/// Gets or sets the failure information.
		/// </summary>
		public string Failure
		{
			get { return fFailure; }
			set { fFailure = value; }
		}
		string fFailure = "";

		/// <summary>
		/// Gets or sets the results for this skill.
		/// </summary>
		public SkillChallengeResult Results
		{
			get { return fResults; }
			set { fResults = value; }
		}
		SkillChallengeResult fResults = new SkillChallengeResult();

		/// <summary>
		/// Creates a copy of the skill data.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public SkillChallengeData Copy()
		{
			SkillChallengeData scd = new SkillChallengeData();

			scd.SkillName = fSkillName;
			scd.Difficulty = fDifficulty;
			scd.DCModifier = fDCModifier;
			scd.Type = fType;
			scd.Details = fDetails;
			scd.Success = fSuccess;
			scd.Failure = fFailure;
			scd.Results = fResults.Copy();

			return scd;
		}

		/// <summary>
		/// Compares this skill with another.
		/// </summary>
		/// <param name="rhs">The other skill.</param>
		/// <returns>Returns -1 if this skill should be sorted before the other, +1 if the other should be sorted before this skill, 0 otherwise.</returns>
		public int CompareTo(SkillChallengeData rhs)
		{
			int result = fSkillName.CompareTo(rhs.SkillName);

			if (result == 0)
				result = fDifficulty.CompareTo(rhs.Difficulty);

			if (result == 0)
				result = fDCModifier.CompareTo(rhs.DCModifier);

			return result;
		}
	}

	/// <summary>
	/// Class representing successes or fails for a skill challenge.
	/// </summary>
	[Serializable]
	public class SkillChallengeResult
	{
		/// <summary>
		/// Gets or sets the number of successes.
		/// </summary>
		public int Successes
		{
			get { return fSuccesses; }
			set { fSuccesses = value; }
		}
		int fSuccesses = 0;

		/// <summary>
		/// Gets or sets the number of fails.
		/// </summary>
		public int Fails
		{
			get { return fFails; }
			set { fFails = value; }
		}
		int fFails = 0;

		/// <summary>
		/// Creates a copy of this SkillChallengeResult.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public SkillChallengeResult Copy()
		{
			SkillChallengeResult scr = new SkillChallengeResult();

			scr.Successes = fSuccesses;
			scr.Fails = fFails;

			return scr;
		}
	}
}
