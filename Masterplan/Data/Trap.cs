using System;
using System.Collections.Generic;

using Masterplan.Tools;

namespace Masterplan.Data
{
	/// <summary>
	/// Specifies trap or hazard.
	/// </summary>
	public enum TrapType
	{
		/// <summary>
		/// An artificial trap.
		/// </summary>
		Trap,

		/// <summary>
		/// A natural / environmental hazard.
		/// </summary>
		Hazard,

		/// <summary>
		/// A terrain effect.
		/// </summary>
		Terrain
	}

	/// <summary>
	/// Class representing a trap or hazard.
	/// </summary>
	[Serializable]
	public class Trap : IComparable<Trap>
	{
		/// <summary>
		/// Gets or sets the unique ID.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets whether the object is a trap or a hazard.
		/// </summary>
		public TrapType Type
		{
			get { return fType; }
			set { fType = value; }
		}
		TrapType fType = TrapType.Trap;

		/// <summary>
		/// Gets or sets the display name.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the level of the trap.
		/// </summary>
		public int Level
		{
			get { return fLevel; }
			set { fLevel = value; }
		}
		int fLevel = 1;

		/// <summary>
		/// Gets or sets the role of the trap.
		/// </summary>
		public IRole Role
		{
			get { return fRole; }
			set { fRole = value; }
		}
		IRole fRole = new ComplexRole(RoleType.Blaster);

		/// <summary>
		/// Gets or sets the read-aloud text for the trap.
		/// </summary>
		public string ReadAloud
		{
			get { return fReadAloud; }
			set { fReadAloud = value; }
		}
		string fReadAloud = "";

		/// <summary>
		/// Gets or sets the trap description.
		/// </summary>
		public string Description
		{
			get { return fDescription; }
			set { fDescription = value; }
		}
		string fDescription = "";

		/// <summary>
		/// Gets or sets the trap details.
		/// </summary>
		public string Details
		{
			get { return fDetails; }
			set { fDetails = value; }
		}
		string fDetails = "";

		/// <summary>
		/// Gets or sets the list of skills that can be used with this trap.
		/// </summary>
		public List<TrapSkillData> Skills
		{
			get { return fSkills; }
			set { fSkills = value; }
		}
		List<TrapSkillData> fSkills = new List<TrapSkillData>();

		/// <summary>
		/// Gets or sets the trap's initiative bonus (or int.MinValue if the trap does not roll initiative).
		/// </summary>
		public int Initiative
		{
			get { return fInitiative; }
			set { fInitiative = value; }
		}
		int fInitiative = int.MinValue;

		/// <summary>
		/// Gets or sets the trigger.
		/// </summary>
		public string Trigger
		{
			get { return fTrigger; }
			set { fTrigger = value; }
		}
		string fTrigger = "";

		/// <summary>
		/// Gets or sets the trap attack data.
		/// </summary>
		public TrapAttack Attack
		{
			get { return fAttack; }
			set { fAttack = value; }
		}
		TrapAttack fAttack = new TrapAttack();

		/// <summary>
		/// Gets or sets the trap's secondary attacks.
		/// </summary>
		public List<TrapAttack> Attacks
		{
			get { return fAttacks; }
			set { fAttacks = value; }
		}
		List<TrapAttack> fAttacks = new List<TrapAttack>();

		/// <summary>
		/// Gets or sets the list of trap countermeasures.
		/// </summary>
		public List<string> Countermeasures
		{
			get { return fCountermeasures; }
			set { fCountermeasures = value; }
		}
		List<string> fCountermeasures = new List<string>();

		/// <summary>
		/// Gets the XP value for the trap.
		/// </summary>
		public int XP
		{
			get
			{
				int xp = 0;

				if (fRole is Minion)
				{
					float experience = (float)Experience.GetCreatureXP(fLevel) / 4;
					xp = (int)Math.Round(experience, MidpointRounding.AwayFromZero);
				}
				else
				{
					ComplexRole role = fRole as ComplexRole;

					xp = Experience.GetCreatureXP(fLevel);
					switch (role.Flag)
					{
						case RoleFlag.Elite:
							xp *= 2;
							break;
						case RoleFlag.Solo:
							xp *= 5;
							break;
					}
				}

				if (Session.Project != null)
				{
					// Apply campaign settings
					xp = (int)(xp * Session.Project.CampaignSettings.XP);
				}

				return xp;
			}
		}

