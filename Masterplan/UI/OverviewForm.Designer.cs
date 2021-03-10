namespace Masterplan.UI
{
	partial class OverviewForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OverviewForm));
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.EncounterBtn = new System.Windows.Forms.ToolStripButton();
			this.TrapBtn = new System.Windows.Forms.ToolStripButton();
			this.ChallengeBtn = new System.Windows.Forms.ToolStripButton();
			this.TreasureBtn = new System.Windows.Forms.ToolStripButton();
			this.ItemList = new System.Windows.Forms.ListView();
			this.PointHdr = new System.Windows.Forms.ColumnHeader();
			this.InfoHdr = new System.Windows.Forms.ColumnHeader();
			this.MainPanel = new System.Windows.Forms.Panel();
			this.CloseBtn = new System.Windows.Forms.Button();
			this.Toolbar.SuspendLayout();
			this.MainPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EncounterBtn,
            this.TrapBtn,
            this.ChallengeBtn,
            this.TreasureBtn});
			this.Toolbar.Location = new System.Drawing.Point(0, 0);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(513, 25);
			this.Toolbar.TabIndex = 0;
			this.Toolbar.Text = "toolStrip1";
			// 
			// EncounterBtn
			// 
			this.EncounterBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.EncounterBtn.Image = ((System.Drawing.Image)(resources.GetObject("EncounterBtn.Image")));
			this.EncounterBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EncounterBtn.Name = "EncounterBtn";
			this.EncounterBtn.Size = new System.Drawing.Size(70, 22);
			this.EncounterBtn.Text = "Encounters";
			this.EncounterBtn.Click += new System.EventHandler(this.EncounterBtn_Click);
			// 
			// TrapBtn
			// 
			this.TrapBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.TrapBtn.Image = ((System.Drawing.Image)(resources.GetObject("TrapBtn.Image")));
			this.TrapBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TrapBtn.Name = "TrapBtn";
			this.TrapBtn.Size = new System.Drawing.Size(40, 22);
			this.TrapBtn.Text = "Traps";
			this.TrapBtn.Click += new System.EventHandler(this.TrapBtn_Click);
			// 
			// ChallengeBtn
			// 
			this.ChallengeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ChallengeBtn.Image = ((System.Drawing.Image)(resources.GetObject("ChallengeBtn.Image")));
			this.ChallengeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ChallengeBtn.Name = "ChallengeBtn";
			this.ChallengeBtn.Size = new System.Drawing.Size(93, 22);
			this.ChallengeBtn.Text = "Skill Challenges";
			this.ChallengeBtn.Click += new System.EventHandler(this.ChallengeBtn_Click);
			// 
			// TreasureBtn
			// 
			this.TreasureBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.TreasureBtn.Image = ((System.Drawing.Image)(resources.GetObject("TreasureBtn.Image")));
			this.TreasureBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TreasureBtn.Name = "TreasureBtn";
			this.TreasureBtn.Size = new System.Drawing.Size(56, 22);
			this.TreasureBtn.Text = "Treasure";
			this.TreasureBtn.Click += new System.EventHandler(this.TreasureBtn_Click);
			// 
			// ItemList
			// 
			this.ItemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PointHdr,
            this.InfoHdr});
			this.ItemList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ItemList.FullRowSelect = true;
			this.ItemList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.ItemList.HideSelection = false;
			this.ItemList.Location = new System.Drawing.Point(0, 25);
			this.ItemList.MultiSelect = false;
			this.ItemList.Name = "ItemList";
			this.ItemList.Size = new System.Drawing.Size(513, 203);
			this.ItemList.TabIndex = 1;
			this.ItemList.UseCompatibleStateImageBehavior = false;
			this.ItemList.View = System.Windows.Forms.View.Details;
			this.ItemList.DoubleClick += new System.EventHandler(this.ItemList_DoubleClick);
			// 
			// PointHdr
			// 
			this.PointHdr.Text = "Point";
			this.PointHdr.Width = 100;
			// 
			// InfoHdr
			// 
			this.InfoHdr.Text = "Information";
			this.InfoHdr.Width = 384;
			// 
			// MainPanel
			// 
			this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.MainPanel.Controls.Add(this.ItemList);
			this.MainPanel.Controls.Add(this.Toolbar);
			this.MainPanel.Location = new System.Drawing.Point(12, 12);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(513, 228);
			this.MainPanel.TabIndex = 2;
			// 
			// CloseBtn
			// 
			this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.CloseBtn.Location = new System.Drawing.Point(450, 246);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.Size = new System.Drawing.Size(75, 23);
			this.CloseBtn.TabIndex = 3;
			this.CloseBtn.Text = "Close";
			this.CloseBtn.UseVisualStyleBackColor = true;
			// 
			// OverviewForm
			// 
			this.AcceptButton = this.CloseBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(537, 281);
			this.Controls.Add(this.CloseBtn);
			this.Controls.Add(this.MainPanel);
			this.MinimizeBox = false;
			this.Name = "OverviewForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Project Overview";
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			this.MainPanel.ResumeLayout(false);
			this.MainPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ListView ItemList;
		private System.Windows.Forms.ColumnHeader PointHdr;
		private System.Windows.Forms.ColumnHeader InfoHdr;
		private System.Windows.Forms.ToolStripButton EncounterBtn;
		private System.Windows.Forms.ToolStripButton ChallengeBtn;
		private System.Windows.Forms.ToolStripButton TreasureBtn;
		private System.Windows.Forms.ToolStripButton TrapBtn;
		private System.Windows.Forms.Panel MainPanel;
		private System.Windows.Forms.Button CloseBtn;

	}
}