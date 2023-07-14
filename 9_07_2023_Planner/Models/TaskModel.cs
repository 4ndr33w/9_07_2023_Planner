using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Xml.Linq;

namespace _9_07_2023_Planner.Models
{
    internal class TaskModel : TaskGroupModel
    {
        protected DateTime _date;
        protected string _note;
        protected string _header;
        protected string _executor;
        protected DateTime _creationDate;
        protected string _status;
        protected bool _urgency;
        protected TaskGroupModel _group;

        public DateTime ExpirationDate { get => _date; set => _date = value; }
        public string Note { get => _note; set => _note = value; }
        public string Header { get => _header; set => _header = value; }
        public string Executor { get => _executor; set => _executor = value; }
        public DateTime CreationDate { get => _creationDate; set => _creationDate = value; }
        public string Status { get => _status; set => _status = value; }
        public bool Urgency { get => _urgency; set => _urgency = value; }
        public TaskGroupModel Group { get => _group; set => _group = value; }

        public TaskModel()
        {
            _date = DateTime.Now;
            _note = String.Empty;
            _header = "Default Header"; ;
            _executor = "Me";
            _creationDate = DateTime.Now;
            _status = "";
            _urgency = false;
            // _group = _group;
        }
        public TaskModel(TaskModel task)
        {
            _date = task.ExpirationDate;
            _note = task.Note;
            _header = task.Header;
            _executor = task.Executor;
            _creationDate = task.CreationDate;
            _status = task.Status;
            _urgency = task.Urgency;
            _group = task.Group;
        }

        public TaskModel(DateTime date, string note, string header, string executor, DateTime creation_date, string status, bool urgency, TaskGroupModel grp)
        {
            _date = date;
            _note = note;
            _header = header;
            _executor = executor;
            _creationDate = creation_date;
            _status = status;
            _urgency = urgency;
            _group = grp;
            _color = grp.GroupColor;
        }

        public TaskModel(TaskGroupModel grp)
        {
            this._color = grp.GroupColor;
            _creationDate = DateTime.Now;
        }

        public class Sort_By_Group : IComparer<TaskModel>
        {
            public int Compare(TaskModel x, TaskModel y)
            {
                return string.Compare(x.Group.GroupName, y.Group.GroupName);
            }
        }
        public class Sort_By_Date : IComparer<TaskModel>
        {
            public int Compare(TaskModel x, TaskModel y)
            {
                return DateTime.Compare(x.ExpirationDate, y.ExpirationDate);
            }
        }
        public class Sort_By_CreationDate : IComparer<TaskModel>
        {
            public int Compare(TaskModel x, TaskModel y)
            {
                return DateTime.Compare(x.CreationDate, y.CreationDate);
            }
        }
        public class Sort_By_Executor : IComparer<TaskModel>
        {
            public int Compare(TaskModel x, TaskModel y)
            {
                return string.Compare(x.Group.ExecutionOf, y.Group.ExecutionOf);
            }
        }
    }
   
}
