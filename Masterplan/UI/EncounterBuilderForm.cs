using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

using Masterplan.Controls;
using Masterplan.Data;
using Masterplan.Events;
using Masterplan.Tools;
using Masterplan.Tools.Generators;
using Masterplan.Wizards;

namespace Masterplan.UI
{
	enum ListMode
	{
		Creatures,
		Templates,
		NPCs,
		Traps,
		SkillChallenges
	}

	partial class EncounterBuilderForm : Form
	{
		public EncounterBuilderForm(Encounter enc, int party_level, bool adding_threats)
		{
			InitializeComponent();

			fMode = ListMode.Creatures;
			fEncounter = enc.Copy() as Encounter;
			fPartyLevel = party_level;
			fAddingThreats = adding_threats;

			SourceItemList.ListViewItemSorter = new SourceSorter();
			NoteDetails.DocumentText = "";

            ToolsUseDeck.Visible = (Session.Project.Decks.Count != 0);

			FilterPanel.Mode = fMode;
			FilterPanel.PartyLevel = fPartyLevel;
			FilterPanel.FilterByPartyLevel();

			Application.Idle += new EventHandler(Application_Idle);

			if (fAddingThreats)
			{
				Pages.TabPages.Remove(MapPage);
				Pages.TabPages.Remove(NotesPage);

				VSplitter.Panel2Collapsed = true;
			}
			else
			{
				Map m = (fEncounter.MapID != Guid.Empty) ? Session.Project.FindTacticalMap(fEncounter.MapID) : null;
				if (m != null)
				{
					MapView.Map = m;
					MapView.Encounter = fEncounter;

					MapArea ma = (fEncounter.MapAreaID != Guid.Empty) ? m.FindArea(fEncounter.MapAreaID) : null;
					MapView.Viewpoint = (ma != null) ? ma.Region : Rectangle.Empty;
				}

				update_difficulty_list();
				update_mapthreats();
				update_notes();
				update_selected_note();
			}

			update_source_list();
			update_encounter();
			update_party_label();
		}

		~EncounterBuilderForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			try
			{
				if (Pages.SelectedTab == ThreatsPage)
				{
					bool selected = ((SelectedSlot != null) || (SelectedSlotTrap != null) || (SelectedSlotSkillChallenge != null));

					AddBtn.Enabled = selected;
					AddBtn.Visible = ((SelectedSlot != null) || (SelectedSlotTrap != null));
					RemoveBtn.Enabled = selected;
					StatBlockBtn.Enabled = selected;

					if ((SelectedSlotTrap != null) || (SelectedSlotSkillChallenge != null))
					{
						RemoveBtn.Text = "Remove";
					}
					else
					{
						RemoveBtn.Text = "-";
					}

					CreaturesBtn.Visible = (Session.Creatures.Count != 0);
					TrapsBtn.Visible = (Session.Traps.Count != 0);
					ChallengesBtn.Visible = (Session.SkillChallenges.Count != 0);

					CreaturesBtn.Checked = (fMode == ListMode.Creatures);
					TrapsBtn.Checked = (fMode == ListMode.Traps);
					ChallengesBtn.Checked = (fMode == ListMode.SkillChallenges);
				}

				if (Pages.SelectedTab == MapPage)
				{
					MapToolsLOS.Checked = MapView.LineOfSight;
					MapToolsGridlines.Checked = (MapView.ShowGrid != MapGridMode.None);
					MapToolsGridLabels.Checked = MapView.ShowGridLabels;
					MapToolsPictureTokens.Checked = MapView.ShowPictureTokens;
					MapToolsPrint.Enabled = (MapView.Map != null);
					MapToolsScreenshot.Enabled = (MapView.Map != null);

					MapSplitter.Panel2Collapsed = ((MapView.Map == null) || (MapThreatList.Items.Count == 0));

					MapContextView.Enabled = (MapView.SelectedTokens.Count == 1);
					MapContextSetPicture.Enabled = (MapView.SelectedTokens.Count == 1);
					MapContextRemove.Enabled = (MapView.SelectedTokens.Count != 0);
					MapContextRemoveEncounter.Enabled = (MapView.SelectedTokens.Count != 0);
					MapContextCopy.Enabled = ((MapView.SelectedTokens.Count == 1) && (MapView.SelectedTokens[0] is CustomToken));

					if (MapView.SelectedTokens.Count == 1)
					{
						MapContextVisible.Enabled = true;

						IToken token = MapView.SelectedTokens[0];

						if (token is CreatureToken)
						{
							CreatureToken ct = token as CreatureToken;
							MapContextVisible.Checked = ct.Data.Visible;
						}
						if (token is CustomToken)
						{
							CustomToken ct = token as CustomToken;
							MapContextVisible.Checked = ct.Data.Visible;
						}
					}
					else
					{
						MapContextVisible.Enabled = false;
						MapContextVisible.Checked = false;
					}
				}

				if (Pages.SelectedTab == NotesPage)
				{
					NoteRemoveBtn.Enabled = (SelectedNote != null);
					NoteEditBtn.Enabled = (SelectedNote != null);
					NoteUpBtn.Enabled = ((SelectedNote != null) && (fEncounter.Notes.IndexOf(SelectedNote) != 0));
					NoteDownBtn.Enabled = ((SelectedNote != null) && (fEncounter.Notes.IndexOf(SelectedNote) != fEncounter.Notes.Count - 1));
				}
            }
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#region Properties

		public Encounter Encounter
		{
			get { return fEncounter; }
		}
		Encounter fEncounter = new Encounter();

		int fPartyLevel = Session.Project.Party.Level;
		int fPartySize = Session.Project.Party.Size;

		public EncounterSlot SelectedSlot
		{
			get
			{
				if (SlotList.SelectedItems.Count != 0)
					return SlotList.SelectedItems[0].Tag as EncounterSlot;

				return null;
			}
		}

		public Trap SelectedSlotTrap
		{
			get
			{
				if (SlotList.SelectedItems.Count != 0)
					return SlotList.SelectedItems[0].Tag as Trap;

				return null;
			}
		}

		public SkillChallenge SelectedSlotSkillChallenge
		{
			get
			{
				if (SlotList.SelectedItems.Count != 0)
					return SlotList.SelectedItems[0].Tag as SkillChallenge;

				return null;
			}
		}

		public ICreature SelectedCreature
		{
			get
			{
				if (SourceItemList.SelectedItems.Count != 0)
					return SourceItemList.SelectedItems[0].Tag as ICreature;

				return null;
			}
		}

		public CreatureTemplate SelectedTemplate
		{
			get
			{
				if (SourceItemList.SelectedItems.Count != 0)
					return SourceItemList.SelectedItems[0].Tag as CreatureTemplate;

				return null;
			}
		}

		public NPC SelectedNPC
		{
			get
			{
				if (SourceItemList.SelectedItems.Count != 0)
					return SourceItemList.SelectedItems[0].Tag as NPC;

				return null;
			}
		}

		public Trap SelectedTrap
		{
			get
			{
				if (SourceItemList.SelectedItems.Count != 0)
					return SourceItemList.SelectedItems[0].Tag as Trap;

				return null;
			}
		}

		public SkillChallenge SelectedSkillChallenge
		{
			get
			{
				if (SourceItemList.SelectedItems.Count != 0)
					return SourceItemList.SelectedItems[0].Tag as SkillChallenge;

				return null;
			}
		}

		public IToken SelectedMapThreat
		{
			get
			{
				if (MapThreatList.SelectedItems.Count != 0)
					return MapThreatList.SelectedItems[0].Tag as IToken;

				return null;
			}
		}

		bool fAddingThreats = false;

		ListMode fMode = ListMode.Creatures;

		#endregion

		#region Threats Page

		#region Encounter list toolbar

		#region Plus / minus

		private void AddBtn_Click(object sender, EventArgs e)
		{
			if (SelectedSlot != null)
			{
				if ((ModifierKeys & Keys.Shift) == Keys.Shift)
				{
					SelectedSlot.Card.LevelAdjustment += 1;

					update_encounter();
				}
				else
				{
					CombatData cd = new CombatData();
					SelectedSlot.CombatData.Add(cd);

					update_encounter();
					update_mapthreats();
				}
			}

			if (SelectedSlotTrap != null)
			{
				Trap trap = SelectedSlotTrap.Copy();
				trap.ID = Guid.NewGuid();

				fEncounter.Traps.Add(trap);

				update_encounter();
			}

			if (SelectedSlotSkillChallenge != null)
			{
				SkillChallenge sc = SelectedSlotSkillChallenge.Copy() as SkillChallenge;
				sc.ID = Guid.NewGuid();

				fEncounter.SkillChallenges.Add(sc);

				update_encounter();
			}
		}

		private void RemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedSlot != null)
			{
				if ((ModifierKeys & Keys.Shift) == Keys.Shift)
				{
					if (SelectedSlot.Card.Level > 1)
					{
						SelectedSlot.Card.LevelAdjustment -= 1;

						update_encounter();
					}
				}
				else
				{
					SelectedSlot.CombatData.RemoveAt(SelectedSlot.CombatData.Count - 1);

					if (SelectedSlot.CombatData.Count == 0)
						fEncounter.Slots.Remove(SelectedSlot);

					update_encounter();
					update_mapthreats();
				}
			}

			if (SelectedSlotTrap != null)
			{
				fEncounter.Traps.Remove(SelectedSlotTrap);

				update_encounter();
			}

