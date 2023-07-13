using _9_07_2023_Planner.Infrastructure.Commands.Base;
using _9_07_2023_Planner.Models.ViewPanelTemplate;
using _9_07_2023_Planner.ViewModels;
using _9_07_2023_Planner.Views.Components.LeftPanel;
using _9_07_2023_Planner.Views.Components.RequestWindowComponents;
using System;
using System.Collections.Generic;
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
                //var selectedIndex = list.SelectedIndex;
                //(list.DataContext as MainWindowViewModel).GroupList.Remove(selectedItem).ToString();
                #endregion

                #region запрос на удаление - передается окно (юзерКонтрол) с полем object Parameter (в котором зашит ListBox)

                var userControl = parameter as DeleteTaskGroupRequest_UserControl;
                if (userControl != null) 
                {
                    var listBox = userControl.Parameter as ListBox;
                    var selectedIndex = listBox.SelectedIndex;
                    var dataContext = listBox.DataContext;
                    MessageBox.Show((dataContext as MainWindowViewModel).GroupList[selectedIndex].GroupName);
                }

                #endregion
            }
        }
    }
}
