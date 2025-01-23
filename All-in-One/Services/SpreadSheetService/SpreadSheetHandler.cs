using All_in_One.DataModels.SpreadSheetModels;
using Aspose.Cells.Rendering;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace All_in_One.Services.SpreadSheetService
{
    public class SpreadSheetHandler
    {
        Connector connector = new();


        public async Task<List<JsonSheetEntry>> GetSpreadSheets()
        {
            var result = await connector.GetSpreadSheets();
            List<Sheet> Sheets = result.Sheets.ToList();
            Sheets.RemoveAt(7);
            return JsonSerializer.Deserialize<List<JsonSheetEntry>>(JsonSerializer.Serialize(Sheets));
        }

    }
}
