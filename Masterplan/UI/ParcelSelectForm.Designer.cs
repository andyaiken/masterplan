namespace Masterplan.UI
{
	partial class ParcelSelectForm
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
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Magic Items", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Mundane Parcels", System.Windows.Forms.HorizontalAlignment.Left);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParcelSelectForm));
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.NameHdr = new System.Windows.Forms.ColumnHeader();
			this.DetailsHdr = new System.Windows.Forms.ColumnHeader();
			this.ParcelList = new System.Windows.Forms.ListView();
			this.ListPanel = new System.Windows.Forms.Panel();
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.ChangeItemBtn = new System.Windows.Forms.ToolStripButton();
			this.StatBlockBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.RandomiseAllBtn = new System.Windows.Forms.ToolStripButton();
			this.RandomiseBtn = new System.Windows.Forms.ToolStripButton();
			this.ListPanel.SuspendLayout();
			this.Toolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(318, 348);
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
			this.CancelBtn.Location = new System.Drawing.Point(399, 348);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 4;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// NameHdr
			// 
			this.NameHdr.Text = "Parcel";
			this.NameHdr.Width = 150;
			// 
			// DetailsHdr
			// 
			this.DetailsHdr.Text = "Details";
			this.DetailsHdr.Width = 275;
			// 
			// ParcelList
			// 
			this.ParcelList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameHdr,
            this.DetailsHdr});
			this.ParcelList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ParcelList.FullRowSelect = true;
			listViewGroup1.Header = "Magic Items";
			listViewGroup1.Name = "listViewGroup1";
			listViewGroup2.Header = "Mundane Parcels";
			listViewGroup2.Name = "listViewGroup2";
			this.ParcelList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
			this.ParcelList.HideSelection = false;
			this.ParcelList.Location = new System.Drawing.Point(0, 25);
			this.ParcelList.MultiSelect = false;
			this.ParcelList.Name = "ParcelList";
			this.ParcelList.Size = new System.Drawing.Size(462, 305);
			this.ParcelList.TabIndex = 0;
			this.ParcelList.UseCompatibleStateImageBehavior = false;
			this.ParcelList.View = System.Windows.Forms.View.Details;
			this.ParcelList.DoubleClick += new System.EventHandler(this.TileList_DoubleClick);
			// 
			// ListPanel
			// 
			this.ListPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ListPanel.Controls.Add(this.ParcelList);
			this.ListPanel.Controls.Add(this.Toolbar);
			this.ListPanel.Location = new System.Drawing.Point(12, 12);
			this.ListPanel.Name = "ListPanel";
			this.ListPanel.Size = new System.Drawing.Size(462, 330);
			this.ListPanel.TabIndex = 5;
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangeItemBtn,
            this.StatBlockBtn,
            this.toolStripSeparator1,
            this.RandomiseBtn,
            this.RandomiseAllBtn});
			this.Toolbar.Location = new System.Drawing.Point(0, 0);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(462, 25);
			this.Toolbar.TabIndex = 1;
			this.Toolbar.Text = Session.I18N.toolStrip1;
			// 
			// ChangeItemBtn
			// 
			this.ChangeItemBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ChangeItemBtn.Image = ((System.Drawing.Image)(resources.GetObject("ChangeItemBtn.Image")));
			this.ChangeItemBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ChangeItemBtn.Name = "ChangeItemBtn";
			this.ChangeItemBtn.Size = new System.Drawing.Size(115, 22);
			this.ChangeItemBtn.Text = "Change Magic Item";
			this.ChangeItemBtn.Click += new System.EventHandler(this.ChangeItemBtn_Click);
			// 
			// StatBlockBtn
			// 
			this.StatBlockBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.StatBlockBtn.Image = ((System.Drawing.Image)(resources.GetObject("StatBlockBtn.Image")));
			this.StatBlockBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.StatBlockBtn.Name = "StatBlockBtn";
			this.StatBlockBtn.Size = new System.Drawing.Size(63, 22);
			this.StatBlockBtn.Text = "Stat Block";
			this.StatBlockBtn.Click += new System.EventHandler(this.StatBlockBtn_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// RandomiseAllBtn
			// 
			this.RandomiseAllBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.RandomiseAllBtn.Image = ((System.Drawing.Image)(resources.GetObject("RandomiseAllBtn.Image")));
			this.RandomiseAllBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RandomiseAllBtn.Name = "RandomiseAllBtn";
			this.RandomiseAllBtn.Size = new System.Drawing.Size(87, 22);
			this.RandomiseAllBtn.Text = "Randomise All";
			this.RandomiseAllBtn.Click += new System.EventHandler(this.RandomiseAllBtn_Click);
			// 
			// RandomiseBtn
			// 
			this.RandomiseBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.RandomiseBtn.Image = ((System.Drawing.Image)(resources.GetObject("RandomiseBtn.Image")));
			this.RandomiseBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RandomiseBtn.Name = "RandomiseBtn";
			this.RandomiseBtn.Size = new System.Drawing.Size(70, 22);
			this.RandomiseBtn.Text = "Randomise";
			this.RandomiseBtn.Click += new System.EventHandler(this.RandomiseBtn_Click);
			// 
			// ParcelSelectForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(486, 383);
			this.Controls.Add(this.ListPanel);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ParcelSelectForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select a Treasure Parcel";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ParcelSelectForm_FormClosed);
			this.ListPanel.ResumeLayout(false);
			this.ListPanel.PerformLayout();
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.ColumnHeader NameHdr;
		private System.Windows.Forms.ColumnHeader DetailsHdr;
		private System.Windows.Forms.ListView ParcelList;
		private System.Windows.Forms.Panel ListPanel;
		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ToolStripButton ChangeItemBtn;
		private System.Windows.Forms.ToolStripButton StatBlockBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton RandomiseAllBtn;
		private System.Windows.Forms.ToolStripButton RandomiseBtn;
	}
}