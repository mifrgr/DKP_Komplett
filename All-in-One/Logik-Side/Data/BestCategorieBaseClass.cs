using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Logik_Side.Data
{
    public class BestCategorieBaseClass
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public Effect_Category.Effect_CategoryType EffectCategoryType { get; set; }

        public BestCategorieBaseClass(int Min, int Max, Effect_Category.Effect_CategoryType effectCategoryType)
        {
            MinValue = Min;
            MaxValue = Max;
            EffectCategoryType = effectCategoryType;
        }


    }
}
