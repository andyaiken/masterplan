using System;
using System.Collections.Generic;
using Utils;

namespace Masterplan.Data
{
	/// <summary>
	/// An encounter log, containing entries.
	/// </summary>
	[Serializable]
	public class EncounterLog
	{
		/// <summary>
		/// Gets or sets the list of encounter log entries.
		/// </summary>
		public List<IEncounterLogEntry> Entries
		{
			get { return fEntries; }
			set { fEntries = value; }
		}
		List<IEncounterLogEntry> fEntries = new List<IEncounterLogEntry>();

		/// <summary>
		/// Gets or sets whether the log responds to Add() methods.
		/// </summary>
		public bool Active
		{
			get { return fActive; }
			set { fActive = value; }
		}
		bool fActive = true;

		#region Adding entries

		/// <summary>
		/// Adds a StartRoundLogEntry to the log.
		/// </summary>
		/// <param name="round">The number of the round.</param>
		public void AddStartRoundEntry(int round)
		{
			if (!fActive)
				return;

			StartRoundLogEntry entry = new StartRoundLogEntry();
			entry.Round = round;
			fEntries.Add(entry);
		}

		/// <summary>
		/// Adds a StartTurnLogEntry to the log.
		/// </summary>
		/// <param name="id">The ID of the creature / hero / trap.</param>
		public void AddStartTurnEntry(Guid id)
		{
			if (!fActive)
				return;

			StartTurnLogEntry entry = new StartTurnLogEntry();
			entry.CombatantID = id;
			fEntries.Add(entry);
		}

		/// <summary>
		/// Adds a DamageLogEntry to the log.
		/// </summary>
		/// <param name="id">The ID of the creature / hero.</param>
		/// <param name="damage">The amount of damage (or healing if negative).</param>
		/// <param name="types">The damage type.</param>
		public void AddDamageEntry(Guid id, int damage, List<DamageType> types)
		{
			if (!fActive)
				return;

			DamageLogEntry entry = new DamageLogEntry();
			entry.CombatantID = id;
			entry.Amount = damage;
			entry.Types = types;
			fEntries.Add(entry);
		}

		/// <summary>
		/// Adds a StateLogEntry to the log.
		/// </summary>
		/// <param name="id">The ID of the creature / hero.</param>
		/// <param name="state">The new state.</param>
		public void AddStateEntry(Guid id, CreatureState state)
		{
			if (!fActive)
				return;

			StateLogEntry entry = new StateLogEntry();
			entry.CombatantID = id;
			entry.State = state;
			fEntries.Add(entry);
		}

		/// <summary>
		/// Adds an EffectLogEntry to the log.
		/// </summary>
		/// <param name="id">The ID of the creature / hero.</param>
		/// <param name="text">The text of the effect.</param>
		/// <param name="added">True if the effect is being added; false if it's being removed.</param>
		public void AddEffectEntry(Guid id, string text, bool added)
		{
			if (!fActive)
				return;

			EffectLogEntry entry = new EffectLogEntry();
			entry.CombatantID = id;
			entry.EffectText = text;
			entry.Added = added;
			fEntries.Add(entry);
		}

		/// <summary>
		/// Adds a PowerLogEntry to the log.
		/// </summary>
		/// <param name="id">The ID of the creature / hero.</param>
		/// <param name="text">The name of the power.</param>
		/// <param name="added">True if the power is being used; false if it's being recharged.</param>
		public void AddPowerEntry(Guid id, string text, bool added)
		{
			if (!fActive)
				return;

			PowerLogEntry entry = new PowerLogEntry();
			entry.CombatantID = id;
			entry.PowerName = text;
			entry.Added = added;
			fEntries.Add(entry);
		}

		/// <summary>
		/// Adds a SkillLogEntry to the log.
		/// </summary>
		/// <param name="id">The ID of the creature / hero.</param>
		/// <param name="text">The name of the skill.</param>
		public void AddSkillEntry(Guid id, string text)
		{
			if (!fActive)
				return;

			SkillLogEntry entry = new SkillLogEntry();
			entry.CombatantID = id;
			entry.SkillName = text;
			fEntries.Add(entry);
		}

		/// <summary>
		/// Adds a SkillChallengeLogEntry to the log.
		/// </summary>
		/// <param name="id">The ID of the creature / hero.</param>
		/// <param name="success">True for a success; false for a failure.</param>
		public void AddSkillChallengeEntry(Guid id, bool success)
		{
			if (!fActive)
				return;

			SkillChallengeLogEntry entry = new SkillChallengeLogEntry();
			entry.CombatantID = id;
			entry.Success = success;
			fEntries.Add(entry);
		}

		/// <summary>
		/// Adds a MoveEntry to the log.
		/// </summary>
		/// <param name="id">The ID of the token.</param>
		/// <param name="distance">The distance moved.</param>
		/// <param name="text">Any additional details.</param>
		public void AddMoveEntry(Guid id, int distance, string text)
		{
			if (!fActive)
				return;

			MoveLogEntry entry = new MoveLogEntry();
			entry.CombatantID = id;
			entry.Distance = distance;
			entry.Details = text;
			fEntries.Add(entry);
		}