		/// <summary>
		/// Level N [role] [trap/hazard]
		/// </summary>
		public string Info
		{
			get { return "Level " + fLevel + " " + fRole + " " + fType.ToString().ToLower(); }
		}

		/// <summary>
		/// Creates a copy of this object.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public Trap Copy()
		{
			Trap t = new Trap();

			t.ID = fID;
			t.Type = fType;
			t.Name = fName;
			t.Level = fLevel;
			t.Role = fRole.Copy();
			t.ReadAloud = fReadAloud;
			t.Description = fDescription;
			t.Details = fDetails;

			foreach (TrapSkillData tsd in fSkills)
				t.Skills.Add(tsd.Copy());

			t.Initiative = fInitiative;
			t.Trigger = fTrigger;

			t.Attack = fAttack != null ? fAttack.Copy() : null;

			foreach (TrapAttack ta in fAttacks)
				t.Attacks.Add(ta.Copy());

			foreach (string cm in fCountermeasures)
				t.Countermeasures.Add(cm);

			return t;
		}

		/// <summary>
		/// Returns the name.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return fName;
		}

		/// <summary>
		/// Compares this trap to another.
		/// </summary>
		/// <param name="rhs">The other trap.</param>
		/// <returns>Returns -1 if this trap should be sorted before the other, +1 if the other should be sorted before this; 0 otherwise.</returns>
		public int CompareTo(Trap rhs)
		{
			return fName.CompareTo(rhs.Name);
		}

		/// <summary>
		/// Finds the specified skill data.
		/// </summary>
		/// <param name="skillname">The name of the skill to look for.</param>
		/// <returns>Returns the skill data if it is present; null otherwise.</returns>
		public TrapSkillData FindSkill(string skillname)
		{
			foreach (TrapSkillData tsd in fSkills)
			{
				if (tsd.SkillName == skillname)
					return tsd;
			}

			return null;
		}

		/// <summary>
		/// Finds the specified skill data.
		/// </summary>
		/// <param name="id">The ID of the skill to look for.</param>
		/// <returns>Returns the skill data if it is present; null otherwise.</returns>
		public TrapSkillData FindSkill(Guid id)
		{
			foreach (TrapSkillData tsd in fSkills)
			{
				if (tsd.ID == id)
					return tsd;
			}

			return null;
		}

		/// <summary>
		/// Finds the specified attack.
		/// </summary>
		/// <param name="id">The ID of the attack to look for.</param>
		/// <returns>Returns the attack if it is present; null otherwise.</returns>
		public TrapAttack FindAttack(Guid id)
		{
			foreach (TrapAttack ta in fAttacks)
			{
				if (ta.ID == id)
					return ta;
			}

			return null;
		}

