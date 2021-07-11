using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class CreatureMultipleSelectForm : Form
	{
		public CreatureMultipleSelectForm()
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			update_list();

			Browser.DocumentText = "";

			update_stats();
		}

		~CreatureMultipleSelectForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			OKBtn.Enabled = (SelectedCreatures.Count >= 2);
		}

		public List<ICreature> SelectedCreatures
		{
			get { return fCreatures; }
		}
		List<ICreature> fCreatures = new List<ICreature>();

		public ICreature SelectedCreature
		{
			get
			{
				if (CreatureList.SelectedItems.Count != 0)
					return CreatureList.SelectedItems[0].Tag as ICreature;

				return null;
			}
		}

		private void TileList_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedCreature != null)
			{
				fCreatures.Add(SelectedCreature);

				update_list();
				update_stats();
			}
		}

		private void CreatureList_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		void update_list()
		{
			CreatureList.BeginUpdate();

			CreatureList.Groups.Clear();
			CreatureList.Items.Clear();

			List<Creature> creatures = Session.Creatures;

			BinarySearchTree<string> bst = new BinarySearchTree<string>();
			foreach (Creature c in creatures)
				bst.Add(c.Category);

			List<string> cats = bst.SortedList;
			cats.Add("Miscellaneous Creatures");
			foreach (string cat in cats)
				CreatureList.Groups.Add(cat, cat);

			List<ListViewItem> items = new List<ListViewItem>();
			foreach (Creature c in creatures)
			{
				if (!match(c, NameBox.Text))
					continue;

				if (fCreatures.Contains(c))
					continue;

				ListViewItem lvi = new ListViewItem(c.Name);
				lvi.SubItems.Add(c.Info);
				lvi.Tag = c;

				if ((c.Category != null) && (c.Category != ""))
					lvi.Group = CreatureList.Groups[c.Category];
				else
					lvi.Group = CreatureList.Groups["Miscellaneous Creatures"];

				items.Add(lvi);
			}

			CreatureList.Items.AddRange(items.ToArray());
			CreatureList.EndUpdate();
		}

		void update_stats()
		{
			List<string> lines = HTML.GetHead("", "", Session.Preferences.TextSize);

			lines.Add("<BODY>");

			if (fCreatures.Count != 0)
			{
				lines.Add("<P class=table>");
				lines.Add("<TABLE>");
				lines.Add("<TR class=heading>");
				lines.Add("<TD colspan=3><B>Selected Creatures</B></TD>");
				lines.Add("</TR>");

				foreach (ICreature c in fCreatures)
				{
					lines.Add("<TR class=header>");
					lines.Add("<TD colspan=2>" + c.Name + "</TD>");
					lines.Add("<TD align=center><A href=remove:" + c.ID + ">remove</A></TD>");
					lines.Add("</TR>");
				}

				lines.Add("</TABLE>");
				lines.Add("</P>");
			}
			else
			{
				lines.Add("<P class=instruction>");
				lines.Add("You have not yet selected any creatures; to select a creature, drag it from the list at the left onto the box above");
				lines.Add("</P>");
			}

			foreach (ICreature creature in fCreatures)
			{
				EncounterCard card = new EncounterCard(creature);

				lines.Add("<P class=table>");
				lines.AddRange(card.AsText(null, CardMode.View, false));
				lines.Add("</P>");
			}

			lines.Add("</BODY>");
			lines.Add("</HTML>");

			string html = HTML.Concatenate(lines);

			Browser.Document.OpenNew(true);
			Browser.Document.Write(html);
		}

		#region Filtering

		private void NameBox_TextChanged(object sender, EventArgs e)
		{
			update_list();
		}

		bool match(ICreature creature, string query)
		{
			string[] tokens = query.ToLower().Split();

			foreach (string token in tokens)
			{
				if (!match_token(creature, token))
					return false;
			}

			return true;
		}

		bool match_token(ICreature creature, string token)
		{
			if (creature.Name.ToLower().Contains(token))
				return true;

			if (creature.Info.ToLower().Contains(token))
				return true;

			return false;
		}

		#endregion

		private void CreatureList_ItemDrag(object sender, ItemDragEventArgs e)
		{
			if (SelectedCreature != null)
			{
				DragLbl.BackColor = SystemColors.Highlight;
				DragLbl.ForeColor = SystemColors.HighlightText;

				if (DoDragDrop(SelectedCreature, DragDropEffects.Move) == DragDropEffects.Move)
				{
					fCreatures.Add(SelectedCreature);

					update_list();
					update_stats();
				}

				DragLbl.BackColor = SystemColors.Control;
				DragLbl.ForeColor = SystemColors.ControlText;
			}
		}

		private void DragLbl_DragOver(object sender, DragEventArgs e)
		{
			if (has_creature(e.Data))
				e.Effect = DragDropEffects.Move;
		}

		private void DragLbl_DragDrop(object sender, DragEventArgs e)
		{
			if (has_creature(e.Data))
				e.Effect = DragDropEffects.Move;
		}

		bool has_creature(IDataObject data)
		{
			Creature c = data.GetData(typeof(Creature)) as Creature;
			if (c != null)
				return true;

			CustomCreature cc = data.GetData(typeof(CustomCreature)) as CustomCreature;
			if (cc != null)
				return true;

			NPC npc = data.GetData(typeof(NPC)) as NPC;
			if (npc != null)
				return true;

			return false;
		}

		private void Browser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			if (e.Url.Scheme == "remove")
			{
				Guid id = new Guid(e.Url.LocalPath);
				ICreature creature = find_creature(id);
				if (creature != null)
				{
					e.Cancel = true;

					fCreatures.Remove(creature);

					update_list();
					update_stats();
				}
			}
		}

		ICreature find_creature(Guid id)
		{
			foreach (ICreature creature in fCreatures)
			{
				if (creature.ID == id)
					return creature;
			}

			return null;
		}
	}
}
