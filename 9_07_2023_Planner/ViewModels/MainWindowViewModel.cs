using _9_07_2023_Planner.Data;
using _9_07_2023_Planner.Models.ViewPanelTemplate;
using _9_07_2023_Planner.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        /// <summary>Заголовок окна </summary>

        private string _title = TextData.ApplicationTitle;
        /// <summary>Заголовок окна</summary>
        public string Title { get => _title; set => Set(ref _title, value); }
        /// <summary>Заголовок окна</summary>
        #endregion

        #region SELECTED GROUP В LISTBOX
        private TaskGroupTemplate _selectedGroup;

        public TaskGroupTemplate SelectedGroup
        {
            get { return _selectedGroup; }
            set
            {
                foreach (var item in GroupList)
                {
                    item.DeleteButtonVisibility = "Collapsed";
                }
                _selectedGroup = value;
                if (GroupList.IndexOf(SelectedGroup) > -1) GroupList[GroupList.IndexOf(SelectedGroup)].DeleteButtonVisibility = "Visible";
                OnPropertyChanged(nameof(SelectedGroup));
            }
        }
        #endregion

        #region СПИСОК ГРУПП
        private ObservableCollection<TaskGroupTemplate> _groupList = new ObservableCollection<TaskGroupTemplate>();
        public ObservableCollection<TaskGroupTemplate> GroupList
        {
            get { return _groupList; }
            set { _groupList = value; OnPropertyChanged(nameof(GroupList)); }
        }
        #endregion


        #endregion



        #region CTOR

        public MainWindowViewModel() { OnStartup();  }

        #endregion

        #region METHODS
        private void OnStartup()
        {
            GenerateGroupList();
        }

        private void GenerateGroupList()
        {
            GroupList = new ObservableCollection<TaskGroupTemplate>
            {
                new TaskGroupTemplate("Red", "Red Group", "Me", 0),
                new TaskGroupTemplate("LawnGreen", "Green Group", "Me", 0),
                new TaskGroupTemplate("Blue", "Blue Group", "Me", 0),
                new TaskGroupTemplate("Yellow", "Yellow Group", "Me", 0),
                new TaskGroupTemplate("White", "White Group", "Me", 0)
            };
        }
        #endregion
    }
}
