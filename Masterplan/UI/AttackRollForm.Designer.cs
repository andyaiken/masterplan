namespace Masterplan.UI
{
	partial class AttackRollForm
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
			this.PowerBrowser = new System.Windows.Forms.WebBrowser();
			this.RollList = new System.Windows.Forms.ListView();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.Pages = new System.Windows.Forms.TabControl();
			this.AttackPage = new System.Windows.Forms.TabPage();
			this.DamagePage = new System.Windows.Forms.TabPage();
			this.RollDamageBtn = new System.Windows.Forms.Button();
			this.MissValueLbl = new System.Windows.Forms.Label();
			this.CritValueLbl = new System.Windows.Forms.Label();
			this.MissLbl = new System.Windows.Forms.Label();
			this.CritLbl = new System.Windows.Forms.Label();
			this.DamageBox = new System.Windows.Forms.NumericUpDown();
			this.HitLbl = new System.Windows.Forms.Label();
			this.DamageExpLbl = new System.Windows.Forms.Label();
			this.DamageInfoLbl = new System.Windows.Forms.Label();
			this.Splitter = new System.Windows.Forms.SplitContainer();
			this.ApplyDamageBox = new System.Windows.Forms.CheckBox();
			this.Pages.SuspendLayout();
			this.AttackPage.SuspendLayout();
			this.DamagePage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DamageBox)).BeginInit();
			this.Splitter.Panel1.SuspendLayout();
			this.Splitter.Panel2.SuspendLayout();
			this.Splitter.SuspendLayout();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(280, 345);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 2;
			this.OKBtn.Text = "Close";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// PowerBrowser
			// 
			this.PowerBrowser.AllowWebBrowserDrop = false;
			this.PowerBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PowerBrowser.IsWebBrowserContextMenuEnabled = false;
			this.PowerBrowser.Location = new System.Drawing.Point(0, 0);
			this.PowerBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.PowerBrowser.Name = "PowerBrowser";
			this.PowerBrowser.ScriptErrorsSuppressed = true;
			this.PowerBrowser.Size = new System.Drawing.Size(343, 163);
			this.PowerBrowser.TabIndex = 0;
			this.PowerBrowser.WebBrowserShortcutsEnabled = false;
			this.PowerBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.PowerBrowser_Navigating);
			// 
			// RollList
			// 
			this.RollList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.RollList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RollList.FullRowSelect = true;
			this.RollList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.RollList.HideSelection = false;
			this.RollList.Location = new System.Drawing.Point(3, 3);
			this.RollList.Name = "RollList";
			this.RollList.Size = new System.Drawing.Size(329, 128);
			this.RollList.TabIndex = 0;
			this.RollList.UseCompatibleStateImageBehavior = false;
			this.RollList.View = System.Windows.Forms.View.Details;
			this.RollList.DoubleClick += new System.EventHandler(this.RollList_DoubleClick);
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Target";
			this.columnHeader4.Width = 120;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Roll";
			this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Bonus";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Total";
			this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// Pages
			// 
			this.Pages.Controls.Add(this.AttackPage);
			this.Pages.Controls.Add(this.DamagePage);
			this.Pages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Pages.Location = new System.Drawing.Point(0, 0);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(343, 160);
			this.Pages.TabIndex = 0;
			// 
			// AttackPage
			// 
			this.AttackPage.Controls.Add(this.RollList);
			this.AttackPage.Location = new System.Drawing.Point(4, 22);
			this.AttackPage.Name = "AttackPage";
			this.AttackPage.Padding = new System.Windows.Forms.Padding(3);
			this.AttackPage.Size = new System.Drawing.Size(335, 134);
			this.AttackPage.TabIndex = 0;
			this.AttackPage.Text = "Attack Rolls";
			this.AttackPage.UseVisualStyleBackColor = true;
			// 
			// DamagePage
			// 
			this.DamagePage.Controls.Add(this.RollDamageBtn);
			this.DamagePage.Controls.Add(this.MissValueLbl);
			this.DamagePage.Controls.Add(this.CritValueLbl);
			this.DamagePage.Controls.Add(this.MissLbl);
			this.DamagePage.Controls.Add(this.CritLbl);
			this.DamagePage.Controls.Add(this.DamageBox);
			this.DamagePage.Controls.Add(this.HitLbl);
			this.DamagePage.Controls.Add(this.DamageExpLbl);
			this.DamagePage.Controls.Add(this.DamageInfoLbl);
			this.DamagePage.Location = new System.Drawing.Point(4, 22);
			this.DamagePage.Name = "DamagePage";
			this.DamagePage.Padding = new System.Windows.Forms.Padding(3);
			this.DamagePage.Size = new System.Drawing.Size(335, 134);
			this.DamagePage.TabIndex = 1;
			this.DamagePage.Text = "Damage Rolls";
			this.DamagePage.UseVisualStyleBackColor = true;
			// 
			// RollDamageBtn
			// 
			this.RollDamageBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.RollDamageBtn.Location = new System.Drawing.Point(254, 33);
			this.RollDamageBtn.Name = "RollDamageBtn";
			this.RollDamageBtn.Size = new System.Drawing.Size(75, 23);
			this.RollDamageBtn.TabIndex = 9;
			this.RollDamageBtn.Text = "Reroll";
			this.RollDamageBtn.UseVisualStyleBackColor = true;
			this.RollDamageBtn.Click += new System.EventHandler(this.RollDamageBtn_Click);
			// 
			// MissValueLbl
			// 
			this.MissValueLbl.AutoSize = true;
			this.MissValueLbl.Location = new System.Drawing.Point(135, 90);
			this.MissValueLbl.Name = "MissValueLbl";
			this.MissValueLbl.Size = new System.Drawing.Size(33, 13);
			this.MissValueLbl.TabIndex = 8;
			this.MissValueLbl.Text = "[miss]";
			// 
			// CritValueLbl
			// 
			this.CritValueLbl.AutoSize = true;
			this.CritValueLbl.Location = new System.Drawing.Point(135, 64);
			this.CritValueLbl.Name = "CritValueLbl";
			this.CritValueLbl.Size = new System.Drawing.Size(27, 13);
			this.CritValueLbl.TabIndex = 7;
			this.CritValueLbl.Text = "[crit]";
			// 
			// MissLbl
			// 
			this.MissLbl.AutoSize = true;
			this.MissLbl.Location = new System.Drawing.Point(6, 90);
			this.MissLbl.Name = "MissLbl";
			this.MissLbl.Size = new System.Drawing.Size(74, 13);
			this.MissLbl.TabIndex = 6;
			this.MissLbl.Text = "On Miss (half):";
			// 
			// CritLbl
			// 
			this.CritLbl.AutoSize = true;
			this.CritLbl.Location = new System.Drawing.Point(6, 64);
			this.CritLbl.Name = "CritLbl";
			this.CritLbl.Size = new System.Drawing.Size(86, 13);
			this.CritLbl.TabIndex = 4;
			this.CritLbl.Text = "On Critical (max):";
			// 
			// DamageBox
			// 
			this.DamageBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DamageBox.Location = new System.Drawing.Point(138, 36);
			this.DamageBox.Name = "DamageBox";
			this.DamageBox.Size = new System.Drawing.Size(110, 20);
			this.DamageBox.TabIndex = 3;
			this.DamageBox.ValueChanged += new System.EventHandler(this.DamageBox_ValueChanged);
			// 
			// HitLbl
			// 
			this.HitLbl.AutoSize = true;
			this.HitLbl.Location = new System.Drawing.Point(6, 38);
			this.HitLbl.Name = "HitLbl";
			this.HitLbl.Size = new System.Drawing.Size(40, 13);
			this.HitLbl.TabIndex = 2;
			this.HitLbl.Text = "On Hit:";
			// 
			// DamageExpLbl
			// 
			this.DamageExpLbl.AutoSize = true;
			this.DamageExpLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DamageExpLbl.Location = new System.Drawing.Point(135, 13);
			this.DamageExpLbl.Name = "DamageExpLbl";
			this.DamageExpLbl.Size = new System.Drawing.Size(38, 13);
			this.DamageExpLbl.TabIndex = 1;
			this.DamageExpLbl.Text = "[dmg]";
			// 
			// DamageInfoLbl
			// 
			this.DamageInfoLbl.AutoSize = true;
			this.DamageInfoLbl.Location = new System.Drawing.Point(6, 13);
			this.DamageInfoLbl.Name = "DamageInfoLbl";
			this.DamageInfoLbl.Size = new System.Drawing.Size(50, 13);
			this.DamageInfoLbl.TabIndex = 0;
			this.DamageInfoLbl.Text = "Damage:";
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
			this.Splitter.Panel1.Controls.Add(this.PowerBrowser);
			// 
			// Splitter.Panel2
			// 
			this.Splitter.Panel2.Controls.Add(this.Pages);
			this.Splitter.Size = new System.Drawing.Size(343, 327);
			this.Splitter.SplitterDistance = 163;
			this.Splitter.TabIndex = 0;
			// 
			// ApplyDamageBox
			// 
			this.ApplyDamageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ApplyDamageBox.AutoSize = true;
			this.ApplyDamageBox.Location = new System.Drawing.Point(12, 349);
			this.ApplyDamageBox.Name = "ApplyDamageBox";
			this.ApplyDamageBox.Size = new System.Drawing.Size(136, 17);
			this.ApplyDamageBox.TabIndex = 1;
			this.ApplyDamageBox.Text = "Apply damage on close";
			this.ApplyDamageBox.UseVisualStyleBackColor = true;
			// 
			// AttackRollForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(367, 380);
			this.Controls.Add(this.ApplyDamageBox);
			this.Controls.Add(this.Splitter);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AttackRollForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Attack Roll";
			this.Pages.ResumeLayout(false);
			this.AttackPage.ResumeLayout(false);
			this.DamagePage.ResumeLayout(false);
			this.DamagePage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DamageBox)).EndInit();
			this.Splitter.Panel1.ResumeLayout(false);
			this.Splitter.Panel2.ResumeLayout(false);
			this.Splitter.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.WebBrowser PowerBrowser;
		private System.Windows.Forms.ListView RollList;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.TabPage AttackPage;
		private System.Windows.Forms.TabPage DamagePage;
		private System.Windows.Forms.Label MissLbl;
		private System.Windows.Forms.Label CritLbl;
		private System.Windows.Forms.NumericUpDown DamageBox;
		private System.Windows.Forms.Label HitLbl;
		private System.Windows.Forms.Label DamageExpLbl;
		private System.Windows.Forms.Label DamageInfoLbl;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Label MissValueLbl;
		private System.Windows.Forms.Label CritValueLbl;
		private System.Windows.Forms.Button RollDamageBtn;
		private System.Windows.Forms.SplitContainer Splitter;
		private System.Windows.Forms.CheckBox ApplyDamageBox;
	}
}