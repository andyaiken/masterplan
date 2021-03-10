namespace Masterplan.UI
{
	partial class MonsterThemePowerForm
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
			this.TypeLbl = new System.Windows.Forms.Label();
			this.TypeBox = new System.Windows.Forms.ComboBox();
			this.ArtilleryBox = new System.Windows.Forms.CheckBox();
			this.BruteBox = new System.Windows.Forms.CheckBox();
			this.ControllerBox = new System.Windows.Forms.CheckBox();
			this.LurkerBox = new System.Windows.Forms.CheckBox();
			this.SkirmisherBox = new System.Windows.Forms.CheckBox();
			this.SoldierBox = new System.Windows.Forms.CheckBox();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.RoleGroup = new System.Windows.Forms.GroupBox();
			this.RoleGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// TypeLbl
			// 
			this.TypeLbl.AutoSize = true;
			this.TypeLbl.Location = new System.Drawing.Point(12, 15);
			this.TypeLbl.Name = "TypeLbl";
			this.TypeLbl.Size = new System.Drawing.Size(63, 13);
			this.TypeLbl.TabIndex = 0;
			this.TypeLbl.Text = "Power type:";
			// 
			// TypeBox
			// 
			this.TypeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TypeBox.FormattingEnabled = true;
			this.TypeBox.Location = new System.Drawing.Point(81, 12);
			this.TypeBox.Name = "TypeBox";
			this.TypeBox.Size = new System.Drawing.Size(147, 21);
			this.TypeBox.TabIndex = 1;
			// 
			// ArtilleryBox
			// 
			this.ArtilleryBox.AutoSize = true;
			this.ArtilleryBox.Location = new System.Drawing.Point(6, 19);
			this.ArtilleryBox.Name = "ArtilleryBox";
			this.ArtilleryBox.Size = new System.Drawing.Size(59, 17);
			this.ArtilleryBox.TabIndex = 0;
			this.ArtilleryBox.Text = "Artillery";
			this.ArtilleryBox.UseVisualStyleBackColor = true;
			// 
			// BruteBox
			// 
			this.BruteBox.AutoSize = true;
			this.BruteBox.Location = new System.Drawing.Point(6, 42);
			this.BruteBox.Name = "BruteBox";
			this.BruteBox.Size = new System.Drawing.Size(51, 17);
			this.BruteBox.TabIndex = 1;
			this.BruteBox.Text = "Brute";
			this.BruteBox.UseVisualStyleBackColor = true;
			// 
			// ControllerBox
			// 
			this.ControllerBox.AutoSize = true;
			this.ControllerBox.Location = new System.Drawing.Point(6, 65);
			this.ControllerBox.Name = "ControllerBox";
			this.ControllerBox.Size = new System.Drawing.Size(70, 17);
			this.ControllerBox.TabIndex = 2;
			this.ControllerBox.Text = "Controller";
			this.ControllerBox.UseVisualStyleBackColor = true;
			// 
			// LurkerBox
			// 
			this.LurkerBox.AutoSize = true;
			this.LurkerBox.Location = new System.Drawing.Point(6, 88);
			this.LurkerBox.Name = "LurkerBox";
			this.LurkerBox.Size = new System.Drawing.Size(56, 17);
			this.LurkerBox.TabIndex = 3;
			this.LurkerBox.Text = "Lurker";
			this.LurkerBox.UseVisualStyleBackColor = true;
			// 
			// SkirmisherBox
			// 
			this.SkirmisherBox.AutoSize = true;
			this.SkirmisherBox.Location = new System.Drawing.Point(6, 111);
			this.SkirmisherBox.Name = "SkirmisherBox";
			this.SkirmisherBox.Size = new System.Drawing.Size(74, 17);
			this.SkirmisherBox.TabIndex = 4;
			this.SkirmisherBox.Text = "Skirmisher";
			this.SkirmisherBox.UseVisualStyleBackColor = true;
			// 
			// SoldierBox
			// 
			this.SoldierBox.AutoSize = true;
			this.SoldierBox.Location = new System.Drawing.Point(6, 134);
			this.SoldierBox.Name = "SoldierBox";
			this.SoldierBox.Size = new System.Drawing.Size(58, 17);
			this.SoldierBox.TabIndex = 5;
			this.SoldierBox.Text = "Soldier";
			this.SoldierBox.UseVisualStyleBackColor = true;
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(72, 210);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 3;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(153, 210);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 4;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// RoleGroup
			// 
			this.RoleGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.RoleGroup.Controls.Add(this.LurkerBox);
			this.RoleGroup.Controls.Add(this.ArtilleryBox);
			this.RoleGroup.Controls.Add(this.BruteBox);
			this.RoleGroup.Controls.Add(this.SoldierBox);
			this.RoleGroup.Controls.Add(this.ControllerBox);
			this.RoleGroup.Controls.Add(this.SkirmisherBox);
			this.RoleGroup.Location = new System.Drawing.Point(12, 39);
			this.RoleGroup.Name = "RoleGroup";
			this.RoleGroup.Size = new System.Drawing.Size(216, 165);
			this.RoleGroup.TabIndex = 2;
			this.RoleGroup.TabStop = false;
			this.RoleGroup.Text = "Roles";
			// 
			// MonsterThemePowerForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(240, 245);
			this.Controls.Add(this.RoleGroup);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.TypeBox);
			this.Controls.Add(this.TypeLbl);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MonsterThemePowerForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Theme Power Information";
			this.RoleGroup.ResumeLayout(false);
			this.RoleGroup.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label TypeLbl;
		private System.Windows.Forms.ComboBox TypeBox;
		private System.Windows.Forms.CheckBox ArtilleryBox;
		private System.Windows.Forms.CheckBox BruteBox;
		private System.Windows.Forms.CheckBox ControllerBox;
		private System.Windows.Forms.CheckBox LurkerBox;
		private System.Windows.Forms.CheckBox SkirmisherBox;
		private System.Windows.Forms.CheckBox SoldierBox;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.GroupBox RoleGroup;
	}
}