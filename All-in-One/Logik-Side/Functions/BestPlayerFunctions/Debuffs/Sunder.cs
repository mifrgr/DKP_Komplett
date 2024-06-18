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
    internal class _Sunder
    {
        internal static PlayerOnlyName BestWarry()
        {
            PlayerOnlyName bestPlayer = new("");
            foreach(var entry in Logs_Results.CastsLogs[Spell_Category.Spell_CategoryType.SunderArmor].entries.OrderByDescending(entry => entry.total).ToList()) 
            {
                bestPlayer.Name = Logs_Results.CastsLogs[Spell_Category.Spell_CategoryType.Casts].entries.ToList().Find(casts_entry => casts_entry.name == entry.name && (entry.total / casts_entry.total * 100) > Config.DKPRequirement[Spell_Category.Spell_CategoryType.SunderArmor].MinValue && (entry.total / casts_entry.total * 100) < Config.DKPRequirement[Spell_Category.Spell_CategoryType.SunderArmor].MaxValue).name;
            }
            return bestPlayer;
        }
    }
}
