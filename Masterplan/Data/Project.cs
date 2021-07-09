using System;
using System.Collections.Generic;

using Utils;

using Masterplan.Tools;

namespace Masterplan.Data
{
	/// <summary>
	/// Class representing a Masterplan project.
	/// </summary>
	[Serializable]
	public class Project
	{
		#region Properties

		/// <summary>
		/// Gets or sets the name of the project.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the name of the author of the project.
		/// </summary>
		public string Author
		{
			get { return fAuthor; }
			set { fAuthor = value; }
		}
		string fAuthor = "";

		/// <summary>
		/// Gets or sets the size and level of the party the project is designed for.
		/// </summary>
		public Party Party
		{
			get { return fParty; }
			set { fParty = value; }
		}
		Party fParty = new Party();

		/// <summary>
		/// Gets or sets the list of PCs.
		/// </summary>
		public List<Hero> Heroes
		{
			get { return fHeroes; }
			set { fHeroes = value; }
		}
		List<Hero> fHeroes = new List<Hero>();

		/// <summary>
		/// Gets or sets the list of PCs.
		/// </summary>
		public List<Hero> InactiveHeroes
		{
			get { return fInactiveHeroes; }
			set { fInactiveHeroes = value; }
		}
		List<Hero> fInactiveHeroes = new List<Hero>();

		/// <summary>
		/// Gets or sets the plot information.
		/// </summary>
		public Plot Plot
		{
			get { return fPlot; }
			set { fPlot = value; }
		}
		Plot fPlot = new Plot();

		/// <summary>
		/// Gets or sets the project encyclopedia.
		/// </summary>
		public Encyclopedia Encyclopedia
		{
			get { return fEncyclopedia; }
			set { fEncyclopedia = value; }
		}
		Encyclopedia fEncyclopedia = new Encyclopedia();

		/// <summary>
		/// Gets or sets the list of notes.
		/// </summary>
		public List<Note> Notes
		{
			get { return fNotes; }
			set { fNotes = value; }
		}
		List<Note> fNotes = new List<Note>();

		/// <summary>
		/// Gets or sets the list of tactical maps.
		/// </summary>
		public List<Map> Maps
		{
			get { return fMaps; }
			set { fMaps = value; }
		}
		List<Map> fMaps = new List<Map>();

		/// <summary>
		/// Gets or sets the list of tactical maps.
		/// </summary>
		public List<RegionalMap> RegionalMaps
		{
			get { return fRegionalMaps; }
			set { fRegionalMaps = value; }
		}
		List<RegionalMap> fRegionalMaps = new List<RegionalMap>();

		/// <summary>
		/// Gets or sets the list of encounter decks.
		/// </summary>
		public List<EncounterDeck> Decks
		{
			get { return fDecks; }
			set { fDecks = value; }
		}
		List<EncounterDeck> fDecks = new List<EncounterDeck>();

		/// <summary>
		/// Gets or sets the list of NPCs.
		/// </summary>
		public List<NPC> NPCs
		{
			get { return fNPCs; }
			set { fNPCs = value; }
		}
		List<NPC> fNPCs = new List<NPC>();

		/// <summary>
		/// Gets or sets the list of project-specific creatures.
		/// </summary>
		public List<CustomCreature> CustomCreatures
		{
			get { return fCustomCreatures; }
			set { fCustomCreatures = value; }
		}
		List<CustomCreature> fCustomCreatures = new List<CustomCreature>();

		/// <summary>
		/// Gets or sets the project calendars.
		/// </summary>
		public List<Calendar> Calendars
		{
			get { return fCalendars; }
			set { fCalendars = value; }
		}
		List<Calendar> fCalendars = new List<Calendar>();

		/// <summary>
		/// Gets or sets the project attachments.
		/// </summary>
		public List<Attachment> Attachments
		{
			get { return fAttachments; }
			set { fAttachments = value; }
		}
		List<Attachment> fAttachments = new List<Attachment>();

		/// <summary>
		/// Gets or sets the list of project background information items.
		/// </summary>
		public List<Background> Backgrounds
		{
			get { return fBackgrounds; }
			set { fBackgrounds = value; }
		}
		List<Background> fBackgrounds = new List<Background>();

		/// <summary>
		/// Gets or sets the list of unassigned treasure parcels.
		/// </summary>
		public List<Parcel> TreasureParcels
		{
			get { return fTreasureParcels; }
			set { fTreasureParcels = value; }
		}
		List<Parcel> fTreasureParcels = new List<Parcel>();

		/// <summary>
		/// Gets or sets the list of player options.
		/// </summary>
		public List<IPlayerOption> PlayerOptions
		{
			get { return fPlayerOptions; }
			set { fPlayerOptions = value; }
		}
		List<IPlayerOption> fPlayerOptions = new List<IPlayerOption>();

        /// <summary>
        /// Gets or sets the list of saved encounters.
        /// </summary>
        public List<CombatState> SavedCombats
        {
            get { return fSavedCombats; }
            set { fSavedCombats = value; }
        }
        List<CombatState> fSavedCombats = new List<CombatState>();

		/// <summary>
		/// Gets or sets add-in specific data.
		/// Data should be stored with add-in name as the key and custom data as the value.
		/// </summary>
		public Dictionary<string, string> AddInData
		{
			get { return fAddInData; }
			set { fAddInData = value; }
		}
		Dictionary<string, string> fAddInData = new Dictionary<string, string>();

