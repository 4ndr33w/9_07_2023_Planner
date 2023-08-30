using _9_07_2023_Planner.Infrastructure.Commands.Base;
using _9_07_2023_Planner.Views.Windows.ChildWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_07_2023_Planner.Infrastructure.Commands
{
    internal class AddNewTaskGroup_ShowWindowCommand : CommandBase
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            //var parameterType = new MainWindow().myGroupsPanel;
            //MessageBox.Show(parameterType.Name);
            ////////////////
            //parameter as MainWindow.myGroupsPanel;
            ///////////////////

            string callSourceWindowName = "";
            //if (parameter is MyGroupsPanel_UserControl)
            //{
            //    callSourceWindowName = (parameter as MyGroupsPanel_UserControl).Name;
            //}
            //if (parameter is DelegatedGroupPanel_UserControl)
            //{
            //    callSourceWindowName = (parameter as DelegatedGroupPanel_UserControl).Name;
            //}
            AddNewTaskGroupWindow newTaskGroupWindow = new AddNewTaskGroupWindow(parameter);
            //AddNewTaskGroupWindow newTaskGroupWindow = new AddNewTaskGroupWindow(callSourceWindowName);
            SetWindowOwnerSetPositionAndShow.ShowModalWindow(newTaskGroupWindow);
        }
    }
}
