using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using All_in_One.Logik_Side.Data;
using All_in_One.Static.Data;
using All_in_One.Warcraft_Logs.Data;

namespace All_in_One.Logik_Side.Functions.BestPlayerFunctions
{
    internal static class _Wisdom
    {
        internal static PlayerOnlyName BestPala()
        {
            return new PlayerOnlyName(Logs_Results.DebuffLogs[Spell_Category.Spell_CategoryType.Wisdom].auras?.ToList().Find(entry => (entry.totalUptime / Handlers.logshandler.GetFightTime() * 100) > Config.DKPRequirement[Spell_Category.Spell_CategoryType.Wisdom].MaxValue)?.name);
        }
    }
}
