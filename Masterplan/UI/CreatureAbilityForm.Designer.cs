namespace Masterplan.UI
{
	partial class CreatureAbilityForm
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
			this.StrModBox = new System.Windows.Forms.TextBox();
			this.StrBox = new System.Windows.Forms.NumericUpDown();
			this.ChaModBox = new System.Windows.Forms.TextBox();
			this.ChaBox = new System.Windows.Forms.NumericUpDown();
			this.StrLbl = new System.Windows.Forms.Label();
			this.ChaLbl = new System.Windows.Forms.Label();
			this.WisModBox = new System.Windows.Forms.TextBox();
			this.WisBox = new System.Windows.Forms.NumericUpDown();
			this.WisLbl = new System.Windows.Forms.Label();
			this.IntModBox = new System.Windows.Forms.TextBox();
			this.IntBox = new System.Windows.Forms.NumericUpDown();
			this.ConLbl = new System.Windows.Forms.Label();
			this.IntLbl = new System.Windows.Forms.Label();
			this.DexModBox = new System.Windows.Forms.TextBox();
			this.DexBox = new System.Windows.Forms.NumericUpDown();
			this.ConBox = new System.Windows.Forms.NumericUpDown();
			this.DexLbl = new System.Windows.Forms.Label();
			this.ConModBox = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.StrBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ChaBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.WisBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.IntBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DexBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ConBox)).BeginInit();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(149, 181);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 18;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(230, 181);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 19;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// StrModBox
			// 
			this.StrModBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.StrModBox.Location = new System.Drawing.Point(209, 12);
			this.StrModBox.Name = "StrModBox";
			this.StrModBox.ReadOnly = true;
			this.StrModBox.Size = new System.Drawing.Size(96, 20);
			this.StrModBox.TabIndex = 2;
			this.StrModBox.TabStop = false;
			this.StrModBox.Text = "[str]";
			this.StrModBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// StrBox
			// 
			this.StrBox.Location = new System.Drawing.Point(83, 12);
			this.StrBox.Name = "StrBox";
			this.StrBox.Size = new System.Drawing.Size(120, 20);
			this.StrBox.TabIndex = 1;
			this.StrBox.ValueChanged += new System.EventHandler(this.StrBox_ValueChanged);
			// 
			// ChaModBox
			// 
			this.ChaModBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ChaModBox.Location = new System.Drawing.Point(209, 142);
			this.ChaModBox.Name = "ChaModBox";
			this.ChaModBox.ReadOnly = true;
			this.ChaModBox.Size = new System.Drawing.Size(96, 20);
			this.ChaModBox.TabIndex = 17;
			this.ChaModBox.TabStop = false;
			this.ChaModBox.Text = "[cha]";
			this.ChaModBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ChaBox
			// 
			this.ChaBox.Location = new System.Drawing.Point(83, 142);
			this.ChaBox.Name = "ChaBox";
			this.ChaBox.Size = new System.Drawing.Size(120, 20);
			this.ChaBox.TabIndex = 16;
			this.ChaBox.ValueChanged += new System.EventHandler(this.StrBox_ValueChanged);
			// 
			// StrLbl
			// 
			this.StrLbl.AutoSize = true;
			this.StrLbl.Location = new System.Drawing.Point(12, 15);
			this.StrLbl.Name = "StrLbl";
			this.StrLbl.Size = new System.Drawing.Size(50, 13);
			this.StrLbl.TabIndex = 0;
			this.StrLbl.Text = "Strength:";
			// 
			// ChaLbl
			// 
			this.ChaLbl.AutoSize = true;
			this.ChaLbl.Location = new System.Drawing.Point(12, 145);
			this.ChaLbl.Name = "ChaLbl";
			this.ChaLbl.Size = new System.Drawing.Size(53, 13);
			this.ChaLbl.TabIndex = 15;
			this.ChaLbl.Text = "Charisma:";
			// 
			// WisModBox
			// 
			this.WisModBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.WisModBox.Location = new System.Drawing.Point(209, 116);
			this.WisModBox.Name = "WisModBox";
			this.WisModBox.ReadOnly = true;
			this.WisModBox.Size = new System.Drawing.Size(96, 20);
			this.WisModBox.TabIndex = 14;
			this.WisModBox.TabStop = false;
			this.WisModBox.Text = "[wis]";
			this.WisModBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// WisBox
			// 
			this.WisBox.Location = new System.Drawing.Point(83, 116);
			this.WisBox.Name = "WisBox";
			this.WisBox.Size = new System.Drawing.Size(120, 20);
			this.WisBox.TabIndex = 13;
			this.WisBox.ValueChanged += new System.EventHandler(this.StrBox_ValueChanged);
			// 
			// WisLbl
			// 
			this.WisLbl.AutoSize = true;
			this.WisLbl.Location = new System.Drawing.Point(12, 119);
			this.WisLbl.Name = "WisLbl";
			this.WisLbl.Size = new System.Drawing.Size(48, 13);
			this.WisLbl.TabIndex = 12;
			this.WisLbl.Text = "Wisdom:";
			// 
			// IntModBox
			// 
			this.IntModBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.IntModBox.Location = new System.Drawing.Point(209, 90);
			this.IntModBox.Name = "IntModBox";
			this.IntModBox.ReadOnly = true;
			this.IntModBox.Size = new System.Drawing.Size(96, 20);
			this.IntModBox.TabIndex = 11;
			this.IntModBox.TabStop = false;
			this.IntModBox.Text = "[int]";
			this.IntModBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// IntBox
			// 
			this.IntBox.Location = new System.Drawing.Point(83, 90);
			this.IntBox.Name = "IntBox";
			this.IntBox.Size = new System.Drawing.Size(120, 20);
			this.IntBox.TabIndex = 10;
			this.IntBox.ValueChanged += new System.EventHandler(this.StrBox_ValueChanged);
			// 
			// ConLbl
			// 
			this.ConLbl.AutoSize = true;
			this.ConLbl.Location = new System.Drawing.Point(12, 41);
			this.ConLbl.Name = "ConLbl";
			this.ConLbl.Size = new System.Drawing.Size(65, 13);
			this.ConLbl.TabIndex = 3;
			this.ConLbl.Text = "Constitution:";
			// 
			// IntLbl
			// 
			this.IntLbl.AutoSize = true;
			this.IntLbl.Location = new System.Drawing.Point(12, 93);
			this.IntLbl.Name = "IntLbl";
			this.IntLbl.Size = new System.Drawing.Size(64, 13);
			this.IntLbl.TabIndex = 9;
			this.IntLbl.Text = "Intelligence:";
			// 
			// DexModBox
			// 
			this.DexModBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DexModBox.Location = new System.Drawing.Point(209, 64);
			this.DexModBox.Name = "DexModBox";
			this.DexModBox.ReadOnly = true;
			this.DexModBox.Size = new System.Drawing.Size(96, 20);
			this.DexModBox.TabIndex = 8;
			this.DexModBox.TabStop = false;
			this.DexModBox.Text = "[dex]";
			this.DexModBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// DexBox
			// 
			this.DexBox.Location = new System.Drawing.Point(83, 64);
			this.DexBox.Name = "DexBox";
			this.DexBox.Size = new System.Drawing.Size(120, 20);
			this.DexBox.TabIndex = 7;
			this.DexBox.ValueChanged += new System.EventHandler(this.StrBox_ValueChanged);
			// 
			// ConBox
			// 
			this.ConBox.Location = new System.Drawing.Point(83, 38);
			this.ConBox.Name = "ConBox";
			this.ConBox.Size = new System.Drawing.Size(120, 20);
			this.ConBox.TabIndex = 4;
			this.ConBox.ValueChanged += new System.EventHandler(this.StrBox_ValueChanged);
			// 
			// DexLbl
			// 
			this.DexLbl.AutoSize = true;
			this.DexLbl.Location = new System.Drawing.Point(12, 67);
			this.DexLbl.Name = "DexLbl";
			this.DexLbl.Size = new System.Drawing.Size(51, 13);
			this.DexLbl.TabIndex = 6;
			this.DexLbl.Text = "Dexterity:";
			// 
			// ConModBox
			// 
			this.ConModBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ConModBox.Location = new System.Drawing.Point(209, 38);
			this.ConModBox.Name = "ConModBox";
			this.ConModBox.ReadOnly = true;
			this.ConModBox.Size = new System.Drawing.Size(96, 20);
			this.ConModBox.TabIndex = 5;
			this.ConModBox.TabStop = false;
			this.ConModBox.Text = "[con]";
			this.ConModBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// CreatureAbilityForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(317, 216);
			this.Controls.Add(this.StrModBox);
			this.Controls.Add(this.StrBox);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.ChaModBox);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.ChaBox);
			this.Controls.Add(this.StrLbl);
			this.Controls.Add(this.ConModBox);
			this.Controls.Add(this.ChaLbl);
			this.Controls.Add(this.DexLbl);
			this.Controls.Add(this.WisModBox);
			this.Controls.Add(this.ConBox);
			this.Controls.Add(this.WisBox);
			this.Controls.Add(this.DexBox);
			this.Controls.Add(this.WisLbl);
			this.Controls.Add(this.DexModBox);
			this.Controls.Add(this.IntModBox);
			this.Controls.Add(this.IntLbl);
			this.Controls.Add(this.IntBox);
			this.Controls.Add(this.ConLbl);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CreatureAbilityForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Ability Scores";
			((System.ComponentModel.ISupportInitialize)(this.StrBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ChaBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.WisBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.IntBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DexBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ConBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.TextBox StrModBox;
		private System.Windows.Forms.NumericUpDown StrBox;
		private System.Windows.Forms.TextBox ChaModBox;
		private System.Windows.Forms.NumericUpDown ChaBox;
		private System.Windows.Forms.Label StrLbl;
		private System.Windows.Forms.Label ChaLbl;
		private System.Windows.Forms.TextBox WisModBox;
		private System.Windows.Forms.NumericUpDown WisBox;
		private System.Windows.Forms.Label WisLbl;
		private System.Windows.Forms.TextBox IntModBox;
		private System.Windows.Forms.NumericUpDown IntBox;
		private System.Windows.Forms.Label ConLbl;
		private System.Windows.Forms.Label IntLbl;
		private System.Windows.Forms.TextBox DexModBox;
		private System.Windows.Forms.NumericUpDown DexBox;
		private System.Windows.Forms.NumericUpDown ConBox;
		private System.Windows.Forms.Label DexLbl;
		private System.Windows.Forms.TextBox ConModBox;
	}
}