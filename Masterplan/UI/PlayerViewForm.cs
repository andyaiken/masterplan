using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Masterplan.Controls;
using Masterplan.Data;
using Masterplan.Events;
using Masterplan.Tools;

namespace Masterplan.UI
{
	enum PlayerViewMode
	{
		Blank,
		HTML,
		RichText,
		Image,
		Calendar,
		Combat,
		RegionalMap
	}

	partial class PlayerViewForm : Form
	{
		public static bool UseOtherDisplay = true;

		public PlayerViewForm(Form parent)
		{
			InitializeComponent();

			set_location(parent);
		}

		void set_location(Form parent)
		{
			if (!PlayerViewForm.UseOtherDisplay)
				return;

			if (Screen.AllScreens.Length < 2)
				return;

			// See if we can find an external monitor
			List<Screen> other_screens = new List<Screen>();
			foreach (Screen screen in Screen.AllScreens)
			{
				Rectangle rect = screen.Bounds;

				if (rect.Contains(parent.ClientRectangle))
					continue;

				other_screens.Add(screen);
			}

			if (other_screens.Count == 0)
				return;

			StartPosition = FormStartPosition.Manual;
			Location = other_screens[0].WorkingArea.Location;
			WindowState = FormWindowState.Maximized;
			FormBorderStyle = FormBorderStyle.None;
		}

		private void PlayerViewForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Session.PlayerView = null;
		}

		public PlayerViewMode Mode
		{
			get { return fMode; }
			set { fMode = value; }
		}
		PlayerViewMode fMode = PlayerViewMode.Blank;

        #region Default

        public void ShowDefault()
		{
			TitlePanel ctrl = new TitlePanel();
			ctrl.Title = "Masterplan";
			ctrl.Zooming = true;
			ctrl.Mode = TitlePanel.TitlePanelMode.PlayerView;
			ctrl.BackColor = Color.Black;
			ctrl.ForeColor = Color.White;
			ctrl.MouseMove += new MouseEventHandler(mouse_move);

			Controls.Clear();
			Controls.Add(ctrl);
			ctrl.Dock = DockStyle.Fill;

			fMode = PlayerViewMode.Blank;

			Show();
		}

		void mouse_move(object sender, MouseEventArgs e)
		{
			TitlePanel title = Controls[0] as TitlePanel;
			title.Wake();
        }

        #endregion

        public void ShowMessage(string message)
		{
			string html = HTML.Text(message, true, true, Session.Preferences.PlayerViewTextSize);
			set_html(html);

			Show();
		}

		public void ShowPlainText(Attachment att)
		{
			string str = new ASCIIEncoding().GetString(att.Contents);
			string html = HTML.Text(str, true, false, Session.Preferences.PlayerViewTextSize);
			set_html(html);

			Show();
		}

		public void ShowRichText(Attachment att)
		{
			string str = new ASCIIEncoding().GetString(att.Contents);

			RichTextBox ctrl = new RichTextBox();
			ctrl.Rtf = str;
			ctrl.ReadOnly = true;
			ctrl.Multiline = true;
			ctrl.ScrollBars = RichTextBoxScrollBars.Vertical;

			Controls.Clear();
			Controls.Add(ctrl);
			ctrl.Dock = DockStyle.Fill;

			fMode = PlayerViewMode.RichText;

			Show();
        }

        public void ShowWebPage(Attachment att)
		{
			WebBrowser ctrl = new WebBrowser();
			ctrl.IsWebBrowserContextMenuEnabled = false;
			ctrl.ScriptErrorsSuppressed = true;
            ctrl.WebBrowserShortcutsEnabled = false;

			switch (att.Type)
			{
				case AttachmentType.URL:
					{
						string str = new ASCIIEncoding().GetString(att.Contents);
						string[] lines = str.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
						string url = "";
						foreach (string line in lines)
						{
							if (line.StartsWith("URL="))
							{
								url = line.Substring(4);
								break;
							}
						}

						if (url != "")
							ctrl.Navigate(url);
					}
					break;
				case AttachmentType.HTML:
					{
						string str = new ASCIIEncoding().GetString(att.Contents);
						ctrl.DocumentText = str;
					}
					break;
			}

			Controls.Clear();
			Controls.Add(ctrl);
			ctrl.Dock = DockStyle.Fill;

			fMode = PlayerViewMode.HTML;

			Show();
		}

