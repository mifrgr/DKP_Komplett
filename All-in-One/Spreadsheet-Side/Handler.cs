using All_in_One.Spreadsheet_Side.Data;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Spreadsheet
{
    public class Handler
    {
        Connector connector = new();
        public List<Sheet> Sheets = new List<Sheet>();
        public List<JsonSheetEntry> SpreadsheetAsJson = new();

        public void ConnectToSpreadsheet()
        {
            Sheets = connector.Connect();
        }
    }
}
