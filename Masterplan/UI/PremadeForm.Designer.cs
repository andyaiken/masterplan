namespace Masterplan.UI
{
	partial class PremadeForm
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
			this.AdventureList = new System.Windows.Forms.ListView();
			this.NameHdr = new System.Windows.Forms.ColumnHeader();
			this.LevelHdr = new System.Windows.Forms.ColumnHeader();
			this.SizeHdr = new System.Windows.Forms.ColumnHeader();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// AdventureList
			// 
			this.AdventureList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.AdventureList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameHdr,
            this.LevelHdr,
            this.SizeHdr});
			this.AdventureList.FullRowSelect = true;
			this.AdventureList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.AdventureList.HideSelection = false;
			this.AdventureList.Location = new System.Drawing.Point(12, 12);
			this.AdventureList.MultiSelect = false;
			this.AdventureList.Name = "AdventureList";
			this.AdventureList.Size = new System.Drawing.Size(452, 188);
			this.AdventureList.TabIndex = 0;
			this.AdventureList.UseCompatibleStateImageBehavior = false;
			this.AdventureList.View = System.Windows.Forms.View.Details;
			this.AdventureList.DoubleClick += new System.EventHandler(this.AdventureList_DoubleClick);
			// 
			// NameHdr
			// 
			this.NameHdr.Text = "Adventure Name";
			this.NameHdr.Width = 219;
			// 
			// LevelHdr
			// 
			this.LevelHdr.Text = "Party Level";
			this.LevelHdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.LevelHdr.Width = 100;
			// 
			// SizeHdr
			// 
			this.SizeHdr.Text = "Party Size";
			this.SizeHdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.SizeHdr.Width = 100;
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(308, 206);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 1;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(389, 206);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 2;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// PremadeForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(476, 241);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.AdventureList);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PremadeForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Premade Adventures";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PremadeForm_FormClosing);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView AdventureList;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.ColumnHeader NameHdr;
		private System.Windows.Forms.ColumnHeader SizeHdr;
		private System.Windows.Forms.ColumnHeader LevelHdr;
	}
}