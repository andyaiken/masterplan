using System;
using System.Collections.Generic;

namespace Masterplan.Tools
{
    class DiceStatistics
    {
        public static Dictionary<int, int> Odds(List<int> dice, int constant)
        {
            Dictionary<int, int> odds = new Dictionary<int, int>();

            if (dice.Count > 0)
            {
                int combinations = 1;
                foreach (int die in dice)
                    combinations *= die;

                // Work out how quickly each die rolls over
                int[] frequencies = new int[dice.Count];
                frequencies[dice.Count - 1] = 1;
                for (int n = dice.Count - 2; n >= 0; --n)
                    frequencies[n] = frequencies[n + 1] * dice[n + 1];

                for (int n = 0; n != combinations; ++n)
                {
                    // Work out the number for each die
                    List<int> rolls = new List<int>();
                    for (int index = 0; index != dice.Count; ++index)
                    {
                        int die = dice[index];
                        int roll = ((n / frequencies[index]) % die) + 1;

                        rolls.Add(roll);
                    }

                    // Work out the sum
                    int sum = constant;
                    foreach (int roll in rolls)
                        sum += roll;

                    if (!odds.ContainsKey(sum))
                        odds[sum] = 0;

                    odds[sum] += 1;
                }
            }

            return odds;
        }

        public static string Expression(List<int> dice, int constant)
        {
            int d4 = 0;
            int d6 = 0;
            int d8 = 0;
            int d10 = 0;
            int d12 = 0;
            int d20 = 0;

            foreach (int die in dice)
            {
                switch (die)
                {
                    case 4:
                        d4 += 1;
                        break;
                    case 6:
                        d6 += 1;
                        break;
                    case 8:
                        d8 += 1;
                        break;
                    case 10:
                        d10 += 1;
                        break;
                    case 12:
                        d12 += 1;
                        break;
                    case 20:
                        d20 += 1;
                        break;
                }
            }

            string exp = "";
            if (d4 != 0)
            {
                if (exp != "")
                    exp += " + ";

                exp += d4 + "d4";
            }
            if (d6 != 0)
            {
                if (exp != "")
                    exp += " + ";

                exp += d6 + "d6";
            }
            if (d8 != 0)
            {
                if (exp != "")
                    exp += " + ";

                exp += d8 + "d8";
            }
            if (d10 != 0)
            {
                if (exp != "")
                    exp += " + ";

                exp += d10 + "d10";
            }
            if (d12 != 0)
            {
                if (exp != "")
                    exp += " + ";

                exp += d12 + "d12";
            }
            if (d20 != 0)
            {
                if (exp != "")
                    exp += " + ";

                exp += d20 + "d20";
            }

			if (constant != 0)
			{
				exp += " ";

				if (constant > 0)
					exp += "+";

				exp += constant.ToString();
			}

            return exp;
        }
    }

	class DiceExpression
	{
		public DiceExpression()
		{
			fThrows = 0;
			fSides = 0;
			fConstant = 0;
		}

		public DiceExpression(int throws, int sides)
		{
			fThrows = throws;
			fSides = sides;
			fConstant = 0;
		}

		public DiceExpression(int throws, int sides, int constant)
		{
			fThrows = throws;
			fSides = sides;
			fConstant = constant;
		}

		public int Throws
		{
			get { return fThrows; }
			set { fThrows = value; }
		}
		int fThrows = 0;

		public int Sides
		{
			get { return fSides; }
			set { fSides = value; }
		}
		int fSides = 0;

		public int Constant
		{
			get { return fConstant; }
			set { fConstant = value; }
		}
		int fConstant = 0;

