using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using All_in_One.DataModels.DKPModels;
using All_in_One.DataModels.PlayerModels;
using All_in_One.DataModels.SpreadSheetModels;
using All_in_One.DataModels.WarcraftlogsModels;

namespace All_in_One.Services.CalculateService
{
    public class Handler
    {
        NewPlayerFinder playerFinder = new NewPlayerFinder();
        GetDataFromTextFileLogs textlogsanalyser = new GetDataFromTextFileLogs();
        GetDataFromLog loganalyser = new GetDataFromLog();
        SetDKPForPlayers setdkp = new SetDKPForPlayers();
        CalculateDKP calculator = new CalculateDKP();

        public List<UnknownPlayer> FindNewPlayers(ObservableCollection<SpreadsheetEntry> DKPPlayer, LogsDataObject logs)
        {
            return playerFinder.FindNewPlayer(DKPPlayer, logs);
        }

        public List<PlayerDKPEntry> GetPlayerDKPRequirements(string path)
        {
            return textlogsanalyser.GetPlayerDataFromTextFileLogs(path);
        }

        public List<PlayerDKPEntry> GetPlayerDKPRequirement(LogsDataObject logs)
        {
            return loganalyser.GetPlayerDataFromLogs(logs);
        }

        public List<SpreadsheetEntry> SetDKPForPlayers(ObservableCollection<PlayerDKPEntry> playerDKPs)
        {
            return setdkp.SetDKPForPlayersFromLog(playerDKPs);
        }

        public float CalculateDKPPoints(SpreadsheetEntry entry)
        {
            return calculator.CalculateDKPPoints(entry);
        }

    }
}
