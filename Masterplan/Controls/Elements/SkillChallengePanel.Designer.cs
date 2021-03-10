namespace Masterplan.Controls
{
	partial class SkillChallengePanel
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
			System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Info", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Primary Skills", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("Other Skills", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("Automatic Failure", System.Windows.Forms.HorizontalAlignment.Left);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkillChallengePanel));
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.SkillList = new System.Windows.Forms.ListView();
			this.InfoHdr = new System.Windows.Forms.ColumnHeader();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.EditBtn = new System.Windows.Forms.ToolStripButton();
			this.LocationBtn = new System.Windows.Forms.ToolStripButton();
			this.ChooseBtn = new System.Windows.Forms.ToolStripButton();
			this.AddLibraryBtn = new System.Windows.Forms.ToolStripButton();
			this.Toolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditBtn,
            this.LocationBtn,
            this.toolStripSeparator1,
            this.ChooseBtn,
            this.toolStripSeparator2,
            this.AddLibraryBtn});
			this.Toolbar.Location = new System.Drawing.Point(0, 0);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(520, 25);
			this.Toolbar.TabIndex = 0;
			this.Toolbar.Text = "toolStrip1";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// SkillList
			// 
			this.SkillList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.InfoHdr});
			this.SkillList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SkillList.FullRowSelect = true;
			listViewGroup5.Header = "Info";
			listViewGroup5.Name = "InfoHdr";
			listViewGroup6.Header = "Primary Skills";
			listViewGroup6.Name = "PrimaryHdr";
			listViewGroup7.Header = "Other Skills";
			listViewGroup7.Name = "SecondaryHdr";
			listViewGroup8.Header = "Automatic Failure";
			listViewGroup8.Name = "listViewGroup1";
			this.SkillList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup5,
            listViewGroup6,
            listViewGroup7,
            listViewGroup8});
			this.SkillList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.SkillList.HideSelection = false;
			this.SkillList.Location = new System.Drawing.Point(0, 25);
			this.SkillList.MultiSelect = false;
			this.SkillList.Name = "SkillList";
			this.SkillList.Size = new System.Drawing.Size(520, 155);
			this.SkillList.TabIndex = 1;
			this.SkillList.UseCompatibleStateImageBehavior = false;
			this.SkillList.View = System.Windows.Forms.View.Details;
			this.SkillList.DoubleClick += new System.EventHandler(this.SkillList_DoubleClick);
			// 
			// InfoHdr
			// 
			this.InfoHdr.Text = "Info";
			this.InfoHdr.Width = 445;
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// EditBtn
			// 
			this.EditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.EditBtn.Image = ((System.Drawing.Image)(resources.GetObject("EditBtn.Image")));
			this.EditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EditBtn.Name = "EditBtn";
			this.EditBtn.Size = new System.Drawing.Size(128, 22);
			this.EditBtn.Text = "Skill Challenge Builder";
			this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
			// 
			// LocationBtn
			// 
			this.LocationBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.LocationBtn.Image = ((System.Drawing.Image)(resources.GetObject("LocationBtn.Image")));
			this.LocationBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.LocationBtn.Name = "LocationBtn";
			this.LocationBtn.Size = new System.Drawing.Size(103, 22);
			this.LocationBtn.Text = "Set Map Location";
			this.LocationBtn.Click += new System.EventHandler(this.LocationBtn_Click);
			// 
			// ChooseBtn
			// 
			this.ChooseBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ChooseBtn.Image = ((System.Drawing.Image)(resources.GetObject("ChooseBtn.Image")));
			this.ChooseBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ChooseBtn.Name = "ChooseBtn";
			this.ChooseBtn.Size = new System.Drawing.Size(136, 22);
			this.ChooseBtn.Text = "Use Standard Challenge";
			this.ChooseBtn.Click += new System.EventHandler(this.ChooseBtn_Click);
			// 
			// AddLibraryBtn
			// 
			this.AddLibraryBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.AddLibraryBtn.Image = ((System.Drawing.Image)(resources.GetObject("AddLibraryBtn.Image")));
			this.AddLibraryBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AddLibraryBtn.Name = "AddLibraryBtn";
			this.AddLibraryBtn.Size = new System.Drawing.Size(86, 22);
			this.AddLibraryBtn.Text = "Add to Library";
			this.AddLibraryBtn.Click += new System.EventHandler(this.AddLibraryBtn_Click);
			// 
			// SkillChallengePanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.SkillList);
			this.Controls.Add(this.Toolbar);
			this.Name = "SkillChallengePanel";
			this.Size = new System.Drawing.Size(520, 180);
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ToolStripButton EditBtn;
		private System.Windows.Forms.ListView SkillList;
		private System.Windows.Forms.ColumnHeader InfoHdr;
		private System.Windows.Forms.ToolStripButton ChooseBtn;
        private System.Windows.Forms.ToolStripButton LocationBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton AddLibraryBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
	}
}
