namespace Masterplan.UI
{
    partial class MapAreaSelectForm
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
			this.MapLbl = new System.Windows.Forms.Label();
			this.MapBox = new System.Windows.Forms.ComboBox();
			this.AreaLbl = new System.Windows.Forms.Label();
			this.AreaBox = new System.Windows.Forms.ComboBox();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.MapView = new Masterplan.Controls.MapView();
			this.NewBtn = new System.Windows.Forms.Button();
			this.ImportBtn = new System.Windows.Forms.Button();
			this.UseTileBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// MapLbl
			// 
			this.MapLbl.AutoSize = true;
			this.MapLbl.Location = new System.Drawing.Point(12, 15);
			this.MapLbl.Name = "MapLbl";
			this.MapLbl.Size = new System.Drawing.Size(31, 13);
			this.MapLbl.TabIndex = 0;
			this.MapLbl.Text = "Map:";
			// 
			// MapBox
			// 
			this.MapBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.MapBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.MapBox.FormattingEnabled = true;
			this.MapBox.Location = new System.Drawing.Point(50, 12);
			this.MapBox.Name = "MapBox";
			this.MapBox.Size = new System.Drawing.Size(497, 21);
			this.MapBox.Sorted = true;
			this.MapBox.TabIndex = 1;
			this.MapBox.SelectedIndexChanged += new System.EventHandler(this.MapBox_SelectedIndexChanged);
			// 
			// AreaLbl
			// 
			this.AreaLbl.AutoSize = true;
			this.AreaLbl.Location = new System.Drawing.Point(12, 42);
			this.AreaLbl.Name = "AreaLbl";
			this.AreaLbl.Size = new System.Drawing.Size(32, 13);
			this.AreaLbl.TabIndex = 2;
			this.AreaLbl.Text = "Area:";
			// 
			// AreaBox
			// 
			this.AreaBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.AreaBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.AreaBox.FormattingEnabled = true;
			this.AreaBox.Location = new System.Drawing.Point(50, 39);
			this.AreaBox.Name = "AreaBox";
			this.AreaBox.Size = new System.Drawing.Size(497, 21);
			this.AreaBox.Sorted = true;
			this.AreaBox.TabIndex = 3;
			this.AreaBox.SelectedIndexChanged += new System.EventHandler(this.AreaBox_SelectedIndexChanged);
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(391, 357);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 8;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(472, 357);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 9;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// MapView
			// 
			this.MapView.AllowDrawing = false;
			this.MapView.AllowDrop = true;
			this.MapView.AllowLinkCreation = false;
			this.MapView.AllowScrolling = false;
			this.MapView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
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
			this.MapView.Location = new System.Drawing.Point(12, 66);
			this.MapView.Map = null;
			this.MapView.Mode = Masterplan.Controls.MapViewMode.Plain;
			this.MapView.Name = "MapView";
			this.MapView.ScalingFactor = 1;
			this.MapView.SelectedArea = null;
			this.MapView.SelectedTiles = null;
			this.MapView.Selection = new System.Drawing.Rectangle(0, 0, 0, 0);
			this.MapView.ShowAuras = true;
			this.MapView.ShowCreatureLabels = true;
			this.MapView.ShowCreatures = Masterplan.Controls.CreatureViewMode.All;
			this.MapView.ShowGrid = Masterplan.Controls.MapGridMode.None;
			this.MapView.ShowGridLabels = false;
			this.MapView.ShowHealthBars = false;
			this.MapView.ShowPictureTokens = true;
			this.MapView.Size = new System.Drawing.Size(535, 285);
			this.MapView.TabIndex = 4;
			this.MapView.Tactical = false;
			this.MapView.TokenLinks = null;
			this.MapView.Viewpoint = new System.Drawing.Rectangle(0, 0, 0, 0);
			// 
			// NewBtn
			// 
			this.NewBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.NewBtn.Location = new System.Drawing.Point(12, 357);
			this.NewBtn.Name = "NewBtn";
			this.NewBtn.Size = new System.Drawing.Size(100, 23);
			this.NewBtn.TabIndex = 5;
			this.NewBtn.Text = "Create New Map";
			this.NewBtn.UseVisualStyleBackColor = true;
			this.NewBtn.Click += new System.EventHandler(this.NewBtn_Click);
			// 
			// ImportBtn
			// 
			this.ImportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ImportBtn.Location = new System.Drawing.Point(118, 357);
			this.ImportBtn.Name = "ImportBtn";
			this.ImportBtn.Size = new System.Drawing.Size(100, 23);
			this.ImportBtn.TabIndex = 6;
			this.ImportBtn.Text = "Import Map File";
			this.ImportBtn.UseVisualStyleBackColor = true;
			this.ImportBtn.Click += new System.EventHandler(this.ImportBtn_Click);
			// 
			// UseTileBtn
			// 
			this.UseTileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.UseTileBtn.Location = new System.Drawing.Point(224, 357);
			this.UseTileBtn.Name = "UseTileBtn";
			this.UseTileBtn.Size = new System.Drawing.Size(100, 23);
			this.UseTileBtn.TabIndex = 7;
			this.UseTileBtn.Text = "Use Map Tile";
			this.UseTileBtn.UseVisualStyleBackColor = true;
			this.UseTileBtn.Click += new System.EventHandler(this.UseTileBtn_Click);
			// 
			// MapAreaSelectForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(559, 392);
			this.Controls.Add(this.UseTileBtn);
			this.Controls.Add(this.ImportBtn);
			this.Controls.Add(this.NewBtn);
			this.Controls.Add(this.MapView);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.AreaBox);
			this.Controls.Add(this.AreaLbl);
			this.Controls.Add(this.MapBox);
			this.Controls.Add(this.MapLbl);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MapAreaSelectForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Location";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MapLbl;
        private System.Windows.Forms.ComboBox MapBox;
        private System.Windows.Forms.Label AreaLbl;
        private System.Windows.Forms.ComboBox AreaBox;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button CancelBtn;
        private Masterplan.Controls.MapView MapView;
		private System.Windows.Forms.Button NewBtn;
		private System.Windows.Forms.Button ImportBtn;
		private System.Windows.Forms.Button UseTileBtn;
    }
}