using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;
using Masterplan.Tools;
using Masterplan.Tools.Generators;

namespace Masterplan.UI
{
	partial class CreatureSelectForm : Form
	{
		public CreatureSelectForm(EncounterTemplateSlot slot, int level)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fTemplateSlot = slot;
			fLevel = level;

			update_list();

			Browser.DocumentText = "";
			CreatureList_SelectedIndexChanged(null, null);
		}

		~CreatureSelectForm()
		{
			Application.Idle -= Application_Idle;
		}

		public CreatureSelectForm(List<Creature> creatures)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fCreatures = creatures;

			update_list();

			Browser.DocumentText = "";
			CreatureList_SelectedIndexChanged(null, null);
		}

		void Application_Idle(object sender, EventArgs e)
		{
			OKBtn.Enabled = (Creature != null);
		}

		public EncounterCard Creature
		{
			get
			{
				if (CreatureList.SelectedItems.Count != 0)
					return CreatureList.SelectedItems[0].Tag as EncounterCard;

				return null;
			}
		}

		List<Creature> fCreatures = null;
		EncounterTemplateSlot fTemplateSlot = null;
		int fLevel = 1;

		private void TileList_DoubleClick(object sender, EventArgs e)
		{
			if (Creature != null)
			{
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void CreatureList_SelectedIndexChanged(object sender, EventArgs e)
		{
			string html = HTML.StatBlock(Creature, null, null, true, false, true, CardMode.View, Session.Preferences.TextSize);

			Browser.Document.OpenNew(true);
			Browser.Document.Write(html);
		}

		void update_list()
		{
			CreatureList.Groups.Clear();
			CreatureList.Items.Clear();

			List<EncounterCard> cards = null;
			if (fCreatures != null)
			{
				cards = new List<EncounterCard>();
				foreach (Creature creature in fCreatures)
					cards.Add(new EncounterCard(creature.ID));
			}
			else
			{
				cards = EncounterBuilder.FindCreatures(fTemplateSlot, fLevel, NameBox.Text);
			}

			BinarySearchTree<string> bst = new BinarySearchTree<string>();
			foreach (EncounterCard card in cards)
			{
				ICreature c = Session.FindCreature(card.CreatureID, SearchType.Global);
				bst.Add(c.Category);
			}

			List<string> cats = bst.SortedList;
			cats.Add("Miscellaneous Creatures");
			foreach (string cat in cats)
				CreatureList.Groups.Add(cat, cat);

			foreach (EncounterCard card in cards)
			{
				ICreature c = Session.FindCreature(card.CreatureID, SearchType.Global);

				ListViewItem lvi = CreatureList.Items.Add(card.Title);
				lvi.SubItems.Add(card.Info);
				lvi.Tag = card;

				if ((c.Category != null) && (c.Category != ""))
					lvi.Group = CreatureList.Groups[c.Category];
				else
					lvi.Group = CreatureList.Groups["Miscellaneous Creatures"];
			}
		}

		private void NameBox_TextChanged(object sender, EventArgs e)
		{
			update_list();
		}

		bool match(Trap trap, string query)
		{
			string[] tokens = query.ToLower().Split();

			foreach (string token in tokens)
			{
				if (!match_token(trap, token))
					return false;
			}

			return true;
		}

		bool match_token(Trap trap, string token)
		{
			if (trap.Name.ToLower().Contains(token))
				return true;

			return false;
		}
	}
}
