using All_in_One.Entrys;
using All_in_One.Logik_Side.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Logik_Side
{
    internal class MarkPlayersAsPresent
    {
        public List<SpreadsheetEntry> MarkPlayer(List<SpreadsheetEntry> inPlayersFromSpreadsheet, List<PlayerOnlyName> PlayersFromLogs)
        {
            foreach(SpreadsheetEntry spreadsheetEntry in inPlayersFromSpreadsheet) 
            {
                spreadsheetEntry.Teilgenommen = "";
                spreadsheetEntry.BesonderePunkte = "";

                foreach(PlayerOnlyName playerOnlyName in PlayersFromLogs)
                {
                    if (spreadsheetEntry.Spieler == playerOnlyName.Name)
                    {
                        spreadsheetEntry.Teilgenommen = "x";
                        break;
                    }
                }
                
            }

            return inPlayersFromSpreadsheet;
        }
    }
}
