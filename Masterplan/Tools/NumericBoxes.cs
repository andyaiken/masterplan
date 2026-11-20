#nullable disable

using System.Windows.Forms;

namespace Masterplan.Tools
{
    /// <summary>
    /// Helpers for number boxes (NumericUpDown).
    /// </summary>
    static class NumericBoxes
    {
        /// <summary>
        /// Shows a stored value in a number box. If the value is outside the box's range, the range is
        /// widened to include it, so the value is shown (and saved again) exactly as it is.
        /// </summary>
        /// <remarks>
        /// Added in 14.1.0.16. A NumericUpDown throws when its Value is set outside Minimum..Maximum, and
        /// several level changes have no limit: Plot > Advanced > Adjust Difficulty can raise a quest or
        /// a skill challenge above 30, and Level Up / Down in the Creature Builder can take a creature
        /// above 40 or below 1. Opening such an item crashed its form. Widening the range (instead of
        /// clamping the value) never changes the user's data.
        /// </remarks>
        /// <param name="box">The number box.</param>
        /// <param name="value">The stored value to show.</param>
        public static void ShowValue(NumericUpDown box, int value)
        {
            if (value > box.Maximum)
                box.Maximum = value;

            if (value < box.Minimum)
                box.Minimum = value;

            box.Value = value;
        }
    }
}
