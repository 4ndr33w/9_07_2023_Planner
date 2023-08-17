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
using _9_07_2023_Planner.Views.Components.MiddlePanel;
using System.Collections.ObjectModel;
using _9_07_2023_Planner.Models.ViewPanelTemplate;

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
            //SetContextOfGroupPanels();
            //SetSourceOfMyGroupPanel();
            //SetSourceOfDelegatedGroupPanel();
        }

        #region METHODS
        private void SetContextOfGroupPanels()
        {
            //(myGroupsPanel as TaskGroupPanel_UserControl).DataContext = new MainWindowViewModel();
        }
        private void SetSourceOfMyGroupPanel()
        {
            //var myGroups = myGroupsPanel as TaskGroupPanel_UserControl;
            //myGroups.TaskGroupListBox.ItemsSource =
            //   (DataContext as MainWindowViewModel).MyGroupList;
            //myGroups.taskGroupExpander.Header = "My Tasks";
        }
        private void SetSourceOfDelegatedGroupPanel()
        {
            //var delegatedGroups = delegatedGroupsPanel as TaskGroupPanel_UserControl;
            //delegatedGroups.TaskGroupListBox.ItemsSource =
            //  (DataContext as MainWindowViewModel).DelegatedGroupList;
            //delegatedGroups.taskGroupExpander.Header = "Delegated Tasks";
        }
        #endregion

        private void delegatedGroupsPanel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if ((myGroupsPanel as MyGroupsPanel_UserControl).TaskGroupListBox.SelectedIndex > -1)
            //{
            //    (myGroupsPanel as MyGroupsPanel_UserControl).TaskGroupListBox.SelectedIndex = -1;
            //}
                
        }
        private void myGroupsPanel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            //if ((delegatedGroupsPanel as DelegatedGroupPanel_UserControl).TaskGroupListBox.SelectedIndex > -1)
            //{
            //    (delegatedGroupsPanel as DelegatedGroupPanel_UserControl).TaskGroupListBox.SelectedIndex = -1;
            //}
            
        }

        private void taskTanel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (delegatedGroupsPanel as DelegatedGroupPanel_UserControl).TaskGroupListBox.SelectedIndex = -1;
            (myGroupsPanel as MyGroupsPanel_UserControl).TaskGroupListBox.SelectedIndex = -1;
        }

        private void todayButtonPanel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (delegatedGroupsPanel as DelegatedGroupPanel_UserControl).TaskGroupListBox.SelectedIndex = -1;
            (myGroupsPanel as MyGroupsPanel_UserControl).TaskGroupListBox.SelectedIndex = -1;
        }

        private void todayButtonPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            (delegatedGroupsPanel as DelegatedGroupPanel_UserControl).TaskGroupListBox.SelectedIndex = -1;
            (myGroupsPanel as MyGroupsPanel_UserControl).TaskGroupListBox.SelectedIndex = -1;
        }

        private void totalTasksButonPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            (delegatedGroupsPanel as DelegatedGroupPanel_UserControl).TaskGroupListBox.SelectedIndex = -1;
            (myGroupsPanel as MyGroupsPanel_UserControl).TaskGroupListBox.SelectedIndex = -1;
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            var dataContextVM = (DataContext as MainWindowViewModel);
            //var taskList = new ObservableCollection<TaskTemplate>(dataContextVM.FullTaskList.Where(c => c.ExpirationDate.Date == Calendar.SelectedDate));
            if (dataContextVM.FullTaskList.Where(c => c.ExpirationDate.Date == Calendar.SelectedDate).ToList().Count > -1)
            {
                dataContextVM.TaskList = new ObservableCollection<TaskTemplate>(dataContextVM.FullTaskList.Where(c => c.ExpirationDate.Date == Calendar.SelectedDate));
                //MessageBox.Show(dataContextVM.TaskList[0].Header);
            }
            (taskPanel as TaskPanel_UserControl).TaskListBox.Items.Refresh();
           
        }
    }
}
