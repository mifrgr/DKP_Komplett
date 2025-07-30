using All_in_One.DataModels.PlayerModels;
using All_in_One.Services.SpreadSheetService.DataModels;
using All_in_One.Services.WarcraftLogsService.WarcraftlogsModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using All_in_One.Services.CalculateService.DataModels;

namespace All_in_One.Services.CalculateService.Functions
{
    internal class NewPlayerFinder
    {
        /// <summary>
        /// Durchsucht die Spreadsheetdaten nach unbekannten Spielern aus den Logs und erstellt eine Liste aus neuen Spreadsheeteinträgen 
        /// </summary>
        /// <param name="DKPPlayer">Liste aller Spieler, die bereits im Spreadsheet eingetragen sind</param>
        /// <param name="logs">Die Daten der Spieler als Dataobject</param>
        /// <returns>Gibt eine Liste der Spieler im Spreadsheetformat zurück</returns>
        public List<UnknownPlayer> FindNewPlayer(List<PlayerData> DKPPlayer, LogsDataObject logs)
        {
            List<UnknownPlayer> result = new List<UnknownPlayer>();

            foreach (var player in logs.baseLogs.friendlies)
            {
                if (!DKPPlayer.ToList().Exists(dkpplayer => dkpplayer.Name == player.name) && player.type != "NPC")
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
