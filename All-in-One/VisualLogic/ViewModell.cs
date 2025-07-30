using All_in_One.DataModels.PlayerModels;
using All_in_One.VisualLogic.Data;
using All_in_One.VisualLogic.Functions;
using All_in_One.VisualLogic.VisualModels;
using All_in_One.VisualLogic.Windows;
using All_in_One.Services;
using System;
using System.CodeDom;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Threading.Tasks;
using System.Diagnostics.Eventing.Reader;
using Aspose.Cells.Drawing;
using All_in_One.Services.CalculateService.DataModels;
using All_in_One.Services.SpreadSheetService.DataModels;


namespace All_in_One.VisualLogic
{
    public class ViewModell : INotifyPropertyChanged
    {
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

        public ObservableCollection<SpreadSheetViewModell> DKPListFromSpreadSheetViewModell { get; set; } = new ObservableCollection<SpreadSheetViewModell>();

        public ObservableCollection<PlayerExtractedDataViewModell> PlayerExtractedDatas { get; set; } = new ObservableCollection<PlayerExtractedDataViewModell> { };

        public ObservableCollection<string> ListOfMains { get; set; } = new ObservableCollection<string> { };

        string _message = "";
        Visibility _show = Visibility.Hidden;
        /// <summary>
        /// Anzuzeigender Text über dem Fortschrittsbalken
        /// </summary>
        public string LoadingDataMessage { get => _message; set { _message = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LoadingDataMessage))); } }
        public Visibility ShowProgressBar { get => _show; set { _show = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShowProgressBar))); } }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Steuert den Fortschrittsbalken. Die Anzeige ist konstant durchlaufend.
        /// </summary>
        /// <param name="Show">Balken ein- oder ausblenden</param>
        /// <param name="memberName">Der Wert wird als Text über dem Fortschrittsbalken angezeigt</param>
        public void ProgressBarControll(bool Show = false, [CallerMemberName] string memberName = "")
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

        public void UpdateViewModellData(VisualUpdateDataObject data)
        {
            if(data.type == typeof(PlayerExtractedData))
            {
                var DataObject = (PlayerExtractedData)data.data;
                var playerToChange = PlayerExtractedDatas.FirstOrDefault(player => player.PlayerName == data.name);
                if (playerToChange == null)
                {
                    playerToChange = new PlayerExtractedDataViewModell()
                    {
                        PlayerName = data.name,
                        Enchantment = DataObject.Enchantment,
                        Consumable1 = DataObject.Consumable1,
                        Consumable2 = DataObject.Consumable2,
                        CountPerMinutes = DataObject.CountPerMinutes.ToString(),
                    };
                    PlayerExtractedDatas.Add(playerToChange);
                }
                else
                {
                    playerToChange.PlayerName = data.name;
                    playerToChange.Enchantment = DataObject.Enchantment;
                    playerToChange.Consumable1 = DataObject.Consumable1;
                    playerToChange.Consumable2 = DataObject.Consumable2;
                    playerToChange.CountPerMinutes = DataObject.CountPerMinutes.ToString();
                }
            }
            if (data.type == typeof(PlayerData))
            {
                var DataObject = (PlayerData)data.data;
                var playerToChange = DKPListFromSpreadSheetViewModell.FirstOrDefault(player => player.Spieler == data.name);
                if (playerToChange == null)
                {
                    playerToChange = new SpreadSheetViewModell()
                    {
                        Spieler = data.name,
                        GesamtIDs = DataObject.IDs_Count.ToString(),
                        IDsGolddrache = DataObject.IDs_Golddrache_Count.ToString(),
                        VersäumteIDs = DataObject.IDs_Missed_Count.ToString(),
                        Verzauberungen = DataObject.Enchantment,
                        Consumables1 = DataObject.Consumable1,
                        Consumable2 = DataObject.Consumable2,
                        CountsPerMinutes = DataObject.CountsPerMinute.ToString(),
                        Stand = DataObject.Date,
                    };
                    DKPListFromSpreadSheetViewModell.Add(playerToChange);
                }
                else
                {
                    playerToChange.Spieler = data.name;
                    playerToChange.GesamtIDs = DataObject.IDs_Count.ToString();
                    playerToChange.IDsGolddrache = DataObject.IDs_Golddrache_Count.ToString();
                    playerToChange.VersäumteIDs = DataObject.IDs_Missed_Count.ToString();
                    playerToChange.Verzauberungen = DataObject.Enchantment;
                    playerToChange.Consumables1 = DataObject.Consumable1;
                    playerToChange.Consumable2 = DataObject.Consumable2;
                    playerToChange.CountsPerMinutes = DataObject.CountsPerMinute.ToString();
                    playerToChange.Stand = DataObject.Date;
                }
                

            }


        }



        public UserControls UserControls = new UserControls();

        PleaseWait window = new PleaseWait();

        public void Init(List<JsonSheetEntry> JsonSheetData)
        {
            RaidCheckBoxCollection.Clear();
            foreach (var item in UserControls.GetCheckBoxItems(JsonSheetData))
            {
                RaidCheckBoxCollection.Add(item);
            }

            LastGuildsRaids.Clear();
            
            foreach (var item in MainService.Instance.LastRaids)
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
        }
        public void ShowWaitWindow()
        {
            window.Show();
            window.Focus();
        }

        void CloseWaitWindow()
        {
            window?.Close();
        }





    }
}
