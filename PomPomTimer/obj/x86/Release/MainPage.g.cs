﻿#pragma checksum "C:\Users\kisai\Documents\PomPomTimer\PomPomTimer\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "16285BCC9A55B293C493DDB8C3E7A700"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PomPomTimer
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.16.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // MainPage.xaml line 24
                {
                    this.AppRoot = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 2: // MainPage.xaml line 44
                {
                    this.rootPivot = (global::Windows.UI.Xaml.Controls.Pivot)(target);
                }
                break;
            case 3: // MainPage.xaml line 45
                {
                    this.PomoItemsPage = (global::Windows.UI.Xaml.Controls.PivotItem)(target);
                }
                break;
            case 4: // MainPage.xaml line 48
                {
                    this.SettingsPage = (global::Windows.UI.Xaml.Controls.PivotItem)(target);
                }
                break;
            case 5: // MainPage.xaml line 52
                {
                    this.notificationToggle = (global::Windows.UI.Xaml.Controls.ToggleSwitch)(target);
                    ((global::Windows.UI.Xaml.Controls.ToggleSwitch)this.notificationToggle).Toggled += this.ToggleSwitch_Toggled;
                }
                break;
            case 6: // MainPage.xaml line 95
                {
                    this.ThemeBox = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.ThemeBox).SelectionChanged += this.ComboBox_SelectionChanged;
                }
                break;
            case 7: // MainPage.xaml line 54
                {
                    this.TaskTime = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.TaskTime).SelectionChanged += this.TaskTime_SelectionChanged;
                }
                break;
            case 8: // MainPage.xaml line 64
                {
                    this.BreakTime = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.BreakTime).SelectionChanged += this.BreakTime_SelectionChanged;
                }
                break;
            case 9: // MainPage.xaml line 46
                {
                    this.PomodoroItems = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 10: // MainPage.xaml line 32
                {
                    this.AddButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.AddButton).Click += this.Button_Click_1;
                }
                break;
            case 11: // MainPage.xaml line 37
                {
                    global::Windows.UI.Xaml.Controls.Button element11 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element11).Click += this.Button_Click;
                }
                break;
            case 12: // MainPage.xaml line 34
                {
                    this.AddSymbol = (global::Windows.UI.Xaml.Controls.SymbolIcon)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.16.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

