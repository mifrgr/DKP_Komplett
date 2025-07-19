using System.Collections.Generic;

namespace All_in_One.DataModels.DKPModels
{
    /// <summary>
    /// Eine Verzauberung verbessert ein oder mehrer Stats um einen bestimmten absoluten oder Prozentwert
    /// </summary>
    internal class Enchantment
    {
        public List<EnchantmentBaseClass> EnchantmentStatImprove { get; set; }
        public int ID;

        public Enchantment(List<EnchantmentBaseClass> StatsImprove, int iD)
        {
            EnchantmentStatImprove = StatsImprove;
            ID = iD;
        }
    }
    /// <summary>
    /// Basisklasse für eine Verzauberung.
    /// </summary>
    internal class EnchantmentBaseClass
    {
        public Enchantments.EnchantmentStat StatImprove { get; set; }
        public int ImproveValue { get; set; }
        public bool IsPercent { get; set; }

        public EnchantmentBaseClass(Enchantments.EnchantmentStat Stat, int Value, bool isPercent = false)
        {
            StatImprove = Stat;
            ImproveValue = Value;
            IsPercent = isPercent;
        }
    }
}
