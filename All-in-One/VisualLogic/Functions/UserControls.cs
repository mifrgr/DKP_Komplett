using All_in_One.DataModels.SpreadSheetModels;
using Aspose.Cells.Drawing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace All_in_One.VisualLogic.Functions
{
    public class UserControls
    {
        public ObservableCollection<RaidSelection> GetUserControl(List<JsonSheetEntry> SpreadSheetAsJson)
        {
            ObservableCollection<RaidSelection> result = new ObservableCollection<RaidSelection>();

            foreach (var Sheet in SpreadSheetAsJson)
            {
                result.Add(new RaidSelection(Sheet.Properties.Title));

            }
            return result;
        }

    }

    public class RaidSelection : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public RaidSelection(string content, bool isChecked = false)
        {
            Content = content;
            IsChecked = isChecked;
        }

        private string content;
        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                if (value != content)
                {
                    content = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private bool isChecked;
        public bool IsChecked
        {
            get
            {
                return isChecked;
            }
            set
            {
                if (value != isChecked)
                {
                    isChecked = value;
                    NotifyPropertyChanged();
                }
            }
        }


    }




}
