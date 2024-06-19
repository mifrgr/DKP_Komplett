using All_in_One.Logik_Side.Data;
using All_in_One.Warcraft_Logs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using All_in_One.Static.Data;

namespace All_in_One.Logik_Side.Functions.BestPlayerFunctions
{
    internal static class _Recklessness
    {
        internal static PlayerDKP Best_Reck_Warlock()
        {
            var Aura = Logs_Results.DebuffLogs[Spell_Category.Spell_CategoryType.Recklessness].auras?.ToList().Find(entry => ((double)entry.totalUptime / (double)Handlers.logshandler.GetFightTime() * 100) > Config.DKPRequirement[Spell_Category.Spell_CategoryType.Wisdom].MinValue);
            if(Aura == null)
            {
                return new PlayerDKP("", Spell_Category.Spell_CategoryType.Recklessness.ToString());
            }
            else
            {
                return new PlayerDKP(Logs_Results.DebuffLogs[Spell_Category.Spell_CategoryType.Recklessness].auras?.ToList().Find(entry => ((double)entry.totalUptime / (double)Handlers.logshandler.GetFightTime() * 100) > Config.DKPRequirement[Spell_Category.Spell_CategoryType.Wisdom].MinValue)?.name, Spell_Category.Spell_CategoryType.Recklessness.ToString());

            }
        }
    }
}
