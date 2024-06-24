using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Warcraft_Logs.LogTypes.Guild
{

    public class Guild_Rootobject
    {
        public string id { get; set; }
        public string title { get; set; }
        public string owner { get; set; }
        public long start { get; set; }
        public long end { get; set; }
        public int zone { get; set; }

    }


}