		/// <summary>
		/// Adds a PauseLogEntry to the log.
		/// </summary>
		public void AddPauseEntry()
		{
			if (!fActive)
				return;

			PauseLogEntry entry = new PauseLogEntry();
			fEntries.Add(entry);
		}

		/// <summary>
		/// Adds a ResumeLogEntry to the log.
		/// </summary>
		public void AddResumeEntry()
		{
			if (!fActive)
				return;

			ResumeLogEntry entry = new ResumeLogEntry();
			fEntries.Add(entry);
		}

		#endregion

		internal EncounterReport CreateReport(Encounter enc, bool all_entries)
		{
			EncounterReport report = new EncounterReport();

			RoundLog round = null;
			TurnLog turn = null;
			foreach (IEncounterLogEntry entry in fEntries)
			{
				StartRoundLogEntry start_round = entry as StartRoundLogEntry;
				StartTurnLogEntry start_turn = entry as StartTurnLogEntry;
				if (start_round != null)
				{
					if (round != null)
						report.Rounds.Add(round);

					round = new RoundLog(start_round.Round);
				}
				else if (start_turn != null)
				{
					if (turn != null)
					{
						turn.End = start_turn.Timestamp;
						round.Turns.Add(turn);
					}

					turn = new TurnLog(start_turn.CombatantID);
					turn.Start = start_turn.Timestamp;
				}
				else
				{
					if (all_entries || entry.Important)
						turn.Entries.Add(entry);
				}
			}

			if (round != null)
			{
				if (turn != null)
				{
					if (turn.Entries.Count != 0)
						turn.End = turn.Entries[turn.Entries.Count - 1].Timestamp;

					round.Turns.Add(turn);
				}

				report.Rounds.Add(round);
			}

			return report;
		}

		internal static string GetName(Guid id, Encounter enc, bool detailed)
		{
			// Creature / NPC
			CombatData cd = enc.FindCombatData(id);
			if (cd != null)
			{
				if (detailed)
					return cd.DisplayName;

				EncounterSlot slot = enc.FindSlot(cd);
				if (slot != null)
				{
					ICreature c = Session.FindCreature(slot.Card.CreatureID, SearchType.Global);
					if ((c != null) && (c.Category != ""))
						return c.Category;
				}
			}

			// Hero
			Hero hero = Session.Project.FindHero(id);
			if (hero != null)
				return hero.Name;

			// Trap
			Trap trap = enc.FindTrap(id);
			if (trap != null)
				return trap.Name;

			return "Creature";
		}
	}

	/// <summary>
	/// Interface for encounter log entries.
	/// </summary>
	public interface IEncounterLogEntry
	{
		/// <summary>
		/// Gets the ID of the creature, hero or trap.
		/// </summary>
		Guid CombatantID { get; }

		/// <summary>
		/// Gets the timestamp for this entry.
		/// </summary>
		DateTime Timestamp { get; }

		/// <summary>
		/// Gets the HTML text description of the entry.
		/// </summary>
		/// <param name="enc">The encounter.</param>
		/// <param name="detailed">True if the description should include detailed creature names; false otherwise.</param>
		/// <returns>Returns a text description of this entry.</returns>
		string Description(Encounter enc, bool detailed);

		/// <summary>
		/// Gets whether the entry should always be shown.
		/// </summary>
		bool Important { get; }
	}

	#region Entry types

	/// <summary>
	/// Log entry for the start of a round.
	/// </summary>
	[Serializable]
	public class StartRoundLogEntry : IEncounterLogEntry
	{
		/// <summary>
		/// Gets the ID of the combatant.
		/// </summary>
		public Guid CombatantID
		{
			get { return Guid.Empty; }
		}

		/// <summary>
		/// Gets or sets the entry timestamp.
		/// </summary>
		public DateTime Timestamp
		{
			get { return fTimestamp; }
			set { fTimestamp = value; }
		}
		DateTime fTimestamp = DateTime.Now;

		/// <summary>
		/// Gets or sets the round.
		/// </summary>
		public int Round
		{
			get { return fRound; }
			set { fRound = value; }
		}
		int fRound = 1;

		/// <summary>
		/// Gets the HTML string description of the entry.
		/// </summary>
		/// <param name="enc">The current encounter.</param>
		/// <param name="detailed">True if the description should include detailed creature names; false otherwise.</param>
		/// <returns>Returns the string description of the entry.</returns>
		public string Description(Encounter enc, bool detailed)
		{
			return "Round " + fRound;
		}

		/// <summary>
		/// Gets whether the entry should always be shown.
		/// </summary>
		public bool Important
		{
			get { return true; }
		}
	}

