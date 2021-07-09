using System;
using System.Collections.Generic;
using System.Drawing;

namespace Masterplan.Data
{
	/// <summary>
	/// Class representing an NPC.
	/// </summary>
	[Serializable]
	public class NPC : ICreature
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
		/// Gets or sets the ID of the template.
		/// </summary>
		public Guid TemplateID
		{
			get { return fTemplateID; }
			set { fTemplateID = value; }
		}
		Guid fTemplateID = Guid.Empty;

		/// <summary>
		/// Gets the role.
		/// </summary>
		public IRole Role
		{
			get
			{
				CreatureTemplate ct = Session.FindTemplate(fTemplateID, SearchType.Global);
				if (ct != null)
				{
					ComplexRole cr = new ComplexRole();
					cr.Type = ct.Role;
					cr.Leader = ct.Leader;

					return cr;
				}

				return null;
			}
			set { }
		}

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
			get { return "NPCs"; }
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
				int score = (fLevel / 2) + fDexterity.Modifier;

				CreatureTemplate ct = Session.FindTemplate(fTemplateID, SearchType.Global);
				if (ct != null)
					score += ct.Initiative;

				return score + fInitiativeModifier;
			}

			set
			{
				int score = (fLevel / 2) + fDexterity.Modifier;

				CreatureTemplate ct = Session.FindTemplate(fTemplateID, SearchType.Global);
				if (ct != null)
					score += ct.Initiative;

				fInitiativeModifier = value - score;
			}
		}

		/// <summary>
		/// Gets the HP total.
		/// </summary>
		public int HP
		{
			get
			{
				CreatureTemplate ct = Session.FindTemplate(fTemplateID, SearchType.Global);
				if (ct != null)
				{
					int hp = fConstitution.Score;
					hp += (fLevel + 1) * ct.HP;

					return hp + fHPModifier;
				}

				return 0;
			}
			set
			{
				CreatureTemplate ct = Session.FindTemplate(fTemplateID, SearchType.Global);
				if (ct != null)
				{
					int hp = fConstitution.Score;
					hp += (fLevel + 1) * ct.HP;

					fHPModifier = value - hp;
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
				int defence = 10 + (fLevel / 2);

				Ability ab = new Ability();
				ab.Score = Math.Max(fDexterity.Score, fIntelligence.Score);
				defence += ab.Modifier;

				CreatureTemplate ct = Session.FindTemplate(fTemplateID, SearchType.Global);
				if (ct != null)
					defence += ct.AC;

				return defence + fACModifier;
			}
			set
			{
				int defence = 10 + (fLevel / 2);

				Ability ab = new Ability();
				ab.Score = Math.Max(fDexterity.Score, fIntelligence.Score);
				defence += ab.Modifier;

				CreatureTemplate ct = Session.FindTemplate(fTemplateID, SearchType.Global);
				if (ct != null)
					defence += ct.AC;

				fACModifier = value - defence;
			}
		}

		/// <summary>
		/// Gets the Fortitude defence.
		/// </summary>
		public int Fortitude
		{
			get
			{
				int defence = 10 + (fLevel / 2);

				Ability ab = new Ability();
				ab.Score = Math.Max(fStrength.Score, fConstitution.Score);
				defence += ab.Modifier;

				CreatureTemplate ct = Session.FindTemplate(fTemplateID, SearchType.Global);
				if (ct != null)
					defence += ct.Fortitude;

				return defence + fFortitudeModifier;
			}
			set
			{
				int defence = 10 + (fLevel / 2);

				Ability ab = new Ability();
				ab.Score = Math.Max(fStrength.Score, fConstitution.Score);
				defence += ab.Modifier;

				CreatureTemplate ct = Session.FindTemplate(fTemplateID, SearchType.Global);
				if (ct != null)
					defence += ct.Fortitude;

				fFortitudeModifier = value - defence;
			}
		}

		/// <summary>
		/// Gets the Reflex defence.
		/// </summary>
		public int Reflex
		{
			get
			{
				int defence = 10 + (fLevel / 2);

				Ability ab = new Ability();
				ab.Score = Math.Max(fDexterity.Score, fIntelligence.Score);
				defence += ab.Modifier;

				CreatureTemplate ct = Session.FindTemplate(fTemplateID, SearchType.Global);
				if (ct != null)
					defence += ct.Reflex;

				return defence + fReflexModifier;
			}
			set
			{
				int defence = 10 + (fLevel / 2);

				Ability ab = new Ability();
				ab.Score = Math.Max(fDexterity.Score, fIntelligence.Score);
				defence += ab.Modifier;

				CreatureTemplate ct = Session.FindTemplate(fTemplateID, SearchType.Global);
				if (ct != null)
					defence += ct.Reflex;

				fReflexModifier = value - defence;
			}
		}

		/// <summary>
		/// Gets the Will defence.
		/// </summary>
		public int Will
		{
			get
			{
				int defence = 10 + (fLevel / 2);

				Ability ab = new Ability();
				ab.Score = Math.Max(fWisdom.Score, fCharisma.Score);
				defence += ab.Modifier;

				CreatureTemplate ct = Session.FindTemplate(fTemplateID, SearchType.Global);
				if (ct != null)
					defence += ct.Will;

				return defence + fWillModifier;
			}
			set
			{
				int defence = 10 + (fLevel / 2);

				Ability ab = new Ability();
				ab.Score = Math.Max(fWisdom.Score, fCharisma.Score);
				defence += ab.Modifier;

				CreatureTemplate ct = Session.FindTemplate(fTemplateID, SearchType.Global);
				if (ct != null)
					defence += ct.Will;

				fWillModifier = value - defence;
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
            get { return "Level " + fLevel + " " + Role; }
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
		/// Gets the point-buy cost of the NPC's ability scores.
		/// </summary>
		public int AbilityCost
		{
			get
			{
				int total = 0;
				int count_below_10 = 0;
				int min = 10;

				total += fStrength.Cost;
				if (fStrength.Score < 10)
					count_below_10 += 1;
				if (fStrength.Score < min)
					min = fStrength.Score;

				total += fConstitution.Cost;
				if (fConstitution.Score < 10)
					count_below_10 += 1;
				if (fConstitution.Score < min)
					min = fConstitution.Score;

				total += fDexterity.Cost;
				if (fDexterity.Score < 10)
					count_below_10 += 1;
				if (fDexterity.Score < min)
					min = fDexterity.Score;

				total += fIntelligence.Cost;
				if (fIntelligence.Score < 10)
					count_below_10 += 1;
				if (fIntelligence.Score < min)
					min = fIntelligence.Score;

				total += fWisdom.Cost;
				if (fWisdom.Score < 10)
					count_below_10 += 1;
				if (fWisdom.Score < min)
					min = fWisdom.Score;

				total += fCharisma.Cost;
				if (fCharisma.Score < 10)
					count_below_10 += 1;
				if (fCharisma.Score < min)
					min = fCharisma.Score;

				if (count_below_10 > 1)
					return -1;

				if (min < 8)
					return -1;

				if (min == 9)
					total += 1;

				if (min > 9)
					total += 2;

				return total;
			}
		}

		/// <summary>
		/// Gets a string representation of the NPC.
		/// </summary>
		/// <returns>Returns the name of the NPC.</returns>
		public override string ToString()
		{
			return fName;
		}

		/// <summary>
		/// Creates a copy of the NPC.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public NPC Copy()
		{
			NPC npc = new NPC();

			npc.ID = fID;
			npc.Name = fName;
			npc.Details = fDetails;
			npc.Size = fSize;
			npc.Origin = fOrigin;
			npc.Type = fType;
			npc.Keywords = fKeywords;
			npc.Level = fLevel;
			npc.TemplateID = fTemplateID;
			npc.Senses = fSenses;
			npc.Movement = fMovement;
			npc.Alignment = fAlignment;
			npc.Languages = fLanguages;
			npc.Skills = fSkills;
			npc.Equipment = fEquipment;

			npc.Strength = fStrength.Copy();
			npc.Constitution = fConstitution.Copy();
			npc.Dexterity = fDexterity.Copy();
			npc.Intelligence = fIntelligence.Copy();
			npc.Wisdom = fWisdom.Copy();
			npc.Charisma = fCharisma.Copy();

			npc.InitiativeModifier = fInitiativeModifier;
			npc.HPModifier = fHPModifier;
			npc.ACModifier = fACModifier;
			npc.FortitudeModifier = fFortitudeModifier;
			npc.ReflexModifier = fReflexModifier;
			npc.WillModifier = fWillModifier;

			npc.Regeneration = (fRegeneration != null) ? fRegeneration.Copy() : null;

			foreach (Aura aura in fAuras)
				npc.Auras.Add(aura.Copy());

			foreach (CreaturePower cp in fCreaturePowers)
				npc.CreaturePowers.Add(cp.Copy());

			foreach (DamageModifier dm in fDamageModifiers)
				npc.DamageModifiers.Add(dm.Copy());

			npc.Resist = fResist;
			npc.Vulnerable = fVulnerable;
			npc.Immune = fImmune;
			npc.Tactics = fTactics;

			npc.Image = fImage;

			return npc;
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
