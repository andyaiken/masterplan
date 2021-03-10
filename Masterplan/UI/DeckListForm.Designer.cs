namespace Masterplan.UI
{
	partial class DeckListForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeckListForm));
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.AddBtn = new System.Windows.Forms.ToolStripButton();
			this.RemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.EditBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.ViewBtn = new System.Windows.Forms.ToolStripButton();
			this.RunBtn = new System.Windows.Forms.ToolStripSplitButton();
			this.RunMap = new System.Windows.Forms.ToolStripMenuItem();
			this.DeckList = new System.Windows.Forms.ListView();
			this.NameHdr = new System.Windows.Forms.ColumnHeader();
			this.LevelHdr = new System.Windows.Forms.ColumnHeader();
			this.CardsHdr = new System.Windows.Forms.ColumnHeader();
			this.MainPanel = new System.Windows.Forms.Panel();
			this.CloseBtn = new System.Windows.Forms.Button();
			this.Toolbar.SuspendLayout();
			this.MainPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddBtn,
            this.RemoveBtn,
            this.EditBtn,
            this.toolStripSeparator1,
            this.ViewBtn,
            this.RunBtn});
			this.Toolbar.Location = new System.Drawing.Point(0, 0);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(378, 25);
			this.Toolbar.TabIndex = 0;
			this.Toolbar.Text = "toolStrip1";
			// 
			// AddBtn
			// 
			this.AddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.AddBtn.Image = ((System.Drawing.Image)(resources.GetObject("AddBtn.Image")));
			this.AddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AddBtn.Name = "AddBtn";
			this.AddBtn.Size = new System.Drawing.Size(33, 22);
			this.AddBtn.Text = "Add";
			this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
			// 
			// RemoveBtn
			// 
			this.RemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.RemoveBtn.Image = ((System.Drawing.Image)(resources.GetObject("RemoveBtn.Image")));
			this.RemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RemoveBtn.Name = "RemoveBtn";
			this.RemoveBtn.Size = new System.Drawing.Size(54, 22);
			this.RemoveBtn.Text = "Remove";
			this.RemoveBtn.Click += new System.EventHandler(this.RemoveBtn_Click);
			// 
			// EditBtn
			// 
			this.EditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.EditBtn.Image = ((System.Drawing.Image)(resources.GetObject("EditBtn.Image")));
			this.EditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EditBtn.Name = "EditBtn";
			this.EditBtn.Size = new System.Drawing.Size(31, 22);
			this.EditBtn.Text = "Edit";
			this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// ViewBtn
			// 
			this.ViewBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ViewBtn.Image = ((System.Drawing.Image)(resources.GetObject("ViewBtn.Image")));
			this.ViewBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ViewBtn.Name = "ViewBtn";
			this.ViewBtn.Size = new System.Drawing.Size(69, 22);
			this.ViewBtn.Text = "View Cards";
			this.ViewBtn.Click += new System.EventHandler(this.ViewBtn_Click);
			// 
			// RunBtn
			// 
			this.RunBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.RunBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RunMap});
			this.RunBtn.Image = ((System.Drawing.Image)(resources.GetObject("RunBtn.Image")));
			this.RunBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RunBtn.Name = "RunBtn";
			this.RunBtn.Size = new System.Drawing.Size(101, 22);
			this.RunBtn.Text = "Run Encounter";
			this.RunBtn.ButtonClick += new System.EventHandler(this.RunBtn_Click);
			// 
			// RunMap
			// 
			this.RunMap.Name = "RunMap";
			this.RunMap.Size = new System.Drawing.Size(150, 22);
			this.RunMap.Text = "Choose Map...";
			this.RunMap.Click += new System.EventHandler(this.RunMap_Click);
			// 
			// DeckList
			// 
			this.DeckList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameHdr,
            this.LevelHdr,
            this.CardsHdr});
			this.DeckList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DeckList.FullRowSelect = true;
			this.DeckList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.DeckList.HideSelection = false;
			this.DeckList.Location = new System.Drawing.Point(0, 25);
			this.DeckList.MultiSelect = false;
			this.DeckList.Name = "DeckList";
			this.DeckList.Size = new System.Drawing.Size(378, 255);
			this.DeckList.TabIndex = 1;
			this.DeckList.UseCompatibleStateImageBehavior = false;
			this.DeckList.View = System.Windows.Forms.View.Details;
			this.DeckList.DoubleClick += new System.EventHandler(this.ViewBtn_Click);
			// 
			// NameHdr
			// 
			this.NameHdr.Text = "Deck";
			this.NameHdr.Width = 225;
			// 
			// LevelHdr
			// 
			this.LevelHdr.Text = "Level";
			this.LevelHdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// CardsHdr
			// 
			this.CardsHdr.Text = "Cards";
			this.CardsHdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// MainPanel
			// 
			this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.MainPanel.Controls.Add(this.DeckList);
			this.MainPanel.Controls.Add(this.Toolbar);
			this.MainPanel.Location = new System.Drawing.Point(12, 12);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(378, 280);
			this.MainPanel.TabIndex = 2;
			// 
			// CloseBtn
			// 
			this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.CloseBtn.Location = new System.Drawing.Point(315, 298);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.Size = new System.Drawing.Size(75, 23);
			this.CloseBtn.TabIndex = 3;
			this.CloseBtn.Text = "Close";
			this.CloseBtn.UseVisualStyleBackColor = true;
			// 
			// DeckListForm
			// 
			this.AcceptButton = this.CloseBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(402, 333);
			this.Controls.Add(this.CloseBtn);
			this.Controls.Add(this.MainPanel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DeckListForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Encounter Decks";
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			this.MainPanel.ResumeLayout(false);
			this.MainPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ListView DeckList;
		private System.Windows.Forms.ColumnHeader NameHdr;
		private System.Windows.Forms.ToolStripButton AddBtn;
		private System.Windows.Forms.ToolStripButton RemoveBtn;
		private System.Windows.Forms.ColumnHeader LevelHdr;
		private System.Windows.Forms.ColumnHeader CardsHdr;
		private System.Windows.Forms.ToolStripButton EditBtn;
		private System.Windows.Forms.Panel MainPanel;
		private System.Windows.Forms.Button CloseBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton ViewBtn;
		private System.Windows.Forms.ToolStripSplitButton RunBtn;
		private System.Windows.Forms.ToolStripMenuItem RunMap;

	}
}