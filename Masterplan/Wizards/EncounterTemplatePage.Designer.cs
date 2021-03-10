namespace Masterplan.Wizards
{
	partial class EncounterTemplatePage
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
            this.TemplatesList = new System.Windows.Forms.ListView();
            this.TemplateHdr = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // InfoLbl
            // 
            this.InfoLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.InfoLbl.Location = new System.Drawing.Point(0, 0);
            this.InfoLbl.Name = "InfoLbl";
            this.InfoLbl.Size = new System.Drawing.Size(372, 40);
            this.InfoLbl.TabIndex = 1;
            this.InfoLbl.Text = "The following templates fit the creatures you have added to the encounter so far." +
                " Select one to continue.";
            // 
            // TemplatesList
            // 
            this.TemplatesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TemplateHdr});
            this.TemplatesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TemplatesList.FullRowSelect = true;
            this.TemplatesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.TemplatesList.HideSelection = false;
            this.TemplatesList.Location = new System.Drawing.Point(0, 40);
            this.TemplatesList.Name = "TemplatesList";
            this.TemplatesList.Size = new System.Drawing.Size(372, 206);
            this.TemplatesList.TabIndex = 2;
            this.TemplatesList.UseCompatibleStateImageBehavior = false;
            this.TemplatesList.View = System.Windows.Forms.View.Details;
            // 
            // TemplateHdr
            // 
            this.TemplateHdr.Text = "Encounter Template";
            this.TemplateHdr.Width = 300;
            // 
            // EncounterTemplatePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TemplatesList);
            this.Controls.Add(this.InfoLbl);
            this.Name = "EncounterTemplatePage";
            this.Size = new System.Drawing.Size(372, 246);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label InfoLbl;
		private System.Windows.Forms.ListView TemplatesList;
		private System.Windows.Forms.ColumnHeader TemplateHdr;
	}
}
