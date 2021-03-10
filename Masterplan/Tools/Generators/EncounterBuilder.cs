using System;
using System.Collections.Generic;

using Utils;

using Masterplan.Data;

namespace Masterplan.Tools.Generators
{
	class EncounterBuilder
	{
		const int TRIES = 100;

		public static bool Build(AutoBuildData data, Encounter enc, bool include_individual)
		{
			int min_level = Math.Max(data.Level - 4, 1);
			int max_level = data.Level + 5;
			build_creature_list(min_level, max_level, data.Categories, data.Keywords, true);

			if (fCreatures.Count == 0)
				return false;

			build_template_list(data.Type, data.Difficulty, data.Level, include_individual);
			if (fTemplateGroups.Count == 0)
				return false;

			build_trap_list(data.Level);
			build_challenge_list(data.Level);

			int attempts = 0;
			while (attempts < TRIES)
			{
				attempts += 1;

				// Pick a template
				int group_index = Session.Random.Next() % fTemplateGroups.Count;
				EncounterTemplateGroup group = fTemplateGroups[group_index];
				int template_index = Session.Random.Next() % group.Templates.Count;
				EncounterTemplate template = group.Templates[template_index];

				bool ok = true;
				List<EncounterSlot> slots = new List<EncounterSlot>();
				foreach (EncounterTemplateSlot template_slot in template.Slots)
				{
					// Attempt to populate the slot
					List<EncounterCard> candidates = new List<EncounterCard>();
					foreach (EncounterCard card in fCreatures)
					{
						if (template_slot.Match(card, data.Level))
							candidates.Add(card);
					}

					if (candidates.Count == 0)
					{
						ok = false;
						break;
					}

					// Choose a candidate
					int creature_index = Session.Random.Next() % candidates.Count;
					EncounterCard candidate = candidates[creature_index];

					// Build the slot
					EncounterSlot slot = new EncounterSlot();
					slot.Card = candidate;
					for (int n = 0; n != template_slot.Count; ++n)
					{
						CombatData ccd = new CombatData();
						slot.CombatData.Add(ccd);
					}

					slots.Add(slot);
				}

				if (ok)
				{
					enc.Slots = slots;
					enc.Traps.Clear();
					enc.SkillChallenges.Clear();

					// Random modification
					switch (Session.Random.Next(12))
					{
						case 4:
						case 5:
							{
								// Replace a creature with a trap / hazard
								if (add_trap(enc))
									remove_creature(enc);
							}
							break;
						case 6:
							{
								// Replace a creature with a skill challenge
								if (add_challenge(enc))
									remove_creature(enc);
							}
							break;
						case 7:
							{
								// Replace a creature with a lurker
								if (add_lurker(enc))
									remove_creature(enc);
							}
							break;
						case 8:
						case 9:
							{
								// Add a trap / hazard
								add_trap(enc);
								Difficulty diff = enc.GetDifficulty(data.Level, data.Size);
								if ((diff == Difficulty.Hard) || (diff == Difficulty.Extreme))
									remove_creature(enc);
							}
							break;
						case 10:
							{
								// Add a skill challenge
								Difficulty diff = enc.GetDifficulty(data.Level, data.Size);
								if ((diff == Difficulty.Hard) || (diff == Difficulty.Extreme))
									remove_creature(enc);
								add_challenge(enc);
							}
							break;
						case 11:
							{
								// Add a lurker
								add_lurker(enc);
								Difficulty diff = enc.GetDifficulty(data.Level, data.Size);
								if ((diff == Difficulty.Hard) || (diff == Difficulty.Extreme))
									remove_creature(enc);
							}
							break;
					}

					while ((enc.GetDifficulty(data.Level, data.Size) == Difficulty.Extreme) && (enc.Count > 1))
						remove_creature(enc);

					foreach (EncounterSlot slot in enc.Slots)
						slot.SetDefaultDisplayNames();

					return true;
				}
			}

			// We were unable to build the encounter
			return false;
		}

		static void remove_creature(Encounter enc)
		{
			if (enc.Count == 0)
				return;

			int index = Session.Random.Next() % enc.Slots.Count;
			EncounterSlot slot = enc.Slots[index];

			if (slot.CombatData.Count == 1)
			{
				enc.Slots.Remove(slot);
			}
			else
			{
				slot.CombatData.RemoveAt(slot.CombatData.Count - 1);
			}
		}

