namespace Masterplan.UI
{
    partial class MonsterThemeForm
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
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Attack Powers", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Utility Powers", System.Windows.Forms.HorizontalAlignment.Left);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonsterThemeForm));
			this.NameLbl = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.Pages = new System.Windows.Forms.TabControl();
			this.PowerPage = new System.Windows.Forms.TabPage();
			this.PowerList = new System.Windows.Forms.ListView();
			this.PowerHdr = new System.Windows.Forms.ColumnHeader();
			this.RoleHdr = new System.Windows.Forms.ColumnHeader();
			this.PowerToolbar = new System.Windows.Forms.ToolStrip();
			this.PowerAddBtn = new System.Windows.Forms.ToolStripSplitButton();
			this.PowerBrowse = new System.Windows.Forms.ToolStripMenuItem();
			this.PowerRemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.SkillPage = new System.Windows.Forms.TabPage();
			this.SkillList = new System.Windows.Forms.ListView();
			this.SkillHdr = new System.Windows.Forms.ColumnHeader();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.PowerEditBtn = new System.Windows.Forms.ToolStripDropDownButton();
			this.EditPower = new System.Windows.Forms.ToolStripMenuItem();
			this.EditClassification = new System.Windows.Forms.ToolStripMenuItem();
			this.Pages.SuspendLayout();
			this.PowerPage.SuspendLayout();
			this.PowerToolbar.SuspendLayout();
			this.SkillPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// NameLbl
			// 
			this.NameLbl.AutoSize = true;
			this.NameLbl.Location = new System.Drawing.Point(12, 15);
			this.NameLbl.Name = "NameLbl";
			this.NameLbl.Size = new System.Drawing.Size(38, 13);
			this.NameLbl.TabIndex = 0;
			this.NameLbl.Text = "Name:";
			// 
			// NameBox
			// 
			this.NameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.NameBox.Location = new System.Drawing.Point(56, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(328, 20);
			this.NameBox.TabIndex = 1;
			// 
			// Pages
			// 
			this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Pages.Controls.Add(this.PowerPage);
			this.Pages.Controls.Add(this.SkillPage);
			this.Pages.Location = new System.Drawing.Point(12, 38);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(372, 291);
			this.Pages.TabIndex = 2;
			// 
			// PowerPage
			// 
			this.PowerPage.Controls.Add(this.PowerList);
			this.PowerPage.Controls.Add(this.PowerToolbar);
			this.PowerPage.Location = new System.Drawing.Point(4, 22);
			this.PowerPage.Name = "PowerPage";
			this.PowerPage.Padding = new System.Windows.Forms.Padding(3);
			this.PowerPage.Size = new System.Drawing.Size(364, 265);
			this.PowerPage.TabIndex = 0;
			this.PowerPage.Text = "Powers";
			this.PowerPage.UseVisualStyleBackColor = true;
			// 
			// PowerList
			// 
			this.PowerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PowerHdr,
            this.RoleHdr});
			this.PowerList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PowerList.FullRowSelect = true;
			listViewGroup1.Header = "Attack Powers";
			listViewGroup1.Name = "listViewGroup1";
			listViewGroup2.Header = "Utility Powers";
			listViewGroup2.Name = "listViewGroup2";
			this.PowerList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
			this.PowerList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.PowerList.HideSelection = false;
			this.PowerList.Location = new System.Drawing.Point(3, 28);
			this.PowerList.MultiSelect = false;
			this.PowerList.Name = "PowerList";
			this.PowerList.Size = new System.Drawing.Size(358, 234);
			this.PowerList.TabIndex = 1;
			this.PowerList.UseCompatibleStateImageBehavior = false;
			this.PowerList.View = System.Windows.Forms.View.Details;
			this.PowerList.DoubleClick += new System.EventHandler(this.PowerEditBtn_Click);
			// 
			// PowerHdr
			// 
			this.PowerHdr.Text = "Power";
			this.PowerHdr.Width = 150;
			// 
			// RoleHdr
			// 
			this.RoleHdr.Text = "Roles";
			this.RoleHdr.Width = 180;
			// 
			// PowerToolbar
			// 
			this.PowerToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PowerAddBtn,
            this.PowerRemoveBtn,
            this.PowerEditBtn});
			this.PowerToolbar.Location = new System.Drawing.Point(3, 3);
			this.PowerToolbar.Name = "PowerToolbar";
			this.PowerToolbar.Size = new System.Drawing.Size(358, 25);
			this.PowerToolbar.TabIndex = 0;
			this.PowerToolbar.Text = "toolStrip1";
			// 
			// PowerAddBtn
			// 
			this.PowerAddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.PowerAddBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PowerBrowse});
			this.PowerAddBtn.Image = ((System.Drawing.Image)(resources.GetObject("PowerAddBtn.Image")));
			this.PowerAddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.PowerAddBtn.Name = "PowerAddBtn";
			this.PowerAddBtn.Size = new System.Drawing.Size(45, 22);
			this.PowerAddBtn.Text = "Add";
			this.PowerAddBtn.ButtonClick += new System.EventHandler(this.PowerAddBtn_Click);
			// 
			// PowerBrowse
			// 
			this.PowerBrowse.Name = "PowerBrowse";
			this.PowerBrowse.Size = new System.Drawing.Size(152, 22);
			this.PowerBrowse.Text = "Browse...";
			this.PowerBrowse.Click += new System.EventHandler(this.PowerBrowse_Click);
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
			// SkillPage
			// 
			this.SkillPage.Controls.Add(this.SkillList);
			this.SkillPage.Location = new System.Drawing.Point(4, 22);
			this.SkillPage.Name = "SkillPage";
			this.SkillPage.Padding = new System.Windows.Forms.Padding(3);
			this.SkillPage.Size = new System.Drawing.Size(364, 265);
			this.SkillPage.TabIndex = 1;
			this.SkillPage.Text = "Skill Bonuses";
			this.SkillPage.UseVisualStyleBackColor = true;
			// 
			// SkillList
			// 
			this.SkillList.CheckBoxes = true;
			this.SkillList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SkillHdr});
			this.SkillList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SkillList.FullRowSelect = true;
			this.SkillList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.SkillList.HideSelection = false;
			this.SkillList.Location = new System.Drawing.Point(3, 3);
			this.SkillList.MultiSelect = false;
			this.SkillList.Name = "SkillList";
			this.SkillList.Size = new System.Drawing.Size(358, 259);
			this.SkillList.TabIndex = 0;
			this.SkillList.UseCompatibleStateImageBehavior = false;
			this.SkillList.View = System.Windows.Forms.View.Details;
			// 
			// SkillHdr
			// 
			this.SkillHdr.Text = "Skill";
			this.SkillHdr.Width = 200;
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(228, 335);
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
			this.CancelBtn.Location = new System.Drawing.Point(309, 335);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 4;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// PowerEditBtn
			// 
			this.PowerEditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.PowerEditBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditPower,
            this.EditClassification});
			this.PowerEditBtn.Image = ((System.Drawing.Image)(resources.GetObject("PowerEditBtn.Image")));
			this.PowerEditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.PowerEditBtn.Name = "PowerEditBtn";
			this.PowerEditBtn.Size = new System.Drawing.Size(40, 22);
			this.PowerEditBtn.Text = "Edit";
			// 
			// EditPower
			// 
			this.EditPower.Name = "EditPower";
			this.EditPower.Size = new System.Drawing.Size(152, 22);
			this.EditPower.Text = "Power";
			this.EditPower.Click += new System.EventHandler(this.PowerEditBtn_Click);
			// 
			// EditClassification
			// 
			this.EditClassification.Name = "EditClassification";
			this.EditClassification.Size = new System.Drawing.Size(152, 22);
			this.EditClassification.Text = "Classification";
			this.EditClassification.Click += new System.EventHandler(this.EditClassification_Click);
			// 
			// MonsterThemeForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(396, 370);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.Pages);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLbl);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MonsterThemeForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Theme";
			this.Pages.ResumeLayout(false);
			this.PowerPage.ResumeLayout(false);
			this.PowerPage.PerformLayout();
			this.PowerToolbar.ResumeLayout(false);
			this.PowerToolbar.PerformLayout();
			this.SkillPage.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TabControl Pages;
        private System.Windows.Forms.TabPage PowerPage;
        private System.Windows.Forms.TabPage SkillPage;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.ListView PowerList;
        private System.Windows.Forms.ColumnHeader PowerHdr;
        private System.Windows.Forms.ColumnHeader RoleHdr;
        private System.Windows.Forms.ToolStrip PowerToolbar;
		private System.Windows.Forms.ToolStripButton PowerRemoveBtn;
        private System.Windows.Forms.ListView SkillList;
        private System.Windows.Forms.ColumnHeader SkillHdr;
        private System.Windows.Forms.ToolStripSplitButton PowerAddBtn;
		private System.Windows.Forms.ToolStripMenuItem PowerBrowse;
		private System.Windows.Forms.ToolStripDropDownButton PowerEditBtn;
		private System.Windows.Forms.ToolStripMenuItem EditPower;
		private System.Windows.Forms.ToolStripMenuItem EditClassification;
    }
}