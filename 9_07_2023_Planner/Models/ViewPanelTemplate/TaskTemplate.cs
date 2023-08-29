using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _9_07_2023_Planner.Models.ViewPanelTemplate
{
    public class TaskTemplate : TaskModel
    {
        private string _taskStatusTitle;
        private string _deleteButtonVisibility = "Collapsed";
        private string _editButtonVisibility = "Collapsed";
        private string _foreground = Colors.Black.ToString();
        private string _expiredForeground = Colors.White.ToString();
        private string _completedOrExpiredTaskButtonVisibility = "Collapsed";
        private string _markToCompleteTaskVisibility = "Collapsed";
        private string _expired;
        private string _time;
        private string _dayAndMonth;

        public string TaskStatusTitle { get => _taskStatusTitle; set => _taskStatusTitle = value; }
        public string DeleteButtonVisibility { get => _deleteButtonVisibility; set => _deleteButtonVisibility = value; }
        public string EditButtonVisibility { get => _editButtonVisibility; set => _editButtonVisibility = value; }
        public string Foreground { get => _foreground; set => _foreground = value; }
        public string ExpiredForeground { get => _expiredForeground; set => _expiredForeground = value; }
        public string CompletedOrExpiredTaskButtonVisibility { get => _completedOrExpiredTaskButtonVisibility; set => _completedOrExpiredTaskButtonVisibility = value; }
        public string CompleteTaskMarkVisibility { get { return _markToCompleteTaskVisibility; } set => _markToCompleteTaskVisibility = value; }
        public string Expired { get { return _expired; } set => _expired = value; }
        public string Time { get { return ExpirationDate.ToString("HH' ':' ' mm"); } /*set { _time = value; OnPropertyChanged(nameof(Time)); }*/ }
        public string DayAndMonth { get { return ExpirationDate.ToString("d MMMM"/*, CultureInfo.CreateSpecificCulture(Properties.Settings.Default.languageCode)*/); } /*set { _dayAndMonth = value; OnPropertyChanged(nameof(DayAndMonth)); }*/ }

        public TaskTemplate() :
           base()
        { 
        }
            public TaskTemplate(DateTime date, string note, string header, string executor, DateTime creationDate, string status, bool urgency, TaskGroupModel group) :
           base(date, note, header, executor, creationDate, status, urgency, group)
        {
            _date = date;
            _note = note;
            _header = header;
            _executor = executor;
            _creationDate = creationDate;
            _status = status;
            _urgency = urgency;
            _group = group;
            _color = group.GroupColor;

            _deleteButtonVisibility = "Collapsed";
            _editButtonVisibility = "Collapsed";
            _foreground = Colors.Black.ToString();
            _expiredForeground = Colors.White.ToString();
            _completedOrExpiredTaskButtonVisibility = "Collapsed";
            _markToCompleteTaskVisibility = "Collapsed";
            _expired = "!!! Expired !!!";

            _group_name = group.GroupName;
            _execution_of = group.ExecutionOf;
            _counter = group.Counter;
            _userIdentifier = group.UserIdentifier;
        }

        public override string ToString()
        {
            return $"{GroupName} {GroupColor}\n{UserIdentifier}\nexpiration: {ExpirationDate.Date}\nToday: {DateTime.Now.Date}";
        }
    }
}
