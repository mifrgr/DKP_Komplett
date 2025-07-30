using All_in_One.Services.CalculateService.DataModels;
using All_in_One.Services.SpreadSheetService.DataModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace All_in_One.VisualLogic.Functions.ExtensionMethods
{
    public static class ListGetOnlyNames
    {
        public static List<string> GetOnlyNamesFromList(this ObservableCollection<PlayerData> spreadsheetEntries)
        {
            List<string> list = new List<string>();
            spreadsheetEntries.ToList().ForEach(spreadsheetEntries => { list.Add(spreadsheetEntries.Name); });
            list.Sort();
            return list;
        }
    }
}
