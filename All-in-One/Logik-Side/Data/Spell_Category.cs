using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Logik_Side.Data
{
    public class Spell_Category
    {
        /// <summary>
        /// Index = SpellID
        /// </summary>
        public enum Spell_CategoryType
        {
            Casts = 0,
            SunderArmor = 11597,
            Wisdom = 20355,

            Recklessness = 11717,
            Elements = 11722,
            Shadow = 17937,

            Decurse = 2,
            Dispell = 988,
            Decurse_Druid = 2782,
            Decurse_Mage = 475,
            Cleanse = 4987,
            Abolish_Poison = 2893,

            Rapidfire = 3045,
            SliceDice = 6774,
        }
    }
}
