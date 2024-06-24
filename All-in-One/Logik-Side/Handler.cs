using All_in_One.Spreadsheet_Side.Data;
using All_in_One.Logik_Side.Data;
using All_in_One.Logik_Side.Functions.ExtensionsMethods;
using All_in_One.Static.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Logik_Side
{
    public class Handler
    {
        AnalyseLog find = new AnalyseLog();

        public ObservableCollection<UnknownPlayer> TwinksOrNewPlayers = new();

        /// <summary>
        /// Adds or reduce the DKP from players
        /// </summary>
        /// <param name="entries"></param>
        public void CalculateDKP(ObservableCollection<SpreadsheetEntry> entries)
        {
            Handlers.visualLogicHandler.PlayersFromSpreadsheet.CalcPoints();
        }
        /// <summary>
        /// Get every Player that is in loglist, but not in DKP-List.
        /// </summary>
        /// <param name="PlayersFromSpreadsheet"></param>
        /// <param name="PlayersFromLogs"></param>
        public void FindNewOrUnknownPlayer(ObservableCollection<SpreadsheetEntry> PlayersFromSpreadsheet, ObservableCollection<PlayerOnlyName> PlayerFromLogs)
        {
            TwinksOrNewPlayers.FindPlayer(PlayersFromSpreadsheet, PlayerFromLogs);
        }

        /// <summary>
        /// Mark every player in the dkp list, if found in loglist
        /// </summary>
        /// <param name="inPlayersFromSpreadsheet"></param>
        /// <param name="PlayersFromLogs"></param>
        /// <param name="PlayersFromSpreadsheet"></param>
        public void MarkPlayerAsPresent(ObservableCollection<SpreadsheetEntry> inPlayersFromSpreadsheet, ObservableCollection<PlayerOnlyName> PlayersFromLogs)
        {
            inPlayersFromSpreadsheet.MarkPlayer(PlayersFromLogs);
        }

        /// <summary>
        /// Get the player from logs who will get dkp points
        /// </summary>
        /// <param name="BestPlayers"></param>
        public void FindBestPlayers(List<SpreadsheetEntry> WorkingSpreadsheet)
        {
            Handlers.visualLogicHandler.PlayersFromSpreadsheet.UpdateSpreadSheet(find.GetDKP_Player());
        }
    }
}
