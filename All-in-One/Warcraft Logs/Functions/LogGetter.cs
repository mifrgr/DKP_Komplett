using All_in_One.Logik_Side.Data;
using All_in_One.Static.Data;
using All_in_One.Warcraft_Logs;
using All_in_One.Warcraft_Logs.Data;
using All_in_One.Warcraft_Logs.LogTypes;
using DamageLogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Warcraft_API
{
    class LogGetter
    {
        internal void GetBaseLogs(string LogID)
        {
            //BaseLogs
            HttpClient Get_Client = new HttpClient()
            {
                BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/fights/" + LogID + "?api_key=28bcab4294b92c0fac4df90ea4c3c59a"),
            };

            Logs_Results.BaseLogs = (Base_Rootobject)System.Text.Json.JsonSerializer.Deserialize(Get_Client.GetStreamAsync(Get_Client.BaseAddress).Result, typeof(Base_Rootobject));           

        }

        internal void GetLogs(string LogID, long endTime) 
        {
            //Casts
            HttpClient Get_Client = new HttpClient()
            {
                BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/casts/" + LogID + "?end=" + endTime +"&api_key=28bcab4294b92c0fac4df90ea4c3c59a"),
            };

            Logs_Results.CastsLogs = (Casts_Rootobject)System.Text.Json.JsonSerializer.Deserialize(Get_Client.GetStreamAsync(Get_Client.BaseAddress).Result, typeof(Casts_Rootobject));
            //TODO: Fix that.
            Handlers.visualLogicHandler.ChangeValue();



            //Damage-Done
            Get_Client = new HttpClient();
            Get_Client.BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/damage-done/" + LogID + "?end=" + endTime + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a");


            Logs_Results.DamageLogs = (Damage_Rootobject)System.Text.Json.JsonSerializer.Deserialize(Get_Client.GetStreamAsync(Get_Client.BaseAddress).Result, typeof(Damage_Rootobject));

            Handlers.visualLogicHandler.ChangeValue();


            //Healing
            Get_Client = new HttpClient();
            Get_Client.BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/healing/" + LogID + "?end=" + endTime + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a");


            Logs_Results.HealingLogs = (HealingLogs.Healing_Rootobject)System.Text.Json.JsonSerializer.Deserialize(Get_Client.GetStreamAsync(Get_Client.BaseAddress).Result, typeof(HealingLogs.Healing_Rootobject));

            Handlers.visualLogicHandler.ChangeValue();




            //Debuffs. Need to be filtered by the debuffs we'll be looking for. Wisdom
            Get_Client = new HttpClient();
            Get_Client.BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/debuffs/" + LogID + "?end=" + endTime + "&by=target&abilityid=" + (int)Spell_Category.Spell_CategoryType.Wisdom + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a");


            Logs_Results.DebuffLogs[Spell_Category.Spell_CategoryType.Wisdom] = (Debuff_Rootobject)System.Text.Json.JsonSerializer.Deserialize(Get_Client.GetStreamAsync(Get_Client.BaseAddress).Result, typeof(Debuff_Rootobject));

            Handlers.visualLogicHandler.ChangeValue();




            //Debuffs. Need to be filtered by the debuffs we'll be looking for. Recklesness
            Get_Client = new HttpClient();
            Get_Client.BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/debuffs/" + LogID + "?end=" + endTime + "&by=target&abilityid=" + (int)Spell_Category.Spell_CategoryType.Recklessness + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a");


            Logs_Results.DebuffLogs[Spell_Category.Spell_CategoryType.Recklessness] = (Debuff_Rootobject)System.Text.Json.JsonSerializer.Deserialize(Get_Client.GetStreamAsync(Get_Client.BaseAddress).Result, typeof(Debuff_Rootobject));

            Handlers.visualLogicHandler.ChangeValue();





            //Debuffs. Need to be filtered by the debuffs we'll be looking for. Elements
            Get_Client = new HttpClient();
            Get_Client.BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/debuffs/" + LogID + "?end=" + endTime + "&by=target&abilityid=" + (int)Spell_Category.Spell_CategoryType.Elements + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a");


            Logs_Results.DebuffLogs[Spell_Category.Spell_CategoryType.Elements] = (Debuff_Rootobject)System.Text.Json.JsonSerializer.Deserialize(Get_Client.GetStreamAsync(Get_Client.BaseAddress).Result, typeof(Debuff_Rootobject));

            Handlers.visualLogicHandler.ChangeValue();




            //Debuffs. Need to be filtered by the debuffs we'll be looking for. Shadow
            Get_Client = new HttpClient();
            Get_Client.BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/debuffs/" + LogID + "?end=" + endTime + "&by=target&abilityid=" + (int)Spell_Category.Spell_CategoryType.Shadow + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a");


            Logs_Results.DebuffLogs[Spell_Category.Spell_CategoryType.Shadow] = (Debuff_Rootobject)System.Text.Json.JsonSerializer.Deserialize(Get_Client.GetStreamAsync(Get_Client.BaseAddress).Result, typeof(Debuff_Rootobject));

            Handlers.visualLogicHandler.ChangeValue();
        }

    }
}
