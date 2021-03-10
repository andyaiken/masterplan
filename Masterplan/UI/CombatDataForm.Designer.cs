namespace Masterplan.UI
{
	partial class CombatDataForm
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
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Ongoing Conditions", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Ongoing Damage", System.Windows.Forms.HorizontalAlignment.Left);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CombatDataForm));
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.InitLbl = new System.Windows.Forms.Label();
			this.InitBox = new System.Windows.Forms.NumericUpDown();
			this.DamageLbl = new System.Windows.Forms.Label();
			this.DamageBox = new System.Windows.Forms.NumericUpDown();
			this.HPBox = new System.Windows.Forms.TextBox();
			this.ConditionPanel = new System.Windows.Forms.Panel();
			this.EffectList = new System.Windows.Forms.ListView();
			this.EffectHdr = new System.Windows.Forms.ColumnHeader();
			this.EffectDurationHdr = new System.Windows.Forms.ColumnHeader();
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.AddBtn = new System.Windows.Forms.ToolStripButton();
			this.RemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.EditBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.DmgBtn = new System.Windows.Forms.ToolStripButton();
			this.SavesBtn = new System.Windows.Forms.ToolStripButton();
			this.TempHPBox = new System.Windows.Forms.NumericUpDown();
			this.TempHPLbl = new System.Windows.Forms.Label();
			this.LabelLbl = new System.Windows.Forms.Label();
			this.LabelBox = new System.Windows.Forms.TextBox();
			this.HPGauge = new Masterplan.Controls.HitPointGauge();
			this.AltitudeBox = new System.Windows.Forms.NumericUpDown();
			this.AltitudeLbl = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.InitBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DamageBox)).BeginInit();
			this.ConditionPanel.SuspendLayout();
			this.Toolbar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.TempHPBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.AltitudeBox)).BeginInit();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(231, 351);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 13;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(312, 351);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 14;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// InitLbl
			// 
			this.InitLbl.AutoSize = true;
			this.InitLbl.Location = new System.Drawing.Point(12, 143);
			this.InitLbl.Name = "InitLbl";
			this.InitLbl.Size = new System.Drawing.Size(49, 13);
			this.InitLbl.TabIndex = 7;
			this.InitLbl.Text = "Initiative:";
			// 
			// InitBox
			// 
			this.InitBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.InitBox.Location = new System.Drawing.Point(73, 141);
			this.InitBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.InitBox.Name = "InitBox";
			this.InitBox.Size = new System.Drawing.Size(276, 20);
			this.InitBox.TabIndex = 8;
			// 
			// DamageLbl
			// 
			this.DamageLbl.AutoSize = true;
			this.DamageLbl.Location = new System.Drawing.Point(12, 53);
			this.DamageLbl.Name = "DamageLbl";
			this.DamageLbl.Size = new System.Drawing.Size(50, 13);
			this.DamageLbl.TabIndex = 2;
			this.DamageLbl.Text = "Damage:";
			// 
			// DamageBox
			// 
			this.DamageBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DamageBox.Location = new System.Drawing.Point(73, 51);
			this.DamageBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.DamageBox.Name = "DamageBox";
			this.DamageBox.Size = new System.Drawing.Size(276, 20);
			this.DamageBox.TabIndex = 3;
			this.DamageBox.ValueChanged += new System.EventHandler(this.DamageBox_ValueChanged);
			// 
			// HPBox
			// 
			this.HPBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.HPBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.HPBox.Location = new System.Drawing.Point(73, 103);
			this.HPBox.Name = "HPBox";
			this.HPBox.ReadOnly = true;
			this.HPBox.Size = new System.Drawing.Size(276, 20);
			this.HPBox.TabIndex = 6;
			this.HPBox.TabStop = false;
			this.HPBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ConditionPanel
			// 
			this.ConditionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ConditionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ConditionPanel.Controls.Add(this.EffectList);
			this.ConditionPanel.Controls.Add(this.Toolbar);
			this.ConditionPanel.Location = new System.Drawing.Point(12, 193);
			this.ConditionPanel.Name = "ConditionPanel";
			this.ConditionPanel.Size = new System.Drawing.Size(337, 152);
			this.ConditionPanel.TabIndex = 11;
			// 
			// EffectList
			// 
			this.EffectList.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.EffectList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EffectHdr,
            this.EffectDurationHdr});
			this.EffectList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EffectList.FullRowSelect = true;
			listViewGroup1.Header = "Ongoing Conditions";
			listViewGroup1.Name = "ConditionHdr";
			listViewGroup2.Header = "Ongoing Damage";
			listViewGroup2.Name = "DmgHdr";
			this.EffectList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
			this.EffectList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.EffectList.HideSelection = false;
			this.EffectList.Location = new System.Drawing.Point(0, 25);
			this.EffectList.MultiSelect = false;
			this.EffectList.Name = "EffectList";
			this.EffectList.Size = new System.Drawing.Size(335, 125);
			this.EffectList.TabIndex = 1;
			this.EffectList.TileSize = new System.Drawing.Size(200, 30);
			this.EffectList.UseCompatibleStateImageBehavior = false;
			this.EffectList.View = System.Windows.Forms.View.Tile;
			this.EffectList.SizeChanged += new System.EventHandler(this.EffectList_SizeChanged);
			this.EffectList.DoubleClick += new System.EventHandler(this.EditBtn_Click);
			// 
			// EffectHdr
			// 
			this.EffectHdr.Text = "Effect";
			this.EffectHdr.Width = 120;
			// 
			// EffectDurationHdr
			// 
			this.EffectDurationHdr.Text = "Duration";
			this.EffectDurationHdr.Width = 141;
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddBtn,
            this.RemoveBtn,
            this.EditBtn,
            this.toolStripSeparator1,
            this.DmgBtn,
            this.SavesBtn});
			this.Toolbar.Location = new System.Drawing.Point(0, 0);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(335, 25);
			this.Toolbar.TabIndex = 0;
			this.Toolbar.Text = "toolStrip1";
			// 
			// AddBtn
			// 
			this.AddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.AddBtn.Image = ((System.Drawing.Image)(resources.GetObject("AddBtn.Image")));
			this.AddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AddBtn.Name = "AddBtn";
			this.AddBtn.Size = new System.Drawing.Size(33, 22);
			this.AddBtn.Text = "Add";
			this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
			// 
			// RemoveBtn
			// 
			this.RemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.RemoveBtn.Image = ((System.Drawing.Image)(resources.GetObject("RemoveBtn.Image")));
			this.RemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RemoveBtn.Name = "RemoveBtn";
			this.RemoveBtn.Size = new System.Drawing.Size(54, 22);
			this.RemoveBtn.Text = "Remove";
			this.RemoveBtn.Click += new System.EventHandler(this.RemoveBtn_Click);
			// 
			// EditBtn
			// 
			this.EditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.EditBtn.Image = ((System.Drawing.Image)(resources.GetObject("EditBtn.Image")));
			this.EditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EditBtn.Name = "EditBtn";
			this.EditBtn.Size = new System.Drawing.Size(31, 22);
			this.EditBtn.Text = "Edit";
			this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// DmgBtn
			// 
			this.DmgBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.DmgBtn.Image = ((System.Drawing.Image)(resources.GetObject("DmgBtn.Image")));
			this.DmgBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.DmgBtn.Name = "DmgBtn";
			this.DmgBtn.Size = new System.Drawing.Size(105, 22);
			this.DmgBtn.Text = "Ongoing Damage";
			this.DmgBtn.Click += new System.EventHandler(this.DmgBtn_Click);
			// 
			// SavesBtn
			// 
			this.SavesBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SavesBtn.Image = ((System.Drawing.Image)(resources.GetObject("SavesBtn.Image")));
			this.SavesBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SavesBtn.Name = "SavesBtn";
			this.SavesBtn.Size = new System.Drawing.Size(40, 22);
			this.SavesBtn.Text = "Saves";
			this.SavesBtn.Click += new System.EventHandler(this.SavesBtn_Click);
			// 
			// TempHPBox
			// 
			this.TempHPBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TempHPBox.Location = new System.Drawing.Point(73, 77);
			this.TempHPBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.TempHPBox.Name = "TempHPBox";
			this.TempHPBox.Size = new System.Drawing.Size(276, 20);
			this.TempHPBox.TabIndex = 5;
			this.TempHPBox.ValueChanged += new System.EventHandler(this.TempHPBox_ValueChanged);
			// 
			// TempHPLbl
			// 
			this.TempHPLbl.AutoSize = true;
			this.TempHPLbl.Location = new System.Drawing.Point(12, 79);
			this.TempHPLbl.Name = "TempHPLbl";
			this.TempHPLbl.Size = new System.Drawing.Size(55, 13);
			this.TempHPLbl.TabIndex = 4;
			this.TempHPLbl.Text = "Temp HP:";
			// 
			// LabelLbl
			// 
			this.LabelLbl.AutoSize = true;
			this.LabelLbl.Location = new System.Drawing.Point(12, 15);
			this.LabelLbl.Name = "LabelLbl";
			this.LabelLbl.Size = new System.Drawing.Size(36, 13);
			this.LabelLbl.TabIndex = 0;
			this.LabelLbl.Text = "Label:";
			// 
			// LabelBox
			// 
			this.LabelBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.LabelBox.Location = new System.Drawing.Point(73, 12);
			this.LabelBox.Name = "LabelBox";
			this.LabelBox.Size = new System.Drawing.Size(314, 20);
			this.LabelBox.TabIndex = 1;
			// 
			// HPGauge
			// 
			this.HPGauge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.HPGauge.Damage = 0;
			this.HPGauge.FullHP = 0;
			this.HPGauge.Location = new System.Drawing.Point(355, 51);
			this.HPGauge.Name = "HPGauge";
			this.HPGauge.Size = new System.Drawing.Size(32, 294);
			this.HPGauge.TabIndex = 12;
			this.HPGauge.TempHP = 0;
			// 
			// AltitudeBox
			// 
			this.AltitudeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.AltitudeBox.Location = new System.Drawing.Point(73, 167);
			this.AltitudeBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.AltitudeBox.Name = "AltitudeBox";
			this.AltitudeBox.Size = new System.Drawing.Size(276, 20);
			this.AltitudeBox.TabIndex = 10;
			// 
			// AltitudeLbl
			// 
			this.AltitudeLbl.AutoSize = true;
			this.AltitudeLbl.Location = new System.Drawing.Point(12, 169);
			this.AltitudeLbl.Name = "AltitudeLbl";
			this.AltitudeLbl.Size = new System.Drawing.Size(45, 13);
			this.AltitudeLbl.TabIndex = 9;
			this.AltitudeLbl.Text = "Altitude:";
			// 
			// CombatDataForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(399, 386);
			this.Controls.Add(this.AltitudeBox);
			this.Controls.Add(this.AltitudeLbl);
			this.Controls.Add(this.LabelBox);
			this.Controls.Add(this.LabelLbl);
			this.Controls.Add(this.HPGauge);
			this.Controls.Add(this.TempHPBox);
			this.Controls.Add(this.TempHPLbl);
			this.Controls.Add(this.ConditionPanel);
			this.Controls.Add(this.HPBox);
			this.Controls.Add(this.DamageBox);
			this.Controls.Add(this.DamageLbl);
			this.Controls.Add(this.InitBox);
			this.Controls.Add(this.InitLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CombatDataForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Combatant";
			((System.ComponentModel.ISupportInitialize)(this.InitBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DamageBox)).EndInit();
			this.ConditionPanel.ResumeLayout(false);
			this.ConditionPanel.PerformLayout();
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.TempHPBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.AltitudeBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label InitLbl;
		private System.Windows.Forms.NumericUpDown InitBox;
		private System.Windows.Forms.Label DamageLbl;
		private System.Windows.Forms.NumericUpDown DamageBox;
		private System.Windows.Forms.TextBox HPBox;
		private System.Windows.Forms.Panel ConditionPanel;
		private System.Windows.Forms.ListView EffectList;
		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ColumnHeader EffectHdr;
		private System.Windows.Forms.ToolStripButton RemoveBtn;
		private System.Windows.Forms.ToolStripButton EditBtn;
		private System.Windows.Forms.ToolStripButton AddBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton SavesBtn;
		private System.Windows.Forms.ToolStripButton DmgBtn;
		private System.Windows.Forms.NumericUpDown TempHPBox;
		private System.Windows.Forms.Label TempHPLbl;
		private Masterplan.Controls.HitPointGauge HPGauge;
		private System.Windows.Forms.Label LabelLbl;
		private System.Windows.Forms.TextBox LabelBox;
		private System.Windows.Forms.ColumnHeader EffectDurationHdr;
		private System.Windows.Forms.NumericUpDown AltitudeBox;
		private System.Windows.Forms.Label AltitudeLbl;
	}
}