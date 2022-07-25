namespace Masterplan.UI
{
	partial class DisplayNameForm
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
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.InfoLbl = new System.Windows.Forms.Label();
			this.CombatantList = new System.Windows.Forms.ListView();
			this.CombatantHdr = new System.Windows.Forms.ColumnHeader();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.SetNameBtn = new System.Windows.Forms.Button();
			this.Pages = new System.Windows.Forms.TabControl();
			this.StatBlockPage = new System.Windows.Forms.TabPage();
			this.Browser = new System.Windows.Forms.WebBrowser();
			this.MapPage = new System.Windows.Forms.TabPage();
			this.Map = new Masterplan.Controls.MapView();
			this.Pages.SuspendLayout();
			this.StatBlockPage.SuspendLayout();
			this.MapPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(444, 333);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 5;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(525, 333);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 6;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// InfoLbl
			// 
			this.InfoLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.InfoLbl.Location = new System.Drawing.Point(12, 9);
			this.InfoLbl.Name = "InfoLbl";
			this.InfoLbl.Size = new System.Drawing.Size(588, 35);
			this.InfoLbl.TabIndex = 0;
			this.InfoLbl.Text = "Click on a creature in the list on the left to change its display name. This can " +
				"be useful if, for example, you need to identify which miniature represents which" +
				" creature.";
			// 
			// CombatantList
			// 
			this.CombatantList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.CombatantList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CombatantHdr});
			this.CombatantList.FullRowSelect = true;
			this.CombatantList.HideSelection = false;
			this.CombatantList.Location = new System.Drawing.Point(12, 47);
			this.CombatantList.MultiSelect = false;
			this.CombatantList.Name = "CombatantList";
			this.CombatantList.Size = new System.Drawing.Size(222, 280);
			this.CombatantList.TabIndex = 1;
			this.CombatantList.UseCompatibleStateImageBehavior = false;
			this.CombatantList.View = System.Windows.Forms.View.Details;
			this.CombatantList.SelectedIndexChanged += new System.EventHandler(this.CombatantList_SelectedIndexChanged);
			// 
			// CombatantHdr
			// 
			this.CombatantHdr.Text = Session.I18N.Creature;
			this.CombatantHdr.Width = 187;
			// 
			// NameBox
			// 
			this.NameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.NameBox.Location = new System.Drawing.Point(240, 47);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(279, 20);
			this.NameBox.TabIndex = 2;
			// 
			// SetNameBtn
			// 
			this.SetNameBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SetNameBtn.Location = new System.Drawing.Point(525, 45);
			this.SetNameBtn.Name = "SetNameBtn";
			this.SetNameBtn.Size = new System.Drawing.Size(75, 23);
			this.SetNameBtn.TabIndex = 3;
			this.SetNameBtn.Text = "Set Name";
			this.SetNameBtn.UseVisualStyleBackColor = true;
			this.SetNameBtn.Click += new System.EventHandler(this.SetNameBtn_Click);
			// 
			// Pages
			// 
			this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Pages.Controls.Add(this.StatBlockPage);
			this.Pages.Controls.Add(this.MapPage);
			this.Pages.Location = new System.Drawing.Point(240, 73);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(360, 254);
			this.Pages.TabIndex = 4;
			// 
			// StatBlockPage
			// 
			this.StatBlockPage.Controls.Add(this.Browser);
			this.StatBlockPage.Location = new System.Drawing.Point(4, 22);
			this.StatBlockPage.Name = "StatBlockPage";
			this.StatBlockPage.Padding = new System.Windows.Forms.Padding(3);
			this.StatBlockPage.Size = new System.Drawing.Size(352, 228);
			this.StatBlockPage.TabIndex = 0;
			this.StatBlockPage.Text = "Stat Block";
			this.StatBlockPage.UseVisualStyleBackColor = true;
			// 
			// Browser
			// 
			this.Browser.AllowWebBrowserDrop = false;
			this.Browser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Browser.IsWebBrowserContextMenuEnabled = false;
			this.Browser.Location = new System.Drawing.Point(3, 3);
			this.Browser.MinimumSize = new System.Drawing.Size(20, 20);
			this.Browser.Name = "Browser";
			this.Browser.ScriptErrorsSuppressed = true;
			this.Browser.Size = new System.Drawing.Size(346, 222);
			this.Browser.TabIndex = 0;
			this.Browser.WebBrowserShortcutsEnabled = false;
			// 
			// MapPage
			// 
			this.MapPage.Controls.Add(this.Map);
			this.MapPage.Location = new System.Drawing.Point(4, 22);
			this.MapPage.Name = "MapPage";
			this.MapPage.Padding = new System.Windows.Forms.Padding(3);
			this.MapPage.Size = new System.Drawing.Size(352, 228);
			this.MapPage.TabIndex = 1;
			this.MapPage.Text = "Map Location";
			this.MapPage.UseVisualStyleBackColor = true;
			// 
			// Map
			// 
			this.Map.AllowDrawing = false;
			this.Map.AllowDrop = true;
			this.Map.AllowLinkCreation = false;
			this.Map.AllowScrolling = false;
			this.Map.BackgroundMap = null;
			this.Map.BorderSize = 0;
			this.Map.Caption = "";
			this.Map.Cursor = System.Windows.Forms.Cursors.Default;
			this.Map.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Map.Encounter = null;
			this.Map.FrameType = Masterplan.Controls.MapDisplayType.Dimmed;
			//this.Map.HeroData = null;
			this.Map.HighlightAreas = false;
			this.Map.HoverToken = null;
			this.Map.LineOfSight = false;
			this.Map.Location = new System.Drawing.Point(3, 3);
			this.Map.Map = null;
			this.Map.Mode = Masterplan.Controls.MapViewMode.Thumbnail;
			this.Map.Name = "Map";
			this.Map.Plot = null;
			this.Map.ScalingFactor = 1;
			this.Map.SelectedArea = null;
			this.Map.SelectedTiles = null;
			this.Map.Selection = new System.Drawing.Rectangle(0, 0, 0, 0);
			this.Map.ShowAuras = false;
			this.Map.ShowConditions = false;
			this.Map.ShowCreatureLabels = true;
			this.Map.ShowCreatures = Masterplan.Controls.CreatureViewMode.All;
			this.Map.ShowGrid = Masterplan.Controls.MapGridMode.None;
			this.Map.ShowGridLabels = false;
			this.Map.ShowHealthBars = false;
			this.Map.ShowPictureTokens = true;
			this.Map.Size = new System.Drawing.Size(346, 222);
			this.Map.TabIndex = 0;
			this.Map.Tactical = false;
			this.Map.TokenLinks = null;
			this.Map.Viewpoint = new System.Drawing.Rectangle(0, 0, 0, 0);
			// 
			// DisplayNameForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(612, 368);
			this.Controls.Add(this.Pages);
			this.Controls.Add(this.SetNameBtn);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.CombatantList);
			this.Controls.Add(this.InfoLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DisplayNameForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Creature Display Names";
			this.Pages.ResumeLayout(false);
			this.StatBlockPage.ResumeLayout(false);
			this.MapPage.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label InfoLbl;
		private System.Windows.Forms.ListView CombatantList;
		private System.Windows.Forms.ColumnHeader CombatantHdr;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.Button SetNameBtn;
		private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.TabPage StatBlockPage;
		private System.Windows.Forms.TabPage MapPage;
		private System.Windows.Forms.WebBrowser Browser;
		private Masterplan.Controls.MapView Map;
	}
}