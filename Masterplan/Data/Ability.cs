using System;

namespace Masterplan.Data
{
	/// <summary>
	/// Class representing an ability score.
	/// </summary>
	[Serializable]
	public class Ability
	{
		/// <summary>
		/// Gets or sets the score.
		/// </summary>
		public int Score
		{
			get { return fScore; }
			set { fScore = value; }
		}
		int fScore = 10;

		/// <summary>
		/// Gets the score modifier.
		/// </summary>
		public int Modifier
		{
			get
			{
				return GetModifier(fScore);
			}
		}

		/// <summary>
		/// Gets the point-buy cost of this score.
		/// </summary>
		public int Cost
		{
			get
			{
				return GetCost(fScore);
			}
		}

		/// <summary>
		/// Gets the score modifier for the given score.
		/// </summary>
		/// <param name="score">The ability score.</param>
		/// <returns>Returns the modifier.</returns>
		public static int GetModifier(int score)
		{
			return (score / 2) - 5;
		}

		/// <summary>
		/// Gets the point-buy cost for the given score.
		/// </summary>
		/// <param name="score">The ability score.</param>
		/// <returns>Returns the cost.</returns>
		public static int GetCost(int score)
		{
			if (score < 10)
				return 0;

			switch (score)
			{
				case 10: return 0;
				case 11: return 1;
				case 12: return 2;
				case 13: return 3;
				case 14: return 5;
				case 15: return 7;
				case 16: return 9;
				case 17: return 12;
				case 18: return 16;
			}

			return -1;
		}

		/// <summary>
		/// Creates a copy of the ability.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public Ability Copy()
		{
			Ability ab = new Ability();

			ab.Score = fScore;

			return ab;
		}

		/// <summary>
		/// NN (+N)
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			string str = fScore.ToString();

			string mod = Modifier.ToString();
			if (Modifier >= 0)
				mod = "+" + mod;

			return str + " (" + mod + ")";
		}
	}
}
