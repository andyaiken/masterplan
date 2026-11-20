#nullable disable

using Masterplan.Data;
using System;
using System.Collections.Generic;

namespace Masterplan.Tools
{
    /// <summary>
    /// What goes on the clipboard when a plot point (MainForm) or a plot point's element
    /// (PlotPointForm) is copied: the item itself plus copies of the project items it refers to.
    /// </summary>
    /// <remarks>
    /// BACKGROUND FOR NEW DEVELOPERS:
    /// A plot point does not contain everything it shows. It refers BY ID to things that belong to
    /// the project or to the libraries:
    ///   - tactical maps (an encounter's map, a trap's or skill challenge's location, a map element),
    ///     and the TILES those maps are drawn from (tiles live in tile libraries);
    ///   - the regional map holding the plot point's location;
    ///   - the creatures in its encounters: library creatures, the project's custom creatures and
    ///     NPCs, and any templates/themes applied to them.
    /// Inside one project those IDs always resolve. Pasted into ANOTHER project (or another running
    /// copy of Masterplan with different libraries) they pointed at nothing, so maps came out blank
    /// and some plot points crashed when opened.
    ///
    /// So copying gathers those items into the bundle (Collect), and pasting adds each one to the
    /// target project ONLY IF the target cannot already find it by ID (MergeInto). Pasting inside the
    /// same project therefore adds nothing. Library items (creatures, templates, themes, tiles) are
    /// added to the project's own library (Project.Library), the same place a saved project keeps
    /// copies of the library items it uses (see Project.PopulateProjectLibrary).
    ///
    /// Not carried (they stay as references and simply show nothing in another project, without
    /// crashing): encyclopedia links, calendar dates, and the magic items/artifacts of treasure
    /// parcels (those resolve if the other copy of Masterplan has the same libraries).
    ///
    /// The bundle is turned into bytes by LibraryConversionService (BundleToBytes / BundleFromBytes,
    /// via ClipboardBundleDto) and put on the clipboard by MasterplanClipboard.
    /// </remarks>
    class ClipboardBundle
    {
        /// <summary>The copied plot point (for a plot point copy), otherwise null.</summary>
        public PlotPoint PlotPoint = null;

        /// <summary>The copied element (for a plot point element copy), otherwise null.</summary>
        public IElement Element = null;

        /// <summary>Tactical maps the item refers to.</summary>
        public List<Map> Maps = new List<Map>();

        /// <summary>Regional maps the item refers to (plot point locations).</summary>
        public List<RegionalMap> RegionalMaps = new List<RegionalMap>();

        /// <summary>Library items the item needs: creatures, templates, themes and map tiles.</summary>
        public Library Library = new Library { Name = "Clipboard" };

        /// <summary>The project's custom creatures used by the item's encounters.</summary>
        public List<CustomCreature> CustomCreatures = new List<CustomCreature>();

        /// <summary>The project's NPCs used by the item's encounters.</summary>
        public List<NPC> NPCs = new List<NPC>();

        #region Copying: gather what the item refers to

        /// <summary>Builds the bundle for copying a plot point (including all of its subplots).</summary>
        public static ClipboardBundle ForPlotPoint(PlotPoint point)
        {
            ClipboardBundle bundle = new ClipboardBundle();
            bundle.PlotPoint = point;
            bundle.collect_point(point);
            bundle.collect_tiles();
            return bundle;
        }

        /// <summary>Builds the bundle for copying a plot point's element (encounter, trap, ...).</summary>
        public static ClipboardBundle ForElement(IElement element)
        {
            ClipboardBundle bundle = new ClipboardBundle();
            bundle.Element = element;
            bundle.collect_element(element);
            bundle.collect_tiles();
            return bundle;
        }

        void collect_point(PlotPoint point)
        {
            if (point == null)
                return;

            add_regional_map(point.RegionalMapID);
            collect_element(point.Element);

            // A plot point can contain a whole subplot; gather what its points refer to as well.
            if (point.Subplot != null)
            {
                foreach (PlotPoint child in point.Subplot.Points)
                    collect_point(child);
            }
        }

        void collect_element(IElement element)
        {
            if (element is Encounter enc)
            {
                add_map(enc.MapID);

                foreach (EncounterSlot slot in enc.AllSlots)
                {
                    add_creature(slot.Card.CreatureID);
                    foreach (Guid template_id in slot.Card.TemplateIDs)
                        add_template(template_id);
                    add_theme(slot.Card.ThemeID);
                }
            }

            if (element is TrapElement te)
                add_map(te.MapID);

            if (element is MapElement me)
                add_map(me.MapID);

            if (element is SkillChallenge sc)
                add_map(sc.MapID);
        }

        void add_map(Guid map_id)
        {
            if ((map_id == Guid.Empty) || Maps.Exists(m => m.ID == map_id))
                return;

            Map map = Session.Project.FindTacticalMap(map_id);
            if (map != null)
                Maps.Add(map);
        }