		public void ShowImage(Attachment att)
		{
			Image img = Image.FromStream(new MemoryStream(att.Contents));

			PictureBox ctrl = new PictureBox();
			ctrl.Image = img;
			ctrl.SizeMode = PictureBoxSizeMode.Zoom;

			Controls.Clear();
			Controls.Add(ctrl);
			ctrl.Dock = DockStyle.Fill;

			fMode = PlayerViewMode.Image;

			Show();
		}

		public void ShowImage(Image img)
		{
			PictureBox ctrl = new PictureBox();
			ctrl.Image = img;
			ctrl.SizeMode = PictureBoxSizeMode.Zoom;

			Controls.Clear();
			Controls.Add(ctrl);
			ctrl.Dock = DockStyle.Fill;

			fMode = PlayerViewMode.Image;

			Show();
		}

		public void ShowPlotPoint(PlotPoint pp)
		{
			string html = HTML.Text(pp.ReadAloud, false, false, Session.Preferences.PlayerViewTextSize);
			set_html(html);

			Show();
        }

        public void ShowBackground(Background background)
		{
			string html = HTML.Background(background, Session.Preferences.PlayerViewTextSize);
			set_html(html);

			Show();
		}

		public void ShowBackground(List<Background> backgrounds)
		{
			string html = HTML.Background(backgrounds, Session.Preferences.PlayerViewTextSize);
			set_html(html);

			Show();
        }

        public void ShowEncyclopediaItem(IEncyclopediaItem item)
		{
			if (item is EncyclopediaEntry)
			{
				string html = HTML.EncyclopediaEntry(item as EncyclopediaEntry, Session.Project.Encyclopedia, Session.Preferences.PlayerViewTextSize, false, false, false, false);
				set_html(html);
			}

			if (item is EncyclopediaGroup)
			{
				string html = HTML.EncyclopediaGroup(item as EncyclopediaGroup, Session.Project.Encyclopedia, Session.Preferences.PlayerViewTextSize, false, false);
				set_html(html);
			}

			Show();
		}

		public void ShowEncyclopediaGroup(EncyclopediaGroup group)
		{
			string html = HTML.EncyclopediaGroup(group, Session.Project.Encyclopedia, Session.Preferences.PlayerViewTextSize, false, false);
			set_html(html);

			Show();
        }

        #region Tactical map

        public void ShowTacticalMap(MapView mapview, string initiative)
		{
			fParentMap = mapview;

			MapView mv = null;
			if (fParentMap != null)
			{
				mv = new MapView();
				mv.Map = fParentMap.Map;
				mv.Viewpoint = fParentMap.Viewpoint;
				mv.BorderSize = fParentMap.BorderSize;
				mv.ScalingFactor = fParentMap.ScalingFactor;
				mv.Encounter = fParentMap.Encounter;
				mv.Plot = fParentMap.Plot;
				mv.TokenLinks = fParentMap.TokenLinks;
				mv.AllowDrawing = fParentMap.AllowDrawing;
				mv.Mode = MapViewMode.PlayerView;
				mv.Tactical = true;
				mv.HighlightAreas = false;
				mv.FrameType = MapDisplayType.Opaque;
				mv.ShowCreatures = Session.Preferences.PlayerViewFog;
				mv.ShowHealthBars = Session.Preferences.PlayerViewHealthBars;
				mv.ShowCreatureLabels = Session.Preferences.PlayerViewCreatureLabels;
				mv.ShowGrid = (Session.Preferences.PlayerViewGrid ? MapGridMode.Overlay : MapGridMode.None);
				mv.ShowGridLabels = Session.Preferences.PlayerViewGridLabels;
				mv.ShowAuras = false;
				mv.ShowGrid = MapGridMode.None;

				foreach (MapSketch sketch in mapview.Sketches)
					mv.Sketches.Add(sketch.Copy());

				mv.SelectedTokensChanged += new EventHandler(selected_tokens_changed);
				mv.HoverTokenChanged += new EventHandler(hover_token_changed);
				mv.ItemMoved += new Masterplan.Events.MovementEventHandler(item_moved);
				mv.TokenDragged += new Masterplan.Events.DraggedTokenEventHandler(token_dragged);
				mv.SketchCreated += new Masterplan.Events.MapSketchEventHandler(sketch_created);
				mv.Dock = DockStyle.Fill;
			}

			Button dicebtn = new Button();
			dicebtn.Text = "Die Roller";
			dicebtn.BackColor = SystemColors.Control;
			dicebtn.Dock = DockStyle.Bottom;
			dicebtn.Click +=new EventHandler(dicebtn_click);

			WebBrowser browser = new WebBrowser();
			browser.IsWebBrowserContextMenuEnabled = false;
			browser.ScriptErrorsSuppressed = true;
			browser.WebBrowserShortcutsEnabled = false;
			browser.Dock = DockStyle.Fill;
			browser.DocumentText = initiative;

			SplitContainer splitter = new SplitContainer();
			splitter.Panel1.Controls.Add(mv);
			splitter.Panel2.Controls.Add(browser);
			splitter.Panel2.Controls.Add(dicebtn);

			Controls.Clear();
			Controls.Add(splitter);
			splitter.Dock = DockStyle.Fill;

			if (mapview == null)
			{
				splitter.Panel1Collapsed = true;
			}
			else if (initiative == null)
			{
				splitter.Panel2Collapsed = true;
			}
			else
			{
				splitter.BackColor = Color.FromArgb(10, 10, 10);
				splitter.SplitterDistance = (int)(Width * 0.65);
				splitter.FixedPanel = FixedPanel.Panel2;

				splitter.Panel2Collapsed = !Session.Preferences.PlayerViewInitiative;
			}

			fMode = PlayerViewMode.Combat;

			Show();
		}

