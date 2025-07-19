using All_in_One.DataModels.DKPModels;
using All_in_One.DataModels.PlayerModels;
using All_in_One.DataModels.RaidModels;
using All_in_One.DataModels.SpreadSheetModels;
using All_in_One.DataModels.WarcraftlogsModels;
using All_in_One.VisualLogic.Functions;
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
    class MainService : INotifyPropertyChanged
    {
        private VisualLogic.Handler visualLogicHandler = new VisualLogic.Handler();
        private CalculateService.Handler calculateHandler = new CalculateService.Handler();
        private SpreadSheetService.SpreadSheetHandler spreadSheetHandler = new SpreadSheetService.SpreadSheetHandler();
        private WarcraftLogsService.WarcraftHandler logsHandler = new WarcraftLogsService.WarcraftHandler();

        /// <summary>
        /// Liste aller Sheets zum Erstellen der CheckBoxen
        /// </summary>
        public ObservableCollection<RaidSelection> RaidCheckBoxCollection { get; set; } = new ObservableCollection<RaidSelection>();
        /// <summary>
        /// Liste der letzten Gild-Logs. Angezeigt werden 10
        /// </summary>
        public ObservableCollection<string> LastGuildsRaids { get; set; } = new ObservableCollection<string>();

        /// <summary>
        /// Liste aller Spieler, die in den Logs vorkommen, aber nicht in der DKP-Liste
        /// </summary>
        public ObservableCollection<UnknownPlayer> UnknownPlayers { get; set; } = new ObservableCollection<UnknownPlayer>();

        /// <summary>
        /// Aktuelle DKP-Liste des aktuellen Raids
        /// </summary>
        public ObservableCollection<SpreadsheetEntry> DKPListFromSpreadSheet { get; set; } = new ObservableCollection<SpreadsheetEntry>();

        public ObservableCollection<PlayerDKPEntry> PlayersDKPRequirement { get; set; } = new ObservableCollection<PlayerDKPEntry> { };

        public ObservableCollection<string> ListOfMains { get; set; } = new ObservableCollection<string> { };

        LogsDataObject logs;
        private List<Task> TaskPool = new();

        string selectedRaid = "";

        public List<JsonSheetEntry> SpreadsheetAsJson = new();

        string _message = "";
        Visibility _show = Visibility.Hidden;
        /// <summary>
        /// Anzuzeigender Text über dem Fortschrittsbalken
        /// </summary>
        public string LoadingDataMessage { get => _message; set { _message = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LoadingDataMessage))); } }
        public Visibility ShowProgressBar { get => _show; set { _show = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShowProgressBar))); } }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Startet die DKP-Auswertung für jeden Spieler. Aktualisiert das Datum und entfernt inaktive Spieler
        /// </summary>
        public void CalculateDKP()
        {
            DKPListFromSpreadSheet[0].Stand = selectedRaid.Split("|")[1].Trim();
            foreach (var item in DKPListFromSpreadSheet)
            {
                item.Punkte = calculateHandler.CalculateDKPPoints(item).ToString();
            }
            TidyUp();
        }

        /// <summary>
        /// Steuert den Fortschrittsbalken. Die Anzeige ist konstant durchlaufend.
        /// </summary>
        /// <param name="Show">Balken ein- oder ausblenden</param>
        /// <param name="memberName">Der Wert wird als Text über dem Fortschrittsbalken angezeigt</param>
        void ProgressBarControll(bool Show = false, [CallerMemberName] string memberName = "")
        {
            if (Show)
            {
                ShowProgressBar = Visibility.Visible;
                LoadingDataMessage = memberName;
            }
            else
            {
                ShowProgressBar = Visibility.Hidden;
                LoadingDataMessage = "";
            }

        }

        /// <summary>
        /// Initialisiert das Programm.
        /// Die Spreadsheets werden abgerufen.
        /// Die letzten Logs werden ausgelesen und als Auswahlmenü angezeigt
        /// </summary>
        public async Task Init()
        {
            ProgressBarControll(true);
            SpreadsheetAsJson = await spreadSheetHandler.GetSpreadSheets();
            RaidCheckBoxCollection.Clear();
            foreach (var item in visualLogicHandler.UserControls.GetUserControl(SpreadsheetAsJson))
            {
                RaidCheckBoxCollection.Add(item);
            }
            var LastRaids = await logsHandler.GetLastRaids();
            LastGuildsRaids.Clear();
            foreach (var item in LastRaids)
            {
                if (LastGuildsRaids.Count < 10)
                {
                    LastGuildsRaids.Add(item.title + " | " + DateTimeOffset.FromUnixTimeMilliseconds(item.start).Date.ToShortDateString() + " | " + item.id);
                }
                else
                {
                    break;
                }

            }
            ProgressBarControll();
        }

        /// <summary>
        /// Die DKPs werden aus dem ausgewählten Spreadsheet ausgelesen. DKPs sind Raidgebunden. Für jeden Raid existiert ein eigenes Sheet.
        /// 
        /// Die Daten werden als Grid in der GUI angezeigt.
        /// 
        /// Es werden unbekannte Spieler ermittelt und angezeigt.
        /// </summary>
        /// <param name="SelectedRaid"></param>
        public async Task GetDKPFromSpreadSheet(string SelectedRaid)
        {
            ProgressBarControll(true);
            foreach (var item in RaidCheckBoxCollection)
            {
                if (item.Content != SelectedRaid)
                {
                    item.IsChecked = false;
                }
            }
            SpreadsheetAsJson = await spreadSheetHandler.GetSpreadSheets();
            DKPListFromSpreadSheet.Clear();
            foreach (var item in visualLogicHandler.ConvertSpreadsheetToDataGrid(SpreadsheetAsJson.Find(entry => entry.Properties.Title == SelectedRaid)))
            {
                if (item.Spieler != null)
                {
                    DKPListFromSpreadSheet.Add(item);
                }

            };
            DKPListFromSpreadSheet.RemoveAt(0);

            List<string> mains = new List<string>();

            foreach (var item in DKPListFromSpreadSheet)
            {
                mains.Add(item.Spieler);
            }
            mains.Sort();

            foreach (var item in mains)
            {
                ListOfMains.Add(item);
            }

            if (logs != null)
            {
                UnknownPlayers.Clear();

                foreach (var player in calculateHandler.FindNewPlayers(DKPListFromSpreadSheet, logs))
                {
                    UnknownPlayers.Add(player);
                };
            }
            ProgressBarControll();
        }

        /// <summary>
        /// Es werden die Daten des ausgewählten Raids aus den Logs ausgelesen, die zur Berechnung erforderlich sind.
        /// </summary>
        /// <param name="SelectedRaid"></param>
        public async Task GetDataFromLog(string SelectedRaid)
        {
            ProgressBarControll(true);
            selectedRaid = SelectedRaid;
            logs = await logsHandler.GetLogfromWarcraftLogs(SelectedRaid.Split("|")[2].Trim());

            foreach (var item in DKPListFromSpreadSheet)
            {
                item.CountsPerMinutes = "";
                item.Consumables1 = "";
                item.Consumable2 = "";
                item.Verzauberungen = "";
            }
            UnknownPlayers.Clear();

            foreach (var player in calculateHandler.FindNewPlayers(DKPListFromSpreadSheet, logs))
            {
                UnknownPlayers.Add(player);
            };

            PlayersDKPRequirement.Clear();

            foreach (var player in calculateHandler.GetPlayerDKPRequirement(logs))
            {
                PlayersDKPRequirement.Add(player);
            }
            ProgressBarControll();
            GetLocalLogTextFile(SelectedRaid.Split("|")[1].Trim());
        }
        /// <summary>
        /// Liest die vom WoW-Client mitgeschriebenen Logdaten aus.
        /// </summary>
        /// <param name="date">Das Datum des Raids</param>
        public void GetLocalLogTextFile(string date)
        {
            //try
            //{
            var logTextFiles = Directory.GetFiles("C:\\Program Files (x86)\\World of Warcraft\\_classic_era_\\Logs");
            var subpath = date.Split(".")[1] + date.Split(".")[0] + date.Split(".")[2][2] + date.Split(".")[2][3];
            var path = logTextFiles.Where(localpath => localpath.Contains(subpath)).First();
            GetDataFromLogTextFile(path);
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
        public void GetDataFromLogTextFile(string path)
        {
            ProgressBarControll(true);
            if (logs == null)
            {
                MessageBox.Show("Erst Log-Analyse einlesen!");
                return;
            }

            List<PlayerDKPEntry> dkpPlayers = calculateHandler.GetPlayerDKPRequirements(path);
            foreach (var player in dkpPlayers)
            {
                foreach (var entry in PlayersDKPRequirement)
                {
                    if (entry.PlayerName == player.PlayerName)
                    {
                        entry.Consumable1 = player.Consumable1;
                        entry.Consumable2 = player.Consumable2;
                    }
                }
            }
            ProgressBarControll();

            foreach (var playerAddon in GetDataFromWoWAddon())
            {
                foreach (var entry in PlayersDKPRequirement)
                {
                    if (entry.PlayerName == playerAddon.Name)
                    {
                        foreach (KeyValuePair<DateTime, string> pair in playerAddon.TimeStamp)
                        {
                            if (pair.Key.Date == DateTime.Parse(selectedRaid.Split("|")[1]).Date)
                            {
                                if (entry.Consumable1 == null)
                                {
                                    entry.Consumable1 = pair.Value;
                                }
                                else if (entry.Consumable2 == null)
                                {
                                    entry.Consumable2 = pair.Value;
                                }
                            }

                        }

                    }
                }
            }
            if (UnknownPlayers.Count == 0)
            {
                SetDKPForPlayers();
            }
        }
        /// <summary>
        /// Liest die Daten aus dem NovaRaidCompanion aus. Die Daten sind in einem LUA-ähnlichem Format und müssen daher umgewandelt werden.
        /// 
        /// TODO: Die Umwandlung erfordert einige schwer nachvollziehbare Einschränkungen. Dies muss noch verbessert werden
        /// </summary>
        /// <returns>Gibt eine Liste </returns>
        private List<PlayerWoWAddon> GetDataFromWoWAddon()
        {
            ProgressBarControll(true);

            List<PlayerWoWAddon> players = new List<PlayerWoWAddon>();
            StreamReader sr = new StreamReader(File.Open("C:\\Program Files (x86)\\World of Warcraft\\_classic_era_\\WTF\\Account\\496316485#1\\SavedVariables\\NovaRaidCompanion.lua", FileMode.Open));

            string data = sr.ReadToEnd();

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
                            players.Find(p => p.ID == playerID).TimeStamp.Add(DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(double.Parse(timestamp.Replace('.', ',')))).DateTime, "Magierbluttrank");
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
                            players.Find(p => p.ID == playerID).TimeStamp.Add(timestampDT, "Weisenfisch");
                        }
                    }

                    if (player.Contains("-5242-01E9F6AC"))
                    {

                    }
                }
            }
            ProgressBarControll();
            sr.Close();
            return players;
        }
        /// <summary>
        /// Neue Spieler werden in die Spreadsheetliste eingetragen.
        /// Die Spreadsheetliste wird mit den ermitteln Daten aktualisiert.
        /// Die versäumten IDs der Spieler werden aktualisiert.
        /// </summary>
        public void SetDKPForPlayers()
        {
            ProgressBarControll(true);
            foreach (var newEntry in UnknownPlayers)
            {
                if (newEntry.AddNewPlayer)
                {
                    DKPListFromSpreadSheet.Add(new SpreadsheetEntry() { Spieler = newEntry.TwinkName, VersäumteIDs = 0.ToString(), Punkte = "0" });
                }
            }

            foreach (var item in DKPListFromSpreadSheet)
            {
                bool playerFound = false;
                foreach (var player in calculateHandler.SetDKPForPlayers(PlayersDKPRequirement))
                {
                    if (player.Spieler == item.Spieler || (item.VersäumteIDs != null && item.Spieler.Contains("-> " + player.Spieler)))
                    {
                        item.VersäumteIDs = 0.ToString();
                        playerFound = true;
                        item.Verzauberungen = player.Verzauberungen;
                        item.Consumables1 = player.Consumables1;
                        item.Consumable2 = player.Consumable2;
                        item.CountsPerMinutes = player.CountsPerMinutes;
                        item.GetDKP = player.GetDKP;
                    }
                }
                if (!playerFound)
                {
                    item.VersäumteIDs = (int.Parse(item.VersäumteIDs) + 1).ToString();
                }
            }


            foreach (var player in calculateHandler.SetDKPForPlayers(PlayersDKPRequirement))
            {

            }
            ProgressBarControll();
            CalculateDKP();
        }
        /// <summary>
        /// Aktualisiert die Liste der Spreadsheetdaten für unbekannte Spieler 
        /// </summary>
        /// <param name="SelectedMain"></param>
        /// <param name="SelectedTwink"></param>
        public void AddMainPlayerToTwink(string SelectedMain, UnknownPlayer SelectedTwink)
        {
            ProgressBarControll(true);
            foreach (var item in DKPListFromSpreadSheet)
            {
                if (item.Spieler == SelectedMain)
                {
                    string playername = item.Spieler;
                    if (playername.Contains(" | "))
                    {
                        item.Spieler = playername.Remove(item.Spieler.IndexOf(" | "));
                    }
                    if (item.Spieler == SelectedTwink.TwinkName)
                    {

                    }
                    else
                    {
                        item.Spieler += " | Umgeloggt -> " + SelectedTwink.TwinkName;
                        ListOfMains[ListOfMains.IndexOf(playername)] = item.Spieler;
                    }

                }
            }

            foreach (var item in UnknownPlayers)
            {
                if (item.TwinkName == SelectedTwink.TwinkName)
                {
                    item.AssociatedMain = SelectedMain;
                }
            }
            ProgressBarControll();
        }
        /// <summary>
        /// Löscht Spieler, die 10 IDs nicht am Raid teilgenommen haben
        /// </summary>
        private void TidyUp()
        {
            var Worklist = DKPListFromSpreadSheet.Where(entry =>
            {
                var ids = 0;
                if (int.TryParse(entry.VersäumteIDs, out ids))
                {
                    return ids >= 10;
                }
                return false;
            }).ToList();

            foreach (var item in Worklist)
            {
                DKPListFromSpreadSheet.Remove(item);
            }
        }

    }
}
