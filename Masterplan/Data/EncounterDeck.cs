using System;
using System.Collections.Generic;

namespace Masterplan.Data
{
	/// <summary>
	/// Enumeration for the types of cards used in an encounter deck.
	/// </summary>
	public enum CardCategory
	{
		/// <summary>
		/// Artillery.
		/// </summary>
		Artillery,

		/// <summary>
		/// Controller.
		/// </summary>
		Controller,

		/// <summary>
		/// Lurker.
		/// </summary>
		Lurker,

		/// <summary>
		/// Skirmisher.
		/// </summary>
		Skirmisher,

		/// <summary>
		/// Soldier or brute.
		/// </summary>
		SoldierBrute,

		/// <summary>
		/// Minion.
		/// </summary>
		Minion,

		/// <summary>
		/// Solo.
		/// </summary>
		Solo
	}

	/// <summary>
	/// Class representing an encounter deck.
	/// </summary>
	[Serializable]
	public class EncounterDeck
	{
		/// <summary>
		/// Gets or sets the unique ID of the deck.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the name of the deck.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the level of the deck.
		/// </summary>
		public int Level
		{
			get { return fLevel; }
			set { fLevel = value; }
		}
		int fLevel = 1;

		/// <summary>
		/// Gets or sets the list of cards in the deck.
		/// </summary>
		public List<EncounterCard> Cards
		{
			get { return fCards; }
			set { fCards = value; }
		}
		List<EncounterCard> fCards = new List<EncounterCard>();

		/// <summary>
		/// Draws cards from the deck to create an encounter.
		/// </summary>
		/// <param name="enc">The encounter to add to.</param>
		/// <returns>Returns true if the process succeeded; false otherwise.</returns>
		public bool DrawEncounter(Encounter enc)
		{
			if (fCards.Count == 0)
				return false;

			List<EncounterCard> cards = new List<EncounterCard>();

			List<EncounterCard> available_cards = new List<EncounterCard>();
			foreach (EncounterCard card in fCards)
			{
				if (!card.Drawn)
					available_cards.Add(card);
			}

			int attempts = 0;
			while (true)
			{
				attempts += 1;

				bool lurker = false;

				int hand_size = Session.Project.Party.Size;
				while ((cards.Count < hand_size) && (available_cards.Count != 0))
				{
					int index = Session.Random.Next() % available_cards.Count;
					EncounterCard card = available_cards[index];

					cards.Add(card);
					available_cards.Remove(card);

					// If there's a lurker, draw an extra card
					if ((card.Category == CardCategory.Lurker) && (!lurker))
					{
						hand_size += 1;
						lurker = true;
					}
				}

				int soldier_cards = 0;
				foreach (EncounterCard card in cards)
				{
					if (card.Category == CardCategory.SoldierBrute)
						soldier_cards += 1;
				}

				if ((soldier_cards == 1) || (attempts == 1000))
					break;

				available_cards.AddRange(cards);
				cards.Clear();
			}

			// If this hand contains the solo creature, take that card and return the others
			foreach (EncounterCard c in cards)
			{
				if (c.Category == CardCategory.Solo)
				{
					cards.Remove(c);

					available_cards.AddRange(cards);
					cards.Clear();

					cards.Add(c);

					break;
				}
			}

			foreach (EncounterCard card in cards)
				card.Drawn = true;

			enc.Slots.Clear();

			foreach (EncounterCard card in cards)
			{
				// Do we already have a card of this type?
				EncounterSlot slot = null;
				foreach (EncounterSlot s in enc.Slots)
				{
					if (s.Card.CreatureID == card.CreatureID)
					{
						slot = s;
						break;
					}
				}

				if (slot == null)
				{
					slot = new EncounterSlot();
					slot.Card = card;
					enc.Slots.Add(slot);
				}

				int count = 1;
				switch (card.Category)
				{
					case CardCategory.SoldierBrute:
						count = 2;
						break;
					case CardCategory.Minion:
						count += 4;
						break;
				}

				for (int n = 0; n != count; ++n)
				{
					CombatData ccd = new CombatData();
					slot.CombatData.Add(ccd);
				}
			}

			foreach (EncounterSlot slot in enc.Slots)
				slot.SetDefaultDisplayNames();

			return true;
		}

		/// <summary>
		/// Draws cards from the deck to create a delve.
		/// </summary>
		/// <param name="pp">The plot point to use as the parent plot.</param>
		/// <param name="map">The map to create the delve for.</param>
		/// <returns>Returns true if the process succeeded; false otherwise.</returns>
		public bool DrawDelve(PlotPoint pp, Map map)
		{
			foreach (MapArea area in map.Areas)
			{
				Encounter enc = new Encounter();
				bool ok = DrawEncounter(enc);
				if (!ok)
					return false;

				PlotPoint enc_point = new PlotPoint(area.Name);
				enc_point.Element = enc;

				pp.Subplot.Points.Add(enc_point);
			}

			return true;
		}

		/// <summary>
		/// Calculates the number of cards of a given category in the deck.
		/// </summary>
		/// <param name="cat">The card category.</param>
		/// <returns>Returns the number of cards.</returns>
		public int Count(CardCategory cat)
		{
			int count = 0;

			foreach (EncounterCard card in fCards)
			{
				if (card.Category == cat)
					count += 1;
			}

			return count;
		}

		/// <summary>
		/// Calculates the number of cards of a given level in the deck.
		/// </summary>
		/// <param name="level">The level.</param>
		/// <returns>Returns the number of cards.</returns>
		public int Count(int level)
		{
			int count = 0;

			foreach (EncounterCard card in fCards)
			{
				if (card.Level == level)
					count += 1;
			}

			return count;
		}

		/// <summary>
		/// Creates a copy of the deck.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public EncounterDeck Copy()
		{
			EncounterDeck deck = new EncounterDeck();

			deck.ID = fID;
			deck.Name = fName;
			deck.Level = fLevel;

			foreach (EncounterCard card in fCards)
				deck.Cards.Add(card.Copy());

			return deck;
		}

		/// <summary>
		/// Returns the name of the deck.
		/// </summary>
		/// <returns>Returns the name of the deck.</returns>
		public override string ToString()
		{
			return fName;
		}
	}
}
