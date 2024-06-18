using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Logik_Side
{
   public class UnknownPlayer
    {
        public string Name { get; set; }
        public bool AddNewPlayer { get; set; }

        public UnknownPlayer(string name)
        {
            Name = name;
        }
    }
}
