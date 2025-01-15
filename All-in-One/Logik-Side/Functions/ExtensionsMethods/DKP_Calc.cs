using All_in_One.Spreadsheet_Side.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows;
using System.Collections.ObjectModel;
using All_in_One.Logik_Side.Data;

namespace All_in_One.Logik_Side.Functions.ExtensionsMethods;

public static class DKP_Calc
{

    public static void CalcPoints(this ObservableCollection<SpreadsheetEntry> entries)
    {
        foreach (SpreadsheetEntry entry in entries)
        {
            if (entry.Teilgenommen == "")
            {
                if (double.Parse(entry.Punkte) >= 5)
                {
                    entry.Punkte = Math.Round(decimal.Parse(entry.Punkte) - 5, 1).ToString();
                }
                else
                {
                    entry.Punkte = "0";
                }
            }
            if (entry.Teilgenommen == "x")
            {
                if (double.Parse(entry.Punkte) <= 91)
                {
                    entry.Punkte = Math.Round(decimal.Parse(entry.Punkte) + 10, 1).ToString(); ;
                }
                else if (double.Parse(entry.Punkte) == 96)
                {
                    entry.Punkte = "101";
                }
                else if (double.Parse(entry.Punkte) < 100)
                {
                    entry.Punkte = Math.Round(100 - Math.Truncate(decimal.Parse(entry.Punkte)) + decimal.Parse(entry.Punkte), 1).ToString();
                }

            }
        }

    }
}
