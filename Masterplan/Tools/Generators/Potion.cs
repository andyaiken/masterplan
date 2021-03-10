using System;
using System.Collections.Generic;

namespace Masterplan.Tools.Generators
{
	class Potion
	{
		public static string Description()
		{
			string potion = "";

			string col = colour(true);
			string adj = adjective();
			string feat = feature();

			List<string> liquids = new List<string>();
			liquids.Add("liquid");
			liquids.Add("solution");
			liquids.Add("draught");
			liquids.Add("oil");
			liquids.Add("elixir");
			liquids.Add("potion");

			int index = Session.Random.Next(liquids.Count);
			string liquid = liquids[index];

			switch (Session.Random.Next(5))
			{
				case 0:
					potion = col + " " + liquid;
					break;
				case 1:
					potion = col + " " + liquid + " " + feat;
					break;
				case 2:
					potion = adj + " " + col + " " + liquid;
					break;
				case 3:
					potion = adj + " " + col + " " + liquid + " " + feat;
					break;
				case 4:
					potion = adj + " " + liquid + ", " + col + " " + feat + ",";
					break;
			}

			string start = TextHelper.StartsWithVowel(potion) ? "An" : "A";
			potion = start + " " + potion + " in " + container() + ".";

			switch (Session.Random.Next(5))
			{
				case 0:
					potion += " It smells " + smell() + ".";
					break;
				case 1:
					potion += " It tastes " + smell() + ".";
					break;
				case 2:
					potion += " It smells " + smell() + " but tastes " + smell() + ".";
					break;
				case 3:
					potion += " It smells and tastes " + smell() + ".";
					break;
			}

			// TODO: Advanced: layered / varigated / alternating colours

			return potion;
		}

		static string adjective()
		{
			List<string> values = new List<string>();

			values.Add("watery");
			values.Add("syrupy");

			values.Add("thick");
			values.Add("viscous");
			values.Add("gloopy");

			values.Add("thin");
			values.Add("runny");
			values.Add("translucent");

			values.Add("effervescent");
			values.Add("fizzing");
			values.Add("bubbling");
			values.Add("foaming");

			values.Add("volatile");
			values.Add("smoking");
			values.Add("fuming");
			values.Add("vaporous");

			values.Add("steaming");
			values.Add("cold");
			values.Add("icy cold");
			values.Add("hot");

			values.Add("sparkling");
			values.Add("iridescent");
			values.Add("cloudy");
			values.Add("opalescent");

			values.Add("luminous");
			values.Add("phosphorescent");
			values.Add("glowing");

			int index = Session.Random.Next(values.Count);
			return values[index];
		}

		static string colour(bool complex)
		{
			List<string> values = new List<string>();

			values.Add("red");
			values.Add("scarlet");
			values.Add("crimson");
			values.Add("vermillion");
			if (complex)
			{
				values.Add("blood red");
				values.Add("cherry red");
				values.Add("ruby-coloured");
			}

			values.Add("pink");
			if (complex)
				values.Add("rose-coloured");

			values.Add("blue");
			values.Add("royal blue");
			values.Add("sky blue");
			values.Add("light blue");
			values.Add("dark blue");
			values.Add("midnight blue");
			values.Add("indigo");
			if (complex)
				values.Add("sapphire-coloured");

			values.Add("yellow");
			values.Add("lemon yellow");
			values.Add("amber");
			if (complex)
				values.Add("straw-coloured");

			values.Add("green");
			values.Add("light green");
			values.Add("dark green");
			values.Add("sea green");
			values.Add("turquoise");
			values.Add("aquamarine");
			values.Add("emerald");
			if (complex)
				values.Add("olive-coloured");

			values.Add("purple");
			values.Add("lavender");
			values.Add("lilac");
			values.Add("mauve");
			if (complex)
				values.Add("plum-coloured");

			values.Add("orange");
			values.Add("brown");
			values.Add("maroon");
			values.Add("ochre");
			if (complex)
				values.Add("mud-coloured");

			values.Add("black");
			values.Add("dark grey");
			values.Add("grey");
			values.Add("light grey");
			if (complex)
			{
				values.Add("cream-coloured");
				values.Add("ivory-coloured");
			}
			values.Add("off-white");
			values.Add("white");

			values.Add("golden");
			values.Add("silver");
			if (complex)
				values.Add("bronze-coloured");

			if (complex)
			{
				values.Add("colourless");
				values.Add("clear");
				values.Add("transparent");
			}

			if (complex)
			{
				// TODO: Two colours
				// TODO: Marbled (two colours)
			}

			int index = Session.Random.Next(values.Count);
			return values[index];
		}

		static string feature()
		{
			switch (Session.Random.Next(5))
			{
				case 0:
					return "with " + colour(true) + " specks";
				case 1:
					return "with flecks of " + colour(false);
				case 2:
					{
						string col = colour(true);
						string article = TextHelper.StartsWithVowel(col) ? "an" : "a";
						return "with " + article + " " + col + " suspension";
					}
				case 3:
					return "with a floating " + colour(true) + " layer";
				case 4:
					return "with a ribbon of " + colour(false);
			}

			return "";
		}

		static string container()
		{
			List<string> shapes = new List<string>();
			shapes.Add("small");
			shapes.Add("rounded");
			shapes.Add("tall");
			shapes.Add("square");
			shapes.Add("irregularly-shaped");
			shapes.Add("long-necked");
			shapes.Add("cylindrical");
			shapes.Add("round-bottomed");

			List<string> materials = new List<string>();
			materials.Add("glass");
			materials.Add("metal");
			materials.Add("ceramic");
			materials.Add("crystal");

			List<string> types = new List<string>();
			types.Add("vial");
			types.Add("jar");
			types.Add("bottle");
			types.Add("flask");

			int shape_index = Session.Random.Next(shapes.Count);
			string shape = shapes[shape_index];

			int material_index = Session.Random.Next(materials.Count);
			string material = materials[material_index];

			int type_index = Session.Random.Next(types.Count);
			string type = types[type_index];

			if (Session.Random.Next(3) == 0)
				material = colour(true) + " " + material;

			string result = "";
			switch (Session.Random.Next(2))
			{
				case 0:
					result = material + " " + type;
					break;
				case 1:
					result = shape + " " + material + " " + type;
					break;
			}

			string start = TextHelper.StartsWithVowel(result) ? "an" : "a";
			return start + " " + result;
		}

		static string smell()
		{
			List<string> values = new List<string>();

			values.Add("acidic");
			values.Add("acrid");
			values.Add("of ammonia");
			values.Add("of apples");
			values.Add("bitter");
			values.Add("brackish");
			values.Add("buttery");
			values.Add("of cherries");
			values.Add("delicious");
			values.Add("earthy");
			values.Add("of earwax");
			values.Add("of fish");
			values.Add("floral");
			values.Add("of lavender");
			values.Add("lemony");
			values.Add("of honey");
			values.Add("fruity");
			values.Add("meaty");
			values.Add("metallic");
			values.Add("musty");
			values.Add("of onions");
			values.Add("of oranges");
			values.Add("peppery");
			values.Add("of perfume");
			values.Add("rotten");
			values.Add("salty");
			values.Add("sickly sweet");
			values.Add("starchy");
			values.Add("sugary");
			values.Add("smokey");
			values.Add("sour");
			values.Add("spicy");
			values.Add("of sweat");
			values.Add("sweet");
			values.Add("unpleasant");
			values.Add("vile");
			values.Add("vinegary");

			int index = Session.Random.Next(values.Count);
			return values[index];
		}
	}
}
