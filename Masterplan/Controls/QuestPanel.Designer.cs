namespace Masterplan.Controls
{
	partial class QuestPanel
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
			this.TypeLbl = new System.Windows.Forms.Label();
			this.TypeBox = new System.Windows.Forms.ComboBox();
			this.LevelLbl = new System.Windows.Forms.Label();
			this.LevelBox = new System.Windows.Forms.NumericUpDown();
			this.XPLbl = new System.Windows.Forms.Label();
			this.XPBox = new System.Windows.Forms.TextBox();
			this.XPSlider = new System.Windows.Forms.TrackBar();
			this.MinorPnl = new System.Windows.Forms.Panel();
			this.MinMaxLbl = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.LevelBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.XPSlider)).BeginInit();
			this.MinorPnl.SuspendLayout();
			this.SuspendLayout();
			// 
			// TypeLbl
			// 
			this.TypeLbl.AutoSize = true;
			this.TypeLbl.Location = new System.Drawing.Point(3, 6);
			this.TypeLbl.Name = "TypeLbl";
			this.TypeLbl.Size = new System.Drawing.Size(65, 13);
			this.TypeLbl.TabIndex = 0;
			this.TypeLbl.Text = "Quest Type:";
			// 
			// TypeBox
			// 
			this.TypeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TypeBox.FormattingEnabled = true;
			this.TypeBox.Location = new System.Drawing.Point(74, 3);
			this.TypeBox.Name = "TypeBox";
			this.TypeBox.Size = new System.Drawing.Size(195, 21);
			this.TypeBox.TabIndex = 1;
			this.TypeBox.SelectedIndexChanged += new System.EventHandler(this.TypeBox_SelectedIndexChanged);
			// 
			// LevelLbl
			// 
			this.LevelLbl.AutoSize = true;
			this.LevelLbl.Location = new System.Drawing.Point(3, 32);
			this.LevelLbl.Name = "LevelLbl";
			this.LevelLbl.Size = new System.Drawing.Size(36, 13);
			this.LevelLbl.TabIndex = 2;
			this.LevelLbl.Text = "Level:";
			// 
			// LevelBox
			// 
			this.LevelBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.LevelBox.Location = new System.Drawing.Point(74, 30);
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
			this.LevelBox.Size = new System.Drawing.Size(195, 20);
			this.LevelBox.TabIndex = 3;
			this.LevelBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.LevelBox.ValueChanged += new System.EventHandler(this.LevelBox_ValueChanged);
			// 
			// XPLbl
			// 
			this.XPLbl.AutoSize = true;
			this.XPLbl.Location = new System.Drawing.Point(3, 59);
			this.XPLbl.Name = "XPLbl";
			this.XPLbl.Size = new System.Drawing.Size(54, 13);
			this.XPLbl.TabIndex = 4;
			this.XPLbl.Text = "XP Value:";
			// 
			// XPBox
			// 
			this.XPBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.XPBox.Location = new System.Drawing.Point(74, 56);
			this.XPBox.Name = "XPBox";
			this.XPBox.ReadOnly = true;
			this.XPBox.Size = new System.Drawing.Size(195, 20);
			this.XPBox.TabIndex = 5;
			// 
			// XPSlider
			// 
			this.XPSlider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.XPSlider.LargeChange = 100;
			this.XPSlider.Location = new System.Drawing.Point(3, 4);
			this.XPSlider.Maximum = 100;
			this.XPSlider.Name = "XPSlider";
			this.XPSlider.Size = new System.Drawing.Size(190, 45);
			this.XPSlider.SmallChange = 50;
			this.XPSlider.TabIndex = 6;
			this.XPSlider.TickFrequency = 50;
			this.XPSlider.Scroll += new System.EventHandler(this.XPSlider_Scroll);
			// 
			// MinorPnl
			// 
			this.MinorPnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.MinorPnl.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.MinorPnl.Controls.Add(this.MinMaxLbl);
			this.MinorPnl.Controls.Add(this.XPSlider);
			this.MinorPnl.Location = new System.Drawing.Point(74, 82);
			this.MinorPnl.Name = "MinorPnl";
			this.MinorPnl.Size = new System.Drawing.Size(195, 73);
			this.MinorPnl.TabIndex = 7;
			// 
			// MinMaxLbl
			// 
			this.MinMaxLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.MinMaxLbl.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.MinMaxLbl.Location = new System.Drawing.Point(3, 52);
			this.MinMaxLbl.Name = "MinMaxLbl";
			this.MinMaxLbl.Size = new System.Drawing.Size(189, 13);
			this.MinMaxLbl.TabIndex = 7;
			this.MinMaxLbl.Text = "[min] - [max]";
			this.MinMaxLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// QuestPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.MinorPnl);
			this.Controls.Add(this.XPBox);
			this.Controls.Add(this.XPLbl);
			this.Controls.Add(this.LevelBox);
			this.Controls.Add(this.LevelLbl);
			this.Controls.Add(this.TypeBox);
			this.Controls.Add(this.TypeLbl);
			this.Name = "QuestPanel";
			this.Size = new System.Drawing.Size(272, 160);
			((System.ComponentModel.ISupportInitialize)(this.LevelBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.XPSlider)).EndInit();
			this.MinorPnl.ResumeLayout(false);
			this.MinorPnl.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label TypeLbl;
		private System.Windows.Forms.ComboBox TypeBox;
		private System.Windows.Forms.Label LevelLbl;
		private System.Windows.Forms.NumericUpDown LevelBox;
		private System.Windows.Forms.Label XPLbl;
		private System.Windows.Forms.TextBox XPBox;
		private System.Windows.Forms.TrackBar XPSlider;
		private System.Windows.Forms.Panel MinorPnl;
		private System.Windows.Forms.Label MinMaxLbl;
	}
}
