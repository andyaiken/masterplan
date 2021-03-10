namespace Masterplan.UI
{
	partial class DieRollerForm
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
			this.DicePanel = new Masterplan.Controls.DicePanel();
			this.SuspendLayout();
			// 
			// DicePanel
			// 
			this.DicePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DicePanel.Expression = null;
			this.DicePanel.Location = new System.Drawing.Point(0, 0);
			this.DicePanel.Name = "DicePanel";
			this.DicePanel.Size = new System.Drawing.Size(247, 372);
			this.DicePanel.TabIndex = 0;
			// 
			// DieRollerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(247, 372);
			this.Controls.Add(this.DicePanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DieRollerForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Die Roller";
			this.ResumeLayout(false);

		}

		#endregion

		private Masterplan.Controls.DicePanel DicePanel;
	}
}