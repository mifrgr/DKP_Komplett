using All_in_One.Static.Data;
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
        List<RaidSelection> RaidSelections;

        public List<RaidSelection> GetUserControl()
        {
            if (RaidSelections == null)
                Init();
            return RaidSelections;
        }
        void Init()
        {
            RaidSelections = new List<RaidSelection>();

            foreach (var Sheet in Handlers.spreadsheethandler.Sheets)
            {
                RaidSelections.Add(new RaidSelection(Sheet.Properties.Title));
                
            }
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
