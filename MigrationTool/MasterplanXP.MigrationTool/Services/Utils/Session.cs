#nullable disable

using System;
using System.Collections.Generic;
using MasterplanXP.MigrationTool.Models.Legacy;

namespace MasterplanXP.MigrationTool.Services.Utils
{
    public enum SearchType
    {
        Project,
        External,
        Global
    }

    /// <summary>
    /// A thinned-down version of the legacy Session class.
    /// Provides stubs and basic utilities to allow legacy models to compile and run 
    /// within the context of the migration tool.
    /// </summary>
    public static class Session
    {
        private static Random _random = new Random();

        public static Project Project { get; set; }

        public static SessionPreferences Preferences { get; set; } = new SessionPreferences();

        public static List<MagicItem> MagicItems { get; set; } = new List<MagicItem>();
        public static List<Artifact> Artifacts { get; set; } = new List<Artifact>();

        /// <summary>
        /// Stub for finding a creature. 
        /// </summary>
        public static ICreature FindCreature(Guid id, SearchType type)
        {
            return null;
        }

        /// <summary>
        /// Stub for finding a magic item.
        /// </summary>
        public static MagicItem FindMagicItem(Guid id, SearchType type)
        {
            return null;
        }

        /// <summary>
        /// Stub for finding an artifact.
        /// </summary>
        public static Artifact FindArtifact(Guid id, SearchType type)
        {
            return null;
        }

        /// <summary>
        /// Stub for finding a theme.
        /// </summary>
        public static MonsterTheme FindTheme(Guid id, SearchType type)
        {
            return null;
        }

        /// <summary>
        /// Stub for finding a library.
        /// </summary>
        public static Library FindLibrary(Guid id)
        {
            return null;
        }

        /// <summary>
        /// Stub for finding a library for a creature.
        /// </summary>
        public static Library FindLibrary(ICreature c)
        {
            return null;
        }

        /// <summary>
        /// Stub for finding a library for a template.
        /// </summary>
        public static Library FindLibrary(CreatureTemplate ct)
        {
            return null;
        }

        /// <summary>
        /// Stub for finding a template.
        /// </summary>
        public static CreatureTemplate FindTemplate(Guid id, SearchType type)
        {
            return null;
        }

        /// <summary>
        /// Stub for finding a trap.
        /// </summary>
        public static Trap FindTrap(Guid id, SearchType type)
        {
            return null;
        }

        /// <summary>
        /// Stub for finding a skill challenge.
        /// </summary>
        public static SkillChallenge FindSkillChallenge(Guid id, SearchType type)
        {
            return null;
        }

        /// <summary>
        /// Stub for finding a tile.
        /// </summary>
        public static Tile FindTile(Guid id, SearchType type)
        {
            return null;
        }

        /// <summary>
        /// Legacy DPI adjustment for images.
        /// </summary>
        public static void SetResolution(System.Drawing.Image img)
        {
            if (img is System.Drawing.Bitmap bmp)
            {
                try
                {
                    float x_dpi = Math.Min(bmp.HorizontalResolution, 96);
                    float y_dpi = Math.Min(bmp.VerticalResolution, 96);
                    bmp.SetResolution(x_dpi, y_dpi);
                }
                catch { }
            }
        }

        /// <summary>
        /// Legacy dice rolling utility.
        /// </summary>
        public static int Dice(int count, int sides)
        {
            int num = 0;
            for (int i = 0; i < count; i++)
            {
                num += _random.Next(1, sides + 1);
            }
            return num;
        }

        /// <summary>
        /// Access to the random number generator.
        /// </summary>
        public static Random Random => _random;
    }
}
