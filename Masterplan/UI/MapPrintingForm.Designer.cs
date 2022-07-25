namespace Masterplan.UI
{
	partial class MapPrintingForm
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
			this.OnePageBtn = new System.Windows.Forms.RadioButton();
			this.PosterBtn = new System.Windows.Forms.RadioButton();
			this.PrintBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(212, 79);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 3;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(293, 79);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 4;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// OnePageBtn
			// 
			this.OnePageBtn.AutoSize = true;
			this.OnePageBtn.Location = new System.Drawing.Point(12, 12);
			this.OnePageBtn.Name = "OnePageBtn";
			this.OnePageBtn.Size = new System.Drawing.Size(200, 17);
			this.OnePageBtn.TabIndex = 0;
			this.OnePageBtn.TabStop = true;
			this.OnePageBtn.Text = "Scale the map to fill one printed page";
			this.OnePageBtn.UseVisualStyleBackColor = true;
			// 
			// PosterBtn
			// 
			this.PosterBtn.AutoSize = true;
			this.PosterBtn.Location = new System.Drawing.Point(12, 35);
			this.PosterBtn.Name = "PosterBtn";
			this.PosterBtn.Size = new System.Drawing.Size(267, 17);
			this.PosterBtn.TabIndex = 1;
			this.PosterBtn.TabStop = true;
			this.PosterBtn.Text = "Print the map at 1\" resolution (possibly many pages)";
			this.PosterBtn.UseVisualStyleBackColor = true;
			// 
			// PrintBtn
			// 
			this.PrintBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.PrintBtn.Location = new System.Drawing.Point(12, 79);
			this.PrintBtn.Name = "PrintBtn";
			this.PrintBtn.Size = new System.Drawing.Size(123, 23);
			this.PrintBtn.TabIndex = 2;
			this.PrintBtn.Text = "Print Settings";
			this.PrintBtn.UseVisualStyleBackColor = true;
			this.PrintBtn.Click += new System.EventHandler(this.PrintBtn_Click);
			// 
			// MapPrintingForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(380, 114);
			this.Controls.Add(this.PrintBtn);
			this.Controls.Add(this.PosterBtn);
			this.Controls.Add(this.OnePageBtn);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MapPrintingForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Print Tactical Map";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.RadioButton OnePageBtn;
		private System.Windows.Forms.RadioButton PosterBtn;
		private System.Windows.Forms.Button PrintBtn;
	}
}