		/// <summary>
		/// Gets or sets the campaign settings.
		/// </summary>
		public CampaignSettings CampaignSettings
		{
			get { return fCampaignSettings; }
			set { fCampaignSettings = value; }
		}
		CampaignSettings fCampaignSettings = new CampaignSettings();

		#endregion

		#region Password

		/// <summary>
		/// The project's password.
		/// </summary>
		public string Password
		{
			get { return fPassword; }
			set { fPassword = value; }
		}
		string fPassword = "";

		/// <summary>
		/// The project's password hint.
		/// </summary>
		public string PasswordHint
		{
			get { return fPasswordHint; }
			set { fPasswordHint = value; }
		}
		string fPasswordHint = "";

		#endregion

		#region Access methods

		/// <summary>
		/// Finds the tactical map with the specified ID.
		/// </summary>
		/// <param name="map_id">The ID to search for.</param>
		/// <returns>Returns the map if it exists; null otherwise.</returns>
		public Map FindTacticalMap(Guid map_id)
		{
			foreach (Map m in fMaps)
			{
				if (m.ID == map_id)
					return m;
			}

			return null;
		}

		/// <summary>
		/// Finds the regional map with the specified ID.
		/// </summary>
		/// <param name="map_id">The ID to search for.</param>
		/// <returns>Returns the map if it exists; null otherwise.</returns>
		public RegionalMap FindRegionalMap(Guid map_id)
		{
			foreach (RegionalMap m in fRegionalMaps)
			{
				if (m.ID == map_id)
					return m;
			}

			return null;
		}

		/// <summary>
		/// Finds the encounter deck with the specified ID.
		/// </summary>
		/// <param name="deck_id">The ID to search for.</param>
		/// <returns>Returns the deck if it exists; null otherwise.</returns>
		public EncounterDeck FindDeck(Guid deck_id)
		{
			foreach (EncounterDeck d in fDecks)
			{
				if (d.ID == deck_id)
					return d;
			}

			return null;
		}

		/// <summary>
		/// Finds the NPC with the specified ID.
		/// </summary>
		/// <param name="npc_id">The ID to search for.</param>
		/// <returns>Returns the NPC if it exists; null otherwise.</returns>
		public NPC FindNPC(Guid npc_id)
		{
			foreach (NPC npc in fNPCs)
			{
				if (npc.ID == npc_id)
					return npc;
			}

			return null;
		}

		/// <summary>
		/// Finds the custom creature with the specified ID.
		/// </summary>
		/// <param name="creature_id">The ID to search for.</param>
		/// <returns>Returns the creature if it exists; null otherwise.</returns>
		public CustomCreature FindCustomCreature(Guid creature_id)
		{
			foreach (CustomCreature cc in fCustomCreatures)
			{
				if (cc.ID == creature_id)
					return cc;
			}

			return null;
		}

		/// <summary>
		/// Finds the custom creature with the specified ID.
		/// </summary>
		/// <param name="creature_name">The ID to search for.</param>
		/// <returns>Returns the creature if it exists; null otherwise.</returns>
		public CustomCreature FindCustomCreature(string creature_name)
		{
			foreach (CustomCreature cc in fCustomCreatures)
			{
				if (cc.Name == creature_name)
					return cc;
			}

			return null;
		}

		/// <summary>
		/// Finds the calendar with the specified ID.
		/// </summary>
		/// <param name="calendar_id">The ID to search for.</param>
		/// <returns>Returns the calendar if it exists; null otherwise.</returns>
		public Calendar FindCalendar(Guid calendar_id)
		{
			foreach (Calendar c in fCalendars)
			{
				if (c.ID == calendar_id)
					return c;
			}

			return null;
		}

		/// <summary>
		/// Finds the note with the specified ID.
		/// </summary>
		/// <param name="note_id">The ID to search for.</param>
		/// <returns>Returns the note if it exists; null otherwise.</returns>
		public Note FindNote(Guid note_id)
		{
			foreach (Note n in fNotes)
			{
				if (n.ID == note_id)
					return n;
			}

			return null;
		}

		/// <summary>
		/// Finds the attachment with the specified name.
		/// </summary>
		/// <param name="name">The name to search for.</param>
		/// <returns>Returns the attachment if it exists; null otherwise.</returns>
		public Attachment FindAttachment(string name)
		{
			foreach (Attachment att in fAttachments)
			{
				if (att.Name == name)
					return att;
			}

			return null;
		}

		/// <summary>
		/// Finds the background with the specified title.
		/// </summary>
		/// <param name="title">The title to search for.</param>
		/// <returns>Returns the background if it exists; null otherwise.</returns>
		public Background FindBackground(string title)
		{
			foreach (Background bg in fBackgrounds)
			{
				if (bg.Title == title)
					return bg;
			}

			return null;
		}

		/// <summary>
		/// Finds the hero with the specified ID.
		/// </summary>
		/// <param name="hero_id">The ID to search for.</param>
		/// <returns>Returns the hero if it exists; null otherwise.</returns>
		public Hero FindHero(Guid hero_id)
		{
			foreach (Hero h in fHeroes)
			{
				if (h.ID == hero_id)
					return h;
			}

			foreach (Hero h in fInactiveHeroes)
			{
				if (h.ID == hero_id)
					return h;
			}

			return null;
		}

