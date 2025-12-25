using All_in_One.DataModels.DKPModels;
using All_in_One.Services.CalculateService.DataModels;
using All_in_One.Services.WarcraftLogsService.WarcraftlogsModels;
using All_in_One.Static.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace All_in_One.Services.CalculateService
{
    public class GetDataFromLog
    {
        /// <summary>
        /// Liest die Spielerdaten aus den Warcraftlogs. Überprüft auf unverzauberte Gegenstände, Berechnet die Fähigkeiten pro Minute.
        /// 
        /// </summary>
        /// <param name="logs">Die Daten als werden als Dataobject übergeben</param>
        /// <returns>Gibt eine Liste aller Spieler mit den ausgelesenen Daten zurück</returns>
        public List<PlayerExtractedData> GetPlayerDataFromLogs(LogsDataObject logs)
        {
            List<PlayerExtractedData> result = new List<PlayerExtractedData>();
            float bossFightsCount = logs.baseLogs.fights.Where(fight => fight.boss != 0).Count();

            foreach (var logentry in logs.castsLogs.entries)
            {
                PlayerExtractedData entry = new PlayerExtractedData();

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
                            if(Consumables.AcceptedWeaponEnchants.ContainsKey(item.temporaryEnchant))
                            {
                                entry.Consumable1 = item.temporaryEnchantName;
                            }
                        }
                    }
                }
                foreach(var buff in logs.buffsLogs)
                {
                    if(buff.Value.auras.ToList().Exists(aura => aura.name == entry.PlayerName))
                    {
                        var filteredBuffs = buff.Value.auras.ToList().Single(aura => aura.name == entry.PlayerName);
                        if((float)filteredBuffs.totalUses / bossFightsCount >= 0.8)
                        {
                            if(entry.Consumable1 == "" || entry.Consumable1.Contains("["))
                            {
                                entry.Consumable1 = Consumables.AcceptedConsumables[buff.Key];
                            }
                            else if (entry.Consumable2 == "" || entry.Consumable2.Contains("["))
                            {
                                entry.Consumable2 = Consumables.AcceptedConsumables[buff.Key];
                            }
                        }
                        else
                        {
                            if (entry.Consumable1 == "")
                            {
                                entry.Consumable1 = Consumables.AcceptedConsumables[buff.Key] + " [" + filteredBuffs.totalUses + "/" + bossFightsCount + "]";
                            }
                            else if (entry.Consumable2 == "" || entry.Consumable2.Contains("["))
                            {
                                entry.Consumable2 = Consumables.AcceptedConsumables[buff.Key] + " [" + filteredBuffs.totalUses + "/" + bossFightsCount + "]";
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
