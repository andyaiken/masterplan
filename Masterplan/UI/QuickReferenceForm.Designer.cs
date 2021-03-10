namespace Masterplan.UI
{
    partial class QuickReferenceForm
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
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Normal Damage", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Limited Damage", System.Windows.Forms.HorizontalAlignment.Left);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickReferenceForm));
			this.LevelLbl = new System.Windows.Forms.Label();
			this.LevelBox = new System.Windows.Forms.NumericUpDown();
			this.SkillGroup = new System.Windows.Forms.GroupBox();
			this.SkillList = new System.Windows.Forms.ListView();
			this.DiffHdr = new System.Windows.Forms.ColumnHeader();
			this.DCHdr = new System.Windows.Forms.ColumnHeader();
			this.DamageGroup = new System.Windows.Forms.GroupBox();
			this.DamageList = new System.Windows.Forms.ListView();
			this.TargetHdr = new System.Windows.Forms.ColumnHeader();
			this.DmgHdr = new System.Windows.Forms.ColumnHeader();
			this.Pages = new System.Windows.Forms.TabControl();
			this.ReferencePage = new System.Windows.Forms.TabPage();
			((System.ComponentModel.ISupportInitialize)(this.LevelBox)).BeginInit();
			this.SkillGroup.SuspendLayout();
			this.DamageGroup.SuspendLayout();
			this.Pages.SuspendLayout();
			this.ReferencePage.SuspendLayout();
			this.SuspendLayout();
			// 
			// LevelLbl
			// 
			this.LevelLbl.AutoSize = true;
			this.LevelLbl.Location = new System.Drawing.Point(8, 8);
			this.LevelLbl.Name = "LevelLbl";
			this.LevelLbl.Size = new System.Drawing.Size(36, 13);
			this.LevelLbl.TabIndex = 0;
			this.LevelLbl.Text = "Level:";
			// 
			// LevelBox
			// 
			this.LevelBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.LevelBox.Location = new System.Drawing.Point(50, 6);
			this.LevelBox.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
			this.LevelBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.LevelBox.Name = "LevelBox";
			this.LevelBox.Size = new System.Drawing.Size(291, 20);
			this.LevelBox.TabIndex = 1;
			this.LevelBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.LevelBox.ValueChanged += new System.EventHandler(this.LevelBox_ValueChanged);
			// 
			// SkillGroup
			// 
			this.SkillGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.SkillGroup.Controls.Add(this.SkillList);
			this.SkillGroup.Location = new System.Drawing.Point(8, 32);
			this.SkillGroup.Name = "SkillGroup";
			this.SkillGroup.Size = new System.Drawing.Size(333, 118);
			this.SkillGroup.TabIndex = 2;
			this.SkillGroup.TabStop = false;
			this.SkillGroup.Text = "Skill DCs";
			// 
			// SkillList
			// 
			this.SkillList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.SkillList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DiffHdr,
            this.DCHdr});
			this.SkillList.FullRowSelect = true;
			this.SkillList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.SkillList.HideSelection = false;
			this.SkillList.Location = new System.Drawing.Point(6, 19);
			this.SkillList.MultiSelect = false;
			this.SkillList.Name = "SkillList";
			this.SkillList.Size = new System.Drawing.Size(321, 93);
			this.SkillList.TabIndex = 0;
			this.SkillList.UseCompatibleStateImageBehavior = false;
			this.SkillList.View = System.Windows.Forms.View.Details;
			// 
			// DiffHdr
			// 
			this.DiffHdr.Text = "Difficulty";
			this.DiffHdr.Width = 200;
			// 
			// DCHdr
			// 
			this.DCHdr.Text = "DC";
			this.DCHdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.DCHdr.Width = 80;
			// 
			// DamageGroup
			// 
			this.DamageGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DamageGroup.Controls.Add(this.DamageList);
			this.DamageGroup.Location = new System.Drawing.Point(8, 156);
			this.DamageGroup.Name = "DamageGroup";
			this.DamageGroup.Size = new System.Drawing.Size(333, 257);
			this.DamageGroup.TabIndex = 3;
			this.DamageGroup.TabStop = false;
			this.DamageGroup.Text = "Damage Expressions";
			// 
			// DamageList
			// 
			this.DamageList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DamageList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TargetHdr,
            this.DmgHdr});
			this.DamageList.FullRowSelect = true;
			listViewGroup1.Header = "Normal Damage";
			listViewGroup1.Name = "listViewGroup1";
			listViewGroup2.Header = "Limited Damage";
			listViewGroup2.Name = "listViewGroup2";
			this.DamageList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
			this.DamageList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.DamageList.HideSelection = false;
			this.DamageList.Location = new System.Drawing.Point(6, 19);
			this.DamageList.MultiSelect = false;
			this.DamageList.Name = "DamageList";
			this.DamageList.Size = new System.Drawing.Size(321, 232);
			this.DamageList.TabIndex = 1;
			this.DamageList.UseCompatibleStateImageBehavior = false;
			this.DamageList.View = System.Windows.Forms.View.Details;
			// 
			// TargetHdr
			// 
			this.TargetHdr.Text = "Target";
			this.TargetHdr.Width = 200;
			// 
			// DmgHdr
			// 
			this.DmgHdr.Text = "Damage";
			this.DmgHdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.DmgHdr.Width = 80;
			// 
			// Pages
			// 
			this.Pages.Controls.Add(this.ReferencePage);
			this.Pages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Pages.Location = new System.Drawing.Point(0, 0);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(357, 447);
			this.Pages.TabIndex = 4;
			// 
			// ReferencePage
			// 
			this.ReferencePage.Controls.Add(this.LevelBox);
			this.ReferencePage.Controls.Add(this.DamageGroup);
			this.ReferencePage.Controls.Add(this.LevelLbl);
			this.ReferencePage.Controls.Add(this.SkillGroup);
			this.ReferencePage.Location = new System.Drawing.Point(4, 22);
			this.ReferencePage.Name = "ReferencePage";
			this.ReferencePage.Padding = new System.Windows.Forms.Padding(3);
			this.ReferencePage.Size = new System.Drawing.Size(349, 421);
			this.ReferencePage.TabIndex = 0;
			this.ReferencePage.Text = "Reference";
			this.ReferencePage.UseVisualStyleBackColor = true;
			// 
			// QuickReferenceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(357, 447);
			this.Controls.Add(this.Pages);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "QuickReferenceForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Quick Reference";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.QuickReferenceForm_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.LevelBox)).EndInit();
			this.SkillGroup.ResumeLayout(false);
			this.DamageGroup.ResumeLayout(false);
			this.Pages.ResumeLayout(false);
			this.ReferencePage.ResumeLayout(false);
			this.ReferencePage.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LevelLbl;
        private System.Windows.Forms.NumericUpDown LevelBox;
        private System.Windows.Forms.GroupBox SkillGroup;
        private System.Windows.Forms.GroupBox DamageGroup;
        private System.Windows.Forms.ListView SkillList;
        private System.Windows.Forms.ColumnHeader DiffHdr;
        private System.Windows.Forms.ColumnHeader DCHdr;
        private System.Windows.Forms.ListView DamageList;
        private System.Windows.Forms.ColumnHeader TargetHdr;
        private System.Windows.Forms.ColumnHeader DmgHdr;
        private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.TabPage ReferencePage;
    }
}