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
    public sealed partial class EmployeeClock : Page
    {
        public EmployeeClock()
        {
            this.InitializeComponent();
        }
        private void ClockIn(object sender, RoutedEventArgs e)
        {
            StatusBox.Text = $"Clocked In at {DateTime.Now.ToString("h:mm:ss tt")}";
        }
        private void ClockOut(object sender, RoutedEventArgs e)
        {
            StatusBox.Text = $"Clocked Out at {DateTime.Now.ToString("h:mm:ss tt")}";
        }
        private void LunchIn(object sender, RoutedEventArgs e)
        {

        }
        private void LunchOut(object sender, RoutedEventArgs e)
        {

        }
    }
}
