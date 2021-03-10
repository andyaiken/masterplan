using System;
using System.Collections.Generic;
using System.Drawing;

using Masterplan.Data;

namespace Masterplan.Tools.Generators
{
	class DelveBuilder
	{
		public static PlotPoint AutoBuild(Map map, AutoBuildData data)
		{
			PlotPoint pp = new PlotPoint(map.Name + " Delve");
			pp.Details = "This delve was automatically generated.";
			pp.Element = new MapElement(map.ID, Guid.Empty);

			int parcel_level = data.Level;
			List<Parcel> parcels = Treasure.CreateParcelSet(data.Level, Session.Project.Party.Size, false);

			foreach (MapArea ma in map.Areas)
			{
				PlotPoint point = new PlotPoint(ma.Name);

				switch (Session.Random.Next() % 8)
				{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
						// Encounter
						point.Element = get_encounter(map, ma, data);
						break;
					case 6:
						// Trap
						point.Element = get_encounter(map, ma, data);
						break;
					case 7:
						// Skill challenge
						point.Element = get_encounter(map, ma, data);
						break;
				}

				// Treasure parcels
				int parcel_count = 0;
				switch (Session.Random.Next() % 8)
				{
					case 0:
					case 1:
						// No parcels
						parcel_count = 0;
						break;
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
						// One parcel
						parcel_count = 1;
						break;
					case 7:
						// Two parcels
						parcel_count = 2;
						break;
				}

				for (int n = 0; n != parcel_count; ++n)
				{
					if (parcels.Count == 0)
					{
						// Generate a new list of parcels of the next level
						parcel_level = Math.Min(30, parcel_level + 1);
						parcels = Treasure.CreateParcelSet(parcel_level, Session.Project.Party.Size, false);
					}

					int index = Session.Random.Next() % parcels.Count;
					Parcel p = parcels[index];
					parcels.RemoveAt(index);

					point.Parcels.Add(p);
				}

				pp.Subplot.Points.Add(point);
			}

			return pp;
		}

