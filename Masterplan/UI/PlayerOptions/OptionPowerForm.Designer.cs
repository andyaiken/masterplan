namespace Masterplan.UI
{
	partial class OptionPowerForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionPowerForm));
			this.NameLbl = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.Pages = new System.Windows.Forms.TabControl();
			this.HeaderPage = new System.Windows.Forms.TabPage();
			this.RangeBox = new System.Windows.Forms.ComboBox();
			this.RangeLbl = new System.Windows.Forms.Label();
			this.ActionBox = new System.Windows.Forms.ComboBox();
			this.TypeLbl = new System.Windows.Forms.Label();
			this.TypeBox = new System.Windows.Forms.ComboBox();
			this.ActionLbl = new System.Windows.Forms.Label();
			this.KeywordBox = new System.Windows.Forms.TextBox();
			this.KeywordLbl = new System.Windows.Forms.Label();
			this.ReadAloudPage = new System.Windows.Forms.TabPage();
			this.ReadAloudBox = new System.Windows.Forms.TextBox();
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
			this.Pages.SuspendLayout();
			this.HeaderPage.SuspendLayout();
			this.ReadAloudPage.SuspendLayout();
			this.SectionPage.SuspendLayout();
			this.SectionToolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// NameLbl
			// 
			this.NameLbl.AutoSize = true;
			this.NameLbl.Location = new System.Drawing.Point(6, 9);
			this.NameLbl.Name = "NameLbl";
			this.NameLbl.Size = new System.Drawing.Size(38, 13);
			this.NameLbl.TabIndex = 0;
			this.NameLbl.Text = "Name:";
			// 
			// NameBox
			// 
			this.NameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.NameBox.Location = new System.Drawing.Point(68, 6);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(259, 20);
			this.NameBox.TabIndex = 1;
			// 
			// Pages
			// 
			this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Pages.Controls.Add(this.HeaderPage);
			this.Pages.Controls.Add(this.ReadAloudPage);
			this.Pages.Controls.Add(this.SectionPage);
			this.Pages.Location = new System.Drawing.Point(12, 12);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(341, 216);
			this.Pages.TabIndex = 10;
			// 
			// HeaderPage
			// 
			this.HeaderPage.Controls.Add(this.RangeBox);
			this.HeaderPage.Controls.Add(this.NameBox);
			this.HeaderPage.Controls.Add(this.RangeLbl);
			this.HeaderPage.Controls.Add(this.NameLbl);
			this.HeaderPage.Controls.Add(this.ActionBox);
			this.HeaderPage.Controls.Add(this.TypeLbl);
			this.HeaderPage.Controls.Add(this.TypeBox);
			this.HeaderPage.Controls.Add(this.ActionLbl);
			this.HeaderPage.Controls.Add(this.KeywordBox);
			this.HeaderPage.Controls.Add(this.KeywordLbl);
			this.HeaderPage.Location = new System.Drawing.Point(4, 22);
			this.HeaderPage.Name = "HeaderPage";
			this.HeaderPage.Padding = new System.Windows.Forms.Padding(3);
			this.HeaderPage.Size = new System.Drawing.Size(333, 190);
			this.HeaderPage.TabIndex = 2;
			this.HeaderPage.Text = Session.I18N.Information;
			this.HeaderPage.UseVisualStyleBackColor = true;
			// 
			// RangeBox
			// 
			this.RangeBox.FormattingEnabled = true;
			this.RangeBox.Location = new System.Drawing.Point(68, 113);
			this.RangeBox.Name = "RangeBox";
			this.RangeBox.Size = new System.Drawing.Size(259, 21);
			this.RangeBox.Sorted = true;
			this.RangeBox.TabIndex = 9;
			// 
			// RangeLbl
			// 
			this.RangeLbl.AutoSize = true;
			this.RangeLbl.Location = new System.Drawing.Point(6, 116);
			this.RangeLbl.Name = "RangeLbl";
			this.RangeLbl.Size = new System.Drawing.Size(42, 13);
			this.RangeLbl.TabIndex = 8;
			this.RangeLbl.Text = "Range:";
			// 
			// ActionBox
			// 
			this.ActionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ActionBox.FormattingEnabled = true;
			this.ActionBox.Location = new System.Drawing.Point(68, 86);
			this.ActionBox.Name = "ActionBox";
			this.ActionBox.Size = new System.Drawing.Size(259, 21);
			this.ActionBox.TabIndex = 7;
			// 
			// TypeLbl
			// 
			this.TypeLbl.AutoSize = true;
			this.TypeLbl.Location = new System.Drawing.Point(6, 35);
			this.TypeLbl.Name = "TypeLbl";
			this.TypeLbl.Size = new System.Drawing.Size(34, 13);
			this.TypeLbl.TabIndex = 2;
			this.TypeLbl.Text = "Type:";
			// 
			// TypeBox
			// 
			this.TypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TypeBox.FormattingEnabled = true;
			this.TypeBox.Location = new System.Drawing.Point(68, 32);
			this.TypeBox.Name = "TypeBox";
			this.TypeBox.Size = new System.Drawing.Size(259, 21);
			this.TypeBox.TabIndex = 3;
			// 
			// ActionLbl
			// 
			this.ActionLbl.AutoSize = true;
			this.ActionLbl.Location = new System.Drawing.Point(6, 89);
			this.ActionLbl.Name = "ActionLbl";
			this.ActionLbl.Size = new System.Drawing.Size(40, 13);
			this.ActionLbl.TabIndex = 6;
			this.ActionLbl.Text = "Action:";
			// 
			// KeywordBox
			// 
			this.KeywordBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.KeywordBox.Location = new System.Drawing.Point(68, 59);
			this.KeywordBox.Name = "KeywordBox";
			this.KeywordBox.Size = new System.Drawing.Size(259, 20);
			this.KeywordBox.TabIndex = 5;
			// 
			// KeywordLbl
			// 
			this.KeywordLbl.AutoSize = true;
			this.KeywordLbl.Location = new System.Drawing.Point(6, 62);
			this.KeywordLbl.Name = "KeywordLbl";
			this.KeywordLbl.Size = new System.Drawing.Size(56, 13);
			this.KeywordLbl.TabIndex = 4;
			this.KeywordLbl.Text = "Keywords:";
			// 
			// ReadAloudPage
			// 
			this.ReadAloudPage.Controls.Add(this.ReadAloudBox);
			this.ReadAloudPage.Location = new System.Drawing.Point(4, 22);
			this.ReadAloudPage.Name = "ReadAloudPage";
			this.ReadAloudPage.Padding = new System.Windows.Forms.Padding(3);
			this.ReadAloudPage.Size = new System.Drawing.Size(333, 190);
			this.ReadAloudPage.TabIndex = 0;
			this.ReadAloudPage.Text = "Read-Aloud Text";
			this.ReadAloudPage.UseVisualStyleBackColor = true;
			// 
			// ReadAloudBox
			// 
			this.ReadAloudBox.AcceptsReturn = true;
			this.ReadAloudBox.AcceptsTab = true;
			this.ReadAloudBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ReadAloudBox.Location = new System.Drawing.Point(3, 3);
			this.ReadAloudBox.Multiline = true;
			this.ReadAloudBox.Name = "ReadAloudBox";
			this.ReadAloudBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.ReadAloudBox.Size = new System.Drawing.Size(327, 184);
			this.ReadAloudBox.TabIndex = 0;
			// 
			// SectionPage
			// 
			this.SectionPage.Controls.Add(this.SectionList);
			this.SectionPage.Controls.Add(this.SectionToolbar);
			this.SectionPage.Location = new System.Drawing.Point(4, 22);
			this.SectionPage.Name = "SectionPage";
			this.SectionPage.Padding = new System.Windows.Forms.Padding(3);
			this.SectionPage.Size = new System.Drawing.Size(333, 190);
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
			this.SectionList.Size = new System.Drawing.Size(327, 159);
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
			this.SectionToolbar.Text = Session.I18N.toolStrip1;
			// 
			// SectionAddBtn
			// 
			this.SectionAddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SectionAddBtn.Image = ((System.Drawing.Image)(resources.GetObject("SectionAddBtn.Image")));
			this.SectionAddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SectionAddBtn.Name = "SectionAddBtn";
			this.SectionAddBtn.Size = new System.Drawing.Size(33, 22);
			this.SectionAddBtn.Text = Session.I18N.Add;
			this.SectionAddBtn.Click += new System.EventHandler(this.SectionAddBtn_Click);
			// 
			// SectionRemoveBtn
			// 
			this.SectionRemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SectionRemoveBtn.Image = ((System.Drawing.Image)(resources.GetObject("SectionRemoveBtn.Image")));
			this.SectionRemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SectionRemoveBtn.Name = "SectionRemoveBtn";
			this.SectionRemoveBtn.Size = new System.Drawing.Size(54, 22);
			this.SectionRemoveBtn.Text = Session.I18N.Remove;
			this.SectionRemoveBtn.Click += new System.EventHandler(this.SectionRemoveBtn_Click);
			// 
			// SectionEditBtn
			// 
			this.SectionEditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SectionEditBtn.Image = ((System.Drawing.Image)(resources.GetObject("SectionEditBtn.Image")));
			this.SectionEditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SectionEditBtn.Name = "SectionEditBtn";
			this.SectionEditBtn.Size = new System.Drawing.Size(31, 22);
			this.SectionEditBtn.Text = Session.I18N.Edit;
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
			this.OKBtn.Location = new System.Drawing.Point(197, 234);
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
			this.CancelBtn.Location = new System.Drawing.Point(278, 234);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 12;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// OptionPowerForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(365, 269);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.Pages);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionPowerForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Power";
			this.Pages.ResumeLayout(false);
			this.HeaderPage.ResumeLayout(false);
			this.HeaderPage.PerformLayout();
			this.ReadAloudPage.ResumeLayout(false);
			this.ReadAloudPage.PerformLayout();
			this.SectionPage.ResumeLayout(false);
			this.SectionPage.PerformLayout();
			this.SectionToolbar.ResumeLayout(false);
			this.SectionToolbar.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label NameLbl;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.TabPage ReadAloudPage;
		private System.Windows.Forms.TextBox ReadAloudBox;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label TypeLbl;
		private System.Windows.Forms.Label ActionLbl;
		private System.Windows.Forms.TextBox KeywordBox;
		private System.Windows.Forms.Label KeywordLbl;
		private System.Windows.Forms.ComboBox TypeBox;
		private System.Windows.Forms.ComboBox ActionBox;
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
		private System.Windows.Forms.Label RangeLbl;
		private System.Windows.Forms.ComboBox RangeBox;
		private System.Windows.Forms.TabPage HeaderPage;
	}
}