﻿#pragma checksum "B:\Software Development Year 4 GMIT\AppProject\MineSweeper\MineSweeper\Game.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "64DC73B1A3A3F3FCDFCF228A86662F2A"
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
    partial class Game : 
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
                    this.gameGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 2:
                {
                    this.mySolidColorBrush = (global::Windows.UI.Xaml.Media.SolidColorBrush)(target);
                }
                break;
            case 3:
                {
                    this.txtTimer = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4:
                {
                    this.txtScore = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5:
                {
                    this.cbSixGrid = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                    #line 23 "..\..\..\Game.xaml"
                    ((global::Windows.UI.Xaml.Controls.CheckBox)this.cbSixGrid).Checked += this.startMineGame;
                    #line default
                }
                break;
            case 6:
                {
                    this.cbEightGrid = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                    #line 29 "..\..\..\Game.xaml"
                    ((global::Windows.UI.Xaml.Controls.CheckBox)this.cbEightGrid).Checked += this.startMineGame;
                    #line default
                }
                break;
            case 7:
                {
                    this.cbTenGrid = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                    #line 35 "..\..\..\Game.xaml"
                    ((global::Windows.UI.Xaml.Controls.CheckBox)this.cbTenGrid).Checked += this.startMineGame;
                    #line default
                }
                break;
            case 8:
                {
                    this.Home = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 58 "..\..\..\Game.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Home).Click += this.homeClick;
                    #line default
                }
                break;
            case 9:
                {
                    this.Settings = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 59 "..\..\..\Game.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Settings).Click += this.settingsClick;
                    #line default
                }
                break;
            case 10:
                {
                    this.Rules = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 60 "..\..\..\Game.xaml"
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

