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
using System.Threading;

namespace COMPE361_Project
{    
    public sealed partial class EmployeeList : Page
    {
        public EmployeeList()
        {
            this.InitializeComponent();
        }
        
        Employee activeEmployee = new Employee();

        //Create temporary files
        Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        Windows.Storage.StorageFile employeeFile;
        public bool employeeExists = true;

        //Create new employee
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = CreateEmployee();
            AddEmployee(Username.Text, employee);
        }

        //Loads employee data
        private async void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            ReadFile();
            CheckIfEmployeeExists(Username.Text);
            if (!employeeExists) TestStatus.Text = "ERROR - EMPLOYEE DOES NOT EXIST";
            else
            {
                string employeeListString = await Windows.Storage.FileIO.ReadTextAsync(employeeFile);
                JObject employeeList = JObject.Parse(employeeListString);
                
                JObject employeeTarget = (JObject)employeeList[Username.Text];
                string EmployeeJSON = employeeTarget.ToString();
                
                Employee foundEmployee = new Employee();
                JsonConvert.PopulateObject(EmployeeJSON, foundEmployee);
                FirstName.Text = foundEmployee.FirstName;
                LastName.Text = foundEmployee.LastName;
                EmailAddress.Text = foundEmployee.EmailAddress;
                PhoneNumber.Text = foundEmployee.CellNumber;
                TestStatus.Text = "SUCCESS - EMPLOYEE FOUND";
            }
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
        public void AddEmployee(string username, Employee newEmployee)
        {
            //Check if employee already exists
            CheckIfEmployeeExists(username);

            //If employee doesn't exist
            if (!employeeExists)
            {
                //Make JSON string from dictionary
                string newEmployeeJSON = CreateEmployeeJSON(username, newEmployee);

                //Write to employee JSON
                WriteToJSON(newEmployeeJSON);

                //**Write Employee Successfully Added**
                TestStatus.Text = "SUCCESS - EMPLOYEE ADDED";

            }
            //If employee already exists
            else
                TestStatus.Text = "ERROR - EMPLOYEE ALREADY EXISTS";
        }

        public async void CheckIfEmployeeExists(string username)
        {
            ReadFile();
            string employeeList = await Windows.Storage.FileIO.ReadTextAsync(employeeFile);

            //Check for empty file
            if (employeeList == "") employeeExists = false;
            else
            {
                //Check if employee already exists
                JObject employeeChecker = JObject.Parse(employeeList);

                //If employee does not exist
                try
                {
                    if (employeeChecker[username] == null) employeeExists = false;
                    else employeeExists = true;
                }
                catch { employeeExists = false; }
            }
        }

        public string CreateEmployeeJSON(string username, Employee newEmployee)
        {
            //Create employee dictionary
            Dictionary<string, Employee> tempEmployee = new Dictionary<string, Employee>
                {
                    { username, newEmployee }
                };

            //Make JSON string from dictionary
            return JsonConvert.SerializeObject(tempEmployee, Formatting.Indented);
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

        public async void ReadFile()
        {
            employeeFile = await storageFolder.CreateFileAsync("testEmployeeFileWrite.json", Windows.Storage.CreationCollisionOption.OpenIfExists);
            //employeeFile = await storageFolder.GetFileAsync("testEmployeeFileWrite.json");
        }
    }
}