	/// <summary>
	/// Log entry for the start of a turn.
	/// </summary>
	[Serializable]
	public class StartTurnLogEntry : IEncounterLogEntry
	{
		/// <summary>
		/// Gets or sets the ID of the combatant.
		/// </summary>
		public Guid CombatantID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.Empty;

		/// <summary>
		/// Gets or sets the entry timestamp.
		/// </summary>
		public DateTime Timestamp
		{
			get { return fTimestamp; }
			set { fTimestamp = value; }
		}
		DateTime fTimestamp = DateTime.Now;

		/// <summary>
		/// Gets the HTML string description of the entry.
		/// </summary>
		/// <param name="enc">The current encounter.</param>
		/// <param name="detailed">True if the description should include detailed creature names; false otherwise.</param>
		/// <returns>Returns the string description of the entry.</returns>
		public string Description(Encounter enc, bool detailed)
		{
			return "Start turn: " + EncounterLog.GetName(fID, enc, detailed);
		}

		/// <summary>
		/// Gets whether the entry should always be shown.
		/// </summary>
		public bool Important
		{
			get { return true; }
		}
	}

	/// <summary>
	/// Log entry for damage taken / healed.
	/// </summary>
	[Serializable]
	public class DamageLogEntry : IEncounterLogEntry
	{
		/// <summary>
		/// Gets or sets the ID of the combatant.
		/// </summary>
		public Guid CombatantID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.Empty;

		/// <summary>
		/// Gets or sets the entry timestamp.
		/// </summary>
		public DateTime Timestamp
		{
			get { return fTimestamp; }
			set { fTimestamp = value; }
		}
		DateTime fTimestamp = DateTime.Now;

		/// <summary>
		/// Gets or sets the amount.
		/// </summary>
		public int Amount
		{
			get { return fAmount; }
			set { fAmount = value; }
		}
		int fAmount = 0;

		/// <summary>
		/// Gets or sets the damage type(s).
		/// </summary>
		public List<DamageType> Types
		{
			get { return fTypes; }
			set { fTypes = value; }
		}
		List<DamageType> fTypes = new List<DamageType>();

		/// <summary>
		/// Gets the HTML string description of the entry.
		/// </summary>
		/// <param name="enc">The current encounter.</param>
		/// <param name="detailed">True if the description should include detailed creature names; false otherwise.</param>
		/// <returns>Returns the string description of the entry.</returns>
		public string Description(Encounter enc, bool detailed)
		{
			string types = "";
			if (fTypes != null)
			{
				foreach (DamageType type in fTypes)
				{
					types += " ";
					types += type.ToString().ToLower();
				}
			}

			string verb = (fAmount >= 0) ? "takes" : "heals";
			return EncounterLog.GetName(fID, enc, detailed) + " " + verb + " " + Math.Abs(fAmount) + types + " damage";
		}

		/// <summary>
		/// Gets whether the entry should always be shown.
		/// </summary>
		public bool Important
		{
			get { return false; }
		}
	}

	/// <summary>
	/// Log entry for a change in active / bloodied / defeated state.
	/// </summary>
	[Serializable]
	public class StateLogEntry : IEncounterLogEntry
	{
		/// <summary>
		/// Gets or sets the ID of the combatant.
		/// </summary>
		public Guid CombatantID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.Empty;

		/// <summary>
		/// Gets or sets the entry timestamp.
		/// </summary>
		public DateTime Timestamp
		{
			get { return fTimestamp; }
			set { fTimestamp = value; }
		}
		DateTime fTimestamp = DateTime.Now;

		/// <summary>
		/// Gets or sets the new state.
		/// </summary>
		public CreatureState State
		{
			get { return fState; }
			set { fState = value; }
		}
		CreatureState fState = CreatureState.Active;

		/// <summary>
		/// Gets the HTML string description of the entry.
		/// </summary>
		/// <param name="enc">The current encounter.</param>
		/// <param name="detailed">True if the description should include detailed creature names; false otherwise.</param>
		/// <returns>Returns the string description of the entry.</returns>
		public string Description(Encounter enc, bool detailed)
		{
			string state = "not bloodied";
			if (fState != CreatureState.Active)
				state = fState.ToString().ToLower();

			return EncounterLog.GetName(fID, enc, detailed) + " is <B>" + state + "</B>";
		}

		/// <summary>
		/// Gets whether the entry should always be shown.
		/// </summary>
		public bool Important
		{
			get { return true; }
		}
	}

	/// <summary>
	/// Log entry for the addition or removal of an effect.
	/// </summary>
	[Serializable]
	public class EffectLogEntry : IEncounterLogEntry
	{
		/// <summary>
		/// Gets or sets the ID of the combatant.
		/// </summary>
		public Guid CombatantID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.Empty;

		/// <summary>
		/// Gets or sets the entry timestamp.
		/// </summary>
		public DateTime Timestamp
		{
			get { return fTimestamp; }
			set { fTimestamp = value; }
		}
		DateTime fTimestamp = DateTime.Now;

