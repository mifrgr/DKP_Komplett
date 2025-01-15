using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using All_in_One.Logik_Side.Data;
using All_in_One.Static.Data;
using All_in_One.VisualLogic.Data;
using All_in_One.Spreadsheet_Side.Data;
using System;
using All_in_One.VisualLogic.Functions.ExtensionMethods;
using System.ComponentModel;
using All_in_One.Logik_Side.Functions;
using System.IO;

namespace All_in_One
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       //List<StartDKPEntry> startDKPEntries = new List<StartDKPEntry>();


        public MainWindow()
        {
            InitializeComponent();
            Handlers.spreadsheethandler.ConnectToSpreadsheet();
            InitVisual();
            SetBindings();
        }

        private void SetBindings()
        {
            Binding Logs_binding = new Binding();
            Logs_binding.Source = Handlers.visualLogicHandler.PlayersFromLogs;
            PlayersFromLogs.SetBinding(DataGrid.ItemsSourceProperty, Logs_binding);

            Binding LastRaid_binding = new Binding();
            LastRaid_binding.Source = Handlers.visualLogicHandler.LastRaids;
            LastRaids.SetBinding(ComboBox.ItemsSourceProperty, LastRaid_binding);
            LastRaids.DisplayMemberPath = nameof(LastRaidComboboxItem.DisplayName);

            Binding Spreadsheet_binding = new Binding();
            Spreadsheet_binding.Source = Handlers.visualLogicHandler.PlayersFromSpreadsheet;
            PlayersFromSpreadsheet.SetBinding(DataGrid.ItemsSourceProperty, Spreadsheet_binding);

            Binding NewOrUnknownPlayer_binding = new Binding();
            NewOrUnknownPlayer_binding.Source = Handlers.logikHandler.TwinksOrNewPlayers;
            NewUnknownPlayers.SetBinding(DataGrid.ItemsSourceProperty, NewOrUnknownPlayer_binding);

            NewUnknownPlayers.SelectionChanged += NewUnknownPlayers_SelectionChanged;

            ListCollectionView view = new ListCollectionView(Handlers.visualLogicHandler.PlayersFromSpreadsheet);
            view.SortDescriptions.Add(new SortDescription(nameof(SpreadsheetEntry.Spieler), ListSortDirection.Ascending));
            ListPotentialMain.ItemsSource = view;
            ListPotentialMain.DisplayMemberPath = nameof(SpreadsheetEntry.Spieler);
        }

        private void NewUnknownPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(NewUnknownPlayers.SelectedItem != null)
            {
                UnknownPlayer clickedPlayer = NewUnknownPlayers.SelectedItem as UnknownPlayer;
                SelectedTwink.Text = clickedPlayer.TwinkName;
            }

        }

        void InitVisual()
        {
            CheckBoxRaidSelection.ItemsSource = Handlers.visualLogicHandler.UserControls.GetUserControl();
            Handlers.logshandler.GetLastRaids();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Alle Sonderpunkte vergeben?" + Environment.NewLine + "Hexertank / Magetank...", "Achtung", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Handlers.logikHandler.CalculateDKP(Handlers.visualLogicHandler.PlayersFromSpreadsheet);
            }

        }

        
        private void ReadFromSpreadSheet_Click(object sender, RoutedEventArgs e)
        {
            ///Get the Raid DKP List from Spreadsheet.
            //Handlers.visualLogicHandler.ConvertSpreadsheetToDataGrid(Handlers.visualLogicHandler.UserControls.GetUserControl().IndexOf(Handlers.visualLogicHandler.UserControls.GetUserControl().Find(x => x.IsChecked == true)),Handlers.spreadsheethandler.Sheets);
        }

        private void CompareLogPlayersWithDKPList_Click(object sender, RoutedEventArgs e)
        {
            Handlers.logikHandler.FindNewOrUnknownPlayer(Handlers.visualLogicHandler.PlayersFromSpreadsheet, Handlers.visualLogicHandler.PlayersFromLogs);
        }

 


        private void AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            Handlers.visualLogicHandler.AddPlayerToSpreadsheet(Handlers.logikHandler.TwinksOrNewPlayers);
        }
        string reportCode;


        private void DrapAndDropBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(DrapAndDropBox.Text .Length > 0)
            {
                reportCode = DrapAndDropBox.Text.Substring(DrapAndDropBox.Text.IndexOf("reports/") + 8);
                Handlers.logshandler.GetLogfromWarcraftLogs(DrapAndDropBox.Text.Substring(DrapAndDropBox.Text.IndexOf("reports/") + 8));
               DrapAndDropBox.Text = "";
            }
            
        }

        private void MarkPlayerForDKP_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Need big Rework!!!!
            Handlers.logikHandler.MarkPlayerAsPresent(Handlers.visualLogicHandler.PlayersFromSpreadsheet, Handlers.visualLogicHandler.PlayersFromLogs, Handlers.logikHandler.TwinksOrNewPlayers);
        }

        private void LastRaids_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Handlers.logshandler.GetLogfromWarcraftLogs(Handlers.visualLogicHandler.LastRaids.Where(Raid => Raid.Guild_Rootobject == ((LastRaidComboboxItem)((ComboBox)sender).SelectedItem).Guild_Rootobject).First().Guild_Rootobject.id) ;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox Box = sender as CheckBox;
            Handlers.visualLogicHandler.UserControls.GetUserControl().ForEach(userControl =>
            {
                if (Box.Content.ToString() != userControl.Content)
                {
                    userControl.IsChecked = false;
                }
            });
            Handlers.visualLogicHandler.ConvertSpreadsheetToDataGrid(Box.Content.ToString(), Handlers.spreadsheethandler.SpreadsheetAsJson);

        }


        private void ConfirmTwinkAsMain_Click(object sender, RoutedEventArgs e)
        {
            Handlers.logikHandler.TwinksOrNewPlayers.ToList().Find(x => x.TwinkName == SelectedTwink.Text).AssociatedMain = ((SpreadsheetEntry)ListPotentialMain.SelectedItem).Spieler;
        }

        private void Rectangle_Drop(object sender, DragEventArgs e)
        {
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop);
            Handlers.logshandler.ReadLogsFromTextFile(fileName[0]);
        }
    }
}
