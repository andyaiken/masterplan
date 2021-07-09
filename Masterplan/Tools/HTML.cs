using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;

using Utils;

using Masterplan.Data;
using Masterplan.Tools.Generators;
using Masterplan.UI;
using Masterplan.Properties;

namespace Masterplan.Tools
{
	enum DisplaySize
	{
		Small,
		Medium,
		Large
	}

	class HTML
	{
		//static Markdown fMarkdown = new Markdown();

		#region Predefined

		public static string Text(string str, bool strip_html, bool centred, DisplaySize size)
		{
			List<string> lines = new List<string>();

			lines.Add("<HTML>");
			lines.AddRange(GetHead(null, null, size));

			lines.Add("<BODY style=\"background-color=black\">");

			string details = Process(str, strip_html);
			if (details != "")
			{
				if (centred)
					lines.Add("<P class=instruction style=\"color=white\">" + details + "</P>");
				else
					lines.Add("<P style=\"color=white\">" + details + "</P>");
			}

			lines.Add("</BODY>");
			lines.Add("</HTML>");

			return Concatenate(lines);
		}

		public static string StatBlock(EncounterCard card, CombatData data, Encounter enc, bool include_wrapper,
			bool initiative_holder, bool full, CardMode mode, DisplaySize size)
		{
			List<string> lines = new List<string>();

			if (include_wrapper)
			{
				lines.Add("<HTML>");
				lines.AddRange(HTML.GetStyle(DisplaySize.Small));
				lines.Add("<BODY>");
			}

			if (full)
			{
				if ((data != null) && (data.Location == CombatData.NoPoint) && (enc != null) && (enc.MapID != Guid.Empty))
				{
					lines.Add("<P class=instruction>Drag this creature from the list onto the map.</P>");
				}

				if (data != null)
					lines.AddRange(get_combat_data(data, card.HP, enc, initiative_holder));
			}

			if (card != null)
			{
				lines.Add("<P class=table>");
				lines.AddRange(card.AsText(data, mode, full));
				lines.Add("</P>");
			}
			else
			{
				lines.Add("<P class=instruction>(no creature selected)</P>");
			}

			if (include_wrapper)
			{
				lines.Add("</BODY>");
				lines.Add("</HTML>");
			}

			return Concatenate(lines);
		}

		public static string StatBlock(Hero hero, Encounter enc, bool include_wrapper,
			bool initiative_holder, bool show_effects, DisplaySize size)
		{
			List<string> lines = new List<string>();

			if (include_wrapper)
			{
				lines.Add("<HTML>");
				lines.AddRange(HTML.GetStyle(DisplaySize.Small));
				lines.Add("<BODY>");
			}

			if (enc != null)
			{
				if ((enc.MapID == Guid.Empty) && (hero.CombatData.Initiative == int.MinValue))
				{
					lines.Add("<P class=instruction>Double-click this character on the list to set its initiative score.</P>");
				}
				else if ((enc.MapID != Guid.Empty) && (hero.CombatData.Location == CombatData.NoPoint))
				{
					lines.Add("<P class=instruction>Drag this character from the list onto the map.</P>");
				}
			}

			lines.AddRange(get_hero(hero, enc, initiative_holder, show_effects));

			if (include_wrapper)
			{
				lines.Add("</BODY>");
				lines.Add("</HTML>");
			}

			return Concatenate(lines);
		}

		public static string CustomMapToken(CustomToken ct, bool drag, bool include_wrapper, DisplaySize size)
        {
            List<string> lines = new List<string>();

			if (include_wrapper)
			{
				lines.Add("<HTML>");
				lines.AddRange(HTML.GetStyle(size));
				lines.Add("<BODY>");
			}

            if (drag)
                lines.Add("<P class=instruction>Drag this item from the list onto the map.</P>");

            lines.AddRange(get_custom_token(ct));

			if (include_wrapper)
			{
				lines.Add("</BODY>");
				lines.Add("</HTML>");
			}

            return Concatenate(lines);
        }

		public static string Trap(Trap trap, CombatData cd, bool include_wrapper, bool initiative_holder,
			bool builder, DisplaySize size)
		{
			List<string> lines = new List<string>();

			if (include_wrapper)
			{
				lines.Add("<HTML>");
				lines.AddRange(HTML.GetStyle(DisplaySize.Small));
				lines.Add("<BODY>");
			}

			if (trap != null)
			{
				lines.AddRange(get_trap(trap, cd, initiative_holder, builder));
			}
			else
			{
				lines.Add("<P class=instruction>(no trap / hazard selected)</P>");
			}

			if (include_wrapper)
			{
				lines.Add("</BODY>");
				lines.Add("</HTML>");
			}

			return Concatenate(lines);
		}

		public static string SkillChallenge(SkillChallenge challenge, bool include_links, bool include_wrapper,
			DisplaySize size)
		{
			List<string> lines = new List<string>();

			if (include_wrapper)
			{
				lines.Add("<HTML>");
				lines.AddRange(HTML.GetStyle(DisplaySize.Small));
				lines.Add("<BODY>");
			}

			if (challenge != null)
			{
				lines.AddRange(get_skill_challenge(challenge, include_links));
			}
			else
			{
				lines.Add("<P class=instruction>(no skill challenge selected)</P>");
			}

			if (include_wrapper)
			{
				lines.Add("</BODY>");
				lines.Add("</HTML>");
			}

			return Concatenate(lines);
		}

