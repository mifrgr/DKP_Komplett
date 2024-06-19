using All_in_One.Logik_Side.Functions.BestPlayerFunctions.BestByRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace All_in_One.Logik_Side
{
    /// <summary>
    /// Interaktionslogik für ChoosePullHunter.xaml
    /// </summary>
    public partial class ChoosePullHunter : Window
    {

        public ChoosePullHunter()
        {
            InitializeComponent();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if(PullHunterList.SelectedItem != null && MessageBox.Show("Auswahl richtig? Es wurde gewählt:" + Environment.NewLine + PullHunterList.SelectedItem.ToString(),"Bitte bestätigen",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _PullHunter.HunterConfirmed(PullHunterList.SelectedItem.ToString());
            }
            Close();
        }


    }
}
