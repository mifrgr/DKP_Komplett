using All_in_One.DataModels.DKPModels;
using All_in_One.DataModels.SpreadSheetModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Services.CalculateService
{
    internal class SetDKPForPlayers
    {
        public List<SpreadsheetEntry> SetDKPForPlayersFromLog(ObservableCollection<PlayerDKPEntry> playerDKPs)
        {
            List<SpreadsheetEntry> result = new List<SpreadsheetEntry>();
            foreach (var item in playerDKPs)
            {
                SpreadsheetEntry entry = new SpreadsheetEntry();
                entry.Spieler = item.PlayerName;
                entry.Teilgenommen = "x";
                entry.ActiveTime = item.ActiveTime.ToString();
                entry.Verzauberungen = item.Enchantment;
                entry.Waffenverzauberungen = item.WeaponEnchantment;
                entry.Consumables = item.Consumable;
                if(item.CountOfNotEnchantetItems <= 2 && item.Consumable != "" && item.WeaponEnchantment != "" && item.ActiveTime > 50)
                {
                    entry.GetDKP = true;
                }

                result.Add(entry);
            }

            return result;
        }
    }
}
