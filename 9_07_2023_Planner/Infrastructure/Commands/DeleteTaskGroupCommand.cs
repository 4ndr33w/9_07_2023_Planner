﻿using _9_07_2023_Planner.Data;
using _9_07_2023_Planner.DataHandlers;
using _9_07_2023_Planner.Infrastructure.Commands.Base;
using _9_07_2023_Planner.Models.ViewPanelTemplate;
using _9_07_2023_Planner.ViewModels;
using _9_07_2023_Planner.Views.Components.LeftPanel;
using _9_07_2023_Planner.Views.Components.RequestWindowComponents;
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

                var listBox = DeleteTaskGroupRequest_UserControl.Parameter as ListBox;
                var mainVM = listBox.DataContext as MainWindowViewModel;
                var groupList = mainVM.GroupList;
                var selectedIndex = mainVM.SelectedGroupIndex;
                groupList.RemoveAt(selectedIndex);
                DeleteTaskGroupRequest_UserControl.Window.Hide();
                #endregion

                #region Сериализация
                DataSerializer Serialize = new DataSerializer();
                Serialize.JsonSerialization(groupList, TextData.directory);
                #endregion
            }
        }
    }
}
