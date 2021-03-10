namespace Masterplan.Wizards
{
	partial class MapAreasPage
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
			this.MaxInfoLbl = new System.Windows.Forms.Label();
			this.MaxAreasLbl = new System.Windows.Forms.Label();
			this.MaxAreasBox = new System.Windows.Forms.NumericUpDown();
			this.MinAreasBox = new System.Windows.Forms.NumericUpDown();
			this.MinAreasLbl = new System.Windows.Forms.Label();
			this.MinInfoLbl = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.MaxAreasBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MinAreasBox)).BeginInit();
			this.SuspendLayout();
			// 
			// MaxInfoLbl
			// 
			this.MaxInfoLbl.Dock = System.Windows.Forms.DockStyle.Top;
			this.MaxInfoLbl.Location = new System.Drawing.Point(0, 0);
			this.MaxInfoLbl.Name = "MaxInfoLbl";
			this.MaxInfoLbl.Size = new System.Drawing.Size(307, 40);
			this.MaxInfoLbl.TabIndex = 0;
			this.MaxInfoLbl.Text = "How many areas do you want in your map? The map builder will try to generate a ma" +
				"p with this number of areas.";
			// 
			// MaxAreasLbl
			// 
			this.MaxAreasLbl.AutoSize = true;
			this.MaxAreasLbl.Location = new System.Drawing.Point(3, 42);
			this.MaxAreasLbl.Name = "MaxAreasLbl";
			this.MaxAreasLbl.Size = new System.Drawing.Size(46, 13);
			this.MaxAreasLbl.TabIndex = 1;
			this.MaxAreasLbl.Text = "At Most:";
			// 
			// MaxAreasBox
			// 
			this.MaxAreasBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.MaxAreasBox.Location = new System.Drawing.Point(58, 40);
			this.MaxAreasBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.MaxAreasBox.Name = "MaxAreasBox";
			this.MaxAreasBox.Size = new System.Drawing.Size(246, 20);
			this.MaxAreasBox.TabIndex = 2;
			this.MaxAreasBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.MaxAreasBox.ValueChanged += new System.EventHandler(this.MaxAreasBox_ValueChanged);
			// 
			// MinAreasBox
			// 
			this.MinAreasBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.MinAreasBox.Location = new System.Drawing.Point(58, 113);
			this.MinAreasBox.Name = "MinAreasBox";
			this.MinAreasBox.Size = new System.Drawing.Size(246, 20);
			this.MinAreasBox.TabIndex = 5;
			this.MinAreasBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// MinAreasLbl
			// 
			this.MinAreasLbl.AutoSize = true;
			this.MinAreasLbl.Location = new System.Drawing.Point(3, 115);
			this.MinAreasLbl.Name = "MinAreasLbl";
			this.MinAreasLbl.Size = new System.Drawing.Size(49, 13);
			this.MinAreasLbl.TabIndex = 4;
			this.MinAreasLbl.Text = "At Least:";
			// 
			// MinInfoLbl
			// 
			this.MinInfoLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.MinInfoLbl.Location = new System.Drawing.Point(0, 84);
			this.MinInfoLbl.Name = "MinInfoLbl";
			this.MinInfoLbl.Size = new System.Drawing.Size(307, 26);
			this.MinInfoLbl.TabIndex = 3;
			this.MinInfoLbl.Text = "The map will be rebuilt if it has fewer than this number of areas:";
			// 
			// MapAreasPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.MinInfoLbl);
			this.Controls.Add(this.MinAreasBox);
			this.Controls.Add(this.MinAreasLbl);
			this.Controls.Add(this.MaxAreasBox);
			this.Controls.Add(this.MaxAreasLbl);
			this.Controls.Add(this.MaxInfoLbl);
			this.Name = "MapAreasPage";
			this.Size = new System.Drawing.Size(307, 151);
			((System.ComponentModel.ISupportInitialize)(this.MaxAreasBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MinAreasBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label MaxInfoLbl;
		private System.Windows.Forms.Label MaxAreasLbl;
		private System.Windows.Forms.NumericUpDown MaxAreasBox;
		private System.Windows.Forms.NumericUpDown MinAreasBox;
		private System.Windows.Forms.Label MinAreasLbl;
		private System.Windows.Forms.Label MinInfoLbl;
	}
}
