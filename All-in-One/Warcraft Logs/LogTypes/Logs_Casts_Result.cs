
namespace All_in_One.Warcraft_Logs.LogTypes.Casts
{
    public class Casts_Rootobject
    {
        public Entry[] entries { get; set; }
        public int totalTime { get; set; }
        public int logVersion { get; set; }
        public int gameVersion { get; set; }
    }

    public class Entry
    {
        public string name { get; set; }
        public int id { get; set; }
        public int guid { get; set; }
        public string type { get; set; }
        public string icon { get; set; }
        public int itemLevel { get; set; }
        public int total { get; set; }
        public int activeTime { get; set; }
        public int activeTimeReduced { get; set; }
        public Ability[] abilities { get; set; }
        public object[] damageAbilities { get; set; }
        public Target[] targets { get; set; }
        public Talent[] talents { get; set; }
        public Gear[] gear { get; set; }
    }

    public class Ability
    {
        public string name { get; set; }
        public int total { get; set; }
        public int type { get; set; }
    }

    public class Target
    {
        public string name { get; set; }
        public int total { get; set; }
        public string type { get; set; }
    }

    public class Talent
    {
        public string name { get; set; }
        public int guid { get; set; }
        public int type { get; set; }
        public string abilityIcon { get; set; }
    }

    public class Gear
    {
        public int id { get; set; }
        public int slot { get; set; }
        public int quality { get; set; }
        public string icon { get; set; }
        public string name { get; set; }
        public int itemLevel { get; set; }
        public int permanentEnchant { get; set; }
        public string permanentEnchantName { get; set; }
        public int setID { get; set; }
        public int temporaryEnchant { get; set; }
        public string temporaryEnchantName { get; set; }
    }
}
