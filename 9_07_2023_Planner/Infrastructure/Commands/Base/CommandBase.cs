using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _9_07_2023_Planner.Infrastructure.Commands.Base
{
    internal abstract class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public abstract bool CanExecute(object parameter);
        //{
        //    throw new NotImplementedException();
        //}

        public abstract void Execute(object parameter);
        //{
        //    throw new NotImplementedException();
        //}
    }
}
