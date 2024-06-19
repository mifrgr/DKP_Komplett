using All_in_One.Logik_Side.Data;
using All_in_One.Warcraft_Logs.Data;
using System.Linq;


namespace All_in_One.Logik_Side.Functions.BestPlayerFunctions.Decurse
{
    internal class _Cleanse
    {
        internal static PlayerDKP BestCleanse()
        {
            var Aura = Logs_Results.CastsLogs[Spell_Category.Spell_CategoryType.Cleanse].entries.OrderByDescending(entry => entry.total).ToList().Find(entry => entry.total >= Config.DKPRequirement[Spell_Category.Spell_CategoryType.Decurse].MinValue);
            if (Aura == null)
            {
                return new PlayerDKP("", Spell_Category.Spell_CategoryType.Cleanse.ToString());
            }
            else
            {
                return new PlayerDKP(Logs_Results.CastsLogs[Spell_Category.Spell_CategoryType.Cleanse].entries.OrderByDescending(entry => entry.total).ToList().Find(entry => entry.total >= Config.DKPRequirement[Spell_Category.Spell_CategoryType.Decurse].MinValue).name, Spell_Category.Spell_CategoryType.Cleanse.ToString());

            }
        }
    }
}
