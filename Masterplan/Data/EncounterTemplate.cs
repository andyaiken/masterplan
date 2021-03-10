using System;
using System.Collections.Generic;

namespace Masterplan.Data
{
	/// <summary>
	/// Class representing a group of EncounterTemplate items.
	/// </summary>
	[Serializable]
	public class EncounterTemplateGroup
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public EncounterTemplateGroup()
		{
		}

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">The name of the group.</param>
        /// <param name="category">The category of the group.</param>
        public EncounterTemplateGroup(string name, string category)
        {
            fName = name;
            fCategory = category;
        }

        /// <summary>
        /// Gets or sets the category of the group.
        /// </summary>
        public string Category
        {
            get { return fCategory; }
            set { fCategory = value; }
        }
        string fCategory = "";

        /// <summary>
        /// Gets or sets the name of the group.
        /// </summary>
        public string Name
        {
            get { return fName; }
            set { fName = value; }
        }
        string fName = "";

		/// <summary>
		/// Gets or sets the list of EncounterTemplate items.
		/// </summary>
		public List<EncounterTemplate> Templates
		{
			get { return fTemplates; }
			set { fTemplates = value; }
		}
		List<EncounterTemplate> fTemplates = new List<EncounterTemplate>();
	}

	/// <summary>
	/// Class representing a template for an encounter.
	/// </summary>
	[Serializable]
	public class EncounterTemplate
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public EncounterTemplate()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="diff">The difficulty of the template.</param>
		public EncounterTemplate(Difficulty diff)
		{
			fDifficulty = diff;
		}

		/// <summary>
		/// Gets or sets the difficulty of the template.
		/// </summary>
		public Difficulty Difficulty
		{
			get { return fDifficulty; }
			set { fDifficulty = value; }
		}
		Difficulty fDifficulty = Difficulty.Moderate;

		/// <summary>
		/// Gets or sets the list of slots in this template.
		/// </summary>
		public List<EncounterTemplateSlot> Slots
		{
			get { return fSlots; }
			set { fSlots = value; }
		}
		List<EncounterTemplateSlot> fSlots = new List<EncounterTemplateSlot>();

		/// <summary>
		/// Find a template slot matching the given encounter slot.
		/// </summary>
		/// <param name="enc_slot">The encounter slot.</param>
		/// <param name="level">The encounter level.</param>
		/// <returns>Returns the matching template slot, or null if no slot is found.</returns>
		public EncounterTemplateSlot FindSlot(EncounterSlot enc_slot, int level)
		{
			foreach (EncounterTemplateSlot template_slot in fSlots)
			{
				if (template_slot.Count < enc_slot.CombatData.Count)
					continue;

				bool match = template_slot.Match(enc_slot.Card, level);
				if (!match)
					continue;

				return template_slot;
			}

			return null;
		}

		/// <summary>
		/// Creates a copy of the template.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public EncounterTemplate Copy()
		{
			EncounterTemplate et = new EncounterTemplate();

			et.Difficulty = fDifficulty;

			foreach (EncounterTemplateSlot slot in fSlots)
				et.Slots.Add(slot.Copy());

			return et;
		}
	}

	/// <summary>
	/// Class representing a slot in an EncounterTemplate.
	/// </summary>
	[Serializable]
	public class EncounterTemplateSlot
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public EncounterTemplateSlot()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="count">The number of creatures.</param>
		/// <param name="level_adj">The level adjustment.</param>
		/// <param name="flag">The type of creature.</param>
		/// <param name="role">The allowed role.</param>
		public EncounterTemplateSlot(int count, int level_adj, RoleFlag flag, RoleType role)
		{
			fCount = count;
			fLevelAdjustment = level_adj;
			fFlag = flag;
			fRoles.Add(role);
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="count">The number of creatures.</param>
		/// <param name="level_adj">The level adjustment.</param>
		/// <param name="flag">The type of creature.</param>
		/// <param name="roles">The allowed roles.</param>
		public EncounterTemplateSlot(int count, int level_adj, RoleFlag flag, RoleType[] roles)
		{
			fCount = count;
			fLevelAdjustment = level_adj;
			fFlag = flag;
			fRoles.AddRange(roles);
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="count">The number of creatures.</param>
		/// <param name="level_adj">The level adjustment.</param>
		/// <param name="flag">The type of creature.</param>
		public EncounterTemplateSlot(int count, int level_adj, RoleFlag flag)
		{
			fCount = count;
			fLevelAdjustment = level_adj;
			fFlag = flag;
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="count">The number of creatures.</param>
		/// <param name="level_adj">The level adjustment.</param>
		/// <param name="role">The allowed role.</param>
		public EncounterTemplateSlot(int count, int level_adj, RoleType role)
		{
			fCount = count;
			fLevelAdjustment = level_adj;
			fRoles.Add(role);
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="count">The number of creatures.</param>
		/// <param name="level_adj">The level adjustment.</param>
		/// <param name="roles">The allowed roles.</param>
		public EncounterTemplateSlot(int count, int level_adj, RoleType[] roles)
		{
			fCount = count;
			fLevelAdjustment = level_adj;
			fRoles.AddRange(roles);
		}

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="count">The number of creatures.</param>
        /// <param name="level_adj">The level adjustment.</param>
        public EncounterTemplateSlot(int count, int level_adj)
        {
            fCount = count;
            fLevelAdjustment = level_adj;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="count">The number of creatures.</param>
        /// <param name="level_adj">The level adjustment.</param>
        /// <param name="minions">Whether the slot should contain minions.</param>
        public EncounterTemplateSlot(int count, int level_adj, bool minions)
        {
            fCount = count;
            fLevelAdjustment = level_adj;
            fMinions = minions;
        }

		/// <summary>
		/// Gets or sets the list of allowed roles.
		/// If empty, all roles are allowed.
		/// </summary>
		public List<RoleType> Roles
		{
			get { return fRoles; }
			set { fRoles = value; }
		}
		List<RoleType> fRoles = new List<RoleType>();

		/// <summary>
		/// Gets or sets the type of creature (standard, elite, solo).
		/// </summary>
		public RoleFlag Flag
		{
			get { return fFlag; }
			set { fFlag = value; }
		}
		RoleFlag fFlag = RoleFlag.Standard;

		/// <summary>
		/// Gets or sets the level adjustment.
		/// </summary>
		public int LevelAdjustment
		{
			get { return fLevelAdjustment; }
			set { fLevelAdjustment = value; }
		}
		int fLevelAdjustment = 0;

        /// <summary>
        /// Gets or sets the number of creatures in the slot.
        /// </summary>
        public int Count
        {
            get { return fCount; }
            set { fCount = value; }
        }
        int fCount = 1;

        /// <summary>
        /// Gets or sets whether the slot should contain minions.
        /// </summary>
        public bool Minions
        {
            get { return fMinions; }
            set { fMinions = value; }
        }
        bool fMinions = false;

		/// <summary>
		/// Determine whether a given creature fits this slot.
		/// </summary>
		/// <param name="card">The creature.</param>
		/// <param name="encounter_level">The level of the encounter.</param>
		/// <returns>True if the creature matches; false otherwise.</returns>
		public bool Match(EncounterCard card, int encounter_level)
		{
			ICreature creature = Session.FindCreature(card.CreatureID, SearchType.Global);

			// Check the level
			int level = encounter_level + fLevelAdjustment;
			if (level < 1)
				level = 1;
			if (creature.Level != level)
				return false;

            // Check minion status
            bool is_minion = (creature.Role is Minion);
            if (is_minion != fMinions)
                return false;

			// Check the role matches
			bool role_ok = false;
			if (fRoles.Count == 0)
			{
				// We match any role
				role_ok = true;
			}
			else
			{
                ComplexRole role = creature.Role as ComplexRole;
				foreach (RoleType r in card.Roles)
				{
					if (fRoles.Contains(role.Type))
					{
						role_ok = true;
						break;
					}
				}
			}
			if (!role_ok)
				return false;

			// Check the elite / solo flag matches
			if (fFlag != card.Flag)
				return false;

			return true;
		}

		/// <summary>
		/// Creates a copy of the slot.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public EncounterTemplateSlot Copy()
		{
			EncounterTemplateSlot slot = new EncounterTemplateSlot();

			slot.Roles.AddRange(fRoles);
			slot.Flag = fFlag;
			slot.LevelAdjustment = fLevelAdjustment;
			slot.Count = fCount;
            slot.Minions = fMinions;

			return slot;
		}
	}
}
