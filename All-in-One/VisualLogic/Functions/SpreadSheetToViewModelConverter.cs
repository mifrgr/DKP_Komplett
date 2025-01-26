using All_in_One.DataModels.SpreadSheetModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.VisualLogic.Functions
{
    class SpreadSheetToViewModelConverter
    {
        public ObservableCollection<SpreadsheetEntry> ConvertSpreadSheetToViewModel(JsonSheetEntry Sheet)
        {
            ObservableCollection<SpreadsheetEntry> entries = new ObservableCollection<SpreadsheetEntry>();

            foreach(Rowdata data in Sheet.Data[0].RowData)
            {
                int i = data.Values.Length;
                int j = data.Values.Count();
                entries.Add(new SpreadsheetEntry()
                {
                    Spieler = data.Values.Count() < 1 ? "" : data.Values[0].FormattedValue,
                    Punkte = data.Values.Count() < 2 ? "" : data.Values[1].FormattedValue,
                    Teilgenommen = data.Values.Count() < 3 ? "" : data.Values[2].FormattedValue,
                    ActiveTime = data.Values.Count() < 4 ? "" : data.Values[3].FormattedValue,
                    Consumables1 = data.Values.Count() < 5 ? "" : data.Values[4].FormattedValue,
                    Verzauberungen = data.Values.Count() < 6 ? "" : data.Values[5].FormattedValue,
                    Consumable2 = data.Values.Count() < 7 ? "" : data.Values[6].FormattedValue,
                    Datum = data.Values.Count() < 8 ? "" : data.Values[7].FormattedValue,

                });
            }

            return entries;
        }
    }
}
