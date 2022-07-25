namespace Masterplan.UI
{
    partial class TerrainPowerForm
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
			this.NameLbl = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.TypeLbl = new System.Windows.Forms.Label();
			this.TypeBox = new System.Windows.Forms.ComboBox();
			this.ActionLbl = new System.Windows.Forms.Label();
			this.ActionBox = new System.Windows.Forms.ComboBox();
			this.Pages = new System.Windows.Forms.TabControl();
			this.GeneralPage = new System.Windows.Forms.TabPage();
			this.RequirementBox = new System.Windows.Forms.TextBox();
			this.RequirementLbl = new System.Windows.Forms.Label();
			this.FlavourBox = new System.Windows.Forms.TextBox();
			this.FlavourLbl = new System.Windows.Forms.Label();
			this.CheckPage = new System.Windows.Forms.TabPage();
			this.SuccessBox = new System.Windows.Forms.TextBox();
			this.SuccessLbl = new System.Windows.Forms.Label();
			this.FailureBox = new System.Windows.Forms.TextBox();
			this.FailureLbl = new System.Windows.Forms.Label();
			this.CheckBox = new System.Windows.Forms.TextBox();
			this.CheckLbl = new System.Windows.Forms.Label();
			this.AttackPage = new System.Windows.Forms.TabPage();
			this.TargetBox = new System.Windows.Forms.TextBox();
			this.TargetLbl = new System.Windows.Forms.Label();
			this.HitBox = new System.Windows.Forms.TextBox();
			this.HitLbl = new System.Windows.Forms.Label();
			this.MissBox = new System.Windows.Forms.TextBox();
			this.MissLbl = new System.Windows.Forms.Label();
			this.EffectBox = new System.Windows.Forms.TextBox();
			this.EffectLbl = new System.Windows.Forms.Label();
			this.AttackBox = new System.Windows.Forms.TextBox();
			this.AttackLbl = new System.Windows.Forms.Label();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.Pages.SuspendLayout();
			this.GeneralPage.SuspendLayout();
			this.CheckPage.SuspendLayout();
			this.AttackPage.SuspendLayout();
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
			this.NameBox.Location = new System.Drawing.Point(58, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(276, 20);
			this.NameBox.TabIndex = 1;
			// 
			// TypeLbl
			// 
			this.TypeLbl.AutoSize = true;
			this.TypeLbl.Location = new System.Drawing.Point(12, 41);
			this.TypeLbl.Name = "TypeLbl";
			this.TypeLbl.Size = new System.Drawing.Size(34, 13);
			this.TypeLbl.TabIndex = 2;
			this.TypeLbl.Text = "Type:";
			// 
			// TypeBox
			// 
			this.TypeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TypeBox.FormattingEnabled = true;
			this.TypeBox.Location = new System.Drawing.Point(58, 38);
			this.TypeBox.Name = "TypeBox";
			this.TypeBox.Size = new System.Drawing.Size(276, 21);
			this.TypeBox.TabIndex = 3;
			// 
			// ActionLbl
			// 
			this.ActionLbl.AutoSize = true;
			this.ActionLbl.Location = new System.Drawing.Point(12, 68);
			this.ActionLbl.Name = "ActionLbl";
			this.ActionLbl.Size = new System.Drawing.Size(40, 13);
			this.ActionLbl.TabIndex = 4;
			this.ActionLbl.Text = "Action:";
			// 
			// ActionBox
			// 
			this.ActionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ActionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ActionBox.FormattingEnabled = true;
			this.ActionBox.Location = new System.Drawing.Point(58, 65);
			this.ActionBox.Name = "ActionBox";
			this.ActionBox.Size = new System.Drawing.Size(276, 21);
			this.ActionBox.TabIndex = 5;
			// 
			// Pages
			// 
			this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Pages.Controls.Add(this.GeneralPage);
			this.Pages.Controls.Add(this.CheckPage);
			this.Pages.Controls.Add(this.AttackPage);
			this.Pages.Location = new System.Drawing.Point(12, 92);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(322, 275);
			this.Pages.TabIndex = 6;
			// 
			// GeneralPage
			// 
			this.GeneralPage.Controls.Add(this.RequirementBox);
			this.GeneralPage.Controls.Add(this.RequirementLbl);
			this.GeneralPage.Controls.Add(this.FlavourBox);
			this.GeneralPage.Controls.Add(this.FlavourLbl);
			this.GeneralPage.Location = new System.Drawing.Point(4, 22);
			this.GeneralPage.Name = "GeneralPage";
			this.GeneralPage.Padding = new System.Windows.Forms.Padding(3);
			this.GeneralPage.Size = new System.Drawing.Size(314, 249);
			this.GeneralPage.TabIndex = 0;
			this.GeneralPage.Text = "General";
			this.GeneralPage.UseVisualStyleBackColor = true;
			// 
			// RequirementBox
			// 
			this.RequirementBox.AcceptsReturn = true;
			this.RequirementBox.AcceptsTab = true;
			this.RequirementBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.RequirementBox.Location = new System.Drawing.Point(81, 151);
			this.RequirementBox.Multiline = true;
			this.RequirementBox.Name = "RequirementBox";
			this.RequirementBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.RequirementBox.Size = new System.Drawing.Size(227, 92);
			this.RequirementBox.TabIndex = 3;
			// 
			// RequirementLbl
			// 
			this.RequirementLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.RequirementLbl.AutoSize = true;
			this.RequirementLbl.Location = new System.Drawing.Point(6, 154);
			this.RequirementLbl.Name = "RequirementLbl";
			this.RequirementLbl.Size = new System.Drawing.Size(70, 13);
			this.RequirementLbl.TabIndex = 2;
			this.RequirementLbl.Text = "Requirement:";
			// 
			// FlavourBox
			// 
			this.FlavourBox.AcceptsReturn = true;
			this.FlavourBox.AcceptsTab = true;
			this.FlavourBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.FlavourBox.Location = new System.Drawing.Point(81, 6);
			this.FlavourBox.Multiline = true;
			this.FlavourBox.Name = "FlavourBox";
			this.FlavourBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.FlavourBox.Size = new System.Drawing.Size(227, 139);
			this.FlavourBox.TabIndex = 1;
			// 
			// FlavourLbl
			// 
			this.FlavourLbl.AutoSize = true;
			this.FlavourLbl.Location = new System.Drawing.Point(6, 9);
			this.FlavourLbl.Name = "FlavourLbl";
			this.FlavourLbl.Size = new System.Drawing.Size(69, 13);
			this.FlavourLbl.TabIndex = 0;
			this.FlavourLbl.Text = "Flavour Text:";
			// 
			// CheckPage
			// 
			this.CheckPage.Controls.Add(this.SuccessBox);
			this.CheckPage.Controls.Add(this.SuccessLbl);
			this.CheckPage.Controls.Add(this.FailureBox);
			this.CheckPage.Controls.Add(this.FailureLbl);
			this.CheckPage.Controls.Add(this.CheckBox);
			this.CheckPage.Controls.Add(this.CheckLbl);
			this.CheckPage.Location = new System.Drawing.Point(4, 22);
			this.CheckPage.Name = "CheckPage";
			this.CheckPage.Padding = new System.Windows.Forms.Padding(3);
			this.CheckPage.Size = new System.Drawing.Size(314, 249);
			this.CheckPage.TabIndex = 2;
			this.CheckPage.Text = "Check";
			this.CheckPage.UseVisualStyleBackColor = true;
			// 
			// SuccessBox
			// 
			this.SuccessBox.AcceptsReturn = true;
			this.SuccessBox.AcceptsTab = true;
			this.SuccessBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.SuccessBox.Location = new System.Drawing.Point(62, 99);
			this.SuccessBox.Multiline = true;
			this.SuccessBox.Name = "SuccessBox";
			this.SuccessBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.SuccessBox.Size = new System.Drawing.Size(246, 69);
			this.SuccessBox.TabIndex = 3;
			// 
			// SuccessLbl
			// 
			this.SuccessLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.SuccessLbl.AutoSize = true;
			this.SuccessLbl.Location = new System.Drawing.Point(5, 99);
			this.SuccessLbl.Name = "SuccessLbl";
			this.SuccessLbl.Size = new System.Drawing.Size(51, 13);
			this.SuccessLbl.TabIndex = 2;
			this.SuccessLbl.Text = "Success:";
			// 
			// FailureBox
			// 
			this.FailureBox.AcceptsReturn = true;
			this.FailureBox.AcceptsTab = true;
			this.FailureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.FailureBox.Location = new System.Drawing.Point(62, 174);
			this.FailureBox.Multiline = true;
			this.FailureBox.Name = "FailureBox";
			this.FailureBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.FailureBox.Size = new System.Drawing.Size(246, 69);
			this.FailureBox.TabIndex = 5;
			// 
			// FailureLbl
			// 
			this.FailureLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.FailureLbl.AutoSize = true;
			this.FailureLbl.Location = new System.Drawing.Point(5, 174);
			this.FailureLbl.Name = "FailureLbl";
			this.FailureLbl.Size = new System.Drawing.Size(41, 13);
			this.FailureLbl.TabIndex = 4;
			this.FailureLbl.Text = "Failure:";
			// 
			// CheckBox
			// 
			this.CheckBox.AcceptsReturn = true;
			this.CheckBox.AcceptsTab = true;
			this.CheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.CheckBox.Location = new System.Drawing.Point(62, 6);
			this.CheckBox.Multiline = true;
			this.CheckBox.Name = "CheckBox";
			this.CheckBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.CheckBox.Size = new System.Drawing.Size(246, 87);
			this.CheckBox.TabIndex = 1;
			// 
			// CheckLbl
			// 
			this.CheckLbl.AutoSize = true;
			this.CheckLbl.Location = new System.Drawing.Point(6, 9);
			this.CheckLbl.Name = "CheckLbl";
			this.CheckLbl.Size = new System.Drawing.Size(41, 13);
			this.CheckLbl.TabIndex = 0;
			this.CheckLbl.Text = "Check:";
			// 
			// AttackPage
			// 
			this.AttackPage.Controls.Add(this.TargetBox);
			this.AttackPage.Controls.Add(this.TargetLbl);
			this.AttackPage.Controls.Add(this.HitBox);
			this.AttackPage.Controls.Add(this.HitLbl);
			this.AttackPage.Controls.Add(this.MissBox);
			this.AttackPage.Controls.Add(this.MissLbl);
			this.AttackPage.Controls.Add(this.EffectBox);
			this.AttackPage.Controls.Add(this.EffectLbl);
			this.AttackPage.Controls.Add(this.AttackBox);
			this.AttackPage.Controls.Add(this.AttackLbl);
			this.AttackPage.Location = new System.Drawing.Point(4, 22);
			this.AttackPage.Name = "AttackPage";
			this.AttackPage.Padding = new System.Windows.Forms.Padding(3);
			this.AttackPage.Size = new System.Drawing.Size(314, 249);
			this.AttackPage.TabIndex = 3;
			this.AttackPage.Text = Session.I18N.Attack;
			this.AttackPage.UseVisualStyleBackColor = true;
			// 
			// TargetBox
			// 
			this.TargetBox.AcceptsReturn = true;
			this.TargetBox.AcceptsTab = true;
			this.TargetBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TargetBox.Location = new System.Drawing.Point(61, 57);
			this.TargetBox.Multiline = true;
			this.TargetBox.Name = "TargetBox";
			this.TargetBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TargetBox.Size = new System.Drawing.Size(248, 42);
			this.TargetBox.TabIndex = 3;
			// 
			// TargetLbl
			// 
			this.TargetLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.TargetLbl.AutoSize = true;
			this.TargetLbl.Location = new System.Drawing.Point(7, 60);
			this.TargetLbl.Name = "TargetLbl";
			this.TargetLbl.Size = new System.Drawing.Size(41, 13);
			this.TargetLbl.TabIndex = 2;
			this.TargetLbl.Text = "Target:";
			// 
			// HitBox
			// 
			this.HitBox.AcceptsReturn = true;
			this.HitBox.AcceptsTab = true;
			this.HitBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.HitBox.Location = new System.Drawing.Point(60, 105);
			this.HitBox.Multiline = true;
			this.HitBox.Name = "HitBox";
			this.HitBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.HitBox.Size = new System.Drawing.Size(248, 42);
			this.HitBox.TabIndex = 5;
			// 
			// HitLbl
			// 
			this.HitLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.HitLbl.AutoSize = true;
			this.HitLbl.Location = new System.Drawing.Point(6, 108);
			this.HitLbl.Name = "HitLbl";
			this.HitLbl.Size = new System.Drawing.Size(40, 13);
			this.HitLbl.TabIndex = 4;
			this.HitLbl.Text = "On Hit:";
			// 
			// MissBox
			// 
			this.MissBox.AcceptsReturn = true;
			this.MissBox.AcceptsTab = true;
			this.MissBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.MissBox.Location = new System.Drawing.Point(60, 153);
			this.MissBox.Multiline = true;
			this.MissBox.Name = "MissBox";
			this.MissBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.MissBox.Size = new System.Drawing.Size(248, 42);
			this.MissBox.TabIndex = 7;
			// 
			// MissLbl
			// 
			this.MissLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.MissLbl.AutoSize = true;
			this.MissLbl.Location = new System.Drawing.Point(6, 156);
			this.MissLbl.Name = "MissLbl";
			this.MissLbl.Size = new System.Drawing.Size(48, 13);
			this.MissLbl.TabIndex = 6;
			this.MissLbl.Text = "On Miss:";
			// 
			// EffectBox
			// 
			this.EffectBox.AcceptsReturn = true;
			this.EffectBox.AcceptsTab = true;
			this.EffectBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.EffectBox.Location = new System.Drawing.Point(61, 201);
			this.EffectBox.Multiline = true;
			this.EffectBox.Name = "EffectBox";
			this.EffectBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.EffectBox.Size = new System.Drawing.Size(248, 42);
			this.EffectBox.TabIndex = 9;
			// 
			// EffectLbl
			// 
			this.EffectLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.EffectLbl.AutoSize = true;
			this.EffectLbl.Location = new System.Drawing.Point(6, 204);
			this.EffectLbl.Name = "EffectLbl";
			this.EffectLbl.Size = new System.Drawing.Size(38, 13);
			this.EffectLbl.TabIndex = 8;
			this.EffectLbl.Text = "Effect:";
			// 
			// AttackBox
			// 
			this.AttackBox.AcceptsReturn = true;
			this.AttackBox.AcceptsTab = true;
			this.AttackBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.AttackBox.Location = new System.Drawing.Point(61, 6);
			this.AttackBox.Multiline = true;
			this.AttackBox.Name = "AttackBox";
			this.AttackBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.AttackBox.Size = new System.Drawing.Size(248, 45);
			this.AttackBox.TabIndex = 1;
			// 
			// AttackLbl
			// 
			this.AttackLbl.AutoSize = true;
			this.AttackLbl.Location = new System.Drawing.Point(7, 9);
			this.AttackLbl.Name = "AttackLbl";
			this.AttackLbl.Size = new System.Drawing.Size(41, 13);
			this.AttackLbl.TabIndex = 0;
			this.AttackLbl.Text = "Attack:";
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(178, 373);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 7;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(259, 373);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 8;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// TerrainPowerForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(346, 408);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.Pages);
			this.Controls.Add(this.ActionBox);
			this.Controls.Add(this.ActionLbl);
			this.Controls.Add(this.TypeBox);
			this.Controls.Add(this.TypeLbl);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLbl);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TerrainPowerForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Terrain Power";
			this.Pages.ResumeLayout(false);
			this.GeneralPage.ResumeLayout(false);
			this.GeneralPage.PerformLayout();
			this.CheckPage.ResumeLayout(false);
			this.CheckPage.PerformLayout();
			this.AttackPage.ResumeLayout(false);
			this.AttackPage.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label TypeLbl;
        private System.Windows.Forms.ComboBox TypeBox;
        private System.Windows.Forms.Label ActionLbl;
        private System.Windows.Forms.ComboBox ActionBox;
        private System.Windows.Forms.TabControl Pages;
        private System.Windows.Forms.TabPage GeneralPage;
        private System.Windows.Forms.TabPage CheckPage;
        private System.Windows.Forms.TabPage AttackPage;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.TextBox RequirementBox;
        private System.Windows.Forms.Label RequirementLbl;
        private System.Windows.Forms.TextBox FlavourBox;
        private System.Windows.Forms.Label FlavourLbl;
        private System.Windows.Forms.TextBox SuccessBox;
        private System.Windows.Forms.Label SuccessLbl;
        private System.Windows.Forms.TextBox FailureBox;
        private System.Windows.Forms.Label FailureLbl;
        private System.Windows.Forms.TextBox CheckBox;
        private System.Windows.Forms.Label CheckLbl;
        private System.Windows.Forms.TextBox TargetBox;
        private System.Windows.Forms.Label TargetLbl;
        private System.Windows.Forms.TextBox HitBox;
        private System.Windows.Forms.Label HitLbl;
        private System.Windows.Forms.TextBox MissBox;
        private System.Windows.Forms.Label MissLbl;
        private System.Windows.Forms.TextBox EffectBox;
        private System.Windows.Forms.Label EffectLbl;
        private System.Windows.Forms.TextBox AttackBox;
        private System.Windows.Forms.Label AttackLbl;
    }
}