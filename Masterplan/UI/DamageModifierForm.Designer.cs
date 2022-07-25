namespace Masterplan.UI
{
	partial class DamageModifierForm
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
			this.DamageTypeLbl = new System.Windows.Forms.Label();
			this.ValueLbl = new System.Windows.Forms.Label();
			this.ValueBox = new System.Windows.Forms.NumericUpDown();
			this.DamageTypeBox = new System.Windows.Forms.ComboBox();
			this.TypeBox = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.ValueBox)).BeginInit();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(104, 97);
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
			this.CancelBtn.Location = new System.Drawing.Point(185, 97);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 6;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// DamageTypeLbl
			// 
			this.DamageTypeLbl.AutoSize = true;
			this.DamageTypeLbl.Location = new System.Drawing.Point(12, 15);
			this.DamageTypeLbl.Name = "DamageTypeLbl";
			this.DamageTypeLbl.Size = new System.Drawing.Size(34, 13);
			this.DamageTypeLbl.TabIndex = 0;
			this.DamageTypeLbl.Text = "Type:";
			// 
			// ValueLbl
			// 
			this.ValueLbl.AutoSize = true;
			this.ValueLbl.Location = new System.Drawing.Point(12, 68);
			this.ValueLbl.Name = "ValueLbl";
			this.ValueLbl.Size = new System.Drawing.Size(37, 13);
			this.ValueLbl.TabIndex = 3;
			this.ValueLbl.Text = "Value:";
			// 
			// ValueBox
			// 
			this.ValueBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ValueBox.Location = new System.Drawing.Point(53, 66);
			this.ValueBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.ValueBox.Name = "ValueBox";
			this.ValueBox.Size = new System.Drawing.Size(207, 20);
			this.ValueBox.TabIndex = 4;
			this.ValueBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// DamageTypeBox
			// 
			this.DamageTypeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DamageTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.DamageTypeBox.FormattingEnabled = true;
			this.DamageTypeBox.Location = new System.Drawing.Point(53, 12);
			this.DamageTypeBox.Name = "DamageTypeBox";
			this.DamageTypeBox.Size = new System.Drawing.Size(207, 21);
			this.DamageTypeBox.TabIndex = 1;
			// 
			// TypeBox
			// 
			this.TypeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TypeBox.FormattingEnabled = true;
			this.TypeBox.Location = new System.Drawing.Point(53, 39);
			this.TypeBox.Name = "TypeBox";
			this.TypeBox.Size = new System.Drawing.Size(207, 21);
			this.TypeBox.TabIndex = 2;
			this.TypeBox.SelectedIndexChanged += new System.EventHandler(this.TypeBox_SelectedIndexChanged);
			// 
			// DamageModifierForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(272, 132);
			this.Controls.Add(this.TypeBox);
			this.Controls.Add(this.DamageTypeBox);
			this.Controls.Add(this.ValueBox);
			this.Controls.Add(this.ValueLbl);
			this.Controls.Add(this.DamageTypeLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DamageModifierForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Damage Modifier";
			((System.ComponentModel.ISupportInitialize)(this.ValueBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label DamageTypeLbl;
		private System.Windows.Forms.Label ValueLbl;
		private System.Windows.Forms.NumericUpDown ValueBox;
		private System.Windows.Forms.ComboBox DamageTypeBox;
		private System.Windows.Forms.ComboBox TypeBox;
	}
}