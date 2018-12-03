using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Collections.ObjectModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CsvParse;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace COMPE361_Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EmployeeList : Page
    {
        public EmployeeList()
        {
            this.InitializeComponent();
        }
        private ObservableCollection<string> CsvRows = new ObservableCollection<string>();

        private async void Button_Click(object sender, RoutedEventArgs e) {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.List;
            picker.FileTypeFilter.Add(".json");

            var file = await picker.PickSingleFileAsync();
            JObject o1 = JObject.Parse(File.ReadAllText(file.Name));
            CSVRowsListView.ItemsSource = o1;

            // read JSON directly from a file
            /*
            using (StreamReader fileRead = File.OpenText(file.Name))
            using (JsonTextReader reader = new JsonTextReader(fileRead))
            {
                JObject o2 = (JObject)JToken.ReadFrom(reader);
                CSVRowsListView.ItemsSource = o1;
            }
            */
            /*
            using (CsvParse.CsvFileReader csvReader = new CsvParse.CsvFileReader(await file.OpenStreamForReadAsync()))
            {
                CsvParse.CsvRow row = new CsvParse.CsvRow();
                while (csvReader.ReadRow(row))
                {
                    string newRow = "";
                    // add the columns one at a time
                    for (int i = 0; i < row.Count; i++)
                    {
                        newRow += row[i] + ",";
                    }

                    // add the row to our ObservableCollection object
                    // we'll assign this to our UI ListView
                    CsvRows.Add(newRow);
                }
            }
            CSVRowsListView.ItemsSource = CsvRows;
            */
        }
        
    }
}
