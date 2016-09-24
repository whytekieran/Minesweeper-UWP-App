using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MineSweeper.ViewModels
{
    //This class extends the INotification interface, this interface can tell when the property of an object has changed
    //and can then describe how an object can participate in XAML bindings.
    //It provides generalized methods that can be applied to any object that inherits this class and are performed when
    //any property of the inheriting object(class) changes.
    //used if the model class has a constructor
    public class VMHelper : INotifyPropertyChanged
    {
        //Represents the method that will handle the PropertyChanged event raised when a property is changed on a component.
        public event PropertyChangedEventHandler PropertyChanged;

        //Generic method
        //[CallerMemberName] - Allows you to obtain the method or property name of the caller to the method.
        //We can trigger the [CallerMemberName] by using a lambda expression (in ScoreViewModel)
        //This way we can tell which property has been triggered due to a change. 
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] String property = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))//Check if parameters are equal (if they have changed)
            {
                return false;
            }
            else//if they are different it means they have changed so....
            {
                field = value;                          //Set the new value
                RaisePropertyChanged(property);         //aise a property changed event
                return true;                            //return true (used in ScoreOrganizerView model)
            }
        }

        //Action -Encapsulates a method that has a single parameter and does not return a value.
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

        //Fired when a property changes
        protected void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }

    //where T : class, new() 
    //This is a constraint on the generic parameter T. It must be a class (reference type) 
    //and must have a public parameter-less default constructor.
    //That means T can't be an int, float, double, DateTime or any other struct (value type).
    //used if the model class has no contructor
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
