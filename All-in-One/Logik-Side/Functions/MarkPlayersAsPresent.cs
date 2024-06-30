using All_in_One.Spreadsheet_Side.Data;
using All_in_One.Logik_Side.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Logik_Side
{
    public static class MarkPlayersAsPresent
    {
        public static void MarkPlayer(this ObservableCollection<SpreadsheetEntry> inPlayersFromSpreadsheet, ObservableCollection<PlayerOnlyName> PlayersFromLogs, ObservableCollection<UnknownPlayer> unknownPlayers)
        {
            foreach(SpreadsheetEntry spreadsheetEntry in inPlayersFromSpreadsheet) 
            {
                spreadsheetEntry.Teilgenommen = "";
                spreadsheetEntry.BesonderePunkte = "";
                //TODO: Fix that, lazy shit!
                foreach (UnknownPlayer player in unknownPlayers)
                {
                    PlayerOnlyName ModifiedPlayer = PlayersFromLogs.ToList().Find(dkpPlayer => dkpPlayer.Name == player.TwinkName && !player.AddNewPlayer);
                    if (ModifiedPlayer != null)
                    {
                        ModifiedPlayer.Name = player.AssociatedMain;
                    }

                }
                foreach (PlayerOnlyName playerOnlyName in PlayersFromLogs)
                {
                    if (spreadsheetEntry.Spieler == playerOnlyName.Name)
                    {
                        spreadsheetEntry.Teilgenommen = "x";
                        break;
                    }
                }
                
            }

        }
    }
}
