using All_in_One.Spreadsheet_Side.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.VisualLogic.Functions.ExtensionMethods
{
    public static class ListGetOnlyNames
    {
        public static List<string> GetOnlyNamesFromList(this ObservableCollection<SpreadsheetEntry> spreadsheetEntries)
        {
            List<string> list = new List<string>();
            spreadsheetEntries.ToList().ForEach(spreadsheetEntries => { list.Add(spreadsheetEntries.Spieler); });
            list.Sort();
            return list;
        }
    }
}
