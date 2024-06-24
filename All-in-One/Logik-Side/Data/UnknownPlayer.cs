using All_in_One.Logik_Side.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Logik_Side.Data
{
   public class UnknownPlayer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string _name;
        bool _AddNewPlayer;
        string _associatedMain;

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
