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
using System.Threading.Tasks;
using System.Diagnostics;

namespace COMPE361_Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    
    public sealed partial class EmployeeList : Page
    {

        //Create file
        Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        Windows.Storage.StorageFile testEmployeeFile;

        public EmployeeList()
        {
            this.InitializeComponent();
        }

        private ObservableCollection<string> CsvRows = new ObservableCollection<string>();

        private async void Button_Click(object sender, RoutedEventArgs e) {
            /*
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.List;
            picker.FileTypeFilter.Add(".json");

            

            
            var file = await picker.PickSingleFileAsync();
            */

            try
            {
                //Read JSON file
                testEmployeeFile = await storageFolder.GetFileAsync("testEmployeeFileRead.json"); //await storageFolder.CreateFileAsync("testEmployeeFile.json", Windows.Storage.CreationCollisionOption.ReplaceExisting);
                string testEmployee = await Windows.Storage.FileIO.ReadTextAsync(testEmployeeFile);

                //Create JObject from JSON file
                JObject o1 = JObject.Parse(testEmployee);

                //Checks if key is in JSON
                bool value = o1.ContainsKey("dylanwraith");

                //Make JObject with data at us:dylanwraith, pw:081597
                if ((JObject)o1["dylanwraith"]["081597"] != null)
                {
                    JObject o2 = (JObject)o1["dylanwraith"]["081597"];


                    //Convert JSON to JSON string
                    string dylanwraith = o2.ToString();

                    //Make employee from JSON string
                    Employee test = new Employee();
                    Newtonsoft.Json.JsonConvert.PopulateObject(dylanwraith, test);

                    //Create dictionary of dictionaries
                    Dictionary<string, Employee> dictionaryTest = new Dictionary<string, Employee>
                    {
                        { "081597", test }
                    };
                    Dictionary<string, Dictionary<string, Employee>> dictionaryOfDictionaryTest = new Dictionary<string, Dictionary<string, Employee>>
                    {
                        { "dylanwraith", dictionaryTest }
                    };

                    //Make JSON string from employee
                    string newJson = JsonConvert.SerializeObject(test);

                    //Make JSON string from dictionary
                    string dictionaryString = JsonConvert.SerializeObject(dictionaryOfDictionaryTest, Formatting.Indented);

                    //Write to screen
                    CsvRows.Add(test.FirstName);
                    CsvRows.Add(test.LastName);
                    CsvRows.Add(test.EmailAddress);
                    CsvRows.Add(test.CellNumber);
                    CsvRows.Add(test.Password);
                    CsvRows.Add(newJson);
                    CsvRows.Add(value.ToString());
                    CSVRowsListView.ItemsSource = CsvRows;

                    //Write to employee JSON
                    testEmployeeFile = await storageFolder.CreateFileAsync("testEmployeeFileWrite.json",Windows.Storage.CreationCollisionOption.OpenIfExists);
                    string newFile = await Windows.Storage.FileIO.ReadTextAsync(testEmployeeFile);
                    if (newFile == "")
                    {
                        //newFile = '{' + newJson + '}';
                        newFile = dictionaryString;
                    }
                    else
                    {
                        newFile = newFile.Remove(newFile.Length - 1, 1);  //newFile.TrimEnd('}');
                        dictionaryString = dictionaryString.Remove(0, 1);
                        dictionaryString = dictionaryString.Remove(dictionaryString.Length - 1, 1);
                        //newFile = newFile + ',' + newJson + '}';
                        newFile = newFile + ',' + dictionaryString + '}';
                    }
                    await Windows.Storage.FileIO.WriteTextAsync(testEmployeeFile, newFile);
                }
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
