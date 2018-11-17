using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace COMPE361_Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>    public sealed partial class HomePage : Page
    public sealed partial class HomePage : Page
    {
        bool isManager = true;
        string Username = "John";
        string Position = "Manager";
        public HomePage()
        {
            this.InitializeComponent();
            Menu.SelectedIndex = 0;
            if (isManager == true)
            {
                Menu.Items.Remove(View_Schedule);
                Menu.Items.Remove(Employee_Clock);
                Menu.Items.Remove(Request_PTO);
            }
            else
            {
                Menu.Items.Remove(Manage_Employees);
                Menu.Items.Remove(Employer_Clock);
                Menu.Items.Remove(PTO_Requests);
                Menu.Items.Remove(Edit_Schedule);
            }
        }
        private void Profile(object sender, RoutedEventArgs e)
        {
            welcome.Text = $"Welcome Back {this.Username}";
            position.Text = $"{this.Position}";
        }
        private void HomeButton(object sender, RoutedEventArgs e)
        {
            Menu.SelectedIndex = 0;
        }
    }
}