using All_in_One.DataModels.SpreadSheetModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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
