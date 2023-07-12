using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _9_07_2023_Planner.Models.ViewPanelTemplate
{
    internal class TaskGroupTemplate : TaskGroupModel
    {
        private string deleteButtonVisibility = "Collapsed";

        public string DeleteButtonVisibility
        {
            get { return deleteButtonVisibility; }
            set { deleteButtonVisibility = value;/* OnPropertyChanged("DeleteButtonVisibility");*/ }
        }

        private bool _shouldEditSelectedGroup = false;
        public bool ShouldEditSelectedGroup
        {
            get => _shouldEditSelectedGroup;
            set { _shouldEditSelectedGroup = value;/* OnPropertyChanged("ShouldEditSelectedGroup");*/ }
        }

        public TaskGroupTemplate()
        {
            GroupColor = Colors.LawnGreen.ToString();
            GroupName = "Default Group";
            ExecutionOf = "Me";
            Counter = 0;
            DeleteButtonVisibility = "Collapsed";
        }

        public TaskGroupTemplate(string color, string groupName, string executor, int counter) : base(color, groupName, executor, counter)
        {
            GroupColor = color;
            GroupName = groupName;
            ExecutionOf = executor;
            Counter = counter;
            DeleteButtonVisibility = "Collapsed";
        }

        public TaskGroupTemplate(TaskGroupModel group)
        {
            group.GroupColor = GroupColor;
            group.GroupName = GroupName;
            group.ExecutionOf = ExecutionOf;
            group.Counter = Counter;
            DeleteButtonVisibility = "Collapsed";
        }
    }
}
