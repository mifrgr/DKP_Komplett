using All_in_One.Logik_Side.Data;
using All_in_One.Static.Data;
using All_in_One.Warcraft_Logs.Data;
using System;
using System.Net.Http;
using All_in_One.Warcraft_Logs.LogTypes.Base;
using All_in_One.Warcraft_Logs.LogTypes.Buffs;
using All_in_One.Warcraft_Logs.LogTypes.Casts;
using All_in_One.Warcraft_Logs.LogTypes.Damage;
using All_in_One.Warcraft_Logs.LogTypes.Debuffs;
using All_in_One.Warcraft_Logs.LogTypes.Healing;
using All_in_One.Warcraft_Logs.LogTypes.Summary;
using System.Linq;
using All_in_One.Warcraft_Logs.LogTypes.Guild;
using System.Text.Json;
using System.Collections.Generic;

namespace All_in_One.Warcraft_API
{
    class LogGetter
    {
        internal async void GetGuildLogs()
        {
            //Guild Logs. Need for dropdown of last Raids
            HttpClient Get_Client = new HttpClient()
            {
                BaseAddress = new Uri("https://vanilla.warcraftlogs.com/v1/reports/guild/" + "Schwarzer Drachenschwarm/Lakeshire/EU?api_key=28bcab4294b92c0fac4df90ea4c3c59a"),
            };
            Logs_Results.GuildLogs = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Guild_Rootobject>>(await Get_Client.GetStringAsync(Get_Client.BaseAddress));
            Handlers.visualLogicHandler.ConvertLogsToDropDown(Logs_Results.GuildLogs);
        }

        internal async void GetAllLogs(string LogID)
        {
            Handlers.visualLogicHandler.ChangeValue("Init", 0, false);
            Handlers.visualLogicHandler.ChangeValue("Base Logs");
            //BaseLogs
            HttpClient Get_Client = new HttpClient()
            {
                BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/fights/" + LogID + "?api_key=28bcab4294b92c0fac4df90ea4c3c59a"),
            };

            Logs_Results.BaseLogs = (Base_Rootobject)JsonSerializer.Deserialize(await Get_Client.GetStreamAsync(Get_Client.BaseAddress), typeof(Base_Rootobject));

            Handlers.logshandler.SetBaseData();
            Handlers.visualLogicHandler.ConvertLogsToDataGrid(Logs_Results.BaseLogs);
            GetLogs(LogID, Handlers.logshandler.GetEndTime());
        }

        internal async void GetLogs(string LogID, long endTime)
        {

            Handlers.visualLogicHandler.ChangeValue("Summary Logs");

            //Summary Logs. Need that for MT DKP
            HttpClient Get_Client = new HttpClient()
            {
                BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/summary/" + LogID + "?end=" + endTime + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a"),
            };
            Logs_Results.SummaryLogs = (Summary_Rootobject)JsonSerializer.Deserialize(await Get_Client.GetStreamAsync(Get_Client.BaseAddress), typeof(Summary_Rootobject));


        }
    }
}
