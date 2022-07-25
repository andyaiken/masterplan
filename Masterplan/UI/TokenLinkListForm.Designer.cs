namespace Masterplan.UI
{
	partial class TokenLinkListForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TokenLinkListForm));
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.RemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.EditBtn = new System.Windows.Forms.ToolStripButton();
			this.EffectList = new System.Windows.Forms.ListView();
			this.LinkHdr = new System.Windows.Forms.ColumnHeader();
			this.TokenHdr = new System.Windows.Forms.ColumnHeader();
			this.Toolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RemoveBtn,
            this.EditBtn});
			this.Toolbar.Location = new System.Drawing.Point(0, 0);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(429, 25);
			this.Toolbar.TabIndex = 0;
			this.Toolbar.Text = Session.I18N.toolStrip1;
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
			// EffectList
			// 
			this.EffectList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TokenHdr,
            this.LinkHdr});
			this.EffectList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EffectList.FullRowSelect = true;
			this.EffectList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.EffectList.HideSelection = false;
			this.EffectList.Location = new System.Drawing.Point(0, 25);
			this.EffectList.MultiSelect = false;
			this.EffectList.Name = "EffectList";
			this.EffectList.Size = new System.Drawing.Size(429, 172);
			this.EffectList.TabIndex = 1;
			this.EffectList.UseCompatibleStateImageBehavior = false;
			this.EffectList.View = System.Windows.Forms.View.Details;
			this.EffectList.DoubleClick += new System.EventHandler(this.EditBtn_Click);
			// 
			// LinkHdr
			// 
			this.LinkHdr.Text = "Link";
			this.LinkHdr.Width = 150;
			// 
			// TokenHdr
			// 
			this.TokenHdr.Text = "Tokens";
			this.TokenHdr.Width = 250;
			// 
			// TokenLinkListForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(429, 197);
			this.Controls.Add(this.EffectList);
			this.Controls.Add(this.Toolbar);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TokenLinkListForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Token Links";
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView EffectList;
		private System.Windows.Forms.ColumnHeader LinkHdr;
		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ToolStripButton RemoveBtn;
		private System.Windows.Forms.ToolStripButton EditBtn;
		private System.Windows.Forms.ColumnHeader TokenHdr;
	}
}