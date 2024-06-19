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
using System.Windows.Controls;

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
            //Summary Logs. Need that for MT DKP
            HttpClient Get_Client = new HttpClient()
            {
                BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/summary/" + LogID + "?end=" + endTime + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a"),
            };

            Logs_Results.SummaryLogs = (Summary_Rootobject)System.Text.Json.JsonSerializer.Deserialize(Get_Client.GetStreamAsync(Get_Client.BaseAddress).Result, typeof(Summary_Rootobject));


            //TODO: Fix that.
            Handlers.visualLogicHandler.ChangeValue();

            //All Casts
            Get_Client = new HttpClient()
            {
                BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/casts/" + LogID + "?end=" + endTime + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a"),
            };

            Logs_Results.CastsLogs[Spell_Category.Spell_CategoryType.Casts] = (Casts_Rootobject)System.Text.Json.JsonSerializer.Deserialize(Get_Client.GetStreamAsync(Get_Client.BaseAddress).Result, typeof(Casts_Rootobject));


            Handlers.visualLogicHandler.ChangeValue();

            //Sunder Armor
            Get_Client = new HttpClient()
            {
                BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/casts/" + LogID + "?end=" + endTime + "&by=target&abilityid=" + (int)Spell_Category.Spell_CategoryType.SunderArmor + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a"),
            };

            Logs_Results.CastsLogs[Spell_Category.Spell_CategoryType.SunderArmor] = (Casts_Rootobject)System.Text.Json.JsonSerializer.Deserialize(Get_Client.GetStreamAsync(Get_Client.BaseAddress).Result, typeof(Casts_Rootobject));
            
            
            Handlers.visualLogicHandler.ChangeValue();



            //Dispell
            Get_Client = new HttpClient()
            {
                BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/casts/" + LogID + "?end=" + endTime + "&abilityid=" + (int)Spell_Category.Spell_CategoryType.Dispell + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a"),
            };

            Logs_Results.CastsLogs[Spell_Category.Spell_CategoryType.Dispell] = (Casts_Rootobject)System.Text.Json.JsonSerializer.Deserialize(Get_Client.GetStreamAsync(Get_Client.BaseAddress).Result, typeof(Casts_Rootobject));


            Handlers.visualLogicHandler.ChangeValue();


            //Decurse-Mage. Same List as Decurse-Druid
            Get_Client = new HttpClient()
            {
                BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/casts/" + LogID + "?end=" + endTime + "&abilityid=" + (int)Spell_Category.Spell_CategoryType.Decurse_Mage + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a"),
            };

            Logs_Results.CastsLogs[Spell_Category.Spell_CategoryType.Decurse] = (Casts_Rootobject)System.Text.Json.JsonSerializer.Deserialize(Get_Client.GetStreamAsync(Get_Client.BaseAddress).Result, typeof(Casts_Rootobject));


            Handlers.visualLogicHandler.ChangeValue();

            //Decurse-Druid. Same List as Decurse-Mage
            Get_Client = new HttpClient()
            {
                BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/casts/" + LogID + "?end=" + endTime + "&abilityid=" + (int)Spell_Category.Spell_CategoryType.Decurse_Druid + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a"),
            };

            Logs_Results.CastsLogs[Spell_Category.Spell_CategoryType.Decurse].entries.Concat(((Casts_Rootobject)System.Text.Json.JsonSerializer.Deserialize(Get_Client.GetStreamAsync(Get_Client.BaseAddress).Result, typeof(Casts_Rootobject))).entries);


            Handlers.visualLogicHandler.ChangeValue();

            //Cleanse Pala
            Get_Client = new HttpClient()
            {
                BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/casts/" + LogID + "?end=" + endTime + "&abilityid=" + (int)Spell_Category.Spell_CategoryType.Cleanse + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a"),
            };

            Logs_Results.CastsLogs[Spell_Category.Spell_CategoryType.Cleanse] = (Casts_Rootobject)System.Text.Json.JsonSerializer.Deserialize(Get_Client.GetStreamAsync(Get_Client.BaseAddress).Result, typeof(Casts_Rootobject));


            Handlers.visualLogicHandler.ChangeValue();

            //Poison - Druid
            Get_Client = new HttpClient()
            {
                BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/casts/" + LogID + "?end=" + endTime + "&abilityid=" + (int)Spell_Category.Spell_CategoryType.Abolish_Poison + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a"),
            };

            Logs_Results.CastsLogs[Spell_Category.Spell_CategoryType.Abolish_Poison] = (Casts_Rootobject)System.Text.Json.JsonSerializer.Deserialize(Get_Client.GetStreamAsync(Get_Client.BaseAddress).Result, typeof(Casts_Rootobject));


            Handlers.visualLogicHandler.ChangeValue();


            //Damage-Done
            Get_Client = new HttpClient();
            Get_Client.BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/damage-done/" + LogID + "?end=" + endTime + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a");


            Logs_Results.DamageLogs = (Damage_Rootobject)System.Text.Json.JsonSerializer.Deserialize(Get_Client.GetStreamAsync(Get_Client.BaseAddress).Result, typeof(Damage_Rootobject));

            Handlers.visualLogicHandler.ChangeValue();


            //Healing
            Get_Client = new HttpClient();
            Get_Client.BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/healing/" + LogID + "?end=" + endTime + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a");


            Logs_Results.HealingLogs = (Healing_Rootobject)System.Text.Json.JsonSerializer.Deserialize(Get_Client.GetStreamAsync(Get_Client.BaseAddress).Result, typeof(Healing_Rootobject));

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

            //Buffs. Need to be filtered, too. Slice and Dice
            Get_Client = new HttpClient();
            Get_Client.BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/buffs/" + LogID + "?end=" + endTime + "&abilityid=" + (int)Spell_Category.Spell_CategoryType.SliceDice + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a");


            Logs_Results.BuffsLogs[Spell_Category.Spell_CategoryType.SliceDice] = (Buffs_Rootobject)System.Text.Json.JsonSerializer.Deserialize(Get_Client.GetStreamAsync(Get_Client.BaseAddress).Result, typeof(Buffs_Rootobject));

            Handlers.visualLogicHandler.ChangeValue();

            Get_Client = new HttpClient();

            //Buffs. Need to be filtered, too. Rapidfire
            Get_Client.BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/buffs/" + LogID + "?end=" + endTime + "&abilityid=" + (int)Spell_Category.Spell_CategoryType.Rapidfire + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a");


            Logs_Results.BuffsLogs[Spell_Category.Spell_CategoryType.Rapidfire] = (Buffs_Rootobject)System.Text.Json.JsonSerializer.Deserialize(Get_Client.GetStreamAsync(Get_Client.BaseAddress).Result, typeof(Buffs_Rootobject));

            Handlers.visualLogicHandler.ChangeValue();


        }

    }
}
