using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;
using Masterplan.Tools;
using Masterplan.Tools.Generators;
using Masterplan.Wizards;

namespace Masterplan.UI
{
	partial class CreatureBuilderForm : Form
	{
		enum SidebarType
		{
			Advice,
			Powers
		}

		const int SAMPLE_POWERS = 5;

		public CreatureBuilderForm(ICreature creature)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			if (creature is Creature)
			{
				Creature c = creature as Creature;
				fCreature = c.Copy();
			}
			if (creature is CustomCreature)
			{
				CustomCreature cc = creature as CustomCreature;
				fCreature = cc.Copy();
			}
			if (creature is NPC)
			{
				NPC npc = creature as NPC;
				fCreature = npc.Copy();

				OptionsVariant.Enabled = false;
			}

			if (Session.Project == null)
			{
				Pages.TabPages.Remove(EntryPage);
				OptionsEntry.Enabled = false;
			}
			else
			{
				update_entry();
			}

			find_sample_powers();

			update_view();
		}

		~CreatureBuilderForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			PicturePasteBtn.Enabled = Clipboard.ContainsImage();
			PictureClearBtn.Enabled = (fCreature.Image != null);

			AdviceBtn.Checked = fSidebar == SidebarType.Advice;
			PowersBtn.Checked = fSidebar == SidebarType.Powers;

