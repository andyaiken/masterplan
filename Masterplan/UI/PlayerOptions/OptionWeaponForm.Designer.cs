namespace Masterplan.UI
{
	partial class OptionWeaponForm
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
			this.CatLbl = new System.Windows.Forms.Label();
			this.CatBox = new System.Windows.Forms.ComboBox();
			this.TypeLbl = new System.Windows.Forms.Label();
			this.TypeBox = new System.Windows.Forms.ComboBox();
			this.TwoHandBox = new System.Windows.Forms.CheckBox();
			this.ProfLbl = new System.Windows.Forms.Label();
			this.ProfBox = new System.Windows.Forms.NumericUpDown();
			this.DamageLbl = new System.Windows.Forms.Label();
			this.DamageBox = new System.Windows.Forms.TextBox();
			this.RangeLbl = new System.Windows.Forms.Label();
			this.RangeBox = new System.Windows.Forms.TextBox();
			this.PriceLbl = new System.Windows.Forms.Label();
			this.PriceBox = new System.Windows.Forms.TextBox();
			this.WeightLbl = new System.Windows.Forms.Label();
			this.WeightBox = new System.Windows.Forms.TextBox();
			this.Pages = new System.Windows.Forms.TabControl();
			this.DetailsPage = new System.Windows.Forms.TabPage();
			this.DetailsBox = new System.Windows.Forms.TextBox();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.PropertiesBox = new System.Windows.Forms.ComboBox();
			this.PropertiesLbl = new System.Windows.Forms.Label();
			this.GroupBox = new System.Windows.Forms.ComboBox();
			this.GroupLbl = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.ProfBox)).BeginInit();
			this.Pages.SuspendLayout();
			this.DetailsPage.SuspendLayout();
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
			this.NameBox.Location = new System.Drawing.Point(80, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(230, 20);
			this.NameBox.TabIndex = 1;
			// 
			// CatLbl
			// 
			this.CatLbl.AutoSize = true;
			this.CatLbl.Location = new System.Drawing.Point(12, 41);
			this.CatLbl.Name = "CatLbl";
			this.CatLbl.Size = new System.Drawing.Size(52, 13);
			this.CatLbl.TabIndex = 2;
			this.CatLbl.Text = "Category:";
			// 
			// CatBox
			// 
			this.CatBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.CatBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CatBox.FormattingEnabled = true;
			this.CatBox.Location = new System.Drawing.Point(80, 38);
			this.CatBox.Name = "CatBox";
			this.CatBox.Size = new System.Drawing.Size(230, 21);
			this.CatBox.TabIndex = 3;
			// 
			// TypeLbl
			// 
			this.TypeLbl.AutoSize = true;
			this.TypeLbl.Location = new System.Drawing.Point(12, 68);
			this.TypeLbl.Name = "TypeLbl";
			this.TypeLbl.Size = new System.Drawing.Size(34, 13);
			this.TypeLbl.TabIndex = 4;
			this.TypeLbl.Text = "Type:";
			// 
			// TypeBox
			// 
			this.TypeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TypeBox.FormattingEnabled = true;
			this.TypeBox.Location = new System.Drawing.Point(80, 65);
			this.TypeBox.Name = "TypeBox";
			this.TypeBox.Size = new System.Drawing.Size(230, 21);
			this.TypeBox.TabIndex = 5;
			// 
			// TwoHandBox
			// 
			this.TwoHandBox.AutoSize = true;
			this.TwoHandBox.Location = new System.Drawing.Point(80, 92);
			this.TwoHandBox.Name = "TwoHandBox";
			this.TwoHandBox.Size = new System.Drawing.Size(162, 17);
			this.TwoHandBox.TabIndex = 6;
			this.TwoHandBox.Text = "Must be wielded two-handed";
			this.TwoHandBox.UseVisualStyleBackColor = true;
			// 
			// ProfLbl
			// 
			this.ProfLbl.AutoSize = true;
			this.ProfLbl.Location = new System.Drawing.Point(12, 117);
			this.ProfLbl.Name = "ProfLbl";
			this.ProfLbl.Size = new System.Drawing.Size(62, 13);
			this.ProfLbl.TabIndex = 7;
			this.ProfLbl.Text = "Proficiency:";
			// 
			// ProfBox
			// 
			this.ProfBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ProfBox.Location = new System.Drawing.Point(80, 115);
			this.ProfBox.Name = "ProfBox";
			this.ProfBox.Size = new System.Drawing.Size(230, 20);
			this.ProfBox.TabIndex = 8;
			// 
			// DamageLbl
			// 
			this.DamageLbl.AutoSize = true;
			this.DamageLbl.Location = new System.Drawing.Point(12, 144);
			this.DamageLbl.Name = "DamageLbl";
			this.DamageLbl.Size = new System.Drawing.Size(50, 13);
			this.DamageLbl.TabIndex = 9;
			this.DamageLbl.Text = "Damage:";
			// 
			// DamageBox
			// 
			this.DamageBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DamageBox.Location = new System.Drawing.Point(80, 141);
			this.DamageBox.Name = "DamageBox";
			this.DamageBox.Size = new System.Drawing.Size(230, 20);
			this.DamageBox.TabIndex = 10;
			// 
			// RangeLbl
			// 
			this.RangeLbl.AutoSize = true;
			this.RangeLbl.Location = new System.Drawing.Point(12, 170);
			this.RangeLbl.Name = "RangeLbl";
			this.RangeLbl.Size = new System.Drawing.Size(42, 13);
			this.RangeLbl.TabIndex = 11;
			this.RangeLbl.Text = "Range:";
			// 
			// RangeBox
			// 
			this.RangeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.RangeBox.Location = new System.Drawing.Point(80, 167);
			this.RangeBox.Name = "RangeBox";
			this.RangeBox.Size = new System.Drawing.Size(230, 20);
			this.RangeBox.TabIndex = 12;
			// 
			// PriceLbl
			// 
			this.PriceLbl.AutoSize = true;
			this.PriceLbl.Location = new System.Drawing.Point(12, 196);
			this.PriceLbl.Name = "PriceLbl";
			this.PriceLbl.Size = new System.Drawing.Size(34, 13);
			this.PriceLbl.TabIndex = 13;
			this.PriceLbl.Text = "Price:";
			// 
			// PriceBox
			// 
			this.PriceBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.PriceBox.Location = new System.Drawing.Point(80, 193);
			this.PriceBox.Name = "PriceBox";
			this.PriceBox.Size = new System.Drawing.Size(230, 20);
			this.PriceBox.TabIndex = 14;
			// 
			// WeightLbl
			// 
			this.WeightLbl.AutoSize = true;
			this.WeightLbl.Location = new System.Drawing.Point(12, 222);
			this.WeightLbl.Name = "WeightLbl";
			this.WeightLbl.Size = new System.Drawing.Size(44, 13);
			this.WeightLbl.TabIndex = 15;
			this.WeightLbl.Text = "Weight:";
			// 
			// WeightBox
			// 
			this.WeightBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.WeightBox.Location = new System.Drawing.Point(80, 219);
			this.WeightBox.Name = "WeightBox";
			this.WeightBox.Size = new System.Drawing.Size(230, 20);
			this.WeightBox.TabIndex = 16;
			// 
			// Pages
			// 
			this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Pages.Controls.Add(this.DetailsPage);
			this.Pages.Location = new System.Drawing.Point(12, 299);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(298, 129);
			this.Pages.TabIndex = 21;
			// 
			// DetailsPage
			// 
			this.DetailsPage.Controls.Add(this.DetailsBox);
			this.DetailsPage.Location = new System.Drawing.Point(4, 22);
			this.DetailsPage.Name = "DetailsPage";
			this.DetailsPage.Padding = new System.Windows.Forms.Padding(3);
			this.DetailsPage.Size = new System.Drawing.Size(290, 103);
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
			this.DetailsBox.Size = new System.Drawing.Size(284, 97);
			this.DetailsBox.TabIndex = 0;
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(154, 434);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 22;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(235, 434);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 23;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// PropertiesBox
			// 
			this.PropertiesBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.PropertiesBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.PropertiesBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.PropertiesBox.FormattingEnabled = true;
			this.PropertiesBox.Location = new System.Drawing.Point(80, 272);
			this.PropertiesBox.Name = "PropertiesBox";
			this.PropertiesBox.Size = new System.Drawing.Size(230, 21);
			this.PropertiesBox.TabIndex = 20;
			// 
			// PropertiesLbl
			// 
			this.PropertiesLbl.AutoSize = true;
			this.PropertiesLbl.Location = new System.Drawing.Point(12, 275);
			this.PropertiesLbl.Name = "PropertiesLbl";
			this.PropertiesLbl.Size = new System.Drawing.Size(57, 13);
			this.PropertiesLbl.TabIndex = 19;
			this.PropertiesLbl.Text = "Properties:";
			// 
			// GroupBox
			// 
			this.GroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.GroupBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.GroupBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.GroupBox.FormattingEnabled = true;
			this.GroupBox.Location = new System.Drawing.Point(80, 245);
			this.GroupBox.Name = "GroupBox";
			this.GroupBox.Size = new System.Drawing.Size(230, 21);
			this.GroupBox.TabIndex = 18;
			// 
			// GroupLbl
			// 
			this.GroupLbl.AutoSize = true;
			this.GroupLbl.Location = new System.Drawing.Point(12, 248);
			this.GroupLbl.Name = "GroupLbl";
			this.GroupLbl.Size = new System.Drawing.Size(50, 13);
			this.GroupLbl.TabIndex = 17;
			this.GroupLbl.Text = "Group(s):";
			// 
			// OptionWeaponForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(322, 469);
			this.Controls.Add(this.PropertiesBox);
			this.Controls.Add(this.PropertiesLbl);
			this.Controls.Add(this.GroupBox);
			this.Controls.Add(this.GroupLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.Pages);
			this.Controls.Add(this.WeightBox);
			this.Controls.Add(this.WeightLbl);
			this.Controls.Add(this.PriceBox);
			this.Controls.Add(this.PriceLbl);
			this.Controls.Add(this.RangeBox);
			this.Controls.Add(this.RangeLbl);
			this.Controls.Add(this.DamageBox);
			this.Controls.Add(this.DamageLbl);
			this.Controls.Add(this.ProfBox);
			this.Controls.Add(this.ProfLbl);
			this.Controls.Add(this.TwoHandBox);
			this.Controls.Add(this.TypeBox);
			this.Controls.Add(this.TypeLbl);
			this.Controls.Add(this.CatBox);
			this.Controls.Add(this.CatLbl);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLbl);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionWeaponForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Weapon";
			((System.ComponentModel.ISupportInitialize)(this.ProfBox)).EndInit();
			this.Pages.ResumeLayout(false);
			this.DetailsPage.ResumeLayout(false);
			this.DetailsPage.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label NameLbl;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.Label CatLbl;
		private System.Windows.Forms.ComboBox CatBox;
		private System.Windows.Forms.Label TypeLbl;
		private System.Windows.Forms.ComboBox TypeBox;
		private System.Windows.Forms.CheckBox TwoHandBox;
		private System.Windows.Forms.Label ProfLbl;
		private System.Windows.Forms.NumericUpDown ProfBox;
		private System.Windows.Forms.Label DamageLbl;
		private System.Windows.Forms.TextBox DamageBox;
		private System.Windows.Forms.Label RangeLbl;
		private System.Windows.Forms.TextBox RangeBox;
		private System.Windows.Forms.Label PriceLbl;
		private System.Windows.Forms.TextBox PriceBox;
		private System.Windows.Forms.Label WeightLbl;
		private System.Windows.Forms.TextBox WeightBox;
		private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.TabPage DetailsPage;
		private System.Windows.Forms.TextBox DetailsBox;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.ComboBox PropertiesBox;
		private System.Windows.Forms.Label PropertiesLbl;
		private System.Windows.Forms.ComboBox GroupBox;
		private System.Windows.Forms.Label GroupLbl;
	}
}