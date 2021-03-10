using System;
using System.Collections.Generic;

using Masterplan.Data;

namespace Masterplan
{
	class HeroData
	{
		public HeroData(RaceData rd, ClassData cd)
		{
			Race = rd;
			Class = cd;
		}

		public RaceData Race;
		public ClassData Class;

		public static HeroData Create()
		{
			// Select a class candidate
			int class_index = Session.Random.Next() % Sourcebook.Classes.Count;
			ClassData selected_class = Sourcebook.Classes[class_index];

			// Select a race candidate
			int race_index = Session.Random.Next() % Sourcebook.Races.Count;
			RaceData selected_race = Sourcebook.Races[race_index];

			return new HeroData(selected_race, selected_class);
		}

		public Hero ConvertToHero()
		{
			Hero hero = new Hero();

			hero.Name = Race.Name + " " + Class.Name;
			hero.Class = Class.Name;
			hero.Role = Class.Role;
			hero.PowerSource = Class.PowerSource.ToString();
			hero.Race = Race.Name;

			return hero;
		}
	}

	class HeroGroup
	{
		public static HeroGroup CreateGroup(int size)
		{
			HeroGroup group = new HeroGroup();

			int fails = 0;
			while (group.Heroes.Count != size)
			{
				HeroData hero = group.Suggest();
				if (hero != null)
				{
					group.Heroes.Add(hero);
				}
				else
				{
					fails += 1;
				}

				if (fails >= 100)
					return CreateGroup(size - 1);
			}

			return group;
		}

		public HeroData Suggest()
		{
			// What type of class do we need?
			List<PowerSource> power_sources = RequiredPowerSources;
			List<PrimaryAbility> abilities = RequiredAbilities;
			List<HeroRoleType> roles = RequiredRoles;

			// Make up a class candidate list
			List<ClassData> class_candidates = Sourcebook.Filter(power_sources, abilities, roles);
			if (class_candidates.Count == 0)
			{
				// Try without the ability score restriction
				class_candidates = Sourcebook.Filter(power_sources, new List<PrimaryAbility>(), roles);

				if (class_candidates.Count == 0)
					return null;
			}

			// Remove classes we already have
			List<ClassData> obsolete_classes = new List<ClassData>();
			foreach (ClassData cd in class_candidates)
			{
				if (Contains(cd))
					obsolete_classes.Add(cd);
			}
			if (obsolete_classes.Count != class_candidates.Count)
			{
				foreach (ClassData cd in obsolete_classes)
					class_candidates.Remove(cd);
			}

			// Select a class candidate
			int class_index = Session.Random.Next() % class_candidates.Count;
			ClassData selected_class = class_candidates[class_index];

			// Make up a race candidate list
			List<RaceData> race_candidates = Sourcebook.Filter(selected_class.KeyAbility);
			if (race_candidates.Count == 0)
				return null;

			// Remove races we already have
			List<RaceData> obsolete_races = new List<RaceData>();
			foreach (RaceData rd in race_candidates)
			{
				if (Contains(rd))
					obsolete_races.Add(rd);
			}
			if (obsolete_races.Count != race_candidates.Count)
			{
				foreach (RaceData rd in obsolete_races)
					race_candidates.Remove(rd);
			}

			// Select a race candidate
			int race_index = Session.Random.Next() % race_candidates.Count;
			RaceData selected_race = race_candidates[race_index];

			return new HeroData(selected_race, selected_class);
		}

		public List<HeroData> Heroes = new List<HeroData>();

		public bool Contains(ClassData cd)
		{
			foreach (HeroData hero in Heroes)
			{
				if (hero.Class == cd)
					return true;
			}

			return false;
		}

		public bool Contains(RaceData rd)
		{
			foreach (HeroData hero in Heroes)
			{
				if (hero.Race == rd)
					return true;
			}

			return false;
		}

		public int Count(PowerSource power_source)
		{
			int count = 0;

			foreach (HeroData hero in Heroes)
			{
				if (hero.Class == null)
					continue;

				if (hero.Class.PowerSource == power_source)
					count += 1;
			}

			return count;
		}

		public int Count(PrimaryAbility key_ability)
		{
			int count = 0;

			foreach (HeroData hero in Heroes)
			{
				if (hero.Class == null)
					continue;

				if (hero.Class.KeyAbility == key_ability)
					count += 1;
			}

			return count;
		}

