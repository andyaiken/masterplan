namespace Masterplan.UI
{
	partial class CreatureSkillForm
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
			this.TrainedBox = new System.Windows.Forms.CheckBox();
			this.AbilityNameLbl = new System.Windows.Forms.Label();
			this.AbilityBonusLbl = new System.Windows.Forms.Label();
			this.LevelLbl = new System.Windows.Forms.Label();
			this.LevelBonusLbl = new System.Windows.Forms.Label();
			this.MiscLbl = new System.Windows.Forms.Label();
			this.MiscBox = new System.Windows.Forms.NumericUpDown();
			this.TotalLbl = new System.Windows.Forms.Label();
			this.TotalBonusLbl = new System.Windows.Forms.Label();
			this.TrainingBonusLbl = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.MiscBox)).BeginInit();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(31, 138);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 9;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(112, 138);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 10;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// TrainedBox
			// 
			this.TrainedBox.AutoSize = true;
			this.TrainedBox.Location = new System.Drawing.Point(12, 51);
			this.TrainedBox.Name = "TrainedBox";
			this.TrainedBox.Size = new System.Drawing.Size(62, 17);
			this.TrainedBox.TabIndex = 4;
			this.TrainedBox.Text = "Trained";
			this.TrainedBox.UseVisualStyleBackColor = true;
			this.TrainedBox.CheckedChanged += new System.EventHandler(this.TrainedBox_CheckedChanged);
			// 
			// AbilityNameLbl
			// 
			this.AbilityNameLbl.AutoSize = true;
			this.AbilityNameLbl.Location = new System.Drawing.Point(12, 9);
			this.AbilityNameLbl.Name = "AbilityNameLbl";
			this.AbilityNameLbl.Size = new System.Drawing.Size(39, 13);
			this.AbilityNameLbl.TabIndex = 0;
			this.AbilityNameLbl.Text = "[ability]";
			// 
			// AbilityBonusLbl
			// 
			this.AbilityBonusLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.AbilityBonusLbl.Location = new System.Drawing.Point(113, 9);
			this.AbilityBonusLbl.Name = "AbilityBonusLbl";
			this.AbilityBonusLbl.Size = new System.Drawing.Size(74, 13);
			this.AbilityBonusLbl.TabIndex = 1;
			this.AbilityBonusLbl.Text = "[ability bonus]";
			this.AbilityBonusLbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// LevelLbl
			// 
			this.LevelLbl.AutoSize = true;
			this.LevelLbl.Location = new System.Drawing.Point(12, 30);
			this.LevelLbl.Name = "LevelLbl";
			this.LevelLbl.Size = new System.Drawing.Size(54, 13);
			this.LevelLbl.TabIndex = 2;
			this.LevelLbl.Text = "Half level:";
			// 
			// LevelBonusLbl
			// 
			this.LevelBonusLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.LevelBonusLbl.Location = new System.Drawing.Point(113, 30);
			this.LevelBonusLbl.Name = "LevelBonusLbl";
			this.LevelBonusLbl.Size = new System.Drawing.Size(74, 13);
			this.LevelBonusLbl.TabIndex = 3;
			this.LevelBonusLbl.Text = "[level bonus]";
			this.LevelBonusLbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// MiscLbl
			// 
			this.MiscLbl.AutoSize = true;
			this.MiscLbl.Location = new System.Drawing.Point(12, 75);
			this.MiscLbl.Name = "MiscLbl";
			this.MiscLbl.Size = new System.Drawing.Size(64, 13);
			this.MiscLbl.TabIndex = 5;
			this.MiscLbl.Text = "Misc bonus:";
			// 
			// MiscBox
			// 
			this.MiscBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.MiscBox.Location = new System.Drawing.Point(116, 73);
			this.MiscBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.MiscBox.Name = "MiscBox";
			this.MiscBox.Size = new System.Drawing.Size(71, 20);
			this.MiscBox.TabIndex = 6;
			this.MiscBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.MiscBox.ValueChanged += new System.EventHandler(this.MiscBox_ValueChanged);
			// 
			// TotalLbl
			// 
			this.TotalLbl.AutoSize = true;
			this.TotalLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TotalLbl.Location = new System.Drawing.Point(12, 100);
			this.TotalLbl.Name = "TotalLbl";
			this.TotalLbl.Size = new System.Drawing.Size(40, 13);
			this.TotalLbl.TabIndex = 7;
			this.TotalLbl.Text = "Total:";
			// 
			// TotalBonusLbl
			// 
			this.TotalBonusLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TotalBonusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TotalBonusLbl.Location = new System.Drawing.Point(113, 100);
			this.TotalBonusLbl.Name = "TotalBonusLbl";
			this.TotalBonusLbl.Size = new System.Drawing.Size(74, 13);
			this.TotalBonusLbl.TabIndex = 8;
			this.TotalBonusLbl.Text = "[total]";
			this.TotalBonusLbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// TrainingBonusLbl
			// 
			this.TrainingBonusLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TrainingBonusLbl.Location = new System.Drawing.Point(113, 51);
			this.TrainingBonusLbl.Name = "TrainingBonusLbl";
			this.TrainingBonusLbl.Size = new System.Drawing.Size(74, 13);
			this.TrainingBonusLbl.TabIndex = 11;
			this.TrainingBonusLbl.Text = "[train bonus]";
			this.TrainingBonusLbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// CreatureSkillForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(199, 173);
			this.Controls.Add(this.TrainingBonusLbl);
			this.Controls.Add(this.TotalBonusLbl);
			this.Controls.Add(this.TotalLbl);
			this.Controls.Add(this.MiscBox);
			this.Controls.Add(this.MiscLbl);
			this.Controls.Add(this.LevelBonusLbl);
			this.Controls.Add(this.LevelLbl);
			this.Controls.Add(this.AbilityBonusLbl);
			this.Controls.Add(this.AbilityNameLbl);
			this.Controls.Add(this.TrainedBox);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CreatureSkillForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Creature Skill";
			((System.ComponentModel.ISupportInitialize)(this.MiscBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.CheckBox TrainedBox;
		private System.Windows.Forms.Label AbilityNameLbl;
		private System.Windows.Forms.Label AbilityBonusLbl;
		private System.Windows.Forms.Label LevelLbl;
		private System.Windows.Forms.Label LevelBonusLbl;
		private System.Windows.Forms.Label MiscLbl;
		private System.Windows.Forms.NumericUpDown MiscBox;
		private System.Windows.Forms.Label TotalLbl;
		private System.Windows.Forms.Label TotalBonusLbl;
		private System.Windows.Forms.Label TrainingBonusLbl;
	}
}