using System;
using System.Collections.Generic;
using System.Drawing;

using Masterplan.Tools;

namespace Masterplan.Data
{
	/// <summary>
	/// Class representing a custom creature.
	/// </summary>
	[Serializable]
	public class CustomCreature : ICreature
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		public CustomCreature()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="c">The creature to copy from.</param>
		public CustomCreature(ICreature c)
		{
			CreatureHelper.CopyFields(c, this);
		}

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
		/// Gets or sets the name.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the details.
		/// </summary>
		public string Details
		{
			get { return fDetails; }
			set { fDetails = value; }
		}
		string fDetails = "";

		/// <summary>
		/// Gets or sets the size.
		/// </summary>
		public CreatureSize Size
		{
			get { return fSize; }
			set { fSize = value; }
		}
		CreatureSize fSize = CreatureSize.Medium;

		/// <summary>
		/// Gets or sets the creature origin.
		/// </summary>
		public CreatureOrigin Origin
		{
			get { return fOrigin; }
			set { fOrigin = value; }
		}
		CreatureOrigin fOrigin = CreatureOrigin.Natural;

		/// <summary>
		/// Gets or sets the creature type.
		/// </summary>
		public CreatureType Type
		{
			get { return fType; }
			set { fType = value; }
		}
		CreatureType fType = CreatureType.MagicalBeast;

		/// <summary>
		/// Gets or sets the creature keywords.
		/// </summary>
		public string Keywords
		{
			get { return fKeywords; }
			set { fKeywords = value; }
		}
		string fKeywords = "";

		/// <summary>
		/// Gets or sets the level.
		/// </summary>
		public int Level
		{
			get { return fLevel; }
			set { fLevel = value; }
		}
		int fLevel = 1;

		/// <summary>
		/// Gets or sets the role.
		/// </summary>
		public IRole Role
		{
			get { return fRole; }
			set { fRole = value; }
		}
		IRole fRole = new ComplexRole();

		/// <summary>
		/// Gets or sets the senses.
		/// </summary>
		public string Senses
		{
			get { return fSenses; }
			set { fSenses = value; }
		}
		string fSenses = "";

		/// <summary>
		/// Gets or sets the movement.
		/// </summary>
		public string Movement
		{
			get
			{
				if ((fMovement == null) || (fMovement == ""))
					return Creature.GetSpeed(fSize) + " " + Session.I18N.Squares;
				else
					return fMovement;
			}
			set { fMovement = value; }
		}
		string fMovement = "";

		/// <summary>
		/// Gets or sets the alignment.
		/// </summary>
		public string Alignment
		{
			get { return fAlignment; }
			set { fAlignment = value; }
		}
		string fAlignment = "";

		/// <summary>
		/// Gets or sets the languages.
		/// </summary>
		public string Languages
		{
			get { return fLanguages; }
			set { fLanguages = value; }
		}
		string fLanguages = "";

		/// <summary>
		/// Gets or sets the skills.
		/// </summary>
		public string Skills
		{
			get { return fSkills; }
			set { fSkills = value; }
		}
		string fSkills = "";

		/// <summary>
		/// Gets or sets the equipment.
		/// </summary>
		public string Equipment
		{
			get { return fEquipment; }
			set { fEquipment = value; }
		}
		string fEquipment = "";

		/// <summary>
		/// Gets the category.
		/// </summary>
		public string Category
		{
			get { return ""; }
			set { }
		}

		#region Abilities

		/// <summary>
		/// Gets or sets the strength ability.
		/// </summary>
		public Ability Strength
		{
			get { return fStrength; }
			set { fStrength = value; }
		}
		Ability fStrength = new Ability();

		/// <summary>
		/// Gets or sets the constitution ability.
		/// </summary>
		public Ability Constitution
		{
			get { return fConstitution; }
			set { fConstitution = value; }
		}
		Ability fConstitution = new Ability();

		/// <summary>
		/// Gets or sets the dexterity ability.
		/// </summary>
		public Ability Dexterity
		{
			get { return fDexterity; }
			set { fDexterity = value; }
		}
		Ability fDexterity = new Ability();

		/// <summary>
		/// Gets or sets the intelligence ability.
		/// </summary>
		public Ability Intelligence
		{
			get { return fIntelligence; }
			set { fIntelligence = value; }
		}
		Ability fIntelligence = new Ability();

		/// <summary>
		/// Gets or sets the wisdom ability.
		/// </summary>
		public Ability Wisdom
		{
			get { return fWisdom; }
			set { fWisdom = value; }
		}
		Ability fWisdom = new Ability();

		/// <summary>
		/// Gets or sets the charisma ability.
		/// </summary>
		public Ability Charisma
		{
			get { return fCharisma; }
			set { fCharisma = value; }
		}
		Ability fCharisma = new Ability();

		#endregion

		#region Generated properties

