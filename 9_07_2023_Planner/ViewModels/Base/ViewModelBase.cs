using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _9_07_2023_Planner.ViewModels.Base
{
    internal abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        public ViewModelBase() { }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); 
        }

        protected virtual bool Set<T> (ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value)) return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }


        public void Dispose()
        {
            this.Dispose(true);
        }
        private bool _disposed;

        protected virtual void Dispose(bool disposing) 
        {
            if (!disposing || _disposed) return;
            _disposed = true;
        }
    }
}
