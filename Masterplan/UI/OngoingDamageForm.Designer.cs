namespace Masterplan.UI
{
	partial class OngoingDamageForm
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
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Ongoing Damage", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Total Damage", System.Windows.Forms.HorizontalAlignment.Left);
			this.CancelBtn = new System.Windows.Forms.Button();
			this.OKBtn = new System.Windows.Forms.Button();
			this.ListPanel = new System.Windows.Forms.Panel();
			this.DamageList = new System.Windows.Forms.ListView();
			this.DamageHdr = new System.Windows.Forms.ColumnHeader();
			this.ValueHdr = new System.Windows.Forms.ColumnHeader();
			this.TakenHdr = new System.Windows.Forms.ColumnHeader();
			this.InfoLbl = new System.Windows.Forms.Label();
			this.ListPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(361, 242);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 3;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(280, 242);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 2;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// ListPanel
			// 
			this.ListPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ListPanel.Controls.Add(this.DamageList);
			this.ListPanel.Location = new System.Drawing.Point(12, 38);
			this.ListPanel.Name = "ListPanel";
			this.ListPanel.Size = new System.Drawing.Size(424, 198);
			this.ListPanel.TabIndex = 9;
			// 
			// DamageList
			// 
			this.DamageList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DamageHdr,
            this.ValueHdr,
            this.TakenHdr});
			this.DamageList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DamageList.FullRowSelect = true;
			listViewGroup1.Header = "Ongoing Damage";
			listViewGroup1.Name = "DamageGrp";
			listViewGroup2.Header = "Total Damage";
			listViewGroup2.Name = "TotalGrp";
			this.DamageList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
			this.DamageList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.DamageList.HideSelection = false;
			this.DamageList.Location = new System.Drawing.Point(0, 0);
			this.DamageList.MultiSelect = false;
			this.DamageList.Name = "DamageList";
			this.DamageList.Size = new System.Drawing.Size(424, 198);
			this.DamageList.TabIndex = 1;
			this.DamageList.UseCompatibleStateImageBehavior = false;
			this.DamageList.View = System.Windows.Forms.View.Details;
			// 
			// DamageHdr
			// 
			this.DamageHdr.Text = "Damage";
			this.DamageHdr.Width = 229;
			// 
			// ValueHdr
			// 
			this.ValueHdr.Text = "Modifier";
			this.ValueHdr.Width = 100;
			// 
			// TakenHdr
			// 
			this.TakenHdr.Text = "Taken";
			this.TakenHdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// InfoLbl
			// 
			this.InfoLbl.AutoSize = true;
			this.InfoLbl.Location = new System.Drawing.Point(12, 9);
			this.InfoLbl.Name = "InfoLbl";
			this.InfoLbl.Size = new System.Drawing.Size(319, 13);
			this.InfoLbl.TabIndex = 10;
			this.InfoLbl.Text = "The following ongoing damage will be applied when you press OK.";
			// 
			// OngoingDamageForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(448, 277);
			this.Controls.Add(this.InfoLbl);
			this.Controls.Add(this.ListPanel);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OngoingDamageForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Ongoing Damage";
			this.ListPanel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Panel ListPanel;
		private System.Windows.Forms.ListView DamageList;
		private System.Windows.Forms.ColumnHeader DamageHdr;
		private System.Windows.Forms.ColumnHeader ValueHdr;
		private System.Windows.Forms.ColumnHeader TakenHdr;
		private System.Windows.Forms.Label InfoLbl;
	}
}