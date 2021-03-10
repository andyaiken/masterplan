namespace Masterplan.UI
{
	partial class CalendarListForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalendarListForm));
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.AddBtn = new System.Windows.Forms.ToolStripButton();
			this.RemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.EditBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.ExportBtn = new System.Windows.Forms.ToolStripButton();
			this.PlayerViewBtn = new System.Windows.Forms.ToolStripButton();
			this.CalendarList = new System.Windows.Forms.ListView();
			this.NameHdr = new System.Windows.Forms.ColumnHeader();
			this.MonthsHdr = new System.Windows.Forms.ColumnHeader();
			this.DaysHdr = new System.Windows.Forms.ColumnHeader();
			this.Splitter = new System.Windows.Forms.SplitContainer();
			this.CalendarPnl = new Masterplan.Controls.CalendarPanel();
			this.NavigationToolbar = new System.Windows.Forms.ToolStrip();
			this.YearPrevBtn = new System.Windows.Forms.ToolStripLabel();
			this.MonthPrevBtn = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.MonthBox = new System.Windows.Forms.ToolStripComboBox();
			this.YearBox = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.MonthNextBtn = new System.Windows.Forms.ToolStripLabel();
			this.YearNextBtn = new System.Windows.Forms.ToolStripLabel();
			this.CloseBtn = new System.Windows.Forms.Button();
			this.Toolbar.SuspendLayout();
			this.Splitter.Panel1.SuspendLayout();
			this.Splitter.Panel2.SuspendLayout();
			this.Splitter.SuspendLayout();
			this.NavigationToolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddBtn,
            this.RemoveBtn,
            this.EditBtn,
            this.toolStripSeparator3,
            this.ExportBtn,
            this.PlayerViewBtn});
			this.Toolbar.Location = new System.Drawing.Point(0, 0);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(485, 25);
			this.Toolbar.TabIndex = 0;
			this.Toolbar.Text = "toolStrip1";
			// 
			// AddBtn
			// 
			this.AddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.AddBtn.Image = ((System.Drawing.Image)(resources.GetObject("AddBtn.Image")));
			this.AddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AddBtn.Name = "AddBtn";
			this.AddBtn.Size = new System.Drawing.Size(33, 22);
			this.AddBtn.Text = "Add";
			this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
			// 
			// RemoveBtn
			// 
			this.RemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.RemoveBtn.Image = ((System.Drawing.Image)(resources.GetObject("RemoveBtn.Image")));
			this.RemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RemoveBtn.Name = "RemoveBtn";
			this.RemoveBtn.Size = new System.Drawing.Size(54, 22);
			this.RemoveBtn.Text = "Remove";
			this.RemoveBtn.Click += new System.EventHandler(this.RemoveBtn_Click);
			// 
			// EditBtn
			// 
			this.EditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.EditBtn.Image = ((System.Drawing.Image)(resources.GetObject("EditBtn.Image")));
			this.EditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EditBtn.Name = "EditBtn";
			this.EditBtn.Size = new System.Drawing.Size(31, 22);
			this.EditBtn.Text = "Edit";
			this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// ExportBtn
			// 
			this.ExportBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ExportBtn.Image = ((System.Drawing.Image)(resources.GetObject("ExportBtn.Image")));
			this.ExportBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ExportBtn.Name = "ExportBtn";
			this.ExportBtn.Size = new System.Drawing.Size(44, 22);
			this.ExportBtn.Text = "Export";
			this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
			// 
			// PlayerViewBtn
			// 
			this.PlayerViewBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.PlayerViewBtn.Image = ((System.Drawing.Image)(resources.GetObject("PlayerViewBtn.Image")));
			this.PlayerViewBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.PlayerViewBtn.Name = "PlayerViewBtn";
			this.PlayerViewBtn.Size = new System.Drawing.Size(114, 22);
			this.PlayerViewBtn.Text = "Send to Player View";
			this.PlayerViewBtn.Click += new System.EventHandler(this.PlayerViewBtn_Click);
			// 
			// CalendarList
			// 
			this.CalendarList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameHdr,
            this.MonthsHdr,
            this.DaysHdr});
			this.CalendarList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CalendarList.FullRowSelect = true;
			this.CalendarList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.CalendarList.HideSelection = false;
			this.CalendarList.Location = new System.Drawing.Point(0, 25);
			this.CalendarList.MultiSelect = false;
			this.CalendarList.Name = "CalendarList";
			this.CalendarList.Size = new System.Drawing.Size(485, 72);
			this.CalendarList.TabIndex = 1;
			this.CalendarList.UseCompatibleStateImageBehavior = false;
			this.CalendarList.View = System.Windows.Forms.View.Details;
			this.CalendarList.SelectedIndexChanged += new System.EventHandler(this.CalendarList_SelectedIndexChanged);
			this.CalendarList.DoubleClick += new System.EventHandler(this.EditBtn_Click);
			// 
			// NameHdr
			// 
			this.NameHdr.Text = "Calendar";
			this.NameHdr.Width = 300;
			// 
			// MonthsHdr
			// 
			this.MonthsHdr.Text = "Months";
			this.MonthsHdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// DaysHdr
			// 
			this.DaysHdr.Text = "Days";
			this.DaysHdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// Splitter
			// 
			this.Splitter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Splitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.Splitter.Location = new System.Drawing.Point(12, 12);
			this.Splitter.Name = "Splitter";
			this.Splitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// Splitter.Panel1
			// 
			this.Splitter.Panel1.Controls.Add(this.CalendarList);
			this.Splitter.Panel1.Controls.Add(this.Toolbar);
			// 
			// Splitter.Panel2
			// 
			this.Splitter.Panel2.Controls.Add(this.CalendarPnl);
			this.Splitter.Panel2.Controls.Add(this.NavigationToolbar);
			this.Splitter.Size = new System.Drawing.Size(485, 364);
			this.Splitter.SplitterDistance = 97;
			this.Splitter.TabIndex = 2;
			// 
			// CalendarPnl
			// 
			this.CalendarPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.CalendarPnl.Calendar = null;
			this.CalendarPnl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CalendarPnl.Location = new System.Drawing.Point(0, 25);
			this.CalendarPnl.MonthIndex = 0;
			this.CalendarPnl.Name = "CalendarPnl";
			this.CalendarPnl.Size = new System.Drawing.Size(485, 238);
			this.CalendarPnl.TabIndex = 0;
			this.CalendarPnl.Year = 0;
			// 
			// NavigationToolbar
			// 
			this.NavigationToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.NavigationToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.YearPrevBtn,
            this.MonthPrevBtn,
            this.toolStripSeparator1,
            this.MonthBox,
            this.YearBox,
            this.toolStripSeparator2,
            this.MonthNextBtn,
            this.YearNextBtn});
			this.NavigationToolbar.Location = new System.Drawing.Point(0, 0);
			this.NavigationToolbar.Name = "NavigationToolbar";
			this.NavigationToolbar.Size = new System.Drawing.Size(485, 25);
			this.NavigationToolbar.TabIndex = 1;
			this.NavigationToolbar.Text = "toolStrip1";
			// 
			// YearPrevBtn
			// 
			this.YearPrevBtn.IsLink = true;
			this.YearPrevBtn.Name = "YearPrevBtn";
			this.YearPrevBtn.Size = new System.Drawing.Size(49, 22);
			this.YearPrevBtn.Text = "<< Year";
			this.YearPrevBtn.Click += new System.EventHandler(this.YearPrevBtn_Click);
			// 
			// MonthPrevBtn
			// 
			this.MonthPrevBtn.IsLink = true;
			this.MonthPrevBtn.Name = "MonthPrevBtn";
			this.MonthPrevBtn.Size = new System.Drawing.Size(62, 22);
			this.MonthPrevBtn.Text = "<< Month";
			this.MonthPrevBtn.Click += new System.EventHandler(this.MonthPrevBtn_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// MonthBox
			// 
			this.MonthBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.MonthBox.Name = "MonthBox";
			this.MonthBox.Size = new System.Drawing.Size(121, 25);
			this.MonthBox.SelectedIndexChanged += new System.EventHandler(this.MonthBox_SelectedIndexChanged);
			// 
			// YearBox
			// 
			this.YearBox.Name = "YearBox";
			this.YearBox.Size = new System.Drawing.Size(100, 25);
			this.YearBox.TextChanged += new System.EventHandler(this.YearBox_TextChanged);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// MonthNextBtn
			// 
			this.MonthNextBtn.IsLink = true;
			this.MonthNextBtn.Name = "MonthNextBtn";
			this.MonthNextBtn.Size = new System.Drawing.Size(62, 22);
			this.MonthNextBtn.Text = "Month >>";
			this.MonthNextBtn.Click += new System.EventHandler(this.MonthNextBtn_Click);
			// 
			// YearNextBtn
			// 
			this.YearNextBtn.IsLink = true;
			this.YearNextBtn.Name = "YearNextBtn";
			this.YearNextBtn.Size = new System.Drawing.Size(49, 22);
			this.YearNextBtn.Text = "Year >>";
			this.YearNextBtn.Click += new System.EventHandler(this.YearNextBtn_Click);
			// 
			// CloseBtn
			// 
			this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.CloseBtn.Location = new System.Drawing.Point(422, 382);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.Size = new System.Drawing.Size(75, 23);
			this.CloseBtn.TabIndex = 3;
			this.CloseBtn.Text = "Close";
			this.CloseBtn.UseVisualStyleBackColor = true;
			// 
			// CalendarListForm
			// 
			this.AcceptButton = this.CloseBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(509, 417);
			this.Controls.Add(this.CloseBtn);
			this.Controls.Add(this.Splitter);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CalendarListForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Calendars";
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			this.Splitter.Panel1.ResumeLayout(false);
			this.Splitter.Panel1.PerformLayout();
			this.Splitter.Panel2.ResumeLayout(false);
			this.Splitter.Panel2.PerformLayout();
			this.Splitter.ResumeLayout(false);
			this.NavigationToolbar.ResumeLayout(false);
			this.NavigationToolbar.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ListView CalendarList;
		private System.Windows.Forms.ColumnHeader NameHdr;
		private System.Windows.Forms.ToolStripButton RemoveBtn;
		private System.Windows.Forms.ToolStripButton EditBtn;
		private System.Windows.Forms.ColumnHeader MonthsHdr;
		private System.Windows.Forms.ColumnHeader DaysHdr;
		private System.Windows.Forms.ToolStripButton AddBtn;
		private System.Windows.Forms.SplitContainer Splitter;
		private Masterplan.Controls.CalendarPanel CalendarPnl;
		private System.Windows.Forms.ToolStrip NavigationToolbar;
		private System.Windows.Forms.ToolStripLabel MonthPrevBtn;
		private System.Windows.Forms.ToolStripLabel MonthNextBtn;
		private System.Windows.Forms.ToolStripLabel YearPrevBtn;
		private System.Windows.Forms.ToolStripLabel YearNextBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripComboBox MonthBox;
		private System.Windows.Forms.ToolStripTextBox YearBox;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton ExportBtn;
		private System.Windows.Forms.ToolStripButton PlayerViewBtn;
		private System.Windows.Forms.Button CloseBtn;

	}
}