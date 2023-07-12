using _9_07_2023_Planner.Infrastructure.Commands.Base;
using System.Windows;

namespace _9_07_2023_Planner.Infrastructure.Commands
{
    internal class CloseApplicationCommand : CommandBase
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter) => Application.Current.Shutdown();
    }
}
