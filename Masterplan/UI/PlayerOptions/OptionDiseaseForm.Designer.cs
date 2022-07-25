namespace Masterplan.UI
{
	partial class OptionDiseaseForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionDiseaseForm));
			this.NameLbl = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.Pages = new System.Windows.Forms.TabControl();
			this.DetailsPage = new System.Windows.Forms.TabPage();
			this.DetailsBox = new System.Windows.Forms.TextBox();
			this.LevelsPage = new System.Windows.Forms.TabPage();
			this.LevelList = new System.Windows.Forms.ListView();
			this.LevelHdr = new System.Windows.Forms.ColumnHeader();
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.AddBtn = new System.Windows.Forms.ToolStripButton();
			this.RemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.EditBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.UpBtn = new System.Windows.Forms.ToolStripButton();
			this.DownBtn = new System.Windows.Forms.ToolStripButton();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.LevelBox = new System.Windows.Forms.TextBox();
			this.LevelLbl = new System.Windows.Forms.Label();
			this.MaintainBox = new System.Windows.Forms.TextBox();
			this.MaintainLbl = new System.Windows.Forms.Label();
			this.ImproveBox = new System.Windows.Forms.TextBox();
			this.ImproveLbl = new System.Windows.Forms.Label();
			this.Pages.SuspendLayout();
			this.DetailsPage.SuspendLayout();
			this.LevelsPage.SuspendLayout();
			this.Toolbar.SuspendLayout();
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
			this.NameBox.Location = new System.Drawing.Point(86, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(272, 20);
			this.NameBox.TabIndex = 1;
			// 
			// Pages
			// 
			this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Pages.Controls.Add(this.DetailsPage);
			this.Pages.Controls.Add(this.LevelsPage);
			this.Pages.Location = new System.Drawing.Point(12, 116);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(346, 239);
			this.Pages.TabIndex = 10;
			// 
			// DetailsPage
			// 
			this.DetailsPage.Controls.Add(this.DetailsBox);
			this.DetailsPage.Location = new System.Drawing.Point(4, 22);
			this.DetailsPage.Name = "DetailsPage";
			this.DetailsPage.Padding = new System.Windows.Forms.Padding(3);
			this.DetailsPage.Size = new System.Drawing.Size(338, 213);
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
			this.DetailsBox.Size = new System.Drawing.Size(332, 207);
			this.DetailsBox.TabIndex = 0;
			// 
			// LevelsPage
			// 
			this.LevelsPage.Controls.Add(this.LevelList);
			this.LevelsPage.Controls.Add(this.Toolbar);
			this.LevelsPage.Location = new System.Drawing.Point(4, 22);
			this.LevelsPage.Name = "LevelsPage";
			this.LevelsPage.Padding = new System.Windows.Forms.Padding(3);
			this.LevelsPage.Size = new System.Drawing.Size(338, 165);
			this.LevelsPage.TabIndex = 1;
			this.LevelsPage.Text = "Disease Levels";
			this.LevelsPage.UseVisualStyleBackColor = true;
			// 
			// LevelList
			// 
			this.LevelList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LevelHdr});
			this.LevelList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LevelList.FullRowSelect = true;
			this.LevelList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.LevelList.HideSelection = false;
			this.LevelList.Location = new System.Drawing.Point(3, 28);
			this.LevelList.MultiSelect = false;
			this.LevelList.Name = "LevelList";
			this.LevelList.Size = new System.Drawing.Size(332, 134);
			this.LevelList.TabIndex = 1;
			this.LevelList.UseCompatibleStateImageBehavior = false;
			this.LevelList.View = System.Windows.Forms.View.Details;
			this.LevelList.DoubleClick += new System.EventHandler(this.EditBtn_Click);
			// 
			// LevelHdr
			// 
			this.LevelHdr.Text = "Disease Level";
			this.LevelHdr.Width = 272;
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddBtn,
            this.RemoveBtn,
            this.EditBtn,
            this.toolStripSeparator1,
            this.UpBtn,
            this.DownBtn});
			this.Toolbar.Location = new System.Drawing.Point(3, 3);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(332, 25);
			this.Toolbar.TabIndex = 0;
			this.Toolbar.Text = Session.I18N.toolStrip1;
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
			this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// UpBtn
			// 
			this.UpBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.UpBtn.Image = ((System.Drawing.Image)(resources.GetObject("UpBtn.Image")));
			this.UpBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.UpBtn.Name = "UpBtn";
			this.UpBtn.Size = new System.Drawing.Size(59, 22);
			this.UpBtn.Text = Session.I18N.MoveUp;
			this.UpBtn.Click += new System.EventHandler(this.UpBtn_Click);
			// 
			// DownBtn
			// 
			this.DownBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.DownBtn.Image = ((System.Drawing.Image)(resources.GetObject("DownBtn.Image")));
			this.DownBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.DownBtn.Name = "DownBtn";
			this.DownBtn.Size = new System.Drawing.Size(75, 22);
			this.DownBtn.Text = Session.I18N.MoveDown;
			this.DownBtn.Click += new System.EventHandler(this.DownBtn_Click);
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(202, 361);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 11;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(283, 361);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 12;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// LevelBox
			// 
			this.LevelBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.LevelBox.Location = new System.Drawing.Point(86, 38);
			this.LevelBox.Name = "LevelBox";
			this.LevelBox.Size = new System.Drawing.Size(272, 20);
			this.LevelBox.TabIndex = 3;
			// 
			// LevelLbl
			// 
			this.LevelLbl.AutoSize = true;
			this.LevelLbl.Location = new System.Drawing.Point(12, 41);
			this.LevelLbl.Name = "LevelLbl";
			this.LevelLbl.Size = new System.Drawing.Size(36, 13);
			this.LevelLbl.TabIndex = 2;
			this.LevelLbl.Text = "Level:";
			// 
			// MaintainBox
			// 
			this.MaintainBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.MaintainBox.Location = new System.Drawing.Point(86, 90);
			this.MaintainBox.Name = "MaintainBox";
			this.MaintainBox.Size = new System.Drawing.Size(272, 20);
			this.MaintainBox.TabIndex = 9;
			// 
			// MaintainLbl
			// 
			this.MaintainLbl.AutoSize = true;
			this.MaintainLbl.Location = new System.Drawing.Point(12, 93);
			this.MaintainLbl.Name = "MaintainLbl";
			this.MaintainLbl.Size = new System.Drawing.Size(68, 13);
			this.MaintainLbl.TabIndex = 8;
			this.MaintainLbl.Text = "Maintain DC:";
			// 
			// ImproveBox
			// 
			this.ImproveBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ImproveBox.Location = new System.Drawing.Point(86, 64);
			this.ImproveBox.Name = "ImproveBox";
			this.ImproveBox.Size = new System.Drawing.Size(272, 20);
			this.ImproveBox.TabIndex = 7;
			// 
			// ImproveLbl
			// 
			this.ImproveLbl.AutoSize = true;
			this.ImproveLbl.Location = new System.Drawing.Point(12, 67);
			this.ImproveLbl.Name = "ImproveLbl";
			this.ImproveLbl.Size = new System.Drawing.Size(66, 13);
			this.ImproveLbl.TabIndex = 6;
			this.ImproveLbl.Text = "Improve DC:";
			// 
			// OptionDiseaseForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(370, 396);
			this.Controls.Add(this.MaintainBox);
			this.Controls.Add(this.MaintainLbl);
			this.Controls.Add(this.ImproveBox);
			this.Controls.Add(this.ImproveLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.Pages);
			this.Controls.Add(this.LevelBox);
			this.Controls.Add(this.LevelLbl);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLbl);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionDiseaseForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = Session.I18N.Disease;
			this.Pages.ResumeLayout(false);
			this.DetailsPage.ResumeLayout(false);
			this.DetailsPage.PerformLayout();
			this.LevelsPage.ResumeLayout(false);
			this.LevelsPage.PerformLayout();
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
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
		private System.Windows.Forms.TextBox LevelBox;
		private System.Windows.Forms.Label LevelLbl;
		private System.Windows.Forms.TabPage LevelsPage;
		private System.Windows.Forms.TextBox MaintainBox;
		private System.Windows.Forms.Label MaintainLbl;
		private System.Windows.Forms.TextBox ImproveBox;
		private System.Windows.Forms.Label ImproveLbl;
		private System.Windows.Forms.ListView LevelList;
		private System.Windows.Forms.ColumnHeader LevelHdr;
		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ToolStripButton AddBtn;
		private System.Windows.Forms.ToolStripButton RemoveBtn;
		private System.Windows.Forms.ToolStripButton EditBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton UpBtn;
		private System.Windows.Forms.ToolStripButton DownBtn;
	}
}