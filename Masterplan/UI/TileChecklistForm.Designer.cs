namespace Masterplan.UI
{
	partial class TileChecklistForm
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
			this.OKBtn = new System.Windows.Forms.Button();
			this.TileList = new System.Windows.Forms.ListView();
			this.PlotTree = new System.Windows.Forms.TreeView();
			this.Splitter = new System.Windows.Forms.SplitContainer();
			this.Splitter.Panel1.SuspendLayout();
			this.Splitter.Panel2.SuspendLayout();
			this.Splitter.SuspendLayout();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(458, 376);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 0;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			// 
			// TileList
			// 
			this.TileList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TileList.FullRowSelect = true;
			this.TileList.HideSelection = false;
			this.TileList.Location = new System.Drawing.Point(0, 0);
			this.TileList.MultiSelect = false;
			this.TileList.Name = "TileList";
			this.TileList.Size = new System.Drawing.Size(521, 249);
			this.TileList.TabIndex = 1;
			this.TileList.UseCompatibleStateImageBehavior = false;
			// 
			// PlotTree
			// 
			this.PlotTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PlotTree.Location = new System.Drawing.Point(0, 0);
			this.PlotTree.Name = "PlotTree";
			this.PlotTree.Size = new System.Drawing.Size(521, 105);
			this.PlotTree.TabIndex = 2;
			this.PlotTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.PlotTree_AfterSelect);
			// 
			// Splitter
			// 
			this.Splitter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Splitter.Location = new System.Drawing.Point(12, 12);
			this.Splitter.Name = "Splitter";
			this.Splitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// Splitter.Panel1
			// 
			this.Splitter.Panel1.Controls.Add(this.PlotTree);
			// 
			// Splitter.Panel2
			// 
			this.Splitter.Panel2.Controls.Add(this.TileList);
			this.Splitter.Size = new System.Drawing.Size(521, 358);
			this.Splitter.SplitterDistance = 105;
			this.Splitter.TabIndex = 3;
			// 
			// TileChecklistForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(545, 411);
			this.Controls.Add(this.Splitter);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TileChecklistForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Map Tile Checklist";
			this.Splitter.Panel1.ResumeLayout(false);
			this.Splitter.Panel2.ResumeLayout(false);
			this.Splitter.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.ListView TileList;
		private System.Windows.Forms.TreeView PlotTree;
		private System.Windows.Forms.SplitContainer Splitter;
	}
}