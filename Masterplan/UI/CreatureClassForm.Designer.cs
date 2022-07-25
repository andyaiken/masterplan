namespace Masterplan.UI
{
	partial class CreatureClassForm
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
			this.OriginLbl = new System.Windows.Forms.Label();
			this.OriginBox = new System.Windows.Forms.ComboBox();
			this.TypeLbl = new System.Windows.Forms.Label();
			this.TypeBox = new System.Windows.Forms.ComboBox();
			this.KeywordLbl = new System.Windows.Forms.Label();
			this.KeywordBox = new System.Windows.Forms.TextBox();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.SizeBox = new System.Windows.Forms.ComboBox();
			this.SizeLbl = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// OriginLbl
			// 
			this.OriginLbl.AutoSize = true;
			this.OriginLbl.Location = new System.Drawing.Point(12, 42);
			this.OriginLbl.Name = "OriginLbl";
			this.OriginLbl.Size = new System.Drawing.Size(37, 13);
			this.OriginLbl.TabIndex = 2;
			this.OriginLbl.Text = "Origin:";
			// 
			// OriginBox
			// 
			this.OriginBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.OriginBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.OriginBox.FormattingEnabled = true;
			this.OriginBox.Location = new System.Drawing.Point(74, 39);
			this.OriginBox.Name = "OriginBox";
			this.OriginBox.Size = new System.Drawing.Size(259, 21);
			this.OriginBox.TabIndex = 3;
			// 
			// TypeLbl
			// 
			this.TypeLbl.AutoSize = true;
			this.TypeLbl.Location = new System.Drawing.Point(12, 69);
			this.TypeLbl.Name = "TypeLbl";
			this.TypeLbl.Size = new System.Drawing.Size(34, 13);
			this.TypeLbl.TabIndex = 4;
			this.TypeLbl.Text = "Type:";
			// 
			// TypeBox
			// 
			this.TypeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TypeBox.FormattingEnabled = true;
			this.TypeBox.Location = new System.Drawing.Point(74, 66);
			this.TypeBox.Name = "TypeBox";
			this.TypeBox.Size = new System.Drawing.Size(259, 21);
			this.TypeBox.TabIndex = 5;
			// 
			// KeywordLbl
			// 
			this.KeywordLbl.AutoSize = true;
			this.KeywordLbl.Location = new System.Drawing.Point(12, 96);
			this.KeywordLbl.Name = "KeywordLbl";
			this.KeywordLbl.Size = new System.Drawing.Size(56, 13);
			this.KeywordLbl.TabIndex = 6;
			this.KeywordLbl.Text = "Keywords:";
			// 
			// KeywordBox
			// 
			this.KeywordBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.KeywordBox.Location = new System.Drawing.Point(74, 93);
			this.KeywordBox.Name = "KeywordBox";
			this.KeywordBox.Size = new System.Drawing.Size(259, 20);
			this.KeywordBox.TabIndex = 7;
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(177, 127);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 8;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(258, 127);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 9;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// SizeBox
			// 
			this.SizeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.SizeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.SizeBox.Location = new System.Drawing.Point(74, 12);
			this.SizeBox.Name = "SizeBox";
			this.SizeBox.Size = new System.Drawing.Size(259, 21);
			this.SizeBox.TabIndex = 1;
			// 
			// SizeLbl
			// 
			this.SizeLbl.AutoSize = true;
			this.SizeLbl.Location = new System.Drawing.Point(12, 15);
			this.SizeLbl.Name = "SizeLbl";
			this.SizeLbl.Size = new System.Drawing.Size(30, 13);
			this.SizeLbl.TabIndex = 0;
			this.SizeLbl.Text = "Size:";
			// 
			// CreatureClassForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(345, 162);
			this.Controls.Add(this.SizeBox);
			this.Controls.Add(this.SizeLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.KeywordBox);
			this.Controls.Add(this.KeywordLbl);
			this.Controls.Add(this.TypeBox);
			this.Controls.Add(this.TypeLbl);
			this.Controls.Add(this.OriginBox);
			this.Controls.Add(this.OriginLbl);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CreatureClassForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Creature Information";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label OriginLbl;
		private System.Windows.Forms.ComboBox OriginBox;
		private System.Windows.Forms.Label TypeLbl;
		private System.Windows.Forms.ComboBox TypeBox;
		private System.Windows.Forms.Label KeywordLbl;
		private System.Windows.Forms.TextBox KeywordBox;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.ComboBox SizeBox;
		private System.Windows.Forms.Label SizeLbl;
	}
}