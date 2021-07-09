using System.Collections.Generic;

namespace Masterplan.Tools.Generators
{
	class DwarfName
	{
		public static string MaleName()
		{
			return name(true);
		}

		public static string FemaleName()
		{
			return name(false);
		}

		public static string Sentence()
		{
			string sentence = "";

			int words = Session.Dice(4, 8);
			for (int n = 0; n != words; ++n)
			{
				string word = "";

				int syllables = 0;
				switch (Session.Random.Next(4))
				{
					case 0:
						syllables = 1;
						break;
					case 1:
					case 2:
						syllables = 2;
						break;
					case 3:
						syllables = 3;
						break;
				}

				for (int x = 0; x != syllables; ++x)
				{
					switch (Session.Random.Next(2))
					{
						case 0:
							word += prefix();
							break;
						case 1:
							word += suffix_male();
							break;
					}

					if ((x != syllables) && (Session.Random.Next(10) == 0))
					{
						List<string> extras = new List<string>();
						extras.Add("k");
						extras.Add("z");
						extras.Add("g");
						extras.Add("-");
						extras.Add("'");

						int index = Session.Random.Next(extras.Count);
						word += extras[index];
					}
				}

				word = word.ToLower();
				if (sentence == "")
				{
					word = TextHelper.Capitalise(word, false);
				}
				else
				{
					sentence += " ";

					if (Session.Random.Next(20) == 0)
						word = TextHelper.Capitalise(word, false);
				}

				sentence += word;
			}

			sentence += ".";

			return sentence;
		}

		static string name(bool male)
		{
			string name = "";

			switch (Session.Random.Next(8))
			{
				case 0:
					name = prefix() + (male ? suffix_male() : suffix_female());
					break;
				case 1:
				case 2:
				case 3:
				case 4:
					name = prefix() + (male ? suffix_male() : suffix_female()) + " " + thing(true) + thing(false);
					break;
				case 5:
				case 6:
					name = prefix() + (male ? suffix_male() : suffix_female()) + " " + prefix() + (male ? suffix_male() : suffix_female());
					break;
				case 7:
					name = prefix() + (male ? suffix_male() : suffix_female()) + " " + prefix() + (male ? suffix_male() : suffix_female()) + " '" + thing(true) + "-" + thing(false) + "'";
					break;
			}

			return TextHelper.Capitalise(name, true);
		}

		static string prefix()
		{
			List<string> values = new List<string>();
			//values.Add("A");
			values.Add("Al");
			values.Add("An");
			values.Add("Ar");
			values.Add("Ara");
			values.Add("Az");
			//values.Add("B");
			values.Add("Bal");
			values.Add("Bar");
			values.Add("Bari");
			values.Add("Baz");
			values.Add("Bel");
			values.Add("Bof");
			values.Add("Bol");
			//values.Add("D");
			values.Add("Dal");
			values.Add("Dar");
			values.Add("Dare");
			values.Add("Del");
			values.Add("Dol");
			values.Add("Dor");
			values.Add("Dora");
			values.Add("Duer");
			values.Add("Dur");
			values.Add("Duri");
			values.Add("Dw");
			values.Add("Dwo");
			values.Add("Dy");
			values.Add("El");
			values.Add("Er");
			values.Add("Eri");
			values.Add("Fal");
			values.Add("Fall");
			values.Add("Far");
			values.Add("Gar");
			values.Add("Gil");
			values.Add("Gim");
			values.Add("Glan");
			values.Add("Glor");
			values.Add("Glori");
			values.Add("Har");
			values.Add("Hel");
			values.Add("Jar");
			values.Add("Kil");
			values.Add("Ma");
			values.Add("Mar");
			values.Add("Mor");
			values.Add("Mori");
			values.Add("Nal");
			values.Add("Nor");
			values.Add("Nora");
			values.Add("Nur");
			values.Add("Nura");
			//values.Add("O");
			values.Add("Ol");
			values.Add("Or");
			values.Add("Ori");
			values.Add("Ov");
			values.Add("Rei");
			values.Add("Th");
			values.Add("Ther");
			values.Add("Tho");
			values.Add("Thor");
			values.Add("Thr");
			values.Add("Thra");
			values.Add("Tor");
			values.Add("Tore");
			values.Add("Ur");
			values.Add("Urni");
			values.Add("Val");
			values.Add("Von");
			values.Add("Wer");
			values.Add("Wera");
			values.Add("Whur");
			values.Add("Yur");

			int index = Session.Random.Next(values.Count);
			return values[index];
		}

