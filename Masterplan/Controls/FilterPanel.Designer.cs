namespace Masterplan.Controls
{
	partial class FilterPanel
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
			this.FilterLevelToggle = new System.Windows.Forms.CheckBox();
			this.FilterModToggle = new System.Windows.Forms.CheckBox();
			this.FilterModBox = new System.Windows.Forms.ComboBox();
			this.FilterNameToggle = new System.Windows.Forms.CheckBox();
			this.FilterCatToggle = new System.Windows.Forms.CheckBox();
			this.FilterKeywordBox = new System.Windows.Forms.TextBox();
			this.FilterKeywordToggle = new System.Windows.Forms.CheckBox();
			this.FilterTypeToggle = new System.Windows.Forms.CheckBox();
			this.FilterTypeBox = new System.Windows.Forms.ComboBox();
			this.FilterOriginToggle = new System.Windows.Forms.CheckBox();
			this.FilterOriginBox = new System.Windows.Forms.ComboBox();
			this.FilterCatBox = new System.Windows.Forms.TextBox();
			this.FilterRoleToggle = new System.Windows.Forms.CheckBox();
			this.FilterRoleBox = new System.Windows.Forms.ComboBox();
			this.FilterNameBox = new System.Windows.Forms.TextBox();
			this.FilterPnl = new System.Windows.Forms.Panel();
			this.FilterSourceBox = new System.Windows.Forms.ComboBox();
			this.FilterSourceToggle = new System.Windows.Forms.CheckBox();
			this.FilterLevelAppropriateToggle = new System.Windows.Forms.CheckBox();
			this.LevelToBox = new System.Windows.Forms.NumericUpDown();
			this.LevelFromBox = new System.Windows.Forms.NumericUpDown();
			this.ToLbl = new System.Windows.Forms.Label();
			this.FromLbl = new System.Windows.Forms.Label();
			this.InfoLbl = new System.Windows.Forms.ToolStripStatusLabel();
			this.EditLbl = new System.Windows.Forms.ToolStripStatusLabel();
			this.Statusbar = new System.Windows.Forms.StatusStrip();
			this.FilterPnl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.LevelToBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LevelFromBox)).BeginInit();
			this.Statusbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// FilterLevelToggle
			// 
			this.FilterLevelToggle.AutoSize = true;
			this.FilterLevelToggle.Location = new System.Drawing.Point(3, 190);
			this.FilterLevelToggle.Name = "FilterLevelToggle";
			this.FilterLevelToggle.Size = new System.Drawing.Size(55, 17);
			this.FilterLevelToggle.TabIndex = 14;
			this.FilterLevelToggle.Text = "Level:";
			this.FilterLevelToggle.UseVisualStyleBackColor = true;
			this.FilterLevelToggle.Click += new System.EventHandler(this.ToggleChanged);
			// 
			// FilterModToggle
			// 
			this.FilterModToggle.AutoSize = true;
			this.FilterModToggle.Location = new System.Drawing.Point(3, 84);
			this.FilterModToggle.Name = "FilterModToggle";
			this.FilterModToggle.Size = new System.Drawing.Size(66, 17);
			this.FilterModToggle.TabIndex = 6;
			this.FilterModToggle.Text = "Modifier:";
			this.FilterModToggle.UseVisualStyleBackColor = true;
			this.FilterModToggle.Click += new System.EventHandler(this.ToggleChanged);
			// 
			// FilterModBox
			// 
			this.FilterModBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.FilterModBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.FilterModBox.FormattingEnabled = true;
			this.FilterModBox.Location = new System.Drawing.Point(84, 82);
			this.FilterModBox.Name = "FilterModBox";
			this.FilterModBox.Size = new System.Drawing.Size(165, 21);
			this.FilterModBox.TabIndex = 7;
			this.FilterModBox.SelectedIndexChanged += new System.EventHandler(this.DropdownOptionChanged);
			// 
			// FilterNameToggle
			// 
			this.FilterNameToggle.AutoSize = true;
			this.FilterNameToggle.Location = new System.Drawing.Point(3, 5);
			this.FilterNameToggle.Name = "FilterNameToggle";
			this.FilterNameToggle.Size = new System.Drawing.Size(57, 17);
			this.FilterNameToggle.TabIndex = 0;
			this.FilterNameToggle.Text = "Name:";
			this.FilterNameToggle.UseVisualStyleBackColor = true;
			this.FilterNameToggle.Click += new System.EventHandler(this.ToggleChanged);
			// 
			// FilterCatToggle
			// 
			this.FilterCatToggle.AutoSize = true;
			this.FilterCatToggle.Location = new System.Drawing.Point(3, 31);
			this.FilterCatToggle.Name = "FilterCatToggle";
			this.FilterCatToggle.Size = new System.Drawing.Size(71, 17);
			this.FilterCatToggle.TabIndex = 2;
			this.FilterCatToggle.Text = "Category:";
			this.FilterCatToggle.UseVisualStyleBackColor = true;
			this.FilterCatToggle.Click += new System.EventHandler(this.ToggleChanged);
			// 
			// FilterKeywordBox
			// 
			this.FilterKeywordBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.FilterKeywordBox.Location = new System.Drawing.Point(84, 163);
			this.FilterKeywordBox.Name = "FilterKeywordBox";
			this.FilterKeywordBox.Size = new System.Drawing.Size(165, 20);
			this.FilterKeywordBox.TabIndex = 13;
			this.FilterKeywordBox.TextChanged += new System.EventHandler(this.TextOptionChanged);
			// 
			// FilterKeywordToggle
			// 
			this.FilterKeywordToggle.AutoSize = true;
			this.FilterKeywordToggle.Location = new System.Drawing.Point(3, 165);
			this.FilterKeywordToggle.Name = "FilterKeywordToggle";
			this.FilterKeywordToggle.Size = new System.Drawing.Size(75, 17);
			this.FilterKeywordToggle.TabIndex = 12;
			this.FilterKeywordToggle.Text = "Keywords:";
			this.FilterKeywordToggle.UseVisualStyleBackColor = true;
			this.FilterKeywordToggle.Click += new System.EventHandler(this.ToggleChanged);
			// 
			// FilterTypeToggle
			// 
			this.FilterTypeToggle.AutoSize = true;
			this.FilterTypeToggle.Location = new System.Drawing.Point(3, 138);
			this.FilterTypeToggle.Name = "FilterTypeToggle";
			this.FilterTypeToggle.Size = new System.Drawing.Size(53, 17);
			this.FilterTypeToggle.TabIndex = 10;
			this.FilterTypeToggle.Text = "Type:";
			this.FilterTypeToggle.UseVisualStyleBackColor = true;
			this.FilterTypeToggle.Click += new System.EventHandler(this.ToggleChanged);
			// 
			// FilterTypeBox
			// 
			this.FilterTypeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.FilterTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.FilterTypeBox.FormattingEnabled = true;
			this.FilterTypeBox.Location = new System.Drawing.Point(84, 136);
			this.FilterTypeBox.Name = "FilterTypeBox";
			this.FilterTypeBox.Size = new System.Drawing.Size(165, 21);
			this.FilterTypeBox.TabIndex = 11;
			this.FilterTypeBox.SelectedIndexChanged += new System.EventHandler(this.DropdownOptionChanged);
			// 
			// FilterOriginToggle
			// 
			this.FilterOriginToggle.AutoSize = true;
			this.FilterOriginToggle.Location = new System.Drawing.Point(3, 111);
			this.FilterOriginToggle.Name = "FilterOriginToggle";
			this.FilterOriginToggle.Size = new System.Drawing.Size(56, 17);
			this.FilterOriginToggle.TabIndex = 8;
			this.FilterOriginToggle.Text = "Origin:";
			this.FilterOriginToggle.UseVisualStyleBackColor = true;
			this.FilterOriginToggle.Click += new System.EventHandler(this.ToggleChanged);
			// 
			// FilterOriginBox
			// 
			this.FilterOriginBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.FilterOriginBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.FilterOriginBox.FormattingEnabled = true;
			this.FilterOriginBox.Location = new System.Drawing.Point(84, 109);
			this.FilterOriginBox.Name = "FilterOriginBox";
			this.FilterOriginBox.Size = new System.Drawing.Size(165, 21);
			this.FilterOriginBox.TabIndex = 9;
			this.FilterOriginBox.SelectedIndexChanged += new System.EventHandler(this.DropdownOptionChanged);
			// 
			// FilterCatBox
			// 
			this.FilterCatBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.FilterCatBox.Location = new System.Drawing.Point(84, 29);
			this.FilterCatBox.Name = "FilterCatBox";
			this.FilterCatBox.Size = new System.Drawing.Size(165, 20);
			this.FilterCatBox.TabIndex = 3;
			this.FilterCatBox.TextChanged += new System.EventHandler(this.TextOptionChanged);
			// 
			// FilterRoleToggle
			// 
			this.FilterRoleToggle.AutoSize = true;
			this.FilterRoleToggle.Location = new System.Drawing.Point(3, 57);
			this.FilterRoleToggle.Name = "FilterRoleToggle";
			this.FilterRoleToggle.Size = new System.Drawing.Size(51, 17);
			this.FilterRoleToggle.TabIndex = 4;
			this.FilterRoleToggle.Text = "Role:";
			this.FilterRoleToggle.UseVisualStyleBackColor = true;
			this.FilterRoleToggle.Click += new System.EventHandler(this.ToggleChanged);
			// 
			// FilterRoleBox
			// 
			this.FilterRoleBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.FilterRoleBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.FilterRoleBox.FormattingEnabled = true;
			this.FilterRoleBox.Location = new System.Drawing.Point(84, 55);
			this.FilterRoleBox.Name = "FilterRoleBox";
			this.FilterRoleBox.Size = new System.Drawing.Size(165, 21);
			this.FilterRoleBox.TabIndex = 5;
			this.FilterRoleBox.SelectedIndexChanged += new System.EventHandler(this.DropdownOptionChanged);
			// 
			// FilterNameBox
			// 
			this.FilterNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.FilterNameBox.Location = new System.Drawing.Point(84, 3);
			this.FilterNameBox.Name = "FilterNameBox";
			this.FilterNameBox.Size = new System.Drawing.Size(165, 20);
			this.FilterNameBox.TabIndex = 1;
			this.FilterNameBox.TextChanged += new System.EventHandler(this.TextOptionChanged);
			// 
			// FilterPnl
			// 
			this.FilterPnl.Controls.Add(this.FilterSourceBox);
			this.FilterPnl.Controls.Add(this.FilterSourceToggle);
			this.FilterPnl.Controls.Add(this.FilterLevelAppropriateToggle);
			this.FilterPnl.Controls.Add(this.LevelToBox);
			this.FilterPnl.Controls.Add(this.LevelFromBox);
			this.FilterPnl.Controls.Add(this.ToLbl);
			this.FilterPnl.Controls.Add(this.FromLbl);
			this.FilterPnl.Controls.Add(this.FilterNameBox);
			this.FilterPnl.Controls.Add(this.FilterLevelToggle);
			this.FilterPnl.Controls.Add(this.FilterRoleBox);
			this.FilterPnl.Controls.Add(this.FilterModToggle);
			this.FilterPnl.Controls.Add(this.FilterRoleToggle);
			this.FilterPnl.Controls.Add(this.FilterModBox);
			this.FilterPnl.Controls.Add(this.FilterCatBox);
			this.FilterPnl.Controls.Add(this.FilterNameToggle);
			this.FilterPnl.Controls.Add(this.FilterOriginBox);
			this.FilterPnl.Controls.Add(this.FilterCatToggle);
			this.FilterPnl.Controls.Add(this.FilterOriginToggle);
			this.FilterPnl.Controls.Add(this.FilterKeywordBox);
			this.FilterPnl.Controls.Add(this.FilterTypeBox);
			this.FilterPnl.Controls.Add(this.FilterKeywordToggle);
			this.FilterPnl.Controls.Add(this.FilterTypeToggle);
			this.FilterPnl.Dock = System.Windows.Forms.DockStyle.Top;
			this.FilterPnl.Location = new System.Drawing.Point(0, 0);
			this.FilterPnl.Name = "FilterPnl";
			this.FilterPnl.Size = new System.Drawing.Size(252, 294);
			this.FilterPnl.TabIndex = 0;
			// 
			// FilterSourceBox
			// 
			this.FilterSourceBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.FilterSourceBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.FilterSourceBox.FormattingEnabled = true;
			this.FilterSourceBox.Location = new System.Drawing.Point(84, 264);
			this.FilterSourceBox.Name = "FilterSourceBox";
			this.FilterSourceBox.Size = new System.Drawing.Size(165, 21);
			this.FilterSourceBox.TabIndex = 21;
			this.FilterSourceBox.SelectedIndexChanged += new System.EventHandler(this.DropdownOptionChanged);
			// 
			// FilterSourceToggle
			// 
			this.FilterSourceToggle.AutoSize = true;
			this.FilterSourceToggle.Location = new System.Drawing.Point(3, 266);
			this.FilterSourceToggle.Name = "FilterSourceToggle";
			this.FilterSourceToggle.Size = new System.Drawing.Size(63, 17);
			this.FilterSourceToggle.TabIndex = 20;
			this.FilterSourceToggle.Text = "Source:";
			this.FilterSourceToggle.UseVisualStyleBackColor = true;
			this.FilterSourceToggle.CheckedChanged += new System.EventHandler(this.ToggleChanged);
			// 
			// FilterLevelAppropriateToggle
			// 
			this.FilterLevelAppropriateToggle.AutoSize = true;
			this.FilterLevelAppropriateToggle.Location = new System.Drawing.Point(3, 241);
			this.FilterLevelAppropriateToggle.Name = "FilterLevelAppropriateToggle";
			this.FilterLevelAppropriateToggle.Size = new System.Drawing.Size(183, 17);
			this.FilterLevelAppropriateToggle.TabIndex = 19;
			this.FilterLevelAppropriateToggle.Text = "Show level-appropriate items only";
			this.FilterLevelAppropriateToggle.UseVisualStyleBackColor = true;
			this.FilterLevelAppropriateToggle.Click += new System.EventHandler(this.ToggleChanged);
			// 
			// LevelToBox
			// 
			this.LevelToBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.LevelToBox.Location = new System.Drawing.Point(130, 215);
			this.LevelToBox.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
			this.LevelToBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.LevelToBox.Name = "LevelToBox";
			this.LevelToBox.Size = new System.Drawing.Size(119, 20);
			this.LevelToBox.TabIndex = 18;
			this.LevelToBox.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.LevelToBox.ValueChanged += new System.EventHandler(this.NumericOptionChanged);
			// 
			// LevelFromBox
			// 
			this.LevelFromBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.LevelFromBox.Location = new System.Drawing.Point(130, 189);
			this.LevelFromBox.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
			this.LevelFromBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.LevelFromBox.Name = "LevelFromBox";
			this.LevelFromBox.Size = new System.Drawing.Size(119, 20);
			this.LevelFromBox.TabIndex = 16;
			this.LevelFromBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.LevelFromBox.ValueChanged += new System.EventHandler(this.NumericOptionChanged);
			// 
			// ToLbl
			// 
			this.ToLbl.AutoSize = true;
			this.ToLbl.Location = new System.Drawing.Point(81, 217);
			this.ToLbl.Name = "ToLbl";
			this.ToLbl.Size = new System.Drawing.Size(23, 13);
			this.ToLbl.TabIndex = 17;
			this.ToLbl.Text = "To:";
			// 
			// FromLbl
			// 
			this.FromLbl.AutoSize = true;
			this.FromLbl.Location = new System.Drawing.Point(81, 191);
			this.FromLbl.Name = "FromLbl";
			this.FromLbl.Size = new System.Drawing.Size(33, 13);
			this.FromLbl.TabIndex = 15;
			this.FromLbl.Text = "From:";
			// 
			// InfoLbl
			// 
			this.InfoLbl.AutoToolTip = true;
			this.InfoLbl.Name = "InfoLbl";
			this.InfoLbl.Size = new System.Drawing.Size(202, 17);
			this.InfoLbl.Spring = true;
			this.InfoLbl.Text = "[info]";
			this.InfoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// EditLbl
			// 
			this.EditLbl.IsLink = true;
			this.EditLbl.Name = "EditLbl";
			this.EditLbl.Size = new System.Drawing.Size(35, 17);
			this.EditLbl.Text = "(edit)";
			this.EditLbl.Click += new System.EventHandler(this.EditLbl_Click);
			// 
			// Statusbar
			// 
			this.Statusbar.Dock = System.Windows.Forms.DockStyle.Top;
			this.Statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InfoLbl,
            this.EditLbl});
			this.Statusbar.Location = new System.Drawing.Point(0, 294);
			this.Statusbar.Name = "Statusbar";
			this.Statusbar.Size = new System.Drawing.Size(252, 22);
			this.Statusbar.SizingGrip = false;
			this.Statusbar.TabIndex = 1;
			this.Statusbar.Text = "statusStrip1";
			// 
			// FilterPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.Controls.Add(this.Statusbar);
			this.Controls.Add(this.FilterPnl);
			this.Name = "FilterPanel";
			this.Size = new System.Drawing.Size(252, 331);
			this.FilterPnl.ResumeLayout(false);
			this.FilterPnl.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.LevelToBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LevelFromBox)).EndInit();
			this.Statusbar.ResumeLayout(false);
			this.Statusbar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox FilterLevelToggle;
		private System.Windows.Forms.CheckBox FilterModToggle;
		private System.Windows.Forms.ComboBox FilterModBox;
		private System.Windows.Forms.CheckBox FilterNameToggle;
		private System.Windows.Forms.CheckBox FilterCatToggle;
		private System.Windows.Forms.TextBox FilterKeywordBox;
		private System.Windows.Forms.CheckBox FilterKeywordToggle;
		private System.Windows.Forms.CheckBox FilterTypeToggle;
		private System.Windows.Forms.ComboBox FilterTypeBox;
		private System.Windows.Forms.CheckBox FilterOriginToggle;
		private System.Windows.Forms.ComboBox FilterOriginBox;
		private System.Windows.Forms.TextBox FilterCatBox;
		private System.Windows.Forms.CheckBox FilterRoleToggle;
		private System.Windows.Forms.ComboBox FilterRoleBox;
		private System.Windows.Forms.TextBox FilterNameBox;
		private System.Windows.Forms.Panel FilterPnl;
		private System.Windows.Forms.NumericUpDown LevelToBox;
		private System.Windows.Forms.NumericUpDown LevelFromBox;
		private System.Windows.Forms.Label ToLbl;
		private System.Windows.Forms.Label FromLbl;
		private System.Windows.Forms.CheckBox FilterLevelAppropriateToggle;
		private System.Windows.Forms.ToolStripStatusLabel InfoLbl;
		private System.Windows.Forms.ToolStripStatusLabel EditLbl;
		private System.Windows.Forms.StatusStrip Statusbar;
		private System.Windows.Forms.ComboBox FilterSourceBox;
		private System.Windows.Forms.CheckBox FilterSourceToggle;
	}
}
