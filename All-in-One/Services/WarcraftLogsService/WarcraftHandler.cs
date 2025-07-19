using All_in_One.DataModels.WarcraftlogsModels;
using All_in_One.DataModels.WarcraftLogsModels.LogTypes;
using System.Collections.Generic;
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

        /// <summary>
        /// Fragt eine Liste der letzten Raids ab.
        /// </summary>
        /// <returns>Eine Liste der letzten Raids als Json Datei</returns>
        public async Task<List<Guild_Rootobject>> GetLastRaids()
        {
            return await loadFunctions.GetGuildLogs();
        }
        /// <summary>
        /// Liest den Log mit der angegebenen ID aus
        /// </summary>
        /// <param name="LogID"></param>
        /// <returns>Gibt einen Task zurück, dessen Ergebnis die Logs als DataObject enthält</returns>
        public async Task<LogsDataObject> GetLogfromWarcraftLogs(string LogID)
        {
            return await loadFunctions.LoadLogs(LogID);

        }


    }
}
