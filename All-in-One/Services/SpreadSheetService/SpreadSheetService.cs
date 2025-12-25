using All_in_One.Services.CalculateService.DataModels;
using All_in_One.Services.SpreadSheetService.DataModels;
using All_in_One.Services.SpreadSheetService.Functions;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace All_in_One.Services.SpreadSheetService
{
    public class SpreadSheetService
    {
        public static readonly string spreadId = "1CoRMUBGOzzGkC8ZXLJqYoN2xVZbFa9qAyl71KzzC5fY";
        //SpreadsheetsResource resource;
        private SheetsService sheetsService;

        DataHandler dataHandler = new DataHandler();

        public SpreadSheetService()
        {
            sheetsService = new SheetsService(new BaseClientService.Initializer
            {
                HttpClientInitializer = GoogleCredential.FromFile("dkp-evershire-rids-9397f0d50e94.json"),
                ApplicationName = "DKP-Project0.1",
            });
        }

        /// <summary>
        /// Liest alle Spreadsheets aus und wandelt die Json Daten um.
        /// </summary>
        /// <returns>Gibt einen Task zurück, dessen Ergebnis die Spreadsheetdaten enthält</returns>
        public async Task<List<JsonSheetEntry>> GetSpreadSheets()
        {
            var result = await dataHandler.GetSpreadSheets(sheetsService,spreadId);
            List<Sheet> Sheets = result.Sheets.ToList();
            return JsonSerializer.Deserialize<List<JsonSheetEntry>>(JsonSerializer.Serialize(Sheets));
        }

        public List<PlayerData> GetSpreadSheetConvertedData(JsonSheetEntry sheets)
        {
            return SpreadSheetToDataListConverter.ConvertSpreadSheetToDataList(sheets);
        }

        public Task<BatchUpdateSpreadsheetResponse> UpdateSpreadSheetData(List<PlayerData> SheetData)
        {
            return dataHandler.UpdateSpreadSheets(SheetData,sheetsService);
        }

    }


}