		static Encounter get_encounter(Map map, MapArea ma, AutoBuildData data)
		{
			// Set up the encounter
			Encounter enc = new Encounter();
			enc.MapID = map.ID;
			enc.MapAreaID = ma.ID;
			EncounterBuilder.Build(data, enc, false);

			Difficulty diff = enc.GetDifficulty(Session.Project.Party.Level, Session.Project.Party.Size);
			if (diff != Difficulty.Extreme)
			{
				// Add a trap or skill challenge
				switch (Session.Random.Next() % 6)
				{
					case 0:
					case 1:
					case 3:
						// Add a trap
						Trap t = select_trap(data);
						if (t != null)
							enc.Traps.Add(t);
						break;
					case 4:
						// Add a skill challenge
						SkillChallenge sc = select_challenge(data);
						if (sc != null)
							enc.SkillChallenges.Add(sc);
						break;
					default:
						// Don't add anything else
						break;
				}
			}

			// Make matrix of tile squares
			List<Rectangle> tiles = new List<Rectangle>();
			foreach (TileData td in map.Tiles)
			{
				Tile t = Session.FindTile(td.TileID, SearchType.Global);
				int width = (td.Rotations % 2 == 0) ? t.Size.Width : t.Size.Height;
				int height = (td.Rotations % 2 == 0) ? t.Size.Height : t.Size.Width;
				Size sz = new Size(width, height);

				Rectangle rect = new Rectangle(td.Location, sz);
				tiles.Add(rect);
			}
			Dictionary<Point, bool> matrix = new Dictionary<Point, bool>();
			for (int x = ma.Region.Left; x != ma.Region.Right; ++x)
			{
				for (int y = ma.Region.Top; y != ma.Region.Bottom; ++y)
				{
					Point pt = new Point(x, y);

					// Is there a tile at this location?
					bool open = false;
					foreach (Rectangle rect in tiles)
					{
						if (rect.Contains(pt))
						{
							open = true;
							break;
						}
					}
					matrix[pt] = open;
				}
			}

			// Place creatures on the map
			foreach (EncounterSlot slot in enc.Slots)
			{
				ICreature creature = Session.FindCreature(slot.Card.CreatureID, SearchType.Global);
				int size = Creature.GetSize(creature.Size);

				foreach (CombatData cd in slot.CombatData)
				{
					// Find candidate points
					List<Point> candidates = new List<Point>();
					for (int x = ma.Region.Left; x != ma.Region.Right; ++x)
					{
						for (int y = ma.Region.Top; y != ma.Region.Bottom; ++y)
						{
							Point pt = new Point(x, y);

							// Is this location free?
							bool all_open = true;
							for (int dx = pt.X; dx != pt.X + size; ++dx)
							{
								for (int dy = pt.Y; dy != pt.Y + size; ++dy)
								{
									Point loc = new Point(dx, dy);
									if ((!matrix.ContainsKey(loc)) || (!matrix[loc]))
										all_open = false;
								}
							}

							if (all_open)
								candidates.Add(pt);
						}
					}

					if (candidates.Count != 0)
					{
						int index = Session.Random.Next() % candidates.Count;
						Point loc = candidates[index];

						// Place creature
						cd.Location = loc;

						// This space is now occupied
						for (int x = loc.X; x != loc.X + size; ++x)
						{
							for (int y = loc.Y; y != loc.Y + size; ++y)
							{
								Point pt = new Point(x, y);
								matrix[pt] = false;
							}
						}
					}
				}
			}

            // Set up notes

            enc.SetStandardEncounterNotes();
            EncounterNote light_note = enc.FindNote("Illumination");
            if (light_note != null)
            {
                int n = Session.Random.Next(6);
                switch (n)
                {
                    case 0:
                    case 1:
                    case 2:
                        light_note.Contents = "The area is in bright light.";
                        break;
                    case 3:
                    case 4:
                        light_note.Contents = "The area is in dim light.";
                        break;
                    case 5:
                        light_note.Contents = "None.";
                        break;
                }
            }

            EncounterNote victory_note = enc.FindNote("Victory Conditions");
            if (victory_note != null)
            {
                List<string> candidates = new List<string>();

                List<string> leaders = new List<string>();
                bool has_minions = false;
				int non_minions = 0;
                foreach (EncounterSlot slot in enc.Slots)
                {
					if (slot.CombatData.Count == 1)
					{
						if ((slot.Card.Leader) || (slot.Card.Flag == RoleFlag.Elite) || (slot.Card.Flag == RoleFlag.Solo))
							leaders.Add(slot.CombatData[0].DisplayName);
					}

                    ICreature c = Session.FindCreature(slot.Card.CreatureID, SearchType.Global);
					if (c != null)
					{
						if (c.Role is Minion)
							has_minions = true;
						else
							non_minions += slot.CombatData.Count;
					}
                }

				if (leaders.Count != 0)
				{
					int index = Session.Random.Next() % leaders.Count;
					string leader = leaders[index];

					if (Session.Random.Next() % 12 == 0)
					{
						candidates.Add("Defeat " + leader + ".");
						candidates.Add("Capture " + leader + ".");
					}

					if (Session.Random.Next() % 12 == 0)
					{
						int rounds = Session.Dice(2, 4);
						candidates.Add("The party must defeat " + leader + " within " + rounds + " rounds.");
					}

					if (Session.Random.Next() % 12 == 0)
					{
						int rounds = Session.Dice(2, 4);
						candidates.Add("After " + rounds + ", " + leader + " will flee or surrender.");
					}

					if (Session.Random.Next() % 12 == 0)
					{
						int hp = 10 * Session.Dice(1, 4);
						candidates.Add("At " + hp + "% HP, " + leader + " will flee or surrender.");
					}

					if (Session.Random.Next() % 12 == 0)
						candidates.Add("The party must obtain an item from " + leader + ".");

					if (Session.Random.Next() % 12 == 0)
						candidates.Add("Defeat " + leader + " by destroying a guarded object in the area.");

					if (has_minions)
						candidates.Add("Minions will flee or surrender when " + leader + " is defeated.");
				}

				if (Session.Random.Next() % 12 == 0)
				{
					int rounds = 2 + Session.Random.Next() % 4;
					candidates.Add("The party must defeat their opponents within " + rounds + " rounds.");
				}

                if ((has_minions) && (Session.Random.Next() % 12 == 0))
                {
                    int waves = 2 + Session.Random.Next() % 4;
                    candidates.Add("The party must defend a certain area from " + waves + " waves of minions.");
                }

				if (Session.Random.Next() % 12 == 0)
				{
					int rounds = 2 + Session.Random.Next() % 4;
					candidates.Add("At least one character must get to a certain area and stay there for " + rounds + " consecutive rounds.");
				}

				if (Session.Random.Next() % 12 == 0)
				{
					int rounds = 2 + Session.Random.Next() % 4;
					candidates.Add("The party must leave the area within " + rounds + " rounds.");
				}

				if (Session.Random.Next() % 12 == 0)
					candidates.Add("The party must keep the enemy away from a certain area for the duration of the encounter.");

				if (Session.Random.Next() % 12 == 0)
					candidates.Add("The party must escort an NPC safely through the encounter area.");

				if (Session.Random.Next() % 12 == 0)
					candidates.Add("The party must rescue an NPC from their opponents.");

				if (Session.Random.Next() % 12 == 0)
					candidates.Add("The party must avoid contact with the enemy in this area.");

				if (Session.Random.Next() % 12 == 0)
					candidates.Add("The party must attack and destroy a feature of the area.");

				if (non_minions > 1)
				{
					if (Session.Random.Next() % 12 == 0)
					{
						int n = 1 + Session.Random.Next(non_minions);
						candidates.Add("The party must defeat " + n + " non-minion opponents.");
					}
				}

				if (candidates.Count != 0)
                {
                    // Select an option
                    int index = Session.Random.Next() % candidates.Count;
                    victory_note.Contents = candidates[index];
                }
            }

			return enc;
		}

