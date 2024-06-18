using All_in_One.Entrys;
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

        public void CalculateDKP(List<SpreadsheetEntry> entries)
        {
            calc.CalcPoints(entries);
        }

        public void FindNewOrUnknownPlayer(List<SpreadsheetEntry> PlayersFromSpreadsheet, List<PlayerOnlyName> PlayersFromLogs)
        {
            finder.FindPlayer(PlayersFromSpreadsheet,PlayersFromLogs,out TwinksOrNewPlayers);
        }

        public void MarkPlayerAsPresent(List<SpreadsheetEntry> inPlayersFromSpreadsheet,List<PlayerOnlyName> PlayersFromLogs, out List<SpreadsheetEntry> PlayersFromSpreadsheet)
        {
            PlayersFromSpreadsheet = mark.MarkPlayer(inPlayersFromSpreadsheet, PlayersFromLogs);
        }

        public void FindBestPlayers(out List<PlayerOnlyName> BestPlayers)
        {
            BestPlayers = find.GetDKP_Player();
        }
    }
}