		/// <summary>
		/// Finds the hero with the specified name.
		/// </summary>
		/// <param name="hero_name">The name to search for.</param>
		/// <returns>Returns the hero if it exists; null otherwise.</returns>
		public Hero FindHero(string hero_name)
		{
			foreach (Hero h in fHeroes)
			{
				if (h.Name == hero_name)
					return h;
			}

			foreach (Hero h in fInactiveHeroes)
			{
				if (h.Name == hero_name)
					return h;
			}

			return null;
		}

		/// <summary>
		/// Finds the player option with the specified ID.
		/// </summary>
		/// <param name="option_id">The ID to search for.</param>
		/// <returns>Returns the player option if it exists; null otherwise.</returns>
		public IPlayerOption FindPlayerOption(Guid option_id)
		{
			foreach (IPlayerOption option in fPlayerOptions)
			{
				if (option.ID == option_id)
					return option;
			}

			return null;
		}

		#endregion

		#region Parent access

		/// <summary>
		/// Find the plot point which is the parent of the specified plot.
		/// </summary>
		/// <param name="p">The plot.</param>
		/// <returns>Returns the parent plot point, if it exists; null otherwise.</returns>
		public PlotPoint FindParent(Plot p)
		{
			List<PlotPoint> all_points = new List<PlotPoint>();
			get_all_points(Session.Project.Plot, all_points);

			foreach (PlotPoint pp in all_points)
			{
				if (pp.Subplot == p)
					return pp;
			}

			return null;
		}

		void get_all_points(Plot p, List<PlotPoint> points)
		{
			List<PlotPoint> children = (p != null) ? p.Points : Session.Project.Plot.Points;
			foreach (PlotPoint child in children)
			{
				points.Add(child);
				get_all_points(child.Subplot, points);
			}
		}

		/// <summary>
		/// Find the plot which is the parent of the specified plot point.
		/// </summary>
		/// <param name="pp">The plot point.</param>
		/// <returns>Returns the parent plot, if it exists; false otherwise.</returns>
		public Plot FindParent(PlotPoint pp)
		{
			List<Plot> all_plots = new List<Plot>();
			get_all_plots(Session.Project.Plot, all_plots);

			foreach (Plot p in all_plots)
			{
				foreach (PlotPoint point in p.Points)
				{
					if (point.ID == pp.ID)
						return p;
				}
			}

			return null;
		}

		void get_all_plots(Plot p, List<Plot> plots)
		{
			plots.Add(p);

			List<PlotPoint> children = (p != null) ? p.Points : Session.Project.Plot.Points;
			foreach (PlotPoint child in children)
			{
				get_all_plots(child.Subplot, plots);
			}
		}

		#endregion

		/// <summary>
		/// Gets a list containing all the plot points in the project.
		/// </summary>
		public List<PlotPoint> AllPlotPoints
		{
			get
			{
				List<PlotPoint> points = new List<PlotPoint>();

				//add_points(fPlot, points);
				foreach (PlotPoint pp in fPlot.Points)
					points.AddRange(pp.Subtree);

				return points;
			}
		}

		/// <summary>
		/// Gets a list containing all the treasure parcels in the project.
		/// </summary>
		public List<Parcel> AllTreasureParcels
		{
			get
			{
				List<Parcel> parcels = new List<Parcel>();

				parcels.AddRange(fTreasureParcels);

				List<PlotPoint> points = AllPlotPoints;
				foreach (PlotPoint point in points)
					parcels.AddRange(point.Parcels);

				return parcels;
			}
		}

