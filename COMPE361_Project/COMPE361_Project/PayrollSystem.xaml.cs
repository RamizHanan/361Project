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
    //    bool isManager = true;
    //    string Username = "John";
    //    string Position = "Manager";
        public PayrollSystem()
        {
            this.InitializeComponent();
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
        private void EmployeeClock_Click(object sender, RoutedEventArgs e)
        {
            Content.Navigate(typeof(EmployeeClock));
        }
        private void Schedule_View(object sender, RoutedEventArgs e)
        {
            Content.Navigate(typeof(SchedulePage));
        }
    }
}
