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

namespace _9_07_2023_Planner.Views.Components.RequestWindowComponents
{
    /// <summary>
    /// Логика взаимодействия для DeleteTaskGroupRequest_UserControl.xaml
    /// </summary>
    public partial class DeleteTaskGroupRequest_UserControl : UserControl//, INotifyPropertyChanged
    {
        //private object _parameter;
        public static object Parameter;//{ get => _parameter; set => Set(ref _parameter, value); }
        public static Window Window { get; set; }
        public DeleteTaskGroupRequest_UserControl()
        {
            InitializeComponent();
            //MessageBox.Show(this.ToString());
        }
        public DeleteTaskGroupRequest_UserControl(object parameter)
        {
            InitializeComponent();
            //MessageBox.Show(this.ToString());
            Parameter = parameter;
        }
        public DeleteTaskGroupRequest_UserControl(Window window)
        {
            InitializeComponent();
            //MessageBox.Show(window.ToString());
            Window = window;
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    //if (PropertyChanged != null) 
        //    //{ 
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //    //}
        //}

        //protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        //{
        //    if (Equals(field, value)) return false;

        //    field = value;
        //    OnPropertyChanged(propertyName);
        //    return true;
        //}
    }
}
