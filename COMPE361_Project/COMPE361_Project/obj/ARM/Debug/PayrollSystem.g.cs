﻿#pragma checksum "C:\Users\Albert\Source\Repos\361Project\COMPE361_Project\COMPE361_Project\PayrollSystem.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "537BA062F0B536120D69C0B36B3F962D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace COMPE361_Project
{
    partial class PayrollSystem : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // PayrollSystem.xaml line 12
                {
                    this.Display = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 3: // PayrollSystem.xaml line 39
                {
                    this.Manage_Employees = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 4: // PayrollSystem.xaml line 40
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element4 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element4).Click += this.Manage_Employee;
                }
                break;
            case 5: // PayrollSystem.xaml line 41
                {
                    global::Windows.UI.Xaml.Controls.Button element5 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element5).Click += this.Manage_Employee;
                }
                break;
            case 6: // PayrollSystem.xaml line 36
                {
                    this.PTO_Button = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.PTO_Button).Click += this.PTO_Click;
                }
                break;
            case 7: // PayrollSystem.xaml line 37
                {
                    this.PTO_Title = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.PTO_Title).Click += this.PTO_Click;
                }
                break;
            case 8: // PayrollSystem.xaml line 32
                {
                    this.Calendar_Button = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Calendar_Button).Click += this.Schedule_Click;
                }
                break;
            case 9: // PayrollSystem.xaml line 33
                {
                    this.Calendar_Title = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Calendar_Title).Click += this.Schedule_Click;
                }
                break;
            case 10: // PayrollSystem.xaml line 28
                {
                    this.Clock_Button = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Clock_Button).Click += this.Clock_Click;
                }
                break;
            case 11: // PayrollSystem.xaml line 29
                {
                    this.Clock_Title = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Clock_Title).Click += this.Clock_Click;
                }
                break;
            case 12: // PayrollSystem.xaml line 24
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element12 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element12).Click += this.LogoutButton_Click;
                }
                break;
            case 13: // PayrollSystem.xaml line 25
                {
                    global::Windows.UI.Xaml.Controls.Button element13 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element13).Click += this.LogoutButton_Click;
                }
                break;
            case 14: // PayrollSystem.xaml line 20
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element14 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element14).Click += this.HomeButton_Click;
                }
                break;
            case 15: // PayrollSystem.xaml line 21
                {
                    global::Windows.UI.Xaml.Controls.Button element15 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element15).Click += this.HomeButton_Click;
                }
                break;
            case 16: // PayrollSystem.xaml line 16
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element16 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element16).Click += this.MenuButton_Click;
                }
                break;
            case 17: // PayrollSystem.xaml line 17
                {
                    global::Windows.UI.Xaml.Controls.Button element17 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element17).Click += this.MenuButton_Click;
                }
                break;
            case 18: // PayrollSystem.xaml line 46
                {
                    this.Content = (global::Windows.UI.Xaml.Controls.Frame)(target);
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
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

