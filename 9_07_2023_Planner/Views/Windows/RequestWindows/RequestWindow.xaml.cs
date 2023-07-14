using _9_07_2023_Planner.Views.Components.RequestWindowComponents;
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
using System.Windows.Shapes;

namespace _9_07_2023_Planner.Views.Windows.RequestWindows
{
    /// <summary>
    /// Логика взаимодействия для RequestWindow.xaml
    /// </summary>
    public partial class RequestWindow : Window
    {
        public object _parameter;
        public RequestWindow()
        {
            InitializeComponent();
            DeleteTaskGroupRequest_UserControl deleteTaskGroupRequest_UserControl = new DeleteTaskGroupRequest_UserControl(this);
            //MessageBox.Show(this.ToString());
        }
        public RequestWindow(object parameter)
        {
            InitializeComponent();
            _parameter = parameter;
            //DeleteTaskGroupRequest_UserControl deleteTaskGroupRequest_UserControl = new DeleteTaskGroupRequest_UserControl(this);
            //MessageBox.Show(this.ToString());
        }
    }
}
