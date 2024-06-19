using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using All_in_One.Logik_Side;
using All_in_One.Logik_Side.Data;
using All_in_One.Warcraft_Logs.LogTypes.Base;
using All_in_One.Warcraft_Logs.LogTypes.Casts;
using All_in_One.Warcraft_Logs.LogTypes.Summary;

namespace All_in_One.VisualLogic.Functions
{
    internal class LogsToVisu
    {
        public void LogsToList(Base_Rootobject Logs, out List<PlayerOnlyName> PlayersFromLogs)
        {
            PlayersFromLogs = new List<PlayerOnlyName>();
            foreach (Friendly Player in Logs.friendlies)
            {
                if(Player.fights.Count() > Logs.fights.Count()/2)
                {
                    PlayersFromLogs.Add(new PlayerOnlyName(Player.name));
                }
                
            }

        }
    }
}
