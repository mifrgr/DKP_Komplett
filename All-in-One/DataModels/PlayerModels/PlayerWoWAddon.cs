using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.DataModels.PlayerModels
{
    public class PlayerWoWAddon
    {
        public string ID;
        public string Name;
        public Dictionary<DateTime,string> TimeStamp = new ();
    }
}
