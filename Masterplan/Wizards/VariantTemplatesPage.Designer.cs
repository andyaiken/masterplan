namespace Masterplan.Wizards
{
	partial class VariantTemplatesPage
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
			this.TemplateList = new System.Windows.Forms.ListView();
			this.NameHdr = new System.Windows.Forms.ColumnHeader();
			this.TypeHdr = new System.Windows.Forms.ColumnHeader();
			this.InfoLbl = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// TemplateList
			// 
			this.TemplateList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TemplateList.CheckBoxes = true;
			this.TemplateList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameHdr,
            this.TypeHdr});
			this.TemplateList.FullRowSelect = true;
			this.TemplateList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.TemplateList.HideSelection = false;
			this.TemplateList.Location = new System.Drawing.Point(3, 43);
			this.TemplateList.MultiSelect = false;
			this.TemplateList.Name = "TemplateList";
			this.TemplateList.Size = new System.Drawing.Size(287, 188);
			this.TemplateList.TabIndex = 5;
			this.TemplateList.UseCompatibleStateImageBehavior = false;
			this.TemplateList.View = System.Windows.Forms.View.Details;
			this.TemplateList.DoubleClick += new System.EventHandler(this.TemplateList_DoubleClick);
			// 
			// NameHdr
			// 
			this.NameHdr.Text = "Template";
			this.NameHdr.Width = 150;
			// 
			// TypeHdr
			// 
			this.TypeHdr.Text = "Role";
			this.TypeHdr.Width = 100;
			// 
			// InfoLbl
			// 
			this.InfoLbl.Dock = System.Windows.Forms.DockStyle.Top;
			this.InfoLbl.Location = new System.Drawing.Point(0, 0);
			this.InfoLbl.Name = "InfoLbl";
			this.InfoLbl.Size = new System.Drawing.Size(293, 40);
			this.InfoLbl.TabIndex = 3;
			this.InfoLbl.Text = "Select any templates you would like to apply to the new creature.";
			// 
			// VariantTemplatesPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.TemplateList);
			this.Controls.Add(this.InfoLbl);
			this.Name = "VariantTemplatesPage";
			this.Size = new System.Drawing.Size(293, 234);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView TemplateList;
		private System.Windows.Forms.ColumnHeader NameHdr;
		private System.Windows.Forms.ColumnHeader TypeHdr;
		private System.Windows.Forms.Label InfoLbl;
	}
}
