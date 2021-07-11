using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class DeckViewForm : Form
	{
		public DeckViewForm(List<EncounterCard> cards)
		{
			InitializeComponent();

			DeckView.SetCards(cards);

			Browser.DocumentText = "";

			update_stats();
		}

		private void DeckView_DeckOrderChanged(object sender, EventArgs e)
		{
			update_stats();
			DeckView.Focus();
		}

		void update_stats()
		{
			Browser.Document.OpenNew(true);
			Browser.Document.Write(HTML.StatBlock(DeckView.TopCard, null, null, true, false, true, CardMode.View, Session.Preferences.TextSize));
		}
	}
}
