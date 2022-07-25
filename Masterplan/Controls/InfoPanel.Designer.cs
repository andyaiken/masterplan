namespace Masterplan.Controls
{
	partial class InfoPanel
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Skill DCs", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Aid Another", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Damage Expressions", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Monster Knowledge", System.Windows.Forms.HorizontalAlignment.Left);
			this.LevelBox = new System.Windows.Forms.NumericUpDown();
			this.LevelLbl = new System.Windows.Forms.Label();
			this.SkillList = new System.Windows.Forms.ListView();
			this.DiffHdr = new System.Windows.Forms.ColumnHeader();
			this.DCHdr = new System.Windows.Forms.ColumnHeader();
			((System.ComponentModel.ISupportInitialize)(this.LevelBox)).BeginInit();
			this.SuspendLayout();
			// 
			// LevelBox
			// 
			this.LevelBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.LevelBox.Location = new System.Drawing.Point(45, 3);
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
			this.LevelBox.Size = new System.Drawing.Size(214, 20);
			this.LevelBox.TabIndex = 10;
			this.LevelBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.LevelBox.ValueChanged += new System.EventHandler(this.LevelBox_ValueChanged);
			// 
			// LevelLbl
			// 
			this.LevelLbl.AutoSize = true;
			this.LevelLbl.Location = new System.Drawing.Point(3, 5);
			this.LevelLbl.Name = "LevelLbl";
			this.LevelLbl.Size = new System.Drawing.Size(36, 13);
			this.LevelLbl.TabIndex = 9;
			this.LevelLbl.Text = "Level:";
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
			listViewGroup1.Header = "Skill DCs";
			listViewGroup1.Name = "listViewGroup1";
			listViewGroup2.Header = "Aid Another";
			listViewGroup2.Name = "listViewGroup2";
			listViewGroup3.Header = "Damage Expressions";
			listViewGroup3.Name = "listViewGroup3";
			listViewGroup4.Header = "Monster Knowledge";
			listViewGroup4.Name = "listViewGroup4";
			this.SkillList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4});
			this.SkillList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.SkillList.HideSelection = false;
			this.SkillList.Location = new System.Drawing.Point(3, 29);
			this.SkillList.MultiSelect = false;
			this.SkillList.Name = "SkillList";
			this.SkillList.Size = new System.Drawing.Size(256, 252);
			this.SkillList.TabIndex = 0;
			this.SkillList.UseCompatibleStateImageBehavior = false;
			this.SkillList.View = System.Windows.Forms.View.Details;
			this.SkillList.DoubleClick += new System.EventHandler(this.DamageList_DoubleClick);
			// 
			// DiffHdr
			// 
			this.DiffHdr.Text = Session.I18N.Information;
			this.DiffHdr.Width = 135;
			// 
			// DCHdr
			// 
			this.DCHdr.Text = "Value";
			this.DCHdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.DCHdr.Width = 94;
			// 
			// InfoPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.SkillList);
			this.Controls.Add(this.LevelBox);
			this.Controls.Add(this.LevelLbl);
			this.Name = "InfoPanel";
			this.Size = new System.Drawing.Size(262, 284);
			((System.ComponentModel.ISupportInitialize)(this.LevelBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown LevelBox;
		private System.Windows.Forms.Label LevelLbl;
		private System.Windows.Forms.ListView SkillList;
		private System.Windows.Forms.ColumnHeader DiffHdr;
		private System.Windows.Forms.ColumnHeader DCHdr;
	}
}
