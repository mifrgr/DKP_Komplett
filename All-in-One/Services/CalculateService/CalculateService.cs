using All_in_One.DataModels.PlayerModels;
using All_in_One.Services.CalculateService.DataModels;
using All_in_One.Services.CalculateService.Functions;
using All_in_One.Services.SpreadSheetService.DataModels;
using All_in_One.Services.WarcraftLogsService.WarcraftlogsModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace All_in_One.Services.CalculateService
{
    public class CalculateService
    {
        GetDataFromLog loganalyser = new GetDataFromLog();
        DataUpdater dataWriter = new DataUpdater();
        CoreLootManagerDataHandler addonDataHandler = new CoreLootManagerDataHandler();

        /// <summary>
        /// Liest die Spielerdaten aus den Warcraftlogs. Überprüft auf unverzauberte Gegenstände, Berechnet die Fähigkeiten pro Minute.
        /// 
        ///
        /// </summary>
        /// <param name="logs">Die Daten als werden als Dataobject übergeben</param>
        /// <returns>Gibt eine Liste aller Spieler mit den ausgelesenen Daten zurück</returns>
        public List<PlayerExtractedData> GetPlayerDKPRequirement(LogsDataObject logs)
        {
            return loganalyser.GetPlayerDataFromLogs(logs);
        }

        public List<PlayerData> SetExtractedDataToSheet(List<PlayerExtractedData> playerExtractedDatas, List<PlayerData> spreadsheetEntries)
        {
            return dataWriter.UpdateDKPData(playerExtractedDatas, spreadsheetEntries);
        }

        public void SetAddonData(List<PlayerData> players)
        {
             addonDataHandler.SetAddonData(players);
        }
    }
}
