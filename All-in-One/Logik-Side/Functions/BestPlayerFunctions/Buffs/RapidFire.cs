using All_in_One.Warcraft_Logs.Data;
using System.Linq;
using All_in_One.Static.Data;
using All_in_One.Logik_Side.Data;

namespace All_in_One.Logik_Side.Functions.BestPlayerFunctions
{
    internal class _RapidFire
    {
        internal static PlayerDKP BestHunter()
        {
            var Aura = Logs_Results.BuffsLogs[Spell_Category.Spell_CategoryType.Rapidfire].auras.ToList().OrderByDescending(entry => entry.totalUses).ToList().Find(entry => entry.totalUses >= Handlers.logshandler.GetEncounters());
            if(Aura == null)
            {
                return new PlayerDKP("",Spell_Category.Spell_CategoryType.Rapidfire.ToString());
            }
            else
            {
                return new PlayerDKP(Logs_Results.BuffsLogs[Spell_Category.Spell_CategoryType.Rapidfire].auras?.ToList().OrderByDescending(entry => entry.totalUses).ToList().Find(entry => entry.totalUses >= Handlers.logshandler.GetEncounters())?.name, Spell_Category.Spell_CategoryType.Rapidfire.ToString());

            }
        }
    }
}
