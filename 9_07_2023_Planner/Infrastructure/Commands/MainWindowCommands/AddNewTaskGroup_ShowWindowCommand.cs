using _9_07_2023_Planner.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using _9_07_2023_Planner.Views.Windows.ChildWindows;
using System.Windows.Controls;

namespace _9_07_2023_Planner.Infrastructure.Commands.MainWindowCommands
{
    internal class AddNewTaskGroup_ShowWindowCommand : CommandBase
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            AddNewTaskGroupWindow newTaskGroupWindow = new AddNewTaskGroupWindow(parameter as ListBox);
            SetWindowOwnerSetPositionAndShow.ShowModalWindow(newTaskGroupWindow);
        }
    }
}
