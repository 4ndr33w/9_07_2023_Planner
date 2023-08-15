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

namespace _9_07_2023_Planner.Views.Components.LeftPanel.InformativeButtons
{
    /// <summary>
    /// Логика взаимодействия для TotalTasksInformativeButton_UserControl.xaml
    /// </summary>
    public partial class TotalTasksInformativeButton_UserControl : UserControl
    {
        public TotalTasksInformativeButton_UserControl()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();
        }
    }
}
