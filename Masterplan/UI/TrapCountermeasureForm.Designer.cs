namespace Masterplan.UI
{
	partial class TrapCountermeasureForm
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
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Skill DCs", System.Windows.Forms.HorizontalAlignment.Left);
			this.CancelBtn = new System.Windows.Forms.Button();
			this.OKBtn = new System.Windows.Forms.Button();
			this.Pages = new System.Windows.Forms.TabControl();
			this.DetailsPage = new System.Windows.Forms.TabPage();
			this.DetailsBox = new Utils.Controls.DefaultTextBox();
			this.AdvicePage = new System.Windows.Forms.TabPage();
			this.AdviceList = new System.Windows.Forms.ListView();
			this.AdviceHdr = new System.Windows.Forms.ColumnHeader();
			this.InfoHdr = new System.Windows.Forms.ColumnHeader();
			this.Pages.SuspendLayout();
			this.DetailsPage.SuspendLayout();
			this.AdvicePage.SuspendLayout();
			this.SuspendLayout();
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(306, 201);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 4;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(225, 201);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 3;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			// 
			// Pages
			// 
			this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Pages.Controls.Add(this.DetailsPage);
			this.Pages.Controls.Add(this.AdvicePage);
			this.Pages.Location = new System.Drawing.Point(12, 12);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(369, 183);
			this.Pages.TabIndex = 2;
			// 
			// DetailsPage
			// 
			this.DetailsPage.Controls.Add(this.DetailsBox);
			this.DetailsPage.Location = new System.Drawing.Point(4, 22);
			this.DetailsPage.Name = "DetailsPage";
			this.DetailsPage.Padding = new System.Windows.Forms.Padding(3);
			this.DetailsPage.Size = new System.Drawing.Size(361, 157);
			this.DetailsPage.TabIndex = 0;
			this.DetailsPage.Text = "Details";
			this.DetailsPage.UseVisualStyleBackColor = true;
			// 
			// DetailsBox
			// 
			this.DetailsBox.AcceptsReturn = true;
			this.DetailsBox.AcceptsTab = true;
			this.DetailsBox.DefaultText = "(enter countermeasure details)";
			this.DetailsBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DetailsBox.Location = new System.Drawing.Point(3, 3);
			this.DetailsBox.Multiline = true;
			this.DetailsBox.Name = "DetailsBox";
			this.DetailsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.DetailsBox.Size = new System.Drawing.Size(355, 151);
			this.DetailsBox.TabIndex = 0;
			this.DetailsBox.Text = "(enter countermeasure details)";
			// 
			// AdvicePage
			// 
			this.AdvicePage.Controls.Add(this.AdviceList);
			this.AdvicePage.Location = new System.Drawing.Point(4, 22);
			this.AdvicePage.Name = "AdvicePage";
			this.AdvicePage.Padding = new System.Windows.Forms.Padding(3);
			this.AdvicePage.Size = new System.Drawing.Size(361, 157);
			this.AdvicePage.TabIndex = 1;
			this.AdvicePage.Text = "Advice";
			this.AdvicePage.UseVisualStyleBackColor = true;
			// 
			// AdviceList
			// 
			this.AdviceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AdviceHdr,
            this.InfoHdr});
			this.AdviceList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AdviceList.FullRowSelect = true;
			listViewGroup1.Header = "Skill DCs";
			listViewGroup1.Name = "listViewGroup1";
			this.AdviceList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
			this.AdviceList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.AdviceList.HideSelection = false;
			this.AdviceList.Location = new System.Drawing.Point(3, 3);
			this.AdviceList.MultiSelect = false;
			this.AdviceList.Name = "AdviceList";
			this.AdviceList.Size = new System.Drawing.Size(355, 151);
			this.AdviceList.TabIndex = 2;
			this.AdviceList.UseCompatibleStateImageBehavior = false;
			this.AdviceList.View = System.Windows.Forms.View.Details;
			// 
			// AdviceHdr
			// 
			this.AdviceHdr.Text = "Advice";
			this.AdviceHdr.Width = 150;
			// 
			// InfoHdr
			// 
			this.InfoHdr.Text = "Information";
			this.InfoHdr.Width = 100;
			// 
			// TrapCountermeasureForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(393, 236);
			this.Controls.Add(this.Pages);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TrapCountermeasureForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Countermeasure";
			this.Shown += new System.EventHandler(this.TrapCountermeasureForm_Shown);
			this.Pages.ResumeLayout(false);
			this.DetailsPage.ResumeLayout(false);
			this.DetailsPage.PerformLayout();
			this.AdvicePage.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.TabPage DetailsPage;
		private Utils.Controls.DefaultTextBox DetailsBox;
		private System.Windows.Forms.TabPage AdvicePage;
		private System.Windows.Forms.ListView AdviceList;
		private System.Windows.Forms.ColumnHeader AdviceHdr;
		private System.Windows.Forms.ColumnHeader InfoHdr;
	}
}