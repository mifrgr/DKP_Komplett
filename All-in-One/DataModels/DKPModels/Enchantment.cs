using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.DataModels.DKPModels
{
    internal class Enchantment
    {
        public List<EnchantmentBaseClass> EnchantmentStatImprove {  get; set; }
        public int ID;

        public Enchantment(List<EnchantmentBaseClass> StatsImprove, int iD)
        {
            EnchantmentStatImprove = StatsImprove;
            ID = iD;
        }
    }

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
