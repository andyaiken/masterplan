namespace Masterplan.UI
{
	partial class DamageModifierTemplateForm
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
			this.DamageTypeLbl = new System.Windows.Forms.Label();
			this.HeroicLbl = new System.Windows.Forms.Label();
			this.HeroicBox = new System.Windows.Forms.NumericUpDown();
			this.DamageTypeBox = new System.Windows.Forms.ComboBox();
			this.TypeBox = new System.Windows.Forms.ComboBox();
			this.ParagonBox = new System.Windows.Forms.NumericUpDown();
			this.ParagonLbl = new System.Windows.Forms.Label();
			this.EpicBox = new System.Windows.Forms.NumericUpDown();
			this.EpicLbl = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.HeroicBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ParagonBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.EpicBox)).BeginInit();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(104, 155);
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
			this.CancelBtn.Location = new System.Drawing.Point(185, 155);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 10;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// DamageTypeLbl
			// 
			this.DamageTypeLbl.AutoSize = true;
			this.DamageTypeLbl.Location = new System.Drawing.Point(12, 15);
			this.DamageTypeLbl.Name = "DamageTypeLbl";
			this.DamageTypeLbl.Size = new System.Drawing.Size(34, 13);
			this.DamageTypeLbl.TabIndex = 0;
			this.DamageTypeLbl.Text = "Type:";
			// 
			// HeroicLbl
			// 
			this.HeroicLbl.AutoSize = true;
			this.HeroicLbl.Location = new System.Drawing.Point(12, 68);
			this.HeroicLbl.Name = "HeroicLbl";
			this.HeroicLbl.Size = new System.Drawing.Size(41, 13);
			this.HeroicLbl.TabIndex = 3;
			this.HeroicLbl.Text = "Heroic:";
			// 
			// HeroicBox
			// 
			this.HeroicBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.HeroicBox.Location = new System.Drawing.Point(68, 66);
			this.HeroicBox.Name = "HeroicBox";
			this.HeroicBox.Size = new System.Drawing.Size(192, 20);
			this.HeroicBox.TabIndex = 4;
			// 
			// DamageTypeBox
			// 
			this.DamageTypeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DamageTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.DamageTypeBox.FormattingEnabled = true;
			this.DamageTypeBox.Location = new System.Drawing.Point(68, 12);
			this.DamageTypeBox.Name = "DamageTypeBox";
			this.DamageTypeBox.Size = new System.Drawing.Size(192, 21);
			this.DamageTypeBox.TabIndex = 1;
			// 
			// TypeBox
			// 
			this.TypeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TypeBox.FormattingEnabled = true;
			this.TypeBox.Location = new System.Drawing.Point(68, 39);
			this.TypeBox.Name = "TypeBox";
			this.TypeBox.Size = new System.Drawing.Size(192, 21);
			this.TypeBox.TabIndex = 2;
			this.TypeBox.SelectedIndexChanged += new System.EventHandler(this.TypeBox_SelectedIndexChanged);
			// 
			// ParagonBox
			// 
			this.ParagonBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ParagonBox.Location = new System.Drawing.Point(68, 92);
			this.ParagonBox.Name = "ParagonBox";
			this.ParagonBox.Size = new System.Drawing.Size(192, 20);
			this.ParagonBox.TabIndex = 6;
			// 
			// ParagonLbl
			// 
			this.ParagonLbl.AutoSize = true;
			this.ParagonLbl.Location = new System.Drawing.Point(12, 94);
			this.ParagonLbl.Name = "ParagonLbl";
			this.ParagonLbl.Size = new System.Drawing.Size(50, 13);
			this.ParagonLbl.TabIndex = 5;
			this.ParagonLbl.Text = "Paragon:";
			// 
			// EpicBox
			// 
			this.EpicBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.EpicBox.Location = new System.Drawing.Point(68, 118);
			this.EpicBox.Name = "EpicBox";
			this.EpicBox.Size = new System.Drawing.Size(192, 20);
			this.EpicBox.TabIndex = 8;
			// 
			// EpicLbl
			// 
			this.EpicLbl.AutoSize = true;
			this.EpicLbl.Location = new System.Drawing.Point(12, 120);
			this.EpicLbl.Name = "EpicLbl";
			this.EpicLbl.Size = new System.Drawing.Size(31, 13);
			this.EpicLbl.TabIndex = 7;
			this.EpicLbl.Text = "Epic:";
			// 
			// DamageModifierTemplateForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(272, 190);
			this.Controls.Add(this.EpicBox);
			this.Controls.Add(this.EpicLbl);
			this.Controls.Add(this.ParagonBox);
			this.Controls.Add(this.ParagonLbl);
			this.Controls.Add(this.TypeBox);
			this.Controls.Add(this.DamageTypeBox);
			this.Controls.Add(this.HeroicBox);
			this.Controls.Add(this.HeroicLbl);
			this.Controls.Add(this.DamageTypeLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DamageModifierTemplateForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Damage Modifier";
			((System.ComponentModel.ISupportInitialize)(this.HeroicBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ParagonBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.EpicBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label DamageTypeLbl;
		private System.Windows.Forms.Label HeroicLbl;
		private System.Windows.Forms.NumericUpDown HeroicBox;
		private System.Windows.Forms.ComboBox DamageTypeBox;
		private System.Windows.Forms.ComboBox TypeBox;
		private System.Windows.Forms.NumericUpDown ParagonBox;
		private System.Windows.Forms.Label ParagonLbl;
		private System.Windows.Forms.NumericUpDown EpicBox;
		private System.Windows.Forms.Label EpicLbl;
	}
}