using All_in_One.Static.Data;
using All_in_One.Warcraft_API;
using All_in_One.Warcraft_Logs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Warcraft_Logs
{
    public class Handler
    {
        InternData data = new InternData();

        public Handler() 
        {
            data.getter = new LogGetter();
        }

        public void GetLogfromWarcraftLogs(string LogID)
        {
            Handlers.visualLogicHandler.ChangeValue(0, false);
            data.getter.GetBaseLogs(LogID);
            //TODO: Fix that
            Handlers.visualLogicHandler.ChangeValue();
            data.endTime = Logs_Results.BaseLogs.end;
            data.getter.GetLogs(LogID,data.endTime);
            data.FightTime = Logs_Results.CastsLogs.totalTime;
        }

        public long GetFightTime()
        {
            return data.FightTime;
        }


    }
}
