using System;
using System.Collections.Generic;

using Masterplan.Tools;
using System.Drawing;

namespace Masterplan.Data
{
	/// <summary>
	/// Class representing a library.
	/// </summary>
	[Serializable]
	public class Library : IComparable<Library>
	{
		/// <summary>
		/// Gets or sets the unique ID of the library.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the name of the library.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		#region Lists

		/// <summary>
		/// Gets or sets the list of creatures in the library.
		/// </summary>
		public List<Creature> Creatures
		{
			get { return fCreatures; }
			set { fCreatures = value; }
		}
		List<Creature> fCreatures = new List<Creature>();

        /// <summary>
        /// Gets or sets the list of creature templates in the library.
        /// </summary>
        public List<CreatureTemplate> Templates
        {
            get { return fTemplates; }
            set { fTemplates = value; }
        }
        List<CreatureTemplate> fTemplates = new List<CreatureTemplate>();

        /// <summary>
        /// Gets or sets the list of monster themes in the library.
        /// </summary>
        public List<MonsterTheme> Themes
        {
            get { return fThemes; }
            set { fThemes = value; }
        }
        List<MonsterTheme> fThemes = new List<MonsterTheme>();

		/// <summary>
		/// Gets or sets the list of traps in the library.
		/// </summary>
		public List<Trap> Traps
		{
			get { return fTraps; }
			set { fTraps = value; }
		}
		List<Trap> fTraps = new List<Trap>();

		/// <summary>
		/// Gets or sets the list of skill challenges in the library.
		/// </summary>
		public List<SkillChallenge> SkillChallenges
		{
			get { return fSkillChallenges; }
			set { fSkillChallenges = value; }
		}
		List<SkillChallenge> fSkillChallenges = new List<SkillChallenge>();

		/// <summary>
		/// Gets or sets the list of magic items in the library.
		/// </summary>
		public List<MagicItem> MagicItems
		{
			get { return fMagicItems; }
			set { fMagicItems = value; }
		}
		List<MagicItem> fMagicItems = new List<MagicItem>();

		/// <summary>
		/// Gets or sets the list of artifacts in the library.
		/// </summary>
		public List<Artifact> Artifacts
		{
			get { return fArtifacts; }
			set { fArtifacts = value; }
		}
		List<Artifact> fArtifacts = new List<Artifact>();

		/// <summary>
		/// Gets or sets the list of map tiles in the library.
		/// </summary>
		public List<Tile> Tiles
		{
			get { return fTiles; }
			set { fTiles = value; }
		}
		List<Tile> fTiles = new List<Tile>();

		/// <summary>
		/// Gets or sets the list of terrain powers in the library.
		/// </summary>
		public List<TerrainPower> TerrainPowers
		{
			get { return fTerrainPowers; }
			set { fTerrainPowers = value; }
		}
		List<TerrainPower> fTerrainPowers = new List<TerrainPower>();

		#endregion

		#region Finding items

		/// <summary>
		/// Finds the creature with the given ID in this library.
		/// </summary>
		/// <param name="creature_id">The ID to search for.</param>
		/// <returns>Returns the creature if it exists; null otherwise.</returns>
		public Creature FindCreature(Guid creature_id)
		{
			foreach (Creature creature in fCreatures)
			{
				if (creature == null)
					continue;

				if (creature.ID == creature_id)
					return creature;
			}

			return null;
		}

		/// <summary>
		/// Finds the creature with the given name in this library.
		/// </summary>
		/// <param name="creature_name">The name to search for.</param>
		/// <returns>Returns the creature if it exists; null otherwise.</returns>
		public Creature FindCreature(string creature_name)
		{
			foreach (Creature creature in fCreatures)
			{
				if (creature == null)
					continue;

				if (creature.Name == creature_name)
					return creature;
			}

			return null;
		}

		/// <summary>
		/// Finds the creature with the given name in this library.
		/// </summary>
		/// <param name="creature_name">The name to search for.</param>
		/// <param name="level">The level of the creature to search for.</param>
		/// <returns>Returns the creature if it exists; null otherwise.</returns>
		public Creature FindCreature(string creature_name, int level)
		{
			foreach (Creature creature in fCreatures)
			{
				if (creature == null)
					continue;

				if ((creature.Name == creature_name) && (creature.Level == level))
					return creature;
			}

			return null;
		}

