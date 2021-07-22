using System;
using System.Collections.Generic;
using System.Text;

namespace Masterplan.Tools
{
	/// <summary>
	/// Class containing string manipulation methods.
	/// </summary>
	public class StringHelper
	{
		/// <summary>
		/// Finds the longest common substring from each token of each string.
		/// </summary>
		/// <param name="str1">The first string.</param>
		/// <param name="str2">The second string.</param>
		/// <returns>Returns the longest common token subtring.</returns>
		public static string LongestCommonToken(string str1, string str2)
		{
			string[] tokens1 = str1.Split(null);
			string[] tokens2 = str2.Split(null);

			List<string> list = new List<string>();
			foreach (string token1 in tokens1)
			{
				foreach (string token2 in tokens2)
				{
					string str = LongestCommonSubstring(token1, token2);
					if (str != "")
						list.Add(str);
				}
			}

			string longest = "";
			foreach (string str in list)
			{
				if (str.Length > longest.Length)
					longest = str;
			}

			return longest;
		}

		/// <summary>
		/// Finds the longest common substring.
		/// </summary>
		/// <param name="str1">The first string.</param>
		/// <param name="str2">The second string.</param>
		/// <returns>Returns the longest common substring.</returns>
		public static string LongestCommonSubstring(string str1, string str2)
		{
			if (String.IsNullOrEmpty(str1) || String.IsNullOrEmpty(str2))
				return "";

			int[,] num = new int[str1.Length, str2.Length];

			int max_length = 0;
			int last_start_pos = 0;

			StringBuilder builder = new StringBuilder();

			for (int i = 0; i < str1.Length; i++)
			{
				for (int j = 0; j < str2.Length; j++)
				{
					if (str1[i] != str2[j])
						num[i, j] = 0;
					else
					{
						if ((i == 0) || (j == 0))
							num[i, j] = 1;
						else
							num[i, j] = 1 + num[i - 1, j - 1];

						if (num[i, j] > max_length)
						{
							max_length = num[i, j];
							int this_start_pos = i - num[i, j] + 1;
							if (last_start_pos == this_start_pos)
							{
								builder.Append(str1[i]);
							}
							else
							{
								last_start_pos = this_start_pos;
								builder.Remove(0, builder.Length);
								builder.Append(str1.Substring(last_start_pos, (i + 1) - last_start_pos));
							}
						}
					}
				}
			}

			return builder.ToString();
		}
	}
}
