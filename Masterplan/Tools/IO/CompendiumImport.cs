using System;
using System.Collections.Generic;
using System.Xml;

using Utils;

using Masterplan.Data;

namespace Masterplan.Tools
{
	class CompendiumImport
	{
		static string simplify_html(string source)
		{
			//source = source.Replace("><", ">\n<");

			int start = source.IndexOf("<div id=\"detail\">", StringComparison.OrdinalIgnoreCase);
			if (start == -1)
				return "";

			int end = source.IndexOf("</div>", start) + 6;
			source = source.Substring(start, end - start);

			source = source.Replace("<br>", "<br/>");
			source = source.Replace("<BR>", "<BR/>");
			source = source.Replace("&nbsp;", " ");

			while (true)
			{
				string href = "href=\"";
				int quote_start = source.IndexOf(href);
				if (quote_start == -1)
					break;

				int quote_end = source.IndexOf("\"", quote_start + href.Length);
				int length = quote_end - quote_start + 1;

				string substr = source.Substring(quote_start, length);
				source = source.Replace(substr, "");
			}

			/*
			try
			{
				string flavor = "<p class=\"flavor\">";
				string flavor_alt = "<p class=\"flavor alt\">";
				int flavor_start = source.IndexOf(flavor_alt);
				while (true)
				{
					flavor_start = source.IndexOf(flavor, start);
					if (flavor_start == -1)
						break;

					// Don't do anything if this is the description node
					int desc_start = source.IndexOf("<b>Description</b>:", flavor_start);
					if (desc_start == flavor_start + flavor.Length)
						break;

					// Remove the <p class=\"flavorIndent\"> tag
					source = source.Remove(flavor_start, flavor.Length);
				}
			}
			catch
			{
			}
			*/

			return source;
		}

		#region Creature

		public static Creature ImportCreatureFromHTML(string html, string url)
		{
			Creature c = null;

			try
			{
				html = simplify_html(html);
				XmlDocument doc = XMLHelper.LoadSource(html);
				if (doc == null)
					return null;

				c = new Creature();
				c.URL = url;

				XmlNode node = doc.DocumentElement.FirstChild;
				try
				{
					handle_title_section(node, c);
				}
				catch
				{
				}

				node = node.NextSibling;
				try
				{
					handle_combat_section(node, c);
				}
				catch
				{
				}

				while (true)
				{
					node = node.NextSibling;

					XmlNode next_node = node.NextSibling;
					XmlAttribute class_att = next_node.Attributes["class"];
					if ((class_att == null) || (class_att.Value != "flavorIndent"))
						break;

					CreaturePower power = null;
					try
					{
						power = parse_power(node);

						while (true)
						{
							XmlAttribute next_att = node.NextSibling.Attributes["class"];
							if ((next_att != null) && (next_att.Value == "flavor alt"))
								break;

							node = node.NextSibling;

							if (power.Details != "")
								power.Details += Environment.NewLine;

							power.Details += node.FirstChild.Value;
						}

						power.ExtractAttackDetails();
					}
					catch
					{
					}

					if (power != null)
						c.CreaturePowers.Add(power);
				}

				try
				{
					handle_end_section(node, c);
				}
				catch
				{
				}

				node = node.NextSibling;
				if (node.FirstChild != null)
				{
					if (node.FirstChild.FirstChild.Value == "Equipment")
					{
						// Equipment
						string equipment = "";
						XmlNode equip_node = node.FirstChild.NextSibling;
						while (equip_node != null)
						{
							if (equip_node.FirstChild != null)
							{
								if (equipment != "")
									equipment += "; ";

								equipment += equip_node.FirstChild.Value.Trim();
							}

							equip_node = equip_node.NextSibling;
						}
						c.Equipment = equipment;
					}
					else if (node.FirstChild.FirstChild.Value == "Description")
					{
						XmlNode desc_node = node.FirstChild.NextSibling;
						if (desc_node != null)
						{
							string desc = desc_node.Value;

							if (desc.StartsWith(":"))
								desc = desc.Substring(1);
							desc = desc.Trim();

							c.Details = desc;
						}
					}
				}
			}
			catch
			{
				Console.WriteLine("Problem with creature: " + c.Name);
				c = null;
			}

			return c;
		}

