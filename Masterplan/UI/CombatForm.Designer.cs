namespace Masterplan.UI
{
	partial class CombatForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CombatForm));
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Combatants", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Delayed / Readied", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Traps", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Skill Challenges", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Custom Tokens and Overlays", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Not In Play", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("Defeated", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("Predefined", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup9 = new System.Windows.Forms.ListViewGroup("Custom Tokens", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup10 = new System.Windows.Forms.ListViewGroup("Custom Overlays", System.Windows.Forms.HorizontalAlignment.Left);
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.DetailsBtn = new System.Windows.Forms.ToolStripButton();
			this.DamageBtn = new System.Windows.Forms.ToolStripButton();
			this.HealBtn = new System.Windows.Forms.ToolStripButton();
			this.EffectMenu = new System.Windows.Forms.ToolStripDropDownButton();
			this.effectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
			this.NextInitBtn = new System.Windows.Forms.ToolStripButton();
			this.DelayBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.CombatantsBtn = new System.Windows.Forms.ToolStripDropDownButton();
			this.CombatantsAdd = new System.Windows.Forms.ToolStripMenuItem();
			this.CombatantsAddToken = new System.Windows.Forms.ToolStripMenuItem();
			this.CombatantsAddOverlay = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.CombatantsWaves = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator26 = new System.Windows.Forms.ToolStripSeparator();
			this.CombatantsRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
			this.CombatantsHideAll = new System.Windows.Forms.ToolStripMenuItem();
			this.CombatantsShowAll = new System.Windows.Forms.ToolStripMenuItem();
			this.MapMenu = new System.Windows.Forms.ToolStripDropDownButton();
			this.ShowMap = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			this.MapFog = new System.Windows.Forms.ToolStripMenuItem();
			this.MapFogAllCreatures = new System.Windows.Forms.ToolStripMenuItem();
			this.MapFogVisibleCreatures = new System.Windows.Forms.ToolStripMenuItem();
			this.MapFogHideCreatures = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
			this.MapLOS = new System.Windows.Forms.ToolStripMenuItem();
			this.MapGrid = new System.Windows.Forms.ToolStripMenuItem();
			this.MapGridLabels = new System.Windows.Forms.ToolStripMenuItem();
			this.MapHealth = new System.Windows.Forms.ToolStripMenuItem();
			this.MapConditions = new System.Windows.Forms.ToolStripMenuItem();
			this.MapPictureTokens = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.MapNavigate = new System.Windows.Forms.ToolStripMenuItem();
			this.MapReset = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.MapDrawing = new System.Windows.Forms.ToolStripMenuItem();
			this.MapClearDrawings = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
			this.MapPrint = new System.Windows.Forms.ToolStripMenuItem();
			this.MapExport = new System.Windows.Forms.ToolStripMenuItem();
			this.PlayerViewMapMenu = new System.Windows.Forms.ToolStripDropDownButton();
			this.PlayerViewMap = new System.Windows.Forms.ToolStripMenuItem();
			this.PlayerViewInitList = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.PlayerViewFog = new System.Windows.Forms.ToolStripMenuItem();
			this.PlayerFogAll = new System.Windows.Forms.ToolStripMenuItem();
			this.PlayerFogVisible = new System.Windows.Forms.ToolStripMenuItem();
			this.PlayerFogNone = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
			this.PlayerViewLOS = new System.Windows.Forms.ToolStripMenuItem();
			this.PlayerViewGrid = new System.Windows.Forms.ToolStripMenuItem();
			this.PlayerViewGridLabels = new System.Windows.Forms.ToolStripMenuItem();
			this.PlayerHealth = new System.Windows.Forms.ToolStripMenuItem();
			this.PlayerConditions = new System.Windows.Forms.ToolStripMenuItem();
			this.PlayerPictureTokens = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
			this.PlayerLabels = new System.Windows.Forms.ToolStripMenuItem();
			this.PlayerViewNoMapMenu = new System.Windows.Forms.ToolStripDropDownButton();
			this.PlayerViewNoMapShowInitiativeList = new System.Windows.Forms.ToolStripMenuItem();
			this.PlayerViewNoMapShowLabels = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsMenu = new System.Windows.Forms.ToolStripDropDownButton();
			this.ToolsEffects = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsLinks = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolsAddIns = new System.Windows.Forms.ToolStripMenuItem();
			this.addinsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OptionsMenu = new System.Windows.Forms.ToolStripDropDownButton();
			this.OptionsShowInit = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
			this.OneColumn = new System.Windows.Forms.ToolStripMenuItem();
			this.TwoColumns = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
			this.MapRight = new System.Windows.Forms.ToolStripMenuItem();
			this.MapBelow = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
			this.OptionsLandscape = new System.Windows.Forms.ToolStripMenuItem();
			this.OptionsPortrait = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolsAutoRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolsColumns = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsColumnsInit = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsColumnsHP = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsColumnsDefences = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsColumnsConditions = new System.Windows.Forms.ToolStripMenuItem();
			this.MapSplitter = new System.Windows.Forms.SplitContainer();
			this.Pages = new System.Windows.Forms.TabControl();
			this.CombatantsPage = new System.Windows.Forms.TabPage();
			this.ListSplitter = new System.Windows.Forms.SplitContainer();
			this.CombatList = new Masterplan.UI.CombatForm.CombatListControl();
			this.NameHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.InitHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.HPHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.DefHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.EffectsHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ListContext = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ListDetails = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
			this.ListDamage = new System.Windows.Forms.ToolStripMenuItem();
			this.ListHeal = new System.Windows.Forms.ToolStripMenuItem();
			this.ListCondition = new System.Windows.Forms.ToolStripMenuItem();
			this.effectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.ListRemoveEffect = new System.Windows.Forms.ToolStripMenuItem();
			this.effectToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.ListRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.ListRemoveMap = new System.Windows.Forms.ToolStripMenuItem();
			this.ListRemoveCombat = new System.Windows.Forms.ToolStripMenuItem();
			this.ListCreateCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.ListVisible = new System.Windows.Forms.ToolStripMenuItem();
			this.ListDelay = new System.Windows.Forms.ToolStripMenuItem();
			this.PreviewPanel = new System.Windows.Forms.Panel();
			this.Preview = new System.Windows.Forms.WebBrowser();
			this.TemplatesPage = new System.Windows.Forms.TabPage();
			this.TemplateList = new System.Windows.Forms.ListView();
			this.TemplateHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.LogPage = new System.Windows.Forms.TabPage();
			this.LogBrowser = new System.Windows.Forms.WebBrowser();
			this.MapView = new Masterplan.Controls.MapView();
			this.MapContext = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.MapDetails = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.MapDamage = new System.Windows.Forms.ToolStripMenuItem();
			this.MapHeal = new System.Windows.Forms.ToolStripMenuItem();
			this.MapAddEffect = new System.Windows.Forms.ToolStripMenuItem();
			this.effectToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.MapRemoveEffect = new System.Windows.Forms.ToolStripMenuItem();
			this.effectToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			this.MapSetPicture = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.MapRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.MapRemoveMap = new System.Windows.Forms.ToolStripMenuItem();
			this.MapRemoveCombat = new System.Windows.Forms.ToolStripMenuItem();
			this.MapCreateCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.MapVisible = new System.Windows.Forms.ToolStripMenuItem();
			this.MapDelay = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
			this.MapContextDrawing = new System.Windows.Forms.ToolStripMenuItem();
			this.MapContextClearDrawings = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator25 = new System.Windows.Forms.ToolStripSeparator();
			this.MapContextLOS = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator24 = new System.Windows.Forms.ToolStripSeparator();
			this.MapContextOverlay = new System.Windows.Forms.ToolStripMenuItem();
			this.ZoomGauge = new System.Windows.Forms.TrackBar();
			this.MapTooltip = new System.Windows.Forms.ToolTip(this.components);
			this.Statusbar = new System.Windows.Forms.StatusStrip();
			this.RoundLbl = new System.Windows.Forms.ToolStripStatusLabel();
			this.XPLbl = new System.Windows.Forms.ToolStripStatusLabel();
			this.LevelLbl = new System.Windows.Forms.ToolStripStatusLabel();
			this.MainPanel = new System.Windows.Forms.Panel();
			this.InitiativePanel = new Masterplan.Controls.InitiativePanel();
			this.CloseBtn = new System.Windows.Forms.Button();
			this.PauseBtn = new System.Windows.Forms.Button();
			this.InfoBtn = new System.Windows.Forms.Button();
			this.DieRollerBtn = new System.Windows.Forms.Button();
			this.ReportBtn = new System.Windows.Forms.Button();
			this.Toolbar.SuspendLayout();
			this.MapSplitter.Panel1.SuspendLayout();
			this.MapSplitter.Panel2.SuspendLayout();
			this.MapSplitter.SuspendLayout();
			this.Pages.SuspendLayout();
			this.CombatantsPage.SuspendLayout();
			this.ListSplitter.Panel1.SuspendLayout();
			this.ListSplitter.Panel2.SuspendLayout();
			this.ListSplitter.SuspendLayout();
			this.ListContext.SuspendLayout();
			this.PreviewPanel.SuspendLayout();
			this.TemplatesPage.SuspendLayout();
			this.LogPage.SuspendLayout();
			this.MapContext.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ZoomGauge)).BeginInit();
			this.Statusbar.SuspendLayout();
			this.MainPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DetailsBtn,
            this.DamageBtn,
            this.HealBtn,
            this.EffectMenu,
            this.toolStripSeparator18,
            this.NextInitBtn,
            this.DelayBtn,
            this.toolStripSeparator1,
            this.CombatantsBtn,
            this.MapMenu,
            this.PlayerViewMapMenu,
            this.PlayerViewNoMapMenu,
            this.ToolsMenu,
            this.OptionsMenu});
			this.Toolbar.Location = new System.Drawing.Point(0, 0);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(850, 25);
			this.Toolbar.TabIndex = 0;
			this.Toolbar.Text = "toolStrip1";
			// 
			// DetailsBtn
			// 
			this.DetailsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.DetailsBtn.Image = ((System.Drawing.Image)(resources.GetObject("DetailsBtn.Image")));
			this.DetailsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.DetailsBtn.Name = "DetailsBtn";
			this.DetailsBtn.Size = new System.Drawing.Size(46, 22);
			this.DetailsBtn.Text = "Details";
			this.DetailsBtn.Click += new System.EventHandler(this.DetailsBtn_Click);
			// 
			// DamageBtn
			// 
			this.DamageBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.DamageBtn.Image = ((System.Drawing.Image)(resources.GetObject("DamageBtn.Image")));
			this.DamageBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.DamageBtn.Name = "DamageBtn";
			this.DamageBtn.Size = new System.Drawing.Size(55, 22);
			this.DamageBtn.Text = "Damage";
			this.DamageBtn.Click += new System.EventHandler(this.DamageBtn_Click);
			// 
			// HealBtn
			// 
			this.HealBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.HealBtn.Image = ((System.Drawing.Image)(resources.GetObject("HealBtn.Image")));
			this.HealBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.HealBtn.Name = "HealBtn";
			this.HealBtn.Size = new System.Drawing.Size(35, 22);
			this.HealBtn.Text = "Heal";
			this.HealBtn.Click += new System.EventHandler(this.HealBtn_Click);
			// 
			// EffectMenu
			// 
			this.EffectMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.EffectMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.effectToolStripMenuItem});
			this.EffectMenu.Image = ((System.Drawing.Image)(resources.GetObject("EffectMenu.Image")));
			this.EffectMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EffectMenu.Name = "EffectMenu";
			this.EffectMenu.Size = new System.Drawing.Size(75, 22);
			this.EffectMenu.Text = "Add Effect";
			this.EffectMenu.DropDownOpening += new System.EventHandler(this.EffectMenu_DropDownOpening);
			// 
			// effectToolStripMenuItem
			// 
			this.effectToolStripMenuItem.Name = "effectToolStripMenuItem";
			this.effectToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
			this.effectToolStripMenuItem.Text = "[effect]";
			// 
			// toolStripSeparator18
			// 
			this.toolStripSeparator18.Name = "toolStripSeparator18";
			this.toolStripSeparator18.Size = new System.Drawing.Size(6, 25);
			// 
			// NextInitBtn
			// 
			this.NextInitBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.NextInitBtn.Image = ((System.Drawing.Image)(resources.GetObject("NextInitBtn.Image")));
			this.NextInitBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.NextInitBtn.Name = "NextInitBtn";
			this.NextInitBtn.Size = new System.Drawing.Size(63, 22);
			this.NextInitBtn.Text = "Next Turn";
			this.NextInitBtn.Click += new System.EventHandler(this.NextInitBtn_Click);
			// 
			// DelayBtn
			// 
			this.DelayBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.DelayBtn.Image = ((System.Drawing.Image)(resources.GetObject("DelayBtn.Image")));
			this.DelayBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.DelayBtn.Name = "DelayBtn";
			this.DelayBtn.Size = new System.Drawing.Size(78, 22);
			this.DelayBtn.Text = "Delay Action";
			this.DelayBtn.Click += new System.EventHandler(this.DelayBtn_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// CombatantsBtn
			// 
			this.CombatantsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.CombatantsBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CombatantsAdd,
            this.CombatantsAddToken,
            this.CombatantsAddOverlay,
            this.toolStripSeparator6,
            this.CombatantsWaves,
            this.toolStripSeparator26,
            this.CombatantsRemove,
            this.toolStripSeparator12,
            this.CombatantsHideAll,
            this.CombatantsShowAll});
			this.CombatantsBtn.Image = ((System.Drawing.Image)(resources.GetObject("CombatantsBtn.Image")));
			this.CombatantsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.CombatantsBtn.Name = "CombatantsBtn";
			this.CombatantsBtn.Size = new System.Drawing.Size(85, 22);
			this.CombatantsBtn.Text = "Combatants";
			this.CombatantsBtn.DropDownOpening += new System.EventHandler(this.CombatantsBtn_DropDownOpening);
			// 
			// CombatantsAdd
			// 
			this.CombatantsAdd.Name = "CombatantsAdd";
			this.CombatantsAdd.Size = new System.Drawing.Size(175, 22);
			this.CombatantsAdd.Text = "Add Combatant...";
			this.CombatantsAdd.Click += new System.EventHandler(this.CombatantsAdd_Click);
			// 
			// CombatantsAddToken
			// 
			this.CombatantsAddToken.Name = "CombatantsAddToken";
			this.CombatantsAddToken.Size = new System.Drawing.Size(175, 22);
			this.CombatantsAddToken.Text = "Add Map Token...";
			this.CombatantsAddToken.Click += new System.EventHandler(this.CombatantsAddCustom_Click);
			// 
			// CombatantsAddOverlay
			// 
			this.CombatantsAddOverlay.Name = "CombatantsAddOverlay";
			this.CombatantsAddOverlay.Size = new System.Drawing.Size(175, 22);
			this.CombatantsAddOverlay.Text = "Add Map Overlay...";
			this.CombatantsAddOverlay.Click += new System.EventHandler(this.CombatantsAddOverlay_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(172, 6);
			// 
			// CombatantsWaves
			// 
			this.CombatantsWaves.Name = "CombatantsWaves";
			this.CombatantsWaves.Size = new System.Drawing.Size(175, 22);
			this.CombatantsWaves.Text = "Waves";
			// 
			// toolStripSeparator26
			// 
			this.toolStripSeparator26.Name = "toolStripSeparator26";
			this.toolStripSeparator26.Size = new System.Drawing.Size(172, 6);
			// 
			// CombatantsRemove
			// 
			this.CombatantsRemove.Name = "CombatantsRemove";
			this.CombatantsRemove.Size = new System.Drawing.Size(175, 22);
			this.CombatantsRemove.Text = "Remove Selected";
			this.CombatantsRemove.Click += new System.EventHandler(this.CombatantsRemove_Click);
			// 
			// toolStripSeparator12
			// 
			this.toolStripSeparator12.Name = "toolStripSeparator12";
			this.toolStripSeparator12.Size = new System.Drawing.Size(172, 6);
			// 
			// CombatantsHideAll
			// 
			this.CombatantsHideAll.Name = "CombatantsHideAll";
			this.CombatantsHideAll.Size = new System.Drawing.Size(175, 22);
			this.CombatantsHideAll.Text = "Hide All";
			this.CombatantsHideAll.Click += new System.EventHandler(this.CombatantsHideAll_Click);
			// 
			// CombatantsShowAll
			// 
			this.CombatantsShowAll.Name = "CombatantsShowAll";
			this.CombatantsShowAll.Size = new System.Drawing.Size(175, 22);
			this.CombatantsShowAll.Text = "Show All";
			this.CombatantsShowAll.Click += new System.EventHandler(this.CombatantsShowAll_Click);
			// 
			// MapMenu
			// 
			this.MapMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.MapMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowMap,
            this.toolStripSeparator10,
            this.MapFog,
            this.toolStripSeparator15,
            this.MapLOS,
            this.MapGrid,
            this.MapGridLabels,
            this.MapHealth,
            this.MapConditions,
            this.MapPictureTokens,
            this.toolStripSeparator7,
            this.MapNavigate,
            this.MapReset,
            this.toolStripSeparator8,
            this.MapDrawing,
            this.MapClearDrawings,
            this.toolStripSeparator19,
            this.MapPrint,
            this.MapExport});
			this.MapMenu.Image = ((System.Drawing.Image)(resources.GetObject("MapMenu.Image")));
			this.MapMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MapMenu.Name = "MapMenu";
			this.MapMenu.Size = new System.Drawing.Size(44, 22);
			this.MapMenu.Text = "Map";
			this.MapMenu.DropDownOpening += new System.EventHandler(this.MapMenu_DropDownOpening);
			// 
			// ShowMap
			// 
			this.ShowMap.Name = "ShowMap";
			this.ShowMap.Size = new System.Drawing.Size(182, 22);
			this.ShowMap.Text = "Show Map";
			this.ShowMap.Click += new System.EventHandler(this.ShowMap_Click);
			// 
			// toolStripSeparator10
			// 
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new System.Drawing.Size(179, 6);
			// 
			// MapFog
			// 
			this.MapFog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.MapFog.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MapFogAllCreatures,
            this.MapFogVisibleCreatures,
            this.MapFogHideCreatures});
			this.MapFog.Image = ((System.Drawing.Image)(resources.GetObject("MapFog.Image")));
			this.MapFog.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MapFog.Name = "MapFog";
			this.MapFog.Size = new System.Drawing.Size(182, 22);
			this.MapFog.Text = "Fog of War";
			// 
			// MapFogAllCreatures
			// 
			this.MapFogAllCreatures.Name = "MapFogAllCreatures";
			this.MapFogAllCreatures.Size = new System.Drawing.Size(221, 22);
			this.MapFogAllCreatures.Text = "Show All Creatures";
			this.MapFogAllCreatures.Click += new System.EventHandler(this.MapFogAllCreatures_Click);
			// 
			// MapFogVisibleCreatures
			// 
			this.MapFogVisibleCreatures.Name = "MapFogVisibleCreatures";
			this.MapFogVisibleCreatures.Size = new System.Drawing.Size(221, 22);
			this.MapFogVisibleCreatures.Text = "Show Visible Creatures Only";
			this.MapFogVisibleCreatures.Click += new System.EventHandler(this.MapFogVisibleCreatures_Click);
			// 
			// MapFogHideCreatures
			// 
			this.MapFogHideCreatures.Name = "MapFogHideCreatures";
			this.MapFogHideCreatures.Size = new System.Drawing.Size(221, 22);
			this.MapFogHideCreatures.Text = "Hide All Creatures";
			this.MapFogHideCreatures.Click += new System.EventHandler(this.MapFogHideCreatures_Click);
			// 
			// toolStripSeparator15
			// 
			this.toolStripSeparator15.Name = "toolStripSeparator15";
			this.toolStripSeparator15.Size = new System.Drawing.Size(179, 6);
			// 
			// MapLOS
			// 
			this.MapLOS.Name = "MapLOS";
			this.MapLOS.Size = new System.Drawing.Size(182, 22);
			this.MapLOS.Text = "Show Line of Sight";
			this.MapLOS.Click += new System.EventHandler(this.MapLOS_Click);
			// 
			// MapGrid
			// 
			this.MapGrid.Name = "MapGrid";
			this.MapGrid.Size = new System.Drawing.Size(182, 22);
			this.MapGrid.Text = "Show Grid";
			this.MapGrid.Click += new System.EventHandler(this.MapGrid_Click);
			// 
			// MapGridLabels
			// 
			this.MapGridLabels.Name = "MapGridLabels";
			this.MapGridLabels.Size = new System.Drawing.Size(182, 22);
			this.MapGridLabels.Text = "Show Grid Labels";
			this.MapGridLabels.Click += new System.EventHandler(this.MapGridLabels_Click);
			// 
			// MapHealth
			// 
			this.MapHealth.Name = "MapHealth";
			this.MapHealth.Size = new System.Drawing.Size(182, 22);
			this.MapHealth.Text = "Show Health Bars";
			this.MapHealth.Click += new System.EventHandler(this.MapHealth_Click);
			// 
			// MapConditions
			// 
			this.MapConditions.Name = "MapConditions";
			this.MapConditions.Size = new System.Drawing.Size(182, 22);
			this.MapConditions.Text = "Show Conditions";
			this.MapConditions.Click += new System.EventHandler(this.MapConditions_Click);
			// 
			// MapPictureTokens
			// 
			this.MapPictureTokens.Name = "MapPictureTokens";
			this.MapPictureTokens.Size = new System.Drawing.Size(182, 22);
			this.MapPictureTokens.Text = "Show Picture Tokens";
			this.MapPictureTokens.Click += new System.EventHandler(this.MapPictureTokens_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(179, 6);
			// 
			// MapNavigate
			// 
			this.MapNavigate.Name = "MapNavigate";
			this.MapNavigate.Size = new System.Drawing.Size(182, 22);
			this.MapNavigate.Text = "Scroll and Zoom";
			this.MapNavigate.Click += new System.EventHandler(this.MapNavigate_Click);
			// 
			// MapReset
			// 
			this.MapReset.Name = "MapReset";
			this.MapReset.Size = new System.Drawing.Size(182, 22);
			this.MapReset.Text = "Reset View";
			this.MapReset.Click += new System.EventHandler(this.MapReset_Click);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(179, 6);
			// 
			// MapDrawing
			// 
			this.MapDrawing.Name = "MapDrawing";
			this.MapDrawing.Size = new System.Drawing.Size(182, 22);
			this.MapDrawing.Text = "Allow Drawing";
			this.MapDrawing.Click += new System.EventHandler(this.MapDrawing_Click);
			// 
			// MapClearDrawings
			// 
			this.MapClearDrawings.Name = "MapClearDrawings";
			this.MapClearDrawings.Size = new System.Drawing.Size(182, 22);
			this.MapClearDrawings.Text = "Clear Drawings";
			this.MapClearDrawings.Click += new System.EventHandler(this.MapClearDrawings_Click);
			// 
			// toolStripSeparator19
			// 
			this.toolStripSeparator19.Name = "toolStripSeparator19";
			this.toolStripSeparator19.Size = new System.Drawing.Size(179, 6);
			// 
			// MapPrint
			// 
			this.MapPrint.Name = "MapPrint";
			this.MapPrint.Size = new System.Drawing.Size(182, 22);
			this.MapPrint.Text = "Print";
			this.MapPrint.Click += new System.EventHandler(this.MapPrint_Click);
			// 
			// MapExport
			// 
			this.MapExport.Name = "MapExport";
			this.MapExport.Size = new System.Drawing.Size(182, 22);
			this.MapExport.Text = "Export Screenshot";
			this.MapExport.Click += new System.EventHandler(this.MapExport_Click);
			// 
			// PlayerViewMapMenu
			// 
			this.PlayerViewMapMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.PlayerViewMapMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PlayerViewMap,
            this.PlayerViewInitList,
            this.toolStripSeparator9,
            this.PlayerViewFog,
            this.toolStripSeparator16,
            this.PlayerViewLOS,
            this.PlayerViewGrid,
            this.PlayerViewGridLabels,
            this.PlayerHealth,
            this.PlayerConditions,
            this.PlayerPictureTokens,
            this.toolStripSeparator17,
            this.PlayerLabels});
			this.PlayerViewMapMenu.Image = ((System.Drawing.Image)(resources.GetObject("PlayerViewMapMenu.Image")));
			this.PlayerViewMapMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.PlayerViewMapMenu.Name = "PlayerViewMapMenu";
			this.PlayerViewMapMenu.Size = new System.Drawing.Size(80, 22);
			this.PlayerViewMapMenu.Text = "Player View";
			this.PlayerViewMapMenu.DropDownOpening += new System.EventHandler(this.PlayerViewMapMenu_DropDownOpening);
			// 
			// PlayerViewMap
			// 
			this.PlayerViewMap.Name = "PlayerViewMap";
			this.PlayerViewMap.Size = new System.Drawing.Size(215, 22);
			this.PlayerViewMap.Text = "Show Map";
			this.PlayerViewMap.Click += new System.EventHandler(this.PlayerViewMap_Click);
			// 
			// PlayerViewInitList
			// 
			this.PlayerViewInitList.Name = "PlayerViewInitList";
			this.PlayerViewInitList.Size = new System.Drawing.Size(215, 22);
			this.PlayerViewInitList.Text = "Show Initiative List";
			this.PlayerViewInitList.Click += new System.EventHandler(this.PlayerViewInitList_Click);
			// 
			// toolStripSeparator9
			// 
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(212, 6);
			// 
			// PlayerViewFog
			// 
			this.PlayerViewFog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.PlayerViewFog.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PlayerFogAll,
            this.PlayerFogVisible,
            this.PlayerFogNone});
			this.PlayerViewFog.Image = ((System.Drawing.Image)(resources.GetObject("PlayerViewFog.Image")));
			this.PlayerViewFog.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.PlayerViewFog.Name = "PlayerViewFog";
			this.PlayerViewFog.Size = new System.Drawing.Size(215, 22);
			this.PlayerViewFog.Text = "Fog of War";
			// 
			// PlayerFogAll
			// 
			this.PlayerFogAll.Name = "PlayerFogAll";
			this.PlayerFogAll.Size = new System.Drawing.Size(221, 22);
			this.PlayerFogAll.Text = "Show All Creatures";
			this.PlayerFogAll.Click += new System.EventHandler(this.PlayerFogAll_Click);
			// 
			// PlayerFogVisible
			// 
			this.PlayerFogVisible.Name = "PlayerFogVisible";
			this.PlayerFogVisible.Size = new System.Drawing.Size(221, 22);
			this.PlayerFogVisible.Text = "Show Visible Creatures Only";
			this.PlayerFogVisible.Click += new System.EventHandler(this.PlayerFogVisible_Click);
			// 
			// PlayerFogNone
			// 
			this.PlayerFogNone.Name = "PlayerFogNone";
			this.PlayerFogNone.Size = new System.Drawing.Size(221, 22);
			this.PlayerFogNone.Text = "Hide All Creatures";
			this.PlayerFogNone.Click += new System.EventHandler(this.PlayerFogNone_Click);
			// 
			// toolStripSeparator16
			// 
			this.toolStripSeparator16.Name = "toolStripSeparator16";
			this.toolStripSeparator16.Size = new System.Drawing.Size(212, 6);
			// 
			// PlayerViewLOS
			// 
			this.PlayerViewLOS.Name = "PlayerViewLOS";
			this.PlayerViewLOS.Size = new System.Drawing.Size(215, 22);
			this.PlayerViewLOS.Text = "Show Line of Sight";
			this.PlayerViewLOS.Click += new System.EventHandler(this.PlayerViewLOS_Click);
			// 
			// PlayerViewGrid
			// 
			this.PlayerViewGrid.Name = "PlayerViewGrid";
			this.PlayerViewGrid.Size = new System.Drawing.Size(215, 22);
			this.PlayerViewGrid.Text = "Show Grid";
			this.PlayerViewGrid.Click += new System.EventHandler(this.PlayerViewGrid_Click);
			// 
			// PlayerViewGridLabels
			// 
			this.PlayerViewGridLabels.Name = "PlayerViewGridLabels";
			this.PlayerViewGridLabels.Size = new System.Drawing.Size(215, 22);
			this.PlayerViewGridLabels.Text = "Show Grid Labels";
			this.PlayerViewGridLabels.Click += new System.EventHandler(this.PlayerViewGridLabels_Click);
			// 
			// PlayerHealth
			// 
			this.PlayerHealth.Name = "PlayerHealth";
			this.PlayerHealth.Size = new System.Drawing.Size(215, 22);
			this.PlayerHealth.Text = "Show Health Bars";
			this.PlayerHealth.Click += new System.EventHandler(this.PlayerHealth_Click);
			// 
			// PlayerConditions
			// 
			this.PlayerConditions.Name = "PlayerConditions";
			this.PlayerConditions.Size = new System.Drawing.Size(215, 22);
			this.PlayerConditions.Text = "Show Conditions";
			this.PlayerConditions.Click += new System.EventHandler(this.PlayerConditions_Click);
			// 
			// PlayerPictureTokens
			// 
			this.PlayerPictureTokens.Name = "PlayerPictureTokens";
			this.PlayerPictureTokens.Size = new System.Drawing.Size(215, 22);
			this.PlayerPictureTokens.Text = "Show Picture Tokens";
			this.PlayerPictureTokens.Click += new System.EventHandler(this.PlayerPictureTokens_Click);
			// 
			// toolStripSeparator17
			// 
			this.toolStripSeparator17.Name = "toolStripSeparator17";
			this.toolStripSeparator17.Size = new System.Drawing.Size(212, 6);
			// 
			// PlayerLabels
			// 
			this.PlayerLabels.Name = "PlayerLabels";
			this.PlayerLabels.Size = new System.Drawing.Size(215, 22);
			this.PlayerLabels.Text = "Show Detailed Information";
			this.PlayerLabels.Click += new System.EventHandler(this.PlayerLabels_Click);
			// 
			// PlayerViewNoMapMenu
			// 
			this.PlayerViewNoMapMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.PlayerViewNoMapMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PlayerViewNoMapShowInitiativeList,
            this.PlayerViewNoMapShowLabels});
			this.PlayerViewNoMapMenu.Image = ((System.Drawing.Image)(resources.GetObject("PlayerViewNoMapMenu.Image")));
			this.PlayerViewNoMapMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.PlayerViewNoMapMenu.Name = "PlayerViewNoMapMenu";
			this.PlayerViewNoMapMenu.Size = new System.Drawing.Size(80, 22);
			this.PlayerViewNoMapMenu.Text = "Player View";
			this.PlayerViewNoMapMenu.DropDownOpening += new System.EventHandler(this.PlayerViewNoMapMenu_DropDownOpening);
			// 
			// PlayerViewNoMapShowInitiativeList
			// 
			this.PlayerViewNoMapShowInitiativeList.Name = "PlayerViewNoMapShowInitiativeList";
			this.PlayerViewNoMapShowInitiativeList.Size = new System.Drawing.Size(215, 22);
			this.PlayerViewNoMapShowInitiativeList.Text = "Show Initiative List";
			this.PlayerViewNoMapShowInitiativeList.Click += new System.EventHandler(this.PlayerViewNoMapShowInitiativeList_Click);
			// 
			// PlayerViewNoMapShowLabels
			// 
			this.PlayerViewNoMapShowLabels.Name = "PlayerViewNoMapShowLabels";
			this.PlayerViewNoMapShowLabels.Size = new System.Drawing.Size(215, 22);
			this.PlayerViewNoMapShowLabels.Text = "Show Detailed Information";
			this.PlayerViewNoMapShowLabels.Click += new System.EventHandler(this.PlayerViewNoMapShowLabels_Click);
			// 
			// ToolsMenu
			// 
			this.ToolsMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ToolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolsEffects,
            this.ToolsLinks,
            this.toolStripSeparator11,
            this.ToolsAddIns});
			this.ToolsMenu.Image = ((System.Drawing.Image)(resources.GetObject("ToolsMenu.Image")));
			this.ToolsMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ToolsMenu.Name = "ToolsMenu";
			this.ToolsMenu.Size = new System.Drawing.Size(47, 22);
			this.ToolsMenu.Text = "Tools";
			this.ToolsMenu.Click += new System.EventHandler(this.ToolsMenu_DopDownOpening);
			// 
			// ToolsEffects
			// 
			this.ToolsEffects.Name = "ToolsEffects";
			this.ToolsEffects.Size = new System.Drawing.Size(159, 22);
			this.ToolsEffects.Text = "Ongoing Effects";
			this.ToolsEffects.Click += new System.EventHandler(this.CombatantsEffects_Click);
			// 
			// ToolsLinks
			// 
			this.ToolsLinks.Name = "ToolsLinks";
			this.ToolsLinks.Size = new System.Drawing.Size(159, 22);
			this.ToolsLinks.Text = "Token Links";
			this.ToolsLinks.Click += new System.EventHandler(this.CombatantsLinks_Click);
			// 
			// toolStripSeparator11
			// 
			this.toolStripSeparator11.Name = "toolStripSeparator11";
			this.toolStripSeparator11.Size = new System.Drawing.Size(156, 6);
			// 
			// ToolsAddIns
			// 
			this.ToolsAddIns.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addinsToolStripMenuItem});
			this.ToolsAddIns.Name = "ToolsAddIns";
			this.ToolsAddIns.Size = new System.Drawing.Size(159, 22);
			this.ToolsAddIns.Text = "Add-Ins";
			// 
			// addinsToolStripMenuItem
			// 
			this.addinsToolStripMenuItem.Name = "addinsToolStripMenuItem";
			this.addinsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.addinsToolStripMenuItem.Text = "[add-ins]";
			// 
			// OptionsMenu
			// 
			this.OptionsMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.OptionsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionsShowInit,
            this.toolStripSeparator13,
            this.OneColumn,
            this.TwoColumns,
            this.toolStripSeparator20,
            this.MapRight,
            this.MapBelow,
            this.toolStripSeparator21,
            this.OptionsLandscape,
            this.OptionsPortrait,
            this.toolStripSeparator5,
            this.ToolsAutoRemove,
            this.toolStripSeparator23,
            this.ToolsColumns});
			this.OptionsMenu.Image = ((System.Drawing.Image)(resources.GetObject("OptionsMenu.Image")));
			this.OptionsMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.OptionsMenu.Name = "OptionsMenu";
			this.OptionsMenu.Size = new System.Drawing.Size(62, 22);
			this.OptionsMenu.Text = "Options";
			this.OptionsMenu.DropDownOpening += new System.EventHandler(this.OptionsMenu_DropDownOpening);
			// 
			// OptionsShowInit
			// 
			this.OptionsShowInit.Name = "OptionsShowInit";
			this.OptionsShowInit.Size = new System.Drawing.Size(229, 22);
			this.OptionsShowInit.Text = "Show Initiative Gauge";
			this.OptionsShowInit.Click += new System.EventHandler(this.OptionsShowInit_Click);
			// 
			// toolStripSeparator13
			// 
			this.toolStripSeparator13.Name = "toolStripSeparator13";
			this.toolStripSeparator13.Size = new System.Drawing.Size(226, 6);
			// 
			// OneColumn
			// 
			this.OneColumn.Name = "OneColumn";
			this.OneColumn.Size = new System.Drawing.Size(229, 22);
			this.OneColumn.Text = "One Column";
			this.OneColumn.Click += new System.EventHandler(this.OneColumn_Click);
			// 
			// TwoColumns
			// 
			this.TwoColumns.Name = "TwoColumns";
			this.TwoColumns.Size = new System.Drawing.Size(229, 22);
			this.TwoColumns.Text = "Two Columns";
			this.TwoColumns.Click += new System.EventHandler(this.TwoColumns_Click);
			// 
			// toolStripSeparator20
			// 
			this.toolStripSeparator20.Name = "toolStripSeparator20";
			this.toolStripSeparator20.Size = new System.Drawing.Size(226, 6);
			// 
			// MapRight
			// 
			this.MapRight.Name = "MapRight";
			this.MapRight.Size = new System.Drawing.Size(229, 22);
			this.MapRight.Text = "Map at Right";
			this.MapRight.Click += new System.EventHandler(this.OptionsMapRight_Click);
			// 
			// MapBelow
			// 
			this.MapBelow.Name = "MapBelow";
			this.MapBelow.Size = new System.Drawing.Size(229, 22);
			this.MapBelow.Text = "Map Below";
			this.MapBelow.Click += new System.EventHandler(this.OptionsMapBelow_Click);
			// 
			// toolStripSeparator21
			// 
			this.toolStripSeparator21.Name = "toolStripSeparator21";
			this.toolStripSeparator21.Size = new System.Drawing.Size(226, 6);
			// 
			// OptionsLandscape
			// 
			this.OptionsLandscape.Name = "OptionsLandscape";
			this.OptionsLandscape.Size = new System.Drawing.Size(229, 22);
			this.OptionsLandscape.Text = "Landscape";
			this.OptionsLandscape.Click += new System.EventHandler(this.OptionsLandscape_Click);
			// 
			// OptionsPortrait
			// 
			this.OptionsPortrait.Name = "OptionsPortrait";
			this.OptionsPortrait.Size = new System.Drawing.Size(229, 22);
			this.OptionsPortrait.Text = "Portrait";
			this.OptionsPortrait.Click += new System.EventHandler(this.OptionsPortrait_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(226, 6);
			// 
			// ToolsAutoRemove
			// 
			this.ToolsAutoRemove.Name = "ToolsAutoRemove";
			this.ToolsAutoRemove.Size = new System.Drawing.Size(229, 22);
			this.ToolsAutoRemove.Text = "Remove Defeated Opponents";
			this.ToolsAutoRemove.Click += new System.EventHandler(this.ToolsAutoRemove_Click);
			// 
			// toolStripSeparator23
			// 
			this.toolStripSeparator23.Name = "toolStripSeparator23";
			this.toolStripSeparator23.Size = new System.Drawing.Size(226, 6);
			// 
			// ToolsColumns
			// 
			this.ToolsColumns.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolsColumnsInit,
            this.ToolsColumnsHP,
            this.ToolsColumnsDefences,
            this.ToolsColumnsConditions});
			this.ToolsColumns.Name = "ToolsColumns";
			this.ToolsColumns.Size = new System.Drawing.Size(229, 22);
			this.ToolsColumns.Text = "Columns";
			this.ToolsColumns.DropDownOpening += new System.EventHandler(this.ToolsColumns_DropDownOpening);
			// 
			// ToolsColumnsInit
			// 
			this.ToolsColumnsInit.Name = "ToolsColumnsInit";
			this.ToolsColumnsInit.Size = new System.Drawing.Size(126, 22);
			this.ToolsColumnsInit.Text = "Initiative";
			this.ToolsColumnsInit.Click += new System.EventHandler(this.ToolsColumnsInit_Click);
			// 
			// ToolsColumnsHP
			// 
			this.ToolsColumnsHP.Name = "ToolsColumnsHP";
			this.ToolsColumnsHP.Size = new System.Drawing.Size(126, 22);
			this.ToolsColumnsHP.Text = "Hit Points";
			this.ToolsColumnsHP.Click += new System.EventHandler(this.ToolsColumnsHP_Click);
			// 
			// ToolsColumnsDefences
			// 
			this.ToolsColumnsDefences.Name = "ToolsColumnsDefences";
			this.ToolsColumnsDefences.Size = new System.Drawing.Size(126, 22);
			this.ToolsColumnsDefences.Text = "Defences";
			this.ToolsColumnsDefences.Click += new System.EventHandler(this.ToolsColumnsDefences_Click);
			// 
			// ToolsColumnsConditions
			// 
			this.ToolsColumnsConditions.Name = "ToolsColumnsConditions";
			this.ToolsColumnsConditions.Size = new System.Drawing.Size(126, 22);
			this.ToolsColumnsConditions.Text = "Effects";
			this.ToolsColumnsConditions.Click += new System.EventHandler(this.ToolsColumnsConditions_Click);
			// 
			// MapSplitter
			// 
			this.MapSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MapSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.MapSplitter.Location = new System.Drawing.Point(0, 0);
			this.MapSplitter.Name = "MapSplitter";
			// 
			// MapSplitter.Panel1
			// 
			this.MapSplitter.Panel1.Controls.Add(this.Pages);
			// 
			// MapSplitter.Panel2
			// 
			this.MapSplitter.Panel2.Controls.Add(this.MapView);
			this.MapSplitter.Panel2.Controls.Add(this.ZoomGauge);
			this.MapSplitter.Size = new System.Drawing.Size(786, 362);
			this.MapSplitter.SplitterDistance = 368;
			this.MapSplitter.TabIndex = 1;
			// 
			// Pages
			// 
			this.Pages.Controls.Add(this.CombatantsPage);
			this.Pages.Controls.Add(this.TemplatesPage);
			this.Pages.Controls.Add(this.LogPage);
			this.Pages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Pages.Location = new System.Drawing.Point(0, 0);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(368, 362);
			this.Pages.TabIndex = 2;
			// 
			// CombatantsPage
			// 
			this.CombatantsPage.Controls.Add(this.ListSplitter);
			this.CombatantsPage.Location = new System.Drawing.Point(4, 22);
			this.CombatantsPage.Name = "CombatantsPage";
			this.CombatantsPage.Padding = new System.Windows.Forms.Padding(3);
			this.CombatantsPage.Size = new System.Drawing.Size(360, 336);
			this.CombatantsPage.TabIndex = 0;
			this.CombatantsPage.Text = "Combatants";
			this.CombatantsPage.UseVisualStyleBackColor = true;
			// 
			// ListSplitter
			// 
			this.ListSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ListSplitter.Location = new System.Drawing.Point(3, 3);
			this.ListSplitter.Name = "ListSplitter";
			this.ListSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// ListSplitter.Panel1
			// 
			this.ListSplitter.Panel1.Controls.Add(this.CombatList);
			// 
			// ListSplitter.Panel2
			// 
			this.ListSplitter.Panel2.Controls.Add(this.PreviewPanel);
			this.ListSplitter.Size = new System.Drawing.Size(354, 330);
			this.ListSplitter.SplitterDistance = 159;
			this.ListSplitter.TabIndex = 1;
			this.ListSplitter.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.ListSplitter_SplitterMoved);
			this.ListSplitter.Resize += new System.EventHandler(this.ListSplitter_Resize);
			// 
			// CombatList
			// 
			this.CombatList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameHdr,
            this.InitHdr,
            this.HPHdr,
            this.DefHdr,
            this.EffectsHdr});
			this.CombatList.ContextMenuStrip = this.ListContext;
			this.CombatList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CombatList.FullRowSelect = true;
			listViewGroup1.Header = "Combatants";
			listViewGroup1.Name = "listViewGroup1";
			listViewGroup2.Header = "Delayed / Readied";
			listViewGroup2.Name = "listViewGroup5";
			listViewGroup3.Header = "Traps";
			listViewGroup3.Name = "listViewGroup3";
			listViewGroup4.Header = "Skill Challenges";
			listViewGroup4.Name = "listViewGroup4";
			listViewGroup5.Header = "Custom Tokens and Overlays";
			listViewGroup5.Name = "listViewGroup6";
			listViewGroup6.Header = "Not In Play";
			listViewGroup6.Name = "listViewGroup2";
			listViewGroup7.Header = "Defeated";
			listViewGroup7.Name = "listViewGroup7";
			this.CombatList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5,
            listViewGroup6,
            listViewGroup7});
			this.CombatList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.CombatList.HideSelection = false;
			this.CombatList.Location = new System.Drawing.Point(0, 0);
			this.CombatList.Name = "CombatList";
			this.CombatList.OwnerDraw = true;
			this.CombatList.Size = new System.Drawing.Size(354, 159);
			this.CombatList.TabIndex = 0;
			this.CombatList.TileSize = new System.Drawing.Size(300, 45);
			this.CombatList.UseCompatibleStateImageBehavior = false;
			this.CombatList.View = System.Windows.Forms.View.Details;
			this.CombatList.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.CombatList_DrawColumnHeader);
			this.CombatList.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.CombatList_DrawItem);
			this.CombatList.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.CombatList_DrawSubItem);
			this.CombatList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.CombatList_ItemDrag);
			this.CombatList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.CombatList_ItemSelectionChanged);
			this.CombatList.SelectedIndexChanged += new System.EventHandler(this.CombatList_SelectedIndexChanged);
			this.CombatList.DoubleClick += new System.EventHandler(this.CombatList_DoubleClick);
			// 
			// NameHdr
			// 
			this.NameHdr.Text = "Name";
			this.NameHdr.Width = 185;
			// 
			// InitHdr
			// 
			this.InitHdr.Text = "Init";
			this.InitHdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// HPHdr
			// 
			this.HPHdr.Text = "HP";
			this.HPHdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// DefHdr
			// 
			this.DefHdr.Text = "Defences";
			this.DefHdr.Width = 200;
			// 
			// EffectsHdr
			// 
			this.EffectsHdr.Text = "Effects";
			this.EffectsHdr.Width = 175;
			// 
			// ListContext
			// 
			this.ListContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ListDetails,
            this.toolStripSeparator14,
            this.ListDamage,
            this.ListHeal,
            this.ListCondition,
            this.ListRemoveEffect,
            this.toolStripSeparator3,
            this.ListRemove,
            this.ListCreateCopy,
            this.toolStripSeparator4,
            this.ListVisible,
            this.ListDelay});
			this.ListContext.Name = "MapContext";
			this.ListContext.Size = new System.Drawing.Size(185, 220);
			this.ListContext.Opening += new System.ComponentModel.CancelEventHandler(this.ListContext_Opening);
			// 
			// ListDetails
			// 
			this.ListDetails.Name = "ListDetails";
			this.ListDetails.Size = new System.Drawing.Size(184, 22);
			this.ListDetails.Text = "Details";
			this.ListDetails.Click += new System.EventHandler(this.ListDetails_Click);
			// 
			// toolStripSeparator14
			// 
			this.toolStripSeparator14.Name = "toolStripSeparator14";
			this.toolStripSeparator14.Size = new System.Drawing.Size(181, 6);
			// 
			// ListDamage
			// 
			this.ListDamage.Name = "ListDamage";
			this.ListDamage.Size = new System.Drawing.Size(184, 22);
			this.ListDamage.Text = "Damage...";
			this.ListDamage.Click += new System.EventHandler(this.ListDamage_Click);
			// 
			// ListHeal
			// 
			this.ListHeal.Name = "ListHeal";
			this.ListHeal.Size = new System.Drawing.Size(184, 22);
			this.ListHeal.Text = "Heal...";
			this.ListHeal.Click += new System.EventHandler(this.ListHeal_Click);
			// 
			// ListCondition
			// 
			this.ListCondition.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.effectToolStripMenuItem1});
			this.ListCondition.Name = "ListCondition";
			this.ListCondition.Size = new System.Drawing.Size(184, 22);
			this.ListCondition.Text = "Add Effect";
			this.ListCondition.DropDownOpening += new System.EventHandler(this.ListCondition_DropDownOpening);
			// 
			// effectToolStripMenuItem1
			// 
			this.effectToolStripMenuItem1.Name = "effectToolStripMenuItem1";
			this.effectToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
			this.effectToolStripMenuItem1.Text = "[effect]";
			// 
			// ListRemoveEffect
			// 
			this.ListRemoveEffect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.effectToolStripMenuItem3});
			this.ListRemoveEffect.Name = "ListRemoveEffect";
			this.ListRemoveEffect.Size = new System.Drawing.Size(184, 22);
			this.ListRemoveEffect.Text = "Remove Effect";
			this.ListRemoveEffect.DropDownOpening += new System.EventHandler(this.ListRemoveEffect_DropDownOpening);
			// 
			// effectToolStripMenuItem3
			// 
			this.effectToolStripMenuItem3.Name = "effectToolStripMenuItem3";
			this.effectToolStripMenuItem3.Size = new System.Drawing.Size(112, 22);
			this.effectToolStripMenuItem3.Text = "[effect]";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(181, 6);
			// 
			// ListRemove
			// 
			this.ListRemove.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ListRemoveMap,
            this.ListRemoveCombat});
			this.ListRemove.Name = "ListRemove";
			this.ListRemove.Size = new System.Drawing.Size(184, 22);
			this.ListRemove.Text = "Remove";
			// 
			// ListRemoveMap
			// 
			this.ListRemoveMap.Name = "ListRemoveMap";
			this.ListRemoveMap.Size = new System.Drawing.Size(192, 22);
			this.ListRemoveMap.Text = "Remove from Map";
			this.ListRemoveMap.Click += new System.EventHandler(this.ListRemoveMap_Click);
			// 
			// ListRemoveCombat
			// 
			this.ListRemoveCombat.Name = "ListRemoveCombat";
			this.ListRemoveCombat.Size = new System.Drawing.Size(192, 22);
			this.ListRemoveCombat.Text = "Remove from Combat";
			this.ListRemoveCombat.Click += new System.EventHandler(this.ListRemoveCombat_Click);
			// 
			// ListCreateCopy
			// 
			this.ListCreateCopy.Name = "ListCreateCopy";
			this.ListCreateCopy.Size = new System.Drawing.Size(184, 22);
			this.ListCreateCopy.Text = "Create Duplicate";
			this.ListCreateCopy.Click += new System.EventHandler(this.ListCreateCopy_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(181, 6);
			// 
			// ListVisible
			// 
			this.ListVisible.Name = "ListVisible";
			this.ListVisible.Size = new System.Drawing.Size(184, 22);
			this.ListVisible.Text = "Visible";
			this.ListVisible.Click += new System.EventHandler(this.ListVisible_Click);
			// 
			// ListDelay
			// 
			this.ListDelay.Name = "ListDelay";
			this.ListDelay.Size = new System.Drawing.Size(184, 22);
			this.ListDelay.Text = "Delay / Ready Action";
			this.ListDelay.Click += new System.EventHandler(this.ListDelay_Click);
			// 
			// PreviewPanel
			// 
			this.PreviewPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.PreviewPanel.Controls.Add(this.Preview);
			this.PreviewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PreviewPanel.Location = new System.Drawing.Point(0, 0);
			this.PreviewPanel.Name = "PreviewPanel";
			this.PreviewPanel.Size = new System.Drawing.Size(354, 167);
			this.PreviewPanel.TabIndex = 1;
			// 
			// Preview
			// 
			this.Preview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Preview.IsWebBrowserContextMenuEnabled = false;
			this.Preview.Location = new System.Drawing.Point(0, 0);
			this.Preview.MinimumSize = new System.Drawing.Size(20, 20);
			this.Preview.Name = "Preview";
			this.Preview.ScriptErrorsSuppressed = true;
			this.Preview.Size = new System.Drawing.Size(350, 163);
			this.Preview.TabIndex = 0;
			this.Preview.WebBrowserShortcutsEnabled = false;
			this.Preview.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.Preview_Navigating);
			// 
			// TemplatesPage
			// 
			this.TemplatesPage.Controls.Add(this.TemplateList);
			this.TemplatesPage.Location = new System.Drawing.Point(4, 22);
			this.TemplatesPage.Name = "TemplatesPage";
			this.TemplatesPage.Padding = new System.Windows.Forms.Padding(3);
			this.TemplatesPage.Size = new System.Drawing.Size(360, 336);
			this.TemplatesPage.TabIndex = 1;
			this.TemplatesPage.Text = "Tokens and Overlays";
			this.TemplatesPage.UseVisualStyleBackColor = true;
			// 
			// TemplateList
			// 
			this.TemplateList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TemplateHdr});
			this.TemplateList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TemplateList.FullRowSelect = true;
			listViewGroup8.Header = "Predefined";
			listViewGroup8.Name = "listViewGroup3";
			listViewGroup9.Header = "Custom Tokens";
			listViewGroup9.Name = "listViewGroup1";
			listViewGroup10.Header = "Custom Overlays";
			listViewGroup10.Name = "listViewGroup2";
			this.TemplateList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup8,
            listViewGroup9,
            listViewGroup10});
			this.TemplateList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.TemplateList.HideSelection = false;
			this.TemplateList.Location = new System.Drawing.Point(3, 3);
			this.TemplateList.MultiSelect = false;
			this.TemplateList.Name = "TemplateList";
			this.TemplateList.Size = new System.Drawing.Size(354, 330);
			this.TemplateList.TabIndex = 0;
			this.TemplateList.UseCompatibleStateImageBehavior = false;
			this.TemplateList.View = System.Windows.Forms.View.Details;
			this.TemplateList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.TemplateList_ItemDrag);
			// 
			// TemplateHdr
			// 
			this.TemplateHdr.Text = "Templates";
			this.TemplateHdr.Width = 283;
			// 
			// LogPage
			// 
			this.LogPage.Controls.Add(this.LogBrowser);
			this.LogPage.Location = new System.Drawing.Point(4, 22);
			this.LogPage.Name = "LogPage";
			this.LogPage.Padding = new System.Windows.Forms.Padding(3);
			this.LogPage.Size = new System.Drawing.Size(360, 336);
			this.LogPage.TabIndex = 2;
			this.LogPage.Text = "Encounter Log";
			this.LogPage.UseVisualStyleBackColor = true;
			// 
			// LogBrowser
			// 
			this.LogBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LogBrowser.IsWebBrowserContextMenuEnabled = false;
			this.LogBrowser.Location = new System.Drawing.Point(3, 3);
			this.LogBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.LogBrowser.Name = "LogBrowser";
			this.LogBrowser.ScriptErrorsSuppressed = true;
			this.LogBrowser.Size = new System.Drawing.Size(354, 330);
			this.LogBrowser.TabIndex = 1;
			this.LogBrowser.WebBrowserShortcutsEnabled = false;
			// 
			// MapView
			// 
			this.MapView.AllowDrawing = false;
			this.MapView.AllowDrop = true;
			this.MapView.AllowLinkCreation = true;
			this.MapView.AllowScrolling = false;
			this.MapView.BackgroundMap = null;
			this.MapView.BorderSize = 0;
			this.MapView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.MapView.Caption = "";
			this.MapView.ContextMenuStrip = this.MapContext;
			this.MapView.Cursor = System.Windows.Forms.Cursors.Default;
			this.MapView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MapView.Encounter = null;
			this.MapView.FrameType = Masterplan.Controls.MapDisplayType.Dimmed;
			this.MapView.HighlightAreas = false;
			this.MapView.HoverToken = null;
			this.MapView.HoverTokenLink = null;
			this.MapView.LineOfSight = false;
			this.MapView.Location = new System.Drawing.Point(0, 0);
			this.MapView.Map = null;
			this.MapView.Mode = Masterplan.Controls.MapViewMode.Thumbnail;
			this.MapView.Name = "MapView";
			this.MapView.Plot = null;
			this.MapView.ScalingFactor = 1D;
			this.MapView.SelectedArea = null;
			this.MapView.SelectedTiles = null;
			this.MapView.Selection = new System.Drawing.Rectangle(0, 0, 0, 0);
			this.MapView.ShowAllWaves = false;
			this.MapView.ShowAuras = true;
			this.MapView.ShowConditions = true;
			this.MapView.ShowCreatureLabels = true;
			this.MapView.ShowCreatures = Masterplan.Controls.CreatureViewMode.All;
			this.MapView.ShowGrid = Masterplan.Controls.MapGridMode.None;
			this.MapView.ShowGridLabels = false;
			this.MapView.ShowHealthBars = false;
			this.MapView.ShowPictureTokens = true;
			this.MapView.Size = new System.Drawing.Size(414, 317);
			this.MapView.TabIndex = 0;
			this.MapView.Tactical = true;
			this.MapView.TokenLinks = null;
			this.MapView.Viewpoint = new System.Drawing.Rectangle(0, 0, 0, 0);
			this.MapView.ItemMoved += new Masterplan.Events.MovementEventHandler(this.MapView_ItemMoved);
			this.MapView.HoverTokenChanged += new System.EventHandler(this.MapView_HoverTokenChanged);
			this.MapView.SelectedTokensChanged += new System.EventHandler(this.MapView_SelectedTokensChanged);
			this.MapView.TokenActivated += new Masterplan.Events.TokenEventHandler(this.MapView_TokenActivated);
			this.MapView.TokenDragged += new Masterplan.Events.DraggedTokenEventHandler(this.MapView_TokenDragged);
			this.MapView.CreateTokenLink += new Masterplan.Events.CreateTokenLinkEventHandler(this.MapView_CreateTokenLink);
			this.MapView.EditTokenLink += new Masterplan.Events.TokenLinkEventHandler(this.MapView_EditTokenLink);
			this.MapView.SketchCreated += new Masterplan.Events.MapSketchEventHandler(this.MapView_SketchCreated);
			this.MapView.MouseZoomed += new System.Windows.Forms.MouseEventHandler(this.MapView_MouseZoomed);
			this.MapView.CancelledScrolling += new System.EventHandler(this.MapView_CancelledScrolling);
			// 
			// MapContext
			// 
			this.MapContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MapDetails,
            this.toolStripMenuItem2,
            this.MapDamage,
            this.MapHeal,
            this.MapAddEffect,
            this.MapRemoveEffect,
            this.MapSetPicture,
            this.toolStripMenuItem1,
            this.MapRemove,
            this.MapCreateCopy,
            this.toolStripSeparator2,
            this.MapVisible,
            this.MapDelay,
            this.toolStripSeparator22,
            this.MapContextDrawing,
            this.MapContextClearDrawings,
            this.toolStripSeparator25,
            this.MapContextLOS,
            this.toolStripSeparator24,
            this.MapContextOverlay});
			this.MapContext.Name = "MapContext";
			this.MapContext.Size = new System.Drawing.Size(185, 348);
			this.MapContext.Opening += new System.ComponentModel.CancelEventHandler(this.MapContext_Opening);
			// 
			// MapDetails
			// 
			this.MapDetails.Name = "MapDetails";
			this.MapDetails.Size = new System.Drawing.Size(184, 22);
			this.MapDetails.Text = "Details";
			this.MapDetails.Click += new System.EventHandler(this.MapDetails_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(181, 6);
			// 
			// MapDamage
			// 
			this.MapDamage.Name = "MapDamage";
			this.MapDamage.Size = new System.Drawing.Size(184, 22);
			this.MapDamage.Text = "Damage...";
			this.MapDamage.Click += new System.EventHandler(this.MapDamage_Click);
			// 
			// MapHeal
			// 
			this.MapHeal.Name = "MapHeal";
			this.MapHeal.Size = new System.Drawing.Size(184, 22);
			this.MapHeal.Text = "Heal...";
			this.MapHeal.Click += new System.EventHandler(this.MapHeal_Click);
			// 
			// MapAddEffect
			// 
			this.MapAddEffect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.effectToolStripMenuItem2});
			this.MapAddEffect.Name = "MapAddEffect";
			this.MapAddEffect.Size = new System.Drawing.Size(184, 22);
			this.MapAddEffect.Text = "Add Effect";
			this.MapAddEffect.DropDownOpening += new System.EventHandler(this.MapCondition_DropDownOpening);
			// 
			// effectToolStripMenuItem2
			// 
			this.effectToolStripMenuItem2.Name = "effectToolStripMenuItem2";
			this.effectToolStripMenuItem2.Size = new System.Drawing.Size(112, 22);
			this.effectToolStripMenuItem2.Text = "[effect]";
			// 
			// MapRemoveEffect
			// 
			this.MapRemoveEffect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.effectToolStripMenuItem4});
			this.MapRemoveEffect.Name = "MapRemoveEffect";
			this.MapRemoveEffect.Size = new System.Drawing.Size(184, 22);
			this.MapRemoveEffect.Text = "Remove Effect";
			this.MapRemoveEffect.DropDownOpening += new System.EventHandler(this.MapRemoveEffect_DropDownOpening);
			// 
			// effectToolStripMenuItem4
			// 
			this.effectToolStripMenuItem4.Name = "effectToolStripMenuItem4";
			this.effectToolStripMenuItem4.Size = new System.Drawing.Size(112, 22);
			this.effectToolStripMenuItem4.Text = "[effect]";
			// 
			// MapSetPicture
			// 
			this.MapSetPicture.Name = "MapSetPicture";
			this.MapSetPicture.Size = new System.Drawing.Size(184, 22);
			this.MapSetPicture.Text = "Set Picture...";
			this.MapSetPicture.Click += new System.EventHandler(this.MapSetPicture_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 6);
			// 
			// MapRemove
			// 
			this.MapRemove.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MapRemoveMap,
            this.MapRemoveCombat});
			this.MapRemove.Name = "MapRemove";
			this.MapRemove.Size = new System.Drawing.Size(184, 22);
			this.MapRemove.Text = "Remove";
			// 
			// MapRemoveMap
			// 
			this.MapRemoveMap.Name = "MapRemoveMap";
			this.MapRemoveMap.Size = new System.Drawing.Size(192, 22);
			this.MapRemoveMap.Text = "Remove from Map";
			this.MapRemoveMap.Click += new System.EventHandler(this.MapRemoveMap_Click);
			// 
			// MapRemoveCombat
			// 
			this.MapRemoveCombat.Name = "MapRemoveCombat";
			this.MapRemoveCombat.Size = new System.Drawing.Size(192, 22);
			this.MapRemoveCombat.Text = "Remove from Combat";
			this.MapRemoveCombat.Click += new System.EventHandler(this.MapRemoveCombat_Click);
			// 
			// MapCreateCopy
			// 
			this.MapCreateCopy.Name = "MapCreateCopy";
			this.MapCreateCopy.Size = new System.Drawing.Size(184, 22);
			this.MapCreateCopy.Text = "Create Duplicate";
			this.MapCreateCopy.Click += new System.EventHandler(this.MapCreateCopy_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
			// 
			// MapVisible
			// 
			this.MapVisible.Name = "MapVisible";
			this.MapVisible.Size = new System.Drawing.Size(184, 22);
			this.MapVisible.Text = "Visible";
			this.MapVisible.Click += new System.EventHandler(this.MapVisible_Click);
			// 
			// MapDelay
			// 
			this.MapDelay.Name = "MapDelay";
			this.MapDelay.Size = new System.Drawing.Size(184, 22);
			this.MapDelay.Text = "Delay / Ready Action";
			this.MapDelay.Click += new System.EventHandler(this.MapDelay_Click);
			// 
			// toolStripSeparator22
			// 
			this.toolStripSeparator22.Name = "toolStripSeparator22";
			this.toolStripSeparator22.Size = new System.Drawing.Size(181, 6);
			// 
			// MapContextDrawing
			// 
			this.MapContextDrawing.Name = "MapContextDrawing";
			this.MapContextDrawing.Size = new System.Drawing.Size(184, 22);
			this.MapContextDrawing.Text = "Allow Drawing";
			this.MapContextDrawing.Click += new System.EventHandler(this.MapDrawing_Click);
			// 
			// MapContextClearDrawings
			// 
			this.MapContextClearDrawings.Name = "MapContextClearDrawings";
			this.MapContextClearDrawings.Size = new System.Drawing.Size(184, 22);
			this.MapContextClearDrawings.Text = "Clear Drawings";
			this.MapContextClearDrawings.Click += new System.EventHandler(this.MapClearDrawings_Click);
			// 
			// toolStripSeparator25
			// 
			this.toolStripSeparator25.Name = "toolStripSeparator25";
			this.toolStripSeparator25.Size = new System.Drawing.Size(181, 6);
			// 
			// MapContextLOS
			// 
			this.MapContextLOS.Name = "MapContextLOS";
			this.MapContextLOS.Size = new System.Drawing.Size(184, 22);
			this.MapContextLOS.Text = "Line of Sight";
			this.MapContextLOS.Click += new System.EventHandler(this.MapLOS_Click);
			// 
			// toolStripSeparator24
			// 
			this.toolStripSeparator24.Name = "toolStripSeparator24";
			this.toolStripSeparator24.Size = new System.Drawing.Size(181, 6);
			// 
			// MapContextOverlay
			// 
			this.MapContextOverlay.Name = "MapContextOverlay";
			this.MapContextOverlay.Size = new System.Drawing.Size(184, 22);
			this.MapContextOverlay.Text = "Add Overlay...";
			this.MapContextOverlay.Click += new System.EventHandler(this.MapContextOverlay_Click);
			// 
			// ZoomGauge
			// 
			this.ZoomGauge.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ZoomGauge.Location = new System.Drawing.Point(0, 317);
			this.ZoomGauge.Maximum = 100;
			this.ZoomGauge.Name = "ZoomGauge";
			this.ZoomGauge.Size = new System.Drawing.Size(414, 45);
			this.ZoomGauge.TabIndex = 1;
			this.ZoomGauge.TickFrequency = 10;
			this.ZoomGauge.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.ZoomGauge.Value = 50;
			this.ZoomGauge.Visible = false;
			this.ZoomGauge.Scroll += new System.EventHandler(this.ZoomGauge_Scroll);
			// 
			// MapTooltip
			// 
			this.MapTooltip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			// 
			// Statusbar
			// 
			this.Statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RoundLbl,
            this.XPLbl,
            this.LevelLbl});
			this.Statusbar.Location = new System.Drawing.Point(0, 362);
			this.Statusbar.Name = "Statusbar";
			this.Statusbar.Size = new System.Drawing.Size(826, 22);
			this.Statusbar.SizingGrip = false;
			this.Statusbar.TabIndex = 0;
			this.Statusbar.Text = "statusStrip1";
			// 
			// RoundLbl
			// 
			this.RoundLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.RoundLbl.Name = "RoundLbl";
			this.RoundLbl.Size = new System.Drawing.Size(48, 17);
			this.RoundLbl.Text = "[round]";
			// 
			// XPLbl
			// 
			this.XPLbl.Name = "XPLbl";
			this.XPLbl.Size = new System.Drawing.Size(28, 17);
			this.XPLbl.Text = "[xp]";
			// 
			// LevelLbl
			// 
			this.LevelLbl.Name = "LevelLbl";
			this.LevelLbl.Size = new System.Drawing.Size(39, 17);
			this.LevelLbl.Text = "[level]";
			// 
			// MainPanel
			// 
			this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MainPanel.Controls.Add(this.MapSplitter);
			this.MainPanel.Controls.Add(this.InitiativePanel);
			this.MainPanel.Controls.Add(this.Statusbar);
			this.MainPanel.Location = new System.Drawing.Point(12, 28);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(826, 384);
			this.MainPanel.TabIndex = 1;
			// 
			// InitiativePanel
			// 
			this.InitiativePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.InitiativePanel.CurrentInitiative = 0;
			this.InitiativePanel.Dock = System.Windows.Forms.DockStyle.Right;
			this.InitiativePanel.InitiativeScores = ((System.Collections.Generic.List<int>)(resources.GetObject("InitiativePanel.InitiativeScores")));
			this.InitiativePanel.Location = new System.Drawing.Point(786, 0);
			this.InitiativePanel.Name = "InitiativePanel";
			this.InitiativePanel.Size = new System.Drawing.Size(40, 362);
			this.InitiativePanel.TabIndex = 2;
			this.InitiativePanel.InitiativeChanged += new System.EventHandler(this.InitiativePanel_InitiativeChanged);
			// 
			// CloseBtn
			// 
			this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.CloseBtn.Location = new System.Drawing.Point(718, 418);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.Size = new System.Drawing.Size(120, 23);
			this.CloseBtn.TabIndex = 6;
			this.CloseBtn.Text = "End Encounter";
			this.CloseBtn.UseVisualStyleBackColor = true;
			this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
			// 
			// PauseBtn
			// 
			this.PauseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.PauseBtn.Location = new System.Drawing.Point(592, 418);
			this.PauseBtn.Name = "PauseBtn";
			this.PauseBtn.Size = new System.Drawing.Size(120, 23);
			this.PauseBtn.TabIndex = 5;
			this.PauseBtn.Text = "Pause Encounter";
			this.PauseBtn.UseVisualStyleBackColor = true;
			this.PauseBtn.Click += new System.EventHandler(this.PauseBtn_Click);
			// 
			// InfoBtn
			// 
			this.InfoBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.InfoBtn.Location = new System.Drawing.Point(12, 418);
			this.InfoBtn.Name = "InfoBtn";
			this.InfoBtn.Size = new System.Drawing.Size(75, 23);
			this.InfoBtn.TabIndex = 2;
			this.InfoBtn.Text = "Information";
			this.InfoBtn.UseVisualStyleBackColor = true;
			this.InfoBtn.Click += new System.EventHandler(this.InfoBtn_Click);
			// 
			// DieRollerBtn
			// 
			this.DieRollerBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.DieRollerBtn.Location = new System.Drawing.Point(93, 418);
			this.DieRollerBtn.Name = "DieRollerBtn";
			this.DieRollerBtn.Size = new System.Drawing.Size(75, 23);
			this.DieRollerBtn.TabIndex = 3;
			this.DieRollerBtn.Text = "Die Roller";
			this.DieRollerBtn.UseVisualStyleBackColor = true;
			this.DieRollerBtn.Click += new System.EventHandler(this.DieRollerBtn_Click);
			// 
			// ReportBtn
			// 
			this.ReportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ReportBtn.Location = new System.Drawing.Point(174, 418);
			this.ReportBtn.Name = "ReportBtn";
			this.ReportBtn.Size = new System.Drawing.Size(75, 23);
			this.ReportBtn.TabIndex = 4;
			this.ReportBtn.Text = "Report";
			this.ReportBtn.UseVisualStyleBackColor = true;
			this.ReportBtn.Click += new System.EventHandler(this.ReportBtn_Click);
			// 
			// CombatForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(850, 453);
			this.Controls.Add(this.ReportBtn);
			this.Controls.Add(this.DieRollerBtn);
			this.Controls.Add(this.Toolbar);
			this.Controls.Add(this.InfoBtn);
			this.Controls.Add(this.MainPanel);
			this.Controls.Add(this.CloseBtn);
			this.Controls.Add(this.PauseBtn);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "CombatForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Combat Encounter";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CombatForm_FormClosing);
			this.Shown += new System.EventHandler(this.CombatForm_Shown);
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			this.MapSplitter.Panel1.ResumeLayout(false);
			this.MapSplitter.Panel2.ResumeLayout(false);
			this.MapSplitter.Panel2.PerformLayout();
			this.MapSplitter.ResumeLayout(false);
			this.Pages.ResumeLayout(false);
			this.CombatantsPage.ResumeLayout(false);
			this.ListSplitter.Panel1.ResumeLayout(false);
			this.ListSplitter.Panel2.ResumeLayout(false);
			this.ListSplitter.ResumeLayout(false);
			this.ListContext.ResumeLayout(false);
			this.PreviewPanel.ResumeLayout(false);
			this.TemplatesPage.ResumeLayout(false);
			this.LogPage.ResumeLayout(false);
			this.MapContext.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ZoomGauge)).EndInit();
			this.Statusbar.ResumeLayout(false);
			this.Statusbar.PerformLayout();
			this.MainPanel.ResumeLayout(false);
			this.MainPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.SplitContainer MapSplitter;
		private CombatListControl CombatList;
		private System.Windows.Forms.ColumnHeader NameHdr;
		private System.Windows.Forms.ColumnHeader InitHdr;
		private System.Windows.Forms.ColumnHeader HPHdr;
		private System.Windows.Forms.ToolTip MapTooltip;
		private System.Windows.Forms.ToolStripButton DetailsBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.SplitContainer ListSplitter;
		private System.Windows.Forms.StatusStrip Statusbar;
		private System.Windows.Forms.ToolStripStatusLabel XPLbl;
		private System.Windows.Forms.ContextMenuStrip MapContext;
		private System.Windows.Forms.ToolStripMenuItem MapDetails;
		private System.Windows.Forms.ToolStripMenuItem MapVisible;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripButton DamageBtn;
		private System.Windows.Forms.ToolStripMenuItem MapDamage;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ContextMenuStrip ListContext;
		private System.Windows.Forms.ToolStripMenuItem ListDetails;
		private System.Windows.Forms.ToolStripMenuItem ListDamage;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem ListVisible;
		public Masterplan.Controls.MapView MapView;
		private System.Windows.Forms.ToolStripDropDownButton CombatantsBtn;
		private System.Windows.Forms.ToolStripMenuItem CombatantsAdd;
		private System.Windows.Forms.ToolStripMenuItem CombatantsRemove;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripMenuItem CombatantsAddToken;
		private System.Windows.Forms.TrackBar ZoomGauge;
		private System.Windows.Forms.ToolStripDropDownButton MapMenu;
		private System.Windows.Forms.ToolStripMenuItem MapReset;
		private System.Windows.Forms.ToolStripMenuItem MapNavigate;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripMenuItem MapExport;
		private System.Windows.Forms.WebBrowser Preview;
		private System.Windows.Forms.Panel PreviewPanel;
		private System.Windows.Forms.ToolStripButton NextInitBtn;
		private System.Windows.Forms.ToolStripMenuItem ShowMap;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripDropDownButton PlayerViewMapMenu;
		private System.Windows.Forms.ToolStripMenuItem PlayerViewMap;
		private System.Windows.Forms.ToolStripMenuItem PlayerLabels;
		private System.Windows.Forms.ToolStripMenuItem MapFog;
		private System.Windows.Forms.ToolStripMenuItem MapFogAllCreatures;
		private System.Windows.Forms.ToolStripMenuItem MapFogVisibleCreatures;
		private System.Windows.Forms.ToolStripMenuItem MapFogHideCreatures;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
		private System.Windows.Forms.ToolStripMenuItem PlayerViewFog;
		private System.Windows.Forms.ToolStripMenuItem PlayerFogAll;
		private System.Windows.Forms.ToolStripMenuItem PlayerFogVisible;
		private System.Windows.Forms.ToolStripMenuItem PlayerFogNone;
		private System.Windows.Forms.ToolStripMenuItem MapGrid;
		private System.Windows.Forms.ToolStripMenuItem PlayerViewGrid;
		private System.Windows.Forms.ToolStripMenuItem MapPrint;
		private System.Windows.Forms.ToolStripMenuItem MapLOS;
		private System.Windows.Forms.ToolStripMenuItem PlayerViewLOS;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
		private System.Windows.Forms.ToolStripMenuItem CombatantsHideAll;
		private System.Windows.Forms.ToolStripMenuItem CombatantsShowAll;
		private System.Windows.Forms.ToolStripDropDownButton OptionsMenu;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
		private System.Windows.Forms.ToolStripMenuItem OneColumn;
		private System.Windows.Forms.ToolStripMenuItem TwoColumns;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem ToolsAutoRemove;
        private System.Windows.Forms.ToolStripStatusLabel LevelLbl;
        private System.Windows.Forms.ToolStripMenuItem CombatantsAddOverlay;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem PlayerHealth;
        private System.Windows.Forms.ToolStripMenuItem MapHealth;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
		private System.Windows.Forms.Panel MainPanel;
		private System.Windows.Forms.Button CloseBtn;
		private System.Windows.Forms.ToolStripButton DelayBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
		private System.Windows.Forms.ToolStripMenuItem ListDelay;
		private System.Windows.Forms.ToolStripMenuItem MapDelay;
		private System.Windows.Forms.ToolStripStatusLabel RoundLbl;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
		private System.Windows.Forms.ToolStripMenuItem MapRight;
		private System.Windows.Forms.ToolStripMenuItem MapBelow;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator21;
		private System.Windows.Forms.ToolStripMenuItem OptionsLandscape;
		private System.Windows.Forms.ToolStripMenuItem OptionsPortrait;
		private System.Windows.Forms.ToolStripMenuItem MapDrawing;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
		private System.Windows.Forms.ToolStripMenuItem MapClearDrawings;
		private System.Windows.Forms.Button PauseBtn;
		private System.Windows.Forms.ToolStripDropDownButton EffectMenu;
		private System.Windows.Forms.ToolStripMenuItem ListCondition;
		private System.Windows.Forms.ToolStripMenuItem MapAddEffect;
		private System.Windows.Forms.ToolStripMenuItem effectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem effectToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem effectToolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem ListRemoveEffect;
		private System.Windows.Forms.ToolStripMenuItem effectToolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem MapRemoveEffect;
		private System.Windows.Forms.ToolStripMenuItem effectToolStripMenuItem4;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator22;
		private System.Windows.Forms.ToolStripMenuItem MapContextDrawing;
		private System.Windows.Forms.ToolStripMenuItem MapContextClearDrawings;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator24;
		private System.Windows.Forms.ToolStripMenuItem MapContextOverlay;
		private System.Windows.Forms.ToolStripMenuItem MapGridLabels;
		private System.Windows.Forms.ToolStripMenuItem PlayerViewGridLabels;
		private System.Windows.Forms.ToolStripMenuItem ListHeal;
		private System.Windows.Forms.ToolStripMenuItem MapHeal;
		private System.Windows.Forms.ToolStripButton HealBtn;
		private System.Windows.Forms.ToolStripMenuItem MapPictureTokens;
		private System.Windows.Forms.ToolStripMenuItem PlayerPictureTokens;
		private System.Windows.Forms.ToolStripDropDownButton ToolsMenu;
		private System.Windows.Forms.ToolStripMenuItem ToolsEffects;
		private System.Windows.Forms.ToolStripMenuItem ToolsLinks;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
		private System.Windows.Forms.ToolStripMenuItem ToolsAddIns;
		private System.Windows.Forms.ToolStripMenuItem addinsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ListCreateCopy;
		private System.Windows.Forms.ToolStripMenuItem MapCreateCopy;
		private System.Windows.Forms.ToolStripMenuItem PlayerViewInitList;
		private System.Windows.Forms.ToolStripMenuItem MapSetPicture;
		private System.Windows.Forms.ToolStripDropDownButton PlayerViewNoMapMenu;
		private System.Windows.Forms.ToolStripMenuItem PlayerViewNoMapShowInitiativeList;
		private System.Windows.Forms.ToolStripMenuItem MapConditions;
		private System.Windows.Forms.ToolStripMenuItem PlayerConditions;
		private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.TabPage CombatantsPage;
		private System.Windows.Forms.TabPage TemplatesPage;
		private System.Windows.Forms.ListView TemplateList;
		private System.Windows.Forms.ColumnHeader TemplateHdr;
		private System.Windows.Forms.Button InfoBtn;
		private Masterplan.Controls.InitiativePanel InitiativePanel;
		private System.Windows.Forms.ToolStripMenuItem OptionsShowInit;
		private System.Windows.Forms.ToolStripMenuItem PlayerViewNoMapShowLabels;
		private System.Windows.Forms.ColumnHeader DefHdr;
		private System.Windows.Forms.ToolStripMenuItem ListRemove;
		private System.Windows.Forms.ToolStripMenuItem MapRemove;
		private System.Windows.Forms.ToolStripMenuItem ListRemoveMap;
		private System.Windows.Forms.ToolStripMenuItem ListRemoveCombat;
		private System.Windows.Forms.ToolStripMenuItem MapRemoveMap;
		private System.Windows.Forms.ToolStripMenuItem MapRemoveCombat;
		private System.Windows.Forms.Button DieRollerBtn;
		private System.Windows.Forms.ColumnHeader EffectsHdr;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator23;
		private System.Windows.Forms.ToolStripMenuItem ToolsColumns;
		private System.Windows.Forms.ToolStripMenuItem ToolsColumnsInit;
		private System.Windows.Forms.ToolStripMenuItem ToolsColumnsHP;
		private System.Windows.Forms.ToolStripMenuItem ToolsColumnsDefences;
		private System.Windows.Forms.ToolStripMenuItem ToolsColumnsConditions;
		private System.Windows.Forms.TabPage LogPage;
		private System.Windows.Forms.WebBrowser LogBrowser;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator25;
		private System.Windows.Forms.ToolStripMenuItem MapContextLOS;
		private System.Windows.Forms.Button ReportBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator26;
		private System.Windows.Forms.ToolStripMenuItem CombatantsWaves;
	}
}