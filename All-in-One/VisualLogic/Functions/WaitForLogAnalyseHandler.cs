using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
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
        int addvalue = 6;
        static WaitForReportAnalys dialog;
        public bool IsDiagOpen { get; set; } = false;

        Task ShowWindow;

        internal void InitDiag()
        {
            
            if(dialog == null | IsDiagOpen == false)
            {
                dialog = new WaitForReportAnalys();
                Binding ProgressBarBinding = new Binding("ProgressBarValue");
                ProgressBarBinding.Source = this;
                dialog.ProgressLogAnalyse.SetBinding(ProgressBar.ValueProperty, ProgressBarBinding);

                Binding LabelBinding = new Binding("ActualLogReadStep");
                LabelBinding.Source = this;
                dialog.ActualStep.SetBinding(Label.ContentProperty, LabelBinding);
            }
            
            IsDiagOpen = true;
            dialog.Show();
        }


        internal void CloseDiag()
        {
            dialog.Close();
            IsDiagOpen = false;
        }

        //TODO: Get this done by binding
        internal void AddValue(string Step) 
        {
            ProgressBarValue += addvalue;
            ActualLogReadStep = "Aktuell wird ausgelesen: " + Step;
        }

        internal void SetValue(int Value) 
        {
            ProgressBarValue = Value;
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

        string avalue = "";
        public string ActualLogReadStep
        {
            get { return avalue; }
            set 
            {
                avalue = value;
                OnPropertyChanged("ActualLogReadStep");
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
