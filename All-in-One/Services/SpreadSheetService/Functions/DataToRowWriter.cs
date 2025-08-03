using All_in_One.Services.CalculateService.DataModels;
using All_in_One.Services.SpreadSheetService.DataModels;
using All_in_One.Static.Data;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Services.SpreadSheetService.Functions
{
    internal class DataToRowWriter
    {
        public static List<CellData> WriteDataToRow(PlayerData player)
        {

            List<CellData> cellData = new()
            {
                MapDataToCellData.MapToValue(player.Name,FormatConditions.Neutral),
                MapDataToCellData.MapToValue(player.IDs_Count,player.IDs_Count >= BonusConditions.NumberOfRaids ? FormatConditions.Good : FormatConditions.Bad),
                MapDataToCellData.MapToValue(player.IDs_Golddrache_Count,player.IDs_Golddrache_Count >= BonusConditions.NumberOfRaidsGold ? FormatConditions.Gold : FormatConditions.Neutral),
                MapDataToCellData.MapToValue(player.IDs_Missed_Count,player.IDs_Missed_Count <= BonusConditions.AcceptedMissedRaid ? FormatConditions.Neutral : FormatConditions.Bad),
                MapDataToCellData.MapToValue(player.Enchantment,player.Enchantment == "" ? FormatConditions.Neutral : FormatConditions.Bad),
                MapDataToCellData.MapToValue(player.Consumable1,player.Consumable1 != "" ? FormatConditions.Neutral : FormatConditions.Bad),
                MapDataToCellData.MapToValue(player.Consumable2,player.Consumable2 != "" ? FormatConditions.Neutral : FormatConditions.Bad),
                MapDataToCellData.MapToValue(player.CountsPerMinute,player.CountsPerMinute >= BonusConditions.CountsPerMinuteReq ? FormatConditions.Neutral : FormatConditions.Bad),
                MapDataToCellData.MapToValue(player.Date,FormatConditions.Neutral),
            };
            return cellData;
            

        }
    }
}
