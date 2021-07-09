using System;
using System.Collections.Generic;
using System.Drawing;

namespace Masterplan.Data
{
	/// <summary>
	/// The various hero roles.
	/// </summary>
	public enum HeroRoleType
	{
		/// <summary>
		/// Controller role.
		/// </summary>
		Controller,
		
		/// <summary>
		/// Defender role.
		/// </summary>
		Defender,
		
		/// <summary>
		/// Leader role.
		/// </summary>
		Leader,
		
		/// <summary>
		/// Striker role.
		/// </summary>
		Striker,

		/// <summary>
		/// Hybrid role.
		/// </summary>
		Hybrid
	}

	/// <summary>
	/// Class representing a PC.
	/// </summary>
	[Serializable]
	public class Hero : IToken, IComparable<Hero>
	{
		/// <summary>
		/// Gets or sets the unique ID of the hero.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set
			{
				fID = value;

				if (fCombatData != null)
					fCombatData.ID = value;
			}
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the name of the hero.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set
			{
				fName = value;

				if (fCombatData != null)
					fCombatData.DisplayName = value;
			}
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the player name.
		/// </summary>
		public string Player
		{
			get { return fPlayer; }
			set { fPlayer = value; }
		}
		string fPlayer = "";

		/// <summary>
		/// Gets or sets the size of the PC.
		/// </summary>
		public CreatureSize Size
		{
			get { return fSize; }
			set { fSize = value; }
		}
		CreatureSize fSize = CreatureSize.Medium;

		/// <summary>
		/// Gets or sets the name of the PC's race.
		/// </summary>
		public string Race
		{
			get { return fRace; }
			set { fRace = value; }
		}
		string fRace = "";

		/// <summary>
		/// Gets or sets the PC's level.
		/// </summary>
		public int Level
		{
			get { return fLevel; }
			set { fLevel = value; }
		}
		int fLevel = Session.Project.Party.Level;

		/// <summary>
		/// Gets or sets the name of the PC's class.
		/// </summary>
		public string Class
		{
			get { return fClass; }
			set { fClass = value; }
		}
		string fClass = "";

		/// <summary>
		/// Gets or sets the name of the PC's paragon path.
		/// </summary>
		public string ParagonPath
		{
			get { return fParagonPath; }
			set { fParagonPath = value; }
		}
		string fParagonPath = "";

		/// <summary>
		/// Gets or sets the name of the PC's epic destiny.
		/// </summary>
		public string EpicDestiny
		{
			get { return fEpicDestiny; }
			set { fEpicDestiny = value; }
		}
		string fEpicDestiny = "";

		/// <summary>
		/// Gets or sets the power source of the PC's class.
		/// </summary>
		public string PowerSource
		{
			get { return fPowerSource; }
			set { fPowerSource = value; }
		}
		string fPowerSource = "";

		/// <summary>
		/// Gets or sets the PC's role.
		/// </summary>
		public HeroRoleType Role
		{
			get { return fRole; }
			set { fRole = value; }
		}
		HeroRoleType fRole = HeroRoleType.Controller;

		/// <summary>
		/// Gets or sets the hero's combat data.
		/// </summary>
		public CombatData CombatData
		{
			get { return fCombatData; }
			set
			{
				fCombatData = value;
				fCombatData.ID = fID;
				fCombatData.DisplayName = fName;
			}
		}
		CombatData fCombatData = new CombatData();

		/// <summary>
		/// Gets or sets the hero's hit points.
		/// </summary>
		public int HP
		{
			get { return fHP; }
			set { fHP = value; }
		}
		int fHP = 0;

		/// <summary>
		/// Gets or sets the AC defence.
		/// </summary>
		public int AC
		{
			get { return fAC; }
			set { fAC = value; }
		}
		int fAC = 10;

		/// <summary>
		/// Gets or sets the Fortitude defence.
		/// </summary>
		public int Fortitude
		{
			get { return fFortitude; }
			set { fFortitude = value; }
		}
		int fFortitude = 10;

		/// <summary>
		/// Gets or sets the Reflex defence.
		/// </summary>
		public int Reflex
		{
			get { return fReflex; }
			set { fReflex = value; }
		}
		int fReflex = 10;

		/// <summary>
		/// Gets or sets the Will defence.
		/// </summary>
		public int Will
		{
			get { return fWill; }
			set { fWill = value; }
		}
		int fWill = 10;

