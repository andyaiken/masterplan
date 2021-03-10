using System;
using System.Collections.Generic;
using System.Drawing;

namespace Masterplan.Data
{
	/// <summary>
	/// Used to modify the XP cost of an EncounterSlot.
	/// </summary>
	public enum EncounterSlotType
	{
		/// <summary>
		/// Opponent.
		/// </summary>
		Opponent,

		/// <summary>
		/// Ally.
		/// </summary>
		Ally,
		
		/// <summary>
		/// Neutral.
		/// </summary>
		Neutral
	}

	/// <summary>
	/// Class representing a slot in an Encounter.
	/// </summary>
	[Serializable]
	public class EncounterSlot
	{
		/// <summary>
		/// Gets or sets the unique ID of the slot.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the creature occupying this slot.
		/// </summary>
		public EncounterCard Card
		{
			get { return fCard; }
			set { fCard = value; }
		}
		EncounterCard fCard = new EncounterCard();

		/// <summary>
		/// Gets or sets the type of slot.
		/// </summary>
		public EncounterSlotType Type
		{
			get { return fType; }
			set { fType = value; }
		}
		EncounterSlotType fType = EncounterSlotType.Opponent;

		/// <summary>
		/// Gets or sets the list of CombatData items for this slot.
		/// </summary>
		public List<CombatData> CombatData
		{
			get { return fCombatData; }
			set { fCombatData = value; }
		}
		List<CombatData> fCombatData = new List<CombatData>();

		/// <summary>
		/// Finds the CombatData item which has the specified map location.
		/// </summary>
		/// <param name="location">The map location.</param>
		/// <returns>Returns the CombatData item, if it exists; null otherwise.</returns>
		public CombatData FindCombatData(Point location)
		{
			foreach (CombatData cmd in fCombatData)
			{
				if (cmd.Location == location)
					return cmd;
			}

			return null;
		}

		/// <summary>
		/// Gets the XP value of the creature or creatures in this slot.
		/// </summary>
		public int XP
		{
			get
			{
				int mod = 0;
				switch (fType)
				{
					case EncounterSlotType.Opponent:
						mod = 1;
						break;
					case EncounterSlotType.Ally:
						mod = -1;
						break;
					case EncounterSlotType.Neutral:
						mod = 0;
						break;
				}

				return fCard.XP * fCombatData.Count * mod;
			}
		}

		/// <summary>
		/// Creates a copy of the slot.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public EncounterSlot Copy()
		{
			EncounterSlot slot = new EncounterSlot();

			slot.ID = fID;
			slot.Card = fCard.Copy();
			slot.Type = fType;

			foreach (CombatData ccd in fCombatData)
				slot.CombatData.Add(ccd.Copy());

			return slot;
		}

		/// <summary>
		/// Sets the default display name for each CombatData element in the slot.
		/// </summary>
		public void SetDefaultDisplayNames()
		{
			string title = fCard.Title;

			if (fCombatData == null)
			{
				fCombatData = new List<CombatData>();
				fCombatData.Add(new CombatData());
			}

			foreach (CombatData cd in fCombatData)
			{
				if (fCombatData.Count == 1)
				{
					cd.DisplayName = title;
				}
				else
				{
					int n = fCombatData.IndexOf(cd) + 1;
					cd.DisplayName = title + " " + n;
				}
			}
		}

		/// <summary>
		/// Determines the combat state (active, bloodied, defeated) for a creature.
		/// </summary>
		/// <param name="data">The CombatData object for the creature.</param>
		/// <returns>Returns the CreatureState for the creature.</returns>
		public CreatureState GetState(CombatData data)
		{
			int hp_max = fCard.HP;

			int hp_bloodied = hp_max / 2;
			int hp_current = hp_max - data.Damage;

			if (hp_current <= 0)
				return CreatureState.Defeated;

			if (hp_current <= hp_bloodied)
				return CreatureState.Bloodied;

			return CreatureState.Active;
		}
	}
}
