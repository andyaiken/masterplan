namespace Masterplan.UI
{
	partial class GroupHealthForm
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
			this.CloseBtn = new System.Windows.Forms.Button();
			this.CombatantList = new System.Windows.Forms.ListView();
			this.CombatantHdr = new System.Windows.Forms.ColumnHeader();
			this.InitHdr = new System.Windows.Forms.ColumnHeader();
			this.HPPanel = new System.Windows.Forms.Panel();
			this.FullHealBtn = new System.Windows.Forms.Button();
			this.HeroNameLbl = new System.Windows.Forms.Label();
			this.MaxHPBox = new System.Windows.Forms.NumericUpDown();
			this.MaxHPLbl = new System.Windows.Forms.Label();
			this.HPGauge = new Masterplan.Controls.HitPointGauge();
			this.TempHPBox = new System.Windows.Forms.NumericUpDown();
			this.TempHPLbl = new System.Windows.Forms.Label();
			this.CurrentHPBox = new System.Windows.Forms.NumericUpDown();
			this.CurrentHPLbl = new System.Windows.Forms.Label();
			this.HPPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MaxHPBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TempHPBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CurrentHPBox)).BeginInit();
			this.SuspendLayout();
			// 
			// CloseBtn
			// 
			this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.CloseBtn.Location = new System.Drawing.Point(378, 220);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.Size = new System.Drawing.Size(75, 23);
			this.CloseBtn.TabIndex = 2;
			this.CloseBtn.Text = "OK";
			this.CloseBtn.UseVisualStyleBackColor = true;
			// 
			// CombatantList
			// 
			this.CombatantList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.CombatantList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CombatantHdr,
            this.InitHdr});
			this.CombatantList.FullRowSelect = true;
			this.CombatantList.HideSelection = false;
			this.CombatantList.Location = new System.Drawing.Point(12, 12);
			this.CombatantList.MultiSelect = false;
			this.CombatantList.Name = "CombatantList";
			this.CombatantList.Size = new System.Drawing.Size(238, 202);
			this.CombatantList.TabIndex = 1;
			this.CombatantList.UseCompatibleStateImageBehavior = false;
			this.CombatantList.View = System.Windows.Forms.View.Details;
			this.CombatantList.SelectedIndexChanged += new System.EventHandler(this.CombatantList_SelectedIndexChanged);
			this.CombatantList.DoubleClick += new System.EventHandler(this.CombatantList_DoubleClick);
			// 
			// CombatantHdr
			// 
			this.CombatantHdr.Text = "PC";
			this.CombatantHdr.Width = 131;
			// 
			// InitHdr
			// 
			this.InitHdr.Text = "Hit Points";
			this.InitHdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InitHdr.Width = 76;
			// 
			// HPPanel
			// 
			this.HPPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.HPPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.HPPanel.Controls.Add(this.FullHealBtn);
			this.HPPanel.Controls.Add(this.HeroNameLbl);
			this.HPPanel.Controls.Add(this.MaxHPBox);
			this.HPPanel.Controls.Add(this.MaxHPLbl);
			this.HPPanel.Controls.Add(this.HPGauge);
			this.HPPanel.Controls.Add(this.TempHPBox);
			this.HPPanel.Controls.Add(this.TempHPLbl);
			this.HPPanel.Controls.Add(this.CurrentHPBox);
			this.HPPanel.Controls.Add(this.CurrentHPLbl);
			this.HPPanel.Location = new System.Drawing.Point(256, 12);
			this.HPPanel.Name = "HPPanel";
			this.HPPanel.Size = new System.Drawing.Size(197, 202);
			this.HPPanel.TabIndex = 3;
			// 
			// FullHealBtn
			// 
			this.FullHealBtn.Location = new System.Drawing.Point(6, 135);
			this.FullHealBtn.Name = "FullHealBtn";
			this.FullHealBtn.Size = new System.Drawing.Size(148, 23);
			this.FullHealBtn.TabIndex = 16;
			this.FullHealBtn.Text = "Full Heal";
			this.FullHealBtn.UseVisualStyleBackColor = true;
			this.FullHealBtn.Click += new System.EventHandler(this.FullHealBtn_Click);
			// 
			// HeroNameLbl
			// 
			this.HeroNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.HeroNameLbl.Location = new System.Drawing.Point(3, 3);
			this.HeroNameLbl.Name = "HeroNameLbl";
			this.HeroNameLbl.Size = new System.Drawing.Size(151, 40);
			this.HeroNameLbl.TabIndex = 15;
			this.HeroNameLbl.Text = "[hero]";
			this.HeroNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// MaxHPBox
			// 
			this.MaxHPBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.MaxHPBox.Location = new System.Drawing.Point(76, 57);
			this.MaxHPBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.MaxHPBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.MaxHPBox.Name = "MaxHPBox";
			this.MaxHPBox.Size = new System.Drawing.Size(78, 20);
			this.MaxHPBox.TabIndex = 9;
			this.MaxHPBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.MaxHPBox.ValueChanged += new System.EventHandler(this.MaxHPBox_ValueChanged);
			// 
			// MaxHPLbl
			// 
			this.MaxHPLbl.AutoSize = true;
			this.MaxHPLbl.Location = new System.Drawing.Point(3, 59);
			this.MaxHPLbl.Name = "MaxHPLbl";
			this.MaxHPLbl.Size = new System.Drawing.Size(48, 13);
			this.MaxHPLbl.TabIndex = 8;
			this.MaxHPLbl.Text = "Max HP:";
			// 
			// HPGauge
			// 
			this.HPGauge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.HPGauge.Damage = 0;
			this.HPGauge.FullHP = 0;
			this.HPGauge.Location = new System.Drawing.Point(160, 3);
			this.HPGauge.Name = "HPGauge";
			this.HPGauge.Size = new System.Drawing.Size(32, 194);
			this.HPGauge.TabIndex = 14;
			this.HPGauge.TempHP = 0;
			// 
			// TempHPBox
			// 
			this.TempHPBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TempHPBox.Location = new System.Drawing.Point(76, 109);
			this.TempHPBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.TempHPBox.Name = "TempHPBox";
			this.TempHPBox.Size = new System.Drawing.Size(78, 20);
			this.TempHPBox.TabIndex = 13;
			this.TempHPBox.ValueChanged += new System.EventHandler(this.TempHPBox_ValueChanged);
			// 
			// TempHPLbl
			// 
			this.TempHPLbl.AutoSize = true;
			this.TempHPLbl.Location = new System.Drawing.Point(3, 111);
			this.TempHPLbl.Name = "TempHPLbl";
			this.TempHPLbl.Size = new System.Drawing.Size(55, 13);
			this.TempHPLbl.TabIndex = 12;
			this.TempHPLbl.Text = "Temp HP:";
			// 
			// CurrentHPBox
			// 
			this.CurrentHPBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.CurrentHPBox.Location = new System.Drawing.Point(76, 83);
			this.CurrentHPBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.CurrentHPBox.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
			this.CurrentHPBox.Name = "CurrentHPBox";
			this.CurrentHPBox.Size = new System.Drawing.Size(78, 20);
			this.CurrentHPBox.TabIndex = 11;
			this.CurrentHPBox.ValueChanged += new System.EventHandler(this.CurrentHPBox_ValueChanged);
			// 
			// CurrentHPLbl
			// 
			this.CurrentHPLbl.AutoSize = true;
			this.CurrentHPLbl.Location = new System.Drawing.Point(3, 85);
			this.CurrentHPLbl.Name = "CurrentHPLbl";
			this.CurrentHPLbl.Size = new System.Drawing.Size(62, 13);
			this.CurrentHPLbl.TabIndex = 10;
			this.CurrentHPLbl.Text = "Current HP:";
			// 
			// GroupHealthForm
			// 
			this.AcceptButton = this.CloseBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(465, 255);
			this.Controls.Add(this.HPPanel);
			this.Controls.Add(this.CombatantList);
			this.Controls.Add(this.CloseBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GroupHealthForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "PC Hit Points";
			this.HPPanel.ResumeLayout(false);
			this.HPPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.MaxHPBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TempHPBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CurrentHPBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button CloseBtn;
		private System.Windows.Forms.ListView CombatantList;
		private System.Windows.Forms.ColumnHeader CombatantHdr;
		private System.Windows.Forms.ColumnHeader InitHdr;
		private System.Windows.Forms.Panel HPPanel;
		private System.Windows.Forms.Label HeroNameLbl;
		private System.Windows.Forms.NumericUpDown MaxHPBox;
		private System.Windows.Forms.Label MaxHPLbl;
		private Masterplan.Controls.HitPointGauge HPGauge;
		private System.Windows.Forms.NumericUpDown TempHPBox;
		private System.Windows.Forms.Label TempHPLbl;
		private System.Windows.Forms.NumericUpDown CurrentHPBox;
		private System.Windows.Forms.Label CurrentHPLbl;
		private System.Windows.Forms.Button FullHealBtn;
	}
}