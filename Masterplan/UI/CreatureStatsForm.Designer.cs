namespace Masterplan.UI
{
	partial class CreatureStatsForm
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
			this.CancelBtn = new System.Windows.Forms.Button();
			this.InitLbl = new System.Windows.Forms.Label();
			this.FortLbl = new System.Windows.Forms.Label();
			this.FortBox = new System.Windows.Forms.NumericUpDown();
			this.InitBox = new System.Windows.Forms.NumericUpDown();
			this.WillBox = new System.Windows.Forms.NumericUpDown();
			this.HPLbl = new System.Windows.Forms.Label();
			this.ACBox = new System.Windows.Forms.NumericUpDown();
			this.WillLbl = new System.Windows.Forms.Label();
			this.RefLbl = new System.Windows.Forms.Label();
			this.HPBox = new System.Windows.Forms.NumericUpDown();
			this.ACLbl = new System.Windows.Forms.Label();
			this.RefBox = new System.Windows.Forms.NumericUpDown();
			this.InitGroup = new System.Windows.Forms.GroupBox();
			this.InitRecBtn = new System.Windows.Forms.Button();
			this.HPGroup = new System.Windows.Forms.GroupBox();
			this.HPRecBtn = new System.Windows.Forms.Button();
			this.DefGroup = new System.Windows.Forms.GroupBox();
			this.WillRecBtn = new System.Windows.Forms.Button();
			this.RefRecBtn = new System.Windows.Forms.Button();
			this.FortRecBtn = new System.Windows.Forms.Button();
			this.ACRecBtn = new System.Windows.Forms.Button();
			this.DefaultBtn = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.FortBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.InitBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.WillBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ACBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.HPBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RefBox)).BeginInit();
			this.InitGroup.SuspendLayout();
			this.HPGroup.SuspendLayout();
			this.DefGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(193, 261);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 3;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(274, 261);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 4;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// InitLbl
			// 
			this.InitLbl.AutoSize = true;
			this.InitLbl.Location = new System.Drawing.Point(6, 21);
			this.InitLbl.Name = "InitLbl";
			this.InitLbl.Size = new System.Drawing.Size(49, 13);
			this.InitLbl.TabIndex = 0;
			this.InitLbl.Text = "Initiative:";
			// 
			// FortLbl
			// 
			this.FortLbl.AutoSize = true;
			this.FortLbl.Location = new System.Drawing.Point(6, 48);
			this.FortLbl.Name = "FortLbl";
			this.FortLbl.Size = new System.Drawing.Size(51, 13);
			this.FortLbl.TabIndex = 3;
			this.FortLbl.Text = "Fortitude:";
			// 
			// FortBox
			// 
			this.FortBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.FortBox.Location = new System.Drawing.Point(67, 45);
			this.FortBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.FortBox.Name = "FortBox";
			this.FortBox.Size = new System.Drawing.Size(141, 20);
			this.FortBox.TabIndex = 4;
			// 
			// InitBox
			// 
			this.InitBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.InitBox.Location = new System.Drawing.Point(67, 19);
			this.InitBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.InitBox.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
			this.InitBox.Name = "InitBox";
			this.InitBox.Size = new System.Drawing.Size(141, 20);
			this.InitBox.TabIndex = 1;
			// 
			// WillBox
			// 
			this.WillBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.WillBox.Location = new System.Drawing.Point(67, 97);
			this.WillBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.WillBox.Name = "WillBox";
			this.WillBox.Size = new System.Drawing.Size(141, 20);
			this.WillBox.TabIndex = 10;
			// 
			// HPLbl
			// 
			this.HPLbl.AutoSize = true;
			this.HPLbl.Location = new System.Drawing.Point(6, 21);
			this.HPLbl.Name = "HPLbl";
			this.HPLbl.Size = new System.Drawing.Size(25, 13);
			this.HPLbl.TabIndex = 0;
			this.HPLbl.Text = "HP:";
			// 
			// ACBox
			// 
			this.ACBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ACBox.Location = new System.Drawing.Point(67, 19);
			this.ACBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.ACBox.Name = "ACBox";
			this.ACBox.Size = new System.Drawing.Size(141, 20);
			this.ACBox.TabIndex = 1;
			// 
			// WillLbl
			// 
			this.WillLbl.AutoSize = true;
			this.WillLbl.Location = new System.Drawing.Point(6, 99);
			this.WillLbl.Name = "WillLbl";
			this.WillLbl.Size = new System.Drawing.Size(27, 13);
			this.WillLbl.TabIndex = 9;
			this.WillLbl.Text = "Will:";
			// 
			// RefLbl
			// 
			this.RefLbl.AutoSize = true;
			this.RefLbl.Location = new System.Drawing.Point(6, 74);
			this.RefLbl.Name = "RefLbl";
			this.RefLbl.Size = new System.Drawing.Size(40, 13);
			this.RefLbl.TabIndex = 6;
			this.RefLbl.Text = "Reflex:";
			// 
			// HPBox
			// 
			this.HPBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.HPBox.Location = new System.Drawing.Point(67, 19);
			this.HPBox.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.HPBox.Name = "HPBox";
			this.HPBox.Size = new System.Drawing.Size(141, 20);
			this.HPBox.TabIndex = 1;
			// 
			// ACLbl
			// 
			this.ACLbl.AutoSize = true;
			this.ACLbl.Location = new System.Drawing.Point(7, 22);
			this.ACLbl.Name = "ACLbl";
			this.ACLbl.Size = new System.Drawing.Size(24, 13);
			this.ACLbl.TabIndex = 0;
			this.ACLbl.Text = "AC:";
			// 
			// RefBox
			// 
			this.RefBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.RefBox.Location = new System.Drawing.Point(67, 71);
			this.RefBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.RefBox.Name = "RefBox";
			this.RefBox.Size = new System.Drawing.Size(141, 20);
			this.RefBox.TabIndex = 7;
			// 
			// InitGroup
			// 
			this.InitGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.InitGroup.Controls.Add(this.InitRecBtn);
			this.InitGroup.Controls.Add(this.InitBox);
			this.InitGroup.Controls.Add(this.InitLbl);
			this.InitGroup.Location = new System.Drawing.Point(12, 68);
			this.InitGroup.Name = "InitGroup";
			this.InitGroup.Size = new System.Drawing.Size(337, 50);
			this.InitGroup.TabIndex = 1;
			this.InitGroup.TabStop = false;
			this.InitGroup.Text = "Initiative";
			// 
			// InitRecBtn
			// 
			this.InitRecBtn.Location = new System.Drawing.Point(214, 16);
			this.InitRecBtn.Name = "InitRecBtn";
			this.InitRecBtn.Size = new System.Drawing.Size(117, 23);
			this.InitRecBtn.TabIndex = 2;
			this.InitRecBtn.Text = "(init)";
			this.InitRecBtn.UseVisualStyleBackColor = true;
			this.InitRecBtn.Click += new System.EventHandler(this.InitRecBtn_Click);
			// 
			// HPGroup
			// 
			this.HPGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.HPGroup.Controls.Add(this.HPRecBtn);
			this.HPGroup.Controls.Add(this.HPBox);
			this.HPGroup.Controls.Add(this.HPLbl);
			this.HPGroup.Location = new System.Drawing.Point(12, 12);
			this.HPGroup.Name = "HPGroup";
			this.HPGroup.Size = new System.Drawing.Size(337, 50);
			this.HPGroup.TabIndex = 0;
			this.HPGroup.TabStop = false;
			this.HPGroup.Text = "Hit Points";
			// 
			// HPRecBtn
			// 
			this.HPRecBtn.Location = new System.Drawing.Point(214, 16);
			this.HPRecBtn.Name = "HPRecBtn";
			this.HPRecBtn.Size = new System.Drawing.Size(117, 23);
			this.HPRecBtn.TabIndex = 2;
			this.HPRecBtn.Text = "(hp)";
			this.HPRecBtn.UseVisualStyleBackColor = true;
			this.HPRecBtn.Click += new System.EventHandler(this.HPRecBtn_Click);
			// 
			// DefGroup
			// 
			this.DefGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DefGroup.Controls.Add(this.WillRecBtn);
			this.DefGroup.Controls.Add(this.RefRecBtn);
			this.DefGroup.Controls.Add(this.FortRecBtn);
			this.DefGroup.Controls.Add(this.ACRecBtn);
			this.DefGroup.Controls.Add(this.ACBox);
			this.DefGroup.Controls.Add(this.RefLbl);
			this.DefGroup.Controls.Add(this.RefBox);
			this.DefGroup.Controls.Add(this.WillLbl);
			this.DefGroup.Controls.Add(this.WillBox);
			this.DefGroup.Controls.Add(this.ACLbl);
			this.DefGroup.Controls.Add(this.FortBox);
			this.DefGroup.Controls.Add(this.FortLbl);
			this.DefGroup.Location = new System.Drawing.Point(12, 124);
			this.DefGroup.Name = "DefGroup";
			this.DefGroup.Size = new System.Drawing.Size(337, 131);
			this.DefGroup.TabIndex = 2;
			this.DefGroup.TabStop = false;
			this.DefGroup.Text = "Defences";
			// 
			// WillRecBtn
			// 
			this.WillRecBtn.Location = new System.Drawing.Point(214, 94);
			this.WillRecBtn.Name = "WillRecBtn";
			this.WillRecBtn.Size = new System.Drawing.Size(117, 23);
			this.WillRecBtn.TabIndex = 11;
			this.WillRecBtn.Text = "(will)";
			this.WillRecBtn.UseVisualStyleBackColor = true;
			this.WillRecBtn.Click += new System.EventHandler(this.WillRecBtn_Click);
			// 
			// RefRecBtn
			// 
			this.RefRecBtn.Location = new System.Drawing.Point(214, 69);
			this.RefRecBtn.Name = "RefRecBtn";
			this.RefRecBtn.Size = new System.Drawing.Size(117, 23);
			this.RefRecBtn.TabIndex = 8;
			this.RefRecBtn.Text = "(ref)";
			this.RefRecBtn.UseVisualStyleBackColor = true;
			this.RefRecBtn.Click += new System.EventHandler(this.RefRecBtn_Click);
			// 
			// FortRecBtn
			// 
			this.FortRecBtn.Location = new System.Drawing.Point(214, 42);
			this.FortRecBtn.Name = "FortRecBtn";
			this.FortRecBtn.Size = new System.Drawing.Size(117, 23);
			this.FortRecBtn.TabIndex = 5;
			this.FortRecBtn.Text = "(fort)";
			this.FortRecBtn.UseVisualStyleBackColor = true;
			this.FortRecBtn.Click += new System.EventHandler(this.FortRecBtn_Click);
			// 
			// ACRecBtn
			// 
			this.ACRecBtn.Location = new System.Drawing.Point(214, 16);
			this.ACRecBtn.Name = "ACRecBtn";
			this.ACRecBtn.Size = new System.Drawing.Size(117, 23);
			this.ACRecBtn.TabIndex = 2;
			this.ACRecBtn.Text = "(ac)";
			this.ACRecBtn.UseVisualStyleBackColor = true;
			this.ACRecBtn.Click += new System.EventHandler(this.ACRecBtn_Click);
			// 
			// DefaultBtn
			// 
			this.DefaultBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.DefaultBtn.Location = new System.Drawing.Point(12, 261);
			this.DefaultBtn.Name = "DefaultBtn";
			this.DefaultBtn.Size = new System.Drawing.Size(142, 23);
			this.DefaultBtn.TabIndex = 5;
			this.DefaultBtn.Text = "Set to Recommendations";
			this.DefaultBtn.UseVisualStyleBackColor = true;
			this.DefaultBtn.Click += new System.EventHandler(this.DefaultBtn_Click);
			// 
			// CreatureStatsForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(361, 296);
			this.Controls.Add(this.DefaultBtn);
			this.Controls.Add(this.DefGroup);
			this.Controls.Add(this.HPGroup);
			this.Controls.Add(this.InitGroup);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CreatureStatsForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Combat Statistics";
			((System.ComponentModel.ISupportInitialize)(this.FortBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.InitBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.WillBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ACBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.HPBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RefBox)).EndInit();
			this.InitGroup.ResumeLayout(false);
			this.InitGroup.PerformLayout();
			this.HPGroup.ResumeLayout(false);
			this.HPGroup.PerformLayout();
			this.DefGroup.ResumeLayout(false);
			this.DefGroup.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label InitLbl;
		private System.Windows.Forms.Label FortLbl;
		private System.Windows.Forms.NumericUpDown FortBox;
		private System.Windows.Forms.NumericUpDown InitBox;
		private System.Windows.Forms.NumericUpDown WillBox;
		private System.Windows.Forms.Label HPLbl;
		private System.Windows.Forms.NumericUpDown ACBox;
		private System.Windows.Forms.Label WillLbl;
		private System.Windows.Forms.Label RefLbl;
		private System.Windows.Forms.NumericUpDown HPBox;
		private System.Windows.Forms.Label ACLbl;
		private System.Windows.Forms.NumericUpDown RefBox;
		private System.Windows.Forms.GroupBox InitGroup;
		private System.Windows.Forms.GroupBox HPGroup;
		private System.Windows.Forms.GroupBox DefGroup;
		private System.Windows.Forms.Button DefaultBtn;
		private System.Windows.Forms.Button InitRecBtn;
		private System.Windows.Forms.Button HPRecBtn;
		private System.Windows.Forms.Button WillRecBtn;
		private System.Windows.Forms.Button RefRecBtn;
		private System.Windows.Forms.Button FortRecBtn;
		private System.Windows.Forms.Button ACRecBtn;
	}
}