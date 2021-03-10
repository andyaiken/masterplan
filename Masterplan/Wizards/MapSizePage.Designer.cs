namespace Masterplan.Wizards
{
	partial class MapSizePage
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.InfoLbl = new System.Windows.Forms.Label();
			this.HeightBox = new System.Windows.Forms.NumericUpDown();
			this.HeightLbl = new System.Windows.Forms.Label();
			this.WidthBox = new System.Windows.Forms.NumericUpDown();
			this.WidthLbl = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.HeightBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.WidthBox)).BeginInit();
			this.SuspendLayout();
			// 
			// InfoLbl
			// 
			this.InfoLbl.Dock = System.Windows.Forms.DockStyle.Top;
			this.InfoLbl.Location = new System.Drawing.Point(0, 0);
			this.InfoLbl.Name = "InfoLbl";
			this.InfoLbl.Size = new System.Drawing.Size(307, 40);
			this.InfoLbl.TabIndex = 0;
			this.InfoLbl.Text = "What size of map would you like to build?";
			// 
			// HeightBox
			// 
			this.HeightBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.HeightBox.Location = new System.Drawing.Point(58, 66);
			this.HeightBox.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.HeightBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.HeightBox.Name = "HeightBox";
			this.HeightBox.Size = new System.Drawing.Size(246, 20);
			this.HeightBox.TabIndex = 10;
			this.HeightBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// HeightLbl
			// 
			this.HeightLbl.AutoSize = true;
			this.HeightLbl.Location = new System.Drawing.Point(3, 68);
			this.HeightLbl.Name = "HeightLbl";
			this.HeightLbl.Size = new System.Drawing.Size(41, 13);
			this.HeightLbl.TabIndex = 9;
			this.HeightLbl.Text = "Height:";
			// 
			// WidthBox
			// 
			this.WidthBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.WidthBox.Location = new System.Drawing.Point(58, 40);
			this.WidthBox.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.WidthBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.WidthBox.Name = "WidthBox";
			this.WidthBox.Size = new System.Drawing.Size(246, 20);
			this.WidthBox.TabIndex = 7;
			this.WidthBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// WidthLbl
			// 
			this.WidthLbl.AutoSize = true;
			this.WidthLbl.Location = new System.Drawing.Point(3, 42);
			this.WidthLbl.Name = "WidthLbl";
			this.WidthLbl.Size = new System.Drawing.Size(38, 13);
			this.WidthLbl.TabIndex = 6;
			this.WidthLbl.Text = "Width:";
			// 
			// MapSizePage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.HeightBox);
			this.Controls.Add(this.HeightLbl);
			this.Controls.Add(this.WidthBox);
			this.Controls.Add(this.WidthLbl);
			this.Controls.Add(this.InfoLbl);
			this.Name = "MapSizePage";
			this.Size = new System.Drawing.Size(307, 114);
			((System.ComponentModel.ISupportInitialize)(this.HeightBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.WidthBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label InfoLbl;
		private System.Windows.Forms.NumericUpDown HeightBox;
		private System.Windows.Forms.Label HeightLbl;
		private System.Windows.Forms.NumericUpDown WidthBox;
		private System.Windows.Forms.Label WidthLbl;
	}
}
