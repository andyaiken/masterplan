namespace Masterplan.UI
{
	partial class TileSizeForm
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
			this.WidthLbl = new System.Windows.Forms.Label();
			this.WidthBox = new System.Windows.Forms.NumericUpDown();
			this.HeightLbl = new System.Windows.Forms.Label();
			this.HeightBox = new System.Windows.Forms.NumericUpDown();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.WidthBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.HeightBox)).BeginInit();
			this.SuspendLayout();
			// 
			// WidthLbl
			// 
			this.WidthLbl.AutoSize = true;
			this.WidthLbl.Location = new System.Drawing.Point(12, 14);
			this.WidthLbl.Name = "WidthLbl";
			this.WidthLbl.Size = new System.Drawing.Size(58, 13);
			this.WidthLbl.TabIndex = 0;
			this.WidthLbl.Text = "Tile Width:";
			// 
			// WidthBox
			// 
			this.WidthBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.WidthBox.Location = new System.Drawing.Point(79, 12);
			this.WidthBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.WidthBox.Name = "WidthBox";
			this.WidthBox.Size = new System.Drawing.Size(175, 20);
			this.WidthBox.TabIndex = 1;
			this.WidthBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// HeightLbl
			// 
			this.HeightLbl.AutoSize = true;
			this.HeightLbl.Location = new System.Drawing.Point(12, 40);
			this.HeightLbl.Name = "HeightLbl";
			this.HeightLbl.Size = new System.Drawing.Size(61, 13);
			this.HeightLbl.TabIndex = 2;
			this.HeightLbl.Text = "Tile Height:";
			// 
			// HeightBox
			// 
			this.HeightBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.HeightBox.Location = new System.Drawing.Point(79, 38);
			this.HeightBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.HeightBox.Name = "HeightBox";
			this.HeightBox.Size = new System.Drawing.Size(175, 20);
			this.HeightBox.TabIndex = 3;
			this.HeightBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(98, 77);
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
			this.CancelBtn.Location = new System.Drawing.Point(179, 77);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 5;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// TileSizeForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(266, 112);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.HeightBox);
			this.Controls.Add(this.HeightLbl);
			this.Controls.Add(this.WidthBox);
			this.Controls.Add(this.WidthLbl);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TileSizeForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Tile Size";
			((System.ComponentModel.ISupportInitialize)(this.WidthBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.HeightBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label WidthLbl;
		private System.Windows.Forms.NumericUpDown WidthBox;
		private System.Windows.Forms.Label HeightLbl;
		private System.Windows.Forms.NumericUpDown HeightBox;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
	}
}