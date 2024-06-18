using All_in_One.Entrys;
using All_in_One.Spreadsheet_Side;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.VisualLogic.Functions
{
    internal class SpreadSheetToVisu
    {
        public void SpreadSheetToList(SpreadSheets RaidType, List<SpreadsheetEntry> InSpreadsheets, List<Sheet> Sheet, out List<SpreadsheetEntry> OutSpreadSheets)
        {
            bool headerwrite = false; ;
            InSpreadsheets.Clear();
            foreach (RowData entry in Sheet[(int)RaidType].Data[0].RowData)
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


                    if (entry.Values.Count > 2 && entry.Values[2].FormattedValue == "x")
                    {
                        if (entry.Values.Count > 3 && entry.Values[3].FormattedValue == "x")
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
                    InSpreadsheets.Add(spreadsheetEntry);
                }
            }
            OutSpreadSheets = InSpreadsheets;
        }
    }
}
