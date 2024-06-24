using All_in_One.Spreadsheet_Side.Data;
using All_in_One.Logik_Side.Data;
using All_in_One.Logik_Side.Functions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace All_in_One.Logik_Side
{
    public static class PlayerFinder
    {
        public static int FindPlayer(this ObservableCollection<UnknownPlayer> TwinkOrMain, ObservableCollection<SpreadsheetEntry> PlayersFromSpreadsheet, ObservableCollection<PlayerOnlyName> PlayerFromLogs)
        {

            if(TwinkOrMain.Count > 0)
            {
                TwinkOrMain.Clear();
            }
            foreach (var playerOnlyName in PlayerFromLogs)
            {
                
                if(!PlayersFromSpreadsheet.ToList().Exists(dkpPlayer => dkpPlayer.Spieler == playerOnlyName.Name))
                {
                    UnknownPlayer newPlayer = new UnknownPlayer(playerOnlyName.Name);
                    TwinkOrMain.Add(newPlayer);

                }
            }
            return TwinkOrMain.Count;

        }
    }
}
