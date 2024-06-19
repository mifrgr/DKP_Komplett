using All_in_One.Entrys;
using All_in_One.Logik_Side.Data;
using All_in_One.StaticFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Logik_Side
{
    public class Handler
    {
        DKP_Calc calc = new DKP_Calc();
        PlayerFinder finder = new PlayerFinder();
        MarkPlayersAsPresent mark = new MarkPlayersAsPresent();
        AnalyseLog find = new AnalyseLog();

        public List<UnknownPlayer> TwinksOrNewPlayers = new List<UnknownPlayer>();

        /// <summary>
        /// Adds or reduce the DKP from players
        /// </summary>
        /// <param name="entries"></param>
        public void CalculateDKP(List<SpreadsheetEntry> entries)
        {
            calc.CalcPoints(entries);
        }

        /// <summary>
        /// Get every Player that is in loglist, but not in DKP-List.
        /// </summary>
        /// <param name="PlayersFromSpreadsheet"></param>
        /// <param name="PlayersFromLogs"></param>
        public void FindNewOrUnknownPlayer(List<SpreadsheetEntry> PlayersFromSpreadsheet, List<PlayerOnlyName> PlayersFromLogs)
        {
            finder.FindPlayer(PlayersFromSpreadsheet,PlayersFromLogs,out TwinksOrNewPlayers);
        }

        /// <summary>
        /// Mark every player in the dkp list, if found in loglist
        /// </summary>
        /// <param name="inPlayersFromSpreadsheet"></param>
        /// <param name="PlayersFromLogs"></param>
        /// <param name="PlayersFromSpreadsheet"></param>
        public void MarkPlayerAsPresent(List<SpreadsheetEntry> inPlayersFromSpreadsheet,List<PlayerOnlyName> PlayersFromLogs, out List<SpreadsheetEntry> WorkingSpreadsheet_PresentPlayer)
        {
            WorkingSpreadsheet_PresentPlayer = mark.MarkPlayer(inPlayersFromSpreadsheet, PlayersFromLogs);
        }

        /// <summary>
        /// Get the player from logs who will get dkp points
        /// </summary>
        /// <param name="BestPlayers"></param>
        public void FindBestPlayers(List<SpreadsheetEntry> WorkingSpreadsheet,out List<SpreadsheetEntry> WorkingSpreadsheet_BestPlayer)
        {
            WorkingSpreadsheet_BestPlayer = find.GetDKP_Player(WorkingSpreadsheet);
        }
    }
}
