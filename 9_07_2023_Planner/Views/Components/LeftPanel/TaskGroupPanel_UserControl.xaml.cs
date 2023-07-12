using _9_07_2023_Planner.Models;
using _9_07_2023_Planner.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _9_07_2023_Planner.Views.Components.LeftPanel
{
    /// <summary>
    /// Логика взаимодействия для TaskGroupPanel_UserControl.xaml
    /// </summary>
    public partial class TaskGroupPanel_UserControl : UserControl
    {
        public TaskGroupPanel_UserControl()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void TaskGroupListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //(DataContext).TaskList = /*ObservableCollection<TaskPanelModel>*/
            //   ((DataContext).FullTaskList.Where(c => c.GroupColor == (TaskGroupListBox.SelectedItem as TaskGroupModel).GroupColor)) as ObservableCollection<TaskPanelModel>;
            TaskGroupListBox.Items.Refresh();
        }
    }
}
