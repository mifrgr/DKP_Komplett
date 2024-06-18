using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Logik_Side.Data
{
    //TODO: Maybe external config file
    public static class Config
    {
        public static Dictionary<Spell_Category.Spell_CategoryType, BestCategorieBaseClass> DKPRequirement = new()
        {
            {Spell_Category.Spell_CategoryType.SunderArmor, new BestCategorieBaseClass(5,25,Effect_Category.Effect_CategoryType.Cast)},
            {Spell_Category.Spell_CategoryType.Wisdom, new BestCategorieBaseClass(50,100,Effect_Category.Effect_CategoryType.Debuff)},
            {Spell_Category.Spell_CategoryType.Recklessness, new BestCategorieBaseClass(50,100,Effect_Category.Effect_CategoryType.Debuff)},
            {Spell_Category.Spell_CategoryType.Elements, new BestCategorieBaseClass(50,100,Effect_Category.Effect_CategoryType.Debuff)},
            {Spell_Category.Spell_CategoryType.Shadow, new BestCategorieBaseClass(50,100,Effect_Category.Effect_CategoryType.Debuff)},
            {Spell_Category.Spell_CategoryType.Rapidfire, new BestCategorieBaseClass(0,25,Effect_Category.Effect_CategoryType.Buffs)},
            {Spell_Category.Spell_CategoryType.SliceDice, new BestCategorieBaseClass(50,25,Effect_Category.Effect_CategoryType.Buffs)},
            {Spell_Category.Spell_CategoryType.Decurse, new BestCategorieBaseClass(5,1000,Effect_Category.Effect_CategoryType.Cast)}
        };
    }
}
