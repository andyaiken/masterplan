using System;
using System.Collections.Generic;

namespace Masterplan.Tools
{
	class TextHelper
	{
		static int LINE_LENGTH = 50;

		public static string Wrap(string str)
		{
			List<string> lines = new List<string>();

			while (str != "")
			{
				string line = get_first_line(ref str);
				lines.Add(line);
			}

			string wrapped = "";
			foreach (string line in lines)
			{
				if (wrapped != "")
					wrapped += Environment.NewLine;

				wrapped += line;
			}

			return wrapped;
		}

		static string get_first_line(ref string str)
		{
			string line = "";

			int length = Math.Min(LINE_LENGTH, str.Length);
			int index = str.IndexOf(" ", length);
			if (index == -1)
			{
				line = str;
				str = "";
			}
			else
			{
				line = str.Substring(0, index);
				str = str.Substring(index + 1);
			}

			return line;
		}

		public static string Abbreviation(string title)
		{
			string abbrev = "";
			foreach (string token in title.Split(null))
			{
				if (token == "")
					continue;

				bool is_number = false;
				try
				{
					int n = int.Parse(token);
					is_number = true;
				}
				catch
				{
					is_number = false;
				}

				if (is_number)
				{
					abbrev += token;
					continue;
				}

				char first = token[0];

				if (Char.IsUpper(first))
					abbrev += first;
			}

			return abbrev;
		}

		public static bool IsVowel(char ch)
		{
			if (fVowels == null)
			{
				fVowels = new List<char>();

				fVowels.Add('a');
				fVowels.Add('e');
				fVowels.Add('i');
				fVowels.Add('o');
				fVowels.Add('u');
			}

			return fVowels.Contains(ch);
		}
		static List<char> fVowels = null;

		public static bool StartsWithVowel(string str)
		{
			if (str.Length == 0)
				return false;

			char first = Char.ToLower(str[0]);
			return IsVowel(first);
		}

		public static string Capitalise(string str, bool title_case)
		{
			if (title_case)
			{
				string[] tokens = str.Split(null);

				str = "";
				foreach (string token in tokens)
				{
					if (str != "")
						str += " ";

					str += Capitalise(token, false);
				}

				return str;
			}

			char first = str[0];

			return Char.ToUpper(first) + str.Substring(1);
		}
	}
}
