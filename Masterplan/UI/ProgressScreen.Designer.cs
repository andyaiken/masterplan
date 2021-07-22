namespace Masterplan.UI
{
	partial class ProgressScreen
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
			this.SplashPanel = new System.Windows.Forms.Panel();
			this.SubActionLbl = new System.Windows.Forms.Label();
			this.ActionLbl = new System.Windows.Forms.Label();
			this.Gauge = new System.Windows.Forms.ProgressBar();
			this.SplashPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// SplashPanel
			// 
			this.SplashPanel.BackColor = System.Drawing.SystemColors.Window;
			this.SplashPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.SplashPanel.Controls.Add(this.SubActionLbl);
			this.SplashPanel.Controls.Add(this.ActionLbl);
			this.SplashPanel.Controls.Add(this.Gauge);
			this.SplashPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SplashPanel.Location = new System.Drawing.Point(0, 0);
			this.SplashPanel.Name = "SplashPanel";
			this.SplashPanel.Size = new System.Drawing.Size(388, 74);
			this.SplashPanel.TabIndex = 0;
			// 
			// SubActionLbl
			// 
			this.SubActionLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.SubActionLbl.ForeColor = System.Drawing.SystemColors.GrayText;
			this.SubActionLbl.Location = new System.Drawing.Point(11, 25);
			this.SubActionLbl.Name = "SubActionLbl";
			this.SubActionLbl.Size = new System.Drawing.Size(364, 13);
			this.SubActionLbl.TabIndex = 4;
			this.SubActionLbl.Text = "[sub action]";
			// 
			// ActionLbl
			// 
			this.ActionLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ActionLbl.Location = new System.Drawing.Point(11, 8);
			this.ActionLbl.Name = "ActionLbl";
			this.ActionLbl.Size = new System.Drawing.Size(364, 13);
			this.ActionLbl.TabIndex = 3;
			this.ActionLbl.Text = "[action]";
			// 
			// Gauge
			// 
			this.Gauge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Gauge.Location = new System.Drawing.Point(10, 48);
			this.Gauge.Maximum = 1;
			this.Gauge.Name = "Gauge";
			this.Gauge.Size = new System.Drawing.Size(366, 16);
			this.Gauge.Step = 1;
			this.Gauge.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.Gauge.TabIndex = 2;
			// 
			// ProgressScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(388, 74);
			this.ControlBox = false;
			this.Controls.Add(this.SplashPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ProgressScreen";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Progress";
			this.TopMost = true;
			this.SplashPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel SplashPanel;
		private System.Windows.Forms.Label ActionLbl;
		private System.Windows.Forms.ProgressBar Gauge;
		private System.Windows.Forms.Label SubActionLbl;

	}
}