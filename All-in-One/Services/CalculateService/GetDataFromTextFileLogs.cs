using All_in_One.DataModels.DKPModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Services.CalculateService
{
    internal class GetDataFromTextFileLogs
    {
        public List<PlayerDKPEntry> GetPlayerDataFromTextFileLogs(string path)
        {
            StreamReader sr = new StreamReader(File.OpenRead(path));
            List<PlayerDKPEntry> result = new List<PlayerDKPEntry>();

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();

                if(line.Split(",")[1].Contains("Player") && ( line.Contains("SPELL_CAST_SUCCESS") || line.Contains("SPELL_AURA_APPLIED") || line.Contains("SPELL_DAMAGE")))
                {
                    string player = line.Split(",")[2].Substring(1, line.Split(",")[2].IndexOf('-') - 1);

                    Consumables.AcceptedConsumables.ForEach(consumable =>
                    {
                        if(line.Contains(consumable))
                        {
                            
                            if (!result.Exists(entry => entry.PlayerName == player))
                            {
                                result.Add(new PlayerDKPEntry() { PlayerName = player, Consumable1 = line.Split(',')[10] });
                            }
                            else
                            {
                                var PlayerDKPEntry = result.Find(entry => entry.PlayerName == player);

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

                                if(!PlayerDKPEntry.Consumable1.Contains(enchant) && PlayerDKPEntry.Consumable2 == null)
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