		/// <summary>
		/// Gets the initiative bonus.
		/// </summary>
		public int Initiative
		{
			get
			{
				int basic = Statistics.Initiative(fLevel, fRole);
				return basic + fDexterity.Modifier + fInitiativeModifier;
			}
			set
			{
				int basic = Statistics.Initiative(fLevel, fRole);
				fInitiativeModifier = value - basic - fDexterity.Modifier;
			}
		}

		/// <summary>
		/// Gets the HP total.
		/// </summary>
		public int HP
		{
			get
			{
				if (fRole is Minion)
				{
					return 1;
				}
				else
				{
					int basic = Statistics.HP(fLevel, fRole as ComplexRole, fConstitution.Score);
					return basic + fHPModifier;
				}
			}
			set
			{
				if (fRole is Minion)
				{
					// Do nothing
				}
				else
				{
					int basic = Statistics.HP(fLevel, fRole as ComplexRole, fConstitution.Score);
					fHPModifier = value - basic;
				}
			}
		}

		/// <summary>
		/// Gets the AC defence.
		/// </summary>
		public int AC
		{
			get
			{
				int ac = Statistics.AC(fLevel, fRole);
				return ac + fACModifier;
			}
			set
			{
				int ac = Statistics.AC(fLevel, fRole);
				fACModifier = value - ac;
			}
		}

		/// <summary>
		/// Gets the Fortitude defence.
		/// </summary>
		public int Fortitude
		{
			get
			{
				int defence = Statistics.NAD(fLevel, fRole);
				int score = Math.Max(fStrength.Score, fConstitution.Score);
				int mod = Ability.GetModifier(score);

				return defence + mod + fFortitudeModifier;
			}
			set
			{
				int defence = Statistics.NAD(fLevel, fRole);
				int score = Math.Max(fStrength.Score, fConstitution.Score);
				int mod = Ability.GetModifier(score);

				fFortitudeModifier = value - defence - mod;
			}
		}

		/// <summary>
		/// Gets the Reflex defence.
		/// </summary>
		public int Reflex
		{
			get
			{
				int defence = Statistics.NAD(fLevel, fRole);
				int score = Math.Max(fDexterity.Score, fIntelligence.Score);
				int mod = Ability.GetModifier(score);

				return defence + mod + fReflexModifier;
			}
			set
			{
				int defence = Statistics.NAD(fLevel, fRole);
				int score = Math.Max(fDexterity.Score, fIntelligence.Score);
				int mod = Ability.GetModifier(score);

				fReflexModifier = value - defence - mod;
			}
		}

		/// <summary>
		/// Gets the Will defence.
		/// </summary>
		public int Will
		{
			get
			{
				int defence = Statistics.NAD(fLevel, fRole);
				int score = Math.Max(fWisdom.Score, fCharisma.Score);
				int mod = Ability.GetModifier(score);

				return defence + mod + fWillModifier;
			}
			set
			{
				int defence = Statistics.NAD(fLevel, fRole);
				int score = Math.Max(fWisdom.Score, fCharisma.Score);
				int mod = Ability.GetModifier(score);

				fWillModifier = value - defence - mod;
			}
		}

		#endregion

		#region Modifiers

		/// <summary>
		/// Gets or sets the modifier for the initiative bonus.
		/// </summary>
		public int InitiativeModifier
		{
			get { return fInitiativeModifier; }
			set { fInitiativeModifier = value; }
		}
		int fInitiativeModifier = 0;

		/// <summary>
		/// Gets or sets the modifier for the HP total.
		/// </summary>
		public int HPModifier
		{
			get { return fHPModifier; }
			set { fHPModifier = value; }
		}
		int fHPModifier = 0;

		/// <summary>
		/// Gets or sets the modifier for the AC defence.
		/// </summary>
		public int ACModifier
		{
			get { return fACModifier; }
			set { fACModifier = value; }
		}
		int fACModifier = 0;

		/// <summary>
		/// Gets or sets the modifier for the Fortitude defence.
		/// </summary>
		public int FortitudeModifier
		{
			get { return fFortitudeModifier; }
			set { fFortitudeModifier = value; }
		}
		int fFortitudeModifier = 0;

		/// <summary>
		/// Gets or sets the modifier for the Reflex defence.
		/// </summary>
		public int ReflexModifier
		{
			get { return fReflexModifier; }
			set { fReflexModifier = value; }
		}
		int fReflexModifier = 0;

		/// <summary>
		/// Gets or sets the modifier for the Will defence.
		/// </summary>
		public int WillModifier
		{
			get { return fWillModifier; }
			set { fWillModifier = value; }
		}
		int fWillModifier = 0;

		#endregion

		/// <summary>
		/// Gets or sets the creature's regeneration.
		/// </summary>
		public Regeneration Regeneration
		{
			get { return fRegeneration; }
			set { fRegeneration = value; }
		}
		Regeneration fRegeneration = null;

