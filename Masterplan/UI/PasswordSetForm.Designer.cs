namespace Masterplan.UI
{
	partial class PasswordSetForm
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
			this.PasswordLbl = new System.Windows.Forms.Label();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.PasswordBox = new System.Windows.Forms.TextBox();
			this.RetypeBox = new System.Windows.Forms.TextBox();
			this.RetypeLbl = new System.Windows.Forms.Label();
			this.HintBox = new System.Windows.Forms.TextBox();
			this.HintLbl = new System.Windows.Forms.Label();
			this.ClearBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// PasswordLbl
			// 
			this.PasswordLbl.AutoSize = true;
			this.PasswordLbl.Location = new System.Drawing.Point(12, 15);
			this.PasswordLbl.Name = "PasswordLbl";
			this.PasswordLbl.Size = new System.Drawing.Size(83, 13);
			this.PasswordLbl.TabIndex = 0;
			this.PasswordLbl.Text = "Enter password:";
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(206, 128);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 7;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(287, 128);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 8;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// PasswordBox
			// 
			this.PasswordBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.PasswordBox.Location = new System.Drawing.Point(110, 12);
			this.PasswordBox.Name = "PasswordBox";
			this.PasswordBox.PasswordChar = '*';
			this.PasswordBox.Size = new System.Drawing.Size(252, 20);
			this.PasswordBox.TabIndex = 1;
			// 
			// RetypeBox
			// 
			this.RetypeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.RetypeBox.Location = new System.Drawing.Point(110, 38);
			this.RetypeBox.Name = "RetypeBox";
			this.RetypeBox.PasswordChar = '*';
			this.RetypeBox.Size = new System.Drawing.Size(252, 20);
			this.RetypeBox.TabIndex = 3;
			// 
			// RetypeLbl
			// 
			this.RetypeLbl.AutoSize = true;
			this.RetypeLbl.Location = new System.Drawing.Point(12, 41);
			this.RetypeLbl.Name = "RetypeLbl";
			this.RetypeLbl.Size = new System.Drawing.Size(92, 13);
			this.RetypeLbl.TabIndex = 2;
			this.RetypeLbl.Text = "Retype password:";
			// 
			// HintBox
			// 
			this.HintBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.HintBox.Location = new System.Drawing.Point(110, 87);
			this.HintBox.Name = "HintBox";
			this.HintBox.Size = new System.Drawing.Size(252, 20);
			this.HintBox.TabIndex = 5;
			// 
			// HintLbl
			// 
			this.HintLbl.AutoSize = true;
			this.HintLbl.Location = new System.Drawing.Point(12, 90);
			this.HintLbl.Name = "HintLbl";
			this.HintLbl.Size = new System.Drawing.Size(76, 13);
			this.HintLbl.TabIndex = 4;
			this.HintLbl.Text = "Password hint:";
			// 
			// ClearBtn
			// 
			this.ClearBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ClearBtn.Location = new System.Drawing.Point(12, 128);
			this.ClearBtn.Name = "ClearBtn";
			this.ClearBtn.Size = new System.Drawing.Size(117, 23);
			this.ClearBtn.TabIndex = 6;
			this.ClearBtn.Text = "Remove Password";
			this.ClearBtn.UseVisualStyleBackColor = true;
			this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
			// 
			// PasswordSetForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(374, 163);
			this.Controls.Add(this.ClearBtn);
			this.Controls.Add(this.HintBox);
			this.Controls.Add(this.HintLbl);
			this.Controls.Add(this.RetypeBox);
			this.Controls.Add(this.RetypeLbl);
			this.Controls.Add(this.PasswordBox);
			this.Controls.Add(this.PasswordLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PasswordSetForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Set Password";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label PasswordLbl;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.TextBox PasswordBox;
		private System.Windows.Forms.TextBox RetypeBox;
		private System.Windows.Forms.Label RetypeLbl;
		private System.Windows.Forms.TextBox HintBox;
		private System.Windows.Forms.Label HintLbl;
		private System.Windows.Forms.Button ClearBtn;
	}
}