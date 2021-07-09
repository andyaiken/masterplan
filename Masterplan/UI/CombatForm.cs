using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;

using Utils;

using Masterplan.Controls;
using Masterplan.Data;
using Masterplan.Events;
using Masterplan.Extensibility;
using Masterplan.Tools;

namespace Masterplan.UI
{
    /// <summary>
    /// Enumeration containing the various methods for rolling initiative.
    /// </summary>
	public enum InitiativeMode
	{
        /// <summary>
        /// Creatures of the same type share the same initiative roll.
        /// </summary>
		AutoGroup,

        /// <summary>
        /// Roll initiative for each creature individually.
        /// </summary>
		AutoIndividual,

		/// <summary>
		/// Roll initiative for creatures manually.
		/// </summary>
		ManualIndividual,

		/// <summary>
		/// Roll initiative for creatures manually in groups.
		/// </summary>
		ManualGroup
	}

	partial class CombatForm : Form
	{
		#region Helper classes

		class InitiativeSorter : IComparer, IComparer<ListViewItem>
		{
			public InitiativeSorter(/*Dictionary<Guid, CombatData> hero_data,*/ Dictionary<Guid, CombatData> trap_data, Encounter enc)
			{
				//fHeroData = hero_data;
				fTrapData = trap_data;
				fEncounter = enc;
			}

			//Dictionary<Guid, CombatData> fHeroData = null;
			Dictionary<Guid, CombatData> fTrapData = null;
			Encounter fEncounter = null;

			public int Compare(object x, object y)
			{
				ListViewItem lvi_x = x as ListViewItem;
				ListViewItem lvi_y = y as ListViewItem;

				if ((lvi_x == null) || (lvi_y == null))
					return 0;

				return Compare(lvi_x, lvi_y);
			}

			public int Compare(ListViewItem lvi_x, ListViewItem lvi_y)
			{
				int score_x = get_score(lvi_x);
				int score_y = get_score(lvi_y);

				int result = score_x.CompareTo(score_y);

				if (result == 0)
				{
					int bonus_x = get_bonus(lvi_x);
					int bonus_y = get_bonus(lvi_y);

					result = bonus_x.CompareTo(bonus_y);
				}

				if (result == 0)
				{
					string text_x = lvi_x.Text;
					string text_y = lvi_y.Text;

					result = text_x.CompareTo(text_y) * -1;
				}

				return -result;
			}

			int get_score(ListViewItem lvi)
			{
				try
				{
					if (lvi.Tag is Hero)
					{
						Hero hero = lvi.Tag as Hero;
						return hero.CombatData.Initiative;
						//if (fHeroData.ContainsKey(hero.ID))
						//    return fHeroData[hero.ID].Initiative;
						//else
						//    return int.MinValue;
					}

					if (lvi.Tag is CreatureToken)
					{
						CreatureToken data = lvi.Tag as CreatureToken;
						return data.Data.Initiative;
					}

					if (lvi.Tag is Trap)
					{
						Trap trap = lvi.Tag as Trap;
						if (fTrapData.ContainsKey(trap.ID))
							return fTrapData[trap.ID].Initiative;
						else
							return int.MinValue;
					}
				}
				catch (Exception ex)
				{
					LogSystem.Trace(ex);
				}

				return 0;
			}

			int get_bonus(ListViewItem lvi)
			{
				try
				{
					if (lvi.Tag is Hero)
					{
						Hero hero = lvi.Tag as Hero;
						return hero.InitBonus;
					}

					if (lvi.Tag is CreatureToken)
					{
						CreatureToken ct = lvi.Tag as CreatureToken;
						EncounterSlot slot = fEncounter.FindSlot(ct.SlotID);
						return (slot != null) ? slot.Card.Initiative : 0;
					}

					if (lvi.Tag is Trap)
					{
						Trap trap = lvi.Tag as Trap;
						return (trap.Initiative != int.MinValue) ? trap.Initiative : 0;
					}
				}
				catch (Exception ex)
				{
					LogSystem.Trace(ex);
				}

				return 0;
			}
		}

		public class CombatListControl : ListView
		{
			public CombatListControl()
			{
				DoubleBuffered = true;
			}
		}

		#endregion

		public CombatForm(CombatState cs)
		{
			InitializeComponent();
			Preview.DocumentText = "";
			LogBrowser.DocumentText = "";

			Application.Idle += new EventHandler(Application_Idle);

			fLeft.Alignment = StringAlignment.Near;
			fLeft.LineAlignment = StringAlignment.Center;
			fRight.Alignment = StringAlignment.Far;
			fRight.LineAlignment = StringAlignment.Center;

			fEncounter = cs.Encounter.Copy() as Encounter;
			fPartyLevel = cs.PartyLevel;
			fRemovedCreatureXP = cs.RemovedCreatureXP;

			fCurrentRound = cs.CurrentRound;
			RoundLbl.Text = "Round " + fCurrentRound;

			if (cs.QuickEffects != null)
			{
				foreach (OngoingCondition effect in cs.QuickEffects)
					add_quick_effect(effect);
			}

			#region Initialise heroes

			if (cs.HeroData != null)
			{
				// Update the hero combat information
				foreach (Hero h in Session.Project.Heroes)
				{
					if (cs.HeroData.ContainsKey(h.ID))
						h.CombatData = cs.HeroData[h.ID];
				}
			}
			else
			{
				// We're starting an encounter; clear PC locations
				foreach (Hero h in Session.Project.Heroes)
					h.CombatData.Location = CombatData.NoPoint;
			}
			foreach (Hero h in Session.Project.Heroes)
			{
				h.CombatData.ID = h.ID;
				h.CombatData.DisplayName = h.Name;
			}
			//if (cs.HeroData != null)
			//    fHeroData = cs.HeroData;
			//if (fHeroData == null)
			//    fHeroData = new Dictionary<Guid, CombatData>();
			//foreach (Hero h in Session.Project.Heroes)
			//{
			//    if (fHeroData.ContainsKey(h.ID))
			//        continue;

			//    CombatData cd = new CombatData();
			//    cd.DisplayName = h.Name;
			//    cd.ID = h.ID;

			//    fHeroData[h.ID] = cd;
			//}

			#endregion

			#region Initialise traps

			if (cs.TrapData != null)
				fTrapData = cs.TrapData;
			else
				fTrapData = new Dictionary<Guid, CombatData>();
			foreach (Trap t in fEncounter.Traps)
			{
				if (fTrapData.ContainsKey(t.ID))
					continue;

				CombatData cd = new CombatData();
				cd.DisplayName = t.Name;
				cd.ID = t.ID;

				fTrapData[t.ID] = cd;
			}

			#endregion

			#region Initialise templates

			if (fEncounter.MapID != Guid.Empty)
			{
				foreach (Hero hero in Session.Project.Heroes)
				{
					foreach (CustomToken ct in hero.Tokens)
					{
						string name = hero.Name + ": " + ct.Name;

						ListViewItem lvi = TemplateList.Items.Add(name);
						lvi.Tag = ct;
						lvi.Group = TemplateList.Groups[0];
					}
				}

				Array sizes = Enum.GetValues(typeof(CreatureSize));
				foreach (CreatureSize size in sizes)
				{
					CustomToken ct = new CustomToken();
					ct.Type = CustomTokenType.Token;
					ct.TokenSize = size;
					ct.Colour = Color.Black;
					ct.Name = size + " Token";

					ListViewItem lvi = TemplateList.Items.Add(ct.Name);
					lvi.Tag = ct;
					lvi.Group = TemplateList.Groups[1];
				}

				for (int n = 2; n <= 10; ++n)
				{
					CustomToken ct = new CustomToken();
					ct.Type = CustomTokenType.Overlay;
					ct.OverlaySize = new Size(n, n);
					ct.Name = n + " x " + n + " Zone";
					ct.Colour = Color.Transparent;

					ListViewItem lvi = TemplateList.Items.Add(ct.Name);
					lvi.Tag = ct;
					lvi.Group = TemplateList.Groups[2];
				}
			}
			else
			{
				Pages.TabPages.Remove(TemplatesPage);
			}

			#endregion

			fLog = cs.Log;
			fLog.Active = false;
			if (fLog.Entries.Count != 0)
			{
				fLog.Active = true;
				fLog.AddResumeEntry();
			}
			update_log();

			// Set current actor
			if (cs.CurrentActor != Guid.Empty)
			{
				fCombatStarted = true;

				Hero hero = Session.Project.FindHero(cs.CurrentActor);
				if (hero != null)
				//if (fHeroData.ContainsKey(cs.CurrentActor))
				{
					//fCurrentActor = fHeroData[cs.CurrentActor];
					fCurrentActor = hero.CombatData;
				}
				else if (fTrapData.ContainsKey(cs.CurrentActor))
				{
					fCurrentActor = fTrapData[cs.CurrentActor];
				}
				else
				{
					CombatData cd = fEncounter.FindCombatData(cs.CurrentActor);
					if (cd != null)
						fCurrentActor = cd;
				}
			}

			CombatList.ListViewItemSorter = new InitiativeSorter(/*fHeroData,*/ fTrapData, fEncounter);

			set_map(cs.TokenLinks, cs.Viewpoint, cs.Sketches);
			MapMenu.Visible = (fEncounter.MapID != Guid.Empty);

			InitiativePanel.InitiativeScores = get_initiatives();
			InitiativePanel.CurrentInitiative = InitiativePanel.Maximum;

			PlayerViewMapMenu.Visible = (fEncounter.MapID != Guid.Empty);
			PlayerViewNoMapMenu.Visible = (fEncounter.MapID == Guid.Empty);

			if (!Session.Preferences.CombatColumnInitiative)
				InitHdr.Width = 0;
			if (!Session.Preferences.CombatColumnHP)
				HPHdr.Width = 0;
			if (!Session.Preferences.CombatColumnDefences)
				DefHdr.Width = 0;
			if (!Session.Preferences.CombatColumnEffects)
				EffectsHdr.Width = 0;

			Screen screen = Screen.FromControl(this);
			if (screen.Bounds.Height > screen.Bounds.Width)
				OptionsPortrait_Click(null, null);

			Session.CurrentEncounter = fEncounter;

			update_list();
			update_log();
			update_preview_panel();
			update_maps();
			update_statusbar();
		}

		#region Properties

		Encounter fEncounter = null;
		int fPartyLevel = Session.Project.Party.Level;

		//Dictionary<Guid, CombatData> fHeroData = null;
		Dictionary<Guid, CombatData> fTrapData = null;

		bool fCombatStarted = false;

		CombatData fCurrentActor = null;
		int fCurrentRound = 1;

		int fRemovedCreatureXP = 0;

		List<OngoingCondition> fEffects = new List<OngoingCondition>();
		EncounterLog fLog = new EncounterLog();

		bool fUpdatingList = false;
		bool fPromptOnClose = true;

		StringFormat fLeft = new StringFormat();
		StringFormat fRight = new StringFormat();

		public List<IToken> SelectedTokens
		{
			get
			{
				List<IToken> tokens = new List<IToken>();

				foreach (ListViewItem lvi in CombatList.SelectedItems)
				{
					IToken token = lvi.Tag as IToken;
					if (token != null)
						tokens.Add(token);
				}

				return tokens;
			}
		}

		public Trap SelectedTrap
		{
			get
			{
				if (CombatList.SelectedItems.Count != 0)
					return CombatList.SelectedItems[0].Tag as Trap;

				return null;
			}
		}

		public SkillChallenge SelectedChallenge
		{
			get
			{
				if (CombatList.SelectedItems.Count != 0)
					return CombatList.SelectedItems[0].Tag as SkillChallenge;

				return null;
			}
		}

		public MapView PlayerMap
		{
			get
			{
				if (Session.PlayerView == null)
					return null;

				if (Session.PlayerView.Controls.Count == 0)
					return null;

				SplitContainer splitter = Session.PlayerView.Controls[0] as SplitContainer;
				if (splitter == null)
					return null;

				if (splitter.Panel1Collapsed)
					return null;

				if (splitter.Panel1.Controls.Count == 0)
					return null;

				return splitter.Panel1.Controls[0] as MapView;
			}
		}

		public WebBrowser PlayerInitiative
		{
			get
			{
				if (Session.PlayerView == null)
					return null;

				if (Session.PlayerView.Controls.Count == 0)
					return null;

				SplitContainer splitter = Session.PlayerView.Controls[0] as SplitContainer;
				if (splitter == null)
					return null;

				if (splitter.Panel2Collapsed)
					return null;

				if (splitter.Panel2.Controls.Count == 0)
					return null;

				foreach (Control ctrl in splitter.Panel2.Controls)
				{
					WebBrowser init = ctrl as WebBrowser;
					if (init != null)
						return init;
				}

				return null;
			}
		}

		public bool TwoColumnPreview
		{
			get
			{
				return (fCurrentActor != null) && (Preview.Width > 630);
			}
		}

		#endregion

		#region Toolbar

