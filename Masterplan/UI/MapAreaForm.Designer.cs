namespace Masterplan.UI
{
	partial class MapAreaForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapAreaForm));
			this.NameLbl = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.Pages = new System.Windows.Forms.TabControl();
			this.DetailsPage = new System.Windows.Forms.TabPage();
			this.DetailsBox = new System.Windows.Forms.TextBox();
			this.DetailsToolbar = new System.Windows.Forms.ToolStrip();
			this.RandomDescBtn = new System.Windows.Forms.ToolStripButton();
			this.MovePage = new System.Windows.Forms.TabPage();
			this.MoveTable = new System.Windows.Forms.TableLayoutPanel();
			this.MoveUpBtn = new System.Windows.Forms.Button();
			this.MoveDownBtn = new System.Windows.Forms.Button();
			this.MoveLeftBtn = new System.Windows.Forms.Button();
			this.MoveRightBtn = new System.Windows.Forms.Button();
			this.ResizePage = new System.Windows.Forms.TabPage();
			this.ResizeTable = new System.Windows.Forms.TableLayoutPanel();
			this.TopMoreBtn = new System.Windows.Forms.Button();
			this.TopLessBtn = new System.Windows.Forms.Button();
			this.LeftMoreBtn = new System.Windows.Forms.Button();
			this.LeftLessBtn = new System.Windows.Forms.Button();
			this.RightLessBtn = new System.Windows.Forms.Button();
			this.RightMoreBtn = new System.Windows.Forms.Button();
			this.BottomLessBtn = new System.Windows.Forms.Button();
			this.BottomMoreBtn = new System.Windows.Forms.Button();
			this.MapView = new Masterplan.Controls.MapView();
			this.RandomNameBtn = new System.Windows.Forms.ToolStripButton();
			this.Pages.SuspendLayout();
			this.DetailsPage.SuspendLayout();
			this.DetailsToolbar.SuspendLayout();
			this.MovePage.SuspendLayout();
			this.MoveTable.SuspendLayout();
			this.ResizePage.SuspendLayout();
			this.ResizeTable.SuspendLayout();
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
			this.NameBox.Size = new System.Drawing.Size(343, 20);
			this.NameBox.TabIndex = 1;
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(594, 382);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 4;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(675, 382);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 5;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// Pages
			// 
			this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Pages.Controls.Add(this.DetailsPage);
			this.Pages.Controls.Add(this.MovePage);
			this.Pages.Controls.Add(this.ResizePage);
			this.Pages.Location = new System.Drawing.Point(12, 38);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(387, 338);
			this.Pages.TabIndex = 6;
			// 
			// DetailsPage
			// 
			this.DetailsPage.Controls.Add(this.DetailsBox);
			this.DetailsPage.Controls.Add(this.DetailsToolbar);
			this.DetailsPage.Location = new System.Drawing.Point(4, 22);
			this.DetailsPage.Name = "DetailsPage";
			this.DetailsPage.Padding = new System.Windows.Forms.Padding(3);
			this.DetailsPage.Size = new System.Drawing.Size(379, 312);
			this.DetailsPage.TabIndex = 0;
			this.DetailsPage.Text = "Details";
			this.DetailsPage.UseVisualStyleBackColor = true;
			// 
			// DetailsBox
			// 
			this.DetailsBox.AcceptsReturn = true;
			this.DetailsBox.AcceptsTab = true;
			this.DetailsBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DetailsBox.Location = new System.Drawing.Point(3, 28);
			this.DetailsBox.Multiline = true;
			this.DetailsBox.Name = "DetailsBox";
			this.DetailsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.DetailsBox.Size = new System.Drawing.Size(373, 281);
			this.DetailsBox.TabIndex = 0;
			// 
			// DetailsToolbar
			// 
			this.DetailsToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RandomNameBtn,
            this.RandomDescBtn});
			this.DetailsToolbar.Location = new System.Drawing.Point(3, 3);
			this.DetailsToolbar.Name = "DetailsToolbar";
			this.DetailsToolbar.Size = new System.Drawing.Size(373, 25);
			this.DetailsToolbar.TabIndex = 1;
			this.DetailsToolbar.Text = "toolStrip1";
			// 
			// RandomDescBtn
			// 
			this.RandomDescBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.RandomDescBtn.Image = ((System.Drawing.Image)(resources.GetObject("RandomDescBtn.Image")));
			this.RandomDescBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RandomDescBtn.Name = "RandomDescBtn";
			this.RandomDescBtn.Size = new System.Drawing.Size(119, 22);
			this.RandomDescBtn.Text = "Random Description";
			this.RandomDescBtn.Click += new System.EventHandler(this.RandomDescBtn_Click);
			// 
			// MovePage
			// 
			this.MovePage.Controls.Add(this.MoveTable);
			this.MovePage.Location = new System.Drawing.Point(4, 22);
			this.MovePage.Name = "MovePage";
			this.MovePage.Padding = new System.Windows.Forms.Padding(3);
			this.MovePage.Size = new System.Drawing.Size(379, 312);
			this.MovePage.TabIndex = 2;
			this.MovePage.Text = "Move";
			this.MovePage.UseVisualStyleBackColor = true;
			// 
			// MoveTable
			// 
			this.MoveTable.ColumnCount = 3;
			this.MoveTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
			this.MoveTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
			this.MoveTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
			this.MoveTable.Controls.Add(this.MoveUpBtn, 1, 0);
			this.MoveTable.Controls.Add(this.MoveDownBtn, 1, 2);
			this.MoveTable.Controls.Add(this.MoveLeftBtn, 0, 1);
			this.MoveTable.Controls.Add(this.MoveRightBtn, 2, 1);
			this.MoveTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MoveTable.Location = new System.Drawing.Point(3, 3);
			this.MoveTable.Name = "MoveTable";
			this.MoveTable.RowCount = 3;
			this.MoveTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
			this.MoveTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
			this.MoveTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
			this.MoveTable.Size = new System.Drawing.Size(373, 306);
			this.MoveTable.TabIndex = 0;
			// 
			// MoveUpBtn
			// 
			this.MoveUpBtn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MoveUpBtn.Location = new System.Drawing.Point(126, 3);
			this.MoveUpBtn.Name = "MoveUpBtn";
			this.MoveUpBtn.Size = new System.Drawing.Size(120, 94);
			this.MoveUpBtn.TabIndex = 0;
			this.MoveUpBtn.Text = "Up";
			this.MoveUpBtn.UseVisualStyleBackColor = true;
			this.MoveUpBtn.Click += new System.EventHandler(this.MoveUpBtn_Click);
			// 
			// MoveDownBtn
			// 
			this.MoveDownBtn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MoveDownBtn.Location = new System.Drawing.Point(126, 207);
			this.MoveDownBtn.Name = "MoveDownBtn";
			this.MoveDownBtn.Size = new System.Drawing.Size(120, 96);
			this.MoveDownBtn.TabIndex = 3;
			this.MoveDownBtn.Text = "Down";
			this.MoveDownBtn.UseVisualStyleBackColor = true;
			this.MoveDownBtn.Click += new System.EventHandler(this.MoveDownBtn_Click);
			// 
			// MoveLeftBtn
			// 
			this.MoveLeftBtn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MoveLeftBtn.Location = new System.Drawing.Point(3, 103);
			this.MoveLeftBtn.Name = "MoveLeftBtn";
			this.MoveLeftBtn.Size = new System.Drawing.Size(117, 98);
			this.MoveLeftBtn.TabIndex = 1;
			this.MoveLeftBtn.Text = "Left";
			this.MoveLeftBtn.UseVisualStyleBackColor = true;
			this.MoveLeftBtn.Click += new System.EventHandler(this.MoveLeftBtn_Click);
			// 
			// MoveRightBtn
			// 
			this.MoveRightBtn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MoveRightBtn.Location = new System.Drawing.Point(252, 103);
			this.MoveRightBtn.Name = "MoveRightBtn";
			this.MoveRightBtn.Size = new System.Drawing.Size(118, 98);
			this.MoveRightBtn.TabIndex = 2;
			this.MoveRightBtn.Text = "Right";
			this.MoveRightBtn.UseVisualStyleBackColor = true;
			this.MoveRightBtn.Click += new System.EventHandler(this.MoveRightBtn_Click);
			// 
			// ResizePage
			// 
			this.ResizePage.Controls.Add(this.ResizeTable);
			this.ResizePage.Location = new System.Drawing.Point(4, 22);
			this.ResizePage.Name = "ResizePage";
			this.ResizePage.Padding = new System.Windows.Forms.Padding(3);
			this.ResizePage.Size = new System.Drawing.Size(391, 312);
			this.ResizePage.TabIndex = 1;
			this.ResizePage.Text = "Resize";
			this.ResizePage.UseVisualStyleBackColor = true;
			// 
			// ResizeTable
			// 
			this.ResizeTable.ColumnCount = 4;
			this.ResizeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.ResizeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.ResizeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.ResizeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.ResizeTable.Controls.Add(this.TopMoreBtn, 1, 0);
			this.ResizeTable.Controls.Add(this.TopLessBtn, 2, 0);
			this.ResizeTable.Controls.Add(this.LeftMoreBtn, 0, 1);
			this.ResizeTable.Controls.Add(this.LeftLessBtn, 0, 2);
			this.ResizeTable.Controls.Add(this.RightLessBtn, 3, 2);
			this.ResizeTable.Controls.Add(this.RightMoreBtn, 3, 1);
			this.ResizeTable.Controls.Add(this.BottomLessBtn, 2, 3);
			this.ResizeTable.Controls.Add(this.BottomMoreBtn, 1, 3);
			this.ResizeTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ResizeTable.Location = new System.Drawing.Point(3, 3);
			this.ResizeTable.Name = "ResizeTable";
			this.ResizeTable.RowCount = 4;
			this.ResizeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.ResizeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.ResizeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.ResizeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.ResizeTable.Size = new System.Drawing.Size(385, 306);
			this.ResizeTable.TabIndex = 0;
			// 
			// TopMoreBtn
			// 
			this.TopMoreBtn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TopMoreBtn.Location = new System.Drawing.Point(99, 3);
			this.TopMoreBtn.Name = "TopMoreBtn";
			this.TopMoreBtn.Size = new System.Drawing.Size(90, 70);
			this.TopMoreBtn.TabIndex = 0;
			this.TopMoreBtn.Text = "More";
			this.TopMoreBtn.UseVisualStyleBackColor = true;
			this.TopMoreBtn.Click += new System.EventHandler(this.TopMoreBtn_Click);
			// 
			// TopLessBtn
			// 
			this.TopLessBtn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TopLessBtn.Location = new System.Drawing.Point(195, 3);
			this.TopLessBtn.Name = "TopLessBtn";
			this.TopLessBtn.Size = new System.Drawing.Size(90, 70);
			this.TopLessBtn.TabIndex = 1;
			this.TopLessBtn.Text = "Less";
			this.TopLessBtn.UseVisualStyleBackColor = true;
			this.TopLessBtn.Click += new System.EventHandler(this.TopLessBtn_Click);
			// 
			// LeftMoreBtn
			// 
			this.LeftMoreBtn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LeftMoreBtn.Location = new System.Drawing.Point(3, 79);
			this.LeftMoreBtn.Name = "LeftMoreBtn";
			this.LeftMoreBtn.Size = new System.Drawing.Size(90, 70);
			this.LeftMoreBtn.TabIndex = 2;
			this.LeftMoreBtn.Text = "More";
			this.LeftMoreBtn.UseVisualStyleBackColor = true;
			this.LeftMoreBtn.Click += new System.EventHandler(this.LeftMoreBtn_Click);
			// 
			// LeftLessBtn
			// 
			this.LeftLessBtn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LeftLessBtn.Location = new System.Drawing.Point(3, 155);
			this.LeftLessBtn.Name = "LeftLessBtn";
			this.LeftLessBtn.Size = new System.Drawing.Size(90, 70);
			this.LeftLessBtn.TabIndex = 3;
			this.LeftLessBtn.Text = "Less";
			this.LeftLessBtn.UseVisualStyleBackColor = true;
			this.LeftLessBtn.Click += new System.EventHandler(this.LeftLessBtn_Click);
			// 
			// RightLessBtn
			// 
			this.RightLessBtn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RightLessBtn.Location = new System.Drawing.Point(291, 155);
			this.RightLessBtn.Name = "RightLessBtn";
			this.RightLessBtn.Size = new System.Drawing.Size(91, 70);
			this.RightLessBtn.TabIndex = 4;
			this.RightLessBtn.Text = "Less";
			this.RightLessBtn.UseVisualStyleBackColor = true;
			this.RightLessBtn.Click += new System.EventHandler(this.RightLessBtn_Click);
			// 
			// RightMoreBtn
			// 
			this.RightMoreBtn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RightMoreBtn.Location = new System.Drawing.Point(291, 79);
			this.RightMoreBtn.Name = "RightMoreBtn";
			this.RightMoreBtn.Size = new System.Drawing.Size(91, 70);
			this.RightMoreBtn.TabIndex = 5;
			this.RightMoreBtn.Text = "More";
			this.RightMoreBtn.UseVisualStyleBackColor = true;
			this.RightMoreBtn.Click += new System.EventHandler(this.RightMoreBtn_Click);
			// 
			// BottomLessBtn
			// 
			this.BottomLessBtn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BottomLessBtn.Location = new System.Drawing.Point(195, 231);
			this.BottomLessBtn.Name = "BottomLessBtn";
			this.BottomLessBtn.Size = new System.Drawing.Size(90, 72);
			this.BottomLessBtn.TabIndex = 6;
			this.BottomLessBtn.Text = "Less";
			this.BottomLessBtn.UseVisualStyleBackColor = true;
			this.BottomLessBtn.Click += new System.EventHandler(this.BottomLessBtn_Click);
			// 
			// BottomMoreBtn
			// 
			this.BottomMoreBtn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BottomMoreBtn.Location = new System.Drawing.Point(99, 231);
			this.BottomMoreBtn.Name = "BottomMoreBtn";
			this.BottomMoreBtn.Size = new System.Drawing.Size(90, 72);
			this.BottomMoreBtn.TabIndex = 7;
			this.BottomMoreBtn.Text = "More";
			this.BottomMoreBtn.UseVisualStyleBackColor = true;
			this.BottomMoreBtn.Click += new System.EventHandler(this.BottomMoreBtn_Click);
			// 
			// MapView
			// 
			this.MapView.AllowDrawing = false;
			this.MapView.AllowDrop = true;
			this.MapView.AllowLinkCreation = false;
			this.MapView.AllowScrolling = false;
			this.MapView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.MapView.BackgroundMap = null;
			this.MapView.BorderSize = 0;
			this.MapView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.MapView.Cursor = System.Windows.Forms.Cursors.Default;
			this.MapView.Encounter = null;
			this.MapView.FrameType = Masterplan.Controls.MapDisplayType.Dimmed;
			//this.MapView.HeroData = null;
			this.MapView.HighlightAreas = false;
			this.MapView.HoverToken = null;
			this.MapView.LineOfSight = false;
			this.MapView.Location = new System.Drawing.Point(405, 12);
			this.MapView.Map = null;
			this.MapView.Mode = Masterplan.Controls.MapViewMode.Thumbnail;
			this.MapView.Name = "MapView";
			this.MapView.ScalingFactor = 1;
			this.MapView.SelectedArea = null;
			this.MapView.SelectedTiles = null;
			this.MapView.Selection = new System.Drawing.Rectangle(0, 0, 0, 0);
			this.MapView.ShowAuras = true;
			this.MapView.ShowConditions = true;
			this.MapView.ShowCreatureLabels = true;
			this.MapView.ShowCreatures = Masterplan.Controls.CreatureViewMode.All;
			this.MapView.ShowGrid = Masterplan.Controls.MapGridMode.None;
			this.MapView.ShowGridLabels = false;
			this.MapView.ShowHealthBars = false;
			this.MapView.ShowPictureTokens = true;
			this.MapView.Size = new System.Drawing.Size(345, 364);
			this.MapView.TabIndex = 3;
			this.MapView.Tactical = false;
			this.MapView.TokenLinks = null;
			this.MapView.Viewpoint = new System.Drawing.Rectangle(0, 0, 0, 0);
			// 
			// RandomNameBtn
			// 
			this.RandomNameBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.RandomNameBtn.Image = ((System.Drawing.Image)(resources.GetObject("RandomNameBtn.Image")));
			this.RandomNameBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RandomNameBtn.Name = "RandomNameBtn";
			this.RandomNameBtn.Size = new System.Drawing.Size(91, 22);
			this.RandomNameBtn.Text = "Random Name";
			this.RandomNameBtn.Click += new System.EventHandler(this.RandomNameBtn_Click);
			// 
			// MapAreaForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(762, 417);
			this.Controls.Add(this.Pages);
			this.Controls.Add(this.MapView);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLbl);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MapAreaForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Map Area";
			this.Pages.ResumeLayout(false);
			this.DetailsPage.ResumeLayout(false);
			this.DetailsPage.PerformLayout();
			this.DetailsToolbar.ResumeLayout(false);
			this.DetailsToolbar.PerformLayout();
			this.MovePage.ResumeLayout(false);
			this.MoveTable.ResumeLayout(false);
			this.ResizePage.ResumeLayout(false);
			this.ResizeTable.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label NameLbl;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private Masterplan.Controls.MapView MapView;
		private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.TabPage DetailsPage;
		private System.Windows.Forms.TextBox DetailsBox;
		private System.Windows.Forms.TabPage ResizePage;
		private System.Windows.Forms.TableLayoutPanel ResizeTable;
		private System.Windows.Forms.Button TopMoreBtn;
		private System.Windows.Forms.Button TopLessBtn;
		private System.Windows.Forms.Button LeftMoreBtn;
		private System.Windows.Forms.Button LeftLessBtn;
		private System.Windows.Forms.Button RightLessBtn;
		private System.Windows.Forms.Button RightMoreBtn;
		private System.Windows.Forms.Button BottomLessBtn;
		private System.Windows.Forms.Button BottomMoreBtn;
		private System.Windows.Forms.TabPage MovePage;
		private System.Windows.Forms.TableLayoutPanel MoveTable;
		private System.Windows.Forms.Button MoveUpBtn;
		private System.Windows.Forms.Button MoveDownBtn;
		private System.Windows.Forms.Button MoveLeftBtn;
		private System.Windows.Forms.Button MoveRightBtn;
		private System.Windows.Forms.ToolStrip DetailsToolbar;
		private System.Windows.Forms.ToolStripButton RandomDescBtn;
		private System.Windows.Forms.ToolStripButton RandomNameBtn;
	}
}