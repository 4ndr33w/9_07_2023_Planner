using _9_07_2023_Planner.Data;
using _9_07_2023_Planner.DataHandlers;
using _9_07_2023_Planner.Infrastructure;
using _9_07_2023_Planner.Models;
using _9_07_2023_Planner.Models.ViewPanelTemplate;
using _9_07_2023_Planner.ViewModels.Base;
using _9_07_2023_Planner.Views.Components.LeftPanel;
using _9_07_2023_Planner.Views.Components.MiddlePanel;
using _9_07_2023_Planner.Views.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace _9_07_2023_Planner.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        #region FIELDS

        string langCode = "en-GB";

        #region INFORMATIVE BUTTONS INITIALIZE

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

        #region ShowTotalTasksButton
        private InformativeButtonTemplate _showAllTasksButton = new InformativeButtonTemplate();
        public InformativeButtonTemplate ShowTotalTasksButton
        {
            get { return _showAllTasksButton; }
            set
            {
                //_showAllTasksButton.Title = "Total tasks: ";
                _showAllTasksButton.Counter = value.Counter;
                OnPropertyChanged(nameof(ShowTotalTasksButton));
            }
        }
        #endregion

        #region ExpiredTasksButton
        private InformativeButtonTemplate _showExpiredTasksButton = new InformativeButtonTemplate();
        public InformativeButtonTemplate ShowExpiredTasksButton
        {
            get { return _showExpiredTasksButton; }
            set
            {
                //_showExpiredTasksButton.Title = "Expired Tasks:";
                _showExpiredTasksButton.Counter = value.Counter;
                OnPropertyChanged(nameof(ShowExpiredTasksButton));
            }
        }
        #endregion

        #region CompletedTasksButton
        private InformativeButtonTemplate _showCompletedTasksButton = new InformativeButtonTemplate();
        public InformativeButtonTemplate ShowCompletedTasksButton
        {
            get { return _showCompletedTasksButton; }
            set
            {
                //_showCompletedTasksButton.Title = "Completed Tasks:";
                _showCompletedTasksButton.Counter = value.Counter;
                OnPropertyChanged(nameof(ShowCompletedTasksButton));
            }
        }
        #endregion

        #endregion



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

        #region SELECTED GROUPS IN GROUPLISTS

        #region SELECTED MYGROUP
        private TaskGroupTemplate _mySelectedGroup;
        public TaskGroupTemplate MySelectedGroup
        {
            get => _mySelectedGroup;
            set
            {
                foreach (var item in MyGroupList)
                {
                    item.DeleteButtonVisibility = "Collapsed";
                }
                foreach (var item in DelegatedGroupList)
                {
                    item.DeleteButtonVisibility = "Collapsed";
                }
                Set(ref _mySelectedGroup, value);
                if (MyGroupList.Contains(MySelectedGroup))
                {
                    MyGroupList[SelectedMyGroupIndex].DeleteButtonVisibility = "Visible";
                    SelectedDelegatedGroupIndex = -1;
                }
                //if (DelegatedGroupList.Contains(SelectedGroup))
                //{
                //    DelegatedGroupList[SelectedDelegatedGroupIndex].DeleteButtonVisibility = "Visible";
                //}
            }
        }
        #endregion

        #region SELECTED DELEGATED GROUP
        private TaskGroupTemplate _delegatedSelectedGroup;
        public TaskGroupTemplate DelegatedSelectedGroup
        {
            get => _delegatedSelectedGroup;
            set
            {
                foreach (var item in MyGroupList)
                {
                    item.DeleteButtonVisibility = "Collapsed";
                }
                foreach (var item in DelegatedGroupList)
                {
                    item.DeleteButtonVisibility = "Collapsed";
                }
                Set(ref _delegatedSelectedGroup, value);
                //if (MyGroupList.Contains(SelectedGroup))
                //{
                //    MyGroupList[SelectedMyGroupIndex].DeleteButtonVisibility = "Visible";
                //}
                if (DelegatedGroupList.Contains(DelegatedSelectedGroup))
                {
                    DelegatedGroupList[SelectedDelegatedGroupIndex].DeleteButtonVisibility = "Visible";
                    SelectedMyGroupIndex = -1;
                }
            }
        }
        #endregion

        #region COMMON SELECTED GROUP IN LISTBOX
        private TaskGroupTemplate _selectedGroup;
        public TaskGroupTemplate SelectedGroup
        {
            get => _selectedGroup;
            set
            {
                foreach (var item in MyGroupList)
                {
                    item.DeleteButtonVisibility = "Collapsed";
                }
                foreach (var item in DelegatedGroupList)
                {
                    item.DeleteButtonVisibility = "Collapsed";
                }
                Set(ref _selectedGroup, value);
                if (MyGroupList.Contains(SelectedGroup))
                {
                    MyGroupList[SelectedMyGroupIndex].DeleteButtonVisibility = "Visible";
                }
                if (DelegatedGroupList.Contains(SelectedGroup))
                {
                    DelegatedGroupList[SelectedGroupIndex].DeleteButtonVisibility = "Visible";
                }
            }
        }
        #endregion

        #endregion



        #region SELECTED GROUPS INDEXEX

        #region SELECTED MYGROUP INDEX
        private int _selectedMyGroupIndex = -1;
        public int SelectedMyGroupIndex { get => _selectedMyGroupIndex; set { Set(ref _selectedMyGroupIndex, value);  } }
        #endregion

        #region COMMON SELECTED INDEX
        private int _selectedGroupIndex = -1;
        public int SelectedGroupIndex { get => _selectedGroupIndex; set => Set(ref _selectedGroupIndex, value); }
        #endregion

        #region SELECTED DELEGATEDGROUP INDEX
        private int _selectedDelegatedGroupIndex = -1;
        public int SelectedDelegatedGroupIndex { get => _selectedDelegatedGroupIndex; set { Set(ref _selectedDelegatedGroupIndex, value); } }
        #endregion



        #endregion

        #region СПИСКИ ГРУПП

        #region общий список
        private ObservableCollection<TaskGroupTemplate> _groupList = new ObservableCollection<TaskGroupTemplate>();
        public ObservableCollection<TaskGroupTemplate> GroupList { get => _groupList; set => _groupList = value; }
        #endregion

        #region My GroupList
        private ObservableCollection<TaskGroupTemplate> _myGroupList = new ObservableCollection<TaskGroupTemplate>();
        //public ObservableCollection<TaskGroupTemplate> MyGroupList { get => _myGroupList; set => _myGroupList = value; }
        public ObservableCollection<TaskGroupTemplate> MyGroupList { get => _myGroupList; set => Set(ref _myGroupList, value); }

        #endregion

        #region Delegated GroupList
        private ObservableCollection<TaskGroupTemplate> _delegatedGroupList = new ObservableCollection<TaskGroupTemplate>();
        //public ObservableCollection<TaskGroupTemplate> DelegatedGroupList { get => _delegatedGroupList; set => _delegatedGroupList = value; }
        public ObservableCollection<TaskGroupTemplate> DelegatedGroupList { get => _delegatedGroupList; set => Set(ref _delegatedGroupList, value); }
        //private List<TaskGroupTemplate> test = new List<TaskGroupTemplate>();

        #endregion

        #endregion

        #region СПИСОК ЗАДАЧ

        #region FullTaskList
        private ObservableCollection<TaskTemplate> _fullTaskList = new ObservableCollection<TaskTemplate>();
        public ObservableCollection<TaskTemplate> FullTaskList
        {
            get => _fullTaskList;
            set { _fullTaskList = value; OnPropertyChanged(); }

        }
        #endregion

        private ObservableCollection<TaskTemplate> _taskList;// = new ObservableCollection<TaskTemplate>();
        public ObservableCollection<TaskTemplate> TaskList 
        { 
            get => _taskList;
            set { _taskList = value; OnPropertyChanged(); InformativeButtonsUpdate(); }

        }
        #endregion

        #region SELECTED TASK
        private TaskTemplate _selectedTask = new TaskTemplate();
        public TaskTemplate SelectedTask 
        { 
            get => _selectedTask; 
            set
            {
                //MessageBox.Show(value.GroupName);
                if (TaskList != null)
                {
                    foreach (var item in TaskList)
                    {
                        item.DeleteButtonVisibility = "Collapsed";
                        item.CompleteTaskMarkVisibility = "Collapsed";
                        item.EditButtonVisibility = "Collapsed";
                        item.CompletedOrExpiredTaskButtonVisibility = "Collapsed";
                    }
                }
                _selectedTask = value;
                OnPropertyChanged(nameof(SelectedTask));
                
                //Set(ref _selectedTask, value);
                if (SelectedTask != null && SelectedTaskIndex > -1)
                {
                    //MessageBox.Show(SelectedTask.GroupName);
                    SelectedTask.DeleteButtonVisibility = "Visible";
                    SelectedTask.CompleteTaskMarkVisibility = "Visible";
                    SelectedTask.EditButtonVisibility = "Visible";
                    //TaskList[SelectedTaskIndex] = SelectedTask;
                    OnPropertyChanged(nameof(SelectedTask));
                    //OnPropertyChanged(nameof(TaskList));
                }
                OnPropertyChanged(nameof(TaskList));
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
            TryToDeserializeData();
            //GenerateTaskListMethod();
            InformativeButtonTitles();
            InformativeButtonsUpdate();
        }

        private void InformativeButtonsUpdate()
        {
            TodayButton.Counter = FullTaskList == null? "0" : FullTaskList.Where(c => c.ExpirationDate.Date == DateTime.Today).ToList().Count.ToString();
            ShowTotalTasksButton.Counter = FullTaskList == null ? "0" : FullTaskList.Count.ToString();
            ShowExpiredTasksButton.Counter = (10).ToString();
            ShowCompletedTasksButton.Counter = (10).ToString();
            if (FullTaskList != null)
            {
                foreach (var task in FullTaskList)
                {
                    foreach (var myGroup in MyGroupList)
                    {
                        if (myGroup.GroupColor == task.GroupColor && myGroup.GroupName == task.GroupName && myGroup.ExecutionOf == task.ExecutionOf) myGroup.Counter++;
                        //if (myGroup.GroupId == task.GroupId) myGroup.Counter++;
                    }
                    foreach (var delegGroup in DelegatedGroupList)
                    {
                        if (delegGroup.GroupColor == task.GroupColor && delegGroup.GroupName == task.GroupName && delegGroup.ExecutionOf == task.ExecutionOf) delegGroup.Counter++;
                        //if (delegGroup.GroupId == task.GroupId) delegGroup.Counter++;
                    }
                }
            }

          
        }
        private void InformativeButtonTitles()
        {
            _todayButton.Title = Languages.Lang.Today + "   " + DateTime.Now.ToString("d MMMM, ddd");
            _showAllTasksButton.Title = Languages.Lang.TotalTasksString;
            _showExpiredTasksButton.Title = "Expired Tasks:";
            _showCompletedTasksButton.Title = "Completed Tasks:";
        }

        private void TryToDeserializeData()
        {
            if (File.Exists(TextData.directory + "\\" + Properties.Resources.GroupListFileName))
            {
                if (GroupList.Count < 1)
                {
                    DataSerializer Serialize = new DataSerializer();
                    GroupList = Serialize.JsonDeserialization(TextData.directory);
                }

                foreach (var group in GroupList) 
                { 
                    if (group.ExecutionOf == "Delegated") DelegatedGroupList.Add((group));
                    else MyGroupList.Add(group);
                }
                //MyGroupList = (ObservableCollection<TaskGroupTemplate>)GroupList.Where(c => c.ExecutionOf == "Me") as ObservableCollection<TaskGroupTemplate>;
            }
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
            FullTaskList = new ObservableCollection<TaskTemplate>
            {
                 new TaskTemplate(DateTime.Now, "SampleTask1", "Sample Header 1", "Me", DateTime.Now, "Urgent", true, new TaskGroupModel(GroupList[0])),
                new TaskTemplate(DateTime.Now.AddDays(9), "Sample Task 2", "Sample Header 2", "Me", DateTime.Now, "Urgent", true, GroupList[1]),
                new TaskTemplate(DateTime.Now.AddDays(11), "Sample Task 3", "Sample Header 3", "Me", DateTime.Now, "Urgent", true, GroupList[2]),
                new TaskTemplate(DateTime.Now.AddDays(12), "Sample Task 4", "Sample Header 4", "Me", DateTime.Now, "Urgent", true, GroupList[3]),


                new TaskTemplate(DateTime.Now.AddDays(13), "Sample Task 5", "Sample Header 5", "Me", DateTime.Now, "Urgent", true, GroupList[0])
            };
            //TaskList = new ObservableCollection<TaskTemplate>(FullTaskList);
        }
        #endregion



        #endregion

        #region COMMANDS

        #region SHOW DEFAULT TASKLIST COMMAND
        private RelayCommand _showDefaultTaskList;
        public RelayCommand ShowDefaultTaskListCommand
        {
            get
            {
                return _showDefaultTaskList ?? new RelayCommand(obj =>
                {
                    GenerateTaskListMethod();
                    SelectedGroupsHideDeleteButtons();
                    ShowDefaultTaskListMethod(obj);
                });
            }
        }
        private void ShowDefaultTaskListMethod(object parameter)
        {
            TaskList = new ObservableCollection<TaskTemplate>(FullTaskList);
            InformativeButtonsUpdate();
        }
        #endregion

        #region SHOW TODAY TASKS COMMAND
        private RelayCommand _showTodayTasksCommand;
        public RelayCommand ShowTodayTasksCommand
        {
            get
            {
                return _showTodayTasksCommand ?? new RelayCommand(obj => 
                {
                    ShowTodayTasksMethod(obj);
                });
            }
        }
        private void SelectedGroupsHideDeleteButtons()
        {
            if (MySelectedGroup != null)
            {
                MySelectedGroup.DeleteButtonVisibility = "Collapsed";
                //MessageBox.Show(MySelectedGroup.DeleteButtonVisibility.ToString());
            }
            else if (DelegatedSelectedGroup != null)
            {
                DelegatedSelectedGroup.DeleteButtonVisibility = "Collapsed";
            }
            SelectedTask = null;
            SelectedTaskIndex = -1;
        }
        public void ShowTodayTasksMethod(object parameter) 
        {
            TaskList = new ObservableCollection<TaskTemplate>(FullTaskList.Where(c => c.ExpirationDate.Date == DateTime.Now.Date));
            SelectedGroupsHideDeleteButtons();
            InformativeButtonsUpdate();
        }
        #endregion

        #region SHOW TOTALTASKS COMMAND
        private RelayCommand _showTotalTasksCommand;
        public RelayCommand ShowTotalTasksCommand
        {
            get
            {
                return _showTotalTasksCommand ?? new RelayCommand(obj =>
                {
                    ShowTotalTasksMethod(obj);
                });
            }
        }

        public void ShowTotalTasksMethod(object parameter)
        {
            TaskList = new ObservableCollection<TaskTemplate>(FullTaskList);
            SelectedGroupsHideDeleteButtons();
            InformativeButtonsUpdate();
        }
        #endregion

        #region SHOW TASKS FROM SELECTED GROUP

        private RelayCommand _showFilteredByGroupTasksCommand;
        public RelayCommand ShowFilteredByGroupTasksCommand
        {
            get
            {
                return _showFilteredByGroupTasksCommand ?? new RelayCommand(obj => {
                    ShowFilteredByGroupTasksMethod(obj);
                });
            }
        }
        private void ShowFilteredByGroupTasksMethod(object parameter)
        {
            //TaskList = new ObservableCollection<TaskTemplate>(FullTaskList.Where(c => c.GroupColor ==));
        }
        #endregion



        #endregion
    }
}
