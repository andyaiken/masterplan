using System;
using System.Collections.Generic;

using Masterplan.Data;

namespace Masterplan.Tools
{
	class Skills
	{
		public static List<string> GetAbilityNames()
		{
			List<string> abilities = new List<string>();

			abilities.Add("Strength");
			abilities.Add("Constitution");
			abilities.Add("Dexterity");
			abilities.Add("Intelligence");
			abilities.Add("Wisdom");
			abilities.Add("Charisma");

			return abilities;
		}

        public static List<string> GetSkillNames()
        {
            List<string> skills = new List<string>();

            skills.Add("Acrobatics");
            skills.Add("Arcana");
            skills.Add("Athletics");
            skills.Add("Bluff");
            skills.Add("Diplomacy");
            skills.Add("Dungeoneering");
            skills.Add("Endurance");
            skills.Add("Heal");
            skills.Add("History");
            skills.Add("Insight");
            skills.Add("Intimidate");
            skills.Add("Nature");
            skills.Add("Perception");
            skills.Add("Religion");
            skills.Add("Stealth");
            skills.Add("Streetwise");
            skills.Add("Thievery");

            return skills;
        }

        public static string GetKeyAbility(string skill_name)
        {
            if (skill_name == "Athletics")
                return "Strength";

            if (skill_name == "Endurance")
                return "Constitution";

            if ((skill_name == "Acrobatics") || (skill_name == "Stealth") || (skill_name == "Thievery"))
                return "Dexterity";

            if ((skill_name == "Arcana") || (skill_name == "History") || (skill_name == "Religion"))
                return "Intelligence";

            if ((skill_name == "Dungeoneering") || (skill_name == "Heal") || (skill_name == "Insight") || (skill_name == "Nature") || (skill_name == "Perception"))
                return "Wisdom";

            if ((skill_name == "Bluff") || (skill_name == "Diplomacy") || (skill_name == "Intimidate") || (skill_name == "Streetwise"))
                return "Charisma";

            return "";
        }
    }
}
