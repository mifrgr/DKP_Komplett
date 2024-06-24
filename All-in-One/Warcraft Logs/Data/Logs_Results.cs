using All_in_One.Logik_Side.Data;
using System.Collections.Generic;
using All_in_One.Warcraft_Logs.LogTypes.Base;
using All_in_One.Warcraft_Logs.LogTypes.Buffs;
using All_in_One.Warcraft_Logs.LogTypes.Casts;
using All_in_One.Warcraft_Logs.LogTypes.Damage;
using All_in_One.Warcraft_Logs.LogTypes.Debuffs;
using All_in_One.Warcraft_Logs.LogTypes.Healing;
using All_in_One.Warcraft_Logs.LogTypes.Summary;
using All_in_One.Warcraft_Logs.LogTypes.Guild;

namespace All_in_One.Warcraft_Logs.Data
{
    public static class Logs_Results
    {
        public static List<Guild_Rootobject> GuildLogs = new();
        public static Summary_Rootobject SummaryLogs = new();
        public static Base_Rootobject BaseLogs = new ();

        public static Dictionary<Spell_Category.Spell_CategoryType, Casts_Rootobject> CastsLogs = new()
        {
            {Spell_Category.Spell_CategoryType.Casts,new Casts_Rootobject()},
            {Spell_Category.Spell_CategoryType.SunderArmor,new Casts_Rootobject()},
            {Spell_Category.Spell_CategoryType.Cleanse,new Casts_Rootobject()},
            {Spell_Category.Spell_CategoryType.Decurse,new Casts_Rootobject()},
            {Spell_Category.Spell_CategoryType.Dispell,new Casts_Rootobject()},
            {Spell_Category.Spell_CategoryType.Abolish_Poison,new Casts_Rootobject()},
        };
        public static Damage_Rootobject DamageLogs = new ();

        public static Dictionary<Spell_Category.Spell_CategoryType,Debuff_Rootobject> DebuffLogs = new()
        {
            {Spell_Category.Spell_CategoryType.Wisdom,new Debuff_Rootobject() },
            {Spell_Category.Spell_CategoryType.Recklessness,new Debuff_Rootobject() },
            {Spell_Category.Spell_CategoryType.Elements,new Debuff_Rootobject() },
            {Spell_Category.Spell_CategoryType.Shadow,new Debuff_Rootobject() },
        };
        public static Dictionary<Spell_Category.Spell_CategoryType,Buffs_Rootobject> BuffsLogs = new ()
        {
            {Spell_Category.Spell_CategoryType.Rapidfire,new Buffs_Rootobject() },
            {Spell_Category.Spell_CategoryType.SliceDice,new Buffs_Rootobject() }
        };
        public static Healing_Rootobject HealingLogs = new();


    }
}
