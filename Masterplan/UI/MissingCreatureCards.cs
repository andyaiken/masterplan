#nullable disable

using Masterplan.Data;
using System.Windows.Forms;

namespace Masterplan.UI
{
    /// <summary>
    /// The messages shown when the user tries to change an encounter card whose creature cannot be
    /// found.
    /// </summary>
    /// <remarks>
    /// WHY SUCH CARDS ARE BLOCKED (for new developers): the card shows the values saved in the file
    /// (see <see cref="SavedCardValues"/>). A new level, template or theme could not be worked out
    /// without the creature, so the numbers would stay the same while the card's settings changed.
    ///
    /// HOW TO USE IT: at the start of a command that changes ONE card,
    ///     if (MissingCreatureCards.Blocks(this, card)) return;
    /// A command that changes MANY cards skips each missing one (card.CreatureMissing) and calls
    /// <see cref="ShowSomeSkipped"/> once at the end.
    /// </remarks>
    static class MissingCreatureCards
    {
        /// <summary>
        /// True if the card must not be changed; a message has then been shown.
        /// </summary>
        public static bool Blocks(IWin32Window owner, EncounterCard card)
        {
            if ((card == null) || !card.CreatureMissing)
                return false;

            Show(owner, "This card's creature can't be found, so it can't be changed.");
            return true;
        }

        /// <summary>After a command on many cards, when at least one was left unchanged.</summary>
        public static void ShowSomeSkipped(IWin32Window owner)
        {
            Show(owner, "Some cards' creatures can't be found, so those cards weren't changed.");
        }

        static void Show(IWin32Window owner, string message)
        {
            MessageBox.Show(owner, message, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
