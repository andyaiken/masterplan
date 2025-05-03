namespace Masterplan.UI
{
	partial class PowerRangeForm
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
            this.RangeLbl = new System.Windows.Forms.Label();
            this.RangeBox = new System.Windows.Forms.ComboBox();
            this.TargetBox = new System.Windows.Forms.ComboBox();
            this.TargetLbl = new System.Windows.Forms.Label();
            this.CurrentRangeLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OKBtn
            // 
            this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.Location = new System.Drawing.Point(212, 106);
            this.OKBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(100, 28);
            this.OKBtn.TabIndex = 15;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(320, 106);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(100, 28);
            this.CancelBtn.TabIndex = 16;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // RangeLbl
            // 
            this.RangeLbl.AutoSize = true;
            this.RangeLbl.Location = new System.Drawing.Point(16, 46);
            this.RangeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RangeLbl.Name = "RangeLbl";
            this.RangeLbl.Size = new System.Drawing.Size(51, 16);
            this.RangeLbl.TabIndex = 12;
            this.RangeLbl.Text = "Range:";
            // 
            // RangeBox
            // 
            this.RangeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RangeBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.RangeBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.RangeBox.FormattingEnabled = true;
            this.RangeBox.Location = new System.Drawing.Point(80, 43);
            this.RangeBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RangeBox.Name = "RangeBox";
            this.RangeBox.Size = new System.Drawing.Size(338, 24);
            this.RangeBox.Sorted = true;
            this.RangeBox.TabIndex = 13;
            // 
            // TargetBox
            // 
            this.TargetBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TargetBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.TargetBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.TargetBox.FormattingEnabled = true;
            this.TargetBox.Location = new System.Drawing.Point(80, 72);
            this.TargetBox.Margin = new System.Windows.Forms.Padding(4);
            this.TargetBox.Name = "TargetBox";
            this.TargetBox.Size = new System.Drawing.Size(338, 24);
            this.TargetBox.Sorted = true;
            this.TargetBox.TabIndex = 18;
            // 
            // TargetLbl
            // 
            this.TargetLbl.AutoSize = true;
            this.TargetLbl.Location = new System.Drawing.Point(17, 75);
            this.TargetLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TargetLbl.Name = "TargetLbl";
            this.TargetLbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TargetLbl.Size = new System.Drawing.Size(50, 16);
            this.TargetLbl.TabIndex = 17;
            this.TargetLbl.Text = "Target:";
            // 
            // CurrentRangeLbl
            // 
            this.CurrentRangeLbl.AutoSize = true;
            this.CurrentRangeLbl.Location = new System.Drawing.Point(16, 10);
            this.CurrentRangeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CurrentRangeLbl.Name = "CurrentRangeLbl";
            this.CurrentRangeLbl.Size = new System.Drawing.Size(162, 16);
            this.CurrentRangeLbl.TabIndex = 19;
            this.CurrentRangeLbl.Text = "<Current Range is not set>";
            // 
            // PowerRangeForm
            // 
            this.AcceptButton = this.OKBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(436, 149);
            this.Controls.Add(this.CurrentRangeLbl);
            this.Controls.Add(this.TargetBox);
            this.Controls.Add(this.TargetLbl);
            this.Controls.Add(this.RangeBox);
            this.Controls.Add(this.RangeLbl);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PowerRangeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Power Range";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label RangeLbl;
		private System.Windows.Forms.ComboBox RangeBox;
        private System.Windows.Forms.ComboBox TargetBox;
        private System.Windows.Forms.Label TargetLbl;
        private System.Windows.Forms.Label CurrentRangeLbl;
    }
}