		static bool add_trap(Encounter enc)
		{
			if (fTraps.Count != 0)
			{
				int index = Session.Random.Next() % fTraps.Count;
				Trap trap = fTraps[index];
				enc.Traps.Add(trap.Copy());

				return true;
			}

			return false;
		}

		static bool add_challenge(Encounter enc)
		{
			if (fChallenges.Count != 0)
			{
				int index = Session.Random.Next() % fChallenges.Count;
				SkillChallenge sc = fChallenges[index];
				enc.SkillChallenges.Add(sc.Copy() as SkillChallenge);

				return true;
			}

			return false;
		}

		static bool add_lurker(Encounter enc)
		{
			List<EncounterCard> lurkers = new List<EncounterCard>();
			foreach (EncounterCard card in fCreatures)
			{
				if (card.Flag != RoleFlag.Standard)
					continue;

				if (card.Roles.Contains(RoleType.Lurker))
					lurkers.Add(card);
			}

			if (lurkers.Count != 0)
			{
				int index = Session.Random.Next() % lurkers.Count;

				EncounterSlot slot = new EncounterSlot();
				slot.Card = lurkers[index];
				slot.CombatData.Add(new CombatData());

				enc.Slots.Add(slot);

				return true;
			}

			return false;
		}

		public static EncounterDeck BuildDeck(int level, List<string> categories, List<string> keywords)
		{
			build_creature_list(level - 2, level + 5, categories, keywords, false);
			if (fCreatures.Count == 0)
				return null;

			Dictionary<CardCategory, Pair<int, int>> role_breakdown = new Dictionary<CardCategory, Pair<int, int>>();
			role_breakdown[CardCategory.SoldierBrute] = new Pair<int, int>(0, 18);
			role_breakdown[CardCategory.Skirmisher] = new Pair<int, int>(0, 14);
			role_breakdown[CardCategory.Minion] = new Pair<int, int>(0, 5);
			role_breakdown[CardCategory.Artillery] = new Pair<int, int>(0, 5);
			role_breakdown[CardCategory.Controller] = new Pair<int, int>(0, 5);
			role_breakdown[CardCategory.Lurker] = new Pair<int, int>(0, 2);
			role_breakdown[CardCategory.Solo] = new Pair<int, int>(0, 1);

			Dictionary<Difficulty, Pair<int, int>> diff_breakdown = new Dictionary<Difficulty, Pair<int, int>>();
			if (level >= 3)
			{
				diff_breakdown[Difficulty.Trivial] = new Pair<int, int>(0, 7);
				diff_breakdown[Difficulty.Easy] = new Pair<int, int>(0, 30);
			}
			else
			{
				diff_breakdown[Difficulty.Easy] = new Pair<int, int>(0, 37);
			}
			diff_breakdown[Difficulty.Moderate] = new Pair<int, int>(0, 8);
			diff_breakdown[Difficulty.Hard] = new Pair<int, int>(0, 5);
			diff_breakdown[Difficulty.Extreme] = new Pair<int, int>(0, 0);

			EncounterDeck deck = new EncounterDeck();
			deck.Level = level;

			int attempts = 0;
			while (attempts < TRIES)
			{
				attempts += 1;

				// Pick a card
				int card_index = Session.Random.Next() % fCreatures.Count;
				EncounterCard card = fCreatures[card_index];

				// Do we need a card of this type?
				CardCategory cat = card.Category;
				Pair<int, int> role_counts = role_breakdown[cat];
				bool role_ok = (role_counts.First < role_counts.Second);
				if (!role_ok)
					continue;

				// Do we need a card of this level?
				Difficulty diff = card.GetDifficulty(level);
				Pair<int, int> diff_counts = diff_breakdown[diff];
				bool level_ok = (diff_counts.First < diff_counts.Second);
				if (!level_ok)
					continue;

				// Add this card to the deck
				deck.Cards.Add(card);
				role_breakdown[cat].First += 1;
				diff_breakdown[diff].First += 1;

				if (deck.Cards.Count == 50)
					break;
			}

			FillDeck(deck);

			return deck;
		}

