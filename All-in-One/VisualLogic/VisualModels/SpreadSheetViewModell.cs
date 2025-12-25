using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.VisualLogic.VisualModels
{
    public class SpreadSheetViewModell : INotifyPropertyChanged
    {
        string _spieler;
        string _versäumteIds;
        string _enchants;
        string _consumable1;
        string _consumable2;
        string _countsPerMinute;
        string _stand;

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

        public string VersäumteIDs
        {
            get
            {
                return _versäumteIds;
            }
            set
            {
                _versäumteIds = value;
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
    }
}
