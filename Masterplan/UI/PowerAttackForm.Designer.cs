namespace Masterplan.UI
{
	partial class PowerAttackForm
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
			this.CancelBtn = new System.Windows.Forms.Button();
			this.OKBtn = new System.Windows.Forms.Button();
			this.BonusLbl = new System.Windows.Forms.Label();
			this.DefenceLbl = new System.Windows.Forms.Label();
			this.DefenceBox = new System.Windows.Forms.ComboBox();
			this.BonusBox = new System.Windows.Forms.NumericUpDown();
			this.InfoLbl = new System.Windows.Forms.Label();
			this.SuggestPnl = new System.Windows.Forms.Panel();
			this.SuggestBtn = new System.Windows.Forms.Button();
			this.SuggestLbl = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.BonusBox)).BeginInit();
			this.SuggestPnl.SuspendLayout();
			this.SuspendLayout();
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(222, 144);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 7;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(141, 144);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 6;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// BonusLbl
			// 
			this.BonusLbl.AutoSize = true;
			this.BonusLbl.Location = new System.Drawing.Point(12, 41);
			this.BonusLbl.Name = "BonusLbl";
			this.BonusLbl.Size = new System.Drawing.Size(37, 13);
			this.BonusLbl.TabIndex = 2;
			this.BonusLbl.Text = "Bonus";
			// 
			// DefenceLbl
			// 
			this.DefenceLbl.AutoSize = true;
			this.DefenceLbl.Location = new System.Drawing.Point(12, 15);
			this.DefenceLbl.Name = "DefenceLbl";
			this.DefenceLbl.Size = new System.Drawing.Size(48, 13);
			this.DefenceLbl.TabIndex = 0;
			this.DefenceLbl.Text = "Defence";
			// 
			// DefenceBox
			// 
			this.DefenceBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DefenceBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.DefenceBox.FormattingEnabled = true;
			this.DefenceBox.Location = new System.Drawing.Point(66, 12);
			this.DefenceBox.Name = "DefenceBox";
			this.DefenceBox.Size = new System.Drawing.Size(231, 21);
			this.DefenceBox.TabIndex = 1;
			this.DefenceBox.SelectedIndexChanged += new System.EventHandler(this.DefenceBox_SelectedIndexChanged);
			// 
			// BonusBox
			// 
			this.BonusBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.BonusBox.Location = new System.Drawing.Point(66, 39);
			this.BonusBox.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
			this.BonusBox.Name = "BonusBox";
			this.BonusBox.Size = new System.Drawing.Size(231, 20);
			this.BonusBox.TabIndex = 3;
			// 
			// InfoLbl
			// 
			this.InfoLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.InfoLbl.Location = new System.Drawing.Point(66, 97);
			this.InfoLbl.Name = "InfoLbl";
			this.InfoLbl.Size = new System.Drawing.Size(231, 44);
			this.InfoLbl.TabIndex = 5;
			this.InfoLbl.Text = "Note: Since this is a functional template power, the creature level will automati" +
				"cally be added to the attack bonus.";
			// 
			// SuggestPnl
			// 
			this.SuggestPnl.Controls.Add(this.SuggestBtn);
			this.SuggestPnl.Controls.Add(this.SuggestLbl);
			this.SuggestPnl.Location = new System.Drawing.Point(66, 65);
			this.SuggestPnl.Name = "SuggestPnl";
			this.SuggestPnl.Size = new System.Drawing.Size(231, 29);
			this.SuggestPnl.TabIndex = 4;
			// 
			// SuggestBtn
			// 
			this.SuggestBtn.Location = new System.Drawing.Point(135, 3);
			this.SuggestBtn.Name = "SuggestBtn";
			this.SuggestBtn.Size = new System.Drawing.Size(93, 23);
			this.SuggestBtn.TabIndex = 1;
			this.SuggestBtn.Text = "[+x]";
			this.SuggestBtn.UseVisualStyleBackColor = true;
			this.SuggestBtn.Click += new System.EventHandler(this.SuggestBtn_Click);
			// 
			// SuggestLbl
			// 
			this.SuggestLbl.AutoSize = true;
			this.SuggestLbl.Location = new System.Drawing.Point(3, 8);
			this.SuggestLbl.Name = "SuggestLbl";
			this.SuggestLbl.Size = new System.Drawing.Size(126, 13);
			this.SuggestLbl.TabIndex = 0;
			this.SuggestLbl.Text = "Suggested attack bonus:";
			// 
			// PowerAttackForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(309, 179);
			this.Controls.Add(this.SuggestPnl);
			this.Controls.Add(this.InfoLbl);
			this.Controls.Add(this.DefenceBox);
			this.Controls.Add(this.DefenceLbl);
			this.Controls.Add(this.BonusBox);
			this.Controls.Add(this.BonusLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PowerAttackForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Attack Details";
			((System.ComponentModel.ISupportInitialize)(this.BonusBox)).EndInit();
			this.SuggestPnl.ResumeLayout(false);
			this.SuggestPnl.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Label BonusLbl;
		private System.Windows.Forms.Label DefenceLbl;
		private System.Windows.Forms.ComboBox DefenceBox;
		private System.Windows.Forms.NumericUpDown BonusBox;
		private System.Windows.Forms.Label InfoLbl;
		private System.Windows.Forms.Panel SuggestPnl;
		private System.Windows.Forms.Button SuggestBtn;
		private System.Windows.Forms.Label SuggestLbl;
	}
}