#nullable disable

using MasterplanXP.MigrationTool.Models.Legacy;
using System;
using System.Collections.Generic;

namespace MasterplanXP.MigrationTool.Services.Utils
{
    public static class Treasure
    {
        public static List<Guid> PlaceholderIDs
        {
            get
            {
                if (fPlaceholderIDs == null)
                {
                    fPlaceholderIDs = new List<Guid>();

                    for (int level = 1; level <= 30; ++level)
                    {
                        Guid id = new Guid(level, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                        fPlaceholderIDs.Add(id);
                    }
                }

                return fPlaceholderIDs;
            }
        }
        static List<Guid> fPlaceholderIDs = null;

        public static int GetItemValue(int level)
        {
            switch (level)
            {
                case 1: return 360;
                case 2: return 520;
                case 3: return 680;
                case 4: return 840;
                case 5: return 1000;
                case 6: return 1800;
                case 7: return 2600;
                case 8: return 3400;
                case 9: return 4200;
                case 10: return 5000;
                case 11: return 9000;
                case 12: return 13000;
                case 13: return 17000;
                case 14: return 21000;
                case 15: return 25000;
                case 16: return 45000;
                case 17: return 65000;
                case 18: return 85000;
                case 19: return 105000;
                case 20: return 125000;
                case 21: return 225000;
                case 22: return 325000;
                case 23: return 425000;
                case 24: return 525000;
                case 25: return 625000;
                case 26: return 1125000;
                case 27: return 1625000;
                case 28: return 2125000;
                case 29: return 2625000;
                case 30: return 3125000;
                default: return 0;
            }
        }
    }
}
