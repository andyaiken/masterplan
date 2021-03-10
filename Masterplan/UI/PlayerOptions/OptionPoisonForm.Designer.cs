namespace Masterplan.UI
{
	partial class OptionPoisonForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionPoisonForm));
			this.NameLbl = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.Pages = new System.Windows.Forms.TabControl();
			this.DetailsPage = new System.Windows.Forms.TabPage();
			this.DetailsBox = new System.Windows.Forms.TextBox();
			this.SectionPage = new System.Windows.Forms.TabPage();
			this.SectionList = new System.Windows.Forms.ListView();
			this.SectionHdr = new System.Windows.Forms.ColumnHeader();
			this.SectionToolbar = new System.Windows.Forms.ToolStrip();
			this.SectionAddBtn = new System.Windows.Forms.ToolStripButton();
			this.SectionRemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.SectionEditBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.SectionUpBtn = new System.Windows.Forms.ToolStripButton();
			this.SectionDownBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.SectionLeftBtn = new System.Windows.Forms.ToolStripButton();
			this.SectionRightBtn = new System.Windows.Forms.ToolStripButton();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.LevelLbl = new System.Windows.Forms.Label();
			this.LevelBox = new System.Windows.Forms.NumericUpDown();
			this.Pages.SuspendLayout();
			this.DetailsPage.SuspendLayout();
			this.SectionPage.SuspendLayout();
			this.SectionToolbar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.LevelBox)).BeginInit();
			this.SuspendLayout();
			// 
			// NameLbl
			// 
			this.NameLbl.AutoSize = true;
			this.NameLbl.Location = new System.Drawing.Point(12, 15);
			this.NameLbl.Name = "NameLbl";
			this.NameLbl.Size = new System.Drawing.Size(38, 13);
			this.NameLbl.TabIndex = 0;
			this.NameLbl.Text = "Name:";
			// 
			// NameBox
			// 
			this.NameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.NameBox.Location = new System.Drawing.Point(56, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(297, 20);
			this.NameBox.TabIndex = 1;
			// 
			// Pages
			// 
			this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Pages.Controls.Add(this.DetailsPage);
			this.Pages.Controls.Add(this.SectionPage);
			this.Pages.Location = new System.Drawing.Point(12, 64);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(341, 170);
			this.Pages.TabIndex = 4;
			// 
			// DetailsPage
			// 
			this.DetailsPage.Controls.Add(this.DetailsBox);
			this.DetailsPage.Location = new System.Drawing.Point(4, 22);
			this.DetailsPage.Name = "DetailsPage";
			this.DetailsPage.Padding = new System.Windows.Forms.Padding(3);
			this.DetailsPage.Size = new System.Drawing.Size(333, 144);
			this.DetailsPage.TabIndex = 0;
			this.DetailsPage.Text = "Details";
			this.DetailsPage.UseVisualStyleBackColor = true;
			// 
			// DetailsBox
			// 
			this.DetailsBox.AcceptsReturn = true;
			this.DetailsBox.AcceptsTab = true;
			this.DetailsBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DetailsBox.Location = new System.Drawing.Point(3, 3);
			this.DetailsBox.Multiline = true;
			this.DetailsBox.Name = "DetailsBox";
			this.DetailsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.DetailsBox.Size = new System.Drawing.Size(327, 138);
			this.DetailsBox.TabIndex = 0;
			// 
			// SectionPage
			// 
			this.SectionPage.Controls.Add(this.SectionList);
			this.SectionPage.Controls.Add(this.SectionToolbar);
			this.SectionPage.Location = new System.Drawing.Point(4, 22);
			this.SectionPage.Name = "SectionPage";
			this.SectionPage.Padding = new System.Windows.Forms.Padding(3);
			this.SectionPage.Size = new System.Drawing.Size(333, 144);
			this.SectionPage.TabIndex = 1;
			this.SectionPage.Text = "Sections";
			this.SectionPage.UseVisualStyleBackColor = true;
			// 
			// SectionList
			// 
			this.SectionList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SectionHdr});
			this.SectionList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SectionList.FullRowSelect = true;
			this.SectionList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.SectionList.HideSelection = false;
			this.SectionList.Location = new System.Drawing.Point(3, 28);
			this.SectionList.MultiSelect = false;
			this.SectionList.Name = "SectionList";
			this.SectionList.Size = new System.Drawing.Size(327, 113);
			this.SectionList.TabIndex = 1;
			this.SectionList.UseCompatibleStateImageBehavior = false;
			this.SectionList.View = System.Windows.Forms.View.Details;
			// 
			// SectionHdr
			// 
			this.SectionHdr.Text = "Section";
			this.SectionHdr.Width = 300;
			// 
			// SectionToolbar
			// 
			this.SectionToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SectionAddBtn,
            this.SectionRemoveBtn,
            this.SectionEditBtn,
            this.toolStripSeparator1,
            this.SectionUpBtn,
            this.SectionDownBtn,
            this.toolStripSeparator2,
            this.SectionLeftBtn,
            this.SectionRightBtn});
			this.SectionToolbar.Location = new System.Drawing.Point(3, 3);
			this.SectionToolbar.Name = "SectionToolbar";
			this.SectionToolbar.Size = new System.Drawing.Size(327, 25);
			this.SectionToolbar.TabIndex = 0;
			this.SectionToolbar.Text = "toolStrip1";
			// 
			// SectionAddBtn
			// 
			this.SectionAddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SectionAddBtn.Image = ((System.Drawing.Image)(resources.GetObject("SectionAddBtn.Image")));
			this.SectionAddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SectionAddBtn.Name = "SectionAddBtn";
			this.SectionAddBtn.Size = new System.Drawing.Size(33, 22);
			this.SectionAddBtn.Text = "Add";
			this.SectionAddBtn.Click += new System.EventHandler(this.SectionAddBtn_Click);
			// 
			// SectionRemoveBtn
			// 
			this.SectionRemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SectionRemoveBtn.Image = ((System.Drawing.Image)(resources.GetObject("SectionRemoveBtn.Image")));
			this.SectionRemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SectionRemoveBtn.Name = "SectionRemoveBtn";
			this.SectionRemoveBtn.Size = new System.Drawing.Size(54, 22);
			this.SectionRemoveBtn.Text = "Remove";
			this.SectionRemoveBtn.Click += new System.EventHandler(this.SectionRemoveBtn_Click);
			// 
			// SectionEditBtn
			// 
			this.SectionEditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SectionEditBtn.Image = ((System.Drawing.Image)(resources.GetObject("SectionEditBtn.Image")));
			this.SectionEditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SectionEditBtn.Name = "SectionEditBtn";
			this.SectionEditBtn.Size = new System.Drawing.Size(31, 22);
			this.SectionEditBtn.Text = "Edit";
			this.SectionEditBtn.Click += new System.EventHandler(this.SectionEditBtn_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// SectionUpBtn
			// 
			this.SectionUpBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SectionUpBtn.Image = ((System.Drawing.Image)(resources.GetObject("SectionUpBtn.Image")));
			this.SectionUpBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SectionUpBtn.Name = "SectionUpBtn";
			this.SectionUpBtn.Size = new System.Drawing.Size(26, 22);
			this.SectionUpBtn.Text = "Up";
			this.SectionUpBtn.Click += new System.EventHandler(this.SectionUpBtn_Click);
			// 
			// SectionDownBtn
			// 
			this.SectionDownBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SectionDownBtn.Image = ((System.Drawing.Image)(resources.GetObject("SectionDownBtn.Image")));
			this.SectionDownBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SectionDownBtn.Name = "SectionDownBtn";
			this.SectionDownBtn.Size = new System.Drawing.Size(42, 22);
			this.SectionDownBtn.Text = "Down";
			this.SectionDownBtn.Click += new System.EventHandler(this.SectionDownBtn_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// SectionLeftBtn
			// 
			this.SectionLeftBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SectionLeftBtn.Image = ((System.Drawing.Image)(resources.GetObject("SectionLeftBtn.Image")));
			this.SectionLeftBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SectionLeftBtn.Name = "SectionLeftBtn";
			this.SectionLeftBtn.Size = new System.Drawing.Size(31, 22);
			this.SectionLeftBtn.Text = "Left";
			this.SectionLeftBtn.Click += new System.EventHandler(this.SectionLeftBtn_Click);
			// 
			// SectionRightBtn
			// 
			this.SectionRightBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SectionRightBtn.Image = ((System.Drawing.Image)(resources.GetObject("SectionRightBtn.Image")));
			this.SectionRightBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SectionRightBtn.Name = "SectionRightBtn";
			this.SectionRightBtn.Size = new System.Drawing.Size(39, 22);
			this.SectionRightBtn.Text = "Right";
			this.SectionRightBtn.Click += new System.EventHandler(this.SectionRightBtn_Click);
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(197, 240);
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
			this.CancelBtn.Location = new System.Drawing.Point(278, 240);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 6;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// LevelLbl
			// 
			this.LevelLbl.AutoSize = true;
			this.LevelLbl.Location = new System.Drawing.Point(12, 40);
			this.LevelLbl.Name = "LevelLbl";
			this.LevelLbl.Size = new System.Drawing.Size(36, 13);
			this.LevelLbl.TabIndex = 2;
			this.LevelLbl.Text = "Level:";
			// 
			// LevelBox
			// 
			this.LevelBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.LevelBox.Location = new System.Drawing.Point(56, 38);
			this.LevelBox.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
			this.LevelBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.LevelBox.Name = "LevelBox";
			this.LevelBox.Size = new System.Drawing.Size(297, 20);
			this.LevelBox.TabIndex = 3;
			this.LevelBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// OptionPoisonForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(365, 275);
			this.Controls.Add(this.LevelBox);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.LevelLbl);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLbl);
			this.Controls.Add(this.Pages);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionPoisonForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Poison";
			this.Pages.ResumeLayout(false);
			this.DetailsPage.ResumeLayout(false);
			this.DetailsPage.PerformLayout();
			this.SectionPage.ResumeLayout(false);
			this.SectionPage.PerformLayout();
			this.SectionToolbar.ResumeLayout(false);
			this.SectionToolbar.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.LevelBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label NameLbl;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.TabPage DetailsPage;
		private System.Windows.Forms.TextBox DetailsBox;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.TabPage SectionPage;
		private System.Windows.Forms.ListView SectionList;
		private System.Windows.Forms.ColumnHeader SectionHdr;
		private System.Windows.Forms.ToolStrip SectionToolbar;
		private System.Windows.Forms.ToolStripButton SectionAddBtn;
		private System.Windows.Forms.ToolStripButton SectionRemoveBtn;
		private System.Windows.Forms.ToolStripButton SectionEditBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton SectionUpBtn;
		private System.Windows.Forms.ToolStripButton SectionDownBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton SectionLeftBtn;
		private System.Windows.Forms.ToolStripButton SectionRightBtn;
		private System.Windows.Forms.Label LevelLbl;
		private System.Windows.Forms.NumericUpDown LevelBox;
	}
}