		/// <summary>
		/// Gets or sets the hero's initiative bonus
		/// </summary>
		public int InitBonus
		{
			get { return fInitBonus; }
			set { fInitBonus = value; }
		}
		int fInitBonus = 0;

		/// <summary>
		/// Gets or sets the PC's passive perception.
		/// </summary>
		public int PassivePerception
		{
			get { return fPassivePerception; }
			set { fPassivePerception = value; }
		}
		int fPassivePerception = 10;

		/// <summary>
		/// Gets or sets the PC's passive insight.
		/// </summary>
		public int PassiveInsight
		{
			get { return fPassiveInsight; }
			set { fPassiveInsight = value; }
		}
		int fPassiveInsight = 10;

		/// <summary>
		/// Gets or sets the languages spoken by the hero.
		/// </summary>
		public string Languages
		{
			get { return fLanguages; }
			set { fLanguages = value; }
		}
		string fLanguages = "";

		/// <summary>
		/// Gets or sets the set of ongoing effects this character can impose in combat.
		/// </summary>
		public List<OngoingCondition> Effects
		{
			get { return fEffects; }
			set { fEffects = value; }
		}
		List<OngoingCondition> fEffects = new List<OngoingCondition>();

		/// <summary>
		/// Gets or sets the set of map tokens and overlays the character can use in combat.
		/// </summary>
		public List<CustomToken> Tokens
		{
			get { return fTokens; }
			set { fTokens = value; }
		}
		List<CustomToken> fTokens = new List<CustomToken>();

		/// <summary>
		/// Level [N] [race] [class] / [paragon path] / [epic destiny]
		/// </summary>
		public string Info
		{
			get
			{
				string str = "Level " + fLevel;

				if (fRace != "")
				{
					if (str != "")
						str += " ";

					str += fRace;
				}

				if (fClass != "")
				{
					if (str != "")
						str += " ";

					str += fClass;
				}

				if (fParagonPath != "")
				{
					if (str != "")
						str += " / ";

					str += fParagonPath;
				}

				if (fEpicDestiny != "")
				{
					if (str != "")
						str += " / ";

					str += fEpicDestiny;
				}

				return str;
			}
		}

		/// <summary>
		/// Gets or sets the PC's portrait image.
		/// </summary>
		public Image Portrait
		{
			get { return fPortrait; }
			set { fPortrait = value; }
		}
		Image fPortrait = null;

		/// <summary>
		/// Calculates the hero's current state.
		/// </summary>
		/// <param name="damage">The hero's current damage.</param>
		/// <returns>Returns the hero's state.</returns>
		public CreatureState GetState(int damage)
		{
			if (fHP != 0)
			{
				int hp_current = fHP - damage;
				int hp_bloodied = fHP / 2;

				if (hp_current <= 0)
					return CreatureState.Defeated;
				else if (hp_current <= hp_bloodied)
					return CreatureState.Bloodied;
			}

			return CreatureState.Active;
		}

		/// <summary>
		/// Creates a copy of the Hero.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public Hero Copy()
		{
			Hero h = new Hero();

			h.ID = fID;
			h.Name = fName;
			h.Player = fPlayer;
			h.Size = fSize;
			h.Race = fRace;
			h.Level = fLevel;
			h.Class = fClass;
			h.ParagonPath = fParagonPath;
			h.EpicDestiny = fEpicDestiny;
			h.PowerSource = fPowerSource;
			h.Role = fRole;
			h.CombatData = fCombatData.Copy();
			h.HP = fHP;
			h.AC = fAC;
			h.Fortitude = fFortitude;
			h.Reflex = fReflex;
			h.Will = fWill;
			h.InitBonus = fInitBonus;
			h.PassivePerception = fPassivePerception;
			h.PassiveInsight = fPassiveInsight;
			h.Languages = fLanguages;
			h.Portrait = fPortrait;

			foreach (OngoingCondition oc in fEffects)
				h.Effects.Add(oc.Copy());

			foreach (CustomToken ct in fTokens)
				h.Tokens.Add(ct.Copy());

			return h;
		}

		/// <summary>
		/// Compares this Hero to another.
		/// </summary>
		/// <param name="rhs">The other Hero object.</param>
		/// <returns>Returns -1 if this Hero should be sorted before rhs, +1 if rhs should be sorted before this, 0 otherwise.</returns>
		public int CompareTo(Hero rhs)
		{
			return fName.CompareTo(rhs.Name);
		}

		/// <summary>
		/// Returns the hero's name.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return fName;
		}
	}
}
