using System;
using System.Collections.Generic;
using System.Drawing;

using Masterplan.Controls;
using Masterplan.Tools;
using Masterplan.UI;

namespace Masterplan
{
    /// <summary>
    /// Class used to store user settings.
    /// </summary>
	[Serializable]
    public class Preferences
	{
		/// <summary>
		/// Gets or sets the last file to be opened.
		/// </summary>
		public string LastFile
		{
			get { return fLastFile; }
			set { fLastFile = value; }
		}
		string fLastFile = "";

		#region Window

		/// <summary>
		/// Gets or sets whether the application is maximised.
		/// </summary>
		public bool Maximised
		{
			get { return fMaximised; }
			set { fMaximised = value; }
		}
		bool fMaximised = false;

		/// <summary>
		/// Gets or sets the size of the application main form.
		/// </summary>
		public Size Size
		{
			get { return fSize; }
			set { fSize = value; }
		}
		Size fSize = Size.Empty;

		/// <summary>
		/// Gets or sets the location of the application main form.
		/// </summary>
		public Point Location
		{
			get { return fLocation; }
			set { fLocation = value; }
		}
		Point fLocation = Point.Empty;

		#endregion

		#region Workspace

		/// <summary>
		/// Gets or sets whether the plot navigation panel is shown.
		/// </summary>
		public bool ShowNavigation
		{
			get { return fNavigation; }
			set { fNavigation = value; }
		}
		bool fNavigation = false;

		/// <summary>
		/// Gets or sets whether the plot preview panel is shown.
		/// </summary>
		public bool ShowPreview
		{
			get { return fPreview; }
			set { fPreview = value; }
		}
		bool fPreview = true;

		/// <summary>
		/// Gets or sets how plot point links are drawn.
		/// </summary>
		public PlotViewLinkStyle LinkStyle
		{
			get { return fLinkStyle; }
			set { fLinkStyle = value; }
		}
		PlotViewLinkStyle fLinkStyle = PlotViewLinkStyle.Curved;

        #endregion

		/// <summary>
		/// Gets or sets the text size for the application.
		/// </summary>
		public DisplaySize TextSize { get; set; } = DisplaySize.Small;

		/// <summary>
		/// Gets or sets the text size for the player view.
		/// </summary>
		public DisplaySize PlayerViewTextSize { get; set; } = DisplaySize.Small;

		/// <summary>
		/// Gets or sets whether the XP calculation sums all plot points.
		/// </summary>
		public bool AllXP
		{
			get { return fAllXP; }
			set { fAllXP = value; }
		}
		bool fAllXP = true;

        #region Map builder

        /// <summary>
        /// Gets or sets the default map builder tile view mode.
        /// </summary>
        public TileView TileView
        {
            get { return fTileView; }
            set { fTileView = value; }
        }
        TileView fTileView = TileView.Size;

        /// <summary>
        /// Gets or sets the default map builder tile size.
        /// </summary>
        public TileSize TileSize
        {
            get { return fTileSize; }
            set { fTileSize = value; }
        }
        TileSize fTileSize = TileSize.Medium;

        #endregion

		/// <summary>
		/// Gets or sets the list of tile libraries which are selected in the mapper.
		/// </summary>
		public List<Guid> TileLibraries
		{
			get { return fTileLibraries; }
			set { fTileLibraries = value; }
		}
		List<Guid> fTileLibraries = new List<Guid>();

        #region Combat

		/// <summary>
		/// Gets or sets the combat initiative mode for creatures.
		/// </summary>
		public InitiativeMode InitiativeMode
		{
			get { return fInitiativeMode; }
			set { fInitiativeMode = value; }
		}
		InitiativeMode fInitiativeMode = InitiativeMode.AutoGroup;

		/// <summary>
		/// Gets or sets the combat initiative mode for PCs.
		/// </summary>
		public InitiativeMode HeroInitiativeMode
		{
			get { return fHeroInitiativeMode; }
			set { fHeroInitiativeMode = value; }
		}
		InitiativeMode fHeroInitiativeMode = InitiativeMode.ManualIndividual;

		/// <summary>
		/// Gets or sets the combat initiative mode for traps.
		/// </summary>
		public InitiativeMode TrapInitiativeMode
		{
			get { return fTrapInitiativeMode; }
			set { fTrapInitiativeMode = value; }
		}
		InitiativeMode fTrapInitiativeMode = InitiativeMode.AutoIndividual;

		/// <summary>
		/// Gets or sets whether creatures are removed from combat when reduced to 0 HP.
		/// </summary>
		public bool CreatureAutoRemove
		{
			get { return fCreatureAutoRemove; }
			set { fCreatureAutoRemove = value; }
		}
		bool fCreatureAutoRemove = true;

		/// <summary>
		/// Gets or sets whether the combat view starts with two columns when there is a combat map.
		/// </summary>
		public bool CombatTwoColumns
		{
			get { return fCombatTwoColumns; }
			set { fCombatTwoColumns = value; }
		}
		bool fCombatTwoColumns = false;

		/// <summary>
		/// Gets or sets whether the combat view starts with two columns when there is no map.
		/// </summary>
		public bool CombatTwoColumnsNoMap
		{
			get { return fCombatTwoColumnsNoMap; }
			set { fCombatTwoColumnsNoMap = value; }
		}
		bool fCombatTwoColumnsNoMap = true;

		/// <summary>
		/// Gets or sets whether the combat map should be shown on the right (true) or at the bottom (false).
		/// </summary>
		public bool CombatMapRight
		{
			get { return fCombatMapRight; }
			set { fCombatMapRight = value; }
		}
		bool fCombatMapRight = true;

