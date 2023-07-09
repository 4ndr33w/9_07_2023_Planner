using _9_07_2023_Planner.Data;
using _9_07_2023_Planner.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_07_2023_Planner.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        #region FIELDS
        //_9_07_2023_Planner.Data.TextData TextData = new Data.TextData();

        #region ЗАГОЛОВОК ОКНА
        /// <summary>ЗАГОЛОВОК ОКНА</summary>
        private string _title = TextData.ApplicationTitle;
        public string Title { get => _title; set => Set(ref _title, value); }
        #endregion


        #endregion



        #region CTOR

        public MainWindowViewModel() {  }

        #endregion
    }
}
