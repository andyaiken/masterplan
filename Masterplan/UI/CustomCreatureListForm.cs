using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;
using Masterplan.Wizards;

namespace Masterplan.UI
{
	partial class CustomCreatureListForm : Form
	{
		public CustomCreatureListForm()
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			update_creatures();
		}

		void Application_Idle(object sender, EventArgs e)
		{
			RemoveBtn.Enabled = (SelectedCreature != null) || (SelectedNPC != null);
			EditBtn.Enabled = (SelectedCreature != null) || (SelectedNPC != null);
			StatBlockBtn.Enabled = (SelectedCreature != null) || (SelectedNPC != null);
			EncEntryBtn.Enabled = (SelectedCreature != null) || (SelectedNPC != null);
		}

		public CustomCreature SelectedCreature
		{
			get
			{
				if (CreatureList.SelectedItems.Count != 0)
					return CreatureList.SelectedItems[0].Tag as CustomCreature;

				return null;
			}
		}

		public NPC SelectedNPC
		{
			get
			{
				if (CreatureList.SelectedItems.Count != 0)
					return CreatureList.SelectedItems[0].Tag as NPC;

				return null;
			}
		}

		#region Add

		private void AddCreature_Click(object sender, EventArgs e)
		{
			CustomCreature cc = new CustomCreature();
			cc.Name = "New Creature";

			CreatureBuilderForm dlg = new CreatureBuilderForm(cc);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Session.Project.CustomCreatures.Add(dlg.Creature as CustomCreature);
				Session.Modified = true;

				update_creatures();
			}
		}

		private void AddNPC_Click(object sender, EventArgs e)
		{
            if (class_templates_exist())
            {
                NPC npc = new NPC();
                npc.Name = "New NPC";

				foreach (CreatureTemplate ct in Session.Templates)
				{
					if (ct.Type == CreatureTemplateType.Class)
					{
						npc.TemplateID = ct.ID;
						break;
					}
				}

				CreatureBuilderForm dlg = new CreatureBuilderForm(npc);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
					Session.Project.NPCs.Add(dlg.Creature as NPC);
					Session.Modified = true;

                    update_creatures();
                }
            }
            else
            {
                // Show message
                string msg = "NPCs require class templates; you have no class templates defined.";
                msg += Environment.NewLine;
                msg += "You can define templates in the Libraries screen.";
                MessageBox.Show(msg, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
		}

		#endregion

		private void RemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedCreature != null)
			{
				string msg = "Are you sure you want to delete this creature?";
				DialogResult dr = MessageBox.Show(msg, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dr == DialogResult.No)
					return;

				Session.Project.CustomCreatures.Remove(SelectedCreature);
				Session.Modified = true;

				update_creatures();
			}

			if (SelectedNPC != null)
			{
				string msg = "Are you sure you want to delete this NPC?";
				DialogResult dr = MessageBox.Show(msg, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dr == DialogResult.No)
					return;

				Session.Project.NPCs.Remove(SelectedNPC);
				Session.Modified = true;

				update_creatures();
			}
		}

		private void EditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedCreature != null)
			{
				int index = Session.Project.CustomCreatures.IndexOf(SelectedCreature);

				//CustomCreatureForm dlg = new CustomCreatureForm(SelectedCreature);
				CreatureBuilderForm dlg = new CreatureBuilderForm(SelectedCreature);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					Session.Project.CustomCreatures[index] = dlg.Creature as CustomCreature;
					Session.Modified = true;

					update_creatures();
				}
			}

			if (SelectedNPC != null)
			{
				int index = Session.Project.NPCs.IndexOf(SelectedNPC);

				//NPCForm dlg = new NPCForm(SelectedNPC);
				CreatureBuilderForm dlg = new CreatureBuilderForm(SelectedNPC);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					Session.Project.NPCs[index] = dlg.Creature as NPC;
					Session.Modified = true;

					update_creatures();
				}
			}
		}

		private void StatBlockBtn_Click(object sender, EventArgs e)
		{
			EncounterCard card = null;

			if (SelectedCreature != null)
			{
				card = new EncounterCard();
				card.CreatureID = SelectedCreature.ID;
			}

			if (SelectedNPC != null)
			{
				card = new EncounterCard();
				card.CreatureID = SelectedNPC.ID;
			}

			CreatureDetailsForm dlg = new CreatureDetailsForm(card);
			dlg.ShowDialog();
		}

		private void EncEntryBtn_Click(object sender, EventArgs e)
		{
			if ((SelectedCreature == null) && (SelectedNPC == null))
				return;

			Guid id = (SelectedNPC != null) ? SelectedNPC.ID : SelectedCreature.ID;
			string name = (SelectedNPC != null) ? SelectedNPC.Name : SelectedCreature.Name;
			string cat = (SelectedNPC != null) ? "People" : "Creatures";

			EncyclopediaEntry entry = Session.Project.Encyclopedia.FindEntryForAttachment(id);

			if (entry == null)
			{
				// If there is no entry, ask to create it
				string msg = "There is no encyclopedia entry associated with " + name + ".";
				msg += Environment.NewLine;
				msg += "Would you like to create one now?";
				if (MessageBox.Show(msg, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					return;

				entry = new EncyclopediaEntry();
				entry.Name = name;
				entry.AttachmentID = id;
				entry.Category = cat;

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
			}
		}

		void update_creatures()
		{
			CreatureList.Items.Clear();

			foreach (CustomCreature cc in Session.Project.CustomCreatures)
			{
				if (cc == null)
					return;

				ListViewItem lvi = CreatureList.Items.Add(cc.Name);
				lvi.SubItems.Add("Level " + cc.Level + " " + cc.Role);
				lvi.SubItems.Add(cc.HP + " HP; AC " + cc.AC + ", Fort " + cc.Fortitude + ", Ref " + cc.Reflex + ", Will " + cc.Will);
				lvi.Group = CreatureList.Groups[0];
				lvi.Tag = cc;
			}

			foreach (NPC npc in Session.Project.NPCs)
			{
				if (npc == null)
					return;

				ListViewItem lvi = CreatureList.Items.Add(npc.Name);
				lvi.SubItems.Add("Level " + npc.Level + " " + npc.Role);
				lvi.SubItems.Add(npc.HP + " HP; AC " + npc.AC + ", Fort " + npc.Fortitude + ", Ref " + npc.Reflex + ", Will " + npc.Will);
				lvi.Group = CreatureList.Groups[1];
				lvi.Tag = npc;
			}

			if (CreatureList.Groups[0].Items.Count == 0)
			{
				ListViewItem lvi = CreatureList.Items.Add("(no custom creatures)");
				lvi.Group = CreatureList.Groups[0];
				lvi.ForeColor = SystemColors.GrayText;
			}

			if (CreatureList.Groups[1].Items.Count == 0)
			{
				ListViewItem lvi = CreatureList.Items.Add("(no NPCs)");
				lvi.Group = CreatureList.Groups[1];
				lvi.ForeColor = SystemColors.GrayText;
			}

			CreatureList.Sort();
		}

        bool class_templates_exist()
        {
            foreach (Library lib in Session.Libraries)
            {
                foreach (CreatureTemplate ct in lib.Templates)
                {
                    if (ct.Type == CreatureTemplateType.Class)
                        return true;
                }
            }

            return false;
        }

		private void CustomCreatureListForm_Shown(object sender, EventArgs e)
		{
			// XP bug
			CreatureList.Invalidate();
		}
	}
}
