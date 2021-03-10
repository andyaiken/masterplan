using System;
using System.Collections.Generic;

namespace Masterplan.Tools.Generators
{
	class RoomBuilder
	{
		public static string Name()
		{
			List<string> names = new List<string>();

			names.Add("Antechamber");
			names.Add("Arena");
			names.Add("Armoury");
			names.Add("Aviary");
			names.Add("Audience Chamber");
			names.Add("Banquet Hall");
			names.Add("Bath Chamber");
			names.Add("Barracks");
			names.Add("Bedroom");
			names.Add("Boudoir");
			names.Add("Bestiary");
			names.Add("Burial Chamber");
			names.Add("Cells");
			names.Add("Chamber");
			names.Add("Chantry");
			names.Add("Chapel");
			names.Add("Classroom");
			names.Add("Closet");
			names.Add("Court");
			names.Add("Crypt");
			names.Add("Dining Room");
			names.Add("Dormitory");
			names.Add("Dressing Room");
			names.Add("Dumping Ground");
			names.Add("Entrance Hall");
			names.Add("Gallery");
			names.Add("Game Room");
			names.Add("Great Hall");
			names.Add("Guard Post");
			names.Add("Hall");
			names.Add("Harem");
			names.Add("Hoard");
			names.Add("Infirmary");
			names.Add("Kennels");
			names.Add("Kitchens");
			names.Add("Laboratory");
			names.Add("Lair");
			names.Add("Library");
			names.Add("Mausoleum");
			names.Add("Meditation Room");
			names.Add("Museum");
			names.Add("Nursery");
			names.Add("Observatory");
			names.Add("Office");
			names.Add("Pantry");
			names.Add("Prison");
			names.Add("Quarters");
			names.Add("Reception Room");
			names.Add("Refectory");
			names.Add("Ritual Chamber");
			names.Add("Shrine");
			names.Add("Smithy");
			names.Add("Stable");
			names.Add("Storeroom");
			names.Add("Study");
			names.Add("Temple");
			names.Add("Throne Room");
			names.Add("Torture Chamber");
			names.Add("Trophy Room");
			names.Add("Training Area");
			names.Add("Treasury");
			names.Add("Waiting Room");
			names.Add("Workroom");
			names.Add("Workshop");
			names.Add("Vault");
			names.Add("Vestibule");

			int index = Session.Random.Next() % names.Count;
			return names[index];
		}

		public static string Details()
		{
			List<string> lines = new List<string>();

			while (lines.Count == 0)
			{
				if (Session.Random.Next(2) == 0)
					lines.Add(random_wall());

				if (Session.Random.Next(3) == 0)
					lines.Add(random_finish());

				if (Session.Random.Next(4) == 0)
					lines.Add(random_air());

				if (Session.Random.Next(5) == 0)
					lines.Add(random_smell());

				if (Session.Random.Next(5) == 0)
					lines.Add(random_sound());

				if (Session.Random.Next(10) == 0)
					lines.Add(random_activity());
			}

			string desc = "";
			foreach (string line in lines)
			{
				if (desc != "")
					desc += " ";

				desc += line;
			}

			return desc;
		}

		static string random_wall()
		{
			List<string> walls = new List<string>();

			walls.Add("The walls of this area are " + random_material() + ".");
			walls.Add("The walls of this area are " + random_material() + " and " + random_material() + ".");
			walls.Add("The floor of this area is made from " + random_material() + ".");
			walls.Add("The walls of this area are made of " + random_material() + ", while the ceiling and floor are " + random_material() + ".");
			walls.Add("This area has been hewn out of solid rock.");
			walls.Add("This area has been panelled in dark wood.");

			int index = Session.Random.Next() % walls.Count;
			return walls[index];
		}

		static string random_material()
		{
			List<string> materials = new List<string>();

			materials.Add("granite");
			materials.Add("slate");
			materials.Add("sandstone");
			materials.Add("brick");
			materials.Add("marble");
			materials.Add("slabs of rock");

			int index = Session.Random.Next() % materials.Count;
			string material = materials[index];

			if (Session.Random.Next(3) == 0)
			{
				List<string> adjectives = new List<string>();

				adjectives.Add("polished");
				adjectives.Add("rough");
				adjectives.Add("chiselled");
				adjectives.Add("uneven");
				adjectives.Add("worked");

				int adj_index = Session.Random.Next() % adjectives.Count;
				material = adjectives[adj_index] + " " + material;
			}

			return material;
		}

