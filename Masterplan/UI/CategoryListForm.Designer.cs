namespace Masterplan.UI
{
	partial class CategoryListForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryListForm));
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.CatList = new System.Windows.Forms.ListView();
			this.CatHdr = new System.Windows.Forms.ColumnHeader();
			this.ListPanel = new System.Windows.Forms.Panel();
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.SelectBtn = new System.Windows.Forms.ToolStripButton();
			this.DeselectBtn = new System.Windows.Forms.ToolStripButton();
			this.ListPanel.SuspendLayout();
			this.Toolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(93, 295);
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
			this.CancelBtn.Location = new System.Drawing.Point(174, 295);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 2;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// CatList
			// 
			this.CatList.CheckBoxes = true;
			this.CatList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CatHdr});
			this.CatList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CatList.FullRowSelect = true;
			this.CatList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.CatList.HideSelection = false;
			this.CatList.Location = new System.Drawing.Point(0, 25);
			this.CatList.MultiSelect = false;
			this.CatList.Name = "CatList";
			this.CatList.Size = new System.Drawing.Size(237, 252);
			this.CatList.TabIndex = 1;
			this.CatList.UseCompatibleStateImageBehavior = false;
			this.CatList.View = System.Windows.Forms.View.Details;
			// 
			// CatHdr
			// 
			this.CatHdr.Text = "Category";
			this.CatHdr.Width = 200;
			// 
			// ListPanel
			// 
			this.ListPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ListPanel.Controls.Add(this.CatList);
			this.ListPanel.Controls.Add(this.Toolbar);
			this.ListPanel.Location = new System.Drawing.Point(12, 12);
			this.ListPanel.Name = "ListPanel";
			this.ListPanel.Size = new System.Drawing.Size(237, 277);
			this.ListPanel.TabIndex = 0;
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectBtn,
            this.DeselectBtn});
			this.Toolbar.Location = new System.Drawing.Point(0, 0);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(237, 25);
			this.Toolbar.TabIndex = 0;
			this.Toolbar.Text = Session.I18N.toolStrip1;
			// 
			// SelectBtn
			// 
			this.SelectBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SelectBtn.Image = ((System.Drawing.Image)(resources.GetObject("SelectBtn.Image")));
			this.SelectBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SelectBtn.Name = "SelectBtn";
			this.SelectBtn.Size = new System.Drawing.Size(59, 22);
			this.SelectBtn.Text = "Select All";
			this.SelectBtn.Click += new System.EventHandler(this.SelectBtn_Click);
			// 
			// DeselectBtn
			// 
			this.DeselectBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.DeselectBtn.Image = ((System.Drawing.Image)(resources.GetObject("DeselectBtn.Image")));
			this.DeselectBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.DeselectBtn.Name = "DeselectBtn";
			this.DeselectBtn.Size = new System.Drawing.Size(72, 22);
			this.DeselectBtn.Text = "Deselect All";
			this.DeselectBtn.Click += new System.EventHandler(this.DeselectBtn_Click);
			// 
			// CategoryListForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(261, 330);
			this.Controls.Add(this.ListPanel);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CategoryListForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Categories";
			this.ListPanel.ResumeLayout(false);
			this.ListPanel.PerformLayout();
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.ListView CatList;
		private System.Windows.Forms.ColumnHeader CatHdr;
		private System.Windows.Forms.Panel ListPanel;
		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ToolStripButton SelectBtn;
		private System.Windows.Forms.ToolStripButton DeselectBtn;
	}
}