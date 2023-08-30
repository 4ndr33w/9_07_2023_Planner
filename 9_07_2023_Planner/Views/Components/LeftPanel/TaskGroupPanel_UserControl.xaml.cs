using System.Windows.Controls;

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
        }

        private void TaskGroupListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TaskGroupListBox.Items.Refresh();
        }
    }
}
