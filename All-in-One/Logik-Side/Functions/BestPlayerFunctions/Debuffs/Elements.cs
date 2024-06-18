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
    internal class _Elements
    {
        internal static PlayerOnlyName Best_Elem_Warlock()
        {
            return new PlayerOnlyName(Logs_Results.DebuffLogs[Spell_Category.Spell_CategoryType.Elements].auras?.ToList().Find(entry => (entry.totalUptime / Handlers.logshandler.GetFightTime() * 100) > Config.DKPRequirement[Spell_Category.Spell_CategoryType.Elements].MinValue)?.name);
        }
    }
}