        /// <summary>
        /// Gets or sets the combat map fog of war setting.
        /// </summary>
        public CreatureViewMode CombatFog
        {
            get { return fCombatFog; }
            set { fCombatFog = value; }
        }
        CreatureViewMode fCombatFog = CreatureViewMode.All;

        /// <summary>
        /// Gets or sets the player view tactical map fog of war setting.
        /// </summary>
        public CreatureViewMode PlayerViewFog
        {
            get { return fPlayerViewFog; }
            set { fPlayerViewFog = value; }
        }
        CreatureViewMode fPlayerViewFog = CreatureViewMode.Visible;

		/// <summary>
		/// Gets or sets whether the health bars are shown on the combat map.
		/// </summary>
		public bool CombatHealthBars
		{
			get { return fCombatHealthBars; }
			set { fCombatHealthBars = value; }
		}
		bool fCombatHealthBars = false;

		/// <summary>
		/// Gets or sets whether condition badges are shown on the player view tactical map.
		/// </summary>
		public bool PlayerViewConditionBadges
		{
			get { return fPlayerViewConditionBadges; }
			set { fPlayerViewConditionBadges = value; }
		}
		bool fPlayerViewConditionBadges = true;

		/// <summary>
		/// Gets or sets whether condition badges are shown on the combat map.
		/// </summary>
		public bool CombatConditionBadges
		{
			get { return fCombatConditionBadges; }
			set { fCombatConditionBadges = value; }
		}
		bool fCombatConditionBadges = true;

		/// <summary>
		/// Gets or sets whether the health bars are shown on the player view tactical map.
		/// </summary>
		public bool PlayerViewHealthBars
		{
			get { return fPlayerViewHealthBars; }
			set { fPlayerViewHealthBars = value; }
		}
		bool fPlayerViewHealthBars = false;

		/// <summary>
		/// Gets or sets whether the player view tactical map shows full creature labels.
		/// </summary>
		public bool PlayerViewCreatureLabels
		{
			get { return fCreatureLabels; }
			set { fCreatureLabels = value; }
		}
		bool fCreatureLabels = false;

		/// <summary>
		/// Gets or sets whether creature images are shown as tokens on the combat map.
		/// </summary>
		public bool CombatPictureTokens
		{
			get { return fCombatPictureTokens; }
			set { fCombatPictureTokens = value; }
		}
		bool fCombatPictureTokens = true;

		/// <summary>
		/// Gets or sets whether creature images are shown as tokens on the player map.
		/// </summary>
		public bool PlayerViewPictureTokens
		{
			get { return fPlayerViewPictureTokens; }
			set { fPlayerViewPictureTokens = value; }
		}
		bool fPlayerViewPictureTokens = true;

		/// <summary>
		/// Gets or sets whether the map is shown on the player view during combat.
		/// </summary>
		public bool PlayerViewMap
		{
			get { return fPlayerViewMap; }
			set { fPlayerViewMap = value; }
		}
		bool fPlayerViewMap = true;

		/// <summary>
		/// Gets or sets whether the initiative list is shown on the player view during combat.
		/// </summary>
		public bool PlayerViewInitiative
		{
			get { return fPlayerViewInitiative; }
			set { fPlayerViewInitiative = value; }
		}
		bool fPlayerViewInitiative = true;

		/// <summary>
		/// Gets or sets whether the grid is shown on the combat map.
		/// </summary>
		public bool CombatGrid
		{
			get { return fCombatGrid; }
			set { fCombatGrid = value; }
		}
		bool fCombatGrid = false;

		/// <summary>
		/// Gets or sets whether the grid is shown on the player map.
		/// </summary>
		public bool PlayerViewGrid
		{
			get { return fPlayerViewGrid; }
			set { fPlayerViewGrid = value; }
		}
		bool fPlayerViewGrid = false;

		/// <summary>
		/// Gets or sets whether grid labels are shown on the combat map.
		/// </summary>
		public bool CombatGridLabels
		{
			get { return fCombatGridLabels; }
			set { fCombatGridLabels = value; }
		}
		bool fCombatGridLabels = false;

		/// <summary>
		/// Gets or sets whether grid labels are shown on the player map.
		/// </summary>
		public bool PlayerViewGridLabels
		{
			get { return fPlayerViewGridLabels; }
			set { fPlayerViewGridLabels = value; }
		}
		bool fPlayerViewGridLabels = false;

		/// <summary>
		/// Gets or sets whether the combat list shows initiative scores.
		/// </summary>
		public bool CombatColumnInitiative
		{
			get { return fCombatColumnInitiative; }
			set { fCombatColumnInitiative = value; }
		}
		bool fCombatColumnInitiative = true;

		/// <summary>
		/// Gets or sets whether the combat list shows hit points.
		/// </summary>
		public bool CombatColumnHP
		{
			get { return fCombatColumnHP; }
			set { fCombatColumnHP = value; }
		}
		bool fCombatColumnHP = true;

		/// <summary>
		/// Gets or sets whether the combat list shows defence scores.
		/// </summary>
		public bool CombatColumnDefences
		{
			get { return fCombatColumnDefences; }
			set { fCombatColumnDefences = value; }
		}
		bool fCombatColumnDefences = false;

		/// <summary>
		/// Gets or sets whether the combat list shows ongoing effects.
		/// </summary>
		public bool CombatColumnEffects
		{
			get { return fCombatColumnEffects; }
			set { fCombatColumnEffects = value; }
		}
		bool fCombatColumnEffects = false;

        #endregion
    }
}