		/// <summary>
		/// Adjusts the trap's level and attack data.
		/// </summary>
		/// <param name="delta">The level adjustment delta.</param>
		public void AdjustLevel(int delta)
		{
			fLevel += delta;
			fLevel = Math.Max(1, fLevel);

			if (fInitiative != int.MinValue)
			{
				Initiative += delta;
				fInitiative = Math.Max(1, fInitiative);
			}

			foreach (TrapAttack ta in fAttacks)
			{
				if (ta.Attack != null)
				{
					ta.Attack.Bonus += delta;
					ta.Attack.Bonus = Math.Max(1, ta.Attack.Bonus);
				}

				string hit_dmg = AI.ExtractDamage(ta.OnHit);
				if (hit_dmg != "")
				{
					DiceExpression exp = DiceExpression.Parse(hit_dmg);
					if (exp != null)
					{
						DiceExpression exp_adj = exp.Adjust(delta);
						if ((exp_adj != null) && (exp.ToString() != exp_adj.ToString()))
							ta.OnHit = ta.OnHit.Replace(hit_dmg, exp_adj + " damage");
					}
				}

				string miss_dmg = AI.ExtractDamage(ta.OnMiss);
				if (miss_dmg != "")
				{
					DiceExpression exp = DiceExpression.Parse(miss_dmg);
					if (exp != null)
					{
						DiceExpression exp_adj = exp.Adjust(delta);
						if ((exp_adj != null) && (exp.ToString() != exp_adj.ToString()))
							ta.OnMiss = ta.OnMiss.Replace(miss_dmg, exp_adj + " damage");
					}
				}

				string effect_dmg = AI.ExtractDamage(ta.Effect);
				if (effect_dmg != "")
				{
					DiceExpression exp = DiceExpression.Parse(effect_dmg);
					if (exp != null)
					{
						DiceExpression exp_adj = exp.Adjust(delta);
						if ((exp_adj != null) && (exp.ToString() != exp_adj.ToString()))
							ta.Effect = ta.Effect.Replace(effect_dmg, exp_adj + " damage");
					}
				}
			}

			foreach (TrapSkillData tsd in fSkills)
				tsd.DC += delta;
		}
	}

	/// <summary>
	/// Class encapsulating skill usage data for a trap.
	/// </summary>
	[Serializable]
	public class TrapSkillData : IComparable<TrapSkillData>
	{
		/// <summary>
		/// Gets or sets the ID of the skill data.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the name of the skill.
		/// </summary>
		public string SkillName
		{
			get { return fSkillName; }
			set { fSkillName = value; }
		}
		string fSkillName = "Perception";

		/// <summary>
		/// Gets or sets the skill DC.
		/// </summary>
		public int DC
		{
			get { return fDC; }
			set { fDC = value; }
		}
		int fDC = 10;

		/// <summary>
		/// Gets or sets the skill usage information.
		/// </summary>
		public string Details
		{
			get { return fDetails; }
			set { fDetails = value; }
		}
		string fDetails = "";

		/// <summary>
		/// [skill name] DC XX: [details]
		/// or
		/// [skill name]: [details]
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			if (fDC == 0)
			{
				return fSkillName + ": " + fDetails;
			}
			else
			{
				return fSkillName + " DC " + fDC + ": " + fDetails;
			}
		}

		/// <summary>
		/// Creates a copy of the TrapSkillData.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public TrapSkillData Copy()
		{
			TrapSkillData tsd = new TrapSkillData();

			tsd.ID = fID;
			tsd.SkillName = fSkillName;
			tsd.DC = fDC;
			tsd.Details = fDetails;

			return tsd;
		}

		/// <summary>
		/// Sorts Perception first, then other skills alphabetically.
		/// Skills with the same name are sorted by ascending DC.
		/// </summary>
		/// <param name="rhs">The other TrapSkillData object.</param>
		/// <returns>Returns -1 if this object should be sorted before rhs, +1 if rhs should be sorted before this, 0 otherwise.</returns>
		public int CompareTo(TrapSkillData rhs)
		{
			if (fSkillName != rhs.SkillName)
			{
				// Sort by skill name
				if (fSkillName == "Perception")
					return -1;

				if (rhs.SkillName == "Perception")
					return 1;

				return fSkillName.CompareTo(rhs.SkillName);
			}
			else
			{
				// Sort by DC
				return fDC.CompareTo(rhs.DC);
			}
		}
	}

	/// <summary>
	/// Class encapsulating attack data for a trap.
	/// </summary>
	[Serializable]
	public class TrapAttack
	{
		/// <summary>
		/// Gets or sets the unique ID.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the attack name.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the trap trigger details.
		/// </summary>
		public string Trigger
		{
			get { return fTrigger; }
			set { fTrigger = value; }
		}
		string fTrigger = "";

		/// <summary>
		/// Gets or sets the action required.
		/// </summary>
		public ActionType Action
		{
			get { return fAction; }
			set { fAction = value; }
		}
		ActionType fAction = ActionType.Standard;

		/// <summary>
		/// Gets or sets the range of the trap.
		/// </summary>
		public string Range
		{
			get { return fRange; }
			set { fRange = value; }
		}
		string fRange = "";

		/// <summary>
		/// Gets or sets the trap attack keywords.
		/// </summary>
		public string Keywords
		{
			get { return fKeywords; }
			set { fKeywords = value; }
		}
		string fKeywords = "";

		/// <summary>
		/// Gets or sets the trap target.
		/// </summary>
		public string Target
		{
			get { return fTarget; }
			set { fTarget = value; }
		}
		string fTarget = "";

		/// <summary>
		/// Gets or sets a value indicating whether the trap has an initiative score.
		/// </summary>
		public bool HasInitiative
		{
			get { return fHasInitiative; }
			set { fHasInitiative = value; }
		}
		bool fHasInitiative = false;

		/// <summary>
		/// Gets or sets the trap's initiative bonus.
		/// </summary>
		public int Initiative
		{
			get { return fInitiative; }
			set { fInitiative = value; }
		}
		int fInitiative = 0;

		/// <summary>
		/// Gets or sets the attack bonus and targeted defence.
		/// </summary>
		public PowerAttack Attack
		{
			get { return fAttack; }
			set { fAttack = value; }
		}
		PowerAttack fAttack = new PowerAttack();

		/// <summary>
		/// Gets or sets the Hit details.
		/// </summary>
		public string OnHit
		{
			get { return fOnHit; }
			set { fOnHit = value; }
		}
		string fOnHit = "";

		/// <summary>
		/// Gets or sets the Miss details.
		/// </summary>
		public string OnMiss
		{
			get { return fOnMiss; }
			set { fOnMiss = value; }
		}
		string fOnMiss = "";

		/// <summary>
		/// Gets or sets the Effect details.
		/// </summary>
		public string Effect
		{
			get { return fEffect; }
			set { fEffect = value; }
		}
		string fEffect = "";

		/// <summary>
		/// Gets or sets the trap attack miscellaneous notes.
		/// </summary>
		public string Notes
		{
			get { return fNotes; }
			set { fNotes = value; }
		}
		string fNotes = "";

		/// <summary>
		/// Creates a copy of the TrapAttack object.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public TrapAttack Copy()
		{
			TrapAttack ta = new TrapAttack();

			ta.ID = fID;
			ta.Name = fName;
			ta.Trigger = fTrigger;
			ta.Action = fAction;
			ta.Keywords = fKeywords;
			ta.Range = fRange;
			ta.Target = fTarget;
			ta.HasInitiative = fHasInitiative;
			ta.Initiative = fInitiative;
			ta.Attack = fAttack.Copy();
			ta.OnHit = fOnHit;
			ta.OnMiss = fOnMiss;
			ta.Effect = fEffect;
			ta.Notes = fNotes;

			return ta;
		}
	}

	/// <summary>
	/// Wrapper class to enable traps to be added to plot points.
	/// </summary>
	[Serializable]
	public class TrapElement : IElement
	{
		/// <summary>
		/// Gets or sets the trap.
		/// </summary>
		public Trap Trap
		{
			get { return fTrap; }
			set { fTrap = value; }
		}
		Trap fTrap = new Trap();

        /// <summary>
        /// Gets or sets the ID of the map containing the trap.
        /// </summary>
        public Guid MapID
        {
            get { return fMapID; }
            set { fMapID = value; }
        }
        Guid fMapID = Guid.Empty;

        /// <summary>
        /// Gets or sets the ID of the map area containing the trap.
        /// </summary>
        public Guid MapAreaID
        {
            get { return fMapAreaID; }
            set { fMapAreaID = value; }
        }
        Guid fMapAreaID = Guid.Empty;

		/// <summary>
		/// Calculates the XP value of the trap.
		/// </summary>
		/// <returns>Returns the XP value.</returns>
		public int GetXP()
		{
			return fTrap.XP;
		}

		/// <summary>
		/// Calculates the difficulty of the trap.
		/// </summary>
		/// <param name="party_level">The party level.</param>
		/// <param name="party_size">The party size.</param>
		/// <returns>Returns the difficulty.</returns>
		public Difficulty GetDifficulty(int party_level, int party_size)
		{
			return AI.GetThreatDifficulty(fTrap.Level, party_level);
		}

		/// <summary>
		/// Creates a copy of the TrapElement.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public IElement Copy()
		{
			TrapElement te = new TrapElement();

			te.Trap = fTrap.Copy();
            te.MapID = fMapID;
            te.MapAreaID = fMapAreaID;

			return te;
		}
	}
}
