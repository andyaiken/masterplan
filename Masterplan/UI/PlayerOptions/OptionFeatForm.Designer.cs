namespace Masterplan.UI
{
	partial class OptionFeatForm
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
			this.PrereqLbl = new System.Windows.Forms.Label();
			this.PrereqBox = new System.Windows.Forms.TextBox();
			this.Pages = new System.Windows.Forms.TabControl();
			this.BenefitPage = new System.Windows.Forms.TabPage();
			this.BenefitBox = new System.Windows.Forms.TextBox();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.TierLbl = new System.Windows.Forms.Label();
			this.TierBox = new System.Windows.Forms.ComboBox();
			this.Pages.SuspendLayout();
			this.BenefitPage.SuspendLayout();
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
			this.NameBox.Location = new System.Drawing.Point(88, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(283, 20);
			this.NameBox.TabIndex = 1;
			// 
			// PrereqLbl
			// 
			this.PrereqLbl.AutoSize = true;
			this.PrereqLbl.Location = new System.Drawing.Point(12, 68);
			this.PrereqLbl.Name = "PrereqLbl";
			this.PrereqLbl.Size = new System.Drawing.Size(70, 13);
			this.PrereqLbl.TabIndex = 4;
			this.PrereqLbl.Text = "Prerequisites:";
			// 
			// PrereqBox
			// 
			this.PrereqBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.PrereqBox.Location = new System.Drawing.Point(88, 65);
			this.PrereqBox.Name = "PrereqBox";
			this.PrereqBox.Size = new System.Drawing.Size(283, 20);
			this.PrereqBox.TabIndex = 5;
			// 
			// Pages
			// 
			this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Pages.Controls.Add(this.BenefitPage);
			this.Pages.Location = new System.Drawing.Point(12, 91);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(359, 138);
			this.Pages.TabIndex = 6;
			// 
			// BenefitPage
			// 
			this.BenefitPage.Controls.Add(this.BenefitBox);
			this.BenefitPage.Location = new System.Drawing.Point(4, 22);
			this.BenefitPage.Name = "BenefitPage";
			this.BenefitPage.Padding = new System.Windows.Forms.Padding(3);
			this.BenefitPage.Size = new System.Drawing.Size(351, 112);
			this.BenefitPage.TabIndex = 0;
			this.BenefitPage.Text = "Benefit";
			this.BenefitPage.UseVisualStyleBackColor = true;
			// 
			// BenefitBox
			// 
			this.BenefitBox.AcceptsReturn = true;
			this.BenefitBox.AcceptsTab = true;
			this.BenefitBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BenefitBox.Location = new System.Drawing.Point(3, 3);
			this.BenefitBox.Multiline = true;
			this.BenefitBox.Name = "BenefitBox";
			this.BenefitBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.BenefitBox.Size = new System.Drawing.Size(345, 106);
			this.BenefitBox.TabIndex = 0;
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(215, 235);
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
			this.CancelBtn.Location = new System.Drawing.Point(296, 235);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 8;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// TierLbl
			// 
			this.TierLbl.AutoSize = true;
			this.TierLbl.Location = new System.Drawing.Point(12, 41);
			this.TierLbl.Name = "TierLbl";
			this.TierLbl.Size = new System.Drawing.Size(28, 13);
			this.TierLbl.TabIndex = 2;
			this.TierLbl.Text = "Tier:";
			// 
			// TierBox
			// 
			this.TierBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TierBox.FormattingEnabled = true;
			this.TierBox.Location = new System.Drawing.Point(88, 38);
			this.TierBox.Name = "TierBox";
			this.TierBox.Size = new System.Drawing.Size(283, 21);
			this.TierBox.TabIndex = 3;
			// 
			// OptionFeatForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(383, 270);
			this.Controls.Add(this.TierBox);
			this.Controls.Add(this.TierLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.Pages);
			this.Controls.Add(this.PrereqBox);
			this.Controls.Add(this.PrereqLbl);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLbl);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionFeatForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = Session.I18N.Feat;
			this.Pages.ResumeLayout(false);
			this.BenefitPage.ResumeLayout(false);
			this.BenefitPage.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label NameLbl;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.Label PrereqLbl;
		private System.Windows.Forms.TextBox PrereqBox;
		private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.TabPage BenefitPage;
		private System.Windows.Forms.TextBox BenefitBox;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label TierLbl;
		private System.Windows.Forms.ComboBox TierBox;
	}
}