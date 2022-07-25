namespace Masterplan.UI
{
	partial class OptionCreatureLoreForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionCreatureLoreForm));
			this.NameLbl = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.Pages = new System.Windows.Forms.TabControl();
			this.InfoPage = new System.Windows.Forms.TabPage();
			this.InfoList = new System.Windows.Forms.ListView();
			this.InfoHdr = new System.Windows.Forms.ColumnHeader();
			this.LevelToolbar = new System.Windows.Forms.ToolStrip();
			this.AddBtn = new System.Windows.Forms.ToolStripButton();
			this.RemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.EditBtn = new System.Windows.Forms.ToolStripButton();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.SkillLbl = new System.Windows.Forms.Label();
			this.SkillBox = new System.Windows.Forms.ComboBox();
			this.Pages.SuspendLayout();
			this.InfoPage.SuspendLayout();
			this.LevelToolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// NameLbl
			// 
			this.NameLbl.AutoSize = true;
			this.NameLbl.Location = new System.Drawing.Point(12, 15);
			this.NameLbl.Name = "NameLbl";
			this.NameLbl.Size = new System.Drawing.Size(81, 13);
			this.NameLbl.TabIndex = 0;
			this.NameLbl.Text = "Creature Name:";
			// 
			// NameBox
			// 
			this.NameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.NameBox.Location = new System.Drawing.Point(99, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(230, 20);
			this.NameBox.TabIndex = 1;
			// 
			// Pages
			// 
			this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Pages.Controls.Add(this.InfoPage);
			this.Pages.Location = new System.Drawing.Point(12, 65);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(317, 203);
			this.Pages.TabIndex = 4;
			// 
			// InfoPage
			// 
			this.InfoPage.Controls.Add(this.InfoList);
			this.InfoPage.Controls.Add(this.LevelToolbar);
			this.InfoPage.Location = new System.Drawing.Point(4, 22);
			this.InfoPage.Name = "InfoPage";
			this.InfoPage.Padding = new System.Windows.Forms.Padding(3);
			this.InfoPage.Size = new System.Drawing.Size(309, 177);
			this.InfoPage.TabIndex = 2;
			this.InfoPage.Text = Session.I18N.Information;
			this.InfoPage.UseVisualStyleBackColor = true;
			// 
			// InfoList
			// 
			this.InfoList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.InfoHdr});
			this.InfoList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.InfoList.FullRowSelect = true;
			this.InfoList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.InfoList.HideSelection = false;
			this.InfoList.Location = new System.Drawing.Point(3, 28);
			this.InfoList.MultiSelect = false;
			this.InfoList.Name = "InfoList";
			this.InfoList.Size = new System.Drawing.Size(303, 146);
			this.InfoList.TabIndex = 1;
			this.InfoList.UseCompatibleStateImageBehavior = false;
			this.InfoList.View = System.Windows.Forms.View.Details;
			this.InfoList.DoubleClick += new System.EventHandler(this.FeatureEditBtn_Click);
			// 
			// InfoHdr
			// 
			this.InfoHdr.Text = Session.I18N.Information;
			this.InfoHdr.Width = 273;
			// 
			// LevelToolbar
			// 
			this.LevelToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddBtn,
            this.RemoveBtn,
            this.EditBtn});
			this.LevelToolbar.Location = new System.Drawing.Point(3, 3);
			this.LevelToolbar.Name = "LevelToolbar";
			this.LevelToolbar.Size = new System.Drawing.Size(303, 25);
			this.LevelToolbar.TabIndex = 0;
			this.LevelToolbar.Text = Session.I18N.toolStrip1;
			// 
			// AddBtn
			// 
			this.AddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.AddBtn.Image = ((System.Drawing.Image)(resources.GetObject("AddBtn.Image")));
			this.AddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AddBtn.Name = "AddBtn";
			this.AddBtn.Size = new System.Drawing.Size(33, 22);
			this.AddBtn.Text = Session.I18N.Add;
			this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
			// 
			// RemoveBtn
			// 
			this.RemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.RemoveBtn.Image = ((System.Drawing.Image)(resources.GetObject("RemoveBtn.Image")));
			this.RemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RemoveBtn.Name = "RemoveBtn";
			this.RemoveBtn.Size = new System.Drawing.Size(54, 22);
			this.RemoveBtn.Text = Session.I18N.Remove;
			this.RemoveBtn.Click += new System.EventHandler(this.RemoveBtn_Click);
			// 
			// EditBtn
			// 
			this.EditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.EditBtn.Image = ((System.Drawing.Image)(resources.GetObject("EditBtn.Image")));
			this.EditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EditBtn.Name = "EditBtn";
			this.EditBtn.Size = new System.Drawing.Size(31, 22);
			this.EditBtn.Text = Session.I18N.Edit;
			this.EditBtn.Click += new System.EventHandler(this.FeatureEditBtn_Click);
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(173, 274);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 5;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(254, 274);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 6;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// SkillLbl
			// 
			this.SkillLbl.AutoSize = true;
			this.SkillLbl.Location = new System.Drawing.Point(12, 41);
			this.SkillLbl.Name = "SkillLbl";
			this.SkillLbl.Size = new System.Drawing.Size(60, 13);
			this.SkillLbl.TabIndex = 2;
			this.SkillLbl.Text = "Skill Name:";
			// 
			// SkillBox
			// 
			this.SkillBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.SkillBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.SkillBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.SkillBox.FormattingEnabled = true;
			this.SkillBox.Location = new System.Drawing.Point(99, 38);
			this.SkillBox.Name = "SkillBox";
			this.SkillBox.Size = new System.Drawing.Size(230, 21);
			this.SkillBox.TabIndex = 3;
			// 
			// OptionCreatureLoreForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(341, 309);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.Pages);
			this.Controls.Add(this.SkillBox);
			this.Controls.Add(this.SkillLbl);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLbl);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionCreatureLoreForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = Session.I18N.CreatureLore;
			this.Pages.ResumeLayout(false);
			this.InfoPage.ResumeLayout(false);
			this.InfoPage.PerformLayout();
			this.LevelToolbar.ResumeLayout(false);
			this.LevelToolbar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label NameLbl;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.TabPage InfoPage;
		private System.Windows.Forms.ListView InfoList;
		private System.Windows.Forms.ColumnHeader InfoHdr;
		private System.Windows.Forms.ToolStrip LevelToolbar;
		private System.Windows.Forms.ToolStripButton EditBtn;
		private System.Windows.Forms.Label SkillLbl;
		private System.Windows.Forms.ToolStripButton AddBtn;
		private System.Windows.Forms.ToolStripButton RemoveBtn;
		private System.Windows.Forms.ComboBox SkillBox;
	}
}