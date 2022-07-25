namespace Masterplan.UI
{
	partial class PartyForm
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
			this.SizeLbl = new System.Windows.Forms.Label();
			this.SizeBox = new System.Windows.Forms.NumericUpDown();
			this.LevelLbl = new System.Windows.Forms.Label();
			this.LevelBox = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.SizeBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LevelBox)).BeginInit();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(108, 75);
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
			this.CancelBtn.Location = new System.Drawing.Point(189, 75);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 5;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// SizeLbl
			// 
			this.SizeLbl.AutoSize = true;
			this.SizeLbl.Location = new System.Drawing.Point(12, 14);
			this.SizeLbl.Name = "SizeLbl";
			this.SizeLbl.Size = new System.Drawing.Size(57, 13);
			this.SizeLbl.TabIndex = 0;
			this.SizeLbl.Text = "Party Size:";
			// 
			// SizeBox
			// 
			this.SizeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.SizeBox.Location = new System.Drawing.Point(81, 12);
			this.SizeBox.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.SizeBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.SizeBox.Name = "SizeBox";
			this.SizeBox.Size = new System.Drawing.Size(183, 20);
			this.SizeBox.TabIndex = 1;
			this.SizeBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// LevelLbl
			// 
			this.LevelLbl.AutoSize = true;
			this.LevelLbl.Location = new System.Drawing.Point(12, 40);
			this.LevelLbl.Name = "LevelLbl";
			this.LevelLbl.Size = new System.Drawing.Size(63, 13);
			this.LevelLbl.TabIndex = 2;
			this.LevelLbl.Text = "Party Level:";
			// 
			// LevelBox
			// 
			this.LevelBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.LevelBox.Location = new System.Drawing.Point(81, 38);
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
			this.LevelBox.Size = new System.Drawing.Size(183, 20);
			this.LevelBox.TabIndex = 3;
			this.LevelBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// PartyForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(276, 110);
			this.Controls.Add(this.LevelBox);
			this.Controls.Add(this.LevelLbl);
			this.Controls.Add(this.SizeBox);
			this.Controls.Add(this.SizeLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PartyForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Party";
			((System.ComponentModel.ISupportInitialize)(this.SizeBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LevelBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label SizeLbl;
		private System.Windows.Forms.NumericUpDown SizeBox;
		private System.Windows.Forms.Label LevelLbl;
		private System.Windows.Forms.NumericUpDown LevelBox;
	}
}