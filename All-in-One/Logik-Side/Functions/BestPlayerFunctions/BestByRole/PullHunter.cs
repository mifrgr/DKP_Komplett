using All_in_One.Warcraft_Logs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Logik_Side.Functions.BestPlayerFunctions.BestByRole
{
    internal class _PullHunter
    {
        static PlayerDKP pullHunter;

        internal static PlayerDKP PullHunter()
        {
            GetPullHunterFromVisu();
            return pullHunter;
        }
        static void GetPullHunterFromVisu()
        {
            ChoosePullHunter pullHunterWindow = new ChoosePullHunter();
            pullHunterWindow.PullHunterList.ItemsSource = Logs_Results.SummaryLogs.playerDetails.dps.Where(dps => dps.type == "Hunter").ToList().Select(hunter => hunter.name);
            pullHunterWindow.ShowDialog();
        }

        internal static void HunterConfirmed(string HunterName)
        {
            pullHunter = new PlayerDKP(HunterName,"Pull-Hunter");
        }


    }
}