		public static void FillDeck(EncounterDeck deck)
		{
			build_creature_list(deck.Level - 2, deck.Level + 5, null, null, false);
			if (fCreatures.Count == 0)
				return;

			while (deck.Cards.Count < 50)
			{
				// Pick a card
				int card_index = Session.Random.Next() % fCreatures.Count;
				EncounterCard card = fCreatures[card_index];

				// Add this card to the deck
				deck.Cards.Add(card);
			}
		}

        public static List<Pair<EncounterTemplateGroup, EncounterTemplate>> FindTemplates(Encounter enc, int level, bool include_individual)
		{
			build_template_list("", Difficulty.Random, level, include_individual);

            List<Pair<EncounterTemplateGroup, EncounterTemplate>> templates = new List<Pair<EncounterTemplateGroup, EncounterTemplate>>();
			foreach (EncounterTemplateGroup group in fTemplateGroups)
			{
				foreach (EncounterTemplate template in group.Templates)
				{
					EncounterTemplate tmpl = template.Copy();

					// Does this template fit what we've already got?
					bool match = true;
					foreach (EncounterSlot enc_slot in enc.Slots)
					{
						EncounterTemplateSlot template_slot = tmpl.FindSlot(enc_slot, level);

						if (template_slot != null)
						{
							template_slot.Count -= enc_slot.CombatData.Count;
							if (template_slot.Count <= 0)
								tmpl.Slots.Remove(template_slot);
						}
						else
						{
							match = false;
							break;
						}
					}
					if (!match)
						continue;

					// Make sure there's at least one possible creature for each remaining slot
					bool has_creatures = true;
					foreach (EncounterTemplateSlot ets in tmpl.Slots)
					{
						bool found_creature = false;

						int creature_level = level + ets.LevelAdjustment;
						build_creature_list(creature_level, creature_level, null, null, true);
						foreach (EncounterCard card in fCreatures)
						{
							if (ets.Match(card, level))
							{
								found_creature = true;
								break;
							}
						}

						if (!found_creature)
						{
							has_creatures = false;
							break;
						}
					}
					if (!has_creatures)
						continue;

                    templates.Add(new Pair<EncounterTemplateGroup, EncounterTemplate>(group, tmpl));
				}
			}

			return templates;
		}

		public static List<string> FindTemplateNames()
		{
			build_template_list("", Difficulty.Random, -1, true);

			List<string> names = new List<string>();

			foreach (EncounterTemplateGroup group in fTemplateGroups)
				names.Add(group.Name);

			names.Sort();

			return names;
		}

		public static List<EncounterCard> FindCreatures(EncounterTemplateSlot slot, int party_level, string query)
		{
			int creature_level = party_level + slot.LevelAdjustment;
			build_creature_list(creature_level, creature_level, null, null, true);

			List<EncounterCard> cards = new List<EncounterCard>();
			foreach (EncounterCard card in fCreatures)
			{
				if (slot.Match(card, party_level) && match(card, query))
					cards.Add(card);
			}

			return cards;
		}

		static bool match(EncounterCard card, string query)
		{
			string[] tokens = query.ToLower().Split();

			foreach (string token in tokens)
			{
				if (!match_token(card, token))
					return false;
			}

			return true;
		}

		static bool match_token(EncounterCard card, string token)
		{
			if (card.Title.ToLower().Contains(token) || card.Category.ToString().ToLower().Contains(token))
				return true;

			return false;
		}

		#region Template list

