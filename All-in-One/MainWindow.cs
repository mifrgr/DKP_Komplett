using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using All_in_One.VisualLogic.Data;
using All_in_One.Services;
using System;
using All_in_One.VisualLogic.Functions.ExtensionMethods;
using System.ComponentModel;
using System.IO;
using All_in_One.DataModels.PlayerModels;
using All_in_One.DataModels.SpreadSheetModels;
using Aspose.Cells;
using System.Xml.Linq;

namespace All_in_One
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainService mainService = new MainService();


        public MainWindow()
        {
            InitializeComponent();
            mainService.Init();
            DataContext = mainService;
        }


        private void NewUnknownPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(NewUnknownPlayers.SelectedItem != null)
            {
                UnknownPlayer clickedPlayer = NewUnknownPlayers.SelectedItem as UnknownPlayer;
                SelectedTwink.Text = clickedPlayer.TwinkName;
            }

        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Alle Sonderpunkte vergeben?" + Environment.NewLine + "Hexertank / Magetank...", "Achtung", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                //mainService.CalculateDKP();
            }

        }

        string reportCode;


        private void DrapAndDropBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(DrapAndDropBox.Text .Length > 0)
            {
               reportCode = DrapAndDropBox.Text.Substring(DrapAndDropBox.Text.IndexOf("reports/") + 8);
               mainService.GetDataFromLog(DrapAndDropBox.Text.Substring(DrapAndDropBox.Text.IndexOf("reports/") + 8));
               DrapAndDropBox.Text = "";
            }
        }

        private void MarkPlayerForDKP_Click(object sender, RoutedEventArgs e)
        {
            mainService.SetDKPForPlayers();
        }

        private void LastRaids_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mainService.GetDataFromLog(((ComboBox)sender).SelectedValue.ToString());

           
        }



        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            mainService.GetDKPFromSpreadSheet((e.Source as CheckBox).Content.ToString());
        }


        private void ConfirmTwinkAsMain_Click(object sender, RoutedEventArgs e)
        {
            mainService.AddMainPlayerToTwink(ListPotentialMain.SelectedValue.ToString(),(UnknownPlayer)NewUnknownPlayers.SelectedValue);
        }

        private void LogFileDropBox_Drop(object sender, DragEventArgs e)
        {
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop);
            mainService.GetDataFromLogTextFile(fileName[0]);
        }
    }
}
