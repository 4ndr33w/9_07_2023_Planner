using _9_07_2023_Planner.Models.ViewPanelTemplate;
using _9_07_2023_Planner.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_07_2023_Planner.ViewModels.Groups
{
    internal class GroupPanelViewModel : ViewModelBase
    {
        private ObservableCollection<TaskGroupTemplate> groupList = new ObservableCollection<TaskGroupTemplate>();
        public ObservableCollection<TaskGroupTemplate> GroupList { get => groupList; set => groupList = value; }


        #region SELECTED GROUP В LISTBOX
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Selected ListBox Item"></param>
        /// <param name="Group Template"></param>
        private TaskGroupTemplate _selectedGroup;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SelectedListBoxItem"></param>
        /// <param name="GroupTemplate"></param>
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
    }
}
