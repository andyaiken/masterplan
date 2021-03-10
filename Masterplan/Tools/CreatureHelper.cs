using System;

using Utils;

using Masterplan.Data;
using System.Collections.Generic;

namespace Masterplan.Tools
{
	class CreatureHelper
	{
		public static void CopyFields(ICreature copy_from, ICreature copy_to)
		{
			try
			{
				if (copy_from != null)
				{
					copy_to.ID = copy_from.ID;
					copy_to.Name = copy_from.Name;
					copy_to.Details = copy_from.Details;
					copy_to.Size = copy_from.Size;
					copy_to.Origin = copy_from.Origin;
					copy_to.Type = copy_from.Type;
					copy_to.Keywords = copy_from.Keywords;
					copy_to.Level = copy_from.Level;
					copy_to.Role = (copy_from.Role != null) ? copy_from.Role.Copy() : null;
					copy_to.Senses = copy_from.Senses;
					copy_to.Movement = copy_from.Movement;
					copy_to.Alignment = copy_from.Alignment;
					copy_to.Languages = copy_from.Languages;
					copy_to.Skills = copy_from.Skills;
					copy_to.Equipment = copy_from.Equipment;
					copy_to.Category = copy_from.Category;

					copy_to.Strength = copy_from.Strength.Copy();
					copy_to.Constitution = copy_from.Constitution.Copy();
					copy_to.Dexterity = copy_from.Dexterity.Copy();
					copy_to.Intelligence = copy_from.Intelligence.Copy();
					copy_to.Wisdom = copy_from.Wisdom.Copy();
					copy_to.Charisma = copy_from.Charisma.Copy();

					copy_to.HP = copy_from.HP;
					copy_to.Initiative = copy_from.Initiative;
					copy_to.AC = copy_from.AC;
					copy_to.Fortitude = copy_from.Fortitude;
					copy_to.Reflex = copy_from.Reflex;
					copy_to.Will = copy_from.Will;

					copy_to.Regeneration = (copy_from.Regeneration != null) ? copy_from.Regeneration.Copy() : null;

					copy_to.Auras.Clear();
					foreach (Aura aura in copy_from.Auras)
						copy_to.Auras.Add(aura.Copy());

					copy_to.CreaturePowers.Clear();
					foreach (CreaturePower cp in copy_from.CreaturePowers)
						copy_to.CreaturePowers.Add(cp.Copy());

					copy_to.DamageModifiers.Clear();
					foreach (DamageModifier dm in copy_from.DamageModifiers)
						copy_to.DamageModifiers.Add(dm.Copy());

					copy_to.Resist = copy_from.Resist;
					copy_to.Vulnerable = copy_from.Vulnerable;
					copy_to.Immune = copy_from.Immune;
					copy_to.Tactics = copy_from.Tactics;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		public static void UpdateRegen(ICreature c)
		{
			Aura regen_aura = FindAura(c, "Regeneration");
			if (regen_aura == null)
				regen_aura = FindAura(c, "Regen");

			if (regen_aura != null)
			{
				Regeneration regen = ConvertAura(regen_aura.Details);
				if (regen != null)
				{
					c.Regeneration = regen;
					c.Auras.Remove(regen_aura);
				}
			}
		}

		public static void UpdatePowerRange(ICreature c, CreaturePower power)
		{
			if ((power.Range != null) && (power.Range != ""))
				return;

			List<string> ranges = new List<string>();
			ranges.Add("close blast");
			ranges.Add("close burst");
			ranges.Add("area burst");
			ranges.Add("melee");
			ranges.Add("ranged");

			string details = "";

			string[] clauses = power.Details.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string clause in clauses)
			{
				bool is_range_clause = false;
				foreach (string range in ranges)
				{
					if (clause.ToLower().Contains(range))
					{
						is_range_clause = true;
						break;
					}
				}

				if (is_range_clause)
				{
					power.Range = clause;
				}
				else
				{
					if (details != "")
						details += "; ";

					details += clause;
				}
			}

			power.Details = details;
		}

		public static Aura FindAura(ICreature c, string name)
		{
			foreach (Aura a in c.Auras)
			{
				if (a.Name == name)
					return a;
			}

			return null;
		}

		public static Regeneration ConvertAura(string aura_details)
		{
			aura_details = aura_details.Trim();

			bool parsing_value = true;
			string val_str = "";
			string details = "";

			foreach (char ch in aura_details)
			{
				if (!char.IsDigit(ch))
					parsing_value = false;

				if (parsing_value)
					val_str += ch;
				else
					details += ch;
			}

			details = details.Trim();
			if (details.StartsWith("(") && details.EndsWith(")"))
			{
				details = details.Substring(1);
				details = details.Substring(0, details.Length - 1);

				details.Trim();
			}

			try
			{
				int value = (val_str != "") ? int.Parse(val_str) : 0;

				return new Regeneration(value, details);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);

				return null;
			}
		}

		public static List<CreaturePower> CreaturePowersByCategory(ICreature c, CreaturePowerCategory category)
		{
			List<CreaturePower> powers = new List<CreaturePower>();

			foreach (CreaturePower cp in c.CreaturePowers)
			{
				if (cp.Category == category)
					powers.Add(cp);
			}

			return powers;
		}

		public static void AdjustCreatureLevel(ICreature creature, int delta)
		{
			// HP
			if (creature.Role is ComplexRole)
			{
				ComplexRole role = creature.Role as ComplexRole;

				int hp = 8;
				switch (role.Type)
				{
					case RoleType.Artillery:
					case RoleType.Lurker:
						hp = 6;
						break;
					case RoleType.Brute:
						hp = 10;
						break;
				}

				switch (role.Flag)
				{
					case RoleFlag.Elite:
						hp *= 2;
						break;
					case RoleFlag.Solo:
						hp *= 5;
						break;
				}

				creature.HP += hp * delta;
				creature.HP = Math.Max(creature.HP, 1);
			}

			// Init
			int init_bonus = creature.Initiative - (creature.Level / 2);
			creature.Initiative = init_bonus + ((creature.Level + delta) / 2);

			// Defences
			creature.AC += delta;
			creature.Fortitude += delta;
			creature.Reflex += delta;
			creature.Will += delta;

			// Powers
			foreach (CreaturePower cp in creature.CreaturePowers)
				AdjustPowerLevel(cp, delta);

			// Skills
			if (creature.Skills != "")
			{
				// Parse string
				Dictionary<string, int> skill_list = CreatureHelper.ParseSkills(creature.Skills);

				// Sort
				BinarySearchTree<string> bst = new BinarySearchTree<string>();
				foreach (string skill_name in skill_list.Keys)
					bst.Add(skill_name);

				string skill_str = "";
				foreach (string skill_name in bst.SortedList)
				{
					if (skill_str != "")
						skill_str += ", ";

					int mod = skill_list[skill_name];

					// Apply level adjustment
					int bonus = mod - (creature.Level / 2);
					mod = bonus + ((creature.Level + delta) / 2);

					if (mod >= 0)
						skill_str += skill_name + " +" + mod;
					else
						skill_str += skill_name + " " + mod;
				}

				creature.Skills = skill_str;
			}

			// Level
			creature.Level += delta;
		}

		public static void AdjustPowerLevel(CreaturePower cp, int delta)
		{
			if (cp.Attack != null)
				cp.Attack.Bonus += delta;

			// Adjust power damage
			string dmg_str = AI.ExtractDamage(cp.Details);
			if (dmg_str != "")
			{
				DiceExpression exp = DiceExpression.Parse(dmg_str);
				if (exp != null)
				{
					DiceExpression exp_adj = exp.Adjust(delta);
					if ((exp_adj != null) && (exp.ToString() != exp_adj.ToString()))
					{
						cp.Details = cp.Details.Replace(dmg_str, exp_adj + " damage");
					}
				}
			}
		}

		public static Dictionary<string, int> ParseSkills(string source)
		{
			Dictionary<string, int> skill_list = new Dictionary<string, int>();

			if ((source != null) && (source != ""))
			{
				string[] skills = source.Split(new string[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
				foreach (string skill in skills)
				{
					string str = skill.Trim();

					int index = str.IndexOf(" ");
					if (index != -1)
					{
						string skill_name = str.Substring(0, index);
						string skill_bonus = str.Substring(index + 1);

						int bonus = 0;
						try
						{
							bonus = int.Parse(skill_bonus);
						}
						catch
						{
							bonus = 0;
						}

						skill_list[skill_name] = bonus;
					}
				}
			}

			return skill_list;
		}
	}
}
