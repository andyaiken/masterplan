namespace Masterplan.UI
{
	partial class ArtifactConcordanceForm
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
			this.RuleLbl = new System.Windows.Forms.Label();
			this.RuleBox = new System.Windows.Forms.TextBox();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.ValueLbl = new System.Windows.Forms.Label();
			this.ValueBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// RuleLbl
			// 
			this.RuleLbl.AutoSize = true;
			this.RuleLbl.Location = new System.Drawing.Point(12, 15);
			this.RuleLbl.Name = "RuleLbl";
			this.RuleLbl.Size = new System.Drawing.Size(32, 13);
			this.RuleLbl.TabIndex = 0;
			this.RuleLbl.Text = "Rule:";
			// 
			// RuleBox
			// 
			this.RuleBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.RuleBox.Location = new System.Drawing.Point(56, 12);
			this.RuleBox.Name = "RuleBox";
			this.RuleBox.Size = new System.Drawing.Size(260, 20);
			this.RuleBox.TabIndex = 1;
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(160, 76);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 4;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(241, 76);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 5;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// ValueLbl
			// 
			this.ValueLbl.AutoSize = true;
			this.ValueLbl.Location = new System.Drawing.Point(12, 41);
			this.ValueLbl.Name = "ValueLbl";
			this.ValueLbl.Size = new System.Drawing.Size(37, 13);
			this.ValueLbl.TabIndex = 2;
			this.ValueLbl.Text = "Value:";
			// 
			// ValueBox
			// 
			this.ValueBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ValueBox.Location = new System.Drawing.Point(56, 34);
			this.ValueBox.Name = "ValueBox";
			this.ValueBox.Size = new System.Drawing.Size(260, 20);
			this.ValueBox.TabIndex = 3;
			// 
			// ArtifactConcordanceForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(328, 111);
			this.Controls.Add(this.ValueBox);
			this.Controls.Add(this.ValueLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.RuleBox);
			this.Controls.Add(this.RuleLbl);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ArtifactConcordanceForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Artifact Concordance Rule";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label RuleLbl;
		private System.Windows.Forms.TextBox RuleBox;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label ValueLbl;
		private System.Windows.Forms.TextBox ValueBox;
	}
}