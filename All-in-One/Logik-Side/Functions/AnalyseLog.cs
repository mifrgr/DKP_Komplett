using All_in_One.Entrys;
using All_in_One.Logik_Side.Functions.BestPlayerFunctions;
using All_in_One.Logik_Side.Functions.BestPlayerFunctions.BestByRole;
using All_in_One.Logik_Side.Functions.BestPlayerFunctions.Decurse;
using All_in_One.Warcraft_Logs;
using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Logik_Side
{
    internal class AnalyseLog
    {
        List<PlayerDKP> DKPPlayer = new List<PlayerDKP>();
        public List<SpreadsheetEntry> GetDKP_Player(List<SpreadsheetEntry> WorkingSpreadsheet)
        {
            List<SpreadsheetEntry> intern = WorkingSpreadsheet;
            DKPPlayer.Clear();
            TopInLogs();
            BestbyRole();
            BestBuffs();
            BestDebuffs();
            BestDecurse();
            foreach (SpreadsheetEntry entry in intern)
            {
                foreach(PlayerDKP player in DKPPlayer) 
                {
                    if(entry.Spieler == player.Name) 
                    {
                        entry.BesonderePunkte = player.Category;
                    }
                }
            }
            return intern;

        }
        void TopInLogs()
        {
            DKPPlayer.AddRange(_BestDD.BestDD());
            DKPPlayer.AddRange(_BestHeal.BestHeal());
        }

        void BestbyRole()
        {
            DKPPlayer.Add(_PullHunter.PullHunter());
            DKPPlayer.AddRange(_Tanks.Tanks());
        }

        void BestBuffs()
        {
            DKPPlayer.Add(_RapidFire.BestHunter());
            DKPPlayer.Add(_SliceDice.BestRog());
        }

        void BestDebuffs()
        {
            DKPPlayer.Add(_Sunder.BestWarry());
            DKPPlayer.Add(_Recklessness.Best_Reck_Warlock());
            DKPPlayer.Add(_Elements.Best_Elem_Warlock());
            DKPPlayer.Add(_Shadow.Best_Shadow_Warlock());
            DKPPlayer.Add(_Wisdom.BestPala());
        }

        void BestDecurse()
        {
            DKPPlayer.Add(_Cleanse.BestCleanse());
            DKPPlayer.Add(_Decurse.BestDecurser());
            DKPPlayer.Add(_Dispell.BestDispell());
            DKPPlayer.Add(_Poison.BestPoison());
        }
    }
}
