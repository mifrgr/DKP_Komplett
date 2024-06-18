using All_in_One.Warcraft_Logs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Logik_Side.Functions.BestPlayerFunctions
{
    internal static class _BestHeal
    {
        internal static List<PlayerOnlyName> BestHeal()
        {
            List<PlayerOnlyName> BestHeal = new();

            List<HealingLogs.Entry> entries = Logs_Results.HealingLogs.entries.ToList();
            entries = entries.OrderByDescending(entry => entry.total).ToList();


            if (Logs_Results.BaseLogs.title.Contains("AQ20") | Logs_Results.BaseLogs.title.Contains("ZG"))
            {
                for (int i = 0; i < 1; i++)
                {
                    BestHeal.Add(new PlayerOnlyName(entries[i].name));
                }
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    BestHeal.Add(new PlayerOnlyName(entries[i].name));
                }
            }

            return BestHeal;
        }
    }
}
