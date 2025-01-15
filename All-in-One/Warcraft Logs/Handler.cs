using All_in_One.Logik_Side.Functions.ExtensionsMethods;
using All_in_One.Static.Data;
using All_in_One.Warcraft_API;
using All_in_One.Warcraft_Logs.Data;
using System;
using System.Collections.Generic;
using System.IO;
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
        

        public void GetLastRaids()
        {
            Handlers.visualLogicHandler.ShowWaitWindow();
            data.getter.GetGuildLogs();
        }

        public void GetLogfromWarcraftLogs(string LogID)
        {
            data.getter.GetAllLogs(LogID);

        }

        public void ReadLogsFromTextFile(string path)
        {
            StreamReader sr = new StreamReader(File.OpenRead(path));
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if(line.Contains("Spell_Aura_Applied") && )
            }

        }

        internal void SetBaseData()
        {
            data.endTime = Logs_Results.BaseLogs.end;
            data.Encounters = Logs_Results.BaseLogs.fights.ToList().Where(x => x.boss != 0).Count();
            
        }

        internal void SetFightData()
        {
            data.FightTime = Logs_Results.SummaryLogs.totalTime;
        }

        public long GetEndTime()
        {
            return data.endTime;
        }

        public string GetRaidDate()
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(data.endTime).DateTime.ToShortDateString();
        }

        public long GetFightTime()
        {
            return data.FightTime;
        }

        public int GetEncounters()
        {
            return data.Encounters;
        }

    }
}
