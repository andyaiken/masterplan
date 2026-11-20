#nullable disable

using System;

namespace MasterplanXP.MigrationTool.Services.Utils
{
    public class DiceExpression
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
                    if (exp == null) continue;

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
            if (adjusted == null) return this;

            adjusted.Throws += throw_diff;
            adjusted.Sides += sides_diff;
            adjusted.Constant += const_diff;

            if (fThrows == 0)
                adjusted.Throws = 0;
            else if (adjusted.Throws <= 0)
                adjusted.Throws = 1;

            if (adjusted.Sides <= 0)
                adjusted.Sides = fSides;

            return adjusted;
        }

        public DiceExpression Adjust(double multiplier)
        {
            return new DiceExpression(fThrows, fSides, (int)Math.Round(fConstant * multiplier));
        }
    }
}
