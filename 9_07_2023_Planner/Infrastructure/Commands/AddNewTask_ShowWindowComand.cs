using _9_07_2023_Planner.Infrastructure.Commands.Base;
using _9_07_2023_Planner.Views.Components.LeftPanel;
using System;
using System.Collections.Generic;
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
            //Views.Windows.ChildWindows.AddNewTaskWindow addNewTaskWindow = new Views.Windows.ChildWindows.AddNewTaskWindow();
            //SetWindowOwnerSetPositionAndShow.ShowModalWindow(addNewTaskWindow);

            MessageBox.Show((parameter as TaskGroupPanel_UserControl).DataContext.ToString());
            //(parameter as TaskGroupPanel_UserControl).DataContext
        }
    }
}
