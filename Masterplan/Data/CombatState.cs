using System;
using System.Collections.Generic;
using System.Drawing;

namespace Masterplan.Data
{
	/// <summary>
	/// Class holding information about an encounter in progress.
	/// </summary>
	[Serializable]
	public class CombatState
	{
		/// <summary>
		/// Gets or sets the time at which the combat was paused.
		/// </summary>
		public DateTime Timestamp
		{
			get { return fTimestamp; }
			set { fTimestamp = value; }
		}
		DateTime fTimestamp = DateTime.Now;

		/// <summary>
		/// Gets or sets the level of the party.
		/// </summary>
		public int PartyLevel
		{
			get { return fPartyLevel; }
			set { fPartyLevel = value; }
		}
		int fPartyLevel = Session.Project.Party.Level;

		/// <summary>
		/// Gets or sets the encounter data.
		/// </summary>
		public Encounter Encounter
		{
			get { return fEncounter; }
			set { fEncounter = value; }
		}
		Encounter fEncounter = null;

		/// <summary>
		/// Gets or sets the current round.
		/// </summary>
		public int CurrentRound
		{
			get { return fCurrentRound; }
			set { fCurrentRound = value; }
		}
		int fCurrentRound = 1;

		/// <summary>
		/// Gets or sets the combat data for heroes in the encounter.
		/// </summary>
		public Dictionary<Guid, CombatData> HeroData
		{
			get { return fHeroData; }
			set { fHeroData = value; }
		}
		Dictionary<Guid, CombatData> fHeroData = null;

		/// <summary>
		/// Gets or sets the combat data for traps in the encounter.
		/// </summary>
		public Dictionary<Guid, CombatData> TrapData
		{
			get { return fTrapData; }
			set { fTrapData = value; }
		}
		Dictionary<Guid, CombatData> fTrapData = null;

		/// <summary>
		/// Gets or sets the links between tokens.
		/// </summary>
		public List<TokenLink> TokenLinks
		{
			get { return fTokenLinks; }
			set { fTokenLinks = value; }
		}
		List<TokenLink> fTokenLinks = null;

		/// <summary>
		/// Gets or sets the XP gained from creatures which are no longer in the combat.
		/// </summary>
		public int RemovedCreatureXP
		{
			get { return fRemovedCreatureXP; }
			set { fRemovedCreatureXP = value; }
		}
		int fRemovedCreatureXP = 0;

		/// <summary>
		/// Gets or sets the ID of the current actor.
		/// </summary>
		public Guid CurrentActor
		{
			get { return fCurrentActor; }
			set { fCurrentActor = value; }
		}
		Guid fCurrentActor = Guid.Empty;

		/// <summary>
		/// Gets or sets the visible map area.
		/// </summary>
		public Rectangle Viewpoint
		{
			get { return fViewpoint; }
			set { fViewpoint = value; }
		}
		Rectangle fViewpoint = Rectangle.Empty;

		/// <summary>
		/// Gets or sets the map sketches.
		/// </summary>
		public List<MapSketch> Sketches
		{
			get { return fSketches; }
			set { fSketches = value; }
		}
		List<MapSketch> fSketches = new List<MapSketch>();

		/// <summary>
		/// Gets or sets the list of previously added effects.
		/// </summary>
		public List<OngoingCondition> QuickEffects
		{
			get { return fQuickEffects; }
			set { fQuickEffects = value; }
		}
		List<OngoingCondition> fQuickEffects = new List<OngoingCondition>();

		/// <summary>
		/// Gets or sets the endounter log
		/// </summary>
		public EncounterLog Log
		{
			get { return fLog; }
			set { fLog = value; }
		}
		EncounterLog fLog = new EncounterLog();

		/// <summary>
		/// Returns the timestamp.
		/// </summary>
		/// <returns>Returns the timestamp.</returns>
		public override string ToString()
		{
			return fTimestamp.ToShortDateString() + " " + Session.I18N.At + " " + fTimestamp.ToShortTimeString();
		}
	}
}