		/// <summary>
		/// Gets or sets the text of the effect.
		/// </summary>
		public string EffectText
		{
			get { return fEffectText; }
			set { fEffectText = value; }
		}
		string fEffectText = "";

		/// <summary>
		/// True if the effect has been added; false if the effect has been removed.
		/// </summary>
		public bool Added
		{
			get { return fAdded; }
			set { fAdded = value; }
		}
		bool fAdded = true;

		/// <summary>
		/// Gets the HTML string description of the entry.
		/// </summary>
		/// <param name="enc">The current encounter.</param>
		/// <param name="detailed">True if the description should include detailed creature names; false otherwise.</param>
		/// <returns>Returns the string description of the entry.</returns>
		public string Description(Encounter enc, bool detailed)
		{
			string name = EncounterLog.GetName(fID, enc, detailed);
			if (fAdded)
				return name + " gained " + fEffectText;
			else
				return name + " lost " + fEffectText;
		}

		/// <summary>
		/// Gets whether the entry should always be shown.
		/// </summary>
		public bool Important
		{
			get { return false; }
		}
	}

	/// <summary>
	/// Log entry for the usage of a power.
	/// </summary>
	[Serializable]
	public class PowerLogEntry : IEncounterLogEntry
	{
		/// <summary>
		/// Gets or sets the ID of the combatant.
		/// </summary>
		public Guid CombatantID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.Empty;

		/// <summary>
		/// Gets or sets the entry timestamp.
		/// </summary>
		public DateTime Timestamp
		{
			get { return fTimestamp; }
			set { fTimestamp = value; }
		}
		DateTime fTimestamp = DateTime.Now;

		/// <summary>
		/// Gets or sets the power name.
		/// </summary>
		public string PowerName
		{
			get { return fPowerName; }
			set { fPowerName = value; }
		}
		string fPowerName = "";

		/// <summary>
		/// True if the power has been used; false if the power has been recharged.
		/// </summary>
		public bool Added
		{
			get { return fAdded; }
			set { fAdded = value; }
		}
		bool fAdded = true;

		/// <summary>
		/// Gets the HTML string description of the entry.
		/// </summary>
		/// <param name="enc">The current encounter.</param>
		/// <param name="detailed">True if the description should include detailed creature names; false otherwise.</param>
		/// <returns>Returns the string description of the entry.</returns>
		public string Description(Encounter enc, bool detailed)
		{
			string name = EncounterLog.GetName(fID, enc, detailed);
			if (fAdded)
				return name + " used <B>" + fPowerName + "</B>";
			else
				return name + " recharged <B>" + fPowerName + "</B>";
		}

		/// <summary>
		/// Gets whether the entry should always be shown.
		/// </summary>
		public bool Important
		{
			get { return false; }
		}
	}

	/// <summary>
	/// Log entry for a skill usage.
	/// </summary>
	[Serializable]
	public class SkillLogEntry : IEncounterLogEntry
	{
		/// <summary>
		/// Gets or sets the ID of the combatant.
		/// </summary>
		public Guid CombatantID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.Empty;

		/// <summary>
		/// Gets or sets the entry timestamp.
		/// </summary>
		public DateTime Timestamp
		{
			get { return fTimestamp; }
			set { fTimestamp = value; }
		}
		DateTime fTimestamp = DateTime.Now;

		/// <summary>
		/// Gets or sets the skill name.
		/// </summary>
		public string SkillName
		{
			get { return fSkillName; }
			set { fSkillName = value; }
		}
		string fSkillName = "";

		/// <summary>
		/// Gets the HTML string description of the entry.
		/// </summary>
		/// <param name="enc">The current encounter.</param>
		/// <param name="detailed">True if the description should include detailed creature names; false otherwise.</param>
		/// <returns>Returns the string description of the entry.</returns>
		public string Description(Encounter enc, bool detailed)
		{
			string name = EncounterLog.GetName(fID, enc, detailed);
			return name + " used <B>" + fSkillName + "</B>";
		}

		/// <summary>
		/// Gets whether the entry should always be shown.
		/// </summary>
		public bool Important
		{
			get { return false; }
		}
	}

	/// <summary>
	/// Log entry for a skill in a skill challenge.
	/// </summary>
	[Serializable]
	public class SkillChallengeLogEntry : IEncounterLogEntry
	{
		/// <summary>
		/// Gets or sets the ID of the combatant.
		/// </summary>
		public Guid CombatantID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.Empty;

		/// <summary>
		/// Gets or sets the entry timestamp.
		/// </summary>
		public DateTime Timestamp
		{
			get { return fTimestamp; }
			set { fTimestamp = value; }
		}
		DateTime fTimestamp = DateTime.Now;

		/// <summary>
		/// True if the skill was a success; false if it was a failure.
		/// </summary>
		public bool Success
		{
			get { return fSuccess; }
			set { fSuccess = value; }
		}
		bool fSuccess = true;

