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
    public sealed partial class EditSchedule : Page
    {
        public EditSchedule()
        {
            this.InitializeComponent();
            for(int i = 0; i < 2400; i += 100)
            {
                for (int j = 1; j <= 4; j++)
                {
                    MenuFlyoutItem x = new MenuFlyoutItem();
                    MenuFlyoutItem y = new MenuFlyoutItem();
                    x.Text = (j * 15 == 60) ? $"{i + (j * 15) + 40}" : $"{i + (j * 15)}";
                    y.Text = (j * 15 == 60) ? $"{i + (j * 15) + 40}" : $"{i + (j * 15)}";
                    x.Click += new RoutedEventHandler(StartTimeSelect);
                    y.Click += new RoutedEventHandler(EndTimeSelect);
                    StartTimeOptions.Items.Add(x);
                    EndTimeOptions.Items.Add(y);
                }
            }
        }
        private void DateSelect(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            dateSelected.Text = sender.Date.Value.ToString("MM.dd.yyyy");
        }
        private void StartTimeSelect(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem x = sender as MenuFlyoutItem;
            Start.Text = x.Text;
        }
        private void EndTimeSelect(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem x = sender as MenuFlyoutItem;
            if (Int32.Parse(x.Text) < Int32.Parse(Start.Text) || Start.Text == null)
            {
                Output.Text = "Cannot Schedule End Time before Start Time";
            }
            else
            End.Text = x.Text;
        }
        private void Schedule(object sender, RoutedEventArgs e)
        {
            if(Start.Text == "" || End.Text == "" || dateSelected.Text == "") Output.Text = "Please Select Every Parameter";
            else Output.Text = "Successful Schedule";
        }
    }
}
