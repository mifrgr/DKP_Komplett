using All_in_One.DataModels.DKPModels;
using All_in_One.DataModels.WarcraftlogsModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace All_in_One.Services.CalculateService
{
    public class GetDataFromLog
    {
        public List<PlayerDKPEntry> GetPlayerDataFromLogs(LogsDataObject logs)
        {
            List<PlayerDKPEntry> result = new List<PlayerDKPEntry>();

            foreach (var logentry in logs.castsLogs.entries)
            {
                PlayerDKPEntry entry = new PlayerDKPEntry();

                entry.PlayerName = logentry.name;
                entry.ActiveTime = (float)logentry.activeTime / (float)logs.castsLogs.totalTime * 100f;

                foreach (var item in logentry.gear)
                {
                    if (item.permanentEnchantName == null && (item.slot == 0 || item.slot == 2 || item.slot == 4 || item.slot == 6 || item.slot == 7 || item.slot == 8 || item.slot == 9 || item.slot == 14 || item.slot == 15 || (item.slot == 16 && (item.icon.Contains("sword")|| item.icon.Contains("mace") || item.icon.Contains("axe") || item.icon.Contains("knife") || item.icon.Contains("blade")))))
                    {
                        entry.Enchantment += item.name + Environment.NewLine;
                        entry.CountOfNotEnchantetItems++;
                    }
                }

                result.Add(entry);
            }

            return result;
        }
    }
   
}
