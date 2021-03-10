namespace Masterplan.Wizards
{
	partial class VariantFinishPage
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
			this.InfoLbl = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// InfoLbl
			// 
			this.InfoLbl.Dock = System.Windows.Forms.DockStyle.Top;
			this.InfoLbl.Location = new System.Drawing.Point(0, 0);
			this.InfoLbl.Name = "InfoLbl";
			this.InfoLbl.Size = new System.Drawing.Size(260, 40);
			this.InfoLbl.TabIndex = 0;
			this.InfoLbl.Text = "Press Finish to edit this creature, or Back to change your selections.";
			// 
			// VariantFinishPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.InfoLbl);
			this.Name = "VariantFinishPage";
			this.Size = new System.Drawing.Size(260, 150);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label InfoLbl;
	}
}
