using All_in_One.Logik_Side.Data;
using All_in_One.Warcraft_Logs.LogTypes;
using HealingLogs;
using DamageLogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Warcraft_Logs.Data
{
    public static class Logs_Results
    {
        public static Base_Rootobject BaseLogs = new ();
        public static Casts_Rootobject CastsLogs = new ();
        public static Damage_Rootobject DamageLogs = new ();

        public static Dictionary<Spell_Category.Spell_CategoryType,Debuff_Rootobject> DebuffLogs = new()
        {
            {Spell_Category.Spell_CategoryType.Wisdom,new Debuff_Rootobject() },
            {Spell_Category.Spell_CategoryType.Recklessness,new Debuff_Rootobject() },
            {Spell_Category.Spell_CategoryType.Elements,new Debuff_Rootobject() },
            {Spell_Category.Spell_CategoryType.Shadow,new Debuff_Rootobject() },
        };
        //internal static Debuff_Rootobject DebuffLogs = new ();
        public static Healing_Rootobject HealingLogs = new();
    }
}
