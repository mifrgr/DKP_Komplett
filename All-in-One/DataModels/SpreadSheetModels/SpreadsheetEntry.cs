using System.ComponentModel;

namespace All_in_One.DataModels.SpreadSheetModels
{
    /// <summary>
    /// Basisklasse für einen Eintrag in Google Sheets
    /// </summary>
    public class SpreadsheetEntry : INotifyPropertyChanged
    {
        string _spieler;
        string _punkte;
        string _idsohneteilname;
        string _countsPerMinute;
        string _consumable1;
        string _enchants;
        string _consumable2;
        string _stand;
        string _datum;

        public bool GetDKP = false;

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

        public string VersäumteIDs
        {
            get
            {
                return _idsohneteilname;
            }
            set
            {
                _idsohneteilname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VersäumteIDs)));
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
        public string CountsPerMinutes
        {
            get
            {
                return _countsPerMinute;
            }
            set
            {
                _countsPerMinute = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CountsPerMinutes)));
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
