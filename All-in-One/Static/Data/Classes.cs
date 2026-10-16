using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Static.Data
{
    internal class PlayerClasses
    {
        internal static Dictionary<ClassEnums,string> Classes = new()
        {
            {ClassEnums.All, "All" },
            {ClassEnums.Alternative, "Alternative" },
            {ClassEnums.Mage, "Mage" },
            {ClassEnums.Warrior, "Warrior" },
            {ClassEnums.Hunter, "Hunter" },
            {ClassEnums.Priest, "Priest" },
            {ClassEnums.Warlock, "Warlock" },
            {ClassEnums.Rogue, "Rogue" },
            {ClassEnums.Paladin, "Paladin" },
            {ClassEnums.Druid, "Druid" },
        };
    }
    internal enum ClassEnums
    {
        All,
        Alternative,
        Mage,
        Warrior,
        Hunter,
        Priest,
        Warlock,
        Rogue,
        Paladin,
        Druid
    }
}
