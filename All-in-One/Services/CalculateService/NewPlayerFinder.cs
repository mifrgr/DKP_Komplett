using All_in_One.DataModels.PlayerModels;
using All_in_One.DataModels.SpreadSheetModels;
using All_in_One.DataModels.WarcraftlogsModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace All_in_One.Services.CalculateService
{
    internal class NewPlayerFinder
    {
        /// <summary>
        /// Durchsucht die Spreadsheetdaten nach unbekannten Spielern aus den Logs und erstellt eine Liste aus neuen Spreadsheeteinträgen 
        /// </summary>
        /// <param name="DKPPlayer">Liste aller Spieler, die bereits im Spreadsheet eingetragen sind</param>
        /// <param name="logs">Die Daten der Spieler als Dataobject</param>
        /// <returns>Gibt eine Liste der Spieler im Spreadsheetformat zurück</returns>
        public List<UnknownPlayer> FindNewPlayer(ObservableCollection<SpreadsheetEntry> DKPPlayer, LogsDataObject logs)
        {
            List<UnknownPlayer> result = new List<UnknownPlayer>();

            foreach (var player in logs.baseLogs.friendlies)
            {
                if (!DKPPlayer.ToList().Exists(dkpplayer => dkpplayer.Spieler == player.name) && player.type != "NPC")
                {
                    if (player.fights.Length > logs.baseLogs.fights.Length / 2)
                    {
                        result.Add(new UnknownPlayer(player.name));
                    }

                }
            }
            return result;
        }
    }
}