		private void DetailsBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (SelectedTokens.Count == 1)
					edit_token(SelectedTokens[0]);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void DamageBtn_Click(object sender, EventArgs e)
		{
			try
			{
				do_damage(SelectedTokens);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void HealBtn_Click(object sender, EventArgs e)
		{
			try
			{
				do_heal(SelectedTokens);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void DelayBtn_Click(object sender, EventArgs e)
		{
			try
			{
				set_delay(SelectedTokens);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void NextInitBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (!fCombatStarted)
				{
					start_combat();
					return;
				}

				List<int> scores = get_initiatives();
				if (scores.Count == 0)
					return;

				handle_ended_effects(false);
				handle_saves();

				// Select the next combatant
				fCurrentActor = get_next_actor(fCurrentActor);
				fLog.AddStartTurnEntry(fCurrentActor.ID);

				if (fCurrentActor.Initiative > InitiativePanel.CurrentInitiative)
				{
					fCurrentRound += 1;
					RoundLbl.Text = "Round: " + fCurrentRound;

					fLog.AddStartRoundEntry(fCurrentRound);
				}
				InitiativePanel.CurrentInitiative = fCurrentActor.Initiative;

				handle_regen();
				handle_ended_effects(true);
				handle_ongoing_damage();
				handle_recharge();

				if ((fCurrentActor != null) && (!TwoColumnPreview))
					select_current_actor();

				update_list();
				update_log();
				update_preview_panel();

				highlight_current_actor();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#region Combatants

		private void CombatantsAdd_Click(object sender, EventArgs e)
		{
			try
			{
				Encounter enc = new Encounter();
				EncounterBuilderForm dlg = new EncounterBuilderForm(enc, fPartyLevel, true);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					foreach (EncounterSlot slot in dlg.Encounter.Slots)
					{
						fEncounter.Slots.Add(slot);

						if (fCombatStarted)
							roll_initiative();
					}

                    foreach (Trap trap in dlg.Encounter.Traps)
                    {
                        if (trap.Initiative != int.MinValue)
                        {
							fTrapData[trap.ID] = new CombatData();

							if (fCombatStarted)
								roll_initiative();
                        }

                        fEncounter.Traps.Add(trap);
                    }

                    foreach (SkillChallenge sc in dlg.Encounter.SkillChallenges)
                    {
                        fEncounter.SkillChallenges.Add(sc);
                    }

					update_list();
					update_preview_panel();
					update_statusbar();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void CombatantsAddCustom_Click(object sender, EventArgs e)
		{
			try
			{
				CustomToken ct = new CustomToken();
				ct.Name = "Custom Token";
                ct.Type = CustomTokenType.Token;

				CustomTokenForm dlg = new CustomTokenForm(ct);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fEncounter.CustomTokens.Add(dlg.Token);

					update_list();
					update_maps();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

        private void CombatantsAddOverlay_Click(object sender, EventArgs e)
        {
            try
            {
                CustomToken ct = new CustomToken();
                ct.Name = "Custom Overlay";
                ct.Type = CustomTokenType.Overlay;

                CustomOverlayForm dlg = new CustomOverlayForm(ct);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    fEncounter.CustomTokens.Add(dlg.Token);

                    update_list();
                    update_maps();
                }
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }
        }

		private void CombatantsRemove_Click(object sender, EventArgs e)
		{
			if (SelectedTokens.Count != 0)
				remove_from_combat(SelectedTokens);
		}

		private void CombatantsHideAll_Click(object sender, EventArgs e)
		{
			show_or_hide_all(false);
		}

		private void CombatantsShowAll_Click(object sender, EventArgs e)
		{
			show_or_hide_all(true);
		}

		#endregion

		#region Map

		private void ShowMap_Click(object sender, EventArgs e)
		{
			try
			{
				MapSplitter.Panel2Collapsed = !MapSplitter.Panel2Collapsed;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void MapLOS_Click(object sender, EventArgs e)
		{
			try
			{
				MapView.LineOfSight = !MapView.LineOfSight;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void MapGrid_Click(object sender, EventArgs e)
		{
			try
			{
				MapView.ShowGrid = (MapView.ShowGrid == MapGridMode.None) ? MapGridMode.Overlay : MapGridMode.None;
				Session.Preferences.CombatGrid = (MapView.ShowGrid == MapGridMode.Overlay);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void MapGridLabels_Click(object sender, EventArgs e)
		{
			try
			{
				MapView.ShowGridLabels = !MapView.ShowGridLabels;
				Session.Preferences.CombatGridLabels = MapView.ShowGridLabels;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

        private void MapHealth_Click(object sender, EventArgs e)
        {
            try
            {
                MapView.ShowHealthBars = !MapView.ShowHealthBars;
                Session.Preferences.CombatHealthBars = MapView.ShowHealthBars;
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }
        }

		private void MapConditions_Click(object sender, EventArgs e)
		{
			try
			{
				MapView.ShowConditions = !MapView.ShowConditions;
				Session.Preferences.CombatConditionBadges = MapView.ShowConditions;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void MapPictureTokens_Click(object sender, EventArgs e)
		{
			try
			{
				MapView.ShowPictureTokens = !MapView.ShowPictureTokens;
				Session.Preferences.CombatPictureTokens = MapView.ShowPictureTokens;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#region Fog of War

		private void MapFogAllCreatures_Click(object sender, EventArgs e)
		{
			try
			{
				MapView.ShowCreatures = CreatureViewMode.All;
                Session.Preferences.CombatFog = CreatureViewMode.All;

				update_list();
				update_preview_panel();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void MapFogVisibleCreatures_Click(object sender, EventArgs e)
		{
			try
			{
				MapView.ShowCreatures = CreatureViewMode.Visible;
                Session.Preferences.CombatFog = CreatureViewMode.Visible;

				update_list();
				update_preview_panel();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void MapFogHideCreatures_Click(object sender, EventArgs e)
		{
			try
			{
				MapView.ShowCreatures = CreatureViewMode.None;
                Session.Preferences.CombatFog = CreatureViewMode.None;

				update_list();
				update_preview_panel();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		private void MapNavigate_Click(object sender, EventArgs e)
		{
			try
			{
				MapView.AllowScrolling = !MapView.AllowScrolling;
				ZoomGauge.Visible = MapView.AllowScrolling;

				if (Session.PlayerView != null)
				{
					if (!MapView.AllowScrolling)
					{
						cancelled_scrolling();
					}
					else
					{
						Session.Preferences.PlayerViewMap = (PlayerMap != null);
						Session.Preferences.PlayerViewInitiative = (PlayerInitiative != null);

						Session.PlayerView.ShowMessage("DM is editing the map; please wait");
					}
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void MapReset_Click(object sender, EventArgs e)
		{
			try
			{
				ZoomGauge.Value = 50;
				MapView.ScalingFactor = 1.0;

				if (fEncounter.MapAreaID != Guid.Empty)
				{
					MapArea area = MapView.Map.FindArea(fEncounter.MapAreaID);
					MapView.Viewpoint = area.Region;
				}
				else
				{
					MapView.Viewpoint = Rectangle.Empty;
				}

				if (PlayerMap != null)
				{
					PlayerMap.Viewpoint = MapView.Viewpoint;
				}

				MapView.MapChanged();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void MapPrint_Click(object sender, EventArgs e)
		{
			try
			{
				MapPrintingForm dlg = new MapPrintingForm(MapView);
				dlg.ShowDialog();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void MapExport_Click(object sender, EventArgs e)
		{
			try
			{
				SaveFileDialog dlg = new SaveFileDialog();
				dlg.FileName = MapView.Map.Name;
				if (fEncounter.MapAreaID != Guid.Empty)
				{
					MapArea area = MapView.Map.FindArea(fEncounter.MapAreaID);
					dlg.FileName += " - " + area.Name;
				}
				dlg.Filter = "Bitmap Image |*.bmp|JPEG Image|*.jpg|GIF Image|*.gif|PNG Image|*.png";

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					ImageFormat format = ImageFormat.Bmp;
					switch (dlg.FilterIndex)
					{
						case 1:
							format = ImageFormat.Bmp;
							break;
						case 2:
							format = ImageFormat.Jpeg;
							break;
						case 3:
							format = ImageFormat.Gif;
							break;
						case 4:
							format = ImageFormat.Png;
							break;
					}

					Bitmap bmp = Screenshot.Map(MapView);
					bmp.Save(dlg.FileName, format);
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		#region Player View

		private void PlayerViewMap_Click(object sender, EventArgs e)
		{
			try
			{
				show_player_view(PlayerMap == null, PlayerInitiative != null);
				//Session.Preferences.PlayerViewMap = !Session.Preferences.PlayerViewMap;

				//if ((PlayerMap != null) && (PlayerInitiative == null))
				//{
				//    // It's all we're showing; turn it off
				//    Session.PlayerView.ShowDefault();
				//}
				//else
				//{
				//    if (Session.PlayerView == null)
				//        Session.PlayerView = new PlayerViewForm(this);

				//    if (PlayerInitiative == null)
				//    {
				//        Session.PlayerView.ShowTacticalMap(MapView, InitiativeView());
				//        //Activate();
				//    }
				//    else
				//    {
				//        // We're already showing the initiative list
				//        SplitContainer splitter = Session.PlayerView.Controls[0] as SplitContainer;
				//        splitter.Panel1Collapsed = false;
				//    }
				//}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void PlayerViewInitList_Click(object sender, EventArgs e)
		{
			try
			{
				show_player_view(PlayerMap != null, PlayerInitiative == null);
				//Session.Preferences.PlayerViewInitiative = !Session.Preferences.PlayerViewInitiative;

				//if (Session.PlayerView == null)
				//    return;

				//if (Session.PlayerView.Controls.Count == 0)
				//    return;

				//SplitContainer splitter = Session.PlayerView.Controls[0] as SplitContainer;
				//splitter.Panel2Collapsed = !Session.Preferences.PlayerViewInitiative;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void PlayerLabels_Click(object sender, EventArgs e)
		{
			try
			{
				Session.Preferences.PlayerViewCreatureLabels = !Session.Preferences.PlayerViewCreatureLabels;

                if (PlayerMap != null)
                {
                    PlayerMap.ShowCreatureLabels = !PlayerMap.ShowCreatureLabels;
                }

				if (PlayerInitiative != null)
				{
					PlayerInitiative.DocumentText = InitiativeView();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

        private void PlayerHealth_Click(object sender, EventArgs e)
        {
            try
            {
                if (PlayerMap != null)
                {
                    PlayerMap.ShowHealthBars = !PlayerMap.ShowHealthBars;
                    Session.Preferences.PlayerViewHealthBars = PlayerMap.ShowHealthBars;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }
        }

		private void PlayerConditions_Click(object sender, EventArgs e)
		{
			try
			{
				if (PlayerMap != null)
				{
					PlayerMap.ShowConditions = !PlayerMap.ShowConditions;
					Session.Preferences.PlayerViewConditionBadges = PlayerMap.ShowConditions;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void PlayerPictureTokens_Click(object sender, EventArgs e)
		{
			try
			{
				if (PlayerMap != null)
				{
					PlayerMap.ShowPictureTokens = !PlayerMap.ShowPictureTokens;
					Session.Preferences.PlayerViewPictureTokens = PlayerMap.ShowPictureTokens;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void PlayerViewLOS_Click(object sender, EventArgs e)
		{
			try
			{
                if (PlayerMap != null)
                {
                    PlayerMap.LineOfSight = !PlayerMap.LineOfSight;
                }
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void PlayerViewGrid_Click(object sender, EventArgs e)
		{
			try
			{
				if (PlayerMap != null)
				{
					PlayerMap.ShowGrid = (PlayerMap.ShowGrid == MapGridMode.None) ? MapGridMode.Overlay : MapGridMode.None;
					Session.Preferences.PlayerViewGrid = (PlayerMap.ShowGrid == MapGridMode.Overlay);
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void PlayerViewGridLabels_Click(object sender, EventArgs e)
		{
			try
			{
				if (PlayerMap != null)
				{
					PlayerMap.ShowGridLabels = !PlayerMap.ShowGridLabels;
					Session.Preferences.PlayerViewGridLabels = PlayerMap.ShowGridLabels;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#region Fog of War

		private void PlayerFogAll_Click(object sender, EventArgs e)
		{
			try
			{
                if (PlayerMap != null)
                {
                    PlayerMap.ShowCreatures = CreatureViewMode.All;
                    Session.Preferences.PlayerViewFog = CreatureViewMode.All;
                }
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void PlayerFogVisible_Click(object sender, EventArgs e)
		{
			try
			{
                if (PlayerMap != null)
                {
                    PlayerMap.ShowCreatures = CreatureViewMode.Visible;
                    Session.Preferences.PlayerViewFog = CreatureViewMode.Visible;
                }
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void PlayerFogNone_Click(object sender, EventArgs e)
		{
			try
			{
                if (PlayerMap != null)
                {
                    PlayerMap.ShowCreatures = CreatureViewMode.None;
                    Session.Preferences.PlayerViewFog = CreatureViewMode.None;
                }
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		#endregion

		#region Options

		private void OneColumn_Click(object sender, EventArgs e)
		{
			try
			{
				if (ListSplitter.Orientation == System.Windows.Forms.Orientation.Horizontal)
					return;

				if (fEncounter.MapID != Guid.Empty)
					Session.Preferences.CombatTwoColumns = false;
				else
					Session.Preferences.CombatTwoColumnsNoMap = false;

				ListSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
				ListSplitter.SplitterDistance = ListSplitter.Height / 2;

				//if (MapSplitter.SplitterDistance > 350)
				//	MapSplitter.SplitterDistance -= 350;
				MapSplitter.SplitterDistance = 350;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void TwoColumns_Click(object sender, EventArgs e)
		{
			try
			{
				if (fEncounter.MapID != Guid.Empty)
					Session.Preferences.CombatTwoColumns = true;
				else
					Session.Preferences.CombatTwoColumnsNoMap = true;

                ListSplitter.Orientation = System.Windows.Forms.Orientation.Vertical;
				if ((!MapSplitter.Panel2Collapsed) && (MapSplitter.Orientation == System.Windows.Forms.Orientation.Vertical))
				{
					MapSplitter.SplitterDistance = 700;
					ListSplitter.SplitterDistance = 350;
				}
				else
				{
					ListSplitter.SplitterDistance = ListSplitter.Width / 2;
				}
				//MapSplitter.SplitterDistance += 350;
				//ListSplitter.SplitterDistance = ListSplitter.Width - 350;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ToolsAutoRemove_Click(object sender, EventArgs e)
		{
            Session.Preferences.CreatureAutoRemove = !Session.Preferences.CreatureAutoRemove;
		}

		#endregion

		#endregion

		#region Event handlers

		void Application_Idle(object sender, EventArgs e)
		{
			try
			{
				bool mob = false;
				bool delayed = false;

				if (SelectedTokens.Count != 0)
				{
					mob = true;
					delayed = true;

					foreach (IToken token in SelectedTokens)
					{
						bool token_is_mob = ((token is CreatureToken) || (token is Hero));
						if (!token_is_mob)
						{
							mob = false;
							delayed = false;
						}

						if (token is CreatureToken)
						{
							CreatureToken ct = token as CreatureToken;
							if (!ct.Data.Delaying)
								delayed = false;
						}

						if (token is Hero)
						{
							Hero hero = token as Hero;
							//CombatData cd = fHeroData[hero.ID];
							CombatData cd = hero.CombatData;
							if (!cd.Delaying)
								delayed = false;
						}
					}
				}

				DetailsBtn.Enabled = (SelectedTokens.Count == 1);
				DamageBtn.Enabled = mob;
				HealBtn.Enabled = mob;
				EffectMenu.Enabled = mob;

				NextInitBtn.Text = fCombatStarted ? "Next Turn" : "Start Encounter";

				DelayBtn.Visible = fCombatStarted;
				DelayBtn.Enabled = mob;
				DelayBtn.Checked = delayed;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void CombatForm_Shown(object sender, EventArgs e)
		{
			try
			{
				if (!Session.Preferences.CombatMapRight)
					MapSplitter.SplitterDistance = MapSplitter.Height / 2;

				if (fCurrentActor == null)
				{
					// Reset PCs for the new fight
					foreach (Hero hero in Session.Project.Heroes)
						hero.CombatData.Reset(false);

					// We do this in case they had temp HP
					update_list();
					update_maps();

					/*
					// Show start screen
					List<CombatData> heroes = new List<CombatData>();
					//foreach (Guid id in fHeroData.Keys)
					//	heroes.Add(fHeroData[id]);
					foreach (Hero hero in Session.Project.Heroes)
						heroes.Add(hero.CombatData);
					List<CombatData> traps = new List<CombatData>();
					foreach (Guid id in fTrapData.Keys)
					{
						Trap trap = fEncounter.FindTrap(id);
						if ((trap != null) && (trap.Initiative != int.MinValue))
							traps.Add(fTrapData[id]);
					}
					CombatStartForm dlg = new CombatStartForm(fEncounter, heroes, traps);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						Session.Preferences.InitiativeMode = dlg.OpponentMode;
						roll_initiative();

						if (dlg.HeroMode == InitiativeMode.Individual)
						{
							foreach (Hero hero in Session.Project.Heroes)
							{
								int init = hero.InitBonus + Session.Dice(1, 20);
								//fHeroData[hero.ID].Initiative = init;
								hero.CombatData.Initiative = init;
							}
						}

						if (dlg.TrapMode == InitiativeMode.Individual)
						{
							foreach (Trap trap in fEncounter.Traps)
							{
								if (trap.Initiative == int.MinValue)
									continue;

								int init = trap.Initiative + Session.Dice(1, 20);
								fTrapData[trap.ID].Initiative = init;
							}
						}
					}
					else
					{
						Close();
						return;
					}
					*/
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void CombatForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if (fPromptOnClose)
				{
					bool enemies = false;
					foreach (EncounterSlot slot in fEncounter.AllSlots)
					{
						int hp = slot.Card.HP;

						foreach (CombatData cd in slot.CombatData)
						{
							// Ignore creatures that haven't been added to the encounter yet
							if (cd.Initiative == int.MinValue)
								continue;

							int total_hp = hp + cd.TempHP - cd.Damage;
							if (total_hp > 0)
								enemies = true;
						}
					}

					if (enemies)
					{
						string str = "There are creatures remaining; are you sure you want to end the encounter?";
						if (MessageBox.Show(str, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
						{
							e.Cancel = true;
							return;
						}
					}
				}

				if ((PlayerMap != null) || (PlayerInitiative != null))
					Session.PlayerView.ShowDefault();

				Session.CurrentEncounter = null;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void CombatList_ItemDrag(object sender, ItemDragEventArgs e)
		{
			try
			{
				if (SelectedTokens.Count != 1)
					return;

				IToken token = SelectedTokens[0];

				if (token is CreatureToken)
				{
					CreatureToken ct = token as CreatureToken;
					if (ct.Data.Location == CombatData.NoPoint)
					{
						DoDragDrop(ct, DragDropEffects.Move);

						update_list();
						update_preview_panel();
						update_maps();
					}
				}

				if (token is Hero)
				{
					Hero hero = token as Hero;

					if (hero.CombatData.Location == CombatData.NoPoint)
					{
						DoDragDrop(hero, DragDropEffects.Move);

						if (hero.CombatData.Location != CombatData.NoPoint)
						{
							update_list();
							update_preview_panel();
							update_maps();
						}
					}
				}

				if (token is CustomToken)
				{
					CustomToken ct = token as CustomToken;
					if (ct.Data.Location == CombatData.NoPoint)
					{
						DoDragDrop(ct, DragDropEffects.Move);

						update_list();
						update_preview_panel();
						update_maps();
					}
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void CombatList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			try
			{
				if (fUpdatingList)
					return;

				if (SelectedTokens.Count == 0)
				{
					MapView.SelectTokens(null, false);
					if (PlayerMap != null)
						PlayerMap.SelectTokens(null, false);

					update_preview_panel();
				}
				else
				{
					MapView.SelectTokens(SelectedTokens, false);
					if (PlayerMap != null)
						PlayerMap.SelectTokens(SelectedTokens, false);

					update_preview_panel();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void CombatList_SelectedIndexChanged(object sender, EventArgs e)
		{
			/*
			try
			{
				if (SelectedTokens.Count == 0)
				{
					MapView.HighlightedToken = null;
					if (PlayerMap != null)
						PlayerMap.HighlightedToken = null;

					update_preview_panel();
				}
				else
				{
					MapView.HighlightedToken = SelectedTokens[0];
					if (PlayerMap != null)
						PlayerMap.HighlightedToken = SelectedTokens[0];

					update_preview_panel();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
			*/
		}

		private void CombatList_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				if (SelectedTokens.Count == 1)
					edit_token(SelectedTokens[0]);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void MapView_ItemMoved(object sender, MovementEventArgs e)
		{
			try
			{
				update_maps();

				foreach (IToken token in MapView.SelectedTokens)
				{
					Guid id = Guid.Empty;

					CreatureToken ct = token as CreatureToken;
					if (ct != null)
						id = ct.Data.ID;

					Hero hero = token as Hero;
					if (hero != null)
						id = hero.ID;

					fLog.AddMoveEntry(id, e.Distance, "");
				}

				update_log();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void MapView_SelectedTokensChanged(object sender, EventArgs e)
		{
			try
			{
				fUpdatingList = true;
				CombatList.SelectedItems.Clear();
				foreach (IToken token in MapView.SelectedTokens)
					select_token(token);
				fUpdatingList = false;

				update_preview_panel();

				if (PlayerMap != null)
					PlayerMap.SelectTokens(MapView.SelectedTokens, false);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void MapView_HoverTokenChanged(object sender, EventArgs e)
		{
			try
			{
				set_tooltip(MapView.HoverToken, MapView);

				if (PlayerMap != null)
					PlayerMap.HoverToken = MapView.HoverToken;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void MapView_TokenActivated(object sender, Masterplan.Events.TokenEventArgs e)
		{
			try
			{
				if ((e.Token is CreatureToken) || (e.Token is Hero))
				{
					List<IToken> tokens = new List<IToken>();
					tokens.Add(e.Token);

					do_damage(tokens);
				}

				if (e.Token is CustomToken)
					edit_token(e.Token);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private TokenLink MapView_CreateTokenLink(object sender, TokenListEventArgs e)
		{
			try
			{
				TokenLink link = new TokenLink();
				link.Tokens.AddRange(e.Tokens);

				TokenLinkForm dlg = new TokenLinkForm(link);
				if (dlg.ShowDialog() == DialogResult.OK)
					return dlg.Link;

				return null;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}

			return null;
		}

		private TokenLink MapView_EditTokenLink(object sender, TokenLinkEventArgs e)
		{
			TokenLinkForm dlg = new TokenLinkForm(e.Link);
			if (dlg.ShowDialog() == DialogResult.OK)
				return dlg.Link;

			return null;
		}

		private void MapView_TokenDragged(object sender, DraggedTokenEventArgs e)
		{
			if (PlayerMap != null)
				PlayerMap.SetDragInfo(e.OldLocation, e.NewLocation);
		}

		private void ZoomGauge_Scroll(object sender, EventArgs e)
		{
			try
			{
				double max = 10.0;
				double mid = 1.0;
				double min = 0.1;

				double x = (double)(ZoomGauge.Value - ZoomGauge.Minimum) / (ZoomGauge.Maximum - ZoomGauge.Minimum);
				if (x >= 0.5)
				{
					x -= 0.5;
					x *= 2;
					MapView.ScalingFactor = mid + (x * (max - mid));
				}
				else
				{
					x *= 2;
					MapView.ScalingFactor = min + (x * (mid - min));
				}

				MapView.MapChanged();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void Preview_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			try
			{
				if (e.Url.Scheme == "power")
				{
					e.Cancel = true;

					string[] tokens = e.Url.LocalPath.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
					Guid token_id = new Guid(tokens[0]);

					CombatData cd = fEncounter.FindCombatData(token_id);
					if (cd != null)
					{
						EncounterSlot slot = fEncounter.FindSlot(cd);
						if (slot != null)
						{
							List<CreaturePower> powers = slot.Card.CreaturePowers;

							Guid power_id = new Guid(tokens[1]);
							CreaturePower power = slot.Card.FindPower(power_id);
							if (power == null)
								return;

							// If it's an attack power, roll it
							if (power.Attack != null)
								roll_attack(power);

							fLog.AddPowerEntry(cd.ID, power.Name, true);
							update_log();

							// If it's an encounter / daily power, ask to use it up
							if ((power.Action != null) && (!cd.UsedPowers.Contains(power.ID)))
							{
								if ((power.Action.Use == PowerUseType.Encounter) || (power.Action.Use == PowerUseType.Daily))
								{
									string usage = "per-encounter";
									if (power.Action.Use == PowerUseType.Daily)
										usage = "daily";

									string str = "This is a " + usage + " power. Do you want to mark it as expended?";
									if (MessageBox.Show(str, power.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
									{
										cd.UsedPowers.Add(power.ID);
										update_preview_panel();
									}
								}
							}
						}
					}
					else
					{
						// This is a trap attack
						foreach (Trap trap in fEncounter.Traps)
						{
							TrapAttack attack = trap.FindAttack(token_id);
							if (attack != null)
							{
								roll_check(attack.Attack.ToString(), attack.Attack.Bonus);
							}
						}
					}
				}

				if (e.Url.Scheme == "refresh")
				{
					e.Cancel = true;

					string[] tokens = e.Url.LocalPath.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
					Guid token_id = new Guid(tokens[0]);
					Guid power_id = new Guid(tokens[1]);

					CombatData cd = fEncounter.FindCombatData(token_id);

					string power_name = "";
					EncounterSlot slot = fEncounter.FindSlot(cd);
					if (slot != null)
					{
						ICreature c = Session.FindCreature(slot.Card.CreatureID, SearchType.Global);
						if (c != null)
						{
							foreach (CreaturePower cp in c.CreaturePowers)
							{
								if (cp.ID == power_id)
								{
									power_name = cp.Name;
									break;
								}
							}
						}
					}

					if (cd.UsedPowers.Contains(power_id))
					{
						cd.UsedPowers.Remove(power_id);
						fLog.AddPowerEntry(cd.ID, power_name, false);
					}
					else
					{
						cd.UsedPowers.Add(power_id);
						fLog.AddPowerEntry(cd.ID, power_name, true);
					}

					update_preview_panel();
					update_log();
				}

				if (e.Url.Scheme == "ability")
				{
					e.Cancel = true;

					int mod = int.Parse(e.Url.LocalPath);
					roll_check("Ability", mod);
				}

				if (e.Url.Scheme == "sc")
				{
					e.Cancel = true;

					if (e.Url.LocalPath == "reset")
					{
						// Reset
						SkillChallenge sc = SelectedChallenge;
						if (sc != null)
						{
							foreach (SkillChallengeData scd in sc.Skills)
							{
								scd.Results.Successes = 0;
								scd.Results.Fails = 0;

								update_list();
								update_preview_panel();
							}
						}
					}
				}

				if (e.Url.Scheme == "success")
				{
					e.Cancel = true;

					// Success
					SkillChallenge sc = SelectedChallenge;
					if (sc != null)
					{
						SkillChallengeData scd = sc.FindSkill(e.Url.LocalPath);
						scd.Results.Successes += 1;

						fLog.AddSkillEntry(fCurrentActor.ID, e.Url.LocalPath);
						fLog.AddSkillChallengeEntry(fCurrentActor.ID, true);

						update_list();
						update_preview_panel();
						update_log();
					}
				}

				if (e.Url.Scheme == "failure")
				{
					e.Cancel = true;

					// Failure
					SkillChallenge sc = SelectedChallenge;
					if (sc != null)
					{
						SkillChallengeData scd = sc.FindSkill(e.Url.LocalPath);
						scd.Results.Fails += 1;

						fLog.AddSkillEntry(fCurrentActor.ID, e.Url.LocalPath);
						fLog.AddSkillChallengeEntry(fCurrentActor.ID, false);

						update_list();
						update_preview_panel();
						update_log();
					}
				}

				if (e.Url.Scheme == "dmg")
				{
					e.Cancel = true;

					Guid id = new Guid(e.Url.LocalPath);

					List<IToken> tokens = new List<IToken>();

					Hero hero = Session.Project.FindHero(id);
					if (hero != null)
					{
						tokens.Add(hero);
					}

					CombatData cd = fEncounter.FindCombatData(id);
					if (cd != null)
					{
						EncounterSlot slot = fEncounter.FindSlot(cd);
						CreatureToken ct = new CreatureToken(slot.ID, cd);
						tokens.Add(ct);
					}

					if (tokens.Count != 0)
					{
						do_damage(tokens);
					}
				}

				if (e.Url.Scheme == "kill")
				{
					e.Cancel = true;

					Guid id = new Guid(e.Url.LocalPath);

					CombatData cd = fEncounter.FindCombatData(id);
					if (cd != null)
					{
						cd.Damage = 1;

						fLog.AddStateEntry(cd.ID, CreatureState.Defeated);

						update_list();
						update_preview_panel();
						update_log();
						update_maps();
					}
				}

				if (e.Url.Scheme == "revive")
				{
					e.Cancel = true;

					Guid id = new Guid(e.Url.LocalPath);

					CombatData cd = fEncounter.FindCombatData(id);
					if (cd != null)
					{
						cd.Damage = 0;

						fLog.AddStateEntry(cd.ID, CreatureState.Active);

						update_list();
						update_preview_panel();
						update_log();
						update_maps();
					}
				}

				if (e.Url.Scheme == "heal")
				{
					e.Cancel = true;

					Guid id = new Guid(e.Url.LocalPath);

					List<IToken> tokens = new List<IToken>();

					Hero hero = Session.Project.FindHero(id);
					if (hero != null)
					{
						tokens.Add(hero);
					}

					CombatData cd = fEncounter.FindCombatData(id);
					if (cd != null)
					{
						EncounterSlot slot = fEncounter.FindSlot(cd);
						CreatureToken ct = new CreatureToken(slot.ID, cd);
						tokens.Add(ct);
					}

					if (tokens.Count != 0)
					{
						do_heal(tokens);
					}
				}

				if (e.Url.Scheme == "init")
				{
					e.Cancel = true;

					Guid id = new Guid(e.Url.LocalPath);

					int bonus = int.MinValue;
					CombatData cd = fEncounter.FindCombatData(id);
					if (cd != null)
					{
						EncounterSlot slot = fEncounter.FindSlot(cd);
						if (slot != null)
							bonus = slot.Card.Initiative;
					}

					if (cd == null)
					{
						//if (fHeroData.ContainsKey(id))
						//    cd = fHeroData[id];

						Hero hero = Session.Project.FindHero(id);
						if (hero != null)
						{
							cd = hero.CombatData;
							bonus = hero.InitBonus;
						}
					}

					if (cd == null)
					{
						if (fTrapData.ContainsKey(id))
							cd = fTrapData[id];

						Trap trap = fEncounter.FindTrap(id);
						if (trap != null)
							bonus = trap.Initiative;
					}

					if ((cd != null) && (bonus != int.MinValue))
					{
						InitiativeForm dlg = new InitiativeForm(bonus, cd.Initiative);
						if (dlg.ShowDialog() == DialogResult.OK)
						{
							cd.Initiative = dlg.Score;

							InitiativePanel.InitiativeScores = get_initiatives();

							if (fCurrentActor != null)
								InitiativePanel.CurrentInitiative = fCurrentActor.Initiative;

							update_list();
							update_preview_panel();
							update_maps();
						}
					}
				}

				if (e.Url.Scheme == "effect")
				{
					e.Cancel = true;

					string[] str_tokens = e.Url.LocalPath.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
					if (str_tokens.Length == 2)
					{
						Guid id = new Guid(str_tokens[0]);
						int index = int.Parse(str_tokens[1]);

						// Find the CD we're working with
						CombatData cd = fEncounter.FindCombatData(id);
						if (cd == null)
						{
							Hero hero = Session.Project.FindHero(id);
							if (hero != null)
							{
								//cd = fHeroData[hero.ID];
								cd = hero.CombatData;
							}
						}

						if (cd != null)
						{
							if ((index >= 0) && (index <= cd.Conditions.Count - 1))
							{
								OngoingCondition oc = cd.Conditions[index];

								cd.Conditions.RemoveAt(index);
								fLog.AddEffectEntry(cd.ID, oc.ToString(fEncounter, false), false);

								update_list();
								update_preview_panel();
								update_log();
								update_maps();
							}
						}
					}
				}

				if (e.Url.Scheme == "addeffect")
				{
					Hero hero = Session.Project.FindHero(fCurrentActor.ID);
					int index = int.Parse(e.Url.LocalPath);
					OngoingCondition oc = hero.Effects[index];

					apply_effect(oc.Copy(), SelectedTokens, false);

					/*
					foreach (IToken token in SelectedTokens)
					{
						if (token == hero)
							continue;

						CombatData cd = null;

						if (token is CreatureToken)
						{
							CreatureToken ct = token as CreatureToken;
							cd = ct.Data;
						}

						if (token is Hero)
						{
							Hero h = token as Hero;
							cd = h.CombatData;
							//if (fHeroData.ContainsKey(h.ID))
							//    cd = fHeroData[h.ID];
						}

						if (cd != null)
						{
							apply_effect(oc.Copy(), SelectedTokens, false);
							fLog.AddEffectEntry(cd.ID, oc.ToString(fEncounter, false), true);

							cd.Conditions.Add(oc.Copy());
						}
					}
					*/

					update_list();
					update_preview_panel();
					update_log();
					update_maps();
				}

				if (e.Url.Scheme == "creatureinit")
				{
					e.Cancel = true;

					if (e.Url.LocalPath == "auto")
					{
						switch (Session.Preferences.InitiativeMode)
						{
							case InitiativeMode.ManualGroup:
								Session.Preferences.InitiativeMode = InitiativeMode.AutoGroup;
								break;
							case InitiativeMode.ManualIndividual:
								Session.Preferences.InitiativeMode = InitiativeMode.AutoIndividual;
								break;
						}
						update_preview_panel();
					}

					if (e.Url.LocalPath == "manual")
					{
						switch (Session.Preferences.InitiativeMode)
						{
							case InitiativeMode.AutoGroup:
								Session.Preferences.InitiativeMode = InitiativeMode.ManualGroup;
								break;
							case InitiativeMode.AutoIndividual:
								Session.Preferences.InitiativeMode = InitiativeMode.ManualIndividual;
								break;
						}
						update_preview_panel();
					}

					if (e.Url.LocalPath == "group")
					{
						switch (Session.Preferences.InitiativeMode)
						{
							case InitiativeMode.AutoIndividual:
								Session.Preferences.InitiativeMode = InitiativeMode.AutoGroup;
								break;
							case InitiativeMode.ManualIndividual:
								Session.Preferences.InitiativeMode = InitiativeMode.ManualGroup;
								break;
						}
						update_preview_panel();
					}

					if (e.Url.LocalPath == "individual")
					{
						switch (Session.Preferences.InitiativeMode)
						{
							case InitiativeMode.AutoGroup:
								Session.Preferences.InitiativeMode = InitiativeMode.AutoIndividual;
								break;
							case InitiativeMode.ManualGroup:
								Session.Preferences.InitiativeMode = InitiativeMode.ManualIndividual;
								break;
						}
						update_preview_panel();
					}
				}

				if (e.Url.Scheme == "heroinit")
				{
					e.Cancel = true;

					if (e.Url.LocalPath == "auto")
					{
						Session.Preferences.HeroInitiativeMode = InitiativeMode.AutoIndividual;
						update_preview_panel();
					}

					if (e.Url.LocalPath == "manual")
					{
						Session.Preferences.HeroInitiativeMode = InitiativeMode.ManualIndividual;
						update_preview_panel();
					}
				}

				if (e.Url.Scheme == "trapinit")
				{
					e.Cancel = true;

					if (e.Url.LocalPath == "auto")
					{
						Session.Preferences.TrapInitiativeMode = InitiativeMode.AutoIndividual;
						update_preview_panel();
					}

					if (e.Url.LocalPath == "manual")
					{
						Session.Preferences.TrapInitiativeMode = InitiativeMode.ManualIndividual;
						update_preview_panel();
					}
				}

				if (e.Url.Scheme == "combat")
				{
					e.Cancel = true;

					if (e.Url.LocalPath == "hp")
					{
						GroupHealthForm dlg = new GroupHealthForm();
						dlg.ShowDialog();

						update_list();
						update_preview_panel();
						update_maps();
					}

					if (e.Url.LocalPath == "rename")
					{
						List<CombatData> list = new List<CombatData>();

						foreach (EncounterSlot slot in fEncounter.AllSlots)
							list.AddRange(slot.CombatData);

						// Enter display names for these combatants
						DisplayNameForm dlg = new DisplayNameForm(list, fEncounter);
						dlg.ShowDialog();

						update_list();
						update_preview_panel();
						update_maps();
					}

					if (e.Url.LocalPath == "start")
					{
						start_combat();
					}
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void InitiativePanel_InitiativeChanged(object sender, EventArgs e)
		{
			try
			{
				Guid previous_actor = fCurrentActor.ID;

				fCurrentActor = null;
				fCurrentActor = get_next_actor(null);

				if (fCurrentActor.ID != previous_actor)
					fLog.AddStartTurnEntry(fCurrentActor.ID);

				update_list();
				update_log();
				update_preview_panel();
				update_maps();

				highlight_current_actor();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void CombatantsEffects_Click(object sender, EventArgs e)
		{
			EffectListForm dlg = new EffectListForm(fEncounter, fCurrentActor, fCurrentRound);
			dlg.ShowDialog();

			update_list();
			update_preview_panel();
			update_maps();
		}

		private void CombatantsLinks_Click(object sender, EventArgs e)
		{
			TokenLinkListForm dlg = new TokenLinkListForm(MapView.TokenLinks);
			dlg.ShowDialog();

			update_list();
			update_preview_panel();
			update_maps();
		}

		void add_in_command_clicked(object sender, EventArgs e)
		{
			try
			{
				ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
				ICommand command = tsmi.Tag as ICommand;

				command.Execute();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ListDelay_Click(object sender, EventArgs e)
		{
			set_delay(SelectedTokens);
		}

		private void MapDelay_Click(object sender, EventArgs e)
		{
			set_delay(MapView.SelectedTokens);
		}

		private void OptionsMapRight_Click(object sender, EventArgs e)
		{
			if (MapSplitter.Orientation == System.Windows.Forms.Orientation.Vertical)
				return;

			bool one_col = (ListSplitter.Orientation == System.Windows.Forms.Orientation.Horizontal);

			MapSplitter.Orientation = System.Windows.Forms.Orientation.Vertical;
			MapSplitter.SplitterDistance = (one_col ? 355 : 700);
			MapSplitter.FixedPanel = FixedPanel.Panel1;

			Session.Preferences.CombatMapRight = true;
		}

		private void OptionsMapBelow_Click(object sender, EventArgs e)
		{
			if (MapSplitter.Orientation == System.Windows.Forms.Orientation.Horizontal)
				return;

			MapSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
			MapSplitter.SplitterDistance = MapSplitter.Height / 2;
			MapSplitter.FixedPanel = FixedPanel.None;

			Session.Preferences.CombatMapRight = false;
		}

		private void OptionsLandscape_Click(object sender, EventArgs e)
		{
			SuspendLayout();

			OneColumn_Click(sender, e);
			OptionsMapRight_Click(sender, e);

			ResumeLayout();
		}

		private void OptionsPortrait_Click(object sender, EventArgs e)
		{
			SuspendLayout();

			TwoColumns_Click(sender, e);
			OptionsMapBelow_Click(sender, e);

			ResumeLayout();
		}

		private void MapDrawing_Click(object sender, EventArgs e)
		{
			MapView.AllowDrawing = !MapView.AllowDrawing;

			if (PlayerMap != null)
				PlayerMap.AllowDrawing = MapView.AllowDrawing;
		}

		private void MapClearDrawings_Click(object sender, EventArgs e)
		{
			MapView.Sketches.Clear();
			MapView.Invalidate();

			if (PlayerMap != null)
			{
				PlayerMap.Sketches.Clear();
				PlayerMap.Invalidate();
			}
		}

		private void MapView_SketchCreated(object sender, MapSketchEventArgs e)
		{
			if (PlayerMap != null)
			{
				PlayerMap.Sketches.Add(e.Sketch);
				PlayerMap.Invalidate();
			}
		}

		private void MapContextOverlay_Click(object sender, EventArgs e)
		{
			CustomToken overlay = new CustomToken();
			overlay.Name = "New Overlay";
			overlay.Type = CustomTokenType.Overlay;

			if (MapView.SelectedTokens.Count == 1)
			{
				IToken token = MapView.SelectedTokens[0];

				CreatureToken creature = token as CreatureToken;
				if (creature != null)
				{
					overlay.Name = "Zone: " + creature.Data.DisplayName;
					overlay.CreatureID = creature.Data.ID;
					overlay.Colour = Color.Red;
				}

				Hero hero = token as Hero;
				if (hero != null)
				{
					overlay.Name = hero.Name + " zone";
					overlay.CreatureID = hero.ID;
					overlay.Colour = Color.DarkGreen;
				}
			}

			CustomOverlayForm dlg = new CustomOverlayForm(overlay);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				overlay = dlg.Token;

				if (overlay.CreatureID == Guid.Empty)
				{
					Point menu_pt = new Point(MapContext.Left, MapContext.Top);
					Point mouse = MapView.PointToClient(menu_pt);
					Point square = MapView.LayoutData.GetSquareAtPoint(mouse);

					int x = square.X - ((overlay.OverlaySize.Width - 1) / 2);
					int y = square.Y - ((overlay.OverlaySize.Height - 1) / 2);
					overlay.Data.Location = new Point(x, y);
				}

				fEncounter.CustomTokens.Add(overlay);

				update_list();
				update_maps();
			}
		}

		private void MapHeal_Click(object sender, EventArgs e)
		{
			try
			{
				do_heal(MapView.SelectedTokens);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ListHeal_Click(object sender, EventArgs e)
		{
			try
			{
				do_heal(SelectedTokens);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ListCreateCopy_Click(object sender, EventArgs e)
		{
			copy_custom_token();
		}

		private void MapCreateCopy_Click(object sender, EventArgs e)
		{
			copy_custom_token();
		}

		private void MapSetPicture_Click(object sender, EventArgs e)
		{
			if (MapView.SelectedTokens.Count != 1)
				return;

			CreatureToken ct = MapView.SelectedTokens[0] as CreatureToken;
			if (ct != null)
			{
				EncounterSlot slot = fEncounter.FindSlot(ct.SlotID);

				ICreature creature = Session.FindCreature(slot.Card.CreatureID, SearchType.Global);
				if (creature != null)
				{
					OpenFileDialog dlg = new OpenFileDialog();
					dlg.Filter = Program.ImageFilter;
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						creature.Image = Image.FromFile(dlg.FileName);
						Program.SetResolution(creature.Image);

						if (creature is Creature)
						{
							Creature c = creature as Creature;
							Library lib = Session.FindLibrary(c);
							if (lib != null)
							{
								string filename = Session.GetLibraryFilename(lib);
								Serialisation<Library>.Save(filename, lib, SerialisationMode.Binary);
							}
						}
						else
						{
							Session.Modified = true;
						}

						update_list();
					}
				}
			}

			Hero hero = MapView.SelectedTokens[0] as Hero;
			if (hero != null)
			{
				OpenFileDialog dlg = new OpenFileDialog();
				dlg.Filter = Program.ImageFilter;
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					hero.Portrait = Image.FromFile(dlg.FileName);
					Program.SetResolution(hero.Portrait);

					Session.Modified = true;

					update_list();
				}
			}
		}

		private void PlayerViewNoMapShowInitiativeList_Click(object sender, EventArgs e)
		{
			try
			{
				show_player_view(false, PlayerInitiative == null);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void PlayerViewNoMapShowLabels_Click(object sender, EventArgs e)
		{
			Session.Preferences.PlayerViewCreatureLabels = !Session.Preferences.PlayerViewCreatureLabels;

			if (PlayerInitiative != null)
			{
				PlayerInitiative.DocumentText = InitiativeView();
			}
		}

		private void TemplateList_ItemDrag(object sender, ItemDragEventArgs e)
		{
			CustomToken ct = TemplateList.SelectedItems[0].Tag as CustomToken;
			ct = ct.Copy();

			if (ct.Data.Location == CombatData.NoPoint)
			{
				if (DoDragDrop(ct, DragDropEffects.Move) == DragDropEffects.Move)
				{
					fEncounter.CustomTokens.Add(ct);

					update_list();
					update_preview_panel();
					update_maps();
				}
			}
		}

		private void OptionsShowInit_Click(object sender, EventArgs e)
		{
			InitiativePanel.Visible = !InitiativePanel.Visible;
		}

		private void ListSplitter_SplitterMoved(object sender, SplitterEventArgs e)
		{
			list_splitter_changed();
		}

		private void ListSplitter_Resize(object sender, EventArgs e)
		{
			list_splitter_changed();
		}

		private void MapView_MouseZoomed(object sender, MouseEventArgs e)
		{
			ZoomGauge.Visible = true;
			ZoomGauge.Value -= Math.Sign(e.Delta);
			ZoomGauge_Scroll(sender, e);
		}

		private void MapView_CancelledScrolling(object sender, EventArgs e)
		{
			cancelled_scrolling();
		}

		#region Draw combat list

		private void CombatList_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			e.DrawDefault = true;
		}

		private void CombatList_DrawItem(object sender, DrawListViewItemEventArgs e)
		{
		}

		private void CombatList_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
		{
			e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

			Brush text = (e.Item.Selected) ? SystemBrushes.HighlightText : new SolidBrush(e.Item.ForeColor);
			Brush bg = (e.Item.Selected) ? SystemBrushes.Highlight : new SolidBrush(e.Item.BackColor);

			StringFormat format = (e.Header.TextAlign == HorizontalAlignment.Left) ? fLeft : fRight;

			e.Graphics.FillRectangle(bg, e.Bounds);

			if (e.ColumnIndex == 0)
			{
				CreatureState state = CreatureState.Defeated;
				int max_value = 0;
				int current_value = 0;
				int temp_value = 0;

				if (e.Item.Tag is CreatureToken)
				{
					CreatureToken ct = e.Item.Tag as CreatureToken;
					CombatData cd = ct.Data;

					EncounterSlot slot = fEncounter.FindSlot(cd);

					state = slot.GetState(cd);
					max_value = slot.Card.HP;
					current_value = max_value - cd.Damage;
					temp_value = cd.TempHP;
				}

				if (e.Item.Tag is Hero)
				{
					Hero hero = e.Item.Tag as Hero;
					//CombatData cd = fHeroData[hero.ID];
					CombatData cd = hero.CombatData;

					state = CreatureState.Active;
					max_value = hero.HP;
					current_value = max_value - cd.Damage;
					temp_value = cd.TempHP;
				}

				if (e.Item.Tag is SkillChallenge)
				{
					SkillChallenge sc = e.Item.Tag as SkillChallenge;

					if (sc.Results.Fails >= 3)
					{
						state = CreatureState.Bloodied;
						current_value = 3;
						max_value = 3;
					}
					else if (sc.Results.Successes >= sc.Successes)
					{
						state = CreatureState.Defeated;
						current_value = sc.Successes;
						max_value = sc.Successes;
					}
					else
					{
						state = CreatureState.Active;
						max_value = sc.Successes;
						current_value = sc.Successes - sc.Results.Successes;
					}
				}

				if (current_value < 0)
					current_value = 0;
				if (current_value > max_value)
					current_value = max_value;

				if ((max_value > 1) && (state != CreatureState.Defeated))
				{
					int width = e.Bounds.Width - 1;
					int height = e.Bounds.Height / 4;

					Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Bottom - height, width, height);

					Color c = (state == CreatureState.Bloodied) ? Color.Red : Color.DarkGray;
					Brush b = new LinearGradientBrush(rect, Color.White, Color.FromArgb(10, c), LinearGradientMode.Vertical);
					e.Graphics.FillRectangle(b, rect);
					e.Graphics.DrawRectangle(Pens.DarkGray, rect);

					int hp_width = (width * current_value) / (max_value + temp_value);
					Rectangle hp_rect = new Rectangle(rect.X, rect.Y, hp_width, height);

					Brush hp_b = new LinearGradientBrush(hp_rect, Color.Transparent, c, LinearGradientMode.Vertical);

					e.Graphics.FillRectangle(hp_b, hp_rect);

					if (temp_value > 0)
					{
						int temp_width = (width * temp_value) / (max_value + temp_value);
						Rectangle temp_rect = new Rectangle(hp_rect.Right, hp_rect.Y, temp_width, height);

						Brush temp_b = new LinearGradientBrush(temp_rect, Color.Transparent, Color.Blue, LinearGradientMode.Vertical);

						e.Graphics.FillRectangle(temp_b, temp_rect);
					}
				}
				else
				{
					e.Graphics.DrawLine(Pens.DarkGray, e.Bounds.Left, e.Bounds.Bottom, e.Bounds.Right, e.Bounds.Bottom);
				}
			}

			e.Graphics.DrawString(e.SubItem.Text, e.Item.Font, text, e.Bounds, format);
		}

		#endregion

		#region Tools menu

		private void ToolsColumnsInit_Click(object sender, EventArgs e)
		{
			InitHdr.Width = (InitHdr.Width > 0) ? 0 : 60;
			Session.Preferences.CombatColumnInitiative = (InitHdr.Width > 0);
		}

		private void ToolsColumnsHP_Click(object sender, EventArgs e)
		{
			HPHdr.Width = (HPHdr.Width > 0) ? 0 : 60;
			Session.Preferences.CombatColumnHP = (HPHdr.Width > 0);
		}

		private void ToolsColumnsDefences_Click(object sender, EventArgs e)
		{
			DefHdr.Width = (DefHdr.Width > 0) ? 0 : 200;
			Session.Preferences.CombatColumnDefences = (DefHdr.Width > 0);
		}

		private void ToolsColumnsConditions_Click(object sender, EventArgs e)
		{
			EffectsHdr.Width = (EffectsHdr.Width > 0) ? 0 : 175;
			Session.Preferences.CombatColumnEffects = (EffectsHdr.Width > 0);
		}

		#endregion

		#region List context menu

		private void ListContext_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				bool mob = false;
				bool delayed = false;
				bool on_map = false;
				bool custom = false;

				if (SelectedTokens.Count != 0)
				{
					mob = true;
					delayed = true;
					on_map = true;

					foreach (IToken token in SelectedTokens)
					{
						bool token_is_mob = ((token is CreatureToken) || (token is Hero));
						if (!token_is_mob)
							mob = false;

						if (token is CreatureToken)
						{
							CreatureToken ct = token as CreatureToken;

							if (!ct.Data.Delaying)
								delayed = false;

							if ((MapView.Map != null) && (ct.Data.Location == CombatData.NoPoint))
								on_map = false;
						}

						if (token is Hero)
						{
							Hero hero = token as Hero;
							//CombatData cd = fHeroData[hero.ID];
							CombatData cd = hero.CombatData;

							if (!cd.Delaying)
								delayed = false;

							if ((MapView.Map != null) && (cd.Location == CombatData.NoPoint))
								on_map = false;
						}

						if (token is CustomToken)
						{
							CustomToken ct = token as CustomToken;

							custom = true;

							if ((MapView.Map != null) && (ct.Data.Location == CombatData.NoPoint))
								on_map = false;

							if (ct.CreatureID != Guid.Empty)
								on_map = false;
						}
					}
				}

				bool non_hero = false;
				foreach (IToken token in SelectedTokens)
				{
					if (!(token is Hero))
						non_hero = true;
				}

				ListDetails.Enabled = (SelectedTokens.Count == 1);
				ListDamage.Enabled = mob;
				ListHeal.Enabled = mob;
				ListCondition.Enabled = mob;
				ListRemoveEffect.Enabled = (SelectedTokens.Count == 1);
				ListRemoveMap.Enabled = on_map;
				ListRemoveCombat.Enabled = (SelectedTokens.Count != 0);
				ListCreateCopy.Enabled = custom;
				ListVisible.Enabled = non_hero;

				if (ListVisible.Enabled && (SelectedTokens.Count == 1))
				{
					if (SelectedTokens[0] is CreatureToken)
					{
						CreatureToken ct = SelectedTokens[0] as CreatureToken;
						ListVisible.Checked = ct.Data.Visible;
					}

					if (SelectedTokens[0] is CustomToken)
					{
						CustomToken ct = SelectedTokens[0] as CustomToken;
						ListVisible.Checked = ct.Data.Visible;
					}
				}
				else
				{
					ListVisible.Checked = false;
				}

				ListDelay.Enabled = mob;
				ListDelay.Checked = delayed;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ListDetails_Click(object sender, EventArgs e)
		{
			try
			{
				edit_token(SelectedTokens[0]);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ListDamage_Click(object sender, EventArgs e)
		{
			try
			{
				do_damage(SelectedTokens);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ListRemoveMap_Click(object sender, EventArgs e)
		{
			remove_from_map(SelectedTokens);
		}

		private void ListRemoveCombat_Click(object sender, EventArgs e)
		{
			remove_from_combat(SelectedTokens);
		}

		private void ListVisible_Click(object sender, EventArgs e)
		{
			toggle_visibility(SelectedTokens);
		}

		#endregion

		#region Map context menu

		private void MapContext_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				bool mob = false;
				bool delayed = false;
				bool on_map = false;
				bool custom = false;

				if (MapView.SelectedTokens.Count != 0)
				{
					mob = true;
					delayed = true;
					on_map = true;

					foreach (IToken token in MapView.SelectedTokens)
					{
						bool token_is_mob = ((token is CreatureToken) || (token is Hero));
						if (!token_is_mob)
							mob = false;

						if (token is CreatureToken)
						{
							CreatureToken ct = token as CreatureToken;

							if (!ct.Data.Delaying)
								delayed = false;

							if (ct.Data.Location == CombatData.NoPoint)
								on_map = false;
						}

						if (token is Hero)
						{
							Hero hero = token as Hero;
							//CombatData cd = fHeroData[hero.ID];
							CombatData cd = hero.CombatData;

							if (!cd.Delaying)
								delayed = false;

							if (cd.Location == CombatData.NoPoint)
								on_map = false;
						}

						if (token is CustomToken)
						{
							CustomToken ct = token as CustomToken;

							custom = true;

							if (ct.Data.Location == CombatData.NoPoint)
								on_map = false;
						}
					}
				}

				bool non_hero = false;
				foreach (IToken token in MapView.SelectedTokens)
				{
					if (!(token is Hero))
						non_hero = true;
				}

				MapDetails.Enabled = (MapView.SelectedTokens.Count == 1);
				MapDamage.Enabled = mob;
				MapHeal.Enabled = mob;
				MapAddEffect.Enabled = mob;
				MapRemoveEffect.Enabled = mob;
				MapRemoveMap.Enabled = on_map;
				MapRemoveCombat.Enabled = (MapView.SelectedTokens.Count != 0);
				MapCreateCopy.Enabled = custom;
				MapVisible.Enabled = non_hero;

				if (MapVisible.Enabled && (MapView.SelectedTokens.Count == 1))
				{
					if (MapView.SelectedTokens[0] is CreatureToken)
					{
						CreatureToken ct = MapView.SelectedTokens[0] as CreatureToken;
						MapVisible.Checked = ct.Data.Visible;
					}

					if (MapView.SelectedTokens[0] is CustomToken)
					{
						CustomToken ct = MapView.SelectedTokens[0] as CustomToken;
						MapVisible.Checked = ct.Data.Visible;
					}
				}
				else
				{
					MapVisible.Checked = false;
				}

				MapDelay.Enabled = mob;
				MapDelay.Checked = delayed;

				MapContextDrawing.Checked = MapView.AllowDrawing;
				MapContextClearDrawings.Enabled = (MapView.Sketches.Count != 0);

				MapContextLOS.Checked = MapView.LineOfSight;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void MapDetails_Click(object sender, EventArgs e)
		{
			try
			{
				if (MapView.SelectedTokens.Count == 0)
					return;

				edit_token(MapView.SelectedTokens[0]);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void MapDamage_Click(object sender, EventArgs e)
		{
			try
			{
				do_damage(MapView.SelectedTokens);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void MapRemoveMap_Click(object sender, EventArgs e)
		{
			remove_from_map(MapView.SelectedTokens);
		}

		private void MapRemoveCombat_Click(object sender, EventArgs e)
		{
			remove_from_combat(MapView.SelectedTokens);
		}

		private void MapVisible_Click(object sender, EventArgs e)
		{
			toggle_visibility(MapView.SelectedTokens);
		}

		#endregion

		#region Drop-down opening

		private void CombatantsBtn_DropDownOpening(object sender, EventArgs e)
		{
			CombatantsAddToken.Visible = (fEncounter.MapID != Guid.Empty);
			CombatantsAddOverlay.Visible = (fEncounter.MapID != Guid.Empty);
			CombatantsRemove.Enabled = (SelectedTokens.Count != 0);

			CombatantsWaves.DropDownItems.Clear();

			foreach (EncounterWave ew in fEncounter.Waves)
			{
				if (ew.Count == 0)
					continue;

				ToolStripMenuItem tsmi = new ToolStripMenuItem(ew.Name);
				tsmi.Checked = ew.Active;
				tsmi.Tag = ew;
				tsmi.Click += new EventHandler(wave_activated);
				CombatantsWaves.DropDownItems.Add(tsmi);
			}
			if (CombatantsWaves.DropDownItems.Count == 0)
			{
				ToolStripMenuItem tsmi = new ToolStripMenuItem("(none set)");
				tsmi.Enabled = false;
				CombatantsWaves.DropDownItems.Add(tsmi);
			}
		}

		void wave_activated(object sender, EventArgs e)
		{
			ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
			EncounterWave ew = tsmi.Tag as EncounterWave;
			ew.Active = !ew.Active;

			update_list();
			update_maps();
			update_statusbar();
		}

		private void MapMenu_DropDownOpening(object sender, EventArgs e)
		{
			ShowMap.Checked = !MapSplitter.Panel2Collapsed;
			MapLOS.Checked = MapView.LineOfSight;
			MapGrid.Checked = (MapView.ShowGrid != MapGridMode.None);
			MapGridLabels.Checked = MapView.ShowGridLabels;
			MapHealth.Checked = MapView.ShowHealthBars;
			MapConditions.Checked = MapView.ShowConditions;
			MapPictureTokens.Checked = MapView.ShowPictureTokens;
			MapNavigate.Checked = MapView.AllowScrolling;

			MapFogAllCreatures.Checked = (MapView.ShowCreatures == CreatureViewMode.All);
			MapFogVisibleCreatures.Checked = (MapView.ShowCreatures == CreatureViewMode.Visible);
			MapFogHideCreatures.Checked = (MapView.ShowCreatures == CreatureViewMode.None);

			MapDrawing.Checked = MapView.AllowDrawing;
			MapClearDrawings.Enabled = (MapView.Sketches.Count != 0);
		}

		private void PlayerViewMapMenu_DropDownOpening(object sender, EventArgs e)
		{
			PlayerViewMap.Checked = (PlayerMap != null);
			PlayerViewInitList.Checked = (PlayerInitiative != null);

			PlayerViewLOS.Enabled = (PlayerMap != null);
			PlayerViewLOS.Checked = ((PlayerMap != null) && PlayerMap.LineOfSight);
			PlayerViewGrid.Enabled = (PlayerMap != null);
			PlayerViewGrid.Checked = ((PlayerMap != null) && (PlayerMap.ShowGrid != MapGridMode.None));
			PlayerViewGridLabels.Enabled = (PlayerMap != null);
			PlayerViewGridLabels.Checked = ((PlayerMap != null) && (PlayerMap.ShowGridLabels));
			PlayerHealth.Enabled = (PlayerMap != null);
			PlayerHealth.Checked = ((PlayerMap != null) && (PlayerMap.ShowHealthBars));
			PlayerConditions.Enabled = (PlayerMap != null);
			PlayerConditions.Checked = ((PlayerMap != null) && (PlayerMap.ShowConditions));
			PlayerPictureTokens.Enabled = (PlayerMap != null);
			PlayerPictureTokens.Checked = ((PlayerMap != null) && (PlayerMap.ShowPictureTokens));
			PlayerLabels.Enabled = ((PlayerMap != null) || (PlayerInitiative != null));
			PlayerLabels.Checked = (((PlayerMap != null) && (PlayerMap.ShowCreatureLabels)) || ((PlayerInitiative != null) && (Session.Preferences.PlayerViewCreatureLabels)));

			PlayerViewFog.Enabled = (PlayerMap != null);
			PlayerFogAll.Checked = ((PlayerMap != null) && (PlayerMap.ShowCreatures == CreatureViewMode.All));
			PlayerFogVisible.Checked = ((PlayerMap != null) && (PlayerMap.ShowCreatures == CreatureViewMode.Visible));
			PlayerFogNone.Checked = ((PlayerMap != null) && (PlayerMap.ShowCreatures == CreatureViewMode.None));
		}

		private void ToolsMenu_DopDownOpening(object sender, EventArgs e)
		{
			ToolsAddIns.DropDownItems.Clear();
			foreach (IAddIn addin in Session.AddIns)
			{
				ToolStripMenuItem addin_item = new ToolStripMenuItem(addin.Name);
				addin_item.ToolTipText = TextHelper.Wrap(addin.Description);
				addin_item.Tag = addin;

				ToolsAddIns.DropDownItems.Add(addin_item);

				foreach (ICommand command in addin.CombatCommands)
				{
					ToolStripMenuItem command_item = new ToolStripMenuItem(command.Name);
					command_item.ToolTipText = TextHelper.Wrap(command.Description);
					command_item.Enabled = command.Available;
					command_item.Checked = command.Active;
					command_item.Click += new EventHandler(add_in_command_clicked);
					command_item.Tag = command;

					addin_item.DropDownItems.Add(command_item);
				}

				if (addin.Commands.Count == 0)
				{
					ToolStripItem command_item = ToolsAddIns.DropDownItems.Add("(no commands)");
					command_item.Enabled = false;
				}
			}

			if (Session.AddIns.Count == 0)
			{
				ToolStripItem addin_item = ToolsAddIns.DropDownItems.Add("(none)");
				addin_item.Enabled = false;
			}
		}

		private void OptionsMenu_DropDownOpening(object sender, EventArgs e)
		{
			bool show_map = !MapSplitter.Panel2Collapsed;

			OptionsShowInit.Checked = InitiativePanel.Visible;

			OneColumn.Checked = (ListSplitter.Orientation == System.Windows.Forms.Orientation.Horizontal);
			TwoColumns.Checked = (ListSplitter.Orientation == System.Windows.Forms.Orientation.Vertical);
			OneColumn.Enabled = show_map;
			TwoColumns.Enabled = show_map;

			MapRight.Enabled = show_map;
			MapBelow.Enabled = show_map;
			MapRight.Checked = (MapSplitter.Orientation == System.Windows.Forms.Orientation.Vertical);
			MapBelow.Checked = (MapSplitter.Orientation == System.Windows.Forms.Orientation.Horizontal);

			OptionsLandscape.Enabled = show_map;
			OptionsPortrait.Enabled = show_map;
			OptionsLandscape.Checked = (OneColumn.Checked && MapRight.Checked);
			OptionsPortrait.Checked = (TwoColumns.Checked && MapBelow.Checked);

			ToolsAutoRemove.Checked = Session.Preferences.CreatureAutoRemove;
		}

		private void EffectMenu_DropDownOpening(object sender, EventArgs e)
		{
			update_effects_list(EffectMenu, true);
		}

		private void ListCondition_DropDownOpening(object sender, EventArgs e)
		{
			update_effects_list(ListCondition, true);
		}

		private void MapCondition_DropDownOpening(object sender, EventArgs e)
		{
			update_effects_list(MapAddEffect, false);
		}

		private void ListRemoveEffect_DropDownOpening(object sender, EventArgs e)
		{
			update_remove_effect_list(ListRemoveEffect, true);
		}

		private void MapRemoveEffect_DropDownOpening(object sender, EventArgs e)
		{
			update_remove_effect_list(MapRemoveEffect, false);
		}

		private void PlayerViewNoMapMenu_DropDownOpening(object sender, EventArgs e)
		{
			PlayerViewNoMapShowInitiativeList.Checked = (PlayerInitiative != null);

			PlayerViewNoMapShowLabels.Enabled = (PlayerInitiative != null);
			PlayerViewNoMapShowLabels.Checked = Session.Preferences.PlayerViewCreatureLabels;
		}

		private void ToolsColumns_DropDownOpening(object sender, EventArgs e)
		{
			ToolsColumnsInit.Checked = InitHdr.Width > 0;
			ToolsColumnsHP.Checked = HPHdr.Width > 0;
			ToolsColumnsDefences.Checked = DefHdr.Width > 0;
			ToolsColumnsConditions.Checked = EffectsHdr.Width > 0;
		}

		#endregion

		#region Form buttons

		private void CloseBtn_Click(object sender, EventArgs e)
		{
			fPromptOnClose = false;
			Close();
		}

		private void PauseBtn_Click(object sender, EventArgs e)
		{
			try
			{
				// Ask to save encounter

				string msg = "Would you like to be able to resume this encounter later?";
				msg += Environment.NewLine;
				msg += Environment.NewLine;
				msg += "If you click Yes, the encounter can be restarted by selecting Paused Encounters from the Project menu.";

				if (MessageBox.Show(msg, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					CombatState cs = new CombatState();

					fLog.AddPauseEntry();

					Dictionary<Guid, CombatData> hero_data = new Dictionary<Guid, CombatData>();
					foreach (Hero hero in Session.Project.Heroes)
						hero_data[hero.ID] = hero.CombatData;

					cs.Encounter = fEncounter;
					cs.CurrentRound = fCurrentRound;
					cs.PartyLevel = fPartyLevel;
					cs.HeroData = hero_data;
					cs.TrapData = fTrapData;
					cs.TokenLinks = MapView.TokenLinks;
					cs.RemovedCreatureXP = fRemovedCreatureXP;
					cs.Viewpoint = MapView.Viewpoint;
					cs.Log = fLog;

					if (fCurrentActor != null)
						cs.CurrentActor = fCurrentActor.ID;

					foreach (MapSketch sketch in MapView.Sketches)
						cs.Sketches.Add(sketch.Copy());

					foreach (OngoingCondition oc in fEffects)
						cs.QuickEffects.Add(oc.Copy());

					Session.Project.SavedCombats.Add(cs);
					Session.Modified = true;

					foreach (Form form in Application.OpenForms)
					{
						PausedCombatListForm dlg = form as PausedCombatListForm;
						if (dlg != null)
							dlg.UpdateEncounters();
					}

					fPromptOnClose = false;
					Close();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void InfoBtn_Click(object sender, EventArgs e)
		{
			InfoForm dlg = new InfoForm();
			dlg.Level = fPartyLevel;
			dlg.ShowDialog();
		}

		private void DieRollerBtn_Click(object sender, EventArgs e)
		{
			DieRollerForm dlg = new DieRollerForm();
			dlg.ShowDialog();
		}

		private void ReportBtn_Click(object sender, EventArgs e)
		{
			EncounterReportForm dlg = new EncounterReportForm(fLog, fEncounter);
			dlg.ShowDialog();
		}

		#endregion

		#endregion

		#region Helper methods

		void start_combat()
		{
			roll_initiative();

			// Set the first actor
			List<int> scores = get_initiatives();
			if (scores.Count != 0)
			{
				int max_init = scores[0];
				List<CombatData> combatants = get_combatants(max_init, false);
				if (combatants.Count != 0)
					fCurrentActor = combatants[0];

				if (fCurrentActor != null)
				{
					fCombatStarted = true;

					InitiativePanel.CurrentInitiative = fCurrentActor.Initiative;
					select_current_actor();

					update_list();
					update_maps();
					update_statusbar();
					update_preview_panel();

					highlight_current_actor();

					fLog.Active = true;
					fLog.AddStartRoundEntry(fCurrentRound);
					fLog.AddStartTurnEntry(fCurrentActor.ID);
					update_log();
				}
			}
		}

		void roll_initiative()
		{
			List<Pair<List<CombatData>, int>> to_roll = new List<Pair<List<CombatData>, int>>();
			Dictionary<string, List<CombatData>> to_enter = new Dictionary<string, List<CombatData>>();

			foreach (Hero hero in Session.Project.Heroes)
			{
				if (hero.CombatData.Initiative != int.MinValue)
					continue;

				switch (Session.Preferences.HeroInitiativeMode)
				{
					case InitiativeMode.AutoIndividual:
						List<CombatData> list = new List<CombatData>();
						list.Add(hero.CombatData);
						to_roll.Add(new Pair<List<CombatData>, int>(list, hero.InitBonus));
						break;
					case InitiativeMode.ManualIndividual:
						to_enter[hero.Name] = new List<CombatData>();
						to_enter[hero.Name].Add(hero.CombatData);
						break;
				}
			}

			foreach (EncounterSlot slot in fEncounter.Slots)
			{
				switch (Session.Preferences.InitiativeMode)
				{
					case InitiativeMode.AutoGroup:
						{
							List<CombatData> list = new List<CombatData>();
							foreach (CombatData cd in slot.CombatData)
							{
								if (cd.Initiative != int.MinValue)
									continue;

								list.Add(cd);
							}

							if (list.Count != 0)
								to_roll.Add(new Pair<List<CombatData>, int>(list, slot.Card.Initiative));
						}
						break;
					case InitiativeMode.AutoIndividual:
						foreach (CombatData cd in slot.CombatData)
						{
							if (cd.Initiative != int.MinValue)
								continue;

							List<CombatData> list = new List<CombatData>();
							list.Add(cd);
							to_roll.Add(new Pair<List<CombatData>, int>(list, slot.Card.Initiative));
						}
						break;
					case InitiativeMode.ManualGroup:
						{
							List<CombatData> list = new List<CombatData>();
							foreach (CombatData cd in slot.CombatData)
							{
								if (cd.Initiative != int.MinValue)
									continue;

								list.Add(cd);
							}

							if (list.Count != 0)
								to_enter[slot.Card.Title] = list;
						}
						break;
					case InitiativeMode.ManualIndividual:
						foreach (CombatData cd in slot.CombatData)
						{
							if (cd.Initiative != int.MinValue)
								continue;

							to_enter[cd.DisplayName] = new List<CombatData>();
							to_enter[cd.DisplayName].Add(cd);
						}
						break;
				}
			}

			foreach (Trap trap in fEncounter.Traps)
			{
				bool has_init = (trap.Initiative != int.MinValue);
				if (!has_init)
					continue;

				CombatData cd = fTrapData[trap.ID];
				if (cd.Initiative != int.MinValue)
					continue;

				switch (Session.Preferences.TrapInitiativeMode)
				{
					case InitiativeMode.AutoIndividual:
						List<CombatData> list = new List<CombatData>();
						list.Add(cd);
						to_roll.Add(new Pair<List<CombatData>, int>(list, trap.Initiative));
						break;
					case InitiativeMode.ManualIndividual:
						to_enter[trap.Name] = new List<CombatData>();
						to_enter[trap.Name].Add(cd);
						break;
				}
			}

			// Roll
			foreach (Pair<List<CombatData>, int> item in to_roll)
			{
				int roll = Session.Dice(1, 20) + item.Second;
				foreach (CombatData cd in item.First)
					cd.Initiative = roll;
			}

			// Enter
			if (to_enter.Count != 0)
			{
				GroupInitiativeForm dlg = new GroupInitiativeForm(to_enter, fEncounter);
				dlg.ShowDialog();
			}

			InitiativePanel.InitiativeScores = get_initiatives();
		}

		void select_current_actor()
		{
			foreach (ListViewItem lvi in CombatList.Items)
				lvi.Selected = false;

			ListViewItem current_lvi = get_combatant(fCurrentActor.ID);
			if (current_lvi != null)
				current_lvi.Selected = true;
		}

		void set_map(List<TokenLink> token_links, Rectangle viewpoint, List<MapSketch> sketches)
		{
			Map m = Session.Project.FindTacticalMap(fEncounter.MapID);
			MapView.Map = m;
			//MapView.HeroData = fHeroData;

			if (token_links != null)
			{
				MapView.TokenLinks = token_links;

				// Update token links to point to the new CreatureToken items
				foreach (TokenLink link in MapView.TokenLinks)
				{
					foreach (IToken token in link.Tokens)
					{
						CreatureToken ct = token as CreatureToken;
						if (ct != null)
						{
							EncounterSlot slot = fEncounter.FindSlot(ct.SlotID);
							if (slot != null)
								ct.Data = slot.FindCombatData(ct.Data.Location);
						}
					}
				}
			}
			else
			{
				MapView.TokenLinks = new List<TokenLink>();
			}

			if (viewpoint != Rectangle.Empty)
			{
				MapView.Viewpoint = viewpoint;
			}
			else
			{
				if (fEncounter.MapAreaID != Guid.Empty)
				{
					MapArea area = m.FindArea(fEncounter.MapAreaID);
					if (area != null)
						MapView.Viewpoint = area.Region;
				}
			}

			foreach (MapSketch sketch in sketches)
				MapView.Sketches.Add(sketch.Copy());

			MapView.Encounter = fEncounter;

			MapView.ShowHealthBars = Session.Preferences.CombatHealthBars;
			MapView.ShowCreatures = Session.Preferences.CombatFog;
			MapView.ShowPictureTokens = Session.Preferences.CombatPictureTokens;
			MapView.ShowGrid = (Session.Preferences.CombatGrid ? MapGridMode.Overlay : MapGridMode.None);
			MapView.ShowGridLabels = Session.Preferences.CombatGridLabels;

			if (fEncounter.MapID == Guid.Empty)
			{
				MapSplitter.Panel2Collapsed = true;
				CombatList.Groups[5].Header = "Non-Combatants";
			}
			else
			{
				if (!Session.Preferences.CombatMapRight)
					OptionsMapBelow_Click(null, null);
			}

			if ((fEncounter.MapID != Guid.Empty) && (Session.Preferences.CombatTwoColumns))
				TwoColumns_Click(null, null);
			if ((fEncounter.MapID == Guid.Empty) && (Session.Preferences.CombatTwoColumnsNoMap))
				TwoColumns_Click(null, null);
		}

		void do_damage(List<IToken> tokens)
		{
			List<Pair<CombatData, EncounterCard>> list = new List<Pair<CombatData, EncounterCard>>();
			foreach (IToken token in tokens)
			{
				CombatData cd = null;
				EncounterCard card = null;

				if (token is CreatureToken)
				{
					CreatureToken ct = token as CreatureToken;
					cd = ct.Data;

					EncounterSlot slot = fEncounter.FindSlot(ct.SlotID);
					card = slot.Card;
				}

				if (token is Hero)
				{
					Hero h = token as Hero;
					//cd = fHeroData[h.ID];
					cd = h.CombatData;
				}

				list.Add(new Pair<CombatData, EncounterCard>(cd, card));
			}

			// Remember their starting HP / state
			Dictionary<CombatData, int> hp_dic = new Dictionary<CombatData, int>();
			Dictionary<CombatData, CreatureState> state_dic = new Dictionary<CombatData, CreatureState>();
			foreach (Pair<CombatData, EncounterCard> pair in list)
				hp_dic[pair.First] = pair.First.Damage;
			foreach (Pair<CombatData, EncounterCard> pair in list)
				state_dic[pair.First] = get_state(pair.First);

			DamageForm dlg = new DamageForm(list, 0);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				foreach (Pair<CombatData, EncounterCard> pair in list)
				{
					// Has HP changed?
					int hp = pair.First.Damage - hp_dic[pair.First];
					if (hp != 0)
						fLog.AddDamageEntry(pair.First.ID, hp, dlg.Types);

					// Has state changed?
					CreatureState new_state = get_state(pair.First);
					if (new_state != state_dic[pair.First])
						fLog.AddStateEntry(pair.First.ID, new_state);
				}

				update_list();
				update_log();
				update_preview_panel();
				update_maps();
			}
		}

		void do_heal(List<IToken> tokens)
		{
			List<Pair<CombatData, EncounterCard>> list = new List<Pair<CombatData, EncounterCard>>();
			foreach (IToken token in tokens)
			{
				CombatData cd = null;
				EncounterCard card = null;

				if (token is CreatureToken)
				{
					CreatureToken ct = token as CreatureToken;
					cd = ct.Data;

					EncounterSlot slot = fEncounter.FindSlot(ct.SlotID);
					card = slot.Card;
				}

				if (token is Hero)
				{
					Hero h = token as Hero;
					//cd = fHeroData[h.ID];
					cd = h.CombatData;
				}

				list.Add(new Pair<CombatData, EncounterCard>(cd, card));
			}

			// Remember their starting HP / state
			Dictionary<CombatData, int> hp_dic = new Dictionary<CombatData, int>();
			Dictionary<CombatData, CreatureState> state_dic = new Dictionary<CombatData, CreatureState>();
			foreach (Pair<CombatData, EncounterCard> pair in list)
				hp_dic[pair.First] = pair.First.Damage;
			foreach (Pair<CombatData, EncounterCard> pair in list)
				state_dic[pair.First] = get_state(pair.First);

			HealForm dlg = new HealForm(list);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				foreach (Pair<CombatData, EncounterCard> pair in list)
				{
					// Has HP changed?
					int hp = pair.First.Damage - hp_dic[pair.First];
					if (hp != 0)
						fLog.AddDamageEntry(pair.First.ID, hp, null);

					// Has state changed?
					CreatureState new_state = get_state(pair.First);
					if (new_state != state_dic[pair.First])
						fLog.AddStateEntry(pair.First.ID, new_state);
				}

				update_list();
				update_log();
				update_preview_panel();
				update_maps();
			}
		}

		void copy_custom_token()
		{
			foreach (IToken token in SelectedTokens)
			{
				if (token is CustomToken)
				{
					CustomToken ct = token as CustomToken;

					CustomToken copy = ct.Copy();
					copy.ID = Guid.NewGuid();
					copy.Data.Location = CombatData.NoPoint;

					fEncounter.CustomTokens.Add(copy);
				}
			}

			update_list();
			//update_preview_panel();
			//update_maps();
		}

		void show_player_view(bool map, bool initiative)
		{
			try
			{
				if (!map && !initiative)
				{
					// Turn it off
					Session.PlayerView.ShowDefault();
				}
				else
				{
					// Do we have a player view already?
					if (Session.PlayerView == null)
						Session.PlayerView = new PlayerViewForm(this);

					if ((PlayerMap == null) && (PlayerInitiative == null))
					{
						// We're not showing anything; turn it on
						Session.PlayerView.ShowTacticalMap(MapView, InitiativeView());
						//Activate();
					}

					SplitContainer splitter = Session.PlayerView.Controls[0] as SplitContainer;
					if (splitter != null)
					{
						splitter.Panel1Collapsed = !map;
						splitter.Panel2Collapsed = !initiative;
					}
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void list_splitter_changed()
		{
			try
			{
				if (Visible)
				{
					//update_list();
					update_preview_panel();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void select_token(IToken token)
		{
			foreach (ListViewItem lvi in CombatList.Items)
			{
				if ((token is CreatureToken) && (lvi.Tag is CreatureToken))
				{
					CreatureToken ct1 = token as CreatureToken;
					CreatureToken ct2 = lvi.Tag as CreatureToken;

					if (ct1.Data == ct2.Data)
						lvi.Selected = true;
				}

				if ((token is CustomToken) && (lvi.Tag is CustomToken))
				{
					CustomToken ct1 = token as CustomToken;
					CustomToken ct2 = lvi.Tag as CustomToken;

					if (ct1.Data == ct2.Data)
						lvi.Selected = true;
				}

				if ((token is Hero) && (lvi.Tag is Hero))
				{
					Hero h1 = token as Hero;
					Hero h2 = lvi.Tag as Hero;

					if (h1 == h2)
						lvi.Selected = true;
				}
			}
		}

		void set_delay(List<IToken> tokens)
		{
			try
			{
				foreach (IToken token in tokens)
				{
					CombatData cd = null;

					if (token is CreatureToken)
					{
						CreatureToken ct = token as CreatureToken;
						cd = ct.Data;
					}

					if (token is Hero)
					{
						Hero hero = token as Hero;
						//cd = fHeroData[hero.ID];
						cd = hero.CombatData;
					}

					if (cd != null)
					{
						cd.Delaying = !cd.Delaying;

						if (cd.Delaying)
						{
							InitiativePanel.InitiativeScores = get_initiatives();
						}
						else
						{
							cd.Initiative = InitiativePanel.CurrentInitiative;
						}
					}
				}

				update_list();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		string get_info(CreatureToken token)
		{
			string str = "";

			EncounterSlot slot = fEncounter.FindSlot(token.SlotID);
			List<string> content = slot.Card.AsText(token.Data, CardMode.Text, true);
			foreach (string line in content)
			{
				if (str != "")
					str += Environment.NewLine;

				str += line;
			}

			if (token.Data.Conditions.Count != 0)
			{
				str += Environment.NewLine;

				foreach (OngoingCondition oc in token.Data.Conditions)
				{
					str += Environment.NewLine;
					str += oc.ToString(fEncounter, false);
				}
			}

			return str;
		}

		string get_info(Hero hero)
		{
			string str = hero.Race + " " + hero.Class;
			if (hero.Player != "")
			{
				str += Environment.NewLine;
				str += "Player: " + hero.Player;
			}

			//CombatData cd = fHeroData[hero.ID];
			CombatData cd = hero.CombatData;
			if (cd != null)
			{
				if (cd.Conditions.Count != 0)
				{
					str += Environment.NewLine;

					foreach (OngoingCondition oc in cd.Conditions)
					{
						str += Environment.NewLine;
						str += oc.ToString(fEncounter, false);
					}
				}
			}

			return str;
		}

		string get_info(CustomToken token)
		{
			return (token.Details != "") ? token.Details : "(no details)";
		}

		void edit_token(IToken token)
		{
			if (token is CreatureToken)
			{
				CreatureToken ct = token as CreatureToken;
				EncounterSlot slot = fEncounter.FindSlot(ct.SlotID);

				int index = slot.CombatData.IndexOf(ct.Data);

				int dmg = ct.Data.Damage;
				CreatureState state = slot.GetState(ct.Data);

				List<string> previous_conditions = new List<string>();
				foreach (OngoingCondition oc in ct.Data.Conditions)
					previous_conditions.Add(oc.ToString(fEncounter, false));

				CombatDataForm dlg = new CombatDataForm(ct.Data, slot.Card, fEncounter, fCurrentActor, fCurrentRound, true);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					slot.CombatData[index] = dlg.Data;

					if (dmg != dlg.Data.Damage)
					{
						dmg = dlg.Data.Damage - dmg;
						fLog.AddDamageEntry(dlg.Data.ID, dmg, null);
					}
					if (slot.GetState(dlg.Data) != state)
					{
						state = slot.GetState(dlg.Data);
						fLog.AddStateEntry(dlg.Data.ID, state);
					}

					// Look for new / removed conditions
					List<string> new_conditions = new List<string>();
					foreach (OngoingCondition oc in dlg.Data.Conditions)
						new_conditions.Add(oc.ToString(fEncounter, false));
					foreach (string str in previous_conditions)
					{
						if (!new_conditions.Contains(str))
							fLog.AddEffectEntry(dlg.Data.ID, str, false);
					}
					foreach (string str in new_conditions)
					{
						if (!previous_conditions.Contains(str))
							fLog.AddEffectEntry(dlg.Data.ID, str, true);
					}

					update_list();
					update_log();
					update_preview_panel();
					update_maps();

					InitiativePanel.InitiativeScores = get_initiatives();
				}
			}

			if (token is Hero)
			{
				Hero h = token as Hero;

				if (h.CombatData.Initiative == int.MinValue)
				{
					edit_initiative(h);
				}
				else
				{
					//CombatData cd = fHeroData[h.ID];
					CombatData cd = h.CombatData;

					int dmg = cd.Damage;
					CreatureState state = h.GetState(cd.Damage);

					List<string> previous_conditions = new List<string>();
					foreach (OngoingCondition oc in cd.Conditions)
						previous_conditions.Add(oc.ToString(fEncounter, false));

					CombatDataForm dlg = new CombatDataForm(cd, null, fEncounter, fCurrentActor, fCurrentRound, false);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						//fHeroData[h.ID] = dlg.Data;
						h.CombatData = dlg.Data;

						if (dmg != dlg.Data.Damage)
						{
							dmg = dlg.Data.Damage - dmg;
							fLog.AddDamageEntry(dlg.Data.ID, dmg, null);
						}
						if (h.GetState(dlg.Data.Damage) != state)
						{
							state = h.GetState(dlg.Data.Damage);
							fLog.AddStateEntry(dlg.Data.ID, state);
						}

						// Look for new / removed conditions
						List<string> new_conditions = new List<string>();
						foreach (OngoingCondition oc in dlg.Data.Conditions)
							new_conditions.Add(oc.ToString(fEncounter, false));
						foreach (string str in previous_conditions)
						{
							if (!new_conditions.Contains(str))
								fLog.AddEffectEntry(dlg.Data.ID, str, false);
						}
						foreach (string str in new_conditions)
						{
							if (!previous_conditions.Contains(str))
								fLog.AddEffectEntry(dlg.Data.ID, str, true);
						}

						update_list();
						update_log();
						update_preview_panel();
						update_maps();

						InitiativePanel.InitiativeScores = get_initiatives();
					}
				}
			}

			if (token is CustomToken)
			{
				CustomToken ct = token as CustomToken;
				int index = fEncounter.CustomTokens.IndexOf(ct);
				if (index != -1)
				{
					switch (ct.Type)
					{
						case CustomTokenType.Token:
							{
								CustomTokenForm dlg = new CustomTokenForm(ct);
								if (dlg.ShowDialog() == DialogResult.OK)
								{
									fEncounter.CustomTokens[index] = dlg.Token;

									update_list();
									update_preview_panel();
									update_maps();
								}
							}
							break;
						case CustomTokenType.Overlay:
							{
								CustomOverlayForm dlg = new CustomOverlayForm(ct);
								if (dlg.ShowDialog() == DialogResult.OK)
								{
									fEncounter.CustomTokens[index] = dlg.Token;

									update_list();
									update_preview_panel();
									update_maps();
								}
							}
							break;
					}
				}
			}
		}

		void set_tooltip(IToken token, Control ctrl)
		{
			string title = "";
			string info = null;

			if (token is CreatureToken)
			{
				CreatureToken ct = token as CreatureToken;

				title = ct.Data.DisplayName;
				info = get_info(ct);
			}

			if (token is Hero)
			{
				Hero hero = token as Hero;

				title = hero.Name;
				info = get_info(hero);
			}

			if (token is CustomToken)
			{
				CustomToken ct = token as CustomToken;

				title = ct.Name;
				info = get_info(ct);
			}

			MapTooltip.ToolTipTitle = title;
			MapTooltip.SetToolTip(ctrl, info);
		}

		void remove_from_map(List<IToken> tokens)
		{
			try
			{
				foreach (IToken token in tokens)
				{
					if (token is CreatureToken)
					{
						CreatureToken ct = token as CreatureToken;
						ct.Data.Location = CombatData.NoPoint;

						remove_effects(token);
						remove_links(token);
					}

					if (token is Hero)
					{
						Hero hero = token as Hero;
						//MapView.HeroData[hero.ID].Location = CombatData.NoPoint;
						hero.CombatData.Location = CombatData.NoPoint;

						remove_effects(token);
						remove_links(token);
					}

					if (token is CustomToken)
					{
						CustomToken ct = token as CustomToken;
						ct.Data.Location = CombatData.NoPoint;

						if (ct.Type == CustomTokenType.Token)
							remove_links(token);
					}
				}

				update_list();
				update_preview_panel();
				update_maps();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void remove_from_combat(List<IToken> tokens)
		{
			try
			{
				foreach (IToken token in tokens)
				{
					if (token is CreatureToken)
					{
						CreatureToken ct = token as CreatureToken;

						EncounterSlot slot = fEncounter.FindSlot(ct.SlotID);
						slot.CombatData.Remove(ct.Data);

						fRemovedCreatureXP += slot.Card.XP;

						remove_effects(token);
						remove_links(token);
					}

					if (token is Hero)
					{
						Hero h = token as Hero;

						//MapView.HeroData[h.ID].Initiative = int.MinValue;
						//MapView.HeroData[h.ID].Location = CombatData.NoPoint;
						h.CombatData.Initiative = int.MinValue;
						h.CombatData.Location = CombatData.NoPoint;

						remove_effects(token);
						remove_links(token);
					}

					if (token is CustomToken)
					{
						CustomToken ct = token as CustomToken;

						fEncounter.CustomTokens.Remove(ct);

						if (ct.Type == CustomTokenType.Token)
							remove_links(token);
					}
				}

				update_list();
				update_preview_panel();
				update_maps();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void remove_effects(IToken token)
		{
			Guid token_id = Guid.Empty;

			if (token is CreatureToken)
			{
				CreatureToken ct = token as CreatureToken;
				token_id = ct.Data.ID;
			}

			if (token is Hero)
			{
				Hero hero = token as Hero;
				token_id = hero.ID;
			}

			if (token_id == Guid.Empty)
				return;

			foreach (Hero hero in Session.Project.Heroes)
			{
				CombatData cd = hero.CombatData;
				remove_effects(token_id, cd);
			}
			//foreach (Guid hero_id in fHeroData.Keys)
			//{
			//    CombatData cd = fHeroData[hero_id];
			//    remove_effects(token_id, cd);
			//}

			foreach (EncounterSlot slot in fEncounter.AllSlots)
			{
				foreach (CombatData cd in slot.CombatData)
					remove_effects(token_id, cd);
			}
		}

		void remove_effects(Guid token_id, CombatData data)
		{
			List<OngoingCondition> obsolete = new List<OngoingCondition>();
			foreach (OngoingCondition oc in data.Conditions)
			{
				if (oc.DurationCreatureID != token_id)
					continue;

				if ((oc.Duration == DurationType.BeginningOfTurn) || (oc.Duration == DurationType.EndOfTurn))
					obsolete.Add(oc);
			}

			foreach (OngoingCondition oc in obsolete)
				data.Conditions.Remove(oc);
		}

		void remove_links(IToken token)
		{
			Point location = get_location(token);
			List<TokenLink> obsolete = new List<TokenLink>();

			foreach (TokenLink tl in MapView.TokenLinks)
			{
				foreach (IToken t in tl.Tokens)
				{
					if (get_location(t) == location)
					{
						obsolete.Add(tl);
						break;
					}
				}
			}

			foreach (TokenLink tl in obsolete)
				MapView.TokenLinks.Remove(tl);

			update_maps();
		}

		Point get_location(IToken token)
		{
			if (token is CreatureToken)
			{
				CreatureToken ct = token as CreatureToken;
				return ct.Data.Location;
			}

			if (token is Hero)
			{
				Hero h = token as Hero;
				//return fHeroData[h.ID].Location;
				return h.CombatData.Location;
			}

			if (token is CustomToken)
			{
				CustomToken ct = token as CustomToken;
				return ct.Data.Location;
			}

			return CombatData.NoPoint;
		}

		void toggle_visibility(List<IToken> tokens)
		{
			try
			{
				foreach (IToken token in tokens)
				{
					if (token is CreatureToken)
					{
						CreatureToken ct = token as CreatureToken;
						ct.Data.Visible = !ct.Data.Visible;
					}

					if (token is CustomToken)
					{
						CustomToken ct = token as CustomToken;
						ct.Data.Visible = !ct.Data.Visible;
					}
				}

				update_list();
				update_preview_panel();
				update_maps();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void show_or_hide_all(bool visible)
		{
			foreach (EncounterSlot slot in fEncounter.AllSlots)
			{
				foreach (CombatData cd in slot.CombatData)
					cd.Visible = visible;
			}

			foreach (CustomToken ct in fEncounter.CustomTokens)
			{
				ct.Data.Visible = visible;
			}

			update_list();
			update_preview_panel();
			update_maps();
		}

		void roll_attack(CreaturePower power)
		{
			AttackRollForm dlg = new AttackRollForm(power, fEncounter);
			dlg.ShowDialog();

			update_list();
			update_log();
			update_preview_panel();
			update_maps();
		}

		void roll_check(string name, int mod)
		{
			int roll = Session.Dice(1, 20);
			int result = roll + mod;

			string roll_str = roll.ToString();
			if ((roll == 1) || (roll == 20))
				roll_str = "Natural " + roll_str;

			string str = "Bonus:\t" + mod + Environment.NewLine + "Roll:\t" + roll_str + Environment.NewLine + Environment.NewLine + "Result:\t" + result;
			MessageBox.Show(str, name, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		#region Initiative

		bool edit_initiative(Hero hero)
		{
			int score = 0;
			//if (fHeroData.ContainsKey(hero.ID))
			//    score = fHeroData[hero.ID].Initiative;
			score = hero.CombatData.Initiative;

			InitiativeForm dlg = new InitiativeForm(hero.InitBonus, score);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				//fHeroData[hero.ID].Initiative = dlg.Score;
				hero.CombatData.Initiative = dlg.Score;

				update_list();
				update_preview_panel();
				update_maps();
				update_statusbar();

				List<int> init_scores = get_initiatives();
				InitiativePanel.InitiativeScores = init_scores;
				int top_score = init_scores[0];

				return true;
			}

			return false;
		}

		int next_init(int current_init)
		{
			List<int> scores = get_initiatives();

			if (!scores.Contains(current_init))
				scores.Add(current_init);

			scores.Sort();
			scores.Reverse();

			int init_index = scores.IndexOf(current_init) + 1;
			if (init_index == scores.Count)
				init_index = 0;

			return scores[init_index];
		}

		int find_max_init()
		{
			List<int> scores = get_initiatives();

			if (scores.Count != 0)
				return scores[0];

			return 0;
		}

		int find_min_init()
		{
			List<int> scores = get_initiatives();

			if (scores.Count != 0)
				return scores[scores.Count - 1];

			return 0;
		}

		List<int> get_initiatives()
		{
			List<int> scores = new List<int>();

			foreach (EncounterSlot slot in fEncounter.AllSlots)
			{
				foreach (CombatData cd in slot.CombatData)
				{
					//if (cd.Delaying)
					//	continue;
					if (slot.GetState(cd) == CreatureState.Defeated)
						continue;

					//if (cd.Damage >= slot.Card.HP)
					//	continue;

					int score = cd.Initiative;
					if (score == int.MinValue)
						continue;

					if (!scores.Contains(score))
						scores.Add(score);
				}
			}

			foreach (Hero hero in Session.Project.Heroes)
			//foreach (CombatData cd in fHeroData.Values)
			{
				CombatData cd = hero.CombatData;

				//if (cd.Delaying)
				//	continue;

				int score = cd.Initiative;
				if (score == int.MinValue)
					continue;

				if (!scores.Contains(score))
					scores.Add(score);
			}

			foreach (CombatData cd in fTrapData.Values)
			{
				if (cd.Delaying)
					continue;

				int score = cd.Initiative;
				if (score == int.MinValue)
					continue;

				if (!scores.Contains(score))
					scores.Add(score);
			}

			scores.Sort();
			scores.Reverse();

			return scores;
		}

		#endregion

		#region Handle game effects

		void handle_regen()
		{
			if (fCurrentActor == null)
				return;

			if (fCurrentActor.Damage <= 0)
				return;

			EncounterSlot slot = fEncounter.FindSlot(fCurrentActor);
			if (slot == null)
				return;

			Regeneration regen = new Regeneration();
			regen.Value = 0;

			if (slot.Card.Regeneration != null)
			{
				regen.Value = slot.Card.Regeneration.Value;
				regen.Details = slot.Card.Regeneration.Details;
			}

			foreach (OngoingCondition oc in fCurrentActor.Conditions)
			{
				if (oc.Type != OngoingType.Regeneration)
					continue;

				// Take the highest regen value
				regen.Value = Math.Max(regen.Value, oc.Regeneration.Value);

				if (oc.Regeneration.Details != "")
				{
					if (regen.Details != "")
						regen.Details += Environment.NewLine;

					regen.Details += oc.Regeneration.Details;
				}
			}
			if (regen.Value == 0)
				return;

			string str = fCurrentActor.DisplayName + " has regeneration:";
			str += Environment.NewLine + Environment.NewLine;
			str += "Value: " + regen.Value + Environment.NewLine;
			if (regen.Details != "")
				str += regen.Details + Environment.NewLine;
			str += Environment.NewLine;
			str += "Do you want to apply it now?";

			if (MessageBox.Show(str, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
			{
				fCurrentActor.Damage -= regen.Value;
				fCurrentActor.Damage = Math.Max(0, fCurrentActor.Damage);
			}
		}

		void handle_ended_effects(bool beginning_of_turn)
		{
			if (fCurrentActor == null)
				return;

			DurationType dt = beginning_of_turn ? DurationType.BeginningOfTurn : DurationType.EndOfTurn;

			List<Pair<CombatData, OngoingCondition>> ended_conditions = new List<Pair<CombatData, OngoingCondition>>();

			foreach (EncounterSlot slot in fEncounter.AllSlots)
			{
				foreach (CombatData cd in slot.CombatData)
				{
					foreach (OngoingCondition oc in cd.Conditions)
					{
						if (oc.Duration != dt)
							continue;

						if (oc.DurationRound > fCurrentRound)
							continue;

						if (fCurrentActor.ID == oc.DurationCreatureID)
							ended_conditions.Add(new Pair<CombatData, OngoingCondition>(cd, oc));
					}
				}
			}

			foreach (Hero hero in Session.Project.Heroes)
			//foreach (Guid hero_id in fHeroData.Keys)
			{
				//CombatData cd = fHeroData[hero_id];
				CombatData cd = hero.CombatData;

				foreach (OngoingCondition oc in cd.Conditions)
				{
					if (oc.Duration != dt)
						continue;

					if (oc.DurationRound > fCurrentRound)
						continue;

					if (fCurrentActor.ID == oc.DurationCreatureID)
						ended_conditions.Add(new Pair<CombatData, OngoingCondition>(cd, oc));
				}
			}

			foreach (Guid trap_id in fTrapData.Keys)
			{
				CombatData cd = fTrapData[trap_id];

				foreach (OngoingCondition oc in cd.Conditions)
				{
					if (oc.Duration != dt)
						continue;

					if (oc.DurationRound > fCurrentRound)
						continue;

					if (fCurrentActor.ID == oc.DurationCreatureID)
						ended_conditions.Add(new Pair<CombatData, OngoingCondition>(cd, oc));
				}
			}

			if (ended_conditions.Count > 0)
			{
				EndedEffectsForm dlg = new EndedEffectsForm(ended_conditions, fEncounter);
				dlg.ShowDialog();

				update_list();
			}
		}

		void handle_saves()
		{
			if (fCurrentActor == null)
				return;

			if (fCurrentActor.Delaying)
				return;

			List<OngoingCondition> conditions = new List<OngoingCondition>();
			foreach (OngoingCondition oc in fCurrentActor.Conditions)
			{
				if (oc.Duration == DurationType.SaveEnds)
					conditions.Add(oc);
			}

			if (conditions.Count == 0)
				return;

			EncounterCard card = null;
			EncounterSlot slot = fEncounter.FindSlot(fCurrentActor);
			if (slot != null)
				card = slot.Card;

			SavingThrowForm dlg = new SavingThrowForm(fCurrentActor, card, fEncounter);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				update_list();
			}
		}

		void handle_ongoing_damage()
		{
			if (fCurrentActor == null)
				return;

			List<OngoingCondition> conditions = new List<OngoingCondition>();
			foreach (OngoingCondition oc in fCurrentActor.Conditions)
			{
				if ((oc.Type == OngoingType.Damage) && (oc.Value > 0))
					conditions.Add(oc);
			}

			if (conditions.Count == 0)
				return;

			EncounterCard card = null;
			EncounterSlot slot = fEncounter.FindSlot(fCurrentActor);
			if (slot != null)
				card = slot.Card;

			int dmg = fCurrentActor.Damage;
			CreatureState state = CreatureState.Active;
			if (slot != null)
				state = slot.GetState(fCurrentActor);
			if (slot == null)
			{
				Hero h = Session.Project.FindHero(fCurrentActor.ID);
				state = h.GetState(dmg);
			}

			OngoingDamageForm dlg = new OngoingDamageForm(fCurrentActor, card, fEncounter);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				if (fCurrentActor.Damage != dmg)
					fLog.AddDamageEntry(fCurrentActor.ID, fCurrentActor.Damage - dmg, null);
				if (slot != null)
				{
					if (slot.GetState(fCurrentActor) != state)
						fLog.AddStateEntry(fCurrentActor.ID, slot.GetState(fCurrentActor));
				}
				else
				{
					Hero h = Session.Project.FindHero(fCurrentActor.ID);
					if (h.GetState(fCurrentActor.Damage) != state)
						fLog.AddStateEntry(fCurrentActor.ID, h.GetState(fCurrentActor.Damage));
				}

				update_list();
				update_log();
			}
		}

		void handle_recharge()
		{
			if (fCurrentActor == null)
				return;

			EncounterSlot slot = fEncounter.FindSlot(fCurrentActor);
			if (slot == null)
				return;

			List<CreaturePower> powers = slot.Card.CreaturePowers;
			List<CreaturePower> rechargable_powers = new List<CreaturePower>();
			foreach (Guid power_id in fCurrentActor.UsedPowers)
			{
				foreach (CreaturePower power in powers)
				{
					if ((power.ID == power_id) && (power.Action != null) && (power.Action.Recharge != ""))
						rechargable_powers.Add(power);
				}
			}

			if (rechargable_powers.Count == 0)
				return;

			RechargeForm dlg = new RechargeForm(fCurrentActor, slot.Card);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				update_list();
			}
		}

		#endregion

		CombatData get_next_actor(CombatData current_actor)
		{
			// What's the current initiative?
			int init = current_actor != null ? current_actor.Initiative : InitiativePanel.CurrentInitiative;

			List<int> scores = get_initiatives();
			if (!scores.Contains(init))
				init = next_init(init);

			CombatData next_actor = null;

			// What combatants are at this init value?
			List<CombatData> combatants = get_combatants(init, true);

			int index = combatants.IndexOf(current_actor);
			if (index == -1)
			{
				// Use first 
				next_actor = combatants[0];
			}
			else if (index == combatants.Count - 1)
			{
				init = next_init(init);
				combatants = get_combatants(init, false);
				next_actor = combatants[0];
			}
			else
			{
				// Use next
				next_actor = combatants[index + 1];
			}

			// If defeated or delaying, get the next one
			bool defeated = get_state(next_actor) == CreatureState.Defeated;
			bool delaying = (next_actor != null) && next_actor.Delaying;
			if (defeated || delaying)
				next_actor = get_next_actor(next_actor);

			return next_actor;
		}

		CreatureState get_state(CombatData cd)
		{
			EncounterSlot slot = fEncounter.FindSlot(cd);
			if (slot != null)
				return slot.GetState(cd);

			Hero hero = Session.Project.FindHero(cd.ID);
			if (hero != null)
				return hero.GetState(cd.Damage);

			Trap trap = fEncounter.FindTrap(cd.ID);
			if (trap != null)
				return CreatureState.Active;

			return CreatureState.Active;
		}

		List<CombatData> get_combatants(int init, bool include_defeated)
		{
			Dictionary<int, List<CombatData>> data = new Dictionary<int, List<CombatData>>();

			foreach (EncounterSlot slot in fEncounter.AllSlots)
			{
				int slot_init = slot.Card.Initiative;
				if (!data.ContainsKey(slot_init))
					data[slot_init] = new List<CombatData>();

				foreach (CombatData cd in slot.CombatData)
				{
					if ((slot.GetState(cd) == CreatureState.Defeated) && (!include_defeated))
						continue;

					if (cd.Initiative == init)
						data[slot_init].Add(cd);
				}
			}
			foreach (Hero hero in Session.Project.Heroes)
			{
				//if (!fHeroData.ContainsKey(hero.ID))
				//	continue;

				if (!data.ContainsKey(hero.InitBonus))
					data[hero.InitBonus] = new List<CombatData>();

				//CombatData cd = fHeroData[hero.ID];
				CombatData cd = hero.CombatData;

				if (cd.Initiative == init)
					data[hero.InitBonus].Add(cd);
			}
			foreach (Trap trap in fEncounter.Traps)
			{
				if (trap.Initiative == int.MinValue)
					continue;

				if (!fTrapData.ContainsKey(trap.ID))
					continue;

				if (!data.ContainsKey(trap.Initiative))
					data[trap.Initiative] = new List<CombatData>();

				CombatData cd = fTrapData[trap.ID];

				if (cd.Initiative == init)
					data[trap.Initiative].Add(cd);
			}

			List<int> bonuses = new List<int>();
			bonuses.AddRange(data.Keys);
			bonuses.Sort();
			bonuses.Reverse();

			List<CombatData> list = new List<CombatData>();
			foreach (int bonus in bonuses)
			{
				data[bonus].Sort();
				list.AddRange(data[bonus]);
			}

			return list;
		}

		void highlight_current_actor()
		{
			MapView.BoxedTokens.Clear();
			if (fCurrentActor != null)
			{
				Hero hero = Session.Project.FindHero(fCurrentActor.ID);
				if (hero != null)
				{
					MapView.BoxedTokens.Add(hero);
				}
				else
				{
					EncounterSlot slot = fEncounter.FindSlot(fCurrentActor);
					if (slot != null)
					{
						CreatureToken ct = new CreatureToken(slot.ID, fCurrentActor);
						MapView.BoxedTokens.Add(ct);
					}
					else
					{
						// It's a trap!
					}
				}

				MapView.MapChanged();
			}
		}

		ListViewItem get_combatant(Guid id)
		{
			foreach (ListViewItem lvi in CombatList.Items)
			{
				CreatureToken ct = lvi.Tag as CreatureToken;
				if (ct != null)
				{
					if (ct.Data.ID == id)
						return lvi;
				}

				Hero hero = lvi.Tag as Hero;
				if (hero != null)
				{
					if (hero.ID == id)
						return lvi;
				}

				Trap trap = lvi.Tag as Trap;
				if (trap != null)
				{
					if (trap.ID == id)
						return lvi;
				}
			}

			return null;
		}

		void cancelled_scrolling()
		{
			MapView map = Session.Preferences.PlayerViewMap ? MapView : null;
			string init = Session.Preferences.PlayerViewInitiative ? InitiativeView() : null;
			Session.PlayerView.ShowTacticalMap(map, init);

			PlayerMap.ScalingFactor = MapView.ScalingFactor;
		}

		#endregion

		#region Updating

		void update_list()
		{
			#region Remove defeated

			List<CombatData> defeated = new List<CombatData>();
			if (Session.Preferences.CreatureAutoRemove)
			{
				// Remove creatures at 0 HP or below

				foreach (EncounterSlot slot in fEncounter.AllSlots)
				{
					int full_hp = slot.Card.HP;
					if (full_hp == 0)
						continue;

					int xp = slot.Card.XP;

					List<CombatData> obsolete = new List<CombatData>();
					foreach (CombatData cd in slot.CombatData)
					{
						CreatureState state = slot.GetState(cd);
						if (state == CreatureState.Defeated)
						{
							obsolete.Add(cd);
							defeated.Add(cd);
						}
					}

					foreach (CombatData cd in obsolete)
					{
						if (cd == fCurrentActor)
						{
							Guid previous_actor = fCurrentActor.ID;

							fCurrentActor = get_next_actor(fCurrentActor);

							if (fCurrentActor.ID != previous_actor)
							{
								fLog.AddStartTurnEntry(fCurrentActor.ID);
								update_log();
							}
						}

						CreatureToken ct = new CreatureToken(slot.ID, cd);

						remove_effects(ct);
						remove_links(ct);

						cd.Location = CombatData.NoPoint;

						//fRemovedCreatureXP += xp;
						//slot.CombatData.Remove(cd);
					}
				}
			}

			#endregion

			int COMBATANTS = 0;
			int DELAYED = 1;
			int TRAPS = 2;
			int SKILLCHALLENGES = 3;
			int CUSTOM = 4;
			int INACTIVE = 5;
			int DEFEATED = 6;

			List<IToken> selected_tokens = SelectedTokens;
			Trap selected_trap = SelectedTrap;
			SkillChallenge selected_challenge = SelectedChallenge;

			CombatList.BeginUpdate();

			#region Columns

			//int required_width = NameHdr.Width + InitHdr.Width + HPHdr.Width + SystemInformation.VerticalScrollBarWidth;
			//int required_defences = required_width + DefHdr.Width;
			//int required_conditions = required_defences + ConditionsHdr.Width;

			//bool show_defences = (CombatList.Width > required_defences);
			//if (show_defences)
			//{
			//    if (!CombatList.Columns.Contains(DefHdr))
			//        CombatList.Columns.Add(DefHdr);
			//}
			//else
			//{
			//    if (CombatList.Columns.Contains(DefHdr))
			//        CombatList.Columns.Remove(DefHdr);
			//}

			//bool show_conditions = (CombatList.Width > required_conditions);
			//if (show_conditions)
			//{
			//    if (!CombatList.Columns.Contains(ConditionsHdr))
			//        CombatList.Columns.Add(ConditionsHdr);
			//}
			//else
			//{
			//    if (CombatList.Columns.Contains(ConditionsHdr))
			//        CombatList.Columns.Remove(ConditionsHdr);
			//}

			#endregion

			CombatList.Items.Clear();

			CombatList.SmallImageList = new ImageList();
			CombatList.SmallImageList.ImageSize = new Size(16, 16);

			#region Creatures

			foreach (EncounterSlot slot in fEncounter.AllSlots)
			{
				EncounterWave ew = fEncounter.FindWave(slot);
				if ((ew != null) && (ew.Active == false))
					continue;

				int full_hp = slot.Card.HP;
				ICreature creature = Session.FindCreature(slot.Card.CreatureID, SearchType.Global);

				foreach (CombatData cd in slot.CombatData)
				{
					int hp = full_hp - cd.Damage;
					string hp_str = hp.ToString();

					if (cd.TempHP > 0)
						hp_str += " (+" + cd.TempHP + ")";

					if (hp != full_hp)
						hp_str += " / " + full_hp;

					string init_str = cd.Initiative.ToString();
					if (cd.Delaying)
						init_str = "(" + init_str + ")";

					ListViewItem lvi = CombatList.Items.Add(cd.DisplayName);
					lvi.Tag = new CreatureToken(slot.ID, cd);

					if (cd.Initiative == int.MinValue)
					{
						lvi.ForeColor = SystemColors.GrayText;
						init_str = "-";
					}

					int ac = slot.Card.AC;
					int fort = slot.Card.Fortitude;
					int reflex = slot.Card.Reflex;
					int will = slot.Card.Will;

					foreach (OngoingCondition oc in cd.Conditions)
					{
						if (oc.Type != OngoingType.DefenceModifier)
							continue;

						if (oc.Defences.Contains(DefenceType.AC))
							ac += oc.DefenceMod;
						if (oc.Defences.Contains(DefenceType.Fortitude))
							fort += oc.DefenceMod;
						if (oc.Defences.Contains(DefenceType.Reflex))
							reflex += oc.DefenceMod;
						if (oc.Defences.Contains(DefenceType.Will))
							will += oc.DefenceMod;
					}

					string def_str = "AC " + ac + ", Fort " + fort + ", Ref " + reflex + ", Will " + will;
					string conditions_str = get_conditions(cd);

					lvi.SubItems.Add(init_str);
					lvi.SubItems.Add(hp_str);
					lvi.SubItems.Add(def_str);
					lvi.SubItems.Add(conditions_str);

					switch (slot.GetState(cd))
					{
						case CreatureState.Bloodied:
							lvi.ForeColor = Color.Maroon;
							break;
						case CreatureState.Defeated:
							lvi.ForeColor = SystemColors.GrayText;
							break;
					}

					if (!cd.Visible)
					{
						lvi.ForeColor = Color.FromArgb(80, lvi.ForeColor);
						lvi.Text += " (hidden)";
					}

					if ((creature != null) && (creature.Image != null))
					{
						CombatList.SmallImageList.Images.Add(new Bitmap(creature.Image, 16, 16));
						lvi.ImageIndex = CombatList.SmallImageList.Images.Count - 1;
					}
					else
					{
						add_icon(lvi, lvi.ForeColor);
					}

					if (cd.Conditions.Count != 0)
						add_condition_hint(lvi);

					int group_index = COMBATANTS;
					if (cd.Initiative == int.MinValue)
						group_index = INACTIVE;
					if (cd.Delaying)
						group_index = DELAYED;
					if ((MapView.Map != null) && (cd.Location == CombatData.NoPoint))
						group_index = INACTIVE;
					if (slot.GetState(cd) == CreatureState.Defeated)
						group_index = DEFEATED;

					lvi.Group = CombatList.Groups[group_index];

					if (cd == fCurrentActor)
					{
						lvi.Font = new Font(lvi.Font, lvi.Font.Style | FontStyle.Bold);
						lvi.UseItemStyleForSubItems = false;
						lvi.BackColor = Color.LightBlue;

						add_initiative_hint(lvi);
					}

					foreach (IToken token in selected_tokens)
					{
						CreatureToken ct = token as CreatureToken;
						if (ct != null)
						{
							if (ct.Data == cd)
								lvi.Selected = true;
						}
					}
				}
			}

			#endregion

			#region Traps

			foreach (Trap trap in fEncounter.Traps)
			{
				ListViewItem lvi = CombatList.Items.Add(trap.Name);
				lvi.Tag = trap;

				add_icon(lvi, Color.White);

				if (trap.Initiative != int.MinValue)
				{
					CombatData cd = fTrapData[trap.ID];

					if ((cd != null) && (cd.Initiative != int.MinValue))
					{
						string init_str = cd.Initiative.ToString();
						lvi.SubItems.Add(init_str);

						lvi.Group = CombatList.Groups[COMBATANTS];
					}
					else
					{
						lvi.SubItems.Add("-");

						lvi.Group = CombatList.Groups[INACTIVE];
					}

					if (cd == fCurrentActor)
					{
						lvi.Font = new Font(lvi.Font, lvi.Font.Style | FontStyle.Bold);
						lvi.UseItemStyleForSubItems = false;
						lvi.BackColor = Color.LightBlue;

						add_initiative_hint(lvi);
					}
				}
				else
				{
					lvi.SubItems.Add("-");
					lvi.Group = CombatList.Groups[TRAPS];
				}

				// HP, defences, conditions
				lvi.SubItems.Add("-");
				lvi.SubItems.Add("-");
				lvi.SubItems.Add("-");

				if (trap == selected_trap)
					lvi.Selected = true;
			}

			#endregion

			#region Skill Challenges

			foreach (SkillChallenge sc in fEncounter.SkillChallenges)
			{
				ListViewItem lvi = CombatList.Items.Add(sc.Name);

				// Init, HP, defences, conditions
				lvi.SubItems.Add("-");
				lvi.SubItems.Add("-");
				lvi.SubItems.Add("-");
				lvi.SubItems.Add(sc.Results.Successes + " / " + sc.Successes + " successes; " + sc.Results.Fails + " / 3 failures");

				add_icon(lvi, Color.White);

				lvi.Tag = sc;
				lvi.Group = CombatList.Groups[SKILLCHALLENGES];

				if (sc == selected_challenge)
					lvi.Selected = true;
			}

			#endregion

			#region Heroes

			foreach (Hero hero in Session.Project.Heroes)
			{
				int group_index = COMBATANTS;

				ListViewItem lvi = CombatList.Items.Add(hero.Name);
				lvi.Tag = hero;

				CombatData cd = hero.CombatData;

				switch (hero.GetState(cd.Damage))
				{
					case CreatureState.Active:
						lvi.ForeColor = SystemColors.WindowText;
						break;
					case CreatureState.Bloodied:
						lvi.ForeColor = Color.Maroon;
						break;
					case CreatureState.Defeated:
						lvi.ForeColor = SystemColors.GrayText;
						break;
				}

				if (hero.Portrait != null)
				{
					CombatList.SmallImageList.Images.Add(new Bitmap(hero.Portrait, 16, 16));
					lvi.ImageIndex = CombatList.SmallImageList.Images.Count - 1;
				}
				else
				{
					add_icon(lvi, Color.Green);
				}

				if (cd.Conditions.Count != 0)
					add_condition_hint(lvi);

				string init_str = "";
				int init = cd.Initiative;
				if (init == int.MinValue)
				{
					lvi.ForeColor = SystemColors.GrayText;
					group_index = INACTIVE;

					init_str = "-";
				}
				else
				{
					init_str = init.ToString();
					if (cd.Delaying)
					{
						init_str = "(" + init_str + ")";
						group_index = DELAYED;
					}

					if (cd == fCurrentActor)
					{
						lvi.Font = new Font(lvi.Font, lvi.Font.Style | FontStyle.Bold);
						lvi.UseItemStyleForSubItems = false;
						lvi.BackColor = Color.LightBlue;

						add_initiative_hint(lvi);
					}
				}

				string hp_str = "";
				if (hero.HP != 0)
				{
					int hp = hero.HP - cd.Damage;
					hp_str = hp.ToString();

					if (cd.TempHP > 0)
						hp_str += " (+" + cd.TempHP + ")";

					if (hp != hero.HP)
						hp_str += " / " + hero.HP;
				}
				else
				{
					hp_str = "-";
				}

				lvi.SubItems.Add(init_str);
				lvi.SubItems.Add(hp_str);

				if ((hero.AC != 0) && (hero.Fortitude != 0) && (hero.Reflex != 0) && (hero.Will != 0))
				{
					int ac = hero.AC;
					int fort = hero.Fortitude;
					int reflex = hero.Reflex;
					int will = hero.Will;

					foreach (OngoingCondition oc in cd.Conditions)
					{
						if (oc.Type != OngoingType.DefenceModifier)
							continue;

						if (oc.Defences.Contains(DefenceType.AC))
							ac += oc.DefenceMod;
						if (oc.Defences.Contains(DefenceType.Fortitude))
							fort += oc.DefenceMod;
						if (oc.Defences.Contains(DefenceType.Reflex))
							reflex += oc.DefenceMod;
						if (oc.Defences.Contains(DefenceType.Will))
							will += oc.DefenceMod;
					}
					string def_str = "AC " + ac + ", Fort " + fort + ", Ref " + reflex + ", Will " + will;
					lvi.SubItems.Add(def_str);
				}
				else
				{
					lvi.SubItems.Add("-");
				}

				lvi.SubItems.Add(get_conditions(cd));

				if ((MapView.Map != null) && (hero.CombatData.Location == CombatData.NoPoint))
					group_index = INACTIVE;

				lvi.Group = CombatList.Groups[group_index];

				if (selected_tokens.Contains(hero))
					lvi.Selected = true;
			}

			#endregion

			#region Custom Tokens

			foreach (CustomToken ct in fEncounter.CustomTokens)
			{
				ListViewItem lvi = CombatList.Items.Add(ct.Name);
				lvi.Tag = ct;

				add_icon(lvi, Color.Blue);

				int group_index = CUSTOM;
				if ((MapView.Map != null) && (ct.Data.Location == CombatData.NoPoint) && (ct.CreatureID == Guid.Empty))
				{
					group_index = INACTIVE;
					lvi.ForeColor = SystemColors.GrayText;
				}

				lvi.Group = CombatList.Groups[group_index];

				if (selected_tokens.Contains(ct))
					lvi.Selected = true;
			}

			#endregion

			CombatList.Sort();

			CombatList.EndUpdate();

			if (PlayerInitiative != null)
				PlayerInitiative.DocumentText = InitiativeView();
		}

		string get_conditions(CombatData cd)
		{
			string str = "";

			// Are there any ongoing damage conditions?
			bool ongoing = false;
			foreach (OngoingCondition oc in cd.Conditions)
			{
				if (oc.Type == OngoingType.Damage)
				{
					ongoing = true;
					break;
				}
			}

			if (ongoing)
			{
				if (str != "")
					str += "; ";

				str += "Damage";
			}

			foreach (OngoingCondition oc in cd.Conditions)
			{
				// Ignore damage conditions
				if (oc.Type == OngoingType.Damage)
					continue;

				if (str != "")
					str += "; ";

				switch (oc.Type)
				{
					case OngoingType.Condition:
						str += oc.Data;
						break;
					case OngoingType.DefenceModifier:
						str += oc.ToString(fEncounter, false);
						break;
				}
			}

			return str;
		}

		void add_icon(ListViewItem lvi, Color c)
		{
			Image img = new Bitmap(16, 16);

			Graphics g = Graphics.FromImage(img);
			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.PixelOffsetMode = PixelOffsetMode.HighQuality;
			g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

			g.FillEllipse(new SolidBrush(c), 2, 2, 12, 12);
			if (c == Color.White)
				g.DrawEllipse(Pens.Black, 2, 2, 12, 12);

			CombatList.SmallImageList.Images.Add(img);
			lvi.ImageIndex = CombatList.SmallImageList.Images.Count - 1;
		}

		void add_condition_hint(ListViewItem lvi)
		{
			if (lvi.ImageIndex == -1)
				return;

			Image img = CombatList.SmallImageList.Images[lvi.ImageIndex];

			Graphics g = Graphics.FromImage(img);
			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.PixelOffsetMode = PixelOffsetMode.HighQuality;
			g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

			g.FillEllipse(Brushes.White, 5, 5, 6, 6);
			g.DrawEllipse(Pens.DarkGray, 5, 5, 6, 6);

			CombatList.SmallImageList.Images[lvi.ImageIndex] = img;
		}

		void add_initiative_hint(ListViewItem lvi)
		{
			if (lvi.ImageIndex == -1)
				return;

			Image img = CombatList.SmallImageList.Images[lvi.ImageIndex];

			Graphics g = Graphics.FromImage(img);
			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.PixelOffsetMode = PixelOffsetMode.HighQuality;
			g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

			Pen p = new Pen(Color.Blue, 3);
			g.DrawRectangle(p, 0, 0, 16, 16);

			CombatList.SmallImageList.Images[lvi.ImageIndex] = img;
		}

		void update_log()
		{
			string html = EncounterLogView(false);
			LogBrowser.Document.OpenNew(true);
			LogBrowser.Document.Write(html);
		}

		void update_preview_panel()
		{
			string html = "";

			html += "<HTML>";
			html += HTML.Concatenate(HTML.GetHead("", "", DisplaySize.Small));
			html += "<BODY>";

			if (fCombatStarted)
			{
				List<IToken> tokens = SelectedTokens;
				if (TwoColumnPreview)
				{
					// Remove the current actor, cos that'll be shown anyway

					List<IToken> obsolete = new List<IToken>();

					foreach (IToken token in tokens)
					{
						CreatureToken ct = token as CreatureToken;
						if ((ct != null) && (ct.Data.ID == fCurrentActor.ID))
							obsolete.Add(token);

						Hero hero = token as Hero;
						if ((hero != null) && (hero.ID == fCurrentActor.ID))
							obsolete.Add(token);
					}

					foreach (IToken token in obsolete)
						tokens.Remove(token);
				}

				if (TwoColumnPreview)
				{
					html += "<P class=table>";
					html += "<TABLE class=clear>";
					html += "<TR class=clear>";
					html += "<TD class=clear>";

					EncounterSlot slot = fEncounter.FindSlot(fCurrentActor);
					if (slot != null)
						html += HTML.StatBlock(slot.Card, fCurrentActor, fEncounter, false, true, true, CardMode.Combat, DisplaySize.Small);

					Hero hero = Session.Project.FindHero(fCurrentActor.ID);
					if (hero != null)
					{
						bool show_effects = (tokens.Count != 0);
						html += HTML.StatBlock(hero, fEncounter, false, true, show_effects, DisplaySize.Small);
					}

					Trap trap = fEncounter.FindTrap(fCurrentActor.ID);
					if (trap != null)
						html += HTML.Trap(trap, fCurrentActor, false, true, false, DisplaySize.Small);

					html += "</TD>";
					html += "<TD class=clear>";
				}

				string statblock = "";
				if (tokens.Count != 0)
				{
					statblock = html_tokens(tokens);
				}
				else if (SelectedTrap != null)
				{
					statblock = html_trap();
				}
				else if (SelectedChallenge != null)
				{
					statblock = html_skill_challenge();
				}

				if (statblock != "")
					html += statblock;
				else
					html += html_encounter_overview();

				if (TwoColumnPreview)
				{
					html += "</TD>";
					html += "</TR>";
					html += "</TABLE>";
					html += "</P>";
				}
			}
			else
			{
				html += html_encounter_start();
			}

			html += "</BODY>";
			html += "</HTML>";

			Preview.Document.OpenNew(true);
			Preview.Document.Write(html);
		}

		void update_maps()
		{
			MapView.Invalidate();

			if (PlayerMap != null)
				PlayerMap.Invalidate();
		}

		void update_statusbar()
		{
			int xp = fEncounter.GetXP() + fRemovedCreatureXP;
			XPLbl.Text = xp + " XP";

			int count = 0;
			foreach (Hero hero in Session.Project.Heroes)
			//foreach (Guid hero_id in fHeroData.Keys)
			{
				if (hero.CombatData.Initiative != int.MinValue)
					count += 1;
			}
			if (count > 1)
				XPLbl.Text += " (" + (xp / count) + " XP each)";

			int level = fEncounter.GetLevel(count);
			LevelLbl.Text = (level != -1) ? "Encounter Level: " + level : "";
		}

		#endregion

		#region Quick effects

		void add_quick_effect(OngoingCondition effect)
		{
			string effect_str = effect.ToString(fEncounter, false);

			foreach (OngoingCondition oc in fEffects)
			{
				if (oc.ToString(fEncounter, false) == effect_str)
					return;
			}

			fEffects.Add(effect.Copy());
			fEffects.Sort();
		}

		void update_effects_list(ToolStripDropDownItem tsddi, bool use_list_selection)
		{
			tsddi.DropDownItems.Clear();

			// Add effects for each standard condition
			ToolStripMenuItem tsmi_std = new ToolStripMenuItem("Standard Conditions");
			tsddi.DropDownItems.Add(tsmi_std);

			foreach (string con in Conditions.GetConditions())
			{
				OngoingCondition effect = new OngoingCondition();
				effect.Data = con;
				effect.Duration = DurationType.Encounter;

				ToolStripMenuItem tsmi_effect = new ToolStripMenuItem(effect.ToString(fEncounter, false));
				tsmi_effect.Tag = effect;
				if (use_list_selection)
					tsmi_effect.Click += new EventHandler(apply_quick_effect_from_toolbar);
				else
					tsmi_effect.Click += new EventHandler(apply_quick_effect_from_map);
				tsmi_std.DropDownItems.Add(tsmi_effect);
			}

			tsddi.DropDownItems.Add(new ToolStripSeparator());			

			// Add effects for each PC
			bool added_hero_effect = false;
			foreach (Hero hero in Session.Project.Heroes)
			{
				if (hero.Effects.Count != 0)
				{
					ToolStripMenuItem tsmi_hero = new ToolStripMenuItem(hero.Name);
					tsddi.DropDownItems.Add(tsmi_hero);

					foreach (OngoingCondition effect in hero.Effects)
					{
						ToolStripMenuItem tsmi_hero_effect = new ToolStripMenuItem(effect.ToString(fEncounter, false));
						tsmi_hero_effect.Tag = effect.Copy();
						if (use_list_selection)
							tsmi_hero_effect.Click += new EventHandler(apply_quick_effect_from_toolbar);
						else
							tsmi_hero_effect.Click += new EventHandler(apply_quick_effect_from_map);
						tsmi_hero.DropDownItems.Add(tsmi_hero_effect);

						added_hero_effect = true;
					}
				}
			}

			if (added_hero_effect)
				tsddi.DropDownItems.Add(new ToolStripSeparator());

			// Add defined quick effects
			foreach (OngoingCondition oc in fEffects)
			{
				ToolStripMenuItem tsmi_quick = new ToolStripMenuItem(oc.ToString(fEncounter, false));
				tsmi_quick.Tag = oc.Copy();
				if (use_list_selection)
					tsmi_quick.Click += new EventHandler(apply_quick_effect_from_toolbar);
				else
					tsmi_quick.Click += new EventHandler(apply_quick_effect_from_map);
				tsddi.DropDownItems.Add(tsmi_quick);
			}

			if (fEffects.Count != 0)
				tsddi.DropDownItems.Add(new ToolStripSeparator());

			// Add other effect
			ToolStripMenuItem other_menu = new ToolStripMenuItem("Add a New Effect...");
			if (use_list_selection)
				other_menu.Click += new EventHandler(apply_effect_from_toolbar);
			else
				other_menu.Click += new EventHandler(apply_effect_from_map);
			tsddi.DropDownItems.Add(other_menu);
		}

		void update_remove_effect_list(ToolStripDropDownItem tsddi, bool use_list_selection)
		{
			tsddi.DropDownItems.Clear();

			List<IToken> tokens = use_list_selection ? SelectedTokens : MapView.SelectedTokens;

			if (tokens.Count != 1)
			{
				ToolStripMenuItem tsmi = new ToolStripMenuItem("(multiple selection)");
				tsmi.Enabled = false;
				tsddi.DropDownItems.Add(tsmi);

				return;
			}

			CombatData cd = null;

			CreatureToken ct = tokens[0] as CreatureToken;
			if (ct != null)
				cd = ct.Data;

			Hero hero = tokens[0] as Hero;
			if (hero != null)
			{
				//cd = fHeroData[hero.ID];
				cd = hero.CombatData;
			}

			if (cd != null)
			{
				foreach (OngoingCondition oc in cd.Conditions)
				{
					ToolStripMenuItem tsmi = new ToolStripMenuItem(oc.ToString(fEncounter, false));
					tsmi.Tag = oc;
					if (use_list_selection)
						tsmi.Click += new EventHandler(remove_effect_from_list);
					else
						tsmi.Click += new EventHandler(remove_effect_from_map);
					tsddi.DropDownItems.Add(tsmi);
				}
			}

			if (tsddi.DropDownItems.Count == 0)
			{
				ToolStripMenuItem tsmi = new ToolStripMenuItem("(no effects)");
				tsmi.Enabled = false;
				tsddi.DropDownItems.Add(tsmi);
			}
		}

		void apply_quick_effect_from_toolbar(object sender, EventArgs e)
		{
			ToolStripItem tsi = sender as ToolStripItem;
			OngoingCondition oc = tsi.Tag as OngoingCondition;
			if (oc == null)
				return;

			apply_effect(oc.Copy(), SelectedTokens, false);
		}

		void apply_quick_effect_from_map(object sender, EventArgs e)
		{
			ToolStripItem tsi = sender as ToolStripItem;
			OngoingCondition oc = tsi.Tag as OngoingCondition;
			if (oc == null)
				return;

			apply_effect(oc.Copy(), MapView.SelectedTokens, false);
		}

		void apply_effect_from_toolbar(object sender, EventArgs e)
		{
			OngoingCondition oc = new OngoingCondition();

			EffectForm dlg = new EffectForm(oc, fEncounter, fCurrentActor, fCurrentRound);
			if (dlg.ShowDialog() == DialogResult.OK)
				apply_effect(dlg.Effect, SelectedTokens, true);
		}

		void apply_effect_from_map(object sender, EventArgs e)
		{
			OngoingCondition oc = new OngoingCondition();

			EffectForm dlg = new EffectForm(oc, fEncounter, fCurrentActor, fCurrentRound);
			if (dlg.ShowDialog() == DialogResult.OK)
				apply_effect(dlg.Effect, MapView.SelectedTokens, true);
		}

		void apply_effect(OngoingCondition oc, List<IToken> tokens, bool add_to_quick_list)
		{
			try
			{
				if ((oc.Duration == DurationType.BeginningOfTurn) || (oc.Duration == DurationType.EndOfTurn))
				{
					if (oc.DurationCreatureID == Guid.Empty)
					{
						// Choose a creature
						CombatantSelectForm dlg = new CombatantSelectForm(fEncounter, fTrapData);
						if (dlg.ShowDialog() == DialogResult.OK)
						{
							if (dlg.SelectedCombatant != null)
								oc.DurationCreatureID = dlg.SelectedCombatant.ID;
							else
								return;
						}
					}

					oc.DurationRound = fCurrentRound;
					if ((fCurrentActor != null) && (oc.DurationCreatureID == fCurrentActor.ID))
						oc.DurationRound += 1;
				}

				foreach (IToken token in tokens)
				{
					CreatureToken ct = token as CreatureToken;
					if (ct != null)
					{
						CombatData cd = ct.Data;
						cd.Conditions.Add(oc.Copy());

						fLog.AddEffectEntry(cd.ID, oc.ToString(fEncounter, false), true);
					}

					Hero hero = token as Hero;
					if (hero != null)
					{
						//CombatData cd = fHeroData[hero.ID];
						CombatData cd = hero.CombatData;
						cd.Conditions.Add(oc.Copy());

						fLog.AddEffectEntry(cd.ID, oc.ToString(fEncounter, false), true);
					}
				}

				if (add_to_quick_list)
				{
					bool added_to_hero = false;
					OngoingCondition copy = oc.Copy();

					if (Session.Project.Heroes.Count != 0)
					{
						Hero selected_hero = Session.Project.FindHero(fCurrentActor.ID);
						HeroSelectForm dlg = new HeroSelectForm(selected_hero);
						if (dlg.ShowDialog() == DialogResult.OK)
						{
							if (dlg.SelectedHero != null)
							{
								// If it refers to someone in this encounter, make it generic
								if (copy.DurationCreatureID != dlg.SelectedHero.ID)
									copy.DurationCreatureID = Guid.Empty;

								dlg.SelectedHero.Effects.Add(copy);
								Session.Modified = true;
								added_to_hero = true;
							}
						}
					}

					if (!added_to_hero)
						add_quick_effect(copy);
				}

				update_list();
				update_log();
				update_preview_panel();
				MapView.MapChanged();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void remove_effect_from_list(object sender, EventArgs e)
		{
			ToolStripItem tsi = sender as ToolStripItem;
			OngoingCondition oc = tsi.Tag as OngoingCondition;
			if (oc == null)
				return;

			if (SelectedTokens.Count != 1)
				return;
			
			CombatData cd = null;

			CreatureToken ct = SelectedTokens[0] as CreatureToken;
			if (ct != null)
				cd = ct.Data;

			Hero hero = SelectedTokens[0] as Hero;
			if (hero != null)
			{
				//cd = fHeroData[hero.ID];
				cd = hero.CombatData;
			}

			if (cd == null)
				return;

			cd.Conditions.Remove(oc);
			fLog.AddEffectEntry(cd.ID, oc.ToString(fEncounter, false), false);

			update_list();
			update_log();
			update_preview_panel();
		}

		void remove_effect_from_map(object sender, EventArgs e)
		{
			ToolStripItem tsi = sender as ToolStripItem;
			OngoingCondition oc = tsi.Tag as OngoingCondition;
			if (oc == null)
				return;

			if (MapView.SelectedTokens.Count != 1)
				return;

			CombatData cd = null;

			CreatureToken ct = MapView.SelectedTokens[0] as CreatureToken;
			if (ct != null)
				cd = ct.Data;

			Hero hero = MapView.SelectedTokens[0] as Hero;
			if (hero != null)
			{
				//cd = fHeroData[hero.ID];
				cd = hero.CombatData;
			}

			if (cd == null)
				return;

			cd.Conditions.Remove(oc);
			fLog.AddEffectEntry(cd.ID, oc.ToString(fEncounter, false), false);

			update_list();
			update_log();
			update_preview_panel();
		}

		#endregion

		#region HTML helpers

		string html_tokens(List<IToken> tokens)
		{
			string html = "";

			if (tokens.Count == 1)
			{
				IToken token = tokens[0];
				html = html_token(token, true);
			}
			else
			{
				List<string> lines = new List<string>();

				//lines.Add("<HTML>");

				//lines.Add("<HEAD>");
				//lines.AddRange(HTML.GetStyle(DisplaySize.Small));
				//lines.Add("</HEAD>");

				//lines.Add("<BODY>");

				foreach (IToken token in tokens)
				{
					lines.Add(html_token(token, false));
				}

				//lines.Add("</BODY>");

				//lines.Add("</HTML>");

				html = HTML.Concatenate(lines);
			}

			return html;
		}

		string html_token(IToken token, bool full)
		{
			string html = "";

			if (token is Hero)
			{
				Hero hero = token as Hero;
				//CombatData cd = fHeroData[hero.ID];
				CombatData cd = hero.CombatData;

				if ((TwoColumnPreview) && (cd == fCurrentActor))
					html = "";
				else
					html = HTML.StatBlock(hero, fEncounter, false, false, false, DisplaySize.Small);
			}

			if (token is CreatureToken)
			{
				CreatureToken ct = token as CreatureToken;
				EncounterSlot slot = fEncounter.FindSlot(ct.SlotID);
				CombatData cd = ct.Data;

				if ((TwoColumnPreview) && (cd == fCurrentActor))
					html = "";
				else
					html = HTML.StatBlock(slot.Card, ct.Data, fEncounter, false, false, full, CardMode.Combat, DisplaySize.Small);
			}

			if (token is CustomToken)
			{
				CustomToken ct = token as CustomToken;
				bool drag = ((fEncounter.MapID != Guid.Empty) && (ct.Data.Location == CombatData.NoPoint));

				html = HTML.CustomMapToken(ct, drag, false, DisplaySize.Small);
			}

			return html;
		}

		string html_trap()
		{
			CombatData cd = null;

			if (fTrapData.ContainsKey(SelectedTrap.ID))
			{
				cd = fTrapData[SelectedTrap.ID];
				if ((TwoColumnPreview) && (cd == fCurrentActor))
					return "";
			}

			return HTML.Trap(SelectedTrap, cd, false, false, false, DisplaySize.Small);
		}

		string html_skill_challenge()
		{
			return HTML.SkillChallenge(SelectedChallenge, true, false, DisplaySize.Small);
		}

		string html_encounter_start()
		{
			List<string> lines = new List<string>();

			lines.Add("<P class=table>");
			lines.Add("<TABLE>");

			lines.Add("<TR class=heading>");
			lines.Add("<TD>");
			lines.Add("<B>Starting the Encounter</B>");
			lines.Add("</TD>");
			lines.Add("</TR>");

			#region Initiative

			string AUTOMATIC = "automatically";
			string MANUAL = "manually";
			string INDIVIDUAL = "individually";
			string GROUP = "in groups";
			string ROLLED = "calculated automatically";
			string ENTERED = "entered manually";
			string INGROUPS = " (grouped by type)";

			lines.Add("<TR class=shaded>");
			lines.Add("<TD>");
			lines.Add("<B>How do you want to roll initiative?</B>");
			lines.Add("</TD>");
			lines.Add("</TR>");

			if (Session.Project.Heroes.Count != 0)
			{
				string mode = "";
				string auto = AUTOMATIC;
				string manual = MANUAL;
				switch (Session.Preferences.HeroInitiativeMode)
				{
					case InitiativeMode.AutoIndividual:
					case InitiativeMode.AutoGroup:
						mode = ROLLED;
						manual = "<A href=heroinit:manual>" + manual + "</A>";
						break;
					case InitiativeMode.ManualIndividual:
					case InitiativeMode.ManualGroup:
						mode = ENTERED;
						auto = "<A href=heroinit:auto>" + auto + "</A>";
						break;
				}

				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("For <B>PCs</B>: " + mode);
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD class=indent>");
				lines.Add(auto + " / " + manual);
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			if (fEncounter.Count != 0)
			{
				string mode = "";
				string auto = AUTOMATIC;
				string manual = MANUAL;
				string individual = INDIVIDUAL;
				string group = GROUP;
				switch (Session.Preferences.InitiativeMode)
				{
					case InitiativeMode.AutoIndividual:
						mode = ROLLED;
						manual = "<A href=creatureinit:manual>" + manual + "</A>";
						group = "<A href=creatureinit:group>" + group + "</A>";
						break;
					case InitiativeMode.AutoGroup:
						mode = ROLLED + INGROUPS;
						manual = "<A href=creatureinit:manual>" + manual + "</A>";
						individual = "<A href=creatureinit:individual>" + individual + "</A>";
						break;
					case InitiativeMode.ManualIndividual:
						mode = ENTERED;
						auto = "<A href=creatureinit:auto>" + auto + "</A>";
						group = "<A href=creatureinit:group>" + group + "</A>";
						break;
					case InitiativeMode.ManualGroup:
						mode = ENTERED + INGROUPS;
						auto = "<A href=creatureinit:auto>" + auto + "</A>";
						individual = "<A href=creatureinit:individual>" + individual + "</A>";
						break;
				}

				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("For <B>creatures</B>: " + mode);
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD class=indent>");
				lines.Add(auto + " / " + manual);
				lines.Add("</TD>");
				lines.Add("</TR>");

				bool groups = false;
				foreach (EncounterSlot slot in fEncounter.AllSlots)
				{
					if (slot.CombatData.Count > 1)
					{
						groups = true;
						break;
					}
				}

				if (groups)
				{
					lines.Add("<TR>");
					lines.Add("<TD class=indent>");
					lines.Add(individual + " / " + group);
					lines.Add("</TD>");
					lines.Add("</TR>");
				}
			}

			bool traps_with_init = false;
			foreach (Trap trap in fEncounter.Traps)
			{
				if (trap.Initiative != int.MinValue)
				{
					traps_with_init = true;
					break;
				}
			}

			if (traps_with_init)
			{
				string mode = "";
				string auto = AUTOMATIC;
				string manual = MANUAL;
				switch (Session.Preferences.TrapInitiativeMode)
				{
					case InitiativeMode.AutoIndividual:
					case InitiativeMode.AutoGroup:
						mode = ROLLED;
						manual = "<A href=trapinit:manual>" + manual + "</A>";
						break;
					case InitiativeMode.ManualIndividual:
					case InitiativeMode.ManualGroup:
						mode = ENTERED;
						auto = "<A href=trapinit:auto>" + auto + "</A>";
						break;
				}

				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("For <B>traps</B>: " + mode);
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD class=indent>");
				lines.Add(auto + " / " + manual);
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			#endregion

			lines.Add("<TR class=shaded>");
			lines.Add("<TD>");
			lines.Add("<B>Preparing for the encounter</B>");
			lines.Add("</TD>");
			lines.Add("</TR>");

			lines.Add("<TR>");
			lines.Add("<TD>");
			lines.Add("<A href=combat:hp>Update PC hit points</A>");
			lines.Add("- if they've healed or taken damage since their last encounter");
			lines.Add("</TD>");
			lines.Add("</TR>");

			lines.Add("<TR>");
			lines.Add("<TD>");
			lines.Add("<A href=combat:rename>Rename combatants</A>");
			lines.Add("- if you need to indicate which mini is which creature");
			lines.Add("</TD>");
			lines.Add("</TR>");

			if (fEncounter.MapID != Guid.Empty)
			{
				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("Place PCs on the map - drag PCs from the list into their starting positions on the map");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			lines.Add("<TR class=shaded>");
			lines.Add("<TD>");
			lines.Add("<B>Everything ready?</B>");
			lines.Add("</TD>");
			lines.Add("</TR>");
			lines.Add("<TR>");
			lines.Add("<TD>");
			lines.Add("<A href=combat:start>Click here to roll initiative and start the encounter!</A>");
			lines.Add("</TD>");
			lines.Add("</TR>");

			lines.Add("</TABLE>");
			lines.Add("</P>");

			return HTML.Concatenate(lines);
		}

		string html_encounter_overview()
		{
			List<string> lines = new List<string>();

			lines.Add("<P class=instruction>Select a combatant from the list to see its stat block here.</P>");
			lines.Add("<P class=instruction></P>");

			List<EncounterCard> with_auras = new List<EncounterCard>();
			List<EncounterCard> with_tactics = new List<EncounterCard>();
			List<EncounterCard> with_reactions = new List<EncounterCard>();
			foreach (EncounterSlot slot in fEncounter.AllSlots)
			{
				if (slot.Card.Auras.Count != 0)
					with_auras.Add(slot.Card);

				if (slot.Card.Tactics != "")
					with_tactics.Add(slot.Card);

				bool has_reactions = false;
				List<CreaturePower> powers = slot.Card.CreaturePowers;
				foreach (CreaturePower cp in powers)
				{
					if ((cp.Action != null) && (cp.Action.Trigger != ""))
						has_reactions = true;
				}
				if (has_reactions)
					with_reactions.Add(slot.Card);
			}

			if ((with_auras.Count != 0) || (with_tactics.Count != 0) || (with_reactions.Count != 0))
			{
				lines.Add("<P class=table>");

				lines.Add("<TABLE>");

				lines.Add("<TR class=heading>");
				lines.Add("<TD>");
				lines.Add("<B>Remember</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				if (with_auras.Count != 0)
				{
					lines.Add("<TR class=shaded>");
					lines.Add("<TD>");
					lines.Add("<B>Auras</B>");
					lines.Add("</TD>");
					lines.Add("</TR>");

					foreach (EncounterCard card in with_auras)
					{
						lines.Add("<TR>");
						lines.Add("<TD>");
						lines.Add("<B>" + card.Title + "</B>");
						lines.Add("</TD>");
						lines.Add("</TR>");

						foreach (Aura aura in card.Auras)
						{
							lines.Add("<TR>");
							lines.Add("<TD class=indent>");
							lines.Add("<B>" + aura.Name + "</B>: " + aura.Details);
							lines.Add("</TD>");
							lines.Add("</TR>");
						}
					}
				}

				if (with_tactics.Count != 0)
				{
					lines.Add("<TR class=shaded>");
					lines.Add("<TD>");
					lines.Add("<B>Tactics</B>");
					lines.Add("</TD>");
					lines.Add("</TR>");

					foreach (EncounterCard card in with_tactics)
					{
						lines.Add("<TR>");
						lines.Add("<TD class=indent>");
						lines.Add("<B>" + card.Title + "</B>: " + card.Tactics);
						lines.Add("</TD>");
						lines.Add("</TR>");
					}
				}

				if (with_reactions.Count != 0)
				{
					lines.Add("<TR class=shaded>");
					lines.Add("<TD>");
					lines.Add("<B>Triggered Powers</B>");
					lines.Add("</TD>");
					lines.Add("</TR>");

					foreach (EncounterCard card in with_reactions)
					{
						lines.Add("<TR>");
						lines.Add("<TD>");
						lines.Add("<B>" + card.Title + "</B>:");
						lines.Add("</TD>");
						lines.Add("</TR>");

						List<CreaturePower> powers = card.CreaturePowers;
						foreach (CreaturePower power in powers)
						{
							if ((power.Action == null) || (power.Action.Trigger == ""))
								continue;

							lines.Add("<TR>");
							lines.Add("<TD class=indent>");
							lines.Add("<B>" + power.Name + "</B>: " + power.Action.Trigger);
							lines.Add("</TD>");
							lines.Add("</TR>");
						}
					}
				}

				lines.Add("</TABLE>");
				lines.Add("</P>");
			}

			if (fEncounter.MapAreaID != Guid.Empty)
			{
				MapArea area = MapView.Map.FindArea(fEncounter.MapAreaID);
				if ((area != null) && (area.Details != ""))
				{
					lines.Add("<P class=encounter_note><B>" + HTML.Process(area.Name, true) + "</B>:</P>");
					lines.Add("<P class=encounter_note>" + HTML.Process(area.Details, true) + "</P>");
				}
			}

			foreach (EncounterNote note in fEncounter.Notes)
			{
				if (note.Contents == "")
					continue;

				lines.Add("<P class=encounter_note><B>" + HTML.Process(note.Title, true) + "</B>:</P>");
				lines.Add("<P class=encounter_note>" + HTML.Process(note.Contents, false) + "</P>");
			}

			return HTML.Concatenate(lines);
		}

		public string InitiativeView()
		{
			List<ListViewItem> items = new List<ListViewItem>();
			foreach (ListViewItem lvi in CombatList.Groups[0].Items)
				items.Add(lvi);
			items.Sort(CombatList.ListViewItemSorter as IComparer<ListViewItem>);

			List<string> lines = new List<string>();
			List<string> previous = new List<string>();

			bool active = false;

			lines.AddRange(HTML.GetHead(null, null, PlayerViewForm.DisplaySize));

			lines.Add("<BODY bgcolor=black>");

			lines.Add("<P class=table>");
			lines.Add("<TABLE class=initiative>");
			foreach (ListViewItem lvi in items)
			{
				CombatData cd = null;
				string name = "";

				if (lvi.Tag is CreatureToken)
				{
					CreatureToken ct = lvi.Tag as CreatureToken;
					cd = ct.Data;

					name = cd.DisplayName;
					if (!Session.Preferences.PlayerViewCreatureLabels)
					{
						EncounterSlot slot = fEncounter.FindSlot(ct.SlotID);
						ICreature creature = Session.FindCreature(slot.Card.CreatureID, SearchType.Global);

						name = creature.Category;
						if (name == "")
							name = "Creature";
					}
				}

				if (lvi.Tag is Trap)
				{
					Trap trap = lvi.Tag as Trap;
					if (trap.Initiative != int.MinValue)
					{
						cd = fTrapData[trap.ID];

						name = cd.DisplayName;
						if (!Session.Preferences.PlayerViewCreatureLabels)
							name = trap.Type.ToString();
					}
				}

				if (lvi.Tag is Hero)
				{
					Hero hero = lvi.Tag as Hero;
					//cd = fHeroData[hero.ID];
					cd = hero.CombatData;

					name = hero.Name;
				}

				if (lvi.Tag is CustomToken)
				{
					CustomToken ct = lvi.Tag as CustomToken;
					cd = ct.Data;

					name = cd.DisplayName;
				}

				if (cd != null)
				{
					if (!cd.Visible)
						continue;

					if (cd.Initiative == int.MinValue)
						continue;

					string colour = "white";
					if (cd == fCurrentActor)
					{
						active = true;

						//colour = "white";
						name = "<B>" + name + "</B>";
					}
					EncounterSlot slot = fEncounter.FindSlot(cd);
					if (slot != null)
					{
						CreatureState state = slot.GetState(cd);
						switch (state)
						{
							case CreatureState.Bloodied:
								colour = "red";
								break;
							case CreatureState.Defeated:
								colour = "darkgrey";
								name = "<S>" + name + "</S>";
								break;
						}
					}
					string text = "<FONT color=" + colour + ">" + name + "</FONT>";

					if (cd.Conditions.Count != 0)
					{
						string conditions = "";
						foreach (OngoingCondition oc in cd.Conditions)
						{
							if (conditions != "")
								conditions += "; ";

							conditions += oc.ToString(fEncounter, true);
						}

						text += "<BR><FONT color=grey>" + conditions + "</FONT>";
					}

					List<string> list = active ? lines : previous;

					list.Add("<TR>");
					list.Add("<TD align=center bgcolor=black width=50><FONT color=lightgrey>" + cd.Initiative + "</FONT></TD>");
					list.Add("<TD bgcolor=black>" + text + "</TD>");
					list.Add("</TR>");
				}
			}
			lines.AddRange(previous);
			lines.Add("</TABLE>");
			lines.Add("</P>");

			lines.Add("<HR>");

			lines.Add(EncounterLogView(true));

			lines.Add("</BODY>");
			lines.Add("</HTML>");

			return HTML.Concatenate(lines);
		}

		public string EncounterLogView(bool player_view)
		{
			List<string> lines = new List<string>();

			if (!player_view)
			{
				lines.AddRange(HTML.GetHead("Encounter Log", "", DisplaySize.Small));
				lines.Add("<BODY>");
			}

			if (fLog != null)
			{
				lines.Add("<P class=table>");
				lines.Add("<TABLE class=wide>");

				lines.Add("<TR class=encounterlog>");
				lines.Add("<TD colspan=2>");
				lines.Add("<B>Encounter Log</B>");
				lines.Add("</TD>");
				lines.Add("<TD align=right>");
				lines.Add("<B>Round " + fCurrentRound + "</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				if (!fLog.Active)
				{
					lines.Add("<TR class=warning>");
					lines.Add("<TD colspan=3>");
					lines.Add("The log is not yet active as the encounter has not started.");
					lines.Add("</TD>");
					lines.Add("</TR>");
				}

				EncounterReport report = fLog.CreateReport(fEncounter, !player_view);
				foreach (RoundLog round in report.Rounds)
				{
					lines.Add("<TR class=shaded>");
					if (player_view)
						lines.Add("<TD class=pvlogentry colspan=3>");
					else
						lines.Add("<TD colspan=3>");
					lines.Add("<B>Round " + round.Round + "</B>");
					lines.Add("</TD>");
					lines.Add("</TR>");

					if (round.Count == 0)
					{
						lines.Add("<TR>");
						if (player_view)
							lines.Add("<TD class=pvlogentry align=center colspan=3>");
						else
							lines.Add("<TD align=center colspan=3>");
						lines.Add("(nothing)");
						lines.Add("</TD>");
						lines.Add("</TR>");
					}

					bool detailed_names = !player_view || Session.Preferences.PlayerViewCreatureLabels;

					foreach (TurnLog turn in round.Turns)
					{
						if (turn.Entries.Count == 0)
							continue;

						lines.Add("<TR>");
						if (player_view)
							lines.Add("<TD class=pvlogentry colspan=3>");
						else
							lines.Add("<TD colspan=2>");
						lines.Add("<B>" + EncounterLog.GetName(turn.ID, fEncounter, detailed_names) + "</B>");
						lines.Add("</TD>");
						if (!player_view)
						{
							lines.Add("<TD align=right>");
							lines.Add(turn.Start.ToString("h:mm:ss"));
							lines.Add("</TD>");
						}
						lines.Add("</TR>");

						foreach (IEncounterLogEntry entry in turn.Entries)
						{
							lines.Add("<TR>");
							if (player_view)
								lines.Add("<TD class=pvlogindent colspan=3>");
							else
								lines.Add("<TD class=indent colspan=3>");
							lines.Add(entry.Description(fEncounter, detailed_names));
							lines.Add("</TD>");
							lines.Add("</TR>");
						}
					}
				}

				lines.Add("</TABLE>");
				lines.Add("</P>");
			}

			if (!player_view)
			{
				lines.Add("</BODY>");
				lines.Add("</HTML>");
			}

			return HTML.Concatenate(lines);
		}

		#endregion
	}
}
