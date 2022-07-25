namespace Masterplan.UI
{
	partial class MagicItemProfileForm
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
			this.NameLbl = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.LevelLbl = new System.Windows.Forms.Label();
			this.LevelBox = new System.Windows.Forms.NumericUpDown();
			this.TypeLbl = new System.Windows.Forms.Label();
			this.TypeBox = new System.Windows.Forms.ComboBox();
			this.RarityBox = new System.Windows.Forms.ComboBox();
			this.RarityLbl = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.LevelBox)).BeginInit();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(119, 124);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 8;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(200, 124);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 9;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
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
			this.NameBox.Location = new System.Drawing.Point(77, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(198, 20);
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
			this.LevelBox.Location = new System.Drawing.Point(77, 38);
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
			this.LevelBox.Size = new System.Drawing.Size(198, 20);
			this.LevelBox.TabIndex = 3;
			this.LevelBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// TypeLbl
			// 
			this.TypeLbl.AutoSize = true;
			this.TypeLbl.Location = new System.Drawing.Point(12, 67);
			this.TypeLbl.Name = "TypeLbl";
			this.TypeLbl.Size = new System.Drawing.Size(34, 13);
			this.TypeLbl.TabIndex = 4;
			this.TypeLbl.Text = "Type:";
			// 
			// TypeBox
			// 
			this.TypeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TypeBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.TypeBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.TypeBox.FormattingEnabled = true;
			this.TypeBox.Location = new System.Drawing.Point(77, 64);
			this.TypeBox.Name = "TypeBox";
			this.TypeBox.Size = new System.Drawing.Size(198, 21);
			this.TypeBox.Sorted = true;
			this.TypeBox.TabIndex = 5;
			// 
			// RarityBox
			// 
			this.RarityBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.RarityBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.RarityBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.RarityBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.RarityBox.FormattingEnabled = true;
			this.RarityBox.Location = new System.Drawing.Point(77, 91);
			this.RarityBox.Name = "RarityBox";
			this.RarityBox.Size = new System.Drawing.Size(198, 21);
			this.RarityBox.Sorted = true;
			this.RarityBox.TabIndex = 7;
			// 
			// RarityLbl
			// 
			this.RarityLbl.AutoSize = true;
			this.RarityLbl.Location = new System.Drawing.Point(12, 94);
			this.RarityLbl.Name = "RarityLbl";
			this.RarityLbl.Size = new System.Drawing.Size(59, 13);
			this.RarityLbl.TabIndex = 6;
			this.RarityLbl.Text = "Availability:";
			// 
			// MagicItemProfileForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(287, 159);
			this.Controls.Add(this.RarityBox);
			this.Controls.Add(this.RarityLbl);
			this.Controls.Add(this.TypeBox);
			this.Controls.Add(this.TypeLbl);
			this.Controls.Add(this.LevelBox);
			this.Controls.Add(this.LevelLbl);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MagicItemProfileForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Magic Item";
			((System.ComponentModel.ISupportInitialize)(this.LevelBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label NameLbl;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.Label LevelLbl;
		private System.Windows.Forms.NumericUpDown LevelBox;
		private System.Windows.Forms.Label TypeLbl;
		private System.Windows.Forms.ComboBox TypeBox;
		private System.Windows.Forms.ComboBox RarityBox;
		private System.Windows.Forms.Label RarityLbl;
	}
}