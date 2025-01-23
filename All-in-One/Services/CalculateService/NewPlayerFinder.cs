using All_in_One.DataModels.PlayerModels;
using All_in_One.DataModels.SpreadSheetModels;
using All_in_One.DataModels.WarcraftlogsModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Services.CalculateService
{
    internal class NewPlayerFinder
    {
        public List<UnknownPlayer> FindNewPlayer(ObservableCollection<SpreadsheetEntry> DKPPlayer, LogsDataObject logs)
        {
            List<UnknownPlayer> result = new List<UnknownPlayer>();

            foreach (var player in logs.baseLogs.friendlies)
            {
                if(!DKPPlayer.ToList().Exists(dkpplayer => dkpplayer.Spieler == player.name && player.fights.Length > logs.baseLogs.fights.Length/2)&& player.type != "NPC")
                {
                    result.Add(new UnknownPlayer(player.name));
                }
            }
            return result;
        }
    }
}
