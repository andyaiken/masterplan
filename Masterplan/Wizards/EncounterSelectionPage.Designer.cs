namespace Masterplan.Wizards
{
	partial class EncounterSelectionPage
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
			this.InfoLbl = new System.Windows.Forms.Label();
			this.SlotList = new System.Windows.Forms.ListView();
			this.SlotHdr = new System.Windows.Forms.ColumnHeader();
			this.CardHdr = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// InfoLbl
			// 
			this.InfoLbl.Dock = System.Windows.Forms.DockStyle.Top;
			this.InfoLbl.Location = new System.Drawing.Point(0, 0);
			this.InfoLbl.Name = "InfoLbl";
			this.InfoLbl.Size = new System.Drawing.Size(372, 40);
			this.InfoLbl.TabIndex = 1;
			this.InfoLbl.Text = "Double-click on each of the empty slots in the list below to select creatures to " +
				"fill them.";
			// 
			// SlotList
			// 
			this.SlotList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SlotHdr,
            this.CardHdr});
			this.SlotList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SlotList.FullRowSelect = true;
			this.SlotList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.SlotList.HideSelection = false;
			this.SlotList.Location = new System.Drawing.Point(0, 40);
			this.SlotList.Name = "SlotList";
			this.SlotList.Size = new System.Drawing.Size(372, 206);
			this.SlotList.TabIndex = 2;
			this.SlotList.UseCompatibleStateImageBehavior = false;
			this.SlotList.View = System.Windows.Forms.View.Details;
			this.SlotList.DoubleClick += new System.EventHandler(this.SlotList_DoubleClick);
			// 
			// SlotHdr
			// 
			this.SlotHdr.Text = "Slot";
			this.SlotHdr.Width = 160;
			// 
			// CardHdr
			// 
			this.CardHdr.Text = "Selected Creature";
			this.CardHdr.Width = 160;
			// 
			// EncounterSelectionPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.SlotList);
			this.Controls.Add(this.InfoLbl);
			this.Name = "EncounterSelectionPage";
			this.Size = new System.Drawing.Size(372, 246);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label InfoLbl;
		private System.Windows.Forms.ListView SlotList;
		private System.Windows.Forms.ColumnHeader SlotHdr;
		private System.Windows.Forms.ColumnHeader CardHdr;
	}
}
