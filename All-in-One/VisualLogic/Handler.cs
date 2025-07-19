using All_in_One.DataModels.SpreadSheetModels;
using All_in_One.VisualLogic.Functions;
using All_in_One.VisualLogic.Windows;
using System.Collections.ObjectModel;


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
