using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Masterplan.Tools
{
    /// <summary>
    /// Checks that a saved window position can still be reached on the screens that are connected now.
    /// </summary>
    /// <remarks>
    /// WHY THIS EXISTS: Preferences.xml remembers where the main window was. If that was on a second
    /// monitor that has since been unplugged (or the resolution / scale changed), restoring the position
    /// puts the window completely off-screen: only the taskbar icon shows and Alt+Tab cannot bring it
    /// back. The caller (MainForm) centres the window instead when this returns false.
    /// The check is a plain function of rectangles so it can be unit tested without any screen.
    /// </remarks>
    internal static class WindowPlacement
    {
        /// <summary>How much of the title bar must be on a screen: wide enough to grab it.</summary>
        const int MinVisibleWidth = 100;

        /// <summary>The title bar strip is this tall (a bit more than a real one).</summary>
        const int TitleBarHeight = 32;

        /// <summary>The working areas (screen minus taskbar) of every connected screen.</summary>
        public static List<Rectangle> ScreenAreas()
        {
            List<Rectangle> areas = new List<Rectangle>();
            foreach (Screen screen in Screen.AllScreens)
                areas.Add(screen.WorkingArea);

            return areas;
        }

        /// <summary>
        /// True if the window's title bar (the top strip of the window) overlaps any of the screen
        /// areas by enough to be grabbed with the mouse.
        /// </summary>
        public static bool TitleBarIsOnScreen(Rectangle window, IEnumerable<Rectangle> screenAreas)
        {
            Rectangle title_bar = new Rectangle(window.X, window.Y, window.Width, TitleBarHeight);

            foreach (Rectangle area in screenAreas)
            {
                Rectangle visible = Rectangle.Intersect(title_bar, area);
                if ((visible.Width >= MinVisibleWidth) && (visible.Height >= TitleBarHeight / 2))
                    return true;
            }

            return false;
        }
    }
}
