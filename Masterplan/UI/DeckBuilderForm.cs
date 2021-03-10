using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;
using Masterplan.Tools.Generators;

namespace Masterplan.UI
{
	partial class DeckBuilderForm : Form
	{
		public DeckBuilderForm(EncounterDeck deck)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fDeck = deck.Copy();

			NameBox.Text = fDeck.Name;
			LevelBox.Value = fDeck.Level;
			DeckView.Deck = fDeck;

			update_groups();
			DeckView_SelectedCellChanged(null, null);
		}

		#region Properties

		public EncounterDeck Deck
		{
			get { return fDeck; }
		}
		EncounterDeck fDeck = null;

		public EncounterCard SelectedCard
		{
			get
			{
				if (CardList.SelectedItems.Count != 0)
					return CardList.SelectedItems[0].Tag as EncounterCard;

				return null;
			}
		}

		public ICreature SelectedCreature
		{
			get
			{
				if (CreatureList.SelectedItems.Count != 0)
					return CreatureList.SelectedItems[0].Tag as ICreature;

				return null;
			}
		}

		#endregion

		void Application_Idle(object sender, EventArgs e)
		{
			DuplicateBtn.Enabled = (SelectedCard != null);
			RemoveBtn.Enabled = (SelectedCard != null);
			RefreshBtn.Enabled = ((SelectedCard != null) && (SelectedCard.Drawn));

			bool drawn = false;
			foreach (EncounterCard card in fDeck.Cards)
			{
				if (card.Drawn)
				{
					drawn = true;
					break;
				}
			}

			RefillBtn.Enabled = drawn;
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fDeck.Name = NameBox.Text;
		}

		#region Toolbar

		private void DuplicateBtn_Click(object sender, EventArgs e)
		{
			if (SelectedCard != null)
			{
				EncounterCard card = SelectedCard.Copy();
				fDeck.Cards.Add(card);

				DeckView.Invalidate();
				update_card_list();
			}
		}

