namespace Masterplan.UI
{
	partial class TrapProfileForm
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
			this.TypeLbl = new System.Windows.Forms.Label();
			this.TypeBox = new System.Windows.Forms.ComboBox();
			this.HasInitBox = new System.Windows.Forms.CheckBox();
			this.InitBox = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.LevelBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.InitBox)).BeginInit();
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
			this.NameBox.Location = new System.Drawing.Point(86, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(198, 20);
			this.NameBox.TabIndex = 1;
			// 
			// LevelLbl
			// 
			this.LevelLbl.AutoSize = true;
			this.LevelLbl.Location = new System.Drawing.Point(12, 67);
			this.LevelLbl.Name = "LevelLbl";
			this.LevelLbl.Size = new System.Drawing.Size(36, 13);
			this.LevelLbl.TabIndex = 4;
			this.LevelLbl.Text = "Level:";
			// 
			// LevelBox
			// 
			this.LevelBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.LevelBox.Location = new System.Drawing.Point(86, 65);
			this.LevelBox.Name = "LevelBox";
			this.LevelBox.Size = new System.Drawing.Size(198, 20);
			this.LevelBox.TabIndex = 5;
			// 
			// RoleLbl
			// 
			this.RoleLbl.AutoSize = true;
			this.RoleLbl.Location = new System.Drawing.Point(12, 96);
			this.RoleLbl.Name = "RoleLbl";
			this.RoleLbl.Size = new System.Drawing.Size(32, 13);
			this.RoleLbl.TabIndex = 6;
			this.RoleLbl.Text = "Role:";
			// 
			// RoleBtn
			// 
			this.RoleBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.RoleBtn.Location = new System.Drawing.Point(86, 91);
			this.RoleBtn.Name = "RoleBtn";
			this.RoleBtn.Size = new System.Drawing.Size(198, 23);
			this.RoleBtn.TabIndex = 7;
			this.RoleBtn.Text = "[role]";
			this.RoleBtn.UseVisualStyleBackColor = true;
			this.RoleBtn.Click += new System.EventHandler(this.RoleBtn_Click);
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(128, 157);
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
			this.CancelBtn.Location = new System.Drawing.Point(209, 157);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 11;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
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
			this.TypeBox.Location = new System.Drawing.Point(86, 38);
			this.TypeBox.Name = "TypeBox";
			this.TypeBox.Size = new System.Drawing.Size(198, 21);
			this.TypeBox.TabIndex = 3;
			// 
			// HasInitBox
			// 
			this.HasInitBox.AutoSize = true;
			this.HasInitBox.Location = new System.Drawing.Point(12, 121);
			this.HasInitBox.Name = "HasInitBox";
			this.HasInitBox.Size = new System.Drawing.Size(68, 17);
			this.HasInitBox.TabIndex = 8;
			this.HasInitBox.Text = "Initiative:";
			this.HasInitBox.UseVisualStyleBackColor = true;
			// 
			// InitBox
			// 
			this.InitBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.InitBox.Location = new System.Drawing.Point(86, 120);
			this.InitBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.InitBox.Name = "InitBox";
			this.InitBox.Size = new System.Drawing.Size(198, 20);
			this.InitBox.TabIndex = 9;
			// 
			// TrapProfileForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(296, 192);
			this.Controls.Add(this.InitBox);
			this.Controls.Add(this.HasInitBox);
			this.Controls.Add(this.TypeBox);
			this.Controls.Add(this.TypeLbl);
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
			this.Name = "TrapProfileForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Trap / Hazard Profile";
			((System.ComponentModel.ISupportInitialize)(this.LevelBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.InitBox)).EndInit();
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
		private System.Windows.Forms.Label TypeLbl;
		private System.Windows.Forms.ComboBox TypeBox;
		private System.Windows.Forms.CheckBox HasInitBox;
		private System.Windows.Forms.NumericUpDown InitBox;
	}
}