		public MapView ParentMap
		{
			get { return fParentMap; }
			set { fParentMap = value; }
		}
		MapView fParentMap = null;

		void selected_tokens_changed(object sender, EventArgs e)
		{
			SplitContainer splitter = Controls[0] as SplitContainer;
			MapView map = splitter.Panel1.Controls[0] as MapView;

			fParentMap.SelectTokens(map.SelectedTokens, true);
		}

		void hover_token_changed(object sender, EventArgs e)
		{
			SplitContainer splitter = Controls[0] as SplitContainer;
			MapView map = splitter.Panel1.Controls[0] as MapView;

			fParentMap.HoverToken = map.HoverToken;

			string title = "";
			string info = null;

			if (map.HoverToken is CreatureToken)
			{
				CreatureToken ct = map.HoverToken as CreatureToken;
				EncounterSlot slot = map.Encounter.FindSlot(ct.SlotID);
				ICreature creature = Session.FindCreature(slot.Card.CreatureID, SearchType.Global);

				int hp_total = slot.Card.HP;
				int hp_current = hp_total - ct.Data.Damage;
				int hp_bloodied = hp_total / 2;

				if (map.ShowCreatureLabels)
				{
					title = ct.Data.DisplayName;
				}
				else
				{
					title = creature.Category;
					if (title == "")
						title = "Creature";
				}

				if (ct.Data.Damage == 0)
					info = "Not wounded";
				if (hp_current < hp_total)
					info = "Wounded";
				if (hp_current < hp_bloodied)
					info = "Bloodied";
				if (hp_current <= 0)
					info = "Dead";

				if (ct.Data.Conditions.Count != 0)
				{
					info += Environment.NewLine;

					foreach (OngoingCondition oc in ct.Data.Conditions)
					{
						info += Environment.NewLine;
						info += oc.ToString(fParentMap.Encounter, false);
					}
				}
			}

			if (map.HoverToken is Hero)
			{
				Hero hero = map.HoverToken as Hero;

				title = hero.Name;

				info = hero.Race + " " + hero.Class;
				info += Environment.NewLine;
				info += "Player: " + hero.Player;
			}

			if (map.HoverToken is CustomToken)
			{
				CustomToken ct = map.HoverToken as CustomToken;

				if (map.ShowCreatureLabels)
				{
					title = ct.Name;
					info = "(custom token)";
				}
			}

			Tooltip.ToolTipTitle = title;
			Tooltip.ToolTipIcon = ToolTipIcon.Info;
			Tooltip.SetToolTip(map, info);
		}

		void item_moved(object sender, MovementEventArgs e)
		{
			fParentMap.Invalidate();
		}

		void token_dragged(object sender, Masterplan.Events.DraggedTokenEventArgs e)
		{
			fParentMap.SetDragInfo(e.OldLocation, e.NewLocation);
        }

