using System.Collections.Generic;
using System.Linq;
using All_in_One.Warcraft_Logs.Data;
using All_in_One.Warcraft_Logs.LogTypes.Damage;

namespace All_in_One.Logik_Side.Functions.BestPlayerFunctions
{
    internal static class _BestDD
    {
        internal static List<PlayerDKP> BestDD()
        {
            List<PlayerDKP> BestDD = new ();
            if (Logs_Results.BaseLogs.title.Contains("AQ20") | Logs_Results.BaseLogs.title.Contains("ZG"))
            {
                List<Entry> entries = Logs_Results.DamageLogs.entries.ToList();
                entries = entries.OrderByDescending(entry => entry.total).ToList();
                for (int i = 0; i < 1; i++)
                {
                    BestDD.Add(new PlayerDKP(entries[i].name,"DD"));
                }
            }
            else
            {
                List<Entry> entries = Logs_Results.DamageLogs.entries.ToList();
                entries = entries.OrderByDescending(entry => entry.total).ToList();
                for (int i = 0; i < 5; i++)
                {
                    BestDD.Add(new PlayerDKP(entries[i].name,"DD"));
                }
            }

            return BestDD;
        }
    }
}
