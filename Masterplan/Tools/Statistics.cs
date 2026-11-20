#nullable disable

using Masterplan.Data;

namespace Masterplan.Tools
{
    enum DamageExpressionType
    {
        Normal,
        Multiple,
        Minion
    }

    class Statistics
    {
        /// <summary>
        /// The role type whose benefits a monster gets: a full role's type, or the type of a minion
        /// that has one ("Minion Soldier"); null for a minion without a role type (or no role).
        /// </summary>
        /// <remarks>
        /// Masterplan's design (project owner, 2026-11-19, kept even if the rules say otherwise): a
        /// minion with a role gets every benefit of that role (AC, initiative) except HP, which is
        /// always 1. Until 14.1.0.13 only a full role (ComplexRole) was looked at, so minions got no
        /// role benefits at all.
        /// </remarks>
        static RoleType? role_type(IRole role)
        {
            if (role is ComplexRole cr)
                return cr.Type;

            if ((role is Minion minion) && minion.HasRole)
                return minion.Type;

            return null;
        }

        /// <summary>The standard initiative: half the level; lurkers +4, skirmishers and soldiers +2 (minions with that role too).</summary>
        /// <param name="level">The monster's level.</param>
        /// <param name="role">Its role (a ComplexRole or a Minion), or null.</param>
        /// <returns>The standard initiative bonus, without the Dexterity modifier.</returns>
        public static int Initiative(int level, IRole role)
        {
            int score = (level / 2);

            RoleType? type = role_type(role);
            if (type != null)
            {
                switch (type.Value)
                {
                    case RoleType.Lurker:
                        score += 4;
                        break;
                    case RoleType.Skirmisher:
                    case RoleType.Soldier:
                        score += 2;
                        break;
                }
            }

            return score;
        }

        public static int HP(int level, ComplexRole role, int constitution_score)
        {
            int multiplier = 8;

            if (role != null)
            {
                switch (role.Type)
                {
                    case RoleType.Artillery:
                    case RoleType.Lurker:
                        multiplier = 6;
                        break;
                    case RoleType.Brute:
                        multiplier = 10;
                        break;
                }
            }

            int hp = constitution_score + ((level + 1) * multiplier);

            if (role != null)
            {
                switch (role.Flag)
                {
                    case RoleFlag.Elite:
                        hp *= 2;
                        break;
                    case RoleFlag.Solo:
                        hp *= 4;
                        break;
                }
            }

            return hp;
        }

        /// <summary>
        /// The standard AC for a monster of this level and role (MM3): level + 14; soldiers +2,
        /// artillery and brutes -2.
        /// </summary>
        /// <remarks>
        /// A minion with a role type ("Minion Soldier") gets that role's AC too (see role_type).
        /// </remarks>
        /// <param name="level">The monster's level.</param>
        /// <param name="role">Its role (a ComplexRole or a Minion), or null.</param>
        /// <returns>The standard AC.</returns>
        public static int AC(int level, IRole role)
        {
            int mod = 14;

            RoleType? type = role_type(role);
            if (type != null)
            {
                switch (type.Value)
                {
                    case RoleType.Artillery:
                    case RoleType.Brute:
                        mod = 12;
                        break;
                    case RoleType.Soldier:
                        mod = 16;
                        break;
                }
            }

            return level + mod;
        }

        public static int NAD(int level, IRole role)
        {
            return 12 + level;
        }

        public static int AttackBonus(DefenceType defence, int level, IRole role)
        {
            if (defence == DefenceType.AC)
            {
                return level + 5;
            }
            else
            {
                return level + 3;
            }
        }

        public static string Damage(int level, DamageExpressionType det)
        {
            if (level < 1)
                level = 1;

            switch (det)
            {
                case DamageExpressionType.Normal:
                    return NormalDamage(level);
                case DamageExpressionType.Multiple:
                    return MultipleDamage(level);
                case DamageExpressionType.Minion:
                    return MinionDamage(level).ToString();
            }

            return null;
        }

        public static string NormalDamage(int level)
        {
            switch (level)
            {
                case 1:
                    return "1d8 +4";
                case 2:
                    return "1d8 +5";
                case 3:
                    return "1d8 +6";
                case 4:
                    return "2d6 +5";
                case 5:
                    return "2d6 +6";
                case 6:
                    return "2d6 +7";
                case 7:
                    return "2d8 +6";
                case 8:
                    return "2d8 +7";
                case 9:
                    return "2d8 +8";
                case 10:
                    return "2d8 +9";
                case 11:
                    return "3d6 +9";
                case 12:
                    return "3d6 +10";
                case 13:
                    return "3d6 +11";
                case 14:
                    return "3d6 +12";
                case 15:
                    return "3d6 +13";
                case 16:
                    return "3d8 +11";
                case 17:
                    return "3d8 +12";
                case 18:
                    return "3d8 +13";
                case 19:
                    return "3d8 +14";
                case 20:
                    return "3d8 +15";
                case 21:
                    return "4d6 +15";
                case 22:
                    return "4d6 +16";
                case 23:
                    return "4d6 +17";
                case 24:
                    return "4d6 +18";
                case 25:
                    return "4d6 +19";
                case 26:
                    return "4d8 +16";
                case 27:
                    return "4d8 +17";
                case 28:
                    return "4d8 +18";
                case 29:
                    return "4d8 +19";
                case 30:
                    return "4d8 +20";
                default:
                    return "4d8 +20";
            }
        }

        public static string MultipleDamage(int level)
        {
            switch (level)
            {
                case 1:
                    return "1d6 +3";
                case 2:
                    return "1d6 +4";
                case 3:
                    return "1d6 +5";
                case 4:
                    return "1d8 +5";
                case 5:
                    return "1d8 +6";
                case 6:
                    return "1d8 +6";
                case 7:
                    return "2d6 +4";
                case 8:
                    return "2d6 +5";
                case 9:
                    return "2d6 +6";
                case 10:
                    return "2d6 +6";
                case 11:
                    return "2d6 +7";
                case 12:
                    return "2d8 +6";
                case 13:
                    return "2d8 +7";
                case 14:
                    return "2d8 +7";
                case 15:
                    return "2d8 +8";
                case 16:
                    return "3d6 +8";
                case 17:
                    return "3d6 +9";
                case 18:
                    return "3d6 +9";
                case 19:
                    return "3d6 +10";
                case 20:
                    return "3d6 +11";
                case 21:
                    return "3d8 +9";
                case 22:
                    return "3d8 +9";
                case 23:
                    return "3d8 +10";
                case 24:
                    return "3d8 +11";
                case 25:
                    return "3d8 +12";
                case 26:
                    return "4d6 +11";
                case 27:
                    return "4d6 +12";
                case 28:
                    return "4d6 +13";
                case 29:
                    return "4d6 +14";
                case 30:
                    return "4d6 +15";
                default:
                    return "4d6 +15";
            }
        }

        public static int MinionDamage(int level)
        {
            switch (level)
            {
                case 1:
                case 2:
                case 3:
                    return 4;
                case 4:
                case 5:
                case 6:
                    return 5;
                case 7:
                case 8:
                case 9:
                    return 6;
                case 10:
                case 11:
                case 12:
                    return 8;
                case 13:
                case 14:
                case 15:
                    return 9;
                case 16:
                case 17:
                case 18:
                    return 10;
                case 19:
                case 20:
                case 21:
                    return 11;
                case 22:
                case 23:
                case 24:
                    return 13;
                case 25:
                case 26:
                case 27:
                    return 14;
                case 28:
                case 29:
                case 30:
                    return 15;
                default:
                    return 15;
            }
        }
    }
}
