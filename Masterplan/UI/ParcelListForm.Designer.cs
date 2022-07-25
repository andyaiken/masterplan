namespace Masterplan.UI
{
	partial class ParcelListForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParcelListForm));
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Parcels which are assigned to a Plot Point", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Parcels which are not yet assigned to a plot point", System.Windows.Forms.HorizontalAlignment.Left);
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.AddBtn = new System.Windows.Forms.ToolStripDropDownButton();
			this.AddParcel = new System.Windows.Forms.ToolStripMenuItem();
			this.AddMagicItem = new System.Windows.Forms.ToolStripMenuItem();
			this.AddArtifact = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.AddSet = new System.Windows.Forms.ToolStripMenuItem();
			this.RemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.EditBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.RandomiseAllBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.ViewMenu = new System.Windows.Forms.ToolStripDropDownButton();
			this.ViewAssigned = new System.Windows.Forms.ToolStripMenuItem();
			this.ViewUnassigned = new System.Windows.Forms.ToolStripMenuItem();
			this.ParcelList = new System.Windows.Forms.ListView();
			this.ParcelHdr = new System.Windows.Forms.ColumnHeader();
			this.DetailsHdr = new System.Windows.Forms.ColumnHeader();
			this.HeroHdr = new System.Windows.Forms.ColumnHeader();
			this.ParcelMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ChangeItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.ChangeAssign = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.RandomiseItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ResetItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MainPanel = new System.Windows.Forms.Panel();
			this.CloseBtn = new System.Windows.Forms.Button();
			this.Toolbar.SuspendLayout();
			this.ParcelMenu.SuspendLayout();
			this.MainPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddBtn,
            this.RemoveBtn,
            this.EditBtn,
            this.toolStripSeparator3,
            this.RandomiseAllBtn,
            this.toolStripSeparator4,
            this.ViewMenu});
			this.Toolbar.Location = new System.Drawing.Point(0, 0);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(665, 25);
			this.Toolbar.TabIndex = 0;
			this.Toolbar.Text = Session.I18N.toolStrip1;
			// 
			// AddBtn
			// 
			this.AddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.AddBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddParcel,
            this.AddMagicItem,
            this.AddArtifact,
            this.toolStripSeparator1,
            this.AddSet});
			this.AddBtn.Image = ((System.Drawing.Image)(resources.GetObject("AddBtn.Image")));
			this.AddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AddBtn.Name = "AddBtn";
			this.AddBtn.Size = new System.Drawing.Size(42, 22);
			this.AddBtn.Text = Session.I18N.Add;
			// 
			// AddParcel
			// 
			this.AddParcel.Name = "AddParcel";
			this.AddParcel.Size = new System.Drawing.Size(228, 22);
			this.AddParcel.Text = "Add a Mundane Parcel...";
			this.AddParcel.Click += new System.EventHandler(this.AddParcel_Click);
			// 
			// AddMagicItem
			// 
			this.AddMagicItem.Name = "AddMagicItem";
			this.AddMagicItem.Size = new System.Drawing.Size(228, 22);
			this.AddMagicItem.Text = "Add a Magic Item...";
			this.AddMagicItem.Click += new System.EventHandler(this.AddMagicItem_Click);
			// 
			// AddArtifact
			// 
			this.AddArtifact.Name = "AddArtifact";
			this.AddArtifact.Size = new System.Drawing.Size(228, 22);
			this.AddArtifact.Text = "Add an Artifact...";
			this.AddArtifact.Click += new System.EventHandler(this.AddArtifact_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(225, 6);
			// 
			// AddSet
			// 
			this.AddSet.Name = "AddSet";
			this.AddSet.Size = new System.Drawing.Size(228, 22);
			this.AddSet.Text = "Add a Standard Set of Parcels";
			this.AddSet.Click += new System.EventHandler(this.AddSet_Click);
			// 
			// RemoveBtn
			// 
			this.RemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.RemoveBtn.Image = ((System.Drawing.Image)(resources.GetObject("RemoveBtn.Image")));
			this.RemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RemoveBtn.Name = "RemoveBtn";
			this.RemoveBtn.Size = new System.Drawing.Size(54, 22);
			this.RemoveBtn.Text = Session.I18N.Remove;
			this.RemoveBtn.Click += new System.EventHandler(this.RemoveBtn_Click);
			// 
			// EditBtn
			// 
			this.EditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.EditBtn.Image = ((System.Drawing.Image)(resources.GetObject("EditBtn.Image")));
			this.EditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EditBtn.Name = "EditBtn";
			this.EditBtn.Size = new System.Drawing.Size(31, 22);
			this.EditBtn.Text = Session.I18N.Edit;
			this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// RandomiseAllBtn
			// 
			this.RandomiseAllBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.RandomiseAllBtn.Image = ((System.Drawing.Image)(resources.GetObject("RandomiseAllBtn.Image")));
			this.RandomiseAllBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RandomiseAllBtn.Name = "RandomiseAllBtn";
			this.RandomiseAllBtn.Size = new System.Drawing.Size(87, 22);
			this.RandomiseAllBtn.Text = "Randomise All";
			this.RandomiseAllBtn.ToolTipText = "Randomise unassigned parcels";
			this.RandomiseAllBtn.Click += new System.EventHandler(this.RandomiseBtn_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			// 
			// ViewMenu
			// 
			this.ViewMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ViewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewAssigned,
            this.ViewUnassigned});
			this.ViewMenu.Image = ((System.Drawing.Image)(resources.GetObject("ViewMenu.Image")));
			this.ViewMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ViewMenu.Name = "ViewMenu";
			this.ViewMenu.Size = new System.Drawing.Size(45, 22);
			this.ViewMenu.Text = Session.I18N.View;
			this.ViewMenu.DropDownOpening += new System.EventHandler(this.ViewMenu_DropDownOpening);
			// 
			// ViewAssigned
			// 
			this.ViewAssigned.Name = "ViewAssigned";
			this.ViewAssigned.Size = new System.Drawing.Size(135, 22);
			this.ViewAssigned.Text = "Assigned";
			this.ViewAssigned.Click += new System.EventHandler(this.ViewAssigned_Click);
			// 
			// ViewUnassigned
			// 
			this.ViewUnassigned.Name = "ViewUnassigned";
			this.ViewUnassigned.Size = new System.Drawing.Size(135, 22);
			this.ViewUnassigned.Text = "Unassigned";
			this.ViewUnassigned.Click += new System.EventHandler(this.ViewUnassigned_Click);
			// 
			// ParcelList
			// 
			this.ParcelList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ParcelHdr,
            this.DetailsHdr,
            this.HeroHdr});
			this.ParcelList.ContextMenuStrip = this.ParcelMenu;
			this.ParcelList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ParcelList.FullRowSelect = true;
			listViewGroup1.Header = "Parcels which are assigned to a Plot Point";
			listViewGroup1.Name = "listViewGroup1";
			listViewGroup2.Header = "Parcels which are not yet assigned to a plot point";
			listViewGroup2.Name = "listViewGroup2";
			this.ParcelList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
			this.ParcelList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.ParcelList.HideSelection = false;
			this.ParcelList.Location = new System.Drawing.Point(0, 25);
			this.ParcelList.MultiSelect = false;
			this.ParcelList.Name = "ParcelList";
			this.ParcelList.Size = new System.Drawing.Size(665, 314);
			this.ParcelList.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.ParcelList.TabIndex = 1;
			this.ParcelList.UseCompatibleStateImageBehavior = false;
			this.ParcelList.View = System.Windows.Forms.View.Details;
			this.ParcelList.DoubleClick += new System.EventHandler(this.EditBtn_Click);
			// 
			// ParcelHdr
			// 
			this.ParcelHdr.Text = "Parcel";
			this.ParcelHdr.Width = 150;
			// 
			// DetailsHdr
			// 
			this.DetailsHdr.Text = "Details";
			this.DetailsHdr.Width = 300;
			// 
			// HeroHdr
			// 
			this.HeroHdr.Text = "Allocated To";
			this.HeroHdr.Width = 183;
			// 
			// ParcelMenu
			// 
			this.ParcelMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangeItem,
            this.toolStripMenuItem1,
            this.ChangeAssign,
            this.toolStripMenuItem2,
            this.RandomiseItem,
            this.ResetItem});
			this.ParcelMenu.Name = "contextMenuStrip1";
			this.ParcelMenu.Size = new System.Drawing.Size(187, 104);
			this.ParcelMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenu_Opening);
			// 
			// ChangeItem
			// 
			this.ChangeItem.Name = "ChangeItem";
			this.ChangeItem.Size = new System.Drawing.Size(186, 22);
			this.ChangeItem.Text = "Choose Magic Item...";
			this.ChangeItem.Click += new System.EventHandler(this.ChangeItemBtn_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(183, 6);
			// 
			// ChangeAssign
			// 
			this.ChangeAssign.Name = "ChangeAssign";
			this.ChangeAssign.Size = new System.Drawing.Size(186, 22);
			this.ChangeAssign.Text = "Allocate To PC";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(183, 6);
			// 
			// RandomiseItem
			// 
			this.RandomiseItem.Name = "RandomiseItem";
			this.RandomiseItem.Size = new System.Drawing.Size(186, 22);
			this.RandomiseItem.Text = "Randomise Parcel";
			this.RandomiseItem.Click += new System.EventHandler(this.RandomiseItem_Click);
			// 
			// ResetItem
			// 
			this.ResetItem.Name = "ResetItem";
			this.ResetItem.Size = new System.Drawing.Size(186, 22);
			this.ResetItem.Text = "Reset Parcel";
			this.ResetItem.Click += new System.EventHandler(this.ResetItem_Click);
			// 
			// MainPanel
			// 
			this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.MainPanel.Controls.Add(this.ParcelList);
			this.MainPanel.Controls.Add(this.Toolbar);
			this.MainPanel.Location = new System.Drawing.Point(12, 12);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(665, 339);
			this.MainPanel.TabIndex = 2;
			// 
			// CloseBtn
			// 
			this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.CloseBtn.Location = new System.Drawing.Point(602, 357);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.Size = new System.Drawing.Size(75, 23);
			this.CloseBtn.TabIndex = 3;
			this.CloseBtn.Text = "Close";
			this.CloseBtn.UseVisualStyleBackColor = true;
			// 
			// ParcelListForm
			// 
			this.AcceptButton = this.CloseBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(689, 392);
			this.Controls.Add(this.CloseBtn);
			this.Controls.Add(this.MainPanel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ParcelListForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = Session.I18N.TreasureParcels;
			this.Shown += new System.EventHandler(this.ParcelListForm_Shown);
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			this.ParcelMenu.ResumeLayout(false);
			this.MainPanel.ResumeLayout(false);
			this.MainPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ListView ParcelList;
		private System.Windows.Forms.ColumnHeader ParcelHdr;
		private System.Windows.Forms.ColumnHeader DetailsHdr;
		private System.Windows.Forms.ToolStripDropDownButton AddBtn;
		private System.Windows.Forms.ToolStripMenuItem AddParcel;
		private System.Windows.Forms.ToolStripButton RemoveBtn;
		private System.Windows.Forms.ToolStripButton EditBtn;
		private System.Windows.Forms.ToolStripMenuItem AddSet;
		private System.Windows.Forms.Panel MainPanel;
		private System.Windows.Forms.Button CloseBtn;
		private System.Windows.Forms.ToolStripMenuItem AddMagicItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripDropDownButton ViewMenu;
		private System.Windows.Forms.ToolStripMenuItem ViewAssigned;
		private System.Windows.Forms.ToolStripMenuItem ViewUnassigned;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton RandomiseAllBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ColumnHeader HeroHdr;
		private System.Windows.Forms.ContextMenuStrip ParcelMenu;
		private System.Windows.Forms.ToolStripMenuItem ChangeItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem ChangeAssign;
		private System.Windows.Forms.ToolStripMenuItem RandomiseItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem ResetItem;
		private System.Windows.Forms.ToolStripMenuItem AddArtifact;
	}
}