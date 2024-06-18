using All_in_One.Entrys;
using All_in_One.Spreadsheet_Side;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Logik_Side
{
    internal class PlayerFinder
    {
        public void FindPlayer(List<SpreadsheetEntry> PlayersFromSpreadsheet, List<PlayerOnlyName> PlayersFromLog, out List<UnknownPlayer> TwinksOrNewPlayers)
        {
            List<UnknownPlayer> Unknown = new();
            foreach (var entry in PlayersFromLog)
            {
                bool playerFound = false;

                foreach (var entry2 in PlayersFromSpreadsheet)
                {
                    if (entry.Name == entry2.Spieler)
                    {
                        playerFound = true;
                        break;
                    }
                }
                if (!playerFound)
                {
                    Unknown.Add(new UnknownPlayer(entry.Name));
                }
            }
            TwinksOrNewPlayers = Unknown;
        }
    }
}
