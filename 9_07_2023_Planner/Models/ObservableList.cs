using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _9_07_2023_Planner.Models
{
    internal class ObservableList<T> : List<T>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value)) return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        //protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        //{
        //    if (this.CollectionChanged != null)
        //    {
        //        using (BlockReentrancy())
        //        {
        //            this.CollectionChanged(this, e);
        //        }
        //    }
        //}
        //protected IDisposable BlockReentrancy()
        //{
        //    _monitor.Enter();
        //    return _monitor;
        //}
    }
}