		/// <summary>
		/// Gets the HTML string description of the entry.
		/// </summary>
		/// <param name="enc">The current encounter.</param>
		/// <param name="detailed">True if the description should include detailed creature names; false otherwise.</param>
		/// <returns>Returns the string description of the entry.</returns>
		public string Description(Encounter enc, bool detailed)
		{
			string name = EncounterLog.GetName(fID, enc, detailed);
			if (fSuccess)
				return name + " gained a success";
			else
				return name + " incurred a failure";
		}

		/// <summary>
		/// Gets whether the entry should always be shown.
		/// </summary>
		public bool Important
		{
			get { return false; }
		}
	}

	/// <summary>
	/// Log entry for a map movement.
	/// </summary>
	[Serializable]
	public class MoveLogEntry : IEncounterLogEntry
	{
		/// <summary>
		/// Gets or sets the ID of the combatant.
		/// </summary>
		public Guid CombatantID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.Empty;

		/// <summary>
		/// Gets or sets the entry timestamp.
		/// </summary>
		public DateTime Timestamp
		{
			get { return fTimestamp; }
			set { fTimestamp = value; }
		}
		DateTime fTimestamp = DateTime.Now;

		/// <summary>
		/// Gets or sets any additional details about the movement.
		/// </summary>
		public int Distance
		{
			get { return fDistance; }
			set { fDistance = value; }
		}
		int fDistance = 0;

		/// <summary>
		/// Gets or sets any additional details about the movement.
		/// </summary>
		public string Details
		{
			get { return fDetails; }
			set { fDetails = value; }
		}
		string fDetails = "";

		/// <summary>
		/// Gets the HTML string description of the entry.
		/// </summary>
		/// <param name="enc">The current encounter.</param>
		/// <param name="detailed">True if the description should include detailed creature names; false otherwise.</param>
		/// <returns>Returns the string description of the entry.</returns>
		public string Description(Encounter enc, bool detailed)
		{
			string name = EncounterLog.GetName(fID, enc, detailed);
			string str = name + " moves";
			if (fDistance > 0)
				str += " " + fDistance + " sq";
			if (fDetails != "")
				str += " " + fDetails.Trim();
			return str;
		}

		/// <summary>
		/// Gets whether the entry should always be shown.
		/// </summary>
		public bool Important
		{
			get { return false; }
		}
	}

	/// <summary>
	/// Log entry for pausing an encounter.
	/// </summary>
	[Serializable]
	public class PauseLogEntry : IEncounterLogEntry
	{
		/// <summary>
		/// Gets the ID of the combatant.
		/// </summary>
		public Guid CombatantID
		{
			get { return Guid.Empty; }
		}

		/// <summary>
		/// Gets or sets the entry timestamp.
		/// </summary>
		public DateTime Timestamp
		{
			get { return fTimestamp; }
			set { fTimestamp = value; }
		}
		DateTime fTimestamp = DateTime.Now;

		/// <summary>
		/// Gets the HTML string description of the entry.
		/// </summary>
		/// <param name="enc">The current encounter.</param>
		/// <param name="detailed">True if the description should include detailed creature names; false otherwise.</param>
		/// <returns>Returns the string description of the entry.</returns>
		public string Description(Encounter enc, bool detailed)
		{
			return "Paused (" + fTimestamp.ToShortTimeString() + " " + fTimestamp.ToShortDateString() + ")";
		}

		/// <summary>
		/// Gets whether the entry should always be shown.
		/// </summary>
		public bool Important
		{
			get { return false; }
		}
	}

	/// <summary>
	/// Log enry for resuming a paused encounter.
	/// </summary>
	[Serializable]
	public class ResumeLogEntry : IEncounterLogEntry
	{
		/// <summary>
		/// Gets the ID of the combatant.
		/// </summary>
		public Guid CombatantID
		{
			get { return Guid.Empty; }
		}

		/// <summary>
		/// Gets or sets the entry timestamp.
		/// </summary>
		public DateTime Timestamp
		{
			get { return fTimestamp; }
			set { fTimestamp = value; }
		}
		DateTime fTimestamp = DateTime.Now;

		/// <summary>
		/// Gets the HTML string description of the entry.
		/// </summary>
		/// <param name="enc">The current encounter.</param>
		/// <param name="detailed">True if the description should include detailed creature names; false otherwise.</param>
		/// <returns>Returns the string description of the entry.</returns>
		public string Description(Encounter enc, bool detailed)
		{
			return "Resumed (" + fTimestamp.ToShortTimeString() + " " + fTimestamp.ToShortDateString() + ")";
		}

		/// <summary>
		/// Gets whether the entry should always be shown.
		/// </summary>
		public bool Important
		{
			get { return false; }
		}
	}

	#endregion

	#region Encounter Report

	class EncounterReport
	{
		public List<RoundLog> Rounds
		{
			get { return fRounds; }
		}
		List<RoundLog> fRounds = new List<RoundLog>();

