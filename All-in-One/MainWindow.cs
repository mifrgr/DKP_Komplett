using All_in_One.DataModels.PlayerModels;
using All_in_One.Services;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace All_in_One
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Dispatcher.Invoke(MainService.Instance.Init);
            DataContext = MainService.Instance.visualViewModeel;
        }


        private async void DrapAndDropBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DrapAndDropBox.Text.Length > 0)
            {
                await MainService.Instance.GetDataFromLog(DrapAndDropBox.Text);
                DrapAndDropBox.Text = "";
            }
        }

        private async void SetDKPForPlayers_Click(object sender, RoutedEventArgs e)
        {
            await MainService.Instance.SetDKPForPlayers();
        }

        private async void LastRaids_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await MainService.Instance.GetDataFromLog(((ComboBox)sender).SelectedValue.ToString());
        }



        private async void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            await MainService.Instance.GetDKPFromSpreadSheet((e.Source as CheckBox)?.Content.ToString());
        }

        private void CLMDataDropBox_Drop(object sender, DragEventArgs e)
        {
            //string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop);
            //MainService.Instance.GetDataFromLogTextFile(fileName[0]);
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
