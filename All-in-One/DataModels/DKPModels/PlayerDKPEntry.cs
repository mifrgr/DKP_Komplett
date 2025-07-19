using System.ComponentModel;

namespace All_in_One.DataModels.DKPModels
{
    /// <summary>
    /// Die Basisklasse für einen Spieler.
    /// Name, Anzahl un- oder ungenügend verzauberter Gegenstände , Consumables und CPM-Wert
    /// </summary>
    public class PlayerDKPEntry : INotifyPropertyChanged
    {
        string _PlayerName;
        public int CountOfNotEnchantetItems = 0;
        string _Enchantment;
        string _Consumable1;
        string _Consumable2;
        float _CountPerMinutes;


        public string PlayerName
        {
            get { return _PlayerName; }
            set { _PlayerName = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PlayerName))); }
        }
        public string Enchantment
        {
            get { return _Enchantment; }
            set { _Enchantment = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Enchantment))); }
        }
        public string Consumable1
        {
            get { return _Consumable1; }
            set { _Consumable1 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Consumable1))); }
        }
        public string Consumable2
        {
            get { return _Consumable2; }
            set { _Consumable2 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Consumable2))); }
        }
        public float CountPerMinutes
        {
            get { return _CountPerMinutes; }
            set { _CountPerMinutes = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CountPerMinutes))); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
