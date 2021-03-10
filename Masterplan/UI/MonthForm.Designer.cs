namespace Masterplan.UI
{
	partial class MonthForm
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
			this.DaysLbl = new System.Windows.Forms.Label();
			this.DaysBox = new System.Windows.Forms.NumericUpDown();
			this.LeapModBox = new System.Windows.Forms.NumericUpDown();
			this.LeapModLbl = new System.Windows.Forms.Label();
			this.LeapPeriodBox = new System.Windows.Forms.NumericUpDown();
			this.LeapPeriodLbl = new System.Windows.Forms.Label();
			this.MonthGroup = new System.Windows.Forms.GroupBox();
			this.LeapGroup = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.DaysBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LeapModBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LeapPeriodBox)).BeginInit();
			this.MonthGroup.SuspendLayout();
			this.LeapGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(93, 194);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 2;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(174, 194);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 3;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// NameLbl
			// 
			this.NameLbl.AutoSize = true;
			this.NameLbl.Location = new System.Drawing.Point(6, 22);
			this.NameLbl.Name = "NameLbl";
			this.NameLbl.Size = new System.Drawing.Size(38, 13);
			this.NameLbl.TabIndex = 0;
			this.NameLbl.Text = "Name:";
			// 
			// NameBox
			// 
			this.NameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.NameBox.Location = new System.Drawing.Point(59, 19);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(172, 20);
			this.NameBox.TabIndex = 1;
			// 
			// DaysLbl
			// 
			this.DaysLbl.AutoSize = true;
			this.DaysLbl.Location = new System.Drawing.Point(6, 47);
			this.DaysLbl.Name = "DaysLbl";
			this.DaysLbl.Size = new System.Drawing.Size(34, 13);
			this.DaysLbl.TabIndex = 2;
			this.DaysLbl.Text = "Days:";
			// 
			// DaysBox
			// 
			this.DaysBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DaysBox.Location = new System.Drawing.Point(59, 45);
			this.DaysBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.DaysBox.Name = "DaysBox";
			this.DaysBox.Size = new System.Drawing.Size(172, 20);
			this.DaysBox.TabIndex = 3;
			this.DaysBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// LeapModBox
			// 
			this.LeapModBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.LeapModBox.Location = new System.Drawing.Point(59, 19);
			this.LeapModBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.LeapModBox.Name = "LeapModBox";
			this.LeapModBox.Size = new System.Drawing.Size(172, 20);
			this.LeapModBox.TabIndex = 1;
			// 
			// LeapModLbl
			// 
			this.LeapModLbl.AutoSize = true;
			this.LeapModLbl.Location = new System.Drawing.Point(6, 21);
			this.LeapModLbl.Name = "LeapModLbl";
			this.LeapModLbl.Size = new System.Drawing.Size(34, 13);
			this.LeapModLbl.TabIndex = 0;
			this.LeapModLbl.Text = "Days:";
			// 
			// LeapPeriodBox
			// 
			this.LeapPeriodBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.LeapPeriodBox.Location = new System.Drawing.Point(59, 45);
			this.LeapPeriodBox.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.LeapPeriodBox.Name = "LeapPeriodBox";
			this.LeapPeriodBox.Size = new System.Drawing.Size(172, 20);
			this.LeapPeriodBox.TabIndex = 3;
			this.LeapPeriodBox.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			// 
			// LeapPeriodLbl
			// 
			this.LeapPeriodLbl.AutoSize = true;
			this.LeapPeriodLbl.Location = new System.Drawing.Point(6, 47);
			this.LeapPeriodLbl.Name = "LeapPeriodLbl";
			this.LeapPeriodLbl.Size = new System.Drawing.Size(40, 13);
			this.LeapPeriodLbl.TabIndex = 2;
			this.LeapPeriodLbl.Text = "Period:";
			// 
			// MonthGroup
			// 
			this.MonthGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.MonthGroup.Controls.Add(this.NameBox);
			this.MonthGroup.Controls.Add(this.NameLbl);
			this.MonthGroup.Controls.Add(this.DaysLbl);
			this.MonthGroup.Controls.Add(this.DaysBox);
			this.MonthGroup.Location = new System.Drawing.Point(12, 12);
			this.MonthGroup.Name = "MonthGroup";
			this.MonthGroup.Size = new System.Drawing.Size(237, 83);
			this.MonthGroup.TabIndex = 0;
			this.MonthGroup.TabStop = false;
			this.MonthGroup.Text = "Month Info";
			// 
			// LeapGroup
			// 
			this.LeapGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.LeapGroup.Controls.Add(this.LeapPeriodBox);
			this.LeapGroup.Controls.Add(this.LeapModLbl);
			this.LeapGroup.Controls.Add(this.LeapModBox);
			this.LeapGroup.Controls.Add(this.LeapPeriodLbl);
			this.LeapGroup.Location = new System.Drawing.Point(12, 101);
			this.LeapGroup.Name = "LeapGroup";
			this.LeapGroup.Size = new System.Drawing.Size(237, 80);
			this.LeapGroup.TabIndex = 1;
			this.LeapGroup.TabStop = false;
			this.LeapGroup.Text = "Leap Years";
			// 
			// MonthForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(261, 229);
			this.Controls.Add(this.LeapGroup);
			this.Controls.Add(this.MonthGroup);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MonthForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Month";
			((System.ComponentModel.ISupportInitialize)(this.DaysBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LeapModBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LeapPeriodBox)).EndInit();
			this.MonthGroup.ResumeLayout(false);
			this.MonthGroup.PerformLayout();
			this.LeapGroup.ResumeLayout(false);
			this.LeapGroup.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label NameLbl;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.Label DaysLbl;
		private System.Windows.Forms.NumericUpDown DaysBox;
		private System.Windows.Forms.NumericUpDown LeapModBox;
		private System.Windows.Forms.Label LeapModLbl;
		private System.Windows.Forms.NumericUpDown LeapPeriodBox;
		private System.Windows.Forms.Label LeapPeriodLbl;
		private System.Windows.Forms.GroupBox MonthGroup;
		private System.Windows.Forms.GroupBox LeapGroup;
	}
}