		public RoundLog GetRound(int round)
		{
			foreach (RoundLog rl in fRounds)
			{
				if (rl.Round == round)
					return rl;
			}

			return null;
		}

		List<TurnLog> get_turns(Guid id)
		{
			List<TurnLog> turns = new List<TurnLog>();

			foreach (RoundLog round in fRounds)
			{
				foreach (TurnLog turn in round.Turns)
				{
					if (turn.ID == id)
						turns.Add(turn);
				}
			}

			return turns;
		}

		public List<Guid> Combatants
		{
			get
			{
				List<Guid> ids = new List<Guid>();

				foreach (RoundLog round in fRounds)
				{
					foreach (TurnLog turn in round.Turns)
					{
						if (!ids.Contains(turn.ID))
							ids.Add(turn.ID);
					}
				}

				return ids;
			}
		}

		public List<Guid> MVPs(Encounter enc)
		{
			Dictionary<Guid, int> standings = new Dictionary<Guid, int>();

			// Qickest mean times
			ReportTable time_table = CreateTable(ReportType.Time, BreakdownType.Controller, enc);
			time_table.ReduceToPCs();
			add_table(time_table, standings);

			// Most damage to enemies
			ReportTable enemy_table = CreateTable(ReportType.DamageToEnemies, BreakdownType.Controller, enc);
			enemy_table.ReduceToPCs();
			add_table(enemy_table, standings);

			// Least damage to allies
			ReportTable ally_table = CreateTable(ReportType.DamageToAllies, BreakdownType.Controller, enc);
			ally_table.ReduceToPCs();
			add_table(ally_table, standings);

			List<Guid> leaders = new List<Guid>();
			int max = int.MinValue;

			foreach (Guid combatant in standings.Keys)
			{
				int total = standings[combatant];

				if (total > max)
				{
					max = total;
					leaders.Clear();
				}

				if (total == max)
				{
					leaders.Add(combatant);
				}
			}

			return leaders;
		}

		void add_table(ReportTable table, Dictionary<Guid, int> standings)
		{
			List<int> points = new List<int>() { 25, 18, 15, 12, 10, 8, 6, 4, 2, 1 };

			List<int> values = new List<int>();
			foreach (ReportRow row in table.Rows)
			{
				if (!values.Contains(row.Total))
					values.Add(row.Total);
			}

			Dictionary<Guid, int> allocations = new Dictionary<Guid, int>();

			foreach (int value in values)
			{
				int points_for_this_value = 0;
				if (allocations.Count < points.Count)
					points_for_this_value = points[allocations.Count];

				foreach (ReportRow row in table.Rows)
				{
					if (row.Total != value)
						continue;

					allocations[row.CombatantID] = points_for_this_value;
				}
			}

			foreach (Guid combatant in allocations.Keys)
			{
				if (!standings.ContainsKey(combatant))
					standings[combatant] = 0;

				standings[combatant] += allocations[combatant];
			}
		}

		#region Metrics

		public int Time(Guid id, int round)
		{
			TimeSpan ts = new TimeSpan();

			foreach (RoundLog rl in fRounds)
			{
				if ((rl.Round == round) || (round == 0))
				{
					foreach (TurnLog tl in rl.Turns)
					{
						if ((tl.ID == id) || (id == Guid.Empty))
							ts += tl.Time();
					}
				}
			}

			return (int)ts.TotalSeconds;
		}

		public int Damage(Guid id, int round, bool allies, Encounter enc)
		{
			int damage = 0;

			foreach (RoundLog rl in fRounds)
			{
				if ((rl.Round == round) || (round == 0))
				{
					foreach (TurnLog tl in rl.Turns)
					{
						if ((tl.ID == id) || (id == Guid.Empty))
						{
							List<Guid> allyIDs = get_allies(tl.ID, enc);

							List<Guid> ids = new List<Guid>();
							if (allies)
							{
								// Use the list of allies
								ids.AddRange(allyIDs);
							}
							else
							{
								// Reverse the list
								foreach (Guid i in Combatants)
								{
									if (!allyIDs.Contains(i))
										ids.Add(i);
								}
							}

							damage += tl.Damage(ids);
						}
					}
				}
			}

			return damage;
		}

		public int Movement(Guid id, int round)
		{
			int movement = 0;

			foreach (RoundLog rl in fRounds)
			{
				if ((rl.Round == round) || (round == 0))
				{
					foreach (TurnLog tl in rl.Turns)
					{
						if ((tl.ID == id) || (id == Guid.Empty))
							movement += tl.Movement();
					}
				}
			}

			return movement;
		}

		#endregion

