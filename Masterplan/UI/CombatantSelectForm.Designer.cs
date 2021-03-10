namespace Masterplan.UI
{
	partial class CombatantSelectForm
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
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("PCs", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Creatures", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Traps", System.Windows.Forms.HorizontalAlignment.Left);
			this.OKBtn = new System.Windows.Forms.Button();
			this.CombatantList = new System.Windows.Forms.ListView();
			this.NameHdr = new System.Windows.Forms.ColumnHeader();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(166, 354);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 3;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			// 
			// CombatantList
			// 
			this.CombatantList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.CombatantList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameHdr});
			this.CombatantList.FullRowSelect = true;
			listViewGroup1.Header = "PCs";
			listViewGroup1.Name = "listViewGroup1";
			listViewGroup2.Header = "Creatures";
			listViewGroup2.Name = "listViewGroup2";
			listViewGroup3.Header = "Traps";
			listViewGroup3.Name = "listViewGroup3";
			this.CombatantList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
			this.CombatantList.HideSelection = false;
			this.CombatantList.Location = new System.Drawing.Point(12, 12);
			this.CombatantList.MultiSelect = false;
			this.CombatantList.Name = "CombatantList";
			this.CombatantList.Size = new System.Drawing.Size(310, 336);
			this.CombatantList.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.CombatantList.TabIndex = 0;
			this.CombatantList.UseCompatibleStateImageBehavior = false;
			this.CombatantList.View = System.Windows.Forms.View.Details;
			this.CombatantList.DoubleClick += new System.EventHandler(this.TileList_DoubleClick);
			// 
			// NameHdr
			// 
			this.NameHdr.Text = "Name";
			this.NameHdr.Width = 270;
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(247, 354);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 4;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// CombatantSelectForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(334, 389);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.CombatantList);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CombatantSelectForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select Combatant";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.ListView CombatantList;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.ColumnHeader NameHdr;
	}
}