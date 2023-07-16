using _9_07_2023_Planner.Infrastructure.Commands.Base;
using _9_07_2023_Planner.Models;
using _9_07_2023_Planner.Models.ViewPanelTemplate;
using _9_07_2023_Planner.ViewModels;
using _9_07_2023_Planner.Views.Windows.ChildWindows;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _9_07_2023_Planner.Infrastructure.Commands
{
    internal class AddNewTaskIntoTaskListCommand : CommandBase
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            
            var mainVM = (parameter as AddNewTaskWindow).NewNoteControlTab.DataContext as MainWindowViewModel;
            var selectedGroup = (parameter as AddNewTaskWindow).TaskGroupComboBox.SelectedItem as TaskGroupTemplate;
            var expirationDate = Convert.ToDateTime((parameter as AddNewTaskWindow).DatePicker.Text);
            var TaskList = mainVM.TaskList;

            var NewTask = new TaskTemplate(expirationDate, "  ", "Header", "Me", DateTime.UtcNow, "Urgently", false, selectedGroup);
            TaskList.Add(NewTask);
            TaskList = new System.Collections.ObjectModel.ObservableCollection<TaskTemplate>(TaskList);

            (parameter as AddNewTaskWindow).Hide();
            //MessageBox.Show(selectedGroup.GroupName);
            // public TaskTemplate(DateTime date, string note, string header, string executor,
            // DateTime creationDate, string status, bool urgency, TaskGroupModel group) :
            //base(date, note, header, executor, creationDate, status, urgency, group)
        }
    }
}
