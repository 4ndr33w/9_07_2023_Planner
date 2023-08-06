using _9_07_2023_Planner.ViewModels;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для DelegatedGroupPanel_UserControl.xaml
    /// </summary>
    public partial class DelegatedGroupPanel_UserControl : UserControl
    {
        public DelegatedGroupPanel_UserControl()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();
        }
        private void TaskGroupListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TaskGroupListBox.Items.Refresh();
        }
    }
}