        /// <summary>
        /// Finds the creature template with the given ID in this library.
        /// </summary>
        /// <param name="template_id">The ID to search for.</param>
        /// <returns>Returns the template if it exists; null otherwise.</returns>
        public CreatureTemplate FindTemplate(Guid template_id)
        {
            foreach (CreatureTemplate template in fTemplates)
            {
				if (template == null)
					continue;

				if (template.ID == template_id)
                    return template;
            }

            return null;
        }

        /// <summary>
        /// Finds the monster theme with the given ID in this library.
        /// </summary>
        /// <param name="theme_id">The ID to search for.</param>
        /// <returns>Returns the monster theme if it exists; null otherwise.</returns>
        public MonsterTheme FindTheme(Guid theme_id)
        {
            foreach (MonsterTheme theme in fThemes)
            {
				if (theme == null)
					continue;

				if (theme.ID == theme_id)
                    return theme;
            }

            return null;
        }

		/// <summary>
		/// Finds the trap with the given ID in this library.
		/// </summary>
		/// <param name="trap_id">The ID to search for.</param>
		/// <returns>Returns the trap if it exists; null otherwise.</returns>
		public Trap FindTrap(Guid trap_id)
		{
			foreach (Trap trap in fTraps)
			{
				if (trap == null)
					continue;

				if (trap.ID == trap_id)
					return trap;
			}

			return null;
		}

		/// <summary>
		/// Finds the trap with the given name in this library.
		/// </summary>
		/// <param name="trap_name">The name to search for.</param>
		/// <returns>Returns the trap if it exists; null otherwise.</returns>
		public Trap FindTrap(string trap_name)
		{
			foreach (Trap trap in fTraps)
			{
				if (trap == null)
					continue;

				if (trap.Name == trap_name)
					return trap;
			}

			return null;
		}

		/// <summary>
		/// Finds the trap with the given name in this library.
		/// </summary>
		/// <param name="trap_name">The name to search for.</param>
		/// <param name="level">The level of the trap to search for.</param>
		/// <param name="role_string">The role of the trap to search for.</param>
		/// <returns>Returns the trap if it exists; null otherwise.</returns>
		public Trap FindTrap(string trap_name, int level, string role_string)
		{
			foreach (Trap trap in fTraps)
			{
				if (trap == null)
					continue;

				if ((trap.Name == trap_name) && (trap.Level == level) && (trap.Role.ToString() == role_string))
					return trap;
			}

			return null;
		}

		/// <summary>
		/// Finds the skill challenge with the given ID in this library.
		/// </summary>
		/// <param name="sc_id">The ID to search for.</param>
		/// <returns>Returns the skill challenge if it exists; null otherwise.</returns>
		public SkillChallenge FindSkillChallenge(Guid sc_id)
		{
			foreach (SkillChallenge sc in fSkillChallenges)
			{
				if (sc == null)
					continue;

				if (sc.ID == sc_id)
					return sc;
			}

			return null;
		}

		/// <summary>
		/// Finds the magic item with the given ID in this library.
		/// </summary>
		/// <param name="item_id">The ID to search for.</param>
		/// <returns>Returns the item if it exists; null otherwise.</returns>
		public MagicItem FindMagicItem(Guid item_id)
		{
			foreach (MagicItem item in fMagicItems)
			{
				if (item == null)
					continue;

				if (item.ID == item_id)
					return item;
			}

			return null;
		}

		/// <summary>
		/// Finds the magic item with the given name in this library.
		/// </summary>
		/// <param name="item_name">The name to search for.</param>
		/// <returns>Returns the item if it exists; null otherwise.</returns>
		public MagicItem FindMagicItem(string item_name)
		{
			foreach (MagicItem item in fMagicItems)
			{
				if (item == null)
					continue;

				if (item.Name == item_name)
					return item;
			}

			return null;
		}

		/// <summary>
		/// Finds the magic item with the given ID in this library.
		/// </summary>
		/// <param name="item_name">The name to search for.</param>
		/// <param name="level">The level of the item to search for.</param>
		/// <returns>Returns the item if it exists; null otherwise.</returns>
		public MagicItem FindMagicItem(string item_name, int level)
		{
			foreach (MagicItem item in fMagicItems)
			{
				if (item == null)
					continue;

				if ((item.Name == item_name) && (item.Level == level))
					return item;
			}

			return null;
		}

		/// <summary>
		/// Finds the artifact with the given ID in this library.
		/// </summary>
		/// <param name="item_id">The ID to search for.</param>
		/// <returns>Returns the artifact if it exists; null otherwise.</returns>
		public Artifact FindArtifact(Guid item_id)
		{
			foreach (Artifact item in fArtifacts)
			{
				if (item == null)
					continue;

				if (item.ID == item_id)
					return item;
			}

			return null;
		}

