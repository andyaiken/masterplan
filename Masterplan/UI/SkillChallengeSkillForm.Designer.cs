namespace Masterplan.UI
{
	partial class SkillChallengeSkillForm
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
			this.SkillLblLbl = new System.Windows.Forms.Label();
			this.DiffLbl = new System.Windows.Forms.Label();
			this.DetailsBox = new System.Windows.Forms.TextBox();
			this.SkillBox = new System.Windows.Forms.ComboBox();
			this.Pages = new System.Windows.Forms.TabControl();
			this.DetailsPage = new System.Windows.Forms.TabPage();
			this.SuccessPage = new System.Windows.Forms.TabPage();
			this.SuccessBox = new System.Windows.Forms.TextBox();
			this.FailurePage = new System.Windows.Forms.TabPage();
			this.FailureBox = new System.Windows.Forms.TextBox();
			this.TypeLbl = new System.Windows.Forms.Label();
			this.TypeBox = new System.Windows.Forms.ComboBox();
			this.DiffBox = new System.Windows.Forms.ComboBox();
			this.ModLbl = new System.Windows.Forms.Label();
			this.ModBox = new System.Windows.Forms.NumericUpDown();
			this.ProgressPage = new System.Windows.Forms.TabPage();
			this.SuccessLbl = new System.Windows.Forms.Label();
			this.FailureLbl = new System.Windows.Forms.Label();
			this.SuccessCountBox = new System.Windows.Forms.NumericUpDown();
			this.FailureCountBox = new System.Windows.Forms.NumericUpDown();
			this.Pages.SuspendLayout();
			this.DetailsPage.SuspendLayout();
			this.SuccessPage.SuspendLayout();
			this.FailurePage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ModBox)).BeginInit();
			this.ProgressPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SuccessCountBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.FailureCountBox)).BeginInit();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(146, 317);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 9;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(227, 317);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 10;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// SkillLblLbl
			// 
			this.SkillLblLbl.AutoSize = true;
			this.SkillLblLbl.Location = new System.Drawing.Point(12, 15);
			this.SkillLblLbl.Name = "SkillLblLbl";
			this.SkillLblLbl.Size = new System.Drawing.Size(29, 13);
			this.SkillLblLbl.TabIndex = 0;
			this.SkillLblLbl.Text = "Skill:";
			// 
			// DiffLbl
			// 
			this.DiffLbl.AutoSize = true;
			this.DiffLbl.Location = new System.Drawing.Point(12, 83);
			this.DiffLbl.Name = "DiffLbl";
			this.DiffLbl.Size = new System.Drawing.Size(50, 13);
			this.DiffLbl.TabIndex = 4;
			this.DiffLbl.Text = "Difficulty:";
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
			this.DetailsBox.Size = new System.Drawing.Size(276, 131);
			this.DetailsBox.TabIndex = 0;
			// 
			// SkillBox
			// 
			this.SkillBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.SkillBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.SkillBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.SkillBox.FormattingEnabled = true;
			this.SkillBox.Location = new System.Drawing.Point(82, 12);
			this.SkillBox.Name = "SkillBox";
			this.SkillBox.Size = new System.Drawing.Size(220, 21);
			this.SkillBox.TabIndex = 1;
			// 
			// Pages
			// 
			this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Pages.Controls.Add(this.DetailsPage);
			this.Pages.Controls.Add(this.SuccessPage);
			this.Pages.Controls.Add(this.FailurePage);
			this.Pages.Controls.Add(this.ProgressPage);
			this.Pages.Location = new System.Drawing.Point(12, 148);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(290, 163);
			this.Pages.TabIndex = 8;
			// 
			// DetailsPage
			// 
			this.DetailsPage.Controls.Add(this.DetailsBox);
			this.DetailsPage.Location = new System.Drawing.Point(4, 22);
			this.DetailsPage.Name = "DetailsPage";
			this.DetailsPage.Padding = new System.Windows.Forms.Padding(3);
			this.DetailsPage.Size = new System.Drawing.Size(282, 137);
			this.DetailsPage.TabIndex = 0;
			this.DetailsPage.Text = "Details";
			this.DetailsPage.UseVisualStyleBackColor = true;
			// 
			// SuccessPage
			// 
			this.SuccessPage.Controls.Add(this.SuccessBox);
			this.SuccessPage.Location = new System.Drawing.Point(4, 22);
			this.SuccessPage.Name = "SuccessPage";
			this.SuccessPage.Padding = new System.Windows.Forms.Padding(3);
			this.SuccessPage.Size = new System.Drawing.Size(282, 137);
			this.SuccessPage.TabIndex = 1;
			this.SuccessPage.Text = "Success";
			this.SuccessPage.UseVisualStyleBackColor = true;
			// 
			// SuccessBox
			// 
			this.SuccessBox.AcceptsReturn = true;
			this.SuccessBox.AcceptsTab = true;
			this.SuccessBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SuccessBox.Location = new System.Drawing.Point(3, 3);
			this.SuccessBox.Multiline = true;
			this.SuccessBox.Name = "SuccessBox";
			this.SuccessBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.SuccessBox.Size = new System.Drawing.Size(276, 131);
			this.SuccessBox.TabIndex = 1;
			// 
			// FailurePage
			// 
			this.FailurePage.Controls.Add(this.FailureBox);
			this.FailurePage.Location = new System.Drawing.Point(4, 22);
			this.FailurePage.Name = "FailurePage";
			this.FailurePage.Padding = new System.Windows.Forms.Padding(3);
			this.FailurePage.Size = new System.Drawing.Size(282, 137);
			this.FailurePage.TabIndex = 2;
			this.FailurePage.Text = "Failure";
			this.FailurePage.UseVisualStyleBackColor = true;
			// 
			// FailureBox
			// 
			this.FailureBox.AcceptsReturn = true;
			this.FailureBox.AcceptsTab = true;
			this.FailureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FailureBox.Location = new System.Drawing.Point(3, 3);
			this.FailureBox.Multiline = true;
			this.FailureBox.Name = "FailureBox";
			this.FailureBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.FailureBox.Size = new System.Drawing.Size(276, 131);
			this.FailureBox.TabIndex = 1;
			// 
			// TypeLbl
			// 
			this.TypeLbl.AutoSize = true;
			this.TypeLbl.Location = new System.Drawing.Point(12, 42);
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
			this.TypeBox.Location = new System.Drawing.Point(82, 39);
			this.TypeBox.Name = "TypeBox";
			this.TypeBox.Size = new System.Drawing.Size(220, 21);
			this.TypeBox.TabIndex = 3;
			this.TypeBox.SelectedIndexChanged += new System.EventHandler(this.TypeBox_SelectedIndexChanged);
			// 
			// DiffBox
			// 
			this.DiffBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DiffBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.DiffBox.FormattingEnabled = true;
			this.DiffBox.Location = new System.Drawing.Point(82, 81);
			this.DiffBox.Name = "DiffBox";
			this.DiffBox.Size = new System.Drawing.Size(220, 21);
			this.DiffBox.TabIndex = 5;
			// 
			// ModLbl
			// 
			this.ModLbl.AutoSize = true;
			this.ModLbl.Location = new System.Drawing.Point(12, 110);
			this.ModLbl.Name = "ModLbl";
			this.ModLbl.Size = new System.Drawing.Size(64, 13);
			this.ModLbl.TabIndex = 6;
			this.ModLbl.Text = "DC modifier:";
			// 
			// ModBox
			// 
			this.ModBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ModBox.Location = new System.Drawing.Point(82, 108);
			this.ModBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.ModBox.Name = "ModBox";
			this.ModBox.Size = new System.Drawing.Size(220, 20);
			this.ModBox.TabIndex = 7;
			// 
			// ProgressPage
			// 
			this.ProgressPage.Controls.Add(this.FailureCountBox);
			this.ProgressPage.Controls.Add(this.SuccessCountBox);
			this.ProgressPage.Controls.Add(this.FailureLbl);
			this.ProgressPage.Controls.Add(this.SuccessLbl);
			this.ProgressPage.Location = new System.Drawing.Point(4, 22);
			this.ProgressPage.Name = "ProgressPage";
			this.ProgressPage.Padding = new System.Windows.Forms.Padding(3);
			this.ProgressPage.Size = new System.Drawing.Size(282, 137);
			this.ProgressPage.TabIndex = 3;
			this.ProgressPage.Text = "Progress";
			this.ProgressPage.UseVisualStyleBackColor = true;
			// 
			// SuccessLbl
			// 
			this.SuccessLbl.AutoSize = true;
			this.SuccessLbl.Location = new System.Drawing.Point(6, 21);
			this.SuccessLbl.Name = "SuccessLbl";
			this.SuccessLbl.Size = new System.Drawing.Size(62, 13);
			this.SuccessLbl.TabIndex = 0;
			this.SuccessLbl.Text = "Successes:";
			// 
			// FailureLbl
			// 
			this.FailureLbl.AutoSize = true;
			this.FailureLbl.Location = new System.Drawing.Point(6, 55);
			this.FailureLbl.Name = "FailureLbl";
			this.FailureLbl.Size = new System.Drawing.Size(46, 13);
			this.FailureLbl.TabIndex = 2;
			this.FailureLbl.Text = "Failures:";
			// 
			// SuccessCountBox
			// 
			this.SuccessCountBox.Location = new System.Drawing.Point(74, 19);
			this.SuccessCountBox.Name = "SuccessCountBox";
			this.SuccessCountBox.Size = new System.Drawing.Size(202, 20);
			this.SuccessCountBox.TabIndex = 1;
			// 
			// FailureCountBox
			// 
			this.FailureCountBox.Location = new System.Drawing.Point(74, 53);
			this.FailureCountBox.Name = "FailureCountBox";
			this.FailureCountBox.Size = new System.Drawing.Size(202, 20);
			this.FailureCountBox.TabIndex = 3;
			// 
			// SkillChallengeSkillForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(314, 352);
			this.Controls.Add(this.ModBox);
			this.Controls.Add(this.ModLbl);
			this.Controls.Add(this.DiffBox);
			this.Controls.Add(this.TypeBox);
			this.Controls.Add(this.TypeLbl);
			this.Controls.Add(this.Pages);
			this.Controls.Add(this.SkillBox);
			this.Controls.Add(this.DiffLbl);
			this.Controls.Add(this.SkillLblLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MinimizeBox = false;
			this.Name = "SkillChallengeSkillForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Skill";
			this.Pages.ResumeLayout(false);
			this.DetailsPage.ResumeLayout(false);
			this.DetailsPage.PerformLayout();
			this.SuccessPage.ResumeLayout(false);
			this.SuccessPage.PerformLayout();
			this.FailurePage.ResumeLayout(false);
			this.FailurePage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ModBox)).EndInit();
			this.ProgressPage.ResumeLayout(false);
			this.ProgressPage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.SuccessCountBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.FailureCountBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label SkillLblLbl;
		private System.Windows.Forms.Label DiffLbl;
		private System.Windows.Forms.TextBox DetailsBox;
		private System.Windows.Forms.ComboBox SkillBox;
		private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.TabPage DetailsPage;
		private System.Windows.Forms.TabPage SuccessPage;
		private System.Windows.Forms.TextBox SuccessBox;
		private System.Windows.Forms.TabPage FailurePage;
		private System.Windows.Forms.TextBox FailureBox;
		private System.Windows.Forms.Label TypeLbl;
		private System.Windows.Forms.ComboBox TypeBox;
		private System.Windows.Forms.ComboBox DiffBox;
		private System.Windows.Forms.Label ModLbl;
		private System.Windows.Forms.NumericUpDown ModBox;
		private System.Windows.Forms.TabPage ProgressPage;
		private System.Windows.Forms.NumericUpDown FailureCountBox;
		private System.Windows.Forms.NumericUpDown SuccessCountBox;
		private System.Windows.Forms.Label FailureLbl;
		private System.Windows.Forms.Label SuccessLbl;
	}
}