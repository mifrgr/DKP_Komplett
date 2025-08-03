using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace All_in_One.VisualLogic.VisualModels
{
    public class TwinkMainViewModell : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public string Name { get; set; }
        public ObservableCollection<string> Mains { get; set; }
        string selectedmain = string.Empty;
        public string SelectedMain
        {
            get
            {
                return selectedmain;
            }
            set
            {
                selectedmain = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedMain)));
            }
        }

        public TwinkMainViewModell(string name, ObservableCollection<string> mains)
        {
            Name = name;
            Mains = mains;
        }
    }
}
