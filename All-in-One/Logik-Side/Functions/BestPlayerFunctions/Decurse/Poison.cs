using All_in_One.Logik_Side.Data;
using All_in_One.Warcraft_Logs.Data;
using System.Linq;

namespace All_in_One.Logik_Side.Functions.BestPlayerFunctions.Decurse
{
    internal class _Poison
    {
        internal static PlayerOnlyName BestDispell()
        {
            return new PlayerOnlyName(Logs_Results.CastsLogs[Spell_Category.Spell_CategoryType.Abolish_Poison].entries.OrderByDescending(entry => entry.total).ToList().Find(entry => entry.total >= Config.DKPRequirement[Spell_Category.Spell_CategoryType.Decurse].MinValue).name);
        }
    }
}
