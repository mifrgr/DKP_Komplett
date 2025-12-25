using All_in_One.Services.CalculateService.DataModels;
using All_in_One.Services.SpreadSheetService.DataModels;
using All_in_One.Services.WarcraftLogsService.WarcraftlogsModels;
using All_in_One.Services.WarcraftLogsService.WarcraftlogsModels.LogTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace All_in_One.Services
{
    class MainService
    {
        public VisualLogic.ViewModell visualViewModeel { get; private set; } = new VisualLogic.ViewModell();
        private CalculateService.CalculateService calculateHandler = new CalculateService.CalculateService();
        private SpreadSheetService.SpreadSheetService spreadSheetHandler = new SpreadSheetService.SpreadSheetService();
        private WarcraftLogsService.WarcraftHandler logsHandler = new WarcraftLogsService.WarcraftHandler();

       
        public static MainService Instance { get; private set; } = new MainService();
        /// <summary>
        /// Aktuelle DKP-Liste des aktuellen Raids
        /// </summary>
        public List<PlayerData> DKPListFromSpreadSheet { get; set; } = new();


        public List<PlayerExtractedData> PlayerExtractedDatas { get; set; } = new List<PlayerExtractedData> { };

        public List<Guild_Rootobject> LastRaids {  get; set; }

        LogsDataObject logs;
        string selectedRaid = "";

        public List<JsonSheetEntry> SpreadsheetAsJson = new();



        /// <summary>
        /// Initialisiert das Programm.
        /// Die Spreadsheets werden abgerufen.
        /// Die letzten Logs werden ausgelesen und als Auswahlmenü angezeigt
        /// </summary>
        public async Task Init()
        {
            try
            {
                visualViewModeel.ProgressBarControll(true);

                LastRaids = await logsHandler.GetLastRaids();
                SpreadsheetAsJson = await spreadSheetHandler.GetSpreadSheets();
                visualViewModeel.Init(SpreadsheetAsJson);
                               
                visualViewModeel.ProgressBarControll();
            }
            catch(Exception ex) 
            {
                visualViewModeel.ProgressBarControll(true, ex.Message);
            }
        }

        /// <summary>
        /// Die DKPs werden aus dem ausgewählten Spreadsheet ausgelesen. DKPs sind Raidgebunden. Für jeden Raid existiert ein eigenes Sheet.
        /// 
        /// <para>Die Daten werden als Grid in der GUI angezeigt.</para>
        /// 
        /// Es werden unbekannte Spieler ermittelt und angezeigt.
        /// </summary>
        /// <param name="SelectedRaid"></param>
        public async Task GetDKPFromSpreadSheet(string SelectedRaid)
        {
            visualViewModeel.ProgressBarControll(true);
            //foreach (var item in RaidCheckBoxCollection)
            //{
            //    if (item.Content != SelectedRaid)
            //    {
            //        item.IsChecked = false;
            //    }
            //}
            SpreadsheetAsJson = await spreadSheetHandler.GetSpreadSheets();

            DKPListFromSpreadSheet = spreadSheetHandler.GetSpreadSheetConvertedData(SpreadsheetAsJson.Find(entry => entry.Properties.Title == SelectedRaid));
            visualViewModeel.ProgressBarControll();
        }



        /// <summary>
        /// Es werden die Daten des ausgewählten Raids aus den Logs ausgelesen, die zur Berechnung erforderlich sind.
        /// </summary>
        /// <param name="SelectedRaid"></param>
        public async Task GetDataFromLog(string SelectedRaid)
        {
            visualViewModeel.ProgressBarControll(true);
            selectedRaid = SelectedRaid;
            if(selectedRaid.Contains("|"))
            {
                logs = await logsHandler.GetLogfromWarcraftLogs(SelectedRaid.Split("|")[2].Trim());
            }
            else
            {
                logs = await logsHandler.GetLogfromWarcraftLogs(selectedRaid);
            }

            PlayerExtractedDatas = calculateHandler.GetPlayerDKPRequirement(logs);
            visualViewModeel.ProgressBarControll();
            await SetDKPForPlayers();
        }

       
        /// <summary>
        /// Neue Spieler werden in die Spreadsheetliste eingetragen.
        /// Die Spreadsheetliste wird mit den ermitteln Daten aktualisiert.
        /// Die versäumten IDs der Spieler werden aktualisiert.
        /// </summary>
        public async Task SetDKPForPlayers()
        {
            visualViewModeel.ProgressBarControll(true);

            var MainTwinkList = visualViewModeel.GetMainTwinkList();
            foreach (var mainTwink in MainTwinkList)
            {
                if(mainTwink.MainName != "")
                {
                    DKPListFromSpreadSheet.Find(player => player.Name == mainTwink.MainName).Name = mainTwink.MainName;
                    PlayerExtractedDatas.Find(player => player.PlayerName == mainTwink.TwinkName).PlayerName = mainTwink.MainName;
                }
            }
            
            var UpdatedSpreadsheetList = calculateHandler.SetExtractedDataToSheet(PlayerExtractedDatas, DKPListFromSpreadSheet);
            DKPListFromSpreadSheet.Clear();
            foreach (var entry in UpdatedSpreadsheetList)
            {
                DKPListFromSpreadSheet.Add(entry);
                visualViewModeel.UpdateViewModellData(new VisualLogic.Data.VisualUpdateDataObject(entry, typeof(PlayerData), entry.Name));
            }
            DKPListFromSpreadSheet[0].Date = selectedRaid.Split("|")[1].Trim();
            TidyUp();
            var result = await spreadSheetHandler.UpdateSpreadSheetData(DKPListFromSpreadSheet);
            visualViewModeel.ProgressBarControll();

            calculateHandler.SetAddonData(DKPListFromSpreadSheet);
        }
        /// <summary>
        /// Löscht Spieler, die 10 IDs nicht am Raid teilgenommen haben
        /// </summary>
        private void TidyUp()
        {
            var Worklist = DKPListFromSpreadSheet.Where(entry =>        
             entry.IDs_Missed_Count >= 10)
            .ToList();

            foreach (var item in Worklist)
            {
                DKPListFromSpreadSheet.Remove(item);
            }
        }

    }
}
