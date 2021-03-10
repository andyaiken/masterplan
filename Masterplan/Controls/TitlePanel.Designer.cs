namespace Masterplan.Controls
{
	partial class TitlePanel
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.FadeTimer = new System.Windows.Forms.Timer(this.components);
			this.PulseTimer = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// FadeTimer
			// 
			this.FadeTimer.Interval = 25;
			this.FadeTimer.Tick += new System.EventHandler(this.FadeTimer_Tick);
			// 
			// PulseTimer
			// 
			this.PulseTimer.Tick += new System.EventHandler(this.PulseTimer_Tick);
			// 
			// TitlePanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ForeColor = System.Drawing.Color.MidnightBlue;
			this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.Name = "TitlePanel";
			this.Size = new System.Drawing.Size(150, 151);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Timer FadeTimer;
		private System.Windows.Forms.Timer PulseTimer;
	}
}
