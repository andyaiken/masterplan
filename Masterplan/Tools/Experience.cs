using System;

using Masterplan.Data;

namespace Masterplan.Tools
{
	static class Experience
	{
		public static int GetCreatureXP(int level)
		{
			if (level < 1)
				level = 1;

			switch (level)
			{
				case 1: return 100;
				case 2: return 125;
				case 3: return 150;
				case 4: return 175;
				case 5: return 200;
				case 6: return 250;
				case 7: return 300;
				case 8: return 350;
				case 9: return 400;
				case 10: return 500;
				case 11: return 600;
				case 12: return 700;
				case 13: return 800;
				case 14: return 1000;
				case 15: return 1200;
				case 16: return 1400;
				case 17: return 1600;
				case 18: return 2000;
				case 19: return 2400;
				case 20: return 2800;
				case 21: return 3200;
				case 22: return 4150;
				case 23: return 5100;
				case 24: return 6050;
				case 25: return 7000;
				case 26: return 9000;
				case 27: return 11000;
				case 28: return 13000;
				case 29: return 15000;
				case 30: return 19000;
				case 31: return 23000;
				case 32: return 27000;
				case 33: return 31000;
				case 34: return 39000;
				case 35: return 47000;
				case 36: return 55000;
				case 37: return 63000;
				case 38: return 79000;
				case 39: return 95000;
				case 40: return 111000;
			}

			return 0;
		}

		public static Pair<int, int> GetMinorQuestXP(int level)
		{
			if (level < 1)
				level = 1;

			switch (level)
			{
				case 1: return new Pair<int, int>(20, 50);
				case 2: return new Pair<int, int>(25, 60);
				case 3: return new Pair<int, int>(30, 75);
				case 4: return new Pair<int, int>(35, 85);
				case 5: return new Pair<int, int>(40, 100);
				case 6: return new Pair<int, int>(50, 125);
				case 7: return new Pair<int, int>(60, 150);
				case 8: return new Pair<int, int>(70, 175);
				case 9: return new Pair<int, int>(80, 200);
				case 10: return new Pair<int, int>(100, 250);
				case 11: return new Pair<int, int>(120, 300);
				case 12: return new Pair<int, int>(140, 350);
				case 13: return new Pair<int, int>(160, 400);
				case 14: return new Pair<int, int>(200, 500);
				case 15: return new Pair<int, int>(240, 600);
				case 16: return new Pair<int, int>(280, 700);
				case 17: return new Pair<int, int>(320, 800);
				case 18: return new Pair<int, int>(400, 1000);
				case 19: return new Pair<int, int>(480, 1200);
				case 20: return new Pair<int, int>(560, 1400);
				case 21: return new Pair<int, int>(640, 1600);
				case 22: return new Pair<int, int>(830, 2075);
				case 23: return new Pair<int, int>(1020, 2550);
				case 24: return new Pair<int, int>(1210, 3025);
				case 25: return new Pair<int, int>(1400, 3500);
				case 26: return new Pair<int, int>(1800, 4500);
				case 27: return new Pair<int, int>(2200, 5500);
				case 28: return new Pair<int, int>(2600, 6500);
				case 29: return new Pair<int, int>(3000, 7500);
				case 30: return new Pair<int, int>(3800, 9500);
			}

			return null;
		}

		public static int GetHeroXP(int level)
		{
			if (level < 1)
				level = 1;

			switch (level)
			{
				case 1: return 0;
				case 2: return 1000;
				case 3: return 2250;
				case 4: return 3750;
				case 5: return 5500;
				case 6: return 7500;
				case 7: return 10000;
				case 8: return 13000;
				case 9: return 16500;
				case 10: return 20500;
				case 11: return 26000;
				case 12: return 32000;
				case 13: return 39000;
				case 14: return 47000;
				case 15: return 57000;
				case 16: return 69000;
				case 17: return 83000;
				case 18: return 99000;
				case 19: return 119000;
				case 20: return 143000;
				case 21: return 175000;
				case 22: return 210000;
				case 23: return 255000;
				case 24: return 310000;
				case 25: return 375000;
				case 26: return 450000;
				case 27: return 550000;
				case 28: return 675000;
				case 29: return 825000;
				case 30: return 1000000;
			}

			return -1;
		}

        public static int GetHeroLevel(int xp)
        {
			if (xp >= GetHeroXP(30))
				return 30;

            for (int level = 1; level <= 29; ++level)
            {
                int xp_for_level = GetHeroXP(level);
				int xp_plus_one = GetHeroXP(level + 1);

				if ((xp >= xp_for_level) && (xp < xp_plus_one))
					return level;
            }

            return -1;
        }

        public static int GetCreatureLevel(int xp)
        {
			if (xp >= GetCreatureXP(30))
				return 30;

			for (int level = 1; level <= 30; ++level)
            {
                int xp_for_level = GetCreatureXP(level);
                if (xp < xp_for_level)
                    return level - 1;
            }

            return -1;
        }

		public static int GetChallengeLevel(int xp, Party p)
		{
			int result = 0;
			int min_diff = int.MaxValue;

			for (int level = 1; level <= 40; ++level)
			{
				int xp_for_level = Experience.GetCreatureXP(level) * p.Size;
				int diff = Math.Abs(xp - xp_for_level);

				if (diff < min_diff)
				{
					min_diff = diff;
					result = level;
				}
			}

			return result;
		}
	}
}