		#region Import HTML

		static void handle_title_section(XmlNode node, Creature c)
		{
			string name = node.FirstChild.InnerText;
			string desc = node.FirstChild.NextSibling.NextSibling.FirstChild.InnerText;
			string info = node.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.InnerText;

			c.Name = name.Trim();

			int level = 0;
			bool minion = false;
			bool leader = false;
			RoleFlag flag = RoleFlag.Standard;
			RoleType role = RoleType.Artillery;
			bool has_role = false;

			string[] info_tokens = info.Split(null);
			foreach (string token in info_tokens)
			{
				if (token == "")
					continue;

				if (token.ToLower() == "minion")
				{
					minion = true;
					continue;
				}

				if (token.ToLower() == "(leader)")
				{
					leader = true;
					continue;
				}

				try
				{
					level = int.Parse(token);
					continue;
				}
				catch
				{
				}

				try
				{
					if (token != level.ToString())
					{
						flag = (RoleFlag)Enum.Parse(typeof(RoleFlag), token);
						continue;
					}
				}
				catch
				{
				}

				try
				{
					if (token != level.ToString())
					{
						role = (RoleType)Enum.Parse(typeof(RoleType), token);
						has_role = true;
						continue;
					}
				}
				catch
				{
				}
			}

			c.Level = level;
			if (minion)
			{
				Minion m = new Minion();
				m.HasRole = has_role;
				if (m.HasRole)
					m.Type = role;

				c.Role = m;
			}
			else
			{
				ComplexRole cr = new ComplexRole();
				cr.Type = role;
				cr.Flag = flag;
				cr.Leader = leader;

				c.Role = cr;
			}

			// Remove anything in parentheses from desc - these are the keywords
			int start = desc.IndexOf("(");
			int end = desc.IndexOf(")");
			if ((start != -1) && (end != -1))
			{
				int length = end - (start + 1);
				string keywords = desc.Substring(start + 1, length);
				desc = desc.Replace(keywords, "");

				c.Keywords = keywords;
			}

			// Remove anything after a comma or semicolon - these are keywords
			int start_comma = desc.IndexOf(",");
			if (start_comma == -1)
				start_comma = desc.IndexOf(";");
			if (start_comma != -1)
			{
				string keywords = desc.Substring(start_comma + 1).Trim();
				desc = desc.Substring(0, start_comma);

				if (c.Keywords != "")
					c.Keywords += "; ";

				c.Keywords += keywords;
			}

			string[] desc_tokens = desc.Split(null);
			foreach (string token in desc_tokens)
			{
				if (token == "")
					continue;

				string str = char.ToUpper(token[0]) + token.Substring(1);

				try
				{
					c.Size = (CreatureSize)Enum.Parse(typeof(CreatureSize), str);
					continue;
				}
				catch
				{
				}

				try
				{
					c.Origin = (CreatureOrigin)Enum.Parse(typeof(CreatureOrigin), str);
					continue;
				}
				catch
				{
				}

				try
				{
					c.Type = (CreatureType)Enum.Parse(typeof(CreatureType), str);
					continue;
				}
				catch
				{
				}
			}
		}

