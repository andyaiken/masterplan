namespace Masterplan.UI
{
	partial class CampaignSettingsForm
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
            this.OKBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.HPLbl = new System.Windows.Forms.Label();
            this.HPBox = new System.Windows.Forms.NumericUpDown();
            this.AttackBox = new System.Windows.Forms.NumericUpDown();
            this.AttackLbl = new System.Windows.Forms.Label();
            this.ACBox = new System.Windows.Forms.NumericUpDown();
            this.ACLbl = new System.Windows.Forms.Label();
            this.InfoLbl = new System.Windows.Forms.Label();
            this.DefenceBox = new System.Windows.Forms.NumericUpDown();
            this.DefenceLbl = new System.Windows.Forms.Label();
            this.XPBox = new System.Windows.Forms.NumericUpDown();
            this.XPLbl = new System.Windows.Forms.Label();
            this.DamageBox = new System.Windows.Forms.NumericUpDown();
            this.dmgMultLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.HPBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttackBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ACBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefenceBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XPBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DamageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // OKBtn
            // 
            this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.Location = new System.Drawing.Point(110, 256);
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
            this.CancelBtn.Location = new System.Drawing.Point(191, 256);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 12;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // HPLbl
            // 
            this.HPLbl.AutoSize = true;
            this.HPLbl.Location = new System.Drawing.Point(12, 55);
            this.HPLbl.Name = "HPLbl";
            this.HPLbl.Size = new System.Drawing.Size(72, 13);
            this.HPLbl.TabIndex = 1;
            this.HPLbl.Text = "Hit Points (%):";
            // 
            // HPBox
            // 
            this.HPBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HPBox.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.HPBox.Location = new System.Drawing.Point(130, 53);
            this.HPBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.HPBox.Name = "HPBox";
            this.HPBox.Size = new System.Drawing.Size(136, 20);
            this.HPBox.TabIndex = 2;
            // 
            // AttackBox
            // 
            this.AttackBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AttackBox.Location = new System.Drawing.Point(130, 121);
            this.AttackBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.AttackBox.Name = "AttackBox";
            this.AttackBox.Size = new System.Drawing.Size(136, 20);
            this.AttackBox.TabIndex = 6;
            // 
            // AttackLbl
            // 
            this.AttackLbl.AutoSize = true;
            this.AttackLbl.Location = new System.Drawing.Point(12, 123);
            this.AttackLbl.Name = "AttackLbl";
            this.AttackLbl.Size = new System.Drawing.Size(74, 13);
            this.AttackLbl.TabIndex = 5;
            this.AttackLbl.Text = "Attack Bonus:";
            // 
            // ACBox
            // 
            this.ACBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ACBox.Location = new System.Drawing.Point(130, 183);
            this.ACBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.ACBox.Name = "ACBox";
            this.ACBox.Size = new System.Drawing.Size(136, 20);
            this.ACBox.TabIndex = 8;
            // 
            // ACLbl
            // 
            this.ACLbl.AutoSize = true;
            this.ACLbl.Location = new System.Drawing.Point(12, 185);
            this.ACLbl.Name = "ACLbl";
            this.ACLbl.Size = new System.Drawing.Size(24, 13);
            this.ACLbl.TabIndex = 7;
            this.ACLbl.Text = "AC:";
            // 
            // InfoLbl
            // 
            this.InfoLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InfoLbl.Location = new System.Drawing.Point(12, 9);
            this.InfoLbl.Name = "InfoLbl";
            this.InfoLbl.Size = new System.Drawing.Size(254, 33);
            this.InfoLbl.TabIndex = 0;
            this.InfoLbl.Text = "These settings will apply to all the creatures, traps and hazards in the campaign" +
    ".";
            // 
            // DefenceBox
            // 
            this.DefenceBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DefenceBox.Location = new System.Drawing.Point(130, 209);
            this.DefenceBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.DefenceBox.Name = "DefenceBox";
            this.DefenceBox.Size = new System.Drawing.Size(136, 20);
            this.DefenceBox.TabIndex = 10;
            // 
            // DefenceLbl
            // 
            this.DefenceLbl.AutoSize = true;
            this.DefenceLbl.Location = new System.Drawing.Point(12, 211);
            this.DefenceLbl.Name = "DefenceLbl";
            this.DefenceLbl.Size = new System.Drawing.Size(85, 13);
            this.DefenceLbl.TabIndex = 9;
            this.DefenceLbl.Text = "Other Defences:";
            // 
            // XPBox
            // 
            this.XPBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.XPBox.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.XPBox.Location = new System.Drawing.Point(130, 79);
            this.XPBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.XPBox.Name = "XPBox";
            this.XPBox.Size = new System.Drawing.Size(136, 20);
            this.XPBox.TabIndex = 4;
            // 
            // XPLbl
            // 
            this.XPLbl.AutoSize = true;
            this.XPLbl.Location = new System.Drawing.Point(12, 81);
            this.XPLbl.Name = "XPLbl";
            this.XPLbl.Size = new System.Drawing.Size(112, 13);
            this.XPLbl.TabIndex = 3;
            this.XPLbl.Text = "Experience Points (%):";
            // 
            // DamageBox
            // 
            this.DamageBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DamageBox.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.DamageBox.Location = new System.Drawing.Point(130, 150);
            this.DamageBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.DamageBox.Name = "DamageBox";
            this.DamageBox.Size = new System.Drawing.Size(136, 20);
            this.DamageBox.TabIndex = 14;
            // 
            // dmgMultLbl
            // 
            this.dmgMultLbl.AutoSize = true;
            this.dmgMultLbl.Location = new System.Drawing.Point(12, 152);
            this.dmgMultLbl.Name = "dmgMultLbl";
            this.dmgMultLbl.Size = new System.Drawing.Size(111, 13);
            this.dmgMultLbl.TabIndex = 13;
            this.dmgMultLbl.Text = "Damage Multiplier (%):";
            // 
            // CampaignSettingsForm
            // 
            this.AcceptButton = this.OKBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(278, 291);
            this.Controls.Add(this.DamageBox);
            this.Controls.Add(this.dmgMultLbl);
            this.Controls.Add(this.XPBox);
            this.Controls.Add(this.XPLbl);
            this.Controls.Add(this.DefenceBox);
            this.Controls.Add(this.DefenceLbl);
            this.Controls.Add(this.InfoLbl);
            this.Controls.Add(this.ACBox);
            this.Controls.Add(this.ACLbl);
            this.Controls.Add(this.AttackBox);
            this.Controls.Add(this.AttackLbl);
            this.Controls.Add(this.HPBox);
            this.Controls.Add(this.HPLbl);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CampaignSettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Campaign Settings";
            ((System.ComponentModel.ISupportInitialize)(this.HPBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttackBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ACBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefenceBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XPBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DamageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label HPLbl;
		private System.Windows.Forms.NumericUpDown HPBox;
		private System.Windows.Forms.NumericUpDown AttackBox;
		private System.Windows.Forms.Label AttackLbl;
		private System.Windows.Forms.NumericUpDown ACBox;
		private System.Windows.Forms.Label ACLbl;
		private System.Windows.Forms.Label InfoLbl;
		private System.Windows.Forms.NumericUpDown DefenceBox;
		private System.Windows.Forms.Label DefenceLbl;
		private System.Windows.Forms.NumericUpDown XPBox;
		private System.Windows.Forms.Label XPLbl;
        private System.Windows.Forms.NumericUpDown DamageBox;
        private System.Windows.Forms.Label dmgMultLbl;
    }
}