namespace Masterplan.UI
{
	partial class ProjectForm
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
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.SizeLbl = new System.Windows.Forms.Label();
			this.SizeBox = new System.Windows.Forms.NumericUpDown();
			this.LevelLbl = new System.Windows.Forms.Label();
			this.LevelBox = new System.Windows.Forms.NumericUpDown();
			this.AuthorBox = new System.Windows.Forms.TextBox();
			this.AuthorLbl = new System.Windows.Forms.Label();
			this.XPLbl = new System.Windows.Forms.Label();
			this.XPBox = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.SizeBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LevelBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.XPBox)).BeginInit();
			this.SuspendLayout();
			// 
			// NameLbl
			// 
			this.NameLbl.AutoSize = true;
			this.NameLbl.Location = new System.Drawing.Point(12, 15);
			this.NameLbl.Name = "NameLbl";
			this.NameLbl.Size = new System.Drawing.Size(74, 13);
			this.NameLbl.TabIndex = 0;
			this.NameLbl.Text = "Project Name:";
			// 
			// NameBox
			// 
			this.NameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.NameBox.Location = new System.Drawing.Point(92, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(263, 20);
			this.NameBox.TabIndex = 1;
			this.NameBox.TextChanged += new System.EventHandler(this.NameBox_TextChanged);
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(199, 173);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 10;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(280, 173);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 11;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// SizeLbl
			// 
			this.SizeLbl.AutoSize = true;
			this.SizeLbl.Location = new System.Drawing.Point(12, 80);
			this.SizeLbl.Name = "SizeLbl";
			this.SizeLbl.Size = new System.Drawing.Size(57, 13);
			this.SizeLbl.TabIndex = 4;
			this.SizeLbl.Text = "Party Size:";
			// 
			// SizeBox
			// 
			this.SizeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.SizeBox.Location = new System.Drawing.Point(92, 78);
			this.SizeBox.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.SizeBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.SizeBox.Name = "SizeBox";
			this.SizeBox.Size = new System.Drawing.Size(263, 20);
			this.SizeBox.TabIndex = 5;
			this.SizeBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.SizeBox.ValueChanged += new System.EventHandler(this.SizeBox_ValueChanged);
			// 
			// LevelLbl
			// 
			this.LevelLbl.AutoSize = true;
			this.LevelLbl.Location = new System.Drawing.Point(12, 106);
			this.LevelLbl.Name = "LevelLbl";
			this.LevelLbl.Size = new System.Drawing.Size(63, 13);
			this.LevelLbl.TabIndex = 6;
			this.LevelLbl.Text = "Party Level:";
			// 
			// LevelBox
			// 
			this.LevelBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.LevelBox.Location = new System.Drawing.Point(92, 104);
			this.LevelBox.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
			this.LevelBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.LevelBox.Name = "LevelBox";
			this.LevelBox.Size = new System.Drawing.Size(263, 20);
			this.LevelBox.TabIndex = 7;
			this.LevelBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.LevelBox.ValueChanged += new System.EventHandler(this.LevelBox_ValueChanged);
			// 
			// AuthorBox
			// 
			this.AuthorBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.AuthorBox.Location = new System.Drawing.Point(92, 38);
			this.AuthorBox.Name = "AuthorBox";
			this.AuthorBox.Size = new System.Drawing.Size(263, 20);
			this.AuthorBox.TabIndex = 3;
			// 
			// AuthorLbl
			// 
			this.AuthorLbl.AutoSize = true;
			this.AuthorLbl.Location = new System.Drawing.Point(12, 41);
			this.AuthorLbl.Name = "AuthorLbl";
			this.AuthorLbl.Size = new System.Drawing.Size(41, 13);
			this.AuthorLbl.TabIndex = 2;
			this.AuthorLbl.Text = "Author:";
			// 
			// XPLbl
			// 
			this.XPLbl.AutoSize = true;
			this.XPLbl.Location = new System.Drawing.Point(12, 132);
			this.XPLbl.Name = "XPLbl";
			this.XPLbl.Size = new System.Drawing.Size(63, 13);
			this.XPLbl.TabIndex = 8;
			this.XPLbl.Text = "Starting XP:";
			// 
			// XPBox
			// 
			this.XPBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.XPBox.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.XPBox.Location = new System.Drawing.Point(92, 130);
			this.XPBox.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
			this.XPBox.Name = "XPBox";
			this.XPBox.Size = new System.Drawing.Size(263, 20);
			this.XPBox.TabIndex = 9;
			this.XPBox.ValueChanged += new System.EventHandler(this.XPBox_ValueChanged);
			// 
			// ProjectForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(367, 208);
			this.Controls.Add(this.XPBox);
			this.Controls.Add(this.XPLbl);
			this.Controls.Add(this.AuthorBox);
			this.Controls.Add(this.AuthorLbl);
			this.Controls.Add(this.LevelBox);
			this.Controls.Add(this.LevelLbl);
			this.Controls.Add(this.SizeBox);
			this.Controls.Add(this.SizeLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLbl);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ProjectForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = Session.I18N.ProjectProperties;
			((System.ComponentModel.ISupportInitialize)(this.SizeBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LevelBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.XPBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label NameLbl;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label SizeLbl;
		private System.Windows.Forms.NumericUpDown SizeBox;
		private System.Windows.Forms.Label LevelLbl;
		private System.Windows.Forms.NumericUpDown LevelBox;
		private System.Windows.Forms.TextBox AuthorBox;
		private System.Windows.Forms.Label AuthorLbl;
        private System.Windows.Forms.Label XPLbl;
		private System.Windows.Forms.NumericUpDown XPBox;
	}
}