﻿#pragma checksum "C:\Users\kisai\Documents\PomPomTimer\PomPomTimer\PomTimeBlock.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DC248393FA35654ABD74C1E23E97E3F6"
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
    partial class PomTimeBlock : 
        global::Windows.UI.Xaml.Controls.UserControl, 
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
            case 1: // PomTimeBlock.xaml line 19
                {
                    this.root = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 2: // PomTimeBlock.xaml line 22
                {
                    this.MarkAsButton = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.MarkAsButton).Click += this.MenuFlyoutItem_Click_1;
                }
                break;
            case 3: // PomTimeBlock.xaml line 23
                {
                    global::Windows.UI.Xaml.Controls.MenuFlyoutItem element3 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)element3).Click += this.MenuFlyoutItem_Click_3;
                }
                break;
            case 4: // PomTimeBlock.xaml line 24
                {
                    global::Windows.UI.Xaml.Controls.MenuFlyoutItem element4 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)element4).Click += this.MenuFlyoutItem_Click_2;
                }
                break;
            case 5: // PomTimeBlock.xaml line 26
                {
                    global::Windows.UI.Xaml.Controls.MenuFlyoutItem element5 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)element5).Click += this.MenuFlyoutItem_Click;
                }
                break;
            case 6: // PomTimeBlock.xaml line 61
                {
                    this.TimerValueBar = (global::Windows.UI.Xaml.Controls.ProgressBar)(target);
                }
                break;
            case 7: // PomTimeBlock.xaml line 48
                {
                    this.DiscriptionBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.DiscriptionBlock).PointerEntered += this.DiscriptionBlock_PointerEntered;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.DiscriptionBlock).PointerExited += this.DiscriptionBlock_PointerExited;
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.DiscriptionBlock).DoubleTapped += this.DiscriptionBlock_DoubleTapped;
                }
                break;
            case 8: // PomTimeBlock.xaml line 50
                {
                    this.DiscriptionField = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.DiscriptionField).LostFocus += this.DiscriptionField_LostFocus;
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.DiscriptionField).KeyDown += this.DiscriptionField_KeyDown;
                }
                break;
            case 9: // PomTimeBlock.xaml line 53
                {
                    this.PomButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.PomButton).Click += this.Button_Click;
                }
                break;
            case 10: // PomTimeBlock.xaml line 55
                {
                    this.PlayPauseTimerSymbol = (global::Windows.UI.Xaml.Controls.FontIcon)(target);
                }
                break;
            case 11: // PomTimeBlock.xaml line 43
                {
                    this.PomOne = (global::Windows.UI.Xaml.Controls.FontIcon)(target);
                }
                break;
            case 12: // PomTimeBlock.xaml line 44
                {
                    this.PomTwo = (global::Windows.UI.Xaml.Controls.FontIcon)(target);
                }
                break;
            case 13: // PomTimeBlock.xaml line 45
                {
                    this.PomThree = (global::Windows.UI.Xaml.Controls.FontIcon)(target);
                }
                break;
            case 14: // PomTimeBlock.xaml line 46
                {
                    this.PomFour = (global::Windows.UI.Xaml.Controls.FontIcon)(target);
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

