using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Xml;

using Utils;

using Masterplan.Data;

namespace Masterplan.Tools
{
	class AppImport
	{
		#region Adventure Tools

		public static Creature ImportCreature(string xml)
		{
			Creature c = null;

			try
			{
				XmlDocument doc = XMLHelper.LoadSource(xml);
				if (doc == null)
					return null;

				XmlNode doc_element = doc.DocumentElement;

				c = new Creature();

				bool role_has_been_set = false;

				foreach (XmlNode node in doc_element.ChildNodes)
				{
					if (node.Name == "ID")
					{
					}
					else if (node.Name == "AbilityScores")
					{
						try
						{
							XmlNode values_node = node.FirstChild;
							foreach (XmlNode value_node in values_node.ChildNodes)
							{
								string name = XMLHelper.NodeText(value_node, "Name");
								int value = XMLHelper.GetIntAttribute(value_node, "FinalValue");
								value = Math.Max(value, 0);

								if (name == "Strength")
									c.Strength.Score = value;

								if (name == "Constitution")
									c.Constitution.Score = value;

								if (name == "Dexterity")
									c.Dexterity.Score = value;

								if (name == "Intelligence")
									c.Intelligence.Score = value;

								if (name == "Wisdom")
									c.Wisdom.Score = value;

								if (name == "Charisma")
									c.Charisma.Score = value;
							}
						}
						catch
						{
							LogSystem.Trace("Error parsing " + node.Name);
						}
					}
					else if (node.Name == "Defenses")
					{
						try
						{
							XmlNode values_node = node.FirstChild;
							foreach (XmlNode value_node in values_node.ChildNodes)
							{
								string name = XMLHelper.NodeText(value_node, "Name");
								int value = XMLHelper.GetIntAttribute(value_node, "FinalValue");

								if (name == "AC")
									c.AC = value;

								if (name == "Fortitude")
									c.Fortitude = value;

								if (name == "Reflex")
									c.Reflex = value;

								if (name == "Will")
									c.Will = value;
							}
						}
						catch
						{
							LogSystem.Trace("Error parsing " + node.Name);

						}
					}
					else if (node.Name == "AttackBonuses")
					{
					}
					else if (node.Name == "Skills")
					{
						try
						{
							string skills = "";

							XmlNode values_node = node.FirstChild;
							foreach (XmlNode value_node in values_node.ChildNodes)
							{
								string name = XMLHelper.NodeText(value_node, "Name");
								int value = XMLHelper.GetIntAttribute(value_node, "FinalValue");

								bool trained = false;
								string trained_str = XMLHelper.NodeText(value_node, "Trained");
								if (trained_str != "")
									trained = bool.Parse(trained_str);

								if (!trained)
									continue;

								if (skills != "")
									skills += ", ";

								string sign = (value >= 0) ? "+" : "";
								skills += name + " " + sign + value;
							}

							c.Skills = skills;
						}
						catch
						{
							LogSystem.Trace("Error parsing " + node.Name);

						}
					}
					else if (node.Name == "Name")
					{
						try
						{
							c.Name = node.InnerText;
						}
						catch
						{
							LogSystem.Trace("Error parsing " + node.Name);

						}
					}
					else if (node.Name == "Level")
					{
						try
						{
							c.Level = int.Parse(node.InnerText);
						}
						catch
						{
							LogSystem.Trace("Error parsing " + node.Name);

						}
					}
					else if (node.Name == "Size")
					{
						try
						{
							XmlNode data_node = XMLHelper.FindChild(node, "ReferencedObject");
							if (data_node != null)
							{
								XmlNode name_node = XMLHelper.FindChild(data_node, "Name");
								if (name_node != null)
								{
									string str = name_node.InnerText;
									c.Size = (CreatureSize)Enum.Parse(typeof(CreatureSize), str);
								}
							}
						}
						catch
						{
							LogSystem.Trace("Error parsing " + node.Name);
						}
					}
					else if (node.Name == "Origin")
					{
						try
						{
							XmlNode data_node = XMLHelper.FindChild(node, "ReferencedObject");
							if (data_node != null)
							{
								XmlNode name_node = XMLHelper.FindChild(data_node, "Name");
								if (name_node != null)
								{
									string str = name_node.InnerText;
									c.Origin = (CreatureOrigin)Enum.Parse(typeof(CreatureOrigin), str);
								}
							}
						}
						catch
						{
							LogSystem.Trace("Error parsing " + node.Name);

						}
					}
					else if (node.Name == "Type")
					{
						try
						{
							XmlNode data_node = XMLHelper.FindChild(node, "ReferencedObject");
							if (data_node != null)
							{
								XmlNode name_node = XMLHelper.FindChild(data_node, "Name");
								if (name_node != null)
								{
									string str = name_node.InnerText.Replace(" ", "");
									c.Type = (CreatureType)Enum.Parse(typeof(CreatureType), str);
								}
							}
						}
						catch
						{
							LogSystem.Trace("Error parsing " + node.Name);

						}
					}
					else if (node.Name == "GroupRole")
					{
						try
						{
							XmlNode data_node = XMLHelper.FindChild(node, "ReferencedObject");
							if (data_node != null)
							{
								XmlNode name_node = XMLHelper.FindChild(data_node, "Name");
								if (name_node != null)
								{
									string str = name_node.InnerText;

									if (str == "Minion")
									{
										Minion m = new Minion();
										if (role_has_been_set)
										{
											ComplexRole cr = c.Role as ComplexRole;

											m.HasRole = true;
											m.Type = cr.Type;
										}

										c.Role = m;
									}
									else
									{
										RoleFlag flag = (RoleFlag)Enum.Parse(typeof(RoleFlag), str);

										ComplexRole cr = c.Role as ComplexRole;
										cr.Flag = flag;
									}
								}
							}
						}
						catch
						{
							LogSystem.Trace("Error parsing " + node.Name);
						}
					}
					else if (node.Name == "Role")
					{
						try
						{
							XmlNode role_node = XMLHelper.FindChild(node, "ReferencedObject");
							if (role_node != null)
							{
								XmlNode name_node = XMLHelper.FindChild(role_node, "Name");
								if (name_node != null)
								{
									string str = name_node.InnerText;
									RoleType type = (RoleType)Enum.Parse(typeof(RoleType), str);

									if (c.Role is ComplexRole)
									{
										ComplexRole cr = c.Role as ComplexRole;
										cr.Type = type;
									}

									if (c.Role is Minion)
									{
										Minion m = c.Role as Minion;
										m.HasRole = true;
										m.Type = type;
									}

									role_has_been_set = true;
								}
							}
						}
						catch
						{
							LogSystem.Trace("Error parsing " + node.Name);

						}
					}
					else if (node.Name == "IsLeader")
					{
						try
						{
							string str = node.InnerText;
							bool leader = bool.Parse(str);

							if ((c.Role is ComplexRole) && (leader == true))
							{
								ComplexRole cr = c.Role as ComplexRole;
								cr.Leader = true;
							}
						}
						catch
						{
							LogSystem.Trace("Error parsing " + node.Name);

						}
					}
					else if (node.Name == "Items")
					{
						try
						{
							foreach (XmlNode child in node.ChildNodes)
							{
								XmlNode item_node = XMLHelper.FindChild(child, "Item");
								XmlNode name_node = XMLHelper.FindChild(XMLHelper.FindChild(item_node, "ReferencedObject"), "Name");
								string name = name_node.InnerText;
								int quantity = int.Parse(XMLHelper.NodeText(child, "Quantity"));

								if (c.Equipment != "")
									c.Equipment += ", ";
								c.Equipment += name;
								if (quantity != 1)
									c.Equipment += " x" + quantity;
							}
						}
						catch
						{
							LogSystem.Trace("Error parsing " + node.Name);

						}
					}
					else if (node.Name == "Languages")
					{
						try
						{
							string langs = "";

							foreach (XmlNode child in node.ChildNodes)
							{
								XmlNode data_node = XMLHelper.FindChild(child, "ReferencedObject");
								if (data_node != null)
								{
									XmlNode name_node = XMLHelper.FindChild(data_node, "Name");
									if (name_node != null)
									{
										string str = name_node.InnerText;

										if (langs != "")
											langs += ", ";

										langs += str;
									}
								}
							}

							c.Languages = langs;
						}
						catch
						{
							LogSystem.Trace("Error parsing " + node.Name);

						}
					}
					else if (node.Name == "Senses")
					{
						try
						{
							string senses = "";

							foreach (XmlNode child in node.ChildNodes)
							{
								XmlNode ro_node = XMLHelper.FindChild(child, "ReferencedObject");
								if (ro_node != null)
								{
									string sense = XMLHelper.NodeText(ro_node, "Name");

									string range = XMLHelper.NodeText(child, "Range");
									if ((range != "") && (range != "0"))
										sense += " " + range;

									if (senses != "")
										senses += ", ";

									senses += sense;
								}
							}

							if (senses != "")
							{
								if (c.Senses != "")
									c.Senses += "; ";

								c.Senses += senses;
							}
						}
						catch
						{
							LogSystem.Trace("Error parsing " + node.Name);

						}
					}
					else if (node.Name == "Regeneration")
					{
						try
						{
							Regeneration regen = new Regeneration();

							regen.Value = XMLHelper.GetIntAttribute(node, "FinalValue");

							string details = XMLHelper.NodeText(node, "Details");
							if (details != "")
								regen.Details = details;

							if ((regen.Value != 0) || (regen.Details != ""))
								c.Regeneration = regen;
						}
						catch
						{
							LogSystem.Trace("Error parsing " + node.Name);
						}
					}
					else if (node.Name == "Keywords")
					{
						try
						{
							string keywords = "";

							foreach (XmlNode child in node.ChildNodes)
							{
								XmlNode data_node = XMLHelper.FindChild(child, "ReferencedObject");
								if (data_node != null)
								{
									XmlNode name_node = XMLHelper.FindChild(data_node, "Name");
									if (name_node != null)
									{
										string str = name_node.InnerText;

										if (keywords != "")
											keywords += ", ";

										keywords += str;
									}
								}

								c.Keywords = keywords;
							}
						}
						catch
						{
							LogSystem.Trace("Error parsing " + node.Name);
						}
					}
					else if (node.Name == "Alignment")
					{
						try
						{
							XmlNode data_node = XMLHelper.FindChild(node, "ReferencedObject");
							if (data_node != null)
							{
								XmlNode name_node = XMLHelper.FindChild(data_node, "Name");
								if (name_node != null)
								{
									string str = name_node.InnerText;
									c.Alignment = str;
								}
							}

						}
						catch
						{
							LogSystem.Trace("Error parsing " + node.Name);
						}
					}
					else if (node.Name == "Powers")
					{
						try
						{
							foreach (XmlNode child in node.ChildNodes)
								import_power(child, c);
						}
						catch
						{
							LogSystem.Trace("Error parsing " + node.Name);
						}
					}
					else if (node.Name == "Initiative")
					{
						try
						{
							c.Initiative = XMLHelper.GetIntAttribute(node, "FinalValue");
						}
						catch
						{
							LogSystem.Trace("Error parsing " + node.Name);
						}
					}
					else if (node.Name == "HitPoints")
					{
						try
						{
							c.HP = XMLHelper.GetIntAttribute(node, "FinalValue");
						}
						catch
						{
							LogSystem.Trace("Error parsing " + node.Name);
						}
					}
					else if (node.Name == "ActionPoints")
					{
					}
					else if (node.Name == "Experience")
					{
					}
					else if (node.Name == "Auras")
					{
						/*
						try
						{
							foreach (XmlNode aura_node in node.ChildNodes)
							{
								string name = XMLHelper.NodeText(aura_node, "Name");
								string details = XMLHelper.NodeText(aura_node, "Details");

								int radius = 0;
								XmlNode range_node = XMLHelper.FindChild(aura_node, "Range");
								if (range_node != null)
									radius = XMLHelper.GetIntAttribute(range_node, "FinalValue");

								Aura aura = new Aura();
								aura.Name = name;
								aura.Details = (radius > 0) ? radius + ": " + details : details;

								c.Auras.Add(aura);
							}
						}
						catch
						{
							LogSystem.Trace("Error parsing " + node.Name);
						}
						*/
					}
					else if (node.Name == "LandSpeed")
					{
						try
						{
							XmlNode speed_node = XMLHelper.FindChild(node, "Speed");
							int value = XMLHelper.GetIntAttribute(speed_node, "FinalValue");

							c.Movement = value.ToString();

							string details = "";
							XmlNode details_node = XMLHelper.FindChild(node, "Details");
							if (details_node != null)
								details = details_node.InnerText;
							if (details != "")
								c.Movement += " " + details;
						}
						catch
						{
							LogSystem.Trace("Error parsing " + node.Name);
						}
					}
					else if (node.Name == "Speeds")
					{
						try
						{
							foreach (XmlNode child in node.ChildNodes)
							{
								XmlNode name_node = XMLHelper.FindChild(child, "ReferencedObject");
								XmlNode speed_node = XMLHelper.FindChild(child, "Speed");
								XmlNode details_node = XMLHelper.FindChild(child, "Details");

								string name = name_node.FirstChild.NextSibling.InnerText;
								int value = XMLHelper.GetIntAttribute(speed_node, "FinalValue");
								string details = (details_node != null) ? details_node.InnerText : "";

								if (c.Movement != "")
									c.Movement += ", ";

								string info = "";
								if (name != "")
									info += name;
								if (details != "")
								{
									if (info != "")
										info += " ";
									info += details;
								}

								c.Movement += info + " " + value;
							}
						}
						catch
						{
							LogSystem.Trace("Error parsing " + node.Name);
						}
					}
					else if (node.Name == "SavingThrows")
					{
					}
					else if (node.Name == "Resistances")
					{
						try
						{
							string str = "";

							foreach (XmlNode child in node.ChildNodes)
							{
								XmlNode name_node = XMLHelper.FindChild(XMLHelper.FindChild(child, "ReferencedObject"), "Name");
								XmlNode value_node = XMLHelper.FindChild(child, "Amount");
								XmlNode details_node = XMLHelper.FindChild(child, "Details");

								string name = name_node.InnerText;
								int value = XMLHelper.GetIntAttribute(value_node, "FinalValue");
								string details = (details_node != null) ? details_node.InnerText : "";

								if (details == "")
								{
									DamageModifier mod = DamageModifier.Parse(name, -value);
									if (mod != null)
									{
										c.DamageModifiers.Add(mod);
										continue;
									}
								}

								if ((name == "") && (details == ""))
									continue;

								if (str != "")
									str += ", ";

								string info = "";
								if (name != "0")
									info += name;

								if (value > 0)
									str += info + " " + value;
								else
									str += info;

								if (details != "")
								{
									if (str != "")
										str += " ";
									str += details;
								}
							}

							c.Resist = str;
						}
						catch
						{
							LogSystem.Trace("Error parsing " + node.Name);
						}
					}
					else if (node.Name == "Weaknesses")
					{
						try
						{
							string str = "";

							foreach (XmlNode child in node.ChildNodes)
							{
								XmlNode name_node = XMLHelper.FindChild(XMLHelper.FindChild(child, "ReferencedObject"), "Name");
								XmlNode value_node = XMLHelper.FindChild(child, "Amount");
								XmlNode details_node = XMLHelper.FindChild(child, "Details");

								string name = name_node.InnerText;
								int value = XMLHelper.GetIntAttribute(value_node, "FinalValue");
								string details = (details_node != null) ? details_node.InnerText : "";

								if (details == "")
								{
									DamageModifier mod = DamageModifier.Parse(name, value);
									if (mod != null)
									{
										c.DamageModifiers.Add(mod);
										continue;
									}
								}

								if ((name == "") && (details == ""))
									continue;

								if (str != "")
									str += ", ";

								string info = "";
								if (name != "0")
									info += name;

								if (value > 0)
									str += info + " " + value;
								else
									str += info;

								if (details != "")
								{
									if (str != "")
										str += " ";
									str += details;
								}
							}

							c.Vulnerable = str;
						}
						catch
						{
							LogSystem.Trace("Error parsing " + node.Name);
						}
					}
					else if (node.Name == "Immunities")
					{
						try
						{
							string str = "";

							foreach (XmlNode child in node.ChildNodes)
							{
								XmlNode name_node = XMLHelper.FindChild(XMLHelper.FindChild(child, "ReferencedObject"), "Name");
								DamageModifier mod = DamageModifier.Parse(name_node.InnerText, 0);
								if (mod != null)
								{
									c.DamageModifiers.Add(mod);
									continue;
								}

								if (str != "")
									str += ", ";

								str += name_node.InnerText;
							}

							c.Immune = str;
						}
						catch
						{
							LogSystem.Trace("Error parsing " + node.Name);
						}
					}
					else if (node.Name == "Tactics")
					{
						try
						{
							c.Tactics = node.InnerText;
						}
						catch
						{
							LogSystem.Trace("Error parsing " + node.Name);
						}
					}
					else if (node.Name == "SourceBook")
					{
						//
					}
					else if (node.Name == "Description")
					{
						//
					}
					else if (node.Name == "Race")
					{
						//
					}
					else if (node.Name == "TemplateApplications")
					{
						//
					}
					else if (node.Name == "EliteUpgradeID")
					{
						//
					}
					else if (node.Name == "FullPortrait")
					{
						//
					}
					else if (node.Name == "CompendiumUrl")
					{
						//
					}
					else if (node.Name == "Phasing")
					{
						//
					}
					else if (node.Name == "SourceBooks")
					{
						//
					}
					else
					{
						LogSystem.Trace("Unhandled XML node: " + node.Name);
					}
				}
			}
			catch
			{
			}

			return c;
		}

