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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace COMPE361_Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ClockLogs : Page
    {
        public ClockLogs()
        {
            this.InitializeComponent();
        }
        //protected override async void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    List<string> names = null;
        //    foreach (var Employee in employeeList)
        //    {
        //        names.Add(Employee.LastName.ToString() + " " + Employee.FirstName.ToString());
        //    }
        //    Employees = names;
        //}
        private void Employee_Select(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
