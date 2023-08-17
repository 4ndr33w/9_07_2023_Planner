using _9_07_2023_Planner.Infrastructure.Commands.Base;
using _9_07_2023_Planner.Models.ViewPanelTemplate;
using _9_07_2023_Planner.ViewModels;
using _9_07_2023_Planner.Views.Components.LeftPanel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _9_07_2023_Planner.Infrastructure.Commands
{
    internal class AddNewTask_ShowWindowComand : CommandBase
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {

            //MessageBox.Show((parameter as TaskGroupPanel_UserControl).DataContext.ToString());
            MainWindowViewModel mainVM = new MainWindowViewModel();
            mainVM.TaskList = new System.Collections.ObjectModel.ObservableCollection<Models.ViewPanelTemplate.TaskTemplate>(mainVM.FullTaskList);
            //MessageBox.Show(mainVM.TaskList.Count.ToString());
            mainVM.TodayButton.Counter = mainVM.TaskList.Where(c => c.ExpirationDate.Date == DateTime.Today).Count().ToString();

            ViewRefreshMethod(mainVM.TaskList);
        }

        private void ViewRefreshMethod(ObservableCollection<TaskTemplate> taskList)
        {
            Views.Components.MiddlePanel.TaskPanel_UserControl taskPanel = new Views.Components.MiddlePanel.TaskPanel_UserControl();
            //taskPanel.TaskListBox.Items.
            //taskPanel.TaskListBox.ItemsSource = null;
            //taskPanel.TaskListBox.Items.Clear();
            taskPanel.TaskListBox.ItemsSource = taskList;
            //MessageBox.Show((taskPanel.TaskListBox.ItemsSource as ObservableCollection<TaskTemplate>).Count.ToString());
            //taskPanel.TaskListBox.DataContext = taskList;
            taskPanel.TaskListBox.Items.Refresh();
        }
        //private void ViewRefreshMethod(ObservableCollection<TaskTemplate> taskList, string callSourceWindowName)
        //{
        //    Views.Components.MiddlePanel.TaskPanel_UserControl taskPanel = new Views.Components.MiddlePanel.TaskPanel_UserControl();
        //    //taskPanel.TaskListBox.Items.
        //    //taskPanel.TaskListBox.ItemsSource = null;
        //    //taskPanel.TaskListBox.Items.Clear();
        //    taskPanel.TaskListBox.ItemsSource = taskList;
        //    //MessageBox.Show((taskPanel.TaskListBox.ItemsSource as ObservableCollection<TaskTemplate>).Count.ToString());
        //    //taskPanel.TaskListBox.DataContext = taskList;
        //    taskPanel.TaskListBox.Items.Refresh();
        //}
    }
}
