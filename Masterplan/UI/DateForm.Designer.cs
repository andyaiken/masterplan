namespace Masterplan.UI
{
	partial class DateForm
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
			this.CalendarLbl = new System.Windows.Forms.Label();
			this.CalendarBox = new System.Windows.Forms.ComboBox();
			this.YearLbl = new System.Windows.Forms.Label();
			this.MonthBox = new System.Windows.Forms.ComboBox();
			this.MonthLbl = new System.Windows.Forms.Label();
			this.YearBox = new System.Windows.Forms.NumericUpDown();
			this.DayLbl = new System.Windows.Forms.Label();
			this.DayBox = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.YearBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DayBox)).BeginInit();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(111, 129);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 8;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(192, 129);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 9;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// CalendarLbl
			// 
			this.CalendarLbl.AutoSize = true;
			this.CalendarLbl.Location = new System.Drawing.Point(12, 15);
			this.CalendarLbl.Name = "CalendarLbl";
			this.CalendarLbl.Size = new System.Drawing.Size(52, 13);
			this.CalendarLbl.TabIndex = 0;
			this.CalendarLbl.Text = "Calendar:";
			// 
			// CalendarBox
			// 
			this.CalendarBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.CalendarBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CalendarBox.FormattingEnabled = true;
			this.CalendarBox.Location = new System.Drawing.Point(70, 12);
			this.CalendarBox.Name = "CalendarBox";
			this.CalendarBox.Size = new System.Drawing.Size(197, 21);
			this.CalendarBox.TabIndex = 1;
			this.CalendarBox.SelectedIndexChanged += new System.EventHandler(this.CalendarBox_SelectedIndexChanged);
			// 
			// YearLbl
			// 
			this.YearLbl.AutoSize = true;
			this.YearLbl.Location = new System.Drawing.Point(12, 41);
			this.YearLbl.Name = "YearLbl";
			this.YearLbl.Size = new System.Drawing.Size(32, 13);
			this.YearLbl.TabIndex = 2;
			this.YearLbl.Text = "Year:";
			// 
			// MonthBox
			// 
			this.MonthBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.MonthBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.MonthBox.FormattingEnabled = true;
			this.MonthBox.Location = new System.Drawing.Point(70, 65);
			this.MonthBox.Name = "MonthBox";
			this.MonthBox.Size = new System.Drawing.Size(197, 21);
			this.MonthBox.TabIndex = 5;
			this.MonthBox.SelectedIndexChanged += new System.EventHandler(this.MonthBox_SelectedIndexChanged);
			// 
			// MonthLbl
			// 
			this.MonthLbl.AutoSize = true;
			this.MonthLbl.Location = new System.Drawing.Point(12, 68);
			this.MonthLbl.Name = "MonthLbl";
			this.MonthLbl.Size = new System.Drawing.Size(40, 13);
			this.MonthLbl.TabIndex = 4;
			this.MonthLbl.Text = "Month:";
			// 
			// YearBox
			// 
			this.YearBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.YearBox.Location = new System.Drawing.Point(70, 39);
			this.YearBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.YearBox.Name = "YearBox";
			this.YearBox.Size = new System.Drawing.Size(197, 20);
			this.YearBox.TabIndex = 3;
			this.YearBox.ValueChanged += new System.EventHandler(this.YearBox_ValueChanged);
			// 
			// DayLbl
			// 
			this.DayLbl.AutoSize = true;
			this.DayLbl.Location = new System.Drawing.Point(12, 94);
			this.DayLbl.Name = "DayLbl";
			this.DayLbl.Size = new System.Drawing.Size(29, 13);
			this.DayLbl.TabIndex = 6;
			this.DayLbl.Text = "Day:";
			// 
			// DayBox
			// 
			this.DayBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DayBox.Location = new System.Drawing.Point(70, 92);
			this.DayBox.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
			this.DayBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.DayBox.Name = "DayBox";
			this.DayBox.Size = new System.Drawing.Size(197, 20);
			this.DayBox.TabIndex = 7;
			this.DayBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// DateForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(279, 164);
			this.Controls.Add(this.DayBox);
			this.Controls.Add(this.DayLbl);
			this.Controls.Add(this.MonthBox);
			this.Controls.Add(this.MonthLbl);
			this.Controls.Add(this.YearBox);
			this.Controls.Add(this.YearLbl);
			this.Controls.Add(this.CalendarBox);
			this.Controls.Add(this.CalendarLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DateForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Date";
			((System.ComponentModel.ISupportInitialize)(this.YearBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DayBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label CalendarLbl;
		private System.Windows.Forms.ComboBox CalendarBox;
		private System.Windows.Forms.Label YearLbl;
		private System.Windows.Forms.ComboBox MonthBox;
		private System.Windows.Forms.Label MonthLbl;
		private System.Windows.Forms.NumericUpDown YearBox;
		private System.Windows.Forms.Label DayLbl;
		private System.Windows.Forms.NumericUpDown DayBox;
	}
}