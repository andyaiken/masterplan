namespace Masterplan.Wizards
{
	partial class VariantRolePage
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
			this.RoleBox = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// InfoLbl
			// 
			this.InfoLbl.Dock = System.Windows.Forms.DockStyle.Top;
			this.InfoLbl.Location = new System.Drawing.Point(0, 0);
			this.InfoLbl.Name = "InfoLbl";
			this.InfoLbl.Size = new System.Drawing.Size(268, 40);
			this.InfoLbl.TabIndex = 1;
			this.InfoLbl.Text = "Select the role that your new creature will fill.";
			// 
			// RoleBox
			// 
			this.RoleBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.RoleBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.RoleBox.FormattingEnabled = true;
			this.RoleBox.Location = new System.Drawing.Point(3, 43);
			this.RoleBox.Name = "RoleBox";
			this.RoleBox.Size = new System.Drawing.Size(262, 21);
			this.RoleBox.TabIndex = 2;
			this.RoleBox.SelectedIndexChanged += new System.EventHandler(this.RoleBox_SelectedIndexChanged);
			// 
			// VariantRolePage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.RoleBox);
			this.Controls.Add(this.InfoLbl);
			this.Name = "VariantRolePage";
			this.Size = new System.Drawing.Size(268, 93);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label InfoLbl;
		private System.Windows.Forms.ComboBox RoleBox;
	}
}
