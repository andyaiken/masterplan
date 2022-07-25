namespace Masterplan.UI
{
	partial class SatelliteForm
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
			this.NameLbl = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.PeriodLbl = new System.Windows.Forms.Label();
			this.PeriodBox = new System.Windows.Forms.NumericUpDown();
			this.OffsetBox = new System.Windows.Forms.NumericUpDown();
			this.OffsetLbl = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.PeriodBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.OffsetBox)).BeginInit();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(97, 100);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 6;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(178, 100);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 7;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// NameLbl
			// 
			this.NameLbl.AutoSize = true;
			this.NameLbl.Location = new System.Drawing.Point(12, 15);
			this.NameLbl.Name = "NameLbl";
			this.NameLbl.Size = new System.Drawing.Size(38, 13);
			this.NameLbl.TabIndex = 0;
			this.NameLbl.Text = "Name:";
			// 
			// NameBox
			// 
			this.NameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.NameBox.Location = new System.Drawing.Point(58, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(195, 20);
			this.NameBox.TabIndex = 1;
			// 
			// PeriodLbl
			// 
			this.PeriodLbl.AutoSize = true;
			this.PeriodLbl.Location = new System.Drawing.Point(12, 40);
			this.PeriodLbl.Name = "PeriodLbl";
			this.PeriodLbl.Size = new System.Drawing.Size(40, 13);
			this.PeriodLbl.TabIndex = 2;
			this.PeriodLbl.Text = "Period:";
			// 
			// PeriodBox
			// 
			this.PeriodBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.PeriodBox.Location = new System.Drawing.Point(58, 38);
			this.PeriodBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.PeriodBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.PeriodBox.Name = "PeriodBox";
			this.PeriodBox.Size = new System.Drawing.Size(195, 20);
			this.PeriodBox.TabIndex = 3;
			this.PeriodBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// OffsetBox
			// 
			this.OffsetBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.OffsetBox.Location = new System.Drawing.Point(58, 64);
			this.OffsetBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.OffsetBox.Name = "OffsetBox";
			this.OffsetBox.Size = new System.Drawing.Size(195, 20);
			this.OffsetBox.TabIndex = 5;
			// 
			// OffsetLbl
			// 
			this.OffsetLbl.AutoSize = true;
			this.OffsetLbl.Location = new System.Drawing.Point(12, 66);
			this.OffsetLbl.Name = "OffsetLbl";
			this.OffsetLbl.Size = new System.Drawing.Size(38, 13);
			this.OffsetLbl.TabIndex = 4;
			this.OffsetLbl.Text = "Offset:";
			// 
			// SatelliteForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(265, 135);
			this.Controls.Add(this.OffsetBox);
			this.Controls.Add(this.OffsetLbl);
			this.Controls.Add(this.PeriodBox);
			this.Controls.Add(this.PeriodLbl);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SatelliteForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Satellite";
			((System.ComponentModel.ISupportInitialize)(this.PeriodBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.OffsetBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label NameLbl;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.Label PeriodLbl;
		private System.Windows.Forms.NumericUpDown PeriodBox;
		private System.Windows.Forms.NumericUpDown OffsetBox;
		private System.Windows.Forms.Label OffsetLbl;
	}
}