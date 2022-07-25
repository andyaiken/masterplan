namespace Masterplan.UI
{
	partial class CreatureSkillsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreatureSkillsForm));
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.SkillList = new System.Windows.Forms.ListView();
			this.SkillHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.TrainedHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.AbilityHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.MiscHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.TotalHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SkillPanel = new System.Windows.Forms.Panel();
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.TrainedBtn = new System.Windows.Forms.ToolStripButton();
			this.EditSkillBtn = new System.Windows.Forms.ToolStripButton();
			this.LevelHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SkillPanel.SuspendLayout();
			this.Toolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(303, 367);
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
			this.CancelBtn.Location = new System.Drawing.Point(384, 367);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 6;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// SkillList
			// 
			this.SkillList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SkillHdr,
            this.LevelHdr,
            this.AbilityHdr,
            this.TrainedHdr,
            this.MiscHdr,
            this.TotalHdr});
			this.SkillList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SkillList.FullRowSelect = true;
			this.SkillList.HideSelection = false;
			this.SkillList.Location = new System.Drawing.Point(0, 25);
			this.SkillList.MultiSelect = false;
			this.SkillList.Name = "SkillList";
			this.SkillList.Size = new System.Drawing.Size(447, 324);
			this.SkillList.TabIndex = 7;
			this.SkillList.UseCompatibleStateImageBehavior = false;
			this.SkillList.View = System.Windows.Forms.View.Details;
			this.SkillList.DoubleClick += new System.EventHandler(this.SkillList_DoubleClick);
			// 
			// SkillHdr
			// 
			this.SkillHdr.Text = "Skill";
			this.SkillHdr.Width = 120;
			// 
			// TrainedHdr
			// 
			this.TrainedHdr.Text = "Trained";
			this.TrainedHdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// AbilityHdr
			// 
			this.AbilityHdr.Text = "Ability";
			this.AbilityHdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// MiscHdr
			// 
			this.MiscHdr.Text = "Misc";
			this.MiscHdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// TotalHdr
			// 
			this.TotalHdr.Text = "Total";
			this.TotalHdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// SkillPanel
			// 
			this.SkillPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SkillPanel.Controls.Add(this.SkillList);
			this.SkillPanel.Controls.Add(this.Toolbar);
			this.SkillPanel.Location = new System.Drawing.Point(12, 12);
			this.SkillPanel.Name = "SkillPanel";
			this.SkillPanel.Size = new System.Drawing.Size(447, 349);
			this.SkillPanel.TabIndex = 8;
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TrainedBtn,
            this.EditSkillBtn});
			this.Toolbar.Location = new System.Drawing.Point(0, 0);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(447, 25);
			this.Toolbar.TabIndex = 0;
			this.Toolbar.Text = Session.I18N.toolStrip1;
			// 
			// TrainedBtn
			// 
			this.TrainedBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.TrainedBtn.Image = ((System.Drawing.Image)(resources.GetObject("TrainedBtn.Image")));
			this.TrainedBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TrainedBtn.Name = "TrainedBtn";
			this.TrainedBtn.Size = new System.Drawing.Size(49, 22);
			this.TrainedBtn.Text = "Trained";
			this.TrainedBtn.Click += new System.EventHandler(this.TrainedBtn_Click);
			// 
			// EditSkillBtn
			// 
			this.EditSkillBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.EditSkillBtn.Image = ((System.Drawing.Image)(resources.GetObject("EditSkillBtn.Image")));
			this.EditSkillBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EditSkillBtn.Name = "EditSkillBtn";
			this.EditSkillBtn.Size = new System.Drawing.Size(55, 22);
			this.EditSkillBtn.Text = "Edit Skill";
			this.EditSkillBtn.Click += new System.EventHandler(this.EditSkillBtn_Click);
			// 
			// LevelHdr
			// 
			this.LevelHdr.Text = Session.I18N.Level;
			this.LevelHdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// CreatureSkillsForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(471, 402);
			this.Controls.Add(this.SkillPanel);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CreatureSkillsForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Creature Skills";
			this.SkillPanel.ResumeLayout(false);
			this.SkillPanel.PerformLayout();
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.ListView SkillList;
		private System.Windows.Forms.ColumnHeader SkillHdr;
		private System.Windows.Forms.ColumnHeader TrainedHdr;
		private System.Windows.Forms.ColumnHeader AbilityHdr;
		private System.Windows.Forms.ColumnHeader MiscHdr;
		private System.Windows.Forms.ColumnHeader TotalHdr;
		private System.Windows.Forms.Panel SkillPanel;
		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ToolStripButton TrainedBtn;
		private System.Windows.Forms.ToolStripButton EditSkillBtn;
		private System.Windows.Forms.ColumnHeader LevelHdr;
	}
}