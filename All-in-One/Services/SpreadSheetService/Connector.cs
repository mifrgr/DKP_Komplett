using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System.Threading.Tasks;

namespace All_in_One.Services.SpreadSheetService
{
    internal class Connector
    {
        private string spreadId = "1CoRMUBGOzzGkC8ZXLJqYoN2xVZbFa9qAyl71KzzC5fY";
        //SpreadsheetsResource resource;
        private SheetsService sheetsService;

        public Connector()
        {
            sheetsService = new SheetsService(new BaseClientService.Initializer
            {
                HttpClientInitializer = GoogleCredential.FromFile("dkp-evershire-rids-9397f0d50e94.json"),
                ApplicationName = "DKP-Project0.1",
            });
        }

        /// <summary>
        /// Liest alle Spreadsheets aus
        /// </summary>
        /// <returns>Gibt einen Task zurück, dessen Ergebnis die Spreadsheetdaten enthält</returns>
        public async Task<Spreadsheet> GetSpreadSheets()
        {
            SpreadsheetsResource.GetRequest request = sheetsService.Spreadsheets.Get(spreadId);
            request.IncludeGridData = true;
            return await request.ExecuteAsync();
        }
    }
}