		/// <summary>
		/// Finds the artifact with the given name in this library.
		/// </summary>
		/// <param name="item_name">The name to search for.</param>
		/// <returns>Returns the artifact if it exists; null otherwise.</returns>
		public Artifact FindArtifact(string item_name)
		{
			foreach (Artifact item in fArtifacts)
			{
				if (item == null)
					continue;

				if (item.Name == item_name)
					return item;
			}

			return null;
		}

		/// <summary>
		/// Finds the map tile with the given ID in this library.
		/// </summary>
		/// <param name="tile_id">The ID to search for.</param>
		/// <returns>Returns the tile if it exists; null otherwise.</returns>
		public Tile FindTile(Guid tile_id)
		{
			foreach (Tile t in fTiles)
			{
				if (t == null)
					continue;

				if (t.ID == tile_id)
					return t;
			}

			return null;
		}

		/// <summary>
		/// Finds the terrain power with the given ID in this library.
		/// </summary>
		/// <param name="item_id">The ID to search for.</param>
		/// <returns>Returns the terrain power if it exists; null otherwise.</returns>
		public TerrainPower FindTerrainPower(Guid item_id)
		{
			foreach (TerrainPower item in fTerrainPowers)
			{
				if (item == null)
					continue;

				if (item.ID == item_id)
					return item;
			}

			return null;
		}

		/// <summary>
		/// Finds the terrain power with the given name in this library.
		/// </summary>
		/// <param name="item_name">The name to search for.</param>
		/// <returns>Returns the terrain power if it exists; null otherwise.</returns>
		public TerrainPower FindTerrainPower(string item_name)
		{
			foreach (TerrainPower item in fTerrainPowers)
			{
				if (item == null)
					continue;

				if (item.Name == item_name)
					return item;
			}

			return null;
		}

		#endregion

		/// <summary>
		/// Get whether the library can be used for map autobuilding
		/// </summary>
		public bool ShowInAutoBuild
		{
			get
			{
				foreach (Tile t in fTiles)
				{
					if (t == null)
						continue;

					if ((t.Category != TileCategory.Special) && (t.Category != TileCategory.Map))
						return true;
				}

				return false;
			}
		}

		/// <summary>
		/// Compares this library to another.
		/// </summary>
		/// <param name="rhs">The other library.</param>
		/// <returns>Returns -1 if this library should be sorted before rhs,+1 if rhs should be sorted before this, 0 otherwise.</returns>
		public int CompareTo(Library rhs)
		{
			return fName.CompareTo(rhs.Name);
		}

		/// <summary>
		/// Returns the name of the library.
		/// </summary>
		/// <returns>Returns the name of the library.</returns>
		public override string ToString()
		{
			return fName;
		}