		/// <summary>
		/// Updates the project to make sure it conforms to the current structure
		/// </summary>
		public void Update()
		{
			fLibrary.Update();

			if (fPassword == null)
				fPassword = "";

			if (fPasswordHint == null)
				fPasswordHint = "";

			if (fParty.XP == 0)
                fParty.XP = Experience.GetHeroXP(fParty.Level);

			if (fAuthor == null)
				fAuthor = "";

			if (fRegionalMaps == null)
				fRegionalMaps = new List<RegionalMap>();

			foreach (RegionalMap map in fRegionalMaps)
			{
				foreach (MapLocation loc in map.Locations)
				{
					if (loc.Category == null)
						loc.Category = "";
				}

				Program.SetResolution(map.Image);
			}

			foreach (Hero hero in fHeroes)
			{
				if (hero.Level == 0)
					hero.Level = fParty.Level;

				if (hero.Effects == null)
					hero.Effects = new List<OngoingCondition>();
				foreach (OngoingCondition oc in hero.Effects)
				{
					if (oc.Defences == null)
						oc.Defences = new List<DefenceType>();
					if (oc.DamageModifier == null)
						oc.DamageModifier = new DamageModifier();
					if (oc.Regeneration == null)
						oc.Regeneration = new Regeneration();
					if (oc.Aura == null)
						oc.Aura = new Aura();
				}

				if (hero.Tokens == null)
					hero.Tokens = new List<CustomToken>();
				foreach (CustomToken ct in hero.Tokens)
				{
					if ((ct.TerrainPower != null) && (ct.TerrainPower.ID == Guid.Empty))
						ct.ID = Guid.NewGuid();
				}

				if (hero.Portrait != null)
					Program.SetResolution(hero.Portrait);

				if (hero.CombatData == null)
					hero.CombatData = new CombatData();
			}

			if (fInactiveHeroes == null)
				fInactiveHeroes = new List<Hero>();

			foreach (Hero hero in fInactiveHeroes)
			{
				if (hero.Effects == null)
					hero.Effects = new List<OngoingCondition>();
				foreach (OngoingCondition oc in hero.Effects)
				{
					if (oc.Defences == null)
						oc.Defences = new List<DefenceType>();
					if (oc.DamageModifier == null)
						oc.DamageModifier = new DamageModifier();
					if (oc.Regeneration == null)
						oc.Regeneration = new Regeneration();
				}

				if (hero.Tokens == null)
					hero.Tokens = new List<CustomToken>();
				foreach (CustomToken ct in hero.Tokens)
				{
					if ((ct.TerrainPower != null) && (ct.TerrainPower.ID == Guid.Empty))
						ct.ID = Guid.NewGuid();
				}

				if (hero.Portrait != null)
					Program.SetResolution(hero.Portrait);

				if (hero.CombatData == null)
					hero.CombatData = new CombatData();
			}

			if (fNPCs == null)
				fNPCs = new List<NPC>();

			while (fNPCs.Contains(null))
				fNPCs.Remove(null);
			foreach (NPC npc in fNPCs)
			{
				if (npc == null)
					continue;

				if (npc.Auras == null)
					npc.Auras = new List<Aura>();

				foreach (Aura aura in npc.Auras)
				{
					if (aura.Keywords == null)
						aura.Keywords = "";
				}

				if (npc.CreaturePowers == null)
					npc.CreaturePowers = new List<CreaturePower>();

				CreatureHelper.UpdateRegen(npc);
				foreach (CreaturePower power in npc.CreaturePowers)
					CreatureHelper.UpdatePowerRange(npc, power);

				if (npc.Tactics == null)
					npc.Tactics = "";

				if (npc.Image != null)
					Program.SetResolution(npc.Image);
			}

			while (fCustomCreatures.Contains(null))
				fCustomCreatures.Remove(null);
			foreach (CustomCreature cc in fCustomCreatures)
			{
				if (cc == null)
					continue;

				if (cc.Auras == null)
					cc.Auras = new List<Aura>();

				foreach (Aura aura in cc.Auras)
				{
					if (aura.Keywords == null)
						aura.Keywords = "";
				}

				if (cc.CreaturePowers == null)
					cc.CreaturePowers = new List<CreaturePower>();

				if (cc.DamageModifiers == null)
					cc.DamageModifiers = new List<DamageModifier>();

				CreatureHelper.UpdateRegen(cc);
				foreach (CreaturePower power in cc.CreaturePowers)
					CreatureHelper.UpdatePowerRange(cc, power);

				if (cc.Tactics == null)
					cc.Tactics = "";

				if (cc.Image != null)
					Program.SetResolution(cc.Image);
			}

			if (fCalendars == null)
				fCalendars = new List<Calendar>();

			if (fEncyclopedia == null)
				fEncyclopedia = new Encyclopedia();

			while (fEncyclopedia.Entries.Contains(null))
				fEncyclopedia.Entries.Remove(null);
			foreach (EncyclopediaEntry entry in fEncyclopedia.Entries)
			{
				if (entry.Category == null)
					entry.Category = "";

				if (entry.DMInfo == null)
					entry.DMInfo = "";

				if (entry.Images == null)
					entry.Images = new List<EncyclopediaImage>();

				foreach (EncyclopediaImage img in entry.Images)
					Program.SetResolution(img.Image);
			}

			if (fEncyclopedia.Groups == null)
				fEncyclopedia.Groups = new List<EncyclopediaGroup>();

			if (fNotes == null)
				fNotes = new List<Note>();

			foreach (Note n in fNotes)
			{
				if (n.Category == null)
					n.Category = "";
			}

			if (fAttachments == null)
				fAttachments = new List<Attachment>();

			if (fBackgrounds == null)
			{
				fBackgrounds = new List<Background>();
				SetStandardBackgroundItems();
			}

			if (fTreasureParcels == null)
				fTreasureParcels = new List<Parcel>();

			if (fPlayerOptions == null)
				fPlayerOptions = new List<IPlayerOption>();

			if (fSavedCombats == null)
				fSavedCombats = new List<CombatState>();
			foreach (CombatState cs in fSavedCombats)
			{
				if (cs.Encounter.Waves == null)
					cs.Encounter.Waves = new List<EncounterWave>();

				if (cs.Sketches == null)
					cs.Sketches = new List<MapSketch>();

				if (cs.Log == null)
					cs.Log = new EncounterLog();

				foreach (OngoingCondition oc in cs.QuickEffects)
				{
					if (oc.Defences == null)
						oc.Defences = new List<DefenceType>();
					if (oc.DamageModifier == null)
						oc.DamageModifier = new DamageModifier();
					if (oc.Regeneration == null)
						oc.Regeneration = new Regeneration();
					if (oc.Aura == null)
						oc.Aura = new Aura();
				}
			}

            if (fAddInData == null)
                fAddInData = new Dictionary<string, string>();

			if (fCampaignSettings == null)
				fCampaignSettings = new CampaignSettings();

			if (fCampaignSettings.XP == 0)
				fCampaignSettings.XP = 1;

			update_plot(fPlot);
		}

