namespace Masterplan.UI
{
	partial class MergeLibrariesForm
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
			this.ThemeList = new System.Windows.Forms.ListView();
			this.NameHdr = new System.Windows.Forms.ColumnHeader();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.NameLbl = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(166, 354);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 3;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			// 
			// ThemeList
			// 
			this.ThemeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ThemeList.CheckBoxes = true;
			this.ThemeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameHdr});
			this.ThemeList.FullRowSelect = true;
			this.ThemeList.HideSelection = false;
			this.ThemeList.Location = new System.Drawing.Point(12, 12);
			this.ThemeList.MultiSelect = false;
			this.ThemeList.Name = "ThemeList";
			this.ThemeList.Size = new System.Drawing.Size(310, 310);
			this.ThemeList.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.ThemeList.TabIndex = 0;
			this.ThemeList.UseCompatibleStateImageBehavior = false;
			this.ThemeList.View = System.Windows.Forms.View.Details;
			this.ThemeList.DoubleClick += new System.EventHandler(this.TileList_DoubleClick);
			// 
			// NameHdr
			// 
			this.NameHdr.Text = "Library";
			this.NameHdr.Width = 270;
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(247, 354);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 4;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// NameLbl
			// 
			this.NameLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.NameLbl.AutoSize = true;
			this.NameLbl.Location = new System.Drawing.Point(12, 331);
			this.NameLbl.Name = "NameLbl";
			this.NameLbl.Size = new System.Drawing.Size(97, 13);
			this.NameLbl.TabIndex = 1;
			this.NameLbl.Text = "New Library Name:";
			// 
			// NameBox
			// 
			this.NameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.NameBox.Location = new System.Drawing.Point(115, 328);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(207, 20);
			this.NameBox.TabIndex = 2;
			// 
			// MergeLibrariesForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(334, 389);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.ThemeList);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MergeLibrariesForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Merge Libraries";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.ListView ThemeList;
		private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.ColumnHeader NameHdr;
		private System.Windows.Forms.Label NameLbl;
		private System.Windows.Forms.TextBox NameBox;
	}
}