		static string suffix_male()
		{
			List<string> values = new List<string>();
			values.Add("aim");
			values.Add("and");
			values.Add("ain");
			values.Add("arn");
			values.Add("ak");
			values.Add("ar");
			values.Add("ard");
			values.Add("auk");
			values.Add("bere");
			values.Add("bir");
			values.Add("bin");
			values.Add("dak");
			values.Add("dek");
			values.Add("dal");
			values.Add("din");
			values.Add("el");
			values.Add("ent");
			values.Add("erl");
			values.Add("gal");
			values.Add("gan");
			values.Add("gar");
			values.Add("gath");
			values.Add("gen");
			values.Add("grim");
			values.Add("gur");
			values.Add("guk");
			//values.Add("i");
			values.Add("ik");
			values.Add("ias");
			values.Add("ili");
			values.Add("li");
			values.Add("im");
			values.Add("rim");
			values.Add("in");
			values.Add("rin");
			values.Add("ir");
			values.Add("init");
			values.Add("kas");
			values.Add("kral");
			values.Add("lond");
			//values.Add("o");
			values.Add("oak");
			values.Add("on");
			values.Add("lon");
			values.Add("or");
			values.Add("ror");
			values.Add("oril");
			values.Add("oric");
			values.Add("rak");
			values.Add("ral");
			values.Add("rek");
			values.Add("ric");
			values.Add("rid");
			values.Add("rim");
			values.Add("ring");
			values.Add("ster");
			values.Add("stili");
			values.Add("sun");
			values.Add("ten");
			values.Add("thal");
			values.Add("then");
			values.Add("thic");
			values.Add("thur");
			values.Add("ur");
			values.Add("rur");
			values.Add("urt");
			values.Add("ut");
			values.Add("unt");
			values.Add("val");
			values.Add("var");
			values.Add("villi");

			int index = Session.Random.Next(values.Count);
			return values[index];
		}

		static string suffix_female()
		{
			List<string> values = new List<string>();
			//values.Add("a");
			values.Add("aed");
			values.Add("ala");
			values.Add("la");
			values.Add("alsia");
			values.Add("ana");
			values.Add("ani");
			values.Add("astr");
			values.Add("bela");
			values.Add("bera");
			values.Add("bena");
			values.Add("bo");
			values.Add("bryn");
			values.Add("deth");
			values.Add("dis");
			values.Add("dred");
			values.Add("drid");
			values.Add("dris");
			values.Add("esli");
			values.Add("gret");
			values.Add("gunn");
			values.Add("hild");
			values.Add("ia");
			values.Add("ida");
			values.Add("iess");
			values.Add("iff");
			values.Add("ifra");
			values.Add("ila");
			values.Add("ild");
			values.Add("ina");
			values.Add("ip");
			values.Add("ippa");
			values.Add("isi");
			values.Add("iz");
			values.Add("ja");
			values.Add("kara");
			values.Add("li");
			values.Add("ili");
			values.Add("lin");
			values.Add("lydd");
			values.Add("mora");
			values.Add("moa");
			values.Add("ola");
			values.Add("on");
			values.Add("ona");
			values.Add("ora");
			values.Add("oa");
			values.Add("re");
			values.Add("rra");
			values.Add("ren");
			values.Add("serd");
			values.Add("shar");
			values.Add("sha");
			values.Add("thra");
			values.Add("tia");
			values.Add("tryd");
			values.Add("unn");
			values.Add("wynn");
			values.Add("ya");
			values.Add("ydd");

			int index = Session.Random.Next(values.Count);
			return values[index];
		}

		static string thing(bool first)
		{
			List<string> values = new List<string>();

			values.Add("forge");
			values.Add("anvil");

			values.Add("hammer");
			values.Add("maul");
			values.Add("shield");
			values.Add("hide");

			values.Add("gold");
			values.Add("silver");
			values.Add("bronze");
			values.Add("brass");
			values.Add("steel");
			values.Add("iron");
			values.Add("copper");
			values.Add("glint");

			values.Add("rock");
			values.Add("stone");
			values.Add("crag");
			values.Add("mountain");
			values.Add("cave");

			values.Add("wrath");
			values.Add("foe");
			values.Add("bound");

			if (first)
			{
				values.Add("goblin");
				values.Add("drake");
				values.Add("giant");
				values.Add("wolf");
				values.Add("boar");
				values.Add("bear");

				values.Add("red");
				values.Add("black");
				values.Add("white");

				values.Add("winter");
				values.Add("ice");
				values.Add("storm");

				values.Add("deep");
				values.Add("dark");

				values.Add("mighty");
				values.Add("stout");
				values.Add("proud");
				values.Add("brave");
				values.Add("bold");
				values.Add("sure");
				values.Add("strong");
				values.Add("wise");
				values.Add("riven");
			}
			else
			{
				values.Add("tooth");
				values.Add("bone");
				values.Add("heart");
				values.Add("fist");

				values.Add("hold");
				values.Add("fast");
				values.Add("guard");

				values.Add("hunter");
				values.Add("killer");
				values.Add("delver");
				values.Add("crusher");
				values.Add("mauler");
				values.Add("breaker");
				values.Add("smasher");
				values.Add("slayer");
				values.Add("striker");

				values.Add("keeper");
				values.Add("warden");
				values.Add("smith");
				values.Add("mason");
				values.Add("friend");
				values.Add("master");
			}

			int index = Session.Random.Next(values.Count);
			return values[index];
		}
	}
}
