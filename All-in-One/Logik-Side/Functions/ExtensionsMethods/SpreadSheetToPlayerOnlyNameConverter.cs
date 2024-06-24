using All_in_One.Spreadsheet_Side.Data;
using All_in_One.Logik_Side.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Logik_Side.Functions
{
    public static class SpreadSheetToPlayerOnlyNameConverter
    {
        public static void ConvertSpreadsheetToPlayerOnlyName(this ObservableCollection<PlayerOnlyName> playerOnlyNames, ObservableCollection<SpreadsheetEntry> spreadsheets) 
        {
            
            foreach(SpreadsheetEntry spreadsheetEntry in spreadsheets)
            {
                playerOnlyNames.Add(new PlayerOnlyName(spreadsheetEntry.Spieler, playerOnlyNames.Count + 1));
            }
        }
    }
}
