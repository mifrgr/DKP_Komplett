using System;
using System.Collections.Generic;

namespace All_in_One.DataModels.PlayerModels
{
    /// <summary>
    /// Basisklasse für einen Spieler aus dem Addon NovaRaidCompanion
    /// SpielerID, Name und eine Liste aller genommen Consumables mit Zeitstempel
    /// </summary>
    public class PlayerWoWAddon
    {
        public string ID;
        public string Name;
        public Dictionary<DateTime, string> TimeStamp = new();
    }
}
