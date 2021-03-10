namespace Masterplan.UI
{
	partial class DamageModListForm
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
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Immunities", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Resistances", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Vulnerabilities", System.Windows.Forms.HorizontalAlignment.Left);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DamageModListForm));
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.DamageList = new System.Windows.Forms.ListView();
			this.DmgModHdr = new System.Windows.Forms.ColumnHeader();
			this.DamageToolbar = new System.Windows.Forms.ToolStrip();
			this.AddDmgBtn = new System.Windows.Forms.ToolStripButton();
			this.RemoveDmgBtn = new System.Windows.Forms.ToolStripButton();
			this.EditDmgBtn = new System.Windows.Forms.ToolStripButton();
			this.ResistLbl = new System.Windows.Forms.Label();
			this.ResistBox = new System.Windows.Forms.TextBox();
			this.VulnerableLbl = new System.Windows.Forms.Label();
			this.VulnerableBox = new System.Windows.Forms.TextBox();
			this.ImmuneLbl = new System.Windows.Forms.Label();
			this.ImmuneBox = new System.Windows.Forms.TextBox();
			this.ModPanel = new System.Windows.Forms.Panel();
			this.SpecialGroup = new System.Windows.Forms.GroupBox();
			this.DamageToolbar.SuspendLayout();
			this.ModPanel.SuspendLayout();
			this.SpecialGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(186, 299);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 2;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(267, 299);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 3;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// DamageList
			// 
			this.DamageList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DmgModHdr});
			this.DamageList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DamageList.FullRowSelect = true;
			listViewGroup1.Header = "Immunities";
			listViewGroup1.Name = "ImmGrp";
			listViewGroup2.Header = "Resistances";
			listViewGroup2.Name = "ResGrp";
			listViewGroup3.Header = "Vulnerabilities";
			listViewGroup3.Name = "VulnGrp";
			this.DamageList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
			this.DamageList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.DamageList.HideSelection = false;
			this.DamageList.Location = new System.Drawing.Point(0, 25);
			this.DamageList.MultiSelect = false;
			this.DamageList.Name = "DamageList";
			this.DamageList.Size = new System.Drawing.Size(330, 145);
			this.DamageList.TabIndex = 1;
			this.DamageList.UseCompatibleStateImageBehavior = false;
			this.DamageList.View = System.Windows.Forms.View.Details;
			this.DamageList.DoubleClick += new System.EventHandler(this.EditDmgBtn_Click);
			// 
			// DmgModHdr
			// 
			this.DmgModHdr.Text = "Damage Modifier";
			this.DmgModHdr.Width = 296;
			// 
			// DamageToolbar
			// 
			this.DamageToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddDmgBtn,
            this.RemoveDmgBtn,
            this.EditDmgBtn});
			this.DamageToolbar.Location = new System.Drawing.Point(0, 0);
			this.DamageToolbar.Name = "DamageToolbar";
			this.DamageToolbar.Size = new System.Drawing.Size(330, 25);
			this.DamageToolbar.TabIndex = 0;
			this.DamageToolbar.Text = "toolStrip1";
			// 
			// AddDmgBtn
			// 
			this.AddDmgBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.AddDmgBtn.Image = ((System.Drawing.Image)(resources.GetObject("AddDmgBtn.Image")));
			this.AddDmgBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AddDmgBtn.Name = "AddDmgBtn";
			this.AddDmgBtn.Size = new System.Drawing.Size(33, 22);
			this.AddDmgBtn.Text = "Add";
			this.AddDmgBtn.Click += new System.EventHandler(this.AddDmgBtn_Click);
			// 
			// RemoveDmgBtn
			// 
			this.RemoveDmgBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.RemoveDmgBtn.Image = ((System.Drawing.Image)(resources.GetObject("RemoveDmgBtn.Image")));
			this.RemoveDmgBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RemoveDmgBtn.Name = "RemoveDmgBtn";
			this.RemoveDmgBtn.Size = new System.Drawing.Size(54, 22);
			this.RemoveDmgBtn.Text = "Remove";
			this.RemoveDmgBtn.Click += new System.EventHandler(this.RemoveDmgBtn_Click);
			// 
			// EditDmgBtn
			// 
			this.EditDmgBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.EditDmgBtn.Image = ((System.Drawing.Image)(resources.GetObject("EditDmgBtn.Image")));
			this.EditDmgBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EditDmgBtn.Name = "EditDmgBtn";
			this.EditDmgBtn.Size = new System.Drawing.Size(31, 22);
			this.EditDmgBtn.Text = "Edit";
			this.EditDmgBtn.Click += new System.EventHandler(this.EditDmgBtn_Click);
			// 
			// ResistLbl
			// 
			this.ResistLbl.AutoSize = true;
			this.ResistLbl.Location = new System.Drawing.Point(6, 22);
			this.ResistLbl.Name = "ResistLbl";
			this.ResistLbl.Size = new System.Drawing.Size(63, 13);
			this.ResistLbl.TabIndex = 0;
			this.ResistLbl.Text = "Resistance:";
			// 
			// ResistBox
			// 
			this.ResistBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ResistBox.Location = new System.Drawing.Point(78, 19);
			this.ResistBox.Name = "ResistBox";
			this.ResistBox.Size = new System.Drawing.Size(246, 20);
			this.ResistBox.TabIndex = 1;
			// 
			// VulnerableLbl
			// 
			this.VulnerableLbl.AutoSize = true;
			this.VulnerableLbl.Location = new System.Drawing.Point(6, 48);
			this.VulnerableLbl.Name = "VulnerableLbl";
			this.VulnerableLbl.Size = new System.Drawing.Size(66, 13);
			this.VulnerableLbl.TabIndex = 2;
			this.VulnerableLbl.Text = "Vulnerability:";
			// 
			// VulnerableBox
			// 
			this.VulnerableBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.VulnerableBox.Location = new System.Drawing.Point(78, 45);
			this.VulnerableBox.Name = "VulnerableBox";
			this.VulnerableBox.Size = new System.Drawing.Size(246, 20);
			this.VulnerableBox.TabIndex = 3;
			// 
			// ImmuneLbl
			// 
			this.ImmuneLbl.AutoSize = true;
			this.ImmuneLbl.Location = new System.Drawing.Point(6, 74);
			this.ImmuneLbl.Name = "ImmuneLbl";
			this.ImmuneLbl.Size = new System.Drawing.Size(51, 13);
			this.ImmuneLbl.TabIndex = 4;
			this.ImmuneLbl.Text = "Immunity:";
			// 
			// ImmuneBox
			// 
			this.ImmuneBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ImmuneBox.Location = new System.Drawing.Point(78, 71);
			this.ImmuneBox.Name = "ImmuneBox";
			this.ImmuneBox.Size = new System.Drawing.Size(246, 20);
			this.ImmuneBox.TabIndex = 5;
			// 
			// ModPanel
			// 
			this.ModPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ModPanel.Controls.Add(this.DamageList);
			this.ModPanel.Controls.Add(this.DamageToolbar);
			this.ModPanel.Location = new System.Drawing.Point(12, 12);
			this.ModPanel.Name = "ModPanel";
			this.ModPanel.Size = new System.Drawing.Size(330, 170);
			this.ModPanel.TabIndex = 0;
			// 
			// SpecialGroup
			// 
			this.SpecialGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.SpecialGroup.Controls.Add(this.ImmuneBox);
			this.SpecialGroup.Controls.Add(this.ResistBox);
			this.SpecialGroup.Controls.Add(this.ImmuneLbl);
			this.SpecialGroup.Controls.Add(this.ResistLbl);
			this.SpecialGroup.Controls.Add(this.VulnerableBox);
			this.SpecialGroup.Controls.Add(this.VulnerableLbl);
			this.SpecialGroup.Location = new System.Drawing.Point(12, 188);
			this.SpecialGroup.Name = "SpecialGroup";
			this.SpecialGroup.Size = new System.Drawing.Size(330, 105);
			this.SpecialGroup.TabIndex = 1;
			this.SpecialGroup.TabStop = false;
			this.SpecialGroup.Text = "Special";
			// 
			// DamageModListForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(354, 334);
			this.Controls.Add(this.SpecialGroup);
			this.Controls.Add(this.ModPanel);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DamageModListForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Resist / Vulnerable / Immune";
			this.DamageToolbar.ResumeLayout(false);
			this.DamageToolbar.PerformLayout();
			this.ModPanel.ResumeLayout(false);
			this.ModPanel.PerformLayout();
			this.SpecialGroup.ResumeLayout(false);
			this.SpecialGroup.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.ListView DamageList;
		private System.Windows.Forms.ColumnHeader DmgModHdr;
		private System.Windows.Forms.ToolStrip DamageToolbar;
		private System.Windows.Forms.ToolStripButton AddDmgBtn;
		private System.Windows.Forms.ToolStripButton RemoveDmgBtn;
		private System.Windows.Forms.ToolStripButton EditDmgBtn;
		private System.Windows.Forms.TextBox ImmuneBox;
		private System.Windows.Forms.Label ImmuneLbl;
		private System.Windows.Forms.TextBox VulnerableBox;
		private System.Windows.Forms.Label VulnerableLbl;
		private System.Windows.Forms.TextBox ResistBox;
		private System.Windows.Forms.Label ResistLbl;
		private System.Windows.Forms.Panel ModPanel;
		private System.Windows.Forms.GroupBox SpecialGroup;
	}
}