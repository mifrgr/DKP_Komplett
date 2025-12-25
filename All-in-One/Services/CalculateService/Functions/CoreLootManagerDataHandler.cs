using System;
using System.Collections.Generic;
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
            return JsonSerializer.Deserialize<CLMJsonEntry>(Clipboard.GetText());
        }
        public void SetAddonData(List<PlayerData> players)
        {
            var jsonDataToEdit = ReadAddonData();
            players.ForEach(player =>
            {
                var dkpPlayer = jsonDataToEdit.standings.roster[0].standings.player.ToList().Find(addonPlayer => addonPlayer.name.Contains(player.Name));
                if (dkpPlayer != null && player.IsGoldDrache)
                {
                    dkpPlayer.points++;
                }
            });
            Clipboard.SetText(JsonSerializer.Serialize<CLMJsonEntry>(jsonDataToEdit));
        }
    }
}
