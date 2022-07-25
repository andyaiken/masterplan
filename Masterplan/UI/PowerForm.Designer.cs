namespace Masterplan.UI
{
	partial class PowerForm
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
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Attack Advice", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Damage Advice", System.Windows.Forms.HorizontalAlignment.Left);
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.NameLbl = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.KeywordLbl = new System.Windows.Forms.Label();
			this.KeywordBox = new System.Windows.Forms.TextBox();
			this.ActionLbl = new System.Windows.Forms.Label();
			this.ActionBtn = new System.Windows.Forms.Button();
			this.ActionClearLbl = new System.Windows.Forms.LinkLabel();
			this.AttackLbl = new System.Windows.Forms.Label();
			this.AttackBtn = new System.Windows.Forms.Button();
			this.AttackClearLbl = new System.Windows.Forms.LinkLabel();
			this.RangeLbl = new System.Windows.Forms.Label();
			this.RangeBox = new System.Windows.Forms.ComboBox();
			this.Pages = new System.Windows.Forms.TabControl();
			this.DetailsPage = new System.Windows.Forms.TabPage();
			this.DetailsBox = new System.Windows.Forms.TextBox();
			this.AdvicePage = new System.Windows.Forms.TabPage();
			this.AdviceList = new System.Windows.Forms.ListView();
			this.AdviceHdr = new System.Windows.Forms.ColumnHeader();
			this.InfoHdr = new System.Windows.Forms.ColumnHeader();
			this.ConditionBox = new System.Windows.Forms.TextBox();
			this.ConditionLbl = new System.Windows.Forms.Label();
			this.DescPage = new System.Windows.Forms.TabPage();
			this.DescBox = new System.Windows.Forms.TextBox();
			this.Pages.SuspendLayout();
			this.DetailsPage.SuspendLayout();
			this.AdvicePage.SuspendLayout();
			this.DescPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(192, 326);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 15;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(273, 326);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 16;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
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
			this.NameBox.Location = new System.Drawing.Point(94, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(254, 20);
			this.NameBox.TabIndex = 1;
			// 
			// KeywordLbl
			// 
			this.KeywordLbl.AutoSize = true;
			this.KeywordLbl.Location = new System.Drawing.Point(12, 41);
			this.KeywordLbl.Name = "KeywordLbl";
			this.KeywordLbl.Size = new System.Drawing.Size(56, 13);
			this.KeywordLbl.TabIndex = 2;
			this.KeywordLbl.Text = "Keywords:";
			// 
			// KeywordBox
			// 
			this.KeywordBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.KeywordBox.Location = new System.Drawing.Point(94, 38);
			this.KeywordBox.Name = "KeywordBox";
			this.KeywordBox.Size = new System.Drawing.Size(254, 20);
			this.KeywordBox.TabIndex = 3;
			// 
			// ActionLbl
			// 
			this.ActionLbl.AutoSize = true;
			this.ActionLbl.Location = new System.Drawing.Point(12, 95);
			this.ActionLbl.Name = "ActionLbl";
			this.ActionLbl.Size = new System.Drawing.Size(40, 13);
			this.ActionLbl.TabIndex = 6;
			this.ActionLbl.Text = "Action:";
			// 
			// ActionBtn
			// 
			this.ActionBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ActionBtn.Location = new System.Drawing.Point(94, 90);
			this.ActionBtn.Name = "ActionBtn";
			this.ActionBtn.Size = new System.Drawing.Size(217, 23);
			this.ActionBtn.TabIndex = 7;
			this.ActionBtn.Text = "[action]";
			this.ActionBtn.UseVisualStyleBackColor = true;
			this.ActionBtn.Click += new System.EventHandler(this.ActionBtn_Click);
			// 
			// ActionClearLbl
			// 
			this.ActionClearLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ActionClearLbl.AutoSize = true;
			this.ActionClearLbl.Location = new System.Drawing.Point(317, 95);
			this.ActionClearLbl.Name = "ActionClearLbl";
			this.ActionClearLbl.Size = new System.Drawing.Size(31, 13);
			this.ActionClearLbl.TabIndex = 8;
			this.ActionClearLbl.TabStop = true;
			this.ActionClearLbl.Text = Session.I18N.Clear;
			this.ActionClearLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ActionClearLbl_LinkClicked);
			// 
			// AttackLbl
			// 
			this.AttackLbl.AutoSize = true;
			this.AttackLbl.Location = new System.Drawing.Point(12, 124);
			this.AttackLbl.Name = "AttackLbl";
			this.AttackLbl.Size = new System.Drawing.Size(41, 13);
			this.AttackLbl.TabIndex = 9;
			this.AttackLbl.Text = "Attack:";
			// 
			// AttackBtn
			// 
			this.AttackBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.AttackBtn.Location = new System.Drawing.Point(94, 119);
			this.AttackBtn.Name = "AttackBtn";
			this.AttackBtn.Size = new System.Drawing.Size(217, 23);
			this.AttackBtn.TabIndex = 10;
			this.AttackBtn.Text = "[attack]";
			this.AttackBtn.UseVisualStyleBackColor = true;
			this.AttackBtn.Click += new System.EventHandler(this.AttackBtn_Click);
			// 
			// AttackClearLbl
			// 
			this.AttackClearLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.AttackClearLbl.AutoSize = true;
			this.AttackClearLbl.Location = new System.Drawing.Point(317, 124);
			this.AttackClearLbl.Name = "AttackClearLbl";
			this.AttackClearLbl.Size = new System.Drawing.Size(31, 13);
			this.AttackClearLbl.TabIndex = 11;
			this.AttackClearLbl.TabStop = true;
			this.AttackClearLbl.Text = Session.I18N.Clear;
			this.AttackClearLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AttackClearLbl_LinkClicked);
			// 
			// RangeLbl
			// 
			this.RangeLbl.AutoSize = true;
			this.RangeLbl.Location = new System.Drawing.Point(12, 151);
			this.RangeLbl.Name = "RangeLbl";
			this.RangeLbl.Size = new System.Drawing.Size(42, 13);
			this.RangeLbl.TabIndex = 12;
			this.RangeLbl.Text = "Range:";
			// 
			// RangeBox
			// 
			this.RangeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.RangeBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.RangeBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.RangeBox.FormattingEnabled = true;
			this.RangeBox.Location = new System.Drawing.Point(94, 148);
			this.RangeBox.Name = "RangeBox";
			this.RangeBox.Size = new System.Drawing.Size(254, 21);
			this.RangeBox.Sorted = true;
			this.RangeBox.TabIndex = 13;
			// 
			// Pages
			// 
			this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Pages.Controls.Add(this.DetailsPage);
			this.Pages.Controls.Add(this.DescPage);
			this.Pages.Controls.Add(this.AdvicePage);
			this.Pages.Location = new System.Drawing.Point(12, 175);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(336, 145);
			this.Pages.TabIndex = 14;
			// 
			// DetailsPage
			// 
			this.DetailsPage.Controls.Add(this.DetailsBox);
			this.DetailsPage.Location = new System.Drawing.Point(4, 22);
			this.DetailsPage.Name = "DetailsPage";
			this.DetailsPage.Padding = new System.Windows.Forms.Padding(3);
			this.DetailsPage.Size = new System.Drawing.Size(328, 119);
			this.DetailsPage.TabIndex = 0;
			this.DetailsPage.Text = "Details";
			this.DetailsPage.UseVisualStyleBackColor = true;
			// 
			// DetailsBox
			// 
			this.DetailsBox.AcceptsReturn = true;
			this.DetailsBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DetailsBox.Location = new System.Drawing.Point(3, 3);
			this.DetailsBox.Multiline = true;
			this.DetailsBox.Name = "DetailsBox";
			this.DetailsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.DetailsBox.Size = new System.Drawing.Size(322, 113);
			this.DetailsBox.TabIndex = 0;
			// 
			// AdvicePage
			// 
			this.AdvicePage.Controls.Add(this.AdviceList);
			this.AdvicePage.Location = new System.Drawing.Point(4, 22);
			this.AdvicePage.Name = "AdvicePage";
			this.AdvicePage.Padding = new System.Windows.Forms.Padding(3);
			this.AdvicePage.Size = new System.Drawing.Size(328, 119);
			this.AdvicePage.TabIndex = 1;
			this.AdvicePage.Text = "Advice";
			this.AdvicePage.UseVisualStyleBackColor = true;
			// 
			// AdviceList
			// 
			this.AdviceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AdviceHdr,
            this.InfoHdr});
			this.AdviceList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AdviceList.FullRowSelect = true;
			listViewGroup1.Header = "Attack Advice";
			listViewGroup1.Name = "AtkGrp";
			listViewGroup2.Header = "Damage Advice";
			listViewGroup2.Name = "DmgGrp";
			this.AdviceList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
			this.AdviceList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.AdviceList.HideSelection = false;
			this.AdviceList.Location = new System.Drawing.Point(3, 3);
			this.AdviceList.MultiSelect = false;
			this.AdviceList.Name = "AdviceList";
			this.AdviceList.Size = new System.Drawing.Size(322, 113);
			this.AdviceList.TabIndex = 0;
			this.AdviceList.UseCompatibleStateImageBehavior = false;
			this.AdviceList.View = System.Windows.Forms.View.Details;
			// 
			// AdviceHdr
			// 
			this.AdviceHdr.Text = "Advice";
			this.AdviceHdr.Width = 150;
			// 
			// InfoHdr
			// 
			this.InfoHdr.Text = Session.I18N.Information;
			this.InfoHdr.Width = 100;
			// 
			// ConditionBox
			// 
			this.ConditionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ConditionBox.Location = new System.Drawing.Point(94, 64);
			this.ConditionBox.Name = "ConditionBox";
			this.ConditionBox.Size = new System.Drawing.Size(254, 20);
			this.ConditionBox.TabIndex = 5;
			// 
			// ConditionLbl
			// 
			this.ConditionLbl.AutoSize = true;
			this.ConditionLbl.Location = new System.Drawing.Point(12, 67);
			this.ConditionLbl.Name = "ConditionLbl";
			this.ConditionLbl.Size = new System.Drawing.Size(59, 13);
			this.ConditionLbl.TabIndex = 4;
			this.ConditionLbl.Text = "Conditions:";
			// 
			// DescPage
			// 
			this.DescPage.Controls.Add(this.DescBox);
			this.DescPage.Location = new System.Drawing.Point(4, 22);
			this.DescPage.Name = "DescPage";
			this.DescPage.Padding = new System.Windows.Forms.Padding(3);
			this.DescPage.Size = new System.Drawing.Size(328, 119);
			this.DescPage.TabIndex = 2;
			this.DescPage.Text = "Description";
			this.DescPage.UseVisualStyleBackColor = true;
			// 
			// DescBox
			// 
			this.DescBox.AcceptsReturn = true;
			this.DescBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DescBox.Location = new System.Drawing.Point(3, 3);
			this.DescBox.Multiline = true;
			this.DescBox.Name = "DescBox";
			this.DescBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.DescBox.Size = new System.Drawing.Size(322, 113);
			this.DescBox.TabIndex = 1;
			// 
			// PowerForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(360, 361);
			this.Controls.Add(this.ConditionBox);
			this.Controls.Add(this.ConditionLbl);
			this.Controls.Add(this.Pages);
			this.Controls.Add(this.RangeBox);
			this.Controls.Add(this.RangeLbl);
			this.Controls.Add(this.AttackClearLbl);
			this.Controls.Add(this.AttackBtn);
			this.Controls.Add(this.AttackLbl);
			this.Controls.Add(this.ActionClearLbl);
			this.Controls.Add(this.ActionBtn);
			this.Controls.Add(this.ActionLbl);
			this.Controls.Add(this.KeywordBox);
			this.Controls.Add(this.KeywordLbl);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PowerForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Power";
			this.Pages.ResumeLayout(false);
			this.DetailsPage.ResumeLayout(false);
			this.DetailsPage.PerformLayout();
			this.AdvicePage.ResumeLayout(false);
			this.DescPage.ResumeLayout(false);
			this.DescPage.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label NameLbl;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.Label KeywordLbl;
		private System.Windows.Forms.TextBox KeywordBox;
		private System.Windows.Forms.Label ActionLbl;
		private System.Windows.Forms.Button ActionBtn;
		private System.Windows.Forms.LinkLabel ActionClearLbl;
		private System.Windows.Forms.Label AttackLbl;
		private System.Windows.Forms.Button AttackBtn;
		private System.Windows.Forms.LinkLabel AttackClearLbl;
		private System.Windows.Forms.Label RangeLbl;
		private System.Windows.Forms.ComboBox RangeBox;
		private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.TabPage DetailsPage;
		private System.Windows.Forms.TextBox DetailsBox;
		private System.Windows.Forms.TabPage AdvicePage;
		private System.Windows.Forms.ListView AdviceList;
		private System.Windows.Forms.ColumnHeader AdviceHdr;
		private System.Windows.Forms.ColumnHeader InfoHdr;
		private System.Windows.Forms.TextBox ConditionBox;
		private System.Windows.Forms.Label ConditionLbl;
		private System.Windows.Forms.TabPage DescPage;
		private System.Windows.Forms.TextBox DescBox;
	}
}