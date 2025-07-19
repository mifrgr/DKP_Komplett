using System.ComponentModel;

namespace All_in_One.DataModels.PlayerModels
{
    /// <summary>
    /// Basisklasse für unbekannte Spieler
    /// Name, Abfrage ob Spieler neu hinzugefügt werden soll, oder ob die Daten einem anderem Char des Spielers zugewiesen werden soll.
    /// </summary>
    public class UnknownPlayer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string _name;
        bool _AddNewPlayer;
        string _associatedMain;
        public bool mainAssociated = false;

        public string TwinkName
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnNotifyChanged(nameof(TwinkName));
            }
        }
        public bool AddNewPlayer
        {
            get
            {
                return _AddNewPlayer;
            }
            set
            {
                _AddNewPlayer = value;
                OnNotifyChanged(nameof(AddNewPlayer));
            }
        }

        public string AssociatedMain
        {
            get
            {
                return _associatedMain;
            }
            set
            {
                _associatedMain = value;
                mainAssociated = true;
                OnNotifyChanged(nameof(AssociatedMain));
            }
        }


        public UnknownPlayer(string name)
        {
            TwinkName = name;
        }

        public void OnNotifyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

    }
}
