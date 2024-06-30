using All_in_One.Logik_Side.Data;
using All_in_One.Spreadsheet_Side.Data;
using All_in_One.Static.Data;
using All_in_One.Warcraft_Logs.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Logik_Side.Functions.ExtensionsMethods
{
    public static class UpdateSpreadSheetList
    {
        //TODO: Implement, when ReadList <- WorkingList -> WriteList is is implemented.
        public static void UpdateSpreadSheet(this ObservableCollection<SpreadsheetEntry> spreadsheets, List<SpreadsheetEntry> WorkingSheet)
        {
            foreach (SpreadsheetEntry workingentry in WorkingSheet)
            {
                if(spreadsheets.ToList().Exists(entry => entry.Spieler == workingentry.Spieler))
                {
                    int index = spreadsheets.IndexOf(workingentry);
                    spreadsheets[index].Spieler = workingentry.Spieler;
                    spreadsheets[index].Teilgenommen = workingentry.Teilgenommen;
                    spreadsheets[index].BesonderePunkte = workingentry.BesonderePunkte;
                    spreadsheets[index].Datum = workingentry.Datum;
                    spreadsheets[index].Stand = workingentry.Stand;

                }
                  
            }

        }

        public static void UpdateSpreadSheet(this ObservableCollection<SpreadsheetEntry> spreadsheets, List<PlayerDKP> Players, ObservableCollection<UnknownPlayer> unknownPlayers)
        {
            //Update Header
            spreadsheets[0].Stand = Handlers.logshandler.GetRaidDate();
            //TODO: FIX that, lazy shit!
            foreach (UnknownPlayer player in unknownPlayers)
            {
                PlayerDKP ModifiedPlayer = Players.Find(dkpPlayer => dkpPlayer.Name == player.TwinkName);
                ModifiedPlayer.Name = player.AssociatedMain;
                ModifiedPlayer.Category += " | Umgeloggt -> " + player.TwinkName;
            }
            foreach(PlayerDKP player in Players)
            {
                if(spreadsheets.ToList().Exists(entry => entry.Spieler == player.Name))
                {
                    SpreadsheetEntry entryToUpdate = spreadsheets.ToList().Find(entry => entry.Spieler == player.Name);
                    int indexToUpdate = spreadsheets.IndexOf(entryToUpdate);
                    //TODO: This should be the Category!
                    if(spreadsheets[indexToUpdate].BesonderePunkte == "")
                    {
                        spreadsheets[indexToUpdate].BesonderePunkte = player.Category;
                    }
                    else
                    {
                        spreadsheets[indexToUpdate].BesonderePunkte += " | " +player.Category;
                    }

                }
            }
        }

        public static void CollectionChangedHandler(object sender, NotifyCollectionChangedEventArgs args)
        {

        }
    }
}