		public int Count(HeroRoleType role)
		{
			int count = 0;

			foreach (HeroData hero in Heroes)
			{
				if (hero.Class == null)
					continue;

				if (hero.Class.Role == role)
					count += 1;
			}

			return count;
		}

		public List<PowerSource> RequiredPowerSources
		{
			get
			{
				Array power_sources = Enum.GetValues(typeof(PowerSource));

				int min = int.MaxValue;
				foreach (PowerSource power_source in power_sources)
				{
					int count = Count(power_source);
					if (count < min)
						min = count;
				}

				List<PowerSource> required = new List<PowerSource>();
				foreach (PowerSource power_source in power_sources)
				{
					int count = Count(power_source);
					if (count == min)
						required.Add(power_source);
				}

				return required;
			}
		}

		public List<PrimaryAbility> RequiredAbilities
		{
			get
			{
				Array abilities = Enum.GetValues(typeof(PrimaryAbility));

				int min = int.MaxValue;
				foreach (PrimaryAbility ability in abilities)
				{
					int count = Count(ability);
					if (count < min)
						min = count;
				}

				List<PrimaryAbility> required = new List<PrimaryAbility>();
				foreach (PrimaryAbility ability in abilities)
				{
					int count = Count(ability);
					if (count == min)
						required.Add(ability);
				}

				return required;
			}
		}

		public List<HeroRoleType> RequiredRoles
		{
			get
			{
				Array roles = Enum.GetValues(typeof(HeroRoleType));

				int min = int.MaxValue;
				foreach (HeroRoleType role in roles)
				{
					int count = Count(role);
					if (count < min)
						min = count;
				}

				List<HeroRoleType> required = new List<HeroRoleType>();
				foreach (HeroRoleType role in roles)
				{
					if (role == HeroRoleType.Hybrid)
						continue;

					int count = Count(role);
					if (count == min)
						required.Add(role);
				}

				return required;
			}
		}
	}

	enum PowerSource
	{
		Martial,
		Arcane,
		Divine,
		Primal,
		Psionic,
		Shadow
	}

	enum PrimaryAbility
	{
		Strength,
		Constitution,
		Dexterity,
		Intelligence,
		Wisdom,
		Charisma
	}

	class ClassData
	{
		public ClassData(string name, PowerSource power_source, PrimaryAbility key_ability, HeroRoleType role)
		{
			Name = name;
			PowerSource = power_source;
			KeyAbility = key_ability;
			Role = role;
		}

		public string Name = "";
		public PowerSource PowerSource = PowerSource.Martial;
		public PrimaryAbility KeyAbility = PrimaryAbility.Strength;
		public HeroRoleType Role = HeroRoleType.Controller;

		public override string ToString()
		{
			return Name;
		}
	}

	class RaceData
	{
		public RaceData(string name, PrimaryAbility[] abilities)
		{
			Name = name;
			Abilities = new List<PrimaryAbility>(abilities);
		}

		public string Name = "";
		public List<PrimaryAbility> Abilities = null;

		public override string ToString()
		{
			return Name;
		}
	}

