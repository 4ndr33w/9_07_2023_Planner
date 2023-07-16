using _9_07_2023_Planner.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_07_2023_Planner.Models.ViewPanelTemplate
{
    internal class InformativeButtonTemplate : ViewModelBase
    {
        private string _title;
        private string _counter;

        public string Counter { get { return _counter; } set { _counter = value; OnPropertyChanged(nameof(Counter)); } }
        public string Title { get { return _title; } set { _title = value; OnPropertyChanged(nameof(Title)); } }

        public InformativeButtonTemplate()
        {

        }

        public InformativeButtonTemplate(string title, int counter)
        {
            Title = title;
            Counter = counter.ToString();
        }
    }
}
