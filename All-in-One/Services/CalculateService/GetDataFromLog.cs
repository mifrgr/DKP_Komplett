using All_in_One.DataModels.DKPModels;
using All_in_One.DataModels.PlayerModels;
using All_in_One.DataModels.WarcraftlogsModels;
using System;
using System.Collections;
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

                int[] ints = (int[])Enum.GetValues(typeof(PlayerItemSlots.ItemSlots));
                entry.PlayerName = logentry.name;
                entry.CountPerMinutes = (float)logentry.total / (((float)logs.castsLogs.totalTime)/60000);
                foreach (var item in logentry.gear)
                {
                    if (((int[])Enum.GetValues(typeof(PlayerItemSlots.ItemSlots))).Contains(item.slot))
                    {

                        if (item.permanentEnchantName == null)
                        {
                            if(item.slot != 16)
                            {
                                entry.Enchantment += item.name + Environment.NewLine;
                                entry.CountOfNotEnchantetItems++;
                            }
                            else if(item.icon.Contains("sword") || item.icon.Contains("mace") || item.icon.Contains("axe") || item.icon.Contains("knife") || item.icon.Contains("blade"))
                            {
                                entry.Enchantment += item.name + Environment.NewLine;
                                entry.CountOfNotEnchantetItems++;

                            }
                        }

                        if (item.permanentEnchantName != null && Enchantments.AcceptedEnchantments.Where(enchant => enchant.ID == item.permanentEnchant).Count() == 0)
                        {
                            entry.Enchantment += item.name + " [" + item.permanentEnchantName + "]" + Environment.NewLine;
                            entry.CountOfNotEnchantetItems++;
                        }
                    }
                }

                result.Add(entry);
            }

            return result;
        }
    }
   
}
