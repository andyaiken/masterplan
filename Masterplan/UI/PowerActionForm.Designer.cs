namespace Masterplan.UI
{
	partial class PowerActionForm
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
			this.CancelBtn = new System.Windows.Forms.Button();
			this.OKBtn = new System.Windows.Forms.Button();
			this.ActionLbl = new System.Windows.Forms.Label();
			this.ActionBox = new System.Windows.Forms.ComboBox();
			this.RechargeLbl = new System.Windows.Forms.Label();
			this.RechargeBox = new System.Windows.Forms.ComboBox();
			this.TriggerBox = new System.Windows.Forms.TextBox();
			this.TriggerLbl = new System.Windows.Forms.Label();
			this.SustainBox = new System.Windows.Forms.ComboBox();
			this.SustainLbl = new System.Windows.Forms.Label();
			this.TraitBox = new System.Windows.Forms.CheckBox();
			this.UsageGroup = new System.Windows.Forms.GroupBox();
			this.BasicAttackBtn = new System.Windows.Forms.CheckBox();
			this.DailyBtn = new System.Windows.Forms.RadioButton();
			this.EncounterBtn = new System.Windows.Forms.RadioButton();
			this.AtWillBtn = new System.Windows.Forms.RadioButton();
			this.UsageGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(218, 288);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 9;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(137, 288);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 8;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// ActionLbl
			// 
			this.ActionLbl.AutoSize = true;
			this.ActionLbl.Location = new System.Drawing.Point(12, 199);
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
			this.ActionBox.Location = new System.Drawing.Point(75, 196);
			this.ActionBox.Name = "ActionBox";
			this.ActionBox.Size = new System.Drawing.Size(218, 21);
			this.ActionBox.TabIndex = 3;
			// 
			// RechargeLbl
			// 
			this.RechargeLbl.AutoSize = true;
			this.RechargeLbl.Location = new System.Drawing.Point(22, 96);
			this.RechargeLbl.Name = "RechargeLbl";
			this.RechargeLbl.Size = new System.Drawing.Size(57, 13);
			this.RechargeLbl.TabIndex = 3;
			this.RechargeLbl.Text = "Recharge:";
			// 
			// RechargeBox
			// 
			this.RechargeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.RechargeBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.RechargeBox.FormattingEnabled = true;
			this.RechargeBox.Location = new System.Drawing.Point(85, 93);
			this.RechargeBox.Name = "RechargeBox";
			this.RechargeBox.Size = new System.Drawing.Size(190, 21);
			this.RechargeBox.TabIndex = 4;
			// 
			// TriggerBox
			// 
			this.TriggerBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TriggerBox.Location = new System.Drawing.Point(75, 223);
			this.TriggerBox.Name = "TriggerBox";
			this.TriggerBox.Size = new System.Drawing.Size(218, 20);
			this.TriggerBox.TabIndex = 5;
			// 
			// TriggerLbl
			// 
			this.TriggerLbl.AutoSize = true;
			this.TriggerLbl.Location = new System.Drawing.Point(12, 226);
			this.TriggerLbl.Name = "TriggerLbl";
			this.TriggerLbl.Size = new System.Drawing.Size(43, 13);
			this.TriggerLbl.TabIndex = 4;
			this.TriggerLbl.Text = "Trigger:";
			// 
			// SustainBox
			// 
			this.SustainBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.SustainBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.SustainBox.FormattingEnabled = true;
			this.SustainBox.Location = new System.Drawing.Point(75, 249);
			this.SustainBox.Name = "SustainBox";
			this.SustainBox.Size = new System.Drawing.Size(218, 21);
			this.SustainBox.TabIndex = 7;
			// 
			// SustainLbl
			// 
			this.SustainLbl.AutoSize = true;
			this.SustainLbl.Location = new System.Drawing.Point(12, 252);
			this.SustainLbl.Name = "SustainLbl";
			this.SustainLbl.Size = new System.Drawing.Size(45, 13);
			this.SustainLbl.TabIndex = 6;
			this.SustainLbl.Text = "Sustain:";
			// 
			// TraitBox
			// 
			this.TraitBox.AutoSize = true;
			this.TraitBox.Location = new System.Drawing.Point(12, 12);
			this.TraitBox.Name = "TraitBox";
			this.TraitBox.Size = new System.Drawing.Size(117, 17);
			this.TraitBox.TabIndex = 0;
			this.TraitBox.Text = "This power is a trait";
			this.TraitBox.UseVisualStyleBackColor = true;
			// 
			// UsageGroup
			// 
			this.UsageGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.UsageGroup.Controls.Add(this.BasicAttackBtn);
			this.UsageGroup.Controls.Add(this.DailyBtn);
			this.UsageGroup.Controls.Add(this.EncounterBtn);
			this.UsageGroup.Controls.Add(this.AtWillBtn);
			this.UsageGroup.Controls.Add(this.RechargeBox);
			this.UsageGroup.Controls.Add(this.RechargeLbl);
			this.UsageGroup.Location = new System.Drawing.Point(12, 35);
			this.UsageGroup.Name = "UsageGroup";
			this.UsageGroup.Size = new System.Drawing.Size(281, 155);
			this.UsageGroup.TabIndex = 1;
			this.UsageGroup.TabStop = false;
			this.UsageGroup.Text = "Power Usage";
			// 
			// BasicAttackBtn
			// 
			this.BasicAttackBtn.AutoSize = true;
			this.BasicAttackBtn.Location = new System.Drawing.Point(25, 43);
			this.BasicAttackBtn.Name = "BasicAttackBtn";
			this.BasicAttackBtn.Size = new System.Drawing.Size(86, 17);
			this.BasicAttackBtn.TabIndex = 1;
			this.BasicAttackBtn.Text = "Basic Attack";
			this.BasicAttackBtn.UseVisualStyleBackColor = true;
			// 
			// DailyBtn
			// 
			this.DailyBtn.AutoSize = true;
			this.DailyBtn.Location = new System.Drawing.Point(6, 125);
			this.DailyBtn.Name = "DailyBtn";
			this.DailyBtn.Size = new System.Drawing.Size(48, 17);
			this.DailyBtn.TabIndex = 5;
			this.DailyBtn.TabStop = true;
			this.DailyBtn.Text = "Daily";
			this.DailyBtn.UseVisualStyleBackColor = true;
			// 
			// EncounterBtn
			// 
			this.EncounterBtn.AutoSize = true;
			this.EncounterBtn.Location = new System.Drawing.Point(6, 70);
			this.EncounterBtn.Name = "EncounterBtn";
			this.EncounterBtn.Size = new System.Drawing.Size(74, 17);
			this.EncounterBtn.TabIndex = 2;
			this.EncounterBtn.TabStop = true;
			this.EncounterBtn.Text = "Encounter";
			this.EncounterBtn.UseVisualStyleBackColor = true;
			// 
			// AtWillBtn
			// 
			this.AtWillBtn.AutoSize = true;
			this.AtWillBtn.Location = new System.Drawing.Point(6, 19);
			this.AtWillBtn.Name = "AtWillBtn";
			this.AtWillBtn.Size = new System.Drawing.Size(55, 17);
			this.AtWillBtn.TabIndex = 0;
			this.AtWillBtn.TabStop = true;
			this.AtWillBtn.Text = "At Will";
			this.AtWillBtn.UseVisualStyleBackColor = true;
			// 
			// PowerActionForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(305, 323);
			this.Controls.Add(this.UsageGroup);
			this.Controls.Add(this.TraitBox);
			this.Controls.Add(this.SustainBox);
			this.Controls.Add(this.SustainLbl);
			this.Controls.Add(this.TriggerBox);
			this.Controls.Add(this.TriggerLbl);
			this.Controls.Add(this.ActionBox);
			this.Controls.Add(this.ActionLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PowerActionForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Power Action";
			this.UsageGroup.ResumeLayout(false);
			this.UsageGroup.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Label ActionLbl;
		private System.Windows.Forms.ComboBox ActionBox;
		private System.Windows.Forms.Label RechargeLbl;
		private System.Windows.Forms.ComboBox RechargeBox;
		private System.Windows.Forms.TextBox TriggerBox;
		private System.Windows.Forms.Label TriggerLbl;
		private System.Windows.Forms.ComboBox SustainBox;
		private System.Windows.Forms.Label SustainLbl;
		private System.Windows.Forms.CheckBox TraitBox;
		private System.Windows.Forms.GroupBox UsageGroup;
		private System.Windows.Forms.CheckBox BasicAttackBtn;
		private System.Windows.Forms.RadioButton DailyBtn;
		private System.Windows.Forms.RadioButton EncounterBtn;
		private System.Windows.Forms.RadioButton AtWillBtn;
	}
}