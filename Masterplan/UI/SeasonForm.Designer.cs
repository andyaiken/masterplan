namespace Masterplan.UI
{
	partial class SeasonForm
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
			this.MonthLbl = new System.Windows.Forms.Label();
			this.MonthBox = new System.Windows.Forms.ComboBox();
			this.DayLbl = new System.Windows.Forms.Label();
			this.DayBox = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.DayBox)).BeginInit();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(98, 100);
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
			this.CancelBtn.Location = new System.Drawing.Point(179, 100);
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
			this.NameBox.Size = new System.Drawing.Size(196, 20);
			this.NameBox.TabIndex = 1;
			// 
			// MonthLbl
			// 
			this.MonthLbl.AutoSize = true;
			this.MonthLbl.Location = new System.Drawing.Point(12, 41);
			this.MonthLbl.Name = "MonthLbl";
			this.MonthLbl.Size = new System.Drawing.Size(40, 13);
			this.MonthLbl.TabIndex = 2;
			this.MonthLbl.Text = "Month:";
			// 
			// MonthBox
			// 
			this.MonthBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.MonthBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.MonthBox.FormattingEnabled = true;
			this.MonthBox.Location = new System.Drawing.Point(58, 38);
			this.MonthBox.Name = "MonthBox";
			this.MonthBox.Size = new System.Drawing.Size(196, 21);
			this.MonthBox.TabIndex = 3;
			this.MonthBox.SelectedIndexChanged += new System.EventHandler(this.MonthBox_SelectedIndexChanged);
			// 
			// DayLbl
			// 
			this.DayLbl.AutoSize = true;
			this.DayLbl.Location = new System.Drawing.Point(12, 67);
			this.DayLbl.Name = "DayLbl";
			this.DayLbl.Size = new System.Drawing.Size(29, 13);
			this.DayLbl.TabIndex = 4;
			this.DayLbl.Text = "Day:";
			// 
			// DayBox
			// 
			this.DayBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DayBox.Location = new System.Drawing.Point(58, 65);
			this.DayBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.DayBox.Name = "DayBox";
			this.DayBox.Size = new System.Drawing.Size(196, 20);
			this.DayBox.TabIndex = 5;
			this.DayBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// SeasonForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(266, 135);
			this.Controls.Add(this.DayBox);
			this.Controls.Add(this.DayLbl);
			this.Controls.Add(this.MonthBox);
			this.Controls.Add(this.MonthLbl);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SeasonForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Season";
			((System.ComponentModel.ISupportInitialize)(this.DayBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label NameLbl;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.Label MonthLbl;
		private System.Windows.Forms.ComboBox MonthBox;
		private System.Windows.Forms.Label DayLbl;
		private System.Windows.Forms.NumericUpDown DayBox;
	}
}