namespace Masterplan.UI
{
	partial class TrapAttackForm
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
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Initiative", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Attack Bonus", System.Windows.Forms.HorizontalAlignment.Left);
			this.CancelBtn = new System.Windows.Forms.Button();
			this.OKBtn = new System.Windows.Forms.Button();
			this.ActionLbl = new System.Windows.Forms.Label();
			this.ActionBox = new System.Windows.Forms.ComboBox();
			this.RangeLbl = new System.Windows.Forms.Label();
			this.RangeBox = new System.Windows.Forms.TextBox();
			this.TargetLbl = new System.Windows.Forms.Label();
			this.TargetBox = new System.Windows.Forms.TextBox();
			this.InitBox = new System.Windows.Forms.NumericUpDown();
			this.AttackLbl = new System.Windows.Forms.Label();
			this.AttackBtn = new System.Windows.Forms.Button();
			this.Pages = new System.Windows.Forms.TabControl();
			this.StatsPage = new System.Windows.Forms.TabPage();
			this.InitBtn = new System.Windows.Forms.CheckBox();
			this.TriggerPage = new System.Windows.Forms.TabPage();
			this.TriggerBox = new System.Windows.Forms.TextBox();
			this.HitPage = new System.Windows.Forms.TabPage();
			this.HitBox = new System.Windows.Forms.TextBox();
			this.MissPage = new System.Windows.Forms.TabPage();
			this.MissBox = new System.Windows.Forms.TextBox();
			this.EffectPage = new System.Windows.Forms.TabPage();
			this.EffectBox = new System.Windows.Forms.TextBox();
			this.AdvicePage = new System.Windows.Forms.TabPage();
			this.AdviceList = new System.Windows.Forms.ListView();
			this.AdviceHdr = new System.Windows.Forms.ColumnHeader();
			this.InfoHdr = new System.Windows.Forms.ColumnHeader();
			((System.ComponentModel.ISupportInitialize)(this.InitBox)).BeginInit();
			this.Pages.SuspendLayout();
			this.StatsPage.SuspendLayout();
			this.TriggerPage.SuspendLayout();
			this.HitPage.SuspendLayout();
			this.MissPage.SuspendLayout();
			this.EffectPage.SuspendLayout();
			this.AdvicePage.SuspendLayout();
			this.SuspendLayout();
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(254, 185);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 14;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(173, 185);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 13;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// ActionLbl
			// 
			this.ActionLbl.AutoSize = true;
			this.ActionLbl.Location = new System.Drawing.Point(6, 9);
			this.ActionLbl.Name = "ActionLbl";
			this.ActionLbl.Size = new System.Drawing.Size(40, 13);
			this.ActionLbl.TabIndex = 2;
			this.ActionLbl.Text = "Action:";
			// 
			// ActionBox
			// 
			this.ActionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ActionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ActionBox.FormattingEnabled = true;
			this.ActionBox.Location = new System.Drawing.Point(80, 6);
			this.ActionBox.Name = "ActionBox";
			this.ActionBox.Size = new System.Drawing.Size(223, 21);
			this.ActionBox.TabIndex = 3;
			// 
			// RangeLbl
			// 
			this.RangeLbl.AutoSize = true;
			this.RangeLbl.Location = new System.Drawing.Point(6, 36);
			this.RangeLbl.Name = "RangeLbl";
			this.RangeLbl.Size = new System.Drawing.Size(42, 13);
			this.RangeLbl.TabIndex = 4;
			this.RangeLbl.Text = "Range:";
			// 
			// RangeBox
			// 
			this.RangeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.RangeBox.Location = new System.Drawing.Point(80, 33);
			this.RangeBox.Name = "RangeBox";
			this.RangeBox.Size = new System.Drawing.Size(223, 20);
			this.RangeBox.TabIndex = 5;
			// 
			// TargetLbl
			// 
			this.TargetLbl.AutoSize = true;
			this.TargetLbl.Location = new System.Drawing.Point(6, 62);
			this.TargetLbl.Name = "TargetLbl";
			this.TargetLbl.Size = new System.Drawing.Size(41, 13);
			this.TargetLbl.TabIndex = 6;
			this.TargetLbl.Text = "Target:";
			// 
			// TargetBox
			// 
			this.TargetBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TargetBox.Location = new System.Drawing.Point(80, 59);
			this.TargetBox.Name = "TargetBox";
			this.TargetBox.Size = new System.Drawing.Size(223, 20);
			this.TargetBox.TabIndex = 7;
			// 
			// InitBox
			// 
			this.InitBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.InitBox.Location = new System.Drawing.Point(80, 85);
			this.InitBox.Name = "InitBox";
			this.InitBox.Size = new System.Drawing.Size(223, 20);
			this.InitBox.TabIndex = 9;
			// 
			// AttackLbl
			// 
			this.AttackLbl.AutoSize = true;
			this.AttackLbl.Location = new System.Drawing.Point(6, 116);
			this.AttackLbl.Name = "AttackLbl";
			this.AttackLbl.Size = new System.Drawing.Size(41, 13);
			this.AttackLbl.TabIndex = 10;
			this.AttackLbl.Text = "Attack:";
			// 
			// AttackBtn
			// 
			this.AttackBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.AttackBtn.Location = new System.Drawing.Point(80, 111);
			this.AttackBtn.Name = "AttackBtn";
			this.AttackBtn.Size = new System.Drawing.Size(223, 23);
			this.AttackBtn.TabIndex = 11;
			this.AttackBtn.Text = "[attack]";
			this.AttackBtn.UseVisualStyleBackColor = true;
			this.AttackBtn.Click += new System.EventHandler(this.AttackBtn_Click);
			// 
			// Pages
			// 
			this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Pages.Controls.Add(this.StatsPage);
			this.Pages.Controls.Add(this.TriggerPage);
			this.Pages.Controls.Add(this.HitPage);
			this.Pages.Controls.Add(this.MissPage);
			this.Pages.Controls.Add(this.EffectPage);
			this.Pages.Controls.Add(this.AdvicePage);
			this.Pages.Location = new System.Drawing.Point(12, 12);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(317, 167);
			this.Pages.TabIndex = 12;
			// 
			// StatsPage
			// 
			this.StatsPage.Controls.Add(this.ActionBox);
			this.StatsPage.Controls.Add(this.AttackBtn);
			this.StatsPage.Controls.Add(this.ActionLbl);
			this.StatsPage.Controls.Add(this.AttackLbl);
			this.StatsPage.Controls.Add(this.RangeLbl);
			this.StatsPage.Controls.Add(this.InitBox);
			this.StatsPage.Controls.Add(this.RangeBox);
			this.StatsPage.Controls.Add(this.InitBtn);
			this.StatsPage.Controls.Add(this.TargetLbl);
			this.StatsPage.Controls.Add(this.TargetBox);
			this.StatsPage.Location = new System.Drawing.Point(4, 22);
			this.StatsPage.Name = "StatsPage";
			this.StatsPage.Padding = new System.Windows.Forms.Padding(3);
			this.StatsPage.Size = new System.Drawing.Size(309, 141);
			this.StatsPage.TabIndex = 4;
			this.StatsPage.Text = "Statistics";
			this.StatsPage.UseVisualStyleBackColor = true;
			// 
			// InitBtn
			// 
			this.InitBtn.AutoSize = true;
			this.InitBtn.Location = new System.Drawing.Point(6, 86);
			this.InitBtn.Name = "InitBtn";
			this.InitBtn.Size = new System.Drawing.Size(68, 17);
			this.InitBtn.TabIndex = 8;
			this.InitBtn.Text = "Initiative:";
			this.InitBtn.UseVisualStyleBackColor = true;
			// 
			// TriggerPage
			// 
			this.TriggerPage.Controls.Add(this.TriggerBox);
			this.TriggerPage.Location = new System.Drawing.Point(4, 22);
			this.TriggerPage.Name = "TriggerPage";
			this.TriggerPage.Padding = new System.Windows.Forms.Padding(3);
			this.TriggerPage.Size = new System.Drawing.Size(309, 141);
			this.TriggerPage.TabIndex = 2;
			this.TriggerPage.Text = "Trigger";
			this.TriggerPage.UseVisualStyleBackColor = true;
			// 
			// TriggerBox
			// 
			this.TriggerBox.AcceptsReturn = true;
			this.TriggerBox.AcceptsTab = true;
			this.TriggerBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TriggerBox.Location = new System.Drawing.Point(3, 3);
			this.TriggerBox.Multiline = true;
			this.TriggerBox.Name = "TriggerBox";
			this.TriggerBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TriggerBox.Size = new System.Drawing.Size(303, 135);
			this.TriggerBox.TabIndex = 0;
			// 
			// HitPage
			// 
			this.HitPage.Controls.Add(this.HitBox);
			this.HitPage.Location = new System.Drawing.Point(4, 22);
			this.HitPage.Name = "HitPage";
			this.HitPage.Padding = new System.Windows.Forms.Padding(3);
			this.HitPage.Size = new System.Drawing.Size(309, 141);
			this.HitPage.TabIndex = 0;
			this.HitPage.Text = "On Hit";
			this.HitPage.UseVisualStyleBackColor = true;
			// 
			// HitBox
			// 
			this.HitBox.AcceptsReturn = true;
			this.HitBox.AcceptsTab = true;
			this.HitBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.HitBox.Location = new System.Drawing.Point(3, 3);
			this.HitBox.Multiline = true;
			this.HitBox.Name = "HitBox";
			this.HitBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.HitBox.Size = new System.Drawing.Size(303, 135);
			this.HitBox.TabIndex = 0;
			// 
			// MissPage
			// 
			this.MissPage.Controls.Add(this.MissBox);
			this.MissPage.Location = new System.Drawing.Point(4, 22);
			this.MissPage.Name = "MissPage";
			this.MissPage.Padding = new System.Windows.Forms.Padding(3);
			this.MissPage.Size = new System.Drawing.Size(309, 141);
			this.MissPage.TabIndex = 1;
			this.MissPage.Text = "On Miss";
			this.MissPage.UseVisualStyleBackColor = true;
			// 
			// MissBox
			// 
			this.MissBox.AcceptsReturn = true;
			this.MissBox.AcceptsTab = true;
			this.MissBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MissBox.Location = new System.Drawing.Point(3, 3);
			this.MissBox.Multiline = true;
			this.MissBox.Name = "MissBox";
			this.MissBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.MissBox.Size = new System.Drawing.Size(303, 135);
			this.MissBox.TabIndex = 1;
			// 
			// EffectPage
			// 
			this.EffectPage.Controls.Add(this.EffectBox);
			this.EffectPage.Location = new System.Drawing.Point(4, 22);
			this.EffectPage.Name = "EffectPage";
			this.EffectPage.Padding = new System.Windows.Forms.Padding(3);
			this.EffectPage.Size = new System.Drawing.Size(309, 141);
			this.EffectPage.TabIndex = 3;
			this.EffectPage.Text = "Effect";
			this.EffectPage.UseVisualStyleBackColor = true;
			// 
			// EffectBox
			// 
			this.EffectBox.AcceptsReturn = true;
			this.EffectBox.AcceptsTab = true;
			this.EffectBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EffectBox.Location = new System.Drawing.Point(3, 3);
			this.EffectBox.Multiline = true;
			this.EffectBox.Name = "EffectBox";
			this.EffectBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.EffectBox.Size = new System.Drawing.Size(303, 135);
			this.EffectBox.TabIndex = 2;
			// 
			// AdvicePage
			// 
			this.AdvicePage.Controls.Add(this.AdviceList);
			this.AdvicePage.Location = new System.Drawing.Point(4, 22);
			this.AdvicePage.Name = "AdvicePage";
			this.AdvicePage.Padding = new System.Windows.Forms.Padding(3);
			this.AdvicePage.Size = new System.Drawing.Size(309, 141);
			this.AdvicePage.TabIndex = 5;
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
			listViewGroup1.Header = "Initiative";
			listViewGroup1.Name = "listViewGroup1";
			listViewGroup2.Header = "Attack Bonus";
			listViewGroup2.Name = "listViewGroup2";
			this.AdviceList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
			this.AdviceList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.AdviceList.HideSelection = false;
			this.AdviceList.Location = new System.Drawing.Point(3, 3);
			this.AdviceList.MultiSelect = false;
			this.AdviceList.Name = "AdviceList";
			this.AdviceList.Size = new System.Drawing.Size(303, 135);
			this.AdviceList.TabIndex = 1;
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
			this.InfoHdr.Text = "Information";
			this.InfoHdr.Width = 100;
			// 
			// TrapAttackForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(341, 220);
			this.Controls.Add(this.Pages);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TrapAttackForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Trap Attack";
			((System.ComponentModel.ISupportInitialize)(this.InitBox)).EndInit();
			this.Pages.ResumeLayout(false);
			this.StatsPage.ResumeLayout(false);
			this.StatsPage.PerformLayout();
			this.TriggerPage.ResumeLayout(false);
			this.TriggerPage.PerformLayout();
			this.HitPage.ResumeLayout(false);
			this.HitPage.PerformLayout();
			this.MissPage.ResumeLayout(false);
			this.MissPage.PerformLayout();
			this.EffectPage.ResumeLayout(false);
			this.EffectPage.PerformLayout();
			this.AdvicePage.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Label ActionLbl;
		private System.Windows.Forms.ComboBox ActionBox;
		private System.Windows.Forms.Label RangeLbl;
		private System.Windows.Forms.TextBox RangeBox;
		private System.Windows.Forms.Label TargetLbl;
		private System.Windows.Forms.TextBox TargetBox;
		private System.Windows.Forms.NumericUpDown InitBox;
		private System.Windows.Forms.Label AttackLbl;
		private System.Windows.Forms.Button AttackBtn;
		private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.TabPage HitPage;
		private System.Windows.Forms.TabPage MissPage;
		private System.Windows.Forms.CheckBox InitBtn;
		private System.Windows.Forms.TextBox HitBox;
		private System.Windows.Forms.TextBox MissBox;
		private System.Windows.Forms.TabPage TriggerPage;
		private System.Windows.Forms.TextBox TriggerBox;
		private System.Windows.Forms.TabPage EffectPage;
		private System.Windows.Forms.TextBox EffectBox;
		private System.Windows.Forms.TabPage StatsPage;
		private System.Windows.Forms.TabPage AdvicePage;
		private System.Windows.Forms.ListView AdviceList;
		private System.Windows.Forms.ColumnHeader AdviceHdr;
		private System.Windows.Forms.ColumnHeader InfoHdr;
	}
}