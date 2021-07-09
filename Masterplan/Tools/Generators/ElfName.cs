using System.Collections.Generic;

namespace Masterplan.Tools.Generators
{
	class ElfName
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
				switch (Session.Random.Next(6))
				{
					case 0:
						syllables = 1;
						break;
					case 1:
					case 2:
						syllables = 2;
						break;
					case 3:
					case 4:
						syllables = 3;
						break;
					case 5:
						syllables = 4;
						break;
				}

				for (int x = 0; x != syllables; ++x)
				{
					switch (Session.Random.Next(3))
					{
						case 0:
							word += prefix();
							break;
						case 1:
							word += suffix(true);
							break;
						case 2:
							word += suffix(false);
							break;
					}

					if ((x != syllables) && (Session.Random.Next(10) == 0))
					{
						List<string> extras = new List<string>();
						extras.Add("y");
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

			switch (Session.Random.Next(10))
			{
				case 0:
				case 1:
				case 2:
				case 3:
					name = prefix() + suffix(male);
					break;
				case 4:
				case 5:
				case 6:
					name = prefix() + suffix(male) + suffix(male);
					break;
				case 7:
				case 8:
					name = prefix() + suffix(male) + " " + prefix() + suffix(male);
					break;
				case 9:
					name = suffix(male) + "'" + prefix() + suffix(male) + suffix(male);
					break;
			}

			return TextHelper.Capitalise(name, true);
		}

		static string prefix()
		{
			List<string> values = new List<string>();
			values.Add("ael");
			values.Add("aer");
			values.Add("af");
			values.Add("ah");
			values.Add("al");
			values.Add("am");
			values.Add("ama");
			values.Add("an");
			values.Add("ang");
			values.Add("ansr");
			values.Add("ar");
			values.Add("ari");
			values.Add("arn");
			values.Add("aza");
			values.Add("bael");
			values.Add("bes");
			values.Add("cael");
			values.Add("cal");
			values.Add("cas");
			values.Add("cla");
			values.Add("cor");
			values.Add("cy");
			values.Add("dae");
			values.Add("dho");
			values.Add("dre");
			values.Add("du");
			values.Add("eli");
			values.Add("eir");
			values.Add("el");
			values.Add("er");
			values.Add("ev");
			values.Add("fera");
			values.Add("fi");
			values.Add("fir");
			values.Add("fis");
			values.Add("gael");
			values.Add("gar");
			values.Add("gil");
			values.Add("ha");
			values.Add("hu");
			values.Add("ia");
			values.Add("il");
			values.Add("ja");
			values.Add("jar");
			values.Add("ka");
			values.Add("kan");
			values.Add("ker");
			values.Add("keth");
			values.Add("koeh");
			values.Add("kor");
			values.Add("ky");
			values.Add("la");
			values.Add("laf");
			values.Add("lam");
			values.Add("lue");
			values.Add("ly");
			values.Add("mai");
			values.Add("mal");
			values.Add("mara");
			values.Add("my");
			values.Add("na");
			values.Add("nai");
			values.Add("nim");
			values.Add("nu");
			values.Add("ny");
			values.Add("py");
			values.Add("raer");
			values.Add("re");
			values.Add("ren");
			values.Add("rid");
			values.Add("ru");
			values.Add("rua");
			values.Add("rum");
			values.Add("ry");
			values.Add("sae");
			values.Add("seh");
			values.Add("sel");
			values.Add("sha");
			values.Add("she");
			values.Add("si");
			values.Add("sim");
			values.Add("sol");
			values.Add("sum");
			values.Add("syl");
			values.Add("ta");
			values.Add("tahl");
			values.Add("tha");
			values.Add("tho");
			values.Add("ther");
			values.Add("thro");
			values.Add("tia");
			values.Add("tra");
			values.Add("ty");
			values.Add("uth");
			values.Add("ver");
			values.Add("vil");
			values.Add("von");
			values.Add("ya");
			values.Add("za");
			values.Add("zy");

			int index = Session.Random.Next(values.Count);
			return values[index];
		}

		static string suffix(bool male)
		{
			List<string> values = new List<string>();
			values.Add("ae");
			values.Add("nae");
			values.Add("ael");
			values.Add(male ? "aer" : "aera");
			values.Add(male ? "aias" : "aia");
			values.Add(male ? "ah" : "aha");
			values.Add(male ? "aith" : "aira");
			values.Add(male ? "al" : "ala");
			values.Add("ali");
			values.Add(male ? "am" : "ama");
			values.Add(male ? "an" : "ana");
			values.Add(male ? "ar" : "ara");
			values.Add("ari");
			values.Add("ri");
			values.Add("aro");
			values.Add("ro");
			values.Add("as");
			values.Add("ash");
			values.Add("sah");
			values.Add("ath");
			values.Add("avel");
			values.Add("brar");
			values.Add("abrar");
			values.Add("ibrar");
			values.Add("dar");
			values.Add("adar");
			values.Add("odar");
			values.Add("deth");
			values.Add("eath");
			values.Add("eth");
			values.Add("dre");
			values.Add("drim");
			values.Add("drimme");
			values.Add("udrim");
			values.Add("dul");
			values.Add("ean");
			values.Add("el");
			values.Add(male ? "ele" : "ela");
			values.Add("emar");
			values.Add("en");
			values.Add("er");
			values.Add("erl");
			values.Add("ern");
			values.Add("ess");
			values.Add("esti");
			values.Add("evar");
			values.Add("fel");
			values.Add("afel");
			values.Add("efel");
			values.Add("hal");
			values.Add("ahal");
			values.Add("ihal");
			values.Add("har");
			values.Add("ihar");
			values.Add("uhar");
			values.Add("hel");
			values.Add("ahel");
			values.Add("ihel");
			values.Add(male ? "ian" : "ianna");
			values.Add("ia");
			values.Add("ii");
			values.Add("ion");
			values.Add("iat");
			values.Add("ik");
			values.Add(male ? "il" : "ila");
			values.Add("iel");
			values.Add("lie");
			values.Add("im");
			values.Add("in");
			values.Add("inar");
			values.Add("ine");
			values.Add(male ? "ir" : "ira");
			values.Add("ire");
			values.Add("is");
			values.Add("iss");
			values.Add("ist");
			values.Add("ith");
			values.Add("lath");
			values.Add("lith");
			values.Add("lyth");
			values.Add("kash");
			values.Add("ashk");
			values.Add("okash");
			values.Add("ki");
			values.Add(male ? "lan" : "lanna");
			values.Add("lean");
			values.Add(male ? "olan" : "ola");
			values.Add("lam");
			values.Add("ilam");
			values.Add("ulam");
			values.Add("lar");
			values.Add("lirr");
			values.Add("las");
			values.Add(male ? "lian" : "lia");
			values.Add("lis");
			values.Add("elis");
			values.Add("lys");
			values.Add("lon");
			values.Add("ellon");
			values.Add("lyn");
			values.Add("llin");
			values.Add("lihn");
			values.Add(male ? "mah" : "ma");
			values.Add("mahs");
			values.Add("mil");
			values.Add("imil");
			values.Add("umil");
			values.Add("mus");
			values.Add("nal");
			values.Add("inal");
			values.Add("onal");
			values.Add("nes");
			values.Add("nin");
			values.Add("nine");
			values.Add("nyn");
			values.Add("nis");
			values.Add("anis");
			values.Add(male ? "on" : "onna");
			values.Add("or");
			values.Add("oro");
			values.Add("oth");
			values.Add("othi");
			values.Add("que");
			values.Add("quis");
			values.Add("rah");
			values.Add("rae");
			values.Add("raee");
			values.Add("rad");
			values.Add("rahd");
			values.Add(male ? "rail" : "ria");
			values.Add("aral");
			values.Add("ral");
			values.Add("ryl");
			values.Add("ran");
			values.Add("re");
			values.Add("reen");
			values.Add("reth");
			values.Add("rath");
			values.Add("ro");
			values.Add("ri");
			values.Add("ron");
			values.Add("ruil");
			values.Add("aruil");
			values.Add("eruil");
			values.Add("sal");
			values.Add("isal");
			values.Add("sali");
			values.Add("san");
			values.Add("sar");
			values.Add("asar");
			values.Add("isar");
			values.Add("sel");
			values.Add("asel");
			values.Add("isel");
			values.Add("sha");
			values.Add("she");
			values.Add("shor");
			values.Add("spar");
			values.Add("tae");
			values.Add("itae");
			values.Add("tas");
			values.Add("itas");
			values.Add("ten");
			values.Add("iten");
			values.Add(male ? "thal" : "tha");
			values.Add(male ? "ethel" : "etha");
			values.Add("thar");
			values.Add("ethar");
			values.Add("ithar");
			values.Add("ther");
			values.Add("ather");
			values.Add("thir");
			values.Add("thi");
			values.Add("ethil");
			values.Add("thil");
			values.Add(male ? "thus" : "thas");
			values.Add(male ? "aethus" : "aethas");
			values.Add("ti");
			values.Add("eti");
			values.Add("til");
			values.Add(male ? "tril" : "tria");
			values.Add("atri");
			values.Add(male ? "atril" : "atria");
			values.Add("ual");
			values.Add("lua");
			values.Add("uath");
			values.Add("uth");
			values.Add("luth");
			values.Add(male ? "us" : "ua");
			values.Add(male ? "van" : "vanna");
			values.Add(male ? "var" : "vara");
			values.Add(male ? "avar" : "avara");
			values.Add("vain");
			values.Add("avain");
			values.Add("via");
			values.Add("avia");
			values.Add("vin");
			values.Add("avin");
			values.Add("wyn");
			values.Add("ya");
			values.Add(male ? "yr" : "yn");
			values.Add("yth");
			values.Add(male ? "zair" : "zara");
			values.Add(male ? "azair" : "ezara");

			int index = Session.Random.Next(values.Count);
			return values[index];
		}
	}
}
