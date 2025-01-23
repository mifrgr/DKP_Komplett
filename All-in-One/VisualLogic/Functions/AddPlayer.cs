using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using All_in_One.DataModels.PlayerModels;
using All_in_One.DataModels.SpreadSheetModels;

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
