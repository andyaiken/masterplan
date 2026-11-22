#nullable disable

using Masterplan.Data;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Masterplan.Tools
{
    /// <summary>
    /// Helpers for showing an encounter's traps on its map.
    /// </summary>
    /// <remarks>
    /// BACKGROUND FOR NEW DEVELOPERS:
    /// Before M14.1 traps could not be placed on a map at all: the map control (Controls/MapView.cs)
    /// only knows creature tokens, heroes and custom tokens/overlays. Rather than teach MapView a new
    /// kind of token, a trap is placed as an ordinary custom OVERLAY whose CustomToken.TrapID links it
    /// to the trap. That way everything overlays already support works for traps for free: any size,
    /// drag, resize, save with the encounter, and hide from the player view until revealed.
    ///
    /// Where this is used:
    ///   - EncounterBuilderForm, map tab: a "Traps" group lists traps that have no overlay yet.
    ///   - CombatForm, Templates palette: a "Traps" group lists every trap of the encounter.
    /// Both create the overlay with CreateOverlay and add it to Encounter.CustomTokens when it is
    /// dropped on the map.
    ///
    /// A trap may have more than one overlay (e.g. a trap that covers two separate zones).
    /// </remarks>
    static class TrapOverlays
    {
        /// <summary>
        /// Creates a new, not yet placed overlay for <paramref name="trap"/>.
        /// </summary>
        /// <remarks>
        /// The overlay starts HIDDEN from the player view (Data.Visible = false), because traps are
        /// usually unknown to the players until they are triggered or spotted. The DM reveals it with
        /// the normal Visible toggle in combat. It starts as a 1x1 square; the size and colour can be
        /// changed in the normal overlay editor (double-click it in the encounter builder).
        /// </remarks>
        public static CustomToken CreateOverlay(Trap trap)
        {
            CustomToken overlay = new CustomToken();

            overlay.Type = CustomTokenType.Overlay;
            overlay.Name = trap.Name;
            overlay.TrapID = trap.ID;

            overlay.OverlaySize = new Size(1, 1);
            overlay.OverlayStyle = OverlayStyle.Rounded;   // translucent, so the map shows through
            overlay.Colour = Color.DarkRed;

            // Not on the map yet: the drop on the map sets the real location.
            overlay.Data.Location = CombatData.NoPoint;

            // Start hidden from the players.
            overlay.Data.Visible = false;

            return overlay;
        }

        /// <summary>True if <paramref name="overlay"/> marks a trap (rather than being an ordinary overlay).</summary>
        public static bool IsTrapOverlay(CustomToken overlay)
        {
            return (overlay != null) && (overlay.TrapID != Guid.Empty);
        }

        /// <summary>True if the encounter already has at least one overlay for <paramref name="trap"/>.</summary>
        public static bool HasOverlay(Encounter encounter, Trap trap)
        {
            if ((encounter == null) || (trap == null))
                return false;

            foreach (CustomToken ct in encounter.CustomTokens)
            {
                if (ct.TrapID == trap.ID)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Finds the trap that <paramref name="overlay"/> marks.
        /// </summary>
        /// <returns>The trap, or null if it is not a trap overlay or the trap is no longer in the encounter.</returns>
        public static Trap FindTrap(Encounter encounter, CustomToken overlay)
        {
            if ((encounter == null) || !IsTrapOverlay(overlay))
                return null;

            return encounter.FindTrap(overlay.TrapID);
        }

        /// <summary>
        /// Removes every overlay of the trap with ID <paramref name="trap_id"/> from the encounter.
        /// Call this whenever a trap is removed from an encounter, so no orphaned overlay is left on the map.
        /// </summary>
        public static void RemoveOverlays(Encounter encounter, Guid trap_id)
        {
            if ((encounter == null) || (trap_id == Guid.Empty))
                return;

            List<CustomToken> obsolete = new List<CustomToken>();
            foreach (CustomToken ct in encounter.CustomTokens)
            {
                if (ct.TrapID == trap_id)
                    obsolete.Add(ct);
            }

            foreach (CustomToken ct in obsolete)
                encounter.CustomTokens.Remove(ct);
        }
    }
}