		static void build_template_list(string group_name, Difficulty diff, int level, bool include_individual)
		{
			fTemplateGroups.Clear();

			build_template_battlefield_control();
			build_template_commander_and_troops();
			build_template_double_line();
			build_template_dragons_den();
            build_template_grand_melee();
			build_template_wolf_pack();

            if (include_individual)
                build_template_duel();

			// Filter by name
			if (group_name != "")
			{
				List<EncounterTemplateGroup> obsolete = new List<EncounterTemplateGroup>();
				foreach (EncounterTemplateGroup group in fTemplateGroups)
				{
					if (group.Name != group_name)
						obsolete.Add(group);
				}
				foreach (EncounterTemplateGroup group in obsolete)
					fTemplateGroups.Remove(group);
			}

			// Filter by difficulty
			if (diff != Difficulty.Random)
			{
				List<EncounterTemplateGroup> obsolete_groups = new List<EncounterTemplateGroup>();
				foreach (EncounterTemplateGroup group in fTemplateGroups)
				{
					List<EncounterTemplate> obsolete = new List<EncounterTemplate>();
					foreach (EncounterTemplate template in group.Templates)
					{
						if (template.Difficulty != diff)
							obsolete.Add(template);
					}
					foreach (EncounterTemplate template in obsolete)
						group.Templates.Remove(template);

					if (group.Templates.Count == 0)
						obsolete_groups.Add(group);
				}
				foreach (EncounterTemplateGroup group in obsolete_groups)
					fTemplateGroups.Remove(group);
			}

			// Filter by level (removes those we don't have creatures to fill)
			if (level != -1)
			{
				List<EncounterTemplateGroup> obsolete_groups = new List<EncounterTemplateGroup>();
				foreach (EncounterTemplateGroup group in fTemplateGroups)
				{
					List<EncounterTemplate> obsolete = new List<EncounterTemplate>();
					foreach (EncounterTemplate template in group.Templates)
					{
						bool ok = true;
						foreach (EncounterTemplateSlot ets in template.Slots)
						{
							if (level + ets.LevelAdjustment < 1)
							{
								ok = false;
								break;
							}
						}

						if (!ok)
							obsolete.Add(template);
					}
					foreach (EncounterTemplate template in obsolete)
						group.Templates.Remove(template);

					if (group.Templates.Count == 0)
						obsolete_groups.Add(group);
				}
				foreach (EncounterTemplateGroup group in obsolete_groups)
					fTemplateGroups.Remove(group);
			}
		}

		static void build_template_battlefield_control()
		{
			EncounterTemplateGroup group = new EncounterTemplateGroup("Battlefield Control", "Entire Party");

			EncounterTemplate bc1 = new EncounterTemplate(Difficulty.Easy);
			bc1.Slots.Add(new EncounterTemplateSlot(1, -2, RoleType.Controller));
			bc1.Slots.Add(new EncounterTemplateSlot(6, -4, RoleType.Skirmisher));
			group.Templates.Add(bc1);

			EncounterTemplate bc2 = new EncounterTemplate(Difficulty.Moderate);
			bc2.Slots.Add(new EncounterTemplateSlot(1, 1, RoleType.Controller));
			bc2.Slots.Add(new EncounterTemplateSlot(6, -2, RoleType.Skirmisher));
			group.Templates.Add(bc2);

			EncounterTemplate bc3 = new EncounterTemplate(Difficulty.Hard);
			bc3.Slots.Add(new EncounterTemplateSlot(1, 5, RoleType.Controller));
			bc3.Slots.Add(new EncounterTemplateSlot(5, 1, RoleType.Skirmisher));
			group.Templates.Add(bc3);

			fTemplateGroups.Add(group);
		}

		static void build_template_commander_and_troops()
		{
            EncounterTemplateGroup group = new EncounterTemplateGroup("Commander and Troops", "Entire Party");

			EncounterTemplate ct1 = new EncounterTemplate(Difficulty.Easy);
			ct1.Slots.Add(new EncounterTemplateSlot(1, 0, new RoleType[] { RoleType.Controller, RoleType.Soldier, RoleType.Lurker, RoleType.Skirmisher }));
			ct1.Slots.Add(new EncounterTemplateSlot(4, -3, new RoleType[] { RoleType.Brute, RoleType.Soldier }));
			group.Templates.Add(ct1);

			EncounterTemplate ct2 = new EncounterTemplate(Difficulty.Moderate);
			ct2.Slots.Add(new EncounterTemplateSlot(1, 3, new RoleType[] { RoleType.Controller, RoleType.Soldier, RoleType.Lurker, RoleType.Skirmisher }));
			ct2.Slots.Add(new EncounterTemplateSlot(5, -2, new RoleType[] { RoleType.Brute, RoleType.Soldier }));
			group.Templates.Add(ct2);

			EncounterTemplate ct3 = new EncounterTemplate(Difficulty.Hard);
			ct3.Slots.Add(new EncounterTemplateSlot(1, 5, new RoleType[] { RoleType.Controller, RoleType.Soldier, RoleType.Lurker, RoleType.Skirmisher }));
			ct3.Slots.Add(new EncounterTemplateSlot(3, 1, new RoleType[] { RoleType.Brute, RoleType.Soldier }));
			ct3.Slots.Add(new EncounterTemplateSlot(2, 1, new RoleType[] { RoleType.Artillery }));
			group.Templates.Add(ct3);

			fTemplateGroups.Add(group);
		}