        void add_regional_map(Guid map_id)
        {
            if ((map_id == Guid.Empty) || RegionalMaps.Exists(m => m.ID == map_id))
                return;

            RegionalMap map = Session.Project.FindRegionalMap(map_id);
            if (map != null)
                RegionalMaps.Add(map);
        }

        void add_creature(Guid creature_id)
        {
            if (creature_id == Guid.Empty)
                return;

            // FindCreature returns a library creature (Creature), a custom creature or an NPC;
            // each kind is kept in its own list because each goes to a different place on paste.
            ICreature creature = Session.FindCreature(creature_id, SearchType.Global);

            if (creature is CustomCreature cc)
            {
                if (!CustomCreatures.Exists(c => c.ID == cc.ID))
                    CustomCreatures.Add(cc);
            }
            else if (creature is NPC npc)
            {
                if (!NPCs.Exists(n => n.ID == npc.ID))
                    NPCs.Add(npc);

                // An NPC is built on a class template, which may come from a library.
                add_template(npc.TemplateID);
            }
            else if (creature is Creature lib_creature)
            {
                if (Library.FindCreature(lib_creature.ID) == null)
                    Library.Creatures.Add(lib_creature);
            }
        }

        void add_template(Guid template_id)
        {
            if ((template_id == Guid.Empty) || (Library.FindTemplate(template_id) != null))
                return;

            CreatureTemplate template = Session.FindTemplate(template_id, SearchType.Global);
            if (template != null)
                Library.Templates.Add(template);
        }

        void add_theme(Guid theme_id)
        {
            if ((theme_id == Guid.Empty) || Library.Themes.Exists(t => t.ID == theme_id))
                return;

            MonsterTheme theme = Session.FindTheme(theme_id, SearchType.Global);
            if (theme != null)
                Library.Themes.Add(theme);
        }

        /// <summary>The tiles every gathered map is drawn from (without them a map pastes blank).</summary>
        void collect_tiles()
        {
            foreach (Map map in Maps)
            {
                foreach (TileData td in map.Tiles)
                {
                    if ((td.TileID == Guid.Empty) || (Library.FindTile(td.TileID) != null))
                        continue;

                    Tile tile = Session.FindTile(td.TileID, SearchType.Global);
                    if (tile != null)
                        Library.Tiles.Add(tile);
                }
            }
        }

        #endregion

        #region Pasting: add what the target project is missing

        /// <summary>
        /// Adds to the current project (Session.Project) every bundled item it cannot already find
        /// by ID. Call this only when the pasted item is actually used.
        /// </summary>
        /// <returns>True if anything was added (so the project needs saving).</returns>
        public bool MergeIntoProject()
        {
            Project project = Session.Project;
            if (project == null)
                return false;

            bool added = false;

            foreach (Map map in Maps)
            {
                if (project.FindTacticalMap(map.ID) == null)
                {
                    project.Maps.Add(map);
                    added = true;
                }
            }

            foreach (RegionalMap map in RegionalMaps)
            {
                if (project.FindRegionalMap(map.ID) == null)
                {
                    project.RegionalMaps.Add(map);
                    added = true;
                }
            }

            // Creatures: Session.FindCreature(Global) looks in the loaded libraries AND in this
            // project (its library, custom creatures and NPCs), so a creature is only added if it
            // cannot be found anywhere.
            foreach (CustomCreature cc in CustomCreatures)
            {
                if (Session.FindCreature(cc.ID, SearchType.Global) == null)
                {
                    project.CustomCreatures.Add(cc);
                    added = true;
                }
            }

            foreach (NPC npc in NPCs)
            {
                if (Session.FindCreature(npc.ID, SearchType.Global) == null)
                {
                    project.NPCs.Add(npc);
                    added = true;
                }
            }

            foreach (Creature c in Library.Creatures)
            {
                if (Session.FindCreature(c.ID, SearchType.Global) == null)
                {
                    project.Library.Creatures.Add(c);
                    added = true;
                }
            }

            foreach (CreatureTemplate ct in Library.Templates)
            {
                if (Session.FindTemplate(ct.ID, SearchType.Global) == null)
                {
                    project.Library.Templates.Add(ct);
                    added = true;
                }
            }

            foreach (MonsterTheme mt in Library.Themes)
            {
                if (Session.FindTheme(mt.ID, SearchType.Global) == null)
                {
                    project.Library.Themes.Add(mt);
                    added = true;
                }
            }

            foreach (Tile tile in Library.Tiles)
            {
                if (Session.FindTile(tile.ID, SearchType.Global) == null)
                {
                    project.Library.Tiles.Add(tile);
                    added = true;
                }
            }

            return added;
        }

        #endregion
    }
}
