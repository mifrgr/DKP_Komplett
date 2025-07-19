using All_in_One.DataModels.DKPModels;
using All_in_One.DataModels.SpreadSheetModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace All_in_One.Services.CalculateService
{
    internal class SetDKPForPlayers
    {
        /// <summary>
        /// Wandelt die DKP Daten der Spieler in entsprechende Spreadsheet Daten.
        /// </summary>
        /// <param name="playerDKPs"></param>
        /// <returns>Gibt eine Liste mit den Daten der Spieler in Spreadsheetform zurück</returns>
        public List<SpreadsheetEntry> SetDKPForPlayersFromLog(ObservableCollection<PlayerDKPEntry> playerDKPs)
        {
            List<SpreadsheetEntry> result = new List<SpreadsheetEntry>();
            foreach (var item in playerDKPs)
            {
                SpreadsheetEntry entry = new SpreadsheetEntry();
                entry.Spieler = item.PlayerName;
                entry.CountsPerMinutes = item.CountPerMinutes.ToString();
                entry.Verzauberungen = item.Enchantment;
                entry.Consumables1 = item.Consumable1;
                entry.Consumable2 = item.Consumable2;
                if (item.CountOfNotEnchantetItems <= 2 && item.Consumable1 != null && item.Consumable2 != null && item.CountPerMinutes >= 10)
                {
                    entry.GetDKP = true;
                }

                result.Add(entry);
            }

            return result;
        }
    }
}
