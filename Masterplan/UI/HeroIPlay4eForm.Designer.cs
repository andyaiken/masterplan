namespace Masterplan.UI
{
	partial class HeroIPlay4eForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeroIPlay4eForm));
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.KeyLbl = new System.Windows.Forms.Label();
			this.KeyBox = new System.Windows.Forms.TextBox();
			this.LogoBox = new System.Windows.Forms.PictureBox();
			this.WebsiteLink = new System.Windows.Forms.LinkLabel();
			((System.ComponentModel.ISupportInitialize)(this.LogoBox)).BeginInit();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(233, 116);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 3;
			this.OKBtn.Text = "Import";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(314, 116);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 4;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// KeyLbl
			// 
			this.KeyLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.KeyLbl.AutoSize = true;
			this.KeyLbl.Location = new System.Drawing.Point(12, 93);
			this.KeyLbl.Name = "KeyLbl";
			this.KeyLbl.Size = new System.Drawing.Size(77, 13);
			this.KeyLbl.TabIndex = 0;
			this.KeyLbl.Text = "Character Key:";
			// 
			// KeyBox
			// 
			this.KeyBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.KeyBox.Location = new System.Drawing.Point(95, 90);
			this.KeyBox.Name = "KeyBox";
			this.KeyBox.Size = new System.Drawing.Size(294, 20);
			this.KeyBox.TabIndex = 1;
			// 
			// LogoBox
			// 
			this.LogoBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.LogoBox.Image = ((System.Drawing.Image)(resources.GetObject("LogoBox.Image")));
			this.LogoBox.Location = new System.Drawing.Point(12, 12);
			this.LogoBox.Name = "LogoBox";
			this.LogoBox.Size = new System.Drawing.Size(377, 72);
			this.LogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.LogoBox.TabIndex = 4;
			this.LogoBox.TabStop = false;
			// 
			// WebsiteLink
			// 
			this.WebsiteLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.WebsiteLink.AutoSize = true;
			this.WebsiteLink.Location = new System.Drawing.Point(12, 121);
			this.WebsiteLink.Name = "WebsiteLink";
			this.WebsiteLink.Size = new System.Drawing.Size(109, 13);
			this.WebsiteLink.TabIndex = 2;
			this.WebsiteLink.TabStop = true;
			this.WebsiteLink.Text = "Go to iPlay4e website";
			this.WebsiteLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.WebsiteLink_LinkClicked);
			// 
			// HeroIPlay4eForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(401, 151);
			this.Controls.Add(this.WebsiteLink);
			this.Controls.Add(this.LogoBox);
			this.Controls.Add(this.KeyBox);
			this.Controls.Add(this.KeyLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HeroIPlay4eForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "iPlay4e Character";
			((System.ComponentModel.ISupportInitialize)(this.LogoBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label KeyLbl;
		private System.Windows.Forms.TextBox KeyBox;
		private System.Windows.Forms.PictureBox LogoBox;
		private System.Windows.Forms.LinkLabel WebsiteLink;
	}
}