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

namespace _9_07_2023_Planner.Views.Windows.ChildWindows
{
    /// <summary>
    /// Логика взаимодействия для AddNewTaskGroupWindow.xaml
    /// </summary>
    public partial class AddNewTaskGroupWindow : Window
    {
        //public ListBox taskGroupListBox = new ListBox();
        //public AddNewTaskGroupWindow(ListBox listBox)
        //{
        //    InitializeComponent();
        //    //this.taskGroupListBox = listBox;
        //}
        public string callSource = "";
        public AddNewTaskGroupWindow(string source)
        {
            InitializeComponent();
            callSource = source;
        }

        public AddNewTaskGroupWindow()
        {
            InitializeComponent();
        }
    }
}
