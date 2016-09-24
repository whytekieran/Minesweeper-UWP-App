using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MineSweeper.ViewModels
{
    public class VMHelper : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] String property = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }
            else
            {
                field = value;
                RaisePropertyChanged(property);
                return true;
            }
        }

        protected bool SetProperty<T>(T currentValue, T newValue, Action DoSet, [CallerMemberName] String property = null)
        {
            if (EqualityComparer<T>.Default.Equals(currentValue, newValue))
            {

                return false;
            }
            else
            {
                DoSet.Invoke();
                RaisePropertyChanged(property);
                return true;
            }
        }

        protected void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }

    public class VMHelper<T> : VMHelper where T : class, new()
    {
        protected T This;

        public static implicit operator T(VMHelper<T> thing) { return thing.This; }

        public VMHelper(T thing = null)
        {
            This = (thing == null) ? new T() : thing;
        }
    }
}
