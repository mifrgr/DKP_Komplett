using Google.Apis.Sheets.v4.Data;
using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using System.IO;
using System.Windows;

namespace All_in_One.Spreadsheet
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
        

        public List<Sheet> Connect()
        {
            SpreadsheetsResource.GetRequest request = sheetsService.Spreadsheets.Get(spreadId);
            //resource = sheetsService.Spreadsheets;
            request.IncludeGridData = true;
            return ExecuteReading(request);
        }

        public List<Sheet> ExecuteReading(SpreadsheetsResource.GetRequest request)
        {
            return request.Execute().Sheets.ToList();
        }
    }
}