        static TrapElement get_trap(Map map, MapArea ma, AutoBuildData data)
		{
			Trap t = select_trap(data);
			if (t != null)
			{
				TrapElement te = new TrapElement();

				te.Trap = t;
				te.MapID = map.ID;
				te.MapAreaID = ma.ID;

				return te;
			}

			return null;
		}

        static SkillChallenge get_challenge(Map map, MapArea ma, AutoBuildData data)
		{
			SkillChallenge sc = select_challenge(data);
			if (sc != null)
			{
				sc.MapID = map.ID;
				sc.MapAreaID = ma.ID;

				return sc;
			}

			return null;
		}

		static Trap select_trap(AutoBuildData data)
		{
			List<Trap> traps = new List<Trap>();

			int min_level = data.Level - 3;
			int max_level = data.Level + 5;

			traps.Clear();
			foreach (Trap trap in Session.Traps)
			{
				if ((trap.Level < min_level) || (trap.Level > max_level))
					continue;

				traps.Add(trap.Copy());
			}

			if (traps.Count != 0)
			{
				int index = Session.Random.Next() % traps.Count;
				return traps[index];
			}

			return null;
		}

		static SkillChallenge select_challenge(AutoBuildData data)
		{
			List<SkillChallenge> challenges = new List<SkillChallenge>();

			int min_level = data.Level - 3;
			int max_level = data.Level + 5;

			challenges.Clear();
			foreach (SkillChallenge sc in Session.SkillChallenges)
			{
				if (sc.Level == -1)
				{
					SkillChallenge challenge = sc.Copy() as SkillChallenge;
					challenge.Level = Session.Project.Party.Level;
					challenges.Add(challenge);
				}
				else
				{
					if ((sc.Level < min_level) || (sc.Level > max_level))
						continue;

					challenges.Add(sc.Copy() as SkillChallenge);
				}
			}

			if (challenges.Count != 0)
			{
				int index = Session.Random.Next() % challenges.Count;
				return challenges[index];
			}

			return null;
		}
	}
}
