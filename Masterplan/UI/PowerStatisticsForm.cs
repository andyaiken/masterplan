using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class PowerStatisticsForm : Form
	{
		public PowerStatisticsForm(List<CreaturePower> powers, int creatures)
		{
			InitializeComponent();

			fPowers = powers;
			fCreatures = creatures;

			update_table();
		}

		List<CreaturePower> fPowers = null;
		int fCreatures = 0;

		void update_table()
		{
			List<string> lines = new List<string>();

			lines.AddRange(HTML.GetHead("Power Statistics", "", DisplaySize.Small));
			lines.Add("<BODY>");

			#region Number of powers

			lines.Add("<P class=table>");
			lines.Add("<TABLE>");

			lines.Add("<TR class=heading>");
			lines.Add("<TD colspan=3>");
			lines.Add("<B>Number of Powers</B>");
			lines.Add("</TD>");
			lines.Add("</TR>");

			lines.Add("<TR>");
			lines.Add("<TD colspan=2>");
			lines.Add("Number of powers");
			lines.Add("</TD>");
			lines.Add("<TD align=right>");
			lines.Add(fPowers.Count.ToString());
			lines.Add("</TD>");
			lines.Add("</TR>");

			if (fCreatures != 0)
			{
				// Powers per creature
				double ppc = (double)fPowers.Count / fCreatures;
				lines.Add("<TR>");
				lines.Add("<TD colspan=2>");
				lines.Add("Powers per creature");
				lines.Add("</TD>");
				lines.Add("<TD align=right>");
				lines.Add(ppc.ToString("F1"));
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			lines.Add("</TABLE>");
			lines.Add("</P>");

			#endregion

			#region Conditions

			if (fPowers.Count != 0)
			{
				lines.Add("<P class=table>");
				lines.Add("<TABLE>");

				// Number of powers with each condition
				Dictionary<string, int> condition_breakdown = get_condition_breakdown();
				if (condition_breakdown.Count != 0)
				{
					lines.Add("<TR class=heading>");
					lines.Add("<TD colspan=3>");
					lines.Add("<B>Conditions</B>");
					lines.Add("</TD>");
					lines.Add("</TR>");

					List<Pair<string, int>> list = sort_breakdown(condition_breakdown);
					foreach (Pair<string, int> condition in list)
					{
						int count = condition.Second;
						if (count == 0)
							continue;

						double pc = (double)count / fPowers.Count;

						lines.Add("<TR>");
						lines.Add("<TD colspan=2>");
						lines.Add(condition.First);
						lines.Add("</TD>");
						lines.Add("<TD align=right>");
						lines.Add(count + " (" + pc.ToString("P0") + ")");
						lines.Add("</TD>");
						lines.Add("</TR>");
					}
				}

				lines.Add("</TABLE>");
				lines.Add("</P>");
			}

			#endregion

			#region Damage types

			if (fPowers.Count != 0)
			{
				lines.Add("<P class=table>");
				lines.Add("<TABLE>");

				// Number of powers with each damage type
				Dictionary<string, int> type_breakdown = get_damage_type_breakdown();
				if (type_breakdown.Count != 0)
				{
					lines.Add("<TR class=heading>");
					lines.Add("<TD colspan=3>");
					lines.Add("<B>Damage Types</B>");
					lines.Add("</TD>");
					lines.Add("</TR>");

					List<Pair<string, int>> list = sort_breakdown(type_breakdown);
					foreach (Pair<string, int> type in list)
					{
						int count = type.Second;
						double pc = (double)count / fPowers.Count;

						lines.Add("<TR>");
						lines.Add("<TD colspan=2>");
						lines.Add(type.First);
						lines.Add("</TD>");
						lines.Add("<TD align=right>");
						lines.Add(count + " (" + pc.ToString("P0") + ")");
						lines.Add("</TD>");
						lines.Add("</TR>");
					}
				}

				lines.Add("</TABLE>");
				lines.Add("</P>");
			}

			#endregion

			#region Keywords

			if (fPowers.Count != 0)
			{
				lines.Add("<P class=table>");
				lines.Add("<TABLE>");

				// Number of powers with each keyword
				Dictionary<string, int> keyword_breakdown = get_keyword_breakdown();
				if (keyword_breakdown.Count != 0)
				{
					lines.Add("<TR class=heading>");
					lines.Add("<TD colspan=3>");
					lines.Add("<B>Keywords</B>");
					lines.Add("</TD>");
					lines.Add("</TR>");

					List<Pair<string, int>> list = sort_breakdown(keyword_breakdown);
					foreach (Pair<string, int> type in list)
					{
						int count = type.Second;
						double pc = (double)count / fPowers.Count;

						lines.Add("<TR>");
						lines.Add("<TD colspan=2>");
						lines.Add(type.First);
						lines.Add("</TD>");
						lines.Add("<TD align=right>");
						lines.Add(count + " (" + pc.ToString("P0") + ")");
						lines.Add("</TD>");
						lines.Add("</TR>");
					}
				}

				lines.Add("</TABLE>");
				lines.Add("</P>");
			}

			#endregion

			#region Categories

			if (fPowers.Count != 0)
			{
				// Number of powers per category
				Dictionary<string, double> category_breakdown = get_category_breakdown();
				if (category_breakdown.Count != 0)
				{
					lines.Add("<P class=table>");
					lines.Add("<TABLE>");

					lines.Add("<TR class=heading>");
					lines.Add("<TD colspan=3>");
					lines.Add("<B>Powers Per Category</B>");
					lines.Add("</TD>");
					lines.Add("</TR>");

					foreach (string category in category_breakdown.Keys)
					{
						double pc = category_breakdown[category];

						lines.Add("<TR>");
						lines.Add("<TD colspan=2>");
						lines.Add(category);
						lines.Add("</TD>");
						lines.Add("<TD align=right>");
						lines.Add(pc.ToString("P0"));
						lines.Add("</TD>");
						lines.Add("</TR>");
					}

					lines.Add("</TABLE>");
					lines.Add("</P>");
				}
			}

			#endregion

			#region Damage expressions

			if (fPowers.Count != 0)
			{
				lines.Add("<P class=table>");
				lines.Add("<TABLE>");

				// Frequency of damage expressions
				Dictionary<string, int> damage_breakdown = get_damage_expression_breakdown();
				if (damage_breakdown.Count != 0)
				{
					lines.Add("<TR class=heading>");
					lines.Add("<TD colspan=3>");
					lines.Add("<B>Damage</B>");
					lines.Add("</TD>");
					lines.Add("</TR>");

					List<Pair<string, int>> list = sort_breakdown(damage_breakdown);
					foreach (Pair<string, int> dmg in list)
					{
						int count = dmg.Second;
						double pc = (double)count / fPowers.Count;

						DiceExpression exp = DiceExpression.Parse(dmg.First);

						lines.Add("<TR>");
						lines.Add("<TD colspan=2>");
						lines.Add(dmg.First + " (avg " + exp.Average + ", max " + exp.Maximum + ")");
						lines.Add("</TD>");
						lines.Add("<TD align=right>");
						lines.Add(count + " (" + pc.ToString("P0") + ")");
						lines.Add("</TD>");
						lines.Add("</TR>");
					}
				}

				lines.Add("</TABLE>");
				lines.Add("</P>");
			}

			#endregion

			lines.Add("</BODY>");
			lines.Add("</HTML>");

			Browser.DocumentText = HTML.Concatenate(lines);
		}

		int count_powers(string text)
		{
			// Account for Americans
			if (text == "Immobilised")
				text = "Immobilized";

			int count = 0;

			foreach (CreaturePower power in fPowers)
			{
				if (power.Details.ToLower().Contains(text.ToLower()))
					count += 1;
			}

			return count;
		}

		List<Pair<string, int>> sort_breakdown(Dictionary<string, int> breakdown)
		{
			List<Pair<string, int>> list = new List<Pair<string, int>>();

			foreach (string key in breakdown.Keys)
				list.Add(new Pair<string, int>(key, breakdown[key]));

			list.Sort((x, y) => x.Second.CompareTo(y.Second) * -1);

			return list;
		}

		Dictionary<string, int> get_condition_breakdown()
		{
			Dictionary<string, int> breakdown = new Dictionary<string, int>();

			List<string> conditions = Conditions.GetConditions();
			foreach (string condition in conditions)
			{
				int count = count_powers(condition);
				if (count == 0)
					continue;

				breakdown[condition] = count;
			}

			return breakdown;
		}

		Dictionary<string, int> get_damage_type_breakdown()
		{
			Dictionary<string, int> breakdown = new Dictionary<string, int>();

			Array damagetypes = Enum.GetValues(typeof(DamageType));
			foreach (DamageType type in damagetypes)
			{
				if (type == DamageType.Untyped)
					continue;

				string damage_type = type.ToString();

				int count = count_powers(damage_type);
				if (count == 0)
					continue;

				breakdown[damage_type] = count;
			}

			return breakdown;
		}

		Dictionary<string, double> get_category_breakdown()
		{
			Dictionary<string, double> breakdown = new Dictionary<string, double>();

			Array categories = Enum.GetValues(typeof(CreaturePowerCategory));
			foreach (CreaturePowerCategory category in categories)
			{
				int count = 0;

				foreach (CreaturePower power in fPowers)
				{
					if (power.Category == category)
						count += 1;
				}

				breakdown[category.ToString()] = (double)count / fPowers.Count;
			}

			return breakdown;
		}

		Dictionary<string, int> get_damage_expression_breakdown()
		{
			Dictionary<string, int> breakdown = new Dictionary<string, int>();

			foreach (CreaturePower power in fPowers)
			{
				DiceExpression exp = DiceExpression.Parse(power.Damage);
				if (exp == null)
					continue;
				if (exp.Maximum == 0)
					continue;

				string dmg = exp.ToString();

				if (!breakdown.ContainsKey(dmg))
					breakdown[dmg] = 0;

				breakdown[dmg] += 1;
			}

			return breakdown;
		}

		Dictionary<string, int> get_keyword_breakdown()
		{
			Dictionary<string, int> breakdown = new Dictionary<string, int>();

			foreach (CreaturePower power in fPowers)
			{
				string[] tokens = power.Keywords.Split(new string[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries);

				foreach (string token in tokens)
				{
					string str = token.Trim();

					if (!breakdown.ContainsKey(str))
						breakdown[str] = 0;

					breakdown[str] += 1;
				}
			}

			return breakdown;
		}
	}
}
