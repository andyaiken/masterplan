using System;
using System.Collections.Generic;

using Masterplan.Tools;

namespace Masterplan.Data
{
	/// <summary>
	/// Class representing a combat encounter game element.
	/// </summary>
	[Serializable]
	public class Encounter : IElement
	{
		/// <summary>
		/// Gets or sets the list of encounter slots.
		/// </summary>
		public List<EncounterSlot> Slots
		{
			get { return fSlots; }
			set { fSlots = value; }
		}
		List<EncounterSlot> fSlots = new List<EncounterSlot>();

		/// <summary>
		/// Gets or sets the list of traps in the encounter.
		/// </summary>
		public List<Trap> Traps
		{
			get { return fTraps; }
			set { fTraps = value; }
		}
		List<Trap> fTraps = new List<Trap>();

		/// <summary>
		/// Gets or sets the list of skill challenges in the encounter.
		/// </summary>
		public List<SkillChallenge> SkillChallenges
		{
			get { return fSkillChallenges; }
			set { fSkillChallenges = value; }
		}
		List<SkillChallenge> fSkillChallenges = new List<SkillChallenge>();

		/// <summary>
		/// Gets or sets the list of custom map tokens.
		/// </summary>
		public List<CustomToken> CustomTokens
		{
			get { return fCustomTokens; }
			set { fCustomTokens = value; }
		}
		List<CustomToken> fCustomTokens = new List<CustomToken>();

		/// <summary>
		/// Gets or sets the ID of the map to be used, or Guid.Empty to use no map.
		/// </summary>
		public Guid MapID
		{
			get { return fMapID; }
			set { fMapID = value; }
		}
		Guid fMapID = Guid.Empty;

		/// <summary>
		/// Gets or sets the ID of the map area to be used, or Guid.Empty to use the full map.
		/// </summary>
		public Guid MapAreaID
		{
			get { return fMapAreaID; }
			set { fMapAreaID = value; }
		}
		Guid fMapAreaID = Guid.Empty;

		/// <summary>
		/// Gets or sets the list of encounter notes.
		/// </summary>
		public List<EncounterNote> Notes
		{
			get { return fNotes; }
			set { fNotes = value; }
		}
		List<EncounterNote> fNotes = new List<EncounterNote>();

		/// <summary>
		/// Gets or sets the list of encounter waves.
		/// </summary>
		public List<EncounterWave> Waves
		{
			get { return fWaves; }
			set { fWaves = value; }
		}
		List<EncounterWave> fWaves = new List<EncounterWave>();

		/// <summary>
		/// Gets the number of creatures in the encounter.
		/// </summary>
		public int Count
		{
			get
			{
				int count = 0;

				foreach (EncounterSlot slot in AllSlots)
					count += slot.CombatData.Count;

				return count;
			}
		}

		/// <summary>
		/// Gets the collection of all the encounter slots for all waves of the encounter.
		/// </summary>
		public List<EncounterSlot> AllSlots
		{
			get
			{
				List<EncounterSlot> slots = new List<EncounterSlot>();

				slots.AddRange(fSlots);

				if (fWaves != null)
				{
					foreach (EncounterWave ew in fWaves)
						slots.AddRange(ew.Slots);
				}

				return slots;
			}
		}

        /// <summary>
        /// Finds the encounter slot with the given ID.
        /// </summary>
        /// <param name="slot_id">The ID of the slot.</param>
        /// <returns>Returns the slot, or null if no such slot exists.</returns>
        public EncounterSlot FindSlot(Guid slot_id)
        {
            foreach (EncounterSlot slot in AllSlots)
            {
                if (slot.ID == slot_id)
                    return slot;
            }

            return null;
        }

		/// <summary>
		/// Finds the encounter slot with the given combat data.
		/// </summary>
		/// <param name="data">The combat data.</param>
		/// <returns>Returns the slot, or null if no such slot exists.</returns>
		public EncounterSlot FindSlot(CombatData data)
		{
			foreach (EncounterSlot slot in AllSlots)
			{
				if (slot.CombatData.Contains(data))
					return slot;
			}

			return null;
		}

		/// <summary>
		/// Finds the encounter wave with the given encounter slot.
		/// </summary>
		/// <param name="slot">The encounter slot.</param>
		/// <returns>Returns the wave, or null if no such wave exists.</returns>
		public EncounterWave FindWave(EncounterSlot slot)
		{
			foreach (EncounterWave ew in fWaves)
			{
				if (ew.Slots.Contains(slot))
					return ew;
			}

			return null;
		}

		/// <summary>
		/// Searches for the CombatData with the given ID.
		/// </summary>
		/// <param name="id">The id to search for.</param>
		/// <returns>Returns the CombatData if it exists; null otherwise.</returns>
		public CombatData FindCombatData(Guid id)
		{
			foreach (EncounterSlot slot in AllSlots)
			{
				foreach (CombatData cd in slot.CombatData)
				{
					if (cd.ID == id)
						return cd;
				}
			}

			return null;
		}

