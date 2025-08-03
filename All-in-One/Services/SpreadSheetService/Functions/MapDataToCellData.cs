using All_in_One.Services.SpreadSheetService.DataModels;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Services.SpreadSheetService.Functions
{
    internal class MapDataToCellData
    {
        /// <summary>
        /// Erzeugt aus der Formatierungsbedingung <see cref="FormatConditions"/> und dem übergebenen Wert eine <see cref="CellData"/>  für das Spreadsheet 
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public static CellData MapToValue(string s, FormatConditions conditions)
        {
            CellData retVal = new CellData
            {
                UserEnteredValue = new ExtendedValue() { StringValue = s }
            };
            switch (conditions)
            {
                case FormatConditions.Bad:
                    {
                        retVal.UserEnteredFormat = new CellFormat() { BackgroundColorStyle = new ColorStyle() { RgbColor = new Google.Apis.Sheets.v4.Data.Color() { Red = 234f / 255f, Green = 153f / 255f, Blue = 153f / 255f } } };
                        break;
                    }
                case FormatConditions.Neutral:
                    {
                        retVal.UserEnteredFormat = new CellFormat() { BackgroundColorStyle = new ColorStyle() { RgbColor = new Google.Apis.Sheets.v4.Data.Color() { Red = 1, Green = 1, Blue = 1 } } };
                        break;
                    }
                case FormatConditions.Good:
                    {
                        retVal.UserEnteredFormat = new CellFormat() { BackgroundColorStyle = new ColorStyle() { RgbColor = new Google.Apis.Sheets.v4.Data.Color() { Red = 182f / 255f, Green = 215f / 255f, Blue = 168f / 255f } } };
                        break;
                    }
                case FormatConditions.Gold:
                    {
                        retVal.UserEnteredFormat = new CellFormat() { BackgroundColorStyle = new ColorStyle() { RgbColor = new Google.Apis.Sheets.v4.Data.Color() { Red = 255 / 255f, Green = 215f / 255f, Blue = 0 / 255f } } };

                        break;
                    }

            }
            return retVal;
        }

        public static CellData MapToValue(float d, FormatConditions conditions)
        {
            return MapToValue(d.ToString(), conditions);
        }

    }
}
