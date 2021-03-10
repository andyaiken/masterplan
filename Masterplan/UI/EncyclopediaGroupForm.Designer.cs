namespace Masterplan.UI
{
	partial class EncyclopediaGroupForm
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
			this.TitleLbl = new System.Windows.Forms.Label();
			this.TitleBox = new System.Windows.Forms.TextBox();
			this.Pages = new System.Windows.Forms.TabControl();
			this.LinksPage = new System.Windows.Forms.TabPage();
			this.EntryList = new System.Windows.Forms.ListView();
			this.EntryHdr = new System.Windows.Forms.ColumnHeader();
			this.Pages.SuspendLayout();
			this.LinksPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(338, 268);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 5;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(419, 268);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 6;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// TitleLbl
			// 
			this.TitleLbl.AutoSize = true;
			this.TitleLbl.Location = new System.Drawing.Point(12, 15);
			this.TitleLbl.Name = "TitleLbl";
			this.TitleLbl.Size = new System.Drawing.Size(30, 13);
			this.TitleLbl.TabIndex = 0;
			this.TitleLbl.Text = "Title:";
			// 
			// TitleBox
			// 
			this.TitleBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TitleBox.Location = new System.Drawing.Point(70, 12);
			this.TitleBox.Name = "TitleBox";
			this.TitleBox.Size = new System.Drawing.Size(424, 20);
			this.TitleBox.TabIndex = 1;
			// 
			// Pages
			// 
			this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Pages.Controls.Add(this.LinksPage);
			this.Pages.Location = new System.Drawing.Point(12, 38);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(482, 224);
			this.Pages.TabIndex = 4;
			// 
			// LinksPage
			// 
			this.LinksPage.Controls.Add(this.EntryList);
			this.LinksPage.Location = new System.Drawing.Point(4, 22);
			this.LinksPage.Name = "LinksPage";
			this.LinksPage.Padding = new System.Windows.Forms.Padding(3);
			this.LinksPage.Size = new System.Drawing.Size(474, 198);
			this.LinksPage.TabIndex = 1;
			this.LinksPage.Text = "Links";
			this.LinksPage.UseVisualStyleBackColor = true;
			// 
			// EntryList
			// 
			this.EntryList.CheckBoxes = true;
			this.EntryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EntryHdr});
			this.EntryList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EntryList.FullRowSelect = true;
			this.EntryList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.EntryList.HideSelection = false;
			this.EntryList.Location = new System.Drawing.Point(3, 3);
			this.EntryList.MultiSelect = false;
			this.EntryList.Name = "EntryList";
			this.EntryList.Size = new System.Drawing.Size(468, 192);
			this.EntryList.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.EntryList.TabIndex = 0;
			this.EntryList.UseCompatibleStateImageBehavior = false;
			this.EntryList.View = System.Windows.Forms.View.Details;
			// 
			// EntryHdr
			// 
			this.EntryHdr.Text = "Entry";
			this.EntryHdr.Width = 300;
			// 
			// EncyclopediaGroupForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(506, 303);
			this.Controls.Add(this.Pages);
			this.Controls.Add(this.TitleBox);
			this.Controls.Add(this.TitleLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MinimizeBox = false;
			this.Name = "EncyclopediaGroupForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Encyclopedia Group";
			this.Pages.ResumeLayout(false);
			this.LinksPage.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label TitleLbl;
		private System.Windows.Forms.TextBox TitleBox;
		private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.TabPage LinksPage;
		private System.Windows.Forms.ListView EntryList;
		private System.Windows.Forms.ColumnHeader EntryHdr;

	}
}