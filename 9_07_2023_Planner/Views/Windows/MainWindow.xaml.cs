using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using _9_07_2023_Planner;
using _9_07_2023_Planner.ViewModels;
using _9_07_2023_Planner.Infrastructure.Commands;
using _9_07_2023_Planner.Views.Components.LeftPanel;

namespace _9_07_2023_Planner.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            OnStartup();
        }
        private void OnStartup()
        {
            DataContext = new MainWindowViewModel();
            SetContextOfGroupPanels();
            SetSourceOfMyGroupPanel();
            SetSourceOfDelegatedGroupPanel();
        }

        #region METHODS
        private void SetContextOfGroupPanels()
        {
            (myGroupsPanel as TaskGroupPanel_UserControl).DataContext = new MainWindowViewModel();
        }
        private void SetSourceOfMyGroupPanel()
        {
            (myGroupsPanel as TaskGroupPanel_UserControl).TaskGroupListBox.ItemsSource =
               (DataContext as MainWindowViewModel).MyGroupList;
        }
        private void SetSourceOfDelegatedGroupPanel()
        {
            (delegatedGroupsPanel as TaskGroupPanel_UserControl).TaskGroupListBox.ItemsSource =
              (DataContext as MainWindowViewModel).DelegatedGroupList;
        }
        #endregion
    }
}
