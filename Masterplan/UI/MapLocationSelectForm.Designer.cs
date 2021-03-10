namespace Masterplan.UI
{
    partial class MapLocationSelectForm
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
			this.LocationLbl = new System.Windows.Forms.Label();
			this.LocationBox = new System.Windows.Forms.ComboBox();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.MapPanel = new Masterplan.Controls.RegionalMapPanel();
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
			this.MapBox.Location = new System.Drawing.Point(69, 12);
			this.MapBox.Name = "MapBox";
			this.MapBox.Size = new System.Drawing.Size(478, 21);
			this.MapBox.Sorted = true;
			this.MapBox.TabIndex = 1;
			this.MapBox.SelectedIndexChanged += new System.EventHandler(this.MapBox_SelectedIndexChanged);
			// 
			// LocationLbl
			// 
			this.LocationLbl.AutoSize = true;
			this.LocationLbl.Location = new System.Drawing.Point(12, 42);
			this.LocationLbl.Name = "LocationLbl";
			this.LocationLbl.Size = new System.Drawing.Size(51, 13);
			this.LocationLbl.TabIndex = 2;
			this.LocationLbl.Text = "Location:";
			// 
			// LocationBox
			// 
			this.LocationBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.LocationBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.LocationBox.FormattingEnabled = true;
			this.LocationBox.Location = new System.Drawing.Point(69, 39);
			this.LocationBox.Name = "LocationBox";
			this.LocationBox.Size = new System.Drawing.Size(478, 21);
			this.LocationBox.Sorted = true;
			this.LocationBox.TabIndex = 3;
			this.LocationBox.SelectedIndexChanged += new System.EventHandler(this.AreaBox_SelectedIndexChanged);
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(391, 357);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 5;
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
			this.CancelBtn.TabIndex = 6;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// MapPanel
			// 
			this.MapPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.MapPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.MapPanel.HighlightedLocation = null;
			this.MapPanel.Location = new System.Drawing.Point(12, 66);
			this.MapPanel.Map = null;
			this.MapPanel.Mode = Masterplan.Controls.MapViewMode.Plain;
			this.MapPanel.Name = "MapPanel";
			this.MapPanel.SelectedLocation = null;
			this.MapPanel.ShowLocations = true;
			this.MapPanel.Size = new System.Drawing.Size(535, 285);
			this.MapPanel.TabIndex = 4;
			// 
			// MapLocationSelectForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(559, 392);
			this.Controls.Add(this.MapPanel);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.LocationBox);
			this.Controls.Add(this.LocationLbl);
			this.Controls.Add(this.MapBox);
			this.Controls.Add(this.MapLbl);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MapLocationSelectForm";
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
        private System.Windows.Forms.Label LocationLbl;
        private System.Windows.Forms.ComboBox LocationBox;
        private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private Masterplan.Controls.RegionalMapPanel MapPanel;
    }
}