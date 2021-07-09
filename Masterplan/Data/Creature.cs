using System;
using System.Collections.Generic;
using System.Drawing;

using Masterplan.Tools;

namespace Masterplan.Data
{
	/// <summary>
	/// Enumeration containing the various string fields.
	/// </summary>
	enum DetailsField
	{
		None,
		Senses,
		Movement,
		Resist,
		Vulnerable,
		Immune,
		Alignment,
		Languages,
		Skills,
		Equipment,
		Description,
		Tactics
	}

	/// <summary>
	/// Class representing a creature.
	/// </summary>
	[Serializable]
	public class Creature : ICreature
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public Creature()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="c">The creature to copy from.</param>
		public Creature(ICreature c)
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
					return Creature.GetSpeed(fSize) + " squares";
				else
					return fMovement;
			}
			set { fMovement = value; }
		}
		string fMovement = "6";

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
		/// Gets or sets the category.
		/// </summary>
		public string Category
		{
			get { return fCategory; }
			set { fCategory = value; }
		}
		string fCategory = "";

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

		/// <summary>
		/// Gets or sets the HP total.
		/// </summary>
		public int HP
		{
			get { return fHP; }
			set { fHP = value; }
		}
		int fHP = 0;

		/// <summary>
		/// Gets or sets the initiative bonus.
		/// </summary>
		public int Initiative
		{
			get { return fInitiative; }
			set { fInitiative = value; }
		}
		int fInitiative = 0;

		#region Defences

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
					str += " magical beast";
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
		/// <returns>Returns the name of the creature, followed by level and role.</returns>
		public override string ToString()
		{
			return fName + " (" + Info + ")";
		}

		/// <summary>
		/// Creates a copy of the creature.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public Creature Copy()
		{
			Creature c = new Creature();

			c.ID = fID;
			c.Name = fName;
			c.Details = fDetails;
			c.Size = fSize;
			c.Origin = fOrigin;
			c.Type = fType;
			c.Keywords = fKeywords;
			c.Level = fLevel;
			c.Role = fRole.Copy();
			c.Senses = fSenses;
			c.Movement = fMovement;
			c.Alignment = fAlignment;
			c.Languages = fLanguages;
			c.Skills = fSkills;
			c.Equipment = fEquipment;
			c.Category = fCategory;

			c.Strength = fStrength.Copy();
			c.Constitution = fConstitution.Copy();
			c.Dexterity = fDexterity.Copy();
			c.Intelligence = fIntelligence.Copy();
			c.Wisdom = fWisdom.Copy();
			c.Charisma = fCharisma.Copy();

			c.HP = fHP;
			c.Initiative = fInitiative;
			c.AC = fAC;
			c.Fortitude = fFortitude;
			c.Reflex = fReflex;
			c.Will = fWill;

			c.Regeneration = (fRegeneration != null) ? fRegeneration.Copy() : null;

			foreach (Aura aura in fAuras)
				c.Auras.Add(aura.Copy());

			foreach (CreaturePower cp in fCreaturePowers)
				c.CreaturePowers.Add(cp.Copy());

			foreach (DamageModifier dm in fDamageModifiers)
				c.DamageModifiers.Add(dm.Copy());

			c.Resist = fResist;
			c.Vulnerable = fVulnerable;
			c.Immune = fImmune;
			c.Tactics = fTactics;

			c.Image = fImage;

			return c;
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

		/// <summary>
		/// Gets the square size of a creature of the given size.
		/// </summary>
		/// <param name="size">The creature size.</param>
		/// <returns>Returns the size in squares.</returns>
		public static int GetSize(CreatureSize size)
		{
			switch (size)
			{
				case CreatureSize.Large:
					return 2;
				case CreatureSize.Huge:
					return 3;
				case CreatureSize.Gargantuan:
					return 4;
			}

			return 1;
		}

		/// <summary>
		/// Gets the typical speed of a creature of the given size.
		/// </summary>
		/// <param name="size">The creature size.</param>
		/// <returns>Returns the spee din squares.</returns>
		public static int GetSpeed(CreatureSize size)
		{
			switch (size)
			{
				case CreatureSize.Tiny:
				case CreatureSize.Small:
					return 4;
				case CreatureSize.Medium:
					return 6;
				case CreatureSize.Large:
					return 6;
				case CreatureSize.Huge:
					return 8;
				case CreatureSize.Gargantuan:
					return 10;
			}

			return 6;
		}
	}
}
