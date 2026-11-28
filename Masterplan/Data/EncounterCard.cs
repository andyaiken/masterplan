#nullable disable

using Masterplan.Properties;
using Masterplan.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace Masterplan.Data
{
    /// <summary>
    /// Enum containing the ways an encounter card can be shown.
    /// </summary>
    public enum CardMode
    {
        /// <summary>
        /// The card will be shown as plaintext.
        /// </summary>
        Text,

        /// <summary>
        /// The card will be non-interactive HTML.
        /// </summary>
        View,

        /// <summary>
        /// The card will show links for use in combat.
        /// </summary>
        Combat,

        /// <summary>
        /// The card will show links for use in creature building.
        /// </summary>
        Build
    }

    /// <summary>
    /// Class representing a creature plus optional templates.
    /// </summary>
    public class EncounterCard
    {
        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public EncounterCard()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="creature_id">The ID of the creature.</param>
        public EncounterCard(Guid creature_id)
        {
            fCreatureID = creature_id;

            // This will save us some time later
            if (fCreatureID != Guid.Empty)
                fCreature = Session.FindCreature(fCreatureID, SearchType.Global);
        }

        /// <summary>
        /// Constructor.
        /// Use this constructor when you need to use a creature which is not contained in a library.
        /// </summary>
        /// <param name="creature">The creature.</param>
        public EncounterCard(ICreature creature)
        {
            fCreature = creature;
            fCreatureID = creature.ID;
        }

        #endregion

        #region Creature properties

        ICreature fCreature = null;

        /// <summary>
        /// Gets or sets the ID of the creature.
        /// </summary>
        public Guid CreatureID
        {
            get { return fCreatureID; }
            set
            {
                fCreatureID = value;
                fLoadedCreature = null;
                fSaved = null;
                fStandIn = null;

                // This will save us some time later
                if (fCreatureID != Guid.Empty)
                    fCreature = Session.FindCreature(fCreatureID, SearchType.Global);
            }
        }
        Guid fCreatureID = Guid.Empty;

        // The creature a loaded card was connected to, when it is stored in the loaded project.
        // Only used when a normal lookup finds nothing (see CardCreature).
        ICreature fLoadedCreature = null;

        /// <summary>
        /// The card's real creature, or null if it cannot be found.
        /// </summary>
        /// <remarks>
        /// In this order:
        ///   1. the object the card remembers (cards made while the program runs);
        ///   2. a lookup by ID, which gives the CURRENT object, also after the creature was edited
        ///      (editing a custom creature or NPC replaces its object);
        ///   3. for a loaded card, the creature it was loaded with. Without this, deleting a custom
        ///      creature or NPC that an encounter still uses would leave its cards empty, and the
        ///      next save would write those empty values into the file.
        /// </remarks>
        ICreature RealCreature()
        {
            if (fCreature != null)
                return fCreature;

            return Session.FindCreature(fCreatureID, SearchType.Global) ?? fLoadedCreature;
        }

        /// <summary>
        /// The creature the card works with: the real one; for a card with saved values whose
        /// creature is missing, a temporary stand-in; otherwise null.
        /// </summary>
        ICreature CardCreature()
        {
            return RealCreature() ?? fStandIn;
        }

        // For a loaded card whose creature could not be found: what the file says the card showed.
        SavedCardValues fSaved = null;
        ICreature fStandIn = null;

        /// <summary>
        /// True if the card's creature cannot be found and the card shows the values saved in the
        /// file. Such a card must not be given a new level, templates or theme: nothing could be
        /// recalculated (the screens check this, see UI\MissingCreatureCards.cs).
        /// </summary>
        public bool CreatureMissing
        {
            get { return (fSaved != null) && (RealCreature() == null); }
        }

        /// <summary>The saved values while the creature is missing; otherwise null.</summary>
        /// <remarks>
        /// Every calculated property starts with this check and returns the saved value as it is.
        /// It is asked each time, so the card works normally as soon as the creature is found again.
        /// </remarks>
        SavedCardValues MissingValues()
        {
            return CreatureMissing ? fSaved : null;
        }

        /// <summary>
        /// For the load code only: the creature cannot be found, so the card is to show the values
        /// saved in the file. The card's settings (level adjustment, templates, theme) stay as they
        /// are, so nothing is lost when the file is saved again.
        /// </summary>
        internal void KeepSavedValues(Guid creature_id, SavedCardValues values)
        {
            fCreatureID = creature_id;
            fCreature = null;
            fLoadedCreature = null;
            fSaved = values;
            fStandIn = values.MakeStandIn(creature_id);
        }

        /// <summary>
        /// For the load code only (LibraryConversionService.ConnectCard): connects the card to a
        /// creature that is stored in the data being loaded.
        /// </summary>
        /// <remarks>
        /// Unlike the CreatureID property this does not look the creature up now: while a file is
        /// loading, a lookup could return an object of the previously open project. The loaded
        /// creature is only kept as the fallback (step 3 of CardCreature).
        /// </remarks>
        internal void ConnectToLoadedCreature(Guid creature_id, ICreature loaded_creature)
        {
            fCreatureID = creature_id;
            fCreature = null;
            fLoadedCreature = loaded_creature;
        }

        /// <summary>
        /// Gets or sets the list of template IDs.
        /// </summary>
        public List<Guid> TemplateIDs
        {
            get { return fTemplateIDs; }
            set { fTemplateIDs = value; }
        }
        List<Guid> fTemplateIDs = new List<Guid>();

        /// <summary>
        /// Gets or sets the card's level adjustment.
        /// </summary>
        public int LevelAdjustment
        {
            get { return fLevelAdjustment; }
            set { fLevelAdjustment = value; }
        }
        int fLevelAdjustment = 0;

        /// <summary>
        /// Gets or sets the ID of the monster theme to be used, or Guid.Empty to use no theme.
        /// </summary>
        public Guid ThemeID
        {
            get { return fThemeID; }
            set { fThemeID = value; }
        }
        Guid fThemeID = Guid.Empty;

        /// <summary>
        /// Gets or sets the ID of the card's theme attack power.
        /// </summary>
        public Guid ThemeAttackPowerID
        {
            get { return fThemeAttackPowerID; }
            set { fThemeAttackPowerID = value; }
        }
        Guid fThemeAttackPowerID = Guid.Empty;

        /// <summary>
        /// Gets or sets the ID of the card's theme utility power.
        /// </summary>
        public Guid ThemeUtilityPowerID
        {
            get { return fThemeUtilityPowerID; }
            set { fThemeUtilityPowerID = value; }
        }
        Guid fThemeUtilityPowerID = Guid.Empty;

        #endregion

        #region Card properties

        /// <summary>
        /// Gets or sets whether the card has been drawn from its deck.
        /// </summary>
        public bool Drawn
        {
            get { return fDrawn; }
            set { fDrawn = value; }
        }
        bool fDrawn = false;

        #endregion

        #region Calculated properties

        /// <summary>
        /// Gets the XP value of this card.
        /// </summary>
        public int XP
        {
            get
            {
                // A missing creature: show the saved value (see MissingValues).
                if (MissingValues() is SavedCardValues saved) return saved.XP;

                int xp = 0;

                ICreature creature = CardCreature();
                if (creature != null)
                {
                    if (creature.Role is Minion)
                    {
                        float experience = (float)Experience.GetCreatureXP(creature.Level + fLevelAdjustment) / 4;
                        xp = (int)Math.Round(experience, MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        xp = Experience.GetCreatureXP(creature.Level + fLevelAdjustment);
                        switch (Flag)
                        {
                            case RoleFlag.Elite:
                                xp *= 2;
                                break;
                            case RoleFlag.Solo:
                                xp *= 5;
                                break;
                        }
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
        /// Gets the title of the card.
        /// </summary>
        public string Title
        {
            get
            {
                // A missing creature: show the saved value (see MissingValues).
                if (MissingValues() is SavedCardValues saved) return saved.Title;

                ICreature creature = CardCreature();
                string name = (creature != null) ? creature.Name : "(unknown creature)";

                foreach (Guid template_id in fTemplateIDs)
                {
                    CreatureTemplate template = Session.FindTemplate(template_id, SearchType.Global);
                    if (template != null)
                        name = template.Name + " " + name;
                }

                if (fThemeID != Guid.Empty)
                {
                    MonsterTheme mt = Session.FindTheme(fThemeID, SearchType.Global);
                    if (mt != null)
                        name += " (" + mt.Name + ")";
                }

                return name;
            }
        }

        /// <summary>
        /// Level N [Elite / Solo] Role
        /// </summary>
        public string Info
        {
            get
            {
                // A missing creature: show the saved value (see MissingValues).
                if (MissingValues() is SavedCardValues saved) return saved.Info;

                ICreature creature = CardCreature();
                if (creature != null)
                {
                    int level = creature.Level + fLevelAdjustment;

                    if (creature.Role is Minion)
                    {
                        return "Level " + level + " " + creature.Role;
                    }
                    else
                    {
                        string prefix = "";
                        switch (Flag)
                        {
                            case RoleFlag.Elite:
                                prefix = "Elite ";
                                break;
                            case RoleFlag.Solo:
                                prefix = "Solo ";
                                break;
                        }

                        string str = "";
                        foreach (RoleType r in Roles)
                        {
                            if (str != "")
                                str += " / ";

                            str += r.ToString();
                        }

                        if (Leader)
                            str += " (L)";

                        return "Level " + level + " " + prefix + str;
                    }
                }

                return "";
            }
        }

        /// <summary>
        /// Gets the level of the card.
        /// </summary>
        public int Level
        {
            get
            {
                // A missing creature: show the saved value (see MissingValues).
                if (MissingValues() is SavedCardValues saved) return saved.Level;

                ICreature creature = CardCreature();
                if (creature == null)
                    return fLevelAdjustment;

                return creature.Level + fLevelAdjustment;
            }
        }

        /// <summary>
        /// Gets the roles filled by this card.
        /// </summary>
        public List<RoleType> Roles
        {
            get
            {
                // A missing creature: show a copy of the saved value (see MissingValues).
                if (MissingValues() is SavedCardValues saved) return new List<RoleType>(saved.Roles);

                List<RoleType> result = new List<RoleType>();

                ICreature creature = CardCreature();
                if ((creature == null) || (creature.Role is Minion))
                    return result;

                ComplexRole role = creature.Role as ComplexRole;
                if (role != null)
                    result.Add(role.Type);

                foreach (Guid template_id in fTemplateIDs)
                {
                    CreatureTemplate template = Session.FindTemplate(template_id, SearchType.Global);
                    if ((template != null) && (!result.Contains(template.Role)))
                        result.Add(template.Role);
                }

                return result;
            }
        }

        /// <summary>
        /// Gets the standard / elite / solo flag for this card.
        /// </summary>
        public RoleFlag Flag
        {
            get
            {
                // A missing creature: show the saved value (see MissingValues).
                if (MissingValues() is SavedCardValues saved) return saved.Flag;

                ICreature creature = CardCreature();
                if ((creature == null) || (creature.Role is Minion))
                    return RoleFlag.Standard;

                int steps = fTemplateIDs.Count;

                ComplexRole role = creature.Role as ComplexRole;
                if (role == null)
                    return RoleFlag.Standard;

                switch (role.Flag)
                {
                    case RoleFlag.Elite:
                        steps += 1;
                        break;
                    case RoleFlag.Solo:
                        steps += 2;
                        break;
                }

                if (steps == 0)
                    return RoleFlag.Standard;
                if (steps == 1)
                    return RoleFlag.Elite;
                else
                    return RoleFlag.Solo;
            }
        }

        /// <summary>
        /// Gets whether this card represents a leader.
        /// </summary>
        public bool Leader
        {
            get
            {
                // A missing creature: show the saved value (see MissingValues).
                if (MissingValues() is SavedCardValues saved) return saved.Leader;

                ICreature creature = CardCreature();
                if ((creature == null) || (creature.Role is Minion))
                    return false;

                ComplexRole cr = creature.Role as ComplexRole;
                if ((cr != null) && (cr.Leader))
                    return true;

                foreach (Guid template_id in fTemplateIDs)
                {
                    CreatureTemplate template = Session.FindTemplate(template_id, SearchType.Global);
                    if ((template != null) && (template.Leader))
                        return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Gets the card's regeneration
        /// </summary>
        public Regeneration Regeneration
        {
            get
            {
                // A missing creature: show a copy of the saved value (see MissingValues).
                if (MissingValues() is SavedCardValues saved) return saved.Regeneration?.Copy();

                ICreature creature = CardCreature();
                if (creature == null)
                    return null;

                Regeneration r = creature.Regeneration;

                foreach (Guid id in fTemplateIDs)
                {
                    CreatureTemplate ct = Session.FindTemplate(id, SearchType.Global);
                    if (ct == null)
                        continue;

                    if (ct.Regeneration != null)
                    {
                        if (r != null)
                        {
                            if (ct.Regeneration.Value > r.Value)
                                r = ct.Regeneration;
                        }
                        else
                        {
                            r = ct.Regeneration;
                        }
                    }
                }

                return (r != null) ? r.Copy() : null;
            }
        }

        /// <summary>
        /// Gets the list of auras for this card.
        /// </summary>
        public List<Aura> Auras
        {
            get
            {
                // A missing creature: show a copy of the saved value (see MissingValues).
                if (MissingValues() is SavedCardValues saved) return saved.Auras.ConvertAll(a => a.Copy());

                List<Aura> auras = new List<Aura>();

                ICreature creature = CardCreature();
                if (creature != null)
                    auras.AddRange(creature.Auras);

                foreach (Guid template_id in fTemplateIDs)
                {
                    CreatureTemplate template = Session.FindTemplate(template_id, SearchType.Global);
                    if (template != null)
                        auras.AddRange(template.Auras);
                }

                return auras;
            }
        }

        /// <summary>
        /// Gets the senses for this card.
        /// </summary>
        public string Senses
        {
            get
            {
                // A missing creature: show the saved value (see MissingValues).
                if (MissingValues() is SavedCardValues saved) return saved.Senses;

                List<string> senses = new List<string>();

                ICreature creature = CardCreature();
                if (creature == null)
                {
                    if (fCreatureID != Guid.Empty)
                        Debug.WriteLine("EncounterCard.Senses: creature not found for ID " + fCreatureID + "; Templates=" + fTemplateIDs.Count + "; LevelAdjustment=" + fLevelAdjustment + "; Title=\"" + Title + "\"; Stack: " + Environment.StackTrace);
                }

                if ((creature != null) && (!string.IsNullOrEmpty(creature.Senses)))
                    senses.Add(creature.Senses);

                foreach (Guid template_id in fTemplateIDs)
                {
                    CreatureTemplate template = Session.FindTemplate(template_id, SearchType.Global);
                    if ((template != null) && (template.Senses != ""))
                    {
                        if (!senses.Contains(template.Senses))
                            senses.Add(template.Senses);
                    }
                }

                string sense_str = "";
                foreach (string sense in senses)
                {
                    if (sense_str != "")
                        sense_str += "; ";

                    sense_str += sense;
                }

                return sense_str;
            }
        }

        /// <summary>
        /// Gets the movement for this card.
        /// </summary>
        public string Movement
        {
            get
            {
                // A missing creature: show the saved value (see MissingValues).
                if (MissingValues() is SavedCardValues saved) return saved.Movement;

                    ICreature creature = CardCreature();

                    if (creature == null)
                    {
                        System.Diagnostics.Trace.TraceWarning($"EncounterCard.Movement: Creature not found for ID {fCreatureID}");
                        return string.Empty;
                    }

                    string speed = creature.Movement;

                foreach (Guid template_id in fTemplateIDs)
                {
                    CreatureTemplate template = Session.FindTemplate(template_id, SearchType.Global);
                    if ((template != null) && (template.Movement != ""))
                    {
                        if (speed != "")
                            speed += "; ";

                        speed += template.Movement;
                    }
                }

                return speed;
            }
        }

        /// <summary>
        /// Gets the equipment for this card.
        /// </summary>
        public string Equipment
        {
            get
            {
                // A missing creature: show the saved value (see MissingValues).
                if (MissingValues() is SavedCardValues saved) return saved.Equipment;

                ICreature creature = CardCreature();
                return (creature != null && creature.Equipment != null) ? creature.Equipment : "";
            }
        }

        /// <summary>
        /// Gets the category of this card.
        /// </summary>
        public CardCategory Category
        {
            get
            {
                // A missing creature: show the saved value (see MissingValues).
                if (MissingValues() is SavedCardValues saved) return saved.Category;

                ICreature creature = CardCreature();

                if (creature == null)
                    return CardCategory.SoldierBrute; // default when creature data missing

                if (creature.Role is Minion)
                    return CardCategory.Minion;

                if (Flag == RoleFlag.Solo)
                    return CardCategory.Solo;

                List<RoleType> roles = Roles;
                if ((roles.Contains(RoleType.Soldier)) || (roles.Contains(RoleType.Brute)))
                    return CardCategory.SoldierBrute;
                if (roles.Contains(RoleType.Skirmisher))
                    return CardCategory.Skirmisher;
                if (roles.Contains(RoleType.Artillery))
                    return CardCategory.Artillery;
                if (roles.Contains(RoleType.Controller))
                    return CardCategory.Controller;
                if (roles.Contains(RoleType.Lurker))
                    return CardCategory.Lurker;

                // Should never reach here
                throw new Exception();
            }
        }

        /// <summary>
        /// Gets the HP total for this card.
        /// </summary>
        public int HP
        {
            get
            {
                // A missing creature: show the saved value (see MissingValues).
                if (MissingValues() is SavedCardValues saved) return saved.HP;

                int hp = 0;

                ICreature creature = CardCreature();
                if (creature != null)
                    hp += creature.HP;

                if (fTemplateIDs.Count != 0)
                {
                    // Add only the highest HP bonus
                    int max_hp_bonus = 0;
                    foreach (Guid template_id in fTemplateIDs)
                    {
                        CreatureTemplate template = Session.FindTemplate(template_id, SearchType.Global);
                        if ((template != null) && (template.HP > max_hp_bonus))
                            max_hp_bonus = template.HP;
                    }
                    hp += (max_hp_bonus * Level);
                    if (creature != null && creature.Constitution != null)
                        hp += creature.Constitution.Score;

                    // If we're using templates to create a solo, multiply HP by 2
                    if (Flag == RoleFlag.Solo)
                        hp *= 2;
                }

                // Handle level adjustment
                if ((fLevelAdjustment != 0) && (creature != null) && (creature.Role is ComplexRole))
                {
                    ComplexRole cr = creature.Role as ComplexRole;

                    int factor = 1;
                    switch (cr.Flag)
                    {
                        case RoleFlag.Elite:
                            factor = 2;
                            break;
                        case RoleFlag.Solo:
                            // A solo has 4 x a standard creature's HP (rules; Statistics.HP); it is
                            // only its XP that counts as 5 x. This was 5 until 14.1.0.13.
                            factor = 4;
                            break;
                    }

                    switch (cr.Type)
                    {
                        case RoleType.Artillery:
                            hp += (6 * fLevelAdjustment * factor);
                            break;
                        case RoleType.Brute:
                            hp += (10 * fLevelAdjustment * factor);
                            break;
                        case RoleType.Controller:
                            hp += (8 * fLevelAdjustment * factor);
                            break;
                        case RoleType.Lurker:
                            hp += (6 * fLevelAdjustment * factor);
                            break;
                        case RoleType.Skirmisher:
                            hp += (8 * fLevelAdjustment * factor);
                            break;
                        case RoleType.Soldier:
                            hp += (8 * fLevelAdjustment * factor);
                            break;
                    }
                }

                if (Session.Project != null)
                {
                    // Campaign settings
                    if ((creature != null) && (creature.Role is ComplexRole))
                        hp = (int)(hp * Session.Project.CampaignSettings.HP);
                }

                return hp;
            }
        }

        /// <summary>
        /// Gets the initiative bonus for this card.
        /// </summary>
        public int Initiative
        {
            get
            {
                // A missing creature: show the saved value (see MissingValues).
                if (MissingValues() is SavedCardValues saved) return saved.Initiative;

                int init = 0;

                ICreature creature = CardCreature();
                if (creature != null)
                    init += creature.Initiative;

                foreach (Guid template_id in fTemplateIDs)
                {
                    CreatureTemplate template = Session.FindTemplate(template_id, SearchType.Global);
                    if (template != null)
                        init += template.Initiative;
                }

                if (fLevelAdjustment != 0)
                    init += fLevelAdjustment / 2;

                return init;
            }
        }

        /// <summary>
        /// Gets the AC defence for this card.
        /// </summary>
        public int AC
        {
            get
            {
                // A missing creature: show the saved value (see MissingValues).
                if (MissingValues() is SavedCardValues saved) return saved.AC;

                int ac = 0;

                ICreature creature = CardCreature();
                if (creature != null)
                    ac += creature.AC;

                foreach (Guid template_id in fTemplateIDs)
                {
                    CreatureTemplate template = Session.FindTemplate(template_id, SearchType.Global);
                    if (template != null)
                        ac += template.AC;
                }

                // Handle level adjustment
                ac += fLevelAdjustment;

                if (Session.Project != null)
                {
                    // Campaign settings
                    ac += Session.Project.CampaignSettings.ACBonus;
                }

                return ac;
            }
        }

        /// <summary>
        /// Gets the Fortitude defence for this card.
        /// </summary>
        public int Fortitude
        {
            get
            {
                // A missing creature: show the saved value (see MissingValues).
                if (MissingValues() is SavedCardValues saved) return saved.Fortitude;

                int fort = 0;

                ICreature creature = CardCreature();
                if (creature != null)
                    fort += creature.Fortitude;

                foreach (Guid template_id in fTemplateIDs)
                {
                    CreatureTemplate template = Session.FindTemplate(template_id, SearchType.Global);
                    if (template != null)
                        fort += template.Fortitude;
                }

                // Handle level adjustment
                fort += fLevelAdjustment;

                if (Session.Project != null)
                {
                    // Campaign settings
                    fort += Session.Project.CampaignSettings.NADBonus;
                }

                return fort;
            }
        }

        /// <summary>
        /// Gets the Reflex defence for this card.
        /// </summary>
        public int Reflex
        {
            get
            {
                // A missing creature: show the saved value (see MissingValues).
                if (MissingValues() is SavedCardValues saved) return saved.Reflex;

                int reflex = 0;

                ICreature creature = CardCreature();
                if (creature != null)
                    reflex += creature.Reflex;

                foreach (Guid template_id in fTemplateIDs)
                {
                    CreatureTemplate template = Session.FindTemplate(template_id, SearchType.Global);
                    if (template != null)
                        reflex += template.Reflex;
                }

                // Handle level adjustment
                reflex += fLevelAdjustment;

                if (Session.Project != null)
                {
                    // Campaign settings
                    reflex += Session.Project.CampaignSettings.NADBonus;
                }

                return reflex;
            }
        }

        /// <summary>
        /// Gets the Will defence for this card.
        /// </summary>
        public int Will
        {
            get
            {
                // A missing creature: show the saved value (see MissingValues).
                if (MissingValues() is SavedCardValues saved) return saved.Will;

                int will = 0;

                ICreature creature = CardCreature();
                if (creature != null)
                    will += creature.Will;

                foreach (Guid template_id in fTemplateIDs)
                {
                    CreatureTemplate template = Session.FindTemplate(template_id, SearchType.Global);
                    if (template != null)
                        will += template.Will;
                }

                // Handle level adjustment
                will += fLevelAdjustment;

                if (Session.Project != null)
                {
                    // Campaign settings
                    will += Session.Project.CampaignSettings.NADBonus;
                }

                return will;
            }
        }

        /// <summary>
        /// Gets the list of powers for this card.
        /// </summary>
        public List<CreaturePower> CreaturePowers
        {
            get
            {
                // A missing creature: show a copy of the saved value (see MissingValues).
                if (MissingValues() is SavedCardValues saved) return saved.CreaturePowers.ConvertAll(p => p.Copy());

                Array dmg_categories = Enum.GetValues(typeof(DamageCategory));
                Array dmg_degrees = Enum.GetValues(typeof(DamageDegree));

                List<CreaturePower> powers = new List<CreaturePower>();

                ICreature creature = CardCreature();
                if (creature != null)
                {
                    foreach (CreaturePower cp in creature.CreaturePowers)
                        powers.Add(cp.Copy());
                }

                foreach (Guid template_id in fTemplateIDs)
                {
                    CreatureTemplate template = Session.FindTemplate(template_id, SearchType.Global);
                    if (template != null)
                    {
                        foreach (CreaturePower cp in template.CreaturePowers)
                        {
                            CreaturePower power = cp.Copy();

                            // Need to add level to attack powers from functional templates
                            if ((template.Type == CreatureTemplateType.Functional) && (power.Attack != null))
                                power.Attack.Bonus += Level;

                            powers.Add(power);
                        }
                    }
                }

                if (fThemeID != Guid.Empty)
                {
                    MonsterTheme mt = Session.FindTheme(fThemeID, SearchType.Global);
                    if (mt != null)
                    {
                        // Guid is a struct, so the old "!= null" test was always true; Guid.Empty is
                        // the "no power chosen" value. (FindPower(Guid.Empty) found nothing anyway,
                        // since every power gets a new Guid, so this changes no result.)
                        if (fThemeAttackPowerID != Guid.Empty)
                        {
                            ThemePowerData power = mt.FindPower(fThemeAttackPowerID);
                            if (power != null)
                                powers.Add(power.Power.Copy());
                        }

                        if (fThemeUtilityPowerID != Guid.Empty)
                        {
                            ThemePowerData power = mt.FindPower(fThemeUtilityPowerID);
                            if (power != null)
                                powers.Add(power.Power.Copy());
                        }
                    }
                }

                // Handle level adjustment
                // Handle null exception crash if a Project is not open before opening a creature from a library
                if (Session.Project != null)
                {
                    if (fLevelAdjustment != 0 || Session.Project.CampaignSettings.AttackBonus != 0 || Math.Abs(Session.Project.CampaignSettings.Damage - 1.0) < 1e-5)
                    {
                        foreach (CreaturePower cp in powers)
                        {
                            if (cp.Attack != null)
                            {
                                cp.Attack.Bonus += fLevelAdjustment;

                                if (Session.Project != null)
                                {
                                    // Campaign settings
                                    cp.Attack.Bonus += Session.Project.CampaignSettings.AttackBonus;
                                }
                            }

                            // Adjust power damage
                            string dmg_str = AI.ExtractDamage(cp.Details);
                            if (dmg_str != "")
                            {
                                DiceExpression exp = DiceExpression.Parse(dmg_str);
                                if (exp != null)
                                {
                                    DiceExpression exp_adj = exp.Adjust(fLevelAdjustment);
                                    if ((exp_adj != null) && (exp.ToString() != exp_adj.ToString()))
                                    {
                                        cp.Details = cp.Details.Replace(dmg_str, exp_adj + " damage (adjusted from " + dmg_str + ")");
                                    }
                                }
                            }
                            string dmg_str_2 = AI.ExtractDamageR(cp.Details);
                            if (dmg_str_2 != "")
                            {
                                DiceExpression exp = DiceExpression.Parse(dmg_str_2);
                                if (exp != null)
                                {
                                    DiceExpression exp_adj = exp.Adjust(Session.Project.CampaignSettings.Damage);
                                    if ((exp_adj != null) && (exp.ToString() != exp_adj.ToString()))
                                    {
                                        cp.Details = cp.Details.Replace(dmg_str_2, exp_adj + " (was " + dmg_str_2 + ")");
                                    }
                                }
                            }
                        }
                    }

                }

                return powers;
            }
        }

        /// <summary>
        /// Gets the list of damage modifiers for this card.
        /// </summary>
        public List<DamageModifier> DamageModifiers
        {
            get
            {
                // A missing creature: show a copy of the saved value (see MissingValues).
                if (MissingValues() is SavedCardValues saved) return saved.DamageModifiers.ConvertAll(m => m.Copy());

                List<DamageModifier> mods = new List<DamageModifier>();

                ICreature creature = CardCreature();
                if (creature != null)
                {
                    foreach (DamageModifier dm in creature.DamageModifiers)
                        mods.Add(dm.Copy());
                }

                foreach (Guid template_id in fTemplateIDs)
                {
                    CreatureTemplate template = Session.FindTemplate(template_id, SearchType.Global);
                    if (template == null)
                        continue;

                    foreach (DamageModifierTemplate dmt in template.DamageModifierTemplates)
                    {
                        // Do we already have this?
                        DamageModifier current = null;
                        foreach (DamageModifier mod in mods)
                        {
                            if (mod.Type == dmt.Type)
                            {
                                current = mod;
                                break;
                            }
                        }

                        // If it's an immunity, ignore the new one
                        if ((current != null) && (current.Value == 0))
                            continue;

                        if (current == null)
                        {
                            current = new DamageModifier();
                            current.Type = dmt.Type;
                            current.Value = 0;

                            mods.Add(current);
                        }

                        // Set the new value
                        int total_mod = dmt.HeroicValue + dmt.ParagonValue + dmt.EpicValue;
                        if (total_mod == 0)
                        {
                            // Set immunity
                            current.Value = 0;
                        }
                        else
                        {
                        int creatureLevel = (creature != null) ? creature.Level : 0;
                        int value = dmt.HeroicValue;
                        if (creatureLevel >= 10)
                            value = dmt.ParagonValue;
                        if (creatureLevel >= 20)
                            value = dmt.EpicValue;

                            current.Value += value;

                            // If new value is 0, remove mod
                            if (current.Value == 0)
                                mods.Remove(current);
                        }
                    }
                }

                return mods;
            }
        }

        /// <summary>
        /// Gets the resistances for this card.
        /// </summary>
        public string Resist
        {
            get
            {
                // A missing creature: show the saved value (see MissingValues).
                if (MissingValues() is SavedCardValues saved) return saved.Resist;

                string str = "";

                ICreature creature = CardCreature();
                if (creature != null)
                    str += creature.Resist;

                foreach (Guid template_id in fTemplateIDs)
                {
                    CreatureTemplate template = Session.FindTemplate(template_id, SearchType.Global);
                    if ((template == null) || (template.Resist == ""))
                        continue;

                    if (str != "")
                        str += ", ";

                    str += template.Resist;
                }

                return str;
            }
        }

        /// <summary>
        /// Gets the vulnerabilities for this card.
        /// </summary>
        public string Vulnerable
        {
            get
            {
                // A missing creature: show the saved value (see MissingValues).
                if (MissingValues() is SavedCardValues saved) return saved.Vulnerable;

                string str = "";

                ICreature creature = CardCreature();
                if (creature != null)
                    str += creature.Vulnerable;

                foreach (Guid template_id in fTemplateIDs)
                {
                    CreatureTemplate template = Session.FindTemplate(template_id, SearchType.Global);
                    if ((template == null) || (template.Vulnerable == ""))
                        continue;

                    if (str != "")
                        str += ", ";

                    str += template.Vulnerable;
                }

                return str;
            }
        }

        /// <summary>
        /// Gets the immunities for this card.
        /// </summary>
        public string Immune
        {
            get
            {
                // A missing creature: show the saved value (see MissingValues).
                if (MissingValues() is SavedCardValues saved) return saved.Immune;

                string str = "";

                ICreature creature = CardCreature();
                if (creature != null)
                    str += creature.Immune;

                foreach (Guid template_id in fTemplateIDs)
                {
                    CreatureTemplate template = Session.FindTemplate(template_id, SearchType.Global);
                    if ((template == null) || (template.Immune == ""))
                        continue;

                    if (str != "")
                        str += ", ";

                    str += template.Immune;
                }

                return str;
            }
        }

        /// <summary>
        /// Gets the tactics for this card.
        /// </summary>
        public string Tactics
        {
            get
            {
                // A missing creature: show the saved value (see MissingValues).
                if (MissingValues() is SavedCardValues saved) return saved.Tactics;

                string str = "";

                ICreature creature = CardCreature();
                if (creature != null)
                    str += creature.Tactics;

                foreach (Guid template_id in fTemplateIDs)
                {
                    CreatureTemplate template = Session.FindTemplate(template_id, SearchType.Global);
                    if ((template == null) || (template.Tactics == ""))
                        continue;

                    if (str != "")
                        str += ", ";

                    str += template.Tactics;
                }

                return str;
            }
        }

        /// <summary>
        /// Gets the skills for this card: the creature's skills text with this card's theme bonuses
        /// and level adjustment, for showing.
        /// </summary>
        /// <remarks>
        /// Since 14.1.0.15 the creature's text is shown as typed (MPX-D38): only each skill's own
        /// number changes (theme bonus, level adjustment) and gets a sign; notes, qualified names,
        /// entries without a number and the order stay. Until 14.1.0.14 the skills were rebuilt from
        /// ParseSkills (sorted, notes lost, anything not a plain number shown as +0), and a theme skill
        /// the creature did not have got the level adjustment twice (finding F1).
        /// </remarks>
        public string Skills
        {
            get
            {
                // A missing creature: show the saved value (see MissingValues).
                if (MissingValues() is SavedCardValues saved) return saved.Skills;

                ICreature creature = CardCreature();
                if (creature == null)
                    return "";

                string skills = creature.Skills ?? "";

                MonsterTheme mt = (fThemeID != Guid.Empty) ? Session.FindTheme(fThemeID, SearchType.Global) : null;
                if (mt != null)
                {
                    foreach (Pair<string, int> theme_bonus in mt.SkillBonuses)
                    {
                        // The creature has this skill: add the bonus to its number (a note stays).
                        string with_bonus = CreatureHelper.AddToSkill(skills, theme_bonus.First, theme_bonus.Second);
                        if (with_bonus != null)
                        {
                            skills = with_bonus;
                        }
                        else
                        {
                            // It does not: untrained at the creature's OWN level (half level + the key
                            // ability's modifier) plus the bonus; the card's level adjustment is added
                            // below, once (until 14.1.0.14 it was counted twice here, finding F1).
                            int mod = creature.Level / 2;

                            string ab = Tools.Skills.GetKeyAbility(theme_bonus.First);
                            if (ab == "Strength")
                                mod += creature.Strength.Modifier;
                            if (ab == "Constitution")
                                mod += creature.Constitution.Modifier;
                            if (ab == "Dexterity")
                                mod += creature.Dexterity.Modifier;
                            if (ab == "Intelligence")
                                mod += creature.Intelligence.Modifier;
                            if (ab == "Wisdom")
                                mod += creature.Wisdom.Modifier;
                            if (ab == "Charisma")
                                mod += creature.Charisma.Modifier;

                            int total = theme_bonus.Second + mod;
                            if (skills.Trim() != "")
                                skills += ", ";
                            skills += theme_bonus.First + " " + total; // FormatSkills adds the sign
                        }
                    }
                }

                // The card's level adjustment, and a sign on every skill number.
                return CreatureHelper.FormatSkills(skills, creature.Level, creature.Level + fLevelAdjustment);
            }
        }

        #endregion

        /// <summary>
        /// Finds the power with the given ID.
        /// </summary>
        /// <param name="power_id">The ID to search for.</param>
        /// <returns>Returns the power if it exists; null otherwise.</returns>
        public CreaturePower FindPower(Guid power_id)
        {
            List<CreaturePower> powers = CreaturePowers;
            foreach (CreaturePower cp in powers)
            {
                if (cp.ID == power_id)
                    return cp;
            }

            return null;
        }

        /// <summary>
        /// Calculates the difficulty of the card.
        /// </summary>
        /// <param name="party_level">The level of the party.</param>
        /// <returns>Returns the difficulty level.</returns>
        public Difficulty GetDifficulty(int party_level)
        {
            int delta = Level - party_level;

            if (delta < -1)
                return Difficulty.Trivial;

            Difficulty diff = Difficulty.Extreme;
            switch (delta)
            {
                case -1:
                case 0:
                case 1:
                    diff = Difficulty.Easy;
                    break;
                case 2:
                case 3:
                    diff = Difficulty.Moderate;
                    break;
                case 4:
                case 5:
                    diff = Difficulty.Hard;
                    break;
            }

            return diff;
        }

        /// <summary>
        /// Calculates the damage modifier for the given damage type.
        /// </summary>
        /// <param name="type">The damage type.</param>
        /// <param name="data">The current combat data.</param>
        /// <returns>Returns the damage modifier.</returns>
        public int GetDamageModifier(DamageType type, CombatData data)
        {
            List<DamageModifier> mods = new List<DamageModifier>();
            mods.AddRange(DamageModifiers);
            if (data != null)
            {
                foreach (OngoingCondition oc in data.Conditions)
                {
                    if (oc.Type != OngoingType.DamageModifier)
                        continue;

                    mods.Add(oc.DamageModifier);
                }
            }

            if (mods.Count == 0)
                return 0;

            // Look for all modifiers for this damage type
            List<int> values = new List<int>();
            foreach (DamageModifier mod in mods)
            {
                if (mod.Type != type)
                    continue;

                if (mod.Value == 0)
                {
                    values.Add(int.MinValue);
                }
                else
                {
                    values.Add(mod.Value);
                }
            }

            int total = 0;
            if (values.Contains(int.MinValue))
            {
                total = int.MinValue;
            }
            else
            {
                int max_pos = 0;
                int min_neg = 0;

                foreach (int value in values)
                {
                    if ((value > 0) && (value > max_pos))
                        max_pos = value;
                    if ((value < 0) && (value < min_neg))
                        min_neg = value;
                }

                total = max_pos + min_neg;
            }

            return total;
        }

        /// <summary>
        /// Calculates the damage modifier for the given damage types.
        /// </summary>
        /// <param name="types">The damage types.</param>
        /// <param name="data">The current combat data.</param>
        /// <returns>Returns the damage modifier.</returns>
        public int GetDamageModifier(List<DamageType> types, CombatData data)
        {
            if ((types == null) || (types.Count == 0))
                return 0;

            Dictionary<DamageType, int> modifiers = new Dictionary<DamageType, int>();
            foreach (DamageType dt in types)
                modifiers[dt] = GetDamageModifier(dt, data);

            // Collate immunities, vulnerabilities, resistances
            List<int> immune = new List<int>();
            List<int> resist = new List<int>();
            List<int> vulnerable = new List<int>();
            foreach (DamageType dt in types)
            {
                int value = modifiers[dt];

                if (value == int.MinValue)
                    immune.Add(value);

                if (value < 0)
                    resist.Add(value);

                if (value > 0)
                    vulnerable.Add(value);
            }

            // If we're immune to all, we're immune
            if (immune.Count == types.Count)
                return int.MinValue;

            // If we resist all, we resist the smallest
            if (resist.Count == types.Count)
            {
                resist.Sort();
                resist.Reverse();
                return resist[0];
            }

            // If we're vulnerable all, we vuln the smallest
            if (vulnerable.Count == types.Count)
            {
                vulnerable.Sort();
                return vulnerable[0];
            }

            return 0;
        }

        /// <summary>
        /// Creates a copy of this card.
        /// </summary>
        /// <returns>Returns the copy.</returns>
        public EncounterCard Copy()
        {
            EncounterCard card = new EncounterCard();

            card.CreatureID = fCreatureID;
            card.fLoadedCreature = fLoadedCreature;
            card.fSaved = fSaved;       // the saved values are never changed, so they can be shared
            card.fStandIn = fStandIn;

            foreach (Guid template_id in fTemplateIDs)
                card.TemplateIDs.Add(template_id);

            card.LevelAdjustment = fLevelAdjustment;
            card.ThemeID = fThemeID;
            card.ThemeAttackPowerID = fThemeAttackPowerID;
            card.ThemeUtilityPowerID = fThemeUtilityPowerID;

            card.Drawn = fDrawn;

            return card;
        }

        /// <summary>
        /// Returns the text of the card.
        /// </summary>
        /// <param name="combat_data">The CombatData object for this card; null to show the card out of combat.</param>
        /// <param name="mode">How the card should be shown.</param>
        /// <param name="full">If false, only shows combat stats.</param>
        /// <returns>Returns the text of the card.</returns>
        public List<string> AsText(CombatData combat_data, CardMode mode, bool full)
        {
            ICreature creature = CardCreature();

            #region If not found

            if (creature == null)
            {
                if (mode == CardMode.Text)
                {
                    List<string> lines = new List<string>();
                    lines.Add("(unknown creature)");
                    return lines;
                }
                else
                {
                    List<string> lines = new List<string>();

                    lines.Add("<TABLE>");
                    lines.Add("<TR class=creature>");
                    lines.Add("<TD>");
                    lines.Add("<B>(unknown creature)</B>");
                    lines.Add("</TD>");
                    lines.Add("</TR>");
                    lines.Add("<TR>");
                    lines.Add("<TD>");
                    lines.Add("No details");
                    lines.Add("</TD>");
                    lines.Add("</TR>");
                    lines.Add("</TABLE>");

                    return lines;
                }
            }

            #endregion

            List<string> content = new List<string>();

            #region Header

            if (mode != CardMode.Text)
            {
                string title = (combat_data == null) ? Title : combat_data.DisplayName;

                // Generate the dynamic table layout
                // (300px or 99%)
                // 
                var generator = CssGenerator.Instance;
                string layoutField = generator.GenerateShortStyle();

                content.Add(layoutField);

                #region Warnings

                if (mode == CardMode.Build)
                {
                    bool has_basic_attack = false;
                    foreach (CreaturePower power in CreaturePowers)
                    {
                        if ((power.Action != null) && (power.Action.Use == PowerUseType.Basic) && (power.Attack != null))
                            has_basic_attack = true;
                    }

                    if (!has_basic_attack)
                    {
                        content.Add("<TR class=warning>");
                        content.Add("<TD colspan=3 align=center>");
                        content.Add("<B>Warning</B>: This creature has no basic attack");
                        content.Add("</TD>");
                        content.Add("</TR>");
                    }

                    if (CreaturePowers.Count > 10)
                    {
                        content.Add("<TR class=warning>");
                        content.Add("<TD colspan=3 align=center>");
                        content.Add("<B>Warning</B>: This many powers might be slow in play");
                        content.Add("</TD>");
                        content.Add("</TR>");
                    }
                }

                #endregion

                content.Add("<TR class=creature>");

                content.Add("<TD colspan=2>");
                content.Add("<B>" + HTML.Process(title, true) + "</B>");
                content.Add("<BR>");
                content.Add(creature.Phenotype);
                content.Add("</TD>");

                content.Add("<TD>");
                content.Add("<B>" + HTML.Process(Info, true) + "</B>");
                content.Add("<BR>");
                content.Add(XP + " XP");
                content.Add("</TD>");

                content.Add("</TR>");

                if (mode == CardMode.Build)
                {
                    content.Add("<TR class=creature>");
                    content.Add("<TD colspan=3 align=center>");
                    content.Add("<A href=build:profile style=\"color:white\">(click here to edit this top section)</A>");
                    content.Add("</TD>");
                    content.Add("</TR>");
                }
            }

            #endregion

            #region Combat stats

            if (mode != CardMode.Text)
                content.Add("<TR>");

            #region HP

            string hp = HP.ToString();
            if ((combat_data != null) && (combat_data.Damage != 0))
            {
                int health = HP - combat_data.Damage;
                if (creature.Role is Minion)
                    hp = health.ToString();
                else
                    hp = health + " of " + HP;
            }
            string hp_str = (mode != CardMode.Text) ? "<B>HP</B>" : "HP";
            hp_str += " " + hp;
            if ((combat_data != null) && (mode == CardMode.Combat))
            {
                if (creature.Role is Minion)
                {
                    if (combat_data.Damage == 0)
                    {
                        hp_str = hp_str + " (<A href=kill:" + combat_data.ID + ">kill</A>)";
                    }
                    else
                    {
                        hp_str = hp_str + " (<A href=revive:" + combat_data.ID + ">revive</A>)";
                    }
                }
                else
                {
                    hp_str = hp_str + " (<A href=dmg:" + combat_data.ID + ">dmg</A> | <A href=heal:" + combat_data.ID + ">heal</A>)";
                }
            }
            if (!(creature.Role is Minion))
            {
                string bloodied_str = (mode != CardMode.Text) ? "<B>Bloodied</B>" : "Bloodied";
                hp_str += "; " + bloodied_str + " " + (HP / 2);
            }
            if ((combat_data != null) && (combat_data.TempHP > 0))
                hp_str += "; " + ((mode != CardMode.Text) ? "<B>Temp HP</B>" : "Temp HP") + " " + combat_data.TempHP;

            if (mode == CardMode.Build)
                hp_str = " <A href=build:combat>" + hp_str + "</A>";

            if (mode != CardMode.Text)
            {
                content.Add("<TD colspan=2>");
                content.Add(hp_str);
                content.Add("</TD>");
            }
            else
            {
                content.Add(hp_str);
            }

            #endregion

            #region Initiative

            int init_bonus = Initiative;
            string init_str = init_bonus.ToString();

            if (init_bonus >= 0)
                init_str = "+" + init_str;

            if ((combat_data != null) && (combat_data.Initiative != int.MinValue))
            {
                init_str = combat_data.Initiative + " (" + init_str + ")";
            }

            switch (mode)
            {
                case CardMode.Text:
                    content.Add("Initiative " + init_str);
                    break;
                case CardMode.View:
                    content.Add("<TD>");
                    content.Add("<B>Initiative</B> " + init_str);
                    content.Add("</TD>");
                    break;
                case CardMode.Combat:
                    content.Add("<TD>");
                    content.Add("<B>Initiative</B> <A href=init:" + combat_data.ID + ">" + init_str + "</A>");
                    content.Add("</TD>");
                    break;
                case CardMode.Build:
                    content.Add("<TD>");
                    content.Add("<A href=build:combat><B>Initiative</B> " + init_str + "</A>");
                    content.Add("</TD>");
                    break;
            }

            #endregion

            if (mode != CardMode.Text)
            {
                content.Add("</TR>");
                content.Add("<TR>");
            }

            #region Defences

            string ac_str = (mode != CardMode.Text) ? "<B>AC</B>" : "AC";
            string fort_str = (mode != CardMode.Text) ? "<B>Fort</B>" : "Fort";
            string ref_str = (mode != CardMode.Text) ? "<B>Ref</B>" : "Ref";
            string will_str = (mode != CardMode.Text) ? "<B>Will</B>" : "Will";

            int ac = AC;
            int fort = Fortitude;
            int reflex = Reflex;
            int will = Will;

            if (combat_data != null)
            {
                foreach (OngoingCondition oc in combat_data.Conditions)
                {
                    if (oc.Type != OngoingType.DefenceModifier)
                        continue;

                    if (oc.Defences.Contains(DefenceType.AC))
                        ac += oc.DefenceMod;
                    if (oc.Defences.Contains(DefenceType.Fortitude))
                        fort += oc.DefenceMod;
                    if (oc.Defences.Contains(DefenceType.Reflex))
                        reflex += oc.DefenceMod;
                    if (oc.Defences.Contains(DefenceType.Will))
                        will += oc.DefenceMod;
                }
            }

            if ((ac == AC) || (mode == CardMode.Text))
                ac_str += " " + ac;
            else
                ac_str += " <B><I>" + ac + "</I></B>";
            if ((fort == Fortitude) || (mode == CardMode.Text))
                fort_str += " " + fort;
            else
                fort_str += " <B><I>" + fort + "</I></B>";
            if ((reflex == Reflex) || (mode == CardMode.Text))
                ref_str += " " + reflex;
            else
                ref_str += " <B><I>" + reflex + "</I></B>";
            if ((will == Will) || (mode == CardMode.Text))
                will_str += " " + will;
            else
                will_str += " <B><I>" + will + "</I></B>";
            string defences = ac_str + "; " + fort_str + "; " + ref_str + "; " + will_str;

            if (mode != CardMode.Text)
                content.Add("<TD colspan=2>");

            if (mode == CardMode.Build)
                defences = "<A href=build:combat>" + defences + "</A>";

            content.Add(defences);

            if (mode != CardMode.Text)
                content.Add("</TD>");

            #endregion

            #region Perception

            if (mode != CardMode.Text)
            {
                string perc = "";

                // 1. Perception from the card's skills (the Skills property): the creature's text as
                //    typed, with this card's level adjustment and theme bonus and a sign
                //    ("Perception +11 (+16 in darkness)"). Up to 14.1.0.12 the raw text was shown, so
                //    a trained Perception showed "Perception 11" and ignored level adjustments; in
                //    14.1.0.13 / 14.1.0.14 text with a note was shown without the level adjustment.
                //    Split outside parentheses, so a comma inside a note does not cut it.
                foreach (string skill in CreatureHelper.SplitSkillEntries(Skills))
                {
                    if (skill.ToLower().Contains("perc"))
                        perc = skill;
                }

                if (perc == "")
                {
                    // 2. Untrained and no theme bonus: Wisdom modifier + 1/2 level (unchanged)
                    int bonus = creature.Wisdom.Modifier + (Level / 2);
                    perc = "Perception ";
                    if (bonus >= 0)
                        perc += "+";
                    perc += bonus.ToString();
                }

                if (perc != "")
                {
                    content.Add("<TD>");

                    if (mode == CardMode.Build)
                        perc = "<A href=build:skills>" + perc + "</A>";

                    content.Add(perc);

                    content.Add("</TD>");
                }
            }

            #endregion

            if (mode != CardMode.Text)
            {
                content.Add("</TR>");
                content.Add("<TR>");
            }

            #region Speed

            if (mode != CardMode.Text)
            {
                string movement = HTML.Process(Movement, true);
                if (movement != "")
                    movement = "<B>Speed</B> " + movement;

                if (mode == CardMode.Build)
                {
                    if (movement == "")
                        movement = "(specify movement)";
                }

                if (movement != "")
                {
                    content.Add("<TD colspan=2>");

                    if (mode == CardMode.Build)
                        movement = "<A href=build:movement>" + movement + "</A>";

                    content.Add(movement);

                    content.Add("</TD>");
                }
            }

            #endregion

            #region Senses

            if (mode != CardMode.Text)
            {
                string senses = Senses;
                if (senses == null)
                    senses = "";
                senses = HTML.Process(senses, true);

                if (senses.ToLower().Contains("perception"))
                {
                    // Remove the Perception clause

                    string[] clauses = senses.Split(new string[] { ";", "," }, StringSplitOptions.RemoveEmptyEntries);

                    senses = "";
                    foreach (string clause in clauses)
                    {
                        if (clause.ToLower().Contains("perception"))
                            continue;

                        if (senses != "")
                            senses += "; ";

                        senses += clause;
                    }
                }

                int rows = (Flag == RoleFlag.Standard) ? 1 : 2;

                // Add 1 if we have damage mods
                int damage_mods = DamageModifiers.Count;
                if (combat_data != null)
                {
                    foreach (OngoingCondition oc in combat_data.Conditions)
                    {
                        if (oc.Type == OngoingType.DamageModifier)
                            damage_mods += 1;
                    }
                }
                if ((Resist != "") || (Vulnerable != "") || (Immune != "") || (damage_mods != 0) || (mode == CardMode.Build))
                    rows += 1;

                if (mode == CardMode.Build)
                {
                    if (senses == "")
                        senses = "(specify senses)";

                    senses = "<A href=build:senses>" + senses + "</A>";
                }

                content.Add("<TD rowspan=" + rows + ">" + senses + "</TD>");
            }

            #endregion

            if (mode != CardMode.Text)
            {
                content.Add("</TR>");
            }

            #region Resistance, vulnerability, immunity

            if (mode != CardMode.Text)
            {
                string resist = HTML.Process(Resist, true);
                string vuln = HTML.Process(Vulnerable, true);
                string immune = HTML.Process(Immune, true);
                if (resist == null)
                    resist = "";
                if (vuln == null)
                    vuln = "";
                if (immune == null)
                    immune = "";

                List<DamageModifier> dmg_mod_list = new List<DamageModifier>();
                dmg_mod_list.AddRange(DamageModifiers);
                if (combat_data != null)
                {
                    foreach (OngoingCondition oc in combat_data.Conditions)
                    {
                        if (oc.Type != OngoingType.DamageModifier)
                            continue;

                        dmg_mod_list.Add(oc.DamageModifier);
                    }
                }

                foreach (DamageModifier dm in dmg_mod_list)
                {
                    if (dm.Value == 0)
                    {
                        if (immune != "")
                            immune += ", ";

                        immune += dm.Type.ToString().ToLower();
                    }

                    if (dm.Value > 0)
                    {
                        if (vuln != "")
                            vuln += ", ";

                        vuln += dm.Value + " " + dm.Type.ToString().ToLower();
                    }

                    if (dm.Value < 0)
                    {
                        if (resist != "")
                            resist += ", ";

                        int val = Math.Abs(dm.Value);
                        resist += val + " " + dm.Type.ToString().ToLower();
                    }
                }

                string damage_mods = "";
                if (immune != "")
                {
                    damage_mods += "<B>Immune</B> " + immune;
                }
                if (resist != "")
                {
                    if (damage_mods != "")
                        damage_mods += "; ";

                    damage_mods += "<B>Resist</B> " + resist;
                }
                if (vuln != "")
                {
                    if (damage_mods != "")
                        damage_mods += "; ";

                    damage_mods += "<B>Vulnerable</B> " + vuln;
                }

                if (damage_mods != "")
                {
                    if (mode == CardMode.Build)
                        damage_mods = "<A href=build:damage>" + damage_mods + "</A>";

                    content.Add("<TR>");
                    content.Add("<TD colspan=2>");
                    content.Add(damage_mods);
                    content.Add("</TD>");
                    content.Add("</TR>");
                }
                else
                {
                    if (mode == CardMode.Build)
                    {
                        content.Add("<TR>");
                        content.Add("<TD colspan=2>");
                        content.Add("<A href=build:damage>No resistances / vulnerabilities / immunities</A>");
                        content.Add("</TD>");
                        content.Add("</TR>");
                    }
                }
            }

            #endregion

            #region Saving throws / action points

            bool added_ap = false;

            if (mode != CardMode.Text)
            {
                int save_mod = 0;
                int ap = 0;

                switch (Flag)
                {
                    case RoleFlag.Elite:
                        save_mod = 2;
                        ap = 1;
                        break;
                    case RoleFlag.Solo:
                        save_mod = 5;
                        ap = 2;
                        break;
                }

                if (ap != 0)
                {
                    content.Add("<TD colspan=2>");
                    content.Add("<B>Saving Throws</B>" + " +" + save_mod + " <B>Action Points</B> " + ap);
                    content.Add("</TD>");

                    added_ap = true;
                }
            }

            if ((added_ap) && (mode != CardMode.Text))
            {
                content.Add("</TR>");
            }

            #endregion

            if (mode == CardMode.Build)
            {
                content.Add("<TR>");

                content.Add("<TD colspan=3 align=center>");
                content.Add("(click on any value in this section to edit it)");
                content.Add("</TD>");

                content.Add("</TR>");
            }

            #endregion

            if ((mode != CardMode.Text) && full)
            {
                #region Powers

                if (mode == CardMode.Build)
                {
                    content.Add("<TR class=creature>");
                    content.Add("<TD colspan=3>");
                    content.Add("<B>Powers and Traits</B>");
                    content.Add("</TD>");
                    content.Add("</TR>");

                    content.Add("<TR>");
                    content.Add("<TD colspan=3 align=center>");
                    content.Add("<A href=power:addtrait>add a trait</A>");
                    content.Add("|");
                    content.Add("<A href=power:addpower>add a power</A>");
                    content.Add("|");
                    content.Add("<A href=power:addaura>add an aura</A>");
                    if (Regeneration == null)
                    {
                        content.Add("|");
                        content.Add("<A href=power:regenedit>add regeneration</A>");
                    }
                    content.Add("<BR>");
                    content.Add("<A href=power:browse>browse for an existing power or trait</A>");
                    content.Add("</TD>");
                    content.Add("</TR>");
                }

                Dictionary<CreaturePowerCategory, List<CreaturePower>> powers = new Dictionary<CreaturePowerCategory, List<CreaturePower>>();
                Array power_categories = Enum.GetValues(typeof(CreaturePowerCategory));
                foreach (CreaturePowerCategory cat in power_categories)
                    powers[cat] = new List<CreaturePower>();
                foreach (CreaturePower cp in CreaturePowers)
                    powers[cp.Category].Add(cp);
                foreach (CreaturePowerCategory cat in power_categories)
                    powers[cat].Sort();

                foreach (CreaturePowerCategory cat in power_categories)
                {
                    int count = powers[cat].Count;
                    if (cat == CreaturePowerCategory.Trait)
                    {
                        // Add auras
                        count += Auras.Count;
                        if (combat_data != null)
                        {
                            foreach (OngoingCondition oc in combat_data.Conditions)
                            {
                                if (oc.Type == OngoingType.Aura)
                                    count += 1;
                            }
                        }

                        // Add regeneration
                        bool has_regen = (Regeneration != null);
                        if (combat_data != null)
                        {
                            foreach (OngoingCondition oc in combat_data.Conditions)
                            {
                                if (oc.Type == OngoingType.Regeneration)
                                    has_regen = true;
                            }
                        }
                        if (has_regen)
                            count += 1;
                    }

                    if (count == 0)
                        continue;

                    string name = "";
                    switch (cat)
                    {
                        case CreaturePowerCategory.Trait:
                            name = "Traits";
                            break;
                        case CreaturePowerCategory.Standard:
                        case CreaturePowerCategory.Move:
                        case CreaturePowerCategory.Minor:
                        case CreaturePowerCategory.Free:
                            name = cat + " Actions";
                            break;
                        case CreaturePowerCategory.Triggered:
                            name = "Triggered Actions";
                            break;
                        case CreaturePowerCategory.Other:
                            name = "Other Actions";
                            break;
                    }

                    content.Add("<TR class=creature>");
                    content.Add("<TD colspan=3>");
                    content.Add("<B>" + name + "</B>");
                    content.Add("</TD>");
                    content.Add("</TR>");

                    if (cat == CreaturePowerCategory.Trait)
                    {
                        // Auras
                        List<Aura> aura_list = new List<Aura>();
                        aura_list.AddRange(Auras);
                        if (combat_data != null)
                        {
                            foreach (OngoingCondition oc in combat_data.Conditions)
                            {
                                if (oc.Type == OngoingType.Aura)
                                    aura_list.Add(oc.Aura);
                            }
                        }

                        foreach (Aura aura in aura_list)
                        {
                            string aura_details = HTML.Process(aura.Description.Trim(), true);
                            if (aura_details.StartsWith("aura", StringComparison.OrdinalIgnoreCase))
                                aura_details = "A" + aura_details.Substring(1);

                            MemoryStream ms = new MemoryStream();
                            Resources.Aura.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();
                            string data = Convert.ToBase64String(byteImage);

                            content.Add("<TR class=shaded>");
                            content.Add("<TD colspan=3>");
                            content.Add("<img src=data:image/png;base64," + data + ">");
                            content.Add("<B>" + HTML.Process(aura.Name, true) + "</B>");
                            // Keywords from their own field and from the start of the details (14.1.1.2).
                            string aura_keywords = aura.ShownKeywords;
                            if (aura_keywords != "")
                                content.Add("(" + aura_keywords + ")");
                            if (aura.Radius > 0)
                                content.Add(" &diams; Aura " + aura.Radius);
                            content.Add("</TD>");
                            content.Add("</TR>");

                            content.Add("<TR>");
                            content.Add("<TD colspan=3>");
                            content.Add(aura_details);
                            content.Add("</TD>");
                            content.Add("</TR>");

                            if (mode == CardMode.Build)
                            {
                                content.Add("<TR>");
                                content.Add("<TD colspan=3 align=center>");
                                content.Add("<A href=auraedit:" + aura.ID + ">edit</A>");
                                content.Add("|");
                                content.Add("<A href=auraremove:" + aura.ID + ">remove</A>");
                                content.Add("this aura");
                                content.Add("</TD>");
                                content.Add("</TR>");
                            }
                        }

                        // Regeneration
                        List<Regeneration> regen_list = new List<Regeneration>();
                        if (Regeneration != null)
                            regen_list.Add(Regeneration);
                        if (combat_data != null)
                        {
                            foreach (OngoingCondition oc in combat_data.Conditions)
                            {
                                if (oc.Type == OngoingType.Regeneration)
                                    regen_list.Add(oc.Regeneration);
                            }
                        }

                        foreach (Regeneration regen in regen_list)
                        {
                            content.Add("<TR class=shaded>");
                            content.Add("<TD colspan=3>");
                            content.Add("<B>Regeneration</B>");
                            content.Add("</TD>");
                            content.Add("</TR>");

                            content.Add("<TR>");
                            content.Add("<TD colspan=3>");
                            content.Add("Regeneration " + HTML.Process(regen.ToString(), true));
                            content.Add("</TD>");
                            content.Add("</TR>");

                            if (mode == CardMode.Build)
                            {
                                content.Add("<TR>");
                                content.Add("<TD colspan=3 align=center>");
                                content.Add("<A href=power:regenedit>edit</A>");
                                content.Add("|");
                                content.Add("<A href=power:regenremove>remove</A>");
                                content.Add("this trait");
                                content.Add("</TD>");
                                content.Add("</TR>");
                            }
                        }
                    }

                    foreach (CreaturePower cp in powers[cat])
                    {
                        CardMode power_mode = mode;
                        if (mode == CardMode.Build)
                            power_mode = CardMode.View;

                        bool used = ((combat_data != null) && (combat_data.UsedPowers.Contains(cp.ID)));
                        content.AddRange(cp.AsHTML(combat_data, power_mode, false));

                        if (mode == CardMode.Build)
                        {
                            content.Add("<TR>");
                            content.Add("<TD colspan=3 align=center>");
                            content.Add("<A href=\"poweredit:" + cp.ID + "\">edit</A>");
                            content.Add("|");
                            content.Add("<A href=\"powerremove:" + cp.ID + "\">remove</A>");
                            content.Add("|");
                            content.Add("<A href=\"powerduplicate:" + cp.ID + "\">duplicate</A>");
                            if (cat == CreaturePowerCategory.Trait)
                                content.Add("this trait");
                            else
                                content.Add("this power");
                            content.Add("</TD>");
                            content.Add("</TR>");
                        }
                    }
                }

                #endregion

                #region Skills

                string skills = Skills;
                if ((skills != null) && (skills.ToLower().Contains("perception")))
                {
                    // Remove the Perception skill (it is shown with the senses). Split outside
                    // parentheses, so a comma inside a note does not cut the note in two (14.1.0.15).
                    string str = "";
                    List<string> tokens = CreatureHelper.SplitSkillEntries(skills);
                    foreach (string token in tokens)
                    {
                        if (token.ToLower().Contains("perception"))
                            continue;

                        if (str != "")
                            str += "; ";

                        str += token;
                    }
                    skills = str;
                }
                if (skills == null)
                    skills = "";
                if ((skills == "") && (mode == CardMode.Build))
                    skills = "(none)";
                if (skills != "")
                {
                    skills = HTML.Process(skills, true);
                    if (mode == CardMode.Build)
                        skills = "<A href=build:skills>" + skills + "</A>";

                    content.Add("<TR class=shaded>");
                    content.Add("<TD colspan=3>");
                    content.Add("<B>Skills</B> " + skills);
                    content.Add("</TD>");
                    content.Add("</TR>");
                }

                #endregion

                #region Ability Scores

                content.Add("<TR class=shaded>");

                content.Add("<TD>");
                content.Add("<B>Str</B>: " + ability(creature.Strength, mode));
                content.Add("<BR>");
                content.Add("<B>Con</B>: " + ability(creature.Constitution, mode));
                content.Add("</TD>");

                content.Add("<TD>");
                content.Add("<B>Dex</B>: " + ability(creature.Dexterity, mode));
                content.Add("<BR>");
                content.Add("<B>Int</B>: " + ability(creature.Intelligence, mode));
                content.Add("</TD>");

                content.Add("<TD>");
                content.Add("<B>Wis</B>: " + ability(creature.Wisdom, mode));
                content.Add("<BR>");
                content.Add("<B>Cha</B>: " + ability(creature.Charisma, mode));
                content.Add("</TD>");

                content.Add("</TR>");

                #endregion

                #region Alignment

                string alignment = creature.Alignment;
                if (alignment == null)
                    alignment = "";
                if (alignment == "")
                {
                    if (mode == CardMode.Build)
                        alignment = "(not set)";
                    else
                        alignment = "Unaligned";
                }
                if (alignment != "")
                {
                    alignment = HTML.Process(alignment, true);
                    if (mode == CardMode.Build)
                        alignment = "<A href=build:alignment>" + alignment + "</A>";

                    content.Add("<TR>");
                    content.Add("<TD colspan=3>");
                    content.Add("<B>Alignment</B> " + alignment);
                    content.Add("</TD>");
                    content.Add("</TR>");
                }

                #endregion

                #region Languages

                string langs = creature.Languages;
                if (langs == null)
                    langs = "";
                if ((langs == "") && (mode == CardMode.Build))
                    langs = "(none)";
                if (langs != "")
                {
                    langs = HTML.Process(langs, true);
                    if (mode == CardMode.Build)
                        langs = "<A href=build:languages>" + langs + "</A>";

                    content.Add("<TR>");
                    content.Add("<TD colspan=3>");
                    content.Add("<B>Languages</B> " + langs);
                    content.Add("</TD>");
                    content.Add("</TR>");
                }

                #endregion

                #region Equipment

                string equip = Equipment;
                if (equip == null)
                    equip = "";
                if ((equip == "") && (mode == CardMode.Build))
                    equip = "(none)";
                if (equip != "")
                {
                    equip = HTML.Process(equip, true);
                    if (mode == CardMode.Build)
                        equip = "<A href=build:equipment>" + equip + "</A>";

                    content.Add("<TR>");
                    content.Add("<TD colspan=3>");
                    content.Add("<B>Equipment</B> " + equip);
                    content.Add("</TD>");
                    content.Add("</TR>");
                }

                #endregion

                #region Tactics

                string tactics = Tactics;
                if (tactics == null)
                    tactics = "";
                if ((tactics == "") && (mode == CardMode.Build))
                    tactics = "(none specified)";
                if (tactics != "")
                {
                    tactics = HTML.Process(tactics, true);
                    if (mode == CardMode.Build)
                        tactics = "<A href=build:tactics>" + tactics + "</A>";

                    content.Add("<TR>");
                    content.Add("<TD colspan=3>");
                    content.Add("<B>Tactics</B> " + tactics);
                    content.Add("</TD>");
                    content.Add("</TR>");
                }

                #endregion

                #region References / copyright

                Creature c = creature as Creature;

                List<string> references = new List<string>();

                if (c != null)
                {
                    Library lib = Session.FindLibrary(c);
                    if ((lib != null) && (lib.Name != ""))
                    {
                        if ((Session.Project == null) || (lib != Session.Project.Library))
                        {
                            string reference = HTML.Process(lib.Name, true);
                            references.Add(reference);
                        }
                    }
                }

                foreach (Guid template_id in fTemplateIDs)
                {
                    CreatureTemplate ct = Session.FindTemplate(template_id, SearchType.Global);
                    Library ct_lib = Session.FindLibrary(ct);

                    if ((ct_lib != null) && (ct_lib != Session.Project.Library))
                    {
                        if (references.Count != 0)
                            references.Add("<BR>");

                        string reference = HTML.Process(ct_lib.Name, true);
                        references.Add(ct.Name + " template: " + reference);
                    }
                }

                if (references.Count != 0)
                {
                    content.Add("<TR class=shaded>");
                    content.Add("<TD colspan=3>");
                    foreach (string reference in references)
                    {
                        content.Add(reference);
                    }
                    content.Add("</TD>");
                    content.Add("</TR>");
                }

                #endregion
            }

            if (mode != CardMode.Text)
            {
                content.Add("</TABLE>");
            }

            return content;
        }

        string ability(Ability ab, CardMode mode)
        {
            if (ab == null)
                return "-";

            int mod = ab.Modifier + (Level / 2);

            string str = "";

            switch (mode)
            {
                case CardMode.Combat:
                    str += "<A href=\"ability:" + mod + "\">";
                    break;
                case CardMode.Build:
                    str += "<A href=build:ability>";
                    break;
            }

            str += ab.Score.ToString();
            str += " ";

            string mod_str = mod.ToString();
            if (mod >= 0)
                mod_str = "+" + mod_str;
            str += "(" + mod_str + ")";

            switch (mode)
            {
                case CardMode.Combat:
                    str += "</A>";
                    break;
                case CardMode.Build:
                    str += "</A>";
                    break;
            }

            return str;
        }
    }
}