		/// <summary>
		/// Updates the library to the latest format.
		/// </summary>
		public void Update()
		{
			if (fID == Guid.Empty)
				fID = Guid.NewGuid();

			foreach (Creature c in fCreatures)
			{
				if (c == null)
					continue;

				if (c.Category == null)
					c.Category = "";

				if (c.Senses == null)
					c.Senses = "";

				if (c.Movement == null)
					c.Movement = "";

				if (c.Auras == null)
					c.Auras = new List<Aura>();

				foreach (Aura aura in c.Auras)
				{
					if (aura.Keywords == null)
						aura.Keywords = "";
				}

				if (c.CreaturePowers == null)
					c.CreaturePowers = new List<CreaturePower>();

				if (c.DamageModifiers == null)
					c.DamageModifiers = new List<DamageModifier>();

				foreach (CreaturePower cp in c.CreaturePowers)
				{
					if (cp.Condition == null)
						cp.Condition = "";

					cp.ExtractAttackDetails();
				}

				CreatureHelper.UpdateRegen(c);
				foreach (CreaturePower power in c.CreaturePowers)
					CreatureHelper.UpdatePowerRange(c, power);

				if (c.Tactics == null)
					c.Tactics = "";

				if (c.URL == null)
					c.URL = "";

				if (c.Image != null)
					Program.SetResolution(c.Image);
			}

			foreach (CreatureTemplate ct in fTemplates)
			{
				if (ct == null)
					continue;

				if (ct.Senses == null)
					ct.Senses = "";

				if (ct.Movement == null)
					ct.Movement = "";

				if (ct.Auras == null)
					ct.Auras = new List<Aura>();

				foreach (Aura aura in ct.Auras)
				{
					if (aura.Keywords == null)
						aura.Keywords = "";
				}

				if (ct.CreaturePowers == null)
					ct.CreaturePowers = new List<CreaturePower>();

				if (ct.DamageModifierTemplates == null)
					ct.DamageModifierTemplates = new List<DamageModifierTemplate>();

				foreach (CreaturePower cp in ct.CreaturePowers)
				{
					if (cp.Condition == null)
						cp.Condition = "";

					cp.ExtractAttackDetails();
				}

				if (ct.Tactics == null)
					ct.Tactics = "";
			}

            if (fThemes == null)
                fThemes = new List<MonsterTheme>();

			foreach (MonsterTheme mt in fThemes)
			{
				if (mt == null)
					continue;

				foreach (ThemePowerData tpd in mt.Powers)
					tpd.Power.ExtractAttackDetails();
			}

			if (fTraps == null)
				fTraps = new List<Trap>();

			foreach (Trap t in fTraps)
			{
				if (t.Description == null)
					t.Description = "";

				if (t.Attacks == null)
					t.Attacks = new List<TrapAttack>();
				if (t.Attack != null)
				{
					t.Attacks.Add(t.Attack);
					t.Initiative = t.Attack.HasInitiative ? t.Attack.Initiative : int.MinValue;
					t.Trigger = t.Attack.Trigger;
					t.Attack = null;
				}
				foreach (TrapAttack ta in t.Attacks)
				{
					if (ta.ID == Guid.Empty)
						ta.ID = Guid.NewGuid();

					if (ta.Name == null)
						ta.Name = "Attack";

					if (ta.Keywords == null)
						ta.Keywords = "";

					if (ta.Notes == null)
						ta.Notes = "";
				}

				if (t.Trigger == null)
					t.Trigger = "";

				foreach (TrapSkillData tsd in t.Skills)
				{
					if (tsd.ID == Guid.Empty)
						tsd.ID = Guid.NewGuid();
				}
			}

			if (fSkillChallenges == null)
				fSkillChallenges = new List<SkillChallenge>();

			foreach (SkillChallenge sc in fSkillChallenges)
			{
				if (sc.Notes == null)
					sc.Notes = "";

				foreach (SkillChallengeData scd in sc.Skills)
				{
					if (scd.Results == null)
						scd.Results = new SkillChallengeResult();
				}
			}

			if (fMagicItems == null)
				fMagicItems = new List<MagicItem>();

			if (fArtifacts == null)
				fArtifacts = new List<Artifact>();

			foreach (Tile t in fTiles)
			{
				Program.SetResolution(t.Image);

				if (t.Keywords == null)
					t.Keywords = "";
			}

			if (fTerrainPowers == null)
				fTerrainPowers = new List<TerrainPower>();
		}

		/// <summary>
		/// Imports information from another library.
		/// </summary>
		/// <param name="lib">The other library</param>
		public void Import(Library lib)
		{
			foreach (Creature c in lib.Creatures)
			{
				if (c == null)
					continue;

				if (FindCreature(c.ID) == null)
					fCreatures.Add(c);
			}

            foreach (CreatureTemplate ct in lib.Templates)
            {
				if (ct == null)
					continue;

				if (FindTemplate(ct.ID) == null)
                    fTemplates.Add(ct);
            }

            foreach (MonsterTheme mt in lib.Themes)
            {
				if (mt == null)
					continue;

				if (FindTheme(mt.ID) == null)
                    fThemes.Add(mt);
            }

			foreach (Trap t in lib.Traps)
			{
				if (t == null)
					continue;

				if (FindTrap(t.ID) == null)
					fTraps.Add(t);
			}

			foreach (SkillChallenge sc in lib.SkillChallenges)
			{
				if (sc == null)
					continue;

				if (FindSkillChallenge(sc.ID) == null)
					fSkillChallenges.Add(sc);
			}

			foreach (MagicItem item in lib.MagicItems)
			{
				if (item == null)
					continue;

				if (FindMagicItem(item.ID) == null)
					fMagicItems.Add(item);
			}

			foreach (Artifact a in lib.Artifacts)
			{
				if (a == null)
					continue;

				if (FindArtifact(a.ID) == null)
					fArtifacts.Add(a);
			}

			foreach (Tile t in lib.Tiles)
			{
				if (t == null)
					continue;

				if (FindTile(t.ID) == null)
					fTiles.Add(t);
			}
		}
	}
}
