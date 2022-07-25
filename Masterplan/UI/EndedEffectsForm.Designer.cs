namespace Masterplan.UI
{
	partial class EndedEffectsForm
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
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Ended effects", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("These effects will not be ended this turn", System.Windows.Forms.HorizontalAlignment.Left);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EndedEffectsForm));
			this.OKBtn = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.EffectPanel = new System.Windows.Forms.Panel();
			this.EffectList = new System.Windows.Forms.ListView();
			this.CreatureHdr = new System.Windows.Forms.ColumnHeader();
			this.EffectHdr = new System.Windows.Forms.ColumnHeader();
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.ExtendBtn = new System.Windows.Forms.ToolStripButton();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.EffectPanel.SuspendLayout();
			this.Toolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(360, 261);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 8;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(504, 33);
			this.label1.TabIndex = 9;
			this.label1.Text = "The following ongoing effects are due to end now. If you want to extend one for a" +
				"nother turn, select it and press the Extend button.";
			// 
			// EffectPanel
			// 
			this.EffectPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.EffectPanel.Controls.Add(this.EffectList);
			this.EffectPanel.Controls.Add(this.Toolbar);
			this.EffectPanel.Location = new System.Drawing.Point(12, 45);
			this.EffectPanel.Name = "EffectPanel";
			this.EffectPanel.Size = new System.Drawing.Size(504, 210);
			this.EffectPanel.TabIndex = 10;
			// 
			// EffectList
			// 
			this.EffectList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CreatureHdr,
            this.EffectHdr});
			this.EffectList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EffectList.FullRowSelect = true;
			listViewGroup1.Header = "Ended effects";
			listViewGroup1.Name = "listViewGroup1";
			listViewGroup2.Header = "These effects will not be ended this turn";
			listViewGroup2.Name = "listViewGroup2";
			this.EffectList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
			this.EffectList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.EffectList.HideSelection = false;
			this.EffectList.Location = new System.Drawing.Point(0, 25);
			this.EffectList.MultiSelect = false;
			this.EffectList.Name = "EffectList";
			this.EffectList.Size = new System.Drawing.Size(504, 185);
			this.EffectList.TabIndex = 1;
			this.EffectList.UseCompatibleStateImageBehavior = false;
			this.EffectList.View = System.Windows.Forms.View.Details;
			// 
			// CreatureHdr
			// 
			this.CreatureHdr.Text = "Affected Creature";
			this.CreatureHdr.Width = 150;
			// 
			// EffectHdr
			// 
			this.EffectHdr.Text = "Effect";
			this.EffectHdr.Width = 323;
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExtendBtn});
			this.Toolbar.Location = new System.Drawing.Point(0, 0);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(504, 25);
			this.Toolbar.TabIndex = 0;
			this.Toolbar.Text = Session.I18N.toolStrip1;
			// 
			// ExtendBtn
			// 
			this.ExtendBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ExtendBtn.Image = ((System.Drawing.Image)(resources.GetObject("ExtendBtn.Image")));
			this.ExtendBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ExtendBtn.Name = "ExtendBtn";
			this.ExtendBtn.Size = new System.Drawing.Size(101, 22);
			this.ExtendBtn.Text = "Extend this effect";
			this.ExtendBtn.Click += new System.EventHandler(this.ExtendBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(441, 261);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 11;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// EndedEffectsForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(528, 296);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.EffectPanel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EndedEffectsForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Ended Effects";
			this.EffectPanel.ResumeLayout(false);
			this.EffectPanel.PerformLayout();
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel EffectPanel;
		private System.Windows.Forms.ListView EffectList;
		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ToolStripButton ExtendBtn;
		private System.Windows.Forms.ColumnHeader CreatureHdr;
		private System.Windows.Forms.ColumnHeader EffectHdr;
		private System.Windows.Forms.Button CancelBtn;
	}
}