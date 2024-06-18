using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Warcraft_Logs
{
    internal class LogGetter_BestInCat
    {
        public DamageLogs.Damage_Rootobject GetLogs(string LogType, string LogID)
        {
            HttpClient Get_Client = new HttpClient()
            {
                BaseAddress = new Uri("https://www.warcraftlogs.com:443/v1/report/tables/" + LogType +"/" + LogID + "?start=0&end=1000000000000&api_key=28bcab4294b92c0fac4df90ea4c3c59a"),
            };

            DamageLogs.Damage_Rootobject retVal;
            try
            {
                retVal = (DamageLogs.Damage_Rootobject)System.Text.Json.JsonSerializer.Deserialize(Get_Client.GetStreamAsync(Get_Client.BaseAddress).Result, typeof(DamageLogs.Damage_Rootobject));
            }
            catch (Exception ex)
            {
                retVal = (DamageLogs.Damage_Rootobject)System.Text.Json.JsonSerializer.Deserialize(Get_Client.GetStreamAsync(Get_Client.BaseAddress).Result, typeof(DamageLogs.Damage_Rootobject));
            }
            return retVal;

        }
    }
}
