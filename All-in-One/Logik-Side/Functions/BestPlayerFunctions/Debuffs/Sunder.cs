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
        internal static PlayerDKP BestWarry()
        {
            PlayerDKP bestPlayer = new("", Spell_Category.Spell_CategoryType.SunderArmor.ToString());
            foreach(var entry in Logs_Results.CastsLogs[Spell_Category.Spell_CategoryType.SunderArmor].entries.OrderByDescending(entry => entry.total)) 
            {
                var Aura = Logs_Results.CastsLogs[Spell_Category.Spell_CategoryType.Casts].entries.ToList().Find(casts_entry => casts_entry.name == entry.name && ((float)entry.total / (float)casts_entry.total * 100) > Config.DKPRequirement[Spell_Category.Spell_CategoryType.SunderArmor].MinValue && ((float)entry.total / (float)casts_entry.total * 100) < Config.DKPRequirement[Spell_Category.Spell_CategoryType.SunderArmor].MaxValue && !Logs_Results.SummaryLogs.playerDetails.tanks.ToList().Exists(tank => tank.name == entry.name));
                if (Aura == null)
                {
                   
                }
                else
                {                    
                    bestPlayer.Name = Logs_Results.CastsLogs[Spell_Category.Spell_CategoryType.Casts].entries.ToList().Find(casts_entry => casts_entry.name == entry.name && ((float)entry.total / (float)casts_entry.total * 100) > Config.DKPRequirement[Spell_Category.Spell_CategoryType.SunderArmor].MinValue && ((float)entry.total / (float)casts_entry.total * 100) < Config.DKPRequirement[Spell_Category.Spell_CategoryType.SunderArmor].MaxValue).name;
                    break;
                }
            }
            return bestPlayer;
        }
    }
}