			LevelDownBtn.Enabled = (fCreature.Level > 1);
		}

		public ICreature Creature
		{
			get { return fCreature; }
		}
		ICreature fCreature = null;

		List<CreaturePower> fSamplePowers = new List<CreaturePower>();

		SidebarType fSidebar = SidebarType.Advice;

		private void Browser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			if (e.Url.Scheme == "build")
			{
				if (e.Url.LocalPath == "profile")
				{
					e.Cancel = true;

					int level = fCreature.Level;
					string role = fCreature.Role.ToString();

					CreatureProfileForm dlg = new CreatureProfileForm(fCreature);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						if ((fCreature.Level != level) || (fCreature.Role.ToString() != role))
						{
							string msg = "You've changed this creature's level and/or role.";
							msg += Environment.NewLine;
							msg += "Do you want to update its combat statistics to match?";
							if (MessageBox.Show(msg, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
							{
								// HP
								if (fCreature.Role is ComplexRole)
									fCreature.HP = Statistics.HP(fCreature.Level, fCreature.Role as ComplexRole, fCreature.Constitution.Score);
								else
									fCreature.HP = 1;

								// Init
								fCreature.Initiative = Statistics.Initiative(fCreature.Level, fCreature.Role);

								// AC
								fCreature.AC = Statistics.AC(fCreature.Level, fCreature.Role);

								// Fort / Ref / Will
								fCreature.Fortitude = Statistics.NAD(fCreature.Level, fCreature.Role);
								fCreature.Reflex = Statistics.NAD(fCreature.Level, fCreature.Role);
								fCreature.Will = Statistics.NAD(fCreature.Level, fCreature.Role);
							}
						}

						find_sample_powers();
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "combat")
				{
					e.Cancel = true;

					CreatureStatsForm dlg = new CreatureStatsForm(fCreature);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "ability")
				{
					e.Cancel = true;

					CreatureAbilityForm dlg = new CreatureAbilityForm(fCreature);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "damage")
				{
					e.Cancel = true;

					DamageModListForm dlg = new DamageModListForm(fCreature);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "senses")
				{
					e.Cancel = true;

					string hint = "Note: Do not add Perception here; it should be entered as a skill.";
					DetailsForm dlg = new DetailsForm(fCreature, DetailsField.Senses, hint);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fCreature.Senses = dlg.Details;
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "movement")
				{
					e.Cancel = true;

					DetailsForm dlg = new DetailsForm(fCreature, DetailsField.Movement, null);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fCreature.Movement = dlg.Details;
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "alignment")
				{
					e.Cancel = true;

					DetailsForm dlg = new DetailsForm(fCreature, DetailsField.Alignment, null);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fCreature.Alignment = dlg.Details;
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "languages")
				{
					e.Cancel = true;

					DetailsForm dlg = new DetailsForm(fCreature, DetailsField.Languages, null);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fCreature.Languages = dlg.Details;
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "skills")
				{
					e.Cancel = true;

					CreatureSkillsForm dlg = new CreatureSkillsForm(fCreature);
					if (dlg.ShowDialog() == DialogResult.OK)
						update_statblock();
				}

				if (e.Url.LocalPath == "equipment")
				{
					e.Cancel = true;

					DetailsForm dlg = new DetailsForm(fCreature, DetailsField.Equipment, null);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fCreature.Equipment = dlg.Details;
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "tactics")
				{
					e.Cancel = true;

					DetailsForm dlg = new DetailsForm(fCreature, DetailsField.Tactics, null);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fCreature.Tactics = dlg.Details;
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "variant")
				{
					e.Cancel = true;

					create_variant();
				}

				if (e.Url.LocalPath == "random")
				{
					e.Cancel = true;

					create_random();
				}

				if (e.Url.LocalPath == "hybrid")
				{
					e.Cancel = true;

					create_hybrid();
				}

				if (e.Url.LocalPath == "name")
				{
					e.Cancel = true;

					string original_name = fCreature.Name;
					fCreature.Name = generate_name();

					for (int n = 0; n != fCreature.CreaturePowers.Count; ++n)
					{
						CreaturePower cp = fCreature.CreaturePowers[n];
						cp = replace_name(cp, original_name, "", fCreature.Name);
						fCreature.CreaturePowers[n] = cp;
					}

					for (int n = 0; n != fSamplePowers.Count; ++n)
					{
						CreaturePower cp = fSamplePowers[n];
						cp = replace_name(cp, original_name, "", fCreature.Name);
						fSamplePowers[n] = cp;
					}

					update_statblock();
				}

				if (e.Url.LocalPath == "template")
				{
					e.Cancel = true;

					// Select and apply a template
					CreatureTemplateSelectForm dlg = new CreatureTemplateSelectForm();
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						if (dlg.Template != null)
						{
							EncounterCard card = new EncounterCard(fCreature);
							card.TemplateIDs.Add(dlg.Template.ID);

							ICreature custom = null;

							if (fCreature is Creature)
								custom = new Creature();

							if (fCreature is CustomCreature)
								custom = new CustomCreature();

							if (fCreature is NPC)
								custom = new NPC();

							custom.Name = card.Title;
							//custom.Details = card.Details;
							//custom.Size = card.Size;
							custom.Level = card.Level;

							custom.Senses = card.Senses;
							custom.Movement = card.Movement;
							custom.Resist = card.Resist;
							custom.Vulnerable = card.Vulnerable;
							custom.Immune = card.Immune;

							// Role
							ComplexRole cr = new ComplexRole();
							cr.Leader = card.Leader;
							cr.Flag = card.Flag;
							cr.Type = card.Roles[0];
							custom.Role = cr;

							// Combat stats
							custom.Initiative = card.Initiative;
							custom.HP = card.HP;
							custom.AC = card.AC;
							custom.Fortitude = card.Fortitude;
							custom.Reflex = card.Reflex;
							custom.Will = card.Will;

							// Regeneration
							custom.Regeneration = (card.Regeneration != null) ? card.Regeneration : null;

							// Auras
							List<Aura> auras = card.Auras;
							foreach (Aura aura in auras)
								custom.Auras.Add(aura.Copy());

							// Add powers
							List<CreaturePower> powers = card.CreaturePowers;
							foreach (CreaturePower power in powers)
								custom.CreaturePowers.Add(power.Copy());

							// Add damage modifiers
							List<DamageModifier> mods = card.DamageModifiers;
							foreach (DamageModifier mod in mods)
								custom.DamageModifiers.Add(mod.Copy());

							Guid id = fCreature.ID;
							CreatureHelper.CopyFields(custom, fCreature);
							fCreature.ID = id;

							find_sample_powers();
							update_view();
						}
					}
				}
			}

			if (e.Url.Scheme == "power")
			{
				if (e.Url.LocalPath == "addpower")
				{
					e.Cancel = true;

					CreaturePower pwr = new CreaturePower();
					pwr.Name = "New Power";
					pwr.Action = new PowerAction();

					//PowerForm dlg = new PowerForm(pwr, false);
					PowerBuilderForm dlg = new PowerBuilderForm(pwr, fCreature, false);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fCreature.CreaturePowers.Add(dlg.Power);
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "addtrait")
				{
					e.Cancel = true;

					CreaturePower pwr = new CreaturePower();
					pwr.Name = "New Trait";
					pwr.Action = null;

					//PowerForm dlg = new PowerForm(pwr, false);
					PowerBuilderForm dlg = new PowerBuilderForm(pwr, fCreature, false);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fCreature.CreaturePowers.Add(dlg.Power);
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "addaura")
				{
					e.Cancel = true;

					Aura aura = new Aura();
					aura.Name = "New Aura";
					aura.Details = "1";

					AuraForm dlg = new AuraForm(aura);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fCreature.Auras.Add(dlg.Aura);
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "browse")
				{
					e.Cancel = true;

					OptionsPowerBrowser_Click(null, null);
				}

				if (e.Url.LocalPath == "statistics")
				{
					e.Cancel = true;

					List<ICreature> creatures = find_matching_creatures(fCreature.Role, fCreature.Level, true);
					List<CreaturePower> powers = new List<CreaturePower>();
					foreach (ICreature c in creatures)
						powers.AddRange(c.CreaturePowers);
					PowerStatisticsForm dlg = new PowerStatisticsForm(powers, creatures.Count);
					dlg.ShowDialog();
				}

				if (e.Url.LocalPath == "regenedit")
				{
					e.Cancel = true;

					Regeneration regen = fCreature.Regeneration;
					if (regen == null)
						regen = new Regeneration(5, "");

					RegenerationForm dlg = new RegenerationForm(regen);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fCreature.Regeneration = dlg.Regeneration;
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "regenremove")
				{
					e.Cancel = true;

					fCreature.Regeneration = null;
					update_statblock();
				}

				if (e.Url.LocalPath == "refresh")
				{
					e.Cancel = true;

					find_sample_powers();

					update_statblock();
				}
			}

			if (e.Url.Scheme == "poweredit")
			{
				CreaturePower pwr = find_power(new Guid(e.Url.LocalPath));
				if (pwr != null)
				{
					e.Cancel = true;
					int index = fCreature.CreaturePowers.IndexOf(pwr);

					//PowerForm dlg = new PowerForm(pwr, false);
					PowerBuilderForm dlg = new PowerBuilderForm(pwr, fCreature, false);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fCreature.CreaturePowers[index] = dlg.Power;
						update_statblock();
					}
				}
			}

			if (e.Url.Scheme == "powerremove")
			{
				CreaturePower pwr = find_power(new Guid(e.Url.LocalPath));
				if (pwr != null)
				{
					e.Cancel = true;

					fCreature.CreaturePowers.Remove(pwr);
					update_statblock();
				}
			}

			if (e.Url.Scheme == "powerduplicate")
			{
				CreaturePower pwr = find_power(new Guid(e.Url.LocalPath));
				if (pwr != null)
				{
					e.Cancel = true;

					int index = fCreature.CreaturePowers.IndexOf(pwr);

					pwr = pwr.Copy();
					pwr.ID = Guid.NewGuid();

					fCreature.CreaturePowers.Insert(index, pwr);
					update_statblock();
				}
			}

			if (e.Url.Scheme == "auraedit")
			{
				Aura aura = find_aura(new Guid(e.Url.LocalPath));
				if (aura != null)
				{
					e.Cancel = true;
					int index = fCreature.Auras.IndexOf(aura);

					AuraForm dlg = new AuraForm(aura);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fCreature.Auras[index] = dlg.Aura;
						update_statblock();
					}
				}
			}

			if (e.Url.Scheme == "auraremove")
			{
				Aura aura = find_aura(new Guid(e.Url.LocalPath));
				if (aura != null)
				{
					e.Cancel = true;

					fCreature.Auras.Remove(aura);
					update_statblock();
				}
			}

			if (e.Url.Scheme == "samplepower")
			{
				CreaturePower power = find_sample_power(new Guid(e.Url.LocalPath));
				if (power != null)
				{
					e.Cancel = true;

					fCreature.CreaturePowers.Add(power);

					fSamplePowers.Remove(power);
					if (fSamplePowers.Count == 0)
						find_sample_powers();

					update_statblock();
				}
			}
		}

		#region Menu

		private void OptionsVariant_Click(object sender, EventArgs e)
		{
			create_variant();
		}

		private void OptionsRandom_Click(object sender, EventArgs e)
		{
			create_random();
		}

		private void OptionsEntry_Click(object sender, EventArgs e)
		{
			EncyclopediaEntry entry = Session.Project.Encyclopedia.FindEntryForAttachment(fCreature.ID);

			if (entry == null)
			{
				// If there is no entry, ask to create it
				string msg = "There is no encyclopedia entry associated with this creature.";
				msg += Environment.NewLine;
				msg += "Would you like to create one now?";
				if (MessageBox.Show(msg, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					return;

				entry = new EncyclopediaEntry();
				entry.Name = fCreature.Name;
				entry.AttachmentID = fCreature.ID;
				entry.Category = "Creatures";

				Session.Project.Encyclopedia.Entries.Add(entry);
				Session.Modified = true;
			}

			// Edit the entry
			int index = Session.Project.Encyclopedia.Entries.IndexOf(entry);
			EncyclopediaEntryForm dlg = new EncyclopediaEntryForm(entry);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Session.Project.Encyclopedia.Entries[index] = dlg.Entry;
				Session.Modified = true;

				update_entry();
			}
		}

		private void OptionsPowerBrowser_Click(object sender, EventArgs e)
		{
			PowerBrowserForm dlg = new PowerBrowserForm(fCreature.Name, fCreature.Level, fCreature.Role, add_power);
			dlg.ShowDialog();
		}

		private void AdviceBtn_Click(object sender, EventArgs e)
		{
			if (fSidebar != SidebarType.Advice)
			{
				fSidebar = SidebarType.Advice;
				update_statblock();
			}
		}

		private void PowersBtn_Click(object sender, EventArgs e)
		{
			if (fSidebar != SidebarType.Powers)
			{
				fSidebar = SidebarType.Powers;
				update_statblock();
			}
		}

		private void LevelUpBtn_Click(object sender, EventArgs e)
		{
			CreatureHelper.AdjustCreatureLevel(fCreature, +1);
			find_sample_powers();
			update_statblock();
		}

		private void LevelDownBtn_Click(object sender, EventArgs e)
		{
			CreatureHelper.AdjustCreatureLevel(fCreature, -1);
			find_sample_powers();
			update_statblock();
		}

		#endregion

		#region Picture toolbar

		private void PictureBrowseBtn_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = Program.ImageFilter;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fCreature.Image = Image.FromFile(dlg.FileName);
				Program.SetResolution(fCreature.Image);
				update_picture();
			}
		}

		private void PicturePasteBtn_Click(object sender, EventArgs e)
		{
			if (Clipboard.ContainsImage())
			{
				fCreature.Image = Clipboard.GetImage();
				Program.SetResolution(fCreature.Image);
				update_picture();
			}
		}

		private void PictureClearBtn_Click(object sender, EventArgs e)
		{
			fCreature.Image = null;
			update_picture();
		}

		#endregion

		#region Updating

		void update_view()
		{
			update_statblock();
			update_picture();
		}

		void update_statblock()
		{
			EncounterCard card = new EncounterCard(fCreature);

			List<string> lines = HTML.GetHead("Creature", "", Session.Preferences.TextSize);
			lines.Add("<BODY>");

			lines.Add("<TABLE class=clear>");
			lines.Add("<TR class=clear>");
			lines.Add("<TD class=clear>");

			#region Creature

			lines.Add("<P class=table>");
			lines.AddRange(card.AsText(null, CardMode.Build, true));
			lines.Add("</P>");

			#endregion

			lines.Add("</TD>");

			switch (fSidebar)
			{
				case SidebarType.Advice:
					{
						lines.Add("<TD class=clear>");
						lines.Add("<P class=table>");

						#region Create A New Creature

						bool hybrid = (Session.Creatures.Count >= 2);

						lines.Add("<P class=table>");
						lines.Add("<TABLE>");
						lines.Add("<TR class=heading>");
						lines.Add("<TD><B>Create A New Creature</B></TD>");
						lines.Add("</TR>");
						lines.Add("<TR>");
						lines.Add("<TD>");
						lines.Add("Create a <A href=build:variant>variant</A> of an existing creature");
						lines.Add("</TD>");
						lines.Add("</TR>");
						lines.Add("<TR>");
						lines.Add("<TD>");
						lines.Add("Generate a <A href=build:random>random creature</A>");
						lines.Add("</TD>");
						lines.Add("</TR>");
						if (hybrid)
						{
							lines.Add("<TR>");
							lines.Add("<TD>");
							lines.Add("Generate a <A href=build:hybrid>hybrid creature</A>");
							lines.Add("</TD>");
							lines.Add("</TR>");
						}
						lines.Add("</TABLE>");
						lines.Add("</P>");

						#endregion

						#region Modify This Creature

						bool template = false;
						ComplexRole cr = fCreature.Role as ComplexRole;
						if (cr != null)
							template = (cr.Flag != RoleFlag.Solo);

						lines.Add("<P class=table>");
						lines.Add("<TABLE>");
						lines.Add("<TR class=heading>");
						lines.Add("<TD><B>Modify This Creature</B></TD>");
						lines.Add("</TR>");
						lines.Add("<TR>");
						lines.Add("<TD>");
						lines.Add("Generate a <A href=build:name>new name</A> for this creature");
						lines.Add("</TD>");
						lines.Add("</TR>");
						lines.Add("<TR>");
						lines.Add("<TD>");
						lines.Add("Browse for <A href=power:browse>existing powers</A> for this creature");
						lines.Add("</TD>");
						lines.Add("</TR>");
						if (template)
						{
							lines.Add("<TR>");
							lines.Add("<TD>");
							lines.Add("Apply a <A href=build:template>template</A> to this creature");
							lines.Add("</TD>");
						}
						lines.Add("</TR>");
						lines.Add("<TR>");
						lines.Add("<TD>");
						lines.Add("See <A href=power:statistics>power statistics</A> for other creatures of this type");
						lines.Add("</TD>");
						lines.Add("</TR>");
						lines.Add("</TABLE>");
						lines.Add("</P>");

						#endregion

						#region Advice

						lines.Add("<P class=table>");
						lines.Add("<TABLE>");

						lines.Add("<TR class=heading>");
						lines.Add("<TD colspan=2><B>Creature Advice</B></TD>");
						lines.Add("</TR>");

						int init = Statistics.Initiative(fCreature.Level, fCreature.Role);
						int ac = Statistics.AC(fCreature.Level, fCreature.Role);
						int nad = Statistics.NAD(fCreature.Level, fCreature.Role);

						bool minion = ((fCreature.Role != null) && (fCreature.Role is Minion));
						if (!minion)
						{
							int hp = (minion) ? 1 : Statistics.HP(fCreature.Level, fCreature.Role as ComplexRole, fCreature.Constitution.Score);

							lines.Add("<TR>");
							lines.Add("<TD>Hit Points</TD>");
							lines.Add("<TD align=center>+" + Statistics.AttackBonus(DefenceType.AC, fCreature.Level, fCreature.Role) + "</TD>");
							lines.Add("</TR>");
						}

						lines.Add("<TR>");
						lines.Add("<TD>Initiative Bonus</TD>");
						lines.Add("<TD align=center>+" + init + "</TD>");
						lines.Add("</TR>");

						lines.Add("<TR>");
						lines.Add("<TD>Armour Class</TD>");
						lines.Add("<TD align=center>+" + ac + "</TD>");
						lines.Add("</TR>");

						lines.Add("<TR>");
						lines.Add("<TD>Other Defences</TD>");
						lines.Add("<TD align=center>+" + nad + "</TD>");
						lines.Add("</TR>");

						lines.Add("<TR>");
						lines.Add("<TD>Number of Powers</TD>");
						lines.Add("<TD align=center>4 - 6</TD>");
						lines.Add("</TR>");

						lines.Add("</TABLE>");
						lines.Add("</P>");

						#endregion

						lines.Add("</TD>");
					}
					break;
				case SidebarType.Powers:
					{
						lines.Add("<TD class=clear>");
						lines.Add("<P class=table>");

						#region Powers

						if (fSamplePowers.Count != 0)
						{
							lines.Add("<P text-align=left>");
							lines.Add("The following powers might be suitable for this creature.");
							lines.Add("Click <A href=power:refresh>here</A> to resample this list, or <A href=power:browse>here</A> to look for other powers.");
							lines.Add("</P>");

							lines.Add("<P class=table>");
							lines.Add("<TABLE>");

							Dictionary<CreaturePowerCategory, List<CreaturePower>> powers = new Dictionary<CreaturePowerCategory, List<CreaturePower>>();

							Array power_categories = Enum.GetValues(typeof(CreaturePowerCategory));
							foreach (CreaturePowerCategory cat in power_categories)
								powers[cat] = new List<CreaturePower>();

							foreach (CreaturePower cp in fSamplePowers)
								powers[cp.Category].Add(cp);

							foreach (CreaturePowerCategory cat in power_categories)
							{
								int count = powers[cat].Count;
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

								foreach (CreaturePower cp in powers[cat])
								{
									lines.AddRange(cp.AsHTML(null, CardMode.View, false));

									lines.Add("<TR>");
									lines.Add("<TD colspan=3 align=center>");
									lines.Add("<A href=samplepower:" + cp.ID + ">copy this power into " + fCreature.Name + "</A>");
									lines.Add("</TD>");
									lines.Add("</TR>");
								}
							}

							lines.Add("</TABLE>");
							lines.Add("</P>");
						}

						#endregion

						lines.Add("</TD>");
					}
					break;
			}

			lines.Add("</TR>");
			lines.Add("</TABLE>");

			lines.Add("</BODY>");
			lines.Add("</HTML>");

			StatBlockBrowser.DocumentText = HTML.Concatenate(lines);
		}

		void update_picture()
		{
			PortraitBox.Image = fCreature.Image;
		}

		void update_entry()
		{
			EncyclopediaEntry entry = Session.Project.Encyclopedia.FindEntryForAttachment(fCreature.ID);
			EntryBrowser.DocumentText = HTML.EncyclopediaEntry(entry, Session.Project.Encyclopedia, Session.Preferences.TextSize, true, false, false, false);
		}

		#endregion

		string generate_name()
		{
			string name = ExoticName.SingleName();

			List<ICreature> creatures = find_matching_creatures(fCreature.Role, fCreature.Level, false);
			string desc = find_description(creatures);
			if (desc != "")
				name = name + " " + desc;

			return name;
		}

		string find_description(List<ICreature> creatures)
		{
			List<string> endings = new List<string>();
			endings.Add("er");
			endings.Add("ist");

			List<string> names = new List<string>();
			foreach (ICreature c in creatures)
			{
				string[] tokens = c.Name.Split(null);

				foreach (string token in tokens)
				{
					bool ok = false;
					foreach (string ending in endings)
					{
						if (token.EndsWith(ending))
						{
							ok = true;
							break;
						}
					}

					if (ok)
						names.Add(token);
				}
			}

			if (names.Count != 0)
			{
				int index = Session.Random.Next(names.Count);
				return names[index];
			}

			return "";
		}

		CreaturePower find_power(Guid id)
		{
			foreach (CreaturePower pwr in fCreature.CreaturePowers)
			{
				if (pwr.ID == id)
					return pwr;
			}

			return null;
		}

		Aura find_aura(Guid id)
		{
			foreach (Aura aura in fCreature.Auras)
			{
				if (aura.ID == id)
					return aura;
			}

			return null;
		}

		void add_power(CreaturePower power)
		{
			fCreature.CreaturePowers.Add(power);
			update_statblock();
		}

		void find_sample_powers()
		{
			BinarySearchTree<string> power_names = new BinarySearchTree<string>();
			List<CreaturePower> all_powers = new List<CreaturePower>();

			foreach (CreaturePower power in fCreature.CreaturePowers)
			{
				if (power != null)
					power_names.Add(power.Name.ToLower());
			}

			List<ICreature> creatures = find_matching_creatures(fCreature.Role, fCreature.Level, false);
			foreach (ICreature creature in creatures)
			{
				foreach (CreaturePower power in creature.CreaturePowers)
				{
					if (power == null)
						continue;

					if (power_names.Contains(power.Name.ToLower()))
						continue;

					CreaturePower cp = replace_name(power, creature.Name, creature.Category, fCreature.Name);
					cp = alter_power_level(cp, creature.Level, fCreature.Level);
					if (cp != null)
					{
						all_powers.Add(cp.Copy());
						power_names.Add(cp.Name);
					}
				}
			}

			int count = Math.Min(all_powers.Count, SAMPLE_POWERS);

			fSamplePowers.Clear();
			while (fSamplePowers.Count != count)
			{
				int index = Session.Random.Next(all_powers.Count);
				CreaturePower power = all_powers[index];
				if (power != null)
				{
					fSamplePowers.Add(power);
					all_powers.Remove(power);
				}
			}
		}

		CreaturePower find_sample_power(Guid id)
		{
			foreach (CreaturePower power in fSamplePowers)
			{
				if (power.ID == id)
					return power;
			}

			return null;
		}

		List<ICreature> find_matching_creatures(IRole role, int level, bool exact_match)
		{
			List<ICreature> list = new List<ICreature>();

			int level_delta = exact_match ? 0 : 1;

			List<ICreature> creatures = new List<ICreature>();
			List<Creature> all_creatures = Session.Creatures;
			foreach (ICreature c in all_creatures)
				creatures.Add(c);
			if (Session.Project != null)
			{
				foreach (ICreature c in Session.Project.CustomCreatures)
					creatures.Add(c);
				foreach (ICreature c in Session.Project.NPCs)
					creatures.Add(c);
			}

			foreach (ICreature creature in creatures)
			{
				bool match_level = (Math.Abs(creature.Level - level) <= level_delta);
				bool match_role = (creature.Role.ToString() == role.ToString());

				if (match_level && match_role)
					list.Add(creature);
			}

			return list;
		}

		CreaturePower replace_name(CreaturePower power, string original_name, string original_category, string replacement)
		{
			CreaturePower cp = power.Copy();

			if (!string.IsNullOrEmpty(original_name) && !replacement.Contains(original_name))
			{
				cp.Details = replace_text(cp.Details, original_name, replacement);
				cp.Description = replace_text(cp.Description, original_name, replacement);
				cp.Condition = replace_text(cp.Condition, original_name, replacement);
				cp.Range = replace_text(cp.Range, original_name, replacement);
			}

			if (!string.IsNullOrEmpty(original_category) && !replacement.Contains(original_category))
			{
				cp.Details = replace_text(cp.Details, original_category, replacement);
				cp.Description = replace_text(cp.Description, original_category, replacement);
				cp.Condition = replace_text(cp.Condition, original_category, replacement);
				cp.Range = replace_text(cp.Range, original_category, replacement);
			}

			return cp;
		}

		string replace_text(string source, string original, string replacement)
		{
			if ((source == null) || (original == null) || (replacement == null))
				return source;

			// Make sure we don't get into an infinite loop
			if (replacement.Contains(original))
				return source;

			string str = source;

			while (true)
			{
				int index = str.ToLower().IndexOf(original.ToLower());
				if (index == -1)
					break;

				string prefix = str.Substring(0, index);
				string suffix = str.Substring(index + original.Length);
				str = prefix + replacement.ToLower() + suffix;
			}

			return str;
		}

		void create_random()
		{
			RandomCreatureForm dlg = new RandomCreatureForm(fCreature.Level, fCreature.Role);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				List<ICreature> creatures = find_matching_creatures(dlg.Role, dlg.Level, true);
				if (creatures.Count == 0)
					return;

				splice(creatures);

				find_sample_powers();
				update_view();
			}
		}

		void create_variant()
		{
			VariantWizard wizard = new VariantWizard();
			if (wizard.Show() == DialogResult.OK)
			{
				VariantData data = wizard.Data as VariantData;

				EncounterCard card = new EncounterCard();
				card.CreatureID = data.BaseCreature.ID;
				foreach (CreatureTemplate ct in data.Templates)
					card.TemplateIDs.Add(ct.ID);

				ICreature custom = null;

				if (fCreature is Creature)
					custom = new Creature();

				if (fCreature is CustomCreature)
					custom = new CustomCreature();

				if (fCreature is NPC)
					custom = new NPC();

				custom.Name = "Variant " + card.Title;
				custom.Details = data.BaseCreature.Details;
				custom.Size = data.BaseCreature.Size;
				custom.Level = card.Level;
				if (data.BaseCreature.Image != null)
					custom.Image = new Bitmap(data.BaseCreature.Image);

				custom.Senses = card.Senses;
				custom.Movement = card.Movement;
				custom.Resist = card.Resist;
				custom.Vulnerable = card.Vulnerable;
				custom.Immune = card.Immune;

				if (data.BaseCreature.Role is Minion)
				{
					custom.Role = new Minion();
				}
				else
				{
					ComplexRole cr = new ComplexRole();

					cr.Type = data.Roles[data.SelectedRoleIndex];
					cr.Flag = card.Flag;
					cr.Leader = card.Leader;

					custom.Role = cr;
				}

				// Set ability scores
				custom.Strength.Score = data.BaseCreature.Strength.Score;
				custom.Constitution.Score = data.BaseCreature.Constitution.Score;
				custom.Dexterity.Score = data.BaseCreature.Dexterity.Score;
				custom.Intelligence.Score = data.BaseCreature.Intelligence.Score;
				custom.Wisdom.Score = data.BaseCreature.Wisdom.Score;
				custom.Charisma.Score = data.BaseCreature.Charisma.Score;

				// Combat stats
				custom.Initiative = data.BaseCreature.Initiative;
				custom.HP = card.HP;
				custom.AC = card.AC;
				custom.Fortitude = card.Fortitude;
				custom.Reflex = card.Reflex;
				custom.Will = card.Will;

				// Regeneration
				custom.Regeneration = (card.Regeneration != null) ? card.Regeneration : null;

				// Auras
				List<Aura> auras = card.Auras;
				foreach (Aura aura in auras)
					custom.Auras.Add(aura.Copy());

				// Add powers
				List<CreaturePower> powers = card.CreaturePowers;
				foreach (CreaturePower power in powers)
					custom.CreaturePowers.Add(power.Copy());

				// Add damage modifiers
				List<DamageModifier> mods = card.DamageModifiers;
				foreach (DamageModifier mod in mods)
					custom.DamageModifiers.Add(mod.Copy());

				Guid id = fCreature.ID;
				CreatureHelper.CopyFields(custom, fCreature);
				//fCreature = custom;
				fCreature.ID = id;

				find_sample_powers();
				update_view();
			}
		}

		void create_hybrid()
		{
			CreatureMultipleSelectForm dlg = new CreatureMultipleSelectForm();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				splice(dlg.SelectedCreatures);

				find_sample_powers();
				update_view();
			}
		}

		void splice(List<ICreature> genepool)
		{
			if (fCreature is Creature)
				fCreature = new Creature();

			if (fCreature is CustomCreature)
				fCreature = new CustomCreature();

			if (fCreature is NPC)
				fCreature = new NPC();

			// Level
			int min_level = int.MaxValue;
			int max_level = int.MinValue;
			foreach (Creature c in genepool)
			{
				min_level = Math.Min(min_level, c.Level);
				max_level = Math.Max(max_level, c.Level);
			}
			fCreature.Level = Session.Random.Next(min_level, max_level + 1);

			// Role
			int role_index = Session.Random.Next(genepool.Count);
			fCreature.Role = genepool[role_index].Role.Copy();

			// Phenotype
			int size_index = Session.Random.Next(genepool.Count);
			fCreature.Size = genepool[size_index].Size;
			int origin_index = Session.Random.Next(genepool.Count);
			fCreature.Origin = genepool[origin_index].Origin;
			int type_index = Session.Random.Next(genepool.Count);
			fCreature.Type = genepool[type_index].Type;

			// Name and category
			string common_name = find_common_name(genepool);
			if (common_name == "")
			{
				fCreature.Name = generate_name();
			}
			else
			{
				fCreature.Name = common_name;

				string desc = find_description(genepool);
				if (desc != "")
					fCreature.Name += " " + desc;
				else
					fCreature.Name = "New " + fCreature.Name;
			}
			fCreature.Category = "";

			// Keywords
			int keyword_index = Session.Random.Next(genepool.Count);
			fCreature.Keywords = genepool[keyword_index].Keywords;

			// Ability scores
			int score_index = Session.Random.Next(genepool.Count);
			fCreature.Strength.Score = genepool[score_index].Strength.Score;
			fCreature.Constitution.Score = genepool[score_index].Constitution.Score;
			fCreature.Dexterity.Score = genepool[score_index].Dexterity.Score;
			fCreature.Intelligence.Score = genepool[score_index].Intelligence.Score;
			fCreature.Wisdom.Score = genepool[score_index].Wisdom.Score;
			fCreature.Charisma.Score = genepool[score_index].Charisma.Score;

			// Defences
			int def_index = Session.Random.Next(genepool.Count);
			int expected_ac = Statistics.AC(genepool[def_index].Level, genepool[def_index].Role);
			int expected_nad = Statistics.NAD(genepool[def_index].Level, genepool[def_index].Role);
			int observed_ac = genepool[def_index].AC;
			int observed_fort = genepool[def_index].Fortitude;
			int observed_ref = genepool[def_index].Reflex;
			int observed_will = genepool[def_index].Will;
			int bonus_ac = observed_ac - expected_ac;
			int bonus_fort = observed_fort - expected_nad;
			int bonus_ref = observed_ref - expected_nad;
			int bonus_will = observed_will - expected_nad;
			fCreature.AC = Statistics.AC(fCreature.Level, fCreature.Role) + bonus_ac;
			fCreature.Fortitude = Statistics.NAD(fCreature.Level, fCreature.Role) + bonus_fort;
			fCreature.Reflex = Statistics.NAD(fCreature.Level, fCreature.Role) + bonus_ref;
			fCreature.Will = Statistics.NAD(fCreature.Level, fCreature.Role) + bonus_will;

			// HP
			if (fCreature.Role is ComplexRole)
			{
				List<ICreature> non_minions = new List<ICreature>();
				foreach (ICreature c in genepool)
				{
					if (c.Role is ComplexRole)
						non_minions.Add(c);
				}
				int hp_index = Session.Random.Next(non_minions.Count);

				int expected_hp = Statistics.HP(non_minions[hp_index].Level, non_minions[hp_index].Role as ComplexRole, non_minions[hp_index].Constitution.Score);
				int observed_hp = non_minions[hp_index].HP;
				int bonus_hp = observed_hp - expected_hp;
				fCreature.HP = Statistics.HP(fCreature.Level, fCreature.Role as ComplexRole, fCreature.Constitution.Score) + bonus_hp;
			}

			// Init
			int init_index = Session.Random.Next(genepool.Count);
			int expected_init = Statistics.Initiative(genepool[init_index].Level, genepool[init_index].Role);
			int observed_init = genepool[init_index].Initiative;
			int bonus_init = observed_init - expected_init;
			fCreature.Initiative = Statistics.Initiative(fCreature.Level, fCreature.Role) + bonus_init;

			// Languages
			int langs_index = Session.Random.Next(genepool.Count);
			fCreature.Languages = genepool[langs_index].Languages;

			// Movement
			int move_index = Session.Random.Next(genepool.Count);
			fCreature.Movement = genepool[move_index].Movement;

			// Senses
			int senses_index = Session.Random.Next(genepool.Count);
			fCreature.Senses = genepool[senses_index].Senses;

			// Damage modifiers
			int damage_index = Session.Random.Next(genepool.Count);
			fCreature.DamageModifiers.Clear();
			foreach (DamageModifier dm in genepool[damage_index].DamageModifiers)
				fCreature.DamageModifiers.Add(dm.Copy());
			fCreature.Resist = genepool[damage_index].Resist;
			fCreature.Vulnerable = genepool[damage_index].Vulnerable;
			fCreature.Immune = genepool[damage_index].Immune;

			// Auras
			int aura_index = Session.Random.Next(genepool.Count);
			fCreature.Auras.Clear();
			foreach (Aura a in genepool[aura_index].Auras)
				fCreature.Auras.Add(a.Copy());

			// Regeneration
			int regen_index = Session.Random.Next(genepool.Count);
			fCreature.Regeneration = genepool[regen_index].Regeneration;

			Dictionary<CreaturePowerCategory, List<CreaturePower>> powers = new Dictionary<CreaturePowerCategory, List<CreaturePower>>();
			Dictionary<Guid, string> creature_name_lookup = new Dictionary<Guid, string>();
			Dictionary<Guid, string> creature_category_lookup = new Dictionary<Guid, string>();

			Array power_categories = Enum.GetValues(typeof(CreaturePowerCategory));
			foreach (CreaturePowerCategory cat in power_categories)
				powers[cat] = new List<CreaturePower>();

			foreach (ICreature c in genepool)
			{
				foreach (CreaturePower cp in c.CreaturePowers)
				{
					powers[cp.Category].Add(cp);
					creature_name_lookup[cp.ID] = c.Name;
					creature_category_lookup[cp.ID] = c.Name;
				}
			}

			// Powers
			fCreature.CreaturePowers.Clear();
			foreach (CreaturePowerCategory cat in power_categories)
			{
				if (powers[cat].Count == 0)
					continue;

				int count = powers[cat].Count / genepool.Count;
				if (Session.Random.Next(6) == 0)
					count += 1;

				for (int n = 0; n != count; ++n)
				{
					int power_index = Session.Random.Next(powers[cat].Count);
					CreaturePower cp = powers[cat][power_index];

					// Remove original creature name / category
					string name = creature_name_lookup[cp.ID];
					string category = creature_category_lookup[cp.ID];
					cp = replace_name(cp, name, category, fCreature.Name);

					fCreature.CreaturePowers.Add(cp);
				}
			}

			// Skills
			int skills_index = Session.Random.Next(genepool.Count);
			fCreature.Skills = genepool[skills_index].Skills;

			// Alignment
			int align_index = Session.Random.Next(genepool.Count);
			fCreature.Alignment = genepool[align_index].Alignment;

			// Tactics, equipment, details
			fCreature.Tactics = "";
			fCreature.Equipment = "";
			fCreature.Details = "";

			fCreature.Image = null;
		}

		CreaturePower alter_power_level(CreaturePower power, int original_level, int new_level)
		{
			CreaturePower cp = power.Copy();

			int delta = new_level - original_level;
			CreatureHelper.AdjustPowerLevel(cp, delta);

			if ((original_level <= 15) && (new_level > 15))
			{
				// Dazed => Stunned
				cp.Details = cp.Details.Replace("Dazed", "Stunned");
				cp.Details = cp.Details.Replace("dazed", "stunned");

				// Slowed => Immobilised
				cp.Details = cp.Details.Replace("Slowed", "Immobilised");
				cp.Details = cp.Details.Replace("slowed", "immobilised");
			}

			if ((original_level > 15) && (new_level <= 15))
			{
				// Stunned => Dazed
				cp.Details = cp.Details.Replace("Stunned", "Dazed");
				cp.Details = cp.Details.Replace("Stunned", "Dazed");

				// Immobilised => Immobilized
				cp.Details = cp.Details.Replace("Immobilised", "Immobilized");
				cp.Details = cp.Details.Replace("immobilised", "immobilized");
				
				// Immobilized => Slowed
				cp.Details = cp.Details.Replace("Immobilized", "Slowed");
				cp.Details = cp.Details.Replace("immobilized", "slowed");
			}

			return cp;
		}

		string find_common_name(List<ICreature> creatures)
		{
			const int MIN_NAME_LENGTH = 3;
			Dictionary<string, int> suggestions = new Dictionary<string, int>();

			for (int x = 0; x != creatures.Count; ++x)
			{
				string name_x = creatures[x].Name;

				for (int y = x + 1; y != creatures.Count; ++y)
				{
					string name_y = creatures[y].Name;

					string lcs = StringHelper.LongestCommonToken(name_x, name_y);
					if (lcs.Length >= MIN_NAME_LENGTH)
					{
						if (!suggestions.ContainsKey(lcs))
							suggestions[lcs] = 0;

						suggestions[lcs] += 1;
					}
				}
			}

			string selected = "";

			if (suggestions.Keys.Count != 0)
			{
				foreach (string token in suggestions.Keys)
				{
					int current = (suggestions.ContainsKey(selected)) ? suggestions[selected] : 0;
					if (suggestions[token] > current)
						selected = token;
				}
			}

			return selected;
		}

		private void FileExport_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Title = "Export Creature";
			dlg.FileName = fCreature.Name;
			dlg.Filter = Program.CreatureFilter;

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Creature c = new Creature(fCreature);
				bool ok = Serialisation<Creature>.Save(dlg.FileName, c, SerialisationMode.Binary);

				if (!ok)
				{
					string error = "The creature could not be exported.";
					MessageBox.Show(error, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
	}
}
