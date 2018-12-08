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
    /// </summary>
    public sealed partial class PayrollSystem : Page
    {
        bool admin = false;
        bool manager = false;
        public PayrollSystem()
        {
            this.InitializeComponent();
            if (admin == true) Manage_Employees.Visibility = Visibility.Visible;
            else Manage_Employees.Visibility = Visibility.Collapsed;
            if (manager == true || admin == true)
            {
                Clock_Title.Content = "Clock Logs";
                Calendar_Title.Content = "Edit Schedule";
                PTO_Title.Content = "Manage PTO";
            }
            else
            {
                Clock_Title.Content = "Clock In/Out";
                Calendar_Title.Content = "View Schedule";
                PTO_Title.Content = "PTO Request";
            }
            Content.SourcePageType = typeof(ProfilePage);
        }
        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            Display.IsPaneOpen = true;
        }
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Content.SourcePageType = typeof(ProfilePage);
        }
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage));
        }
        private void Clock_Click(object sender, RoutedEventArgs e)
        {
            if (manager == true || admin == true) Content.Navigate(typeof(ClockLogs));
            else Content.Navigate(typeof(EmployeeClock));
        }
        private void Schedule_Click(object sender, RoutedEventArgs e)
        {
            if (manager == true || admin == true) Content.Navigate(typeof(EditSchedule));
            else Content.Navigate(typeof(ViewSchedule));
        }
        private void PTO_Click(object sender, RoutedEventArgs e)
        {
            if (manager == true || admin == true) Content.Navigate(typeof(ManagePTO));
            else Content.Navigate(typeof(PTORequest));
        }
        private void Manage_Employee(object sender, RoutedEventArgs e)
        {
            Content.Navigate(typeof(ManageEmployees));
        }
    }
}
