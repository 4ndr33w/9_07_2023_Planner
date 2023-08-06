using _9_07_2023_Planner.Infrastructure.Commands.Base;
using _9_07_2023_Planner.Models.ViewPanelTemplate;
using _9_07_2023_Planner.ViewModels;
using _9_07_2023_Planner.Views.Components.MiddlePanel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _9_07_2023_Planner.Infrastructure.Commands
{
    internal class ShowDefaultTaskListCommand : CommandBase
    {
        public override bool CanExecute(object parameter) => true;


        public override void Execute(object parameter)
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();
            viewModel.TaskList = new ObservableCollection<TaskTemplate>(viewModel.FullTaskList);
            //var taskList = new ObservableCollection<TaskTemplate>(viewModel.FullTaskList);
            TaskPanel_UserControl taskPanel_UserControl = new TaskPanel_UserControl();
            taskPanel_UserControl.TaskListBox.ItemsSource = viewModel.TaskList;
            MessageBox.Show(taskPanel_UserControl.TaskListBox.Items.Count.ToString());
            //throw new NotImplementedException();
            //TaskList = new ObservableCollection<TaskTemplate>(FullTaskList);
        }
    }
}