	class Sourcebook
	{
		public static List<ClassData> Classes
		{
			get
			{
				if (all_classes == null)
				{
					all_classes = new List<ClassData>();

					all_classes.Add(new ClassData("Cleric", PowerSource.Divine, PrimaryAbility.Wisdom, HeroRoleType.Leader));
					all_classes.Add(new ClassData("Cleric", PowerSource.Divine, PrimaryAbility.Strength, HeroRoleType.Leader));
					all_classes.Add(new ClassData("Fighter", PowerSource.Martial, PrimaryAbility.Strength, HeroRoleType.Defender));
					all_classes.Add(new ClassData("Paladin", PowerSource.Divine, PrimaryAbility.Strength, HeroRoleType.Defender));
					all_classes.Add(new ClassData("Paladin", PowerSource.Divine, PrimaryAbility.Charisma, HeroRoleType.Defender));
					all_classes.Add(new ClassData("Ranger", PowerSource.Martial, PrimaryAbility.Strength, HeroRoleType.Striker));
					all_classes.Add(new ClassData("Ranger", PowerSource.Martial, PrimaryAbility.Dexterity, HeroRoleType.Striker));
					all_classes.Add(new ClassData("Rogue", PowerSource.Martial, PrimaryAbility.Dexterity, HeroRoleType.Striker));
					all_classes.Add(new ClassData("Warlock", PowerSource.Arcane, PrimaryAbility.Charisma, HeroRoleType.Striker));
					all_classes.Add(new ClassData("Warlord", PowerSource.Martial, PrimaryAbility.Strength, HeroRoleType.Leader));
					all_classes.Add(new ClassData("Wizard", PowerSource.Arcane, PrimaryAbility.Intelligence, HeroRoleType.Controller));

					all_classes.Add(new ClassData("Avenger", PowerSource.Divine, PrimaryAbility.Wisdom, HeroRoleType.Striker));
					all_classes.Add(new ClassData("Barbarian", PowerSource.Primal, PrimaryAbility.Strength, HeroRoleType.Striker));
					all_classes.Add(new ClassData("Bard", PowerSource.Arcane, PrimaryAbility.Charisma, HeroRoleType.Leader));
					all_classes.Add(new ClassData("Druid", PowerSource.Primal, PrimaryAbility.Wisdom, HeroRoleType.Controller));
					all_classes.Add(new ClassData("Invoker", PowerSource.Divine, PrimaryAbility.Wisdom, HeroRoleType.Controller));
					all_classes.Add(new ClassData("Shaman", PowerSource.Primal, PrimaryAbility.Wisdom, HeroRoleType.Leader));
					all_classes.Add(new ClassData("Sorcerer", PowerSource.Arcane, PrimaryAbility.Charisma, HeroRoleType.Striker));
					all_classes.Add(new ClassData("Warden", PowerSource.Primal, PrimaryAbility.Strength, HeroRoleType.Defender));

					all_classes.Add(new ClassData("Ardent", PowerSource.Psionic, PrimaryAbility.Charisma, HeroRoleType.Leader));
					all_classes.Add(new ClassData("Battlemind", PowerSource.Psionic, PrimaryAbility.Constitution, HeroRoleType.Defender));
					all_classes.Add(new ClassData("Monk", PowerSource.Psionic, PrimaryAbility.Dexterity, HeroRoleType.Striker));
					all_classes.Add(new ClassData("Psion", PowerSource.Psionic, PrimaryAbility.Intelligence, HeroRoleType.Controller));
					all_classes.Add(new ClassData("Runepriest", PowerSource.Divine, PrimaryAbility.Strength, HeroRoleType.Leader));
					all_classes.Add(new ClassData("Seeker", PowerSource.Primal, PrimaryAbility.Wisdom, HeroRoleType.Controller));

					all_classes.Add(new ClassData("Artificer", PowerSource.Arcane, PrimaryAbility.Intelligence, HeroRoleType.Leader));
					all_classes.Add(new ClassData("Assassin", PowerSource.Shadow, PrimaryAbility.Dexterity, HeroRoleType.Striker));
					all_classes.Add(new ClassData("Swordmage", PowerSource.Arcane, PrimaryAbility.Intelligence, HeroRoleType.Defender));
					all_classes.Add(new ClassData("Vampire", PowerSource.Shadow, PrimaryAbility.Dexterity, HeroRoleType.Striker));
				}

				return all_classes;
			}
		}
		static List<ClassData> all_classes = null;

