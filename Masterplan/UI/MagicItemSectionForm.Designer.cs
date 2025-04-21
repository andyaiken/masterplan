namespace Masterplan.UI
{
	partial class MagicItemSectionForm
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
            this.HeaderLbl = new System.Windows.Forms.Label();
            this.Pages = new System.Windows.Forms.TabControl();
            this.DetailsPage = new System.Windows.Forms.TabPage();
            this.DetailsBox = new System.Windows.Forms.TextBox();
            this.OKBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.HeaderBox = new System.Windows.Forms.ComboBox();
            this.Pages.SuspendLayout();
            this.DetailsPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeaderLbl
            // 
            this.HeaderLbl.AutoSize = true;
            this.HeaderLbl.Location = new System.Drawing.Point(16, 18);
            this.HeaderLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HeaderLbl.Name = "HeaderLbl";
            this.HeaderLbl.Size = new System.Drawing.Size(56, 16);
            this.HeaderLbl.TabIndex = 0;
            this.HeaderLbl.Text = "Header:";
            // 
            // Pages
            // 
            this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Pages.Controls.Add(this.DetailsPage);
            this.Pages.Location = new System.Drawing.Point(16, 48);
            this.Pages.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Pages.Name = "Pages";
            this.Pages.SelectedIndex = 0;
            this.Pages.Size = new System.Drawing.Size(409, 180);
            this.Pages.TabIndex = 2;
            // 
            // DetailsPage
            // 
            this.DetailsPage.Controls.Add(this.DetailsBox);
            this.DetailsPage.Location = new System.Drawing.Point(4, 25);
            this.DetailsPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DetailsPage.Name = "DetailsPage";
            this.DetailsPage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DetailsPage.Size = new System.Drawing.Size(401, 151);
            this.DetailsPage.TabIndex = 0;
            this.DetailsPage.Text = "Details";
            this.DetailsPage.UseVisualStyleBackColor = true;
            // 
            // DetailsBox
            // 
            this.DetailsBox.AcceptsReturn = true;
            this.DetailsBox.AcceptsTab = true;
            this.DetailsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailsBox.Location = new System.Drawing.Point(4, 4);
            this.DetailsBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DetailsBox.Multiline = true;
            this.DetailsBox.Name = "DetailsBox";
            this.DetailsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DetailsBox.Size = new System.Drawing.Size(393, 143);
            this.DetailsBox.TabIndex = 0;
            // 
            // OKBtn
            // 
            this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.Location = new System.Drawing.Point(217, 235);
            this.OKBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(100, 28);
            this.OKBtn.TabIndex = 3;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(325, 235);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(100, 28);
            this.CancelBtn.TabIndex = 4;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // HeaderBox
            // 
            this.HeaderBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HeaderBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.HeaderBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.HeaderBox.FormattingEnabled = true;
            this.HeaderBox.Location = new System.Drawing.Point(84, 15);
            this.HeaderBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.HeaderBox.Name = "HeaderBox";
            this.HeaderBox.Size = new System.Drawing.Size(340, 24);
            this.HeaderBox.Sorted = true;
            this.HeaderBox.TabIndex = 1;
            // 
            // MagicItemSectionForm
            // 
            this.AcceptButton = this.OKBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(441, 278);
            this.Controls.Add(this.HeaderBox);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.Pages);
            this.Controls.Add(this.HeaderLbl);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimizeBox = false;
            this.Name = "MagicItemSectionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Magic Item Section";
            this.Pages.ResumeLayout(false);
            this.DetailsPage.ResumeLayout(false);
            this.DetailsPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label HeaderLbl;
		private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.TabPage DetailsPage;
		private System.Windows.Forms.TextBox DetailsBox;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.ComboBox HeaderBox;
	}
}