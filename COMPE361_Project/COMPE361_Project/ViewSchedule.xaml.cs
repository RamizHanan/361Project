using Newtonsoft.Json.Linq;
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
using System.Threading.Tasks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace COMPE361_Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewSchedule : Page
    {
        public ViewSchedule()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var currentEmployee = (ProgramParams)e.Parameter;

            activeEmployee = currentEmployee.FoundEmployee;
        }
        Employee activeEmployee = new Employee();

        Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        Windows.Storage.StorageFile employeeFile;
        private async void Display_Schedule(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs e)
        {
            //retreives selected date and converts to string in order to view schedule for that day
            var myDate = e.AddedDates.First();
            string selectedDate = myDate.ToString();
            string truncatedSelectedDate = new string(selectedDate.Take(10).ToArray());

            ReadFile();

            CalendarViewDayItem dayStatus = new CalendarViewDayItem();

            //Deserialize from json
            string employeeScheduleString = await Windows.Storage.FileIO.ReadTextAsync(employeeFile);
            JObject scheduleChecker = JObject.Parse(employeeScheduleString);
            JArray schedules = (JArray)scheduleChecker[activeEmployee.EmailAddress]["Schedule"];
            List<string> employeeSchedule = JsonConvert.DeserializeObject<List<string>>(schedules.ToString());


            //search for selected date within json
            for (int i = 0; i < employeeSchedule.Count; i++)
            {
                if (employeeSchedule[i].Contains(truncatedSelectedDate))
                {
                    Schedule.Items.Add(new ListViewItem { Content = $"{employeeSchedule[i]}" });
                    break;
                }
                else if (i == employeeSchedule.Count - 1)
                {
                    Schedule.Items.Add(new ListViewItem { Content = "Not working" });
                }
            }
        }


            public async void ReadFile()
        {
            employeeFile = await storageFolder.GetFileAsync("testEmployeeFileWrite.json");
        }
    }
}
