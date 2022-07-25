namespace Masterplan.UI
{
	partial class CreatureTemplateStatsForm
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
			this.WillBox = new System.Windows.Forms.NumericUpDown();
			this.WillLbl = new System.Windows.Forms.Label();
			this.RefBox = new System.Windows.Forms.NumericUpDown();
			this.RefLbl = new System.Windows.Forms.Label();
			this.FortBox = new System.Windows.Forms.NumericUpDown();
			this.FortLbl = new System.Windows.Forms.Label();
			this.ACBox = new System.Windows.Forms.NumericUpDown();
			this.ACLbl = new System.Windows.Forms.Label();
			this.HPBox = new System.Windows.Forms.NumericUpDown();
			this.HPLbl = new System.Windows.Forms.Label();
			this.InitBox = new System.Windows.Forms.NumericUpDown();
			this.InitLbl = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.WillBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RefBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.FortBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ACBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.HPBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.InitBox)).BeginInit();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(84, 193);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 14;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(165, 193);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 15;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// WillBox
			// 
			this.WillBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.WillBox.Location = new System.Drawing.Point(76, 156);
			this.WillBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.WillBox.Name = "WillBox";
			this.WillBox.Size = new System.Drawing.Size(164, 20);
			this.WillBox.TabIndex = 11;
			// 
			// WillLbl
			// 
			this.WillLbl.AutoSize = true;
			this.WillLbl.Location = new System.Drawing.Point(12, 158);
			this.WillLbl.Name = "WillLbl";
			this.WillLbl.Size = new System.Drawing.Size(27, 13);
			this.WillLbl.TabIndex = 10;
			this.WillLbl.Text = "Will:";
			// 
			// RefBox
			// 
			this.RefBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.RefBox.Location = new System.Drawing.Point(76, 130);
			this.RefBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.RefBox.Name = "RefBox";
			this.RefBox.Size = new System.Drawing.Size(164, 20);
			this.RefBox.TabIndex = 9;
			// 
			// RefLbl
			// 
			this.RefLbl.AutoSize = true;
			this.RefLbl.Location = new System.Drawing.Point(12, 132);
			this.RefLbl.Name = "RefLbl";
			this.RefLbl.Size = new System.Drawing.Size(37, 13);
			this.RefLbl.TabIndex = 8;
			this.RefLbl.Text = "Reflex";
			// 
			// FortBox
			// 
			this.FortBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.FortBox.Location = new System.Drawing.Point(76, 104);
			this.FortBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.FortBox.Name = "FortBox";
			this.FortBox.Size = new System.Drawing.Size(164, 20);
			this.FortBox.TabIndex = 7;
			// 
			// FortLbl
			// 
			this.FortLbl.AutoSize = true;
			this.FortLbl.Location = new System.Drawing.Point(12, 106);
			this.FortLbl.Name = "FortLbl";
			this.FortLbl.Size = new System.Drawing.Size(51, 13);
			this.FortLbl.TabIndex = 6;
			this.FortLbl.Text = "Fortitude:";
			// 
			// ACBox
			// 
			this.ACBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ACBox.Location = new System.Drawing.Point(76, 78);
			this.ACBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.ACBox.Name = "ACBox";
			this.ACBox.Size = new System.Drawing.Size(164, 20);
			this.ACBox.TabIndex = 5;
			// 
			// ACLbl
			// 
			this.ACLbl.AutoSize = true;
			this.ACLbl.Location = new System.Drawing.Point(12, 80);
			this.ACLbl.Name = "ACLbl";
			this.ACLbl.Size = new System.Drawing.Size(24, 13);
			this.ACLbl.TabIndex = 4;
			this.ACLbl.Text = "AC:";
			// 
			// HPBox
			// 
			this.HPBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.HPBox.Location = new System.Drawing.Point(76, 12);
			this.HPBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.HPBox.Name = "HPBox";
			this.HPBox.Size = new System.Drawing.Size(164, 20);
			this.HPBox.TabIndex = 1;
			// 
			// HPLbl
			// 
			this.HPLbl.AutoSize = true;
			this.HPLbl.Location = new System.Drawing.Point(12, 14);
			this.HPLbl.Name = "HPLbl";
			this.HPLbl.Size = new System.Drawing.Size(58, 13);
			this.HPLbl.TabIndex = 0;
			this.HPLbl.Text = "HP / level:";
			// 
			// InitBox
			// 
			this.InitBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.InitBox.Location = new System.Drawing.Point(76, 38);
			this.InitBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.InitBox.Name = "InitBox";
			this.InitBox.Size = new System.Drawing.Size(164, 20);
			this.InitBox.TabIndex = 3;
			// 
			// InitLbl
			// 
			this.InitLbl.AutoSize = true;
			this.InitLbl.Location = new System.Drawing.Point(12, 40);
			this.InitLbl.Name = "InitLbl";
			this.InitLbl.Size = new System.Drawing.Size(49, 13);
			this.InitLbl.TabIndex = 2;
			this.InitLbl.Text = "Initiative:";
			// 
			// CreatureTemplateStatsForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(252, 228);
			this.Controls.Add(this.HPBox);
			this.Controls.Add(this.InitLbl);
			this.Controls.Add(this.InitBox);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.WillLbl);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.ACBox);
			this.Controls.Add(this.HPLbl);
			this.Controls.Add(this.RefLbl);
			this.Controls.Add(this.RefBox);
			this.Controls.Add(this.FortBox);
			this.Controls.Add(this.ACLbl);
			this.Controls.Add(this.FortLbl);
			this.Controls.Add(this.WillBox);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CreatureTemplateStatsForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Combat Stats";
			((System.ComponentModel.ISupportInitialize)(this.WillBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RefBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.FortBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ACBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.HPBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.InitBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.NumericUpDown WillBox;
		private System.Windows.Forms.Label WillLbl;
		private System.Windows.Forms.NumericUpDown RefBox;
		private System.Windows.Forms.Label RefLbl;
		private System.Windows.Forms.NumericUpDown FortBox;
		private System.Windows.Forms.Label FortLbl;
		private System.Windows.Forms.NumericUpDown ACBox;
		private System.Windows.Forms.Label ACLbl;
		private System.Windows.Forms.NumericUpDown HPBox;
		private System.Windows.Forms.Label HPLbl;
		private System.Windows.Forms.NumericUpDown InitBox;
		private System.Windows.Forms.Label InitLbl;
	}
}