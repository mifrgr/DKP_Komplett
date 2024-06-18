using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Warcraft_Logs.LogTypes.Base
{
    public class Base_Rootobject
    {
        public string lang { get; set; }
        public Fight[] fights { get; set; }
        public Friendly[] friendlies { get; set; }
        public Enemy[] enemies { get; set; }
        public Friendlypet[] friendlyPets { get; set; }
        public Enemypet[] enemyPets { get; set; }
        public int logVersion { get; set; }
        public int gameVersion { get; set; }
        public object[] phases { get; set; }
        public string title { get; set; }
        public string owner { get; set; }
        public long start { get; set; }
        public long end { get; set; }
        public int zone { get; set; }
        public Exportedcharacter[] exportedCharacters { get; set; }
    }

    public class Fight
    {
        public int id { get; set; }
        public int boss { get; set; }
        public int start_time { get; set; }
        public int end_time { get; set; }
        public string name { get; set; }
        public int zoneID { get; set; }
        public string zoneName { get; set; }
        public int zoneDifficulty { get; set; }
        public int size { get; set; }
        public int difficulty { get; set; }
        public bool kill { get; set; }
        public int partial { get; set; }
        public bool inProgress { get; set; }
        public int bossPercentage { get; set; }
        public int fightPercentage { get; set; }
        public int lastPhaseAsAbsoluteIndex { get; set; }
        public int lastPhaseForPercentageDisplay { get; set; }
        public object[] maps { get; set; }
    }

    public class Friendly
    {
        public string name { get; set; }
        public int id { get; set; }
        public int guid { get; set; }
        public string type { get; set; }
        public string server { get; set; }
        public string icon { get; set; }
        public Fight1[] fights { get; set; }
    }

    public class Fight1
    {
        public int id { get; set; }
        public int instances { get; set; }
        public int groups { get; set; }
    }

    public class Enemy
    {
        public string name { get; set; }
        public int id { get; set; }
        public int guid { get; set; }
        public string type { get; set; }
        public string icon { get; set; }
        public Fight2[] fights { get; set; }
    }

    public class Fight2
    {
        public int id { get; set; }
        public int instances { get; set; }
        public int groups { get; set; }
    }

    public class Friendlypet
    {
        public string name { get; set; }
        public int id { get; set; }
        public int guid { get; set; }
        public string type { get; set; }
        public string icon { get; set; }
        public int petOwner { get; set; }
        public Fight3[] fights { get; set; }
    }

    public class Fight3
    {
        public int id { get; set; }
        public int instances { get; set; }
    }

    public class Enemypet
    {
        public string name { get; set; }
        public int id { get; set; }
        public int guid { get; set; }
        public string type { get; set; }
        public string icon { get; set; }
        public int petOwner { get; set; }
        public Fight4[] fights { get; set; }
    }

    public class Fight4
    {
        public int id { get; set; }
        public int instances { get; set; }
    }

    public class Exportedcharacter
    {
        public int id { get; set; }
        public string name { get; set; }
        public string server { get; set; }
        public string region { get; set; }
    }

}
