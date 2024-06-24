using All_in_One.Spreadsheet_Side.Data;
using All_in_One.Logik_Side.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.VisualLogic.Functions
{
    public static  class AddPlayer
    {
        public static void AddPlayers(this ObservableCollection<SpreadsheetEntry> entries, ObservableCollection<UnknownPlayer> TwinksOrNewPlayers)
        {

            foreach (var entry in TwinksOrNewPlayers)
            {
                if (entry.AddNewPlayer)
                {
                    entries.Add(new SpreadsheetEntry
                    {
                        Spieler = entry.TwinkName,
                        Teilgenommen = "x",
                        Punkte = "0",


                    });
                }
            }

        }
    }
}