		static string random_finish()
		{
			List<string> finishes = new List<string>();

			finishes.Add("The walls here are covered in black soot.");
			finishes.Add("The walls are " + random_style() + " with " + random_deco() + ".");
			finishes.Add("Claw marks cover the walls here.");
			finishes.Add("The walls have been painted " + random_colour() + ".");
			finishes.Add("It is possible to tell that the walls were once plastered.");
			finishes.Add("Here and there, graffiti covers the walls.");
			finishes.Add("A thick layer of dust covers the room.");
			finishes.Add("Moss and lichen grows here and there on the walls.");
			finishes.Add("The patina of age covers the walls.");
			finishes.Add("Childlike drawings and sketches cover the walls.");
			finishes.Add("Cryptic signs have been scratched into the walls.");

			int index = Session.Random.Next() % finishes.Count;
			return finishes[index];
		}

		static string random_style()
		{
			List<string> styles = new List<string>();

			styles.Add("painted");
			styles.Add("engraved");

			int index = Session.Random.Next() % styles.Count;
			return styles[index];
		}

		static string random_deco()
		{
			List<string> deco = new List<string>();

			deco.Add("abstract artwork");
			deco.Add("battle scenes");
			deco.Add("landscape scenes");
			deco.Add("hunting scenes");
			deco.Add("pastoral scenes");
			deco.Add("religious symbols");
			deco.Add("runes");
			deco.Add("glyphs");
			deco.Add("sigils");
			deco.Add("cryptic signs");

			int index = Session.Random.Next() % deco.Count;
			return deco[index];
		}

		static string random_colour()
		{
			List<string> colours = new List<string>();

			colours.Add("black");
			colours.Add("white");
			colours.Add("grey");

			colours.Add("red");
			colours.Add("blue");
			colours.Add("yellow");
			
			colours.Add("purple");
			colours.Add("green");
			colours.Add("orange");
			
			colours.Add("brown");
			colours.Add("pink");

			int index = Session.Random.Next() % colours.Count;
			return colours[index];
		}

		static string random_air()
		{
			List<string> air = new List<string>();

			air.Add("The room is bitterly cold.");
			air.Add("There is a distinct chill in the air.");
			air.Add("A cold breeze blows through this area.");
			air.Add("A warm draught blows through this area.");
			air.Add("The area is uncomfortably hot.");
			air.Add("The air is dank.");
			air.Add("The air here is warm and humid.");
			air.Add("A strange mist hangs in the air here.");
			air.Add("The room's surfaces are covered in frost.");

			int index = Session.Random.Next() % air.Count;
			return air[index];
		}

		static string random_smell()
		{
			List<string> smells = new List<string>();

			smells.Add("A smell of burning hangs in the air.");
			smells.Add("The air feels stagnant.");
			smells.Add("From time to time the smell of blood catches your nostrils.");
			smells.Add("The stench of rotting meat is in the air.");
			smells.Add("The area has a strange musky smell.");
			smells.Add("You notice a strangly acrid smell throughout the area.");
			smells.Add("The area is filled with an unpleasant putrid smell.");

			int index = Session.Random.Next() % smells.Count;
			return smells[index];
		}

		static string random_sound()
		{
			List<string> sounds = new List<string>();

			sounds.Add("You can hear distant chanting.");
			sounds.Add("You can hear a quiet buzzing sound.");
			sounds.Add("The sound of running water fills this area.");
			sounds.Add("A low humming sound can be heard.");
			sounds.Add("The area is unnaturally quiet.");
			sounds.Add("A quiet susurration can just be heard.");
			sounds.Add("Creaking sounds fill the area.");
			sounds.Add("Scratching sounds can be heard.");
			sounds.Add("From time to time, a distant voice can be heard.");

			int index = Session.Random.Next() % sounds.Count;
			return sounds[index];
		}

		static string random_activity()
		{
			List<string> activities = new List<string>();

			activities.Add("The dust swirls as if disturbed by movement.");
			activities.Add("You catch a sudden movement out of the corner of your eye.");
			activities.Add("From time to time tiny pieces of debris fall from the ceiling.");
			activities.Add("Water drips slowly from a crack in the ceiling.");
			activities.Add("Water drips down the walls.");

			int index = Session.Random.Next() % activities.Count;
			return activities[index];
		}
	}
}
