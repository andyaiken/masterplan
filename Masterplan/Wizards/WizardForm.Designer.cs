namespace Masterplan.Wizards
{
	partial class WizardForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WizardForm));
			this.BackBtn = new System.Windows.Forms.Button();
			this.NextBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.ContentPnl = new System.Windows.Forms.Panel();
			this.FinishBtn = new System.Windows.Forms.Button();
			this.ImageBox = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
			this.SuspendLayout();
			// 
			// BackBtn
			// 
			this.BackBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BackBtn.Location = new System.Drawing.Point(148, 277);
			this.BackBtn.Name = "BackBtn";
			this.BackBtn.Size = new System.Drawing.Size(75, 23);
			this.BackBtn.TabIndex = 1;
			this.BackBtn.Text = "< Back";
			this.BackBtn.UseVisualStyleBackColor = true;
			this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
			// 
			// NextBtn
			// 
			this.NextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.NextBtn.Location = new System.Drawing.Point(229, 277);
			this.NextBtn.Name = "NextBtn";
			this.NextBtn.Size = new System.Drawing.Size(75, 23);
			this.NextBtn.TabIndex = 2;
			this.NextBtn.Text = "Next >";
			this.NextBtn.UseVisualStyleBackColor = true;
			this.NextBtn.Click += new System.EventHandler(this.NextBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(391, 277);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 4;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
			// 
			// ContentPnl
			// 
			this.ContentPnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ContentPnl.Location = new System.Drawing.Point(149, 12);
			this.ContentPnl.Name = "ContentPnl";
			this.ContentPnl.Size = new System.Drawing.Size(317, 259);
			this.ContentPnl.TabIndex = 0;
			// 
			// FinishBtn
			// 
			this.FinishBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.FinishBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.FinishBtn.Location = new System.Drawing.Point(310, 277);
			this.FinishBtn.Name = "FinishBtn";
			this.FinishBtn.Size = new System.Drawing.Size(75, 23);
			this.FinishBtn.TabIndex = 3;
			this.FinishBtn.Text = "Finish";
			this.FinishBtn.UseVisualStyleBackColor = true;
			this.FinishBtn.Click += new System.EventHandler(this.FinishBtn_Click);
			// 
			// ImageBox
			// 
			this.ImageBox.Image = ((System.Drawing.Image)(resources.GetObject("ImageBox.Image")));
			this.ImageBox.Location = new System.Drawing.Point(12, 12);
			this.ImageBox.Name = "ImageBox";
			this.ImageBox.Size = new System.Drawing.Size(131, 259);
			this.ImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.ImageBox.TabIndex = 13;
			this.ImageBox.TabStop = false;
			// 
			// WizardForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(478, 312);
			this.Controls.Add(this.ImageBox);
			this.Controls.Add(this.FinishBtn);
			this.Controls.Add(this.ContentPnl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.NextBtn);
			this.Controls.Add(this.BackBtn);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "WizardForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Wizard";
			((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button BackBtn;
		private System.Windows.Forms.Button NextBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Panel ContentPnl;
		private System.Windows.Forms.Button FinishBtn;
		private System.Windows.Forms.PictureBox ImageBox;
	}
}