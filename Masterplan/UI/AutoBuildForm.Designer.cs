namespace Masterplan.UI
{
	partial class AutoBuildForm
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
			this.TemplateBox = new System.Windows.Forms.ComboBox();
			this.LevelLbl = new System.Windows.Forms.Label();
			this.LevelBox = new System.Windows.Forms.NumericUpDown();
			this.DiffLbl = new System.Windows.Forms.Label();
			this.DiffBox = new System.Windows.Forms.ComboBox();
			this.TemplateLbl = new System.Windows.Forms.Label();
			this.CatLbl = new System.Windows.Forms.Label();
			this.CatBtn = new System.Windows.Forms.Button();
			this.KeywordLbl = new System.Windows.Forms.Label();
			this.KeywordBox = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.LevelBox)).BeginInit();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(196, 155);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 12;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(277, 155);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 13;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// TemplateBox
			// 
			this.TemplateBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TemplateBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TemplateBox.FormattingEnabled = true;
			this.TemplateBox.Location = new System.Drawing.Point(74, 12);
			this.TemplateBox.Name = "TemplateBox";
			this.TemplateBox.Size = new System.Drawing.Size(278, 21);
			this.TemplateBox.TabIndex = 1;
			// 
			// LevelLbl
			// 
			this.LevelLbl.AutoSize = true;
			this.LevelLbl.Location = new System.Drawing.Point(12, 68);
			this.LevelLbl.Name = "LevelLbl";
			this.LevelLbl.Size = new System.Drawing.Size(36, 13);
			this.LevelLbl.TabIndex = 4;
			this.LevelLbl.Text = "Level:";
			// 
			// LevelBox
			// 
			this.LevelBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.LevelBox.Location = new System.Drawing.Point(74, 66);
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
			this.LevelBox.Size = new System.Drawing.Size(278, 20);
			this.LevelBox.TabIndex = 5;
			this.LevelBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// DiffLbl
			// 
			this.DiffLbl.AutoSize = true;
			this.DiffLbl.Location = new System.Drawing.Point(12, 42);
			this.DiffLbl.Name = "DiffLbl";
			this.DiffLbl.Size = new System.Drawing.Size(50, 13);
			this.DiffLbl.TabIndex = 2;
			this.DiffLbl.Text = "Difficulty:";
			// 
			// DiffBox
			// 
			this.DiffBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DiffBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.DiffBox.FormattingEnabled = true;
			this.DiffBox.Location = new System.Drawing.Point(74, 39);
			this.DiffBox.Name = "DiffBox";
			this.DiffBox.Size = new System.Drawing.Size(278, 21);
			this.DiffBox.TabIndex = 3;
			// 
			// TemplateLbl
			// 
			this.TemplateLbl.AutoSize = true;
			this.TemplateLbl.Location = new System.Drawing.Point(12, 15);
			this.TemplateLbl.Name = "TemplateLbl";
			this.TemplateLbl.Size = new System.Drawing.Size(54, 13);
			this.TemplateLbl.TabIndex = 0;
			this.TemplateLbl.Text = "Template:";
			// 
			// CatLbl
			// 
			this.CatLbl.AutoSize = true;
			this.CatLbl.Location = new System.Drawing.Point(12, 97);
			this.CatLbl.Name = "CatLbl";
			this.CatLbl.Size = new System.Drawing.Size(55, 13);
			this.CatLbl.TabIndex = 6;
			this.CatLbl.Text = "Creatures:";
			// 
			// CatBtn
			// 
			this.CatBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.CatBtn.Location = new System.Drawing.Point(74, 92);
			this.CatBtn.Name = "CatBtn";
			this.CatBtn.Size = new System.Drawing.Size(278, 23);
			this.CatBtn.TabIndex = 7;
			this.CatBtn.Text = "All Categories";
			this.CatBtn.UseVisualStyleBackColor = true;
			this.CatBtn.Click += new System.EventHandler(this.CatBtn_Click);
			// 
			// KeywordLbl
			// 
			this.KeywordLbl.AutoSize = true;
			this.KeywordLbl.Location = new System.Drawing.Point(12, 124);
			this.KeywordLbl.Name = "KeywordLbl";
			this.KeywordLbl.Size = new System.Drawing.Size(56, 13);
			this.KeywordLbl.TabIndex = 8;
			this.KeywordLbl.Text = "Keywords:";
			// 
			// KeywordBox
			// 
			this.KeywordBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.KeywordBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.KeywordBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.KeywordBox.FormattingEnabled = true;
			this.KeywordBox.Location = new System.Drawing.Point(74, 121);
			this.KeywordBox.Name = "KeywordBox";
			this.KeywordBox.Size = new System.Drawing.Size(278, 21);
			this.KeywordBox.TabIndex = 9;
			// 
			// AutoBuildForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(364, 190);
			this.Controls.Add(this.KeywordBox);
			this.Controls.Add(this.KeywordLbl);
			this.Controls.Add(this.CatBtn);
			this.Controls.Add(this.CatLbl);
			this.Controls.Add(this.TemplateLbl);
			this.Controls.Add(this.DiffBox);
			this.Controls.Add(this.DiffLbl);
			this.Controls.Add(this.LevelBox);
			this.Controls.Add(this.LevelLbl);
			this.Controls.Add(this.TemplateBox);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AutoBuildForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AutoBuild Options";
			((System.ComponentModel.ISupportInitialize)(this.LevelBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.ComboBox TemplateBox;
		private System.Windows.Forms.Label LevelLbl;
		private System.Windows.Forms.NumericUpDown LevelBox;
		private System.Windows.Forms.Label DiffLbl;
		private System.Windows.Forms.ComboBox DiffBox;
		private System.Windows.Forms.Label TemplateLbl;
		private System.Windows.Forms.Label CatLbl;
		private System.Windows.Forms.Button CatBtn;
        private System.Windows.Forms.Label KeywordLbl;
        private System.Windows.Forms.ComboBox KeywordBox;
	}
}