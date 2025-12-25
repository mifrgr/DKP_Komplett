using All_in_One.Services.WarcraftLogsService.WarcraftlogsModels.LogTypes;
using System.Collections.Generic;

namespace All_in_One.Services.WarcraftLogsService.WarcraftlogsModels
{
    /// <summary>
    /// DataObject für Logs
    /// Die Logdaten für alle gewirkten Fähigkeiten und Die Basisdaten aller Spieler
    /// </summary>
    public class LogsDataObject
    {
        public Casts_Rootobject castsLogs;
        public Base_Rootobject baseLogs;
        public Dictionary<int,Buffs_Rootobject> buffsLogs = new();
    }
}
