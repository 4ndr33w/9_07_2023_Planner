using _9_07_2023_Planner.Infrastructure.Commands.Base;
using _9_07_2023_Planner.Models.ViewPanelTemplate;
using _9_07_2023_Planner.ViewModels;
using _9_07_2023_Planner.Views.Components.LeftPanel;
using _9_07_2023_Planner.Views.Windows.ChildWindows;
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
            var groupWindow = (Window)parameter;

            var _groupColor = (groupWindow as AddNewTaskGroupWindow).colorTextBox.Text;
            var _groupName = (groupWindow as AddNewTaskGroupWindow).groupNameTextBox.Text;

            (((groupWindow as AddNewTaskGroupWindow).
                taskGroupListBox as ListBox).
                DataContext as MainWindowViewModel).
                GroupList.Add(new TaskGroupTemplate(_groupColor, _groupName));
            ((groupWindow as AddNewTaskGroupWindow).
                taskGroupListBox as ListBox).SelectedIndex = -1;

            groupWindow.Hide();
        }
    }
}
