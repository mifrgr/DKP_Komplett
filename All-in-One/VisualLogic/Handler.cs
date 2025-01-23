using All_in_One.VisualLogic.Data;
using All_in_One.VisualLogic.Functions;
using All_in_One.VisualLogic.Windows;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using All_in_One.DataModels.PlayerModels;
using All_in_One.DataModels.SpreadSheetModels;
using All_in_One.DataModels.WarcraftLogsModels.LogTypes;


namespace All_in_One.VisualLogic
{
    public class Handler
    {



        public UserControls UserControls = new UserControls();

        PleaseWait window = new PleaseWait();

        public void ShowWaitWindow()
        {          
            window.Show();
            window.Focus();
        }

        void CloseWaitWindow()
        {
            window?.Close();
        }

        public ObservableCollection<SpreadsheetEntry> ConvertSpreadsheetToDataGrid(JsonSheetEntry Sheet)
        {
            SpreadSheetToViewModelConverter converter = new SpreadSheetToViewModelConverter();
            return converter.ConvertSpreadSheetToViewModel(Sheet);
        }


        

    }
}
