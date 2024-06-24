using All_in_One.Logik_Side.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Logik_Side.Functions
{
    public static class SwitchTwinkToMainForDKPCalc
    {
        public static void SwitchTwinkForMainInLogs(this ObservableCollection<PlayerOnlyName> PlayersFromLog, ObservableCollection<UnknownPlayer> unknownPlayers)
        {
            foreach (var player in unknownPlayers) 
            { 
                if(player.AssociatedMain != null && player.AssociatedMain.Length > 0) 
                {
                    PlayerOnlyName playerToUpdate = PlayersFromLog.ToList().Find(unplayer => unplayer.Name == player.TwinkName);
                    playerToUpdate.Name = player.AssociatedMain;
                    playerToUpdate.loggedFlag = true;
                }
            }
        }
    }
}