		public static List<RaceData> Races
		{
			get
			{
				if (all_races == null)
				{
					all_races = new List<RaceData>();

					all_races.Add(new RaceData("Dragonborn", new PrimaryAbility[] { PrimaryAbility.Charisma, PrimaryAbility.Strength }));
					all_races.Add(new RaceData("Dwarf", new PrimaryAbility[] { PrimaryAbility.Constitution, PrimaryAbility.Wisdom }));
					all_races.Add(new RaceData("Eladrin", new PrimaryAbility[] { PrimaryAbility.Dexterity, PrimaryAbility.Intelligence }));
					all_races.Add(new RaceData("Elf", new PrimaryAbility[] { PrimaryAbility.Dexterity, PrimaryAbility.Wisdom }));
					all_races.Add(new RaceData("Half-Elf", new PrimaryAbility[] { PrimaryAbility.Charisma, PrimaryAbility.Constitution }));
					all_races.Add(new RaceData("Halfling", new PrimaryAbility[] { PrimaryAbility.Charisma, PrimaryAbility.Dexterity }));
					all_races.Add(new RaceData("Human", new PrimaryAbility[] { PrimaryAbility.Strength, PrimaryAbility.Constitution, PrimaryAbility.Dexterity, PrimaryAbility.Intelligence, PrimaryAbility.Wisdom, PrimaryAbility.Charisma }));
					all_races.Add(new RaceData("Tiefling", new PrimaryAbility[] { PrimaryAbility.Charisma, PrimaryAbility.Intelligence }));

					all_races.Add(new RaceData("Deva", new PrimaryAbility[] { PrimaryAbility.Intelligence, PrimaryAbility.Wisdom }));
					all_races.Add(new RaceData("Gnome", new PrimaryAbility[] { PrimaryAbility.Charisma, PrimaryAbility.Intelligence }));
					all_races.Add(new RaceData("Goliath", new PrimaryAbility[] { PrimaryAbility.Constitution, PrimaryAbility.Strength }));
					all_races.Add(new RaceData("Half-Orc", new PrimaryAbility[] { PrimaryAbility.Dexterity, PrimaryAbility.Strength }));
					all_races.Add(new RaceData("Longtooth Shifter", new PrimaryAbility[] { PrimaryAbility.Strength, PrimaryAbility.Wisdom }));
					all_races.Add(new RaceData("Razorclaw Shifter", new PrimaryAbility[] { PrimaryAbility.Dexterity, PrimaryAbility.Wisdom }));

					all_races.Add(new RaceData("Githzerai", new PrimaryAbility[] { PrimaryAbility.Wisdom, PrimaryAbility.Dexterity, PrimaryAbility.Intelligence }));
					all_races.Add(new RaceData("Minotaur", new PrimaryAbility[] { PrimaryAbility.Strength, PrimaryAbility.Constitution, PrimaryAbility.Wisdom }));
					all_races.Add(new RaceData("Shardmind", new PrimaryAbility[] { PrimaryAbility.Intelligence, PrimaryAbility.Charisma, PrimaryAbility.Wisdom }));
					all_races.Add(new RaceData("Wilden", new PrimaryAbility[] { PrimaryAbility.Wisdom, PrimaryAbility.Constitution, PrimaryAbility.Dexterity }));

					all_races.Add(new RaceData("Drow", new PrimaryAbility[] { PrimaryAbility.Charisma, PrimaryAbility.Dexterity }));
					all_races.Add(new RaceData("Genasi", new PrimaryAbility[] { PrimaryAbility.Intelligence, PrimaryAbility.Strength }));

					all_races.Add(new RaceData("Changeling", new PrimaryAbility[] { PrimaryAbility.Charisma, PrimaryAbility.Dexterity, PrimaryAbility.Intelligence }));
					all_races.Add(new RaceData("Kalashtar", new PrimaryAbility[] { PrimaryAbility.Charisma, PrimaryAbility.Wisdom }));
					all_races.Add(new RaceData("Warforged", new PrimaryAbility[] { PrimaryAbility.Constitution, PrimaryAbility.Strength }));

					all_races.Add(new RaceData("Revenant", new PrimaryAbility[] { PrimaryAbility.Constitution, PrimaryAbility.Dexterity }));
					all_races.Add(new RaceData("Shadar-kai", new PrimaryAbility[] { PrimaryAbility.Dexterity, PrimaryAbility.Intelligence }));

					all_races.Add(new RaceData("Shade", new PrimaryAbility[] { PrimaryAbility.Dexterity, PrimaryAbility.Charisma }));
					all_races.Add(new RaceData("Vryloka", new PrimaryAbility[] { PrimaryAbility.Dexterity, PrimaryAbility.Charisma }));
				}

				return all_races;
			}
		}
		static List<RaceData> all_races = null;

		public static List<ClassData> Filter(List<PowerSource> power_sources, List<PrimaryAbility> abilities, List<HeroRoleType> roles)
		{
			List<ClassData> classes = new List<ClassData>();

			foreach (ClassData cd in Classes)
			{
				if ((power_sources.Count != 0) && (!power_sources.Contains(cd.PowerSource)))
					continue;

				if ((abilities.Count != 0) && (!abilities.Contains(cd.KeyAbility)))
					continue;

				if ((roles.Count != 0) && (!roles.Contains(cd.Role)))
					continue;

				classes.Add(cd);
			}

			return classes;
		}

		public static List<RaceData> Filter(PrimaryAbility ability)
		{
			List<RaceData> races = new List<RaceData>();

			foreach (RaceData rd in Races)
			{
				if (rd.Abilities.Contains(ability))
					races.Add(rd);
			}

			return races;
		}

		public static ClassData GetClass(string name)
		{
			foreach (ClassData cd in Classes)
			{
				if (cd.Name == name)
					return cd;
			}

			return null;
		}

		public static RaceData GetRace(string name)
		{
			foreach (RaceData rd in Races)
			{
				if (rd.Name == name)
					return rd;
			}

			return null;
		}
	}
}
