using _9_07_2023_Planner.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_07_2023_Planner.Infrastructure.Commands
{
    internal class AddNewTask_ShowWindowComand : CommandBase
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            Views.Windows.ChildWindows.AddNewTaskWindow addNewTaskWindow = new Views.Windows.ChildWindows.AddNewTaskWindow();
            SetWindowOwnerSetPositionAndShow.ShowModalWindow(addNewTaskWindow);
        }
    }
}
