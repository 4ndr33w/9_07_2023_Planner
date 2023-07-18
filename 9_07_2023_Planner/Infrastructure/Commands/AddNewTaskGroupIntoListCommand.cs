using _9_07_2023_Planner.Data;
using _9_07_2023_Planner.DataHandlers;
using _9_07_2023_Planner.Infrastructure.Commands.Base;
using _9_07_2023_Planner.Models.ViewPanelTemplate;
using _9_07_2023_Planner.ViewModels;
using _9_07_2023_Planner.Views.Components.LeftPanel;
using _9_07_2023_Planner.Views.Windows;
using _9_07_2023_Planner.Views.Windows.ChildWindows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace _9_07_2023_Planner.Infrastructure.Commands
{
    internal class AddNewTaskGroupIntoListCommand : CommandBase
    {
        //static string directory =
        //   Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
        //   Properties.Resources.SaveDirectory + "\\";
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            var userControl = parameter as TaskGroupPanel_UserControl;
            var dataContext = userControl.DataContext as MainWindowViewModel;

            DataSerializer Serialize = new DataSerializer();
            var addGroupWindow = (Window)parameter;

            var _groupColor = (addGroupWindow as AddNewTaskGroupWindow).colorTextBox.Text;
            var _groupName = (addGroupWindow as AddNewTaskGroupWindow).groupNameTextBox.Text;
            string _executor = "";

            var groupListBox = (addGroupWindow as AddNewTaskGroupWindow).taskGroupListBox as ListBox;
            var mainVM = groupListBox.DataContext as MainWindowViewModel;
            var groupList = mainVM.GroupList;



            //if (userControl.TaskGroupListBox.ItemsSource == dataContext.MyGroupList)
            //{
            //    _executor = "Me";
            //    dataContext.MyGroupList.Add(new TaskGroupTemplate(_groupColor, _groupName, _executor));
            //}
            //else
            //{
            //    _executor = "Delegated";
            //    dataContext.DelegatedGroupList.Add(new TaskGroupTemplate(_groupColor, _groupName, _executor));
            //}

            groupList.Add(new TaskGroupTemplate(_groupColor, _groupName, _executor));
            groupList = new System.Collections.ObjectModel.ObservableCollection<TaskGroupTemplate>(groupList);


            groupListBox.SelectedIndex = -1;

            addGroupWindow.Hide();

            Serialize.JsonSerialization(groupList, TextData.directory);
        }
    }
}