		static List<Guid> get_allies(Guid id, Encounter enc)
		{
			List<Guid> allyIDs = new List<Guid>();

			if (Session.Project.FindHero(id) != null)
			{
				// All heroes
				foreach (Hero hero in Session.Project.Heroes)
					allyIDs.Add(hero.ID);

				// All allied creatures
				foreach (EncounterSlot slot in enc.Slots)
				{
					if (slot.Type != EncounterSlotType.Ally)
						continue;

					foreach (CombatData cd in slot.CombatData)
						allyIDs.Add(cd.ID);
				}
			}
			else
			{
				// Get faction
				CombatData cd = enc.FindCombatData(id);
				if (cd != null)
				{
					EncounterSlot slot = enc.FindSlot(cd);
					if (slot != null)
					{
						// All of same faction
						foreach (EncounterSlot s in enc.Slots)
						{
							if (s.Type != slot.Type)
								continue;

							foreach (CombatData c in s.CombatData)
								allyIDs.Add(c.ID);
						}

						// If ally, all heroes
						if (slot.Type == EncounterSlotType.Ally)
						{
							foreach (Hero hero in Session.Project.Heroes)
								allyIDs.Add(hero.ID);
						}
					}
				}
			}

			return allyIDs;
		}

		public ReportTable CreateTable(ReportType report_type, BreakdownType breakdown_type, Encounter enc)
		{
			ReportTable table = new ReportTable();
			table.ReportType = report_type;
			table.BreakdownType = breakdown_type;

			List<Pair<string, List<Guid>>> rowsets = new List<Pair<string, List<Guid>>>();
			switch (breakdown_type)
			{
				case BreakdownType.Individual:
					{
						// Add individually

						List<Guid> combatant_ids = Combatants;
						foreach (Guid id in combatant_ids)
						{
							List<Guid> list = new List<Guid>();
							list.Add(id);
							rowsets.Add(new Pair<string, List<Guid>>(enc.WhoIs(id), list));
						}
					}
					break;
				case BreakdownType.Controller:
					{
						// Add by controller (PCs, DM)

						List<Guid> dm_ids = new List<Guid>();

						List<Guid> combatant_ids = Combatants;
						foreach (Guid id in combatant_ids)
						{
							if (Session.Project.FindHero(id) != null)
							{
								List<Guid> list = new List<Guid>();
								list.Add(id);
								rowsets.Add(new Pair<string, List<Guid>>(enc.WhoIs(id), list));
							}
							else
							{
								dm_ids.Add(id);
							}
						}

						rowsets.Add(new Pair<string, List<Guid>>("DM", dm_ids));
					}
					break;
				case BreakdownType.Faction:
					{
						// Add by faction (PC, ally, neutral, enemy)

						List<Guid> pc_ids = new List<Guid>();
						List<Guid> ally_ids = new List<Guid>();
						List<Guid> neutral_ids = new List<Guid>();
						List<Guid> enemy_ids = new List<Guid>();

						List<Guid> combatant_ids = Combatants;
						foreach (Guid id in combatant_ids)
						{
							if (Session.Project.FindHero(id) != null)
							{
								pc_ids.Add(id);
							}
							else
							{
								CombatData cd = enc.FindCombatData(id);
								EncounterSlot slot = enc.FindSlot(cd);
								switch (slot.Type)
								{
									case EncounterSlotType.Ally:
										ally_ids.Add(id);
										break;
									case EncounterSlotType.Neutral:
										neutral_ids.Add(id);
										break;
									case EncounterSlotType.Opponent:
										enemy_ids.Add(id);
										break;
								}
							}
						}

						rowsets.Add(new Pair<string, List<Guid>>("PCs", pc_ids));
						rowsets.Add(new Pair<string, List<Guid>>("Allies", ally_ids));
						rowsets.Add(new Pair<string, List<Guid>>("Neutral", neutral_ids));
						rowsets.Add(new Pair<string, List<Guid>>("Enemies", enemy_ids));
					}
					break;
			}

			foreach (Pair<string, List<Guid>> rowset in rowsets)
			{
				if (rowset.Second.Count == 0)
					continue;

				ReportRow row = new ReportRow();
				row.Heading = rowset.First;

				if (rowset.Second.Count == 1)
					row.CombatantID = rowset.Second[0];

				for (int round = 1; round <= fRounds.Count; ++round)
				{
					switch (report_type)
					{
						case ReportType.Time:
							{
								int total = 0;
								foreach (Guid id in rowset.Second)
									total += Time(id, round);
								row.Values.Add(total);
							}
							break;
						case ReportType.DamageToEnemies:
							{
								int total = 0;
								foreach (Guid id in rowset.Second)
									total += Damage(id, round, false, enc);
								row.Values.Add(total);
							}
							break;
						case ReportType.DamageToAllies:
							{
								int total = 0;
								foreach (Guid id in rowset.Second)
									total += Damage(id, round, true, enc);
								row.Values.Add(total);
							}
							break;
						case ReportType.Movement:
							{
								int total = 0;
								foreach (Guid id in rowset.Second)
									total += Movement(id, round);
								row.Values.Add(total);
							}
							break;
					}
				}

				table.Rows.Add(row);
			}

			table.Rows.Sort();

			switch (table.ReportType)
			{
				case ReportType.Time:
				case ReportType.DamageToAllies:
					// For these reports, lower numbers are better
					table.Rows.Reverse();
					break;
			}

			return table;
		}
	}

