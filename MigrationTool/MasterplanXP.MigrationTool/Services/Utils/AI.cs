#nullable disable

using MasterplanXP.MigrationTool.Models.Legacy;
using System;
using System.Text.RegularExpressions;

namespace MasterplanXP.MigrationTool.Services.Utils
{
    public static class AI
    {
        #region Difficulty

        public static Difficulty GetThreatDifficulty(int threat_level, int party_level)
        {
            int level_diff = threat_level - party_level;

            if (level_diff > 5)
                return Difficulty.Extreme;

            if (level_diff < -3)
                return Difficulty.Trivial;

            return Difficulty.Easy;
        }

        public static Difficulty GetSkillDifficulty(int dc, int party_level)
        {
            int easy = GetSkillDC(Difficulty.Easy, party_level);
            int mod = GetSkillDC(Difficulty.Moderate, party_level);
            int hard = GetSkillDC(Difficulty.Hard, party_level);
            int ext = hard + ((hard - easy) / 2);

            if (dc < easy)
            {
                return Difficulty.Trivial;
            }
            else if (dc < mod)
            {
                return Difficulty.Easy;
            }
            else if (dc < hard)
            {
                return Difficulty.Moderate;
            }
            else if (dc < ext)
            {
                return Difficulty.Hard;
            }
            else
            {
                return Difficulty.Extreme;
            }
        }

        #endregion

        #region Skill DCs

        public static int GetSkillDC(Difficulty diff, int level)
        {
            switch (diff)
            {
                case Difficulty.Easy:
                    return 5 + (level / 2);
                case Difficulty.Moderate:
                    return 10 + (level / 2);
                case Difficulty.Hard:
                    return 15 + (level / 2);
                case Difficulty.Extreme:
                    return 20 + (level / 2);
                default:
                    return 10 + (level / 2);
            }
        }

        #endregion

        #region Text

        public static string ExtractDamage(string source)
        {
            string[] separators = { ",", ";", ".", ":", Environment.NewLine };
            string[] sections = source.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (string section in sections)
            {
                string str = section.Trim().ToLower();

                if (str.Contains("damage") || str.Contains("dmg"))
                    return str;
            }

            foreach (string section in sections)
            {
                DiceExpression exp = DiceExpression.Parse(section);
                if (exp != null)
                    return section;
            }

            return "";
        }

        const string damageRegExp = @"((?<dCount>[0-9]{1,2})d(?<dSize>[0-9]{1,2})[ ]*(?<dConst>(\+|-)[ ]*[0-9]{1,2})?|(?<dConst>[0-9]{1,2}))[ ]*[a-z, ]*?[ ]+(dmg|damage)";

        public static string ExtractDamageR(string source)
        {
            Regex re = new Regex(damageRegExp);
            Match match = re.Match(source);
            if (match.Success)
            {
                return match.Value;
            }
            return "";
        }

        #endregion
    }
}
