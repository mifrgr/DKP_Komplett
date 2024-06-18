using System.Collections.Generic;
using System.Linq;
using All_in_One.Warcraft_Logs.Data;
using All_in_One.Warcraft_Logs.LogTypes.Damage;

namespace All_in_One.Logik_Side.Functions.BestPlayerFunctions
{
    internal static class _BestDD
    {
        internal static List<PlayerOnlyName> BestDD()
        {
            List<PlayerOnlyName> BestDD = new ();
            if (Logs_Results.BaseLogs.title.Contains("AQ20") | Logs_Results.BaseLogs.title.Contains("ZG"))
            {
                List<Entry> entries = Logs_Results.DamageLogs.entries.ToList();
                entries = entries.OrderByDescending(entry => entry.total).ToList();
                for (int i = 0; i < 1; i++)
                {
                    BestDD.Add(new PlayerOnlyName(entries[i].name));
                }
            }
            else
            {
                List<Entry> entries = Logs_Results.DamageLogs.entries.ToList();
                entries = entries.OrderByDescending(entry => entry.total).ToList();
                for (int i = 0; i < 5; i++)
                {
                    BestDD.Add(new PlayerOnlyName(entries[i].name));
                }
            }

            return BestDD;
        }
    }
}
