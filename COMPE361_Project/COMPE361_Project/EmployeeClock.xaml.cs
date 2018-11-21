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
        public UserData Data { get; set; }
        public EmployeeClock()
        {
            this.InitializeComponent();
            //if (Data.DataSet.Any())
            //{
            //    if(Data.DataSet.Count > 10)
            //    {
            //        for(int i = Data.DataSet.Count - 10; i < Data.DataSet.Count; i++)
            //        {
            //            Recent_Clocked_Times.Items.Add(Data.DataSet[i]);
            //        }
            //    }
            //    for (int i = 0; i < Data.DataSet.Count; i++)
            //    {
            //        Recent_Clocked_Times.Items.Add(Data.DataSet[i]);
            //    }
            //}
        }
        private void ClockIn(object sender, RoutedEventArgs e)
        {
            Data.DataSet.Add(new ClockInfo("Clocked In", DateTime.Now.ToString("h:mm:ss tt")));
            Recent_Clocked_Times.Items.Add(new ClockInfo("Clocked In", DateTime.Now.ToString("h:mm:ss tt")));
        }
        private void ClockOut(object sender, RoutedEventArgs e)
        {

        }
    }
}
