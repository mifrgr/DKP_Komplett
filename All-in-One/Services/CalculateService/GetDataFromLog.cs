using All_in_One.DataModels.DKPModels;
using All_in_One.DataModels.PlayerModels;
using All_in_One.DataModels.WarcraftlogsModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace All_in_One.Services.CalculateService
{
    public class GetDataFromLog
    {
        /// <summary>
        /// Liest die Spielerdaten aus den Warcraftlogs. Überprüft auf unverzauberte Gegenstände, Berechnet die Fähigkeiten pro Minute.
        /// 
        ///
        /// </summary>
        /// <param name="logs">Die Daten als werden als Dataobject übergeben</param>
        /// <returns>Gibt eine Liste aller Spieler mit den ausgelesenen Daten zurück</returns>
        public List<PlayerDKPEntry> GetPlayerDataFromLogs(LogsDataObject logs)
        {
            List<PlayerDKPEntry> result = new List<PlayerDKPEntry>();

            foreach (var logentry in logs.castsLogs.entries)
            {
                PlayerDKPEntry entry = new PlayerDKPEntry();

                int[] ints = (int[])Enum.GetValues(typeof(PlayerItemSlots.ItemSlots));
                entry.PlayerName = logentry.name;
                entry.CountPerMinutes = (float)logentry.total / (((float)logs.castsLogs.totalTime) / 60000);
                foreach (var item in logentry.gear)
                {
                    if (((int[])Enum.GetValues(typeof(PlayerItemSlots.ItemSlots))).Contains(item.slot))
                    {
                        if (item.name != null)
                        {
                            if (item.permanentEnchantName == null)
                            {
                                if (item.slot != 16)
                                {
                                    entry.Enchantment += item.name + Environment.NewLine;
                                    entry.CountOfNotEnchantetItems++;
                                }
                                else if (!OffHands.OffHand.Contains(item.id.ToString()))
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
                }

                result.Add(entry);
            }

            return result;
        }
    }

}
