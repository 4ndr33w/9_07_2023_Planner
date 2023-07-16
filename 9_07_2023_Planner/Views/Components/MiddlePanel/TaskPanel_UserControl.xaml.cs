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

namespace _9_07_2023_Planner.Views.Components.MiddlePanel
{
    /// <summary>
    /// Логика взаимодействия для TaskPanel_UserControl.xaml
    /// </summary>
    public partial class TaskPanel_UserControl : UserControl
    {
        public TaskPanel_UserControl()
        {
            InitializeComponent();
        }

        #region  LISTBOX SELECTION CHANGED
        /// <summary>
        /// не получается уведомлять View об изменении выбранного элемента ЛистБокса... 
        /// не смотря на использование INotifyPropertyChanged
        /// Пришлось использовать этот "костыль"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TaskGroupListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TaskGroupListBox.Items.Refresh();
        }
        #endregion
    }
}
