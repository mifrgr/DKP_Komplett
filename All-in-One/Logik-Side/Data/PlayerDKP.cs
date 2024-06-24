using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Logik_Side
{
    public class PlayerDKP : INotifyPropertyChanged
    {
        public PlayerDKP(string name, string category)
        {
            Name = name;
            Category = category;
        }

        string _name;
        string _category;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnNotifyPropertyChanged(nameof(Name));
            }
        }

        public string Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                OnNotifyPropertyChanged(nameof(Category));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnNotifyPropertyChanged(string PropName)
        {
            if(PropertyChanged == null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropName));
            }

        }

      

       
    }

}
