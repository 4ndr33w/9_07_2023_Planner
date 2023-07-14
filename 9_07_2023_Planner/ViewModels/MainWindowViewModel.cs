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

        #region REQUEST WINDOW USER-CONTROL VISIBILITY
        private string _deleteGroupRequestWindowUserControlVisibility = "Collapsed";
        private string _deleteTaskRequestWindowUserControlVisibility = "Collapsed";

        public string DeleteGroupRequestWindowUserControlVisibility
        {
            get => _deleteGroupRequestWindowUserControlVisibility;
            set 
            { 
                Set(ref _deleteGroupRequestWindowUserControlVisibility, value);
                if (value == "Visible") DeleteTaskRequestWindowUserControlVisibility = "Collapsed";
            }
        }
        public string DeleteTaskRequestWindowUserControlVisibility
        {
            get => _deleteTaskRequestWindowUserControlVisibility;
            set
            {
                Set(ref _deleteTaskRequestWindowUserControlVisibility, value);
                if (value == "Visible") DeleteGroupRequestWindowUserControlVisibility = "Collapsed";
            }
        }
        #endregion

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
            get => _selectedGroup;
            set
            {
                foreach (var item in GroupList)
                {
                    item.DeleteButtonVisibility = "Collapsed";
                }
                Set(ref _selectedGroup, value);
                //_selectedGroup = value;
                if (GroupList.IndexOf(SelectedGroup) > -1) GroupList[GroupList.IndexOf(SelectedGroup)].DeleteButtonVisibility = "Visible";
                //OnPropertyChanged(nameof(SelectedGroup));
            }
        }
        #endregion

        #region SELECTED INDEX
        private int _selectedIndex = -1;
        public int SelectedIndex { get => _selectedIndex; set => Set(ref _selectedIndex, value); }
        #endregion

        #region СПИСОК ГРУПП
        private ObservableCollection<TaskGroupTemplate> _groupList = new ObservableCollection<TaskGroupTemplate>();
        public ObservableCollection<TaskGroupTemplate> GroupList
        { get => _groupList; set => Set(ref _groupList, value); }
        #endregion


        #endregion



        #region CTOR

        public MainWindowViewModel() { OnStartup();  }

        public MainWindowViewModel(ObservableCollection<TaskGroupTemplate> groupList) { OnStartup(); GroupList = groupList; }

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
