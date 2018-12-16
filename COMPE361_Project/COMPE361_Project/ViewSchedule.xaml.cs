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
        Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        Windows.Storage.StorageFile employeeFile;
        bool working = true;
        private async void Display_Schedule(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs e)
        {
            ReadFile();
            string employeeScheduleString = await Windows.Storage.FileIO.ReadTextAsync(employeeFile);
            JObject scheduleChecker = JObject.Parse(employeeScheduleString);

            try
            {
                if (scheduleChecker[Schedule] == null) working = false;
                else working = true;
            }
            catch
            {
                working = false;
            }
            //testing with my email first
            string shift = $"{scheduleChecker["albertrafou@gmail.com"]["Schedule"]} ";
            Schedule.Items.Add(new ListViewItem { Content = $"{shift}" });
            
        }

        public async void ReadFile()
        {
            employeeFile = await storageFolder.GetFileAsync("testEmployeeFileWrite.json");
        }
    }
}
