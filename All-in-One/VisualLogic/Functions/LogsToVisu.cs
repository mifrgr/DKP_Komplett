using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using All_in_One.Logik_Side;

namespace All_in_One.VisualLogic.Functions
{
    internal class LogsToVisu
    {
        public void LogsToList(Casts_Rootobject Logs, out List<PlayerOnlyName> PlayersFromLogs)
        {
            PlayersFromLogs = new List<PlayerOnlyName>();
            foreach (var LogsItem in Logs.entries)
            {
                PlayersFromLogs.Add(new PlayerOnlyName(LogsItem.name));
            }

        }
    }
}
