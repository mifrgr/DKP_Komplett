using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Logik_Side.Data
{
    public class PlayerOnlyName : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        private int _id;

        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnNotify(nameof(ID));
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnNotify(nameof(Name));
            }
        }

        public PlayerOnlyName(string name, int id)
        {
            _name = name;
            _id = id;

        }

        public void OnNotify(string info)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(info));
        }
    }
}