		void update_plot(Plot p)
		{
			foreach (PlotPoint pp in p.Points)
			{
				if (pp.ReadAloud == null)
					pp.ReadAloud = "";

                if (pp.Parcels == null)
                    pp.Parcels = new List<Parcel>();

                if (pp.EncyclopediaEntryIDs == null)
                    pp.EncyclopediaEntryIDs = new List<Guid>();

				if (pp.Element is Encounter)
				{
					Encounter enc = pp.Element as Encounter;

					if (enc.Traps == null)
						enc.Traps = new List<Trap>();

					foreach (Trap t in enc.Traps)
					{
						if (t.Description == null)
							t.Description = "";

						if (t.Attacks == null)
							t.Attacks = new List<TrapAttack>();
						if (t.Attack != null)
						{
							t.Attacks.Add(t.Attack);
							t.Initiative = t.Attack.HasInitiative ? t.Attack.Initiative : int.MinValue;
							t.Trigger = t.Attack.Trigger;
							t.Attack = null;
						}
						foreach (TrapAttack ta in t.Attacks)
						{
							if (ta.ID == Guid.Empty)
								ta.ID = Guid.NewGuid();

							if (ta.Name == null)
								ta.Name = "Attack";

							if (ta.Keywords == null)
								ta.Keywords = "";

							if (ta.Notes == null)
								ta.Notes = "";
						}

						if (t.Trigger == null)
							t.Trigger = "";

						foreach (TrapSkillData tsd in t.Skills)
						{
							if (tsd.ID == Guid.Empty)
								tsd.ID = Guid.NewGuid();
						}
					}

					if (enc.SkillChallenges == null)
						enc.SkillChallenges = new List<SkillChallenge>();

					foreach (SkillChallenge sc in enc.SkillChallenges)
					{
						if (sc.Notes == null)
							sc.Notes = "";

						foreach (SkillChallengeData scd in sc.Skills)
						{
							if (scd.Results == null)
								scd.Results = new SkillChallengeResult();
						}
					}

					if (enc.CustomTokens == null)
						enc.CustomTokens = new List<CustomToken>();
					foreach (CustomToken ct in enc.CustomTokens)
					{
						if ((ct.TerrainPower != null) && (ct.TerrainPower.ID == Guid.Empty))
							ct.TerrainPower.ID = Guid.NewGuid();
					}

                    if (enc.Notes == null)
                    {
                        enc.Notes = new List<EncounterNote>();
                        enc.SetStandardEncounterNotes();
                    }

					if (enc.Waves == null)
						enc.Waves = new List<EncounterWave>();

					foreach (EncounterSlot slot in enc.AllSlots)
					{
						slot.SetDefaultDisplayNames();

						foreach (CombatData data in slot.CombatData)
						{
							data.Initiative = int.MinValue;

							if (data.ID == Guid.Empty)
								data.ID = Guid.NewGuid();

							if (data.UsedPowers == null)
								data.UsedPowers = new List<Guid>();
						}
					}
				}

				if (pp.Element is SkillChallenge)
				{
					SkillChallenge sc = pp.Element as SkillChallenge;

					if (sc.ID == Guid.Empty)
						sc.ID = Guid.NewGuid();

					if (sc.Name == null)
						sc.Name = "Skill Challenge";

					if (sc.Level <= 0)
						sc.Level = fParty.Level;

					if (sc.Notes == null)
						sc.Notes = "";

					foreach (SkillChallengeData scd in sc.Skills)
					{
						if (scd.Difficulty == Difficulty.Random)
							scd.Difficulty = Difficulty.Moderate;

						if (scd.Results == null)
							scd.Results = new SkillChallengeResult();
					}
				}

				if (pp.Element is TrapElement)
				{
					TrapElement te = pp.Element as TrapElement;

					if (te.Trap.Description == null)
						te.Trap.Description = "";

					if (te.Trap.Attacks == null)
						te.Trap.Attacks = new List<TrapAttack>();
					if (te.Trap.Attack != null)
					{
						te.Trap.Attacks.Add(te.Trap.Attack);
						te.Trap.Initiative = te.Trap.Attack.HasInitiative ? te.Trap.Attack.Initiative : int.MinValue;
						te.Trap.Trigger = te.Trap.Attack.Trigger;
						te.Trap.Attack = null;
					}
					foreach (TrapAttack ta in te.Trap.Attacks)
					{
						if (ta.ID == Guid.Empty)
							ta.ID = Guid.NewGuid();

						if (ta.Name == null)
							ta.Name = "Attack";

						if (ta.Keywords == null)
							ta.Keywords = "";

						if (ta.Notes == null)
							ta.Notes = "";
					}

					if (te.Trap.Trigger == null)
						te.Trap.Trigger = "";

					foreach (TrapSkillData tsd in te.Trap.Skills)
					{
						if (tsd.ID == Guid.Empty)
							tsd.ID = Guid.NewGuid();
					}
				}

				if (pp.Element is Quest)
				{
					Quest q = pp.Element as Quest;
					if (q.Type == QuestType.Minor)
					{
						if (q.XP == 0)
						{
							Pair<int, int> range = Experience.GetMinorQuestXP(q.Level);
							q.XP = range.First;
						}
					}
				}

				update_plot(pp.Subplot);
			}
		}

