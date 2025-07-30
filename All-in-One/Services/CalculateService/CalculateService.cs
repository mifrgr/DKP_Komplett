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
        NewPlayerFinder playerFinder = new NewPlayerFinder();
        GetDataFromTextFileLogs textlogsanalyser = new GetDataFromTextFileLogs();
        GetDataFromLog loganalyser = new GetDataFromLog();
        DataUpdater dataWriter = new DataUpdater();
        CoreLootManagerDataHandler addonDataHandler = new CoreLootManagerDataHandler();

        /// <summary>
        /// Durchsucht die Spreadsheetdaten nach unbekannten Spielern aus den Logs und erstellt eine Liste aus neuen Spreadsheeteinträgen 
        /// </summary>
        /// <param name="DKPPlayer">Liste aller Spieler, die bereits im Spreadsheet eingetragen sind</param>
        /// <param name="logs">Die Daten der Spieler als Dataobject</param>
        /// <returns>Gibt eine Liste der Spieler im Spreadsheetformat zurück</returns>
        public List<UnknownPlayer> FindNewPlayers(List<PlayerData> DKPPlayer, LogsDataObject logs)
        {
            return playerFinder.FindNewPlayer(DKPPlayer, logs);
        }
        /// <summary>
        /// Liest die Daten des WoW-Clienten Logger aus. Die Consumables werden von warcraftlogs teilweise nicht korrekt ermittelt, da diese nur Events im Fight auswerden.
        /// </summary>
        /// <param name="path">Der Pfad der Logdatei</param>
        /// <returns></returns>
        public List<PlayerExtractedData> GetPlayerDKPRequirements(string path)
        {
            return textlogsanalyser.GetPlayerDataFromTextFileLogs(path);
        }
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
