using All_in_One.Services.CalculateService.DataModels;
using All_in_One.Services.SpreadSheetService.DataModels;
using All_in_One.Static.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Services.SpreadSheetService.Functions
{
    public class SpreadSheetToBossDKPValueConverter
    {
        public static List<BossDKPBaseClass> ConvertSpreadsheetDataToBossDKP(JsonSheetEntry Sheet)
        {
            var entries = new List<BossDKPBaseClass>();

            foreach (Rowdata data in Sheet.Data[0].RowData)
            {
                int index = Sheet.Data[0].RowData.ToList().IndexOf(data);
                if (Sheet.Data[0].RowData.ToList().IndexOf(data) == 0)
                {
                    continue;
                }
                entries.Add(new BossDKPBaseClass(data.Values?[0]?.FormattedValue ?? "", int.Parse(data.Values?[2]?.FormattedValue ?? "0")));
            }

            return entries;

        }
    }
}
