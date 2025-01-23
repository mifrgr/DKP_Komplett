using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.DataModels.DKPModels
{
    public class PlayerDKPEntry : INotifyPropertyChanged
    {
        string _PlayerName;
        public int CountOfNotEnchantetItems = 0;
        string _Enchantment;
        string _Consumable;
        string _WeaponEnchantment;
        float _ActiveTime;


        public string PlayerName 
        { 
            get {return _PlayerName;}
            set { _PlayerName = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PlayerName))); } 
        }
        public string Enchantment 
        {
            get { return _Enchantment; }
            set { _Enchantment = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Enchantment))); }
        }
        public string Consumable 
        {
            get { return _Consumable; }
            set { _Consumable = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Consumable))); } 
        }
        public string WeaponEnchantment 
        { 
            get { return _WeaponEnchantment; }
            set { _WeaponEnchantment = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(WeaponEnchantment))); } 
        }
        public float ActiveTime 
        {
            get { return _ActiveTime; }
            set { _ActiveTime = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ActiveTime))); } 
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
