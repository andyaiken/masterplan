namespace Masterplan.UI
{
	partial class CalendarForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalendarForm));
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.NameLbl = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.YearLbl = new System.Windows.Forms.Label();
			this.YearBox = new System.Windows.Forms.NumericUpDown();
			this.Pages = new System.Windows.Forms.TabControl();
			this.DetailsPage = new System.Windows.Forms.TabPage();
			this.DetailsBox = new System.Windows.Forms.TextBox();
			this.MonthsPage = new System.Windows.Forms.TabPage();
			this.MonthList = new System.Windows.Forms.ListView();
			this.MonthHdr = new System.Windows.Forms.ColumnHeader();
			this.DaysHdr = new System.Windows.Forms.ColumnHeader();
			this.MonthToolbar = new System.Windows.Forms.ToolStrip();
			this.MonthAddBtn = new System.Windows.Forms.ToolStripButton();
			this.MonthRemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.MonthEditBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.MonthUpBtn = new System.Windows.Forms.ToolStripButton();
			this.MonthDownBtn = new System.Windows.Forms.ToolStripButton();
			this.DaysPage = new System.Windows.Forms.TabPage();
			this.DayList = new System.Windows.Forms.ListView();
			this.DayHdr = new System.Windows.Forms.ColumnHeader();
			this.DayToolbar = new System.Windows.Forms.ToolStrip();
			this.DayAddBtn = new System.Windows.Forms.ToolStripButton();
			this.DayRemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.DayEditBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.DayUpBtn = new System.Windows.Forms.ToolStripButton();
			this.DayDownBtn = new System.Windows.Forms.ToolStripButton();
			this.SeasonsPage = new System.Windows.Forms.TabPage();
			this.SeasonList = new System.Windows.Forms.ListView();
			this.SeasonHdr = new System.Windows.Forms.ColumnHeader();
			this.SeasonDateHdr = new System.Windows.Forms.ColumnHeader();
			this.SeasonToolbar = new System.Windows.Forms.ToolStrip();
			this.SeasonAddBtn = new System.Windows.Forms.ToolStripButton();
			this.SeasonRemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.SeasonEditBtn = new System.Windows.Forms.ToolStripButton();
			this.EventsPage = new System.Windows.Forms.TabPage();
			this.EventList = new System.Windows.Forms.ListView();
			this.EventHdr = new System.Windows.Forms.ColumnHeader();
			this.DateHdr = new System.Windows.Forms.ColumnHeader();
			this.EventToolbar = new System.Windows.Forms.ToolStrip();
			this.EventAddBtn = new System.Windows.Forms.ToolStripButton();
			this.EventRemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.EventEditBtn = new System.Windows.Forms.ToolStripButton();
			this.SatellitePage = new System.Windows.Forms.TabPage();
			this.SatelliteList = new System.Windows.Forms.ListView();
			this.SatelliteHdr = new System.Windows.Forms.ColumnHeader();
			this.SatelliteToolbar = new System.Windows.Forms.ToolStrip();
			this.SatelliteAddBtn = new System.Windows.Forms.ToolStripButton();
			this.SatelliteRemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.SatelliteEditBtn = new System.Windows.Forms.ToolStripButton();
			((System.ComponentModel.ISupportInitialize)(this.YearBox)).BeginInit();
			this.Pages.SuspendLayout();
			this.DetailsPage.SuspendLayout();
			this.MonthsPage.SuspendLayout();
			this.MonthToolbar.SuspendLayout();
			this.DaysPage.SuspendLayout();
			this.DayToolbar.SuspendLayout();
			this.SeasonsPage.SuspendLayout();
			this.SeasonToolbar.SuspendLayout();
			this.EventsPage.SuspendLayout();
			this.EventToolbar.SuspendLayout();
			this.SatellitePage.SuspendLayout();
			this.SatelliteToolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(179, 365);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 0;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(260, 365);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 1;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// NameLbl
			// 
			this.NameLbl.AutoSize = true;
			this.NameLbl.Location = new System.Drawing.Point(12, 15);
			this.NameLbl.Name = "NameLbl";
			this.NameLbl.Size = new System.Drawing.Size(38, 13);
			this.NameLbl.TabIndex = 2;
			this.NameLbl.Text = "Name:";
			// 
			// NameBox
			// 
			this.NameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.NameBox.Location = new System.Drawing.Point(100, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(235, 20);
			this.NameBox.TabIndex = 3;
			// 
			// YearLbl
			// 
			this.YearLbl.AutoSize = true;
			this.YearLbl.Location = new System.Drawing.Point(12, 40);
			this.YearLbl.Name = "YearLbl";
			this.YearLbl.Size = new System.Drawing.Size(82, 13);
			this.YearLbl.TabIndex = 4;
			this.YearLbl.Text = "Campaign Year:";
			// 
			// YearBox
			// 
			this.YearBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.YearBox.Location = new System.Drawing.Point(100, 38);
			this.YearBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.YearBox.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
			this.YearBox.Name = "YearBox";
			this.YearBox.Size = new System.Drawing.Size(235, 20);
			this.YearBox.TabIndex = 5;
			// 
			// Pages
			// 
			this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Pages.Controls.Add(this.DetailsPage);
			this.Pages.Controls.Add(this.MonthsPage);
			this.Pages.Controls.Add(this.DaysPage);
			this.Pages.Controls.Add(this.SeasonsPage);
			this.Pages.Controls.Add(this.EventsPage);
			this.Pages.Controls.Add(this.SatellitePage);
			this.Pages.Location = new System.Drawing.Point(12, 64);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(323, 295);
			this.Pages.TabIndex = 6;
			// 
			// DetailsPage
			// 
			this.DetailsPage.Controls.Add(this.DetailsBox);
			this.DetailsPage.Location = new System.Drawing.Point(4, 22);
			this.DetailsPage.Name = "DetailsPage";
			this.DetailsPage.Padding = new System.Windows.Forms.Padding(3);
			this.DetailsPage.Size = new System.Drawing.Size(315, 269);
			this.DetailsPage.TabIndex = 0;
			this.DetailsPage.Text = "Details";
			this.DetailsPage.UseVisualStyleBackColor = true;
			// 
			// DetailsBox
			// 
			this.DetailsBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DetailsBox.Location = new System.Drawing.Point(3, 3);
			this.DetailsBox.Multiline = true;
			this.DetailsBox.Name = "DetailsBox";
			this.DetailsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.DetailsBox.Size = new System.Drawing.Size(309, 263);
			this.DetailsBox.TabIndex = 0;
			// 
			// MonthsPage
			// 
			this.MonthsPage.Controls.Add(this.MonthList);
			this.MonthsPage.Controls.Add(this.MonthToolbar);
			this.MonthsPage.Location = new System.Drawing.Point(4, 22);
			this.MonthsPage.Name = "MonthsPage";
			this.MonthsPage.Padding = new System.Windows.Forms.Padding(3);
			this.MonthsPage.Size = new System.Drawing.Size(315, 269);
			this.MonthsPage.TabIndex = 1;
			this.MonthsPage.Text = "Months";
			this.MonthsPage.UseVisualStyleBackColor = true;
			// 
			// MonthList
			// 
			this.MonthList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MonthHdr,
            this.DaysHdr});
			this.MonthList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MonthList.FullRowSelect = true;
			this.MonthList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.MonthList.HideSelection = false;
			this.MonthList.Location = new System.Drawing.Point(3, 28);
			this.MonthList.MultiSelect = false;
			this.MonthList.Name = "MonthList";
			this.MonthList.Size = new System.Drawing.Size(309, 238);
			this.MonthList.TabIndex = 1;
			this.MonthList.UseCompatibleStateImageBehavior = false;
			this.MonthList.View = System.Windows.Forms.View.Details;
			this.MonthList.DoubleClick += new System.EventHandler(this.MonthEditBtn_Click);
			// 
			// MonthHdr
			// 
			this.MonthHdr.Text = "Month";
			this.MonthHdr.Width = 150;
			// 
			// DaysHdr
			// 
			this.DaysHdr.Text = "Days";
			this.DaysHdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// MonthToolbar
			// 
			this.MonthToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MonthAddBtn,
            this.MonthRemoveBtn,
            this.MonthEditBtn,
            this.toolStripSeparator1,
            this.MonthUpBtn,
            this.MonthDownBtn});
			this.MonthToolbar.Location = new System.Drawing.Point(3, 3);
			this.MonthToolbar.Name = "MonthToolbar";
			this.MonthToolbar.Size = new System.Drawing.Size(309, 25);
			this.MonthToolbar.TabIndex = 0;
			this.MonthToolbar.Text = "toolStrip1";
			// 
			// MonthAddBtn
			// 
			this.MonthAddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.MonthAddBtn.Image = ((System.Drawing.Image)(resources.GetObject("MonthAddBtn.Image")));
			this.MonthAddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MonthAddBtn.Name = "MonthAddBtn";
			this.MonthAddBtn.Size = new System.Drawing.Size(33, 22);
			this.MonthAddBtn.Text = "Add";
			this.MonthAddBtn.Click += new System.EventHandler(this.MonthAddBtn_Click);
			// 
			// MonthRemoveBtn
			// 
			this.MonthRemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.MonthRemoveBtn.Image = ((System.Drawing.Image)(resources.GetObject("MonthRemoveBtn.Image")));
			this.MonthRemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MonthRemoveBtn.Name = "MonthRemoveBtn";
			this.MonthRemoveBtn.Size = new System.Drawing.Size(54, 22);
			this.MonthRemoveBtn.Text = "Remove";
			this.MonthRemoveBtn.Click += new System.EventHandler(this.MonthRemoveBtn_Click);
			// 
			// MonthEditBtn
			// 
			this.MonthEditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.MonthEditBtn.Image = ((System.Drawing.Image)(resources.GetObject("MonthEditBtn.Image")));
			this.MonthEditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MonthEditBtn.Name = "MonthEditBtn";
			this.MonthEditBtn.Size = new System.Drawing.Size(31, 22);
			this.MonthEditBtn.Text = "Edit";
			this.MonthEditBtn.Click += new System.EventHandler(this.MonthEditBtn_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// MonthUpBtn
			// 
			this.MonthUpBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.MonthUpBtn.Image = ((System.Drawing.Image)(resources.GetObject("MonthUpBtn.Image")));
			this.MonthUpBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MonthUpBtn.Name = "MonthUpBtn";
			this.MonthUpBtn.Size = new System.Drawing.Size(59, 22);
			this.MonthUpBtn.Text = "Move Up";
			this.MonthUpBtn.Click += new System.EventHandler(this.MonthUpBtn_Click);
			// 
			// MonthDownBtn
			// 
			this.MonthDownBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.MonthDownBtn.Image = ((System.Drawing.Image)(resources.GetObject("MonthDownBtn.Image")));
			this.MonthDownBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MonthDownBtn.Name = "MonthDownBtn";
			this.MonthDownBtn.Size = new System.Drawing.Size(75, 22);
			this.MonthDownBtn.Text = "Move Down";
			this.MonthDownBtn.Click += new System.EventHandler(this.MonthDownBtn_Click);
			// 
			// DaysPage
			// 
			this.DaysPage.Controls.Add(this.DayList);
			this.DaysPage.Controls.Add(this.DayToolbar);
			this.DaysPage.Location = new System.Drawing.Point(4, 22);
			this.DaysPage.Name = "DaysPage";
			this.DaysPage.Padding = new System.Windows.Forms.Padding(3);
			this.DaysPage.Size = new System.Drawing.Size(315, 269);
			this.DaysPage.TabIndex = 2;
			this.DaysPage.Text = "Days";
			this.DaysPage.UseVisualStyleBackColor = true;
			// 
			// DayList
			// 
			this.DayList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DayHdr});
			this.DayList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DayList.FullRowSelect = true;
			this.DayList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.DayList.HideSelection = false;
			this.DayList.Location = new System.Drawing.Point(3, 28);
			this.DayList.MultiSelect = false;
			this.DayList.Name = "DayList";
			this.DayList.Size = new System.Drawing.Size(309, 238);
			this.DayList.TabIndex = 3;
			this.DayList.UseCompatibleStateImageBehavior = false;
			this.DayList.View = System.Windows.Forms.View.Details;
			this.DayList.DoubleClick += new System.EventHandler(this.DayEditBtn_Click);
			// 
			// DayHdr
			// 
			this.DayHdr.Text = "Day";
			this.DayHdr.Width = 150;
			// 
			// DayToolbar
			// 
			this.DayToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DayAddBtn,
            this.DayRemoveBtn,
            this.DayEditBtn,
            this.toolStripSeparator2,
            this.DayUpBtn,
            this.DayDownBtn});
			this.DayToolbar.Location = new System.Drawing.Point(3, 3);
			this.DayToolbar.Name = "DayToolbar";
			this.DayToolbar.Size = new System.Drawing.Size(309, 25);
			this.DayToolbar.TabIndex = 2;
			this.DayToolbar.Text = "toolStrip2";
			// 
			// DayAddBtn
			// 
			this.DayAddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.DayAddBtn.Image = ((System.Drawing.Image)(resources.GetObject("DayAddBtn.Image")));
			this.DayAddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.DayAddBtn.Name = "DayAddBtn";
			this.DayAddBtn.Size = new System.Drawing.Size(33, 22);
			this.DayAddBtn.Text = "Add";
			this.DayAddBtn.Click += new System.EventHandler(this.DayAddBtn_Click);
			// 
			// DayRemoveBtn
			// 
			this.DayRemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.DayRemoveBtn.Image = ((System.Drawing.Image)(resources.GetObject("DayRemoveBtn.Image")));
			this.DayRemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.DayRemoveBtn.Name = "DayRemoveBtn";
			this.DayRemoveBtn.Size = new System.Drawing.Size(54, 22);
			this.DayRemoveBtn.Text = "Remove";
			this.DayRemoveBtn.Click += new System.EventHandler(this.DayRemoveBtn_Click);
			// 
			// DayEditBtn
			// 
			this.DayEditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.DayEditBtn.Image = ((System.Drawing.Image)(resources.GetObject("DayEditBtn.Image")));
			this.DayEditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.DayEditBtn.Name = "DayEditBtn";
			this.DayEditBtn.Size = new System.Drawing.Size(31, 22);
			this.DayEditBtn.Text = "Edit";
			this.DayEditBtn.Click += new System.EventHandler(this.DayEditBtn_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// DayUpBtn
			// 
			this.DayUpBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.DayUpBtn.Image = ((System.Drawing.Image)(resources.GetObject("DayUpBtn.Image")));
			this.DayUpBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.DayUpBtn.Name = "DayUpBtn";
			this.DayUpBtn.Size = new System.Drawing.Size(59, 22);
			this.DayUpBtn.Text = "Move Up";
			this.DayUpBtn.Click += new System.EventHandler(this.DayUpBtn_Click);
			// 
			// DayDownBtn
			// 
			this.DayDownBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.DayDownBtn.Image = ((System.Drawing.Image)(resources.GetObject("DayDownBtn.Image")));
			this.DayDownBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.DayDownBtn.Name = "DayDownBtn";
			this.DayDownBtn.Size = new System.Drawing.Size(75, 22);
			this.DayDownBtn.Text = "Move Down";
			this.DayDownBtn.Click += new System.EventHandler(this.DayDownBtn_Click);
			// 
			// SeasonsPage
			// 
			this.SeasonsPage.Controls.Add(this.SeasonList);
			this.SeasonsPage.Controls.Add(this.SeasonToolbar);
			this.SeasonsPage.Location = new System.Drawing.Point(4, 22);
			this.SeasonsPage.Name = "SeasonsPage";
			this.SeasonsPage.Padding = new System.Windows.Forms.Padding(3);
			this.SeasonsPage.Size = new System.Drawing.Size(315, 269);
			this.SeasonsPage.TabIndex = 5;
			this.SeasonsPage.Text = "Seasons";
			this.SeasonsPage.UseVisualStyleBackColor = true;
			// 
			// SeasonList
			// 
			this.SeasonList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SeasonHdr,
            this.SeasonDateHdr});
			this.SeasonList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SeasonList.FullRowSelect = true;
			this.SeasonList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.SeasonList.HideSelection = false;
			this.SeasonList.Location = new System.Drawing.Point(3, 28);
			this.SeasonList.MultiSelect = false;
			this.SeasonList.Name = "SeasonList";
			this.SeasonList.Size = new System.Drawing.Size(309, 238);
			this.SeasonList.TabIndex = 7;
			this.SeasonList.UseCompatibleStateImageBehavior = false;
			this.SeasonList.View = System.Windows.Forms.View.Details;
			this.SeasonList.DoubleClick += new System.EventHandler(this.SeasonEditBtn_Click);
			// 
			// SeasonHdr
			// 
			this.SeasonHdr.Text = "Season";
			this.SeasonHdr.Width = 150;
			// 
			// SeasonDateHdr
			// 
			this.SeasonDateHdr.Text = "Date";
			this.SeasonDateHdr.Width = 120;
			// 
			// SeasonToolbar
			// 
			this.SeasonToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SeasonAddBtn,
            this.SeasonRemoveBtn,
            this.SeasonEditBtn});
			this.SeasonToolbar.Location = new System.Drawing.Point(3, 3);
			this.SeasonToolbar.Name = "SeasonToolbar";
			this.SeasonToolbar.Size = new System.Drawing.Size(309, 25);
			this.SeasonToolbar.TabIndex = 6;
			this.SeasonToolbar.Text = "toolStrip2";
			// 
			// SeasonAddBtn
			// 
			this.SeasonAddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SeasonAddBtn.Image = ((System.Drawing.Image)(resources.GetObject("SeasonAddBtn.Image")));
			this.SeasonAddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SeasonAddBtn.Name = "SeasonAddBtn";
			this.SeasonAddBtn.Size = new System.Drawing.Size(33, 22);
			this.SeasonAddBtn.Text = "Add";
			this.SeasonAddBtn.Click += new System.EventHandler(this.SeasonAddBtn_Click);
			// 
			// SeasonRemoveBtn
			// 
			this.SeasonRemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SeasonRemoveBtn.Image = ((System.Drawing.Image)(resources.GetObject("SeasonRemoveBtn.Image")));
			this.SeasonRemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SeasonRemoveBtn.Name = "SeasonRemoveBtn";
			this.SeasonRemoveBtn.Size = new System.Drawing.Size(54, 22);
			this.SeasonRemoveBtn.Text = "Remove";
			this.SeasonRemoveBtn.Click += new System.EventHandler(this.SeasonRemoveBtn_Click);
			// 
			// SeasonEditBtn
			// 
			this.SeasonEditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SeasonEditBtn.Image = ((System.Drawing.Image)(resources.GetObject("SeasonEditBtn.Image")));
			this.SeasonEditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SeasonEditBtn.Name = "SeasonEditBtn";
			this.SeasonEditBtn.Size = new System.Drawing.Size(31, 22);
			this.SeasonEditBtn.Text = "Edit";
			this.SeasonEditBtn.Click += new System.EventHandler(this.SeasonEditBtn_Click);
			// 
			// EventsPage
			// 
			this.EventsPage.Controls.Add(this.EventList);
			this.EventsPage.Controls.Add(this.EventToolbar);
			this.EventsPage.Location = new System.Drawing.Point(4, 22);
			this.EventsPage.Name = "EventsPage";
			this.EventsPage.Padding = new System.Windows.Forms.Padding(3);
			this.EventsPage.Size = new System.Drawing.Size(315, 269);
			this.EventsPage.TabIndex = 3;
			this.EventsPage.Text = "Events";
			this.EventsPage.UseVisualStyleBackColor = true;
			// 
			// EventList
			// 
			this.EventList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EventHdr,
            this.DateHdr});
			this.EventList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EventList.FullRowSelect = true;
			this.EventList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.EventList.HideSelection = false;
			this.EventList.Location = new System.Drawing.Point(3, 28);
			this.EventList.MultiSelect = false;
			this.EventList.Name = "EventList";
			this.EventList.Size = new System.Drawing.Size(309, 238);
			this.EventList.TabIndex = 5;
			this.EventList.UseCompatibleStateImageBehavior = false;
			this.EventList.View = System.Windows.Forms.View.Details;
			this.EventList.DoubleClick += new System.EventHandler(this.EventEditBtn_Click);
			// 
			// EventHdr
			// 
			this.EventHdr.Text = "Event";
			this.EventHdr.Width = 150;
			// 
			// DateHdr
			// 
			this.DateHdr.Text = "Date";
			this.DateHdr.Width = 120;
			// 
			// EventToolbar
			// 
			this.EventToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EventAddBtn,
            this.EventRemoveBtn,
            this.EventEditBtn});
			this.EventToolbar.Location = new System.Drawing.Point(3, 3);
			this.EventToolbar.Name = "EventToolbar";
			this.EventToolbar.Size = new System.Drawing.Size(309, 25);
			this.EventToolbar.TabIndex = 4;
			this.EventToolbar.Text = "toolStrip2";
			// 
			// EventAddBtn
			// 
			this.EventAddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.EventAddBtn.Image = ((System.Drawing.Image)(resources.GetObject("EventAddBtn.Image")));
			this.EventAddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EventAddBtn.Name = "EventAddBtn";
			this.EventAddBtn.Size = new System.Drawing.Size(33, 22);
			this.EventAddBtn.Text = "Add";
			this.EventAddBtn.Click += new System.EventHandler(this.EventAddBtn_Click);
			// 
			// EventRemoveBtn
			// 
			this.EventRemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.EventRemoveBtn.Image = ((System.Drawing.Image)(resources.GetObject("EventRemoveBtn.Image")));
			this.EventRemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EventRemoveBtn.Name = "EventRemoveBtn";
			this.EventRemoveBtn.Size = new System.Drawing.Size(54, 22);
			this.EventRemoveBtn.Text = "Remove";
			this.EventRemoveBtn.Click += new System.EventHandler(this.EventRemoveBtn_Click);
			// 
			// EventEditBtn
			// 
			this.EventEditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.EventEditBtn.Image = ((System.Drawing.Image)(resources.GetObject("EventEditBtn.Image")));
			this.EventEditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EventEditBtn.Name = "EventEditBtn";
			this.EventEditBtn.Size = new System.Drawing.Size(31, 22);
			this.EventEditBtn.Text = "Edit";
			this.EventEditBtn.Click += new System.EventHandler(this.EventEditBtn_Click);
			// 
			// SatellitePage
			// 
			this.SatellitePage.Controls.Add(this.SatelliteList);
			this.SatellitePage.Controls.Add(this.SatelliteToolbar);
			this.SatellitePage.Location = new System.Drawing.Point(4, 22);
			this.SatellitePage.Name = "SatellitePage";
			this.SatellitePage.Padding = new System.Windows.Forms.Padding(3);
			this.SatellitePage.Size = new System.Drawing.Size(315, 269);
			this.SatellitePage.TabIndex = 4;
			this.SatellitePage.Text = "Satellites";
			this.SatellitePage.UseVisualStyleBackColor = true;
			// 
			// SatelliteList
			// 
			this.SatelliteList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SatelliteHdr});
			this.SatelliteList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SatelliteList.FullRowSelect = true;
			this.SatelliteList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.SatelliteList.HideSelection = false;
			this.SatelliteList.Location = new System.Drawing.Point(3, 28);
			this.SatelliteList.MultiSelect = false;
			this.SatelliteList.Name = "SatelliteList";
			this.SatelliteList.Size = new System.Drawing.Size(309, 238);
			this.SatelliteList.TabIndex = 7;
			this.SatelliteList.UseCompatibleStateImageBehavior = false;
			this.SatelliteList.View = System.Windows.Forms.View.Details;
			this.SatelliteList.DoubleClick += new System.EventHandler(this.SatelliteEditBtn_Click);
			// 
			// SatelliteHdr
			// 
			this.SatelliteHdr.Text = "Satellite";
			this.SatelliteHdr.Width = 150;
			// 
			// SatelliteToolbar
			// 
			this.SatelliteToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SatelliteAddBtn,
            this.SatelliteRemoveBtn,
            this.SatelliteEditBtn});
			this.SatelliteToolbar.Location = new System.Drawing.Point(3, 3);
			this.SatelliteToolbar.Name = "SatelliteToolbar";
			this.SatelliteToolbar.Size = new System.Drawing.Size(309, 25);
			this.SatelliteToolbar.TabIndex = 6;
			this.SatelliteToolbar.Text = "toolStrip2";
			// 
			// SatelliteAddBtn
			// 
			this.SatelliteAddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SatelliteAddBtn.Image = ((System.Drawing.Image)(resources.GetObject("SatelliteAddBtn.Image")));
			this.SatelliteAddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SatelliteAddBtn.Name = "SatelliteAddBtn";
			this.SatelliteAddBtn.Size = new System.Drawing.Size(33, 22);
			this.SatelliteAddBtn.Text = "Add";
			this.SatelliteAddBtn.Click += new System.EventHandler(this.SatelliteAddBtn_Click);
			// 
			// SatelliteRemoveBtn
			// 
			this.SatelliteRemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SatelliteRemoveBtn.Image = ((System.Drawing.Image)(resources.GetObject("SatelliteRemoveBtn.Image")));
			this.SatelliteRemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SatelliteRemoveBtn.Name = "SatelliteRemoveBtn";
			this.SatelliteRemoveBtn.Size = new System.Drawing.Size(54, 22);
			this.SatelliteRemoveBtn.Text = "Remove";
			this.SatelliteRemoveBtn.Click += new System.EventHandler(this.SatelliteRemoveBtn_Click);
			// 
			// SatelliteEditBtn
			// 
			this.SatelliteEditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SatelliteEditBtn.Image = ((System.Drawing.Image)(resources.GetObject("SatelliteEditBtn.Image")));
			this.SatelliteEditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SatelliteEditBtn.Name = "SatelliteEditBtn";
			this.SatelliteEditBtn.Size = new System.Drawing.Size(31, 22);
			this.SatelliteEditBtn.Text = "Edit";
			this.SatelliteEditBtn.Click += new System.EventHandler(this.SatelliteEditBtn_Click);
			// 
			// CalendarForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(347, 400);
			this.Controls.Add(this.Pages);
			this.Controls.Add(this.YearBox);
			this.Controls.Add(this.YearLbl);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CalendarForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Calendar";
			((System.ComponentModel.ISupportInitialize)(this.YearBox)).EndInit();
			this.Pages.ResumeLayout(false);
			this.DetailsPage.ResumeLayout(false);
			this.DetailsPage.PerformLayout();
			this.MonthsPage.ResumeLayout(false);
			this.MonthsPage.PerformLayout();
			this.MonthToolbar.ResumeLayout(false);
			this.MonthToolbar.PerformLayout();
			this.DaysPage.ResumeLayout(false);
			this.DaysPage.PerformLayout();
			this.DayToolbar.ResumeLayout(false);
			this.DayToolbar.PerformLayout();
			this.SeasonsPage.ResumeLayout(false);
			this.SeasonsPage.PerformLayout();
			this.SeasonToolbar.ResumeLayout(false);
			this.SeasonToolbar.PerformLayout();
			this.EventsPage.ResumeLayout(false);
			this.EventsPage.PerformLayout();
			this.EventToolbar.ResumeLayout(false);
			this.EventToolbar.PerformLayout();
			this.SatellitePage.ResumeLayout(false);
			this.SatellitePage.PerformLayout();
			this.SatelliteToolbar.ResumeLayout(false);
			this.SatelliteToolbar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label NameLbl;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.Label YearLbl;
		private System.Windows.Forms.NumericUpDown YearBox;
		private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.TabPage DetailsPage;
		private System.Windows.Forms.TabPage MonthsPage;
		private System.Windows.Forms.TabPage DaysPage;
		private System.Windows.Forms.TextBox DetailsBox;
		private System.Windows.Forms.ListView MonthList;
		private System.Windows.Forms.ToolStrip MonthToolbar;
		private System.Windows.Forms.ColumnHeader MonthHdr;
		private System.Windows.Forms.ColumnHeader DaysHdr;
		private System.Windows.Forms.ToolStripButton MonthAddBtn;
		private System.Windows.Forms.ToolStripButton MonthRemoveBtn;
		private System.Windows.Forms.ToolStripButton MonthEditBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton MonthUpBtn;
		private System.Windows.Forms.ToolStripButton MonthDownBtn;
		private System.Windows.Forms.ListView DayList;
		private System.Windows.Forms.ColumnHeader DayHdr;
		private System.Windows.Forms.ToolStrip DayToolbar;
		private System.Windows.Forms.ToolStripButton DayAddBtn;
		private System.Windows.Forms.ToolStripButton DayRemoveBtn;
		private System.Windows.Forms.ToolStripButton DayEditBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton DayUpBtn;
		private System.Windows.Forms.ToolStripButton DayDownBtn;
		private System.Windows.Forms.TabPage EventsPage;
		private System.Windows.Forms.ListView EventList;
		private System.Windows.Forms.ColumnHeader EventHdr;
		private System.Windows.Forms.ColumnHeader DateHdr;
		private System.Windows.Forms.ToolStrip EventToolbar;
		private System.Windows.Forms.ToolStripButton EventAddBtn;
		private System.Windows.Forms.ToolStripButton EventRemoveBtn;
		private System.Windows.Forms.ToolStripButton EventEditBtn;
		private System.Windows.Forms.TabPage SatellitePage;
		private System.Windows.Forms.ListView SatelliteList;
		private System.Windows.Forms.ColumnHeader SatelliteHdr;
		private System.Windows.Forms.ToolStrip SatelliteToolbar;
		private System.Windows.Forms.ToolStripButton SatelliteAddBtn;
		private System.Windows.Forms.ToolStripButton SatelliteRemoveBtn;
		private System.Windows.Forms.ToolStripButton SatelliteEditBtn;
		private System.Windows.Forms.TabPage SeasonsPage;
		private System.Windows.Forms.ListView SeasonList;
		private System.Windows.Forms.ColumnHeader SeasonHdr;
		private System.Windows.Forms.ColumnHeader SeasonDateHdr;
		private System.Windows.Forms.ToolStrip SeasonToolbar;
		private System.Windows.Forms.ToolStripButton SeasonAddBtn;
		private System.Windows.Forms.ToolStripButton SeasonRemoveBtn;
		private System.Windows.Forms.ToolStripButton SeasonEditBtn;
	}
}