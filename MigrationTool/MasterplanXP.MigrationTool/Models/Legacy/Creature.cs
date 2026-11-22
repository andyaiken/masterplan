#nullable disable

using MasterplanXP.MigrationTool.Services.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace MasterplanXP.MigrationTool.Models.Legacy
{
    /*
     * JUNIOR DEVELOPER GUIDE:
     * This class is the primary representation of a D&D 4th Edition creature (Monster or NPC).
     * It implements ICreature, which is the common interface for all combatants.
     * 
     * Key D&D 4e Concepts:
     * - Level & Role: Defines the challenge rating and combat archetype (e.g., Brute, Controller).
     * - Phenotype: A composite description of the creature's Size, Origin (e.g., Fey), and Type (e.g., Humanoid).
     * - Defences: AC (Armor Class), Fortitude, Reflex, and Will.
     * - Ability Scores: Strength, Constitution, Dexterity, Intelligence, Wisdom, and Charisma.
     * 
     * THINNING PROCESS NOTES (MasterplanXP Migration):
     * 1. [Serializable]: Legacy attribute used for BinaryFormatter. This will be removed in favor of MessagePack DTOs in the Bridge project.
     * 2. System.Drawing.Image: GDI+ dependency. This must be replaced with byte[] or a platform-agnostic image abstraction for AvaloniaUI.
     * 3. CreatureHelper.CopyFields: Manual property copying. In MasterplanXP, use AutoMapper or the LegacyConversionService in the Bridge.
     * 4. Legacy Naming: Uses 'f' prefix for private fields (e.g., fID). New code should use '_' prefix.
     */

    /// <summary>
    /// Enumeration containing the various string fields used for detailed creature descriptions.
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
    /// Represents a creature in the Masterplan system. 
    /// This is a core data object used for encounter building and combat tracking.
    /// </summary>
    [Serializable]
    public class Creature : ICreature
    {
        /// <summary>
        /// Default constructor. Initializes a new instance of the Creature class.
        /// </summary>
        public Creature()
        {
        }

        /// <summary>
        /// Copy constructor. Initializes a new instance by copying fields from another ICreature.
        /// </summary>
        /// <param name="c">The creature to copy from.</param>
        public Creature(ICreature c)
        {
            // THINNING NOTE: This relies on CreatureHelper, which is a candidate for refactoring into a Mapper.
            CreatureHelper.CopyFields(c, this);
        }

        /// <summary>
        /// Gets or sets the unique identifier for this creature instance.
        /// </summary>
        public Guid ID
        {
            get { return fID; }
            set { fID = value; }
        }
        Guid fID = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the name of the creature (e.g., "Goblin Slasher").
        /// </summary>
        public string Name
        {
            get { return fName; }
            set { fName = value; }
        }
        string fName = "";

        /// <summary>
        /// Gets or sets general descriptive details about the creature.
        /// </summary>
        public string Details
        {
            get { return fDetails; }
            set { fDetails = value; }
        }
        string fDetails = "";

        /// <summary>
        /// Gets or sets the creature's physical size (Tiny to Gargantuan).
        /// </summary>
        public CreatureSize Size
        {
            get { return fSize; }
            set { fSize = value; }
        }
        CreatureSize fSize = CreatureSize.Medium;

        /// <summary>
        /// Gets or sets the creature's cosmic origin (e.g., Natural, Fey, Shadow).
        /// </summary>
        public CreatureOrigin Origin
        {
            get { return fOrigin; }
            set { fOrigin = value; }
        }
        CreatureOrigin fOrigin = CreatureOrigin.Natural;

        /// <summary>
        /// Gets or sets the biological/magical type (e.g., Humanoid, Beast).
        /// </summary>
        public CreatureType Type
        {
            get { return fType; }
            set { fType = value; }
        }
        CreatureType fType = CreatureType.MagicalBeast;

        /// <summary>
        /// Gets or sets any descriptive keywords (e.g., "Undead", "Fire", "Swarm").
        /// </summary>
        public string Keywords
        {
            get { return fKeywords; }
            set { fKeywords = value; }
        }
        string fKeywords = "";

        /// <summary>
        /// Gets or sets the creature's level.
        /// </summary>
        public int Level
        {
            get { return fLevel; }
            set { fLevel = value; }
        }
        int fLevel = 1;

        /// <summary>
        /// Gets or sets the combat role (e.g., Brute, Skirmisher, Elite, Solo).
        /// </summary>
        public IRole Role
        {
            get { return fRole; }
            set { fRole = value; }
        }
        IRole fRole = new ComplexRole();

        /// <summary>
        /// Gets or sets the senses and perception notes (e.g., "Darkvision", "Perception +10").
        /// </summary>
        public string Senses
        {
            get { return fSenses; }
            set { fSenses = value; }
        }
        string fSenses = "";

        /// <summary>
        /// Gets or sets the movement speed and modes.
        /// If empty, returns default speed based on size.
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
        /// Gets or sets the ethical/moral alignment.
        /// </summary>
        public string Alignment
        {
            get { return fAlignment; }
            set { fAlignment = value; }
        }
        string fAlignment = "";

        /// <summary>
        /// Gets or sets the known languages.
        /// </summary>
        public string Languages
        {
            get { return fLanguages; }
            set { fLanguages = value; }
        }
        string fLanguages = "";

        /// <summary>
        /// Gets or sets skill bonuses (e.g., "Acrobatics +12", "Stealth +15").
        /// </summary>
        public string Skills
        {
            get { return fSkills; }
            set { fSkills = value; }
        }
        string fSkills = "";

        /// <summary>
        /// Gets or sets carried equipment.
        /// </summary>
        public string Equipment
        {
            get { return fEquipment; }
            set { fEquipment = value; }
        }
        string fEquipment = "";

        /// <summary>
        /// Gets or sets the organizational category (e.g., for library grouping).
        /// </summary>
        public string Category
        {
            get { return fCategory; }
            set { fCategory = value; }
        }
        string fCategory = "";

        #region Abilities

        /// <summary>
        /// Gets or sets the Strength ability score.
        /// </summary>
        public Ability Strength
        {
            get { return fStrength; }
            set { fStrength = value; }
        }
        Ability fStrength = new Ability();

        /// <summary>
        /// Gets or sets the Constitution ability score.
        /// </summary>
        public Ability Constitution
        {
            get { return fConstitution; }
            set { fConstitution = value; }
        }
        Ability fConstitution = new Ability();

        /// <summary>
        /// Gets or sets the Dexterity ability score.
        /// </summary>
        public Ability Dexterity
        {
            get { return fDexterity; }
            set { fDexterity = value; }
        }
        Ability fDexterity = new Ability();

        /// <summary>
        /// Gets or sets the Intelligence ability score.
        /// </summary>
        public Ability Intelligence
        {
            get { return fIntelligence; }
            set { fIntelligence = value; }
        }
        Ability fIntelligence = new Ability();

        /// <summary>
        /// Gets or sets the Wisdom ability score.
        /// </summary>
        public Ability Wisdom
        {
            get { return fWisdom; }
            set { fWisdom = value; }
        }
        Ability fWisdom = new Ability();

        /// <summary>
        /// Gets or sets the Charisma ability score.
        /// </summary>
        public Ability Charisma
        {
            get { return fCharisma; }
            set { fCharisma = value; }
        }
        Ability fCharisma = new Ability();

        #endregion

        /// <summary>
        /// Gets or sets the total Hit Points.
        /// </summary>
        public int HP
        {
            get { return fHP; }
            set { fHP = value; }
        }
        int fHP = 0;

        /// <summary>
        /// Gets or sets the base initiative bonus.
        /// </summary>
        public int Initiative
        {
            get { return fInitiative; }
            set { fInitiative = value; }
        }
        int fInitiative = 0;

        #region Defences

        /// <summary>
        /// Gets or sets Armor Class.
        /// </summary>
        public int AC
        {
            get { return fAC; }
            set { fAC = value; }
        }
        int fAC = 10;

        /// <summary>
        /// Gets or sets Fortitude defence.
        /// </summary>
        public int Fortitude
        {
            get { return fFortitude; }
            set { fFortitude = value; }
        }
        int fFortitude = 10;

        /// <summary>
        /// Gets or sets Reflex defence.
        /// </summary>
        public int Reflex
        {
            get { return fReflex; }
            set { fReflex = value; }
        }
        int fReflex = 10;

        /// <summary>
        /// Gets or sets Will defence.
        /// </summary>
        public int Will
        {
            get { return fWill; }
            set { fWill = value; }
        }
        int fWill = 10;

        #endregion

        /// <summary>
        /// Gets or sets the regeneration properties.
        /// </summary>
        public Regeneration Regeneration
        {
            get { return fRegeneration; }
            set { fRegeneration = value; }
        }
        Regeneration fRegeneration = null;

        /// <summary>
        /// Gets or sets the collection of passive Auras.
        /// </summary>
        public List<Aura> Auras
        {
            get { return fAuras; }
            set { fAuras = value; }
        }
        List<Aura> fAuras = new List<Aura>();

        /// <summary>
        /// Gets or sets the collection of combat powers.
        /// </summary>
        public List<CreaturePower> CreaturePowers
        {
            get { return fCreaturePowers; }
            set { fCreaturePowers = value; }
        }
        List<CreaturePower> fCreaturePowers = new List<CreaturePower>();

        /// <summary>
        /// Gets or sets damage modifications like Resistances or Vulnerabilities.
        /// </summary>
        public List<DamageModifier> DamageModifiers
        {
            get { return fDamageModifiers; }
            set { fDamageModifiers = value; }
        }
        List<DamageModifier> fDamageModifiers = new List<DamageModifier>();

        /// <summary>
        /// Gets or sets the resistance string (e.g., "Fire 10").
        /// </summary>
        public string Resist
        {
            get { return fResist; }
            set { fResist = value; }
        }
        string fResist = "";

        /// <summary>
        /// Gets or sets the vulnerability string (e.g., "Cold 5").
        /// </summary>
        public string Vulnerable
        {
            get { return fVulnerable; }
            set { fVulnerable = value; }
        }
        string fVulnerable = "";

        /// <summary>
        /// Gets or sets the immunity string (e.g., "Poison").
        /// </summary>
        public string Immune
        {
            get { return fImmune; }
            set { fImmune = value; }
        }
        string fImmune = "";

        /// <summary>
        /// Gets or sets combat tactics for the DM.
        /// </summary>
        public string Tactics
        {
            get { return fTactics; }
            set { fTactics = value; }
        }
        string fTactics = "";

        /// <summary>
        /// Gets or sets the image to display on the tactical map.
        /// THINNING NOTE: GDI+ Dependency (System.Drawing.Image).
        /// </summary>
        public Image Image
        {
            get { return fImage; }
            set { fImage = value; }
        }
        Image fImage = null;

        /// <summary>
        /// Gets a summary info string: "Level N [role]".
        /// </summary>
        public string Info
        {
            get { return "Level " + fLevel + " " + fRole; }
        }

        /// <summary>
        /// Gets the phenotype string: "[Size] [Origin] [Type] ([Keywords])".
        /// Example: "Medium natural humanoid (goblin)".
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
        /// Returns a string that represents the current creature.
        /// </summary>
        /// <returns>The creature's name and info string.</returns>
        public override string ToString()
        {
            return fName + " (" + Info + ")";
        }

        /// <summary>
        /// Creates a deep copy of the creature instance.
        /// </summary>
        /// <returns>A new Creature instance with copied values.</returns>
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
            c.Role = (fRole != null) ? fRole.Copy() : null;
            c.Senses = fSenses;
            c.Movement = fMovement;
            c.Alignment = fAlignment;
            c.Languages = fLanguages;
            c.Skills = fSkills;
            c.Equipment = fEquipment;
            c.Category = fCategory;

            c.Strength = (fStrength != null) ? fStrength.Copy() : new Ability();
            c.Constitution = (fConstitution != null) ? fConstitution.Copy() : new Ability();
            c.Dexterity = (fDexterity != null) ? fDexterity.Copy() : new Ability();
            c.Intelligence = (fIntelligence != null) ? fIntelligence.Copy() : new Ability();
            c.Wisdom = (fWisdom != null) ? fWisdom.Copy() : new Ability();
            c.Charisma = (fCharisma != null) ? fCharisma.Copy() : new Ability();

            c.HP = fHP;
            c.Initiative = fInitiative;
            c.AC = fAC;
            c.Fortitude = fFortitude;
            c.Reflex = fReflex;
            c.Will = fWill;

            c.Regeneration = (fRegeneration != null) ? fRegeneration.Copy() : null;

            if (fAuras != null)
            {
                foreach (Aura aura in fAuras)
                    c.Auras.Add(aura.Copy());
            }

            if (fCreaturePowers != null)
            {
                foreach (CreaturePower cp in fCreaturePowers)
                    c.CreaturePowers.Add(cp.Copy());
            }

            if (fDamageModifiers != null)
            {
                foreach (DamageModifier dm in fDamageModifiers)
                    c.DamageModifiers.Add(dm.Copy());
            }

            c.Resist = fResist;
            c.Vulnerable = fVulnerable;
            c.Immune = fImmune;
            c.Tactics = fTactics;

            c.Image = fImage;

            return c;
        }

        /// <summary>
        /// Compares this creature's name to another creature's name.
        /// </summary>
        /// <param name="rhs">The creature to compare to.</param>
        /// <returns>Comparison result based on Name.</returns>
        public int CompareTo(ICreature rhs)
        {
            if (rhs == null) return 1;
            return fName.CompareTo(rhs.Name);
        }

        /// <summary>
        /// Gets the square size on a tactical grid for a given CreatureSize.
        /// </summary>
        /// <param name="size">The size category.</param>
        /// <returns>The dimension in squares (e.g., Large = 2x2).</returns>
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
        /// Gets the typical tactical speed (in squares) for a given CreatureSize.
        /// </summary>
        /// <param name="size">The size category.</param>
        /// <returns>Speed in squares.</returns>
        public static int GetSpeed(CreatureSize size)
        {
            switch (size)
            {
                case CreatureSize.Tiny:
                case CreatureSize.Small:
                    return 4;
                case CreatureSize.Medium:
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


