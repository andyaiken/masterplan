namespace Masterplan.UI
{
	partial class CreatureProfileForm
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
			this.LevelLbl = new System.Windows.Forms.Label();
			this.LevelBox = new System.Windows.Forms.NumericUpDown();
			this.RoleLbl = new System.Windows.Forms.Label();
			this.RoleBtn = new System.Windows.Forms.Button();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.CatBox = new System.Windows.Forms.ComboBox();
			this.CatLbl = new System.Windows.Forms.Label();
			this.SizeBox = new System.Windows.Forms.ComboBox();
			this.SizeLbl = new System.Windows.Forms.Label();
			this.KeywordBox = new System.Windows.Forms.TextBox();
			this.KeywordLbl = new System.Windows.Forms.Label();
			this.TypeBox = new System.Windows.Forms.ComboBox();
			this.TypeLbl = new System.Windows.Forms.Label();
			this.OriginBox = new System.Windows.Forms.ComboBox();
			this.OriginLbl = new System.Windows.Forms.Label();
			this.TemplateBox = new System.Windows.Forms.ComboBox();
			this.TemplateLbl = new System.Windows.Forms.Label();
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
			this.NameBox.Location = new System.Drawing.Point(74, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(214, 20);
			this.NameBox.TabIndex = 1;
			// 
			// LevelLbl
			// 
			this.LevelLbl.AutoSize = true;
			this.LevelLbl.Location = new System.Drawing.Point(12, 40);
			this.LevelLbl.Name = "LevelLbl";
			this.LevelLbl.Size = new System.Drawing.Size(36, 13);
			this.LevelLbl.TabIndex = 2;
			this.LevelLbl.Text = "Level:";
			// 
			// LevelBox
			// 
			this.LevelBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.LevelBox.Location = new System.Drawing.Point(74, 38);
			this.LevelBox.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
			this.LevelBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.LevelBox.Name = "LevelBox";
			this.LevelBox.Size = new System.Drawing.Size(214, 20);
			this.LevelBox.TabIndex = 3;
			this.LevelBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// RoleLbl
			// 
			this.RoleLbl.AutoSize = true;
			this.RoleLbl.Location = new System.Drawing.Point(12, 69);
			this.RoleLbl.Name = "RoleLbl";
			this.RoleLbl.Size = new System.Drawing.Size(32, 13);
			this.RoleLbl.TabIndex = 4;
			this.RoleLbl.Text = "Role:";
			// 
			// RoleBtn
			// 
			this.RoleBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.RoleBtn.Location = new System.Drawing.Point(74, 64);
			this.RoleBtn.Name = "RoleBtn";
			this.RoleBtn.Size = new System.Drawing.Size(214, 23);
			this.RoleBtn.TabIndex = 5;
			this.RoleBtn.Text = "[role]";
			this.RoleBtn.UseVisualStyleBackColor = true;
			this.RoleBtn.Click += new System.EventHandler(this.RoleBtn_Click);
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(132, 265);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 16;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(213, 265);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 17;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// CatBox
			// 
			this.CatBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.CatBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.CatBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.CatBox.FormattingEnabled = true;
			this.CatBox.Location = new System.Drawing.Point(74, 227);
			this.CatBox.Name = "CatBox";
			this.CatBox.Size = new System.Drawing.Size(214, 21);
			this.CatBox.Sorted = true;
			this.CatBox.TabIndex = 15;
			// 
			// CatLbl
			// 
			this.CatLbl.AutoSize = true;
			this.CatLbl.Location = new System.Drawing.Point(12, 230);
			this.CatLbl.Name = "CatLbl";
			this.CatLbl.Size = new System.Drawing.Size(52, 13);
			this.CatLbl.TabIndex = 14;
			this.CatLbl.Text = "Category:";
			// 
			// SizeBox
			// 
			this.SizeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.SizeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.SizeBox.Location = new System.Drawing.Point(74, 120);
			this.SizeBox.Name = "SizeBox";
			this.SizeBox.Size = new System.Drawing.Size(214, 21);
			this.SizeBox.TabIndex = 7;
			// 
			// SizeLbl
			// 
			this.SizeLbl.AutoSize = true;
			this.SizeLbl.Location = new System.Drawing.Point(12, 123);
			this.SizeLbl.Name = "SizeLbl";
			this.SizeLbl.Size = new System.Drawing.Size(30, 13);
			this.SizeLbl.TabIndex = 6;
			this.SizeLbl.Text = "Size:";
			// 
			// KeywordBox
			// 
			this.KeywordBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.KeywordBox.Location = new System.Drawing.Point(74, 201);
			this.KeywordBox.Name = "KeywordBox";
			this.KeywordBox.Size = new System.Drawing.Size(214, 20);
			this.KeywordBox.TabIndex = 13;
			// 
			// KeywordLbl
			// 
			this.KeywordLbl.AutoSize = true;
			this.KeywordLbl.Location = new System.Drawing.Point(12, 204);
			this.KeywordLbl.Name = "KeywordLbl";
			this.KeywordLbl.Size = new System.Drawing.Size(56, 13);
			this.KeywordLbl.TabIndex = 12;
			this.KeywordLbl.Text = "Keywords:";
			// 
			// TypeBox
			// 
			this.TypeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TypeBox.FormattingEnabled = true;
			this.TypeBox.Location = new System.Drawing.Point(74, 174);
			this.TypeBox.Name = "TypeBox";
			this.TypeBox.Size = new System.Drawing.Size(214, 21);
			this.TypeBox.TabIndex = 11;
			// 
			// TypeLbl
			// 
			this.TypeLbl.AutoSize = true;
			this.TypeLbl.Location = new System.Drawing.Point(12, 177);
			this.TypeLbl.Name = "TypeLbl";
			this.TypeLbl.Size = new System.Drawing.Size(34, 13);
			this.TypeLbl.TabIndex = 10;
			this.TypeLbl.Text = "Type:";
			// 
			// OriginBox
			// 
			this.OriginBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.OriginBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.OriginBox.FormattingEnabled = true;
			this.OriginBox.Location = new System.Drawing.Point(74, 147);
			this.OriginBox.Name = "OriginBox";
			this.OriginBox.Size = new System.Drawing.Size(214, 21);
			this.OriginBox.TabIndex = 9;
			// 
			// OriginLbl
			// 
			this.OriginLbl.AutoSize = true;
			this.OriginLbl.Location = new System.Drawing.Point(12, 150);
			this.OriginLbl.Name = "OriginLbl";
			this.OriginLbl.Size = new System.Drawing.Size(37, 13);
			this.OriginLbl.TabIndex = 8;
			this.OriginLbl.Text = "Origin:";
			// 
			// TemplateBox
			// 
			this.TemplateBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TemplateBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TemplateBox.FormattingEnabled = true;
			this.TemplateBox.Location = new System.Drawing.Point(74, 93);
			this.TemplateBox.Name = "TemplateBox";
			this.TemplateBox.Size = new System.Drawing.Size(214, 21);
			this.TemplateBox.TabIndex = 19;
			this.TemplateBox.SelectedIndexChanged += new System.EventHandler(this.TemplateBox_SelectedIndexChanged);
			// 
			// TemplateLbl
			// 
			this.TemplateLbl.AutoSize = true;
			this.TemplateLbl.Location = new System.Drawing.Point(12, 96);
			this.TemplateLbl.Name = "TemplateLbl";
			this.TemplateLbl.Size = new System.Drawing.Size(54, 13);
			this.TemplateLbl.TabIndex = 18;
			this.TemplateLbl.Text = "Template:";
			// 
			// CreatureProfileForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(300, 300);
			this.Controls.Add(this.TemplateBox);
			this.Controls.Add(this.TemplateLbl);
			this.Controls.Add(this.SizeBox);
			this.Controls.Add(this.SizeLbl);
			this.Controls.Add(this.KeywordBox);
			this.Controls.Add(this.KeywordLbl);
			this.Controls.Add(this.TypeBox);
			this.Controls.Add(this.TypeLbl);
			this.Controls.Add(this.OriginBox);
			this.Controls.Add(this.OriginLbl);
			this.Controls.Add(this.CatBox);
			this.Controls.Add(this.CatLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.RoleBtn);
			this.Controls.Add(this.RoleLbl);
			this.Controls.Add(this.LevelBox);
			this.Controls.Add(this.LevelLbl);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLbl);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CreatureProfileForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = Session.I18N.Creature;
			((System.ComponentModel.ISupportInitialize)(this.LevelBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label NameLbl;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.Label LevelLbl;
		private System.Windows.Forms.NumericUpDown LevelBox;
		private System.Windows.Forms.Label RoleLbl;
		private System.Windows.Forms.Button RoleBtn;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.ComboBox CatBox;
		private System.Windows.Forms.Label CatLbl;
		private System.Windows.Forms.ComboBox SizeBox;
		private System.Windows.Forms.Label SizeLbl;
		private System.Windows.Forms.TextBox KeywordBox;
		private System.Windows.Forms.Label KeywordLbl;
		private System.Windows.Forms.ComboBox TypeBox;
		private System.Windows.Forms.Label TypeLbl;
		private System.Windows.Forms.ComboBox OriginBox;
		private System.Windows.Forms.Label OriginLbl;
		private System.Windows.Forms.ComboBox TemplateBox;
		private System.Windows.Forms.Label TemplateLbl;
	}
}