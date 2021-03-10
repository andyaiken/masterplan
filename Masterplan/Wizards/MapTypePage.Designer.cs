namespace Masterplan.Wizards
{
	partial class MapTypePage
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
			this.DungeonBtn = new System.Windows.Forms.RadioButton();
			this.AreaBtn = new System.Windows.Forms.RadioButton();
			this.FreeformBtn = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// InfoLbl
			// 
			this.InfoLbl.Dock = System.Windows.Forms.DockStyle.Top;
			this.InfoLbl.Location = new System.Drawing.Point(0, 0);
			this.InfoLbl.Name = "InfoLbl";
			this.InfoLbl.Size = new System.Drawing.Size(307, 40);
			this.InfoLbl.TabIndex = 0;
			this.InfoLbl.Text = "What kind of map do you want to create?";
			// 
			// DungeonBtn
			// 
			this.DungeonBtn.AutoSize = true;
			this.DungeonBtn.Location = new System.Drawing.Point(3, 40);
			this.DungeonBtn.Name = "DungeonBtn";
			this.DungeonBtn.Size = new System.Drawing.Size(100, 17);
			this.DungeonBtn.TabIndex = 1;
			this.DungeonBtn.TabStop = true;
			this.DungeonBtn.Text = "A dungeon map";
			this.DungeonBtn.UseVisualStyleBackColor = true;
			// 
			// AreaBtn
			// 
			this.AreaBtn.AutoSize = true;
			this.AreaBtn.Location = new System.Drawing.Point(3, 63);
			this.AreaBtn.Name = "AreaBtn";
			this.AreaBtn.Size = new System.Drawing.Size(112, 17);
			this.AreaBtn.TabIndex = 2;
			this.AreaBtn.TabStop = true;
			this.AreaBtn.Text = "A rectangular area";
			this.AreaBtn.UseVisualStyleBackColor = true;
			// 
			// FreeformBtn
			// 
			this.FreeformBtn.AutoSize = true;
			this.FreeformBtn.Location = new System.Drawing.Point(3, 86);
			this.FreeformBtn.Name = "FreeformBtn";
			this.FreeformBtn.Size = new System.Drawing.Size(97, 17);
			this.FreeformBtn.TabIndex = 3;
			this.FreeformBtn.TabStop = true;
			this.FreeformBtn.Text = "A freeform area";
			this.FreeformBtn.UseVisualStyleBackColor = true;
			// 
			// MapTypePage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.FreeformBtn);
			this.Controls.Add(this.AreaBtn);
			this.Controls.Add(this.DungeonBtn);
			this.Controls.Add(this.InfoLbl);
			this.Name = "MapTypePage";
			this.Size = new System.Drawing.Size(307, 129);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label InfoLbl;
		private System.Windows.Forms.RadioButton DungeonBtn;
		private System.Windows.Forms.RadioButton AreaBtn;
		private System.Windows.Forms.RadioButton FreeformBtn;
	}
}
