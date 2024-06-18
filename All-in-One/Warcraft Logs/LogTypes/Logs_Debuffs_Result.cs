using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Warcraft_Logs.LogTypes
{
    public class Debuff_Rootobject
    {
        public Aura[] auras { get; set; }
        public int totalTime { get; set; }
        public bool useTargets { get; set; }
        public int startTime { get; set; }
        public long endTime { get; set; }
        public int logVersion { get; set; }
        public int gameVersion { get; set; }
    }

    public class Aura
    {
        public string name { get; set; }
        public int guid { get; set; }
        public string type { get; set; }
        public string abilityIcon { get; set; }
        public int totalUptime { get; set; }
        public int totalUses { get; set; }
        public Band[] bands { get; set; }
    }

    public class Band
    {
        public int startTime { get; set; }
        public int endTime { get; set; }
    }

}