		static void import_power(XmlNode power_node, Creature c)
		{
			try
			{
				CreaturePower power = new CreaturePower();

				power.Name = XMLHelper.NodeText(power_node, "Name");

				#region Condition

				string req = XMLHelper.NodeText(power_node, "Requirements");
				if (req != "")
					power.Condition = req;

				#endregion

				#region Attack data

				string type = XMLHelper.NodeText(power_node, "Type");
				if (type != "Trait")
				{
					string action = XMLHelper.NodeText(power_node, "Action");
					string is_basic = XMLHelper.NodeText(power_node, "IsBasic");
					string usage = XMLHelper.NodeText(power_node, "Usage");

					power.Action = new PowerAction();
					if (is_basic == "true")
					{
						power.Action.Use = PowerUseType.Basic;
					}
					else
					{
						if (usage.StartsWith("At-Will"))
						{
							power.Action.Use = PowerUseType.AtWill;
						}
						else
						{
							power.Action.Use = PowerUseType.Encounter;
							if (!usage.StartsWith("Encounter"))
							{
								if (usage.ToLower().StartsWith("recharge"))
								{
									string details = XMLHelper.NodeText(power_node, "UsageDetails");

									if (details == "")
										details = PowerAction.RECHARGE_6;

									if (details == "2")
										details = PowerAction.RECHARGE_2;

									if (details == "3")
										details = PowerAction.RECHARGE_3;

									if (details == "4")
										details = PowerAction.RECHARGE_4;

									if (details == "5")
										details = PowerAction.RECHARGE_5;

									if (details == "6")
										details = PowerAction.RECHARGE_6;

									power.Action.Recharge = details;
								}
							}
						}
					}

					if (action.ToLower().StartsWith("standard"))
					{
						power.Action.Action = ActionType.Standard;
						//power.Action.Trigger = action.Substring("standard".Length);
					}
					if (action.ToLower().StartsWith("move"))
					{
						power.Action.Action = ActionType.Move;
						//power.Action.Trigger = action.Substring("move".Length);
					}
					if (action.ToLower().StartsWith("minor"))
					{
						power.Action.Action = ActionType.Minor;
						//power.Action.Trigger = action.Substring("minor".Length);
					}
					if (action.ToLower().StartsWith("immediate interrupt"))
					{
						power.Action.Action = ActionType.Interrupt;
						//power.Action.Trigger = action.Substring("immediate interrupt".Length);
					}
					if (action.ToLower().StartsWith("immediate reaction"))
					{
						power.Action.Action = ActionType.Reaction;
						//power.Action.Trigger = action.Substring("immediate reaction".Length);
					}
					if (action.ToLower().StartsWith("opportunity"))
					{
						power.Action.Action = ActionType.Opportunity;
						//power.Action.Trigger = action.Substring("opportunity".Length);
					}
					if (action.ToLower().StartsWith("free"))
					{
						power.Action.Action = ActionType.Free;
						//power.Action.Trigger = action.Substring("free".Length);
					}
					if (action.ToLower().StartsWith("none"))
					{
						power.Action.Action = ActionType.None;
						//power.Action.Trigger = action.Substring("none".Length);
					}
					if (action.ToLower().StartsWith("no action"))
					{
						power.Action.Action = ActionType.None;
						//power.Action.Trigger = action.Substring("no action".Length);
					}
					if (action == "")
					{
						power.Action.Action = ActionType.None;
					}
				}
				else
				{
					#region Aura / trait

					// Might be an aura
					XmlNode range_node = XMLHelper.FindChild(power_node, "Range");
					if (range_node != null)
					{
						int range = XMLHelper.GetIntAttribute(range_node, "FinalValue");
						string details = XMLHelper.NodeText(power_node, "Details");

						if (range == 0)
						{
							power.Action = null;
							power.Details = details;
						}
						else
						{
							Aura aura = new Aura();
							aura.Name = power.Name;
							aura.Details = range + " " + details;

							c.Auras.Add(aura);

							return;
						}
					}

					#endregion
				}

				#endregion

				#region Trigger

				if (power.Action != null)
					power.Action.Trigger = XMLHelper.NodeText(power_node, "Trigger");

				if ((power.Action != null) && (power.Action.Trigger != ""))
				{
					string trigger = power.Action.Trigger.Trim();

					// Remove leading comma
					if (trigger.StartsWith(", "))
						trigger = trigger.Substring(2);

					// Remove leading semicolon
					if (trigger.StartsWith("; "))
						trigger = trigger.Substring(2);

					// Remove parentheses
					if (trigger.StartsWith("("))
						trigger = trigger.Substring(1);
					if (trigger.EndsWith(")"))
						trigger = trigger.Substring(0, trigger.Length - 1);

					power.Action.Trigger = trigger;
				}

				#endregion

				#region Keywords

				XmlNode keywords_node = XMLHelper.FindChild(power_node, "Keywords");
				if (keywords_node != null)
				{
					foreach (XmlNode keyword_node in keywords_node.ChildNodes)
					{
						XmlNode keyword_name_node = XMLHelper.FindChild(keyword_node, "ReferencedObject");
						string str = XMLHelper.NodeText(keyword_name_node, "Name");

						if (str != "")
						{
							if (power.Keywords != "")
								power.Keywords += ", ";

							power.Keywords += str;
						}
					}
				}

				#endregion

				#region Description

				XmlNode attacks_node = XMLHelper.FindChild(power_node, "Attacks");
				if (attacks_node != null)
				{
					string range = "";
					string target = "";
					string damage = "";

					string desc = "";

					foreach (XmlNode attack_node in attacks_node.ChildNodes)
					{
						XmlNode bonus_node = XMLHelper.FindChild(attack_node, "AttackBonuses");
						bool is_attack = ((bonus_node != null) && (bonus_node.ChildNodes.Count != 0));

						foreach (XmlNode field_node in attack_node.ChildNodes)
						{
							if (field_node.Name == "Name")
								continue;

							if (field_node.Name == "Range")
							{
								range = field_node.InnerText.ToLower();
								range = range.Replace("basic ", "");
							}
							else if (field_node.Name == "Targets")
							{
								target = field_node.InnerText;
							}
							else if (field_node.Name == "AttackBonuses")
							{
								if (field_node.FirstChild != null)
								{
									int bonus = XMLHelper.GetIntAttribute(field_node.FirstChild, "FinalValue");
									XmlNode defence_node = XMLHelper.FindChild(field_node.FirstChild, "Defense");
									XmlNode defence_name_node = XMLHelper.FindChild(XMLHelper.FindChild(defence_node, "ReferencedObject"), "DefenseName");
									string defence = defence_name_node.InnerText;

									power.Attack = new PowerAttack();
									power.Attack.Bonus = bonus;
									power.Attack.Defence = (DefenceType)Enum.Parse(typeof(DefenceType), defence);
								}
							}
							else if (field_node.Name == "Description")
							{
								power.Description = field_node.InnerText;
							}
							else if (field_node.Name == "Damage")
							{
								damage = Statistics.NormalDamage(c.Level);
							}
							else
							{
								string header = XMLHelper.NodeText(field_node, "Name");
								if (header == "")
									header = "Hit";

								if (!is_attack)
								{
									if ((header == "Hit") || (header == "Miss"))
										continue;
								}

								XmlNode dmg_node = XMLHelper.FindChild(field_node, "Damage");
								if (dmg_node != null)
									damage = XMLHelper.NodeText(dmg_node, "Expression");

								string details = XMLHelper.NodeText(field_node, "Description");
								if ((damage != "") && (details == ""))
									details = "damage";
								if (details == "")
									continue;

								string line = header + ": " + damage + " " + details;

								string special = XMLHelper.NodeText(field_node, "Special");
								if (special != "")
									line += Environment.NewLine + "Special: " + special;

								// Look through Attacks node
								XmlNode sub_attacks_node = XMLHelper.FindChild(field_node, "Attacks");
								if (sub_attacks_node != null)
								{
									foreach (XmlNode sub_attack_node in sub_attacks_node.ChildNodes)
									{
										string str = secondary_attack(sub_attack_node);
										if (str != "")
										{
											line += Environment.NewLine;
											line += str;
										}
									}
								}

								if (desc != "")
									desc += "\n";

								desc += line;
							}
						}
					}

					// TODO: Sustain
					// TODO: Aftereffect
					// TODO: FailedSavingThrows

					string rng_tgt = range;
					if (target != "")
						rng_tgt += " (" + target + ")";
					power.Range = rng_tgt;

					power.Details = desc;
				}
				else
				{
					power.Details = XMLHelper.NodeText(power_node, "Details");
				}

				#endregion

				c.CreaturePowers.Add(power);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		static string secondary_attack(XmlNode attack_node)
		{
			// Name & description
			string name = XMLHelper.NodeText(attack_node, "Name");
			string details = XMLHelper.NodeText(attack_node, "Description");

			string str = name + ": " + details;

			string hit = "";
			string miss = "";
			string effect = "";

			foreach (XmlNode node in attack_node.ChildNodes)
			{
				switch (node.Name)
				{
					case "Hit":
						hit = secondary_attack_details(node);
						break;
					case "Miss":
						miss = secondary_attack_details(node);
						break;
					case "Effect":
						effect = secondary_attack_details(node);
						break;
				}
			}

			if (hit != "")
				str += Environment.NewLine + "Hit: " + hit;

			if (miss != "")
				str += Environment.NewLine + "Miss: " + miss;

			if (effect != "")
				str += Environment.NewLine + "Effect: " + effect;

			return str;
		}

		static string secondary_attack_details(XmlNode details_node)
		{
			XmlNode dmg_node = XMLHelper.FindChild(details_node, "Damage");
			string dmg = XMLHelper.NodeText(dmg_node, "Expression");

			string desc = XMLHelper.NodeText(details_node, "Description");

			if ((dmg != "") && (desc != ""))
				return dmg + " " + desc;
			if ((dmg != "") && (desc == ""))
				return dmg + " damage";
			if ((dmg == "") && (desc != ""))
				return desc;

			return "";
		}

		#endregion

		#region Character Builder

		public static Hero ImportHero(string xml)
		{
			Hero hero = new Hero();

			try
			{
				xml = xml.Replace("RESISTANCE_+", "RESISTANCE_PLUS");
				xml = xml.Replace("CORMYR!", "CORMYR");
				xml = xml.Replace("SILVER_TONGUE,", "SILVER_TONGUE");

				XmlDocument doc = XMLHelper.LoadSource(xml);
				if (doc == null)
					return null;

				#region Character Sheet

				XmlNode cs_node = XMLHelper.FindChild(doc.DocumentElement, "CharacterSheet");
				if (cs_node != null)
				{
					XmlNode details_node = XMLHelper.FindChild(cs_node, "Details");
					if (details_node != null)
					{
						hero.Name = XMLHelper.NodeText(details_node, "name").Trim();
						hero.Player = XMLHelper.NodeText(details_node, "Player").Trim();
						hero.Level = int.Parse(XMLHelper.NodeText(details_node, "Level"));

						string portrait_file = XMLHelper.NodeText(details_node, "Portrait").Trim();
						if (portrait_file != "")
						{
							try
							{
								string preamble = "file://";
								if (portrait_file.StartsWith(preamble))
									portrait_file = portrait_file.Substring(preamble.Length);

								if (File.Exists(portrait_file))
									hero.Portrait = Image.FromFile(portrait_file);
							}
							catch
							{
							}
						}
					}

					XmlNode stats_node = XMLHelper.FindChild(cs_node, "StatBlock");
					if (stats_node != null)
					{
						// HP
						XmlNode hp_node = get_stat_node(stats_node, "Hit Points");
						if (hp_node != null)
							hero.HP = XMLHelper.GetIntAttribute(hp_node, "value");

						// AC
						XmlNode ac_node = get_stat_node(stats_node, "AC");
						if (ac_node != null)
							hero.AC = XMLHelper.GetIntAttribute(ac_node, "value");

						// Fortitude
						XmlNode fort_node = get_stat_node(stats_node, "Fortitude Defense");
						if (fort_node != null)
							hero.Fortitude = XMLHelper.GetIntAttribute(fort_node, "value");

						// Reflex
						XmlNode ref_node = get_stat_node(stats_node, "Reflex Defense");
						if (ref_node != null)
							hero.Reflex = XMLHelper.GetIntAttribute(ref_node, "value");

						// Will
						XmlNode will_node = get_stat_node(stats_node, "Will Defense");
						if (will_node != null)
							hero.Will = XMLHelper.GetIntAttribute(will_node, "value");

						// Initiative bonus
						XmlNode init_node = get_stat_node(stats_node, "Initiative");
						if (init_node != null)
							hero.InitBonus = XMLHelper.GetIntAttribute(init_node, "value");

						// Passive perception
						XmlNode perc_node = get_stat_node(stats_node, "Passive Perception");
						if (perc_node != null)
							hero.PassivePerception = XMLHelper.GetIntAttribute(perc_node, "value");

						// Passive insight
						XmlNode ins_node = get_stat_node(stats_node, "Passive Insight");
						if (ins_node != null)
							hero.PassiveInsight = XMLHelper.GetIntAttribute(ins_node, "value");
					}

					XmlNode rules_node = XMLHelper.FindChild(cs_node, "RulesElementTally");
					if (rules_node != null)
					{
						// Race
						XmlNode race_node = XMLHelper.FindChildWithAttribute(rules_node, "type", "Race");
						if (race_node != null)
							hero.Race = XMLHelper.GetAttribute(race_node, "name");

						// Class
						XmlNode class_node = XMLHelper.FindChildWithAttribute(rules_node, "type", "Class");
						if (class_node != null)
							hero.Class = XMLHelper.GetAttribute(class_node, "name");

						// Paragon Path
						XmlNode pp_node = XMLHelper.FindChildWithAttribute(rules_node, "type", "Paragon Path");
						if (pp_node != null)
							hero.ParagonPath = XMLHelper.GetAttribute(pp_node, "name");

						// Epic Destiny
						XmlNode ed_node = XMLHelper.FindChildWithAttribute(rules_node, "type", "Epic Destiny");
						if (ed_node != null)
							hero.EpicDestiny = XMLHelper.GetAttribute(ed_node, "name");

						// Role
						XmlNode role_node = XMLHelper.FindChildWithAttribute(rules_node, "type", "Role");
						if (role_node != null)
							hero.Role = (HeroRoleType)Enum.Parse(typeof(HeroRoleType), XMLHelper.GetAttribute(role_node, "name"));

						// Power source
						XmlNode source_node = XMLHelper.FindChildWithAttribute(rules_node, "type", "Power Source");
						if (source_node != null)
							hero.PowerSource = XMLHelper.GetAttribute(source_node, "name");

						// Languages
						List<XmlNode> lang_nodes = XMLHelper.FindChildrenWithAttribute(rules_node, "type", "Language");
						foreach (XmlNode lang_node in lang_nodes)
						{
							string lang = XMLHelper.GetAttribute(lang_node, "name");
							if (lang != "")
							{
								if (hero.Languages != "")
									hero.Languages += ", ";

								hero.Languages += lang;
							}
						}
					}
				}

				#endregion

				#region Levels

				XmlNode level_node = XMLHelper.FindChild(doc.DocumentElement, "Level");
				if (level_node != null)
				{
					XmlNode level_1 = XMLHelper.FindChildWithAttribute(level_node, "name", "1");
					if (level_1 != null)
					{
						if (hero.Race == "")
						{
							XmlNode race_node = XMLHelper.FindChildWithAttribute(level_1, "type", "Race");
							if (race_node != null)
								hero.Race = XMLHelper.GetAttribute(race_node, "name");
						}

						if (hero.Class == "")
						{
							XmlNode class_node = XMLHelper.FindChildWithAttribute(level_1, "type", "Class");
							if (class_node != null)
								hero.Class = XMLHelper.GetAttribute(class_node, "name");
						}
					}

					XmlNode level_11 = XMLHelper.FindChildWithAttribute(level_node, "name", "11");
					if (level_11 != null)
					{
						if (hero.ParagonPath == "")
						{
							XmlNode pp_node = XMLHelper.FindChildWithAttribute(level_11, "type", "ParagonPath");
							if (pp_node != null)
								hero.ParagonPath = XMLHelper.GetAttribute(pp_node, "name");
						}
					}

					XmlNode level_21 = XMLHelper.FindChildWithAttribute(level_node, "name", "21");
					if (level_21 != null)
					{
						if (hero.EpicDestiny == "")
						{
							XmlNode ed_node = XMLHelper.FindChildWithAttribute(level_21, "type", "EpicDestiny");
							if (ed_node != null)
								hero.EpicDestiny = XMLHelper.GetAttribute(ed_node, "name");
						}
					}
				}

				#endregion
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}

			return hero;
		}

		static XmlNode get_stat_node(XmlNode parent, string name)
		{
			XmlNode node = XMLHelper.FindChildWithAttribute(parent, "name", name);
			if (node != null)
				return node;

			foreach (XmlNode child in parent.ChildNodes)
			{
				node = XMLHelper.FindChildWithAttribute(child, "name", name);
				if (node != null)
					return child;
			}

			return null;
		}

		#endregion

		#region iPlay4e

		public static bool ImportIPlay4e(Hero hero)
		{
			if ((hero.Key == null) || (hero.Key == ""))
				return false;

			bool ok = true;

			try
			{
				string url = "http://iplay4e.appspot.com/view?xsl=jPint&key=" + hero.Key;

				WebClient client = new WebClient();
				string xml = client.DownloadString(url);

				XmlDocument doc = new XmlDocument();
				doc.LoadXml(xml);

				XmlNode character_node = doc.DocumentElement;
				hero.Name = XMLHelper.GetAttribute(character_node, "name");

				XmlNode build_node = XMLHelper.FindChild(character_node, "Build");
				if (build_node != null)
				{
					hero.Level = XMLHelper.GetIntAttribute(build_node, "level");
					try
					{
						string role = XMLHelper.GetAttribute(build_node, "role");
						hero.Role = (HeroRoleType)Enum.Parse(typeof(HeroRoleType), role);
					}
					catch
					{
					}

					try
					{
						string size = XMLHelper.GetAttribute(build_node, "size");
						hero.Size = (CreatureSize)Enum.Parse(typeof(CreatureSize), size);
					}
					catch
					{
					}

					hero.PowerSource = XMLHelper.GetAttribute(build_node, "powersource");
					hero.Class = XMLHelper.GetAttribute(build_node, "name");

					XmlNode race_node = XMLHelper.FindChild(build_node, "Race");
					if (race_node != null)
						hero.Race = XMLHelper.GetAttribute(race_node, "name");

					XmlNode pp_node = XMLHelper.FindChild(build_node, "ParagonPath");
					if (pp_node != null)
						hero.ParagonPath = XMLHelper.GetAttribute(pp_node, "name");

					XmlNode ed_node = XMLHelper.FindChild(build_node, "EpicDestiny");
					if (ed_node != null)
						hero.EpicDestiny = XMLHelper.GetAttribute(ed_node, "name");
				}

				XmlNode health_node = XMLHelper.FindChild(character_node, "Health");
				if (health_node != null)
				{
					XmlNode max_hp_node = XMLHelper.FindChild(health_node, "MaxHitPoints");
					if (max_hp_node != null)
						hero.HP = XMLHelper.GetIntAttribute(max_hp_node, "value");
				}

				XmlNode move_node = XMLHelper.FindChild(character_node, "Movement");
				if (move_node != null)
				{
					XmlNode init_node = XMLHelper.FindChild(move_node, "Initiative");
					if (init_node != null)
						hero.InitBonus = XMLHelper.GetIntAttribute(init_node, "value");
				}

				XmlNode def_node = XMLHelper.FindChild(character_node, "Defenses");
				if (def_node != null)
				{
					XmlNode ac_node = XMLHelper.FindChildWithAttribute(def_node, "abbreviation", "AC");
					if (ac_node != null)
						hero.AC = XMLHelper.GetIntAttribute(ac_node, "value");

					XmlNode fort_node = XMLHelper.FindChildWithAttribute(def_node, "abbreviation", "Fort");
					if (fort_node != null)
						hero.Fortitude = XMLHelper.GetIntAttribute(fort_node, "value");

					XmlNode ref_node = XMLHelper.FindChildWithAttribute(def_node, "abbreviation", "Ref");
					if (ref_node != null)
						hero.Reflex = XMLHelper.GetIntAttribute(ref_node, "value");

					XmlNode will_node = XMLHelper.FindChildWithAttribute(def_node, "abbreviation", "Will");
					if (will_node != null)
						hero.Will = XMLHelper.GetIntAttribute(will_node, "value");
				}

				XmlNode skills_node = XMLHelper.FindChild(character_node, "PassiveSkills");
				if (skills_node != null)
				{
					XmlNode ins_node = XMLHelper.FindChildWithAttribute(skills_node, "name", "Insight");
					if (ins_node != null)
						hero.PassiveInsight = XMLHelper.GetIntAttribute(ins_node, "value");

					XmlNode perc_node = XMLHelper.FindChildWithAttribute(skills_node, "name", "Perception");
					if (perc_node != null)
						hero.PassivePerception = XMLHelper.GetIntAttribute(perc_node, "value");
				}

				XmlNode langs_node = XMLHelper.FindChild(character_node, "Languages");
				if (langs_node != null)
				{
					string langs = "";

					foreach (XmlNode lang_node in langs_node.ChildNodes)
					{
						string lang = XMLHelper.GetAttribute(lang_node, "name");

						if (langs != "")
							langs += ", ";

						langs += lang;
					}

					hero.Languages = langs;
				}
			}
			catch
			{
				ok = false;
			}

			return ok;
		}

		public static List<Hero> ImportParty(string key)
		{
			List<Hero> heroes = new List<Hero>();

			try
			{
				string url = "http://iplay4e.appspot.com/campaigns/" + key + "/main";

				WebClient client = new WebClient();
				string xml = client.DownloadString(url);

				XmlDocument doc = new XmlDocument();
				doc.LoadXml(xml);

				XmlNode campaign_node = doc.DocumentElement;
				if (campaign_node != null)
				{
					XmlNode chars_node = XMLHelper.FindChild(campaign_node, "Characters");
					if (chars_node != null)
					{
						foreach (XmlNode char_node in chars_node.ChildNodes)
						{
							try
							{
								string hero_key = XMLHelper.GetAttribute(char_node, "key");

								Hero hero = new Hero();
								hero.Key = hero_key;

								bool ok = ImportIPlay4e(hero);

								if (ok)
									heroes.Add(hero);
							}
							catch
							{
							}
						}
					}
				}
			}
			catch
			{
			}

			return heroes;
		}

		#endregion
	}
}
