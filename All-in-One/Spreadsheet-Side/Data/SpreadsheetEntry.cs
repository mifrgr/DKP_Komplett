using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Spreadsheet_Side.Data
{
    public class SpreadsheetEntry : INotifyPropertyChanged
    {
        string _spieler;
        string _punkte;
        string _teilgenommen;
        string _activeTime;
        string _consumables;
        string _enchants;
        string _stand;
        string _datum;

        public event PropertyChangedEventHandler PropertyChanged;
        
        public string Spieler
        {
            get
            {
                return _spieler;
            }
            set
            {
                _spieler = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Spieler)));
            }
        }

        public string Punkte 
        {
            get
            {
                return _punkte;
            }
            set
            {
                _punkte = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Punkte)));
            }
        }

        public string Teilgenommen 
        {
            get
            {
                return _teilgenommen;
            }
            set
            {
                _teilgenommen = value;
                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(Teilgenommen)));
            }

        }
        public string ActiveTime 
        {
            get
            {
                return _activeTime;
            }
            set
            {
                _activeTime = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ActiveTime)));
            }
        }
        public string Stand 
        {
            get
            {
                return _stand;
            }
            set
            {
                _stand = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Stand)));
            }
        }
        public string Datum 
        {
            get
            {
                return _datum;
            }
            set
            {
                _datum = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Datum)));
            }

        }
    }
}
