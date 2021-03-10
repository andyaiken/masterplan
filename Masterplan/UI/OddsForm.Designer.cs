namespace Masterplan.UI
{
    partial class OddsForm
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
			this.DiceGraph = new Masterplan.Controls.DiceGraphPanel();
			this.SuspendLayout();
			// 
			// DiceGraph
			// 
			this.DiceGraph.Constant = 0;
			this.DiceGraph.Dice = null;
			this.DiceGraph.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DiceGraph.Location = new System.Drawing.Point(0, 0);
			this.DiceGraph.Name = "DiceGraph";
			this.DiceGraph.Size = new System.Drawing.Size(449, 262);
			this.DiceGraph.TabIndex = 0;
			this.DiceGraph.Title = "";
			// 
			// OddsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(449, 262);
			this.Controls.Add(this.DiceGraph);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OddsForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Odds";
			this.ResumeLayout(false);

        }

        #endregion

        private Masterplan.Controls.DiceGraphPanel DiceGraph;
    }
}