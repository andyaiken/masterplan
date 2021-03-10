using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class CreatureDetailsForm : Form
	{
		public CreatureDetailsForm(EncounterCard card)
		{
			InitializeComponent();

			fCard = card;

			Browser.DocumentText = HTML.StatBlock(fCard, null, null, true, false, true, CardMode.View, DisplaySize.Small);
		}

		EncounterCard fCard = null;

		private void PlayerViewBtn_Click(object sender, EventArgs e)
		{
			if (fCard != null)
			{
				if (Session.PlayerView == null)
					Session.PlayerView = new PlayerViewForm(this);

				Session.PlayerView.ShowEncounterCard(fCard);
			}
		}

		private void ExportHTML_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.FileName = fCard.Title;
			dlg.Filter = Program.HTMLFilter;

			if (dlg.ShowDialog() == DialogResult.OK)
				File.WriteAllText(dlg.FileName, Browser.DocumentText);
		}
	}
}