		static void handle_combat_section(XmlNode node, Creature c)
		{
			XmlNode init_node = node.FirstChild.NextSibling;
			c.Initiative = get_score(init_node);

			XmlNode sense_node = init_node.NextSibling.NextSibling;
			c.Senses = sense_node.Value.Trim();

			XmlNode next_node = sense_node;
			while (true)
			{
				next_node = next_node.NextSibling.NextSibling;
				if (next_node.FirstChild.Value == "HP")
					break;

				// Add aura
				Aura aura = new Aura();
				aura.Name = next_node.FirstChild.Value;
				aura.Details = next_node.NextSibling.Value;

				c.Auras.Add(aura);

				next_node = next_node.NextSibling;
			}

			XmlNode hp_node = next_node.NextSibling;
			c.HP = get_score(hp_node);

			XmlNode regen_node = hp_node.NextSibling.NextSibling.NextSibling.NextSibling;
			if (regen_node.FirstChild.Value == "Regeneration")
			{
				regen_node = regen_node.NextSibling;

				Regeneration regeneration = CreatureHelper.ConvertAura(regen_node.Value);
				if (regeneration != null)
					c.Regeneration = regeneration;

				next_node = regen_node;
			}
			else
				next_node = hp_node;

			while (true)
			{
				if ((next_node.FirstChild != null) && (next_node.FirstChild.Value == "AC"))
					break;

				next_node = next_node.NextSibling;
			}

			XmlNode ac_node = next_node.NextSibling;
			c.AC = get_score(ac_node);
			XmlNode fort_node = ac_node.NextSibling.NextSibling;
			c.Fortitude = get_score(fort_node);
			XmlNode ref_node = fort_node.NextSibling.NextSibling;
			c.Reflex = get_score(ref_node);
			XmlNode will_node = ref_node.NextSibling.NextSibling;
			c.Will = get_score(will_node);

			next_node = will_node.NextSibling;

			XmlNode immune_node = null;
			XmlNode resist_node = null;
			XmlNode vuln_node = null;
			XmlNode save_node = null;
			XmlNode speed_node = null;
			XmlNode action_node = null;
			while (true)
			{
				next_node = next_node.NextSibling;
				if (next_node == null)
					break;

				XmlNode title_node = next_node.FirstChild;
				if (title_node == null)
					continue;

				string title = title_node.Value.Trim();

				if (title == "Immune")
					immune_node = next_node.NextSibling;

				if (title == "Resist")
					resist_node = next_node.NextSibling;

				if (title == "Vulnerable")
					vuln_node = next_node.NextSibling;

				if (title == "Saving Throws")
					save_node = next_node.NextSibling;

				if (title == "Speed")
					speed_node = next_node.NextSibling;

				if (title == "Action Points")
					action_node = next_node.NextSibling;
			}

			if (immune_node != null)
			{
				string text = immune_node.Value.Trim();
				string[] sections = text.Split(new string[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries);

				string str = "";
				foreach (string section in sections)
				{
					string s = section.Trim();

					// Try to create damage modifier
					int index = s.IndexOf(" ");
					if (index != -1)
					{
						try
						{
							string value_str = s.Substring(0, index);
							int value = int.Parse(value_str);
							string type = s.Substring(index + 1);

							DamageModifier mod = DamageModifier.Parse(type, 0);
							if (mod != null)
							{
								c.DamageModifiers.Add(mod);
								continue;
							}
						}
						catch
						{
						}
					}

					if (str != "")
						str += ", ";

					str += section;
				}

				c.Immune = str;
			}

			if (resist_node != null)
			{
				string text = resist_node.Value.Trim();
				string[] sections = text.Split(new string[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries);

				string str = "";
				foreach (string section in sections)
				{
					string s = section.Trim();

					// Try to create damage modifier
					int index = s.IndexOf(" ");
					if (index != -1)
					{
						try
						{
							string value_str = s.Substring(0, index);
							int value = int.Parse(value_str);
							string type = s.Substring(index + 1);

							DamageModifier mod = DamageModifier.Parse(type, -value);
							if (mod != null)
							{
								c.DamageModifiers.Add(mod);
								continue;
							}
						}
						catch
						{
						}
					}

					if (str != "")
						str += ", ";

					str += section;
				}

				c.Resist = str;
			}

			if (vuln_node != null)
			{
				string text = vuln_node.Value.Trim();
				string[] sections = text.Split(new string[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries);

				string str = "";
				foreach (string section in sections)
				{
					string s = section.Trim();

					// Try to create damage modifier
					int index = s.IndexOf(" ");
					if (index != -1)
					{
						try
						{
							string value_str = s.Substring(0, index);
							int value = int.Parse(value_str);
							string type = s.Substring(index + 1);

							DamageModifier mod = DamageModifier.Parse(type, value);
							if (mod != null)
							{
								c.DamageModifiers.Add(mod);
								continue;
							}
						}
						catch
						{
						}
					}

					if (str != "")
						str += ", ";

					str += section;
				}

				c.Vulnerable = str;
			}

			if (save_node != null)
			{
			}

			if (speed_node != null)
			{
				string speed = speed_node.Value.Trim();
				c.Movement = speed;
			}

			if (action_node != null)
			{
			}
		}

		static void handle_end_section(XmlNode node, Creature c)
		{
			// Alignment
			XmlNode align_node = node.FirstChild.NextSibling;
			c.Alignment = align_node.Value.Trim();

			// Languages
			XmlNode lang_node = align_node.NextSibling.NextSibling;
			string langs = lang_node.Value.Trim();
			langs = langs.Replace("-", "");
			c.Languages = langs;

			// Skills
			XmlNode next_node = lang_node;
			if (lang_node.NextSibling.NextSibling.FirstChild.Value == "Skills")
			{
				XmlNode skills_node = lang_node.NextSibling.NextSibling.NextSibling;
				c.Skills = skills_node.Value.Trim();

				next_node = skills_node;
			}

			// Ability scores
			XmlNode str_node = next_node.NextSibling.NextSibling.NextSibling;
			c.Strength.Score = get_score(str_node);
			XmlNode dex_node = str_node.NextSibling.NextSibling;
			c.Dexterity.Score = get_score(dex_node);
			XmlNode wis_node = dex_node.NextSibling.NextSibling;
			c.Wisdom.Score = get_score(wis_node);
			XmlNode con_node = wis_node.NextSibling.NextSibling.NextSibling;
			c.Constitution.Score = get_score(con_node);
			XmlNode int_node = con_node.NextSibling.NextSibling;
			c.Intelligence.Score = get_score(int_node);
			XmlNode cha_node = int_node.NextSibling.NextSibling;
			c.Charisma.Score = get_score(cha_node);
		}

		static CreaturePower parse_power(XmlNode node)
		{
			CreaturePower power = new CreaturePower();

			foreach (XmlNode child in node.ChildNodes)
			{
				if (child.Name == "b")
				{
					power.Name = child.FirstChild.Value.Trim();
					break;
				}
			}

			string parenthesis = "";
			bool is_basic_attack = false;

			foreach (XmlNode child in node.ChildNodes)
			{
				if (child.Name == "img")
				{
					XmlAttribute src_att = child.Attributes["src"];
					string image = src_att.Value;

					if (image.EndsWith("S2.gif"))
					{
						power.Action = new PowerAction();
						power.Action.Use = PowerUseType.Basic;

						is_basic_attack = true;
					}
					else if (image.EndsWith("x.gif"))
					{
						XmlNode key_node = child.NextSibling.FirstChild;
						power.Keywords = key_node.Value;
					}
					else if ((image.EndsWith("Z1a.gif")) || (image.EndsWith("Z2a.gif")) || (image.EndsWith("Z3a.gif")) || (image.EndsWith("Z4a.gif")))
					{
						// It's one of the action icons
						// Ignore
					}
					else
					{
						parenthesis += " " + image.Substring(image.Length - 6, 1);
					}
				}

				if (child.Name == "#text")
				{
					string text = child.Value.Trim();
					parenthesis += text;
				}
			}

			if (parenthesis != "")
			{
				parenthesis = parenthesis.Trim();
				parenthesis = parenthesis.Substring(1, parenthesis.Length - 2);
				parenthesis = parenthesis.Trim();

				parenthesis = parenthesis.Replace(",", ";");
				List<string> tokens = new List<string>(parenthesis.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries));
				if (tokens.Count != 0)
				{
					for (int index = 0; index != tokens.Count; ++index)
						tokens[index] = tokens[index].Trim();

					string first_token = tokens[0].ToLower();
					if ((!first_token.StartsWith("standard")) && (!first_token.StartsWith("move")) && (!first_token.StartsWith("minor")) && (!first_token.StartsWith("free")) && (!first_token.StartsWith("immediate")))
					{
						power.Condition = tokens[0];
						tokens.RemoveAt(0);
					}

					if ((tokens.Count != 0) && (power.Action == null))
					{
						power.Action = new PowerAction();
						power.Action.Action = ActionType.None;
					}

					for (int index = 0; index != tokens.Count; ++index)
					{
						string token = tokens[index];
						string token_lc = token.ToLower();

						if (token_lc.StartsWith("standard"))
						{
							power.Action.Action = ActionType.Standard;
							continue;
						}

						if (token_lc.StartsWith("move"))
						{
							power.Action.Action = ActionType.Move;
							continue;
						}

						if (token_lc.StartsWith("minor"))
						{
							power.Action.Action = ActionType.Minor;
							continue;
						}

						if (token_lc.StartsWith("free"))
						{
							power.Action.Action = ActionType.Free;
							continue;
						}

						if (token_lc == "immediate interrupt")
						{
							power.Action.Action = ActionType.Interrupt;
							//power.Action.Trigger = tokens[index + 1];
							//tokens.RemoveAt(index + 1);

							continue;
						}

						if (token_lc == "immediate reaction")
						{
							power.Action.Action = ActionType.Reaction;
							//power.Action.Trigger = tokens[index + 1];
							//tokens.RemoveAt(index + 1);

							continue;
						}

						if (token_lc == "at-will")
						{
							if (!is_basic_attack)
								power.Action.Use = PowerUseType.AtWill;

							continue;
						}

						if (token_lc == "encounter")
						{
							power.Action.Use = PowerUseType.Encounter;
							continue;
						}

						if (token_lc == "daily")
						{
							power.Action.Use = PowerUseType.Daily;
							continue;
						}

						string recharge_str = "recharge ";
						if (token_lc.StartsWith(recharge_str))
						{
							power.Action.Use = PowerUseType.Encounter;

							string recharge = token.Substring(recharge_str.Length);
							if (recharge == "6")
							{
								power.Action.Recharge = "Recharges on 6";
							}
							else if (recharge == "5 6")
							{
								power.Action.Recharge = "Recharges on 5-6";
							}
							else if (recharge == "4 5 6")
							{
								power.Action.Recharge = "Recharges on 4-6";
							}
							else if (recharge == "3 4 5 6")
							{
								power.Action.Recharge = "Recharges on 3-6";
							}
							else if (recharge == "2 3 4 5 6")
							{
								power.Action.Recharge = "Recharges on 2-6";
							}
							else
							{
								power.Action.Recharge = token;
							}

							continue;
						}

						string re = "recharge";
						if (token_lc.StartsWith(re))
						{
							power.Action.Recharge = token;
							continue;
						}

						string sustain = "sustain ";
						if (token_lc.StartsWith(sustain))
						{
							try
							{
								string action = token.Substring(sustain.Length);
								action = char.ToUpper(action[0]) + action.Substring(1);
								ActionType type = (ActionType)Enum.Parse(typeof(ActionType), action);
								power.Action.SustainAction = type;
							}
							catch
							{
							}

							continue;
						}

						if (token_lc.StartsWith("when") || token_lc.StartsWith("if"))
						{
							power.Action.Trigger = token;
							continue;
						}

						// If we got here, assume it's a usage condition
						power.Condition = token;
					}
				}
			}

			return power;
		}

		static int get_score(XmlNode node)
		{
			string str = "";
			bool started = false;
			foreach (char ch in node.Value)
			{
				if (char.IsNumber(ch))
				{
					started = true;
					str += ch;
				}
				else
				{
					if (started)
						break;
				}
			}

			try
			{
				int val = int.Parse(str);
				return val;
			}
			catch
			{
			}

			string text = node.Value;
			string[] tokens = text.Split(new string[] { }, StringSplitOptions.RemoveEmptyEntries);

			try
			{
				string val_str = tokens[0];
				int val = int.Parse(val_str);
				return val;
			}
			catch
			{
			}

			return 0;
		}

		#endregion

		static ActionType parse_action(string str)
		{
			if ((str == "standard") || (str == "standard action"))
				return ActionType.Standard;

			if ((str == "move") || (str == "move action"))
				return ActionType.Move;

			if ((str == "minor") || (str == "minor action"))
				return ActionType.Minor;

			if ((str == "free") || (str == "free action"))
				return ActionType.Free;

			if (str == "immediate interrupt")
				return ActionType.Interrupt;

			if (str == "immediate reaction")
				return ActionType.Reaction;

			return ActionType.Standard;
		}

		#endregion

		#region Trap

		public static Trap ImportTrapFromHTML(string html, string url)
		{
			Trap t = null;

			try
			{
				string xml = simplify_html(html);
				XmlDocument doc = XMLHelper.LoadSource(xml);
				if (doc == null)
					return null;

				t = new Trap();
				t.URL = url;

				if (doc.InnerText.ToLower().Contains("hazard"))
					t.Type = TrapType.Hazard;
				else
					t.Type = TrapType.Trap;

				#region Title section

				XmlNode node = doc.DocumentElement.FirstChild;
				try
				{
					handle_title_section(node, t);
				}
				catch
				{
				}

				string next = node.NextSibling.InnerText.ToLower();
				if ((!next.StartsWith("trap")) && (!next.StartsWith("hazard")))
				{
					node = node.NextSibling;
					t.ReadAloud = node.InnerText;
				}

				if (node.FirstChild.NextSibling != null)
				{
					node = node.NextSibling;
					t.Details = node.FirstChild.NextSibling.InnerText;
				}

				#endregion

				#region Skills

				try
				{
					node = node.NextSibling;
					while (true)
					{
						string skill_name = node.InnerText;

						if ((skill_name.StartsWith("Trap")) || (skill_name.StartsWith("Hazard")))
						{
							node = node.NextSibling;
							continue;
						}

						if ((skill_name.StartsWith("Trigger")) || (skill_name.StartsWith("Initiative")) || (skill_name.StartsWith("Target")))
							break;

						TrapSkillData tsd = new TrapSkillData();
						tsd.SkillName = skill_name;
						tsd.DC = 0;

						foreach (XmlNode n in node.NextSibling.ChildNodes)
						{
							string skill_details = n.InnerText;
							if (skill_details.StartsWith("DC "))
							{
								skill_details = skill_details.Substring(3);

								int index = skill_details.IndexOf(":");
								string dc_str = skill_details.Substring(0, index);
								try
								{
									tsd.DC = int.Parse(dc_str);
								}
								catch
								{
								}

								skill_details = skill_details.Substring(index + 1);
								skill_details = skill_details.Trim();
							}

							if (skill_details != "")
							{
								if (tsd.Details != "")
									tsd.Details += Environment.NewLine;

								tsd.Details += skill_details;
							}
						}

						t.Skills.Add(tsd);

						node = node.NextSibling.NextSibling;
					}
				}
				catch
				{
				}

				#endregion

				#region Initiative

				if (node.InnerText == "Initiative")
				{
					try
					{
						string init_str = node.FirstChild.NextSibling.InnerText;
						int init = int.Parse(init_str);

						t.Attack.HasInitiative = true;
						t.Attack.Initiative = init;
					}
					catch
					{
					}
				}

				#endregion

				#region Trigger

				node = node.NextSibling;
				if ((node.FirstChild != null) && (node.FirstChild.InnerText == "Trigger"))
				{
					while (node.NextSibling.FirstChild == null)
						node = node.NextSibling;

					t.Attack.Trigger = node.NextSibling.FirstChild.InnerText;
				}

				#endregion

				#region Attack

				node = node.NextSibling.NextSibling;
				while (true)
				{
					node = node.NextSibling;
					if (node.Name.ToLower() == "p")
						break;

					string title = node.FirstChild.InnerText.ToLower();
					if (title.StartsWith("countermeasure"))
						break;

					if (title.StartsWith("target"))
					{
						t.Attack.Target = node.FirstChild.NextSibling.InnerText;
					}
					else if (title.StartsWith("attack"))
					{
						if (node.FirstChild.NextSibling != null)
						{
							string attack = node.FirstChild.NextSibling.InnerText;
							string[] tokens = attack.Split(null);

							int bonus = 0;
							DefenceType defence = DefenceType.AC;

							try
							{
								bonus = int.Parse(tokens[0]);
								defence = (DefenceType)Enum.Parse(typeof(DefenceType), tokens[2]);
							}
							catch
							{
							}

							t.Attack.Attack.Bonus = bonus;
							t.Attack.Attack.Defence = defence;
						}
					}
					else if (title.StartsWith("hit"))
					{
						if (node.FirstChild.NextSibling != null)
						{
							t.Attack.OnHit = node.FirstChild.NextSibling.InnerText;
						}
						else
						{
							foreach (XmlNode n in node.NextSibling.ChildNodes)
							{
								if (t.Attack.OnHit != "")
									t.Attack.OnHit += Environment.NewLine;

								t.Attack.OnHit += n.InnerText;
							}

							node = node.NextSibling;
						}
					}
					else if (title.StartsWith("miss"))
					{
						if (node.FirstChild.NextSibling != null)
						{
							t.Attack.OnMiss = node.FirstChild.NextSibling.InnerText;
						}
						else
						{
							foreach (XmlNode n in node.NextSibling.ChildNodes)
							{
								if (t.Attack.OnMiss != "")
									t.Attack.OnMiss += Environment.NewLine;

								t.Attack.OnMiss += n.InnerText;
							}

							node = node.NextSibling;
						}
					}
					else if (title.StartsWith("effect"))
					{
						if (node.FirstChild.NextSibling != null)
						{
							t.Attack.Effect = node.FirstChild.NextSibling.InnerText;
						}
						else
						{
							foreach (XmlNode n in node.NextSibling.ChildNodes)
							{
								if (t.Attack.Effect != "")
									t.Attack.Effect += Environment.NewLine;

								t.Attack.Effect += n.InnerText;
							}

							node = node.NextSibling;
						}
					}
					else if (title.Contains(":"))
					{
						if (node.FirstChild.NextSibling != null)
						{
							string str = node.FirstChild.NextSibling.InnerText;
							t.Details = title + str + Environment.NewLine + t.Details;
						}
					}
					else
					{
						// Action type
						XmlNode n = node.FirstChild;
						t.Attack.Action = parse_action(n.InnerText);

						// Range
						n = n.NextSibling;
						if (n != null)
						{
							string range = n.InnerText;
							n = n.NextSibling;
							if (n != null)
								range += n.InnerText;
							t.Attack.Range = range;
						}
					}
				}

				#endregion

				#region Countermeasures

				if (node.InnerText == "Countermeasures")
				{
					XmlNode cm_node = node.NextSibling.FirstChild;
					while (cm_node != null)
					{
						string cm = cm_node.InnerText.Trim();
						if (cm != "")
							t.Countermeasures.Add(cm);

						cm_node = cm_node.NextSibling;
					}
				}
				else
				{
					if (node.NextSibling != null)
						node = node.NextSibling;

					if (node.FirstChild != null)
						node = node.FirstChild;

					while ((node != null) && (node.Name.ToUpper() != "P") && (node.InnerText != "Encounter Uses"))
					{
						string cm = node.InnerText;
						t.Countermeasures.Add(cm);

						node = node.NextSibling;
					}
				}

				#endregion
			}
			catch
			{
				Console.WriteLine("Problem with trap: " + t.Name);
				t = null;
			}

			return t;
		}

		static void handle_title_section(XmlNode node, Trap t)
		{
			string name = node.FirstChild.InnerText;
			string info = node.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.InnerText;

			t.Name = name;

			int level = 0;
			bool minion = false;
			bool leader = false;
			RoleFlag flag = RoleFlag.Standard;
			RoleType role = RoleType.Artillery;
			bool has_role = false;

			string[] info_tokens = info.Split(null);
			foreach (string token in info_tokens)
			{
				if (token == "")
					continue;

				if (token.ToLower() == "minion")
				{
					minion = true;
					continue;
				}

				if (token.ToLower() == "(leader)")
				{
					leader = true;
					continue;
				}

				try
				{
					level = int.Parse(token);
				}
				catch
				{
				}

				try
				{
					if (token != level.ToString())
					{
						flag = (RoleFlag)Enum.Parse(typeof(RoleFlag), token);
					}
				}
				catch
				{
				}

				try
				{
					if (token != level.ToString())
					{
						role = (RoleType)Enum.Parse(typeof(RoleType), token);

						has_role = true;
					}
				}
				catch
				{
				}
			}

			t.Level = level;
			if (minion)
			{
				Minion m = new Minion();
				m.HasRole = has_role;
				if (m.HasRole)
					m.Type = role;

				t.Role = m;
			}
			else
			{
				ComplexRole cr = new ComplexRole();
				cr.Type = role;
				cr.Flag = flag;
				cr.Leader = leader;

				t.Role = cr;
			}
		}

		#endregion

		#region Magic Item

		public static MagicItem ImportItemFromHTML(string html, string url)
		{
			MagicItem mi = null;

			try
			{
				string xml = simplify_html(html);
				XmlDocument doc = XMLHelper.LoadSource(xml);
				if (doc == null)
					return null;

				mi = new MagicItem();
				mi.URL = url;

				XmlNode name_node = doc.DocumentElement.FirstChild;
				mi.Name = name_node.InnerText.Trim();

				XmlNode desc_node = name_node.NextSibling;
				mi.Description = desc_node.InnerText.Trim();

				try
				{
					XmlNode properties_node = desc_node.NextSibling.FirstChild;

					while (true)
					{
						if ((properties_node.NextSibling == null) || (properties_node.NextSibling.NextSibling == null))
							break;

						while (properties_node.Name != "b")
							properties_node = properties_node.NextSibling;

						MagicItemSection mis = new MagicItemSection();

						mis.Header = properties_node.InnerText;
						mis.Details = properties_node.NextSibling.InnerText;

						if ((mis.Header == "Level") && (mis.Details != ""))
						{
							try
							{
								string level_str = mis.Details.Substring(1).Trim();
								mi.Level = int.Parse(level_str);
							}
							catch
							{
							}
						}
						else
						{
							if (mis.Details.StartsWith(":"))
								mis.Details = mis.Details.Substring(1).Trim();

							if (mis.Details == "")
							{
								mi.Type = mis.ToString();
							}
							else if (mis.Header == "Item Slot")
							{
								mi.Type = mis.Header + " (" + mis.Details.ToLower() + ")";
							}
							else
							{
								mi.Sections.Add(mis);
							}

							if (mis.Header == "Weapon")
								mi.Type = "Weapon";

							if (mis.Header == "Armor")
								mi.Type = "Armour";
						}

						properties_node = properties_node.NextSibling.NextSibling;
					}
				}
				catch
				{
				}

				try
				{
					XmlNode section_node = desc_node.NextSibling.NextSibling;

					while (true)
					{
						if (section_node == null)
							break;

						if (section_node.InnerXml.ToLower().Contains("<a"))
							break;

						string text = section_node.InnerText;
						int colon = text.IndexOf(":");
						if (colon != -1)
						{
							MagicItemSection mis = new MagicItemSection();

							mis.Header = text.Substring(0, colon).Trim();
							mis.Details = text.Substring(colon).Trim();

							if (mis.Details.StartsWith(":"))
								mis.Details = mis.Details.Substring(1).Trim();

							mi.Sections.Add(mis);
						}

						section_node = section_node.NextSibling;
					}
				}
				catch
				{
				}
			}
			catch
			{
				Console.WriteLine("Problem with magic item: " + mi.Name);
				mi = null;
			}

			if (mi.Type == "")
				mi = null;

			return mi;
		}

		#endregion
	}
}
