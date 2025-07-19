using All_in_One.DataModels.SpreadSheetModels;
using Google.Apis.Sheets.v4.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace All_in_One.Services.SpreadSheetService
{
    public class SpreadSheetHandler
    {
        Connector connector = new();

        /// <summary>
        /// Liest alle Spreadsheets aus und wandelt die Json Daten um.
        /// </summary>
        /// <returns>Gibt einen Task zurück, dessen Ergebnis die Spreadsheetdaten enthält</returns>
        public async Task<List<JsonSheetEntry>> GetSpreadSheets()
        {
            var result = await connector.GetSpreadSheets();
            List<Sheet> Sheets = result.Sheets.ToList();
            Sheets.RemoveAt(6);
            return JsonSerializer.Deserialize<List<JsonSheetEntry>>(JsonSerializer.Serialize(Sheets));
        }

    }
}