		/// <summary>
		/// Finds the trap with the given ID.
		/// </summary>
		/// <param name="trap_id">The ID of the trap.</param>
		/// <returns>Returns the trap, or null if no such trap exists.</returns>
		public Trap FindTrap(Guid trap_id)
		{
			foreach (Trap trap in fTraps)
			{
				if (trap.ID == trap_id)
					return trap;
			}

			return null;
		}

		/// <summary>
		/// Finds the skill challenge with the given ID.
		/// </summary>
		/// <param name="challenge_id">The ID of the skill challenge.</param>
		/// <returns>Returns the skill challenge, or null if no such trap exists.</returns>
		public SkillChallenge FindSkillChallenge(Guid challenge_id)
		{
			foreach (SkillChallenge sc in fSkillChallenges)
			{
				if (sc.ID == challenge_id)
					return sc;
			}

			return null;
		}

		/// <summary>
		/// Finds the encounter note with the given title.
		/// </summary>
		/// <param name="note_title">The title of the note.</param>
		/// <returns>Returns the note, or null if no such note exists.</returns>
		public EncounterNote FindNote(string note_title)
		{
			foreach (EncounterNote note in fNotes)
			{
				if (note.Title == note_title)
					return note;
			}

			return null;
		}

		/// <summary>
		/// Determines whether the encounter contains the given combatant.
		/// </summary>
		/// <param name="combatant_id">The ID of a creature or NPC.</param>
		/// <returns>True if the encounter contains the creature; false otherwise.</returns>
		public bool Contains(Guid combatant_id)
		{
			foreach (EncounterSlot slot in AllSlots)
			{
				if (slot.Card.CreatureID == combatant_id)
					return true;
			}

			return false;
		}

		/// <summary>
		/// Returns the display name of a creature / hero / trap with the given ID.
		/// </summary>
		/// <param name="id">The ID to search for.</param>
		/// <returns>Returns the name if found; empty string otherwise.</returns>
		public string WhoIs(Guid id)
		{
			// Check slot combat data
			foreach (EncounterSlot slot in AllSlots)
			{
				foreach (CombatData data in slot.CombatData)
				{
					if (data.ID == id)
						return data.DisplayName;
				}
			}

			// Check heroes
			foreach (Hero hero in Session.Project.Heroes)
			{
				if (hero.ID == id)
					return hero.Name;
			}

			// Check traps
			foreach (Trap trap in fTraps)
			{
				if (trap.ID == id)
					return trap.Name;
			}

			return "";
		}

		/// <summary>
		/// Calculates the XP value of the encounter.
		/// </summary>
		/// <returns>Returns the encounter XP value.</returns>
		public int GetXP()
		{
			int total = 0;

			foreach (EncounterSlot slot in AllSlots)
				total += slot.XP;

			foreach (Trap trap in fTraps)
				total += trap.XP;

			foreach (SkillChallenge sc in fSkillChallenges)
				total += sc.GetXP();

			total = Math.Max(0, total);
			return total;
		}

		/// <summary>
		/// Calculates the level of the encounter.
		/// </summary>
		/// <param name="party_size">The party size.</param>
		/// <returns>Returns the encounter level.</returns>
		public int GetLevel(int party_size)
		{
            if (party_size == 0)
                return -1;

			int xp = GetXP();
			if (Session.Project != null)
				xp = (int)(xp / Session.Project.CampaignSettings.XP);

			xp /= party_size;

			int result = 0;
			int min_diff = int.MaxValue;

			for (int cl = 0; cl <= 40; ++cl)
			{
				int level_xp = Experience.GetCreatureXP(cl);
				int diff = Math.Abs(xp - level_xp);

				if (diff < min_diff)
				{
					result = cl;
					min_diff = diff;
				}
			}

			return result;
		}

		/// <summary>
		/// Calculates the difficulty of the encounter.
		/// </summary>
		/// <param name="party_level">The party level.</param>
		/// <param name="party_size">The party size.</param>
		/// <returns>Returns the encounter difficulty.</returns>
		public Difficulty GetDifficulty(int party_level, int party_size)
		{
			List<Difficulty> diffs = new List<Difficulty>();

			foreach (EncounterSlot slot in AllSlots)
			{
				if (slot.Type != EncounterSlotType.Opponent)
					continue;

				ICreature creature = Session.FindCreature(slot.Card.CreatureID, SearchType.Global);
				if (creature != null)
					diffs.Add(AI.GetThreatDifficulty(creature.Level + slot.Card.LevelAdjustment, party_level));
			}

			foreach (Trap trap in fTraps)
			{
				diffs.Add(AI.GetThreatDifficulty(trap.Level, party_level));
			}

			foreach (SkillChallenge sc in fSkillChallenges)
			{
				diffs.Add(sc.GetDifficulty(party_level, party_size));
			}

			diffs.Add(get_diff(party_level, party_size));

			if (diffs.Contains(Difficulty.Extreme))
				return Difficulty.Extreme;

			if (diffs.Contains(Difficulty.Hard))
				return Difficulty.Hard;

			if (diffs.Contains(Difficulty.Moderate))
				return Difficulty.Moderate;

			if (diffs.Contains(Difficulty.Easy))
				return Difficulty.Easy;

			return Difficulty.Trivial;
		}

