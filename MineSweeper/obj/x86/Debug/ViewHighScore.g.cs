﻿#pragma checksum "B:\Software Development Year 4 GMIT\AppProject\MineSweeper\MineSweeper\ViewHighScore.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7433FA82A4602702EE84949703DEF104"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MineSweeper
{
    partial class ViewHighScore : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        internal class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Windows.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
        };

        private class ViewHighScore_obj3_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IViewHighScore_Bindings
        {
            private global::MineSweeper.ViewModels.ScoreGenericViewModel dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.TextBlock obj4;
            private global::Windows.UI.Xaml.Controls.TextBlock obj5;

            private ViewHighScore_obj3_BindingsTracking bindingsTracking;

            public ViewHighScore_obj3_Bindings()
            {
                this.bindingsTracking = new ViewHighScore_obj3_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 4:
                        this.obj4 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 5:
                        this.obj5 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    default:
                        break;
                }
            }

            public void DataContextChangedHandler(global::Windows.UI.Xaml.FrameworkElement sender, global::Windows.UI.Xaml.DataContextChangedEventArgs args)
            {
                 global::MineSweeper.ViewModels.ScoreGenericViewModel data = args.NewValue as global::MineSweeper.ViewModels.ScoreGenericViewModel;
                 if (args.NewValue != null && data == null)
                 {
                    throw new global::System.ArgumentException("Incorrect type passed into template. Based on the x:DataType global::MineSweeper.ViewModels.ScoreGenericViewModel was expected.");
                 }
                 this.SetDataRoot(data);
                 this.Update();
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                switch(args.Phase)
                {
                    case 0:
                        nextPhase = -1;
                        this.SetDataRoot(args.Item as global::MineSweeper.ViewModels.ScoreGenericViewModel);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            ((global::Windows.UI.Xaml.Controls.StackPanel)args.ItemContainer.ContentTemplateRoot).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_((global::MineSweeper.ViewModels.ScoreGenericViewModel) args.Item, 1 << (int)args.Phase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
                this.bindingsTracking.ReleaseAllListeners();
            }

            // IViewHighScore_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            // ViewHighScore_obj3_Bindings

            public void SetDataRoot(global::MineSweeper.ViewModels.ScoreGenericViewModel newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.dataRoot = newDataRoot;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::MineSweeper.ViewModels.ScoreGenericViewModel obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_username(obj.username, phase);
                        this.Update_userscore(obj.userscore, phase);
                    }
                }
            }
            private void Update_username(global::System.String obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj4, obj, null);
                }
            }
            private void Update_userscore(global::System.Int32 obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj5, obj.ToString(), null);
                }
            }

            private class ViewHighScore_obj3_BindingsTracking
            {
                global::System.WeakReference<ViewHighScore_obj3_Bindings> WeakRefToBindingObj; 

                public ViewHighScore_obj3_BindingsTracking(ViewHighScore_obj3_Bindings obj)
                {
                    WeakRefToBindingObj = new global::System.WeakReference<ViewHighScore_obj3_Bindings>(obj);
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_(null);
                }

                public void PropertyChanged_(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    ViewHighScore_obj3_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        string propName = e.PropertyName;
                        global::MineSweeper.ViewModels.ScoreGenericViewModel obj = sender as global::MineSweeper.ViewModels.ScoreGenericViewModel;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                    bindings.Update_username(obj.username, DATA_CHANGED);
                                    bindings.Update_userscore(obj.userscore, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "username":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_username(obj.username, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "userscore":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_userscore(obj.userscore, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                public void UpdateChildListeners_(global::MineSweeper.ViewModels.ScoreGenericViewModel obj)
                {
                    ViewHighScore_obj3_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        if (bindings.dataRoot != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)bindings.dataRoot).PropertyChanged -= PropertyChanged_;
                        }
                        if (obj != null)
                        {
                            bindings.dataRoot = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_;
                        }
                    }
                }
            }
        }

        private class ViewHighScore_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IViewHighScore_Bindings
        {
            private global::MineSweeper.ViewHighScore dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.ListBox obj2;

            private ViewHighScore_obj1_BindingsTracking bindingsTracking;

            public ViewHighScore_obj1_Bindings()
            {
                this.bindingsTracking = new ViewHighScore_obj1_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2:
                        this.obj2 = (global::Windows.UI.Xaml.Controls.ListBox)target;
                        break;
                    default:
                        break;
                }
            }

            // IViewHighScore_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            // ViewHighScore_obj1_Bindings

            public void SetDataRoot(global::MineSweeper.ViewHighScore newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.dataRoot = newDataRoot;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::MineSweeper.ViewHighScore obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ScoreOrganizerVM(obj.ScoreOrganizerVM, phase);
                    }
                }
            }
            private void Update_ScoreOrganizerVM(global::MineSweeper.ViewModels.ScoreOrganizerViewModel obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_ScoreOrganizerVM(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ScoreOrganizerVM_ScoresCollection(obj.ScoresCollection, phase);
                    }
                }
            }
            private void Update_ScoreOrganizerVM_ScoresCollection(global::System.Collections.ObjectModel.ObservableCollection<global::MineSweeper.ViewModels.ScoreGenericViewModel> obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj2, obj, null);
                }
            }

            private class ViewHighScore_obj1_BindingsTracking
            {
                global::System.WeakReference<ViewHighScore_obj1_Bindings> WeakRefToBindingObj; 

                public ViewHighScore_obj1_BindingsTracking(ViewHighScore_obj1_Bindings obj)
                {
                    WeakRefToBindingObj = new global::System.WeakReference<ViewHighScore_obj1_Bindings>(obj);
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_ScoreOrganizerVM(null);
                }

                public void PropertyChanged_ScoreOrganizerVM(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    ViewHighScore_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        string propName = e.PropertyName;
                        global::MineSweeper.ViewModels.ScoreOrganizerViewModel obj = sender as global::MineSweeper.ViewModels.ScoreOrganizerViewModel;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                    bindings.Update_ScoreOrganizerVM_ScoresCollection(obj.ScoresCollection, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "ScoresCollection":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ScoreOrganizerVM_ScoresCollection(obj.ScoresCollection, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                private global::MineSweeper.ViewModels.ScoreOrganizerViewModel cache_ScoreOrganizerVM = null;
                public void UpdateChildListeners_ScoreOrganizerVM(global::MineSweeper.ViewModels.ScoreOrganizerViewModel obj)
                {
                    if (obj != cache_ScoreOrganizerVM)
                    {
                        if (cache_ScoreOrganizerVM != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_ScoreOrganizerVM).PropertyChanged -= PropertyChanged_ScoreOrganizerVM;
                            cache_ScoreOrganizerVM = null;
                        }
                        if (obj != null)
                        {
                            cache_ScoreOrganizerVM = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_ScoreOrganizerVM;
                        }
                    }
                }
                public void PropertyChanged_ScoreOrganizerVM_ScoresCollection(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    ViewHighScore_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        string propName = e.PropertyName;
                        global::System.Collections.ObjectModel.ObservableCollection<global::MineSweeper.ViewModels.ScoreGenericViewModel> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::MineSweeper.ViewModels.ScoreGenericViewModel>;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                        }
                        else
                        {
                            switch (propName)
                            {
                                default:
                                    break;
                            }
                        }
                    }
                }
                public void CollectionChanged_ScoreOrganizerVM_ScoresCollection(object sender, global::System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
                {
                    ViewHighScore_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        global::System.Collections.ObjectModel.ObservableCollection<global::MineSweeper.ViewModels.ScoreGenericViewModel> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::MineSweeper.ViewModels.ScoreGenericViewModel>;
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2:
                {
                    this.HighScoreList = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                }
                break;
            case 6:
                {
                    this.Home = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 72 "..\..\..\ViewHighScore.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Home).Click += this.homeClick;
                    #line default
                }
                break;
            case 7:
                {
                    this.Settings = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 73 "..\..\..\ViewHighScore.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Settings).Click += this.settingsClick;
                    #line default
                }
                break;
            case 8:
                {
                    this.Rules = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 74 "..\..\..\ViewHighScore.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Rules).Click += this.rulesClick;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    ViewHighScore_obj1_Bindings bindings = new ViewHighScore_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            case 3:
                {
                    global::Windows.UI.Xaml.Controls.StackPanel element3 = (global::Windows.UI.Xaml.Controls.StackPanel)target;
                    ViewHighScore_obj3_Bindings bindings = new ViewHighScore_obj3_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot((global::MineSweeper.ViewModels.ScoreGenericViewModel) element3.DataContext);
                    element3.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element3, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

