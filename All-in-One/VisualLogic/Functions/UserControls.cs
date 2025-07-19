using All_in_One.DataModels.SpreadSheetModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace All_in_One.VisualLogic.Functions
{
    public class UserControls
    {
        /// <summary>
        /// Liest die Titel der Spreadsheettabellen aus, die in der GUI als Checkboxen erstellt werden.
        /// </summary>
        /// <param name="SpreadSheetAsJson">Die Liste aller Spreadsheet als Json Datei</param>
        /// <returns>Gibt eine Liste mit der Checkbox-Basisklasse aus</returns>
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

    /// <summary>
    /// Die Raids in denen DKP verwendet werden, sind als jeweils eigenes Tabellenblatt vorhanden.
    /// Jedes Tabellenblatt ist als Checkbox in der GUI auswählbar. Dies ist die Basisklasse
    /// </summary>
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
