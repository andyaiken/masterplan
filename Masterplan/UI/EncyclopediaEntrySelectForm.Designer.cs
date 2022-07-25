namespace Masterplan.UI
{
	partial class EncyclopediaEntrySelectForm
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
            this.EntryList = new System.Windows.Forms.ListView();
            this.NameHdr = new System.Windows.Forms.ColumnHeader();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OKBtn
            // 
            this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.Location = new System.Drawing.Point(188, 354);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 23);
            this.OKBtn.TabIndex = 1;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = true;
            // 
            // EntryList
            // 
            this.EntryList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.EntryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameHdr});
            this.EntryList.FullRowSelect = true;
            this.EntryList.HideSelection = false;
            this.EntryList.Location = new System.Drawing.Point(12, 12);
            this.EntryList.MultiSelect = false;
            this.EntryList.Name = "EntryList";
            this.EntryList.Size = new System.Drawing.Size(332, 336);
            this.EntryList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.EntryList.TabIndex = 0;
            this.EntryList.UseCompatibleStateImageBehavior = false;
            this.EntryList.View = System.Windows.Forms.View.Details;
            this.EntryList.DoubleClick += new System.EventHandler(this.TileList_DoubleClick);
            // 
            // NameHdr
            // 
            this.NameHdr.Text = "Entry";
            this.NameHdr.Width = 300;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(269, 354);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 2;
            this.CancelBtn.Text = Session.I18N.Cancel;
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // EncyclopediaEntrySelectForm
            // 
            this.AcceptButton = this.OKBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(356, 389);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.EntryList);
            this.Controls.Add(this.OKBtn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EncyclopediaEntrySelectForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select an Encyclopedia Entry";
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.ListView EntryList;
		private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.ColumnHeader NameHdr;
	}
}