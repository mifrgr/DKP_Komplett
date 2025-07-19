using All_in_One.DataModels.WarcraftLogsModels.LogTypes;

namespace All_in_One.DataModels.WarcraftlogsModels
{
    /// <summary>
    /// DataObject für Logs
    /// Die Logdaten für alle gewirkten Fähigkeiten und Die Basisdaten aller Spieler
    /// </summary>
    public class LogsDataObject
    {
        public Casts_Rootobject castsLogs;
        public Base_Rootobject baseLogs;
    }
}