		static void build_template_dragons_den()
		{
            EncounterTemplateGroup group = new EncounterTemplateGroup("Dragon's Den", "Entire Party");

			EncounterTemplate dd1 = new EncounterTemplate(Difficulty.Easy);
			dd1.Slots.Add(new EncounterTemplateSlot(1, -2, RoleFlag.Solo));
			group.Templates.Add(dd1);

			EncounterTemplate dd2 = new EncounterTemplate(Difficulty.Moderate);
			dd2.Slots.Add(new EncounterTemplateSlot(1, 0, RoleFlag.Solo));
			group.Templates.Add(dd2);

			EncounterTemplate dd3 = new EncounterTemplate(Difficulty.Moderate);
			dd3.Slots.Add(new EncounterTemplateSlot(1, 1, RoleFlag.Solo));
			group.Templates.Add(dd3);

			EncounterTemplate dd4 = new EncounterTemplate(Difficulty.Hard);
			dd4.Slots.Add(new EncounterTemplateSlot(1, 3, RoleFlag.Solo));
			group.Templates.Add(dd4);

			EncounterTemplate dd5 = new EncounterTemplate(Difficulty.Hard);
			dd5.Slots.Add(new EncounterTemplateSlot(1, 1, RoleFlag.Solo));
			dd5.Slots.Add(new EncounterTemplateSlot(1, 0, RoleFlag.Elite));
			group.Templates.Add(dd5);

			fTemplateGroups.Add(group);
		}

		static void build_template_double_line()
		{
            EncounterTemplateGroup group = new EncounterTemplateGroup("Double Line", "Entire Party");

			EncounterTemplate dl1 = new EncounterTemplate(Difficulty.Easy);
			dl1.Slots.Add(new EncounterTemplateSlot(3, -4, new RoleType[] { RoleType.Brute, RoleType.Soldier }));
			dl1.Slots.Add(new EncounterTemplateSlot(2, -2, new RoleType[] { RoleType.Artillery, RoleType.Controller }));
			group.Templates.Add(dl1);

			EncounterTemplate dl2 = new EncounterTemplate(Difficulty.Moderate);
			dl2.Slots.Add(new EncounterTemplateSlot(3, 0, new RoleType[] { RoleType.Brute, RoleType.Soldier }));
			dl2.Slots.Add(new EncounterTemplateSlot(2, 0, new RoleType[] { RoleType.Artillery, RoleType.Controller }));
			group.Templates.Add(dl2);

			EncounterTemplate dl3 = new EncounterTemplate(Difficulty.Moderate);
			dl3.Slots.Add(new EncounterTemplateSlot(3, -2, new RoleType[] { RoleType.Brute, RoleType.Soldier }));
			dl3.Slots.Add(new EncounterTemplateSlot(2, 3, new RoleType[] { RoleType.Artillery, RoleType.Controller }));
			group.Templates.Add(dl3);

			EncounterTemplate dl4 = new EncounterTemplate(Difficulty.Hard);
			dl4.Slots.Add(new EncounterTemplateSlot(3, 2, new RoleType[] { RoleType.Brute, RoleType.Soldier }));
			dl4.Slots.Add(new EncounterTemplateSlot(1, 4, RoleType.Controller));
			dl4.Slots.Add(new EncounterTemplateSlot(1, 4, new RoleType[] { RoleType.Artillery, RoleType.Lurker }));
			group.Templates.Add(dl4);

			EncounterTemplate dl5 = new EncounterTemplate(Difficulty.Hard);
			dl5.Slots.Add(new EncounterTemplateSlot(3, 0, new RoleType[] { RoleType.Brute, RoleType.Soldier }));
			dl5.Slots.Add(new EncounterTemplateSlot(2, 1, RoleType.Artillery));
			dl5.Slots.Add(new EncounterTemplateSlot(1, 2, RoleType.Controller));
			dl5.Slots.Add(new EncounterTemplateSlot(1, 2, RoleType.Lurker));
			group.Templates.Add(dl5);

			fTemplateGroups.Add(group);
		}

