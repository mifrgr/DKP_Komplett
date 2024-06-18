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
    internal class _SliceDice
    {
        internal static PlayerOnlyName BestRog()
        {
            return new PlayerOnlyName(Logs_Results.BuffsLogs[Spell_Category.Spell_CategoryType.SliceDice].auras?.OrderByDescending(entry => entry.totalUptime).ToList().Find(entry => (entry.totalUptime / Handlers.logshandler.GetFightTime() * 100) > Config.DKPRequirement[Spell_Category.Spell_CategoryType.SliceDice].MinValue)?.name);
        }
    }
}