		/// <summary>
		/// Imports data from another project into this one.
		/// </summary>
		/// <param name="p">The other project.</param>
		public void Import(Project p)
		{
			p.Update();

			// Plots
			PlotPoint pp = new PlotPoint(p.Name);
			pp.Subplot = p.Plot;
			fPlot.Points.Add(pp);

			// Encyclopedia
			fEncyclopedia.Import(p.Encyclopedia);

			// Notes
			fNotes.AddRange(p.Notes);

			// Maps
			fMaps.AddRange(p.Maps);
			fRegionalMaps.AddRange(p.RegionalMaps);

			// Decks
			fDecks.AddRange(p.Decks);

			// NPCs
			fNPCs.AddRange(p.NPCs);

			// Custom creatures
			fCustomCreatures.AddRange(p.CustomCreatures);

			// Calendars
			fCalendars.AddRange(p.Calendars);

			// Attachments
			fAttachments.AddRange(p.Attachments);

			// Player options
			fPlayerOptions.AddRange(p.PlayerOptions);

			// Backgrounds
			foreach (Background bg in p.Backgrounds)
			{
				if (bg.Details == "")
					continue;

				Background source = FindBackground(bg.Title);
				if (source == null)
				{
					fBackgrounds.AddRange(p.Backgrounds);
				}
				else
				{
					if (source.Details != "")
						source.Details += Environment.NewLine;

					source.Details += bg.Details;
				}
			}

			// Update the internal library
			PopulateProjectLibrary();
			fLibrary.Import(p.Library);
			SimplifyProjectLibrary();
		}

		#region Internal library

		/// <summary>
		/// Gets or sets the internal library.
		/// </summary>
		public Library Library
		{
			get { return fLibrary; }
			set { fLibrary = value; }
		}
		Library fLibrary = new Library();

		/// <summary>
		/// Removes any data from the project's internal library that exists in the external libraries.
		/// </summary>
		public void SimplifyProjectLibrary()
		{
			// Update creatures
			List<Creature> obs_creatures = new List<Creature>();
			foreach (Creature c in fLibrary.Creatures)
			{
				if (c == null)
					continue;

				ICreature from_lib = Session.FindCreature(c.ID, SearchType.External);

				if ((from_lib != null) && (from_lib is Creature))
					obs_creatures.Add(from_lib as Creature);
			}
			foreach (Creature c in obs_creatures)
				fLibrary.Creatures.Remove(c);

			// Update templates
			List<CreatureTemplate> obs_templates = new List<CreatureTemplate>();
			foreach (CreatureTemplate ct in fLibrary.Templates)
			{
				if (ct == null)
					continue;

				CreatureTemplate from_lib = Session.FindTemplate(ct.ID, SearchType.External);

				if (from_lib != null)
					obs_templates.Add(ct);
			}
			foreach (CreatureTemplate ct in obs_templates)
				fLibrary.Templates.Remove(ct);

            // Update themes
            List<MonsterTheme> obs_themes = new List<MonsterTheme>();
            foreach (MonsterTheme mt in fLibrary.Themes)
            {
                if (mt == null)
                    continue;

                MonsterTheme from_lib = Session.FindTheme(mt.ID, SearchType.External);

                if (from_lib != null)
                    obs_themes.Add(mt);
            }
            foreach (MonsterTheme mt in obs_themes)
                fLibrary.Themes.Remove(mt);

			// Update traps
			List<Trap> obs_traps = new List<Trap>();
			foreach (Trap t in fLibrary.Traps)
			{
				if (t == null)
					continue;

				Trap from_lib = Session.FindTrap(t.ID, SearchType.External);

				if (from_lib != null)
					obs_traps.Add(t);
			}
			foreach (Trap t in obs_traps)
				fLibrary.Traps.Remove(t);

			// Update skill challenges
			List<SkillChallenge> obs_challenges = new List<SkillChallenge>();
			foreach (SkillChallenge sc in fLibrary.SkillChallenges)
			{
				if (sc == null)
					continue;

				SkillChallenge from_lib = Session.FindSkillChallenge(sc.ID, SearchType.External);

				if (from_lib != null)
					obs_challenges.Add(sc);
			}
			foreach (SkillChallenge sc in obs_challenges)
				fLibrary.SkillChallenges.Remove(sc);

			// Update magic items
			List<MagicItem> obs_items = new List<MagicItem>();
			foreach (MagicItem item in fLibrary.MagicItems)
			{
				if (item == null)
					continue;

				MagicItem from_lib = Session.FindMagicItem(item.ID, SearchType.External);

				if (from_lib != null)
					obs_items.Add(item);
			}
			foreach (MagicItem item in obs_items)
				fLibrary.MagicItems.Remove(item);

			// Update tiles
			List<Tile> obs_tiles = new List<Tile>();
			foreach (Tile t in fLibrary.Tiles)
			{
				if (t == null)
					continue;

				Tile from_lib = Session.FindTile(t.ID, SearchType.External);

				if (from_lib != null)
					obs_tiles.Add(t);
			}
			foreach (Tile t in obs_tiles)
				fLibrary.Tiles.Remove(t);
		}

