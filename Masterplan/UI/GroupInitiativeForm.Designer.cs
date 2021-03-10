namespace Masterplan.UI
{
	partial class GroupInitiativeForm
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
			this.CloseBtn = new System.Windows.Forms.Button();
			this.InfoLbl = new System.Windows.Forms.Label();
			this.CombatantList = new System.Windows.Forms.ListView();
			this.CombatantHdr = new System.Windows.Forms.ColumnHeader();
			this.InitHdr = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// CloseBtn
			// 
			this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.CloseBtn.Location = new System.Drawing.Point(292, 301);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.Size = new System.Drawing.Size(75, 23);
			this.CloseBtn.TabIndex = 2;
			this.CloseBtn.Text = "OK";
			this.CloseBtn.UseVisualStyleBackColor = true;
			// 
			// InfoLbl
			// 
			this.InfoLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.InfoLbl.Location = new System.Drawing.Point(12, 9);
			this.InfoLbl.Name = "InfoLbl";
			this.InfoLbl.Size = new System.Drawing.Size(355, 22);
			this.InfoLbl.TabIndex = 0;
			this.InfoLbl.Text = "Double-click on a combatant in the list to set its initiative score.";
			// 
			// CombatantList
			// 
			this.CombatantList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.CombatantList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CombatantHdr,
            this.InitHdr});
			this.CombatantList.FullRowSelect = true;
			this.CombatantList.HideSelection = false;
			this.CombatantList.Location = new System.Drawing.Point(12, 34);
			this.CombatantList.MultiSelect = false;
			this.CombatantList.Name = "CombatantList";
			this.CombatantList.Size = new System.Drawing.Size(355, 261);
			this.CombatantList.TabIndex = 1;
			this.CombatantList.UseCompatibleStateImageBehavior = false;
			this.CombatantList.View = System.Windows.Forms.View.Details;
			this.CombatantList.DoubleClick += new System.EventHandler(this.CombatantList_DoubleClick);
			// 
			// CombatantHdr
			// 
			this.CombatantHdr.Text = "Combatant";
			this.CombatantHdr.Width = 234;
			// 
			// InitHdr
			// 
			this.InitHdr.Text = "Initiative";
			this.InitHdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InitHdr.Width = 68;
			// 
			// GroupInitiativeForm
			// 
			this.AcceptButton = this.CloseBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(379, 336);
			this.Controls.Add(this.CombatantList);
			this.Controls.Add(this.InfoLbl);
			this.Controls.Add(this.CloseBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GroupInitiativeForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Set Initiative Scores";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button CloseBtn;
		private System.Windows.Forms.Label InfoLbl;
		private System.Windows.Forms.ListView CombatantList;
		private System.Windows.Forms.ColumnHeader CombatantHdr;
		private System.Windows.Forms.ColumnHeader InitHdr;
	}
}