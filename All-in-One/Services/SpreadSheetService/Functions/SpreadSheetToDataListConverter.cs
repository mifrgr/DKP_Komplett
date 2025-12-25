using All_in_One.Services.CalculateService.DataModels;
using All_in_One.Services.SpreadSheetService.DataModels;
using All_in_One.VisualLogic.VisualModels;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Services.SpreadSheetService.Functions
{
    public class SpreadSheetToDataListConverter
    {
        public static List<PlayerData> ConvertSpreadSheetToDataList(JsonSheetEntry Sheet)
        {
            List<PlayerData> entries = new();

            foreach (Rowdata data in Sheet.Data[0].RowData)
            {
                int index = Sheet.Data[0].RowData.ToList().IndexOf(data);
                if (Sheet.Data[0].RowData.ToList().IndexOf(data) == 0)
                {
                    continue;
                }
                entries.Add(new PlayerData()
                {
                    Name = data.Values?[0]?.FormattedValue ?? "",
                    IDs_Missed_Count = float.Parse(data.Values?[1]?.FormattedValue ?? "0"),
                    Enchantment = data.Values?[2]?.FormattedValue ?? "",
                    Consumable1 = data.Values?[3]?.FormattedValue ?? "",
                    Consumable2 = data.Values?[4]?.FormattedValue ?? "",
                    CountsPerMinute = float.Parse(data.Values?[5]?.FormattedValue ?? "0"),
                    Date = data?.Values?.Length == 9 ? data.Values[6].FormattedValue : "",
                });
            }

            return entries;

        }
    }
}
