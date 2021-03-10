using System;
using System.Collections.Generic;

using Masterplan.Data;

namespace Masterplan.Tools.Generators
{
	class Treasure
	{
		public static List<Guid> PlaceholderIDs
		{
			get
			{
				if (fPlaceholderIDs == null)
				{
					fPlaceholderIDs = new List<Guid>();

					for (int level = 1; level <= 30; ++level)
					{
						Guid id = new Guid(level, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
						fPlaceholderIDs.Add(id);
					}
				}

				return fPlaceholderIDs;
			}
		}
		static List<Guid> fPlaceholderIDs = null;

		static MagicItem get_placeholder_item(int level)
		{
			int lvl = Math.Min(level, 30);

			MagicItem item = new MagicItem();
			item.Name = "Magic Item (level " + lvl + ")";
			item.Level = lvl;
			item.ID = PlaceholderIDs[lvl - 1];

			return item;
		}

		public static int GetItemValue(int level)
		{
			switch (level)
			{
				case 1:
					return 360;
				case 2:
					return 520;
				case 3:
					return 680;
				case 4:
					return 840;
				case 5:
					return 1000;
				case 6:
					return 1800;
				case 7:
					return 2600;
				case 8:
					return 3400;
				case 9:
					return 4200;
				case 10:
					return 5000;
				case 11:
					return 9000;
				case 12:
					return 13000;
				case 13:
					return 17000;
				case 14:
					return 21000;
				case 15:
					return 25000;
				case 16:
					return 45000;
				case 17:
					return 65000;
				case 18:
					return 85000;
				case 19:
					return 105000;
				case 20:
					return 125000;
				case 21:
					return 225000;
				case 22:
					return 325000;
				case 23:
					return 425000;
				case 24:
					return 525000;
				case 25:
					return 625000;
				case 26:
					return 1125000;
				case 27:
					return 1625000;
				case 28:
					return 2125000;
				case 29:
					return 2625000;
				case 30:
					return 3125000;
			}

			return 0;
		}

		public static List<Parcel> CreateParcelSet(int level, int size, bool placeholder_items)
		{
			List<Parcel> parcels = new List<Parcel>();

			switch (size)
			{
				case 1:
					{
						parcels.Add(get_magic_item(level + 2, placeholder_items));
					}
					break;
				case 2:
					{
						parcels.Add(get_magic_item(level + 2, placeholder_items));
					}
					break;
				case 3:
					{
						parcels.Add(get_magic_item(level + 4, placeholder_items));
						parcels.Add(get_magic_item(level + 2, placeholder_items));
					}
					break;
				case 4:
					{
						parcels.Add(get_magic_item(level + 4, placeholder_items));
						parcels.Add(get_magic_item(level + 3, placeholder_items));
						parcels.Add(get_magic_item(level + 1, placeholder_items));
					}
					break;
				case 5:
					{
						parcels.Add(get_magic_item(level + 4, placeholder_items));
						parcels.Add(get_magic_item(level + 3, placeholder_items));
						parcels.Add(get_magic_item(level + 2, placeholder_items));
						parcels.Add(get_magic_item(level + 1, placeholder_items));
					}
					break;
				case 6:
					{
						parcels.Add(get_magic_item(level + 4, placeholder_items));
						parcels.Add(get_magic_item(level + 3, placeholder_items));
						parcels.Add(get_magic_item(level + 2, placeholder_items));
						parcels.Add(get_magic_item(level + 2, placeholder_items));
						parcels.Add(get_magic_item(level + 1, placeholder_items));
					}
					break;
				case 7:
					{
						parcels.Add(get_magic_item(level + 4, placeholder_items));
						parcels.Add(get_magic_item(level + 3, placeholder_items));
						parcels.Add(get_magic_item(level + 2, placeholder_items));
						parcels.Add(get_magic_item(level + 2, placeholder_items));
						parcels.Add(get_magic_item(level + 1, placeholder_items));
						parcels.Add(get_magic_item(level + 1, placeholder_items));
					}
					break;
				case 8:
					{
						parcels.Add(get_magic_item(level + 4, placeholder_items));
						parcels.Add(get_magic_item(level + 3, placeholder_items));
						parcels.Add(get_magic_item(level + 3, placeholder_items));
						parcels.Add(get_magic_item(level + 2, placeholder_items));
						parcels.Add(get_magic_item(level + 2, placeholder_items));
						parcels.Add(get_magic_item(level + 1, placeholder_items));
						parcels.Add(get_magic_item(level + 1, placeholder_items));
					}
					break;
			}

			List<int> gp_values = get_gp_values(level);
			if (size == 1)
				gp_values.RemoveAt(0);

			foreach (int value in gp_values)
			{
				Parcel p = CreateParcel(value, placeholder_items);
				parcels.Add(p);
			}

			return parcels;
		}

		public static Parcel CreateParcel(int level, int size, bool placeholder)
		{
			List<Parcel> parcels = CreateParcelSet(level, size, placeholder);
			int index = Session.Random.Next() % parcels.Count;
			return parcels[index];
		}

		public static Parcel CreateParcel(int value, bool placeholder)
		{
			Parcel p = new Parcel();
			p.Name = "Items worth " + value + " GP";
			p.Value = value;

			if (!placeholder)
			{
				p.Details = RandomMundaneItem(value);
			}

			return p;
		}

		public static MagicItem RandomMagicItem(int level)
		{
			int item_level = Math.Min(30, level);

			List<MagicItem> candidates = new List<MagicItem>();
			foreach (MagicItem item in Session.MagicItems)
			{
				if (item.Level == item_level)
					candidates.Add(item);
			}

			if (candidates.Count != 0)
			{
				int index = Session.Random.Next() % candidates.Count;
				MagicItem item = candidates[index];

				return item;
			}

			return null;
		}

		public static Artifact RandomArtifact(Tier tier)
		{
			List<Artifact> candidates = new List<Artifact>();
			foreach (Artifact item in Session.Artifacts)
			{
				if (item.Tier == tier)
					candidates.Add(item);
			}

			if (candidates.Count != 0)
			{
				int index = Session.Random.Next() % candidates.Count;
				Artifact item = candidates[index];

				return item;
			}

			return null;
		}

		public static string RandomMundaneItem(int value)
		{
			List<string> items = create_from_gp(value);

			string details = "";
			foreach (string item in items)
			{
				if (details != "")
					details += "; ";

				details += item;
			}

			return details;
		}

		public static string ArtObject()
		{
			string item = random_item_type(false, false);

			item = (TextHelper.StartsWithVowel(item) ? "An" : "A") + " " + item;

			return item;
		}

		static Parcel get_magic_item(int level, bool placeholder)
		{
			int item_level = Math.Min(30, level);

			if (placeholder)
			{
				return new Parcel(get_placeholder_item(level));
			}
			else
			{
				MagicItem mi = RandomMagicItem(item_level);
				if (mi != null)
					return new Parcel(mi);
			}

			Parcel p = new Parcel();
			p.Details = "Random magic item (level " + item_level + ")";
			return p;
		}

		static List<int> get_gp_values(int level)
		{
			switch (level)
			{
				case 1:
					return new List<int>(new int[] { 200, 180, 120, 120, 60, 40 });
				case 2:
					return new List<int>(new int[] { 290, 260, 170, 170, 90, 60 });
				case 3:
					return new List<int>(new int[] { 380, 340, 225, 225, 110, 75 });
				case 4:
					return new List<int>(new int[] { 470, 420, 280, 280, 140, 90 });
				case 5:
					return new List<int>(new int[] { 550, 500, 340, 340, 160, 110 });
				case 6:
					return new List<int>(new int[] { 1000, 900, 600, 600, 300, 200 });
				case 7:
					return new List<int>(new int[] { 1500, 1300, 850, 850, 400, 300 });
				case 8:
					return new List<int>(new int[] { 1900, 1700, 1100, 1100, 600, 400 });
				case 9:
					return new List<int>(new int[] { 2400, 2100, 1400, 1400, 700, 400 });
				case 10:
					return new List<int>(new int[] { 2800, 2500, 1700, 1700, 800, 500 });
				case 11:
					return new List<int>(new int[] { 5000, 4000, 3000, 3000, 2000, 1000 });
				case 12:
					return new List<int>(new int[] { 7200, 7000, 4400, 4400, 2000, 1000 });
				case 13:
					return new List<int>(new int[] { 9500, 8500, 5700, 5700, 2800, 1800 });
				case 14:
					return new List<int>(new int[] { 12000, 10000, 7000, 7000, 4000, 2000 });
				case 15:
					return new List<int>(new int[] { 14000, 12000, 8500, 8500, 5000, 2000 });
				case 16:
					return new List<int>(new int[] { 25000, 22000, 15000, 15000, 8000, 5000 });
				case 17:
					return new List<int>(new int[] { 36000, 33000, 22000, 22000, 11000, 6000 });
				case 18:
					return new List<int>(new int[] { 48000, 42000, 29000, 29000, 15000, 7000 });
				case 19:
					return new List<int>(new int[] { 60000, 52000, 35000, 35000, 18000, 10000 });
				case 20:
					return new List<int>(new int[] { 70000, 61000, 42000, 42000, 21000, 14000 });
				case 21:
					return new List<int>(new int[] { 125000, 112000, 75000, 75000, 38000, 25000 });
				case 22:
					return new List<int>(new int[] { 180000, 160000, 110000, 110000, 55000, 35000 });
				case 23:
					return new List<int>(new int[] { 240000, 210000, 140000, 140000, 70000, 50000 });
				case 24:
					return new List<int>(new int[] { 300000, 250000, 175000, 175000, 90000, 60000 });
				case 25:
					return new List<int>(new int[] { 350000, 320000, 200000, 200000, 100000, 80000 });
				case 26:
					return new List<int>(new int[] { 625000, 560000, 375000, 375000, 190000, 125000 });
				case 27:
					return new List<int>(new int[] { 900000, 800000, 550000, 550000, 280000, 170000 });
				case 28:
					return new List<int>(new int[] { 1200000, 1000000, 720000, 720000, 360000, 250000 });
				case 29:
					return new List<int>(new int[] { 1500000, 1300000, 875000, 875000, 450000, 250000 });
				case 30:
					return new List<int>(new int[] { 1750000, 1500000, 1000000, 1000000, 600000, 400000 });
			}

			return null;
		}

		static List<string> create_from_gp(int gp)
		{
			List<string> items = new List<string>();

			if (Session.Random.Next() % 4 == 0)
			{
				// Just coins
				items.Add(coins(gp));
			}
			else
			{
				// Split into [gems, art objects, potions] and leftover coins
				int current = gp;
				while (current != 0)
				{
					int value = get_value(current);
					if (value == 0)
						break;

					// How many of these will fit?
					int count = current / value;

					// What sort of item is it?
					string type = random_item_type(count != 1, true);

					if (count == 1)
					{
						string start = TextHelper.StartsWithVowel(type) ? "an" : "a";
						items.Add(start + " " + type + " (worth " + value + " GP)");
					}
					else
					{
						items.Add(count + " " + type + " (worth " + value + " GP each)");
					}

					current -= (value * count);
				}

				if (current != 0)
				{
					// Add leftover as coins
					items.Add(coins(current));
				}
			}

			for (int n = 0; n != items.Count; ++n)
			{
				items[n] = TextHelper.Capitalise(items[n], false);
			}

			return items;
		}

		static int get_value(int total)
		{
			List<int> candidates = new List<int>();

			foreach (int value in fValues)
			{
				int count = total / value;

				if ((count >= 1) && (count <= 10))
					candidates.Add(value);
			}

			if (candidates.Count == 0)
				return 0;

			int index = Session.Random.Next() % candidates.Count;
			return candidates[index];
		}

		static string random_item_type(bool plural, bool allow_potion)
		{
			string result = "";

			if (allow_potion)
			{
				if (Session.Random.Next() % 4 == 0)
				{
					result = "potion";

					if (plural)
						result += "s";

					return result;
				}
			}

			switch (Session.Random.Next() % 12)
			{
				case 0:
				case 1:
				case 2:
					// Gemstone
					#region Gemstone
					{
						int index = Session.Random.Next() % fStones.Count;
						string stone = fStones[index];

						switch (Session.Random.Next() % 2)
						{
							case 0:
								stone = stone + " gemstone";
								break;
							case 1:
								stone = "piece of " + stone;
								break;
						}

						switch (Session.Random.Next() % 12)
						{
							case 0:
								stone = "well cut " + stone;
								break;
							case 1:
								stone = "rough-cut " + stone;
								break;
							case 2:
								stone = "poorly cut " + stone;
								break;
							case 3:
								stone = "small " + stone;
								break;
							case 4:
								stone = "large " + stone;
								break;
							case 5:
								stone = "oddly shaped " + stone;
								break;
							case 6:
								stone = "highly polished " + stone;
								break;
							default:
								break;
						}

						result = stone;
					}
					#endregion
					break;
				case 3:
				case 4:
				case 5:
					// Object
					#region Object
					{
						int index = Session.Random.Next() % fObjects.Count;
						string artobject = fObjects[index];

						List<string> adjectives = new List<string>();
						adjectives.Add("small");
						adjectives.Add("large");
						adjectives.Add("light");
						adjectives.Add("heavy");
						adjectives.Add("delicate");
						adjectives.Add("fragile");
						adjectives.Add("masterwork");
						adjectives.Add("elegant");

						int adj_index = Session.Random.Next() % adjectives.Count;
						string adjective = adjectives[adj_index];

						result = adjective + " " + artobject;
					}
					#endregion
					break;
				case 6:
				case 7:
				case 8:
					// Jewellery
					#region Jewellery
					{
						int item_index = Session.Random.Next() % fJewellery.Count;
						string item = fJewellery[item_index];

						int metal_index = Session.Random.Next() % fMetals.Count;
						string metal = fMetals[metal_index];

						result = metal + " " + item;

						switch (Session.Random.Next(5))
						{
							case 0:
								// Enamelled or laquered
								{
									string deco = (Session.Random.Next(2) == 0) ? "enamelled" : "laquered";
									result = deco + " " + result;
								}
								break;
							case 1:
								// Filigree or plating
								{
									metal_index = Session.Random.Next() % fMetals.Count;
									metal = fMetals[metal_index];

									string deco = (Session.Random.Next(2) == 0) ? "plated" : "filigreed";
									result = metal + "-" + deco + " " + result;
								}
								break;
						}

						switch (Session.Random.Next() % 10)
						{
							case 0:
								result = "delicate " + result;
								break;
							case 1:
								result = "intricate " + result;
								break;
							case 2:
								result = "elegant " + result;
								break;
							case 3:
								result = "simple " + result;
								break;
							case 4:
								result = "plain " + result;
								break;
							default:
								break;
						}
					}
					#endregion
					break;
				case 9:
				case 10:
					// Artwork
					#region Artwork
					{
						string artwork = "";
						switch (Session.Random.Next(2))
						{
							case 0:
								// Painting
								#region Painting
								{
									artwork = "painting";

									switch (Session.Random.Next(2))
									{
										case 0:
											artwork = "oil " + artwork;
											break;
										case 1:
											artwork = "watercolour " + artwork;
											break;
									}
								}
								#endregion
								break;
							case 1:
								// Drawing
								#region Drawing
								{
									artwork = "drawing";

									switch (Session.Random.Next(2))
									{
										case 0:
											artwork = "pencil " + artwork;
											break;
										case 1:
											artwork = "charcoal " + artwork;
											break;
									}
								}
								#endregion
								break;
						}

						List<string> adjectives = new List<string>();
						adjectives.Add("small");
						adjectives.Add("large");
						adjectives.Add("delicate");
						adjectives.Add("fragile");
						adjectives.Add("elegant");
						adjectives.Add("detailed");

						List<string> media = new List<string>();
						media.Add("canvas");
						media.Add("paper");
						media.Add("parchment");
						media.Add("wood panels");
						media.Add("fabric");

						int adj_index = Session.Random.Next() % adjectives.Count;
						string adjective = adjectives[adj_index];

						int medium_index = Session.Random.Next() % media.Count;
						string medium = media[medium_index];

						result = adjective + " " + artwork + " on " + medium;

						// TODO: Subject
					}
					#endregion
					break;
				case 11:
					// Musical instrument
					#region Musical instrument
					{
						int index = Session.Random.Next() % fInstruments.Count;
						string artobject = fInstruments[index];

						List<string> adjectives = new List<string>();
						adjectives.Add("small");
						adjectives.Add("large");
						adjectives.Add("light");
						adjectives.Add("heavy");
						adjectives.Add("delicate");
						adjectives.Add("fragile");
						adjectives.Add("masterwork");
						adjectives.Add("elegant");

						int adj_index = Session.Random.Next() % adjectives.Count;
						string adjective = adjectives[adj_index];

						result = adjective + " " + artobject;
					}
					#endregion
					break;
			}

			if (plural)
				result += "s";

			switch (Session.Random.Next() % 5)
			{
				case 0:
					#region Provenance
					{
						List<string> sources = new List<string>();
						sources.Add("feywild");
						sources.Add("shadowfell");
						sources.Add("elemental chaos");
						sources.Add("astral plane");
						sources.Add("abyss");
						sources.Add("distant north");
						sources.Add("distant east");
						sources.Add("distant west");
						sources.Add("distant south");

						int source_index = Session.Random.Next() % sources.Count;
						string source = sources[source_index];

						result += " from the " + source;
					}
					#endregion
					break;
				case 1:
					#region Decoration
					{
						List<string> gerunds = new List<string>();
						gerunds.Add("decorated with");
						gerunds.Add("inscribed with");
						gerunds.Add("engraved with");
						gerunds.Add("embossed with");
						gerunds.Add("carved with");

						List<string> adjectives = new List<string>();
						adjectives.Add("indecipherable");
						adjectives.Add("ancient");
						adjectives.Add("curious");
						adjectives.Add("unusual");
						adjectives.Add("dwarven");
						adjectives.Add("eladrin");
						adjectives.Add("elven");
						adjectives.Add("draconic");
						adjectives.Add("gith");

						List<string> designs = new List<string>();
						designs.Add("script");
						designs.Add("designs");
						designs.Add("sigils");
						designs.Add("runes");
						designs.Add("glyphs");
						designs.Add("patterns");

						int gerund_index = Session.Random.Next() % gerunds.Count;
						string gerund = gerunds[gerund_index];

						int adjective_index = Session.Random.Next() % adjectives.Count;
						string adjective = adjectives[adjective_index];

						int design_index = Session.Random.Next() % designs.Count;
						string design = designs[design_index];

						result += " " + gerund + " " + adjective + " " + design;
					}
					#endregion
					break;
				case 2:
					#region Magical
					{
						List<string> gerunds = new List<string>();
						gerunds.Add("glowing with");
						gerunds.Add("suffused with");
						gerunds.Add("infused with");
						gerunds.Add("humming with");
						gerunds.Add("pulsing with");

						List<string> sources = new List<string>();
						sources.Add("arcane");
						sources.Add("divine");
						sources.Add("primal");
						sources.Add("psionic");
						sources.Add("shadow");
						sources.Add("elemental");
						sources.Add("unknown");

						List<string> powers = new List<string>();
						powers.Add("energy");
						powers.Add("power");
						powers.Add("magic");

						int gerund_index = Session.Random.Next() % gerunds.Count;
						string gerund = gerunds[gerund_index];

						int source_index = Session.Random.Next() % sources.Count;
						string source = sources[source_index];

						int power_index = Session.Random.Next() % powers.Count;
						string power = powers[power_index];

						result += " " + gerund + " " + source + " " + power;
					}
					#endregion
					break;
				case 4:
					#region Jewelled
					{
						List<string> gerunds = new List<string>();
						gerunds.Add("set with");
						gerunds.Add("inlaid with");
						gerunds.Add("studded with");
						gerunds.Add("with shards of");

						int stone_index = Session.Random.Next() % fStones.Count;
						string stone = fStones[stone_index];

						if (Session.Random.Next() % 2 == 0)
						{
							stone += "s";
						}
						else
						{
							stone = "a single " + stone;
						}

						int gerund_index = Session.Random.Next() % gerunds.Count;
						string gerund = gerunds[gerund_index];

						result += " " + gerund + " " + stone;
					}
					#endregion
					break;
			}

			return result;
		}

		static string coins(int gp)
		{
			// 1 AD = 10000 GP
			int ad = gp / 10000;
			int ad_rem = gp % 10000;
			if ((ad > 0) && (ad_rem == 0))
			{
				string str = "astral diamond";
				if (ad > 1)
					str += "s";

				return ad + " " + str;
			}

			// 1 PP = 100 GP
			int pp = gp / 100;
			int pp_rem = gp % 100;
			if ((pp >= 100) && (pp_rem == 0))
				return pp + " PP";

			// 10 SP = 1 GP
			int sp = gp * 10;
			if (sp <= 100)
				return sp + " SP";

			return gp + " GP";
		}

		static List<int> fValues = new List<int>(new int[] { 125000, 100000, 75000, 50000, 25000, 20000, 10000, 7500, 5000, 2500, 2000, 1000, 7500, 5000, 2500, 2000, 1000, 750, 500, 250, 200, 100, 50 });

		static List<string> fObjects = new List<string>(new string[] { "medal", "statuette", "sculpture", "idol", "chalice", "goblet", "dish", "bowl" });
		static List<string> fJewellery = new List<string>(new string[] { "ring", "necklace", "crown", "circlet", "bracelet", "anklet", "torc", "brooch", "pendant", "locket", "diadem", "tiara", "earring" });
		static List<string> fInstruments = new List<string>(new string[] { "lute", "lyre", "mandolin", "violin", "drum", "flute", "clarinet", "accordion", "banjo", "bodhran", "ocarina", "zither", "djembe" });

		static List<string> fStones = new List<string>(new string[] { "diamond", "ruby", "sapphire", "emerald", "amethyst", "garnet", "topaz", "pearl", "black pearl", "opal", "fire opal", "amber", "coral", "agate", "carnelian", "jade", "peridot", "moonstone", "alexandrite", "aquamarine", "jacinth", "marble" });
		static List<string> fMetals = new List<string>(new string[] { "gold", "silver", "bronze", "platinum", "electrum", "mithral", "orium", "adamantine" });
	}
}
