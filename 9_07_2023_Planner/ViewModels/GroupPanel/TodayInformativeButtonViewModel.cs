using _9_07_2023_Planner.Models.ViewPanelTemplate;
using _9_07_2023_Planner.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_07_2023_Planner.ViewModels.GroupPanel
{
    internal class TodayInformativeButtonViewModel : ViewModelBase
    {
        #region TodayTasksButton
        private InformativeButtonTemplate _todayButton = new InformativeButtonTemplate();
        public InformativeButtonTemplate TodayButton
        {
            get { return _todayButton; }
            set
            {
                _todayButton.Counter = value.Counter;
                OnPropertyChanged(nameof(TodayButton));
            }
        }
        #endregion

        private void TitleStringMethod()
        {
            _todayButton.Title = Languages.Lang.Today + "   " + DateTime.Now.ToString("d MMMM, ddd");
        }
        
        public TodayInformativeButtonViewModel() 
        {
            TitleStringMethod();
            TodayButton.Counter = 0.ToString();
        }

        public TodayInformativeButtonViewModel(int counter) 
        {
            TitleStringMethod();
            CounterUpdate(counter);
        }

        public void CounterUpdate(int counter)
        {
            TodayButton.Counter = counter.ToString();
        }

    }
}
