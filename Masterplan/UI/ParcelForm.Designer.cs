namespace Masterplan.UI
{
	partial class ParcelForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParcelForm));
			this.NameLbl = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.DetailsBox = new System.Windows.Forms.TextBox();
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.ChangeTo = new System.Windows.Forms.ToolStripDropDownButton();
			this.ChangeToMundaneParcel = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.ChangeToMagicItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ChangeToArtifact = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.SelectBtn = new System.Windows.Forms.ToolStripButton();
			this.RandomiseBtn = new System.Windows.Forms.ToolStripButton();
			this.Browser = new System.Windows.Forms.WebBrowser();
			this.MainPanel = new System.Windows.Forms.Panel();
			this.DetailsPanel = new System.Windows.Forms.Panel();
			this.Toolbar.SuspendLayout();
			this.MainPanel.SuspendLayout();
			this.DetailsPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// NameLbl
			// 
			this.NameLbl.AutoSize = true;
			this.NameLbl.Location = new System.Drawing.Point(3, 6);
			this.NameLbl.Name = "NameLbl";
			this.NameLbl.Size = new System.Drawing.Size(38, 13);
			this.NameLbl.TabIndex = 0;
			this.NameLbl.Text = "Name:";
			// 
			// NameBox
			// 
			this.NameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.NameBox.Location = new System.Drawing.Point(47, 3);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(297, 20);
			this.NameBox.TabIndex = 1;
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(203, 359);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 5;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(284, 359);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 6;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// DetailsBox
			// 
			this.DetailsBox.AcceptsReturn = true;
			this.DetailsBox.AcceptsTab = true;
			this.DetailsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DetailsBox.Location = new System.Drawing.Point(3, 29);
			this.DetailsBox.Multiline = true;
			this.DetailsBox.Name = "DetailsBox";
			this.DetailsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.DetailsBox.Size = new System.Drawing.Size(341, 284);
			this.DetailsBox.TabIndex = 0;
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangeTo,
            this.toolStripSeparator1,
            this.SelectBtn,
            this.RandomiseBtn});
			this.Toolbar.Location = new System.Drawing.Point(0, 0);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(347, 25);
			this.Toolbar.TabIndex = 0;
			this.Toolbar.Text = Session.I18N.toolStrip1;
			// 
			// ChangeTo
			// 
			this.ChangeTo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ChangeTo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangeToMundaneParcel,
            this.toolStripSeparator2,
            this.ChangeToMagicItem,
            this.ChangeToArtifact});
			this.ChangeTo.Image = ((System.Drawing.Image)(resources.GetObject("ChangeTo.Image")));
			this.ChangeTo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ChangeTo.Name = "ChangeTo";
			this.ChangeTo.Size = new System.Drawing.Size(78, 22);
			this.ChangeTo.Text = "Change To";
			// 
			// ChangeToMundaneParcel
			// 
			this.ChangeToMundaneParcel.Name = "ChangeToMundaneParcel";
			this.ChangeToMundaneParcel.Size = new System.Drawing.Size(160, 22);
			this.ChangeToMundaneParcel.Text = "Mundane Parcel";
			this.ChangeToMundaneParcel.Click += new System.EventHandler(this.ChangeToMundaneParcel_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(157, 6);
			// 
			// ChangeToMagicItem
			// 
			this.ChangeToMagicItem.Name = "ChangeToMagicItem";
			this.ChangeToMagicItem.Size = new System.Drawing.Size(160, 22);
			this.ChangeToMagicItem.Text = "Magic Item...";
			this.ChangeToMagicItem.Click += new System.EventHandler(this.ChangeToMagicItem_Click);
			// 
			// ChangeToArtifact
			// 
			this.ChangeToArtifact.Name = "ChangeToArtifact";
			this.ChangeToArtifact.Size = new System.Drawing.Size(160, 22);
			this.ChangeToArtifact.Text = "Artifact...";
			this.ChangeToArtifact.Click += new System.EventHandler(this.ChangeToArtifact_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// SelectBtn
			// 
			this.SelectBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SelectBtn.Image = ((System.Drawing.Image)(resources.GetObject("SelectBtn.Image")));
			this.SelectBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SelectBtn.Name = "SelectBtn";
			this.SelectBtn.Size = new System.Drawing.Size(42, 22);
			this.SelectBtn.Text = "Select";
			this.SelectBtn.Click += new System.EventHandler(this.SelectBtn_Click);
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
			// Browser
			// 
			this.Browser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Browser.Location = new System.Drawing.Point(0, 25);
			this.Browser.MinimumSize = new System.Drawing.Size(20, 20);
			this.Browser.Name = "Browser";
			this.Browser.Size = new System.Drawing.Size(347, 316);
			this.Browser.TabIndex = 1;
			// 
			// MainPanel
			// 
			this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.MainPanel.Controls.Add(this.Browser);
			this.MainPanel.Controls.Add(this.DetailsPanel);
			this.MainPanel.Controls.Add(this.Toolbar);
			this.MainPanel.Location = new System.Drawing.Point(12, 12);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(347, 341);
			this.MainPanel.TabIndex = 9;
			// 
			// DetailsPanel
			// 
			this.DetailsPanel.Controls.Add(this.DetailsBox);
			this.DetailsPanel.Controls.Add(this.NameBox);
			this.DetailsPanel.Controls.Add(this.NameLbl);
			this.DetailsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DetailsPanel.Location = new System.Drawing.Point(0, 25);
			this.DetailsPanel.Name = "DetailsPanel";
			this.DetailsPanel.Size = new System.Drawing.Size(347, 316);
			this.DetailsPanel.TabIndex = 2;
			// 
			// ParcelForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(371, 394);
			this.Controls.Add(this.MainPanel);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ParcelForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Treasure Parcel";
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			this.MainPanel.ResumeLayout(false);
			this.MainPanel.PerformLayout();
			this.DetailsPanel.ResumeLayout(false);
			this.DetailsPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label NameLbl;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.TextBox DetailsBox;
		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.WebBrowser Browser;
		private System.Windows.Forms.ToolStripDropDownButton ChangeTo;
		private System.Windows.Forms.ToolStripMenuItem ChangeToMundaneParcel;
		private System.Windows.Forms.ToolStripMenuItem ChangeToMagicItem;
		private System.Windows.Forms.ToolStripMenuItem ChangeToArtifact;
		private System.Windows.Forms.ToolStripButton SelectBtn;
		private System.Windows.Forms.Panel MainPanel;
		private System.Windows.Forms.Panel DetailsPanel;
		private System.Windows.Forms.ToolStripButton RandomiseBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
	}
}