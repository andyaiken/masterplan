namespace Masterplan.Controls
{
	partial class LevelRangePanel
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
			this.MinLbl = new System.Windows.Forms.Label();
			this.MinBox = new System.Windows.Forms.NumericUpDown();
			this.MaxLbl = new System.Windows.Forms.Label();
			this.MaxBox = new System.Windows.Forms.NumericUpDown();
			this.NameLbl = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.MinBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MaxBox)).BeginInit();
			this.SuspendLayout();
			// 
			// MinLbl
			// 
			this.MinLbl.AutoSize = true;
			this.MinLbl.Location = new System.Drawing.Point(3, 31);
			this.MinLbl.Name = "MinLbl";
			this.MinLbl.Size = new System.Drawing.Size(76, 13);
			this.MinLbl.TabIndex = 2;
			this.MinLbl.Text = "Minimum level:";
			// 
			// MinBox
			// 
			this.MinBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.MinBox.Location = new System.Drawing.Point(88, 29);
			this.MinBox.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
			this.MinBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.MinBox.Name = "MinBox";
			this.MinBox.Size = new System.Drawing.Size(273, 20);
			this.MinBox.TabIndex = 3;
			this.MinBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.MinBox.ValueChanged += new System.EventHandler(this.MinBox_ValueChanged);
			// 
			// MaxLbl
			// 
			this.MaxLbl.AutoSize = true;
			this.MaxLbl.Location = new System.Drawing.Point(3, 57);
			this.MaxLbl.Name = "MaxLbl";
			this.MaxLbl.Size = new System.Drawing.Size(79, 13);
			this.MaxLbl.TabIndex = 4;
			this.MaxLbl.Text = "Maximum level:";
			// 
			// MaxBox
			// 
			this.MaxBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.MaxBox.Location = new System.Drawing.Point(88, 55);
			this.MaxBox.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
			this.MaxBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.MaxBox.Name = "MaxBox";
			this.MaxBox.Size = new System.Drawing.Size(273, 20);
			this.MaxBox.TabIndex = 5;
			this.MaxBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.MaxBox.ValueChanged += new System.EventHandler(this.MaxBox_ValueChanged);
			// 
			// NameLbl
			// 
			this.NameLbl.AutoSize = true;
			this.NameLbl.Location = new System.Drawing.Point(3, 6);
			this.NameLbl.Name = "NameLbl";
			this.NameLbl.Size = new System.Drawing.Size(38, 13);
			this.NameLbl.TabIndex = 0;
			this.NameLbl.Text = "Name:";
			// 
			// NameBox
			// 
			this.NameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.NameBox.Location = new System.Drawing.Point(88, 3);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(273, 20);
			this.NameBox.TabIndex = 1;
			this.NameBox.TextChanged += new System.EventHandler(this.NameBox_TextChanged);
			// 
			// LevelRangePanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLbl);
			this.Controls.Add(this.MaxBox);
			this.Controls.Add(this.MaxLbl);
			this.Controls.Add(this.MinBox);
			this.Controls.Add(this.MinLbl);
			this.Name = "LevelRangePanel";
			this.Size = new System.Drawing.Size(364, 80);
			((System.ComponentModel.ISupportInitialize)(this.MinBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MaxBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label MinLbl;
		private System.Windows.Forms.NumericUpDown MinBox;
		private System.Windows.Forms.Label MaxLbl;
		private System.Windows.Forms.NumericUpDown MaxBox;
		private System.Windows.Forms.Label NameLbl;
		private System.Windows.Forms.TextBox NameBox;
	}
}
