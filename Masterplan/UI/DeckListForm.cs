using System;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class DeckListForm : Form
	{
		public DeckListForm()
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			update_decks();
		}

		~DeckListForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			RemoveBtn.Enabled = (SelectedDeck != null);
			EditBtn.Enabled = (SelectedDeck != null);

			ViewBtn.Enabled = ((SelectedDeck != null) && (SelectedDeck.Cards.Count != 0));
			RunBtn.Enabled = ((SelectedDeck != null) && (SelectedDeck.Cards.Count != 0));
		}

		public EncounterDeck SelectedDeck
		{
			get
			{
				if (DeckList.SelectedItems.Count != 0)
					return DeckList.SelectedItems[0].Tag as EncounterDeck;

				return null;
			}
		}

		private void AddBtn_Click(object sender, EventArgs e)
		{
			EncounterDeck deck = new EncounterDeck();
			deck.Name = "New Deck";
			deck.Level = Session.Project.Party.Level;

			DeckBuilderForm dlg = new DeckBuilderForm(deck);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Session.Project.Decks.Add(dlg.Deck);
				Session.Modified = true;

				update_decks();
			}
		}

		private void RemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedDeck != null)
			{
				Session.Project.Decks.Remove(SelectedDeck);
				Session.Modified = true;

				update_decks();
			}
		}

		private void EditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedDeck != null)
			{
				int index = Session.Project.Decks.IndexOf(SelectedDeck);

				DeckBuilderForm dlg = new DeckBuilderForm(SelectedDeck);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					Session.Project.Decks[index] = dlg.Deck;
					Session.Modified = true;

					update_decks();
				}
			}
		}

		private void ViewBtn_Click(object sender, EventArgs e)
		{
			if (SelectedDeck != null)
			{
				DeckViewForm dlg = new DeckViewForm(SelectedDeck.Cards);
				dlg.ShowDialog();
			}
		}

		private void RunBtn_Click(object sender, EventArgs e)
		{
			if (SelectedDeck != null)
				run_encounter(SelectedDeck, false);
		}

		private void RunMap_Click(object sender, EventArgs e)
		{
			if (SelectedDeck != null)
				run_encounter(SelectedDeck, true);
		}

		void run_encounter(EncounterDeck deck, bool choose_map)
		{
			MapAreaSelectForm map_dlg = null;
			if (choose_map)
			{
				map_dlg = new MapAreaSelectForm(Guid.Empty, Guid.Empty);
				if (map_dlg.ShowDialog() != DialogResult.OK)
					return;
			}

			Encounter enc = new Encounter();
			bool ok = deck.DrawEncounter(enc);
			update_decks();

			if (ok)
			{
				CombatState cs = new CombatState();
				cs.Encounter = enc;
				cs.PartyLevel = Session.Project.Party.Level;

				if ((map_dlg != null) && (map_dlg.Map != null))
				{
					cs.Encounter.MapID = map_dlg.Map.ID;

					if (map_dlg.MapArea != null)
						cs.Encounter.MapAreaID = map_dlg.MapArea.ID;
				}

				CombatForm dlg = new CombatForm(cs);
				dlg.Show();
			}
			else
			{
				string str = "An encounter could not be built from this deck; check that there are enough cards remaining.";
				MessageBox.Show(str, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		void update_decks()
		{
			DeckList.Items.Clear();

			foreach (EncounterDeck deck in Session.Project.Decks)
			{
				int available = 0;
				foreach (EncounterCard card in deck.Cards)
				{
					if (!card.Drawn)
						available += 1;
				}

				string count = deck.Cards.Count.ToString();
				if (available != deck.Cards.Count)
					count = available + " / " + deck.Cards.Count;

				ListViewItem lvi = DeckList.Items.Add(deck.Name);
				lvi.SubItems.Add(deck.Level.ToString());
				lvi.SubItems.Add(count);
				lvi.Tag = deck;
			}

			if (DeckList.Items.Count == 0)
			{
				ListViewItem lvi = DeckList.Items.Add("(no decks)");
				lvi.ForeColor = SystemColors.GrayText;
			}
		}
	}
}
