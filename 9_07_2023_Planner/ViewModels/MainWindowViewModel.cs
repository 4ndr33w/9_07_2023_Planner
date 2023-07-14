using _9_07_2023_Planner.Data;
using _9_07_2023_Planner.DataHandlers;
using _9_07_2023_Planner.Infrastructure;
using _9_07_2023_Planner.Models;
using _9_07_2023_Planner.Models.ViewPanelTemplate;
using _9_07_2023_Planner.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace _9_07_2023_Planner.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        #region FIELDS

        string langCode = "en-GB";

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
                if (SelectedGroupIndex > -1) GroupList[SelectedGroupIndex].DeleteButtonVisibility = "Visible";
                //OnPropertyChanged(nameof(SelectedGroup));
            }
        }
        #endregion

        #region SELECTED GROUP INDEX
        private int _selectedGroupIndex = -1;
        public int SelectedGroupIndex { get => _selectedGroupIndex; set => Set(ref _selectedGroupIndex, value); }
        #endregion

        #region СПИСОК ГРУПП
        private ObservableCollection<TaskGroupTemplate> _groupList = new ObservableCollection<TaskGroupTemplate>();
        public ObservableCollection<TaskGroupTemplate> GroupList
        { 
            get => _groupList;
            set => _groupList = value;
            //{
            //    Set(ref _groupList, value);
            //    if (SelectedGroupIndex > -1)
            //    {
            //        foreach (var item in GroupList)
            //        {
            //            item.DeleteButtonVisibility = "Collapsed";
            //        }
            //        GroupList[SelectedGroupIndex].DeleteButtonVisibility = "Visible";
                    
            //    }
            //}

        }
        #endregion

        #region СПИСОК ЗАДАЧ
        private ObservableCollection<TaskTemplate> _taskList = new ObservableCollection<TaskTemplate>();
        public ObservableCollection<TaskTemplate> TaskList { get => _taskList; set => _taskList = value; }
        #endregion

        #region SELECTED TASK
        private TaskTemplate _selectedTask;
        public TaskTemplate SelectedTask 
        { 
            get => _selectedTask; 
            set
            {
                foreach(var item in TaskList)
                {
                    item.DeleteButtonVisibility = "Collapsed";
                    item.CompleteTaskMarkVisibility = "Collapsed";
                    item.EditButtonVisibility = "Collapsed";
                    item.CompletedOrExpiredTaskButtonVisibility = "Collapsed";
                }
                Set(ref _selectedTask, value);
                if (TaskList[SelectedTaskIndex] != null)
                {
                    TaskList[SelectedTaskIndex].DeleteButtonVisibility = "Visible";
                    TaskList[SelectedTaskIndex].CompleteTaskMarkVisibility = "Visible";
                    TaskList[SelectedTaskIndex].EditButtonVisibility = "Visible";
                }
            }
        }
        #endregion

        #region SELECTED TASK INDEX
        private int _selectedTaskIndex = -1;
        public int SelectedTaskIndex { get => _selectedTaskIndex; set => Set(ref _selectedTaskIndex, value); }
        #endregion

        #endregion

        #region CTOR

        public MainWindowViewModel() { OnStartup(); }

        public MainWindowViewModel(ObservableCollection<TaskGroupTemplate> groupList) { OnStartup(); GroupList = groupList; }

        #endregion

        #region METHODS
        private void OnStartup()
        {
            //GenerateGroupList();
            //GenerateTaskListMethod();
            //GenerateTaskListCommand = new RelayCommand(TestMethod);
            TryToDeserializeData();
        }

        #region Генерирование дефолтных списков... Для разработки
        private void GenerateGroupList()
        {
            GroupList = new ObservableCollection<TaskGroupTemplate>
            {
                new TaskGroupTemplate("OrangeRed", "Orange Red Group", "Me", 0),
                new TaskGroupTemplate("DarkOrange", "Dark Orande Group", "Me", 0),
                new TaskGroupTemplate("Orange", "Orange Group", "Me", 0),
                new TaskGroupTemplate("#FFF66B4C", "Green Group", "Me", 0),
                new TaskGroupTemplate("#FF8A2BE2", "Purple Group", "Me", 0)
            };
        }
        private void GenerateTaskListMethod()
        {
            TaskList = new ObservableCollection<TaskTemplate>
            {
                 new TaskTemplate(DateTime.Now, "SampleTask1", "Sample Header 1", "Me", DateTime.Now, "Urgent", true, new TaskGroupModel(GroupList[0])),
                new TaskTemplate(DateTime.Now.AddDays(9), "Sample Task 2", "Sample Header 2", "Me", DateTime.Now, "Urgent", true, GroupList[1]),
                new TaskTemplate(DateTime.Now.AddDays(11), "Sample Task 3", "Sample Header 3", "Me", DateTime.Now, "Urgent", true, GroupList[2]),
                new TaskTemplate(DateTime.Now.AddDays(12), "Sample Task 4", "Sample Header 4", "Me", DateTime.Now, "Urgent", true, GroupList[3]),


                new TaskTemplate(DateTime.Now.AddDays(13), "Sample Task 5", "Sample Header 5", "Me", DateTime.Now, "Urgent", true, GroupList[4])
            };
        }
        #endregion

        private void TryToDeserializeData()
        {
            if (File.Exists(TextData.directory + "\\" + Properties.Resources.GroupListFileName))
            {
                if (GroupList.Count < 1)
                {
                    DataSerializer Serialize = new DataSerializer();
                    GroupList = Serialize.JsonDeserialization(TextData.directory);
                }
            }
        }

        #endregion

        #region COMMANDS

       
        #endregion
    }
}
