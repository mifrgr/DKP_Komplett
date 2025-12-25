using System.Collections.Generic;

namespace All_in_One.Static.Data
{
    internal class Consumables
    {
        public static Dictionary<int,string> AcceptedConsumables = new()
        {
            {17538, "Elixier des Mungos" },
            //{ 17538, "Elixier der großen Beweglichkeit" },
            { 17539, "Großes Arkanelixier" },
            { 18194, "Manaregeneration" },
            {24363,"Magierblut" },
            //"Zanza",
            { 21920, "Frostmacht" },
            //{ 17538, "Arkanes Elixier" },
            { 17626, "Fläschchen der Titanen" },
            { 17627, "Destillierte Weisheit" },
            //"Gesegnete Sonnenfrucht",
            { 17038, "Feuerwasser der Winterfelle" },
            { 16323, "Juju" },
            //"kotellets",
            //"Runn Tum",
            { 18192, "Kalmar" },
            //"knödel",
            { 26276, "Feuermacht" },
            { 11474, "Schattenmacht" },
            { 11405, "Elixier der Riesen" },
            //{ 17538, "Wut der Zeiten" },
            //{ 17538, "Stoß des Skorpoks" },
            //"Große Rüstung",
            { 17628, "Oberste Macht" }
        };

        public static Dictionary<int,string> AcceptedWeaponEnchants = new()
        {
            {2629, "Hervorragendes Manaöl" },
            {2628, "Hervorragendes Zauberöl" },
            {2506, "Waffe schärfen - Kritisch" },
            {1643, "Verdichteter Wetzstein" }
        };

    }
}
