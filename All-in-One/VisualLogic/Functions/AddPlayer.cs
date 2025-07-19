using All_in_One.DataModels.PlayerModels;
using All_in_One.DataModels.SpreadSheetModels;
using System.Collections.ObjectModel;

namespace All_in_One.VisualLogic.Functions
{
    public static class AddPlayer
    {
        /// <summary>
        /// Fügt einen Spieler in der GUI hinzu, wenn dieser als "neu hinzufügen" markiert wurde.
        /// </summary>
        /// <param name="entries">Die Liste aller Spieler, die angezeigt wird</param>
        /// <param name="TwinksOrNewPlayers">Liste aller unbekanten Spieler</param>
        public static void AddPlayers(this ObservableCollection<SpreadsheetEntry> entries, ObservableCollection<UnknownPlayer> TwinksOrNewPlayers)
        {

            foreach (var entry in TwinksOrNewPlayers)
            {
                if (entry.AddNewPlayer)
                {
                    entries.Add(new SpreadsheetEntry
                    {
                        Spieler = entry.TwinkName,
                        VersäumteIDs = 0.ToString(),
                        Punkte = "0",


                    });
                }
            }

        }
    }
}
