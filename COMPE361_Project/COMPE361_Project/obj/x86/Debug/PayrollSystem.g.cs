﻿#pragma checksum "C:\Users\Drowz\Documents\GitHub\361Project\COMPE361_Project\COMPE361_Project\PayrollSystem.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BFCF244F29F0CC25D3EA3D152DBC3885"
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
            case 2: // PayrollSystem.xaml line 11
                {
                    this.Display = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 3: // PayrollSystem.xaml line 35
                {
                    this.PTO_Request = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 4: // PayrollSystem.xaml line 27
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element4 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element4).Click += this.EmployeeClock_Click;
                }
                break;
            case 5: // PayrollSystem.xaml line 28
                {
                    global::Windows.UI.Xaml.Controls.Button element5 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element5).Click += this.EmployeeClock_Click;
                }
                break;
            case 6: // PayrollSystem.xaml line 23
                {
                    global::Windows.UI.Xaml.Controls.Button element6 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element6).Click += this.LogoutButton_Click;
                }
                break;
            case 7: // PayrollSystem.xaml line 24
                {
                    global::Windows.UI.Xaml.Controls.Button element7 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element7).Click += this.LogoutButton_Click;
                }
                break;
            case 8: // PayrollSystem.xaml line 19
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element8 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element8).Click += this.HomeButton_Click;
                }
                break;
            case 9: // PayrollSystem.xaml line 20
                {
                    global::Windows.UI.Xaml.Controls.Button element9 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element9).Click += this.HomeButton_Click;
                }
                break;
            case 10: // PayrollSystem.xaml line 15
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element10 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element10).Click += this.MenuButton_Click;
                }
                break;
            case 11: // PayrollSystem.xaml line 16
                {
                    global::Windows.UI.Xaml.Controls.Button element11 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element11).Click += this.MenuButton_Click;
                }
                break;
            case 12: // PayrollSystem.xaml line 42
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

