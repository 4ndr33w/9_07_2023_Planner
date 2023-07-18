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
    internal class ShowTodayTasksCommand : CommandBase
    {
        public override bool CanExecute(object parameter) => true; 

        public override void Execute(object parameter)
        {
            var informativeButton = parameter as InformativeButton_UserControl;
            var dataContext = informativeButton.DataContext as InformativeButtonTemplate;

            var mainVM = new MainWindowViewModel();

            if (dataContext.Title == Languages.Lang.Today + "   " + DateTime.Now.ToString("d MMMM, ddd"))
            {
                mainVM.TaskList = new ObservableCollection<TaskTemplate>(mainVM.TaskList.Where(c => c.ExpirationDate.Date == DateTime.Today).ToList());
                //var test = mainVM.TaskList;
                ViewRefreshMethod(new ObservableCollection<TaskTemplate>(mainVM.TaskList.Where(c => c.ExpirationDate.Date == DateTime.Today).ToList()));
                //MessageBox.Show(test.Count.ToString());


            }
            if (dataContext.Title == Languages.Lang.TotalTasksString)
            {
                //mainVM.TaskList = new System.Collections.ObjectModel.ObservableCollection<TaskTemplate>(mainVM.FullTaskList);
                //MessageBox.Show(mainVM.TaskList.Count.ToString());
            }
            
        }

        private void ViewRefreshMethod(ObservableCollection<TaskTemplate> taskList)
        {
            Views.Components.MiddlePanel.TaskPanel_UserControl taskPanel = new Views.Components.MiddlePanel.TaskPanel_UserControl();
            //taskPanel.TaskListBox.Items.
            taskPanel.TaskListBox.ItemsSource = null;
            taskPanel.TaskListBox.Items.Clear();
            taskPanel.TaskListBox.ItemsSource = taskList;
            MessageBox.Show((taskPanel.TaskListBox.ItemsSource as ObservableCollection<TaskTemplate>).Count.ToString());
            //taskPanel.TaskListBox.DataContext = taskList;
            taskPanel.TaskListBox.Items.Refresh();
        }


    }
}
