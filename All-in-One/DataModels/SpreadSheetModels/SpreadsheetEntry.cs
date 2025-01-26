using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.DataModels.SpreadSheetModels
{
    public class SpreadsheetEntry : INotifyPropertyChanged
    {
        string _spieler;
        string _punkte;
        string _teilgenommen;
        string _activeTime;
        string _consumable1;
        string _enchants;
        string _consumable2;
        string _stand;
        string _datum;

        public bool GetDKP =false;

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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Teilgenommen)));
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
        public string Consumables1
        {
            get
            {
                return _consumable1;
            }
            set
            {
                _consumable1 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Consumables1)));
            }
        }
        public string Verzauberungen
        {
            get
            {
                return _enchants;
            }
            set
            {
                _enchants = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Verzauberungen)));
            }
        }
        public string Consumable2
        {
            get
            {
                return _consumable2;
            }
            set
            {
                _consumable2 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Consumable2)));
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
