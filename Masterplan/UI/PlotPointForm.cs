using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Masterplan.Controls;
using Masterplan.Data;
using Masterplan.Tools;
using Masterplan.Tools.Generators;

namespace Masterplan.UI
{
	partial class PlotPointForm : Form
	{
		public PlotPointForm(PlotPoint pp, Plot p, bool start_at_element_page)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			ParcelList_SizeChanged(null, null);
			LinkList_SizeChanged(null, null);
			EncBrowser.DocumentText = "";

			fPoint = pp.Copy();
			fPlot = p;
			fStartAtElement = start_at_element_page;

			NameBox.Text = fPoint.Name;
			DetailsBox.Text = fPoint.Details;
			ReadAloudBox.Text = fPoint.ReadAloud;
			XPBox.Value = fPoint.AdditionalXP;

			if (fPlot.FindPoint(fPoint.ID) != null)
				StartXPLbl.Text = "Start at: " + Workspace.GetTotalXP(fPoint) + " XP";
			else
			{
				StartXPLbl.Visible = false;
				XPSeparator.Visible = false;
			}

			update_element();
			update_parcels();
            update_encyclopedia_entries();
			update_links();

			if (Session.Project.Encyclopedia.Entries.Count == 0)
				Pages.TabPages.Remove(EncyclopediaPage);
			else
				EncyclopediaList_SelectedIndexChanged(null, null);

			if (start_at_element_page)
				Pages.SelectedTab = RPGPage;
		}

		~PlotPointForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			MapLocation loc = null;
			if (fPoint.RegionalMapID != Guid.Empty)
			{
				RegionalMap map = Session.Project.FindRegionalMap(fPoint.RegionalMapID);
				if ((map != null) && (fPoint.MapLocationID != Guid.Empty))
					loc = map.FindLocation(fPoint.MapLocationID);
			}

			int count = 0;
			foreach (RegionalMap map in Session.Project.RegionalMaps)
				count += map.Locations.Count;

			LocationBtn.Enabled = (count != 0);
			LocationBtn.Text = (loc != null) ? loc.Name : "Set Location";
			ClearLocationLbl.Visible = (loc != null);

			DateBtn.Enabled = (Session.Project.Calendars.Count != 0);
			DateBtn.Text = (fPoint.Date != null) ? fPoint.Date.ToString() : "Set Date";
			ClearDateLbl.Visible = (fPoint.Date != null);

			CopyElementBtn.Visible = (fPoint.Element != null);
			RemoveElementBtn.Visible = (fPoint.Element != null);

			ParcelAddPredefined.Enabled = (Session.Project.TreasureParcels.Count != 0);
			ParcelAddItem.Enabled = (Session.MagicItems.Count != 0);
			ParcelAddArtifact.Enabled = (Session.Artifacts.Count != 0);
			ParcelRemoveBtn.Enabled = (SelectedParcel != null);
			ParcelEditBtn.Enabled = (SelectedParcel != null);

			if (SelectedParcel != null)
			{
				bool is_item = SelectedParcel.MagicItemID != Guid.Empty;
				bool is_real_item = is_item && !Treasure.PlaceholderIDs.Contains(SelectedParcel.MagicItemID);
				bool is_artifact = SelectedParcel.ArtifactID != Guid.Empty;
				bool is_real_artifact = is_artifact && !Treasure.PlaceholderIDs.Contains(SelectedParcel.ArtifactID);

				ChangeItemBtn.Enabled = (is_item || is_artifact);
				ItemStatBlockBtn.Enabled = (is_real_item || is_real_artifact);

				if (is_item)
					ChangeItemBtn.Text = "Select Magic Item";
				else if (is_artifact)
					ChangeItemBtn.Text = "Select Artifact";
				else
					ChangeItemBtn.Text = "Select";
			}
			else
			{
				ChangeItemBtn.Enabled = false;
				ItemStatBlockBtn.Enabled = false;
			}

            EncyclopediaRemoveBtn.Enabled = (SelectedEntry != null);
			EncPlayerViewBtn.Enabled = (SelectedEntry != null);

