namespace Masterplan.UI
{
	partial class HeroSelectForm
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
			this.QuestionLbl = new System.Windows.Forms.Label();
			this.YesBtn = new System.Windows.Forms.RadioButton();
			this.HeroBox = new System.Windows.Forms.ComboBox();
			this.NoBtn = new System.Windows.Forms.RadioButton();
			this.InfoLbl = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(165, 185);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 3;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(246, 185);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 4;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// QuestionLbl
			// 
			this.QuestionLbl.AutoSize = true;
			this.QuestionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.QuestionLbl.Location = new System.Drawing.Point(12, 9);
			this.QuestionLbl.Name = "QuestionLbl";
			this.QuestionLbl.Size = new System.Drawing.Size(193, 13);
			this.QuestionLbl.TabIndex = 5;
			this.QuestionLbl.Text = "Was this effect applied by a PC?";
			// 
			// YesBtn
			// 
			this.YesBtn.AutoSize = true;
			this.YesBtn.Location = new System.Drawing.Point(12, 40);
			this.YesBtn.Name = "YesBtn";
			this.YesBtn.Size = new System.Drawing.Size(43, 17);
			this.YesBtn.TabIndex = 6;
			this.YesBtn.TabStop = true;
			this.YesBtn.Text = "Yes";
			this.YesBtn.UseVisualStyleBackColor = true;
			this.YesBtn.CheckedChanged += new System.EventHandler(this.option_changed);
			// 
			// HeroBox
			// 
			this.HeroBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.HeroBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.HeroBox.FormattingEnabled = true;
			this.HeroBox.Location = new System.Drawing.Point(61, 39);
			this.HeroBox.Name = "HeroBox";
			this.HeroBox.Size = new System.Drawing.Size(260, 21);
			this.HeroBox.TabIndex = 7;
			this.HeroBox.SelectedIndexChanged += new System.EventHandler(this.option_changed);
			// 
			// NoBtn
			// 
			this.NoBtn.AutoSize = true;
			this.NoBtn.Location = new System.Drawing.Point(12, 76);
			this.NoBtn.Name = "NoBtn";
			this.NoBtn.Size = new System.Drawing.Size(39, 17);
			this.NoBtn.TabIndex = 8;
			this.NoBtn.TabStop = true;
			this.NoBtn.Text = "No";
			this.NoBtn.UseVisualStyleBackColor = true;
			this.NoBtn.CheckedChanged += new System.EventHandler(this.option_changed);
			// 
			// InfoLbl
			// 
			this.InfoLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.InfoLbl.Location = new System.Drawing.Point(12, 109);
			this.InfoLbl.Name = "InfoLbl";
			this.InfoLbl.Size = new System.Drawing.Size(309, 73);
			this.InfoLbl.TabIndex = 9;
			this.InfoLbl.Text = "[info]";
			// 
			// HeroSelectForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(333, 220);
			this.Controls.Add(this.InfoLbl);
			this.Controls.Add(this.NoBtn);
			this.Controls.Add(this.HeroBox);
			this.Controls.Add(this.YesBtn);
			this.Controls.Add(this.QuestionLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HeroSelectForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select a PC";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label QuestionLbl;
		private System.Windows.Forms.RadioButton YesBtn;
		private System.Windows.Forms.ComboBox HeroBox;
		private System.Windows.Forms.RadioButton NoBtn;
		private System.Windows.Forms.Label InfoLbl;
	}
}