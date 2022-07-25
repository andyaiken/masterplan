namespace Masterplan.UI
{
	partial class SavingThrowForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SavingThrowForm));
			this.CancelBtn = new System.Windows.Forms.Button();
			this.OKBtn = new System.Windows.Forms.Button();
			this.ModLbl = new System.Windows.Forms.Label();
			this.ModBox = new System.Windows.Forms.NumericUpDown();
			this.ListPanel = new System.Windows.Forms.Panel();
			this.EffectList = new System.Windows.Forms.ListView();
			this.EffectHdr = new System.Windows.Forms.ColumnHeader();
			this.SaveHdr = new System.Windows.Forms.ColumnHeader();
			this.ResultHdr = new System.Windows.Forms.ColumnHeader();
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.AddBtn = new System.Windows.Forms.ToolStripButton();
			this.SubtractBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.RollBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.SavedBtn = new System.Windows.Forms.ToolStripButton();
			this.NotSavedBtn = new System.Windows.Forms.ToolStripButton();
			this.InfoLbl = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.ModBox)).BeginInit();
			this.ListPanel.SuspendLayout();
			this.Toolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(415, 277);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 5;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(334, 277);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 4;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// ModLbl
			// 
			this.ModLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ModLbl.AutoSize = true;
			this.ModLbl.Location = new System.Drawing.Point(12, 282);
			this.ModLbl.Name = "ModLbl";
			this.ModLbl.Size = new System.Drawing.Size(47, 13);
			this.ModLbl.TabIndex = 2;
			this.ModLbl.Text = "Modifier:";
			// 
			// ModBox
			// 
			this.ModBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ModBox.Location = new System.Drawing.Point(65, 280);
			this.ModBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.ModBox.Name = "ModBox";
			this.ModBox.Size = new System.Drawing.Size(263, 20);
			this.ModBox.TabIndex = 3;
			this.ModBox.ValueChanged += new System.EventHandler(this.ModBox_ValueChanged);
			// 
			// ListPanel
			// 
			this.ListPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ListPanel.Controls.Add(this.EffectList);
			this.ListPanel.Controls.Add(this.Toolbar);
			this.ListPanel.Location = new System.Drawing.Point(12, 33);
			this.ListPanel.Name = "ListPanel";
			this.ListPanel.Size = new System.Drawing.Size(478, 238);
			this.ListPanel.TabIndex = 1;
			// 
			// EffectList
			// 
			this.EffectList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EffectHdr,
            this.SaveHdr,
            this.ResultHdr});
			this.EffectList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EffectList.FullRowSelect = true;
			this.EffectList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.EffectList.HideSelection = false;
			this.EffectList.Location = new System.Drawing.Point(0, 25);
			this.EffectList.MultiSelect = false;
			this.EffectList.Name = "EffectList";
			this.EffectList.Size = new System.Drawing.Size(478, 213);
			this.EffectList.TabIndex = 1;
			this.EffectList.UseCompatibleStateImageBehavior = false;
			this.EffectList.View = System.Windows.Forms.View.Details;
			// 
			// EffectHdr
			// 
			this.EffectHdr.Text = "Effect";
			this.EffectHdr.Width = 257;
			// 
			// SaveHdr
			// 
			this.SaveHdr.Text = "Roll";
			this.SaveHdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.SaveHdr.Width = 76;
			// 
			// ResultHdr
			// 
			this.ResultHdr.Text = "Result";
			this.ResultHdr.Width = 111;
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddBtn,
            this.SubtractBtn,
            this.toolStripSeparator1,
            this.RollBtn,
            this.toolStripSeparator2,
            this.SavedBtn,
            this.NotSavedBtn});
			this.Toolbar.Location = new System.Drawing.Point(0, 0);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(478, 25);
			this.Toolbar.TabIndex = 2;
			this.Toolbar.Text = Session.I18N.toolStrip1;
			// 
			// AddBtn
			// 
			this.AddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.AddBtn.Image = ((System.Drawing.Image)(resources.GetObject("AddBtn.Image")));
			this.AddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AddBtn.Name = "AddBtn";
			this.AddBtn.Size = new System.Drawing.Size(23, 22);
			this.AddBtn.Text = "+";
			this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
			// 
			// SubtractBtn
			// 
			this.SubtractBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SubtractBtn.Image = ((System.Drawing.Image)(resources.GetObject("SubtractBtn.Image")));
			this.SubtractBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SubtractBtn.Name = "SubtractBtn";
			this.SubtractBtn.Size = new System.Drawing.Size(23, 22);
			this.SubtractBtn.Text = "-";
			this.SubtractBtn.Click += new System.EventHandler(this.SubtractBtn_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// RollBtn
			// 
			this.RollBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.RollBtn.Image = ((System.Drawing.Image)(resources.GetObject("RollBtn.Image")));
			this.RollBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RollBtn.Name = "RollBtn";
			this.RollBtn.Size = new System.Drawing.Size(41, 22);
			this.RollBtn.Text = "Reroll";
			this.RollBtn.Click += new System.EventHandler(this.RollBtn_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// SavedBtn
			// 
			this.SavedBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SavedBtn.Image = ((System.Drawing.Image)(resources.GetObject("SavedBtn.Image")));
			this.SavedBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SavedBtn.Name = "SavedBtn";
			this.SavedBtn.Size = new System.Drawing.Size(86, 22);
			this.SavedBtn.Text = "Mark as Saved";
			this.SavedBtn.Click += new System.EventHandler(this.SavedBtn_Click);
			// 
			// NotSavedBtn
			// 
			this.NotSavedBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.NotSavedBtn.Image = ((System.Drawing.Image)(resources.GetObject("NotSavedBtn.Image")));
			this.NotSavedBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.NotSavedBtn.Name = "NotSavedBtn";
			this.NotSavedBtn.Size = new System.Drawing.Size(109, 22);
			this.NotSavedBtn.Text = "Mark as Not Saved";
			this.NotSavedBtn.Click += new System.EventHandler(this.NotSavedBtn_Click);
			// 
			// InfoLbl
			// 
			this.InfoLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.InfoLbl.Location = new System.Drawing.Point(12, 9);
			this.InfoLbl.Name = "InfoLbl";
			this.InfoLbl.Size = new System.Drawing.Size(478, 21);
			this.InfoLbl.TabIndex = 0;
			this.InfoLbl.Text = "Saving throws are due to be rolled against the following effects.";
			// 
			// SavingThrowForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(502, 312);
			this.Controls.Add(this.InfoLbl);
			this.Controls.Add(this.ListPanel);
			this.Controls.Add(this.ModBox);
			this.Controls.Add(this.ModLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SavingThrowForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Saving Throws";
			((System.ComponentModel.ISupportInitialize)(this.ModBox)).EndInit();
			this.ListPanel.ResumeLayout(false);
			this.ListPanel.PerformLayout();
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Label ModLbl;
		private System.Windows.Forms.NumericUpDown ModBox;
		private System.Windows.Forms.Panel ListPanel;
		private System.Windows.Forms.ListView EffectList;
		private System.Windows.Forms.ColumnHeader EffectHdr;
		private System.Windows.Forms.ColumnHeader SaveHdr;
		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ToolStripButton AddBtn;
		private System.Windows.Forms.ToolStripButton SubtractBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton RollBtn;
		private System.Windows.Forms.Label InfoLbl;
		private System.Windows.Forms.ColumnHeader ResultHdr;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton SavedBtn;
		private System.Windows.Forms.ToolStripButton NotSavedBtn;
	}
}