		void sketch_created(object sender, Masterplan.Events.MapSketchEventArgs e)
		{
			fParentMap.Sketches.Add(e.Sketch.Copy());
			fParentMap.Invalidate();
		}

		void dicebtn_click(object sender, EventArgs e)
		{
			DieRollerForm dlg = new DieRollerForm();
			dlg.ShowDialog();
		}

        #endregion

		public void ShowRegionalMap(RegionalMapPanel panel)
		{
			RegionalMapPanel ctrl = new RegionalMapPanel();
			ctrl.Map = panel.Map;
			ctrl.Mode = MapViewMode.PlayerView;

			if (panel.SelectedLocation == null)
			{
				ctrl.ShowLocations = false;
			}
			else
			{
				ctrl.ShowLocations = true;
				ctrl.HighlightedLocation = panel.SelectedLocation;
			}

			Controls.Clear();
			Controls.Add(ctrl);
			ctrl.Dock = DockStyle.Fill;

			fMode = PlayerViewMode.RegionalMap;

			Show();
		}
		
		public void ShowHandout(List<object> items, bool include_dm_info)
		{
			string html = HTML.Handout(items, Session.Preferences.PlayerViewTextSize, include_dm_info);
			set_html(html);

			Show();
        }

        public void ShowPCs()
		{
			string html = HTML.PartyBreakdown(Session.Preferences.PlayerViewTextSize);
			set_html(html);

			Show();
		}

		public void ShowPlayerOption(IPlayerOption option)
		{
			string html = HTML.PlayerOption(option, Session.Preferences.PlayerViewTextSize);
			set_html(html);

			Show();
		}

		public void ShowCalendar(Calendar calendar, int month_index, int year)
		{
			CalendarPanel ctrl = new CalendarPanel();
			ctrl.Calendar = calendar;
			ctrl.MonthIndex = month_index;
			ctrl.Year = year;

			Controls.Clear();
			Controls.Add(ctrl);
			ctrl.Dock = DockStyle.Fill;

			fMode = PlayerViewMode.Calendar;

			Show();
		}

		public void ShowHero(Hero h)
		{
			string html = HTML.StatBlock(h, null, true, false, false, Session.Preferences.PlayerViewTextSize);
			set_html(html);

			Show();
		}

		public void ShowEncounterCard(EncounterCard card)
		{
			string html = HTML.StatBlock(card, null, null, true, false, true, CardMode.View, Session.Preferences.PlayerViewTextSize);
			set_html(html);

			Show();
		}

		public void ShowCreatureTemplate(CreatureTemplate template)
		{
			string html = HTML.CreatureTemplate(template, Session.Preferences.PlayerViewTextSize, false);
			set_html(html);

			Show();
		}

		public void ShowTrap(Trap trap)
		{
			string html = HTML.Trap(trap, null, true, false, false, Session.Preferences.PlayerViewTextSize);
			set_html(html);

			Show();
		}

		public void ShowSkillChallenge(SkillChallenge sc)
		{
			string html = HTML.SkillChallenge(sc, false, true, Session.Preferences.PlayerViewTextSize);
			set_html(html);

			Show();
		}

		public void ShowMagicItem(MagicItem item)
		{
			string html = HTML.MagicItem(item, Session.Preferences.PlayerViewTextSize, false, true);
			set_html(html);

			Show();
		}

		public void ShowArtifact(Artifact artifact)
		{
			string html = HTML.Artifact(artifact, Session.Preferences.PlayerViewTextSize, false, true);
			set_html(html);

			Show();
		}

		public void ShowTerrainPower(TerrainPower tp)
		{
			string html = HTML.TerrainPower(tp, Session.Preferences.PlayerViewTextSize);
			set_html(html);

			Show();
		}

		public void ShowEncounterReportTable(ReportTable table)
		{
			string html = HTML.EncounterReportTable(table, Session.Preferences.PlayerViewTextSize);
			set_html(html);

			Show();
		}

		void set_html(string html)
		{
			WebBrowser ctrl = new WebBrowser();
			ctrl.IsWebBrowserContextMenuEnabled = false;
			ctrl.ScriptErrorsSuppressed = true;
			ctrl.WebBrowserShortcutsEnabled = false;
			ctrl.DocumentText = html;

			Controls.Clear();
			Controls.Add(ctrl);
			ctrl.Dock = DockStyle.Fill;

			fMode = PlayerViewMode.HTML;
		}
	}
}
