using All_in_One.Spreadsheet_Side.Data;
using All_in_One.Logik_Side;
using All_in_One.Logik_Side.Data;
using All_in_One.VisualLogic.Data;
using All_in_One.VisualLogic.Functions;
using All_in_One.VisualLogic.Windows;
using All_in_One.Warcraft_Logs.LogTypes.Base;
using All_in_One.Warcraft_Logs.LogTypes.Guild;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;


namespace All_in_One.VisualLogic
{
    public class Handler
    {
        //TODO: Big rework. List need to be better documented. Multi use! Need to have a read List, write list and work list.
        /// <summary>
        /// This presents one Sheet from Spreadsheet.
        /// </summary>
        public ObservableCollection<SpreadsheetEntry> PlayersFromSpreadsheet = new();

        /// <summary>
        /// A List with every Player from the given Log. Will be compared to the Spreadsheet-List to find new Player/Twinks
        /// </summary>
        public ObservableCollection<PlayerOnlyName> PlayersFromLogs = new ();

        public ObservableCollection<PlayerOnlyName> PotentialMains = new ();

        public ObservableCollection<LastRaidComboboxItem> LastRaids = new ();

        /// <summary>
        /// Intern Working list. Holds the player-names to update the dkp list.
        /// </summary>
        public List<PlayerDKP> DKPPlayers = new List<PlayerDKP>();

        /// <summary>
        /// Updatet DKP. Ready to write to the Spreadsheet.
        /// </summary>
        public List<SpreadsheetEntry> PlayersToSpreadsheet = new List<SpreadsheetEntry>();


        public UserControls UserControls = new UserControls();

        WaitForLogAnalyseHandler handler = new WaitForLogAnalyseHandler();
        PleaseWait window = new PleaseWait();

        public void ShowWaitWindow()
        {          
            window.Show();
            window.Focus();
            LastRaids.CollectionChanged += (sender, e) => { CloseWaitWindow(); };
        }

        void CloseWaitWindow()
        {
            window?.Close();
        }

        public void ConvertSpreadsheetToDataGrid(string Raid,List<JsonSheetEntry> Sheet)
        {
            PlayersFromSpreadsheet.SpreadSheetToList(Raid,Sheet);
        }

        public void ConvertLogsToDropDown(List<Guild_Rootobject> logs)
        {
            logs.Take(10).ToList().ForEach(log => { LastRaids.Add(new LastRaidComboboxItem(log, log.title + " | " + DateTimeOffset.FromUnixTimeMilliseconds(log.start).DateTime)); });
        }


        public void ConvertLogsToDataGrid(Base_Rootobject Logs)
        {
            if(PlayersFromLogs.Count > 0)
            {
                PlayersFromLogs.Clear();
            }
            Logs.friendlies.ToList().ForEach(player =>
            {
                if (player.fights.Count() > Logs.fights.Count() / 2)
                {
                    PlayersFromLogs.Add(new PlayerOnlyName(player.name, PlayersFromLogs.Count + 1));
                }

            });
        }

        public void AddPlayerToSpreadsheet(ObservableCollection<UnknownPlayer> TwinksOrNewPlayers)
        {
            PlayersFromSpreadsheet.AddPlayers(TwinksOrNewPlayers);
        }
        
        //TODO: This need to be done by Propertychangedvalue.
        /// <summary>
        /// Change the Value of the ProgressPar
        /// </summary>
        /// <param name="newValue"> The Valeue to add or to set</param>
        /// <param name="IsValueAdded">If true (default), the Value will be added to old Value, otherwise the value will be overriden </param>
        public void ChangeValue(string Step, int newValue = 0, bool IsValueAdded = true, bool LastValueAdded = false)
        {
            if(!handler.IsDiagOpen)
            {
                handler.InitDiag();
            }
            if(LastValueAdded)
            {
                handler.CloseDiag();
            }
            if(IsValueAdded)
            {
                handler.AddValue(Step);
            }
            else
            {
                handler.SetValue(newValue);
            }
        }

        public int GetValueOfProperty()
        {
            return handler.GetValue();
        }

        public int GetValueOfBar()
        {
            return handler.GetValueOfProp();
        }

    }
}
