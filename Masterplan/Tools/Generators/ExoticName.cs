using System.Collections.Generic;

namespace Masterplan.Tools.Generators
{
	class ExoticName
	{
		public static string SingleName()
		{
			return TextHelper.Capitalise(get_word(), true);
		}

		public static string FullName()
		{
			string first = TextHelper.Capitalise(get_word(), true);
			string second = TextHelper.Capitalise(get_word(), true);

			return first + " " + second;
		}

		public static string Sentence()
		{
			string sentence = "";

			int words = Session.Dice(3, 6);
			for (int n = 0; n != words; ++n)
			{
				if (sentence != "")
					sentence += " ";

				sentence += get_word();
			}

			sentence += ".";

			return TextHelper.Capitalise(sentence, false);
		}

		static string get_word()
		{
			List<string> vowels = new List<string>();
			vowels.Add("a");
			vowels.Add("e");
			vowels.Add("i");
			vowels.Add("o");
			vowels.Add("u");
			vowels.Add("ae");
			vowels.Add("ai");
			vowels.Add("ao");
			vowels.Add("au");
			vowels.Add("ea");
			vowels.Add("ee");
			vowels.Add("ei");
			vowels.Add("eo");
			vowels.Add("eu");
			vowels.Add("ia");
			vowels.Add("ie");
			vowels.Add("io");
			vowels.Add("iu");
			vowels.Add("oa");
			vowels.Add("oe");
			vowels.Add("oi");
			vowels.Add("oo");
			vowels.Add("ou");
			vowels.Add("ua");
			vowels.Add("ue");
			vowels.Add("ui");
			vowels.Add("uo");
			vowels.Add("y");

			List<string> consonants = new List<string>();
			consonants.AddRange(new string[] { "b" });
			consonants.AddRange(new string[] { "c", "ch" });
			consonants.AddRange(new string[] { "d" });
			consonants.AddRange(new string[] { "f", "fl", "fr" });
			consonants.AddRange(new string[] { "g", "gh", "gn", "gr" });
			consonants.AddRange(new string[] { "h" });
			consonants.AddRange(new string[] { "j" });
			consonants.AddRange(new string[] { "k", "kh", "kr" });
			consonants.AddRange(new string[] { "l", "ll" });
			consonants.AddRange(new string[] { "m" });
			consonants.AddRange(new string[] { "n" });
			consonants.AddRange(new string[] { "p", "ph", "pr" });
			consonants.AddRange(new string[] { "q" });
			consonants.AddRange(new string[] { "r", "rh" });
			consonants.AddRange(new string[] { "s", "sc", "sch", "sh", "sk", "sp", "st" });
			consonants.AddRange(new string[] { "t", "th" });
			consonants.AddRange(new string[] { "v" });
			consonants.AddRange(new string[] { "w", "wr" });

			string separator = "-";
			if (Session.Random.Next(3) == 0)
				separator = "'";

			string name = "";
			int syllables = Session.Random.Next(2) + 1;
			for (int n = 0; n != syllables; ++n)
			{
				if (name != "")
				{
					if (Session.Random.Next(10) == 0)
						name += separator;
				}

				if (name == "")
				{
					// Add a starting consonant
					int index = Session.Random.Next(consonants.Count);
					name += consonants[index];
				}

				// Add a vowel
				{
					int index = Session.Random.Next(vowels.Count);
					name += vowels[index];
				}

				// Add a consonant
				{
					int index = Session.Random.Next(consonants.Count);
					name += consonants[index];
				}
			}

			if (Session.Random.Next(4) == 0)
			{
				// Add a final vowel
				int index = Session.Random.Next(vowels.Count);
				string vowel = vowels[index];
				name += vowel[0];
			}

			return name;
		}
	}
}
