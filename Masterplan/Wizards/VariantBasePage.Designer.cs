namespace Masterplan.Wizards
{
	partial class VariantBasePage
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
			this.InfoLbl = new System.Windows.Forms.Label();
			this.CreatureList = new System.Windows.Forms.ListView();
			this.CreatureHdr = new System.Windows.Forms.ColumnHeader();
			this.RoleHdr = new System.Windows.Forms.ColumnHeader();
			this.panel1 = new System.Windows.Forms.Panel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.SearchLbl = new System.Windows.Forms.ToolStripLabel();
			this.SearchBox = new System.Windows.Forms.ToolStripTextBox();
			this.SearchClearBtn = new System.Windows.Forms.ToolStripLabel();
			this.panel1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// InfoLbl
			// 
			this.InfoLbl.Dock = System.Windows.Forms.DockStyle.Top;
			this.InfoLbl.Location = new System.Drawing.Point(0, 0);
			this.InfoLbl.Name = "InfoLbl";
			this.InfoLbl.Size = new System.Drawing.Size(342, 40);
			this.InfoLbl.TabIndex = 0;
			this.InfoLbl.Text = "Select the creature you want to create a variant of.";
			// 
			// CreatureList
			// 
			this.CreatureList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CreatureHdr,
            this.RoleHdr});
			this.CreatureList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CreatureList.FullRowSelect = true;
			this.CreatureList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.CreatureList.HideSelection = false;
			this.CreatureList.Location = new System.Drawing.Point(0, 25);
			this.CreatureList.MultiSelect = false;
			this.CreatureList.Name = "CreatureList";
			this.CreatureList.Size = new System.Drawing.Size(336, 179);
			this.CreatureList.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.CreatureList.TabIndex = 2;
			this.CreatureList.UseCompatibleStateImageBehavior = false;
			this.CreatureList.View = System.Windows.Forms.View.Details;
			this.CreatureList.DoubleClick += new System.EventHandler(this.CreatureList_DoubleClick);
			// 
			// CreatureHdr
			// 
			this.CreatureHdr.Text = Session.I18N.Creature;
			this.CreatureHdr.Width = 150;
			// 
			// RoleHdr
			// 
			this.RoleHdr.Text = "Role";
			this.RoleHdr.Width = 150;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.CreatureList);
			this.panel1.Controls.Add(this.toolStrip1);
			this.panel1.Location = new System.Drawing.Point(3, 43);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(336, 204);
			this.panel1.TabIndex = 3;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SearchLbl,
            this.SearchBox,
            this.SearchClearBtn});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = Session.I18N.toolStrip1;
			this.toolStrip1.Size = new System.Drawing.Size(336, 25);
			this.toolStrip1.TabIndex = 3;
			this.toolStrip1.Text = Session.I18N.toolStrip1;
			// 
			// SearchLbl
			// 
			this.SearchLbl.Name = "SearchLbl";
			this.SearchLbl.Size = new System.Drawing.Size(45, 22);
			this.SearchLbl.Text = "Search:";
			// 
			// SearchBox
			// 
			this.SearchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.SearchBox.Name = "SearchBox";
			this.SearchBox.Size = new System.Drawing.Size(200, 25);
			this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
			// 
			// SearchClearBtn
			// 
			this.SearchClearBtn.IsLink = true;
			this.SearchClearBtn.Name = "SearchClearBtn";
			this.SearchClearBtn.Size = new System.Drawing.Size(34, 22);
			this.SearchClearBtn.Text = Session.I18N.Clear;
			this.SearchClearBtn.Click += new System.EventHandler(this.SearchClearBtn_Click);
			// 
			// VariantBasePage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.InfoLbl);
			this.Name = "VariantBasePage";
			this.Size = new System.Drawing.Size(342, 250);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label InfoLbl;
		private System.Windows.Forms.ListView CreatureList;
		private System.Windows.Forms.ColumnHeader CreatureHdr;
		private System.Windows.Forms.ColumnHeader RoleHdr;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripLabel SearchLbl;
		private System.Windows.Forms.ToolStripTextBox SearchBox;
		private System.Windows.Forms.ToolStripLabel SearchClearBtn;
	}
}
