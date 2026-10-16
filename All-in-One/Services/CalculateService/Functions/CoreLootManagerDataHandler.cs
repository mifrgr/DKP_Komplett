using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using All_in_One.Services.CalculateService.DataModels;

namespace All_in_One.Services.CalculateService.Functions
{
    internal class CoreLootManagerDataHandler
    {
        /// <summary>
        /// Liest die Punkte aus dem CLM-Addon aus. ToDo: Aktuell nur über die Zwischenablage.
        /// </summary>
        /// <returns></returns>
        public CLMJsonEntry ReadAddonData()
        {
            string data = Clipboard.GetText();
            File.WriteAllText(@"C:\\Users\\Marcel\\Desktop\\backup\"  + "backup" +  DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".txt", data);
            return JsonSerializer.Deserialize<CLMJsonEntry>(data);
        }
        public List<PlayerData> SetAddonData(List<PlayerData> players, int bossDKP)
        {
            var jsonDataToEdit = ReadAddonData();

            players.ForEach(player =>
            {
                var dkpPlayer = jsonDataToEdit.standings.roster[0].standings.player.ToList().Find(addonPlayer => addonPlayer.name.Contains(player.Name));
                if (dkpPlayer != null)
                {
                    if(player.IDs_Missed_Count >= 40)
                    {
                        jsonDataToEdit.standings.roster[0].standings.player.ToList().Remove(dkpPlayer);
                    }
                    if(player.IsGoldDrache)
                    {
                        dkpPlayer.points++;
                    }
                    if(!player.HasPlayerWorldbuffs)
                    {
                        dkpPlayer.points-= bossDKP;
                    }
                    player.Punktestand = dkpPlayer.points;
                }
            });
            var PlayerToRemove = new List<Player>();
            foreach (var item in jsonDataToEdit.standings.roster[0].standings.player)
            {
                var playerInDKPList = players.Find(player => player.Name == item.name);
                if (playerInDKPList == null) PlayerToRemove.Add(item);
            }
            PlayerToRemove.ForEach(p => jsonDataToEdit.standings.roster[0].standings.player.ToList().Remove(p));
            Clipboard.SetText(JsonSerializer.Serialize<CLMJsonEntry>(jsonDataToEdit));
            return players;
        }
    }
}