	class RoundLog
	{
		public RoundLog(int round)
		{
			fRound = round;
		}

		public int Round
		{
			get { return fRound; }
		}
		int fRound = 0;

		public List<TurnLog> Turns
		{
			get { return fTurns; }
		}
		List<TurnLog> fTurns = new List<TurnLog>();

		public TurnLog GetTurn(Guid id)
		{
			foreach (TurnLog tl in fTurns)
			{
				if (tl.ID == id)
					return tl;
			}

			return null;
		}

		public int Count
		{
			get
			{
				int count = 0;
				foreach (TurnLog turn in fTurns)
					count += turn.Entries.Count;

				return count;
			}
		}
	}

	class TurnLog
	{
		public TurnLog(Guid id)
		{
			fID = id;
		}

		public Guid ID
		{
			get { return fID; }
		}
		Guid fID = Guid.Empty;

		public List<IEncounterLogEntry> Entries
		{
			get { return fEntries; }
		}
		List<IEncounterLogEntry> fEntries = new List<IEncounterLogEntry>();

		public DateTime Start = DateTime.MinValue;
		public DateTime End = DateTime.MinValue;

		public TimeSpan Time()
		{
			TimeSpan time = End - Start;

			if (time.Ticks < 0)
				return new TimeSpan(0);

			IEncounterLogEntry pause_start = null;
			foreach (IEncounterLogEntry entry in fEntries)
			{
				if (entry is PauseLogEntry)
				{
					pause_start = entry;
					continue;
				}

				if (entry is ResumeLogEntry)
				{
					if (pause_start != null)
					{
						TimeSpan pause = entry.Timestamp - pause_start.Timestamp;
						time -= pause;

						pause_start = null;
					}
				}
			}

			return time;
		}

		public int Damage(List<Guid> allyIDs)
		{
			int damage = 0;

			foreach (IEncounterLogEntry entry in fEntries)
			{
				DamageLogEntry dle = entry as DamageLogEntry;
				if (dle != null)
				{
					if (allyIDs.Contains(dle.CombatantID))
						damage += dle.Amount;
				}
			}

			return damage;
		}

		public int Movement()
		{
			int movement = 0;

			foreach (IEncounterLogEntry entry in fEntries)
			{
				MoveLogEntry mle = entry as MoveLogEntry;
				if (mle != null)
				{
					if (mle.Distance > 0)
						movement += mle.Distance;
				}
			}

			return movement;
		}
	}

	#endregion

	#region Report Table

	enum ReportType
	{
		Time,
		DamageToEnemies,
		DamageToAllies,
		Movement
	}

	enum BreakdownType
	{
		Individual,
		Controller,
		Faction
	}

	class ReportTable
	{
		public ReportType ReportType
		{
			get { return fReportType; }
			set { fReportType = value; }
		}
		ReportType fReportType = ReportType.Time;

		public BreakdownType BreakdownType
		{
			get { return fBreakdownType; }
			set { fBreakdownType = value; }
		}
		BreakdownType fBreakdownType = BreakdownType.Individual;

		public List<ReportRow> Rows
		{
			get { return fRows; }
		}
		List<ReportRow> fRows = new List<ReportRow>();

		public int Rounds
		{
			get
			{
				int max = 0;

				foreach (ReportRow row in fRows)
					max = Math.Max(max, row.Values.Count);

				return max;
			}
		}

		public int ColumnTotal(int column)
		{
			int total = 0;

			foreach (ReportRow row in fRows)
				total += row.Values[column];

			return total;
		}

		public int GrandTotal
		{
			get
			{
				int total = 0;

				foreach (ReportRow row in fRows)
					total += row.Total;

				return total;
			}
		}

		public void ReduceToPCs()
		{
			List<ReportRow> obsolete = new List<ReportRow>();
			foreach (ReportRow row in fRows)
			{
				Hero hero = Session.Project.FindHero(row.CombatantID);
				if (hero == null)
					obsolete.Add(row);
			}
			foreach (ReportRow row in obsolete)
				fRows.Remove(row);
		}
	}

	class ReportRow : IComparable<ReportRow>
	{
		public string Heading
		{
			get { return fHeading; }
			set { fHeading = value; }
		}
		string fHeading = "";

		public Guid CombatantID
		{
			get { return fCombatantID; }
			set { fCombatantID = value; }
		}
		Guid fCombatantID = Guid.Empty;

		public List<int> Values
		{
			get { return fValues; }
		}
		List<int> fValues = new List<int>();

		public int Total
		{
			get
			{
				int total = 0;

				foreach (int value in fValues)
					total += value;

				return total;
			}
		}

		public double Average
		{
			get { return (double)Total / fValues.Count; }
		}

		public int CompareTo(ReportRow rhs)
		{
			return Total.CompareTo(rhs.Total) * -1;
		}
	}

	#endregion
}
