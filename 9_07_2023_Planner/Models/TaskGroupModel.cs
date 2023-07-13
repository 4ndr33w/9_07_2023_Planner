using _9_07_2023_Planner.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _9_07_2023_Planner.Models
{
    internal class TaskGroupModel //: ViewModelBase
    {
        protected string _color = Colors.LawnGreen.ToString();
        protected string _group_name = "Default Group";
        protected string _execution_of = "Me";
        protected int _counter = 0;
        protected string _userIdentifier = "abc123";

        public string GroupColor { get => _color; set { _color = value;/* OnPropertyChanged("GroupColor"); */} }
        public string ExecutionOf { get => _execution_of; set { _execution_of = value;/* OnPropertyChanged("ExecutionOf"); */} }
        public int Counter { get => _counter; set { _counter = value;/* OnPropertyChanged("Counter"); */} }
        public string GroupName
        {
            get { return _group_name; }
            set
            {
                if (value.Length <= 13) { _group_name = value; }
                else
                {
                    _group_name = value.Substring(0, 12) + '.';
                    //OnPropertyChanged("GroupName");
                }
            }
        }
        public string UserIdentifier { get => _userIdentifier; }

        public TaskGroupModel()
        {
            _color = Colors.LawnGreen.ToString();
            _group_name = "Default Group";
            _execution_of = "Me";
            _counter = 0;
        }

        public TaskGroupModel(TaskGroupModel group)
        {
            _color = group.GroupColor;
            _group_name = group.GroupName;
            _execution_of = group.ExecutionOf;
            _counter = group.Counter;
        }

        public TaskGroupModel(string color, string groupName, string executor, int counter)
        {
            _color = color;
            _group_name = groupName;
            _execution_of = executor;
            _counter = counter;
        }
        public TaskGroupModel(string color, string groupName)
        {
            _color = color;
            _group_name = groupName;
            _execution_of = "Me";
            _counter = 0;
        }

        public bool GroupEquals(TaskGroupModel compareData)
        {
            bool result = false;

            if (GroupColor == compareData.GroupColor && GroupName == compareData.GroupName && ExecutionOf == compareData.ExecutionOf) result = true;

            return result;
        }

        public class CompareGroups : IComparer<TaskGroupModel>
        {
            public int Compare(TaskGroupModel x, TaskGroupModel y)
            {
                if (string.Compare(x.GroupName, y.GroupName) == 0 &&
                    string.Compare(x.GroupColor, y.GroupColor) == 0 &&
                    string.Compare(x.ExecutionOf, y.ExecutionOf) == 0)
                {
                    return 0;
                }
                else return 1;
            }
        }
    }
}
