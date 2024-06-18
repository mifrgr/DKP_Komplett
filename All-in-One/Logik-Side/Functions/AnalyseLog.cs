using All_in_One.Entrys;
using All_in_One.Logik_Side.Functions.BestPlayerFunctions;
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

        public List<PlayerOnlyName> GetDKP_Player()
        {
            List<PlayerOnlyName> DKPPlayer = new();
            DKPPlayer.AddRange(_BestDD.BestDD());
            DKPPlayer.AddRange(_BestHeal.BestHeal());
            DKPPlayer.Add(_Wisdom.BestPala());
            return DKPPlayer;

        }
    }
}
