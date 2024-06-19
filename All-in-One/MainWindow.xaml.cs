using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Text.Json;
using Newtonsoft.Json;
using Google.Apis.Sheets.v4.Data;
using Aspose.Cells.Drawing;
using All_in_One.Entrys;
using All_in_One.StaticFunctions;
using System.Runtime.InteropServices;
using All_in_One.Warcraft_API;
using All_in_One.Spreadsheet_Side;
using All_in_One.Static.Data;
using All_in_One.VisualLogic;
using System.Threading;
using All_in_One.Warcraft_Logs.Data;

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
            InitVisualLogic();
        }

        void InitVisualLogic()
        {
            CheckBoxRaidSelection.ItemsSource = Handlers.visualLogicHandler.UserControls.GetUserControl();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            Tabelle.BeginInit();
            Handlers.logikHandler.CalculateDKP(Handlers.visualLogicHandler.PlayersFromSpreadsheet);
            Tabelle.EndInit();
        }

        
        private void ReadFromSpreadSheet_Click(object sender, RoutedEventArgs e)
        {
            ///Get the Raid DKP List from Spreadsheet.
            Handlers.spreadsheethandler.ConnectToSpreadsheet();
            Handlers.visualLogicHandler.ConvertSpreadsheetToDataGrid((SpreadSheets)Handlers.visualLogicHandler.UserControls.GetUserControl().IndexOf(Handlers.visualLogicHandler.UserControls.GetUserControl().Find(x => x.IsChecked == true)),Handlers.spreadsheethandler.Sheets);
            Tabelle.BeginInit();
            Tabelle.ItemsSource = Handlers.visualLogicHandler.PlayersFromSpreadsheet;
            Tabelle.EndInit();
        }

        private void CompareLogPlayersWithDKPList_Click(object sender, RoutedEventArgs e)
        {
            Handlers.logikHandler.FindNewOrUnknownPlayer(Handlers.visualLogicHandler.PlayersFromSpreadsheet, Handlers.visualLogicHandler.PlayersFromLogs);
            NewUnknownPlayers.ItemsSource = Handlers.logikHandler.TwinksOrNewPlayers;
            NewUnknownPlayers.EndInit();
        }


        private void AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            Tabelle.BeginInit();
            Handlers.visualLogicHandler.AddPlayerToSpreadsheet(Handlers.logikHandler.TwinksOrNewPlayers);            
            Tabelle.EndInit();
        }
        string reportCode;


        private void DrapAndDropBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(DrapAndDropBox.Text .Length > 0)
            {
                reportCode = DrapAndDropBox.Text.Substring(DrapAndDropBox.Text.IndexOf("reports/") + 8);
                Handlers.logshandler.GetLogfromWarcraftLogs(DrapAndDropBox.Text.Substring(DrapAndDropBox.Text.IndexOf("reports/") + 8));
                PlayersFromLogs.BeginInit();
                Handlers.visualLogicHandler.ConvertLogsToDataGrid(Logs_Results.BaseLogs);
                PlayersFromLogs.ItemsSource = Handlers.visualLogicHandler.PlayersFromLogs;
                PlayersFromLogs.EndInit();
               DrapAndDropBox.Text = "";
            }
            
        }

        private void MarkPlayerForDKP_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Need big Rework!!!!
            Tabelle.BeginInit();
            Handlers.logikHandler.MarkPlayerAsPresent(Handlers.visualLogicHandler.PlayersFromSpreadsheet, Handlers.visualLogicHandler.PlayersFromLogs, out Handlers.visualLogicHandler.PlayersToSpreadsheet);
            Handlers.logikHandler.FindBestPlayers(Handlers.visualLogicHandler.PlayersToSpreadsheet,out Handlers.visualLogicHandler.PlayersToSpreadsheet);
            Tabelle.EndInit();
        }
    }
}
