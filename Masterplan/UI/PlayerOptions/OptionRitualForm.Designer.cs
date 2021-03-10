namespace Masterplan.UI
{
	partial class OptionRitualForm
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
			this.DurationLbl = new System.Windows.Forms.Label();
			this.DurationBox = new System.Windows.Forms.TextBox();
			this.Pages = new System.Windows.Forms.TabControl();
			this.InfoPage = new System.Windows.Forms.TabPage();
			this.SkillBox = new System.Windows.Forms.ComboBox();
			this.SkillLbl = new System.Windows.Forms.Label();
			this.MarketBox = new System.Windows.Forms.TextBox();
			this.MarketLbl = new System.Windows.Forms.Label();
			this.ComponentBox = new System.Windows.Forms.TextBox();
			this.ComponentLbl = new System.Windows.Forms.Label();
			this.TimeBox = new System.Windows.Forms.TextBox();
			this.TimeLbl = new System.Windows.Forms.Label();
			this.ReadAloudPage = new System.Windows.Forms.TabPage();
			this.ReadAloudBox = new System.Windows.Forms.TextBox();
			this.DetailsPage = new System.Windows.Forms.TabPage();
			this.DetailsBox = new System.Windows.Forms.TextBox();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.LevelLbl = new System.Windows.Forms.Label();
			this.LevelBox = new System.Windows.Forms.NumericUpDown();
			this.CatLbl = new System.Windows.Forms.Label();
			this.CatBox = new System.Windows.Forms.ComboBox();
			this.Pages.SuspendLayout();
			this.InfoPage.SuspendLayout();
			this.ReadAloudPage.SuspendLayout();
			this.DetailsPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.LevelBox)).BeginInit();
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
			this.NameBox.Location = new System.Drawing.Point(70, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(282, 20);
			this.NameBox.TabIndex = 1;
			// 
			// DurationLbl
			// 
			this.DurationLbl.AutoSize = true;
			this.DurationLbl.Location = new System.Drawing.Point(6, 35);
			this.DurationLbl.Name = "DurationLbl";
			this.DurationLbl.Size = new System.Drawing.Size(50, 13);
			this.DurationLbl.TabIndex = 2;
			this.DurationLbl.Text = "Duration:";
			// 
			// DurationBox
			// 
			this.DurationBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DurationBox.Location = new System.Drawing.Point(100, 32);
			this.DurationBox.Name = "DurationBox";
			this.DurationBox.Size = new System.Drawing.Size(226, 20);
			this.DurationBox.TabIndex = 3;
			// 
			// Pages
			// 
			this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Pages.Controls.Add(this.InfoPage);
			this.Pages.Controls.Add(this.ReadAloudPage);
			this.Pages.Controls.Add(this.DetailsPage);
			this.Pages.Location = new System.Drawing.Point(12, 91);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(340, 168);
			this.Pages.TabIndex = 6;
			// 
			// InfoPage
			// 
			this.InfoPage.Controls.Add(this.SkillBox);
			this.InfoPage.Controls.Add(this.SkillLbl);
			this.InfoPage.Controls.Add(this.MarketBox);
			this.InfoPage.Controls.Add(this.MarketLbl);
			this.InfoPage.Controls.Add(this.ComponentBox);
			this.InfoPage.Controls.Add(this.ComponentLbl);
			this.InfoPage.Controls.Add(this.DurationBox);
			this.InfoPage.Controls.Add(this.DurationLbl);
			this.InfoPage.Controls.Add(this.TimeBox);
			this.InfoPage.Controls.Add(this.TimeLbl);
			this.InfoPage.Location = new System.Drawing.Point(4, 22);
			this.InfoPage.Name = "InfoPage";
			this.InfoPage.Padding = new System.Windows.Forms.Padding(3);
			this.InfoPage.Size = new System.Drawing.Size(332, 142);
			this.InfoPage.TabIndex = 2;
			this.InfoPage.Text = "Information";
			this.InfoPage.UseVisualStyleBackColor = true;
			// 
			// SkillBox
			// 
			this.SkillBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.SkillBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.SkillBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.SkillBox.FormattingEnabled = true;
			this.SkillBox.Location = new System.Drawing.Point(100, 110);
			this.SkillBox.Name = "SkillBox";
			this.SkillBox.Size = new System.Drawing.Size(226, 21);
			this.SkillBox.TabIndex = 9;
			// 
			// SkillLbl
			// 
			this.SkillLbl.AutoSize = true;
			this.SkillLbl.Location = new System.Drawing.Point(6, 113);
			this.SkillLbl.Name = "SkillLbl";
			this.SkillLbl.Size = new System.Drawing.Size(50, 13);
			this.SkillLbl.TabIndex = 8;
			this.SkillLbl.Text = "Key Skill:";
			// 
			// MarketBox
			// 
			this.MarketBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.MarketBox.Location = new System.Drawing.Point(100, 84);
			this.MarketBox.Name = "MarketBox";
			this.MarketBox.Size = new System.Drawing.Size(226, 20);
			this.MarketBox.TabIndex = 7;
			// 
			// MarketLbl
			// 
			this.MarketLbl.AutoSize = true;
			this.MarketLbl.Location = new System.Drawing.Point(6, 87);
			this.MarketLbl.Name = "MarketLbl";
			this.MarketLbl.Size = new System.Drawing.Size(70, 13);
			this.MarketLbl.TabIndex = 6;
			this.MarketLbl.Text = "Market Price:";
			// 
			// ComponentBox
			// 
			this.ComponentBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ComponentBox.Location = new System.Drawing.Point(100, 58);
			this.ComponentBox.Name = "ComponentBox";
			this.ComponentBox.Size = new System.Drawing.Size(226, 20);
			this.ComponentBox.TabIndex = 5;
			// 
			// ComponentLbl
			// 
			this.ComponentLbl.AutoSize = true;
			this.ComponentLbl.Location = new System.Drawing.Point(6, 61);
			this.ComponentLbl.Name = "ComponentLbl";
			this.ComponentLbl.Size = new System.Drawing.Size(88, 13);
			this.ComponentLbl.TabIndex = 4;
			this.ComponentLbl.Text = "Component Cost:";
			// 
			// TimeBox
			// 
			this.TimeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TimeBox.Location = new System.Drawing.Point(100, 6);
			this.TimeBox.Name = "TimeBox";
			this.TimeBox.Size = new System.Drawing.Size(226, 20);
			this.TimeBox.TabIndex = 1;
			// 
			// TimeLbl
			// 
			this.TimeLbl.AutoSize = true;
			this.TimeLbl.Location = new System.Drawing.Point(6, 9);
			this.TimeLbl.Name = "TimeLbl";
			this.TimeLbl.Size = new System.Drawing.Size(33, 13);
			this.TimeLbl.TabIndex = 0;
			this.TimeLbl.Text = "Time:";
			// 
			// ReadAloudPage
			// 
			this.ReadAloudPage.Controls.Add(this.ReadAloudBox);
			this.ReadAloudPage.Location = new System.Drawing.Point(4, 22);
			this.ReadAloudPage.Name = "ReadAloudPage";
			this.ReadAloudPage.Padding = new System.Windows.Forms.Padding(3);
			this.ReadAloudPage.Size = new System.Drawing.Size(332, 142);
			this.ReadAloudPage.TabIndex = 1;
			this.ReadAloudPage.Text = "Read-Aloud";
			this.ReadAloudPage.UseVisualStyleBackColor = true;
			// 
			// ReadAloudBox
			// 
			this.ReadAloudBox.AcceptsReturn = true;
			this.ReadAloudBox.AcceptsTab = true;
			this.ReadAloudBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ReadAloudBox.Location = new System.Drawing.Point(3, 3);
			this.ReadAloudBox.Multiline = true;
			this.ReadAloudBox.Name = "ReadAloudBox";
			this.ReadAloudBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.ReadAloudBox.Size = new System.Drawing.Size(326, 136);
			this.ReadAloudBox.TabIndex = 1;
			// 
			// DetailsPage
			// 
			this.DetailsPage.Controls.Add(this.DetailsBox);
			this.DetailsPage.Location = new System.Drawing.Point(4, 22);
			this.DetailsPage.Name = "DetailsPage";
			this.DetailsPage.Padding = new System.Windows.Forms.Padding(3);
			this.DetailsPage.Size = new System.Drawing.Size(332, 142);
			this.DetailsPage.TabIndex = 0;
			this.DetailsPage.Text = "Details";
			this.DetailsPage.UseVisualStyleBackColor = true;
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
			this.DetailsBox.Size = new System.Drawing.Size(326, 136);
			this.DetailsBox.TabIndex = 0;
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(196, 265);
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
			this.CancelBtn.Location = new System.Drawing.Point(277, 265);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 8;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// LevelLbl
			// 
			this.LevelLbl.AutoSize = true;
			this.LevelLbl.Location = new System.Drawing.Point(12, 40);
			this.LevelLbl.Name = "LevelLbl";
			this.LevelLbl.Size = new System.Drawing.Size(33, 13);
			this.LevelLbl.TabIndex = 2;
			this.LevelLbl.Text = "Level";
			// 
			// LevelBox
			// 
			this.LevelBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.LevelBox.Location = new System.Drawing.Point(70, 38);
			this.LevelBox.Name = "LevelBox";
			this.LevelBox.Size = new System.Drawing.Size(282, 20);
			this.LevelBox.TabIndex = 3;
			// 
			// CatLbl
			// 
			this.CatLbl.AutoSize = true;
			this.CatLbl.Location = new System.Drawing.Point(12, 67);
			this.CatLbl.Name = "CatLbl";
			this.CatLbl.Size = new System.Drawing.Size(52, 13);
			this.CatLbl.TabIndex = 4;
			this.CatLbl.Text = "Category:";
			// 
			// CatBox
			// 
			this.CatBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.CatBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CatBox.FormattingEnabled = true;
			this.CatBox.Location = new System.Drawing.Point(70, 64);
			this.CatBox.Name = "CatBox";
			this.CatBox.Size = new System.Drawing.Size(282, 21);
			this.CatBox.TabIndex = 5;
			this.CatBox.SelectedIndexChanged += new System.EventHandler(this.CatBox_SelectedIndexChanged);
			// 
			// OptionRitualForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(364, 300);
			this.Controls.Add(this.CatBox);
			this.Controls.Add(this.CatLbl);
			this.Controls.Add(this.LevelBox);
			this.Controls.Add(this.LevelLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.Pages);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLbl);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionRitualForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Ritual";
			this.Pages.ResumeLayout(false);
			this.InfoPage.ResumeLayout(false);
			this.InfoPage.PerformLayout();
			this.ReadAloudPage.ResumeLayout(false);
			this.ReadAloudPage.PerformLayout();
			this.DetailsPage.ResumeLayout(false);
			this.DetailsPage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.LevelBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label NameLbl;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.Label DurationLbl;
		private System.Windows.Forms.TextBox DurationBox;
		private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.TabPage DetailsPage;
		private System.Windows.Forms.TextBox DetailsBox;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.TextBox TimeBox;
		private System.Windows.Forms.Label TimeLbl;
		private System.Windows.Forms.TabPage ReadAloudPage;
		private System.Windows.Forms.TextBox ReadAloudBox;
		private System.Windows.Forms.Label LevelLbl;
		private System.Windows.Forms.NumericUpDown LevelBox;
		private System.Windows.Forms.Label CatLbl;
		private System.Windows.Forms.ComboBox CatBox;
		private System.Windows.Forms.TabPage InfoPage;
		private System.Windows.Forms.ComboBox SkillBox;
		private System.Windows.Forms.Label SkillLbl;
		private System.Windows.Forms.TextBox MarketBox;
		private System.Windows.Forms.Label MarketLbl;
		private System.Windows.Forms.TextBox ComponentBox;
		private System.Windows.Forms.Label ComponentLbl;
	}
}