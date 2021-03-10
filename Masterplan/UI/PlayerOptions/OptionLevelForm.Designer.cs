namespace Masterplan.UI
{
	partial class OptionLevelForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionLevelForm));
			this.Pages = new System.Windows.Forms.TabControl();
			this.FeaturesPage = new System.Windows.Forms.TabPage();
			this.FeatureList = new System.Windows.Forms.ListView();
			this.FeatureHdr = new System.Windows.Forms.ColumnHeader();
			this.FeatureToolbar = new System.Windows.Forms.ToolStrip();
			this.FeatureAddBtn = new System.Windows.Forms.ToolStripButton();
			this.FeatureRemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.FeatureEditBtn = new System.Windows.Forms.ToolStripButton();
			this.PowersPage = new System.Windows.Forms.TabPage();
			this.PowerList = new System.Windows.Forms.ListView();
			this.PowerHdr = new System.Windows.Forms.ColumnHeader();
			this.PowerToolbar = new System.Windows.Forms.ToolStrip();
			this.PowerAddBtn = new System.Windows.Forms.ToolStripButton();
			this.PowerRemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.PowerEditBtn = new System.Windows.Forms.ToolStripButton();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.Pages.SuspendLayout();
			this.FeaturesPage.SuspendLayout();
			this.FeatureToolbar.SuspendLayout();
			this.PowersPage.SuspendLayout();
			this.PowerToolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// Pages
			// 
			this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Pages.Controls.Add(this.FeaturesPage);
			this.Pages.Controls.Add(this.PowersPage);
			this.Pages.Location = new System.Drawing.Point(12, 12);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(349, 200);
			this.Pages.TabIndex = 2;
			// 
			// FeaturesPage
			// 
			this.FeaturesPage.Controls.Add(this.FeatureList);
			this.FeaturesPage.Controls.Add(this.FeatureToolbar);
			this.FeaturesPage.Location = new System.Drawing.Point(4, 22);
			this.FeaturesPage.Name = "FeaturesPage";
			this.FeaturesPage.Padding = new System.Windows.Forms.Padding(3);
			this.FeaturesPage.Size = new System.Drawing.Size(341, 174);
			this.FeaturesPage.TabIndex = 2;
			this.FeaturesPage.Text = "Features";
			this.FeaturesPage.UseVisualStyleBackColor = true;
			// 
			// FeatureList
			// 
			this.FeatureList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FeatureHdr});
			this.FeatureList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FeatureList.FullRowSelect = true;
			this.FeatureList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.FeatureList.HideSelection = false;
			this.FeatureList.Location = new System.Drawing.Point(3, 28);
			this.FeatureList.MultiSelect = false;
			this.FeatureList.Name = "FeatureList";
			this.FeatureList.Size = new System.Drawing.Size(335, 143);
			this.FeatureList.TabIndex = 1;
			this.FeatureList.UseCompatibleStateImageBehavior = false;
			this.FeatureList.View = System.Windows.Forms.View.Details;
			this.FeatureList.DoubleClick += new System.EventHandler(this.FeatureEditBtn_Click);
			// 
			// FeatureHdr
			// 
			this.FeatureHdr.Text = "Feature";
			this.FeatureHdr.Width = 300;
			// 
			// FeatureToolbar
			// 
			this.FeatureToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FeatureAddBtn,
            this.FeatureRemoveBtn,
            this.FeatureEditBtn});
			this.FeatureToolbar.Location = new System.Drawing.Point(3, 3);
			this.FeatureToolbar.Name = "FeatureToolbar";
			this.FeatureToolbar.Size = new System.Drawing.Size(335, 25);
			this.FeatureToolbar.TabIndex = 0;
			this.FeatureToolbar.Text = "toolStrip1";
			// 
			// FeatureAddBtn
			// 
			this.FeatureAddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.FeatureAddBtn.Image = ((System.Drawing.Image)(resources.GetObject("FeatureAddBtn.Image")));
			this.FeatureAddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.FeatureAddBtn.Name = "FeatureAddBtn";
			this.FeatureAddBtn.Size = new System.Drawing.Size(33, 22);
			this.FeatureAddBtn.Text = "Add";
			this.FeatureAddBtn.Click += new System.EventHandler(this.FeatureAddBtn_Click);
			// 
			// FeatureRemoveBtn
			// 
			this.FeatureRemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.FeatureRemoveBtn.Image = ((System.Drawing.Image)(resources.GetObject("FeatureRemoveBtn.Image")));
			this.FeatureRemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.FeatureRemoveBtn.Name = "FeatureRemoveBtn";
			this.FeatureRemoveBtn.Size = new System.Drawing.Size(54, 22);
			this.FeatureRemoveBtn.Text = "Remove";
			this.FeatureRemoveBtn.Click += new System.EventHandler(this.FeatureRemoveBtn_Click);
			// 
			// FeatureEditBtn
			// 
			this.FeatureEditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.FeatureEditBtn.Image = ((System.Drawing.Image)(resources.GetObject("FeatureEditBtn.Image")));
			this.FeatureEditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.FeatureEditBtn.Name = "FeatureEditBtn";
			this.FeatureEditBtn.Size = new System.Drawing.Size(31, 22);
			this.FeatureEditBtn.Text = "Edit";
			this.FeatureEditBtn.Click += new System.EventHandler(this.FeatureEditBtn_Click);
			// 
			// PowersPage
			// 
			this.PowersPage.Controls.Add(this.PowerList);
			this.PowersPage.Controls.Add(this.PowerToolbar);
			this.PowersPage.Location = new System.Drawing.Point(4, 22);
			this.PowersPage.Name = "PowersPage";
			this.PowersPage.Padding = new System.Windows.Forms.Padding(3);
			this.PowersPage.Size = new System.Drawing.Size(341, 222);
			this.PowersPage.TabIndex = 3;
			this.PowersPage.Text = "Powers";
			this.PowersPage.UseVisualStyleBackColor = true;
			// 
			// PowerList
			// 
			this.PowerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PowerHdr});
			this.PowerList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PowerList.FullRowSelect = true;
			this.PowerList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.PowerList.HideSelection = false;
			this.PowerList.Location = new System.Drawing.Point(3, 28);
			this.PowerList.MultiSelect = false;
			this.PowerList.Name = "PowerList";
			this.PowerList.Size = new System.Drawing.Size(335, 191);
			this.PowerList.TabIndex = 2;
			this.PowerList.UseCompatibleStateImageBehavior = false;
			this.PowerList.View = System.Windows.Forms.View.Details;
			this.PowerList.DoubleClick += new System.EventHandler(this.PowerEditBtn_Click);
			// 
			// PowerHdr
			// 
			this.PowerHdr.Text = "Feature";
			this.PowerHdr.Width = 300;
			// 
			// PowerToolbar
			// 
			this.PowerToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PowerAddBtn,
            this.PowerRemoveBtn,
            this.PowerEditBtn});
			this.PowerToolbar.Location = new System.Drawing.Point(3, 3);
			this.PowerToolbar.Name = "PowerToolbar";
			this.PowerToolbar.Size = new System.Drawing.Size(335, 25);
			this.PowerToolbar.TabIndex = 1;
			this.PowerToolbar.Text = "toolStrip2";
			// 
			// PowerAddBtn
			// 
			this.PowerAddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.PowerAddBtn.Image = ((System.Drawing.Image)(resources.GetObject("PowerAddBtn.Image")));
			this.PowerAddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.PowerAddBtn.Name = "PowerAddBtn";
			this.PowerAddBtn.Size = new System.Drawing.Size(33, 22);
			this.PowerAddBtn.Text = "Add";
			this.PowerAddBtn.Click += new System.EventHandler(this.PowerAddBtn_Click);
			// 
			// PowerRemoveBtn
			// 
			this.PowerRemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.PowerRemoveBtn.Image = ((System.Drawing.Image)(resources.GetObject("PowerRemoveBtn.Image")));
			this.PowerRemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.PowerRemoveBtn.Name = "PowerRemoveBtn";
			this.PowerRemoveBtn.Size = new System.Drawing.Size(54, 22);
			this.PowerRemoveBtn.Text = "Remove";
			this.PowerRemoveBtn.Click += new System.EventHandler(this.PowerRemoveBtn_Click);
			// 
			// PowerEditBtn
			// 
			this.PowerEditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.PowerEditBtn.Image = ((System.Drawing.Image)(resources.GetObject("PowerEditBtn.Image")));
			this.PowerEditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.PowerEditBtn.Name = "PowerEditBtn";
			this.PowerEditBtn.Size = new System.Drawing.Size(31, 22);
			this.PowerEditBtn.Text = "Edit";
			this.PowerEditBtn.Click += new System.EventHandler(this.PowerEditBtn_Click);
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(205, 218);
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
			this.CancelBtn.Location = new System.Drawing.Point(286, 218);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 4;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// OptionLevelForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(373, 253);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.Pages);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionLevelForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Level";
			this.Pages.ResumeLayout(false);
			this.FeaturesPage.ResumeLayout(false);
			this.FeaturesPage.PerformLayout();
			this.FeatureToolbar.ResumeLayout(false);
			this.FeatureToolbar.PerformLayout();
			this.PowersPage.ResumeLayout(false);
			this.PowersPage.PerformLayout();
			this.PowerToolbar.ResumeLayout(false);
			this.PowerToolbar.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.TabPage FeaturesPage;
		private System.Windows.Forms.TabPage PowersPage;
		private System.Windows.Forms.ListView FeatureList;
		private System.Windows.Forms.ColumnHeader FeatureHdr;
		private System.Windows.Forms.ToolStrip FeatureToolbar;
		private System.Windows.Forms.ToolStripButton FeatureAddBtn;
		private System.Windows.Forms.ToolStripButton FeatureRemoveBtn;
		private System.Windows.Forms.ToolStripButton FeatureEditBtn;
		private System.Windows.Forms.ListView PowerList;
		private System.Windows.Forms.ColumnHeader PowerHdr;
		private System.Windows.Forms.ToolStrip PowerToolbar;
		private System.Windows.Forms.ToolStripButton PowerAddBtn;
		private System.Windows.Forms.ToolStripButton PowerRemoveBtn;
		private System.Windows.Forms.ToolStripButton PowerEditBtn;
	}
}