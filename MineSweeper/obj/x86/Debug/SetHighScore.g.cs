﻿#pragma checksum "B:\Software Development Year 4 GMIT\AppProject\MineSweeper\MineSweeper\SetHighScore.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BD8554C2ACC1A050CE97DCFFF6EE965C"
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
    partial class SetHighScore : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.TitlePanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 2:
                {
                    this.InputPanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 3:
                {
                    this.UsernameLabel = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4:
                {
                    this.txtUser = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5:
                {
                    this.ScoreLabel = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6:
                {
                    this.txtScore = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7:
                {
                    this.btnSubmitScore = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 51 "..\..\..\SetHighScore.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnSubmitScore).PointerEntered += this.btnHover;
                    #line 54 "..\..\..\SetHighScore.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnSubmitScore).PointerExited += this.btnHoverStopped;
                    #line 55 "..\..\..\SetHighScore.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnSubmitScore).Click += this.submitScoreClick;
                    #line default
                }
                break;
            case 8:
                {
                    this.Title = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9:
                {
                    this.Home = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 62 "..\..\..\SetHighScore.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Home).Click += this.homeClick;
                    #line default
                }
                break;
            case 10:
                {
                    this.Settings = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 63 "..\..\..\SetHighScore.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Settings).Click += this.settingsClick;
                    #line default
                }
                break;
            case 11:
                {
                    this.Rules = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 64 "..\..\..\SetHighScore.xaml"
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
            return returnValue;
        }
    }
}