			if (SelectedSlotSkillChallenge != null)
			{
				fEncounter.SkillChallenges.Remove(SelectedSlotSkillChallenge);

				update_encounter();
			}
		}

		#endregion

		private void StatBlockBtn_Click(object sender, EventArgs e)
		{
			if (SelectedSlot != null)
			{
				CreatureDetailsForm dlg = new CreatureDetailsForm(SelectedSlot.Card);
				dlg.ShowDialog();
			}

			if (SelectedSlotTrap != null)
			{
				TrapDetailsForm dlg = new TrapDetailsForm(SelectedSlotTrap);
				dlg.ShowDialog();
			}

			if (SelectedSlotSkillChallenge != null)
			{
				SkillChallengeDetailsForm dlg = new SkillChallengeDetailsForm(SelectedSlotSkillChallenge);
				dlg.ShowDialog();
			}
		}

		#region Edit menu

		private void EditStatBlock_Click(object sender, EventArgs e)
		{
			if (SelectedSlot != null)
			{
				Guid id = SelectedSlot.Card.CreatureID;

				CustomCreature cc = Session.Project.FindCustomCreature(id);
				NPC npc = Session.Project.FindNPC(id);

				if (cc != null)
				{
					int index = Session.Project.CustomCreatures.IndexOf(cc);

					//CustomCreatureForm dlg = new CustomCreatureForm(cc);
					CreatureBuilderForm dlg = new CreatureBuilderForm(cc);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						SelectedSlot.SetDefaultDisplayNames();

						Session.Project.CustomCreatures[index] = dlg.Creature as CustomCreature;
						Session.Modified = true;

						update_encounter();
						update_source_list();
						update_mapthreats();
					}
				}
				else if (npc != null)
				{
					int index = Session.Project.NPCs.IndexOf(npc);

					CreatureBuilderForm dlg = new CreatureBuilderForm(npc);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						SelectedSlot.SetDefaultDisplayNames();

						Session.Project.NPCs[index] = dlg.Creature as NPC;
						Session.Modified = true;

						update_encounter();
						update_source_list();
						update_mapthreats();
					}
				}
				else
				{
					string msg = "You're about to edit a creature's stat block. Do you want to change this creature globally?";
					msg += Environment.NewLine;
					msg += Environment.NewLine;
					msg += "Press Yes to apply your changes to this creature, everywhere it appears, even in other projects. Select this option if you're correcting an error in the creature's stat block.";
					msg += Environment.NewLine;
					msg += Environment.NewLine;
					msg += "Press No to apply your changes to a copy of this creature. Select this option if you're modifying or re-skinning the creature for this encounter only, leaving other encounters as they are.";

					DialogResult dr = MessageBox.Show(msg, "Masterplan", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
					switch (dr)
					{
						case DialogResult.Yes:
							{
								// Edit the base creature
								Creature original = Session.FindCreature(id, SearchType.Global) as Creature;
								Library lib = Session.FindLibrary(original);
								int index = lib.Creatures.IndexOf(original);

								CreatureBuilderForm dlg = new CreatureBuilderForm(original);
								if (dlg.ShowDialog() == DialogResult.OK)
								{
									SelectedSlot.SetDefaultDisplayNames();
									
									lib.Creatures[index] = dlg.Creature as Creature;

									// Save the library
									string filename = Session.GetLibraryFilename(lib);
									Serialisation<Library>.Save(filename, lib, SerialisationMode.Binary);

									update_encounter();
									update_source_list();
									update_mapthreats();
								}
							}
							break;
						case DialogResult.No:
							{
								// Make it into a custom creature
								ICreature original = Session.FindCreature(id, SearchType.Global);
								CustomCreature creature = new CustomCreature(original);
								CreatureHelper.AdjustCreatureLevel(creature, SelectedSlot.Card.LevelAdjustment);
								creature.ID = Guid.NewGuid();

								//CustomCreatureForm dlg = new CustomCreatureForm(creature);
								CreatureBuilderForm dlg = new CreatureBuilderForm(creature);
								if (dlg.ShowDialog() == DialogResult.OK)
								{
									Session.Project.CustomCreatures.Add(dlg.Creature as CustomCreature);
									Session.Modified = true;

									SelectedSlot.Card.CreatureID = dlg.Creature.ID;
									SelectedSlot.Card.LevelAdjustment = 0;
									SelectedSlot.SetDefaultDisplayNames();

									update_encounter();
									update_source_list();
									update_mapthreats();
								}
							}
							break;
					}
				}
			}

			if (SelectedSlotTrap != null)
			{
				int index = fEncounter.Traps.IndexOf(SelectedSlotTrap);

				TrapBuilderForm dlg = new TrapBuilderForm(SelectedSlotTrap);
				//TrapForm dlg = new TrapForm(SelectedSlotTrap);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					dlg.Trap.ID = Guid.NewGuid();

					fEncounter.Traps[index] = dlg.Trap;

					update_encounter();
				}
			}

			if (SelectedSlotSkillChallenge != null)
			{
				int index = fEncounter.SkillChallenges.IndexOf(SelectedSlotSkillChallenge);

				SkillChallengeBuilderForm dlg = new SkillChallengeBuilderForm(SelectedSlotSkillChallenge);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					dlg.SkillChallenge.ID = Guid.NewGuid();

					fEncounter.SkillChallenges[index] = dlg.SkillChallenge;

					update_encounter();
				}
			}
		}

		void count_slot_as(object sender, EventArgs e)
		{
			if (SelectedSlot != null)
			{
				ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
				EncounterSlotType type = (EncounterSlotType)tsmi.Tag;

				SelectedSlot.Type = type;
				update_encounter();
			}
		}

		private void EditRemoveTemplate_Click(object sender, EventArgs e)
		{
			if ((SelectedSlot != null) && (SelectedSlot.Card.TemplateIDs.Count != 0))
			{
				SelectedSlot.Card.TemplateIDs.Clear();

				update_encounter();
				update_mapthreats();
			}
		}

		private void EditRemoveLevelAdj_Click(object sender, EventArgs e)
		{
			if ((SelectedSlot != null) && (SelectedSlot.Card.LevelAdjustment != 0))
			{
				SelectedSlot.Card.LevelAdjustment = 0;

				update_encounter();
				update_mapthreats();
			}
		}

		#region Swapping

		private void SwapStandard_Click(object sender, EventArgs e)
		{
			EncounterCard card = SelectedSlot.Card;
			ICreature selected = Session.FindCreature(card.CreatureID, SearchType.Global);

			// Work out how many to use
			int count = 1;
			if (selected.Role is Minion)
			{
				count = SelectedSlot.CombatData.Count / 4;
			}
			else
			{
				switch (card.Flag)
				{
					case RoleFlag.Standard:
						count = SelectedSlot.CombatData.Count;
						break;
					case RoleFlag.Elite:
						count = SelectedSlot.CombatData.Count * 2;
						break;
					case RoleFlag.Solo:
						count = SelectedSlot.CombatData.Count * 5;
						break;
				}
			}

			// Find all standard creatures of this level and role
			List<Creature> creatures = find_creatures(RoleFlag.Standard, card.Level, card.Roles);
			if (creatures.Count == 0)
			{
				string msg = "There are no creatures of this type.";
				MessageBox.Show(msg, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			Creature creature = choose_creature(creatures, selected.Category);
			if (creature == null)
				return;

			perform_swap(creature, count, SelectedSlot);
		}

		private void SwapElite_Click(object sender, EventArgs e)
		{
			EncounterCard card = SelectedSlot.Card;
			ICreature selected = Session.FindCreature(card.CreatureID, SearchType.Global);

			// Work out how many to use
			int count = 1;
			if (selected.Role is Minion)
			{
				count = SelectedSlot.CombatData.Count / 8;
			}
			else
			{
				switch (card.Flag)
				{
					case RoleFlag.Standard:
						count = SelectedSlot.CombatData.Count / 2;
						break;
					case RoleFlag.Elite:
						count = SelectedSlot.CombatData.Count;
						break;
					case RoleFlag.Solo:
						count = SelectedSlot.CombatData.Count * 5 / 2;
						break;
				}
			}

			// Find all elite creatures of this level and role
			List<Creature> creatures = find_creatures(RoleFlag.Elite, card.Level, card.Roles);
			if (creatures.Count == 0)
			{
				string msg = "There are no creatures of this type.";
				MessageBox.Show(msg, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			Creature creature = choose_creature(creatures, selected.Category);
			if (creature == null)
				return;

			perform_swap(creature, count, SelectedSlot);
		}

		private void SwapSolo_Click(object sender, EventArgs e)
		{
			EncounterCard card = SelectedSlot.Card;
			ICreature selected = Session.FindCreature(card.CreatureID, SearchType.Global);

			// Work out how many to use
			int count = 1;
			if (selected.Role is Minion)
			{
				count = SelectedSlot.CombatData.Count / 20;
			}
			else
			{
				switch (card.Flag)
				{
					case RoleFlag.Standard:
						count = SelectedSlot.CombatData.Count / 5;
						break;
					case RoleFlag.Elite:
						count = SelectedSlot.CombatData.Count * 2 / 5;
						break;
					case RoleFlag.Solo:
						count = SelectedSlot.CombatData.Count;
						break;
				}
			}

			// Find all solo creatures of this level and role
			List<Creature> creatures = find_creatures(RoleFlag.Solo, card.Level, card.Roles);
			if (creatures.Count == 0)
			{
				string msg = "There are no creatures of this type.";
				MessageBox.Show(msg, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			Creature creature = choose_creature(creatures, selected.Category);
			if (creature == null)
				return;

			perform_swap(creature, count, SelectedSlot);
		}

		private void SwapMinions_Click(object sender, EventArgs e)
		{
			EncounterCard card = SelectedSlot.Card;
			ICreature selected = Session.FindCreature(card.CreatureID, SearchType.Global);

			// Work out how many to use
			int count = 1;
			if (selected.Role is Minion)
			{
				count = SelectedSlot.CombatData.Count / 4;
			}
			else
			{
				switch (card.Flag)
				{
					case RoleFlag.Standard:
						count = SelectedSlot.CombatData.Count * 4;
						break;
					case RoleFlag.Elite:
						count = SelectedSlot.CombatData.Count * 8;
						break;
					case RoleFlag.Solo:
						count = SelectedSlot.CombatData.Count * 20;
						break;
				}
			}

			// Find all minions of this level
			List<Creature> creatures = find_minions(card.Level);
			if (creatures.Count == 0)
			{
				string msg = "There are no creatures of this type.";
				MessageBox.Show(msg, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			Creature creature = choose_creature(creatures, selected.Category);
			if (creature == null)
				return;

			perform_swap(creature, count, SelectedSlot);
		}

		List<Creature> find_creatures(RoleFlag flag, int level, List<RoleType> roles)
		{
			List<Creature> creatures = new List<Creature>();

			foreach (Library lib in Session.Libraries)
			{
				foreach (Creature c in lib.Creatures)
				{
					if (c.Role is Minion)
						continue;

					ComplexRole role = c.Role as ComplexRole;

					if ((role.Flag == flag) && (c.Level == level))
					{
						if ((roles.Count == 0) || (roles.Contains(role.Type)))
							creatures.Add(c);
					}
				}
			}

			return creatures;
		}

		List<Creature> find_minions(int level)
		{
			List<Creature> creatures = new List<Creature>();

			foreach (Library lib in Session.Libraries)
			{
				foreach (Creature c in lib.Creatures)
				{
					if ((c.Role is Minion) && (c.Level == level))
						creatures.Add(c);
				}
			}

			return creatures;
		}

		Creature choose_creature(List<Creature> creatures, string category)
		{
			CreatureSelectForm dlg = new CreatureSelectForm(creatures);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				EncounterCard card = dlg.Creature;
				return Session.FindCreature(card.CreatureID, SearchType.Global) as Creature;
			}

			return null;
		}

		void perform_swap(Creature creature, int count, EncounterSlot old_slot)
		{
			EncounterSlot newslot = new EncounterSlot();
			newslot.Card.CreatureID = creature.ID;
			for (int n = 0; n != count; ++n)
			{
				CombatData ccd = new CombatData();
				newslot.CombatData.Add(ccd);
			}

			fEncounter.Slots.Remove(old_slot);
			fEncounter.Slots.Add(newslot);

			update_encounter();
			update_mapthreats();
		}

		#endregion

		private void EditApplyTheme_Click(object sender, EventArgs e)
		{
			if (SelectedSlot == null)
				return;

			ThemeForm dlg = new ThemeForm(SelectedSlot.Card);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				SelectedSlot.Card = dlg.Card;

				update_encounter();
				update_mapthreats();
			}
		}

		private void EditClearTheme_Click(object sender, EventArgs e)
		{
			if (SelectedSlot == null)
				return;

			SelectedSlot.Card.ThemeID = Guid.Empty;

			SelectedSlot.Card.ThemeAttackPowerID = Guid.Empty;
			SelectedSlot.Card.ThemeUtilityPowerID = Guid.Empty;

			update_encounter();
			update_mapthreats();
		}

		#endregion

		#region Tools menu

		private void ToolsClearAll_Click(object sender, EventArgs e)
		{
			fEncounter.Slots.Clear();
			fEncounter.Traps.Clear();
			fEncounter.SkillChallenges.Clear();

			update_encounter();
			update_mapthreats();
		}

		private void ToolsUseTemplate_Click(object sender, EventArgs e)
		{
            List<Pair<EncounterTemplateGroup, EncounterTemplate>> templates = EncounterBuilder.FindTemplates(fEncounter, fPartyLevel, true);

			if (templates.Count == 0)
			{
				string msg = "There are no encounter templates which match the creatures already in the encounter.";
				msg += Environment.NewLine;
				msg += "This does not mean there is a problem with your encounter.";

				MessageBox.Show(msg, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Information);

				return;
			}
			else
			{
				EncounterTemplateWizard wizard = new EncounterTemplateWizard(templates, fEncounter, fPartyLevel);
				if (wizard.Show() == DialogResult.OK)
				{
					update_encounter();
					update_mapthreats();
				}
			}
		}

		private void ToolsMenu_DropDownOpening(object sender, EventArgs e)
		{
			ToolsUseDeck.DropDownItems.Clear();

			foreach (EncounterDeck deck in Session.Project.Decks)
			{
				if (deck.Cards.Count == 0)
					continue;

				ToolStripMenuItem tsmi = new ToolStripMenuItem(deck.Name + " (" + deck.Cards.Count + " cards)");
				tsmi.Tag = deck;
				tsmi.Click += new EventHandler(use_deck);

				ToolsUseDeck.DropDownItems.Add(tsmi);
			}

			if (ToolsUseDeck.DropDownItems.Count == 0)
			{
				ToolStripMenuItem tsmi = new ToolStripMenuItem("(no decks)");
				tsmi.ForeColor = SystemColors.GrayText;

				ToolsUseDeck.DropDownItems.Add(tsmi);
			}
		}

		void use_deck(object sender, EventArgs e)
		{
			ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
			EncounterDeck deck = tsmi.Tag as EncounterDeck;

			deck.DrawEncounter(fEncounter);

			if (deck.Cards.Count == 0)
				Session.Project.Decks.Remove(deck);

			update_encounter();
			update_mapthreats();
		}

		private void ToolsAddCreature_Click(object sender, EventArgs e)
		{
			try
			{
				CustomCreature creature = new CustomCreature();
				creature.Name = "Custom Creature";
				creature.Level = fPartyLevel;

				CreatureBuilderForm dlg = new CreatureBuilderForm(creature);
				//CustomCreatureForm dlg = new CustomCreatureForm(creature);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					Session.Project.CustomCreatures.Add(dlg.Creature as CustomCreature);
					Session.Modified = true;

					add_opponent(dlg.Creature);
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ToolsAddTrap_Click(object sender, EventArgs e)
		{
			try
			{
				Trap trap = new Trap();
				trap.Name = "Custom Trap";
				trap.Level = fPartyLevel;
				trap.Attacks.Add(new TrapAttack());

				TrapBuilderForm dlg = new TrapBuilderForm(trap);
				//TrapForm dlg = new TrapForm(trap);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fEncounter.Traps.Add(dlg.Trap);
					update_encounter();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ToolsAddChallenge_Click(object sender, EventArgs e)
		{
			try
			{
				SkillChallenge sc = new SkillChallenge();
				sc.Name = "Custom Skill Challenge";
				sc.Level = fPartyLevel;

				SkillChallengeBuilderForm dlg = new SkillChallengeBuilderForm(sc);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fEncounter.SkillChallenges.Add(dlg.SkillChallenge);
					update_encounter();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ToolsApplyTheme_Click(object sender, EventArgs e)
		{
			MonsterThemeSelectForm dlg = new MonsterThemeSelectForm();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				if (dlg.MonsterTheme != null)
				{
					foreach (EncounterSlot slot in fEncounter.Slots)
					{
						slot.Card.ThemeID = dlg.MonsterTheme.ID;

						slot.Card.ThemeAttackPowerID = Guid.Empty;
						slot.Card.ThemeUtilityPowerID = Guid.Empty;

						List<ThemePowerData> attacks = dlg.MonsterTheme.ListPowers(slot.Card.Roles, PowerType.Attack);
						if (attacks.Count != 0)
						{
							int index = Session.Random.Next() % attacks.Count;
							ThemePowerData power = attacks[index];
							slot.Card.ThemeAttackPowerID = power.Power.ID;
						}

						List<ThemePowerData> utilities = dlg.MonsterTheme.ListPowers(slot.Card.Roles, PowerType.Utility);
						if (utilities.Count != 0)
						{
							int index = Session.Random.Next() % utilities.Count;
							ThemePowerData power = utilities[index];
							slot.Card.ThemeUtilityPowerID = power.Power.ID;
						}
					}

					update_encounter();
					update_mapthreats();
				}
			}
		}

		#endregion

		#region AutoBuild

		private void AutoBuildBtn_Click(object sender, EventArgs e)
		{
			autobuild(false);
		}

		private void AutoBuildAdvanced_Click(object sender, EventArgs e)
		{
			autobuild(true);
		}

		void autobuild(bool advanced)
		{
			AutoBuildData data = null;

			if (advanced)
			{
				AutoBuildForm dlg = new AutoBuildForm(AutoBuildForm.Mode.Encounter);
				if (dlg.ShowDialog() == DialogResult.OK)
					data = dlg.Data;
				else
					return;
			}
			else
			{
				data = new AutoBuildData();
			}
			data.Level = fPartyLevel;

			bool ok = EncounterBuilder.Build(data, fEncounter, false);

			update_encounter();
			update_mapthreats();

			if (!ok)
			{
				string str = "AutoBuild was unable to find enough creatures of the appropriate type to build an encounter.";
				MessageBox.Show(str, "Encounter Builder", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		#endregion

		#endregion

		#region Source List toolbar

		private void ViewMenu_DropDownOpening(object sender, EventArgs e)
		{
			ViewTemplates.Enabled = (Session.Templates.Count != 0);
			ViewNPCs.Enabled = (Session.Project.NPCs.Count != 0);

			ViewNPCs.Checked = (fMode == ListMode.NPCs);
			ViewTemplates.Checked = (fMode == ListMode.Templates);

			ViewGroups.Checked = (SourceItemList.ShowGroups);
		}

		private void ViewCreatures_Click(object sender, EventArgs e)
		{
			fMode = ListMode.Creatures;
			FilterPanel.Mode = ListMode.Creatures;

			update_source_list();
		}

		private void ViewTemplates_Click(object sender, EventArgs e)
		{
			fMode = ListMode.Templates;
			FilterPanel.Mode = ListMode.Templates;

			update_source_list();
		}

		private void ViewNPCs_Click(object sender, EventArgs e)
		{
			fMode = ListMode.NPCs;
			FilterPanel.Mode = ListMode.NPCs;

			update_source_list();
		}

		private void ViewTraps_Click(object sender, EventArgs e)
		{
			fMode = ListMode.Traps;
			FilterPanel.Mode = ListMode.Traps;

			update_source_list();
		}

		private void ViewChallenges_Click(object sender, EventArgs e)
		{
			fMode = ListMode.SkillChallenges;
			FilterPanel.Mode = ListMode.SkillChallenges;

			update_source_list();
		}

		#endregion

		private void FilterPanel_FilterChanged(object sender, EventArgs e)
		{
			update_source_list();
		}

		private void SlotList_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				if (SelectedSlot != null)
				{
					fEncounter.Slots.Remove(SelectedSlot);

					update_encounter();

					e.Handled = true;
				}
				else if (SelectedSlotSkillChallenge != null)
				{
					fEncounter.SkillChallenges.Remove(SelectedSlotSkillChallenge);

					update_encounter();

					e.Handled = true;
				}
				else if (SelectedSlotTrap != null)
				{
					fEncounter.Traps.Remove(SelectedSlotTrap);

					update_encounter();

					e.Handled = true;
				}
			}
		}

		private void SlotList_DoubleClick(object sender, EventArgs e)
		{
			StatBlockBtn_Click(sender, e);
		}

		private void ThreatList_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedCreature != null)
			{
				EncounterCard card = new EncounterCard();
				card.CreatureID = SelectedCreature.ID;

				CreatureDetailsForm dlg = new CreatureDetailsForm(card);
				dlg.ShowDialog();
			}

			if (SelectedTemplate != null)
			{
				CreatureTemplateDetailsForm dlg = new CreatureTemplateDetailsForm(SelectedTemplate);
				dlg.ShowDialog();
			}

			if (SelectedTrap != null)
			{
				TrapDetailsForm dlg = new TrapDetailsForm(SelectedTrap);
				dlg.ShowDialog();
			}

			if (SelectedSkillChallenge != null)
			{
				SkillChallengeDetailsForm dlg = new SkillChallengeDetailsForm(SelectedSkillChallenge);
				dlg.ShowDialog();
			}
		}

		#region Drag and drop

		private void OpponentList_ItemDrag(object sender, ItemDragEventArgs e)
		{
			if (SelectedCreature != null)
				DoDragDrop(SelectedCreature, DragDropEffects.All);

			if (SelectedTemplate != null)
				DoDragDrop(SelectedTemplate, DragDropEffects.All);

			if (SelectedNPC != null)
				DoDragDrop(SelectedNPC, DragDropEffects.All);

			if (SelectedTrap != null)
				DoDragDrop(SelectedTrap, DragDropEffects.All);

			if (SelectedSkillChallenge != null)
				DoDragDrop(SelectedSkillChallenge, DragDropEffects.All);
		}

		private void SlotList_DragOver(object sender, DragEventArgs e)
		{
			Creature creature = e.Data.GetData(typeof(Creature)) as Creature;
			if (creature != null)
				e.Effect = DragDropEffects.Copy;

			CustomCreature custom = e.Data.GetData(typeof(CustomCreature)) as CustomCreature;
			if (custom != null)
				e.Effect = DragDropEffects.Copy;

			NPC npc = e.Data.GetData(typeof(NPC)) as NPC;
			if (npc != null)
				e.Effect = DragDropEffects.Copy;

			Trap trap = e.Data.GetData(typeof(Trap)) as Trap;
			if (trap != null)
				e.Effect = DragDropEffects.Copy;

			SkillChallenge sc = e.Data.GetData(typeof(SkillChallenge)) as SkillChallenge;
			if (sc != null)
				e.Effect = DragDropEffects.Copy;

			CreatureTemplate template = e.Data.GetData(typeof(CreatureTemplate)) as CreatureTemplate;
			if (template != null) 
			{
				Point mouse = SlotList.PointToClient(Cursor.Position);
				ListViewItem lvi = SlotList.GetItemAt(mouse.X, mouse.Y);
				lvi.Selected = true;

				EncounterSlot slot = lvi.Tag as EncounterSlot;
				if ((slot != null) && (allow_template_drop(slot, template)))
				{
					e.Effect = DragDropEffects.Copy;
				}
				else
				{
					e.Effect = DragDropEffects.None;
				}
			}
		}

		private void SlotList_DragDrop(object sender, DragEventArgs e)
		{
			Creature creature = e.Data.GetData(typeof(Creature)) as Creature;
			if (creature != null)
				add_opponent(creature);

			CustomCreature custom = e.Data.GetData(typeof(CustomCreature)) as CustomCreature;
			if (custom != null)
				add_opponent(custom);

			NPC npc = e.Data.GetData(typeof(NPC)) as NPC;
			if (npc != null)
				add_opponent(npc);

			Trap trap = e.Data.GetData(typeof(Trap)) as Trap;
			if (trap != null)
				add_trap(trap);

			SkillChallenge sc = e.Data.GetData(typeof(SkillChallenge)) as SkillChallenge;
			if (sc != null)
				add_challenge(sc);

			CreatureTemplate template = e.Data.GetData(typeof(CreatureTemplate)) as CreatureTemplate;
			if ((template != null) && (SelectedSlot != null) && (allow_template_drop(SelectedSlot, template)))
				add_template(template, SelectedSlot);
		}

		bool allow_template_drop(EncounterSlot slot, CreatureTemplate template)
		{
			// You can't add the same template twice
			if (slot.Card.TemplateIDs.Contains(template.ID))
				return false;

			ICreature creature = Session.FindCreature(slot.Card.CreatureID, SearchType.Global);

			// You can't add a template to a minion
			if (creature.Role is Minion)
				return false;

			// You can't add a template to something which is already effectively a solo
			ComplexRole role = creature.Role as ComplexRole;
			int steps = slot.Card.TemplateIDs.Count;
			switch (role.Flag)
			{
				case RoleFlag.Elite:
					steps += 1;
					break;
				case RoleFlag.Solo:
					steps += 2;
					break;
			}

			return (steps < 2);
		}

		#endregion

		#region Adding threats

		void add_opponent(ICreature creature)
		{
			EncounterSlot slot = null;
			foreach (EncounterSlot es in fEncounter.Slots)
			{
				if ((es.Card.CreatureID == creature.ID) && (es.Card.TemplateIDs.Count == 0))
				{
					slot = es;
					break;
				}
			}

			if (slot == null)
			{
				slot = new EncounterSlot();
				slot.Card.CreatureID = creature.ID;

				fEncounter.Slots.Add(slot);
			}

			CombatData cd = new CombatData();
			cd.DisplayName = slot.Card.Title;
			slot.CombatData.Add(cd);

			update_encounter();
			update_mapthreats();
		}

		void add_template(CreatureTemplate template, EncounterSlot slot)
		{
			slot.Card.TemplateIDs.Add(template.ID);

			update_encounter();
			update_mapthreats();
		}

		void add_trap(Trap trap)
		{
			fEncounter.Traps.Add(trap.Copy());
			update_encounter();
		}

		void add_challenge(SkillChallenge sc)
		{
			SkillChallenge challenge = sc.Copy() as SkillChallenge;
			challenge.Level = fPartyLevel;

			fEncounter.SkillChallenges.Add(challenge);
			update_encounter();
		}

		#endregion

		#region Updating

		private void update_difficulty_list()
		{
			int easy_xp = (fPartySize * (Experience.GetCreatureXP(fPartyLevel - 3) + Experience.GetCreatureXP(fPartyLevel - 2))) / 2;
			int mod_xp = (fPartySize * (Experience.GetCreatureXP(fPartyLevel - 1) + Experience.GetCreatureXP(fPartyLevel - 0))) / 2;
			int hard_xp = (fPartySize * (Experience.GetCreatureXP(fPartyLevel + 1) + Experience.GetCreatureXP(fPartyLevel + 2))) / 2;
			int ext_xp = (fPartySize * (Experience.GetCreatureXP(fPartyLevel + 4) + Experience.GetCreatureXP(fPartyLevel + 5))) / 2;

			easy_xp = Math.Max(1, easy_xp);
			mod_xp = Math.Max(1, mod_xp);
			hard_xp = Math.Max(1, hard_xp);
			ext_xp = Math.Max(1, ext_xp);

			DifficultyList.Items.Clear();

			ListViewItem lvi_easy = DifficultyList.Items.Add("Easy");
			lvi_easy.SubItems.Add(easy_xp + " - " + mod_xp);
			int min_easy = Math.Max(1, fPartyLevel - 4);
			lvi_easy.SubItems.Add(min_easy + " - " + (fPartyLevel + 3));
			lvi_easy.Tag = Difficulty.Easy;

			ListViewItem lvi_mod = DifficultyList.Items.Add("Moderate");
			lvi_mod.SubItems.Add(mod_xp + " - " + hard_xp);
			int min_mod = Math.Max(1, fPartyLevel - 3);
			lvi_mod.SubItems.Add(min_mod + " - " + (fPartyLevel + 3));
			lvi_mod.Tag = Difficulty.Moderate;

			ListViewItem lvi_hard = DifficultyList.Items.Add("Hard");
			lvi_hard.SubItems.Add(hard_xp + " - " + ext_xp);
			int min_hard = Math.Max(1, fPartyLevel - 3);
			lvi_hard.SubItems.Add(min_hard + " - " + (fPartyLevel + 5));
			lvi_hard.Tag = Difficulty.Hard;

			XPGauge.Party = new Party(fPartySize, fPartyLevel);
		}

		void update_encounter()
		{
			SlotList.BeginUpdate();
			ListState state = ListState.GetState(SlotList);

			SlotList.Groups.Clear();
			SlotList.Items.Clear();

			SlotList.ShowGroups = ((fEncounter.Count != 0) || (fEncounter.Traps.Count != 0) || (fEncounter.SkillChallenges.Count != 0));

			if (fEncounter.Count != 0)
			{
				foreach (EncounterSlot slot in fEncounter.AllSlots)
					slot.SetDefaultDisplayNames();

				SlotList.Groups.Add("Combatants", "Combatants");
				foreach (EncounterWave ew in fEncounter.Waves)
					SlotList.Groups.Add(ew.Name, ew.Name);

				foreach (EncounterSlot slot in fEncounter.AllSlots)
				{
					string name = slot.Card.Title;

					ICreature creature = Session.FindCreature(slot.Card.CreatureID, SearchType.Global);

					ListViewItem lvi = SlotList.Items.Add(name);
					lvi.SubItems.Add(slot.Card.Info);
					lvi.SubItems.Add(slot.CombatData.Count.ToString());
					lvi.SubItems.Add(slot.XP.ToString());
					lvi.Tag = slot;

					if (creature != null)
					{
						EncounterWave ew = fEncounter.FindWave(slot);
						lvi.Group = SlotList.Groups[ew == null ? "Combatants" : ew.Name];
					}

					if (creature == null)
					{
						lvi.ForeColor = Color.Red;
					}
					else
					{
						Difficulty diff = AI.GetThreatDifficulty(creature.Level + slot.Card.LevelAdjustment, fPartyLevel);
						if (diff == Difficulty.Trivial)
							lvi.ForeColor = Color.Green;
						if (diff == Difficulty.Extreme)
							lvi.ForeColor = Color.Red;
					}
				}
			}
			else
			{
				SlotList.Groups.Add("Creatures", "Creatures");

				ListViewItem lvi = SlotList.Items.Add("(none)");
				lvi.ForeColor = SystemColors.GrayText;
				lvi.Group = SlotList.Groups["Creatures"];
			}

			if (fEncounter.Traps.Count != 0)
			{
				SlotList.Groups.Add("Traps / Hazards", "Traps / Hazards");

				foreach (Trap trap in fEncounter.Traps)
				{
					ListViewItem lvi = SlotList.Items.Add(trap.Name);
					lvi.SubItems.Add(trap.Info);
					lvi.SubItems.Add("");
					lvi.SubItems.Add(trap.XP.ToString());
					lvi.Tag = trap;

					lvi.Group = SlotList.Groups["Traps / Hazards"];

					Difficulty diff = AI.GetThreatDifficulty(trap.Level, fPartyLevel);
					if (diff == Difficulty.Trivial)
						lvi.ForeColor = Color.Green;
					if (diff == Difficulty.Extreme)
						lvi.ForeColor = Color.Red;
				}
			}

			if (fEncounter.SkillChallenges.Count != 0)
			{
				SlotList.Groups.Add("Skill Challenges", "Skill Challenges");

				foreach (SkillChallenge sc in fEncounter.SkillChallenges)
				{
					ListViewItem lvi = SlotList.Items.Add(sc.Name);
					lvi.SubItems.Add(sc.Info);
					lvi.SubItems.Add("");
					lvi.SubItems.Add(sc.GetXP().ToString());
					lvi.Tag = sc;

					lvi.Group = SlotList.Groups["Skill Challenges"];

					Difficulty diff = sc.GetDifficulty(fPartyLevel, fPartySize);
					if (diff == Difficulty.Trivial)
						lvi.ForeColor = Color.Green;
					if (diff == Difficulty.Extreme)
						lvi.ForeColor = Color.Red;
				}
			}

			ListState.SetState(SlotList, state);
			SlotList.EndUpdate();

			Difficulty enc_diff = fEncounter.GetDifficulty(fPartyLevel, fPartySize);
			foreach (ListViewItem lvi in DifficultyList.Items)
			{
				Difficulty lvi_diff = (Difficulty)lvi.Tag;

				lvi.BackColor = (enc_diff == lvi_diff) ? Color.Gray : SystemColors.Window;
				lvi.Font = (enc_diff == lvi_diff) ? new Font(Font, Font.Style | FontStyle.Bold) : Font;
			}

			int xp = fEncounter.GetXP();
			XPGauge.XP = xp;
			XPLbl.Text = "XP: " + xp;

			int level = Experience.GetCreatureLevel(xp / fPartySize);
			LevelLbl.Text = "Level: " + Math.Max(level, 1);

			DiffLbl.Text = "Difficulty: " + fEncounter.GetDifficulty(fPartyLevel, fPartySize);
			CountLbl.Text = "Opponents: " + fEncounter.Count;
		}

		void update_source_list()
		{
			Cursor.Current = Cursors.WaitCursor;
			SourceItemList.BeginUpdate();

			try
			{
				SourceItemList.Items.Clear();
				SourceItemList.Groups.Clear();
				SourceItemList.ShowGroups = true;

				switch (fMode)
				{
					case ListMode.Creatures:
						{
							List<Creature> creatures = Session.Creatures;

							BinarySearchTree<string> bst = new BinarySearchTree<string>();
							foreach (Creature c in creatures)
							{
								if ((c.Category != null) && (c.Category != ""))
									bst.Add(c.Category);
							}

							List<string> cats = bst.SortedList;
							cats.Insert(0, "Custom Creatures");
							cats.Add("Miscellaneous Creatures");

							foreach (string cat in cats)
								SourceItemList.Groups.Add(cat, cat);

							List<ListViewItem> list_items = new List<ListViewItem>();

							foreach (CustomCreature c in Session.Project.CustomCreatures)
							{
								ListViewItem lvi = add_creature_to_list(c);
								if (lvi != null)
									list_items.Add(lvi);
							}

							foreach (Creature c in creatures)
							{
								ListViewItem lvi = add_creature_to_list(c);
								if (lvi != null)
									list_items.Add(lvi);
							}

							SourceItemList.Items.AddRange(list_items.ToArray());

							if (SourceItemList.Items.Count == 0)
							{
								SourceItemList.ShowGroups = false;

								ListViewItem lvi = SourceItemList.Items.Add("(no creatures)");
								lvi.ForeColor = SystemColors.GrayText;
							}
						}
						break;
					case ListMode.Templates:
						{
							List<CreatureTemplate> templates = Session.Templates;

							ListViewGroup lvg_functional = SourceItemList.Groups.Add("Functional Templates", "Functional Templates");
							ListViewGroup lvg_class = SourceItemList.Groups.Add("Class Templates", "Class Templates");
							
							List<ListViewItem> list_items = new List<ListViewItem>();

							foreach (CreatureTemplate ct in templates)
							{
								ListViewGroup lvg = (ct.Type == CreatureTemplateType.Functional) ? lvg_functional : lvg_class;
								ListViewItem lvi = add_template_to_list(ct, lvg);
								if (lvi != null)
									list_items.Add(lvi);
							}

							SourceItemList.Items.AddRange(list_items.ToArray());

							if (SourceItemList.Items.Count == 0)
							{
								SourceItemList.ShowGroups = false;

								ListViewItem lvi = SourceItemList.Items.Add("(no templates)");
								lvi.ForeColor = SystemColors.GrayText;
							}
						}
						break;
					case ListMode.NPCs:
						{
							ListViewGroup lvg = SourceItemList.Groups.Add("NPCs", "NPCs");

							List<ListViewItem> list_items = new List<ListViewItem>();

							foreach (NPC npc in Session.Project.NPCs)
							{
								ListViewItem lvi = add_npc_to_list(npc, lvg);
								if (lvi != null)
									list_items.Add(lvi);
							}

							SourceItemList.Items.AddRange(list_items.ToArray());

							if (SourceItemList.Items.Count == 0)
							{
								SourceItemList.ShowGroups = false;

								ListViewItem lvi = SourceItemList.Items.Add("(no npcs)");
								lvi.ForeColor = SystemColors.GrayText;
							}
						}
						break;
					case ListMode.Traps:
						{
							List<Trap> traps = Session.Traps;

							ListViewGroup trap_group = SourceItemList.Groups.Add("Traps", "Traps");
							ListViewGroup hazard_group = SourceItemList.Groups.Add("Hazards", "Hazards");
							ListViewGroup terrain_group = SourceItemList.Groups.Add("Terrain", "Terrain");

							List<ListViewItem> list_items = new List<ListViewItem>();

							foreach (Trap trap in traps)
							{
								ListViewGroup lvg = null;
								switch (trap.Type)
								{
									case TrapType.Trap:
										lvg = trap_group;
										break;
									case TrapType.Hazard:
										lvg = hazard_group;
										break;
									case TrapType.Terrain:
										lvg = terrain_group;
										break;
								}

								ListViewItem lvi = add_trap_to_list(trap, lvg);
								if (lvi != null)
									list_items.Add(lvi);
							}

							SourceItemList.Items.AddRange(list_items.ToArray());

							if (SourceItemList.Items.Count == 0)
							{
								SourceItemList.ShowGroups = false;

								ListViewItem lvi = SourceItemList.Items.Add("(no traps)");
								lvi.ForeColor = SystemColors.GrayText;
							}
						}
						break;
					case ListMode.SkillChallenges:
						{
							List<SkillChallenge> challenges = Session.SkillChallenges;

							List<ListViewItem> list_items = new List<ListViewItem>();

							foreach (SkillChallenge sc in challenges)
							{
								ListViewItem lvi = add_challenge_to_list(sc);
								if (lvi != null)
									list_items.Add(lvi);
							}

							SourceItemList.Items.AddRange(list_items.ToArray());

							if (SourceItemList.Items.Count == 0)
							{
								SourceItemList.ShowGroups = false;

								ListViewItem lvi = SourceItemList.Items.Add("(no skill challenges)");
								lvi.ForeColor = SystemColors.GrayText;
							}
						}
						break;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}

			SourceItemList.EndUpdate();
			Cursor.Current = Cursors.Default;
		}

		#region Add to source list

		ListViewItem add_creature_to_list(ICreature c)
		{
			if (c == null)
				return null;

			Difficulty diff;
			if (!FilterPanel.AllowItem(c, out diff))
				return null;

			ListViewItem lvi = new ListViewItem(c.Name);
			ListViewItem.ListViewSubItem lvsi = lvi.SubItems.Add(c.Info);
			lvi.Tag = c;

			lvi.UseItemStyleForSubItems = false;
			lvsi.ForeColor = SystemColors.GrayText;

			switch (diff)
			{
				case Difficulty.Trivial:
					lvi.ForeColor = Color.Green;
					break;
				case Difficulty.Extreme:
					lvi.ForeColor = Color.Maroon;
					break;
			}

			if (c is CustomCreature)
			{
				lvi.Group = SourceItemList.Groups["Custom Creatures"];
			}
			else
			{
				if ((c.Category != null) && (c.Category != ""))
					lvi.Group = SourceItemList.Groups[c.Category];
				else
					lvi.Group = SourceItemList.Groups["Miscellaneous Creatures"];
			}

			return lvi;
		}

		ListViewItem add_template_to_list(CreatureTemplate ct, ListViewGroup group)
		{
			if (ct == null)
				return null;

			Difficulty diff;
			if (!FilterPanel.AllowItem(ct, out diff))
				return null;

			ListViewItem lvi = new ListViewItem(ct.Name);
			ListViewItem.ListViewSubItem lvsi = lvi.SubItems.Add(ct.Info);
			lvi.Group = group;
			lvi.Tag = ct;

			lvi.UseItemStyleForSubItems = false;
			lvsi.ForeColor = SystemColors.GrayText;

			return lvi;
		}

		ListViewItem add_npc_to_list(NPC npc, ListViewGroup group)
		{
			if (npc == null)
				return null;

			Difficulty diff;
			if (!FilterPanel.AllowItem(npc, out diff))
				return null;

			ListViewItem lvi = new ListViewItem(npc.Name);
			ListViewItem.ListViewSubItem lvsi = lvi.SubItems.Add(npc.Info);
			lvi.Group = group;
			lvi.Tag = npc;

			lvi.UseItemStyleForSubItems = false;
			lvsi.ForeColor = SystemColors.GrayText;

			if (diff == Difficulty.Trivial)
				lvi.ForeColor = Color.Green;

			if (diff == Difficulty.Extreme)
				lvi.ForeColor = Color.Red;

			return lvi;
		}

		ListViewItem add_trap_to_list(Trap trap, ListViewGroup lvg)
		{
			if (trap == null)
				return null;

			Difficulty diff;
			if (!FilterPanel.AllowItem(trap, out diff))
				return null;

			ListViewItem lvi = new ListViewItem(trap.Name);
			ListViewItem.ListViewSubItem lvsi = lvi.SubItems.Add(trap.Info);
			lvi.Group = lvg;
			lvi.Tag = trap;

			lvi.UseItemStyleForSubItems = false;
			lvsi.ForeColor = SystemColors.GrayText;

			if (diff == Difficulty.Trivial)
				lvi.ForeColor = Color.Green;

			if (diff == Difficulty.Extreme)
				lvi.ForeColor = Color.Red;

			return lvi;
		}

		ListViewItem add_challenge_to_list(SkillChallenge sc)
		{
			if (sc == null)
				return null;

			Difficulty diff;
			if (!FilterPanel.AllowItem(sc, out diff))
				return null;

			ListViewItem lvi = new ListViewItem(sc.Name);
			ListViewItem.ListViewSubItem lvsi = lvi.SubItems.Add(sc.Info);
			lvi.Tag = sc;

			lvi.UseItemStyleForSubItems = false;
			lvsi.ForeColor = SystemColors.GrayText;

			return lvi;
		}

		#endregion

		#endregion

		#endregion

		#region Map Page

		private void AddToken_Click(object sender, EventArgs e)
		{
			try
			{
				CustomToken ct = new CustomToken();
				ct.Name = "Custom Map Token";
				ct.Type = CustomTokenType.Token;

				CustomTokenForm dlg = new CustomTokenForm(ct);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fEncounter.CustomTokens.Add(dlg.Token);

					update_encounter();
					update_mapthreats();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void CreaturesAddOverlay_Click(object sender, EventArgs e)
		{
			try
			{
				CustomToken ct = new CustomToken();
				ct.Name = "Custom Overlay";
				ct.Type = CustomTokenType.Overlay;

				CustomOverlayForm dlg = new CustomOverlayForm(ct);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fEncounter.CustomTokens.Add(dlg.Token);
					update_encounter();
					update_mapthreats();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void MapCreaturesRemoveAll_Click(object sender, EventArgs e)
		{
			foreach (EncounterSlot slot in fEncounter.Slots)
			{
				foreach (CombatData cd in slot.CombatData)
					cd.Location = CombatData.NoPoint;
			}

			foreach (CustomToken ct in fEncounter.CustomTokens)
				ct.Data.Location = CombatData.NoPoint;

			MapView.MapChanged();
			update_mapthreats();
		}

		private void MapCreaturesShowAll_Click(object sender, EventArgs e)
		{
			foreach (EncounterSlot slot in fEncounter.Slots)
			{
				foreach (CombatData cd in slot.CombatData)
					cd.Visible = true;
			}

			foreach (CustomToken ct in fEncounter.CustomTokens)
				ct.Data.Visible = true;

			MapView.MapChanged();
		}

		private void MapCreaturesHideAll_Click(object sender, EventArgs e)
		{
			foreach (EncounterSlot slot in fEncounter.Slots)
			{
				foreach (CombatData cd in slot.CombatData)
					cd.Visible = false;
			}

			foreach (CustomToken ct in fEncounter.CustomTokens)
				ct.Data.Visible = false;

			MapView.MapChanged();
		}

		private void ExportBtn_Click(object sender, EventArgs e)
		{
			if (MapView.Map != null)
			{
				SaveFileDialog dlg = new SaveFileDialog();
				dlg.FileName = MapView.Name;
				dlg.Filter = "Bitmap Image|*.bmp|JPEG Image|*.jpg|GIF Image|*.gif|PNG Image|*.png";

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					ImageFormat format = ImageFormat.Bmp;
					switch (dlg.FilterIndex)
					{
						case 1:
							format = ImageFormat.Bmp;
							break;
						case 2:
							format = ImageFormat.Jpeg;
							break;
						case 3:
							format = ImageFormat.Gif;
							break;
						case 4:
							format = ImageFormat.Png;
							break;
					}

					Bitmap bmp = Screenshot.Map(MapView);
					bmp.Save(dlg.FileName, format);
				}
			}
		}

		private void MapThreatList_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedMapThreat != null)
			{
				CreatureToken creature = SelectedMapThreat as CreatureToken;
				if (creature != null)
				{
					EncounterSlot slot = fEncounter.FindSlot(creature.SlotID);

					CreatureDetailsForm dlg = new CreatureDetailsForm(slot.Card);
					dlg.ShowDialog();
				}

				CustomToken custom = SelectedMapThreat as CustomToken;
				if (custom != null)
				{
					int index = fEncounter.CustomTokens.IndexOf(custom);

                    switch (custom.Type)
                    {
                        case CustomTokenType.Token:
                            {
                                CustomTokenForm dlg = new CustomTokenForm(custom);
                                if (dlg.ShowDialog() == DialogResult.OK)
                                {
                                    fEncounter.CustomTokens[index] = dlg.Token;

                                    update_encounter();
                                    update_mapthreats();
                                }
                            }
                            break;
                        case CustomTokenType.Overlay:
                            {
                                CustomOverlayForm dlg = new CustomOverlayForm(custom);
                                if (dlg.ShowDialog() == DialogResult.OK)
                                {
                                    fEncounter.CustomTokens[index] = dlg.Token;

                                    update_encounter();
                                    update_mapthreats();
                                }
                            }
                            break;
                    }
				}
			}
		}

		private void MapThreatList_ItemDrag(object sender, ItemDragEventArgs e)
		{
			if (SelectedMapThreat != null)
			{
				DoDragDrop(SelectedMapThreat, DragDropEffects.Move);
			}
		}

		private void MapView_ItemDropped(object sender, EventArgs e)
		{
			update_mapthreats();
		}

		private void MapView_ItemMoved(object sender, MovementEventArgs e)
		{
		}

		private void MapView_SelectedTokensChanged(object sender, EventArgs e)
		{
		}

		private void MapView_HoverTokenChanged(object sender, EventArgs e)
		{
			string title = "";
			string info = "";

			CreatureToken token = MapView.HoverToken as CreatureToken;
			if (token != null)
			{
				EncounterSlot slot = fEncounter.FindSlot(token.SlotID);

				title = slot.Card.Title;

				info = slot.Card.Info;
				info += Environment.NewLine;
				info += "Double-click for more details";
			}

			CustomToken custom = MapView.HoverToken as CustomToken;
			if (custom != null)
			{
				title = custom.Name;
				info = "Double-click to edit";
			}

			Tooltip.ToolTipTitle = title;
			Tooltip.ToolTipIcon = ToolTipIcon.Info;
			Tooltip.SetToolTip(MapView, info);
		}

		private void MapView_TokenActivated(object sender, TokenEventArgs e)
		{
			CreatureToken token = e.Token as CreatureToken;
			if (token != null)
			{
				EncounterSlot slot = fEncounter.FindSlot(token.SlotID);

				CreatureDetailsForm dlg = new CreatureDetailsForm(slot.Card);
				dlg.ShowDialog();
			}

			CustomToken custom = e.Token as CustomToken;
			if (custom != null)
			{
				int index = fEncounter.CustomTokens.IndexOf(custom);
				if (index != -1)
				{
					switch (custom.Type)
					{
						case CustomTokenType.Token:
							{
								CustomTokenForm dlg = new CustomTokenForm(custom);
								if (dlg.ShowDialog() == DialogResult.OK)
								{
									fEncounter.CustomTokens[index] = dlg.Token;

									update_encounter();
									update_mapthreats();
								}
							}
							break;
						case CustomTokenType.Overlay:
							{
								CustomOverlayForm dlg = new CustomOverlayForm(custom);
								if (dlg.ShowDialog() == DialogResult.OK)
								{
									fEncounter.CustomTokens[index] = dlg.Token;

									update_encounter();
									update_mapthreats();
								}
							}
							break;
					}
				}
			}
		}

		private void MapView_DoubleClick(object sender, EventArgs e)
		{
			if (fEncounter.MapID == Guid.Empty)
				MapBtn_Click(sender, e);
		}

		#region Map toolbar

		private void MapBtn_Click(object sender, EventArgs e)
		{
			MapAreaSelectForm dlg = new MapAreaSelectForm(fEncounter.MapID, fEncounter.MapAreaID);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Guid map_id = (dlg.Map != null) ? dlg.Map.ID : Guid.Empty;
				Guid map_area_id = (dlg.MapArea != null) ? dlg.MapArea.ID : Guid.Empty;

				// Have we changed anything?
				if ((map_id == fEncounter.MapID) && (map_area_id == fEncounter.MapAreaID))
					return;

				// Take everything off the map
				foreach (EncounterSlot slot in fEncounter.Slots)
				{
					foreach (CombatData cd in slot.CombatData)
						cd.Location = CombatData.NoPoint;
				}
				foreach (CustomToken ct in fEncounter.CustomTokens)
					ct.Data.Location = CombatData.NoPoint;

				fEncounter.MapID = map_id;
				fEncounter.MapAreaID = map_area_id;

				MapView.Map = dlg.Map;
				MapView.Viewpoint = (dlg.MapArea != null) ? dlg.MapArea.Region : Rectangle.Empty;
				MapView.Encounter = fEncounter;

				update_mapthreats();
			}
		}

		private void PrintBtn_Click(object sender, EventArgs e)
		{
			MapPrintingForm dlg = new MapPrintingForm(MapView);
			dlg.ShowDialog();
		}

		private void MapToolsLOS_Click(object sender, EventArgs e)
		{
			try
			{
				MapView.LineOfSight = !MapView.LineOfSight;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void MapToolsGridlines_Click(object sender, EventArgs e)
		{
			try
			{
				MapView.ShowGrid = (MapView.ShowGrid == MapGridMode.None) ? MapGridMode.Overlay : MapGridMode.None;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void MapToolsGridLabels_Click(object sender, EventArgs e)
		{
			try
			{
				MapView.ShowGridLabels = !MapView.ShowGridLabels;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void MapToolsPictureTokens_Click(object sender, EventArgs e)
		{
			MapView.ShowPictureTokens = !MapView.ShowPictureTokens;
		}

		#endregion

		#region Map Context Menu

		private void MapContextView_Click(object sender, EventArgs e)
		{
			if (MapView.SelectedTokens.Count != 1)
				return;

			CreatureToken ct = MapView.SelectedTokens[0] as CreatureToken;
			if (ct != null)
			{
				EncounterSlot slot = fEncounter.FindSlot(ct.SlotID);

				CreatureDetailsForm dlg = new CreatureDetailsForm(slot.Card);
				dlg.ShowDialog();
			}

			CustomToken custom = MapView.SelectedTokens[0] as CustomToken;
			if (custom != null)
			{
				int index = fEncounter.CustomTokens.IndexOf(custom);

                switch (custom.Type)
                {
                    case CustomTokenType.Token:
                        {
                            CustomTokenForm dlg = new CustomTokenForm(custom);
                            if (dlg.ShowDialog() == DialogResult.OK)
                            {
                                fEncounter.CustomTokens[index] = dlg.Token;

                                update_encounter();
                                update_mapthreats();
                            }
                        }
                        break;
                    case CustomTokenType.Overlay:
                        {
                            CustomOverlayForm dlg = new CustomOverlayForm(custom);
                            if (dlg.ShowDialog() == DialogResult.OK)
                            {
                                fEncounter.CustomTokens[index] = dlg.Token;

                                update_encounter();
                                update_mapthreats();
                            }
                        }
                        break;
                }
			}
		}

		private void MapContextRemove_Click(object sender, EventArgs e)
		{
			foreach (IToken token in MapView.SelectedTokens)
			{
				CreatureToken ct = token as CreatureToken;
				if (ct != null)
					ct.Data.Location = CombatData.NoPoint;

				CustomToken custom = token as CustomToken;
				if (custom != null)
					custom.Data.Location = CombatData.NoPoint;
			}

			update_mapthreats();
		}

        private void MapContextRemoveEncounter_Click(object sender, EventArgs e)
        {
			foreach (IToken token in MapView.SelectedTokens)
			{
				CreatureToken ct = token as CreatureToken;
				if (ct != null)
				{
					EncounterSlot slot = fEncounter.FindSlot(ct.SlotID);
					slot.CombatData.Remove(ct.Data);

					if (slot.CombatData.Count == 0)
						fEncounter.Slots.Remove(slot);
				}

				CustomToken custom = token as CustomToken;
				if (custom != null)
					fEncounter.CustomTokens.Remove(custom);
			}

			update_encounter();
			update_mapthreats();
		}

		private void MapContextVisible_Click(object sender, EventArgs e)
		{
			foreach (IToken token in MapView.SelectedTokens)
			{
				CreatureToken ct = token as CreatureToken;
				if (ct != null)
				{
					ct.Data.Visible = !ct.Data.Visible;

					MapView.Invalidate();
				}

				CustomToken custom = token as CustomToken;
				if (custom != null)
				{
					custom.Data.Visible = !custom.Data.Visible;

					MapView.Invalidate();
				}
			}
		}

		private void MapContextSetPicture_Click(object sender, EventArgs e)
		{
			if (MapView.SelectedTokens.Count != 1)
				return;

			CreatureToken ct = MapView.SelectedTokens[0] as CreatureToken;
			if (ct != null)
			{
				EncounterSlot slot = fEncounter.FindSlot(ct.SlotID);

				ICreature creature = Session.FindCreature(slot.Card.CreatureID, SearchType.Global);
				if (creature != null)
				{
					OpenFileDialog dlg = new OpenFileDialog();
					dlg.Filter = Program.ImageFilter;
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						creature.Image = Image.FromFile(dlg.FileName);
						Program.SetResolution(creature.Image);

						if (creature is Creature)
						{
							Creature c = creature as Creature;
							Library lib = Session.FindLibrary(c);
							if (lib != null)
							{
								string filename = Session.GetLibraryFilename(lib);
								Serialisation<Library>.Save(filename, lib, SerialisationMode.Binary);
							}
						}
						else
						{
							Session.Modified = true;
						}

						MapView.Invalidate();
					}
				}
			}
		}

		private void MapContextCopy_Click(object sender, EventArgs e)
		{
			if (MapView.SelectedTokens.Count != 1)
				return;

			CustomToken ct = MapView.SelectedTokens[0] as CustomToken;
			if (ct != null)
			{
				CustomToken copy = ct.Copy();
				copy.ID = Guid.NewGuid();
				copy.Data.Location = CombatData.NoPoint;

				fEncounter.CustomTokens.Add(copy);
			}

			update_mapthreats();
		}

		#endregion

		void update_mapthreats()
		{
			MapThreatList.Items.Clear();
			MapThreatList.Groups.Clear();

			SlotList.Groups.Add("Combatants", "Combatants");
			foreach (EncounterWave ew in fEncounter.Waves)
				SlotList.Groups.Add(ew.Name, ew.Name);
			SlotList.Groups.Add("Custom Tokens / Overlays", "Custom Tokens / Overlays");

			foreach (EncounterSlot slot in fEncounter.AllSlots)
			{
				foreach (CombatData cd in slot.CombatData)
				{
					if (cd.Location == CombatData.NoPoint)
					{
						ListViewItem map_lvi = MapThreatList.Items.Add(cd.DisplayName);
						map_lvi.Tag = new CreatureToken(slot.ID, cd);

						EncounterWave ew = fEncounter.FindWave(slot);
						map_lvi.Group = MapThreatList.Groups[ew == null ? "Combatants" : ew.Name];
					}
				}
			}

			foreach (CustomToken ct in fEncounter.CustomTokens)
			{
				if (ct.Data.Location == CombatData.NoPoint)
				{
					ListViewItem map_lvi = MapThreatList.Items.Add(ct.Name);
					map_lvi.Tag = ct;
					map_lvi.Group = MapThreatList.Groups["Custom Tokens / Overlays"];
				}
			}

			if (MapThreatList.Items.Count == 0)
				MapView.Caption = "";
			else
				MapView.Caption = "Drag creatures from the list to place them on the map";
		}

		#endregion

        #region Notes Page

        EncounterNote SelectedNote
        {
            get
            {
                if (NoteList.SelectedItems.Count != 0)
                    return NoteList.SelectedItems[0].Tag as EncounterNote;

                return null;
            }
            set
            {
                NoteList.SelectedItems.Clear();

                if (value != null)
                {
                    foreach (ListViewItem lvi in NoteList.Items)
                    {
                        EncounterNote en = lvi.Tag as EncounterNote;
                        if ((en != null) && (en.ID == value.ID))
                            lvi.Selected = true;
                    }
                }

                update_selected_note();
            }
        }

        private void NoteAddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                EncounterNote en = new EncounterNote("New Note");
                EncounterNoteForm dlg = new EncounterNoteForm(en);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    fEncounter.Notes.Add(dlg.Note);

                    update_notes();
                    SelectedNote = dlg.Note;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }
        }

        private void NoteRemoveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectedNote != null)
                {
					string str = "Remove encounter note: are you sure?";
					if (MessageBox.Show(str, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
						return;

                    fEncounter.Notes.Remove(SelectedNote);

                    update_notes();
                    SelectedNote = null;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }
        }

        private void NoteEditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectedNote != null)
                {
                    int index = fEncounter.Notes.IndexOf(SelectedNote);

                    EncounterNoteForm dlg = new EncounterNoteForm(SelectedNote);
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        fEncounter.Notes[index] = dlg.Note;

                        update_notes();
                        SelectedNote = dlg.Note;
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }
        }

        private void NoteUpBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if ((SelectedNote != null) && (fEncounter.Notes.IndexOf(SelectedNote) != 0))
                {
                    int index = fEncounter.Notes.IndexOf(SelectedNote);
                    EncounterNote tmp = fEncounter.Notes[index - 1];
                    fEncounter.Notes[index - 1] = SelectedNote;
                    fEncounter.Notes[index] = tmp;

                    update_notes();
                }
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }
        }

        private void NoteDownBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if ((SelectedNote != null) && (fEncounter.Notes.IndexOf(SelectedNote) != fEncounter.Notes.Count - 1))
                {
                    int index = fEncounter.Notes.IndexOf(SelectedNote);
                    EncounterNote tmp = fEncounter.Notes[index + 1];
                    fEncounter.Notes[index + 1] = SelectedNote;
                    fEncounter.Notes[index] = tmp;

                    update_notes();
                }
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }
        }

        private void NoteList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                update_selected_note();
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }
        }

        private void NoteDetails_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            try
            {
                if (e.Url.Scheme == "note")
                {
                    e.Cancel = true;

                    if (e.Url.LocalPath == "edit")
                    {
                        NoteEditBtn_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }
        }

        void update_notes()
        {
            try
            {
                EncounterNote selection = SelectedNote;

                NoteList.Items.Clear();
                foreach (EncounterNote en in fEncounter.Notes)
                {
                    ListViewItem lvi = NoteList.Items.Add(en.Title);
                    lvi.Tag = en;

                    if (en.Contents == "")
                        lvi.ForeColor = SystemColors.GrayText;

                    if (en == selection)
                        lvi.Selected = true;
                }

                if (NoteList.Items.Count == 0)
                {
                    ListViewItem lvi = NoteList.Items.Add("(no notes)");
                    lvi.ForeColor = SystemColors.GrayText;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }
        }

        void update_selected_note()
        {
            try
            {
				NoteDetails.Document.OpenNew(true);
                NoteDetails.Document.Write(HTML.EncounterNote(SelectedNote, Session.Preferences.TextSize));
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }
        }

        #endregion

		private void SourceItemList_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			SourceSorter sorter = SourceItemList.ListViewItemSorter as SourceSorter;
			sorter.Set(e.Column);

			SourceItemList.Sort();
		}

		class SourceSorter : IComparer
		{
			public void Set(int column)
			{
				if (fColumn == column)
					fAscending = !fAscending;

				fColumn = column;
			}

			bool fAscending = true;
			int fColumn = 0;

			public int Compare(object x, object y)
			{
				ListViewItem lvi_x = x as ListViewItem;
				ListViewItem lvi_y = y as ListViewItem;

				int result = 0;

				if (fColumn == 1)
				{
					if (lvi_x.Tag is ICreature)
					{
						ICreature creature_x = lvi_x.Tag as ICreature;
						ICreature creature_y = lvi_y.Tag as ICreature;

						int level_x = creature_x.Level;
						int level_y = creature_y.Level;

						result = level_x.CompareTo(level_y);
					}

					if (lvi_x.Tag is Trap)
					{
						Trap trap_x = lvi_x.Tag as Trap;
						Trap trap_y = lvi_y.Tag as Trap;

						int level_x = trap_x.Level;
						int level_y = trap_y.Level;

						result = level_x.CompareTo(level_y);
					}
				}

				if (result == 0)
				{
					ListViewItem.ListViewSubItem lvsi_x = lvi_x.SubItems[fColumn];
					ListViewItem.ListViewSubItem lvsi_y = lvi_y.SubItems[fColumn];

					string str_x = lvsi_x.Text;
					string str_y = lvsi_y.Text;

					result = str_x.CompareTo(str_y);
				}

				if (!fAscending)
					result *= -1;

				return result;
			}
		}

		private void ViewGroups_Click(object sender, EventArgs e)
		{
			SourceItemList.ShowGroups = !SourceItemList.ShowGroups;
		}

		private void ToolsExport_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.FileName = "Encounter";
			dlg.Filter = Program.EncounterFilter;

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				string xml = EncounterExporter.ExportXML(fEncounter);
				File.WriteAllText(dlg.FileName, xml);
			}
		}

		private void ThreatContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			EditStatBlock.Enabled = ((SelectedSlot != null) || (SelectedSlotTrap != null) || (SelectedSlotSkillChallenge != null));

			EditSetFaction.Enabled = (SelectedSlot != null);
			EditSetFaction.DropDownItems.Clear();

			// Factions
			foreach (EncounterSlotType type in Enum.GetValues(typeof(EncounterSlotType)))
			{
				ToolStripMenuItem tsmi = new ToolStripMenuItem(type.ToString());
				tsmi.Tag = type;
				tsmi.Enabled = (SelectedSlot != null);
				tsmi.Checked = ((SelectedSlot != null) && (SelectedSlot.Type == type));
				tsmi.Click += new EventHandler(count_slot_as);

				EditSetFaction.DropDownItems.Add(tsmi);
			}

			EditRemoveTemplate.Enabled = ((SelectedSlot != null) && (SelectedSlot.Card.TemplateIDs.Count != 0));
			EditRemoveLevelAdj.Enabled = ((SelectedSlot != null) && (SelectedSlot.Card.LevelAdjustment != 0));
			EditSwap.Enabled = (SelectedSlot != null);

			EditSetWave.Enabled = (SelectedSlot != null);
			EditSetWave.DropDownItems.Clear();

			// Initial wave
			ToolStripMenuItem tsmi_initial_wave = new ToolStripMenuItem("Initial Wave");
			tsmi_initial_wave.Tag = fEncounter;
			tsmi_initial_wave.Enabled = (SelectedSlot != null);
			tsmi_initial_wave.Checked = ((SelectedSlot != null) && (fEncounter.Slots.Contains(SelectedSlot)));
			tsmi_initial_wave.Click += new EventHandler(wave_initial);
			EditSetWave.DropDownItems.Add(tsmi_initial_wave);

			// Waves
			foreach (EncounterWave ew in fEncounter.Waves)
			{
				ToolStripMenuItem tsmi_wave = new ToolStripMenuItem(ew.Name);
				tsmi_wave.Tag = ew;
				tsmi_wave.Enabled = (SelectedSlot != null);
				tsmi_wave.Checked = ((SelectedSlot != null) && (fEncounter.FindWave(SelectedSlot) == ew));
				tsmi_wave.Click += new EventHandler(wave_subsequent);
				EditSetWave.DropDownItems.Add(tsmi_wave);
			}

			// Add a wave
			ToolStripMenuItem tsmi_new_wave = new ToolStripMenuItem("New Wave...");
			tsmi_new_wave.Tag = null;
			tsmi_new_wave.Enabled = (SelectedSlot != null);
			tsmi_new_wave.Checked = false;
			tsmi_new_wave.Click += new EventHandler(wave_new);
			EditSetWave.DropDownItems.Add(tsmi_new_wave);

			if (SelectedSlot == null)
			{
				SwapStandard.Enabled = false;
				SwapElite.Enabled = false;
				SwapSolo.Enabled = false;
				SwapMinions.Enabled = false;
			}
			else
			{
				ICreature creature = Session.FindCreature(SelectedSlot.Card.CreatureID, SearchType.Global);
				if (creature == null)
				{
					SwapStandard.Enabled = false;
					SwapElite.Enabled = false;
					SwapSolo.Enabled = false;
					SwapMinions.Enabled = false;
				}
				else
				{
					bool minion = (creature.Role is Minion);
					if (minion)
					{
						SwapStandard.Enabled = ((SelectedSlot.CombatData.Count >= 4) && (SelectedSlot.CombatData.Count % 4 == 0));
						SwapElite.Enabled = ((SelectedSlot.CombatData.Count >= 8) && (SelectedSlot.CombatData.Count % 8 == 0));
						SwapSolo.Enabled = ((SelectedSlot.CombatData.Count >= 20) && (SelectedSlot.CombatData.Count % 20 == 0));
						SwapMinions.Enabled = false;
					}
					else
					{
						RoleFlag flag = SelectedSlot.Card.Flag;

						SwapStandard.Enabled = true;
						SwapElite.Enabled = ((SelectedSlot.CombatData.Count >= 2) && (SelectedSlot.CombatData.Count % 2 == 0));
						SwapSolo.Enabled = ((SelectedSlot.CombatData.Count >= 5) && (SelectedSlot.CombatData.Count % 5 == 0));
						SwapMinions.Enabled = true;
					}
				}
			}

			if (SelectedSlot != null)
			{
				EditApplyTheme.Enabled = (SelectedSlot.Card != null);
				EditClearTheme.Enabled = ((SelectedSlot.Card != null) && (SelectedSlot.Card.ThemeID != Guid.Empty));
			}
			else
			{
				EditApplyTheme.Enabled = false;
				EditClearTheme.Enabled = false;
			}
		}

		private void wave_initial(object sender, EventArgs e)
		{
			// Move slot to encounter
			EncounterWave initial = fEncounter.FindWave(SelectedSlot);
			if (initial != null)
			{
				initial.Slots.Remove(SelectedSlot);
				fEncounter.Slots.Add(SelectedSlot);
			}

			update_encounter();
			update_mapthreats();
		}

		private void wave_subsequent(object sender, EventArgs e)
		{
			// Move slot to this wave
			ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
			EncounterWave ew = tsmi.Tag as EncounterWave;
			if (ew != null)
			{
				EncounterWave initial = fEncounter.FindWave(SelectedSlot);
				if (initial == null)
					fEncounter.Slots.Remove(SelectedSlot);
				else
					initial.Slots.Remove(SelectedSlot);
				ew.Slots.Add(SelectedSlot);
			}

			update_encounter();
			update_mapthreats();
		}

		private void wave_new(object sender, EventArgs e)
		{
			// Create a new wave
			EncounterWave ew = new EncounterWave();
			ew.Name = "Wave " + (fEncounter.Waves.Count + 2);
			fEncounter.Waves.Add(ew);

			// Move slot to new wave
			EncounterWave initial = fEncounter.FindWave(SelectedSlot);
			if (initial == null)
				fEncounter.Slots.Remove(SelectedSlot);
			else
				initial.Slots.Remove(SelectedSlot);
			ew.Slots.Add(SelectedSlot);

			update_encounter();
			update_mapthreats();
		}

		private void InfoBtn_Click(object sender, EventArgs e)
		{
			InfoForm dlg = new InfoForm();
			dlg.Level = fPartyLevel;
			dlg.ShowDialog();
		}

		private void DieRollerBtn_Click(object sender, EventArgs e)
		{
			DieRollerForm dlg = new DieRollerForm();
			dlg.ShowDialog();
		}

		private void PartyLbl_Click(object sender, EventArgs e)
		{
			Party party = new Party(fPartySize, fPartyLevel);
			PartyForm dlg = new PartyForm(party);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fPartySize = dlg.Party.Size;
				fPartyLevel = dlg.Party.Level;

				update_difficulty_list();
				update_encounter();
				update_party_label();
			}
		}

		void update_party_label()
		{
			PartyLbl.Text = fPartySize + " PCs at level " + fPartyLevel;
		}
	}
}
