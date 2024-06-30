using All_in_One.Spreadsheet_Side.Data;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.VisualLogic.Functions
{
    public static class SpreadSheetToVisu
    {
        public static void SpreadSheetToList(this ObservableCollection<SpreadsheetEntry> entries,string Raid, List<JsonSheetEntry> Sheets)
        {
            Sheet sheet = new Sheet();

            bool headerwrite = false;
            entries.Clear();
            //Data[O] because whole Sheet was requested
            foreach (var entry in Sheets.Find(entry => entry.Properties.Title == Raid).Data[0].RowData)
            {
                if (!headerwrite)
                {
                    headerwrite = true;
                    continue;
                }

                //if (!headerwrite)
                //{
                //    SpreadsheetEntry spreadsheetEntry = new SpreadsheetEntry
                //    {
                //        Spieler = entry.Values[0].FormattedValue,
                //        Punkte = entry.Values[1].FormattedValue,
                //        Teilgenommen = entry.Values[2].FormattedValue,
                //        Besondere_Leistung = entry.Values[3].FormattedValue,
                //        Stand = entry.Values[4].FormattedValue,
                //        Datum = entry.Values[5].FormattedValue,

                //    };
                //    spreadsheets.Add(spreadsheetEntry);
                //    headerwrite = true;
                //    continue;
                //}
                if (entry.Values != null && entry.Values[0].FormattedValue != null)
                {
                    SpreadsheetEntry spreadsheetEntry = new SpreadsheetEntry
                    {
                        Spieler = entry.Values[0].FormattedValue,
                        Punkte = entry.Values[1].FormattedValue,
                    };

                    if(entry.Values.Count() > 4)
                    {
                        spreadsheetEntry.Stand = entry.Values[4].FormattedValue;
                    }

                    if (entry.Values.Count() > 2 && entry.Values[2].FormattedValue == "x")
                    {
                        if (entry.Values.Count() > 3 && entry.Values[3].FormattedValue == "x")
                        {
                            spreadsheetEntry.Teilgenommen = "x";
                            spreadsheetEntry.BesonderePunkte = "x";

                        }
                        else
                        {
                            spreadsheetEntry.Teilgenommen = "x";
                        }
                    }
                    else
                    {
                        spreadsheetEntry.Teilgenommen = "";
                        spreadsheetEntry.BesonderePunkte = "";
                    }
                    entries.Add(spreadsheetEntry);
                }
            }
            
        }
    }
}