		/// <summary>
		/// Gets or sets the list of auras.
		/// </summary>
		public List<Aura> Auras
		{
			get { return fAuras; }
			set { fAuras = value; }
		}
		List<Aura> fAuras = new List<Aura>();

		/// <summary>
		/// Gets or sets the list of powers.
		/// </summary>
		public List<CreaturePower> CreaturePowers
		{
			get { return fCreaturePowers; }
			set { fCreaturePowers = value; }
		}
		List<CreaturePower> fCreaturePowers = new List<CreaturePower>();

		/// <summary>
		/// Gets or sets the list of damage modifiers.
		/// </summary>
		public List<DamageModifier> DamageModifiers
		{
			get { return fDamageModifiers; }
			set { fDamageModifiers = value; }
		}
		List<DamageModifier> fDamageModifiers = new List<DamageModifier>();

		/// <summary>
		/// Gets or sets the resistances.
		/// </summary>
		public string Resist
		{
			get { return fResist; }
			set { fResist = value; }
		}
		string fResist = "";

		/// <summary>
		/// Gets or sets the vulnerabilities.
		/// </summary>
		public string Vulnerable
		{
			get { return fVulnerable; }
			set { fVulnerable = value; }
		}
		string fVulnerable = "";

		/// <summary>
		/// Gets or sets the immunities.
		/// </summary>
		public string Immune
		{
			get { return fImmune; }
			set { fImmune = value; }
		}
		string fImmune = "";

		/// <summary>
		/// Gets or sets the tactics.
		/// </summary>
		public string Tactics
		{
			get { return fTactics; }
			set { fTactics = value; }
		}
		string fTactics = "";

		/// <summary>
		/// Gets or sets the picture to display on the map.
		/// </summary>
		public Image Image
		{
			get { return fImage; }
			set { fImage = value; }
		}
		Image fImage = null;

		/// <summary>
		/// Level N [role]
		/// </summary>
		public string Info
		{
			get { return "Level " + fLevel + " " + fRole; }
		}

        /// <summary>
        /// [origin] [type] [keywords]
        /// </summary>
        public string Phenotype
        {
            get
            {
				string str = fSize + " " + fOrigin.ToString().ToLower();

				if (fType == CreatureType.MagicalBeast)
					str += " " + Session.I18N.MagicalBeast;
				else
					str += " " + fType.ToString().ToLower();

				if ((fKeywords != null) && (fKeywords != ""))
					str += " (" + fKeywords.ToLower() + ")";

				return str;
			}
        }

		/// <summary>
		/// Gets a string representation of the creature.
		/// </summary>
		/// <returns>Returns the name of the creature.</returns>
		public override string ToString()
		{
			return fName;
		}

		/// <summary>
		/// Creates a copy of the creature.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public CustomCreature Copy()
		{
			CustomCreature cc = new CustomCreature();

			cc.ID = fID;
			cc.Name = fName;
			cc.Details = fDetails;
			cc.Size = fSize;
			cc.Origin = fOrigin;
			cc.Type = fType;
			cc.Keywords = fKeywords;
			cc.Level = fLevel;
			cc.Role = fRole.Copy();
			cc.Senses = fSenses;
			cc.Movement = fMovement;
			cc.Alignment = fAlignment;
			cc.Languages = fLanguages;
			cc.Skills = fSkills;
			cc.Equipment = fEquipment;

			cc.Strength = fStrength.Copy();
			cc.Constitution = fConstitution.Copy();
			cc.Dexterity = fDexterity.Copy();
			cc.Intelligence = fIntelligence.Copy();
			cc.Wisdom = fWisdom.Copy();
			cc.Charisma = fCharisma.Copy();

			cc.InitiativeModifier = fInitiativeModifier;
			cc.HPModifier = fHPModifier;
			cc.ACModifier = fACModifier;
			cc.FortitudeModifier = fFortitudeModifier;
			cc.ReflexModifier = fReflexModifier;
			cc.WillModifier = fWillModifier;

			cc.Regeneration = (fRegeneration != null) ? fRegeneration.Copy() : null;

			foreach (Aura aura in fAuras)
				cc.Auras.Add(aura.Copy());

			foreach (CreaturePower cp in fCreaturePowers)
				cc.CreaturePowers.Add(cp.Copy());

			foreach (DamageModifier dm in fDamageModifiers)
				cc.DamageModifiers.Add(dm.Copy());

			cc.Resist = fResist;
			cc.Vulnerable = fVulnerable;
			cc.Immune = fImmune;
			cc.Tactics = fTactics;

			cc.Image = fImage;

			return cc;
		}

		/// <summary>
		/// Compares this creature to another.
		/// </summary>
		/// <param name="rhs">The other creature.</param>
		/// <returns>Returns -1 if this creature should be sorted before the other, +1 if the other should be sorted before this; 0 otherwise.</returns>
		public int CompareTo(ICreature rhs)
		{
			return fName.CompareTo(rhs.Name);
		}
	}
}