		public static DiceExpression Parse(string str)
		{
			DiceExpression exp = new DiceExpression();

			try
			{
				bool started = false;
				bool minus = false;
				char[] digits = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

				str = str.ToLower();
				str = str.Replace("+", " + ");
				str = str.Replace("-", " - ");

				string[] tokens = str.Split(null);
				foreach (string token in tokens)
				{
					if ((token == "damage") || (token == "dmg"))
						break;

					if ((token == "-") && (started))
					{
						minus = true;
						continue;
					}

					if (token.IndexOfAny(digits) == -1)
						continue;

					// Has a 'd'
					int d_index = token.IndexOf("d");
					if (d_index != -1)
					{
						string throws = token.Substring(0, d_index);
						string sides = token.Substring(d_index + 1);

						if (throws != "")
							exp.Throws = int.Parse(throws);

						exp.Sides = int.Parse(sides);
					}
					else
					{
						if (exp.Constant == 0)
						{
							exp.Constant = int.Parse(token);

							if (minus)
								exp.Constant = -exp.Constant;
						}
					}

					started = true;
				}
			}
			catch
			{
				// Parse error?
				exp = null;
			}

			if ((exp != null) && (exp.Throws == 0) && (exp.Constant == 0))
				exp = null;

			return exp;
		}

		public int Evaluate()
		{
			return Session.Dice(fThrows, fSides) + fConstant;
		}

		public int Maximum
		{
			get
			{
				return (fThrows * fSides) + fConstant;
			}
		}

		public double Average
		{
			get
			{
				double mean = (double)(fSides + 1) / 2;
				return (fThrows * mean) + fConstant;
			}
		}

		public override string ToString()
		{
			string str = "";

			if (fThrows != 0)
				str = fThrows + "d" + fSides;

			if (fConstant != 0)
			{
				if (str != "")
				{
					str += " ";

					if (fConstant > 0)
						str += "+";
				}

				str += fConstant.ToString();
			}

			if (str == "")
				str = "0";

			return str;
		}

		public DiceExpression Adjust(int level_adjustment)
		{
			Array dmgs = Enum.GetValues(typeof(DamageExpressionType));

			// Choose the closest level and work out the differences (in throws / sides / constant)
			int min_difference = int.MaxValue;
			int best_level = 0;
			DamageExpressionType best_det = DamageExpressionType.Normal;
			DiceExpression best_exp = null;
			for (int level = 1; level <= 30; ++level)
			{
				foreach (DamageExpressionType det in dmgs)
				{
					DiceExpression exp = DiceExpression.Parse(Statistics.Damage(level, det));

					int diff_throws = Math.Abs(fThrows - exp.Throws);
					int diff_sides = Math.Abs(fSides - exp.Sides) / 2;
					int diff_const = Math.Abs(fConstant - exp.Constant);

					int difference = (diff_throws * 10) + (diff_sides * 100) + diff_const;
					if (difference < min_difference)
					{
						min_difference = difference;
						best_level = level;
						best_det = det;
						best_exp = exp;
					}
				}
			}

			if (best_exp == null)
				return this;

			int throw_diff = fThrows - best_exp.Throws;
			int sides_diff = fSides - best_exp.Sides;
			int const_diff = fConstant - best_exp.Constant;

			// Adjust the new expression
			int adj_level = Math.Max(best_level + level_adjustment, 1);
			DiceExpression adjusted = DiceExpression.Parse(Statistics.Damage(adj_level, best_det));
			adjusted.Throws += throw_diff;
			adjusted.Sides += sides_diff;
			adjusted.Constant += const_diff;

			if (fThrows == 0)
				adjusted.Throws = 0;
			else
				adjusted.Throws = Math.Max(adjusted.Throws, 1);

			// Make sure we have a valid dice type
			switch (adjusted.Sides)
			{
				case 0:
				case 1:
				case 2:
				case 3:
				case 4:
					adjusted.Sides = 4;
					break;
				case 5:
				case 6:
					adjusted.Sides = 6;
					break;
				case 7:
				case 8:
					adjusted.Sides = 8;
					break;
				case 9:
				case 10:
					adjusted.Sides = 10;
					break;
				case 11:
				case 12:
				case 13:
				case 14:
				case 15:
				case 16:
					adjusted.Sides = 12;
					break;
				default:
					adjusted.Sides = 20;
					break;
			}

			return adjusted;
		}
		public DiceExpression Adjust(double percentage_adjustment)
		{
			double diceExpected = Throws * (Sides + 1) / 2.0f;
			double expected = diceExpected + Constant;
			double adjusted = expected * percentage_adjustment;
			double adjustedConstant = adjusted - diceExpected;

			return new DiceExpression(Throws, Sides, (int)adjustedConstant);
		}
	}
}
