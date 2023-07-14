using _9_07_2023_Planner.Infrastructure.Commands.Base;
using _9_07_2023_Planner.ViewModels;
using _9_07_2023_Planner.Views.Components.RequestWindowComponents;
using _9_07_2023_Planner.Views.Windows.RequestWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace _9_07_2023_Planner.Infrastructure.Commands
{
    internal class DeleteTaskGroup_ShowRequestWindowCommand : CommandBase
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            //MessageBox.Show()
            RequestWindow requestWindow = new RequestWindow();
            requestWindow.deleteGroupShow_UK.Visibility = System.Windows.Visibility.Visible;

            DeleteTaskGroupRequest_UserControl deleteGroup_UK = new DeleteTaskGroupRequest_UserControl(parameter);

            var listBox = parameter as ListBox;
            var dataContext = listBox.DataContext as MainWindowViewModel;
            //MessageBox.Show(dataContext.Title);
            dataContext.DeleteGroupRequestWindowUserControlVisibility = "Visible";
            SetWindowOwnerSetPositionAndShow.ShowModalWindow(requestWindow);

            

        }
    }
}
