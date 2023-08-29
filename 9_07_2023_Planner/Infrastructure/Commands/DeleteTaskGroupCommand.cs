using _9_07_2023_Planner.Data;
using _9_07_2023_Planner.DataHandlers;
using _9_07_2023_Planner.Infrastructure.Commands.Base;
using _9_07_2023_Planner.Models.ViewPanelTemplate;
using _9_07_2023_Planner.ViewModels;
using _9_07_2023_Planner.Views.Components.LeftPanel;
using _9_07_2023_Planner.Views.Components.RequestWindowComponents;
using _9_07_2023_Planner.Views.Windows;
using _9_07_2023_Planner.Views.Windows.ChildWindows;
using _9_07_2023_Planner.Views.Windows.RequestWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace _9_07_2023_Planner.Infrastructure.Commands
{
    internal class DeleteTaskGroupCommand : CommandBase
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            var requestWindow = (parameter as DeleteTaskGroupRequest_UserControl).DataContext as RequestWindow;
            var listBox = requestWindow._parameter as ListBox;
            var selectedGroup = listBox.SelectedItem as TaskGroupTemplate;

            var mainVM = requestWindow.DataContext as MainWindowViewModel;
            //MessageBox.Show(selectedGroup.GroupName + "\n" + mainVM.GroupList.Count.ToString());
            if (parameter != null)
            {
                #region логика для удаления группы без запроса - передавая ЛистБокс как параметр
                //var list = (ListBox)parameter;
                ////MessageBox.Show(list.Items.Count.ToString());

                //var selectedItem = list.SelectedItem as TaskGroupTemplate;
                //var selectedIndex = list.SelectedGroupIndex;
                //(list.DataContext as MainWindowViewModel).GroupList.Remove(selectedItem).ToString();
                #endregion

                #region запрос на удаление

                var groupList = mainVM.GroupList;
                ////var selectedIndex = mainVM.SelectedGroupIndex;
                var findGroup = groupList.First(c => c.GroupEquals(selectedGroup));
                ////////////////////
                //MessageBox.Show(findGroup.GroupName);
                /////////////////////////
                //MessageBox.Show(listBox.Items.Count.ToString());
                if (findGroup != default)
                {
                    groupList.Remove(findGroup);
                }
                requestWindow.Hide();
                if (mainVM.MyGroupList.Contains(findGroup))
                {
                    //MessageBox.Show(listBox.Items.Count.ToString());
                    mainVM.MyGroupList.Remove(findGroup);
                    //listBox.ItemsSource = null;
                    listBox.ItemsSource = new List<TaskGroupTemplate>(mainVM.MyGroupList);
                    //listBox.Items.Refresh();
                    //listBox.SelectedIndex = -1;
                }
                if (mainVM.DelegatedGroupList.Contains(findGroup))
                {
                    mainVM.DelegatedGroupList.Remove(findGroup);
                    //listBox.ItemsSource = null;
                    listBox.ItemsSource = new List<TaskGroupTemplate>(mainVM.MyGroupList);
                    //listBox.Items.Refresh();
                    //listBox.SelectedIndex = -1;
                }
                
                ////DeleteTaskGroupRequest_UserControl.Window.Hide();
                ///
                
                #endregion

                #region Сериализация
                DataSerializer Serialize = new DataSerializer();
                Serialize.JsonSerialization(groupList, TextData.directory);
                //groupList.Clear();
                //mainVM.MyGroupList.Clear();
                //mainVM.DelegatedGroupList.Clear();
                mainVM.TryToDeserializeData();

                //var mainWindow = new MainWindow();

                //(mainWindow.myGroupsPanel as MyGroupsPanel_UserControl).TaskGroupListBox.Items.Clear();
                //(mainWindow.myGroupsPanel as MyGroupsPanel_UserControl).TaskGroupListBox.ItemsSource = mainVM.MyGroupList;

                //(mainWindow.delegatedGroupsPanel as DelegatedGroupPanel_UserControl).TaskGroupListBox.Items.Clear();
                //(mainWindow.delegatedGroupsPanel as DelegatedGroupPanel_UserControl).TaskGroupListBox.ItemsSource = mainVM.MyGroupList;



                #endregion
            }
        }
    }
}
