namespace Masterplan.Controls
{
	partial class MapElementPanel
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapElementPanel));
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.MapView = new Masterplan.Controls.MapView();
			this.Toolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
			this.Toolbar.Location = new System.Drawing.Point(0, 0);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(410, 25);
			this.Toolbar.TabIndex = 0;
			this.Toolbar.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(69, 22);
			this.toolStripButton1.Text = "Select Map";
			this.toolStripButton1.Click += new System.EventHandler(this.MapSelectBtn_Click);
			// 
			// MapView
			// 
			this.MapView.AllowDrop = true;
			this.MapView.AllowLinkCreation = false;
			this.MapView.AllowScrolling = false;
			this.MapView.BackgroundMap = null;
			this.MapView.BorderSize = 0;
			this.MapView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.MapView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MapView.Encounter = null;
			this.MapView.FrameType = Masterplan.Controls.MapDisplayType.Dimmed;
			//this.MapView.HeroData = null;
			this.MapView.HighlightAreas = false;
			this.MapView.LineOfSight = false;
			this.MapView.Location = new System.Drawing.Point(0, 25);
			this.MapView.Map = null;
			this.MapView.Mode = Masterplan.Controls.MapViewMode.Thumbnail;
			this.MapView.Name = "MapView";
			this.MapView.ScalingFactor = 1;
			this.MapView.SelectedTiles = null;
			this.MapView.Selection = new System.Drawing.Rectangle(0, 0, 0, 0);
			this.MapView.ShowCreatureLabels = false;
			this.MapView.ShowCreatures = Masterplan.Controls.CreatureViewMode.None;
			this.MapView.ShowGrid = Masterplan.Controls.MapGridMode.None;
			this.MapView.ShowHealthBars = false;
			this.MapView.Size = new System.Drawing.Size(410, 216);
			this.MapView.TabIndex = 1;
			this.MapView.Tactical = false;
			this.MapView.TokenLinks = null;
			this.MapView.Viewpoint = new System.Drawing.Rectangle(0, 0, 0, 0);
			this.MapView.DoubleClick += new System.EventHandler(this.MapSelectBtn_Click);
			// 
			// MapElementPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.MapView);
			this.Controls.Add(this.Toolbar);
			this.Name = "MapElementPanel";
			this.Size = new System.Drawing.Size(410, 241);
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip Toolbar;
		private MapView MapView;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
	}
}
