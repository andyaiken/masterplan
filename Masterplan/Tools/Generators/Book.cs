using System.Collections.Generic;

namespace Masterplan.Tools.Generators
{
	class Book
	{
		public static string Title()
		{
			string title = "";

			switch (Session.Random.Next(5))
			{
				case 0:
					{
						// The NOUN's NOUN
						bool concrete1 = (Session.Random.Next(2) == 0);
						bool concrete2 = (Session.Random.Next(2) == 0);
						title = noun_phrase(concrete1, concrete1) + "'s " + noun_phrase(concrete2, false);
					}
					break;
				case 1:
					{
						// The NOUN and the NOUN
						bool concrete1 = (Session.Random.Next(2) == 0);
						bool concrete2 = (Session.Random.Next(2) == 0);
						title = noun_phrase(concrete1, concrete1) + " " + preposition() + " " + noun_phrase(concrete2, concrete2);
					}
					break;
				case 2:
					{
						// VERBING the NOUN
						bool concrete = (Session.Random.Next(2) == 0);
						title = gerund() + " the " + noun_phrase(concrete, false);
					}
					break;
				case 3:
					{
						if (Session.Random.Next(2) == 0)
						{
							// About CONCRETE_NOUNs
							title = about() + " " + noun(true) + "s";
						}
						else
						{
							// About ABTRACT_NOUN
							title = about() + " " + noun(false);
						}
					}
					break;
				case 4:
					{
						// The NOUN
						bool concrete = (Session.Random.Next(2) == 0);
						title = noun_phrase(concrete, true);
					}
					break;
			}

			if (Session.Random.Next(10) == 0)
			{
				// Append a volume number

				string type = "";
				switch (Session.Random.Next(2))
				{
					case 0:
						type = "volume";
						break;
					case 1:
						type = "part";
						break;
				}

				int volume = Session.Random.Next(5);
				switch (volume)
				{
					case 0:
						title += ", " + type + " one";
						break;
					case 1:
						title += ", " + type + " two";
						break;
					case 2:
						title += ", " + type + " three";
						break;
					case 3:
						title += ", " + type + " four";
						break;
					case 4:
						title += ", " + type + " five";
						break;
				}
			}

			// Capitalise
			title = TextHelper.Capitalise(title, true);

			return title;
		}

		static string noun_phrase(bool concrete_noun, bool article)
		{
			string np = noun(concrete_noun);

			bool plural = false;
			if ((concrete_noun) && (Session.Random.Next(5) == 0))
			{
				// Pluralise
				np += "s";
				plural = true;
			}

			if (Session.Random.Next(3) == 0)
			{
				string adj = adjective();
				np = adj + " " + np;
			}

			if (article)
			{
				if (Session.Random.Next(2) == 0)
				{
					// Prepend 'the' or 'a' / 'an' or 'one'
					switch (Session.Random.Next(2))
					{
						case 0:
							np = "the " + np;
							break;
						case 1:
							if (!plural)
							{
								switch (Session.Random.Next(2))
								{
									case 0:
										np = (TextHelper.StartsWithVowel(np) ? "an" : "a") + " " + np;
										break;
									case 1:
										np = "one " + np;
										break;
								}
							}
							else
							{
								switch (Session.Random.Next(6))
								{
									case 0:
										np = "two " + np;
										break;
									case 1:
										np = "three " + np;
										break;
									case 2:
										np = "four " + np;
										break;
									case 3:
										np = "five " + np;
										break;
									case 4:
										np = "six " + np;
										break;
									case 5:
										np = "seven " + np;
										break;
								}
							}
							break;
					}
				}
			}

			return np;
		}

