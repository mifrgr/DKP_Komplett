using All_in_One.DataModels.DKPModels;
using All_in_One.DataModels.PlayerModels;
using All_in_One.DataModels.SpreadSheetModels;
using All_in_One.DataModels.WarcraftlogsModels;
using All_in_One.DataModels.WarcraftLogsModels.LogTypes;
using All_in_One.VisualLogic.Functions;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.ComponentModel;

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

        public List<JsonSheetEntry> SpreadsheetAsJson = new();

        string _message = "";
        Visibility _show = Visibility.Hidden;
        public string LoadingDataMessage { get => _message; set { _message = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LoadingDataMessage))); } } 
        public Visibility ShowProgressBar { get => _show; set { _show = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShowProgressBar))); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public void CalculateDKP()
        {
            foreach(var item in  DKPListFromSpreadSheet)
            {
                item.Punkte = calculateHandler.CalculateDKPPoints(item).ToString();
            }

        }

        void ProgressBarControll(bool Show = false, [CallerMemberName] string memberName = "")
        {
            if(Show)
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

        public async void Init()
        {
            ProgressBarControll(true);
            SpreadsheetAsJson = await spreadSheetHandler.GetSpreadSheets(); 
            RaidCheckBoxCollection.Clear();
            foreach(var item in visualLogicHandler.UserControls.GetUserControl(SpreadsheetAsJson))
            {
                RaidCheckBoxCollection.Add(item);
            }
            var LastRaids = await logsHandler.GetLastRaids();
            LastGuildsRaids.Clear();
            foreach (var item in LastRaids)
            {
                if(LastGuildsRaids.Count < 10)
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

        public async void GetDKPFromSpreadSheet(string SelectedRaid)
        {
            ProgressBarControll(true);
            foreach (var item in RaidCheckBoxCollection)
            {
                if(item.Content != SelectedRaid)
                {
                    item.IsChecked = false;
                }
            }
            spreadSheetHandler.GetSpreadSheets();
            DKPListFromSpreadSheet.Clear();
            foreach (var item in visualLogicHandler.ConvertSpreadsheetToDataGrid(SpreadsheetAsJson.Find(entry => entry.Properties.Title == SelectedRaid)))
            {
                DKPListFromSpreadSheet.Add(item);
            };
            DKPListFromSpreadSheet.RemoveAt(0);

            List<string> mains = new List<string>();

            foreach(var item in DKPListFromSpreadSheet)
            {
                mains.Add(item.Spieler);
            }
            mains.Sort();

            foreach (var item in mains) 
            {
                ListOfMains.Add(item);
            }

            if(logs != null)
            {
                UnknownPlayers.Clear();

                foreach (var player in calculateHandler.FindNewPlayers(DKPListFromSpreadSheet, logs))
                {
                    UnknownPlayers.Add(player);
                };
            }
            ProgressBarControll();
        }

        public async void GetDataFromLog(string reportCode)
        {
            ProgressBarControll(true);
            logs = await logsHandler.GetLogfromWarcraftLogs(reportCode);

            foreach (var item in DKPListFromSpreadSheet)
            {
                item.Teilgenommen = "";
                item.ActiveTime = "";
                item.Consumables = "";
                item.Waffenverzauberungen = "";
                item.Verzauberungen = "";
            }
            UnknownPlayers.Clear();

            foreach (var player in calculateHandler.FindNewPlayers(DKPListFromSpreadSheet, logs))
            {
                UnknownPlayers.Add(player);
            };

            PlayersDKPRequirement.Clear();
           
            foreach(var player in calculateHandler.GetPlayerDKPRequirement(logs))
            {
                PlayersDKPRequirement.Add(player);
            }
            ProgressBarControll();
        }

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
                foreach(var entry in PlayersDKPRequirement)
                {
                    if(entry.PlayerName == player.PlayerName)
                    {
                        entry.Consumable = player.Consumable;
                        entry.WeaponEnchantment = player.WeaponEnchantment;
                    }
                }
            }
            ProgressBarControll();
        }

        public void SetDKPForPlayers()
        {
            ProgressBarControll(true);
            foreach(var newEntry in UnknownPlayers)
            {
                if(newEntry.AddNewPlayer)
                {
                    DKPListFromSpreadSheet.Add(new SpreadsheetEntry() { Spieler = newEntry.TwinkName, Teilgenommen = "x", Punkte = "0"});
                }
            }
            foreach (var player in calculateHandler.SetDKPForPlayers(PlayersDKPRequirement))
            {
                foreach(var item in DKPListFromSpreadSheet)
                {
                    if(player.Spieler == item.Spieler || (item.Teilgenommen != null && item.Teilgenommen.Contains(player.Spieler)))
                    {
                        if(!item.Teilgenommen.Contains("Umgeloggt"))
                        {
                            item.Teilgenommen = player.Teilgenommen;
                        }
                        item.Verzauberungen = player.Verzauberungen;                      
                        item.Consumables = player.Consumables;
                        item.Waffenverzauberungen = player.Waffenverzauberungen;
                        item.ActiveTime = player.ActiveTime;
                        item.GetDKP = player.GetDKP;
                    }
                }
            }
            ProgressBarControll();
            CalculateDKP();
        }

        public void AddMainPlayerToTwink(string SelectedMain,UnknownPlayer SelectedTwink)
        {
            ProgressBarControll(true);
            foreach (var item in DKPListFromSpreadSheet)
            {
                if(item.Spieler == SelectedMain)
                {
                    item.Teilgenommen = "Umgeloggt -> " + SelectedTwink.TwinkName;
                }
            }

            foreach (var item in UnknownPlayers)
            {
                if(item.TwinkName == SelectedTwink.TwinkName)
                {
                    item.AssociatedMain = SelectedMain;
                }
            }
            ProgressBarControll();
        }

    }
}
