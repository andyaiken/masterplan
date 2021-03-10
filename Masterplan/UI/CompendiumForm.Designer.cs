namespace Masterplan.UI
{
	partial class CompendiumForm
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
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Books", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Dragon Magazine", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Dungeon Magazine", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("RPGA Modules", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Creatures", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Traps / Hazards", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("Magic Items", System.Windows.Forms.HorizontalAlignment.Left);
			this.CloseBtn = new System.Windows.Forms.Button();
			this.Splitter = new System.Windows.Forms.SplitContainer();
			this.BookList = new System.Windows.Forms.ListView();
			this.BookHdr = new System.Windows.Forms.ColumnHeader();
			this.ItemList = new System.Windows.Forms.ListView();
			this.ItemHdr = new System.Windows.Forms.ColumnHeader();
			this.InfoHdr = new System.Windows.Forms.ColumnHeader();
			this.Splitter.Panel1.SuspendLayout();
			this.Splitter.Panel2.SuspendLayout();
			this.Splitter.SuspendLayout();
			this.SuspendLayout();
			// 
			// CloseBtn
			// 
			this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.CloseBtn.Location = new System.Drawing.Point(565, 330);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.Size = new System.Drawing.Size(75, 23);
			this.CloseBtn.TabIndex = 2;
			this.CloseBtn.Text = "Close";
			this.CloseBtn.UseVisualStyleBackColor = true;
			// 
			// Splitter
			// 
			this.Splitter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Splitter.Location = new System.Drawing.Point(12, 12);
			this.Splitter.Name = "Splitter";
			// 
			// Splitter.Panel1
			// 
			this.Splitter.Panel1.Controls.Add(this.BookList);
			// 
			// Splitter.Panel2
			// 
			this.Splitter.Panel2.Controls.Add(this.ItemList);
			this.Splitter.Size = new System.Drawing.Size(628, 312);
			this.Splitter.SplitterDistance = 228;
			this.Splitter.TabIndex = 3;
			// 
			// BookList
			// 
			this.BookList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.BookHdr});
			this.BookList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BookList.FullRowSelect = true;
			listViewGroup1.Header = "Books";
			listViewGroup1.Name = "listViewGroup1";
			listViewGroup2.Header = "Dragon Magazine";
			listViewGroup2.Name = "listViewGroup2";
			listViewGroup3.Header = "Dungeon Magazine";
			listViewGroup3.Name = "listViewGroup3";
			listViewGroup4.Header = "RPGA Modules";
			listViewGroup4.Name = "listViewGroup4";
			this.BookList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4});
			this.BookList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.BookList.HideSelection = false;
			this.BookList.Location = new System.Drawing.Point(0, 0);
			this.BookList.MultiSelect = false;
			this.BookList.Name = "BookList";
			this.BookList.Size = new System.Drawing.Size(228, 312);
			this.BookList.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.BookList.TabIndex = 3;
			this.BookList.UseCompatibleStateImageBehavior = false;
			this.BookList.View = System.Windows.Forms.View.Details;
			this.BookList.SelectedIndexChanged += new System.EventHandler(this.BookList_SelectedIndexChanged);
			// 
			// BookHdr
			// 
			this.BookHdr.Text = "Source Book";
			this.BookHdr.Width = 200;
			// 
			// ItemList
			// 
			this.ItemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ItemHdr,
            this.InfoHdr});
			this.ItemList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ItemList.FullRowSelect = true;
			listViewGroup5.Header = "Creatures";
			listViewGroup5.Name = "listViewGroup1";
			listViewGroup6.Header = "Traps / Hazards";
			listViewGroup6.Name = "listViewGroup2";
			listViewGroup7.Header = "Magic Items";
			listViewGroup7.Name = "listViewGroup3";
			this.ItemList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup5,
            listViewGroup6,
            listViewGroup7});
			this.ItemList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.ItemList.HideSelection = false;
			this.ItemList.Location = new System.Drawing.Point(0, 0);
			this.ItemList.MultiSelect = false;
			this.ItemList.Name = "ItemList";
			this.ItemList.Size = new System.Drawing.Size(396, 312);
			this.ItemList.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.ItemList.TabIndex = 1;
			this.ItemList.UseCompatibleStateImageBehavior = false;
			this.ItemList.View = System.Windows.Forms.View.Details;
			this.ItemList.DoubleClick += new System.EventHandler(this.ItemList_DoubleClick);
			// 
			// ItemHdr
			// 
			this.ItemHdr.Text = "Item";
			this.ItemHdr.Width = 208;
			// 
			// InfoHdr
			// 
			this.InfoHdr.Text = "Details";
			this.InfoHdr.Width = 158;
			// 
			// SourceBookListForm
			// 
			this.AcceptButton = this.CloseBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(652, 365);
			this.Controls.Add(this.Splitter);
			this.Controls.Add(this.CloseBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SourceBookListForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Dungeons & Dragons Compendium";
			this.Shown += new System.EventHandler(this.SourceBookListForm_Shown);
			this.Splitter.Panel1.ResumeLayout(false);
			this.Splitter.Panel2.ResumeLayout(false);
			this.Splitter.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button CloseBtn;
		private System.Windows.Forms.SplitContainer Splitter;
		private System.Windows.Forms.ListView BookList;
		private System.Windows.Forms.ColumnHeader BookHdr;
		private System.Windows.Forms.ListView ItemList;
		private System.Windows.Forms.ColumnHeader ItemHdr;
		private System.Windows.Forms.ColumnHeader InfoHdr;
	}
}