		static string noun(bool concrete)
		{
			List<string> list = new List<string>();

			if (concrete)
			{
				list.Add("elf");
				list.Add("eladrin");
				list.Add("halfling");
				list.Add("dwarf");
				list.Add("gnome");
				list.Add("deva");
				list.Add("tiefling");
				list.Add("dragonborn");
				list.Add("goliath");
				list.Add("changeling");
				list.Add("drow");
				list.Add("minotaur");

				list.Add("beast");
				list.Add("orc");
				list.Add("goblin");
				list.Add("hobgoblin");
				list.Add("dragon");
				list.Add("demon");
				list.Add("devil");
				list.Add("angel");
				list.Add("god");
				list.Add("gith");

				list.Add("night");
				list.Add("day");
				list.Add("eclipse");
				list.Add("shadow");

				list.Add("sun");
				list.Add("moon");
				list.Add("star");

				list.Add("battle");
				list.Add("war");
				list.Add("brawl");
				list.Add("fist");
				list.Add("blade");
				list.Add("arrow");
				list.Add("spell");
				list.Add("prayer");
				list.Add("eye");
				list.Add("wing");
				list.Add("army");
				list.Add("legion");
				list.Add("brigade");

				list.Add("galleon");
				list.Add("warship");
				list.Add("frigate");

				list.Add("potion");
				list.Add("jewel");
				list.Add("ring");
				list.Add("amulet");
				list.Add("cloak");
				list.Add("sword");
				list.Add("spear");
				list.Add("helm");

				list.Add("flame");

				list.Add("wizard");
				list.Add("king");
				list.Add("queen");
				list.Add("prince");
				list.Add("princess");
				list.Add("warlock");
				list.Add("barbarian");
				list.Add("sorcerer");
				list.Add("thief");
				list.Add("mage");
				list.Add("child");
				list.Add("wayfarer");
				list.Add("adventurer");
				list.Add("pirate");
				list.Add("spy");
				list.Add("sage");
				list.Add("assassin");

				list.Add("mountain");
				list.Add("forest");
				list.Add("peak");
				list.Add("cave");
				list.Add("cavern");
				list.Add("lake");
				list.Add("swamp");
				list.Add("marshland");
				list.Add("island");
				list.Add("shore");

				list.Add("city");
				list.Add("town");
				list.Add("village");
				list.Add("tower");
				list.Add("arena");
				list.Add("castle");
				list.Add("citadel");

				list.Add("game");
				list.Add("wager");
				list.Add("quest");
				list.Add("challenge");

				list.Add("rose");
				list.Add("lily");
				list.Add("thorn");

				list.Add("word");
				list.Add("snake");

				list.Add("song");
				list.Add("lament");
				list.Add("dirge");
				list.Add("elegy");
			}
			else
			{
				list.Add("darkness");
				list.Add("light");
				list.Add("dusk");
				list.Add("twilight");

				list.Add("revenge");
				list.Add("vengeance");
				list.Add("blood");

				list.Add("earth");
				list.Add("water");
				list.Add("ice");
				list.Add("wood");
				list.Add("metal");
				list.Add("lightning");
				list.Add("thunder");
				list.Add("mist");

				list.Add("destruction");
				list.Add("life");
				list.Add("death");
				list.Add("time");
				list.Add("end");

				list.Add("danger");
				list.Add("luck");
				list.Add("chaos");
				list.Add("truth");

				list.Add("music");

				list.Add("one");
				list.Add("two");
				list.Add("three");
				list.Add("four");
				list.Add("five");
				list.Add("six");
				list.Add("seven");
				list.Add("eight");
				list.Add("nine");
				list.Add("ten");
				list.Add("eleven");
				list.Add("twelve");
			}
			
			list.Add("wind");
			list.Add("stone");
			list.Add("fire");
			list.Add("storm");

			int index = Session.Random.Next(list.Count);
			return list[index];
		}

		static string adjective()
		{
			List<string> list = new List<string>();

			list.Add("dark");
			list.Add("bright");
			list.Add("tyrannous");
			list.Add("devout");
			list.Add("noble");
			list.Add("eldritch");
			list.Add("mystical");
			list.Add("magical");
			list.Add("sorcerous");
			list.Add("savage");
			list.Add("silent");
			list.Add("lonely");
			list.Add("violent");
			list.Add("peaceful");
			list.Add("black");
			list.Add("white");
			list.Add("gold");
			list.Add("silver");
			list.Add("red");
			list.Add("pale");
			list.Add("dying");
			list.Add("living");
			list.Add("ascending");
			list.Add("defiled");
			list.Add("mythical");
			list.Add("legendary");
			list.Add("heroic");
			list.Add("empty");
			list.Add("mighty");
			list.Add("despairing");
			list.Add("spellbound");
			list.Add("enchanted");
			list.Add("soaring");
			list.Add("falling");
			list.Add("visionary");
			list.Add("bold");
			list.Add("perilous");

			int index = Session.Random.Next(list.Count);
			return list[index];
		}

		static string gerund()
		{
			List<string> list = new List<string>();

			list.Add("killing");
			list.Add("murdering");
			list.Add("watching");
			list.Add("examining");
			list.Add("enchanting");
			list.Add("destroying");
			list.Add("defying");
			list.Add("betraying");
			list.Add("protecting");
			list.Add("silencing");
			list.Add("bearing");
			list.Add("fighting");

			int index = Session.Random.Next(list.Count);
			return list[index];
		}

		static string preposition()
		{
			int index = Session.Random.Next(fPrepositions.Length);
			return fPrepositions[index];
		}

		static string about()
		{
			int index = Session.Random.Next(fAbout.Length);
			return fAbout[index];
		}

		static string[] fPrepositions = { "and", "in", "of", "with", "without", "against", "for", "to" };
		static string[] fAbout = { "about", "on", "concerning", "regarding" };
	}
}
