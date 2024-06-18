using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;

namespace All_in_One.VisualLogic.Functions
{
    /// <summary>
    /// Handles the whole WaitingDialog
    /// </summary>
    internal class WaitForLogAnalyseHandler : INotifyPropertyChanged
    {
        int addvalue = 5;
        WaitForReportAnalys dialog;
        public bool IsDiagOpen { get; set; }

        internal void ShowDialog()
        {
            if(dialog == null)
            {
                dialog = new WaitForReportAnalys();
                //Binding binding = new Binding("ProgressBarValue");
                //dialog.ProgressLogAnalyse.SetBinding(ProgressBar.ValueProperty, binding);
            }
            dialog.Show();
            IsDiagOpen = true;
        }
        //TODO: Get this done by binding
        internal void AddValue(int Value) 
        {

            dialog.BeginInit();
            ProgressBarValue += addvalue;
            dialog.ProgressLogAnalyse.Value = addvalue;
            dialog.EndInit();
        }

        internal void SetValue(int Value) 
        {
            dialog.BeginInit();
            ProgressBarValue = Value;
            dialog.ProgressLogAnalyse.Value = Value;
            dialog.EndInit();
        }

        internal int GetValue() 
        { 
            return ProgressBarValue;
        }

        internal int GetValueOfProp()
        {
            return (int)dialog.ProgressLogAnalyse.Value;
        }

        int pvalue = 0;

        public int ProgressBarValue
        {
            get { return pvalue; }
            set
            {
                pvalue = value;
                OnPropertyChanged("ProgressBarValue");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }

    }
}
