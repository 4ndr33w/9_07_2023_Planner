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

namespace _9_07_2023_Planner.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //if (PropertyChanged != null) 
            //{ 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            //}
        }
        //private double _windowHeight;
        //public double WindowHeight
        //{
        //    get { return _windowHeight; }
        //    set
        //    {
        //        //_windowHeight = value; 
        //        _windowHeight = this.Height;
        //        OnPropertyChanged(nameof(WindowHeight));
        //    }
        //}

        //private double _panelHeight;
        //public double PanelHeight
        //{
        //    get { return _panelHeight; }
        //    set
        //    {
        //        _panelHeight = WindowHeight - 50; OnPropertyChanged(nameof(PanelHeight));
        //    }
        //}
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
