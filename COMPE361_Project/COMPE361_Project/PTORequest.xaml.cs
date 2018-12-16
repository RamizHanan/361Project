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
    public sealed partial class PTORequest : Page
    {
        public PTORequest()
        {
            this.InitializeComponent();
        }
        private void DateSelected(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs e)
        {
            DatesRequested.Items.Clear();
            foreach (DateTimeOffset date in DateSelector.SelectedDates)
            {
                DatesRequested.Items.Add(date.ToString("MM/dd/yyyy"));
            }
        }
        private void Clear(object sender, RoutedEventArgs e)
        {
            DateSelector.SelectedDates.Clear();
        }
        private void Send(object sender, RoutedEventArgs e)
        {
            Status.Text = "Request Successful";
        }
    }
}