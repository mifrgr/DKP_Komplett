using All_in_One.DataModels.PlayerModels;
using All_in_One.Services.CalculateService.DataModels;
using All_in_One.Services.SpreadSheetService.DataModels;
using All_in_One.Services.WarcraftLogsService.WarcraftlogsModels;
using All_in_One.Services.WarcraftLogsService.WarcraftlogsModels.LogTypes;
using All_in_One.Static.Data;
using All_in_One.VisualLogic.Functions;
using All_in_One.VisualLogic.VisualModels;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace All_in_One.Services
{
    class MainService
    {
        public VisualLogic.ViewModell visualViewModeel { get; private set; } = new VisualLogic.ViewModell();
        private CalculateService.CalculateService calculateHandler = new CalculateService.CalculateService();
        private SpreadSheetService.SpreadSheetService spreadSheetHandler = new SpreadSheetService.SpreadSheetService();
        private WarcraftLogsService.WarcraftHandler logsHandler = new WarcraftLogsService.WarcraftHandler();

       
        public static MainService Instance { get; private set; } = new MainService();
        /// <summary>
        /// Aktuelle DKP-Liste des aktuellen Raids
        /// </summary>
        public List<PlayerData> DKPListFromSpreadSheet { get; set; } = new();


        public List<PlayerExtractedData> PlayerExtractedDatas { get; set; } = new List<PlayerExtractedData> { };

        public List<Guild_Rootobject> LastRaids {  get; set; }

        LogsDataObject logs;
        string selectedRaid = "";

        public List<JsonSheetEntry> SpreadsheetAsJson = new();

        /// <summary>
        /// Startet die DKP-Auswertung für jeden Spieler. Aktualisiert das Datum und entfernt inaktive Spieler
        /// </summary>
        public void CalculateDKP()
        {
            DKPListFromSpreadSheet[0].Date = selectedRaid.Split("|")[1].Trim();
            TidyUp();
        }


        /// <summary>
        /// Initialisiert das Programm.
        /// Die Spreadsheets werden abgerufen.
        /// Die letzten Logs werden ausgelesen und als Auswahlmenü angezeigt
        /// </summary>
        public async Task Init()
        {
            try
            {
                visualViewModeel.ProgressBarControll(true);

                LastRaids = await logsHandler.GetLastRaids();
                SpreadsheetAsJson = await spreadSheetHandler.GetSpreadSheets();
                visualViewModeel.Init(SpreadsheetAsJson);
                               
                visualViewModeel.ProgressBarControll();
            }
            catch(Exception ex) 
            {
                visualViewModeel.ProgressBarControll(true, ex.Message);
            }
        }

        /// <summary>
        /// Die DKPs werden aus dem ausgewählten Spreadsheet ausgelesen. DKPs sind Raidgebunden. Für jeden Raid existiert ein eigenes Sheet.
        /// 
        /// <para>Die Daten werden als Grid in der GUI angezeigt.</para>
        /// 
        /// Es werden unbekannte Spieler ermittelt und angezeigt.
        /// </summary>
        /// <param name="SelectedRaid"></param>
        public async Task GetDKPFromSpreadSheet(string SelectedRaid)
        {
            visualViewModeel.ProgressBarControll(true);
            //foreach (var item in RaidCheckBoxCollection)
            //{
            //    if (item.Content != SelectedRaid)
            //    {
            //        item.IsChecked = false;
            //    }
            //}
            SpreadsheetAsJson = await spreadSheetHandler.GetSpreadSheets();

            DKPListFromSpreadSheet = spreadSheetHandler.GetSpreadSheetConvertedData(SpreadsheetAsJson.Find(entry => entry.Properties.Title == SelectedRaid));

            if (logs != null)
            {
            }
            visualViewModeel.ProgressBarControll();
        }



        /// <summary>
        /// Es werden die Daten des ausgewählten Raids aus den Logs ausgelesen, die zur Berechnung erforderlich sind.
        /// </summary>
        /// <param name="SelectedRaid"></param>
        public async Task GetDataFromLog(string SelectedRaid)
        {
            visualViewModeel.ProgressBarControll(true);
            selectedRaid = SelectedRaid;
            logs = await logsHandler.GetLogfromWarcraftLogs(SelectedRaid.Split("|")[2].Trim());
            PlayerExtractedDatas = calculateHandler.GetPlayerDKPRequirement(logs);
            visualViewModeel.ProgressBarControll();
            await GetLocalLogTextFile(SelectedRaid.Split("|")[1].Trim());
        }
        /// <summary>
        /// Liest die vom WoW-Client mitgeschriebenen Logdaten aus.
        /// </summary>
        /// <param name="date">Das Datum des Raids</param>
        public async Task GetLocalLogTextFile(string date)
        {
            //try
            //{
            var logTextFiles = Directory.GetFiles("C:\\Program Files (x86)\\World of Warcraft\\_classic_era_\\Logs");
            var subpath = date.Split(".")[1] + date.Split(".")[0] + date.Split(".")[2][2] + date.Split(".")[2][3];
            var path = logTextFiles.Where(localpath => localpath.Contains(subpath)).First();
            await GetDataFromLogTextFile(path);
            //}
            //catch (Exception ex) 
            //{
            //    ProgressBarControll(true, ex.Message + ex.StackTrace + " " + nameof(GetLocalLogTextFile));
            //}

        }
        /// <summary>
        /// Es werden die Daten vom WoW Logger ausgelesen, sowie die Daten aus dem WoW-Addon NovaRaidCompanion, da diese einige Consumables erfasst, die in den Logs nicht geschrieben werden.
        /// </summary>
        /// <param name="path"></param>
        public async Task GetDataFromLogTextFile(string path)
        {
            visualViewModeel.ProgressBarControll(true);
            if (logs == null)
            {
                MessageBox.Show("Erst Log-Analyse einlesen!");
                return;
            }

            List<PlayerExtractedData> dkpPlayers = calculateHandler.GetPlayerDKPRequirements(path);

            dkpPlayers.ForEach(dkpPlayer =>
            {
                var playerfound = DKPListFromSpreadSheet.Find(sheetPlayer => sheetPlayer.Name == dkpPlayer.PlayerName);
                if (playerfound != null)
                {
                    playerfound.Consumable1 = dkpPlayer.Consumable1;
                    playerfound.Consumable2 = dkpPlayer.Consumable2;
                }
            });
            visualViewModeel.ProgressBarControll();

            var PlayerDataWowAddon = await GetDataFromWoWAddon();
            PlayerExtractedDatas.Where(player => player.Consumable1 == null || player.Consumable2 == null).ToList().ForEach(
                playerFound =>
                {
                    var playerInAddonFound = PlayerDataWowAddon.Find(playerInAddon => playerInAddon.Name == playerFound.PlayerName);
                    if (playerInAddonFound != null)
                    {
                        foreach(var item in playerInAddonFound.TimeStamp)
                        {
                            if(item.Key.Date == DateTime.Parse(selectedRaid.Split("|")[1]).Date)
                            {
                                if (playerFound.Consumable1 == "")
                                {
                                    playerFound.Consumable1 = item.Value;
                                }
                                else if (playerFound.Consumable2 == "")
                                {
                                    playerFound.Consumable2 = item.Value;
                                }

                            }
                        }
                    }
                });
            var UnknownPlayers = PlayerExtractedDatas.ExceptBy(DKPListFromSpreadSheet.Select(playersheet => playersheet.Name), playerData => playerData.PlayerName).ToList();
            UnknownPlayers.Sort();
            visualViewModeel.UpdateMainTwinkList(DKPListFromSpreadSheet, UnknownPlayers);
            if (!UnknownPlayers.Any())
            {
                await SetDKPForPlayers();
            }
        }
        /// <summary>
        /// Liest die Daten aus dem NovaRaidCompanion aus. Die Daten sind in einem LUA-ähnlichem Format und müssen daher umgewandelt werden.
        /// 
        /// TODO: Die Umwandlung erfordert einige schwer nachvollziehbare Einschränkungen. Dies muss noch verbessert werden
        /// </summary>
        /// <returns>Gibt eine Liste </returns>
        private async Task<List<PlayerWoWAddon>> GetDataFromWoWAddon()
        {
            visualViewModeel.ProgressBarControll(true);

            List<PlayerWoWAddon> players = new List<PlayerWoWAddon>();
            StreamReader sr = new StreamReader(File.Open("C:\\Program Files (x86)\\World of Warcraft\\_classic_era_\\WTF\\Account\\496316485#1\\SavedVariables\\NovaRaidCompanion.lua", FileMode.Open));

            string data = await sr.ReadToEndAsync();

            string RaidName = selectedRaid.Split("|")[0].Trim() == "Naxx" ? "Naxxramas" : selectedRaid.Split("|")[0];

            string[] datablocks = data.Split("[\"instanceID\"] = " + Enum.Parse(typeof(RaidIDs), RaidName) + ",");
            foreach (string block in datablocks)
            {
                string[] playerBuffs = block.Split("Player");
                foreach (string player in playerBuffs)
                {
                    PlayerWoWAddon playerToAdd = new PlayerWoWAddon();
                    if (player.Contains("race") && !player.Contains("NRC"))
                    {
                        string nameSeperated = player.Split(",").ToList().Find(s => s.Contains("name"));
                        if (nameSeperated != null)
                        {

                            int startindex = nameSeperated.IndexOf("= \"") + 3;
                            string playerName = nameSeperated.Substring(startindex, nameSeperated.Length - startindex - 1);
                            if (!players.Exists(p => p.Name == playerName))
                            {
                                playerToAdd.Name = playerName;
                                playerToAdd.ID = player.Substring(0, player.IndexOf("]") - 1);
                            }
                        }

                    }
                    else if (player.Contains("instanceName"))
                    {

                    }
                    if (player.Contains("24363") && player.Contains("timestamp"))
                    {
                        int startindexBuff = player.IndexOf("24363") + 5;
                        string searchvalue = "[\"timestamp\"] = ";
                        int startindex = player.IndexOf(searchvalue, startindexBuff) + searchvalue.Length;
                        int endindex = player.IndexOf(",", startindex);

                        string timestamp = player.Substring(startindex, endindex - startindex);

                        string playerID = player.Substring(0, player.IndexOf("]") - 1);

                        if (playerToAdd.Name != null || playerToAdd.ID != null)
                        {
                            playerToAdd.TimeStamp.Add(DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(double.Parse(timestamp.Replace('.', ',')))).DateTime, "Magierbluttrank");
                            players.Add(playerToAdd);
                        }
                        else if (players.Exists(p => p.ID == playerID) && startindex - searchvalue.Length != -1)
                        {
                            players.Find(p => p.ID == playerID)?.TimeStamp.Add(DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(double.Parse(timestamp.Replace('.', ',')))).DateTime, "Magierbluttrank");
                        }
                    }
                    if (player.Contains("[25941") && player.Contains("endTime"))
                    {
                        int startindexBuff = player.IndexOf("25941") + 5;
                        string searchvalue = "[\"endTime\"] = ";
                        int startindex = player.IndexOf(searchvalue, startindexBuff) + searchvalue.Length;
                        int endindex = player.IndexOf(",", startindex);

                        string timestamp = player.Substring(startindex, endindex - startindex);

                        DateTime timestampDT = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(double.Parse(timestamp.Replace('.', ',')))).DateTime;

                        string playerID = player.Substring(0, player.IndexOf("]") - 1);

                        if (playerToAdd.Name != null || playerToAdd.ID != null)
                        {
                            playerToAdd.TimeStamp.Add(timestampDT, "Weisenfisch");
                            players.Add(playerToAdd);
                        }
                        else if (players.Exists(p => p.ID == playerID && !p.TimeStamp.ContainsKey(timestampDT) && startindex - searchvalue.Length != -1))
                        {
                            players.Find(p => p.ID == playerID)?.TimeStamp.Add(timestampDT, "Weisenfisch");
                        }
                    }

                    if (player.Contains("-5242-01E9F6AC"))
                    {

                    }
                }
            }
            visualViewModeel.ProgressBarControll();
            sr.Close();
            return players;
        }
        /// <summary>
        /// Neue Spieler werden in die Spreadsheetliste eingetragen.
        /// Die Spreadsheetliste wird mit den ermitteln Daten aktualisiert.
        /// Die versäumten IDs der Spieler werden aktualisiert.
        /// </summary>
        public async Task SetDKPForPlayers()
        {
            visualViewModeel.ProgressBarControll(true);

            var MainTwinkList = visualViewModeel.GetMainTwinkList();
            foreach (var mainTwink in MainTwinkList)
            {
                if(mainTwink.MainName != "")
                {
                    DKPListFromSpreadSheet.Find(player => player.Name == mainTwink.MainName).Name = mainTwink.MainName + " [-> " + mainTwink.TwinkName + " <-]";
                    PlayerExtractedDatas.Find(player => player.PlayerName == mainTwink.TwinkName).PlayerName = mainTwink.MainName + " [-> " + mainTwink.TwinkName + " <-]";
                }
            }
            
            var UpdatedSpreadsheetList = calculateHandler.SetExtractedDataToSheet(PlayerExtractedDatas, DKPListFromSpreadSheet);
            DKPListFromSpreadSheet.Clear();
            foreach (var entry in UpdatedSpreadsheetList)
            {
                DKPListFromSpreadSheet.Add(entry);
                visualViewModeel.UpdateViewModellData(new VisualLogic.Data.VisualUpdateDataObject(entry, typeof(PlayerData), entry.Name));
            }
            var result = await spreadSheetHandler.UpdateSpreadSheetData(DKPListFromSpreadSheet);
            visualViewModeel.ProgressBarControll();
            CalculateDKP();
            calculateHandler.SetAddonData(DKPListFromSpreadSheet);
        }
        /// <summary>
        /// Löscht Spieler, die 10 IDs nicht am Raid teilgenommen haben
        /// </summary>
        private void TidyUp()
        {
            var Worklist = DKPListFromSpreadSheet.Where(entry =>        
             entry.IDs_Missed_Count >= 10)
            .ToList();

            foreach (var item in Worklist)
            {
                DKPListFromSpreadSheet.Remove(item);
            }
        }

    }
}
