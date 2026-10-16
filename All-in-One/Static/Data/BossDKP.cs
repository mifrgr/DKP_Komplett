using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Static.Data
{
    internal class BossDKP
    {
        public List<BossDKPBaseClass> BossDKPValues { get; set; } = new List<BossDKPBaseClass>();
    }

    public class BossDKPBaseClass
    {
        public BossDKPBaseClass(string BossName, int BossDKPVal) 
        {
            this.BossName = BossName;
            this.BossDKPVal = BossDKPVal;
        }

        public string BossName { get; private set; }
        public int BossDKPVal { get; private set; }
    }
}
