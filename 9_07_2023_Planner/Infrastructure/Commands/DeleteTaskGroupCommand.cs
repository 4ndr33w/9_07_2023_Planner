using _9_07_2023_Planner.Infrastructure.Commands.Base;
using _9_07_2023_Planner.Models.ViewPanelTemplate;
using _9_07_2023_Planner.ViewModels;
using _9_07_2023_Planner.Views.Components.LeftPanel;
using _9_07_2023_Planner.Views.Components.RequestWindowComponents;
using _9_07_2023_Planner.Views.Windows.RequestWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            //MessageBox.Show(DeleteTaskGroupRequest_UserControl.Window.ToString());
            //MessageBox.Show(((DeleteTaskGroupRequest_UserControl.Parameter as ListBox).DataContext as MainWindowViewModel).SelectedIndex.ToString());
            if (parameter != null)
            {
                #region логика для удаления группы без запроса - передавая ЛистБокс как параметр
                //var list = (ListBox)parameter;
                ////MessageBox.Show(list.Items.Count.ToString());

                //var selectedItem = list.SelectedItem as TaskGroupTemplate;
                //var selectedIndex = list.SelectedIndex;
                //(list.DataContext as MainWindowViewModel).GroupList.Remove(selectedItem).ToString();
                #endregion

                #region запрос на удаление - передается окно (юзерКонтрол) с полем object Parameter (в котором зашит ListBox)

                var listBox = DeleteTaskGroupRequest_UserControl.Parameter as ListBox;
                var mainVM = listBox.DataContext as MainWindowViewModel;
                var groupList = mainVM.GroupList;
                var selectedIndex = mainVM.SelectedIndex;
                groupList.RemoveAt(selectedIndex);
                DeleteTaskGroupRequest_UserControl.Window.Hide();
                //var groupList = parameter as ObservableCollection<TaskGroupTemplate>;
                //if (groupList != null) 
                //{
                //    MainWindowViewModel mainVM = new MainWindowViewModel(/*groupList*/);
                //    //var group = mainVM.I;
                //    //var listBox = userControl.Parameter as ListBox;
                //    //var selectedIndex = listBox.SelectedIndex;
                //    //var dataContext = listBox.DataContext;
                //    MessageBox.Show(mainVM.SelectedIndex.ToString());
                //}

                #endregion
            }
        }
    }
}