		/// <summary>
		/// Populates the project's internal library with all the data required for the project.
		/// </summary>
		public void PopulateProjectLibrary()
		{
			// Build lists of data in the project
			List<Guid> creature_ids = new List<Guid>();
			List<Guid> template_ids = new List<Guid>();
            List<Guid> theme_ids = new List<Guid>();
			List<Guid> trap_ids = new List<Guid>();
			List<Guid> challenge_ids = new List<Guid>();
			List<Guid> magic_item_ids = new List<Guid>();

			foreach (PlotPoint pp in fPlot.Points)
				add_data(pp, creature_ids, template_ids, theme_ids, trap_ids, challenge_ids, magic_item_ids);

			foreach (EncounterDeck deck in fDecks)
				add_data(deck, creature_ids, template_ids, theme_ids);

			foreach (NPC npc in fNPCs)
				add_data(npc, template_ids);

			populate_creatures(creature_ids);
			populate_templates(template_ids);
            populate_themes(theme_ids);
			populate_traps(trap_ids);
			populate_challenges(challenge_ids);
			populate_magic_items(magic_item_ids);
			populate_tiles();
		}

        void add_data(PlotPoint pp, List<Guid> creature_ids, List<Guid> template_ids, List<Guid> theme_ids, List<Guid> trap_ids, List<Guid> challenge_ids, List<Guid> magic_item_ids)
		{
			// Add creatures and templates
			if (pp.Element is Encounter)
			{
				Encounter enc = pp.Element as Encounter;

                foreach (EncounterSlot slot in enc.Slots)
                    add_data(slot.Card, creature_ids, template_ids, theme_ids);

				foreach (Trap t in enc.Traps)
				{
					if (!trap_ids.Contains(t.ID))
						trap_ids.Add(t.ID);
				}

				foreach (SkillChallenge sc in enc.SkillChallenges)
				{
					if (!challenge_ids.Contains(sc.ID))
						challenge_ids.Add(sc.ID);
				}
			}

			if (pp.Element is SkillChallenge)
			{
				SkillChallenge sc = pp.Element as SkillChallenge;
				if (!challenge_ids.Contains(sc.ID))
					challenge_ids.Add(sc.ID);
			}

			if (pp.Element is Trap)
			{
				Trap trap = pp.Element as Trap;
				if (!trap_ids.Contains(trap.ID))
					trap_ids.Add(trap.ID);
			}

			foreach (Parcel p in pp.Parcels)
			{
				if (p.MagicItemID != Guid.Empty)
				{
					if (!magic_item_ids.Contains(p.MagicItemID))
						magic_item_ids.Add(p.MagicItemID);
				}
			}

			// Recurse through children
			foreach (PlotPoint child in pp.Subplot.Points)
				add_data(child, creature_ids, template_ids, theme_ids, trap_ids, challenge_ids, magic_item_ids);
		}

		void add_data(EncounterDeck deck, List<Guid> creature_ids, List<Guid> template_ids, List<Guid> theme_ids)
		{
			foreach (EncounterCard card in deck.Cards)
				add_data(card, creature_ids, template_ids, theme_ids);
		}

        void add_data(EncounterCard card, List<Guid> creature_ids, List<Guid> template_ids, List<Guid> theme_ids)
		{
			if (!creature_ids.Contains(card.CreatureID))
				creature_ids.Add(card.CreatureID);

			foreach (Guid template_id in card.TemplateIDs)
			{
				if (!template_ids.Contains(template_id))
					template_ids.Add(template_id);
			}

            if (card.ThemeID != Guid.Empty)
            {
                if (!theme_ids.Contains(card.ThemeID))
                    theme_ids.Add(card.ThemeID);
            }
		}

		void add_data(NPC npc, List<Guid> template_ids)
		{
			if (!template_ids.Contains(npc.TemplateID))
				template_ids.Add(npc.TemplateID);
		}

		void populate_creatures(List<Guid> creature_ids)
		{
			// Remove creatures in the library that aren't in any encounter
			List<Creature> obsolete = new List<Creature>();
			foreach (Creature t in fLibrary.Creatures)
			{
				if ((t == null) || (!creature_ids.Contains(t.ID)))
					obsolete.Add(t);
			}
			foreach (Creature t in obsolete)
			{
				fLibrary.Creatures.Remove(t);
			}

			// Add creatures that aren't there
			foreach (Guid creature_id in creature_ids)
			{
				if (fLibrary.FindCreature(creature_id) == null)
				{
					ICreature t = Session.FindCreature(creature_id, SearchType.Global);
					if (t != null)
						fLibrary.Creatures.Add(t as Creature);
				}
			}
		}

		void populate_templates(List<Guid> template_ids)
		{
			// Remove templates in the library that aren't in any encounter
			List<CreatureTemplate> obsolete = new List<CreatureTemplate>();
			foreach (CreatureTemplate ct in fLibrary.Templates)
			{
				if ((ct == null) || (!template_ids.Contains(ct.ID)))
					obsolete.Add(ct);
			}
			foreach (CreatureTemplate t in obsolete)
			{
				fLibrary.Templates.Remove(t);
			}

			// Add templates that aren't there
			foreach (Guid template_id in template_ids)
			{
				if (fLibrary.FindTemplate(template_id) == null)
				{
					CreatureTemplate ct = Session.FindTemplate(template_id, SearchType.Global);
					if (ct != null)
						fLibrary.Templates.Add(ct);
				}
			}
		}