		static void build_template_wolf_pack()
		{
            EncounterTemplateGroup group = new EncounterTemplateGroup("Wolf Pack", "Entire Party");

			EncounterTemplate wp1 = new EncounterTemplate(Difficulty.Easy);
			wp1.Slots.Add(new EncounterTemplateSlot(7, -4, RoleType.Skirmisher));
			group.Templates.Add(wp1);

			EncounterTemplate wp2 = new EncounterTemplate(Difficulty.Moderate);
			wp2.Slots.Add(new EncounterTemplateSlot(7, -2, RoleType.Skirmisher));
			group.Templates.Add(wp2);

			EncounterTemplate wp3 = new EncounterTemplate(Difficulty.Moderate);
			wp3.Slots.Add(new EncounterTemplateSlot(5, 0, RoleType.Skirmisher));
			group.Templates.Add(wp3);

			EncounterTemplate wp4 = new EncounterTemplate(Difficulty.Hard);
			wp4.Slots.Add(new EncounterTemplateSlot(3, 5, RoleType.Skirmisher));
			group.Templates.Add(wp4);

			EncounterTemplate wp5 = new EncounterTemplate(Difficulty.Hard);
			wp5.Slots.Add(new EncounterTemplateSlot(4, 5, RoleType.Skirmisher));
			group.Templates.Add(wp5);

			EncounterTemplate wp6 = new EncounterTemplate(Difficulty.Hard);
			wp6.Slots.Add(new EncounterTemplateSlot(6, 2, RoleType.Skirmisher));
			group.Templates.Add(wp6);

			fTemplateGroups.Add(group);
		}

