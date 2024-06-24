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
            Logs_Results.SummaryLogs =  (Summary_Rootobject)JsonSerializer.Deserialize(await Get_Client.GetStreamAsync(Get_Client.BaseAddress), typeof(Summary_Rootobject));

            Handlers.visualLogicHandler.ChangeValue("Casts Logs");

            //All Casts
            Get_Client = new HttpClient()
            {
                BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/casts/" + LogID + "?end=" + endTime + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a"),
            };

            Logs_Results.CastsLogs[Spell_Category.Spell_CategoryType.Casts] = (Casts_Rootobject)JsonSerializer.Deserialize(await Get_Client.GetStreamAsync(Get_Client.BaseAddress), typeof(Casts_Rootobject));


            Handlers.visualLogicHandler.ChangeValue("Sunder Armor Logs");
            //Sunder Armor
            Get_Client = new HttpClient()
            {
                BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/casts/" + LogID + "?end=" + endTime + "&abilityid=" + (int)Spell_Category.Spell_CategoryType.SunderArmor + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a"),
            };

            Logs_Results.CastsLogs[Spell_Category.Spell_CategoryType.SunderArmor] = (Casts_Rootobject)JsonSerializer.Deserialize(await Get_Client.GetStreamAsync(Get_Client.BaseAddress), typeof(Casts_Rootobject));



            Handlers.visualLogicHandler.ChangeValue("Dispell Logs");
            //Dispell
            Get_Client = new HttpClient()
            {
                BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/casts/" + LogID + "?end=" + endTime + "&abilityid=" + (int)Spell_Category.Spell_CategoryType.Dispell + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a"),
            };

            Logs_Results.CastsLogs[Spell_Category.Spell_CategoryType.Dispell] = (Casts_Rootobject)JsonSerializer.Deserialize(await Get_Client.GetStreamAsync(Get_Client.BaseAddress), typeof(Casts_Rootobject));


            Handlers.visualLogicHandler.ChangeValue("Decurse Mage Logs");
            //Decurse-Mage. Same List as Decurse-Druid
            Get_Client = new HttpClient()
            {
                BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/casts/" + LogID + "?end=" + endTime + "&abilityid=" + (int)Spell_Category.Spell_CategoryType.Decurse_Mage + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a"),
            };

            Logs_Results.CastsLogs[Spell_Category.Spell_CategoryType.Decurse] = (Casts_Rootobject)JsonSerializer.Deserialize(await Get_Client.GetStreamAsync(Get_Client.BaseAddress), typeof(Casts_Rootobject));


            Handlers.visualLogicHandler.ChangeValue("Decurse Druid Logs");
            //Decurse-Druid. Same List as Decurse-Mage
            Get_Client = new HttpClient()
            {
                BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/casts/" + LogID + "?end=" + endTime + "&abilityid=" + (int)Spell_Category.Spell_CategoryType.Decurse_Druid + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a"),
            };

            Logs_Results.CastsLogs[Spell_Category.Spell_CategoryType.Decurse].entries = Logs_Results.CastsLogs[Spell_Category.Spell_CategoryType.Decurse].entries.Concat(JsonSerializer.Deserialize<Casts_Rootobject>(await Get_Client.GetStreamAsync(Get_Client.BaseAddress)).entries).ToArray();



            Handlers.visualLogicHandler.ChangeValue("Cleanse Pala Logs");
            //Cleanse Pala
            Get_Client = new HttpClient()
            {
                BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/casts/" + LogID + "?end=" + endTime + "&abilityid=" + (int)Spell_Category.Spell_CategoryType.Cleanse + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a"),
            };

            Logs_Results.CastsLogs[Spell_Category.Spell_CategoryType.Cleanse] = (Casts_Rootobject)JsonSerializer.Deserialize(await Get_Client.GetStreamAsync(Get_Client.BaseAddress), typeof(Casts_Rootobject));




            Handlers.visualLogicHandler.ChangeValue("Poison Druid Logs");
            //Poison - Druid
            Get_Client = new HttpClient()
            {
                BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/casts/" + LogID + "?end=" + endTime + "&abilityid=" + (int)Spell_Category.Spell_CategoryType.Abolish_Poison + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a"),
            };

            Logs_Results.CastsLogs[Spell_Category.Spell_CategoryType.Abolish_Poison] = (Casts_Rootobject)JsonSerializer.Deserialize(await Get_Client.GetStreamAsync(Get_Client.BaseAddress), typeof(Casts_Rootobject));




            Handlers.visualLogicHandler.ChangeValue("Damage Done Logs");
            //Damage-Done
            Get_Client = new HttpClient();
            Get_Client.BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/damage-done/" + LogID + "?end=" + endTime + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a");


            Logs_Results.DamageLogs = (Damage_Rootobject)JsonSerializer.Deserialize(await Get_Client.GetStreamAsync(Get_Client.BaseAddress), typeof(Damage_Rootobject));


            Handlers.visualLogicHandler.ChangeValue("Healing Done Logs");
            //Healing
            Get_Client = new HttpClient();
            Get_Client.BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/healing/" + LogID + "?end=" + endTime + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a");


            Logs_Results.HealingLogs = (Healing_Rootobject)JsonSerializer.Deserialize(await Get_Client.GetStreamAsync(Get_Client.BaseAddress), typeof(Healing_Rootobject));




            Handlers.visualLogicHandler.ChangeValue("Wisdon Debuff Logs");
            //Debuffs. Need to be filtered by the debuffs we'll be looking for. Wisdom
            Get_Client = new HttpClient();
            Get_Client.BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/debuffs/" + LogID + "?end=" + endTime + "&by=target&abilityid=" + (int)Spell_Category.Spell_CategoryType.Wisdom + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a");


            Logs_Results.DebuffLogs[Spell_Category.Spell_CategoryType.Wisdom] = (Debuff_Rootobject)JsonSerializer.Deserialize(await Get_Client.GetStreamAsync(Get_Client.BaseAddress), typeof(Debuff_Rootobject));





            Handlers.visualLogicHandler.ChangeValue("Recklessness Logs");
            //Debuffs. Need to be filtered by the debuffs we'll be looking for. Recklesness
            Get_Client = new HttpClient();
            Get_Client.BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/debuffs/" + LogID + "?end=" + endTime + "&by=target&abilityid=" + (int)Spell_Category.Spell_CategoryType.Recklessness + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a");


            Logs_Results.DebuffLogs[Spell_Category.Spell_CategoryType.Recklessness] = (Debuff_Rootobject)JsonSerializer.Deserialize(await Get_Client.GetStreamAsync(Get_Client.BaseAddress), typeof(Debuff_Rootobject));






            Handlers.visualLogicHandler.ChangeValue("Curse of Elements Logs");
            //Debuffs. Need to be filtered by the debuffs we'll be looking for. Elements
            Get_Client = new HttpClient();
            Get_Client.BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/debuffs/" + LogID + "?end=" + endTime + "&by=target&abilityid=" + (int)Spell_Category.Spell_CategoryType.Elements + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a");


            Logs_Results.DebuffLogs[Spell_Category.Spell_CategoryType.Elements] = (Debuff_Rootobject)JsonSerializer.Deserialize(await Get_Client.GetStreamAsync(Get_Client.BaseAddress), typeof(Debuff_Rootobject));




            Handlers.visualLogicHandler.ChangeValue("Curse of Shadow Logs");
            //Debuffs. Need to be filtered by the debuffs we'll be looking for. Shadow
            Get_Client = new HttpClient();
            Get_Client.BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/debuffs/" + LogID + "?end=" + endTime + "&by=target&abilityid=" + (int)Spell_Category.Spell_CategoryType.Shadow + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a");


            Logs_Results.DebuffLogs[Spell_Category.Spell_CategoryType.Shadow] = (Debuff_Rootobject)JsonSerializer.Deserialize(await Get_Client.GetStreamAsync(Get_Client.BaseAddress), typeof(Debuff_Rootobject));


            Handlers.visualLogicHandler.ChangeValue("Slice 'n Dice Logs");
            //Buffs. Need to be filtered, too. Slice and Dice
            Get_Client = new HttpClient();
            Get_Client.BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/buffs/" + LogID + "?end=" + endTime + "&abilityid=" + (int)Spell_Category.Spell_CategoryType.SliceDice + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a");


            Logs_Results.BuffsLogs[Spell_Category.Spell_CategoryType.SliceDice] = (Buffs_Rootobject)JsonSerializer.Deserialize(await Get_Client.GetStreamAsync(Get_Client.BaseAddress), typeof(Buffs_Rootobject));



            Handlers.visualLogicHandler.ChangeValue("Rapidfire Logs");
            Get_Client = new HttpClient();

            //Buffs. Need to be filtered, too. Rapidfire
            Get_Client.BaseAddress = new Uri("https://www.warcraftlogs.com/v1/report/tables/buffs/" + LogID + "?end=" + endTime + "&abilityid=" + (int)Spell_Category.Spell_CategoryType.Rapidfire + "&api_key=28bcab4294b92c0fac4df90ea4c3c59a");


            Logs_Results.BuffsLogs[Spell_Category.Spell_CategoryType.Rapidfire] = (Buffs_Rootobject)JsonSerializer.Deserialize(await Get_Client.GetStreamAsync(Get_Client.BaseAddress), typeof(Buffs_Rootobject));

            Handlers.logshandler.SetFightData();
            Handlers.visualLogicHandler.ChangeValue("Done", 0, true, true);
        }

    }
}
