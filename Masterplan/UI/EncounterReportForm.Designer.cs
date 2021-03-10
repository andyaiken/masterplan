namespace Masterplan.UI
{
	partial class EncounterReportForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EncounterReportForm));
			this.Browser = new System.Windows.Forms.WebBrowser();
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.ReportBtn = new System.Windows.Forms.ToolStripDropDownButton();
			this.ReportTime = new System.Windows.Forms.ToolStripMenuItem();
			this.ReportDamageEnemies = new System.Windows.Forms.ToolStripMenuItem();
			this.ReportDamageAllies = new System.Windows.Forms.ToolStripMenuItem();
			this.ReportMovement = new System.Windows.Forms.ToolStripMenuItem();
			this.BreakdownBtn = new System.Windows.Forms.ToolStripDropDownButton();
			this.BreakdownIndividually = new System.Windows.Forms.ToolStripMenuItem();
			this.BreakdownByController = new System.Windows.Forms.ToolStripMenuItem();
			this.BreakdownByFaction = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.PlayerViewBtn = new System.Windows.Forms.ToolStripButton();
			this.ExportBtn = new System.Windows.Forms.ToolStripButton();
			this.Splitter = new System.Windows.Forms.SplitContainer();
			this.Graph = new Masterplan.Controls.DemographicsPanel();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.MVPLbl = new System.Windows.Forms.ToolStripLabel();
			this.Toolbar.SuspendLayout();
			this.Splitter.Panel1.SuspendLayout();
			this.Splitter.Panel2.SuspendLayout();
			this.Splitter.SuspendLayout();
			this.SuspendLayout();
			// 
			// Browser
			// 
			this.Browser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Browser.IsWebBrowserContextMenuEnabled = false;
			this.Browser.Location = new System.Drawing.Point(0, 0);
			this.Browser.Name = "Browser";
			this.Browser.ScriptErrorsSuppressed = true;
			this.Browser.Size = new System.Drawing.Size(404, 266);
			this.Browser.TabIndex = 2;
			this.Browser.WebBrowserShortcutsEnabled = false;
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReportBtn,
            this.BreakdownBtn,
            this.toolStripSeparator1,
            this.PlayerViewBtn,
            this.ExportBtn,
            this.toolStripSeparator2,
            this.MVPLbl});
			this.Toolbar.Location = new System.Drawing.Point(0, 0);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(811, 25);
			this.Toolbar.TabIndex = 3;
			this.Toolbar.Text = "toolStrip1";
			// 
			// ReportBtn
			// 
			this.ReportBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ReportBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReportTime,
            this.ReportDamageEnemies,
            this.ReportDamageAllies,
            this.ReportMovement});
			this.ReportBtn.Image = ((System.Drawing.Image)(resources.GetObject("ReportBtn.Image")));
			this.ReportBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ReportBtn.Name = "ReportBtn";
			this.ReportBtn.Size = new System.Drawing.Size(84, 22);
			this.ReportBtn.Text = "Report Type";
			// 
			// ReportTime
			// 
			this.ReportTime.Name = "ReportTime";
			this.ReportTime.Size = new System.Drawing.Size(218, 22);
			this.ReportTime.Text = "Time Taken";
			this.ReportTime.Click += new System.EventHandler(this.ReportTime_Click);
			// 
			// ReportDamageEnemies
			// 
			this.ReportDamageEnemies.Name = "ReportDamageEnemies";
			this.ReportDamageEnemies.Size = new System.Drawing.Size(218, 22);
			this.ReportDamageEnemies.Text = "Damage Done (to enemies)";
			this.ReportDamageEnemies.Click += new System.EventHandler(this.ReportDamageEnemies_Click);
			// 
			// ReportDamageAllies
			// 
			this.ReportDamageAllies.Name = "ReportDamageAllies";
			this.ReportDamageAllies.Size = new System.Drawing.Size(218, 22);
			this.ReportDamageAllies.Text = "Damage Done (to allies)";
			this.ReportDamageAllies.Click += new System.EventHandler(this.ReportDamageAllies_Click);
			// 
			// ReportMovement
			// 
			this.ReportMovement.Name = "ReportMovement";
			this.ReportMovement.Size = new System.Drawing.Size(218, 22);
			this.ReportMovement.Text = "Movement";
			this.ReportMovement.Click += new System.EventHandler(this.ReportMovement_Click);
			// 
			// BreakdownBtn
			// 
			this.BreakdownBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.BreakdownBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BreakdownIndividually,
            this.BreakdownByController,
            this.BreakdownByFaction});
			this.BreakdownBtn.Image = ((System.Drawing.Image)(resources.GetObject("BreakdownBtn.Image")));
			this.BreakdownBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BreakdownBtn.Name = "BreakdownBtn";
			this.BreakdownBtn.Size = new System.Drawing.Size(70, 22);
			this.BreakdownBtn.Text = "Grouping";
			// 
			// BreakdownIndividually
			// 
			this.BreakdownIndividually.Name = "BreakdownIndividually";
			this.BreakdownIndividually.Size = new System.Drawing.Size(183, 22);
			this.BreakdownIndividually.Text = "Individually (default)";
			this.BreakdownIndividually.Click += new System.EventHandler(this.BreakdownIndividually_Click);
			// 
			// BreakdownByController
			// 
			this.BreakdownByController.Name = "BreakdownByController";
			this.BreakdownByController.Size = new System.Drawing.Size(183, 22);
			this.BreakdownByController.Text = "By Controller";
			this.BreakdownByController.Click += new System.EventHandler(this.BreakdownByController_Click);
			// 
			// BreakdownByFaction
			// 
			this.BreakdownByFaction.Name = "BreakdownByFaction";
			this.BreakdownByFaction.Size = new System.Drawing.Size(183, 22);
			this.BreakdownByFaction.Text = "By Faction";
			this.BreakdownByFaction.Click += new System.EventHandler(this.BreakdownByFaction_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// PlayerViewBtn
			// 
			this.PlayerViewBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.PlayerViewBtn.Image = ((System.Drawing.Image)(resources.GetObject("PlayerViewBtn.Image")));
			this.PlayerViewBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.PlayerViewBtn.Name = "PlayerViewBtn";
			this.PlayerViewBtn.Size = new System.Drawing.Size(114, 22);
			this.PlayerViewBtn.Text = "Send to Player View";
			this.PlayerViewBtn.Click += new System.EventHandler(this.PlayerViewBtn_Click);
			// 
			// ExportBtn
			// 
			this.ExportBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ExportBtn.Image = ((System.Drawing.Image)(resources.GetObject("ExportBtn.Image")));
			this.ExportBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ExportBtn.Name = "ExportBtn";
			this.ExportBtn.Size = new System.Drawing.Size(44, 22);
			this.ExportBtn.Text = "Export";
			this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
			// 
			// Splitter
			// 
			this.Splitter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Splitter.Location = new System.Drawing.Point(0, 25);
			this.Splitter.Name = "Splitter";
			// 
			// Splitter.Panel1
			// 
			this.Splitter.Panel1.Controls.Add(this.Browser);
			// 
			// Splitter.Panel2
			// 
			this.Splitter.Panel2.Controls.Add(this.Graph);
			this.Splitter.Size = new System.Drawing.Size(811, 266);
			this.Splitter.SplitterDistance = 404;
			this.Splitter.TabIndex = 4;
			// 
			// Graph
			// 
			this.Graph.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Graph.Library = null;
			this.Graph.Location = new System.Drawing.Point(0, 0);
			this.Graph.Mode = Masterplan.Controls.DemographicsMode.Level;
			this.Graph.Name = "Graph";
			this.Graph.Size = new System.Drawing.Size(403, 266);
			this.Graph.Source = Masterplan.Controls.DemographicsSource.Creatures;
			this.Graph.TabIndex = 0;
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// MVPLbl
			// 
			this.MVPLbl.Name = "MVPLbl";
			this.MVPLbl.Size = new System.Drawing.Size(39, 22);
			this.MVPLbl.Text = "[mvp]";
			// 
			// EncounterReportForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(811, 291);
			this.Controls.Add(this.Splitter);
			this.Controls.Add(this.Toolbar);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EncounterReportForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Encounter Report";
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			this.Splitter.Panel1.ResumeLayout(false);
			this.Splitter.Panel2.ResumeLayout(false);
			this.Splitter.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.WebBrowser Browser;
		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ToolStripButton ExportBtn;
		private System.Windows.Forms.ToolStripDropDownButton ReportBtn;
		private System.Windows.Forms.ToolStripDropDownButton BreakdownBtn;
		private System.Windows.Forms.ToolStripMenuItem ReportTime;
		private System.Windows.Forms.ToolStripMenuItem ReportDamageEnemies;
		private System.Windows.Forms.ToolStripMenuItem ReportDamageAllies;
		private System.Windows.Forms.ToolStripMenuItem ReportMovement;
		private System.Windows.Forms.ToolStripMenuItem BreakdownIndividually;
		private System.Windows.Forms.ToolStripMenuItem BreakdownByController;
		private System.Windows.Forms.ToolStripMenuItem BreakdownByFaction;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton PlayerViewBtn;
		private System.Windows.Forms.SplitContainer Splitter;
		private Masterplan.Controls.DemographicsPanel Graph;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripLabel MVPLbl;

	}
}