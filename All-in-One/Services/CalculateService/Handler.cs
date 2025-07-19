using All_in_One.DataModels.DKPModels;
using All_in_One.DataModels.PlayerModels;
using All_in_One.DataModels.SpreadSheetModels;
using All_in_One.DataModels.WarcraftlogsModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace All_in_One.Services.CalculateService
{
    public class Handler
    {
        NewPlayerFinder playerFinder = new NewPlayerFinder();
        GetDataFromTextFileLogs textlogsanalyser = new GetDataFromTextFileLogs();
        GetDataFromLog loganalyser = new GetDataFromLog();
        SetDKPForPlayers setdkp = new SetDKPForPlayers();
        CalculateDKP calculator = new CalculateDKP();

        /// <summary>
        /// Durchsucht die Spreadsheetdaten nach unbekannten Spielern aus den Logs und erstellt eine Liste aus neuen Spreadsheeteinträgen 
        /// </summary>
        /// <param name="DKPPlayer">Liste aller Spieler, die bereits im Spreadsheet eingetragen sind</param>
        /// <param name="logs">Die Daten der Spieler als Dataobject</param>
        /// <returns>Gibt eine Liste der Spieler im Spreadsheetformat zurück</returns>
        public List<UnknownPlayer> FindNewPlayers(ObservableCollection<SpreadsheetEntry> DKPPlayer, LogsDataObject logs)
        {
            return playerFinder.FindNewPlayer(DKPPlayer, logs);
        }
        /// <summary>
        /// Liest die Daten des WoW-Clienten Logger aus. Die Consumables werden von warcraftlogs teilweise nicht korrekt ermittelt, da diese nur Events im Fight auswerden.
        /// </summary>
        /// <param name="path">Der Pfad der Logdatei</param>
        /// <returns></returns>
        public List<PlayerDKPEntry> GetPlayerDKPRequirements(string path)
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
        public List<PlayerDKPEntry> GetPlayerDKPRequirement(LogsDataObject logs)
        {
            return loganalyser.GetPlayerDataFromLogs(logs);
        }
        /// <summary>
        /// Wandelt die DKP Daten der Spieler in entsprechende Spreadsheet Daten.
        /// </summary>
        /// <param name="playerDKPs"></param>
        /// <returns>Gibt eine Liste mit den Daten der Spieler in Spreadsheetform zurück</returns>
        public List<SpreadsheetEntry> SetDKPForPlayers(ObservableCollection<PlayerDKPEntry> playerDKPs)
        {
            return setdkp.SetDKPForPlayersFromLog(playerDKPs);
        }
        /// <summary>
        /// Berecnet die Punkte für den Spieler. Maximal dürfen 101 erreicht werden.
        /// </summary>
        /// <param name="entry">Spielerdaten als SpreadSheet Eintrag</param>
        /// <returns></returns>
        public float CalculateDKPPoints(SpreadsheetEntry entry)
        {
            return calculator.CalculateDKPPoints(entry);
        }

    }
}
