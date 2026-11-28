#nullable disable

using System;
using System.Collections.Generic;

namespace Masterplan.Data
{
    /// <summary>
    /// What an encounter card showed when its file was saved: the copy of the results that a file
    /// stores beside the card's settings. A loaded card whose creature cannot be found anywhere
    /// shows these values (see <see cref="EncounterCard.CreatureMissing"/>).
    /// </summary>
    /// <remarks>
    /// WHY (for new developers): a card normally CALCULATES everything from its creature, then
    /// applies its templates, theme, level adjustment and the campaign settings. Without the
    /// creature there is nothing to calculate from. These values already include all of those
    /// changes, so they are shown AS THEY ARE: applying anything again would count it twice (until
    /// 14.1.1.0 the theme was added again at every save and open, and HP grew).
    ///
    /// EXAMPLE FLOW: open a project -> the card's creature is not found -> the load code
    /// (LibraryConversionService) fills this class from the file and hands it to the card -> the
    /// card's properties return these values -> saving writes the same values back. If the creature
    /// is found again later, the card calculates from the creature as usual.
    ///
    /// This class is not saved by itself: the card's properties return its values, and saving a card
    /// stores what the properties return.
    /// </remarks>
    public class SavedCardValues
    {
        public string Title = "";
        public string Info = "";
        public int XP;
        public int Level;

        public List<RoleType> Roles = new List<RoleType>();
        public RoleFlag Flag = RoleFlag.Standard;
        public bool Leader;
        public CardCategory Category = CardCategory.SoldierBrute;

        public int HP;
        public int AC;
        public int Fortitude;
        public int Reflex;
        public int Will;
        public int Initiative;

        public Regeneration Regeneration; // null when the creature has none
        public List<Aura> Auras = new List<Aura>();
        public List<CreaturePower> CreaturePowers = new List<CreaturePower>();
        public List<DamageModifier> DamageModifiers = new List<DamageModifier>();

        public string Senses = "";
        public string Movement = "";
        public string Equipment = "";
        public string Skills = "";
        public string Resist = "";
        public string Vulnerable = "";
        public string Immune = "";
        public string Tactics = "";

        /// <summary>
        /// A temporary creature for the few things a stat block asks the creature itself for and the
        /// card does not store (whether it is a minion, ability scores, size, alignment, ...).
        /// </summary>
        /// <remarks>
        /// It is never saved and never added to the project. Values the file does not hold keep the
        /// defaults of a new creature, which is also what the program showed before 14.1.1.0.
        /// </remarks>
        internal ICreature MakeStandIn(Guid creature_id)
        {
            CustomCreature creature = new CustomCreature();
            creature.ID = creature_id;
            creature.Name = Title;
            creature.Details = Info;
            creature.Level = Level;

            // A minion is its own kind of role; every other card has an ordinary role.
            if (Category == CardCategory.Minion)
                creature.Role = new Minion();
            else
                creature.Role = new ComplexRole
                {
                    Type = (Roles.Count != 0) ? Roles[0] : RoleType.Artillery,
                    Flag = Flag,
                    Leader = Leader
                };

            creature.Senses = Senses;
            creature.Movement = Movement;
            creature.Equipment = Equipment;
            creature.Skills = Skills;
            creature.Resist = Resist;
            creature.Vulnerable = Vulnerable;
            creature.Immune = Immune;
            creature.Tactics = Tactics;
            return creature;
        }
    }
}
