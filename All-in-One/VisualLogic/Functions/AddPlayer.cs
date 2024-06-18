using All_in_One.Entrys;
using All_in_One.Logik_Side;
using All_in_One.Spreadsheet_Side;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.VisualLogic.Functions
{
    internal class AddPlayer
    {
        public void AddPlayers(List<UnknownPlayer> TwinksOrNewPlayers, List<SpreadsheetEntry> inPlayersFromSpreadsheet, out List<SpreadsheetEntry> PlayersFromSpreadsheet)
        {

            foreach (var entry in TwinksOrNewPlayers)
            {
                if (entry.AddNewPlayer)
                {
                    inPlayersFromSpreadsheet.Add(new SpreadsheetEntry
                    {
                        Spieler = entry.Name,
                        Teilgenommen = "x",
                        Punkte = "0",


                    });
                }
            }

            PlayersFromSpreadsheet = inPlayersFromSpreadsheet;
        }
    }
}
