using All_in_One.Logik_Side.Data;
using All_in_One.Warcraft_Logs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Logik_Side.Functions.BestPlayerFunctions.BestByRole
{
    internal class _Tanks
    {
        internal static List<PlayerOnlyName> Tanks()
        {
            List<PlayerOnlyName> TankList = new List<PlayerOnlyName>();
            foreach(var entry in Logs_Results.SummaryLogs.playerDetails.tanks)
            {
                TankList.Add(new PlayerOnlyName(entry.name));
            }
            return TankList;
        }
    }
}
