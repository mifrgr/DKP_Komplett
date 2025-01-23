using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.DataModels.DKPModels
{
    internal class Consumables
    {
        public static List<string> AcceptedConsumables = new List<string>()
        {
            "Elixier des Mungos",
            "Elixier der großen Beweglichkeit",
            "Großes Arkanelixier",
            "Manaregeneration",
            "Zanza",
            "Frostmacht",
            "Arkanes Elixier",
            "Fläschchen",
            "Destil",
        };

        public static List<string> AcceptedWeaponEnchants = new List<string>()
        {
            "Gift",
            "Manaöl",
            "Zauberöl",
            "schärfen",
        };
    }
}
