using All_in_One.Services.SpreadSheetService.DataModels;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using All_in_One.Services.CalculateService.DataModels;

namespace All_in_One.Services.SpreadSheetService.Functions
{
    internal class DataHandler
    {
        /// <summary>
        /// Liest alle Spreadsheets aus
        /// </summary>
        /// <returns>Gibt einen Task zurück, dessen Ergebnis die Spreadsheetdaten enthält</returns>
        public async Task<Spreadsheet> GetSpreadSheets(SheetsService service, string spreadID)
        {
            SpreadsheetsResource.GetRequest request = service.Spreadsheets.Get(spreadID);
            request.IncludeGridData = true;
            return await request.ExecuteAsync();
        }

        public async Task<BatchUpdateSpreadsheetResponse> UpdateSpreadSheets(List<PlayerData> spreadsheetData, SheetsService sheetsService)
        {
            var batchUpdate = new BatchUpdateSpreadsheetRequest()
            {
                Requests = DataListToSpreadSheetConverter.ConvertSpreadsheetDataToSpradsheetUpdateObjet(spreadsheetData)
            };

            var batchUpdateRequest = sheetsService.Spreadsheets.BatchUpdate(batchUpdate, SpreadSheetService.spreadId);
            return await batchUpdateRequest.ExecuteAsync();
        }
    }
}
