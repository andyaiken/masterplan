namespace Masterplan.Controls
{
	partial class EncounterPanel
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EncounterPanel));
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.EditBtn = new System.Windows.Forms.ToolStripButton();
			this.RunBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.XPLbl = new System.Windows.Forms.ToolStripLabel();
			this.DiffLbl = new System.Windows.Forms.ToolStripLabel();
			this.ItemList = new System.Windows.Forms.ListView();
			this.CreatureHdr = new System.Windows.Forms.ColumnHeader();
			this.CountHdr = new System.Windows.Forms.ColumnHeader();
			this.RoleHdr = new System.Windows.Forms.ColumnHeader();
			this.XPHdr = new System.Windows.Forms.ColumnHeader();
			this.Toolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditBtn,
            this.RunBtn,
            this.toolStripSeparator2,
            this.XPLbl,
            this.DiffLbl});
			this.Toolbar.Location = new System.Drawing.Point(0, 0);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(435, 25);
			this.Toolbar.TabIndex = 0;
			this.Toolbar.Text = "toolStrip1";
			// 
			// EditBtn
			// 
			this.EditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.EditBtn.Image = ((System.Drawing.Image)(resources.GetObject("EditBtn.Image")));
			this.EditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EditBtn.Name = "EditBtn";
			this.EditBtn.Size = new System.Drawing.Size(105, 22);
			this.EditBtn.Text = "Encounter Builder";
			this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
			// 
			// RunBtn
			// 
			this.RunBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.RunBtn.Image = ((System.Drawing.Image)(resources.GetObject("RunBtn.Image")));
			this.RunBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RunBtn.Name = "RunBtn";
			this.RunBtn.Size = new System.Drawing.Size(89, 22);
			this.RunBtn.Text = "Run Encounter";
			this.RunBtn.Click += new System.EventHandler(this.RunBtn_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// XPLbl
			// 
			this.XPLbl.Name = "XPLbl";
			this.XPLbl.Size = new System.Drawing.Size(78, 22);
			this.XPLbl.Text = "[N XP (CL N)]";
			// 
			// DiffLbl
			// 
			this.DiffLbl.Name = "DiffLbl";
			this.DiffLbl.Size = new System.Drawing.Size(62, 22);
			this.DiffLbl.Text = "[difficulty]";
			// 
			// ItemList
			// 
			this.ItemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CreatureHdr,
            this.RoleHdr,
            this.CountHdr,
            this.XPHdr});
			this.ItemList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ItemList.FullRowSelect = true;
			this.ItemList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.ItemList.HideSelection = false;
			this.ItemList.Location = new System.Drawing.Point(0, 25);
			this.ItemList.MultiSelect = false;
			this.ItemList.Name = "ItemList";
			this.ItemList.Size = new System.Drawing.Size(435, 181);
			this.ItemList.TabIndex = 1;
			this.ItemList.UseCompatibleStateImageBehavior = false;
			this.ItemList.View = System.Windows.Forms.View.Details;
			this.ItemList.DoubleClick += new System.EventHandler(this.CreatureList_DoubleClick);
			// 
			// CreatureHdr
			// 
			this.CreatureHdr.Text = "Creature";
			this.CreatureHdr.Width = 150;
			// 
			// CountHdr
			// 
			this.CountHdr.Text = "Count";
			this.CountHdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// RoleHdr
			// 
			this.RoleHdr.Text = "Role";
			this.RoleHdr.Width = 150;
			// 
			// XPHdr
			// 
			this.XPHdr.Text = "XP";
			this.XPHdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// EncounterPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ItemList);
			this.Controls.Add(this.Toolbar);
			this.Name = "EncounterPanel";
			this.Size = new System.Drawing.Size(435, 206);
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ToolStripButton EditBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripLabel XPLbl;
		private System.Windows.Forms.ToolStripLabel DiffLbl;
		private System.Windows.Forms.ListView ItemList;
		private System.Windows.Forms.ColumnHeader CreatureHdr;
		private System.Windows.Forms.ColumnHeader CountHdr;
		private System.Windows.Forms.ColumnHeader RoleHdr;
		private System.Windows.Forms.ColumnHeader XPHdr;
		private System.Windows.Forms.ToolStripButton RunBtn;
	}
}