        /// <summary>
        /// Adds blank standard notes to the encounter.
        /// </summary>
        public void SetStandardEncounterNotes()
        {
            fNotes.Add(new EncounterNote("Illumination"));
            fNotes.Add(new EncounterNote("Features of the Area"));
            fNotes.Add(new EncounterNote("Setup"));
            fNotes.Add(new EncounterNote("Tactics"));
            fNotes.Add(new EncounterNote("Victory Conditions"));
        }

		/// <summary>
		/// Creates a copy of the encounter.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public IElement Copy()
		{
			Encounter enc = new Encounter();

			foreach (EncounterSlot slot in fSlots)
				enc.Slots.Add(slot.Copy());

			foreach (Trap trap in fTraps)
				enc.Traps.Add(trap.Copy());

			foreach (SkillChallenge sc in fSkillChallenges)
				enc.SkillChallenges.Add(sc.Copy() as SkillChallenge);

			foreach (CustomToken ct in fCustomTokens)
				enc.CustomTokens.Add(ct.Copy());

			enc.MapID = fMapID;
			enc.MapAreaID = fMapAreaID;

			foreach (EncounterNote en in fNotes)
				enc.Notes.Add(en.Copy());

			foreach (EncounterWave ew in fWaves)
				enc.Waves.Add(ew.Copy());

			return enc;
		}

		Difficulty get_diff(int party_level, int party_size)
		{
			if (GetXP() <= 0)
				return Difficulty.Trivial;

			int level = GetLevel(party_size);
			int level_diff = level - party_level;

			if (level_diff < -2)
			{
				return Difficulty.Trivial;
			}
			else if ((level_diff == -2) || (level_diff == -1))
			{
				return Difficulty.Easy;
			}
			else if ((level_diff == 0) || (level_diff == 1))
			{
				return Difficulty.Moderate;
			}
			else if ((level_diff == 2) || (level_diff == 3) || (level_diff == 4))
			{
				return Difficulty.Hard;
			}
			else
			{
				return Difficulty.Extreme;
			}
		}
	}

    /// <summary>
    /// Class representing a piece of information about an encounter.
    /// </summary>
    [Serializable]
    public class EncounterNote
    {
		/// <summary>
		/// Default constructor.
		/// </summary>
		public EncounterNote()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="title">The title of the note.</param>
        public EncounterNote(string title)
		{
			fTitle = title;
		}

		/// <summary>
		/// Gets or sets the unique ID of the note.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the encounter note title.
        /// </summary>
        public string Title
        {
            get { return fTitle; }
            set { fTitle = value; }
        }
        string fTitle = "";

        /// <summary>
        /// Gets or sets the encounter note contents.
        /// </summary>
        public string Contents
        {
            get { return fContents; }
            set { fContents = value; }
        }
        string fContents = "";

		/// <summary>
		/// Creates a copy of the note.
		/// </summary>
		/// <returns>Returns the copy.</returns>
        public EncounterNote Copy()
		{
            EncounterNote en = new EncounterNote();

			en.ID = fID;
			en.Title = fTitle;
            en.Contents = fContents;

			return en;
		}

		/// <summary>
		/// Returns the note title.
		/// </summary>
		/// <returns>Returns the note title.</returns>
		public override string ToString()
		{
			return fTitle;
		}
    }

	/// <summary>
	/// Class representing a wave of combatants
	/// </summary>
	[Serializable]
	public class EncounterWave
	{
		/// <summary>
		/// Gets or sets the ID of the wave.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the name of the wave.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets whether the wave is active.
		/// </summary>
		public bool Active
		{
			get { return fActive; }
			set { fActive = value; }
		}
		bool fActive = false;

		/// <summary>
		/// Gets or sets the list of encounter slots in the wave.
		/// </summary>
		public List<EncounterSlot> Slots
		{
			get { return fSlots; }
			set { fSlots = value; }
		}
		List<EncounterSlot> fSlots = new List<EncounterSlot>();

		/// <summary>
		/// Gets the number of combatants in this wave.
		/// </summary>
		public int Count
		{
			get
			{
				int count = 0;
				foreach (EncounterSlot slot in fSlots)
					count += slot.CombatData.Count;

				return count;
			}
		}

		/// <summary>
		/// Creates a copy of the wave.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public EncounterWave Copy()
		{
			EncounterWave ew = new EncounterWave();

			ew.ID = fID;
			ew.Name = fName;
			ew.Active = fActive;

			foreach (EncounterSlot slot in fSlots)
				ew.Slots.Add(slot.Copy());

			return ew;
		}
	}
}