        static void build_template_duel()
        {
            #region Controller

            EncounterTemplateGroup group_controller = new EncounterTemplateGroup("Duel vs Controller", "Individual PC");

            EncounterTemplate c1 = new EncounterTemplate(Difficulty.Easy);
            c1.Slots.Add(new EncounterTemplateSlot(1, 0, RoleType.Artillery));
            group_controller.Templates.Add(c1);

            EncounterTemplate c2 = new EncounterTemplate(Difficulty.Easy);
            c2.Slots.Add(new EncounterTemplateSlot(1, -1, new RoleType[] { RoleType.Controller, RoleType.Skirmisher }));
            group_controller.Templates.Add(c2);

            EncounterTemplate c3 = new EncounterTemplate(Difficulty.Moderate);
            c3.Slots.Add(new EncounterTemplateSlot(1, 2, RoleType.Artillery));
            group_controller.Templates.Add(c3);

            EncounterTemplate c4 = new EncounterTemplate(Difficulty.Moderate);
            c4.Slots.Add(new EncounterTemplateSlot(1, 1, new RoleType[] { RoleType.Controller, RoleType.Skirmisher }));
            group_controller.Templates.Add(c4);

            EncounterTemplate c5 = new EncounterTemplate(Difficulty.Hard);
            c5.Slots.Add(new EncounterTemplateSlot(1, 4, RoleType.Artillery));
            group_controller.Templates.Add(c5);

            EncounterTemplate c6 = new EncounterTemplate(Difficulty.Hard);
            c6.Slots.Add(new EncounterTemplateSlot(1, 3, new RoleType[] { RoleType.Controller, RoleType.Skirmisher }));
            group_controller.Templates.Add(c6);

            fTemplateGroups.Add(group_controller);

            #endregion

            #region Defender

            EncounterTemplateGroup group_defender = new EncounterTemplateGroup("Duel vs Defender", "Individual PC");

            EncounterTemplate d1 = new EncounterTemplate(Difficulty.Easy);
            d1.Slots.Add(new EncounterTemplateSlot(1, 0, RoleType.Skirmisher));
            group_defender.Templates.Add(d1);

            EncounterTemplate d2 = new EncounterTemplate(Difficulty.Easy);
            d2.Slots.Add(new EncounterTemplateSlot(1, -1, new RoleType[] { RoleType.Brute, RoleType.Soldier }));
            group_defender.Templates.Add(d2);

            EncounterTemplate d3 = new EncounterTemplate(Difficulty.Moderate);
            d3.Slots.Add(new EncounterTemplateSlot(1, 2, RoleType.Skirmisher));
            group_defender.Templates.Add(d3);

            EncounterTemplate d4 = new EncounterTemplate(Difficulty.Moderate);
            d4.Slots.Add(new EncounterTemplateSlot(1, 1, new RoleType[] { RoleType.Brute, RoleType.Soldier }));
            group_defender.Templates.Add(d4);

            EncounterTemplate d5 = new EncounterTemplate(Difficulty.Hard);
            d5.Slots.Add(new EncounterTemplateSlot(1, 4, RoleType.Skirmisher));
            group_defender.Templates.Add(d5);

            EncounterTemplate d6 = new EncounterTemplate(Difficulty.Hard);
            d6.Slots.Add(new EncounterTemplateSlot(1, 3, new RoleType[] { RoleType.Controller, RoleType.Skirmisher }));
            group_defender.Templates.Add(d6);

            fTemplateGroups.Add(group_defender);

            #endregion

            #region Leader

            EncounterTemplateGroup group_leader = new EncounterTemplateGroup("Duel vs Leader", "Individual PC");

            EncounterTemplate l1 = new EncounterTemplate(Difficulty.Easy);
            l1.Slots.Add(new EncounterTemplateSlot(1, 0, RoleType.Skirmisher));
            group_leader.Templates.Add(l1);

            EncounterTemplate l2 = new EncounterTemplate(Difficulty.Easy);
            l2.Slots.Add(new EncounterTemplateSlot(1, -1, new RoleType[] { RoleType.Controller, RoleType.Soldier }));
            group_leader.Templates.Add(l2);

            EncounterTemplate l3 = new EncounterTemplate(Difficulty.Moderate);
            l3.Slots.Add(new EncounterTemplateSlot(1, 2, RoleType.Skirmisher));
            group_leader.Templates.Add(l3);

            EncounterTemplate l4 = new EncounterTemplate(Difficulty.Moderate);
            l4.Slots.Add(new EncounterTemplateSlot(1, 1, new RoleType[] { RoleType.Controller, RoleType.Soldier }));
            group_leader.Templates.Add(l4);

            EncounterTemplate l5 = new EncounterTemplate(Difficulty.Hard);
            l5.Slots.Add(new EncounterTemplateSlot(1, 4, RoleType.Skirmisher));
            group_leader.Templates.Add(l5);

            EncounterTemplate l6 = new EncounterTemplate(Difficulty.Hard);
            l6.Slots.Add(new EncounterTemplateSlot(1, 3, new RoleType[] { RoleType.Controller, RoleType.Soldier }));
            group_leader.Templates.Add(l6);

            fTemplateGroups.Add(group_leader);

            #endregion

            #region Striker

            EncounterTemplateGroup group_striker = new EncounterTemplateGroup("Duel vs Striker", "Individual PC");

            EncounterTemplate s1 = new EncounterTemplate(Difficulty.Easy);
            s1.Slots.Add(new EncounterTemplateSlot(1, 0, RoleType.Skirmisher));
            group_striker.Templates.Add(s1);

            EncounterTemplate s2 = new EncounterTemplate(Difficulty.Easy);
            s2.Slots.Add(new EncounterTemplateSlot(1, -1, new RoleType[] { RoleType.Brute, RoleType.Soldier }));
            group_striker.Templates.Add(s2);

            EncounterTemplate s3 = new EncounterTemplate(Difficulty.Moderate);
            s3.Slots.Add(new EncounterTemplateSlot(1, 2, RoleType.Skirmisher));
            group_striker.Templates.Add(s3);

            EncounterTemplate s4 = new EncounterTemplate(Difficulty.Moderate);
            s4.Slots.Add(new EncounterTemplateSlot(1, 1, new RoleType[] { RoleType.Brute, RoleType.Soldier }));
            group_striker.Templates.Add(s4);

            EncounterTemplate s5 = new EncounterTemplate(Difficulty.Hard);
            s5.Slots.Add(new EncounterTemplateSlot(1, 4, RoleType.Skirmisher));
            group_striker.Templates.Add(s5);

            EncounterTemplate s6 = new EncounterTemplate(Difficulty.Hard);
            s6.Slots.Add(new EncounterTemplateSlot(1, 3, new RoleType[] { RoleType.Brute, RoleType.Soldier }));
            group_striker.Templates.Add(s6);

            fTemplateGroups.Add(group_striker);

            #endregion
        }

