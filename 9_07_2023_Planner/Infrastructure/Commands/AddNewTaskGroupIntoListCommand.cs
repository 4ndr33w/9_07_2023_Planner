using _9_07_2023_Planner.Infrastructure.Commands.Base;
using _9_07_2023_Planner.Models.ViewPanelTemplate;
using _9_07_2023_Planner.ViewModels;
using _9_07_2023_Planner.Views.Components.LeftPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace _9_07_2023_Planner.Infrastructure.Commands
{
    internal class AddNewTaskGroupIntoListCommand : CommandBase
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            MainWindowViewModel mainWV = new MainWindowViewModel();
            TaskGroupPanel_UserControl taskGroupPanel_UserControl = new TaskGroupPanel_UserControl();
            //MessageBox.Show(mainWV.GroupList.Count.ToString());

            var groupWindow = (Window)parameter;
            var _color = (groupWindow.FindName("colorTextBox") as TextBox).Text;
            var _groupName = (groupWindow.FindName("groupNameTextBox") as TextBox).Text;

            //var group = new TaskGroupTemplate(_color, _groupName);
            mainWV.GroupList.Add(new TaskGroupTemplate(_color, _groupName));
            (taskGroupPanel_UserControl.FindName("TaskGroupListBox") as ListBox).ItemsSource = mainWV.GroupList;
            (taskGroupPanel_UserControl.FindName("TaskGroupListBox") as ListBox).Items.Refresh();
            groupWindow.Hide();
            //MessageBox.Show($"{mainWV.GroupList[mainWV.GroupList.Count - 1].GroupName}\n{(taskGroupPanel_UserControl.FindName("TaskGroupListBox") as ListBox).Items.Count}");

        }
    }
}
