using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using All_in_One.Services.SpreadSheetService.DataModels;
using All_in_One.Services.CalculateService.DataModels;

namespace All_in_One.Services.SpreadSheetService.Functions
{
    internal class DataListToSpreadSheetConverter
    {
        public static List<Request> ConvertSpreadsheetDataToSpradsheetUpdateObjet(List<PlayerData> entries)
        {
            List<Request> ListOfRequests = new();
            Request request = new Request();

            UpdateCellsRequest UpdateCellsRequest = new UpdateCellsRequest();
            UpdateCellsRequest.Fields = "*";
            UpdateCellsRequest.Range = new GridRange()
            {
                SheetId = 641158770,               
                StartRowIndex = 1,
                StartColumnIndex = 0,
            };
            List<RowData> rows = new();
            foreach (PlayerData entry in entries)
            {
                RowData rowData = new RowData();               
                rowData.Values = DataToRowWriter.WriteDataToRow(entry);
                rows.Add(rowData);
            }
            UpdateCellsRequest.Rows = rows;
            request.UpdateCells = UpdateCellsRequest;
            ListOfRequests.Add(request);
            return ListOfRequests;
        }
    }
}
