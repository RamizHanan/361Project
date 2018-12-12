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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
//Bert was here

namespace COMPE361_Project
{    
    public sealed partial class EmployeeList : Page
    {
        public EmployeeList()
        {
            this.InitializeComponent();
        }

        //Create temporary files
        Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        Windows.Storage.StorageFile employeeFile;
        bool employeeExists = true;
        public async void AddEmployee(string username, string password, Employee newEmployee)
        {
            //Check if employee already exists
            CheckIfEmployeeExists(username, password);

            //If employee doesn't exist
            if (!employeeExists)
            {
                //Make JSON string from dictionary
                string newEmployeeJSON = CreateEmployeeJSON(username, password, newEmployee);

                //Write to employee JSON
                WriteToJSON(newEmployeeJSON);

                //**Write Employee Successfully Added**
                TestStatus.Text = "SUCCESS - EMPLOYEE ADDED";

            }
            //If employee already exists
            else
                TestStatus.Text = "ERROR - EMPLOYEE ALREADY EXISTS";
        }

        public async void WriteToJSON(string newJSON)
        {
            employeeFile = await storageFolder.CreateFileAsync("testEmployeeFileWrite.json", Windows.Storage.CreationCollisionOption.OpenIfExists);
            string newFile = await Windows.Storage.FileIO.ReadTextAsync(employeeFile);
            if (newFile == "")
                newFile = newJSON;
            else
            {
                newFile = newFile.Remove(newFile.Length - 1, 1);
                newJSON = newJSON.Remove(0, 1);
                newJSON = newJSON.Remove(newJSON.Length - 1, 1);
                newFile = newFile + ',' + newJSON + '}';
            }
            await Windows.Storage.FileIO.WriteTextAsync(employeeFile, newFile);
        }

        public async void CheckIfEmployeeExists(string username, string password)
        {
            ReadFile();
            string employeeList = await Windows.Storage.FileIO.ReadTextAsync(employeeFile);

            //Check if employee already exists
            JObject employeeChecker = JObject.Parse(employeeList);

            //If employee does not exist
            try
            {
                if (employeeChecker[username][password] == null) employeeExists = false;
                else employeeExists = true;
            }
            catch { employeeExists = false; }
        }

        public async void ReadFile()
        {
            employeeFile = await storageFolder.GetFileAsync("testEmployeeFileWrite.json");
        }

        public string CreateEmployeeJSON(string username, string password, Employee newEmployee)
        {
            //Create employee dictionary
            Dictionary<string, Employee> tempEmployee = new Dictionary<string, Employee>
                {
                    { password, newEmployee }
                };
            Dictionary<string, Dictionary<string, Employee>> newEmployeeDictionary = new Dictionary<string, Dictionary<string, Employee>>
                {
                    { username, tempEmployee }
                };

            //Make JSON string from dictionary
            return JsonConvert.SerializeObject(newEmployeeDictionary, Formatting.Indented);
        }

        public Employee CreateEmployee()
        {
            Employee employee = new Employee();
            employee.FirstName = FirstName.Text;
            employee.LastName = LastName.Text;
            employee.CellNumber = PhoneNumber.Text;
            employee.EmailAddress = EmailAddress.Text;
            return employee;
        }

        //Create new employee
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = CreateEmployee();
            AddEmployee(Username.Text, Password.Text, employee);
        }

        //Loads employee data
        private async void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            ReadFile();
            CheckIfEmployeeExists(Username.Text, Password.Text);
            if (!employeeExists) TestStatus.Text = "ERROR - EMPLOYEE DOES NOT EXIST";
            else
            {
                string employeeListString = await Windows.Storage.FileIO.ReadTextAsync(employeeFile);
                JObject employeeList = JObject.Parse(employeeListString);
                string EmployeeJSON = employeeList[Username.Text][Password.Text].ToString();
                Employee foundEmployee = new Employee();
                Newtonsoft.Json.JsonConvert.PopulateObject(EmployeeJSON, foundEmployee);
                FirstName.Text = foundEmployee.FirstName;
                LastName.Text = foundEmployee.LastName;
                EmailAddress.Text = foundEmployee.EmailAddress;
                PhoneNumber.Text = foundEmployee.CellNumber;
                TestStatus.Text = "SUCCESS - EMPLOYEE FOUND";
            }
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
            {

            }

            private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
            {

            }

            private void TextBlock_SelectionChanged_1(object sender, RoutedEventArgs e)
            {

            }

            private void First_Copy1_SelectionChanged(object sender, RoutedEventArgs e)
            {

            }
        }
    
}