		public static string CreatureTemplate(CreatureTemplate template, DisplaySize size, bool builder)
		{
			List<string> lines = new List<string>();

			lines.Add("<HTML>");
			lines.AddRange(GetHead(null, null, size));
			lines.Add("<BODY>");

			lines.Add("<P class=table>");
			lines.Add("<TABLE>");

			#region Header

			lines.Add("<TR class=template>");

			lines.Add("<TD colspan=2>");
			lines.Add("<B>" + HTML.Process(template.Name, true) + "</B>");
			lines.Add("</TD>");

			lines.Add("<TD>");
			lines.Add("<B>" + HTML.Process(template.Info, true) + "</B>");
			lines.Add("</TD>");

			if (builder)
			{
				lines.Add("<TR class=template>");
				lines.Add("<TD colspan=3 align=center>");
				lines.Add("<A href=build:profile style=\"color:white\">(click here to edit this top section)</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			lines.Add("</TR>");

			#endregion

			#region Initiative

			string init_str = template.Initiative.ToString();
			if (template.Initiative >= 0)
				init_str = "+" + init_str;

			if (builder)
				init_str = "<A href=build:combat>" + init_str + "</A>";

			lines.Add("<TR>");
			lines.Add("<TD colspan=3>");
			lines.Add("<B>Initiative</B> " + init_str);
			lines.Add("</TD>");
			lines.Add("</TR>");

			#endregion

			#region Movement

			string move = HTML.Process(template.Movement, true);
			if ((move != "") || (builder))
			{
				if (builder)
				{
					if (move == "")
						move = "no additional movement modes";

					move = "<A href=build:movement>" + move + "</A>";
				}

				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Movement</B> " + move);
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			#endregion

			#region Senses

			if ((template.Senses != "") || (builder))
			{
				int rows = 2;

				// Add 1 row if there are damage mods
				if ((template.Resist != "") || (template.Vulnerable != "") || (template.Immune != "") || (template.DamageModifierTemplates.Count != 0))
					rows += 1;

				string senses = HTML.Process(template.Senses, true);

				if (builder)
				{
					if (senses == "")
						senses = "no additional senses";

					senses = "<A href=build:senses>" + senses + "</A>";
				}

				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Senses</B> " + senses);
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			#endregion

			#region Defences

			string defences = "";
			if (template.AC != 0)
			{
				string sign = (template.AC > 0) ? "+" : "";
				defences += sign + template.AC + " AC";
			}
			if (template.Fortitude != 0)
			{
				if (defences != "")
					defences += "; ";

				string sign = (template.Fortitude > 0) ? "+" : "";
				defences += sign + template.Fortitude + " Fort";
			}
			if (template.Reflex != 0)
			{
				if (defences != "")
					defences += "; ";

				string sign = (template.Reflex > 0) ? "+" : "";
				defences += sign + template.Reflex + " Ref";
			}
			if (template.Will != 0)
			{
				if (defences != "")
					defences += "; ";

				string sign = (template.Will > 0) ? "+" : "";
				defences += sign + template.Will + " Will";
			}

			if ((defences != "") || (builder))
			{
				if (builder)
				{
					if (defences == "")
						defences = "no defence bonuses";

					defences = "<A href=build:combat>" + defences + "</A>";
				}

				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Defences</B> " + defences);
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			#endregion

			#region Resistance, vulnerability, immunity

			string resist = HTML.Process(template.Resist, true);
			string vuln = HTML.Process(template.Vulnerable, true);
			string immune = HTML.Process(template.Immune, true);
			if (resist == null)
				resist = "";
			if (vuln == null)
				vuln = "";
			if (immune == null)
				immune = "";

			foreach (DamageModifierTemplate dm in template.DamageModifierTemplates)
			{
				int total = dm.HeroicValue + dm.ParagonValue + dm.EpicValue;

				// Immunity
				if (total == 0)
				{
					if (immune != "")
						immune += ", ";

					immune += dm.Type.ToString().ToLower();
				}

				// Vulnerability
				if (total > 0)
				{
					if (vuln != "")
						vuln += ", ";

					vuln += dm.HeroicValue + "/" + dm.ParagonValue + "/" + dm.EpicValue + " " + dm.Type.ToString().ToLower();
				}

				// Resistance
				if (total < 0)
				{
					if (resist != "")
						resist += ", ";

					int val1 = Math.Abs(dm.HeroicValue);
					int val2 = Math.Abs(dm.ParagonValue);
					int val3 = Math.Abs(dm.EpicValue);
					resist += val1 + "/" + val2 + "/" + val3 + " " + dm.Type.ToString().ToLower();
				}
			}

			string damage = "";
			if (immune != "")
			{
				if (damage != "")
					damage += " ";

				damage += "<B>Immune</B> " + immune;
			}
			if (resist != "")
			{
				if (damage != "")
					damage += " ";

				damage += "<B>Resist</B> " + resist;
			}
			if (vuln != "")
			{
				if (damage != "")
					damage += " ";

				damage += "<B>Vulnerable</B> " + vuln;
			}

			if ((damage != "") || (builder))
			{
				if (builder)
				{
					if (damage == "")
						damage = "Set resistances / vulnerabilities / immunities";

					damage = "<A href=build:damage>" + damage + "</A>";
				}

				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add(damage);
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			#endregion

			#region Saving throws, action points

			lines.Add("<TR>");
			lines.Add("<TD colspan=3>");
			lines.Add("<B>Saving Throws</B> +2");
			lines.Add("</TD>");
			lines.Add("</TR>");

			lines.Add("<TR>");
			lines.Add("<TD colspan=3>");
			lines.Add("<B>Action Point</B> 1");
			lines.Add("</TD>");
			lines.Add("</TR>");

			#endregion

			#region HP

			string hp = "+" + template.HP + " per level + Constitution score";
			if (builder)
				hp = "<A href=build:combat>" + hp + "</A>";

			lines.Add("<TR>");
			lines.Add("<TD colspan=3>");
			lines.Add("<B>HP</B> " + hp);
			lines.Add("</TD>");
			lines.Add("</TR>");

			#endregion

			#region Powers, Auras, Regen

			if (builder)
			{
				lines.Add("<TR class=template>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Powers and Traits</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD colspan=3 align=center>");
				lines.Add("<A href=power:addtrait>add a trait</A>");
				lines.Add("|");
				lines.Add("<A href=power:addpower>add a power</A>");
				lines.Add("|");
				lines.Add("<A href=power:addaura>add an aura</A>");
				if (template.Regeneration == null)
				{
					lines.Add("|");
					lines.Add("<A href=power:regenedit>add regeneration</A>");
				}
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			Dictionary<CreaturePowerCategory, List<CreaturePower>> powers = new Dictionary<CreaturePowerCategory, List<CreaturePower>>();

			Array power_categories = Enum.GetValues(typeof(CreaturePowerCategory));
			foreach (CreaturePowerCategory cat in power_categories)
				powers[cat] = new List<CreaturePower>();

			foreach (CreaturePower cp in template.CreaturePowers)
				powers[cp.Category].Add(cp);

			foreach (CreaturePowerCategory cat in power_categories)
			{
				int count = powers[cat].Count;
				if (cat == CreaturePowerCategory.Trait)
				{
					// Add auras
					count += template.Auras.Count;

					// Add regeneration
					Regeneration regen = template.Regeneration;
					if (regen != null)
						count += 1;
				}

				if (count == 0)
					continue;

				string name = "";
				switch (cat)
				{
					case CreaturePowerCategory.Trait:
						name = "Traits";
						break;
					case CreaturePowerCategory.Standard:
					case CreaturePowerCategory.Move:
					case CreaturePowerCategory.Minor:
					case CreaturePowerCategory.Free:
						name = cat + " Actions";
						break;
					case CreaturePowerCategory.Triggered:
						name = "Triggered Actions";
						break;
					case CreaturePowerCategory.Other:
						name = "Other Actions";
						break;
				}

				lines.Add("<TR class=creature>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>" + name + "</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				if (cat == CreaturePowerCategory.Trait)
				{
					// Auras
					foreach (Aura aura in template.Auras)
					{
						string aura_details = HTML.Process(aura.Details.Trim(), true);
						if (!aura_details.StartsWith("aura", StringComparison.OrdinalIgnoreCase))
							aura_details = "Aura " + aura_details;
						else
							aura_details = "A" + aura_details.Substring(1);

						MemoryStream ms = new MemoryStream();
						Resources.Aura.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
						byte[] byteImage = ms.ToArray();
						string data = Convert.ToBase64String(byteImage);

						lines.Add("<TR class=shaded>");
						lines.Add("<TD colspan=3>");
						lines.Add("<img src=data:image/png;base64," + data + ">");
						lines.Add("<B>" + HTML.Process(aura.Name, true) + "</B>");
						if (aura.Keywords != "")
							lines.Add("(" + aura.Keywords + ")");
						if (aura.Radius > 0)
							lines.Add(" &diams; Aura " + aura.Radius);
						lines.Add("</TD>");
						lines.Add("</TR>");

						lines.Add("<TR>");
						lines.Add("<TD colspan=3>");
						lines.Add(aura_details);
						lines.Add("</TD>");
						lines.Add("</TR>");

						if (builder)
						{
							lines.Add("<TR>");
							lines.Add("<TD colspan=3 align=center>");
							lines.Add("<A href=auraedit:" + aura.ID + ">edit</A>");
							lines.Add("|");
							lines.Add("<A href=auraremove:" + aura.ID + ">remove</A>");
							lines.Add("</TD>");
							lines.Add("</TR>");
						}
					}

					// Regeneration
					if (template.Regeneration != null)
					{
						lines.Add("<TR class=shaded>");
						lines.Add("<TD colspan=3>");
						lines.Add("<B>Regeneration</B>");
						lines.Add("</TD>");
						lines.Add("</TR>");

						lines.Add("<TR>");
						lines.Add("<TD colspan=3>");
						lines.Add("Regeneration " + HTML.Process(template.Regeneration.ToString(), true));
						lines.Add("</TD>");
						lines.Add("</TR>");

						if (builder)
						{
							lines.Add("<TR>");
							lines.Add("<TD colspan=3 align=center>");
							lines.Add("<A href=power:regenedit>edit</A>");
							lines.Add("|");
							lines.Add("<A href=power:regenremove>remove</A>");
							lines.Add("</TD>");
							lines.Add("</TR>");
						}
					}
				}

				foreach (CreaturePower cp in powers[cat])
				{
					lines.AddRange(cp.AsHTML(null, CardMode.View, false));

					if (builder)
					{
						lines.Add("<TR>");
						lines.Add("<TD colspan=3 align=center>");
						lines.Add("<A href=\"poweredit:" + cp.ID + "\">edit this power</A>");
						lines.Add("|");
						lines.Add("<A href=\"powerremove:" + cp.ID + "\">remove this power</A>");
						//lines.Add("|");
						//lines.Add("<A href=\"powerduplicate:" + cp.ID + "\">duplicate this power</A>");
						lines.Add("</TD>");
						lines.Add("</TR>");

						//if (powers[cat].Count > 1)
						//{
						//    int index = powers[cat].IndexOf(cp);
						//    bool up = (index != 0);
						//    bool down = (index != powers[cat].Count - 1);

						//    lines.Add("<TR>");
						//    lines.Add("<TD colspan=3 align=center>");
						//    if (up)
						//        lines.Add("<A href=\"powerup:" + cp.ID + "\">move up</A>");
						//    if (up && down)
						//        lines.Add("|");
						//    if (down)
						//        lines.Add("<A href=\"powerdown:" + cp.ID + "\">move down</A>");
						//    lines.Add("</TD>");
						//    lines.Add("</TR>");
						//}
					}
				}
			}

			#endregion

			#region Tactics

			if ((template.Tactics != "") || (builder))
			{
				string tactics = HTML.Process(template.Tactics, true);

				if (builder)
				{
					if (tactics == "")
						tactics = "no tactics specified";

					tactics = "<A href=build:tactics>" + tactics + "</A>";
				}

				lines.Add("<TR class=shaded>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Tactics</B> " + tactics);
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			#endregion

			#region References

			Library lib = Session.FindLibrary(template);
			if ((lib != null) && (lib.Name != ""))
			{
				if ((Session.Project == null) || (lib != Session.Project.Library))
				{
					string reference = HTML.Process(lib.Name, true);

					lines.Add("<TR class=shaded>");
					lines.Add("<TD colspan=3>");
					lines.Add(reference);
					lines.Add("</TD>");
					lines.Add("</TR>");
				}
			}

			#endregion

			lines.Add("</TABLE>");
			lines.Add("</P>");

			lines.Add("</BODY>");
			lines.Add("</HTML>");

			return Concatenate(lines);
		}

		public static string MagicItem(MagicItem item, DisplaySize size, bool builder, bool wrapper)
		{
			List<string> lines = new List<string>();

			if (wrapper)
			{
				lines.Add("<HTML>");
				lines.AddRange(HTML.GetHead(null, null, size));
			}

			lines.Add("<BODY>");

			if (item != null)
			{
				lines.AddRange(get_magic_item(item, builder));
			}
			else
			{
				lines.Add("<P class=instruction>(no item selected)</P>");
			}

			if (wrapper)
			{
				lines.Add("</BODY>");
				lines.Add("</HTML>");
			}

			return Concatenate(lines);
		}

		public static string Artifact(Artifact artifact, DisplaySize size, bool builder, bool wrapper)
		{
			List<string> lines = new List<string>();

			if (wrapper)
			{
				lines.Add("<HTML>");
				lines.AddRange(HTML.GetHead(null, null, size));
			}

			lines.Add("<BODY>");

			if (artifact != null)
			{
				lines.AddRange(get_artifact(artifact, builder));
			}
			else
			{
				lines.Add("<P class=instruction>(no item selected)</P>");
			}

			if (wrapper)
			{
				lines.Add("</BODY>");
				lines.Add("</HTML>");
			}

			return Concatenate(lines);
		}

		public static string PlotPoint(PlotPoint pp, Plot plot, int party_level, bool links, MainForm.ViewType view,
			DisplaySize size)
		{
			if (Session.Project == null)
				return null;

			List<string> lines = new List<string>();

			lines.Add("<HTML>");
			lines.AddRange(GetHead(null, null, size));
			lines.Add("<BODY>");

			if (pp != null)
			{
				lines.Add("<H3>" + Process(pp.Name, true) + "</H3>");

				switch (pp.State)
				{
					case PlotPointState.Completed:
						lines.Add("<P class=instruction>(completed)</P>");
						break;
					case PlotPointState.Skipped:
						lines.Add("<P class=instruction>(skipped)</P>");
						break;
				}

				#region Options

				if (links)
				{
					List<string> options = new List<string>();

					if (view == MainForm.ViewType.Flowchart)
					{
						options.Add("<A href=\"plot:edit\">Open</A> this plot point.");
					}

					if (pp.Element == null)
					{
						options.Add("Turn this point into a <A href=plot:encounter>combat encounter</A>.");
						options.Add("Turn this point into a <A href=plot:challenge>skill challenge</A>.");
					}

					if (pp.Subplot.Points.Count != 0)
					{
						options.Add("This plot point has a <A href=\"plot:explore\">subplot</A>.");
					}
					else
					{
						options.Add("Create a <A href=\"plot:explore\">subplot</A> for this point.");
					}

					Encounter enc = pp.Element as Encounter;
					if (enc != null)
					{
						options.Add("This plot point contains an <A href=plot:element>encounter</A> (<A href=plot:run>run it</a>).");
					}

					SkillChallenge sc = pp.Element as SkillChallenge;
					if (sc != null)
					{
						options.Add("This plot point contains a <A href=plot:element>skill challenge</A>.");
					}

					TrapElement te = pp.Element as TrapElement;
					if (te != null)
					{
						string type = (te.Trap.Type == TrapType.Trap) ? "trap" : "hazard";
						options.Add("This plot point contains a <A href=plot:element>" + type + "</A>.");
					}

					Map map = null;
					MapArea map_area = null;
					pp.GetTacticalMapArea(ref map, ref map_area);
					if ((map != null) && (map_area != null))
					{
						string name = Process(map_area.Name, true);
						options.Add("This plot point occurs in <A href=plot:maparea>" + name + "</A>.");
					}

					RegionalMap rmap = null;
					MapLocation loc = null;
					pp.GetRegionalMapArea(ref rmap, ref loc, Session.Project);
					if ((rmap != null) && (loc != null))
					{
						string name = Process(loc.Name, true);
						options.Add("This plot point occurs at <A href=plot:maploc>" + name + "</A>.");
					}

					if (options.Count != 0)
					{
						lines.Add("<P class=table>");
						lines.Add("<TABLE>");

						lines.Add("<TR class=heading>");
						lines.Add("<TD><B>Options</B></TD>");
						lines.Add("</TR>");

						for (int index = 0; index != options.Count; ++index)
						{
							lines.Add("<TR>");
							lines.Add("<TD>");
							lines.Add(options[index]);
							lines.Add("</TD>");
							lines.Add("</TR>");
						}

						lines.Add("</TABLE>");
						lines.Add("</P>");
					}
				}

				#endregion

				string readaloud = Process(pp.ReadAloud, false);
				if (readaloud != "")
				{
					//readaloud = fMarkdown.Transform(readaloud);
					readaloud = readaloud.Replace("<p>", "<p class=readaloud>");
					lines.Add(readaloud);
				}

				string details = Process(pp.Details, false);
				if (details != "")
				{
					//details = fMarkdown.Transform(details);
					lines.Add(details);
				}

				if (party_level != Session.Project.Party.Level)
					lines.Add("<P><B>Party level</B>: " + party_level + "</P>");

				if (pp.Date != null)
					lines.Add("<P><B>Date</B>: " + pp.Date + "</P>");

				lines.AddRange(get_map_area_details(pp));

				#region Encyclopedia links

				if (links)
                {
					BinarySearchTree<EncyclopediaEntry> entry_set = new BinarySearchTree<EncyclopediaEntry>();
                    foreach (Guid entry_id in pp.EncyclopediaEntryIDs)
                    {
						EncyclopediaEntry entry = Session.Project.Encyclopedia.FindEntry(entry_id);
                        if (entry != null)
                            entry_set.Add(entry);
                    }

					if (pp.MapLocationID != Guid.Empty)
					{
						EncyclopediaEntry entry = Session.Project.Encyclopedia.FindEntryForAttachment(pp.MapLocationID);
						if (entry != null)
							entry_set.Add(entry);
					}

					if ((pp.Element != null) && (pp.Element is Encounter))
					{
						Encounter enc = pp.Element as Encounter;

						foreach (NPC npc in Session.Project.NPCs)
						{
							EncyclopediaEntry entry = Session.Project.Encyclopedia.FindEntryForAttachment(npc.ID);
							if (entry == null)
								continue;

							if (enc.Contains(npc.ID))
								entry_set.Add(entry);
						}
					}

					List<EncyclopediaEntry> entries = entry_set.SortedList;
                    if (entries.Count != 0)
                    {
                        lines.Add("<P><B>See also</B>:</P>");
                        lines.Add("<UL>");

                        foreach (EncyclopediaEntry entry in entries)
                        {
                            lines.Add("<LI><A href=\"entry:" + entry.ID + "\">" + entry.Name + "</A></LI>");
                        }

                        lines.Add("</UL>");
                    }
                }

				#endregion

				#region Game elements

				if (pp.Element != null)
				{
					Encounter enc = pp.Element as Encounter;
					if (enc != null)
						lines.AddRange(get_encounter(enc));

					TrapElement te = pp.Element as TrapElement;
					if (te != null)
						lines.AddRange(get_trap(te.Trap, null, false, false));

					SkillChallenge sc = pp.Element as SkillChallenge;
					if (sc != null)
						lines.AddRange(get_skill_challenge(sc, links));

					Quest q = pp.Element as Quest;
					if (q != null)
						lines.AddRange(get_quest(q));
				}

				#endregion

				#region Treasure parcels

				if (pp.Parcels.Count != 0)
					lines.AddRange(get_parcels(pp, links));

				#endregion
			}
			else
			{
				PlotPoint parent_point = Session.Project.FindParent(plot);

				string heading = (parent_point != null) ? parent_point.Name : Session.Project.Name;
				lines.Add("<H2>" + Process(heading, true) + "</H2>");

				if (parent_point != null)
				{
					if (parent_point.Date != null)
						lines.Add("<P>" + parent_point.Date + "</P>");

					if (parent_point.Details != "")
						lines.Add("<P>" + Process(parent_point.Details, false) + "</P>");
				}
				else
				{
					if (Session.Project.Author != "")
						lines.Add("<P class=instruction>by " + Session.Project.Author + "</P>");

					int count = Session.Project.Party.Size;
					int level = Session.Project.Party.Level;
					int start_xp = Session.Project.Party.XP;
					int normal_xp = Experience.GetHeroXP(level);

					string str = "<B>" + Process(Session.Project.Name, true) + "</B> is designed for a party of " + count + " characters at level " + level;
					if (start_xp != normal_xp)
						str += ", starting with " + start_xp + " XP";
					str += ".";

					lines.Add("<P>" + str + "</P>");
				}

				#region XP

				int xp = 0;
				List<List<PlotPoint>> layers = Workspace.FindLayers(plot);
				foreach (List<PlotPoint> layer in layers)
					xp += Workspace.GetLayerXP(layer);

				if (xp != 0)
				{
					string xp_str = "XP available: " + xp + ".";

					if (plot == Session.Project.Plot)
					{
						int level_initial = Session.Project.Party.Level;
						int xp_current = Experience.GetHeroXP(level_initial);
						int xp_final = xp_current + (xp / Session.Project.Party.Size);
						int level_final = Experience.GetHeroLevel(xp_final);

						if ((level_final != -1) && (level_final != level_initial))
						{
							xp_str += "<BR>";
							xp_str += "The party will reach level " + level_final + ".";
						}
					}

					lines.Add("<P>" + xp_str + "</P>");
				}

				#endregion

				#region Options

				if (links)
				{
					lines.Add("<P class=table>");
					lines.Add("<TABLE>");

					lines.Add("<TR class=heading>");
					lines.Add("<TD><B>Options</B></TD>");
					lines.Add("</TR>");

					if (view == MainForm.ViewType.Flowchart)
					{
						if (plot.Points.Count == 0)
						{
							lines.Add("<TR>");
							lines.Add("<TD>This plot is empty:</TD>");
							lines.Add("</TR>");

							lines.Add("<TR>");
							lines.Add("<TD class=indent>Add a <A href=\"plot:add\">plot point</A>.</TD>");
							lines.Add("</TR>");

							lines.Add("<TR>");
							lines.Add("<TD class=indent>Add a <A href=\"plot:encounter\">combat encounter</A>.</TD>");
							lines.Add("</TR>");

							lines.Add("<TR>");
							lines.Add("<TD class=indent>Add a <A href=\"plot:challenge\">skill challenge</A>.</TD>");
							lines.Add("</TR>");
						}

						if (parent_point != null)
						{
							lines.Add("<TR>");
							lines.Add("<TD>Move up <A href=\"plot:up\">one plot level</A>.</TD>");
							lines.Add("</TR>");
						}

						List<Guid> tactical_map_ids = plot.FindTacticalMaps();
						if (tactical_map_ids.Count == 0)
						{
							if (Session.Project.Maps.Count == 0)
							{
								lines.Add("<TR>");
								lines.Add("<TD>Create a <A href=\"delveview:build\">tactical map</A> to use as the basis of this plot.</TD>");
								lines.Add("</TR>");
							}
							else
							{
								lines.Add("<TR>");
								lines.Add("<TD>Use a tactical map as the basis of this plot:</TD>");
								lines.Add("</TR>");

								lines.Add("<TR>");
								lines.Add("<TD class=indent>Build a <A href=\"delveview:build\">new map</A>.</TD>");
								lines.Add("</TR>");

								lines.Add("<TR>");
								lines.Add("<TD class=indent>Select an <A href=\"delveview:select\">existing map</A>.</TD>");
								lines.Add("</TR>");
							}
						}
						else if (tactical_map_ids.Count == 1)
						{
							lines.Add("<TR>");
							lines.Add("<TD>Switch to <A href=\"delveview:" + tactical_map_ids[0] + "\">delve view</A>.</TD>");
							lines.Add("</TR>");
						}
						else
						{
							lines.Add("<TR>");
							lines.Add("<TD>Switch to delve view using one of the following maps:</TD>");
							lines.Add("</TR>");

							foreach (Guid map_id in tactical_map_ids)
							{
								if (map_id == Guid.Empty)
									continue;

								Map map = Session.Project.FindTacticalMap(map_id);
								if (map == null)
									continue;

								lines.Add("<TR>");
								lines.Add("<TD class=indent><A href=\"delveview:" + map_id + "\">" + Process(map.Name, true) + "</A></TD>");
								lines.Add("</TR>");
							}

							lines.Add("<TR>");
							lines.Add("<TD class=indent><A href=\"delveview:select\">Select (or create) a map</A></TD>");
							lines.Add("</TR>");
						}

						List<Guid> regional_map_ids = plot.FindRegionalMaps();
						if (regional_map_ids.Count == 0)
						{
							if (Session.Project.RegionalMaps.Count == 0)
							{
								lines.Add("<TR>");
								lines.Add("<TD>Create a <A href=\"mapview:build\">regional map</A> to use as the basis of this plot.</TD>");
								lines.Add("</TR>");
							}
							else
							{
								lines.Add("<TR>");
								lines.Add("<TD>Use a regional map as the basis of this plot:</TD>");
								lines.Add("</TR>");

								lines.Add("<TR>");
								lines.Add("<TD class=indent>Build a <A href=\"mapview:build\">new map</A>.</TD>");
								lines.Add("</TR>");

								lines.Add("<TR>");
								lines.Add("<TD class=indent>Select an <A href=\"mapview:select\">existing map</A>.</TD>");
								lines.Add("</TR>");
							}
						}
						else if (regional_map_ids.Count == 1)
						{
							lines.Add("<TR>");
							lines.Add("<TD>Switch to <A href=\"mapview:" + regional_map_ids[0] + "\">map view</A>.</TD>");
							lines.Add("</TR>");
						}
						else
						{
							lines.Add("<TR>");
							lines.Add("<TD>Switch to map view using one of the following maps:</TD>");
							lines.Add("</TR>");

							foreach (Guid map_id in regional_map_ids)
							{
								if (map_id == Guid.Empty)
									continue;

								RegionalMap map = Session.Project.FindRegionalMap(map_id);
								if (map == null)
									continue;

								lines.Add("<TR>");
								lines.Add("<TD class=indent><A href=\"mapview:" + map_id + "\">" + Process(map.Name, true) + "</A></TD>");
								lines.Add("</TR>");
							}

							lines.Add("<TR>");
							lines.Add("<TD class=indent><A href=\"mapview:select\">Select (or create) a map</A></TD>");
							lines.Add("</TR>");
						}

						if (parent_point == null)
						{
							lines.Add("<TR>");
							lines.Add("<TD>Edit the <A href=\"plot:properties\">project properties</A>.</TD>");
							lines.Add("</TR>");
						}
					}
					else if (view == MainForm.ViewType.Delve)
					{
						lines.Add("<TR>");
						lines.Add("<TD>Switch to <A href=\"delveview:off\">flowchart view</A>.</TD>");
						lines.Add("</TR>");

						lines.Add("<TR>");
						lines.Add("<TD><A href=\"delveview:edit\">Edit this map</A>.</TD>");
						lines.Add("</TR>");

						lines.Add("<TR>");
						lines.Add("<TD>Send this map to the <A href=\"delveview:playerview\">player view</A>.</TD>");
						lines.Add("</TR>");
					}
					else if (view == MainForm.ViewType.Map)
					{
						lines.Add("<TR>");
						lines.Add("<TD>Switch to <A href=\"mapview:off\">flowchart view</A>.</TD>");
						lines.Add("</TR>");

						lines.Add("<TR>");
						lines.Add("<TD><A href=\"mapview:edit\">Edit this map</A>.</TD>");
						lines.Add("</TR>");

						lines.Add("<TR>");
						lines.Add("<TD>Send this map to the <A href=\"mapview:playerview\">player view</A>.</TD>");
						lines.Add("</TR>");
					}

					lines.Add("</TR>");
					lines.Add("</TABLE>");
					lines.Add("</P>");
				}

				#endregion
			}

			lines.Add("</BODY>");
			lines.Add("</HTML>");

			return Concatenate(lines);
		}

		public static string MapArea(MapArea area, DisplaySize size)
		{
			List<string> lines = new List<string>();

			lines.Add("<HTML>");
			lines.AddRange(GetHead(null, null, size));
			lines.Add("<BODY>");

			if (area != null)
			{
				string name = Process(area.Name, true);
				lines.Add("<H3>" + name + "</H3>");

				if (area.Details != "")
				{
					lines.Add("<P>");
					lines.Add(Process(area.Details, true));
					lines.Add("</P>");
				}
				
				lines.Add("<P class=table>");
				lines.Add("<TABLE>");

				lines.Add("<TR class=heading>");
				lines.Add("<TD><B>Options</B></TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("<A href=\"maparea:edit\">View information</A> about this map area.");
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("<A href=\"maparea:create\">Create a plot point</A> here.");
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD class=indent>");
				lines.Add("... containing a <A href=\"maparea:encounter\">combat encounter</A>.");
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD class=indent>");
				lines.Add("... containing a <A href=\"maparea:trap\">trap or hazard</A>.");
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD class=indent>");
				lines.Add("... containing a <A href=\"maparea:challenge\">skill challenge</A>.");
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("</TABLE>");
				lines.Add("</P>");
			}

			return Concatenate(lines);
		}

		public static string MapLocation(MapLocation loc, DisplaySize size)
		{
			List<string> lines = new List<string>();

			lines.Add("<HTML>");
			lines.AddRange(GetHead(null, null, size));
			lines.Add("<BODY>");

			if (loc != null)
			{
				string name = Process(loc.Name, true);
				lines.Add("<H3>" + name + "</H3>");

				lines.Add("<P class=table>");
				lines.Add("<TABLE>");

				lines.Add("<TR class=heading>");
				lines.Add("<TD><B>Options</B></TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("<A href=\"maploc:edit\">View information</A> about this map location.");
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("<A href=\"maploc:create\">Create a plot point</A> here.");
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD class=indent>");
				lines.Add("... containing a <A href=\"maploc:encounter\">combat encounter</A>.");
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD class=indent>");
				lines.Add("... containing a <A href=\"maploc:trap\">trap or hazard</A>.");
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD class=indent>");
				lines.Add("... containing a <A href=\"maploc:challenge\">skill challenge</A>.");
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("</TABLE>");
				lines.Add("</P>");
			}

			return Concatenate(lines);
		}

        public static string EncounterNote(EncounterNote en, DisplaySize size)
        {
            List<string> lines = new List<string>();

            lines.Add("<HTML>");
            lines.AddRange(GetHead(null, null, size));

            lines.Add("<BODY>");
            if (en != null)
            {
                lines.Add("<H3>" + Process(en.Title, true) + "</H3>");

				string str = Process(en.Contents, false);
                if (str != "")
                {
					//str = fMarkdown.Transform(str);
					str = str.Replace("<p>", "<p class=encounter_note>");
                    lines.Add(str);
                }
                else
                {
                    lines.Add("<P class=instruction>" + "This note has no contents." + "</P>");
                    lines.Add("<P class=instruction>" + "Press <A href=\"note:edit\">Edit</A> to add information to this note." + "</P>");
                }
            }
            else
            {
                lines.Add("<P class=instruction>" + "(no note selected)" + "</P>");
            }
            lines.Add("</BODY>");
            lines.Add("</HTML>");

            return Concatenate(lines);
        }

        public static string Background(Background bg, DisplaySize size)
        {
            List<string> lines = new List<string>();

            lines.Add("<HTML>");
            lines.AddRange(GetHead(null, null, size));

            lines.Add("<BODY>");
            if (bg != null)
            {
                string details = Process(bg.Details, false);
                if (details != "")
                {
					//details = fMarkdown.Transform(details);
					details = details.Replace("<p>", "<p class=background>");
                    lines.Add(details);
                }
                else
                {
                    lines.Add("<P class=instruction>" + "Press <A href=\"background:edit\">Edit</A> to add information to this item." + "</P>");
                }
            }
            else
            {
                lines.Add("<P class=instruction>" + "(no background selected)" + "</P>");
            }
            lines.Add("</BODY>");
            lines.Add("</HTML>");

            return Concatenate(lines);
        }

		public static string Background(List<Background> backgrounds, DisplaySize size)
		{
			List<string> lines = new List<string>();

			lines.Add("<HTML>");
			lines.AddRange(GetHead(null, null, size));

			lines.Add("<BODY>");

			foreach (Background bg in backgrounds)
			{
				string title = Process(bg.Title, false);
				string details = Process(bg.Details, false);

				if ((title != "") && (details != ""))
				{
					lines.Add("<H3>" + title + "</H3>");

					//details = fMarkdown.Transform(details);
					details = details.Replace("<p>", "<p class=background>");
					lines.Add(details);
				}
			}

			lines.Add("</BODY>");
			lines.Add("</HTML>");

			return Concatenate(lines);
		}

		public static string EncyclopediaEntry(EncyclopediaEntry entry, Encyclopedia encyclopedia, DisplaySize size,
			bool include_dm_info, bool include_entry_links, bool include_attachment, bool include_picture_links)
		{
			List<string> lines = new List<string>();

			lines.Add("<HTML>");
			lines.AddRange(GetHead(null, null, size));

			lines.Add("<BODY>");
			if (entry != null)
			{
				lines.Add("<H4>" + Process(entry.Name, true) + "</H4>");
				lines.Add("<HR>");
			}
			if (entry != null)
			{
				if ((include_attachment) && (entry.AttachmentID != Guid.Empty))
				{
					MapLocation loc = null;
					foreach (RegionalMap map in Session.Project.RegionalMaps)
					{
						loc = map.FindLocation(entry.AttachmentID);
						if (loc != null)
							break;
					}

					if (loc != null)
					{
						lines.Add("<P class=instruction>" + "<A href=\"map:" + entry.AttachmentID + "\">View location on map</A>." + "</P>");
						lines.Add("<HR>");
					}
				}

				string details = process_encyclopedia_info(entry.Details, encyclopedia, include_entry_links, include_dm_info);
				string dm_info = process_encyclopedia_info(entry.DMInfo, encyclopedia, include_entry_links, include_dm_info);

				if ((details == "") && (dm_info == ""))
					lines.Add("<P class=instruction>" + "Press <A href=\"entry:edit\">Edit</A> to add information to this entry." + "</P>");

				if (details != "")
					lines.Add("<P class=encyclopedia_entry>" + Process(details, false) + "</P>");

				if (include_dm_info && (dm_info != ""))
				{
					lines.Add("<H4>For DMs Only</H4>");
					lines.Add("<P class=encyclopedia_entry>" + Process(dm_info, false) + "</P>");
				}

				if (include_picture_links)
				{
					if (entry.Images.Count != 0)
					{
						lines.Add("<H4>Pictures</H4>");
						lines.Add("<UL>");

						foreach (EncyclopediaImage img in entry.Images)
						{
							lines.Add("<LI>");
							lines.Add("<A href=picture:" + img.ID + ">" + img.Name + "</A>");
							lines.Add("</LI>");
						}

						lines.Add("</UL>");
					}
				}

				if (include_attachment)
				{
					if (entry.AttachmentID != Guid.Empty)
					{
						// PC
						Hero hero = Session.Project.FindHero(entry.AttachmentID);
						if (hero != null)
						{
							lines.AddRange(get_hero(hero, null, false, false));
						}

						// Creature or NPC
						ICreature c = Session.FindCreature(entry.AttachmentID, SearchType.Global);
						if (c != null)
						{
							EncounterCard card = new EncounterCard(c.ID);

							lines.Add("<P class=table>");
							lines.AddRange(card.AsText(null, CardMode.View, true));
							lines.Add("</P>");
						}

						// Player option
						IPlayerOption option = Session.Project.FindPlayerOption(entry.AttachmentID);
						if (option != null)
						{
							lines.AddRange(get_player_option(option));
						}
					}
				}

				if ((include_entry_links) && (encyclopedia != null))
				{
					// Links
					List<EncyclopediaLink> links = new List<EncyclopediaLink>();
					foreach (EncyclopediaLink link in encyclopedia.Links)
					{
						if (link.EntryIDs.Contains(entry.ID))
							links.Add(link);
					}

					if (links.Count != 0)
					{
						lines.Add("<HR>");
						lines.Add("<P><B>See also</B>:</P>");
						lines.Add("<UL>");

						foreach (EncyclopediaLink link in links)
						{
							foreach (Guid entry_id in link.EntryIDs)
							{
								if (entry_id == entry.ID)
									continue;

								EncyclopediaEntry linked_entry = encyclopedia.FindEntry(entry_id);
								lines.Add("<LI><A href=\"entry:" + entry_id + "\">" + Process(linked_entry.Name, true) + "</A></LI>");
							}
						}

						lines.Add("</UL>");
					}

					// Groups
					List<EncyclopediaGroup> groups = new List<EncyclopediaGroup>();
					foreach (EncyclopediaGroup group in encyclopedia.Groups)
					{
						if (group.EntryIDs.Contains(entry.ID))
							groups.Add(group);
					}

					if (groups.Count != 0)
					{
						lines.Add("<HR>");
						lines.Add("<P><B>Groups</B>:</P>");

						foreach (EncyclopediaGroup group in groups)
						{
							lines.Add("<P class=table>");
							lines.Add("<TABLE class=wide>");

							lines.Add("<TR class=shaded align=center>");
							lines.Add("<TD>");
							lines.Add("<B><A href=\"group:" + group.ID + "\">" + Process(group.Name, true) + "</A></B>");
							lines.Add("</TD>");
							lines.Add("</TR>");

							lines.Add("<TR>");
							lines.Add("<TD>");

							List<EncyclopediaEntry> entries = new List<EncyclopediaEntry>();
							foreach (Guid entry_id in group.EntryIDs)
							{
								EncyclopediaEntry ee = encyclopedia.FindEntry(entry_id);
								if (ee == null)
									continue;

								entries.Add(ee);
							}
							entries.Sort();

							foreach (EncyclopediaEntry ee in entries)
							{
								if (ee != entry)
								{
									lines.Add("<A href=\"entry:" + ee.ID + "\">" + Process(ee.Name, true) + "</A>");
								}
								else
								{
									lines.Add("<B>" + Process(ee.Name, true) + "</B>");
								}
							}

							lines.Add("</TD>");
							lines.Add("</TR>");

							lines.Add("</TABLE>");
						}
					}
				}
			}
			else
			{
				lines.Add("<P class=instruction>" + "(no entry selected)" + "</P>");
			}

			lines.Add("</BODY>");
			lines.Add("</HTML>");

			return Concatenate(lines);
		}

		public static string EncyclopediaGroup(EncyclopediaGroup group, Encyclopedia encyclopedia, DisplaySize size,
			bool include_dm_info, bool include_entry_links)
		{
			List<string> lines = new List<string>();

			lines.Add("<HTML>");
			lines.AddRange(GetHead(null, null, size));

			lines.Add("<BODY>");
			if (group != null)
			{
				if (encyclopedia != null)
				{
					// Links
					List<EncyclopediaEntry> links = new List<EncyclopediaEntry>();
					foreach (Guid entry_id in group.EntryIDs)
					{
						EncyclopediaEntry entry = encyclopedia.FindEntry(entry_id);
						if (entry != null)
							links.Add(entry);
					}

					if (links.Count != 0)
					{
						foreach (EncyclopediaEntry entry in links)
						{
							lines.Add("<H3>" + Process(entry.Name, true) + "</H3>");

							string str = process_encyclopedia_info(entry.Details, encyclopedia, include_entry_links, include_dm_info);
							lines.Add("<P class=encyclopedia_entry>" + Process(str, false) + "</P>");
						}
					}
					else
					{
						lines.Add("<P class=instruction>" + "(no entries in group)" + "</P>");
					}
				}
			}
			else
			{
				lines.Add("<P class=instruction>" + "(no group selected)" + "</P>");
			}

			lines.Add("</BODY>");
			lines.Add("</HTML>");

			return Concatenate(lines);
		}

		public static string Handout(List<object> items, DisplaySize size, bool include_dm_info)
		{
			List<string> lines = new List<string>();

			lines.Add("<HTML>");
			lines.AddRange(GetHead(Session.Project.Name, "Handout", size));

			lines.Add("<BODY>");

			if (items.Count != 0)
			{
				foreach (object item in items)
				{
					if (item is Background)
					{
						Background bg = item as Background;

						string details = Process(bg.Details, false);
						//details = fMarkdown.Transform(details);
						details = details.Replace("<p>", "<p class=background>");

						lines.Add("<H3>" + Process(bg.Title, true) + "</H3>");
						lines.Add(details);
					}

					if (item is EncyclopediaEntry)
					{
						EncyclopediaEntry entry = item as EncyclopediaEntry;

						lines.Add("<H3>" + Process(entry.Name, true) + "</H3>");
						string details = process_encyclopedia_info(entry.Details, Session.Project.Encyclopedia, false, include_dm_info);
						lines.Add("<P class=encyclopedia_entry>" + Process(details, false) + "</P>");

						if (include_dm_info && (entry.DMInfo != ""))
						{
							string dm_info = process_encyclopedia_info(entry.DMInfo, Session.Project.Encyclopedia, false, include_dm_info);

							lines.Add("<H4>For DMs Only</H4>");
							lines.Add("<P class=encyclopedia_entry>" + Process(dm_info, false) + "</P>");
						}
					}

					if (item is IPlayerOption)
					{
						IPlayerOption option = item as IPlayerOption;

						lines.Add("<H3>" + Process(option.Name, true) + "</H3>");
						lines.AddRange(get_player_option(option));
					}
				}
			}
			else
			{
				lines.Add("<P class=instruction>" + "(no items selected)" + "</P>");
			}

			lines.Add("</BODY>");
			lines.Add("</HTML>");

			return Concatenate(lines);
		}

		public static string PlayerOption(IPlayerOption option, DisplaySize size)
		{
			List<string> lines = new List<string>();

			lines.Add("<HTML>");
			lines.AddRange(GetHead(null, null, size));

			lines.Add("<BODY>");

			if (option != null)
			{
				lines.AddRange(get_player_option(option));
			}
			else
			{
				lines.Add("<P class=instruction>(no item selected)</P>");
			}

			lines.Add("</BODY>");
			lines.Add("</HTML>");

			return Concatenate(lines);
		}

		public static string PartyBreakdown(DisplaySize size)
		{
			List<string> lines = new List<string>();

			lines.Add("<HTML>");
			lines.AddRange(HTML.GetHead("Party", null, size));

			lines.Add("<BODY>");
			lines.Add("<P class=table>");
			lines.Add("<TABLE>");

			lines.Add("<TR class=heading>");
			lines.Add("<TD colspan=2>");
			lines.Add("<B>Party</B>");
			lines.Add("</TD>");
			lines.Add("</TR>");

			lines.Add("<TR class=shaded>");
			lines.Add("<TD colspan=2>");
			lines.Add("<B>PCs</B>");
			lines.Add("</TD>");
			lines.Add("</TR>");

			Dictionary<HeroRoleType, int> breakdown = new Dictionary<HeroRoleType, int>();
			foreach (HeroRoleType role in Enum.GetValues(typeof(HeroRoleType)))
				breakdown[role] = 0;

			foreach (Hero hero in Session.Project.Heroes)
			{
				string name_str = "<B>" + hero.Name + "</B>";
				if (hero.Player != "")
					name_str += " (" + hero.Player + ")";

				string race_class_str = hero.Race;
				if ((hero.Class != null) && (hero.Class != ""))
					race_class_str += " " + hero.Class;
				if ((hero.ParagonPath != null) && (hero.ParagonPath != ""))
					race_class_str += " / " + hero.ParagonPath;
				if ((hero.EpicDestiny != null) && (hero.EpicDestiny != ""))
					race_class_str += " / " + hero.EpicDestiny;

				lines.Add("<TR>");

				lines.Add("<TD>");
				lines.Add(name_str);
				lines.Add("</TD>");

				lines.Add("<TD>");
				lines.Add(race_class_str);
				lines.Add("</TD>");

				lines.Add("</TR>");

				breakdown[hero.Role] += 1;
			}

			lines.Add("<TR class=shaded>");
			lines.Add("<TD colspan=2>");
			lines.Add("<B>Roles</B>");
			lines.Add("</TD>");
			lines.Add("</TR>");

			foreach (HeroRoleType role in breakdown.Keys)
			{
				lines.Add("<TR>");

				lines.Add("<TD>");
				lines.Add("<B>" + role + "</B>");
				lines.Add("</TD>");

				lines.Add("<TD>");
				lines.Add(breakdown[role].ToString());
				lines.Add("</TD>");

				lines.Add("</TR>");
			}

			lines.Add("</TABLE>");
			lines.Add("</P>");
			lines.Add("</BODY>");

			lines.Add("</HTML>");

			return Concatenate(lines);
		}

		public static string PCs(string secondary, DisplaySize size)
		{
			List<string> lines = new List<string>();

			lines.AddRange(HTML.GetHead(null, null, size));
			lines.Add("<BODY>");

			if (Session.Project != null)
			{
				if (Session.Project.Heroes.Count == 0)
				{
					lines.Add("<P class=instruction>");
					lines.Add("No PC details have been entered; click <A href=\"party:edit\">here</A> to do this now.");
					lines.Add("</P>");

					lines.Add("<P class=instruction>");
					lines.Add("When PCs have been entered, you will see a useful breakdown of their defences, passive skills and known languages here.");
					lines.Add("</P>");
				}
				else
				{
					#region Calculations

					int min_ac = int.MaxValue;
					int min_fort = int.MaxValue;
					int min_ref = int.MaxValue;
					int min_will = int.MaxValue;
					int max_ac = int.MinValue;
					int max_fort = int.MinValue;
					int max_ref = int.MinValue;
					int max_will = int.MinValue;

					int min_perc = int.MaxValue;
					int min_ins = int.MaxValue;
					int max_perc = int.MinValue;
					int max_ins = int.MinValue;

					BinarySearchTree<string> language_bst = new BinarySearchTree<string>();

					foreach (Hero hero in Session.Project.Heroes)
					{
						min_ac = Math.Min(min_ac, hero.AC);
						min_fort = Math.Min(min_fort, hero.Fortitude);
						min_ref = Math.Min(min_ref, hero.Reflex);
						min_will = Math.Min(min_will, hero.Will);
						max_ac = Math.Max(max_ac, hero.AC);
						max_fort = Math.Max(max_fort, hero.Fortitude);
						max_ref = Math.Max(max_ref, hero.Reflex);
						max_will = Math.Max(max_will, hero.Will);

						min_perc = Math.Min(min_perc, hero.PassivePerception);
						min_ins = Math.Min(min_ins, hero.PassiveInsight);
						max_perc = Math.Max(max_perc, hero.PassivePerception);
						max_ins = Math.Max(max_ins, hero.PassiveInsight);

						string langs = hero.Languages;
						langs = langs.Replace(".", "");
						langs = langs.Replace(",", "");
						langs = langs.Replace(";", "");
						langs = langs.Replace(":", "");
						langs = langs.Replace("/", "");

						string[] tokens = langs.Split(null);
						foreach (string token in tokens)
						{
							if (token != "")
								language_bst.Add(token);
						}
					}

					#endregion

					lines.Add("<P class=table>");
					lines.Add("<TABLE class=clear>");
					lines.Add("<TR class=clear>");
					lines.Add("<TD class=clear>");

					lines.Add("<P class=table>");
					lines.Add("<TABLE>");

					lines.Add("<TR class=heading>");
					lines.Add("<TD colspan=3>");
					lines.Add("<B>Party Breakdown</B>");
					lines.Add("</TD>");
					lines.Add("</TR>");

					#region PCs

					lines.Add("<TR class=shaded>");
					lines.Add("<TD colspan=3>");
					lines.Add("<B>The Party</B>");
					lines.Add("</TD>");
					lines.Add("</TR>");

					foreach (Hero hero in Session.Project.Heroes)
					{
						lines.Add("<TR>");
						lines.Add("<TD><A href=show:" + hero.ID + ">" + hero.Name + "</A></TD>");
						lines.Add("<TD colspan=2>" + hero.Info + "</TD>");
						lines.Add("</TR>");
					}

					#endregion

					#region Defences

					lines.Add("<TR class=shaded>");
					lines.Add("<TD colspan=3>");
					lines.Add("<B>Defences</B>");
					lines.Add("</TD>");
					lines.Add("</TR>");

					lines.Add("<TR>");
					lines.Add("<TD><A href=show:ac>Armour Class</A></TD>");
					lines.Add("<TD colspan=2>");
					if (min_ac == max_ac)
						lines.Add(min_ac.ToString());
					else
						lines.Add(min_ac + " - " + max_ac);
					lines.Add("</TD>");
					lines.Add("</TR>");

					lines.Add("<TR>");
					lines.Add("<TD><A href=show:fort>Fortitude</A></TD>");
					lines.Add("<TD colspan=2>");
					if (min_fort == max_fort)
						lines.Add(min_fort.ToString());
					else
						lines.Add(min_fort + " - " + max_fort);
					lines.Add("</TD>");
					lines.Add("</TR>");

					lines.Add("<TR>");
					lines.Add("<TD><A href=show:ref>Reflex</A></TD>");
					lines.Add("<TD colspan=2>");
					if (min_ref == max_ref)
						lines.Add(min_ref.ToString());
					else
						lines.Add(min_ref + " - " + max_ref);
					lines.Add("</TD>");
					lines.Add("</TR>");

					lines.Add("<TR>");
					lines.Add("<TD><A href=show:will>Will</A></TD>");
					lines.Add("<TD colspan=2>");
					if (min_will == max_will)
						lines.Add(min_will.ToString());
					else
						lines.Add(min_will + " - " + max_will);
					lines.Add("</TD>");
					lines.Add("</TR>");

					#endregion

					#region Passive skills

					lines.Add("<TR class=shaded>");
					lines.Add("<TD colspan=3>");
					lines.Add("<B>Passive Skills</B>");
					lines.Add("</TD>");
					lines.Add("</TR>");

					lines.Add("<TR>");
					lines.Add("<TD><A href=show:passiveinsight>Insight</A></TD>");
					lines.Add("<TD colspan=2>");
					if (min_ins == max_ins)
						lines.Add(min_ins.ToString());
					else
						lines.Add(min_ins + " - " + max_ins);
					lines.Add("</TD>");
					lines.Add("</TR>");

					lines.Add("<TR>");
					lines.Add("<TD><A href=show:passiveperception>Perception</A></TD>");
					lines.Add("<TD colspan=2>");
					if (min_perc == max_perc)
						lines.Add(min_perc.ToString());
					else
						lines.Add(min_perc + " - " + max_perc);
					lines.Add("</TD>");
					lines.Add("</TR>");

					#endregion

					#region Trained skills

					//lines.Add("<TR class=shaded>");
					//lines.Add("<TD colspan=3>");
					//lines.Add("<B>Trained Skills</B>");
					//lines.Add("</TD>");
					//lines.Add("</TR>");

					//List<string> skill_names = Skills.GetSkillNames();
					//foreach (string skill in skill_names)
					//{
					//    lines.Add("<TR>");
					//    lines.Add("<TD><A href=show" + skill + ">" + skill + "</A></TD>");
					//    lines.Add("<TD colspan=2>" + "-" + "</TD>");
					//    lines.Add("</TR>");
					//}

					#endregion

					#region Languages

					if (language_bst.Count != 0)
					{
						lines.Add("<TR class=shaded>");
						lines.Add("<TD colspan=3>");
						lines.Add("<B>Known Languages</B>");
						lines.Add("</TD>");
						lines.Add("</TR>");

						List<string> languages = language_bst.SortedList;
						foreach (string language in languages)
						{
							string heroes = "";
							foreach (Hero hero in Session.Project.Heroes)
							{
								if (hero.Languages.Contains(language))
								{
									if (heroes != "")
										heroes += ", ";

									heroes += hero.Name;
								}
							}

							lines.Add("<TR>");
							lines.Add("<TD>" + language + "</TD>");
							lines.Add("<TD colspan=2>" + heroes + "</TD>");
							lines.Add("</TR>");
						}
					}

					#endregion

					lines.Add("</TABLE>");
					lines.Add("</P>");

					lines.Add("</TD>");
					lines.Add("<TD class=clear>");

					#region Secondary table

					if (secondary == "")
					{
						lines.Add("<P class=instruction>");
						lines.Add("Click on a link to the right to show details here");
						lines.Add("</P>");
					}
					else
					{
						Guid id = Guid.Empty;
						try
						{
							id = new Guid(secondary);
						}
						catch
						{
							id = Guid.Empty;
						}

						if (id != Guid.Empty)
						{
							Hero hero = Session.Project.FindHero(id);
							lines.Add(HTML.StatBlock(hero, null, false, false, false, size));
						}
						else
						{
							string title = "";
							Dictionary<int, string> data = new Dictionary<int, string>();

							if (secondary == "ac")
								title = "Armour Class";
							if (secondary == "fort")
								title = "Fortitude";
							if (secondary == "ref")
								title = "Reflex";
							if (secondary == "will")
								title = "Will";
							if (secondary == "passiveinsight")
								title = "Passive Insight";
							if (secondary == "passiveperception")
								title = "Passive Perception";

							foreach (Hero hero in Session.Project.Heroes)
							{
								int value = 0;

								if (secondary == "ac")
									value = hero.AC;
								if (secondary == "fort")
									value = hero.Fortitude;
								if (secondary == "ref")
									value = hero.Reflex;
								if (secondary == "will")
									value = hero.Will;
								if (secondary == "passiveinsight")
									value = hero.PassiveInsight;
								if (secondary == "passiveperception")
									value = hero.PassivePerception;

								string str = "<A href=show:" + hero.ID + ">" + hero.Name + "</A>";
								if (data.ContainsKey(value))
									data[value] += ", " + str;
								else
									data[value] = str;
							}

							lines.Add("<P class=table>");
							lines.Add("<TABLE>");

							lines.Add("<TR class=heading>");
							lines.Add("<TD colspan=3>");
							lines.Add("<B>" + title + "</B>");
							lines.Add("</TD>");
							lines.Add("</TR>");

							List<int> values = new List<int>(data.Keys);
							values.Sort();
							values.Reverse();
							foreach (int value in values)
							{
								lines.Add("<TR>");
								lines.Add("<TD>" + value + "</TD>");
								lines.Add("<TD colspan=2>" + data[value] + "</TD>");
								lines.Add("</TR>");
							}

							lines.Add("</TABLE>");
							lines.Add("</P>");
						}
					}

					#endregion

					lines.Add("</TD>");
					lines.Add("</TR>");
					lines.Add("</TABLE>");
					lines.Add("</P>");
				}
			}
			else
			{
				lines.Add("<P class=instruction>");
				lines.Add("(no project loaded)");
				lines.Add("</P>");
			}

			lines.Add("</BODY>");

			return Concatenate(lines);
		}

		public static string EncounterReportTable(ReportTable table, DisplaySize size)
		{
			List<string> lines = new List<string>();

			lines.AddRange(HTML.GetHead("Encounter Log", "", DisplaySize.Small));
			lines.Add("<BODY>");

			#region Title

			string title = "";
			switch (table.ReportType)
			{
				case ReportType.Time:
					title = "Time Taken";
					break;
				case ReportType.DamageToEnemies:
					title = "Damage (to opponents)";
					break;
				case ReportType.DamageToAllies:
					title = "Damage (to allies)";
					break;
				case ReportType.Movement:
					title = "Movement";
					break;
			}

			switch (table.BreakdownType)
			{
				case BreakdownType.Controller:
					title += " (by controller)";
					break;
				case BreakdownType.Faction:
					title += " (by faction)";
					break;
			}

			lines.Add("<H3>");
			lines.Add(title);
			lines.Add("</H3>");

			#endregion

			lines.Add("<P class=table>");
			lines.Add("<TABLE class=wide>");

			#region Header row

			lines.Add("<TR class=encounterlog>");

			lines.Add("<TD align=center>");
			lines.Add("<B>Combatant</B>");
			lines.Add("</TD>");

			for (int round = 1; round <= table.Rounds; ++round)
			{
				lines.Add("<TD align=right>");
				lines.Add("<B>Round " + round + "</B>");
				lines.Add("</TD>");
			}

			lines.Add("<TD align=right>");
			lines.Add("<B>Total</B>");
			lines.Add("</TD>");

			lines.Add("</TR>");

			#endregion

			#region Combatants

			foreach (ReportRow row in table.Rows)
			{
				lines.Add("<TR>");

				lines.Add("<TD>");
				lines.Add("<B>" + row.Heading + "</B>");
				lines.Add("</TD>");

				for (int round = 0; round <= table.Rounds - 1; ++round)
				{
					lines.Add("<TD align=right>");
					switch (table.ReportType)
					{
						case ReportType.Time:
							{
								TimeSpan ts = new TimeSpan(0, 0, row.Values[round]);
								if (ts.TotalSeconds >= 1)
									lines.Add(get_time(ts));
								else
									lines.Add("-");
							}
							break;
						case ReportType.DamageToEnemies:
						case ReportType.DamageToAllies:
						case ReportType.Movement:
							{
								int value = row.Values[round];
								if (value != 0)
									lines.Add(value.ToString());
								else
									lines.Add("-");
							}
							break;
					}
					lines.Add("</TD>");
				}

				lines.Add("<TD align=right>");
				switch (table.ReportType)
				{
					case ReportType.Time:
						{
							TimeSpan ts = new TimeSpan(0, 0, row.Total);
							if (ts.TotalSeconds >= 1)
								lines.Add(get_time(ts));
							else
								lines.Add("-");
						}
						break;
					case ReportType.DamageToEnemies:
					case ReportType.DamageToAllies:
					case ReportType.Movement:
						{
							int value = row.Total;
							if (value != 0)
								lines.Add(value.ToString());
							else
								lines.Add("-");
						}
						break;
				}
				lines.Add("</TD>");

				lines.Add("</TR>");
			}

			#endregion

			#region Totals

			lines.Add("<TR>");

			lines.Add("<TD>");
			lines.Add("<B>Totals</B>");
			lines.Add("</TD>");

			for (int round = 0; round <= table.Rounds - 1; ++round)
			{
				lines.Add("<TD align=right>");
				switch (table.ReportType)
				{
					case ReportType.Time:
						{
							TimeSpan ts = new TimeSpan(0, 0, table.Rows[round].Total);
							if (ts.TotalSeconds >= 1)
								lines.Add(get_time(ts));
							else
								lines.Add("-");
						}
						break;
					case ReportType.DamageToEnemies:
					case ReportType.DamageToAllies:
					case ReportType.Movement:
						{
							int value = table.Rows[round].Total;
							if (value != 0)
								lines.Add(value.ToString());
							else
								lines.Add("-");
						}
						break;
				}
				lines.Add("</TD>");
			}

			lines.Add("<TD align=right>");
			switch (table.ReportType)
			{
				case ReportType.Time:
					{
						TimeSpan ts = new TimeSpan(0, 0, table.GrandTotal);
						if (ts.TotalSeconds >= 1)
							lines.Add(get_time(ts));
						else
							lines.Add("-");
					}
					break;
				case ReportType.DamageToEnemies:
				case ReportType.DamageToAllies:
				case ReportType.Movement:
					{
						int value = table.GrandTotal;
						if (value != 0)
							lines.Add(value.ToString());
						else
							lines.Add("-");
					}
					break;
			}
			lines.Add("</TD>");

			lines.Add("</TR>");

			#endregion

			lines.Add("</TABLE>");
			lines.Add("</P>");

			lines.Add("</BODY>");
			lines.Add("</HTML>");

			return HTML.Concatenate(lines);
		}

		public static string TerrainPower(TerrainPower tp, DisplaySize size)
		{
			List<string> lines = new List<string>();

			lines.AddRange(HTML.GetHead(null, null, size));
			lines.Add("<BODY>");
			lines.AddRange(get_terrain_power(tp));
			lines.Add("</BODY>");
			lines.Add("</HTML>");

			return Concatenate(lines);
		}

		#endregion

		#region Project

		public bool ExportProject(string filename)
		{
			try
			{
				// Remove extension from main filename
				string dir = FileName.Directory(filename);
				fRelativePath = FileName.Name(filename) + " Files" + Path.DirectorySeparatorChar;
				fFullPath = dir + fRelativePath;

				StreamWriter sw = new StreamWriter(filename);

				List<string> content = get_content();
				foreach (string line in content)
					sw.WriteLine(line);

				sw.Close();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
				return false;
			}

			if ((fPlots.Count != 0) || (fMaps.Keys.Count != 0))
			{
				// Make sure dir exists
				Directory.CreateDirectory(fFullPath);
			}

			// Save each plot image
			foreach (Pair<string, Plot> pair in fPlots)
			{
				try
				{
					Bitmap bmp = Screenshot.Plot(pair.Second, new Size(800, 600));
					string img_filename = get_filename(pair.First, "jpg", true);
					bmp.Save(img_filename, ImageFormat.Jpeg);
				}
				catch (Exception ex)
				{
					LogSystem.Trace(ex);
					return false;
				}
			}

			// Save each map image
			foreach (Guid map_id in fMaps.Keys)
			{
				try
				{
					Map map = Session.Project.FindTacticalMap(map_id);

					foreach (Guid area_id in fMaps[map_id])
					{
						Rectangle view = Rectangle.Empty;
						if (area_id != Guid.Empty)
						{
							MapArea area = map.FindArea(area_id);
							view = area.Region;
						}

						Bitmap bmp = Screenshot.Map(map, view, null, null, null);
						string map_name = get_map_name(map_id, area_id);
						string img_filename = get_filename(map_name, "jpg", true);
						bmp.Save(img_filename, ImageFormat.Jpeg);
					}
				}
				catch (Exception ex)
				{
					LogSystem.Trace(ex);
					return false;
				}
			}

			return true;
		}

		string fRelativePath = "";
		string fFullPath = "";

		List<Pair<string, Plot>> fPlots = new List<Pair<string, Plot>>();
		Dictionary<Guid, List<Guid>> fMaps = new Dictionary<Guid, List<Guid>>();

		#endregion

		#region Common

		public static string Concatenate(List<string> lines)
		{
			string text = "";
			foreach (string line in lines)
			{
				if (text != "")
					text += Environment.NewLine;

				text += line;
			}

			return text;
		}

		public static string Process(string raw_text, bool strip_html)
		{
			List<Pair<string, string>> pairs = new List<Pair<string, string>>();

			pairs.Add(new Pair<string, string>("&", "&amp;"));
			pairs.Add(new Pair<string, string>("Á", "&Aacute;"));
			pairs.Add(new Pair<string, string>("á", "&aacute;"));
			pairs.Add(new Pair<string, string>("À", "&Agrave;"));
			pairs.Add(new Pair<string, string>("Â", "&Acirc;"));
			pairs.Add(new Pair<string, string>("à", "&agrave;"));
			pairs.Add(new Pair<string, string>("Â", "&Acirc;"));
			pairs.Add(new Pair<string, string>("â", "&acirc;"));
			pairs.Add(new Pair<string, string>("Ä", "&Auml;"));
			pairs.Add(new Pair<string, string>("ä", "&auml;"));
			pairs.Add(new Pair<string, string>("Ã", "&Atilde;"));
			pairs.Add(new Pair<string, string>("ã", "&atilde;"));
			pairs.Add(new Pair<string, string>("Å", "&Aring;"));
			pairs.Add(new Pair<string, string>("å", "&aring;"));
			pairs.Add(new Pair<string, string>("Æ", "&Aelig;"));
			pairs.Add(new Pair<string, string>("æ", "&aelig;"));
			pairs.Add(new Pair<string, string>("Ç", "&Ccedil;"));
			pairs.Add(new Pair<string, string>("ç", "&ccedil;"));
			pairs.Add(new Pair<string, string>("Ð", "&Eth;"));
			pairs.Add(new Pair<string, string>("ð", "&eth;"));
			pairs.Add(new Pair<string, string>("É", "&Eacute;"));
			pairs.Add(new Pair<string, string>("é", "&eacute;"));
			pairs.Add(new Pair<string, string>("È", "&Egrave;"));
			pairs.Add(new Pair<string, string>("è", "&egrave;"));
			pairs.Add(new Pair<string, string>("Ê", "&Ecirc;"));
			pairs.Add(new Pair<string, string>("ê", "&ecirc;"));
			pairs.Add(new Pair<string, string>("Ë", "&Euml;"));
			pairs.Add(new Pair<string, string>("ë", "&euml;"));
			pairs.Add(new Pair<string, string>("Í", "&Iacute;"));
			pairs.Add(new Pair<string, string>("í", "&iacute;"));
			pairs.Add(new Pair<string, string>("Ì", "&Igrave;"));
			pairs.Add(new Pair<string, string>("ì", "&igrave;"));
			pairs.Add(new Pair<string, string>("Î", "&Icirc;"));
			pairs.Add(new Pair<string, string>("î", "&icirc;"));
			pairs.Add(new Pair<string, string>("Ï", "&Iuml;"));
			pairs.Add(new Pair<string, string>("ï", "&iuml;"));
			pairs.Add(new Pair<string, string>("Ñ", "&Ntilde;"));
			pairs.Add(new Pair<string, string>("ñ", "&ntilde;"));
			pairs.Add(new Pair<string, string>("Ó", "&Oacute;"));
			pairs.Add(new Pair<string, string>("ó", "&oacute;"));
			pairs.Add(new Pair<string, string>("Ò", "&Ograve;"));
			pairs.Add(new Pair<string, string>("ò", "&ograve;"));
			pairs.Add(new Pair<string, string>("Ô", "&Ocirc;"));
			pairs.Add(new Pair<string, string>("ô", "&ocirc;"));
			pairs.Add(new Pair<string, string>("Ö", "&Ouml;"));
			pairs.Add(new Pair<string, string>("ö", "&ouml;"));
			pairs.Add(new Pair<string, string>("Õ", "&Otilde;"));
			pairs.Add(new Pair<string, string>("õ", "&otilde;"));
			pairs.Add(new Pair<string, string>("Ø", "&Oslash;"));
			pairs.Add(new Pair<string, string>("ø", "&oslash;"));
			pairs.Add(new Pair<string, string>("ß", "&szlig;"));
			pairs.Add(new Pair<string, string>("Þ", "&Thorn;"));
			pairs.Add(new Pair<string, string>("þ", "&thorn;"));
			pairs.Add(new Pair<string, string>("Ú", "&Uacute;"));
			pairs.Add(new Pair<string, string>("ú", "&uacute;"));
			pairs.Add(new Pair<string, string>("Ù", "&Ugrave;"));
			pairs.Add(new Pair<string, string>("ù", "&ugrave;"));
			pairs.Add(new Pair<string, string>("Û", "&Ucirc;"));
			pairs.Add(new Pair<string, string>("û", "&ucirc;"));
			pairs.Add(new Pair<string, string>("Ü", "&Uuml;"));
			pairs.Add(new Pair<string, string>("ü", "&uuml;"));
			pairs.Add(new Pair<string, string>("Ý", "&Yacute;"));
			pairs.Add(new Pair<string, string>("ý", "&yacute;"));
			pairs.Add(new Pair<string, string>("ÿ", "&yuml;"));
			pairs.Add(new Pair<string, string>("©", "&copy;"));
			pairs.Add(new Pair<string, string>("®", "&reg;"));
			pairs.Add(new Pair<string, string>("™", "&trade;"));
			pairs.Add(new Pair<string, string>("€", "&euro;"));
			pairs.Add(new Pair<string, string>("¢", "&cent;"));
			pairs.Add(new Pair<string, string>("£", "&pound;"));
			pairs.Add(new Pair<string, string>("‘", "&lsquo;"));
			pairs.Add(new Pair<string, string>("’", "&rsquo;"));
			pairs.Add(new Pair<string, string>("“", "&ldquo;"));
			pairs.Add(new Pair<string, string>("”", "&rdquo;"));
			pairs.Add(new Pair<string, string>("«", "&laquo;"));
			pairs.Add(new Pair<string, string>("»", "&raquo;"));
			pairs.Add(new Pair<string, string>("—", "&mdash;"));
			pairs.Add(new Pair<string, string>("–", "&ndash;"));
			pairs.Add(new Pair<string, string>("°", "&deg;"));
			pairs.Add(new Pair<string, string>("±", "&plusmn;"));
			pairs.Add(new Pair<string, string>("¼", "&frac14;"));
			pairs.Add(new Pair<string, string>("½", "&frac12;"));
			pairs.Add(new Pair<string, string>("¾", "&frac34;"));
			pairs.Add(new Pair<string, string>("×", "&times;"));
			pairs.Add(new Pair<string, string>("÷", "&divide;"));
			pairs.Add(new Pair<string, string>("α", "&alpha;"));
			pairs.Add(new Pair<string, string>("β", "&beta;"));
			pairs.Add(new Pair<string, string>("∞", "&infin;"));

			if (strip_html)
			{
				pairs.Add(new Pair<string, string>("\"", "&quot;"));

				pairs.Add(new Pair<string, string>("<", "&lt;"));
				pairs.Add(new Pair<string, string>(">", "&gt;"));
			}

			//pairs.Add(new Pair<string, string>("\n", "\n<BR>\n"));

			string html = raw_text;
			foreach (Pair<string, string> pair in pairs)
				html = html.Replace(pair.First, pair.Second);

			return html;
		}

		public static List<string> GetHead(string title, string description, DisplaySize size)
		{
			List<string> lines = new List<string>();

			lines.Add("<HEAD>");

			if (title != null)
				lines.Add(wrap(title, "title"));

			if (description != null)
				lines.Add("<META name=\"Description\" content=\"" + description + "\">");

			lines.Add("<META name=\"Generator\" content=\"Masterplan\">");
			lines.Add("<META name=\"Originator\" content=\"Masterplan\">");

			lines.AddRange(GetStyle(size));

			lines.Add("</HEAD>");

			return lines;
		}

		static Dictionary<DisplaySize, List<string>> fStyles = new Dictionary<DisplaySize,List<string>>();
		public static List<string> GetStyle(DisplaySize size)
		{
			if (fStyles.ContainsKey(size))
				return fStyles[size];

			#region Sizes

			Dictionary<int, int> pt_sizes = new Dictionary<int, int>();
			switch (size)
			{
				case DisplaySize.Small:
					pt_sizes[8] = 8;
					pt_sizes[9] = 9;
					pt_sizes[12] = 12;
					pt_sizes[16] = 16;
					pt_sizes[24] = 24;
					break;
				case DisplaySize.Medium:
					pt_sizes[8] = 16;
					pt_sizes[9] = 18;
					pt_sizes[12] = 24;
					pt_sizes[16] = 32;
					pt_sizes[24] = 48;
					break;
				case DisplaySize.Large:
					pt_sizes[8] = 25;
					pt_sizes[9] = 30;
					pt_sizes[12] = 40;
					pt_sizes[16] = 50;
					pt_sizes[24] = 72;
					break;
			}

			Dictionary<int, int> px_sizes = new Dictionary<int, int>();
			switch (size)
			{
				case DisplaySize.Small:
					px_sizes[15] = 15;
					px_sizes[300] = 300;
					break;
				case DisplaySize.Medium:
					px_sizes[15] = 30;
					px_sizes[300] = 600;
					break;
				case DisplaySize.Large:
					px_sizes[15] = 45;
					px_sizes[300] = 1000;
					break;
			}

			#endregion

			List<string> lines = new List<string>();

			lines.Add("<STYLE type=\"text/css\">");

			#region External

			bool loaded = false;
			Assembly ass = Assembly.GetEntryAssembly();
			if (ass != null)
			{
				string external_style_file = Utils.FileName.Directory(ass.Location) + "Style." + size + ".css";
				if (File.Exists(external_style_file))
				{
					string[] file_lines = File.ReadAllLines(external_style_file);
					lines.AddRange(file_lines);

					loaded = true;
				}
			}

			#endregion

			if (!loaded)
			{
				lines.Add("body                 { font-family: Arial; font-size: " + pt_sizes[9] + "pt }");
				lines.Add("h1, h2, h3, h4       { color: #000060 }");
				lines.Add("h1                   { font-size: " + pt_sizes[24] + "pt; font-weight: bold; text-align: center }");
				lines.Add("h2                   { font-size: " + pt_sizes[16] + "pt; font-weight: bold; text-align: center }");
				lines.Add("h3                   { font-size: " + pt_sizes[12] + "pt }");
				lines.Add("h4                   { font-size: " + pt_sizes[9] + "pt }");
				lines.Add("p                    { }");
				lines.Add("p.instruction        { color: #666666; text-align: center; font-size: " + pt_sizes[8] + "pt }");
				lines.Add("p.description        { }");
				lines.Add("p.signature          { color: #666666; text-align: center }");
				lines.Add("p.readaloud          { padding-left: " + px_sizes[15] + "px; padding-right: " + px_sizes[15] + "px; font-style: italic }");
				lines.Add("p.background         { }");
				lines.Add("p.encounter_note     { }");
				lines.Add("p.encyclopedia_entry { }");
				lines.Add("p.note               { }");
				lines.Add("p.table              { text-align: center }");
				lines.Add("p.figure             { text-align: center }");
				lines.Add("table                { font-size: " + pt_sizes[8] + "pt; border-color: #BBBBBB; border-style: solid; border-width: 1px; border-collapse: collapse; table-layout: fixed; width: " + px_sizes[300] + "px }");
				lines.Add("table.clear          { border-style: none; table-layout: fixed; width: 99% }");
				lines.Add("table.wide           { width: 99% }");
				lines.Add("table.initiative     { table-layout: auto; border-style: none; width=99% }");
				lines.Add("tr                   { background-color: #E1E7C5 }");
				lines.Add("tr.clear             { background-color: #FFFFFF }");
				lines.Add("tr.heading           { background-color: #143D5F; color: #FFFFFF }");
				lines.Add("tr.trap              { background-color: #5B1F34; color: #FFFFFF }");
				lines.Add("tr.template          { background-color: #5B1F34; color: #FFFFFF }");
				lines.Add("tr.creature          { background-color: #364F27; color: #FFFFFF }");
				lines.Add("tr.hero              { background-color: #143D5F; color: #FFFFFF }");
				lines.Add("tr.item              { background-color: #D06015; color: #FFFFFF }");
				lines.Add("tr.artifact          { background-color: #5B1F34; color: #FFFFFF }");
				lines.Add("tr.encounterlog      { background-color: #303030; color: #FFFFFF }");
				lines.Add("tr.shaded            { background-color: #9FA48D }");
				lines.Add("tr.dimmed            { color: #666666; text-decoration: line-through }");
				lines.Add("tr.shaded_dimmed     { background-color: #9FA48D; color: #666666 }");
				lines.Add("tr.atwill            { background-color: #238E23; color: #FFFFFF }");
				lines.Add("tr.encounter         { background-color: #8B0000; color: #FFFFFF }");
				lines.Add("tr.daily             { background-color: #000000; color: #FFFFFF }");
				lines.Add("tr.warning           { background-color: #E5A0A0; color: #000000; text-align: center }");
				lines.Add("td                   { padding-top: 2px; padding-bottom: 2px; vertical-align: top }");
				lines.Add("td.clear             { vertical-align: top }");
				lines.Add("td.indent            { padding-left: " + px_sizes[15] + "px }");
				lines.Add("td.readaloud         { font-style: italic }");
				lines.Add("td.dimmed            { color: #666666 }");
				lines.Add("td.pvlogentry        { color: lightgrey; background-color: #000000 }");
				lines.Add("td.pvlogindent       { color: #FFFFFF; background-color: #000000; padding-left: " + px_sizes[15] + "px }");
				lines.Add("ul, ol               { font-size: " + pt_sizes[8] + "pt }");
				lines.Add("a                    { text-decoration: none }");
				lines.Add("a:link               { color: #0000C0 }");
				lines.Add("a:visited            { color: #0000C0 }");
				lines.Add("a:active             { color: #FF0000 }");
				lines.Add("a.missing            { color: #FF0000 }");
				lines.Add("a:hover              { text-decoration: underline }");
			}

			lines.Add("</STYLE>");

			fStyles[size] = lines;
			return lines;
		}

		#endregion

		#region Methods

		static string wrap(string content, string tag)
		{
			string on = "<" + tag.ToUpper() + ">";
			string off = "</" + tag.ToUpper() + ">";

			return on + content + off;
		}

		List<string> get_content()
		{
			List<string> lines = new List<string>();

			string desc = Session.Project.Name + ": " + get_description();

			lines.Add("<HTML>");
			lines.AddRange(GetHead(Session.Project.Name, desc, DisplaySize.Small));
			lines.AddRange(get_body());
			lines.Add("</HTML>");

			return lines;
		}

		List<string> get_body()
		{
			List<string> lines = new List<string>();

			lines.Add("<BODY>");

			lines.Add("<H1>" + Session.Project.Name + "</H1>");
			lines.Add("<P class=description>" + get_description() + "</P>");
			if (Session.Project.Author != "")
				lines.Add("<P class=description>" + "By " + Process(Session.Project.Author, true) + "</P>");

			if (Session.Project.Backgrounds.Count != 0)
			{
				lines.AddRange(get_backgrounds());
			}

			if (Session.Project.Plot.Points.Count != 0)
			{
				lines.Add("<HR>");
				lines.AddRange(get_full_plot());
			}

			if (Session.Project.NPCs.Count != 0)
			{
				lines.Add("<HR>");
				lines.AddRange(get_npcs());
			}

			if (Session.Project.Encyclopedia.Entries.Count != 0)
			{
				lines.Add("<HR>");
				lines.AddRange(get_encyclopedia());
			}

			if (Session.Project.Notes.Count != 0)
			{
				lines.Add("<HR>");
				lines.AddRange(get_notes());
			}

			lines.Add("<HR>");
			lines.Add("<P class=signature>Designed using <B>Masterplan</B></P>");

			lines.Add("</BODY>");

			return lines;
		}

		List<string> get_backgrounds()
		{
			List<string> lines = new List<string>();

			foreach (Background bg in Session.Project.Backgrounds)
			{
				if (bg.Details == "")
					continue;

				lines.Add(wrap(Process(bg.Title, true), "h3"));
				lines.Add("<P class=background>" + Process(bg.Details, false) + "</P>");
			}

			return lines;
		}

		List<string> get_full_plot()
		{
			List<string> lines = new List<string>();

			lines.Add(wrap(Process(Session.Project.Name, true), "h2"));
			lines.AddRange(get_plot(Session.Project.Name, Session.Project.Plot));

			return lines;
		}

		List<string> get_npcs()
		{
			List<string> lines = new List<string>();

			lines.Add(wrap("Encyclopedia", "h2"));

			foreach (NPC npc in Session.Project.NPCs)
			{
				lines.Add(wrap(Process(npc.Name, true), "h3"));

				string details = Process(npc.Details, true);
				if (details != "")
					lines.Add("<P>" + details + "</P>");

				lines.Add("<P class=table>");
				EncounterCard card = new EncounterCard();
				card.CreatureID = npc.ID;
				lines.AddRange(card.AsText(null, CardMode.View, true));
				lines.Add("</P>");
			}

			return lines;
		}

		List<string> get_encyclopedia()
		{
			List<string> lines = new List<string>();

			lines.Add(wrap("Encyclopedia", "h2"));

			foreach (EncyclopediaEntry e in Session.Project.Encyclopedia.Entries)
			{
				lines.Add(wrap(Process(e.Name, true), "h3"));
				lines.Add("<P class=encyclopedia_entry>" + Process(e.Details, false) + "</P>");
			}

			return lines;
		}

		static string process_encyclopedia_info(string details, Encyclopedia encyclopedia, bool include_entry_links, bool include_dm_info)
		{
			while (true)
			{
				string marker = "[[DM]]";

				int start_index = details.IndexOf(marker);
				if (start_index == -1)
					break;

				int end_index = details.IndexOf(marker, start_index + marker.Length);
				if (end_index == -1)
					break;

				int middle_start = start_index + marker.Length;
				string dm_info = details.Substring(middle_start, end_index - middle_start);

				if (include_dm_info)
				{
					details = details.Substring(0, start_index) + "<B>" + dm_info + "</B>" + details.Substring(end_index + marker.Length);
				}
				else
				{
					details = details.Substring(0, start_index) + details.Substring(end_index + marker.Length);
				}
			}

			while (true)
			{
				string start = "[[";
				string end = "]]";

				int start_index = details.IndexOf(start);
				if (start_index == -1)
					break;

				int end_index = details.IndexOf(end, start_index + start.Length);
				if (end_index == -1)
					break;

				int middle_start = start_index + start.Length;
				string middle = details.Substring(middle_start, end_index - middle_start);

				string entry_name = middle;
				string display_text = middle;

				if (middle.Contains("|"))
				{
					int index = middle.IndexOf("|");

					entry_name = middle.Substring(0, index);
					display_text = middle.Substring(index + 1);

					display_text = display_text.Trim();
				}

				string link = "";
				if (include_entry_links)
				{
					EncyclopediaEntry ee = encyclopedia.FindEntry(entry_name);
					if (ee == null)
					{
						link = "<A class=\"missing\" href=\"missing:" + entry_name + "\" title=\"Create entry '" + entry_name + "'\">" + display_text + "</A>";
					}
					else
					{
						link = "<A href=\"entry:" + ee.ID + "\" title=\"" + ee.Name + "\">" + display_text + "</A>";
					}
				}
				else
				{
					link = display_text;
				}

				details = details.Substring(0, start_index) + link + details.Substring(end_index + end.Length);
			}

			//details = fMarkdown.Transform(details);
			details = details.Replace("<p>", "<p class=encyclopedia_entry>");

			return details;
		}

		List<string> get_notes()
		{
			List<string> lines = new List<string>();

			lines.Add(wrap("Notes", "h2"));

			foreach (Note n in Session.Project.Notes)
				lines.Add("<P class=note>" + Process(n.Content, true) + "</P>");

			return lines;
		}

		string get_description()
		{
			return "An adventure for " + Session.Project.Party.Size + " characters of level " + Session.Project.Party.Level + ".";
		}

		List<string> get_plot(string plot_name, Plot p)
		{
			List<string> lines = new List<string>();

			if (p.Points.Count > 1)
			{
				// Plot flowchart image
				fPlots.Add(new Pair<string, Plot>(plot_name, p));
				string plot_file = get_filename(plot_name, "jpg", false);
				lines.Add("<P class=figure><A href=\"" + plot_file + "\"><IMG src=\"" + plot_file + "\" alt=\"" + Process(plot_name, true) + "\" height=200></A></P>");
			}

			List<List<PlotPoint>> layers = Workspace.FindLayers(p);
			foreach (List<PlotPoint> layer in layers)
				foreach (PlotPoint pp in layer)
					lines.AddRange(get_plot_point(pp));

			return lines;
		}

		List<string> get_plot_point(PlotPoint pp)
		{
			List<string> lines = new List<string>();

			lines.Add(wrap(Process(pp.Name, true), "h3"));

			if (pp.ReadAloud != "")
				lines.Add("<P class=readaloud>" + Process(pp.ReadAloud, false) + "</P>");

			if (pp.Details != "")
				lines.Add("<P>" + Process(pp.Details, false) + "</P>");

			if (pp.Date != null)
				lines.Add("<P>Date: " + pp.Date + "</P>");

			Encounter enc = pp.Element as Encounter;
			if (enc != null)
			{
				lines.AddRange(get_encounter(enc));

				// Encounter map
				if (enc.MapID != Guid.Empty)
				{
					add_map(enc.MapID, enc.MapAreaID);

					string map_name = get_map_name(enc.MapID, enc.MapAreaID);
					string map_file = get_filename(map_name, "jpg", false);
					lines.Add("<P class=figure><A href=\"" + map_file + "\"><IMG src=\"" + map_file + "\" alt=\"" + Process(pp.Name, true) + "\" height=200></A></P>");
				}
			}

			TrapElement te = pp.Element as TrapElement;
			if (te != null)
				lines.AddRange(get_trap(te.Trap, null, false, false));

			SkillChallenge sc = pp.Element as SkillChallenge;
			if (sc != null)
				lines.AddRange(get_skill_challenge(sc, false));

			Quest q = pp.Element as Quest;
			if (q != null)
				lines.AddRange(get_quest(q));

			MapElement m = pp.Element as MapElement;
			if (m != null)
			{
				if (m.MapID != Guid.Empty)
				{
					add_map(m.MapID, m.MapAreaID);

					string map_name = get_map_name(m.MapID, m.MapAreaID);
					string map_file = get_filename(map_name, "jpg", false);
					lines.Add("<P class=figure><A href=\"" + map_file + "\"><IMG src=\"" + map_file + "\" alt=\"" + Process(map_name, true) + "\" height=200></A></P>");
				}
			}

			if (pp.Parcels.Count != 0)
				lines.AddRange(get_parcels(pp, false));

			if (pp.Subplot.Points.Count != 0)
			{
				lines.Add("<BLOCKQUOTE>");
				lines.AddRange(get_plot(pp.Name, pp.Subplot));
				lines.Add("</BLOCKQUOTE>");
			}

			return lines;
		}

		static List<string> get_map_area_details(PlotPoint pp)
		{
			List<string> lines = new List<string>();

			Map map = null;
			MapArea map_area = null;
			pp.GetTacticalMapArea(ref map, ref map_area);

			if ((map != null) && (map_area != null) && (map_area.Details != ""))
			{
				lines.Add("<P><B>" + Process(map_area.Name, true) + "</B>:</P>");
				lines.Add("<P>" + Process(map_area.Details, true) + "</P>");
			}

			return lines;
		}

		static List<string> get_encounter(Encounter enc)
		{
			List<string> lines = new List<string>();

			lines.Add("<P class=table>");
			lines.Add("<TABLE>");

			lines.Add("<TR class=heading>");
			lines.Add("<TD colspan=2>");
			lines.Add("<B>Encounter</B>");
			lines.Add("</TD>");
			lines.Add("<TD>");
			lines.Add(enc.GetXP() + " XP");
			lines.Add("</TD>");
			lines.Add("</TR>");

			lines.Add("<TR>");
			lines.Add("<TD colspan=3>");
			lines.Add("<B>Level</B> " + enc.GetLevel(Session.Project.Party.Size));
			lines.Add("</TD>");
			lines.Add("</TR>");

			if (enc.Slots.Count != 0)
			{
				lines.Add("<TR class=shaded>");
				lines.Add("<TD colspan=2>");
				lines.Add("<B>Combatants</B>");
				lines.Add("</TD>");
				lines.Add("<TD>");
				lines.Add("<B>" + enc.Count + "</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				foreach (EncounterSlot slot in enc.Slots)
				{
					lines.Add("<TR>");

					lines.Add("<TD colspan=2>");
					lines.Add(slot.Card.Title);
					lines.Add("</TD>");

					lines.Add("<TD>");
					if (slot.CombatData.Count > 1)
						lines.Add("x" + slot.CombatData.Count);
					lines.Add("</TD>");

					lines.Add("</TR>");
				}
			}

			foreach (EncounterWave ew in enc.Waves)
			{
				if (ew.Count == 0)
					continue;

				lines.Add("<TR class=shaded>");
				lines.Add("<TD colspan=2>");
				lines.Add("<B>" + ew.Name + "</B>");
				lines.Add("</TD>");
				lines.Add("<TD>");
				lines.Add("<B>" + ew.Count + "</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				foreach (EncounterSlot slot in ew.Slots)
				{
					lines.Add("<TR>");

					lines.Add("<TD colspan=2>");
					lines.Add(slot.Card.Title);
					lines.Add("</TD>");

					lines.Add("<TD>");
					if (slot.CombatData.Count > 1)
						lines.Add("x" + slot.CombatData.Count);
					lines.Add("</TD>");

					lines.Add("</TR>");
				}
			}

			if (enc.Traps.Count != 0)
			{
				lines.Add("<TR class=shaded>");
				lines.Add("<TD colspan=2>");
				lines.Add("<B>Traps / Hazards</B>");
				lines.Add("</TD>");
				lines.Add("<TD>");
				lines.Add("<B>" + enc.Traps.Count + "</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				foreach (Trap trap in enc.Traps)
				{
					lines.Add("<TR>");

					lines.Add("<TD colspan=3>");
					lines.Add(HTML.Process(trap.Name, true));
					lines.Add("</TD>");

					lines.Add("</TR>");
				}
			}

			if (enc.SkillChallenges.Count != 0)
			{
				lines.Add("<TR class=shaded>");
				lines.Add("<TD colspan=2>");
				lines.Add("<B>Skill Challenges</B>");
				lines.Add("</TD>");
				lines.Add("<TD>");
				lines.Add("<B>" + enc.SkillChallenges.Count + "</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				foreach (SkillChallenge sc in enc.SkillChallenges)
				{
					lines.Add("<TR>");

					lines.Add("<TD colspan=3>");
					lines.Add(HTML.Process(sc.Name, true));
					lines.Add("</TD>");

					lines.Add("</TR>");
				}
			}

			lines.Add("</TABLE>");
			lines.Add("</P>");

            foreach (EncounterNote note in enc.Notes)
            {
                if (note.Contents == "")
                    continue;

				lines.Add("<P class=encounter_note>");
				lines.Add("<B>" + Process(note.Title, true) + "</B>");
				lines.Add("</P>");

				lines.Add("<P class=encounter_note>");
				lines.Add(Process(note.Contents, false));
				lines.Add("</P>");
			}

			// Opponent stats
			List<string> shown = new List<string>();
			foreach (EncounterSlot slot in enc.AllSlots)
			{
				if (shown.Contains(slot.Card.Title))
					continue;

				lines.Add("<P class=table>");
				lines.AddRange(slot.Card.AsText(null, CardMode.View, true));
				lines.Add("</P>");

				shown.Add(slot.Card.Title);
			}

			foreach (Trap trap in enc.Traps)
			{
				lines.AddRange(get_trap(trap, null, false, false));
			}

			foreach (SkillChallenge sc in enc.SkillChallenges)
			{
				lines.AddRange(get_skill_challenge(sc, false));
			}

            foreach (CustomToken ct in enc.CustomTokens)
            {
                if (ct.Type == CustomTokenType.Token)
                    continue;

                lines.AddRange(get_custom_token(ct));
            }

			return lines;
		}

		static List<string> get_trap(Trap trap, CombatData cd, bool initiative_holder, bool builder)
		{
			List<string> lines = new List<string>();

			if (initiative_holder)
			{
				lines.Add("<P class=table>");
				lines.Add("<TABLE>");

				lines.Add("<TR class=heading>");
				lines.Add("<TD>");
				lines.Add("<B>Information</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add(HTML.Process(trap.Name, true) + " is the current initiative holder");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			lines.Add("<P class=table>");
			lines.Add("<TABLE>");

			lines.Add("<TR class=trap>");
			lines.Add("<TD colspan=2>");
			lines.Add("<B>" + HTML.Process(trap.Name, true) + "</B>");
			lines.Add("<BR>");
			lines.Add(HTML.Process(trap.Info, true));
			lines.Add("</TD>");
			lines.Add("<TD>");
			lines.Add(trap.XP + " XP");
			lines.Add("</TD>");
			lines.Add("</TR>");

			if (builder)
			{
				lines.Add("<TR class=trap>");
				lines.Add("<TD colspan=3 align=center>");
				lines.Add("<A href=build:profile style=\"color:white\">(click here to edit this top section)</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			if (builder)
			{
				lines.Add("<TR>");
				lines.Add("<TD colspan=3 align=center>");

				lines.Add("<A href=build:addskill>add a skill</A>");
				lines.Add("|");
				lines.Add("<A href=build:addattack>add an attack</A>");
				lines.Add("|");
				lines.Add("<A href=build:addcm>add a countermeasure</A>");

				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			#region Read-aloud, description, details

			string readaloud = HTML.Process(trap.ReadAloud, true);
			if (builder)
			{
				if (readaloud == "")
					readaloud = "<A href=build:readaloud>Click here to enter read-aloud text</A>";
				else
					readaloud += " <A href=build:readaloud>(edit)</A>";
			}
			if (readaloud != "")
			{
				lines.Add("<TR class=shaded>");
				lines.Add("<TD class=readaloud colspan=3>");
				lines.Add(readaloud);
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			string desc = HTML.Process(trap.Description, true);
			if (builder)
			{
				if (desc == "")
					desc = "<A href=build:desc>Click here to enter a description</A>";
				else
					desc += " <A href=build:desc>(edit)</A>";
			}
			if (desc != "")
			{
				lines.Add("<TR class=shaded>");
				lines.Add("<TD colspan=3>");
				lines.Add(desc);
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			string details = HTML.Process(trap.Details, true);
			if (builder)
			{
				if (details == "")
					details = "<A href=build:details>(no trap details entered)</A>";
				else
					details += " <A href=build:details>(edit)</A>";
			}
			if (details != "")
			{
				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>" + trap.Type + "</B>: ");
				lines.Add(details);
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			#endregion

			#region Skills

			List<string> skillnames = new List<string>();
			Dictionary<string, List<TrapSkillData>> skills = new Dictionary<string, List<TrapSkillData>>();
			foreach (TrapSkillData tsd in trap.Skills)
			{
				if (tsd.Details == "")
					continue;

				if ((tsd.SkillName != "Perception") && (!skillnames.Contains(tsd.SkillName)))
					skillnames.Add(tsd.SkillName);

				if (!skills.ContainsKey(tsd.SkillName))
					skills[tsd.SkillName] = new List<TrapSkillData>();

				skills[tsd.SkillName].Add(tsd);
			}

			skillnames.Sort();
			if (skills.ContainsKey("Perception"))
				skillnames.Insert(0, "Perception");

			foreach (string skillname in skillnames)
			{
				List<TrapSkillData> data = skills[skillname];
				data.Sort();

				lines.Add("<TR class=shaded>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>" + HTML.Process(skillname, true) + "</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				foreach (TrapSkillData tsd in data)
				{
					lines.Add("<TR>");
					lines.Add("<TD colspan=3>");
					if (tsd.DC != 0)
						lines.Add("<B>DC " + tsd.DC + "</B>:");
					lines.Add(HTML.Process(tsd.Details, true));
					if (builder)
						lines.Add("(<A href=skill:" + tsd.ID + ">edit</A> | <A href=skillremove:" + tsd.ID + ">remove</A>)");
					lines.Add("</TD>");
					lines.Add("</TR>");
				}
			}

			#endregion

			#region Initiative

			if (trap.Initiative != int.MinValue)
			{
				string init_str = trap.Initiative.ToString();
				if (trap.Initiative >= 0)
					init_str = "+" + init_str;

				if (cd != null)
					init_str = cd.Initiative + " (" + init_str + ")";

				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Initiative</B>:");
				if (builder)
					lines.Add("<A href=build:profile>");
				if (cd != null)
					lines.Add("<A href=init:" + cd.ID + ">");
				lines.Add(init_str);
				if (cd != null)
					lines.Add("</A>");
				if (builder)
					lines.Add("</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}
			else if (builder)
			{
				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Initiative</B>: <A href=build:profile>The trap does not roll initiative</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			#endregion

			#region Trigger

			if (trap.Trigger != "")
			{
				lines.Add("<TR class=shaded>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Trigger</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				if (builder)
					lines.Add("<A href=build:trigger>");
				lines.Add(HTML.Process(trap.Trigger, true));
				if (builder)
					lines.Add("</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}
			else if (builder)
			{
				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Trigger</B>: <A href=build:trigger>Set trigger</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			#endregion

			foreach (TrapAttack ta in trap.Attacks)
				lines.AddRange(get_trap_attack(ta, cd != null, builder));

			#region Countermeasures

			if (trap.Countermeasures.Count != 0)
			{
				lines.Add("<TR class=shaded>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Countermeasures</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				for (int index = 0; index != trap.Countermeasures.Count; ++index)
				{
					string cm = trap.Countermeasures[index];

					lines.Add("<TR>");
					lines.Add("<TD colspan=3>");
					if (builder)
						lines.Add("<A href=cm:" + index + ">");
					lines.Add(HTML.Process(cm, true));
					if (builder)
						lines.Add("</A>");
					lines.Add("</TD>");
					lines.Add("</TR>");
				}
			}

			#endregion

			Trap t = Session.FindTrap(trap.ID, SearchType.External);
			if (t != null)
			{
				Library lib = Session.FindLibrary(t);
				if (lib != null)
				{
					lines.Add("<TR class=shaded>");
					lines.Add("<TD colspan=3>");
					lines.Add(HTML.Process(lib.Name, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}
			}

			lines.Add("</TABLE>");
			lines.Add("</P>");

			return lines;
		}

		static List<string> get_trap_attack(TrapAttack trap_attack, bool links, bool builder)
		{
			List<string> lines = new List<string>();

			string name = trap_attack.Name;
			if (name == "")
				name = "Attack";
			lines.Add("<TR class=shaded>");
			lines.Add("<TD colspan=3>");
			lines.Add("<B>" + name + "</B>");
			if (builder)
			{
				lines.Add("<A href=attackaction:" + trap_attack.ID + ">");
				lines.Add("(edit)");
				lines.Add("</A>");

				lines.Add("<A href=attackremove:" + trap_attack.ID + ">");
				lines.Add("(remove)");
				lines.Add("</A>");
			}
			lines.Add("</TD>");
			lines.Add("</TR>");

			lines.Add("<TR>");
			lines.Add("<TD colspan=3>");
			lines.Add("<B>Action</B>:");
			if (builder)
				lines.Add("<A href=attackaction:" + trap_attack.ID + ">");
			lines.Add(trap_attack.Action.ToString().ToLower());
			if (builder)
				lines.Add("</A>");
			lines.Add("</TD>");
			lines.Add("</TR>");

			if (trap_attack.Range != "")
			{
				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Range</B>:");
				if (builder)
					lines.Add("<A href=attackaction:" + trap_attack.ID + ">");
				lines.Add(HTML.Process(trap_attack.Range, true));
				if (builder)
					lines.Add("</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}
			else if (builder)
			{
				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Range</B>: <A href=attackaction:" + trap_attack.ID + ">Set range</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			if (trap_attack.Target != "")
			{
				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Target</B>:");
				if (builder)
					lines.Add("<A href=attackaction:" + trap_attack.ID + ">");
				lines.Add(HTML.Process(trap_attack.Target, true));
				if (builder)
					lines.Add("</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}
			else if (builder)
			{
				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Target</B>: <A href=attackaction:" + trap_attack.ID + ">Set target</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			if (trap_attack.Attack != null)
			{
				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Attack</B>:");
				if (builder)
					lines.Add("<A href=attackattack:" + trap_attack.ID + ">");
				if (links)
					lines.Add("<A href=power:" + trap_attack.ID + ">");
				lines.Add(trap_attack.Attack.ToString());
				if (links)
					lines.Add("</A>");
				if (builder)
					lines.Add("</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}
			else if (builder)
			{
				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Attack</B>: <A href=attackattack:" + trap_attack.ID + ">Set attack</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			if (trap_attack.OnHit != "")
			{
				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Hit</B>:");
				if (builder)
					lines.Add("<A href=attackhit:" + trap_attack.ID + ">");
				lines.Add(HTML.Process(trap_attack.OnHit, true));
				if (builder)
					lines.Add("</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}
			else if (builder)
			{
				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Hit</B>: <A href=attackhit:" + trap_attack.ID + ">Set hit</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			if (trap_attack.OnMiss != "")
			{
				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Miss</B>:");
				if (builder)
					lines.Add("<A href=attackmiss:" + trap_attack.ID + ">");
				lines.Add(HTML.Process(trap_attack.OnMiss, true));
				if (builder)
					lines.Add("</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}
			else if (builder)
			{
				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Miss</B>: <A href=attackmiss:" + trap_attack.ID + ">Set miss</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			if (trap_attack.Effect != "")
			{
				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Effect</B>:");
				if (builder)
					lines.Add("<A href=attackeffect:" + trap_attack.ID + ">");
				lines.Add(HTML.Process(trap_attack.Effect, true));
				if (builder)
					lines.Add("</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}
			else if (builder)
			{
				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Effect</B>: <A href=attackeffect:" + trap_attack.ID + ">Set effect</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			if (trap_attack.Notes != "")
			{
				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Notes</B>:");
				if (builder)
					lines.Add("<A href=attacknotes:" + trap_attack.ID + ">");
				lines.Add(HTML.Process(trap_attack.Notes, true));
				if (builder)
					lines.Add("</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}
			else if (builder)
			{
				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Notes</B>: <A href=attacknotes:" + trap_attack.ID + ">Set notes</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			return lines;
		}

		static List<string> get_skill_challenge(SkillChallenge sc, bool include_links)
		{
			// Separate primary and secondary skills
			List<SkillChallengeData> primary_skills = new List<SkillChallengeData>();
			List<SkillChallengeData> other_skills = new List<SkillChallengeData>();
			List<SkillChallengeData> fail_skills = new List<SkillChallengeData>();

			foreach (SkillChallengeData scd in sc.Skills)
			{
				switch (scd.Type)
				{
					case SkillType.Primary:
						primary_skills.Add(scd);
						break;
					case SkillType.Secondary:
						other_skills.Add(scd);
						break;
					case SkillType.AutoFail:
						fail_skills.Add(scd);
						break;
				}
			}

			List<string> lines = new List<string>();

			lines.Add("<P class=table>");
			lines.Add("<TABLE>");

			lines.Add("<TR class=trap>");
			lines.Add("<TD colspan=2>");
			lines.Add("<B>" + HTML.Process(sc.Name, true) + "</B>");
			lines.Add("</TD>");
			lines.Add("<TD>");
			lines.Add(sc.GetXP() + " XP");
			lines.Add("</TD>");
			lines.Add("</TR>");

			lines.Add("<TR>");
			lines.Add("<TD colspan=3>");
			lines.Add("<B>Level</B> " + sc.Level);
			lines.Add("<BR>");
			lines.Add("<B>Complexity</B> " + sc.Complexity + " (requires " + sc.Successes + " successes before 3 failures)");
			lines.Add("</TD>");
			lines.Add("</TR>");

			SkillChallengeResult results = sc.Results;
			if (results.Successes + results.Fails != 0)
			{
				string str = "In Progress";
				if (results.Fails >= 3)
					str = "Failed";
				else if (results.Successes >= sc.Successes)
					str = "Succeeded";

				lines.Add("<TR class=shaded>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>" + str + "</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Successes</B> " + results.Successes + " <B>Failures</B> " + results.Fails);
				if (include_links)
				{
					// Add reset link
					lines.Add("(<A href=\"sc:reset\">reset</A>)");
				}
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			// Primary skills
			if (primary_skills.Count != 0)
			{
				lines.Add("<TR class=shaded>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Primary Skills</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				foreach (SkillChallengeData scd in primary_skills)
					lines.AddRange(get_skill(scd, sc.Level, true, include_links));
			}

			// Other skills
			if (other_skills.Count != 0)
			{
				lines.Add("<TR class=shaded>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Other Skills</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				foreach (SkillChallengeData scd in other_skills)
					lines.AddRange(get_skill(scd, sc.Level, true, false));
			}

			// Automatic failure skills
			if (fail_skills.Count != 0)
			{
				lines.Add("<TR class=shaded>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Automatic Failure</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				foreach (SkillChallengeData scd in fail_skills)
					lines.AddRange(get_skill(scd, sc.Level, false, false));
			}

			if (sc.Success != "")
			{
				lines.Add("<TR class=shaded>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Victory</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add(Process(sc.Success, true));
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			if (sc.Failure != "")
			{
				lines.Add("<TR class=shaded>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Defeat</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add(Process(sc.Failure, true));
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			if (sc.Notes != "")
			{
				lines.Add("<TR class=shaded>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Notes</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add(Process(sc.Notes, true));
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			SkillChallenge ch = Session.FindSkillChallenge(sc.ID, SearchType.External);
			if (ch != null)
			{
				Library lib = Session.FindLibrary(ch);
				if (lib != null)
				{
					lines.Add("<TR class=shaded>");
					lines.Add("<TD colspan=3>");
					lines.Add(HTML.Process(lib.Name, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}
			}

			lines.Add("</TABLE>");
			lines.Add("</P>");

			return lines;
		}

		static List<string> get_skill(SkillChallengeData scd, int level, bool include_details, bool include_links)
		{
			List<string> lines = new List<string>();

			string info = "<B>" + scd.SkillName + "</B>";
			if (include_details)
			{
				int dc = AI.GetSkillDC(scd.Difficulty, level) + scd.DCModifier;
				info += " (DC " + dc + ")";
			}
			if (scd.Details != "")
				info += ": " + scd.Details;

			lines.Add("<TR>");
			lines.Add("<TD colspan=3>");
			lines.Add(Process(info, false));
			lines.Add("</TD>");
			lines.Add("</TR>");

			if (include_details)
			{
				if (scd.Success != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD class=indent colspan=3>");
					lines.Add("<B>Success</B>: " + Process(scd.Success, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (scd.Failure != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD class=indent colspan=3>");
					lines.Add("<B>Failure</B>: " + Process(scd.Failure, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}
			}

			lines.Add("<TR>");
			lines.Add("<TD class=indent colspan=3>");
			if (include_links)
			{
				// Add success / failure links
				lines.Add("Add a <A href=\"success:" + scd.SkillName + "\">success</A>");
				if (scd.Results.Successes > 0)
					lines.Add("(" + scd.Results.Successes + ")");
				lines.Add("or <A href=\"failure:" + scd.SkillName + "\">failure</A>");
				if (scd.Results.Fails > 0)
					lines.Add("(" + scd.Results.Fails + ")");
			}
			lines.Add("</TD>");
			lines.Add("</TR>");

			return lines;
		}

		static List<string> get_quest(Quest q)
		{
			string name = (q.Type == QuestType.Major) ? "Major Quest" : "Minor Quest";

			List<string> lines = new List<string>();

			lines.Add("<P class=table>");
			lines.Add("<TABLE>");

			lines.Add("<TR class=heading>");
			lines.Add("<TD colspan=2>");
			lines.Add("<B>" + name + "</B>");
			lines.Add("</TD>");
			lines.Add("<TD>");
			lines.Add(q.GetXP() + " XP");
			lines.Add("</TD>");
			lines.Add("</TR>");

			lines.Add("<TR>");
			lines.Add("<TD colspan=3>");
			lines.Add("<B>Level</B> " + q.Level);
			lines.Add("</TD>");
			lines.Add("</TR>");

			lines.Add("</TABLE>");
			lines.Add("</P>");

			return lines;
		}

		static List<string> get_hero(Hero hero, Encounter enc, bool initiative_holder, bool show_effects)
		{
			List<string> lines = new List<string>();

			if (enc != null)
				lines.AddRange(get_combat_data(hero.CombatData, hero.HP, enc, initiative_holder));

			if (show_effects && (hero.Effects.Count != 0))
			{
				lines.Add("<P class=table>");
				lines.Add("<TABLE>");
				lines.Add("<TR class=heading><TD colspan=3><B>Effects</B></TD></TR>");
				foreach (OngoingCondition oc in hero.Effects)
				{
					int index = hero.Effects.IndexOf(oc);
					lines.Add("<TR><TD colspan=2>" + oc.ToString(enc, true) + "</TD>");
					lines.Add("<TD align=right><A href=addeffect:" + index + ">Apply &#8658</A></TD></TR>");
				}
				lines.Add("</TABLE>");
				lines.Add("</P>");
			}

			lines.Add("<P class=table>");
			lines.Add("<TABLE>");

			lines.Add("<TR class=hero>");
			lines.Add("<TD colspan=2>");
			lines.Add("<B>" + Process(hero.Name, true) + "</B>");
			lines.Add("</TD>");
			lines.Add("<TD align=right>");
			lines.Add(Process(hero.Player, true));
			lines.Add("</TD>");
			lines.Add("</TR>");

			lines.Add("<TR>");
			lines.Add("<TD colspan=3>");
			lines.Add(Process(hero.Info, true));
			lines.Add("</TD>");
			lines.Add("</TR>");

			lines.Add("<TR class=shaded>");
			lines.Add("<TD colspan=3>");
			lines.Add("<B>Combat</B>");
			lines.Add("</TD>");
			lines.Add("</TR>");

			string init_str = hero.InitBonus.ToString();
			if (hero.InitBonus >= 0)
				init_str = "+" + init_str;
			if ((hero.CombatData != null) && (hero.CombatData.Initiative != int.MinValue))
			{
				init_str = hero.CombatData.Initiative + " (" + init_str + ")";
			}

			if (enc != null)
			{
				init_str = "<A href=init:" + hero.CombatData.ID + ">" + init_str + "</A>";
			}

			lines.Add("<TR>");
			lines.Add("<TD colspan=3>");
			lines.Add("<B>Initiative</B> " + init_str);
			lines.Add("</TD>");
			lines.Add("</TR>");

			string hp = hero.HP.ToString();
			if ((hero.CombatData != null) && (hero.CombatData.Damage != 0))
			{
				int health = hero.HP - hero.CombatData.Damage;
				hp = health + " of " + hero.HP;
			}
			string hp_str = "<B>HP</B> " + hp;
			if (enc != null)
			{
				hp_str = "<A href=hp:" + hero.ID + ">" + hp_str + "</A>";
			}
			hp_str += "; " + "<B>Bloodied</B>" + " " + (hero.HP / 2);
			if ((hero.CombatData != null) && (hero.CombatData.TempHP > 0))
				hp_str += "; " + "<B>Temp HP</B> " + hero.CombatData.TempHP;

			lines.Add("<TR>");
			lines.Add("<TD colspan=3>");
			lines.Add(hp_str);
			lines.Add("</TD>");
			lines.Add("</TR>");

			int ac = hero.AC;
			int fort = hero.Fortitude;
			int reflex = hero.Reflex;
			int will = hero.Will;

			if (hero.CombatData != null)
			{
				foreach (OngoingCondition oc in hero.CombatData.Conditions)
				{
					if (oc.Type != OngoingType.DefenceModifier)
						continue;

					if (oc.Defences.Contains(DefenceType.AC))
						ac += oc.DefenceMod;
					if (oc.Defences.Contains(DefenceType.Fortitude))
						fort += oc.DefenceMod;
					if (oc.Defences.Contains(DefenceType.Reflex))
						reflex += oc.DefenceMod;
					if (oc.Defences.Contains(DefenceType.Will))
						will += oc.DefenceMod;
				}
			}

			string ac_str = ac.ToString();
			if (ac != hero.AC)
				ac_str = "<B><I>" + ac_str + "</I></B>";
			string fort_str = fort.ToString();
			if (fort != hero.Fortitude)
				fort_str = "<B><I>" + fort_str + "</I></B>";
			string ref_str = reflex.ToString();
			if (reflex != hero.Reflex)
				ref_str = "<B><I>" + ref_str + "</I></B>";
			string will_str = will.ToString();
			if (will != hero.Will)
				will_str = "<B><I>" + will_str + "</I></B>";

			lines.Add("<TR>");
			lines.Add("<TD colspan=3>");
			lines.Add("<B>AC</B> " + ac_str + "; <B>Fort</B> " + fort_str + "; <B>Ref</B> " + ref_str + "; <B>Will</B> " + will_str);
			lines.Add("</TD>");
			lines.Add("</TR>");

			lines.Add("<TR class=shaded>");
			lines.Add("<TD colspan=3>");
			lines.Add("<B>Skills</B>");
			lines.Add("</TD>");
			lines.Add("</TR>");
			lines.Add("<TR>");
			lines.Add("<TD colspan=3>");
			lines.Add("<B>Passive Insight</B> " + hero.PassiveInsight);
			lines.Add("<BR>");
			lines.Add("<B>Passive Perception</B> " + hero.PassivePerception);
			lines.Add("</TD>");
			lines.Add("</TR>");

			if (hero.Languages != "")
			{
				lines.Add("<TR class=shaded>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Languages</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add(Process(hero.Languages, true));
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			lines.Add("</TABLE>");
			lines.Add("</P>");

			return lines;
		}

		static List<string> get_combat_data(CombatData cd, int max_hp, Encounter enc, bool initiative_holder)
		{
			int bloodied_hp = max_hp / 2;
			int current_hp = max_hp - cd.Damage;
			bool is_bloodied = (max_hp != 0) && (current_hp <= bloodied_hp);
			bool is_dead = (max_hp != 0) && (current_hp <= 0);

			List<string> lines = new List<string>();

			if ((cd.Conditions.Count != 0) || (is_bloodied) || (is_dead) || (initiative_holder) || (cd.Altitude != 0))
			{
				lines.Add("<P class=table>");
				lines.Add("<TABLE>");

				lines.Add("<TR class=heading>");
				lines.Add("<TD>");
				lines.Add("<B>Information</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				if (initiative_holder)
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add(cd.DisplayName + " is the current initiative holder");
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (cd.Altitude != 0)
				{
					string squares = Math.Abs(cd.Altitude) == 1 ? "square" : "squares";
					string direction = cd.Altitude > 0 ? "up" : "down";

					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add(cd.DisplayName + " is " + Math.Abs(cd.Altitude) + " " + squares + " <B>" + direction + "</B>");
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (is_dead)
				{
					lines.Add("<TR class=shaded>");
					lines.Add("<TD>");
					lines.Add("<B>Hit Points</B>");
					lines.Add("</TD>");
					lines.Add("</TR>");

					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add(cd.DisplayName + " is <B>dead</B>");
					lines.Add("</TD>");
					lines.Add("</TR>");
				}
				else if (is_bloodied)
				{
					lines.Add("<TR class=shaded>");
					lines.Add("<TD>");
					lines.Add("<B>Hit Points</B>");
					lines.Add("</TD>");
					lines.Add("</TR>");

					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add(cd.DisplayName + " is <B>bloodied</B>");
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (cd.Conditions.Count != 0)
				{
					lines.Add("<TR class=shaded>");
					lines.Add("<TD>");
					lines.Add("<B>Effects</B>");
					lines.Add("</TD>");
					lines.Add("</TR>");

					foreach (OngoingCondition oc in cd.Conditions)
					{
						lines.Add("<TR>");
						lines.Add("<TD>");

						lines.Add(oc.ToString(enc, true));

						// Add link for quick removal
						int index = cd.Conditions.IndexOf(oc);
						lines.Add("<A href=\"effect:" + cd.ID + ":" + index + "\">(remove)</A>");

						if (oc.Type == OngoingType.Condition)
						{
							lines.Add("</TD>");
							lines.Add("</TR>");

							lines.Add("<TR>");
							lines.Add("<TD class=indent>");

							List<string> info = Conditions.GetConditionInfo(oc.Data);
							if (info.Count != 0)
								lines.AddRange(info);

							lines.Add("</TD>");
							lines.Add("</TR>");
						}
					}
				}

				lines.Add("</TABLE>");
				lines.Add("</P>");
			}

			return lines;
		}

		static List<string> get_magic_item(MagicItem item, bool builder)
		{
			List<string> lines = new List<string>();

			lines.Add("<P class=table>");
			lines.Add("<TABLE>");

			lines.Add("<TR class=item>");
			lines.Add("<TD colspan=2>");
			lines.Add("<B>" + Process(item.Name, true) + "</B>");
			lines.Add("</TD>");
			lines.Add("<TD>");
			lines.Add(Process(item.Type, true));
			lines.Add("</TD>");
			lines.Add("</TR>");
			if (builder)
			{
				lines.Add("<TR class=item>");
				lines.Add("<TD colspan=3 align=center>");
				lines.Add("<A href=build:profile style=\"color:white\">(click here to edit this top section)</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			string desc = Process(item.Description, true);
			if (builder && (desc == ""))
				desc = "(no description set)";
			if (desc != "")
			{
				if (builder)
					desc = "<A href=build:desc>" + desc + "</A>";

				lines.Add("<TR>");
				lines.Add("<TD class=readaloud colspan=3>");
				lines.Add(desc);
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			string rarity = item.Rarity.ToString();
			if (builder)
				rarity = "<A href=build:profile>" + rarity + "</A>";
			lines.Add("<TR>");
			lines.Add("<TD colspan=3>");
			lines.Add("<B>Availability</B> " + rarity);
			lines.Add("</TD>");
			lines.Add("</TR>");

			string level = item.Level.ToString();
			if (builder)
				level = "<A href=build:profile>" + level + "</A>";
			lines.Add("<TR>");
			lines.Add("<TD colspan=3>");
			lines.Add("<B>Level</B> " + level);
			lines.Add("</TD>");
			lines.Add("</TR>");

			// Sections
			foreach (MagicItemSection section in item.Sections)
			{
				int index = item.Sections.IndexOf(section);

				lines.Add("<TR class=shaded>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>" + Process(section.Header, true) + "</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD class=indent colspan=3>");
				lines.Add(Process(section.Details, true));
				lines.Add("</TD>");
				lines.Add("</TR>");

				if (builder)
				{
					lines.Add("<TR>");
					lines.Add("<TD colspan=3 align=center>");
					lines.Add("<A href=edit:" + index + ">edit</A>");
					lines.Add("|");
					lines.Add("<A href=remove:" + index + ">remove</A>");
					if (item.Sections.Count > 1)
					{
						if (index != 0)
						{
							lines.Add("|");
							lines.Add("<A href=moveup:" + index + ">move up</A>");
						}
						if (index != item.Sections.Count - 1)
						{
							lines.Add("|");
							lines.Add("<A href=movedown:" + index + ">move down</A>");
						}
					}
					lines.Add("</TD>");
					lines.Add("</TR>");
				}
			}
			if (builder)
			{
				lines.Add("<TR class=shaded>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Sections</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				if (item.Sections.Count == 0)
				{
					lines.Add("<TR>");
					lines.Add("<TD class=indent colspan=3>");
					lines.Add("No details set");
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				lines.Add("<TR>");
				lines.Add("<TD colspan=3 align=center>");
				lines.Add("<A href=section:new>add a new section</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			Library lib = Session.FindLibrary(item);
			if (lib != null)
			{
				lines.Add("<TR class=shaded>");
				lines.Add("<TD colspan=3>");
				lines.Add(Process(lib.Name, true));
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			lines.Add("</TABLE>");
			lines.Add("</P>");

			return lines;
		}

		static List<string> get_artifact(Artifact artifact, bool builder)
		{
			List<string> lines = new List<string>();

			lines.Add("<P class=table>");
			lines.Add("<TABLE>");

			lines.Add("<TR class=artifact>");
			lines.Add("<TD colspan=2>");
			lines.Add("<B>" + Process(artifact.Name, true) + "</B>");
			lines.Add("</TD>");
			lines.Add("<TD align=center>");
			lines.Add(artifact.Tier + " tier");
			lines.Add("</TD>");
			lines.Add("</TR>");
			if (builder)
			{
				lines.Add("<TR class=artifact>");
				lines.Add("<TD colspan=3 align=center>");
				lines.Add("<A href=build:profile style=\"color:white\">(click here to edit this top section)</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			string desc = Process(artifact.Description, true);
			if (builder)
			{
				if (desc == "")
					desc = "click to set description";

				desc = "<A href=build:description>" + desc + "</A>";
			}
			if (desc != "")
			{
				lines.Add("<TR>");
				lines.Add("<TD class=readaloud colspan=3>");
				lines.Add(desc);
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			string details = Process(artifact.Details, true);
			if (builder)
			{
				if (details == "")
					details = "click to set details";

				details = "<A href=build:details>" + details + "</A>";
			}
			if (details != "")
			{
				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add(details);
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			foreach (MagicItemSection section in artifact.Sections)
			{
				int index = artifact.Sections.IndexOf(section);

				lines.Add("<TR class=shaded>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>" + Process(section.Header, true) + "</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD class=indent colspan=3>");
				lines.Add(Process(section.Details, true));
				lines.Add("</TD>");
				lines.Add("</TR>");

				if (builder)
				{
					lines.Add("<TR>");
					lines.Add("<TD colspan=3 align=center>");
					lines.Add("<A href=sectionedit:" + index + ">edit</A>");
					lines.Add("|");
					lines.Add("<A href=sectionremove:" + index + ">remove</A>");
					lines.Add("</TD>");
					lines.Add("</TR>");
				}
			}
			if (builder)
			{
				lines.Add("<TR>");
				lines.Add("<TD colspan=3 align=center>");
				lines.Add("<A href=section:new>add a section</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			// Goals
			string goals = Process(artifact.Goals, true);
			if (builder)
			{
				if (goals == "")
					goals = "click to set goals";

				goals = "<A href=build:goals>" + goals + "</A>";
			}
			if (goals != "")
			{
				lines.Add("<TR class=shaded>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Goals of " + Process(artifact.Name, true) + "</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");
				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add(goals);
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			// Roleplaying
			string rp = Process(artifact.RoleplayingTips, true);
			if (builder)
			{
				if (rp == "")
					rp = "click to set roleplaying tips";

				rp = "<A href=build:rp>" + rp + "</A>";
			}
			if (rp != "")
			{
				lines.Add("<TR class=shaded>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Roleplaying " + Process(artifact.Name, true) + "</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");
				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add(rp);
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			// Concordance table
			lines.Add("<TR class=shaded>");
			lines.Add("<TD colspan=3>");
			lines.Add("<B>Concordance</B>");
			lines.Add("</TD>");
			lines.Add("</TR>");
			lines.Add("<TR>");
			lines.Add("<TD colspan=2>Starting score</TD>");
			lines.Add("<TD align=center>5</TD>");
			lines.Add("</TR>");
			foreach (Pair<string, string> ac in artifact.ConcordanceRules)
			{
				int index = artifact.ConcordanceRules.IndexOf(ac);

				lines.Add("<TR>");
				lines.Add("<TD colspan=2>");
				lines.Add(ac.First);
				if (builder)
				{
					lines.Add("<A href=ruleedit:" + index + ">edit</A>");
					lines.Add("|");
					lines.Add("<A href=ruleremove:" + index + ">remove</A>");
				}
				lines.Add("</TD>");
				lines.Add("<TD align=center>");
				lines.Add(ac.Second);
				lines.Add("</TD>");
				lines.Add("</TR>");
			}
			if (builder)
			{
				lines.Add("<TR>");
				lines.Add("<TD colspan=3 align=center>");
				lines.Add("<A href=rule:new>add a concordance rule</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			// Concordance levels
			foreach (ArtifactConcordance ac in artifact.ConcordanceLevels)
			{
				int ac_index = artifact.ConcordanceLevels.IndexOf(ac);

				string name = Process(ac.Name, true);
				if (ac.ValueRange != "")
					name += " (" + Process(ac.ValueRange, true) + ")";

				lines.Add("<TR class=shaded>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>" + name + "</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				string ac_quote = Process(ac.Quote, true);
				if (builder)
				{
					if (ac_quote == "")
						ac_quote = "click to set a quote for this concordance level";

					ac_quote = "<A href=quote:" + ac_index + ">" + ac_quote + "</A>";
				}
				if (ac_quote != "")
				{
					lines.Add("<TR class=readaloud>");
					lines.Add("<TD colspan=3>");
					lines.Add(ac_quote);
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				string ac_desc = Process(ac.Description, true);
				if (builder)
				{
					if (ac_desc == "")
						ac_desc = "click to set concordance details";

					ac_desc = "<A href=desc:" + ac_index + ">" + ac_desc + "</A>";
				}
				if (ac_desc != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD colspan=3>");
					lines.Add(ac_desc);
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				// Properties
				if (ac.ValueRange != "")
				{
					foreach (MagicItemSection section in ac.Sections)
					{
						int index = artifact.Sections.IndexOf(section);

						lines.Add("<TR class=shaded>");
						lines.Add("<TD colspan=3>");
						lines.Add("<B>" + Process(section.Header, true) + "</B>");
						lines.Add("</TD>");
						lines.Add("</TR>");

						lines.Add("<TR>");
						lines.Add("<TD class=indent colspan=3>");
						lines.Add(Process(section.Details, true));
						lines.Add("</TD>");
						lines.Add("</TR>");

						if (builder)
						{
							lines.Add("<TR>");
							lines.Add("<TD colspan=3 align=center>");
							lines.Add("<A href=sectionedit:" + ac_index + "," + index + ">edit</A>");
							lines.Add("|");
							lines.Add("<A href=sectionremove:" + ac_index + "," + index + ">remove</A>");
							lines.Add("</TD>");
							lines.Add("</TR>");
						}
					}
					if (builder)
					{
						lines.Add("<TR>");
						lines.Add("<TD colspan=3 align=center>");
						lines.Add("<A href=section:" + ac_index + ",new>add a section</A>");
						lines.Add("</TD>");
						lines.Add("</TR>");
					}
				}
			}
			lines.Add("</TABLE>");
			lines.Add("</P>");

			return lines;
		}

        static List<string> get_custom_token(CustomToken ct)
        {
            List<string> lines = new List<string>();

            lines.Add("<P class=table>");
            lines.Add("<TABLE>");

            lines.Add("<TR class=heading>");
            lines.Add("<TD>");
            lines.Add("<B>" + Process(ct.Name, true) + "</B>");
            lines.Add("</TD>");
            lines.Add("</TR>");

            lines.Add("<TR>");
            lines.Add("<TD>");
            lines.Add(ct.Details != "" ? Process(ct.Details, true) : "(no details)");
            lines.Add("</TD>");
            lines.Add("</TR>");

            if (ct.TerrainPower != null)
            {
                lines.Add("<TR>");
                lines.Add("<TD>");
                lines.Add(Process("Includes the terrain power \"" + ct.TerrainPower.Name + "\"", true));
                lines.Add("</TD>");
                lines.Add("</TR>");
            }

            lines.Add("</TABLE>");

            if (ct.TerrainPower != null)
            {
                lines.Add("<BR>");
				lines.AddRange(get_terrain_power(ct.TerrainPower));
            }

            lines.Add("</BODY>");

            lines.Add("</HTML>");
            lines.Add("</P>");

            return lines;
        }

		static List<string> get_terrain_power(TerrainPower tp)
		{
			List<string> lines = new List<string>();

			if (tp != null)
			{
				lines.Add("<P class=table>");
				lines.Add("<TABLE>");

				lines.Add("<TR class=heading>");
				lines.Add("<TD>");
				lines.Add("<B>" + Process(tp.Name, true) + "</B>");
				lines.Add("</TD>");
				lines.Add("<TD>");
				lines.Add(tp.Type == TerrainPowerType.AtWill ? "At-Will Terrain" : "Single-Use Terrain");
				lines.Add("</TD>");
				lines.Add("</TR>");

				if (tp.FlavourText != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD class=readaloud colspan=2>");
					lines.Add(Process(tp.FlavourText, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (tp.Requirement != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD colspan=2>");
					lines.Add("<B>Requirement</B> " + Process(tp.Requirement, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (tp.Check != "")
				{
					lines.Add("<TR class=shaded>");
					lines.Add("<TD colspan=2>");
					lines.Add("<B>Check</B> " + Process(tp.Check, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (tp.Success != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD colspan=2>");
					lines.Add("<B>Success</B> " + Process(tp.Success, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (tp.Failure != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD colspan=2>");
					lines.Add("<B>Failure</B> " + Process(tp.Failure, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (tp.Attack != "")
				{
					lines.Add("<TR class=shaded>");
					lines.Add("<TD colspan=2>");
					lines.Add("<B>Attack</B> " + Process(tp.Attack, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (tp.Target != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD colspan=2>");
					lines.Add("<B>Target</B> " + Process(tp.Target, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (tp.Hit != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD colspan=2>");
					lines.Add("<B>Hit</B> " + Process(tp.Hit, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (tp.Miss != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD colspan=2>");
					lines.Add("<B>Miss</B> " + Process(tp.Miss, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (tp.Effect != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD colspan=2>");
					lines.Add("<B>Effect</B> " + Process(tp.Effect, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				lines.Add("</TABLE>");
				lines.Add("</P>");
			}
			else
			{
				lines.Add("<P class=instruction>(none)</P>");
			}

			return lines;
		}

		static List<string> get_parcels(PlotPoint pp, bool links)
		{
			List<string> lines = new List<string>();

			lines.Add("<P class=table>");
			lines.Add("<TABLE>");

			lines.Add("<TR class=heading>");
			lines.Add("<TD>");
			lines.Add("<B>Treasure Parcels</B>");
			lines.Add("</TD>");
			lines.Add("</TR>");

			foreach (Parcel parcel in pp.Parcels)
			{
				MagicItem item = null;
				if (parcel.MagicItemID != Guid.Empty)
					item = Session.FindMagicItem(parcel.MagicItemID, SearchType.Global);

				string name = (parcel.Name != "") ? Process(parcel.Name, true) : "(undefined parcel)";
				if (links && (item != null))
					name = "<A href=\"item:" + item.ID + "\">" + name + "</A>";

				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("<B>" + name + "</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				if (parcel.Details != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add(Process(parcel.Details, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (parcel.MagicItemID != Guid.Empty)
				{
					if (item != null)
					{
						Library lib = Session.FindLibrary(item);
						if (lib != null)
						{
							if ((Session.Project != null) && (Session.Project.Library == lib))
							{
								// Don't show this
							}
							else
							{
								lines.Add("<TR>");
								lines.Add("<TD>");
								lines.Add(Process(lib.Name, true));
								lines.Add("</TD>");
								lines.Add("</TR>");
							}
						}
					}
				}
			}

			lines.Add("</TABLE>");
			lines.Add("</P>");

			return lines;
		}

		static List<string> get_player_option(IPlayerOption option)
		{
			List<string> lines = new List<string>();

			#region Race

			if (option is Race)
			{
				Race race = option as Race;

				if ((race.Quote != null) && (race.Quote != ""))
				{
					lines.Add("<P class=readaloud>");
					lines.Add(Process(race.Quote, true));
					lines.Add("</P>");
				}

				lines.Add("<P class=table>");
				lines.Add("<TABLE>");

				lines.Add("<TR class=heading>");
				lines.Add("<TD>");
				lines.Add("<B>" + Process(race.Name, true) + "</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				if (race.HeightRange != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Average Height</B> " + Process(race.HeightRange, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (race.WeightRange != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Average Weight</B> " + Process(race.WeightRange, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (race.AbilityScores != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Ability Scores</B> " + Process(race.AbilityScores, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("<B>Size</B> " + race.Size);
				lines.Add("</TD>");
				lines.Add("</TR>");

				if (race.Speed != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Speed</B> " + Process(race.Speed, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (race.Vision != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Vision</B> " + Process(race.Vision, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (race.Languages != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Languages</B> " + Process(race.Languages, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (race.SkillBonuses != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Skill Bonuses</B> " + Process(race.SkillBonuses, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				foreach (Feature ft in race.Features)
				{
					lines.Add("<TR class=shaded>");
					lines.Add("<TD>");
					lines.Add("<B>" + Process(ft.Name, true) + "</B> " + Process(ft.Details, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				lines.Add("</TABLE>");
				lines.Add("</P>");

				foreach (PlayerPower power in race.Powers)
					lines.AddRange(get_player_power(power, 0));

				if (race.Details != "")
				{
					lines.Add("<P>");
					lines.Add(Process(race.Details, true));
					lines.Add("</P>");
				}
			}

			#endregion

			#region Class

			if (option is Class)
			{
				Class c = option as Class;

				if ((c.Quote != null) && (c.Quote != ""))
				{
					lines.Add("<P class=readaloud>");
					lines.Add(Process(c.Quote, true));
					lines.Add("</P>");
				}

				lines.Add("<P class=table>");
				lines.Add("<TABLE>");

				lines.Add("<TR class=heading>");
				lines.Add("<TD>");
				lines.Add("<B>" + Process(c.Name, true) + "</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				if (c.Role != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Role</B> " + Process(c.Role, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (c.PowerSource != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Power Source</B> " + Process(c.PowerSource, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (c.KeyAbilities != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Key Abilities</B> " + Process(c.KeyAbilities, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (c.ArmourProficiencies != "")
				{
					lines.Add("<TR class=shaded>");
					lines.Add("<TD>");
					lines.Add("<B>Armour Proficiencies</B> " + Process(c.ArmourProficiencies, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (c.WeaponProficiencies != "")
				{
					lines.Add("<TR class=shaded>");
					lines.Add("<TD>");
					lines.Add("<B>Weapon Proficiencies</B> " + Process(c.WeaponProficiencies, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (c.Implements != "")
				{
					lines.Add("<TR class=shaded>");
					lines.Add("<TD>");
					lines.Add("<B>Implements</B> " + Process(c.Implements, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (c.DefenceBonuses != "")
				{
					lines.Add("<TR class=shaded>");
					lines.Add("<TD>");
					lines.Add("<B>Defence Bonuses</B> " + Process(c.DefenceBonuses, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("<B>Hit Points at 1st Level</B> " + c.HPFirst + " + Constitution score");
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("<B>HP per Level Gained</B> " + c.HPSubsequent);
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("<B>Healing Surges per Day</B> " + c.HealingSurges + " + Constitution modifier");
				lines.Add("</TD>");
				lines.Add("</TR>");

				if (c.TrainedSkills != "")
				{
					lines.Add("<TR class=shaded>");
					lines.Add("<TD>");
					lines.Add("<B>Trained Skills</B> " + Process(c.TrainedSkills, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				string class_features = "";
				foreach (Feature ft in c.FeatureData.Features)
				{
					if (class_features != "")
						class_features += ", ";

					class_features += ft.Name;
				}

				if (class_features != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Class Features</B> " + Process(class_features, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				lines.Add("</TABLE>");
				lines.Add("</P>");

				if (c.Description != "")
				{
					lines.Add("<P>");
					lines.Add(Process(c.Description, true));
					lines.Add("</P>");
				}

				if ((c.OverviewCharacteristics != "") || (c.OverviewReligion != "") || (c.OverviewRaces != ""))
				{
					lines.Add("<P class=table>");
					lines.Add("<TABLE>");

					lines.Add("<TR class=heading>");
					lines.Add("<TD>");
					lines.Add("<B>Overview</B>");
					lines.Add("</TD>");
					lines.Add("</TR>");

					if (c.OverviewCharacteristics != "")
					{
						lines.Add("<TR>");
						lines.Add("<TD>");
						lines.Add("<B>Characteristics</B> " + Process(c.OverviewCharacteristics, true));
						lines.Add("</TD>");
						lines.Add("</TR>");
					}

					if (c.OverviewReligion != "")
					{
						lines.Add("<TR>");
						lines.Add("<TD>");
						lines.Add("<B>Religion</B> " + Process(c.OverviewReligion, true));
						lines.Add("</TD>");
						lines.Add("</TR>");
					}

					if (c.OverviewRaces != "")
					{
						lines.Add("<TR>");
						lines.Add("<TD>");
						lines.Add("<B>Races</B> " + Process(c.OverviewRaces, true));
						lines.Add("</TD>");
						lines.Add("</TR>");
					}

					lines.Add("</TABLE>");
					lines.Add("</P>");
				}

				if (c.FeatureData.Features.Count != 0)
				{
					lines.Add("<H4>Class Features</H4>");

					foreach (Feature ft in c.FeatureData.Features)
					{
						lines.Add("<P class=table>");
						lines.Add("<TABLE>");

						lines.Add("<TR class=heading>");
						lines.Add("<TD>");
						lines.Add("<B>" + Process(ft.Name, true) + "</B>");
						lines.Add("</TD>");
						lines.Add("</TR>");

						lines.Add("<TR>");
						lines.Add("<TD>");
						lines.Add(Process(ft.Details, true));
						lines.Add("</TD>");
						lines.Add("</TR>");

						lines.Add("</TABLE>");
						lines.Add("</P>");
					}
				}

				foreach (PlayerPower pwr in c.FeatureData.Powers)
					lines.AddRange(get_player_power(pwr, 0));

				foreach (LevelData ld in c.Levels)
				{
					if (ld.Powers.Count != 0)
					{
						lines.Add("<H4>Level " + ld.Level + " Powers</H4>");

						foreach (PlayerPower pwr in ld.Powers)
							lines.AddRange(get_player_power(pwr, ld.Level));
					}
				}
			}

			#endregion

			#region Theme

			if (option is Theme)
			{
				Theme theme = option as Theme;

				if ((theme.Quote != null) && (theme.Quote != ""))
				{
					lines.Add("<P class=readaloud>");
					lines.Add(Process(theme.Quote, true));
					lines.Add("</P>");
				}

				lines.Add("<P class=table>");
				lines.Add("<TABLE>");

				lines.Add("<TR class=heading>");
				lines.Add("<TD>");
				lines.Add("<B>" + Process(theme.Name, true) + "</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				if (theme.Prerequisites != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Prerequisites</B> " + Process(theme.Prerequisites, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (theme.SecondaryRole != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Secondary Role</B> " + Process(theme.SecondaryRole, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (theme.PowerSource != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Power Source</B> " + Process(theme.PowerSource, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("<B>Granted Power</B> " + Process(theme.GrantedPower.Name, true));
				lines.Add("</TD>");
				lines.Add("</TR>");

				foreach (LevelData ld in theme.Levels)
				{
					foreach (Feature ft in ld.Features)
					{
						lines.Add("<TR class=shaded>");
						lines.Add("<TD>");
						lines.Add("<B>" + Process(ft.Name, true) + " (level " + ld.Level + ")</B> " + Process(ft.Details, true));
						lines.Add("</TD>");
						lines.Add("</TR>");
					}
				}

				lines.Add("</TABLE>");
				lines.Add("</P>");

				lines.AddRange(get_player_power(theme.GrantedPower, 0));

				foreach (LevelData ld in theme.Levels)
				{
					foreach (PlayerPower power in ld.Powers)
						lines.AddRange(get_player_power(power, ld.Level));
				}

				if (theme.Details != "")
				{
					lines.Add("<P>");
					lines.Add(Process(theme.Details, true));
					lines.Add("</P>");
				}
			}

			#endregion

			#region Paragon path

			if (option is ParagonPath)
			{
				ParagonPath pp = option as ParagonPath;

				if ((pp.Quote != null) && (pp.Quote != ""))
				{
					lines.Add("<P class=readaloud>");
					lines.Add(Process(pp.Quote, true));
					lines.Add("</P>");
				}

				lines.Add("<P class=table>");
				lines.Add("<TABLE>");

				lines.Add("<TR class=heading>");
				lines.Add("<TD>");
				lines.Add("<B>" + Process(pp.Name, true) + "</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				if (pp.Prerequisites != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Prerequisites</B> " + Process(pp.Prerequisites, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				foreach (LevelData ld in pp.Levels)
				{
					foreach (Feature ft in ld.Features)
					{
						lines.Add("<TR class=shaded>");
						lines.Add("<TD>");
						lines.Add("<B>" + Process(ft.Name, true) + " (level " + ld.Level + ")</B> " + Process(ft.Details, true));
						lines.Add("</TD>");
						lines.Add("</TR>");
					}
				}

				lines.Add("</TABLE>");
				lines.Add("</P>");

				foreach (LevelData ld in pp.Levels)
				{
					foreach (PlayerPower power in ld.Powers)
						lines.AddRange(get_player_power(power, ld.Level));
				}

				if (pp.Details != "")
				{
					lines.Add("<P>");
					lines.Add(Process(pp.Details, true));
					lines.Add("</P>");
				}
			}

			#endregion

			#region Epic destiny

			if (option is EpicDestiny)
			{
				EpicDestiny ed = option as EpicDestiny;

				if ((ed.Quote != null) && (ed.Quote != ""))
				{
					lines.Add("<P class=readaloud>");
					lines.Add(Process(ed.Quote, true));
					lines.Add("</P>");
				}

				lines.Add("<P class=table>");
				lines.Add("<TABLE>");

				lines.Add("<TR class=heading>");
				lines.Add("<TD>");
				lines.Add("<B>" + Process(ed.Name, true) + "</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				if (ed.Prerequisites != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Prerequisites</B> " + Process(ed.Prerequisites, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				foreach (LevelData ld in ed.Levels)
				{
					foreach (Feature ft in ld.Features)
					{
						lines.Add("<TR class=shaded>");
						lines.Add("<TD>");
						lines.Add("<B>" + Process(ft.Name, true) + " (level " + ld.Level + ")</B> " + Process(ft.Details, true));
						lines.Add("</TD>");
						lines.Add("</TR>");
					}
				}

				lines.Add("</TABLE>");
				lines.Add("</P>");

				foreach (LevelData ld in ed.Levels)
				{
					foreach (PlayerPower power in ld.Powers)
						lines.AddRange(get_player_power(power, ld.Level));
				}

				if (ed.Details != "")
				{
					lines.Add("<P>");
					lines.Add(Process(ed.Details, true));
					lines.Add("</P>");
				}

				if (ed.Immortality != "")
				{
					lines.Add("<P>");
					lines.Add("<B>Immortality</B> " + Process(ed.Immortality, true));
					lines.Add("</P>");
				}
			}

			#endregion

			#region Background

			if (option is PlayerBackground)
			{
				PlayerBackground bg = option as PlayerBackground;

				lines.Add("<P class=table>");
				lines.Add("<TABLE>");

				lines.Add("<TR class=heading>");
				lines.Add("<TD>");
				lines.Add("<B>" + Process(bg.Name, true) + "</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				if (bg.Details != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add(Process(bg.Details, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (bg.AssociatedSkills != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Associated Skills</B> " + Process(bg.AssociatedSkills, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (bg.RecommendedFeats != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Recommended Feats</B> " + Process(bg.RecommendedFeats, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				lines.Add("</TABLE>");
				lines.Add("</P>");
			}

			#endregion

			#region Feat

			if (option is Feat)
			{
				Feat feat = option as Feat;

				lines.Add("<P class=table>");
				lines.Add("<TABLE>");

				lines.Add("<TR class=heading>");
				lines.Add("<TD>");
				lines.Add("<B>" + Process(feat.Name, true) + "</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				if (feat.Prerequisites != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Prerequisites</B> " + Process(feat.Prerequisites, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (feat.Benefits != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Benefit</B> " + Process(feat.Benefits, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				lines.Add("</TABLE>");
				lines.Add("</P>");
			}

			#endregion

			#region Weapon

			if (option is Weapon)
			{
				Weapon wpn = option as Weapon;

				string info = wpn.Type + " " + wpn.Category;
				info += wpn.TwoHanded ? " two-handed weapon" : " one-handed weapon";

				lines.Add("<P class=table>");
				lines.Add("<TABLE>");

				lines.Add("<TR class=item>");
				lines.Add("<TD>");
				lines.Add("<B>" + Process(wpn.Name, true) + "</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add(info);
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("<B>Proficiency</B> +" + wpn.Proficiency);
				lines.Add("</TD>");
				lines.Add("</TR>");

				if (wpn.Damage != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Damage</B> " + wpn.Damage);
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (wpn.Range != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Range</B> " + wpn.Range);
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (wpn.Price != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Price</B> " + wpn.Price);
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (wpn.Weight != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Weight</B> " + wpn.Weight);
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (wpn.Group != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Group</B> " + wpn.Group);
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (wpn.Properties != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Properties</B> " + wpn.Properties);
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				lines.Add("</TABLE>");
				lines.Add("</P>");

				if (wpn.Description != "")
					lines.Add("<P>" + Process(wpn.Description, true) + "</P>");
			}

			#endregion

			#region Ritual

			if (option is Ritual)
			{
				Ritual ritual = option as Ritual;

				lines.Add("<P class=table>");
				lines.Add("<TABLE>");

				lines.Add("<TR class=heading>");
				lines.Add("<TD>");
				lines.Add("<B>" + Process(ritual.Name, true) + "</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				if (ritual.ReadAloud != "")
				{
					lines.Add("<TR class=shaded>");
					lines.Add("<TD class=readaloud>");
					lines.Add(Process(ritual.ReadAloud, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("<B>Level</B> " + ritual.Level);
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("<B>Category</B> " + ritual.Category);
				lines.Add("</TD>");
				lines.Add("</TR>");

				if (ritual.Time != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Time</B> " + Process(ritual.Time, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (ritual.Duration != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Duration</B> " + Process(ritual.Duration, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (ritual.ComponentCost != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Component Cost</B> " + Process(ritual.ComponentCost, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (ritual.MarketPrice != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Market Price</B> " + Process(ritual.MarketPrice, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (ritual.KeySkill != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add("<B>Key Skill</B> " + Process(ritual.KeySkill, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				if (ritual.Details != "")
				{
					lines.Add("<TR class=shaded>");
					lines.Add("<TD>");
					lines.Add(Process(ritual.Details, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				lines.Add("</TABLE>");
				lines.Add("</P>");
			}

			#endregion

			#region Creature Lore

			if (option is CreatureLore)
			{
				CreatureLore lore = option as CreatureLore;

				lines.Add("<H3>" + Process(lore.Name, true) + " Lore</H3>");

				lines.Add("<P>");
				lines.Add("A character knows the following information with a successful <B>" + lore.SkillName + "</B> check:");
				lines.Add("</P>");

				lines.Add("<UL>");
				foreach (Pair<int, string> info in lore.Information)
				{
					lines.Add("<LI>");
					lines.Add("<B>DC " + info.First + "</B>: " + info.Second);
					lines.Add("</LI>");
				}
				lines.Add("</UL>");
			}

			#endregion

			#region Disease

			if (option is Disease)
			{
				Disease disease = option as Disease;

				lines.Add("<P class=table>");
				lines.Add("<TABLE>");

				lines.Add("<TR class=trap>");
				lines.Add("<TD colspan=2>");
				lines.Add("<B>" + Process(disease.Name, true) + "</B>");
				lines.Add("</TD>");
				lines.Add("<TD>");
				if (disease.Level != "")
					lines.Add("Level " + disease.Level + " Disease");
				lines.Add("</TD>");
				lines.Add("</TR>");

				if (disease.Details != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD class=readaloud colspan=3>");
					lines.Add(Process(disease.Details, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				/*
				if (disease.Attack != "")
				{
					lines.Add("<TR>");
					lines.Add("<TD colspan=3>");
					lines.Add("<B>Attack</B>: " + Process(disease.Attack, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}
				*/

				// Stages
				if (disease.Levels.Count != 0)
				{
					lines.Add("<TR class=shaded>");
					lines.Add("<TD colspan=3>");
					lines.Add("<B>Stages</B>");
					lines.Add("</TD>");
					lines.Add("</TR>");

					lines.Add("<TR>");
					lines.Add("<TD colspan=3>");
					lines.Add("<B>Cured</B>: The target is cured.");
					lines.Add("</TD>");
					lines.Add("</TR>");

					foreach (string level in disease.Levels)
					{
						lines.Add("<TR>");
						lines.Add("<TD colspan=3>");

						if (disease.Levels.Count > 1)
						{
							int index = disease.Levels.IndexOf(level);
							if (index == 0)
								lines.Add("<B>Initial state</B>:");
							if (index == disease.Levels.Count - 1)
								lines.Add("<B>Final state</B>:");
						}

						lines.Add(Process(level, true));

						lines.Add("</TD>");
						lines.Add("</TR>");
					}
				}

				// DCs
				lines.Add("<TR class=shaded>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Check</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Maintain</B>: DC " + Process(disease.MaintainDC, true));
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD colspan=3>");
				lines.Add("<B>Improve</B>: DC " + Process(disease.ImproveDC, true));
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("</TABLE>");
				lines.Add("</P>");
			}

			#endregion

			#region Poison

			if (option is Poison)
			{
				Poison poison = option as Poison;

				lines.Add("<P class=table>");
				lines.Add("<TABLE>");

				lines.Add("<TR class=trap>");
				lines.Add("<TD>");
				lines.Add("<B>" + Process(poison.Name, true) + "</B> (level " + poison.Level + ")");
				lines.Add("</TD>");
				lines.Add("</TR>");

				if (poison.Details != "")
				{
					lines.Add("<TR class=shaded>");
					lines.Add("<TD class=readaloud>");
					lines.Add(Process(poison.Details, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				int price = Treasure.GetItemValue(poison.Level) / 4;
				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("<B>Price</B>: " + price + " gp");
				lines.Add("</TD>");
				lines.Add("</TR>");

				foreach (PlayerPowerSection section in poison.Sections)
				{
					lines.Add("<TR>");
					if (section.Indent == 0)
					{
						lines.Add("<TD>");
					}
					else
					{
						int padding = section.Indent * 15;
						lines.Add("<TD style=\"padding-left=" + padding + "px\">");
					}
					lines.Add("<B>" + Process(section.Header, true) + "</B> " + Process(section.Details, true));
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				lines.Add("</TABLE>");
				lines.Add("</P>");
			}

			#endregion

			return lines;
		}

		static List<string> get_player_power(PlayerPower power, int level)
		{
			List<string> lines = new List<string>();

			lines.Add("<P class=table>");
			lines.Add("<TABLE>");

			string name = Process(power.Name, true);
			if (name == "")
				name = "(unnamed power)";

			string header = "<B>" + name + "</B>";
			if (level != 0)
				header += " (level " + level + ")";

			switch (power.Type)
			{
				case PlayerPowerType.AtWill:
					lines.Add("<TR class=atwill>");
					break;
				case PlayerPowerType.Encounter:
					lines.Add("<TR class=encounter>");
					break;
				case PlayerPowerType.Daily:
					lines.Add("<TR class=daily>");
					break;
			}
			lines.Add("<TD>");
			lines.Add(header);
			lines.Add("</TD>");
			lines.Add("</TR>");

			if (power.ReadAloud != "")
			{
				lines.Add("<TR class=shaded>");
				lines.Add("<TD class=readaloud>");
				lines.Add(Process(power.ReadAloud, true));
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			string line_1 = power.Type.ToString();
			if (power.Keywords != "")
				line_1 += " &diams; " + Process(power.Keywords, true);

			lines.Add("<TR>");
			lines.Add("<TD>");
			lines.Add(line_1);
			lines.Add("</TD>");
			lines.Add("</TR>");

			string line_2 = "<B>Action</B> " + power.Action;
			if (power.Range != "")
				line_2 += "; <B>Range</B> " + Process(power.Range, true);

			lines.Add("<TR>");
			lines.Add("<TD>");
			lines.Add(line_2);
			lines.Add("</TD>");
			lines.Add("</TR>");

			foreach (PlayerPowerSection section in power.Sections)
			{
				lines.Add("<TR>");
				if (section.Indent == 0)
				{
					lines.Add("<TD>");
				}
				else
				{
					int padding = section.Indent * 15;
					lines.Add("<TD style=\"padding-left=" + padding + "px\">");
				}
				lines.Add("<B>" + Process(section.Header, true) + "</B> " + Process(section.Details, true));
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			lines.Add("</TABLE>");
			lines.Add("</P>");

			return lines;
		}

		void add_map(Guid map_id, Guid area_id)
		{
			if (map_id == Guid.Empty)
				return;

			if (!fMaps.ContainsKey(map_id))
				fMaps[map_id] = new List<Guid>();

			if (!fMaps[map_id].Contains(area_id))
				fMaps[map_id].Add(area_id);
		}

		string get_filename(string item_name, string extension, bool full_path)
		{
			string cleaned = item_name;

			List<string> prohibited = new List<string>();
			prohibited.Add("\\");
			prohibited.Add("/");
			prohibited.Add(":");
			prohibited.Add("*");
			prohibited.Add("?");
			prohibited.Add("\"");
			prohibited.Add("<");
			prohibited.Add(">");
			prohibited.Add("|");

			foreach (string bad in prohibited)
				cleaned = cleaned.Replace(bad, "");

			string result = (full_path ? fFullPath : fRelativePath) + cleaned + "." + extension;

			if (!full_path)
				result = result.Replace(" ", "%20");

			return result;
		}

		string get_map_name(Guid map_id, Guid area_id)
		{
			Map m = Session.Project.FindTacticalMap(map_id);
			if (m == null)
				return "";

			if (area_id == Guid.Empty)
			{
				return m.Name;
			}
			else
			{
				MapArea area = m.FindArea(area_id);
				return m.Name + " - " + area.Name;
			}
		}

		static string get_time(TimeSpan ts)
		{
			return ts.Hours.ToString("00") + ":" + ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00");
		}

		#endregion
	}
}
