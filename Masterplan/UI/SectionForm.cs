#nullable disable
// Legacy WinForms form (controls created in InitializeComponent): nullable checking is off here, as
// in the other legacy files (see CLAUDE.md), instead of annotating every designer field.

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Masterplan.UI
{
    public partial class SectionForm : Form
    {
        public SectionForm(string header, string details, string title, IEnumerable<string> suggestedHeaders)
        {
            InitializeComponent();

            this.Text = title;

            if (suggestedHeaders != null)
            {
                foreach (string h in suggestedHeaders)
                {
                    HeaderBox.Items.Add(h);
                }
            }

            HeaderBox.Text = header;
            DetailsBox.Text = details;
        }

        public string Header
        {
            get { return HeaderBox.Text; }
        }

        public string Details
        {
            get { return DetailsBox.Text; }
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            HeaderLbl = new Label();
            Pages = new TabControl();
            DetailsPage = new TabPage();
            DetailsBox = new TextBox();
            OKBtn = new Button();
            CancelBtn = new Button();
            HeaderBox = new ComboBox();
            Pages.SuspendLayout();
            DetailsPage.SuspendLayout();
            SuspendLayout();
            // 
            // HeaderLbl
            // 
            HeaderLbl.AutoSize = true;
            HeaderLbl.Location = new System.Drawing.Point(14, 17);
            HeaderLbl.Margin = new Padding(4, 0, 4, 0);
            HeaderLbl.Name = "HeaderLbl";
            HeaderLbl.Size = new System.Drawing.Size(48, 15);
            HeaderLbl.TabIndex = 0;
            HeaderLbl.Text = "Header:";
            // 
            // Pages
            // 
            Pages.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Pages.Controls.Add(DetailsPage);
            Pages.Location = new System.Drawing.Point(14, 45);
            Pages.Margin = new Padding(4, 3, 4, 3);
            Pages.Name = "Pages";
            Pages.SelectedIndex = 0;
            Pages.Size = new System.Drawing.Size(358, 168);
            Pages.TabIndex = 2;
            // 
            // DetailsPage
            // 
            DetailsPage.Controls.Add(DetailsBox);
            DetailsPage.Location = new System.Drawing.Point(4, 24);
            DetailsPage.Margin = new Padding(4, 3, 4, 3);
            DetailsPage.Name = "DetailsPage";
            DetailsPage.Padding = new Padding(4, 3, 4, 3);
            DetailsPage.Size = new System.Drawing.Size(350, 140);
            DetailsPage.TabIndex = 0;
            DetailsPage.Text = "Details";
            DetailsPage.UseVisualStyleBackColor = true;
            // 
            // DetailsBox
            // 
            DetailsBox.AcceptsReturn = true;
            DetailsBox.AcceptsTab = true;
            DetailsBox.Dock = DockStyle.Fill;
            DetailsBox.Location = new System.Drawing.Point(4, 3);
            DetailsBox.Margin = new Padding(4, 3, 4, 3);
            DetailsBox.Multiline = true;
            DetailsBox.Name = "DetailsBox";
            DetailsBox.ScrollBars = ScrollBars.Vertical;
            DetailsBox.Size = new System.Drawing.Size(342, 134);
            DetailsBox.TabIndex = 0;
            // 
            // OKBtn
            // 
            OKBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            OKBtn.DialogResult = DialogResult.OK;
            OKBtn.Location = new System.Drawing.Point(190, 220);
            OKBtn.Margin = new Padding(4, 3, 4, 3);
            OKBtn.Name = "OKBtn";
            OKBtn.Size = new System.Drawing.Size(88, 27);
            OKBtn.TabIndex = 3;
            OKBtn.Text = "OK";
            OKBtn.UseVisualStyleBackColor = true;
            OKBtn.Click += OKBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CancelBtn.DialogResult = DialogResult.Cancel;
            CancelBtn.Location = new System.Drawing.Point(285, 220);
            CancelBtn.Margin = new Padding(4, 3, 4, 3);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new System.Drawing.Size(88, 27);
            CancelBtn.TabIndex = 4;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = true;
            // 
            // HeaderBox
            // 
            HeaderBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            HeaderBox.AutoCompleteMode = AutoCompleteMode.Append;
            HeaderBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            HeaderBox.FormattingEnabled = true;
            HeaderBox.Location = new System.Drawing.Point(74, 14);
            HeaderBox.Margin = new Padding(4, 3, 4, 3);
            HeaderBox.Name = "HeaderBox";
            HeaderBox.Size = new System.Drawing.Size(298, 23);
            HeaderBox.Sorted = true;
            HeaderBox.TabIndex = 1;
            // 
            // SectionForm
            // 
            AcceptButton = OKBtn;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CancelBtn;
            ClientSize = new System.Drawing.Size(386, 261);
            Controls.Add(HeaderBox);
            Controls.Add(CancelBtn);
            Controls.Add(OKBtn);
            Controls.Add(Pages);
            Controls.Add(HeaderLbl);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MinimizeBox = false;
            Name = "SectionForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Section";
            Pages.ResumeLayout(false);
            DetailsPage.ResumeLayout(false);
            DetailsPage.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        private System.Windows.Forms.Label HeaderLbl;
        private System.Windows.Forms.TabControl Pages;
        private System.Windows.Forms.TabPage DetailsPage;
        private System.Windows.Forms.TextBox DetailsBox;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.ComboBox HeaderBox;
    }
}