			RemoveBtn.Enabled = (SelectedLink != null);
		}

		public PlotPoint PlotPoint
		{
			get { return fPoint; }
			set { fPoint = value; }
		}
		PlotPoint fPoint = null;

		Plot fPlot = null;
		bool fStartAtElement = false;

		#region Game elements

		private void RemoveElementBtn_Click(object sender, EventArgs e)
		{
			if (fPoint.Element != null)
			{
				fPoint.Element = null;
				update_element();
			}
		}

		private void CopyElementBtn_Click(object sender, EventArgs e)
		{
			if (fPoint.Element != null)
			{
				string type = fPoint.Element.GetType().ToString();
				Clipboard.SetData(type, fPoint.Element);
			}
		}

		private void CutElementBtn_Click(object sender, EventArgs e)
		{
			if (fPoint.Element != null)
			{
				string type = fPoint.Element.GetType().ToString();
				Clipboard.SetData(type, fPoint.Element);

				fPoint.Element = null;
				update_element();
			}
		}

		void update_element()
		{
			RPGPanel.Controls.Clear();

			Control ctrl = null;
			int level = get_party_level();

			if (fPoint.Element is Encounter)
			{
				EncounterPanel panel = new EncounterPanel();
				panel.Encounter = fPoint.Element as Encounter;
				panel.PartyLevel = level;

				ctrl = panel;
			}

			if (fPoint.Element is SkillChallenge)
			{
				SkillChallengePanel panel = new SkillChallengePanel();
				panel.Challenge = fPoint.Element as SkillChallenge;
				panel.PartyLevel = level;

				ctrl = panel;
			}

			if (fPoint.Element is TrapElement)
			{
				TrapElementPanel panel = new TrapElementPanel();
				panel.Trap = fPoint.Element as TrapElement;

				ctrl = panel;
			}

			if (fPoint.Element is Quest)
			{
				QuestPanel panel = new QuestPanel();
				panel.Quest = fPoint.Element as Quest;

				ctrl = panel;
			}

			if (fPoint.Element is MapElement)
			{
				MapElementPanel panel = new MapElementPanel();
				panel.MapElement = fPoint.Element as MapElement;

				ctrl = panel;
			}

			if (ctrl == null)
			{
				WebBrowser browser = new WebBrowser();
				browser.IsWebBrowserContextMenuEnabled = false;
				browser.ScriptErrorsSuppressed = true;
				browser.WebBrowserShortcutsEnabled = false;
				browser.ScrollBarsEnabled = false;
				browser.DocumentText = get_element_html();
				browser.Navigating += new WebBrowserNavigatingEventHandler(element_select);
				ctrl = browser;
			}

			if (ctrl != null)
			{
				ctrl.Dock = DockStyle.Fill;
				RPGPanel.Controls.Add(ctrl);
			}
		}

		string get_element_html()
		{
			List<string> lines = new List<string>();

			lines.Add("<HTML>");
			lines.AddRange(HTML.GetHead("Plot Point", "Plot Point", Session.Preferences.TextSize));
			lines.Add("<BODY>");

			lines.Add("<P>");
			lines.Add("This plot point does not contain a game element (such as an encounter or a skill challenge).");
			lines.Add("The list of available game elements is below.");
			lines.Add("You can add a game element to this plot point by clicking on one of the links.");
			lines.Add("</P>");

			lines.Add("<P class=table>");
			lines.Add("<TABLE>");

			lines.Add("<TR class=heading>");
			lines.Add("<TD><B>Select a Game Element</B></TD>");
			lines.Add("</TR>");

			lines.Add("<TR>");
			lines.Add("<TD>Add a <A href=\"element:encounter\">combat encounter</A></TD>");
			lines.Add("</TR>");

			lines.Add("<TR>");
			lines.Add("<TD>Add a <A href=\"element:challenge\">skill challenge</A></TD>");
			lines.Add("</TR>");

			lines.Add("<TR>");
			lines.Add("<TD>Add a <A href=\"element:trap\">trap or hazard</A></TD>");
			lines.Add("</TR>");

			lines.Add("<TR>");
			lines.Add("<TD>Add a <A href=\"element:quest\">quest</A></TD>");
			lines.Add("</TR>");

			lines.Add("<TR>");
			lines.Add("<TD>Add a <A href=\"element:map\">tactical map</A></TD>");
			lines.Add("</TR>");

			if (Clipboard.ContainsData(typeof(Encounter).ToString()))
			{
				lines.Add("<TR>");
				lines.Add("<TD><A href=\"element:pasteencounter\">Paste the encounter from the clipboard</A></TD>");
				lines.Add("</TR>");
			}

			if (Clipboard.ContainsData(typeof(SkillChallenge).ToString()))
			{
				lines.Add("<TR>");
				lines.Add("<TD><A href=\"element:pastechallenge\">Paste the skill challenge from the clipboard</A></TD>");
				lines.Add("</TR>");
			}

			if (Clipboard.ContainsData(typeof(TrapElement).ToString()))
			{
				lines.Add("<TR>");
				lines.Add("<TD><A href=\"element:pastetrap\">Paste the trap from the clipboard</A></TD>");
				lines.Add("</TR>");
			}

			if (Clipboard.ContainsData(typeof(Quest).ToString()))
			{
				lines.Add("<TR>");
				lines.Add("<TD><A href=\"element:pastequest\">Paste the quest from the clipboard</A></TD>");
				lines.Add("</TR>");
			}

			if (Clipboard.ContainsData(typeof(MapElement).ToString()))
			{
				lines.Add("<TR>");
				lines.Add("<TD><A href=\"element:pastemap\">Paste the map from the clipboard</A></TD>");
				lines.Add("</TR>");
			}

			lines.Add("</TABLE>");
			lines.Add("</P>");

			lines.Add("</BODY>");
			lines.Add("</HTML>");

			return HTML.Concatenate(lines);
		}

		void element_select(object sender, WebBrowserNavigatingEventArgs e)
		{
			int level = get_party_level();

			if (e.Url.LocalPath == "encounter")
			{
				// Add an encounter
				Encounter enc = new Encounter();
				enc.SetStandardEncounterNotes();
				fPoint.Element = enc;

				update_element();
			}

			if (e.Url.LocalPath == "pasteencounter")
			{
				// Add an encounter
				Encounter enc = Clipboard.GetData(typeof(Encounter).ToString()) as Encounter;
				fPoint.Element = enc;

				update_element();
			}

			if (e.Url.LocalPath == "challenge")
			{
				// Add a skill challenge
				SkillChallenge sc = new SkillChallenge();
				sc.Name = "Unnamed Skill Challenge";
				sc.Level = level;
				fPoint.Element = sc;

				update_element();
			}

			if (e.Url.LocalPath == "pastechallenge")
			{
				// Add a skill challenge
				SkillChallenge sc = Clipboard.GetData(typeof(SkillChallenge).ToString()) as SkillChallenge;
				sc.Level = level;
				fPoint.Element = sc;

				update_element();
			}

			if (e.Url.LocalPath == "trap")
			{
				// Add a trap
				TrapElement te = new TrapElement();
				te.Trap.Name = "Unnamed Trap";
				te.Trap.Level = level;
				fPoint.Element = te;

				update_element();
			}

			if (e.Url.LocalPath == "pastetrap")
			{
				// Add a trap
				TrapElement te = Clipboard.GetData(typeof(TrapElement).ToString()) as TrapElement;
				te.Trap.Level = level;
				fPoint.Element = te;

				update_element();
			}

			if (e.Url.LocalPath == "quest")
			{
				// Add a quest
				Quest q = new Quest();
				q.Level = level;
				fPoint.Element = q;

				update_element();
			}

			if (e.Url.LocalPath == "pastequest")
			{
				// Add a quest
				Quest q = Clipboard.GetData(typeof(Quest).ToString()) as Quest;
				q.Level = level;
				fPoint.Element = q;

				update_element();
			}

			if (e.Url.LocalPath == "map")
			{
				// Add a map
				MapElement me = new MapElement();
				fPoint.Element = me;

				update_element();
			}

			if (e.Url.LocalPath == "pastemap")
			{
				// Add a map
				MapElement me = Clipboard.GetData(typeof(MapElement).ToString()) as MapElement;
				fPoint.Element = me;

				update_element();
			}
		}

		#endregion

		#region Parcels

		public Parcel SelectedParcel
		{
			get
			{
				if (ParcelList.SelectedItems.Count != 0)
					return ParcelList.SelectedItems[0].Tag as Parcel;

				return null;
			}
		}

		private void ParcelAddPredefined_Click(object sender, EventArgs e)
		{
			ParcelSelectForm dlg = new ParcelSelectForm();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fPoint.Parcels.Add(dlg.Parcel);
				Session.Project.TreasureParcels.Remove(dlg.Parcel);

				update_parcels();
			}
		}

		private void ParcelAddParcel_Click(object sender, EventArgs e)
		{
			Parcel p = new Parcel();
			p.Name = "New Treasure Parcel";

			ParcelForm dlg = new ParcelForm(p);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fPoint.Parcels.Add(dlg.Parcel);
				update_parcels();
			}
		}

		private void ParcelAddItem_Click(object sender, EventArgs e)
		{
			MagicItemSelectForm dlg = new MagicItemSelectForm(Session.Project.Party.Level);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fPoint.Parcels.Add(new Parcel(dlg.MagicItem));
				update_parcels();
			}
		}

		private void ParcelAddArtifact_Click(object sender, EventArgs e)
		{
			ArtifactSelectForm dlg = new ArtifactSelectForm();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fPoint.Parcels.Add(new Parcel(dlg.Artifact));
				update_parcels();
			}
		}

		private void ParcelRemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedParcel != null)
			{
				fPoint.Parcels.Remove(SelectedParcel);
				Session.Project.TreasureParcels.Add(SelectedParcel);

				update_parcels();
			}
		}

		private void ParcelEditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedParcel != null)
			{
				int index = fPoint.Parcels.IndexOf(SelectedParcel);

				ParcelForm dlg = new ParcelForm(SelectedParcel);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fPoint.Parcels[index] = dlg.Parcel;
					update_parcels();
				}
			}
		}

		private void ChangeItemBtn_Click(object sender, EventArgs e)
		{
			if (SelectedParcel != null)
			{
				if (SelectedParcel.MagicItemID != Guid.Empty)
				{
					int level = SelectedParcel.FindItemLevel();
					if (level != -1)
					{
						MagicItemSelectForm dlg = new MagicItemSelectForm(level);
						if (dlg.ShowDialog() == DialogResult.OK)
							SelectedParcel.SetAsMagicItem(dlg.MagicItem);
					}
				}
				else if (SelectedParcel.ArtifactID != Guid.Empty)
				{
					ArtifactSelectForm dlg = new ArtifactSelectForm();
					if (dlg.ShowDialog() == DialogResult.OK)
						SelectedParcel.SetAsArtifact(dlg.Artifact);
				}

				update_parcels();
			}
		}

		private void ItemStatBlockBtn_Click(object sender, EventArgs e)
		{
			if (SelectedParcel != null)
			{
				if (SelectedParcel.MagicItemID != Guid.Empty)
				{
					MagicItem item = Session.FindMagicItem(SelectedParcel.MagicItemID, SearchType.Global);
					if (item != null)
					{
						MagicItemDetailsForm dlg = new MagicItemDetailsForm(item);
						dlg.ShowDialog();
					}
				}
				else if (SelectedParcel.ArtifactID != Guid.Empty)
				{
					Artifact item = Session.FindArtifact(SelectedParcel.ArtifactID, SearchType.Global);
					if (item != null)
					{
						ArtifactDetailsForm dlg = new ArtifactDetailsForm(item);
						dlg.ShowDialog();
					}
				}

			}
		}

		private void ParcelList_SizeChanged(object sender, EventArgs e)
		{
			int width = ParcelList.Width - (SystemInformation.VerticalScrollBarWidth + 6);
			ParcelList.TileSize = new Size(width, ParcelList.TileSize.Height);
		}

		void update_parcels()
		{
			ParcelList.Items.Clear();

			foreach (Parcel p in fPoint.Parcels)
			{
				string name = p.Name;
				if (name == "")
					name = "(undefined parcel)";

				if (p.MagicItemID != Guid.Empty)
				{
					if (Treasure.PlaceholderIDs.Contains(p.MagicItemID))
					{
						// Placeholder
					}
					else
					{
						MagicItem item = Session.FindMagicItem(p.MagicItemID, SearchType.Global);
						if (item != null)
							name += " (" + item.Info.ToLower() + ")";
					}
				}

				if (p.ArtifactID != Guid.Empty)
				{
					if (Treasure.PlaceholderIDs.Contains(p.ArtifactID))
					{
						// Placeholder
					}
					else
					{
						Artifact item = Session.FindArtifact(p.ArtifactID, SearchType.Global);
						if (item != null)
							name += " (" + item.Tier.ToString().ToLower() + " tier)";
					}
				}

				ListViewItem lvi = ParcelList.Items.Add(name);
				lvi.Tag = p;

				if (p.Details != "")
					lvi.SubItems.Add(p.Details);
				else
					lvi.SubItems.Add("(no details)");

				Hero hero = null;
				if (p.HeroID != Guid.Empty)
					hero = Session.Project.FindHero(p.HeroID);

				if (hero != null)
					lvi.SubItems.Add("Allocated to " + hero.Name);
				else
					lvi.SubItems.Add("(not allocated to a PC)");
			}

			if (ParcelList.Items.Count == 0)
			{
				ListViewItem lvi = ParcelList.Items.Add("(no parcels)");
				lvi.ForeColor = SystemColors.GrayText;
			}
		}

		#endregion

        #region Encyclopedia Entries

        EncyclopediaEntry SelectedEntry
        {
            get
            {
                if (EncyclopediaList.SelectedItems.Count != 0)
                    return EncyclopediaList.SelectedItems[0].Tag as EncyclopediaEntry;

                return null;
            }
        }

        private void EncyclopediaAddBtn_Click(object sender, EventArgs e)
        {
            EncyclopediaEntrySelectForm dlg = new EncyclopediaEntrySelectForm(fPoint.EncyclopediaEntryIDs);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fPoint.EncyclopediaEntryIDs.Add(dlg.EncyclopediaEntry.ID);
                update_encyclopedia_entries();
            }
        }

        private void EncyclopediaRemoveBtn_Click(object sender, EventArgs e)
        {
            if (SelectedEntry != null)
            {
                fPoint.EncyclopediaEntryIDs.Remove(SelectedEntry.ID);
                update_encyclopedia_entries();
            }
        }

		private void EncPlayerViewBtn_Click(object sender, EventArgs e)
		{
			if (SelectedEntry != null)
			{
				if (Session.PlayerView == null)
					Session.PlayerView = new PlayerViewForm(this);

				Session.PlayerView.ShowEncyclopediaItem(SelectedEntry);
			}
		}

		private void EncyclopediaList_SelectedIndexChanged(object sender, EventArgs e)
		{
			string text = HTML.EncyclopediaEntry(SelectedEntry, Session.Project.Encyclopedia, Session.Preferences.TextSize, true, false, false, true);

			EncBrowser.Document.OpenNew(true);
			EncBrowser.Document.Write(text);
		}

        void update_encyclopedia_entries()
        {
            EncyclopediaList.BeginUpdate();

            EncyclopediaList.Items.Clear();
            foreach (Guid entry_id in fPoint.EncyclopediaEntryIDs)
            {
                EncyclopediaEntry entry = Session.Project.Encyclopedia.FindEntry(entry_id);
                if (entry == null)
                    continue;

                ListViewItem lvi = EncyclopediaList.Items.Add(entry.Name);
                lvi.Tag = entry;
            }

            if (EncyclopediaList.Items.Count == 0)
            {
                ListViewItem lvi = EncyclopediaList.Items.Add("(no encyclopedia entries)");
                lvi.ForeColor = SystemColors.GrayText;
            }

            EncyclopediaList.EndUpdate();
        }

        #endregion

		#region Links

		PlotPoint SelectedLink
		{
			get
			{
				if (LinkList.SelectedItems.Count != 0)
					return LinkList.SelectedItems[0].Tag as PlotPoint;

				return null;
			}
		}

		private void RemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedLink != null)
			{
				if (SelectedLink.Links.Contains(fPoint.ID))
				{
					// Remove the link to this item
					while (SelectedLink.Links.Contains(fPoint.ID))
						SelectedLink.Links.Remove(fPoint.ID);
				}
				else if (fPoint.Links.Contains(SelectedLink.ID))
				{
					// Remove the link from this item
					while (fPoint.Links.Contains(SelectedLink.ID))
						fPoint.Links.Remove(SelectedLink.ID);
				}

				update_links();
			}
		}

		private void LinkList_SizeChanged(object sender, EventArgs e)
		{
			int width = LinkList.Width - (SystemInformation.VerticalScrollBarWidth + 6);
			LinkList.TileSize = new Size(width, LinkList.TileSize.Height);
		}

		void update_links()
		{
			LinkList.Items.Clear();

			// Links to this item
			foreach (PlotPoint pp in fPlot.Points)
			{
				if (pp.Links.Contains(fPoint.ID))
				{
					ListViewItem lvi = LinkList.Items.Add(pp.Name);
					lvi.SubItems.Add((pp.Details != "") ? pp.Details : "(no details)");

					lvi.Tag = pp;
					lvi.Group = LinkList.Groups[0];
				}
			}

			// Links from this item
			foreach (Guid id in fPoint.Links)
			{
				PlotPoint pp = fPlot.FindPoint(id);
				if (pp != null)
				{
					ListViewItem lvi = LinkList.Items.Add(pp.Name);
					lvi.SubItems.Add((pp.Details != "") ? pp.Details : "(no details)");

					lvi.Tag = pp;
					lvi.Group = LinkList.Groups[1];
				}
			}

			foreach (ListViewGroup lvg in LinkList.Groups)
			{
				if (lvg.Items.Count == 0)
				{
					ListViewItem lvi = LinkList.Items.Add("(none)");
					lvi.ForeColor = SystemColors.GrayText;
					lvi.Group = lvg;
				}
			}
		}

		#endregion

		#region Location and Date

		private void LocationBtn_Click(object sender, EventArgs e)
		{
			MapLocationSelectForm dlg = new MapLocationSelectForm(fPoint.RegionalMapID, fPoint.MapLocationID);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fPoint.RegionalMapID = (dlg.Map != null) ? dlg.Map.ID : Guid.Empty;
				fPoint.MapLocationID = (dlg.MapLocation != null) ? dlg.MapLocation.ID : Guid.Empty;
			}
		}

		private void ClearLocationLbl_Click(object sender, EventArgs e)
		{
			fPoint.RegionalMapID = Guid.Empty;
			fPoint.MapLocationID = Guid.Empty;
		}

		private void DateBtn_Click(object sender, EventArgs e)
		{
			CalendarDate date = fPoint.Date;
			if (date == null)
			{
				date = new CalendarDate();

				Calendar cal = Session.Project.Calendars[0];
				date.CalendarID = cal.ID;
				date.Year = cal.CampaignYear;
			}

			DateForm dlg = new DateForm(date);
			if (dlg.ShowDialog() == DialogResult.OK)
				fPoint.Date = dlg.Date;
		}

		private void ClearDateLbl_Click(object sender, EventArgs e)
		{
			fPoint.Date = null;
		}

		#endregion

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fPoint.Name = NameBox.Text;
			fPoint.Details = (DetailsBox.Text != DetailsBox.DefaultText) ? DetailsBox.Text : "";
			fPoint.ReadAloud = (ReadAloudBox.Text != ReadAloudBox.DefaultText) ? ReadAloudBox.Text : "";
			fPoint.AdditionalXP = (int)XPBox.Value;
        }

		private void AllocateBtn_DropDownOpening(object sender, EventArgs e)
		{
			AllocateBtn.DropDownItems.Clear();
			foreach (Hero hero in Session.Project.Heroes)
			{
				ToolStripMenuItem tsmi = new ToolStripMenuItem(hero.Name);
				tsmi.Tag = hero;
				tsmi.Click += assign_to_hero;

				if (SelectedParcel != null)
					tsmi.Checked = (SelectedParcel.HeroID == hero.ID);

				AllocateBtn.DropDownItems.Add(tsmi);
			}

			if (Session.Project.Heroes.Count != 0)
				AllocateBtn.DropDownItems.Add(new ToolStripSeparator());

			ToolStripMenuItem tsmi_none = new ToolStripMenuItem("Not Allocated");
			tsmi_none.Tag = null;
			tsmi_none.Click += assign_to_hero;

			if (SelectedParcel != null)
				tsmi_none.Checked = (SelectedParcel.HeroID == Guid.Empty);

			AllocateBtn.DropDownItems.Add(tsmi_none);
		}

		private void assign_to_hero(object sender, EventArgs e)
		{
			if (SelectedParcel == null)
				return;

			ToolStripItem tsi = sender as ToolStripItem;
			if (tsi == null)
				return;

			Hero hero = tsi.Tag as Hero;
			SelectedParcel.HeroID = (hero != null) ? hero.ID : Guid.Empty;

			update_parcels();
		}

		private void PlotPointForm_Shown(object sender, EventArgs e)
		{
			if (fStartAtElement)
			{
				if (RPGPanel.Controls.Count == 0)
					return;

				EncounterPanel enc_pnl = RPGPanel.Controls[0] as EncounterPanel;
				if (enc_pnl != null)
					enc_pnl.Edit();

				SkillChallengePanel sc_pnl = RPGPanel.Controls[0] as SkillChallengePanel;
				if (sc_pnl != null)
					sc_pnl.Edit();
			}
		}

		int get_party_level()
		{
			// Work out the approximate party level here
			int level = Session.Project.Party.Level;
			if (fPlot.FindPoint(fPoint.ID) != null)
			{
				level = Workspace.GetPartyLevel(fPoint);
			}
			else
			{
				if (fPlot.Points.Count > 0)
				{
					List<List<PlotPoint>> layers = Workspace.FindLayers(fPlot);
					level = Workspace.GetPartyLevel(layers[0][0]);
				}
			}

			return level;
		}

		private void SettingsMenu_DropDownOpening(object sender, EventArgs e)
		{
			SettingsMenu.DropDownItems.Clear();

			Array states = Enum.GetValues(typeof(PlotPointState));
			foreach (PlotPointState state in states)
			{
				ToolStripMenuItem tsmi = SettingsMenu.DropDownItems.Add(state.ToString()) as ToolStripMenuItem;
				tsmi.Tag = state;
				tsmi.Checked = (fPoint.State == state);
				tsmi.Click += new EventHandler(select_state);
			}

			SettingsMenu.DropDownItems.Add(new ToolStripSeparator());

			Array colours = Enum.GetValues(typeof(PlotPointColour));
			foreach (PlotPointColour colour in colours)
			{
				string text = colour.ToString();
				if (colour == PlotPointColour.Yellow)
					text += " (default)";

				Bitmap img = new Bitmap(16, 16);
				Rectangle img_rect = new Rectangle(0, 0, 16, 16);
				Pair<Color, Color> gradient = PlotView.GetColourGradient(colour, 255);
				Graphics g = Graphics.FromImage(img);
				g.FillRectangle(new LinearGradientBrush(img_rect, gradient.First, gradient.Second, LinearGradientMode.Vertical), img_rect);

				ToolStripMenuItem tsmi = SettingsMenu.DropDownItems.Add(text) as ToolStripMenuItem;
				tsmi.Image = img;
				tsmi.Tag = colour;
				tsmi.Checked = (fPoint.Colour == colour);
				tsmi.Click += new EventHandler(select_colour);
			}
		}

		void select_state(object sender, EventArgs e)
		{
			ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
			if (tsmi != null)
			{
				PlotPointState state = (PlotPointState)tsmi.Tag;
				fPoint.State = state;
			}
		}

		void select_colour(object sender, EventArgs e)
		{
			ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
			if (tsmi != null)
			{
				PlotPointColour colour = (PlotPointColour)tsmi.Tag;
				fPoint.Colour = colour;
			}
		}

		private void InfoBtn_Click(object sender, EventArgs e)
		{
			InfoForm dlg = new InfoForm();
			dlg.Level = get_party_level();
			dlg.ShowDialog();
		}

		private void DieRollerBtn_Click(object sender, EventArgs e)
		{
			DieRollerForm dlg = new DieRollerForm();
			dlg.ShowDialog();
		}
	}
}