		private void RemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedCard != null)
			{
				if (fDeck.Cards.Contains(SelectedCard))
					fDeck.Cards.Remove(SelectedCard);

				DeckView.Invalidate();
				update_card_list();
			}
		}

		private void RefreshBtn_Click(object sender, EventArgs e)
		{
			if ((SelectedCard != null) && (SelectedCard.Drawn))
			{
				SelectedCard.Drawn = false;

				DeckView.Invalidate();
				update_card_list();
			}
		}

		private void ViewBtn_Click(object sender, EventArgs e)
		{
			List<EncounterCard> cards = new List<EncounterCard>();

			foreach (EncounterCard card in fDeck.Cards)
			{
				if (!DeckView.InSelectedCell(card))
					continue;

				cards.Add(card);
			}

			if (cards.Count != 0)
			{
				DeckViewForm dlg = new DeckViewForm(cards);
				dlg.ShowDialog();
			}
		}

		#endregion

		private void AutoBuildBtn_Click(object sender, EventArgs e)
		{
			AutoBuildForm dlg = new AutoBuildForm(AutoBuildForm.Mode.Deck);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				EncounterDeck deck = EncounterBuilder.BuildDeck(dlg.Data.Level, dlg.Data.Categories, dlg.Data.Keywords);
				if (deck != null)
				{
					fDeck = deck;

					LevelBox.Value = fDeck.Level;
					DeckView.Deck = fDeck;
					DeckView_SelectedCellChanged(null, null);
				}
			}
		}

		private void RefillBtn_Click(object sender, EventArgs e)
		{
			foreach (EncounterCard card in fDeck.Cards)
				card.Drawn = false;

			DeckView.Invalidate();
			update_card_list();
		}

		#region Stat blocks

		private void CreatureList_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedCreature != null)
			{
				EncounterCard card = new EncounterCard();
				card.CreatureID = SelectedCreature.ID;

				CreatureDetailsForm dlg = new CreatureDetailsForm(card);
				dlg.ShowDialog();
			}
		}

		private void CardList_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedCard != null)
			{
				CreatureDetailsForm dlg = new CreatureDetailsForm(SelectedCard);
				dlg.ShowDialog();
			}
		}

		#endregion

		#region Drag and drop

		private void CreatureList_ItemDrag(object sender, ItemDragEventArgs e)
		{
			if (SelectedCreature != null)
			{
				if (DoDragDrop(SelectedCreature, DragDropEffects.Copy) == DragDropEffects.Copy)
				{
					EncounterCard card = new EncounterCard();
					card.CreatureID = SelectedCreature.ID;

					fDeck.Cards.Add(card);

					DeckView.Invalidate();
					update_card_list();
				}
			}
		}

		private void DeckView_DragOver(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.None;

			Creature c = e.Data.GetData(typeof(Creature)) as Creature;
			if (c != null)
				e.Effect = DragDropEffects.Copy;

			CustomCreature cc = e.Data.GetData(typeof(CustomCreature)) as CustomCreature;
			if (cc != null)
				e.Effect = DragDropEffects.Copy;
		}

		private void DeckView_DragDrop(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.None;

			Creature c = e.Data.GetData(typeof(Creature)) as Creature;
			if (c != null)
				e.Effect = DragDropEffects.Copy;

			CustomCreature cc = e.Data.GetData(typeof(CustomCreature)) as CustomCreature;
			if (cc != null)
				e.Effect = DragDropEffects.Copy;
		}

		#endregion

		#region Event handlers

		private void LevelBox_ValueChanged(object sender, EventArgs e)
		{
			fDeck.Level = (int)LevelBox.Value;
			DeckView.Invalidate();
		}

		private void DeckView_SelectedCellChanged(object sender, EventArgs e)
		{
			if (DeckView.IsCellSelected)
			{
				InfoLbl.Text = "Drag creatures from this list onto the grid to the left to add them into your deck.";
			}
			else
			{
				InfoLbl.Text = "Select a cell on the grid to display the list of creatures that can be added to the deck.";
			}

			Cursor.Current = Cursors.WaitCursor;

			update_card_list();
			update_creature_list();

			Cursor.Current = Cursors.Default;
		}

		private void DeckView_CellActivated(object sender, EventArgs e)
		{
			ViewBtn_Click(null, null);
		}

		#endregion

		#region Updating

		void update_groups()
		{
			BinarySearchTree<string> bst = new BinarySearchTree<string>();

			foreach (Creature c in Session.Creatures)
			{
				if (c.Category != "")
					bst.Add(c.Category);
			}

			List<string> cats = bst.SortedList;
			cats.Insert(0, "Custom Creatures");
			cats.Add("Miscellaneous Creatures");

			foreach (string cat in cats)
			{
				CardList.Groups.Add(cat, cat);
				CreatureList.Groups.Add(cat, cat);
			}
		}

		void update_card_list()
		{
			CardList.BeginUpdate();
			CardList.ShowGroups = true;

			List<ListViewItem> item_list = new List<ListViewItem>();

			if (DeckView.IsCellSelected)
			{
				foreach (EncounterCard card in fDeck.Cards)
				{
					if (!DeckView.InSelectedCell(card))
						continue;

					item_list.Add(add_card(card));
				}

				if (item_list.Count == 0)
				{
					CardList.ShowGroups = false;

					ListViewItem lvi = new ListViewItem("(no cards)");
					lvi.ForeColor = SystemColors.GrayText;

					item_list.Add(lvi);
				}
			}
			else
			{
				CardList.ShowGroups = false;

				ListViewItem lvi = new ListViewItem("(no cell selected)");
				lvi.ForeColor = SystemColors.GrayText;

				item_list.Add(lvi);
			}

			CardList.Items.Clear();
			CardList.Items.AddRange(item_list.ToArray());
			CardList.EndUpdate();

			ViewBtn.Enabled = (item_list.Count != 0);
		}

		ListViewItem add_card(EncounterCard card)
		{
			ListViewItem lvi = new ListViewItem(card.Title);
			lvi.SubItems.Add(card.Info);
			lvi.Tag = card;

			if (card.Drawn)
				lvi.ForeColor = SystemColors.GrayText;

			ICreature c = Session.FindCreature(card.CreatureID, SearchType.Global);
			string cat_name = (c.Category != "") ? c.Category : "Miscellaneous Creatures";
			lvi.Group = CardList.Groups[cat_name];

			return lvi;
		}

		void update_creature_list()
		{
			CreatureList.BeginUpdate();
			CreatureList.ShowGroups = true;

			List<ListViewItem> item_list = new List<ListViewItem>();

			if (DeckView.IsCellSelected)
			{
				List<ICreature> creatures = new List<ICreature>();
				foreach (Creature c in Session.Creatures)
					creatures.Add(c);
				foreach (CustomCreature cc in Session.Project.CustomCreatures)
					creatures.Add(cc);

				foreach (ICreature c in creatures)
				{
					EncounterCard card = new EncounterCard();
					card.CreatureID = c.ID;

					if (!DeckView.InSelectedCell(card))
						continue;

					ListViewItem lvi = new ListViewItem(c.Name);
					lvi.Tag = c;

					string cat_name = (c.Category != "") ? c.Category : "Miscellaneous Creatures";
					lvi.Group = CreatureList.Groups[cat_name];

					item_list.Add(lvi);
				}

				if (item_list.Count == 0)
				{
					CreatureList.ShowGroups = false;

					ListViewItem lvi = new ListViewItem("(no creatures)");
					lvi.ForeColor = SystemColors.GrayText;

					item_list.Add(lvi);
				}
			}
			else
			{
				CreatureList.ShowGroups = false;

				ListViewItem lvi = new ListViewItem("(no cell selected)");
				lvi.ForeColor = SystemColors.GrayText;

				item_list.Add(lvi);
			}

			CreatureList.Items.Clear();
			CreatureList.Items.AddRange(item_list.ToArray());
			CreatureList.EndUpdate();
		}

		#endregion
	}
}