        void populate_themes(List<Guid> theme_ids)
        {
            // Remove themes in the library that aren't in any encounter
            List<MonsterTheme> obsolete = new List<MonsterTheme>();
            foreach (MonsterTheme t in fLibrary.Themes)
            {
                if ((t == null) || (!theme_ids.Contains(t.ID)))
                    obsolete.Add(t);
            }
            foreach (MonsterTheme mt in obsolete)
            {
                fLibrary.Themes.Remove(mt);
            }

            // Add templates that aren't there
            foreach (Guid theme_id in theme_ids)
            {
				if (fLibrary.FindTheme(theme_id) == null)
                {
					MonsterTheme mt = Session.FindTheme(theme_id, SearchType.Global);
                    if (mt != null)
                        fLibrary.Themes.Add(mt);
                }
            }
        }

		void populate_traps(List<Guid> trap_ids)
		{
			// Remove traps in the library that aren't used in the project
			List<Trap> obsolete = new List<Trap>();
			foreach (Trap t in fLibrary.Traps)
			{
				if ((t == null) || (!trap_ids.Contains(t.ID)))
					obsolete.Add(t);
			}
			foreach (Trap t in obsolete)
			{
				fLibrary.Traps.Remove(t);
			}

			// Add traps that aren't there
			foreach (Guid trap_id in trap_ids)
			{
				if (fLibrary.FindTrap(trap_id) == null)
				{
					Trap t = Session.FindTrap(trap_id, SearchType.Global);
					if (t != null)
						fLibrary.Traps.Add(t);
				}
			}
		}

		void populate_challenges(List<Guid> challenge_ids)
		{
			// Remove skill challenges in the library that aren't used in the project
			List<SkillChallenge> obsolete = new List<SkillChallenge>();
			foreach (SkillChallenge sc in fLibrary.SkillChallenges)
			{
				if ((sc == null) || (!challenge_ids.Contains(sc.ID)))
					obsolete.Add(sc);
			}
			foreach (SkillChallenge t in obsolete)
			{
				fLibrary.SkillChallenges.Remove(t);
			}

			// Add skill challenges that aren't there
			foreach (Guid challenge_id in challenge_ids)
			{
				if (fLibrary.FindSkillChallenge(challenge_id) == null)
				{
					SkillChallenge sc = Session.FindSkillChallenge(challenge_id, SearchType.Global);
					if (sc != null)
						fLibrary.SkillChallenges.Add(sc);
				}
			}
		}

		void populate_magic_items(List<Guid> magic_item_ids)
		{
			// Remove magic items in the library that aren't used in the project
			List<MagicItem> obsolete = new List<MagicItem>();
			foreach (MagicItem item in fLibrary.MagicItems)
			{
				if ((item == null) || (!magic_item_ids.Contains(item.ID)))
					obsolete.Add(item);
			}
			foreach (MagicItem item in obsolete)
			{
				fLibrary.MagicItems.Remove(item);
			}

			// Add skill challenges that aren't there
			foreach (Guid item_id in magic_item_ids)
			{
				if (fLibrary.FindMagicItem(item_id) == null)
				{
					MagicItem item = Session.FindMagicItem(item_id, SearchType.Global);
					if (item != null)
						fLibrary.MagicItems.Add(item);
				}
			}
		}

		void populate_tiles()
		{
			// Build tile list
			List<Guid> tile_ids = new List<Guid>();
			foreach (Map m in fMaps)
			{
				foreach (TileData td in m.Tiles)
				{
					if (!tile_ids.Contains(td.TileID))
						tile_ids.Add(td.TileID);
				}
			}

			// Remove tilesets in the library that aren't in any encounter
			List<Tile> obsolete = new List<Tile>();
			foreach (Tile t in fLibrary.Tiles)
			{
				if ((t == null) || (!tile_ids.Contains(t.ID)))
					obsolete.Add(t);
			}
			foreach (Tile t in obsolete)
			{
				fLibrary.Tiles.Remove(t);
			}

			// Add tiles that aren't there
			foreach (Guid tile_id in tile_ids)
			{
				if (Session.FindTile(tile_id, SearchType.Project) == null)
				{
					Tile t = Session.FindTile(tile_id, SearchType.External);
					if (t != null)
						fLibrary.Tiles.Add(t);
				}
			}
		}

		#endregion

        /// <summary>
        /// Adds blank standard background items to the project.
        /// </summary>
        public void SetStandardBackgroundItems()
        {
            fBackgrounds.Add(new Background("Introduction"));
            fBackgrounds.Add(new Background("Adventure Synopsis"));
            fBackgrounds.Add(new Background("Adventure Background"));
            fBackgrounds.Add(new Background("DM Information"));
            fBackgrounds.Add(new Background("Player Introduction"));
            fBackgrounds.Add(new Background("Character Hooks"));
			fBackgrounds.Add(new Background("Treasure Preparation"));
			fBackgrounds.Add(new Background("Continuing the Story"));
		}
    }
}
