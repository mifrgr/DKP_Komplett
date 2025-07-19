using All_in_One.DataModels.DKPModels;
using System.Collections.Generic;
using System.IO;

namespace All_in_One.Services.CalculateService
{
    internal class GetDataFromTextFileLogs
    {
        /// <summary>
        /// Liest die Daten des WoW-Clienten Logger aus. Die Consumables werden von warcraftlogs teilweise nicht korrekt ermittelt, da diese nur Events im Fight auswerden.
        /// </summary>
        /// <param name="path">Der Pfad der Logdatei</param>
        /// <returns></returns>
        public List<PlayerDKPEntry> GetPlayerDataFromTextFileLogs(string path)
        {
            StreamReader sr = new StreamReader(File.OpenRead(path));
            List<PlayerDKPEntry> result = new List<PlayerDKPEntry>();

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();

                if (line.Split(",")[1].Contains("Player") && (line.Contains("SPELL_CAST_SUCCESS") || line.Contains("SPELL_AURA_APPLIED") || line.Contains("SPELL_DAMAGE")))
                {
                    string player = line.Split(",")[2].Substring(1, line.Split(",")[2].IndexOf('-') - 1);

                    Consumables.AcceptedConsumables.ForEach(consumable =>
                    {
                        if (line.Contains(consumable))
                        {
                            bool isFlask = false;
                            Consumables.AcceptedDoubleConsumables.ForEach(flask => { if (line.Contains(flask)) { isFlask = true; }; });

                            if (!result.Exists(entry => entry.PlayerName == player))
                            {
                                if (isFlask)
                                {
                                    result.Add(new PlayerDKPEntry() { PlayerName = player, Consumable1 = line.Split(',')[10], Consumable2 = line.Split(',')[10] });
                                }
                                else
                                {
                                    result.Add(new PlayerDKPEntry() { PlayerName = player, Consumable1 = line.Split(',')[10] });
                                }
                            }
                            else
                            {
                                var PlayerDKPEntry = result.Find(entry => entry.PlayerName == player);

                                if (isFlask)
                                {
                                    PlayerDKPEntry.Consumable2 = line.Split(',')[10];
                                }

                                if (!PlayerDKPEntry.Consumable1.Contains(consumable) && PlayerDKPEntry.Consumable2 == null)
                                {
                                    PlayerDKPEntry.Consumable2 = line.Split(',')[10];
                                }

                            }
                        }
                    });
                    Consumables.AcceptedWeaponEnchants.ForEach(enchant =>
                    {
                        if (line.Contains(enchant))
                        {
                            if (!result.Exists(entry => entry.PlayerName == player))
                            {
                                result.Add(new PlayerDKPEntry() { PlayerName = player, Consumable1 = line.Split(',')[10] });
                            }
                            else
                            {
                                var PlayerDKPEntry = result.Find(entry => entry.PlayerName == player);

                                if (!PlayerDKPEntry.Consumable1.Contains(enchant) && PlayerDKPEntry.Consumable2 == null)
                                {
                                    PlayerDKPEntry.Consumable2 = line.Split(',')[10];
                                }
                            }
                        }
                    });
                }
            }

            return result;
        }
    }
}
