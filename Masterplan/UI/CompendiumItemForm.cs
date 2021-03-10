using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class CompendiumItemForm : Form
	{
		public CompendiumItemForm(CompendiumHelper.CompendiumItem item)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fItem = item;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			OKBtn.Enabled = (fResult != null);
		}

		public object Result
		{
			get { return fResult; }
		}
		object fResult = null;

		CompendiumHelper.CompendiumItem fItem = null;

		private void CompendiumItemForm_Shown(object sender, EventArgs e)
		{
			CompendiumBrowser.Navigate(fItem.URL);
		}

		private void CompendiumBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			if (e.Url.ToString() != fItem.URL)
			{
				List<string> lines = new List<string>();

				lines.AddRange(HTML.GetHead(null, null, DisplaySize.Small));
				lines.Add("<BODY>");
				lines.Add("<P>You need to log into the Compendium to see this item.</P>");
				lines.Add("<P>When you do, the item will be imported and its details will be shown in this panel.</P>");
				lines.Add("<P>The imported item can then be edited if its details are incorrect.</P>");
				lines.Add("</BODY>");
				lines.Add("</HTML>");

				ItemBrowser.DocumentText = HTML.Concatenate(lines);

				return;
			}

			switch (fItem.Type)
			{
				case CompendiumHelper.ItemType.Creature:
					fResult = CompendiumImport.ImportCreatureFromHTML(CompendiumBrowser.DocumentText, fItem.URL);
					break;
				case CompendiumHelper.ItemType.Trap:
					fResult = CompendiumImport.ImportTrapFromHTML(CompendiumBrowser.DocumentText, fItem.URL);
					break;
				case CompendiumHelper.ItemType.MagicItem:
					fResult = CompendiumImport.ImportItemFromHTML(CompendiumBrowser.DocumentText, fItem.URL);
					break;
			}

			if (fResult != null)
			{
				display_result();
			}
			else
			{
				List<string> lines = new List<string>();

				lines.AddRange(HTML.GetHead(null, null, DisplaySize.Small));
				lines.Add("<BODY>");
				lines.Add("<P class=instruction>The item could not be imported.</P>");
				lines.Add("</BODY>");
				lines.Add("</HTML>");

				ItemBrowser.DocumentText = HTML.Concatenate(lines);
			}
		}

		void display_result()
		{
			Library lib = new Library();
			lib.Name = "Not yet added";
			Session.Libraries.Insert(0, lib);

			switch (fItem.Type)
			{
				case CompendiumHelper.ItemType.Creature:
					{
						Creature c = fResult as Creature;
						lib.Creatures.Add(c);

						EncounterCard card = new EncounterCard();
						card.CreatureID = c.ID;

						ItemBrowser.DocumentText = HTML.StatBlock(card, null, null, true, false, true, CardMode.View, DisplaySize.Small);
					}
					break;
				case CompendiumHelper.ItemType.Trap:
					{
						Trap t = fResult as Trap;
						lib.Traps.Add(t);

						ItemBrowser.DocumentText = HTML.Trap(t, null, true, false, false, DisplaySize.Small);
					}
					break;
				case CompendiumHelper.ItemType.MagicItem:
					{
						MagicItem mi = fResult as MagicItem;
						lib.MagicItems.Add(mi);

						ItemBrowser.DocumentText = HTML.MagicItem(mi, DisplaySize.Small, false, true);
					}
					break;
			}

			Session.Libraries.Remove(lib);
		}
	}
}
