using All_in_One.DataModels.WarcraftlogsModels;
using All_in_One.DataModels.WarcraftLogsModels.LogTypes;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace All_in_One.Services.WarcraftLogsService
{
    class LoadFunctions
    {
        internal async Task<List<Guild_Rootobject>> GetGuildLogs()
        {
            //Guild Logs. Need for dropdown of last Raids
            HttpClient Get_Client = new HttpClient()
            {
                BaseAddress = new Uri("https://vanilla.warcraftlogs.com/v1/reports/guild/" + "Schwarzer Drachenschwarm/Lakeshire/EU?api_key=28bcab4294b92c0fac4df90ea4c3c59a"),
            };
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Guild_Rootobject>>(await Get_Client.GetStringAsync(Get_Client.BaseAddress));
        }

        internal async Task<LogsDataObject> LoadLogs(string LogID)
        {
            LogsDataObject result = new LogsDataObject();
            //BaseLogs
            HttpClient Get_Client = new HttpClient()
            {
                BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/fights/" + LogID + "?api_key=28bcab4294b92c0fac4df90ea4c3c59a"),
            };

            result.baseLogs = (Base_Rootobject)JsonSerializer.Deserialize(await Get_Client.GetStreamAsync(Get_Client.BaseAddress), typeof(Base_Rootobject));


            Get_Client = new HttpClient()
            {
                BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/casts/" + LogID + "?end=" + result.baseLogs.end + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a"),
            };
            result.castsLogs = (Casts_Rootobject)JsonSerializer.Deserialize(await Get_Client.GetStreamAsync(Get_Client.BaseAddress), typeof(Casts_Rootobject));

            return result;
        }

    }
}
