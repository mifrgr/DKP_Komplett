using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Static.Data
{
    internal class Worldbuffs
    {
        public static Dictionary<int, WorldbuffEntry> RequiredWorldbuffs = new ()
        {
            {355363, new(){Name = "Schlachtruf der Drachentöter", ReqForClasses = new (){PlayerClasses.Classes[ClassEnums.All]},ReqForRaid = new() {"Naxx","AQ40","BWL","MC","BWL-SA" } } },
            {355365, new(){Name = "Geist von Zandalar", ReqForClasses = new (){ PlayerClasses.Classes[ClassEnums.All] },ReqForRaid = new(){"Naxx","AQ40","BWL","MC", "BWL-SA" } } },
            {22818, new(){Name = "Mol'Dars Mut", ReqForClasses = new (){ PlayerClasses.Classes[ClassEnums.All] },ReqForRaid = new(){"Naxx","AQ40","BWL","MC" } } },

            {22820, new(){Name = "Slip'kik's Grips", ReqForClasses = new(){ PlayerClasses.Classes[ClassEnums.Paladin],PlayerClasses.Classes[ClassEnums.Mage],PlayerClasses.Classes[ClassEnums.Priest],PlayerClasses.Classes[ClassEnums.Warlock] },ReqForRaid = new() { "Naxx", "AQ40", "BWL", "MC" } } },
            {22817, new(){Name = "Fengus' Wildheit", ReqForClasses = new(){PlayerClasses.Classes[ClassEnums.Hunter],PlayerClasses.Classes[ClassEnums.Rogue],PlayerClasses.Classes[ClassEnums.Warrior] },ReqForRaid = new() { "Naxx", "AQ40", "BWL", "MC" } } },

            {23768,new() { Name = "Sayges dunkles Schicksal des Schadens", ReqForClasses = new() { PlayerClasses.Classes[ClassEnums.All], PlayerClasses.Classes[ClassEnums.Alternative] },ReqForRaid = new() { "Naxx", "AQ40", "BWL", "MC" } }},
            {23769,new() { Name = "Sayges dunkles Schicksal des Widerstands", ReqForClasses = new() {PlayerClasses.Classes[ClassEnums.Paladin],PlayerClasses.Classes[ClassEnums.Druid],PlayerClasses.Classes[ClassEnums.Priest], PlayerClasses.Classes[ClassEnums.Alternative] },ReqForRaid = new() { "Naxx", "AQ40", "BWL", "MC" } } },

            {15366,new() { Name = "Liedblumenserenade", ReqForClasses = new() { PlayerClasses.Classes[ClassEnums.All] },ReqForRaid = new(){"Naxx","AQ40" } } }
        };

        public class WorldbuffEntry
        {
            public string Name;
            public List<string> ReqForClasses;
            public List<string> ReqForRaid;
        }
    }

    
}
