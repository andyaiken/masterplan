namespace Masterplan.UI
{
	partial class InitiativeForm
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
			this.InitLbl = new System.Windows.Forms.Label();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.InitBox = new System.Windows.Forms.NumericUpDown();
			this.BonusLbl = new System.Windows.Forms.Label();
			this.BonusValueLbl = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.InitBox)).BeginInit();
			this.SuspendLayout();
			// 
			// InitLbl
			// 
			this.InitLbl.AutoSize = true;
			this.InitLbl.Location = new System.Drawing.Point(12, 36);
			this.InitLbl.Name = "InitLbl";
			this.InitLbl.Size = new System.Drawing.Size(38, 13);
			this.InitLbl.TabIndex = 2;
			this.InitLbl.Text = "Score:";
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(79, 69);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 4;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(160, 69);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 5;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// InitBox
			// 
			this.InitBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.InitBox.Location = new System.Drawing.Point(61, 34);
			this.InitBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.InitBox.Name = "InitBox";
			this.InitBox.Size = new System.Drawing.Size(174, 20);
			this.InitBox.TabIndex = 3;
			// 
			// BonusLbl
			// 
			this.BonusLbl.AutoSize = true;
			this.BonusLbl.Location = new System.Drawing.Point(12, 9);
			this.BonusLbl.Name = "BonusLbl";
			this.BonusLbl.Size = new System.Drawing.Size(40, 13);
			this.BonusLbl.TabIndex = 0;
			this.BonusLbl.Text = "Bonus:";
			// 
			// BonusValueLbl
			// 
			this.BonusValueLbl.AutoSize = true;
			this.BonusValueLbl.Location = new System.Drawing.Point(58, 9);
			this.BonusValueLbl.Name = "BonusValueLbl";
			this.BonusValueLbl.Size = new System.Drawing.Size(58, 13);
			this.BonusValueLbl.TabIndex = 1;
			this.BonusValueLbl.Text = "[init bonus]";
			// 
			// InitiativeForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(247, 104);
			this.Controls.Add(this.BonusValueLbl);
			this.Controls.Add(this.BonusLbl);
			this.Controls.Add(this.InitBox);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.InitLbl);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "InitiativeForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Initiative";
			this.Shown += new System.EventHandler(this.InitiativeForm_Shown);
			((System.ComponentModel.ISupportInitialize)(this.InitBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label InitLbl;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.NumericUpDown InitBox;
		private System.Windows.Forms.Label BonusLbl;
		private System.Windows.Forms.Label BonusValueLbl;
	}
}