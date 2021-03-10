using System;
using System.Collections.Generic;

using Utils;

namespace Masterplan.Data
{
    /// <summary>
    /// Class representing a theme which can be applied to groups of monsters.
    /// </summary>
    [Serializable]
    public class MonsterTheme
    {
        /// <summary>
        /// Gets or sets the unique ID of the monster theme.
        /// </summary>
        public Guid ID
        {
            get { return fID; }
            set { fID = value; }
        }
        Guid fID = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the name of the monster theme.
        /// </summary>
        public string Name
        {
            get { return fName; }
            set { fName = value; }
        }
        string fName = "";

        /// <summary>
        /// Gets or sets the list of skill bonuses.
        /// </summary>
        public List<Pair<string, int>> SkillBonuses
        {
            get { return fSkillBonuses; }
            set { fSkillBonuses = value; }
        }
        List<Pair<string, int>> fSkillBonuses = new List<Pair<string, int>>();

        /// <summary>
        /// Gets or sets the list of theme powers.
        /// </summary>
        public List<ThemePowerData> Powers
        {
            get { return fPowers; }
            set { fPowers = value; }
        }
        List<ThemePowerData> fPowers = new List<ThemePowerData>();

        /// <summary>
        /// Finds the power with the specified ID.
        /// </summary>
        /// <param name="power_id">The ID to search for.</param>
        /// <returns>Returns the power if it exists; null otherwise.</returns>
		public ThemePowerData FindPower(Guid power_id)
        {
            foreach (ThemePowerData tpd in fPowers)
            {
                if (tpd.Power.ID == power_id)
                    return tpd;
            }

            return null;
        }

		/// <summary>
		/// Returns a list of the powers that fit the specified roles.
		/// </summary>
		/// <param name="creature_roles">The roles to fit.</param>
		/// <param name="type">The power type to list (attack or utility).</param>
		/// <returns>Returns a list of matching powers.</returns>
		public List<ThemePowerData> ListPowers(List<RoleType> creature_roles, PowerType type)
        {
			List<ThemePowerData> candidates = new List<ThemePowerData>();

            foreach (ThemePowerData power in fPowers)
            {
				if (power.Type != type)
                    continue;

				if (power.Roles.Count == 0)
				{
					candidates.Add(power);
				}
				else
				{
					bool match = false;
					foreach (RoleType role in creature_roles)
					{
						if (power.Roles.Contains(role))
							match = true;
					}

					if (match)
						candidates.Add(power);
				}
            }

			return candidates;
        }

        /// <summary>
        /// Creates a copy of the monster theme.
        /// </summary>
        /// <returns>Returns the copy.</returns>
        public MonsterTheme Copy()
        {
            MonsterTheme mt = new MonsterTheme();

            mt.ID = fID;
            mt.Name = fName;

            foreach (Pair<string, int> sb in fSkillBonuses)
                mt.SkillBonuses.Add(new Pair<string, int>(sb.First, sb.Second));

            foreach (ThemePowerData tpd in fPowers)
                mt.Powers.Add(tpd.Copy());

            return mt;
        }

        /// <summary>
        /// Returns the theme name.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return fName;
        }
    }

	/// <summary>
	/// Power types.
	/// </summary>
	public enum PowerType
	{
		/// <summary>
		/// Attack power.
		/// </summary>
		Attack,

		/// <summary>
		/// Utility power.
		/// </summary>
		Utility
	}

    /// <summary>
    /// Class representing a power in a monster theme.
    /// </summary>
    [Serializable]
    public class ThemePowerData
    {
        /// <summary>
        /// Gets or sets the power.
        /// </summary>
        public CreaturePower Power
        {
            get { return fPower; }
            set { fPower = value; }
        }
        CreaturePower fPower = new CreaturePower();

		/// <summary>
		/// Gets or sets the power type (attack or utility).
		/// </summary>
		public PowerType Type
		{
			get { return fType; }
			set { fType = value; }
		}
		PowerType fType = PowerType.Attack;

		/// <summary>
		/// Gets or sets the creature roles the power is suitable for.
		/// </summary>
		public List<RoleType> Roles
		{
			get { return fRoles; }
			set { fRoles = value; }
		}
		List<RoleType> fRoles = new List<RoleType>();

        /// <summary>
        /// Creates a copy of the power data.
        /// </summary>
        /// <returns>Returns the copy.</returns>
        public ThemePowerData Copy()
        {
            ThemePowerData tpd = new ThemePowerData();

            tpd.Power = fPower.Copy();
			tpd.Type = fType;

            foreach (RoleType rt in fRoles)
                tpd.Roles.Add(rt);

            return tpd;
        }

		/// <summary>
		/// Returns the power name.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return fPower.Name;
		}
    }
}
