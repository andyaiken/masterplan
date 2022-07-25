namespace Masterplan.UI
{
	partial class RoleForm
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
			this.RoleLbl = new System.Windows.Forms.Label();
			this.RoleBox = new System.Windows.Forms.ComboBox();
			this.ModLbl = new System.Windows.Forms.Label();
			this.ModBox = new System.Windows.Forms.ComboBox();
			this.LeaderBox = new System.Windows.Forms.CheckBox();
			this.StandardBtn = new System.Windows.Forms.RadioButton();
			this.MinionBtn = new System.Windows.Forms.RadioButton();
			this.HasRoleBox = new System.Windows.Forms.CheckBox();
			this.MinionRoleBox = new System.Windows.Forms.ComboBox();
			this.MinionRoleLbl = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(66, 216);
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
			this.CancelBtn.Location = new System.Drawing.Point(147, 216);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 11;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// RoleLbl
			// 
			this.RoleLbl.AutoSize = true;
			this.RoleLbl.Location = new System.Drawing.Point(32, 38);
			this.RoleLbl.Name = "RoleLbl";
			this.RoleLbl.Size = new System.Drawing.Size(32, 13);
			this.RoleLbl.TabIndex = 1;
			this.RoleLbl.Text = "Role:";
			// 
			// RoleBox
			// 
			this.RoleBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.RoleBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.RoleBox.FormattingEnabled = true;
			this.RoleBox.Location = new System.Drawing.Point(85, 35);
			this.RoleBox.Name = "RoleBox";
			this.RoleBox.Size = new System.Drawing.Size(137, 21);
			this.RoleBox.TabIndex = 2;
			// 
			// ModLbl
			// 
			this.ModLbl.AutoSize = true;
			this.ModLbl.Location = new System.Drawing.Point(32, 65);
			this.ModLbl.Name = "ModLbl";
			this.ModLbl.Size = new System.Drawing.Size(47, 13);
			this.ModLbl.TabIndex = 3;
			this.ModLbl.Text = "Modifier:";
			// 
			// ModBox
			// 
			this.ModBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ModBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ModBox.FormattingEnabled = true;
			this.ModBox.Location = new System.Drawing.Point(85, 62);
			this.ModBox.Name = "ModBox";
			this.ModBox.Size = new System.Drawing.Size(137, 21);
			this.ModBox.TabIndex = 4;
			// 
			// LeaderBox
			// 
			this.LeaderBox.AutoSize = true;
			this.LeaderBox.Location = new System.Drawing.Point(35, 89);
			this.LeaderBox.Name = "LeaderBox";
			this.LeaderBox.Size = new System.Drawing.Size(139, 17);
			this.LeaderBox.TabIndex = 5;
			this.LeaderBox.Text = "This creature is a leader";
			this.LeaderBox.UseVisualStyleBackColor = true;
			// 
			// StandardBtn
			// 
			this.StandardBtn.AutoSize = true;
			this.StandardBtn.Location = new System.Drawing.Point(12, 12);
			this.StandardBtn.Name = "StandardBtn";
			this.StandardBtn.Size = new System.Drawing.Size(93, 17);
			this.StandardBtn.TabIndex = 0;
			this.StandardBtn.TabStop = true;
			this.StandardBtn.Text = "Standard Role";
			this.StandardBtn.UseVisualStyleBackColor = true;
			// 
			// MinionBtn
			// 
			this.MinionBtn.AutoSize = true;
			this.MinionBtn.Location = new System.Drawing.Point(12, 126);
			this.MinionBtn.Name = "MinionBtn";
			this.MinionBtn.Size = new System.Drawing.Size(56, 17);
			this.MinionBtn.TabIndex = 6;
			this.MinionBtn.TabStop = true;
			this.MinionBtn.Text = "Minion";
			this.MinionBtn.UseVisualStyleBackColor = true;
			// 
			// HasRoleBox
			// 
			this.HasRoleBox.AutoSize = true;
			this.HasRoleBox.Location = new System.Drawing.Point(35, 149);
			this.HasRoleBox.Name = "HasRoleBox";
			this.HasRoleBox.Size = new System.Drawing.Size(99, 17);
			this.HasRoleBox.TabIndex = 7;
			this.HasRoleBox.Text = "Minion with role";
			this.HasRoleBox.UseVisualStyleBackColor = true;
			// 
			// MinionRoleBox
			// 
			this.MinionRoleBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.MinionRoleBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.MinionRoleBox.FormattingEnabled = true;
			this.MinionRoleBox.Location = new System.Drawing.Point(85, 172);
			this.MinionRoleBox.Name = "MinionRoleBox";
			this.MinionRoleBox.Size = new System.Drawing.Size(137, 21);
			this.MinionRoleBox.TabIndex = 9;
			// 
			// MinionRoleLbl
			// 
			this.MinionRoleLbl.AutoSize = true;
			this.MinionRoleLbl.Location = new System.Drawing.Point(32, 175);
			this.MinionRoleLbl.Name = "MinionRoleLbl";
			this.MinionRoleLbl.Size = new System.Drawing.Size(32, 13);
			this.MinionRoleLbl.TabIndex = 8;
			this.MinionRoleLbl.Text = "Role:";
			// 
			// RoleForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(234, 251);
			this.Controls.Add(this.MinionRoleLbl);
			this.Controls.Add(this.MinionRoleBox);
			this.Controls.Add(this.HasRoleBox);
			this.Controls.Add(this.MinionBtn);
			this.Controls.Add(this.StandardBtn);
			this.Controls.Add(this.LeaderBox);
			this.Controls.Add(this.ModBox);
			this.Controls.Add(this.ModLbl);
			this.Controls.Add(this.RoleBox);
			this.Controls.Add(this.RoleLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "RoleForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Role";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label RoleLbl;
		private System.Windows.Forms.ComboBox RoleBox;
		private System.Windows.Forms.Label ModLbl;
		private System.Windows.Forms.ComboBox ModBox;
		private System.Windows.Forms.CheckBox LeaderBox;
		private System.Windows.Forms.RadioButton StandardBtn;
		private System.Windows.Forms.RadioButton MinionBtn;
		private System.Windows.Forms.CheckBox HasRoleBox;
		private System.Windows.Forms.ComboBox MinionRoleBox;
		private System.Windows.Forms.Label MinionRoleLbl;
	}
}