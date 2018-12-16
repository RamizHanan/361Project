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
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

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
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var currentEmployee = (ProgramParams)e.Parameter;
            receivedEmployee = currentEmployee.FoundEmployee;
        }

        Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        Windows.Storage.StorageFile employeeFile;
        public Employee receivedEmployee;

        private void ClockIn(object sender, RoutedEventArgs e)
        {
            StatusBox.Text = $"Clocked In at {DateTime.Now.ToString("h:mm:ss tt")}";
            string dateTimeString = $"{DateTime.Today.ToString("d")} {DateTime.Now.ToString("HH:mm:ss")}";
            WriteToJSON(dateTimeString);
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



        public async void ReadDatesAndTimesFromJSON(string newDateAndTime)
        {
            employeeFile = await storageFolder.CreateFileAsync("testEmployeeFileWrite.json", Windows.Storage.CreationCollisionOption.OpenIfExists);
            string newFile = await Windows.Storage.FileIO.ReadTextAsync(employeeFile);
            JObject json = JObject.Parse(newFile);
            JArray employee = (JArray)json[receivedEmployee.EmailAddress]["DatesAndTimes"];
            string[] employeeDatesAndTimes = JsonConvert.DeserializeObject<string[]>(employee.ToString());
            employeeDatesAndTimes[employeeDatesAndTimes.Length] = newDateAndTime;
            JArray update = JsonConvert.SerializeObject(employeeDatesAndTimes);
        }



    }
}
