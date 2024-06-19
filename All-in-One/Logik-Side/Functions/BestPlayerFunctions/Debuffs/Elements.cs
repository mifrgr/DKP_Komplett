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
        internal static PlayerDKP Best_Elem_Warlock()
        {
            var Aura = Logs_Results.DebuffLogs[Spell_Category.Spell_CategoryType.Elements].auras?.ToList().Find(entry => ((double)entry.totalUptime / (double)Handlers.logshandler.GetFightTime() * 100) > Config.DKPRequirement[Spell_Category.Spell_CategoryType.Elements].MinValue);
            if(Aura == null)
            {
                return new PlayerDKP("", Spell_Category.Spell_CategoryType.Elements.ToString());
            }
            else
            {
                return new PlayerDKP(Logs_Results.DebuffLogs[Spell_Category.Spell_CategoryType.Elements].auras?.ToList().Find(entry => ((double)entry.totalUptime / (double)Handlers.logshandler.GetFightTime() * 100) > Config.DKPRequirement[Spell_Category.Spell_CategoryType.Elements].MinValue)?.name, Spell_Category.Spell_CategoryType.Elements.ToString());

            }
        }
    }
}
