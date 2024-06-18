using All_in_One.Entrys;
using All_in_One.Logik_Side;
using All_in_One.Spreadsheet_Side;
using All_in_One.VisualLogic.Functions;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.VisualLogic
{
    public class Handler
    {
        public List<SpreadsheetEntry> PlayersFromSpreadsheet = new List<SpreadsheetEntry>();
        public List<PlayerOnlyName> PlayersFromLogs = new List<PlayerOnlyName>();

        SpreadSheetToVisu sheetToVisu = new SpreadSheetToVisu();
        LogsToVisu logsToVisu = new LogsToVisu();
        AddPlayer add = new AddPlayer();

        public UserControls UserControls = new UserControls();

        WaitForLogAnalyseHandler handler = new WaitForLogAnalyseHandler();

        Task WaitWindow;
        Task AddValueToBar;
        

        public void ConvertSpreadsheetToDataGrid(SpreadSheets RaidType,List<Sheet> Sheet)
        {
            sheetToVisu.SpreadSheetToList(RaidType,PlayersFromSpreadsheet,Sheet, out PlayersFromSpreadsheet);
        }

        public void ConvertLogsToDataGrid(Casts_Rootobject Logs)
        {
            logsToVisu.LogsToList(Logs, out PlayersFromLogs);
        }

        public void AddPlayerToSpreadsheet(List<UnknownPlayer> TwinksOrNewPlayers)
        {
            add.AddPlayers(TwinksOrNewPlayers, PlayersFromSpreadsheet, out PlayersFromSpreadsheet);
        }
        
        /// <summary>
        /// Change the Value of the ProgressPar
        /// </summary>
        /// <param name="newValue"> The Valeue to add or to set</param>
        /// <param name="IsValueAdded">If true (default), the Value will be added to old Value, otherwise the value will be overriden </param>
        public void ChangeValue(int newValue = 0, bool IsValueAdded = true)
        {
            if(!handler.IsDiagOpen)
            {
                handler.ShowDialog();
                    
            }
            //TODO: FIX THAT
            //if (IsValueAdded)
            //{
            //    AddValueToBar = new Task(() => { handler.AddValue(newValue); });
            //    AddValueToBar.Start();
            //}
            //else
            //{
            //    AddValueToBar = new Task(() => { handler.SetValue(newValue); });
            //    AddValueToBar.Start();
                
            //}
        }

        public int GetValueOfProperty()
        {
            return handler.GetValue();
        }

        public int GetValueOfBar()
        {
            return handler.GetValueOfProp();
        }

    }
}
