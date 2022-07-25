namespace Masterplan.UI
{
	partial class HealForm
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
			this.HPLbl = new System.Windows.Forms.Label();
			this.HPBox = new System.Windows.Forms.NumericUpDown();
			this.TempHPBox = new System.Windows.Forms.CheckBox();
			this.SurgeLbl = new System.Windows.Forms.Label();
			this.SurgeBox = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.HPBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SurgeBox)).BeginInit();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(116, 110);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 5;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(197, 110);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 6;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// HPLbl
			// 
			this.HPLbl.AutoSize = true;
			this.HPLbl.Location = new System.Drawing.Point(12, 40);
			this.HPLbl.Name = "HPLbl";
			this.HPLbl.Size = new System.Drawing.Size(25, 13);
			this.HPLbl.TabIndex = 2;
			this.HPLbl.Text = "HP:";
			// 
			// HPBox
			// 
			this.HPBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.HPBox.Location = new System.Drawing.Point(68, 38);
			this.HPBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.HPBox.Name = "HPBox";
			this.HPBox.Size = new System.Drawing.Size(204, 20);
			this.HPBox.TabIndex = 3;
			// 
			// TempHPBox
			// 
			this.TempHPBox.AutoSize = true;
			this.TempHPBox.Location = new System.Drawing.Point(68, 75);
			this.TempHPBox.Name = "TempHPBox";
			this.TempHPBox.Size = new System.Drawing.Size(153, 17);
			this.TempHPBox.TabIndex = 4;
			this.TempHPBox.Text = "Add as temporary hit points";
			this.TempHPBox.UseVisualStyleBackColor = true;
			// 
			// SurgeLbl
			// 
			this.SurgeLbl.AutoSize = true;
			this.SurgeLbl.Location = new System.Drawing.Point(12, 14);
			this.SurgeLbl.Name = "SurgeLbl";
			this.SurgeLbl.Size = new System.Drawing.Size(43, 13);
			this.SurgeLbl.TabIndex = 0;
			this.SurgeLbl.Text = "Surges:";
			// 
			// SurgeBox
			// 
			this.SurgeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.SurgeBox.Location = new System.Drawing.Point(68, 12);
			this.SurgeBox.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.SurgeBox.Name = "SurgeBox";
			this.SurgeBox.Size = new System.Drawing.Size(204, 20);
			this.SurgeBox.TabIndex = 1;
			// 
			// HealForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(284, 145);
			this.Controls.Add(this.SurgeBox);
			this.Controls.Add(this.SurgeLbl);
			this.Controls.Add(this.TempHPBox);
			this.Controls.Add(this.HPBox);
			this.Controls.Add(this.HPLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HealForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Heal";
			this.Shown += new System.EventHandler(this.DamageForm_Shown);
			((System.ComponentModel.ISupportInitialize)(this.HPBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SurgeBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label HPLbl;
		private System.Windows.Forms.NumericUpDown HPBox;
		private System.Windows.Forms.CheckBox TempHPBox;
		private System.Windows.Forms.Label SurgeLbl;
		private System.Windows.Forms.NumericUpDown SurgeBox;
	}
}