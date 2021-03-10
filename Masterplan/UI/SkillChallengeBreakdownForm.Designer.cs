namespace Masterplan.UI
{
	partial class SkillChallengeBreakdownForm
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
			this.AbilitiesPanel = new Masterplan.Controls.KeyAbilitiesPanel();
			this.SuspendLayout();
			// 
			// AbilitiesPanel
			// 
			this.AbilitiesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AbilitiesPanel.Location = new System.Drawing.Point(0, 0);
			this.AbilitiesPanel.Name = "AbilitiesPanel";
			this.AbilitiesPanel.Size = new System.Drawing.Size(752, 290);
			this.AbilitiesPanel.TabIndex = 0;
			// 
			// SkillChallengeBreakdownForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(752, 290);
			this.Controls.Add(this.AbilitiesPanel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SkillChallengeBreakdownForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Skill Challenge Breakdown";
			this.ResumeLayout(false);

		}

		#endregion

		private Masterplan.Controls.KeyAbilitiesPanel AbilitiesPanel;


	}
}