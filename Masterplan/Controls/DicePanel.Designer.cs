namespace Masterplan.Controls
{
	partial class DicePanel
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DicePanel));
			this.DiceToolbar = new System.Windows.Forms.ToolStrip();
			this.RollBtn = new System.Windows.Forms.ToolStripButton();
			this.ClearBtn = new System.Windows.Forms.ToolStripButton();
			this.OddsBtn = new System.Windows.Forms.ToolStripButton();
			this.DiceLbl = new System.Windows.Forms.Label();
			this.DiceList = new System.Windows.Forms.ListView();
			this.DiceSourceList = new System.Windows.Forms.ListView();
			this.ResultPanel = new System.Windows.Forms.Panel();
			this.ExpressionBox = new System.Windows.Forms.TextBox();
			this.DiceToolbar.SuspendLayout();
			this.ResultPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// DiceToolbar
			// 
			this.DiceToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RollBtn,
            this.ClearBtn,
            this.OddsBtn});
			this.DiceToolbar.Location = new System.Drawing.Point(0, 0);
			this.DiceToolbar.Name = "DiceToolbar";
			this.DiceToolbar.Size = new System.Drawing.Size(287, 25);
			this.DiceToolbar.TabIndex = 8;
			this.DiceToolbar.Text = Session.I18N.toolStrip1;
			// 
			// RollBtn
			// 
			this.RollBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.RollBtn.Image = ((System.Drawing.Image)(resources.GetObject("RollBtn.Image")));
			this.RollBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RollBtn.Name = "RollBtn";
			this.RollBtn.Size = new System.Drawing.Size(41, 22);
			this.RollBtn.Text = "Reroll";
			this.RollBtn.Click += new System.EventHandler(this.RollBtn_Click);
			// 
			// ClearBtn
			// 
			this.ClearBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ClearBtn.Image = ((System.Drawing.Image)(resources.GetObject("ClearBtn.Image")));
			this.ClearBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ClearBtn.Name = "ClearBtn";
			this.ClearBtn.Size = new System.Drawing.Size(38, 22);
			this.ClearBtn.Text = Session.I18N.Clear;
			this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
			// 
			// OddsBtn
			// 
			this.OddsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.OddsBtn.Image = ((System.Drawing.Image)(resources.GetObject("OddsBtn.Image")));
			this.OddsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.OddsBtn.Name = "OddsBtn";
			this.OddsBtn.Size = new System.Drawing.Size(39, 22);
			this.OddsBtn.Text = "Odds";
			this.OddsBtn.Click += new System.EventHandler(this.OddsBtn_Click);
			// 
			// DiceLbl
			// 
			this.DiceLbl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DiceLbl.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DiceLbl.Location = new System.Drawing.Point(0, 0);
			this.DiceLbl.Name = "DiceLbl";
			this.DiceLbl.Size = new System.Drawing.Size(287, 50);
			this.DiceLbl.TabIndex = 7;
			this.DiceLbl.Text = "-";
			this.DiceLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// DiceList
			// 
			this.DiceList.AllowDrop = true;
			this.DiceList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DiceList.Location = new System.Drawing.Point(0, 169);
			this.DiceList.Name = "DiceList";
			this.DiceList.Size = new System.Drawing.Size(287, 136);
			this.DiceList.TabIndex = 6;
			this.DiceList.UseCompatibleStateImageBehavior = false;
			this.DiceList.DoubleClick += new System.EventHandler(this.DiceList_DoubleClick);
			this.DiceList.DragOver += new System.Windows.Forms.DragEventHandler(this.DiceList_DragOver);
			// 
			// DiceSourceList
			// 
			this.DiceSourceList.Dock = System.Windows.Forms.DockStyle.Top;
			this.DiceSourceList.Location = new System.Drawing.Point(0, 25);
			this.DiceSourceList.Name = "DiceSourceList";
			this.DiceSourceList.Size = new System.Drawing.Size(287, 144);
			this.DiceSourceList.TabIndex = 5;
			this.DiceSourceList.UseCompatibleStateImageBehavior = false;
			this.DiceSourceList.DoubleClick += new System.EventHandler(this.DiceSourceList_DoubleClick);
			this.DiceSourceList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.DiceSourceList_ItemDrag);
			// 
			// ResultPanel
			// 
			this.ResultPanel.Controls.Add(this.DiceLbl);
			this.ResultPanel.Controls.Add(this.ExpressionBox);
			this.ResultPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ResultPanel.Location = new System.Drawing.Point(0, 235);
			this.ResultPanel.Name = "ResultPanel";
			this.ResultPanel.Size = new System.Drawing.Size(287, 70);
			this.ResultPanel.TabIndex = 10;
			// 
			// ExpressionBox
			// 
			this.ExpressionBox.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ExpressionBox.Location = new System.Drawing.Point(0, 50);
			this.ExpressionBox.Name = "ExpressionBox";
			this.ExpressionBox.Size = new System.Drawing.Size(287, 20);
			this.ExpressionBox.TabIndex = 10;
			this.ExpressionBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ExpressionBox.TextChanged += new System.EventHandler(this.ExpressionBox_TextChanged);
			// 
			// DicePanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ResultPanel);
			this.Controls.Add(this.DiceList);
			this.Controls.Add(this.DiceSourceList);
			this.Controls.Add(this.DiceToolbar);
			this.Name = "DicePanel";
			this.Size = new System.Drawing.Size(287, 305);
			this.DiceToolbar.ResumeLayout(false);
			this.DiceToolbar.PerformLayout();
			this.ResultPanel.ResumeLayout(false);
			this.ResultPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip DiceToolbar;
		private System.Windows.Forms.ToolStripButton RollBtn;
		private System.Windows.Forms.ToolStripButton ClearBtn;
		private System.Windows.Forms.Label DiceLbl;
		private System.Windows.Forms.ListView DiceList;
		private System.Windows.Forms.ListView DiceSourceList;
		private System.Windows.Forms.Panel ResultPanel;
		private System.Windows.Forms.ToolStripButton OddsBtn;
		private System.Windows.Forms.TextBox ExpressionBox;
	}
}
