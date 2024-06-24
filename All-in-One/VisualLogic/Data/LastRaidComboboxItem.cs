using All_in_One.Warcraft_Logs.LogTypes.Guild;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.VisualLogic.Data
{
    public class LastRaidComboboxItem
    {
        public Guild_Rootobject Guild_Rootobject { get; set; }
        public string DisplayName { get; set; }

        public LastRaidComboboxItem(Guild_Rootobject guild_Rootobject, string Name) 
        { 
            Guild_Rootobject = guild_Rootobject;
            DisplayName = Name;
        }

    }
}