        static void build_template_grand_melee()
        {
            EncounterTemplateGroup group = new EncounterTemplateGroup("Grand Melee", "Entire Party");

            EncounterTemplate gm1 = new EncounterTemplate(Difficulty.Easy);
            gm1.Slots.Add(new EncounterTemplateSlot(4, -2, RoleType.Brute));
            gm1.Slots.Add(new EncounterTemplateSlot(11, -4, true));
            group.Templates.Add(gm1);

            EncounterTemplate gm2 = new EncounterTemplate(Difficulty.Moderate);
            gm2.Slots.Add(new EncounterTemplateSlot(2, -1, RoleType.Soldier));
            gm2.Slots.Add(new EncounterTemplateSlot(4, -2, RoleType.Brute));
            gm2.Slots.Add(new EncounterTemplateSlot(12, -4, true));
            group.Templates.Add(gm2);

            EncounterTemplate gm3 = new EncounterTemplate(Difficulty.Hard);
            gm3.Slots.Add(new EncounterTemplateSlot(2, 0, RoleType.Soldier));
            gm3.Slots.Add(new EncounterTemplateSlot(4, -1, RoleType.Brute));
            gm3.Slots.Add(new EncounterTemplateSlot(17, -2, true));
            group.Templates.Add(gm3);

            fTemplateGroups.Add(group);
        }

		#endregion

		#region Creature list

		static void build_creature_list(int min_level, int max_level, List<string> categories, List<string> keywords, bool include_templates)
		{
			fCreatures.Clear();

			List<Creature> creatures = Session.Creatures;
			foreach (Creature creature in creatures)
			{
				if (creature == null)
					continue;

				if (min_level != -1)
				{
					if (creature.Level < min_level)
						continue;
				}

				if (max_level != -1)
				{
					if (creature.Level > max_level)
						continue;
				}

				if ((categories != null) && (categories.Count != 0) && (!categories.Contains(creature.Category)))
					continue;

				if ((keywords != null) && (keywords.Count != 0))
				{
					bool matched = false;
					foreach (string keyword in keywords)
					{
						if (creature.Phenotype.ToLower().Contains(keyword.ToLower()))
						{
							matched = true;
							break;
						}
					}

					if (!matched)
						continue;
				}

				EncounterCard card = new EncounterCard();
				card.CreatureID = creature.ID;

				fCreatures.Add(card);

				if (include_templates)
					add_templates(creature);
			}

			foreach (CustomCreature cc in Session.Project.CustomCreatures)
			{
				EncounterCard card = new EncounterCard();
				card.CreatureID = cc.ID;

				fCreatures.Add(card);

				if (include_templates)
					add_templates(cc);
			}
		}

		static void add_templates(ICreature creature)
		{
			// Can't add a template to a minion
			if (creature.Role is Minion)
				return;

			// Can't add a template to a solo
			ComplexRole role = creature.Role as ComplexRole;
			if (role.Flag == RoleFlag.Solo)
				return;

			foreach (Library lib in Session.Libraries)
			{
				foreach (CreatureTemplate tmpl in lib.Templates)
				{
					EncounterCard card = new EncounterCard();
					card.CreatureID = creature.ID;
					card.TemplateIDs.Add(tmpl.ID);
				}
			}
		}

		#endregion

		#region Trap list

		static void build_trap_list(int level)
		{
			int min_level = level - 3;
			int max_level = level + 5;

			fTraps.Clear();
			foreach (Trap trap in Session.Traps)
			{
				if ((trap.Level < min_level) || (trap.Level > max_level))
					continue;

				fTraps.Add(trap);
			}
		}

		#endregion

		#region Challenge list

		static void build_challenge_list(int level)
		{
			int min_level = level - 3;
			int max_level = level + 5;

			fChallenges.Clear();
			foreach (SkillChallenge sc in Session.SkillChallenges)
			{
				if ((sc.Level < min_level) || (sc.Level > max_level))
					continue;

				fChallenges.Add(sc);
			}
		}

		#endregion

		static List<EncounterTemplateGroup> fTemplateGroups = new List<EncounterTemplateGroup>();
		static List<EncounterCard> fCreatures = new List<EncounterCard>();
		static List<Trap> fTraps = new List<Trap>();
		static List<SkillChallenge> fChallenges = new List<SkillChallenge>();
	}
}
