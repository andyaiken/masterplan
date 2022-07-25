namespace Masterplan.UI
{
	partial class DamageForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DamageForm));
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.DmgLbl = new System.Windows.Forms.Label();
			this.DmgBox = new System.Windows.Forms.NumericUpDown();
			this.ModLbl = new System.Windows.Forms.Label();
			this.ModBox = new System.Windows.Forms.TextBox();
			this.ValLbl = new System.Windows.Forms.Label();
			this.HalveBtn = new System.Windows.Forms.CheckBox();
			this.TypeLbl = new System.Windows.Forms.Label();
			this.ValBox = new System.Windows.Forms.TextBox();
			this.AmountToolbar = new System.Windows.Forms.ToolStrip();
			this.Dmg1 = new System.Windows.Forms.ToolStripButton();
			this.Dmg2 = new System.Windows.Forms.ToolStripButton();
			this.Dmg5 = new System.Windows.Forms.ToolStripButton();
			this.Dmg10 = new System.Windows.Forms.ToolStripButton();
			this.Dmg20 = new System.Windows.Forms.ToolStripButton();
			this.Dmg50 = new System.Windows.Forms.ToolStripButton();
			this.Dmg100 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.ResetBtn = new System.Windows.Forms.ToolStripButton();
			this.TypeToolbar = new System.Windows.Forms.ToolStrip();
			this.AcidBtn = new System.Windows.Forms.ToolStripButton();
			this.ColdBtn = new System.Windows.Forms.ToolStripButton();
			this.FireBtn = new System.Windows.Forms.ToolStripButton();
			this.ForceBtn = new System.Windows.Forms.ToolStripButton();
			this.LightningBtn = new System.Windows.Forms.ToolStripButton();
			this.NecroticBtn = new System.Windows.Forms.ToolStripButton();
			this.PoisonBtn = new System.Windows.Forms.ToolStripButton();
			this.PsychicBtn = new System.Windows.Forms.ToolStripButton();
			this.RadiantBtn = new System.Windows.Forms.ToolStripButton();
			this.ThunderBtn = new System.Windows.Forms.ToolStripButton();
			this.TypeBox = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.DmgBox)).BeginInit();
			this.AmountToolbar.SuspendLayout();
			this.TypeToolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(172, 190);
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
			this.CancelBtn.Location = new System.Drawing.Point(253, 190);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 12;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// DmgLbl
			// 
			this.DmgLbl.AutoSize = true;
			this.DmgLbl.Location = new System.Drawing.Point(66, 30);
			this.DmgLbl.Name = "DmgLbl";
			this.DmgLbl.Size = new System.Drawing.Size(50, 13);
			this.DmgLbl.TabIndex = 2;
			this.DmgLbl.Text = "Damage:";
			// 
			// DmgBox
			// 
			this.DmgBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DmgBox.Location = new System.Drawing.Point(134, 28);
			this.DmgBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.DmgBox.Name = "DmgBox";
			this.DmgBox.Size = new System.Drawing.Size(194, 20);
			this.DmgBox.TabIndex = 3;
			this.DmgBox.ValueChanged += new System.EventHandler(this.DmgBox_ValueChanged);
			// 
			// ModLbl
			// 
			this.ModLbl.AutoSize = true;
			this.ModLbl.Location = new System.Drawing.Point(66, 86);
			this.ModLbl.Name = "ModLbl";
			this.ModLbl.Size = new System.Drawing.Size(47, 13);
			this.ModLbl.TabIndex = 6;
			this.ModLbl.Text = "Modifier:";
			// 
			// ModBox
			// 
			this.ModBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ModBox.Location = new System.Drawing.Point(134, 83);
			this.ModBox.Name = "ModBox";
			this.ModBox.ReadOnly = true;
			this.ModBox.Size = new System.Drawing.Size(194, 20);
			this.ModBox.TabIndex = 7;
			// 
			// ValLbl
			// 
			this.ValLbl.AutoSize = true;
			this.ValLbl.Location = new System.Drawing.Point(66, 135);
			this.ValLbl.Name = "ValLbl";
			this.ValLbl.Size = new System.Drawing.Size(62, 13);
			this.ValLbl.TabIndex = 9;
			this.ValLbl.Text = "Final Value:";
			// 
			// HalveBtn
			// 
			this.HalveBtn.AutoSize = true;
			this.HalveBtn.Location = new System.Drawing.Point(134, 109);
			this.HalveBtn.Name = "HalveBtn";
			this.HalveBtn.Size = new System.Drawing.Size(95, 17);
			this.HalveBtn.TabIndex = 8;
			this.HalveBtn.Text = "Halve damage";
			this.HalveBtn.UseVisualStyleBackColor = true;
			this.HalveBtn.CheckedChanged += new System.EventHandler(this.HalveBtn_CheckedChanged);
			// 
			// TypeLbl
			// 
			this.TypeLbl.AutoSize = true;
			this.TypeLbl.Location = new System.Drawing.Point(66, 57);
			this.TypeLbl.Name = "TypeLbl";
			this.TypeLbl.Size = new System.Drawing.Size(34, 13);
			this.TypeLbl.TabIndex = 4;
			this.TypeLbl.Text = "Type:";
			// 
			// ValBox
			// 
			this.ValBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ValBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ValBox.Location = new System.Drawing.Point(134, 132);
			this.ValBox.Name = "ValBox";
			this.ValBox.ReadOnly = true;
			this.ValBox.Size = new System.Drawing.Size(194, 26);
			this.ValBox.TabIndex = 10;
			this.ValBox.Text = "[dmg]";
			this.ValBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// AmountToolbar
			// 
			this.AmountToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Dmg1,
            this.Dmg2,
            this.Dmg5,
            this.Dmg10,
            this.Dmg20,
            this.Dmg50,
            this.Dmg100,
            this.toolStripSeparator1,
            this.ResetBtn});
			this.AmountToolbar.Location = new System.Drawing.Point(63, 0);
			this.AmountToolbar.Name = "AmountToolbar";
			this.AmountToolbar.Size = new System.Drawing.Size(277, 25);
			this.AmountToolbar.TabIndex = 0;
			this.AmountToolbar.Text = Session.I18N.toolStrip1;
			// 
			// Dmg1
			// 
			this.Dmg1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.Dmg1.Image = ((System.Drawing.Image)(resources.GetObject("Dmg1.Image")));
			this.Dmg1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.Dmg1.Name = "Dmg1";
			this.Dmg1.Size = new System.Drawing.Size(25, 22);
			this.Dmg1.Text = "+1";
			this.Dmg1.Click += new System.EventHandler(this.Dmg1_Click);
			// 
			// Dmg2
			// 
			this.Dmg2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.Dmg2.Image = ((System.Drawing.Image)(resources.GetObject("Dmg2.Image")));
			this.Dmg2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.Dmg2.Name = "Dmg2";
			this.Dmg2.Size = new System.Drawing.Size(25, 22);
			this.Dmg2.Text = "+2";
			this.Dmg2.Click += new System.EventHandler(this.Dmg2_Click);
			// 
			// Dmg5
			// 
			this.Dmg5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.Dmg5.Image = ((System.Drawing.Image)(resources.GetObject("Dmg5.Image")));
			this.Dmg5.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.Dmg5.Name = "Dmg5";
			this.Dmg5.Size = new System.Drawing.Size(25, 22);
			this.Dmg5.Text = "+5";
			this.Dmg5.Click += new System.EventHandler(this.Dmg5_Click);
			// 
			// Dmg10
			// 
			this.Dmg10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.Dmg10.Image = ((System.Drawing.Image)(resources.GetObject("Dmg10.Image")));
			this.Dmg10.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.Dmg10.Name = "Dmg10";
			this.Dmg10.Size = new System.Drawing.Size(31, 22);
			this.Dmg10.Text = "+10";
			this.Dmg10.Click += new System.EventHandler(this.Dmg10_Click);
			// 
			// Dmg20
			// 
			this.Dmg20.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.Dmg20.Image = ((System.Drawing.Image)(resources.GetObject("Dmg20.Image")));
			this.Dmg20.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.Dmg20.Name = "Dmg20";
			this.Dmg20.Size = new System.Drawing.Size(31, 22);
			this.Dmg20.Text = "+20";
			this.Dmg20.Click += new System.EventHandler(this.Dmg20_Click);
			// 
			// Dmg50
			// 
			this.Dmg50.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.Dmg50.Image = ((System.Drawing.Image)(resources.GetObject("Dmg50.Image")));
			this.Dmg50.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.Dmg50.Name = "Dmg50";
			this.Dmg50.Size = new System.Drawing.Size(31, 22);
			this.Dmg50.Text = "+50";
			this.Dmg50.Click += new System.EventHandler(this.Dmg50_Click);
			// 
			// Dmg100
			// 
			this.Dmg100.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.Dmg100.Image = ((System.Drawing.Image)(resources.GetObject("Dmg100.Image")));
			this.Dmg100.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.Dmg100.Name = "Dmg100";
			this.Dmg100.Size = new System.Drawing.Size(37, 22);
			this.Dmg100.Text = "+100";
			this.Dmg100.Click += new System.EventHandler(this.Dmg100_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// ResetBtn
			// 
			this.ResetBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ResetBtn.Image = ((System.Drawing.Image)(resources.GetObject("ResetBtn.Image")));
			this.ResetBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ResetBtn.Name = "ResetBtn";
			this.ResetBtn.Size = new System.Drawing.Size(39, 22);
			this.ResetBtn.Text = "Reset";
			this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
			// 
			// TypeToolbar
			// 
			this.TypeToolbar.Dock = System.Windows.Forms.DockStyle.Left;
			this.TypeToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.TypeToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AcidBtn,
            this.ColdBtn,
            this.FireBtn,
            this.ForceBtn,
            this.LightningBtn,
            this.NecroticBtn,
            this.PoisonBtn,
            this.PsychicBtn,
            this.RadiantBtn,
            this.ThunderBtn});
			this.TypeToolbar.Location = new System.Drawing.Point(0, 0);
			this.TypeToolbar.Name = "TypeToolbar";
			this.TypeToolbar.Size = new System.Drawing.Size(63, 225);
			this.TypeToolbar.TabIndex = 1;
			this.TypeToolbar.Text = "toolStrip2";
			// 
			// AcidBtn
			// 
			this.AcidBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.AcidBtn.Image = ((System.Drawing.Image)(resources.GetObject("AcidBtn.Image")));
			this.AcidBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AcidBtn.Name = "AcidBtn";
			this.AcidBtn.Size = new System.Drawing.Size(60, 19);
			this.AcidBtn.Text = "Acid";
			this.AcidBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.AcidBtn.Click += new System.EventHandler(this.AcidBtn_Click);
			// 
			// ColdBtn
			// 
			this.ColdBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ColdBtn.Image = ((System.Drawing.Image)(resources.GetObject("ColdBtn.Image")));
			this.ColdBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ColdBtn.Name = "ColdBtn";
			this.ColdBtn.Size = new System.Drawing.Size(60, 19);
			this.ColdBtn.Text = "Cold";
			this.ColdBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ColdBtn.Click += new System.EventHandler(this.ColdBtn_Click);
			// 
			// FireBtn
			// 
			this.FireBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.FireBtn.Image = ((System.Drawing.Image)(resources.GetObject("FireBtn.Image")));
			this.FireBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.FireBtn.Name = "FireBtn";
			this.FireBtn.Size = new System.Drawing.Size(60, 19);
			this.FireBtn.Text = "Fire";
			this.FireBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.FireBtn.Click += new System.EventHandler(this.FireBtn_Click);
			// 
			// ForceBtn
			// 
			this.ForceBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ForceBtn.Image = ((System.Drawing.Image)(resources.GetObject("ForceBtn.Image")));
			this.ForceBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ForceBtn.Name = "ForceBtn";
			this.ForceBtn.Size = new System.Drawing.Size(60, 19);
			this.ForceBtn.Text = "Force";
			this.ForceBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ForceBtn.Click += new System.EventHandler(this.ForceBtn_Click);
			// 
			// LightningBtn
			// 
			this.LightningBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.LightningBtn.Image = ((System.Drawing.Image)(resources.GetObject("LightningBtn.Image")));
			this.LightningBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.LightningBtn.Name = "LightningBtn";
			this.LightningBtn.Size = new System.Drawing.Size(60, 19);
			this.LightningBtn.Text = "Lightning";
			this.LightningBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LightningBtn.Click += new System.EventHandler(this.LightningBtn_Click);
			// 
			// NecroticBtn
			// 
			this.NecroticBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.NecroticBtn.Image = ((System.Drawing.Image)(resources.GetObject("NecroticBtn.Image")));
			this.NecroticBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.NecroticBtn.Name = "NecroticBtn";
			this.NecroticBtn.Size = new System.Drawing.Size(60, 19);
			this.NecroticBtn.Text = "Necrotic";
			this.NecroticBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.NecroticBtn.Click += new System.EventHandler(this.NecroticBtn_Click);
			// 
			// PoisonBtn
			// 
			this.PoisonBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.PoisonBtn.Image = ((System.Drawing.Image)(resources.GetObject("PoisonBtn.Image")));
			this.PoisonBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.PoisonBtn.Name = "PoisonBtn";
			this.PoisonBtn.Size = new System.Drawing.Size(60, 19);
			this.PoisonBtn.Text = Session.I18N.Poison;
			this.PoisonBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.PoisonBtn.Click += new System.EventHandler(this.PoisonBtn_Click);
			// 
			// PsychicBtn
			// 
			this.PsychicBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.PsychicBtn.Image = ((System.Drawing.Image)(resources.GetObject("PsychicBtn.Image")));
			this.PsychicBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.PsychicBtn.Name = "PsychicBtn";
			this.PsychicBtn.Size = new System.Drawing.Size(60, 19);
			this.PsychicBtn.Text = "Psychic";
			this.PsychicBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.PsychicBtn.Click += new System.EventHandler(this.PsychicBtn_Click);
			// 
			// RadiantBtn
			// 
			this.RadiantBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.RadiantBtn.Image = ((System.Drawing.Image)(resources.GetObject("RadiantBtn.Image")));
			this.RadiantBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RadiantBtn.Name = "RadiantBtn";
			this.RadiantBtn.Size = new System.Drawing.Size(60, 19);
			this.RadiantBtn.Text = "Radiant";
			this.RadiantBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.RadiantBtn.Click += new System.EventHandler(this.RadiantBtn_Click);
			// 
			// ThunderBtn
			// 
			this.ThunderBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ThunderBtn.Image = ((System.Drawing.Image)(resources.GetObject("ThunderBtn.Image")));
			this.ThunderBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ThunderBtn.Name = "ThunderBtn";
			this.ThunderBtn.Size = new System.Drawing.Size(60, 19);
			this.ThunderBtn.Text = "Thunder";
			this.ThunderBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ThunderBtn.Click += new System.EventHandler(this.ThunderBtn_Click);
			// 
			// TypeBox
			// 
			this.TypeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TypeBox.Location = new System.Drawing.Point(134, 54);
			this.TypeBox.Name = "TypeBox";
			this.TypeBox.ReadOnly = true;
			this.TypeBox.Size = new System.Drawing.Size(194, 20);
			this.TypeBox.TabIndex = 5;
			// 
			// DamageForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(340, 225);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.TypeBox);
			this.Controls.Add(this.DmgBox);
			this.Controls.Add(this.DmgLbl);
			this.Controls.Add(this.ModLbl);
			this.Controls.Add(this.AmountToolbar);
			this.Controls.Add(this.TypeToolbar);
			this.Controls.Add(this.HalveBtn);
			this.Controls.Add(this.TypeLbl);
			this.Controls.Add(this.ModBox);
			this.Controls.Add(this.ValLbl);
			this.Controls.Add(this.ValBox);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DamageForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Damage";
			this.Shown += new System.EventHandler(this.DamageForm_Shown);
			((System.ComponentModel.ISupportInitialize)(this.DmgBox)).EndInit();
			this.AmountToolbar.ResumeLayout(false);
			this.AmountToolbar.PerformLayout();
			this.TypeToolbar.ResumeLayout(false);
			this.TypeToolbar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label DmgLbl;
		private System.Windows.Forms.NumericUpDown DmgBox;
		private System.Windows.Forms.Label ModLbl;
		private System.Windows.Forms.TextBox ModBox;
		private System.Windows.Forms.Label ValLbl;
		private System.Windows.Forms.CheckBox HalveBtn;
		private System.Windows.Forms.Label TypeLbl;
		private System.Windows.Forms.TextBox ValBox;
		private System.Windows.Forms.ToolStrip AmountToolbar;
		private System.Windows.Forms.ToolStripButton Dmg1;
		private System.Windows.Forms.ToolStripButton Dmg2;
		private System.Windows.Forms.ToolStripButton Dmg5;
		private System.Windows.Forms.ToolStripButton Dmg10;
		private System.Windows.Forms.ToolStripButton Dmg20;
		private System.Windows.Forms.ToolStripButton Dmg50;
		private System.Windows.Forms.ToolStripButton Dmg100;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton ResetBtn;
		private System.Windows.Forms.ToolStrip TypeToolbar;
		private System.Windows.Forms.ToolStripButton FireBtn;
		private System.Windows.Forms.ToolStripButton ColdBtn;
		private System.Windows.Forms.ToolStripButton LightningBtn;
		private System.Windows.Forms.ToolStripButton ThunderBtn;
		private System.Windows.Forms.ToolStripButton PsychicBtn;
		private System.Windows.Forms.ToolStripButton ForceBtn;
		private System.Windows.Forms.ToolStripButton AcidBtn;
		private System.Windows.Forms.ToolStripButton PoisonBtn;
		private System.Windows.Forms.ToolStripButton NecroticBtn;
		private System.Windows.Forms.ToolStripButton RadiantBtn;
		private System.Windows.Forms.TextBox TypeBox;
	}
}