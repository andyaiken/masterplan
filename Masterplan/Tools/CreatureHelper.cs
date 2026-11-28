#nullable disable

using Masterplan.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Masterplan.Tools
{
    /*
     * JUNIOR DEVELOPER GUIDE:
     * CreatureHelper is a utility class containing static methods for manipulating Creature data.
     * It handles three main types of tasks:
     * 1. Data Management: Copying fields between creature instances.
     * 2. Statblock Parsing: Extracting structured data (like a power's Range) from raw text fields.
     *    An aura is NEVER turned into regeneration, whatever its name. Until 14.1.1.3 loading a file
     *    did that to an aura named "Regeneration" or "Regen": it replaced the creature's own
     *    regeneration, removed the aura and its keywords, and could read the aura's radius as the
     *    regeneration value. User data stays as it was saved; do not bring the conversion back.
     * 3. Math & Scaling: Adjusting a creature's level and automatically scaling its stats (HP, Defences, Attack Bonuses) 
     *    according to D&D 4th Edition rules.
     * 
     * THINNING PROCESS NOTES (MasterplanXP Migration):
     * 1. Scaling Logic (AdjustCreatureLevel): This contains pure D&D 4e business rules. It should be moved 
     *    to 'MasterplanXP.Core' so it can be reused by both the UI and any CLI tools without legacy dependencies.
     * 2. Parsing Logic (UpdatePowerRange, ParseSkills): Legacy Masterplan relies heavily on 
     *    string parsing of "Details" fields. In MasterplanXP, we should prefer structured data at the DTO level, 
     *    but these methods should be moved to a 'StatblockParsingService' in 'MasterplanXP.Infrastructure'.
     * 3. CopyFields: This manual mapping is fragile. In the new architecture, we use DTOs and the Bridge project 
     *    to handle object state transitions.
     * 4. Logging: Replaces 'LogSystem.Trace' with 'Microsoft.Extensions.Logging' in the new projects.
     */

    /// <summary>
    /// Utility class for creature-related operations, including deep copying, 
    /// level scaling, and text parsing.
    /// </summary>
    class CreatureHelper
    {
        /// <summary>
        /// Performs a deep copy of all fields from one ICreature to another.
        /// THINNING NOTE: Replace with AutoMapper or DTO mapping in MasterplanXP.
        /// </summary>
        /// <param name="copy_from">The source creature.</param>
        /// <param name="copy_to">The destination creature.</param>
        public static void CopyFields(ICreature copy_from, ICreature copy_to)
        {
            try
            {
                if (copy_from != null)
                {
                    copy_to.ID = copy_from.ID;
                    copy_to.Name = copy_from.Name;
                    copy_to.Details = copy_from.Details;
                    copy_to.Size = copy_from.Size;
                    copy_to.Origin = copy_from.Origin;
                    copy_to.Type = copy_from.Type;
                    copy_to.Keywords = copy_from.Keywords;
                    copy_to.Level = copy_from.Level;
                    copy_to.Role = (copy_from.Role != null) ? copy_from.Role.Copy() : null;
                    copy_to.Senses = copy_from.Senses;
                    copy_to.Movement = copy_from.Movement;
                    copy_to.Alignment = copy_from.Alignment;
                    copy_to.Languages = copy_from.Languages;
                    copy_to.Skills = copy_from.Skills;
                    copy_to.Equipment = copy_from.Equipment;
                    copy_to.Category = copy_from.Category;

                    copy_to.Strength = (copy_from.Strength != null) ? copy_from.Strength.Copy() : new Ability();
                    copy_to.Constitution = (copy_from.Constitution != null) ? copy_from.Constitution.Copy() : new Ability();
                    copy_to.Dexterity = (copy_from.Dexterity != null) ? copy_from.Dexterity.Copy() : new Ability();
                    copy_to.Intelligence = (copy_from.Intelligence != null) ? copy_from.Intelligence.Copy() : new Ability();
                    copy_to.Wisdom = (copy_from.Wisdom != null) ? copy_from.Wisdom.Copy() : new Ability();
                    copy_to.Charisma = (copy_from.Charisma != null) ? copy_from.Charisma.Copy() : new Ability();

                    copy_to.HP = copy_from.HP;
                    copy_to.Initiative = copy_from.Initiative;
                    copy_to.AC = copy_from.AC;
                    copy_to.Fortitude = copy_from.Fortitude;
                    copy_to.Reflex = copy_from.Reflex;
                    copy_to.Will = copy_from.Will;

                    copy_to.Regeneration = (copy_from.Regeneration != null) ? copy_from.Regeneration.Copy() : null;

                    copy_to.Auras.Clear();
                    foreach (Aura aura in copy_from.Auras)
                        copy_to.Auras.Add(aura.Copy());

                    copy_to.CreaturePowers.Clear();
                    foreach (CreaturePower cp in copy_from.CreaturePowers)
                        copy_to.CreaturePowers.Add(cp.Copy());

                    copy_to.DamageModifiers.Clear();
                    foreach (DamageModifier dm in copy_from.DamageModifiers)
                        copy_to.DamageModifiers.Add(dm.Copy());

                    copy_to.Resist = copy_from.Resist;
                    copy_to.Vulnerable = copy_from.Vulnerable;
                    copy_to.Immune = copy_from.Immune;
                    copy_to.Tactics = copy_from.Tactics;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }
        }

        /// <summary>
        /// Applies a creature template to a creature for good (the Creature Builder's template link):
        /// the creature becomes what an encounter card with that template shows, and keeps everything
        /// the template does not change.
        /// </summary>
        /// <remarks>
        /// What the template changes: the name (the template's name in front), level, role, senses,
        /// movement, resistances / vulnerabilities / immunities, HP, defenses, initiative,
        /// regeneration, and the auras, powers and damage modifiers (the card's, which include the
        /// template's). Everything else stays exactly as it was (MPX-D38): skills, ability scores,
        /// alignment, languages, equipment, keywords, origin, type, size, description, tactics,
        /// category, picture and ID.
        /// Moved here from CreatureBuilderForm in 14.1.0.15 (finding F16). Until 14.1.0.14 the result
        /// started as an EMPTY creature that was then copied over the original, so applying a template
        /// erased the skills, reset the ability scores to 10 and emptied alignment, languages,
        /// equipment, keywords, description and tactics (confirmed by the project owner, 2026-11-19).
        /// Still open (M14.2): the powers come from the card's display list, which also carries the
        /// campaign settings' adjustments.
        /// </remarks>
        /// <param name="creature">The creature to change (a Creature, CustomCreature or NPC).</param>
        /// <param name="template_id">The template's ID; it is looked up through the session, as the card does.</param>
        public static void ApplyTemplate(ICreature creature, Guid template_id)
        {
            // An encounter card with the template works out the templated numbers; it reads the
            // creature as it is now, so build the result before the creature is changed.
            EncounterCard card = new EncounterCard(creature);
            card.TemplateIDs.Add(template_id);

            ICreature result = null;
            if (creature is Creature)
                result = new Creature();
            if (creature is CustomCreature)
                result = new CustomCreature();
            if (creature is NPC)
                result = new NPC();
            if (result == null)
                return;

            // Start from a FULL copy, so everything the template does not change is kept.
            CopyFields(creature, result);

            result.Name = card.Title;
            result.Level = card.Level;

            result.Senses = card.Senses;
            result.Movement = card.Movement;
            result.Resist = card.Resist;
            result.Vulnerable = card.Vulnerable;
            result.Immune = card.Immune;

            // Role
            ComplexRole cr = new ComplexRole();
            cr.Leader = card.Leader;
            cr.Flag = card.Flag;
            cr.Type = card.Roles[0];
            result.Role = cr;

            // Combat stats
            result.Initiative = card.Initiative;
            result.HP = card.HP;
            result.AC = card.AC;
            result.Fortitude = card.Fortitude;
            result.Reflex = card.Reflex;
            result.Will = card.Will;

            // Regeneration
            result.Regeneration = (card.Regeneration != null) ? card.Regeneration : null;

            // Auras, powers and damage modifiers: replaced by the card's (the creature's own plus the
            // template's), so the copied ones are cleared first.
            result.Auras.Clear();
            foreach (Aura aura in card.Auras)
                result.Auras.Add(aura.Copy());

            result.CreaturePowers.Clear();
            foreach (CreaturePower power in card.CreaturePowers)
                result.CreaturePowers.Add(power.Copy());

            result.DamageModifiers.Clear();
            foreach (DamageModifier mod in card.DamageModifiers)
                result.DamageModifiers.Add(mod.Copy());

            Guid id = creature.ID;
            CopyFields(result, creature);
            creature.ID = id;
        }

        /// <summary>
        /// Attempts to parse and update a power's Range field based on keywords in its Details text.
        /// THINNING NOTE: Move to a 'StatblockParsingService'.
        /// </summary>
        /// <param name="c">The creature owning the power.</param>
        /// <param name="power">The power to analyze.</param>
        public static void UpdatePowerRange(ICreature c, CreaturePower power)
        {
            // A missing range counts as a blank one.
            if (power.Range == null)
                power.Range = "";

            // A range that is ONLY the word "Self" (any capitals, spaces around it ignored) is
            // written as "Personal". The WHOLE range must be that word: any other text, such as
            // "Close burst 2 (Self and allies)", stays exactly as stored. Until 14.1.1.4 such a
            // range was replaced by "Personal" if it had "Self" and no lowercase "self".
            if (power.Range.Trim().Equals("Self", StringComparison.OrdinalIgnoreCase))
            {
                power.Range = "Personal";
                return;
            }

            // If the range field is not empty - do nothing
            if (power.Range != "")
                return;

            // Malformed details will impact parsing
            // in that case send back - do nothing
            if ((power.Details == null) || !power.Details.Contains(";"))
                return;

            // Start the parsing process to derive the
            // range of an attack from text on details field

            // Define the 5 ranges to be parsed.
            List<string> ranges = new List<string>();
            ranges.Add("close blast");
            ranges.Add("close burst");
            ranges.Add("area burst");
            ranges.Add("melee");
            ranges.Add("ranged");

            // split the details on the ";" delimiter for parsing
            string[] clauses = power.Details.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string clause in clauses)
            {
                foreach (string range in ranges)
                {
                    if (clause.ToLower().Contains(range))
                    {
                        try
                        {
                            int startIndex = clause.ToLower().IndexOf(range);
                            int endIndex = clause.Length;
                            power.Range = clause.Substring(startIndex, (endIndex - startIndex));

                            // Only the range is filled in. The power's usage is never changed: until
                            // 14.1.1.4 the word "basic" here turned an at-will power into a basic attack.
                            break;
                        }
                        catch { } // Error Handling

                    }
                }
            }
        }

        /// <summary>
        /// Filters creature powers by their category (Standard, Minor, etc.).
        /// </summary>
        /// <param name="c">The creature.</param>
        /// <param name="category">The category to filter by.</param>
        /// <returns>A list of matching powers.</returns>
        public static List<CreaturePower> CreaturePowersByCategory(ICreature c, CreaturePowerCategory category)
        {
            List<CreaturePower> powers = new List<CreaturePower>();

            foreach (CreaturePower cp in c.CreaturePowers)
            {
                if (cp.Category == category)
                    powers.Add(cp);
            }

            return powers;
        }

        /// <summary>
        /// Mathematically adjusts a creature's level, scaling HP, Defences, and Powers accordingly.
        /// THINNING NOTE: CORE BUSINESS LOGIC. Move to MasterplanXP.Core.
        /// </summary>
        /// <remarks>
        /// A plain Creature stores its HP, initiative and defenses as numbers, so they are moved here.
        /// A CustomCreature or NPC does not: it stores only its difference from the standard numbers
        /// and works out HP, initiative and defenses from its level, so changing the level moves them
        /// by itself (and keeps that difference). Until 14.1.0.13 they were moved here as well, so
        /// every level up counted twice for them (a soldier gained 16 HP and 2 AC per level instead
        /// of 8 and 1). Powers and skills are stored as they are by all three, so they are always
        /// adjusted here.
        /// </remarks>
        /// <param name="creature">The creature to scale.</param>
        /// <param name="delta">The number of levels to add or subtract.</param>
        public static void AdjustCreatureLevel(ICreature creature, int delta)
        {
            if (creature is Creature)
                adjust_stored_statistics(creature, delta);

            // Powers Scaling
            foreach (CreaturePower cp in creature.CreaturePowers)
                AdjustPowerLevel(cp, delta);

            // Skills Scaling: only each skill's own number moves; everything else in the skills text
            // (notes, order, separators) stays exactly as the user typed it (14.1.0.14 and earlier
            // rewrote the whole line and lost anything it could not read; see AdjustSkillsText).
            creature.Skills = AdjustSkillsText(creature.Skills, creature.Level, creature.Level + delta);

            // Level Update
            creature.Level += delta;
        }

        // The start of one skills entry: the skill name (letters, optionally with a qualifier in
        // parentheses: "Knowledge (arcana)"), spaces, and the skill's own number ("+N", "-N", "N", or
        // the old "--N", which ParseSkills reads as -N). Whatever follows the number (a note such as
        // "(only with dragons)") is not part of the match, so it is kept exactly as typed.
        static readonly Regex fSkillStart = new Regex(
            @"^(?<lead>\s*)(?<name>[A-Za-z]+(\s*\([^()]*\))?)(?<gap>\s+)(?<value>(\+|--?)?\d{1,4})(?!\d)");

        /// <summary>
        /// Moves the skill numbers in a creature's skills text by the change in half level (a skill
        /// total includes half the creature's level). In each entry only the skill's own number
        /// changes; everything else stays exactly as the user typed it: notes, unusual names, the
        /// order and the separators. "Diplomacy +9 (only with dragons)" becomes "Diplomacy +10 (only
        /// with dragons)" when half the level goes up by 1.
        /// </summary>
        /// <remarks>
        /// Added in 14.1.0.15 (finding F20). Until 14.1.0.14 a level change read the skills with
        /// ParseSkills and wrote the whole line again, sorted, from what it understood: "Perception +8
        /// (trained)" became "Perception +0" and "Knowledge (arcana) +5" became "Knowledge +0", for
        /// good. Rule (project owner, 2026-11-19, MPX-D38): what the user enters is saved exactly as
        /// entered, even when it breaks the standard rules; an adjustment changes only the numbers it
        /// understands.
        /// Numbers INSIDE a note are left alone (project owner, 2026-11-19): in "Stealth +10 (+15 in
        /// shadows)" the +15 is another total, but in "Perception +8 (+2 vs. undead)" the +2 is a bonus
        /// that must not change, and the two cannot be told apart. An entry that does not start with a
        /// name and a number ("Insight (see tactics)") is left as typed.
        /// </remarks>
        /// <param name="skills">The creature's skills text, e.g. "Perception +8, Stealth +10".</param>
        /// <param name="old_level">The creature's level before the change.</param>
        /// <param name="new_level">The creature's level after the change.</param>
        /// <returns>The adjusted text, or the text unchanged if half the level stays the same.</returns>
        public static string AdjustSkillsText(string skills, int old_level, int new_level)
        {
            if (string.IsNullOrEmpty(skills))
                return skills;

            // The same change in half level the old code applied to every skill.
            int change = (new_level / 2) - (old_level / 2);
            if (change == 0)
                return skills; // saved text is never touched when nothing changes

            return rewrite_skill_numbers(skills, (name, value) => value + change);
        }

        /// <summary>
        /// A creature's skills text for SHOWING (stat blocks, combat): every skill's own number moved
        /// by the change in half level from <paramref name="creature_level"/> to
        /// <paramref name="shown_level"/>, and always written with a sign ("perception 8" is shown as
        /// "perception +8", the old "--2" as "-2"). Everything else is shown as typed (MPX-D38).
        /// </summary>
        /// <remarks>
        /// Added in 14.1.0.15. Until 14.1.0.14 the stat block rebuilt the skills from ParseSkills,
        /// which split notes at their commas and showed anything that was not a plain number as +0
        /// ("Stealth +10 (+15 in shadows, at night)" showed as "Stealth +0" and "at +0").
        /// </remarks>
        /// <param name="skills">The creature's skills text (with theme bonuses already added, if any).</param>
        /// <param name="creature_level">The creature's own level.</param>
        /// <param name="shown_level">The level the card shows (with its level adjustment).</param>
        /// <returns>The text to show.</returns>
        public static string FormatSkills(string skills, int creature_level, int shown_level)
        {
            if (string.IsNullOrEmpty(skills))
                return "";

            int change = (shown_level / 2) - (creature_level / 2);
            return rewrite_skill_numbers(skills, (name, value) => value + change);
        }

        /// <summary>
        /// Adds <paramref name="bonus"/> to the number of the skill called <paramref name="skill_name"/>
        /// (not case-sensitive; a qualifier such as "(arcana)" and a note are kept). Returns null if
        /// the text has no entry for that skill that starts with a number.
        /// </summary>
        /// <param name="skills">A skills text.</param>
        /// <param name="skill_name">The skill, e.g. "Stealth".</param>
        /// <param name="bonus">The bonus to add (a monster theme's skill bonus).</param>
        /// <returns>The text with the bonus added, or null if the skill was not found.</returns>
        public static string AddToSkill(string skills, string skill_name, int bonus)
        {
            if (string.IsNullOrEmpty(skills))
                return null;

            bool found = false;
            string result = rewrite_skill_numbers(skills, (name, value) =>
            {
                if (found || !same_skill(name, skill_name))
                    return value;

                found = true; // only the first entry for that skill gets the bonus
                return value + bonus;
            });

            return found ? result : null;
        }

        /// <summary>
        /// Splits a skills text into its entries at "," and ";", but not inside parentheses, so a note
        /// such as "(+15 in shadows, at night)" stays with its skill. Entries are trimmed; empty ones
        /// are left out.
        /// </summary>
        /// <param name="skills">A skills text.</param>
        /// <returns>The entries, in the order typed.</returns>
        public static List<string> SplitSkillEntries(string skills)
        {
            List<string> entries = new List<string>();
            foreach (string entry in split_keeping_separators(skills ?? "", out _))
            {
                string trimmed = entry.Trim();
                if (trimmed != "")
                    entries.Add(trimmed);
            }
            return entries;
        }

        // Rewrites the number of every entry that starts with a skill name and a number: the new
        // number is change(name, old number), always written with a sign. Everything else (entries
        // without a number, notes, spacing, separators) stays exactly as typed.
        static string rewrite_skill_numbers(string skills, Func<string, int, int> change)
        {
            List<string> entries = split_keeping_separators(skills, out List<char> separators);

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < entries.Count; ++i)
            {
                result.Append(rewrite_skill_entry(entries[i], change));
                if (i < separators.Count)
                    result.Append(separators[i]);
            }
            return result.ToString();
        }

        // Splits at "," and ";" outside parentheses; entries are not trimmed, and the separator after
        // each entry (but the last) is returned too, so the text can be put back together exactly.
        static List<string> split_keeping_separators(string skills, out List<char> separators)
        {
            List<string> entries = new List<string>();
            separators = new List<char>();

            int depth = 0;
            int start = 0;
            for (int i = 0; i < skills.Length; ++i)
            {
                char ch = skills[i];
                if (ch == '(')
                {
                    ++depth;
                }
                else if ((ch == ')') && (depth > 0))
                {
                    --depth;
                }
                else if (((ch == ',') || (ch == ';')) && (depth == 0))
                {
                    entries.Add(skills.Substring(start, i - start));
                    separators.Add(ch);
                    start = i + 1;
                }
            }
            entries.Add(skills.Substring(start));

            return entries;
        }

        // One entry of a skills text: its own number becomes change(name, number), the rest stays as typed.
        static string rewrite_skill_entry(string entry, Func<string, int, int> change)
        {
            Match m = fSkillStart.Match(entry);
            if (!m.Success)
                return entry;

            string number = m.Groups["value"].Value;
            if (number.StartsWith("--"))
                number = number.Substring(1); // the old "--2" means -2 (see ParseSkills)

            int value = change(m.Groups["name"].Value, int.Parse(number));
            string signed = (value >= 0) ? "+" + value : value.ToString();

            // Put the new number exactly where the old one was; the name, spacing and note stay as typed.
            return m.Groups["lead"].Value + m.Groups["name"].Value + m.Groups["gap"].Value + signed
                + entry.Substring(m.Index + m.Length);
        }

        // "Knowledge (arcana)" is the skill "Knowledge"; names are compared without case.
        static bool same_skill(string entry_name, string skill_name)
        {
            int paren = entry_name.IndexOf('(');
            string name = (paren >= 0) ? entry_name.Substring(0, paren) : entry_name;
            return string.Equals(name.Trim(), skill_name.Trim(), StringComparison.OrdinalIgnoreCase);
        }

        // HP, initiative and defenses of a creature that stores them as numbers (a plain Creature; see
        // the remarks on AdjustCreatureLevel). Called before the level itself changes.
        static void adjust_stored_statistics(ICreature creature, int delta)
        {
            // HP Scaling Logic
            if (creature.Role is ComplexRole)
            {
                ComplexRole role = creature.Role as ComplexRole;

                int hp = 8;
                switch (role.Type)
                {
                    case RoleType.Artillery:
                    case RoleType.Lurker:
                        hp = 6;
                        break;
                    case RoleType.Brute:
                        hp = 10;
                        break;
                }

                switch (role.Flag)
                {
                    case RoleFlag.Elite:
                        hp *= 2;
                        break;
                    case RoleFlag.Solo:
                        // A solo has 4 x a standard creature's HP (rules; Statistics.HP); it is only
                        // its XP that counts as 5 x. This was 5 until 14.1.0.13.
                        hp *= 4;
                        break;
                }

                creature.HP += hp * delta;
                creature.HP = Math.Max(creature.HP, 1);
            }

            // Initiative Scaling
            int init_bonus = creature.Initiative - (creature.Level / 2);
            creature.Initiative = init_bonus + ((creature.Level + delta) / 2);

            // Defences Scaling (Flat +1 per level)
            creature.AC += delta;
            creature.Fortitude += delta;
            creature.Reflex += delta;
            creature.Will += delta;
        }

        /// <summary>
        /// Brings a creature's combat statistics in line after its level and/or role were changed in
        /// its profile (the Creature Builder's profile link, when the user answers Yes to "update its
        /// combat statistics to match?"). Call it AFTER the profile has set the new level and role.
        /// </summary>
        /// <remarks>
        /// A level change goes through exactly the same code as the Level Up / Down buttons
        /// (AdjustCreatureLevel, by the whole difference): HP, initiative, defenses, every power's
        /// attack bonus and damage, and the skills all move together, and the creature's own
        /// adjustments above or below the standard numbers are kept. Before 14.1.0.14 the profile link
        /// replaced HP, initiative and defenses with the standard numbers and left powers and skills
        /// at the old level.
        /// A role change has no "difference" to apply, so HP, initiative, AC and the other defenses are
        /// set to the standard numbers for the new level and role (as before 14.1.0.14).
        /// The same for every kind of creature (Creature, CustomCreature, NPC): AdjustCreatureLevel
        /// itself knows which of them store their statistics as numbers.
        /// </remarks>
        /// <param name="creature">The creature, already showing its new level and role.</param>
        /// <param name="old_level">Its level before the profile was edited.</param>
        /// <param name="old_role">A copy of its role before the profile was edited.</param>
        public static void ApplyProfileChange(ICreature creature, int old_level, IRole old_role)
        {
            int new_level = creature.Level;
            IRole new_role = creature.Role;

            if (new_level != old_level)
            {
                // Same as pressing Level Up / Down (new_level - old_level) times, from the old level
                // and the old role (HP grows by the old role's amount per level).
                creature.Level = old_level;
                creature.Role = old_role;
                AdjustCreatureLevel(creature, new_level - old_level);
                creature.Role = new_role;
            }

            if (new_role.ToString() != old_role.ToString())
            {
                // HP
                if (creature.Role is ComplexRole)
                    creature.HP = Statistics.HP(creature.Level, creature.Role as ComplexRole, creature.Constitution.Score);
                else
                    creature.HP = 1;

                // Init
                creature.Initiative = Statistics.Initiative(creature.Level, creature.Role);

                // AC
                creature.AC = Statistics.AC(creature.Level, creature.Role);

                // Fort / Ref / Will
                creature.Fortitude = Statistics.NAD(creature.Level, creature.Role);
                creature.Reflex = Statistics.NAD(creature.Level, creature.Role);
                creature.Will = Statistics.NAD(creature.Level, creature.Role);
            }
        }

        /// <summary>
        /// Adjusts a power's attack bonus and damage based on level delta.
        /// </summary>
        /// <param name="cp">The power to adjust.</param>
        /// <param name="delta">The level delta.</param>
        public static void AdjustPowerLevel(CreaturePower cp, int delta)
        {
            if (cp.Attack != null)
                cp.Attack.Bonus += delta;

            // Adjust the damage in the power's text: only the dice are rewritten, the rest of the
            // text (damage type, extra damage, effects) is kept (14.1.0.14; see AI.AdjustDamageText).
            cp.Details = AI.AdjustDamageText(cp.Details, delta);
        }

        /// <summary>
        /// Parses a skills string (e.g. "Acrobatics +10, Stealth +12") into a dictionary.
        /// THINNING NOTE: Move to parsing service.
        /// </summary>
        /// <param name="source">The skills string.</param>
        /// <returns>A dictionary of skill names and their bonuses.</returns>
        public static Dictionary<string, int> ParseSkills(string source)
        {
            Dictionary<string, int> skill_list = new Dictionary<string, int>();

            if ((source != null) && (source != ""))
            {
                string[] skills = source.Split(new string[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string skill in skills)
                {
                    string str = skill.Trim();

                    int index = str.IndexOf(" ");
                    if (index != -1)
                    {
                        string skill_name = str.Substring(0, index);
                        string skill_bonus = str.Substring(index + 1);

                        // The Skills dialog in 14.1.0.12 and earlier saved negative skills with a
                        // doubled minus ("Stealth --2"), which int.Parse rejects (the skill became 0).
                        // Dropping one minus reads it as -2 again, so those creatures come back correct.
                        if (skill_bonus.StartsWith("--"))
                            skill_bonus = skill_bonus.Substring(1);

                        int bonus = 0;
                        try
                        {
                            bonus = int.Parse(skill_bonus);
                        }
                        catch
                        {
                            bonus = 0;
                        }

                        skill_list[skill_name] = bonus;
                    }
                }
            }

            return skill_list;
        }
    }
}
