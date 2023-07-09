using _9_07_2023_Planner.ViewModels;
using _9_07_2023_Planner.Views.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace _9_07_2023_Planner
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        MainWindowViewModel _vm = new MainWindowViewModel();

        public App() 
        {
            new MainWindow() { DataContext = _vm }.ShowDialog();
        }
    }
}
