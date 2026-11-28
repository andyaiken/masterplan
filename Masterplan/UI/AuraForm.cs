#nullable disable

using Masterplan.Data;
using Masterplan.Tools;
using System;
using System.Windows.Forms;

namespace Masterplan.UI
{
    partial class AuraForm : Form
    {
        public AuraForm(Aura aura)
        {
            InitializeComponent();

            fAura = aura.Copy();

            NameBox.Text = fAura.Name;
            // The keywords of their own field and any written in the details (14.1.1.2; see Aura).
            KeywordBox.Text = fAura.ShownKeywords;
            // A stored radius above the box's usual limit is shown too, instead of failing.
            NumericBoxes.ShowValue(SizeBox, fAura.Radius);
            DetailsBox.Text = fAura.Description;

            // Remember what the boxes show, so that OK can tell whether the user changed them.
            // Read back from the boxes, because a box may not hold a value exactly as it was given.
            fShownKeywords = KeywordBox.Text;
            fShownRadius = SizeBox.Value;
            fShownDetails = DetailsBox.Text;
        }

        public Aura Aura
        {
            get { return fAura; }
        }
        Aura fAura = null;

        readonly string fShownKeywords;
        readonly decimal fShownRadius;
        readonly string fShownDetails;

        private void OKBtn_Click(object sender, EventArgs e)
        {
            fAura.Name = NameBox.Text;

            // With the other three boxes unchanged, the stored keywords and details stay exactly as
            // they were (14.1.1.2: until then OK rebuilt the details and could delete text).
            if ((KeywordBox.Text == fShownKeywords) && (SizeBox.Value == fShownRadius) && (DetailsBox.Text == fShownDetails))
                return;

            string keywords = KeywordBox.Text;
            int radius = (int)SizeBox.Value;
            string details = DetailsBox.Text;

            // Details that begin like the rule books, "(Fire) aura 3; ..." (typed or pasted), are
            // taken apart: the keywords join the Keywords field, the number is the radius unless the
            // user changed the Size box, and only the rest stays in the details. Repeated, in case
            // such a start was pasted twice.
            string found_keywords;
            int found_radius;
            string rest;
            bool use_found_radius = (SizeBox.Value == fShownRadius);
            while (Aura.TryReadLabelledStart(details, out found_keywords, out found_radius, out rest))
            {
                keywords = Aura.MergeKeywords(keywords, found_keywords);
                if (use_found_radius)
                {
                    radius = found_radius;
                    use_found_radius = false; // the first number found counts
                }
                details = rest;
            }

            fAura.Keywords = keywords;
            // (Writing the details also makes the aura read them again.)
            fAura.Details = radius + ": " + details;
        }
    }
}
