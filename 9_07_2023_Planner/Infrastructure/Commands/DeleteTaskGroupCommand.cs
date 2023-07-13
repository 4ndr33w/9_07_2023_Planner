using _9_07_2023_Planner.Infrastructure.Commands.Base;
using _9_07_2023_Planner.Models.ViewPanelTemplate;
using _9_07_2023_Planner.ViewModels;
using _9_07_2023_Planner.Views.Components.LeftPanel;
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
                var list = (ListBox)parameter;
                var selectedItem = list.SelectedItem as TaskGroupTemplate;
                var selectedIndex = list.SelectedIndex;
                (list.DataContext as MainWindowViewModel).GroupList.Remove(selectedItem).ToString();
            }
        }
    }
}
