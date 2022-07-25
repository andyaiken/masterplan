namespace Masterplan.UI
{
	partial class DemographicsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DemographicsForm));
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.LevelBtn = new System.Windows.Forms.ToolStripButton();
			this.RoleBtn = new System.Windows.Forms.ToolStripButton();
			this.BreakdownPanel = new Masterplan.Controls.DemographicsPanel();
			this.StatusBtn = new System.Windows.Forms.ToolStripButton();
			this.Toolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LevelBtn,
            this.RoleBtn,
            this.StatusBtn});
			this.Toolbar.Location = new System.Drawing.Point(0, 0);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(752, 25);
			this.Toolbar.TabIndex = 1;
			this.Toolbar.Text = Session.I18N.toolStrip1;
			// 
			// LevelBtn
			// 
			this.LevelBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.LevelBtn.Image = ((System.Drawing.Image)(resources.GetObject("LevelBtn.Image")));
			this.LevelBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.LevelBtn.Name = "LevelBtn";
			this.LevelBtn.Size = new System.Drawing.Size(54, 22);
			this.LevelBtn.Text = "By Level";
			this.LevelBtn.Click += new System.EventHandler(this.LevelBtn_Click);
			// 
			// RoleBtn
			// 
			this.RoleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.RoleBtn.Image = ((System.Drawing.Image)(resources.GetObject("RoleBtn.Image")));
			this.RoleBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RoleBtn.Name = "RoleBtn";
			this.RoleBtn.Size = new System.Drawing.Size(50, 22);
			this.RoleBtn.Text = "By Role";
			this.RoleBtn.Click += new System.EventHandler(this.RoleBtn_Click);
			// 
			// BreakdownPanel
			// 
			this.BreakdownPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BreakdownPanel.Library = null;
			this.BreakdownPanel.Location = new System.Drawing.Point(0, 25);
			this.BreakdownPanel.Mode = Masterplan.Controls.DemographicsMode.Level;
			this.BreakdownPanel.Name = "BreakdownPanel";
			this.BreakdownPanel.Size = new System.Drawing.Size(752, 265);
			this.BreakdownPanel.TabIndex = 0;
			// 
			// StatusBtn
			// 
			this.StatusBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.StatusBtn.Image = ((System.Drawing.Image)(resources.GetObject("StatusBtn.Image")));
			this.StatusBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.StatusBtn.Name = "StatusBtn";
			this.StatusBtn.Size = new System.Drawing.Size(59, 22);
			this.StatusBtn.Text = "By Status";
			this.StatusBtn.Click += new System.EventHandler(this.StatusBtn_Click);
			// 
			// LibraryBreakdownForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(752, 290);
			this.Controls.Add(this.BreakdownPanel);
			this.Controls.Add(this.Toolbar);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LibraryBreakdownForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Library Breakdown";
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Masterplan.Controls.DemographicsPanel BreakdownPanel;
		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ToolStripButton LevelBtn;
		private System.Windows.Forms.ToolStripButton RoleBtn;
		private System.Windows.Forms.ToolStripButton StatusBtn;
	}
}