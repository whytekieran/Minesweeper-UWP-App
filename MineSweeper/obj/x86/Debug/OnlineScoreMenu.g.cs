﻿#pragma checksum "B:\Software Development Year 4 GMIT\AppProject\MineSweeper\MineSweeper\OnlineScoreMenu.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1D2458AA898618DCF62B3A6B0ED0CD4B"
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
    partial class OnlineScoreMenu : 
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
                    this.highscoreOnlineOptionsList = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                    #line 25 "..\..\..\OnlineScoreMenu.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListBox)this.highscoreOnlineOptionsList).Tapped += this.listItemTap;
                    #line default
                }
                break;
            case 2:
                {
                    this.Home = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 62 "..\..\..\OnlineScoreMenu.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Home).Click += this.homeClick;
                    #line default
                }
                break;
            case 3:
                {
                    this.Settings = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 63 "..\..\..\OnlineScoreMenu.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Settings).Click += this.settingsClick;
                    #line default
                }
                break;
            case 4:
                {
                    this.Rules = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 64 "..\..\..\OnlineScoreMenu.xaml"
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

