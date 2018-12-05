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

            //Pick JSON file
            var file = await picker.PickSingleFileAsync();

            //Create JObject from JSON file
            JObject o1 = JObject.Parse(File.ReadAllText(file.Name));

            //Checks if key is in JSON
            bool value = o1.ContainsKey("dylanwraith@gmail.com");

            //Make JObject with data at dyalnwraith@gmail.com
            JObject o2 = (JObject)o1["dylanwraith@gmail.com"];


            try
            {
                //Convert to string
                string dylanwraith = o2.ToString();

                //Make employee from JSON
                Employee test = new Employee();
                Newtonsoft.Json.JsonConvert.PopulateObject(dylanwraith, test);

                //Make JSON from employee
                string newJson = JsonConvert.SerializeObject(test);

                //Write to screen
                CsvRows.Add(test.FirstName);
                CsvRows.Add(test.LastName);
                CsvRows.Add(test.EmployeeID);
                CsvRows.Add(test.EmailAddress);
                CsvRows.Add(test.CellNumber);
                CsvRows.Add(test.Password);
                CsvRows.Add(test.UserName);
                CsvRows.Add(newJson);
                CsvRows.Add(value.ToString());
                CSVRowsListView.ItemsSource = CsvRows;

                //Create new file
                File.WriteAllText(@"C:\Users\Dylan's PC\Documents\GitHub\361Project\COMPE361_Project\COMPE361_Project\bin\x86\Debug\AppX\test.json", newJson);
            }
            catch(Exception ex)
            {
                CsvRows.Add(ex.Message);
                CsvRows.Add("Error - User not found");
                CSVRowsListView.ItemsSource = CsvRows;
            }
        }
        
    }
}
