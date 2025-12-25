using All_in_One.Services.CalculateService.DataModels;
using All_in_One.Services.SpreadSheetService.DataModels;
using All_in_One.VisualLogic.Functions;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Services.CalculateService.Functions
{
    public class DataUpdater
    {
        public List<PlayerData> UpdateDKPData(List<PlayerExtractedData> playerExtractedDatas, List<PlayerData> spreadsheetEntries)
        {
            var oldPlayers = spreadsheetEntries.IntersectBy(playerExtractedDatas.Select(p => p.PlayerName), entry => entry.Name);
            var newPlayers = playerExtractedDatas.ExceptBy(spreadsheetEntries.Select(s => s.Name), player => player.PlayerName);
            var absentPlayers = spreadsheetEntries.ExceptBy(playerExtractedDatas.Select(p => p.PlayerName), s => s.Name);

            List<PlayerData> retEntries = new();
            foreach (var oldPlayer in oldPlayers)
            {
                retEntries.Add(HandleOldPlayer(oldPlayer, playerExtractedDatas));
            }
            foreach (var absentPlayer in absentPlayers)
            {
                retEntries.Add(HandleAbsentPlayer(absentPlayer));
            }
            foreach (var newPlayer in newPlayers)
            {
                retEntries.Add(HandleNewPlayer(newPlayer));
            }

            return retEntries;
        }

        PlayerData HandleNewPlayer(PlayerExtractedData playerLogData)
        {
            PlayerData entry = new();
            entry.Name = playerLogData.PlayerName;
            entry.IDs_Missed_Count = 0;
            entry.Enchantment = playerLogData.Enchantment;
            entry.Consumable1 = playerLogData.Consumable1;
            entry.Consumable2 = playerLogData.Consumable2;
            entry.CountsPerMinute = playerLogData.CountPerMinutes;
            entry.Date = "";
            return entry;
        }
        PlayerData HandleAbsentPlayer(PlayerData absentPlayer)
        {
            absentPlayer.IDs_Missed_Count = absentPlayer.IDs_Missed_Count + 1;
            return absentPlayer;
        }

        PlayerData HandleOldPlayer(PlayerData oldPlayer, List<PlayerExtractedData> playerExtractedDatas)
        {
            var playerLogData = playerExtractedDatas.Find(player => player.PlayerName == oldPlayer.Name);

            oldPlayer.IDs_Missed_Count = 0;
            oldPlayer.Enchantment = playerLogData.Enchantment;
            oldPlayer.Consumable1 = playerLogData.Consumable1;
            oldPlayer.Consumable2 = playerLogData.Consumable2;
            oldPlayer.CountsPerMinute = playerLogData.CountPerMinutes;
            return oldPlayer;
        }
    }
}
