namespace Masterplan.UI
{
	partial class TrapActionForm
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
			this.CancelBtn = new System.Windows.Forms.Button();
			this.OKBtn = new System.Windows.Forms.Button();
			this.ActionLbl = new System.Windows.Forms.Label();
			this.ActionBox = new System.Windows.Forms.ComboBox();
			this.RangeLbl = new System.Windows.Forms.Label();
			this.RangeBox = new System.Windows.Forms.TextBox();
			this.TargetLbl = new System.Windows.Forms.Label();
			this.TargetBox = new System.Windows.Forms.TextBox();
			this.NameLbl = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(222, 127);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 9;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(141, 127);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 8;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// ActionLbl
			// 
			this.ActionLbl.AutoSize = true;
			this.ActionLbl.Location = new System.Drawing.Point(12, 41);
			this.ActionLbl.Name = "ActionLbl";
			this.ActionLbl.Size = new System.Drawing.Size(40, 13);
			this.ActionLbl.TabIndex = 2;
			this.ActionLbl.Text = "Action:";
			// 
			// ActionBox
			// 
			this.ActionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ActionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ActionBox.FormattingEnabled = true;
			this.ActionBox.Location = new System.Drawing.Point(60, 38);
			this.ActionBox.Name = "ActionBox";
			this.ActionBox.Size = new System.Drawing.Size(237, 21);
			this.ActionBox.TabIndex = 3;
			// 
			// RangeLbl
			// 
			this.RangeLbl.AutoSize = true;
			this.RangeLbl.Location = new System.Drawing.Point(12, 68);
			this.RangeLbl.Name = "RangeLbl";
			this.RangeLbl.Size = new System.Drawing.Size(42, 13);
			this.RangeLbl.TabIndex = 4;
			this.RangeLbl.Text = "Range:";
			// 
			// RangeBox
			// 
			this.RangeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.RangeBox.Location = new System.Drawing.Point(60, 65);
			this.RangeBox.Name = "RangeBox";
			this.RangeBox.Size = new System.Drawing.Size(237, 20);
			this.RangeBox.TabIndex = 5;
			// 
			// TargetLbl
			// 
			this.TargetLbl.AutoSize = true;
			this.TargetLbl.Location = new System.Drawing.Point(12, 94);
			this.TargetLbl.Name = "TargetLbl";
			this.TargetLbl.Size = new System.Drawing.Size(41, 13);
			this.TargetLbl.TabIndex = 6;
			this.TargetLbl.Text = "Target:";
			// 
			// TargetBox
			// 
			this.TargetBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TargetBox.Location = new System.Drawing.Point(60, 91);
			this.TargetBox.Name = "TargetBox";
			this.TargetBox.Size = new System.Drawing.Size(237, 20);
			this.TargetBox.TabIndex = 7;
			// 
			// NameLbl
			// 
			this.NameLbl.AutoSize = true;
			this.NameLbl.Location = new System.Drawing.Point(12, 15);
			this.NameLbl.Name = "NameLbl";
			this.NameLbl.Size = new System.Drawing.Size(38, 13);
			this.NameLbl.TabIndex = 0;
			this.NameLbl.Text = "Name:";
			// 
			// NameBox
			// 
			this.NameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.NameBox.Location = new System.Drawing.Point(60, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(237, 20);
			this.NameBox.TabIndex = 1;
			// 
			// TrapActionForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(309, 162);
			this.Controls.Add(this.NameLbl);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.RangeLbl);
			this.Controls.Add(this.RangeBox);
			this.Controls.Add(this.TargetLbl);
			this.Controls.Add(this.TargetBox);
			this.Controls.Add(this.ActionBox);
			this.Controls.Add(this.ActionLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TrapActionForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Trap Attack";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Label ActionLbl;
		private System.Windows.Forms.ComboBox ActionBox;
		private System.Windows.Forms.Label RangeLbl;
		private System.Windows.Forms.TextBox RangeBox;
		private System.Windows.Forms.Label TargetLbl;
		private System.Windows.Forms.TextBox TargetBox;
		private System.Windows.Forms.Label NameLbl;
		private System.Windows.Forms.TextBox NameBox;
	}
}