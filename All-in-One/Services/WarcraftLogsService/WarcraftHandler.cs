using All_in_One.DataModels.DKPModels;
using All_in_One.DataModels.WarcraftlogsModels;
using All_in_One.DataModels.WarcraftLogsModels;
using All_in_One.DataModels.WarcraftLogsModels.LogTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Services.WarcraftLogsService
{
    public class WarcraftHandler
    {
        LoadFunctions loadFunctions;

        public WarcraftHandler() 
        {
            loadFunctions = new LoadFunctions();
        }
        

        public async Task<List<Guild_Rootobject>> GetLastRaids()
        {
            return await loadFunctions.GetGuildLogs();
        }

        public async Task<LogsDataObject> GetLogfromWarcraftLogs(string LogID)
        {
            return await loadFunctions.LoadLogs(LogID);

        }


    }
}
