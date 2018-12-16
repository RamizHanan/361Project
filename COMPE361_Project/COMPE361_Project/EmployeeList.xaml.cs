using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace COMPE361_Project
{
    public sealed partial class EmployeeList : Page
    {
        public EmployeeList()
        {
            this.InitializeComponent();
            newFunction();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var currentEmployee = (ProgramParams)e.Parameter;

            activeEmployee = currentEmployee.FoundEmployee;

            

            //Schedule.Items.Add(new ListViewItem { Content =  });
        }

        public async void newFunction()
        {
            //get json into string
            employeeFile = await storageFolder.CreateFileAsync("testEmployeeFileWrite.json", Windows.Storage.CreationCollisionOption.OpenIfExists);
            string newFile = await Windows.Storage.FileIO.ReadTextAsync(employeeFile);
            JObject json = JObject.Parse(newFile);

            //access employees
            JArray employeeList = (JArray)json["employees"];

            List<string> employees = JsonConvert.DeserializeObject<List<string>>(employeeList.ToString());
       
            for(int i = 0; i < employees.Count; i ++) {
                //Employees.Items.Add(new ListViewItem { Content = (string)json[employees[i]]["FirstName"] + " " + (string)json[employees[i]]["LastName"] });
                Employees.Items.Add(new ListViewItem { Content = employees[i] });
            }

        }

        Employee activeEmployee = new Employee();
        


        //Create temporary files
        Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

        Windows.Storage.StorageFile employeeFile;
        public bool employeeExists = true;
        
        public async void AddEmployee(string username, Employee newEmployee)
        {
            //Check if employee already exists
            CheckIfEmployeeExists(username);
            //If employee doesn't exist
            if (!employeeExists)
            {
                //get json into string
                employeeFile = await storageFolder.CreateFileAsync("testEmployeeFileWrite.json", Windows.Storage.CreationCollisionOption.OpenIfExists);
                string newFile = await Windows.Storage.FileIO.ReadTextAsync(employeeFile);
                JObject json = JObject.Parse(newFile);

                //access employees
                JArray employeeList = (JArray)json["employees"];

                //add employee email to list
                employeeList.Add(username);

                //update json
                await Windows.Storage.FileIO.WriteTextAsync(employeeFile, json.ToString());

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

        public async void ReadFile()
        {
            employeeFile = await storageFolder.CreateFileAsync("testEmployeeFileWrite.json", Windows.Storage.CreationCollisionOption.OpenIfExists);
            //employeeFile = await storageFolder.GetFileAsync("testEmployeeFileWrite.json");
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
        public async void UpdateEmployee(string email)
        {

            //get json into string
            employeeFile = await storageFolder.CreateFileAsync("testEmployeeFileWrite.json", Windows.Storage.CreationCollisionOption.OpenIfExists);
            string newFile = await Windows.Storage.FileIO.ReadTextAsync(employeeFile);
            JObject json = JObject.Parse(newFile);

            //access employees
            json[email]["FirstName"] = FirstName.Text;

            //update json
            await Windows.Storage.FileIO.WriteTextAsync(employeeFile, json.ToString());
        }
        public Employee CreateEmployee()
        {
            //userName is email address since that is how we login
            Employee employee = new Employee();
            employee.FirstName = FirstName.Text;
            employee.LastName = LastName.Text;
            employee.CellNumber = PhoneNumber.Text;
            employee.EmailAddress = Username.Text.ToLower(); //keep it lowercase cuz email
            employee.Address = Address.Text;
           // employee.employeeType = EmployeeType.Text;
            return employee;
        }

        //Create new employee
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = CreateEmployee();
            AddEmployee(Username.Text, employee);
        }

        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateEmployee(Username.Text);
        }

        //Loads employee data
        private async void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            ReadFile();
            CheckIfEmployeeExists(Username.Text);
            if (!employeeExists) TestStatus.Text = "ERROR - EMPLOYEE DOES NOT EXIST";
            else
            {
                try
                {
                    string employeeListString = await Windows.Storage.FileIO.ReadTextAsync(employeeFile);
                    JObject employeeList = JObject.Parse(employeeListString);

                    //NEW
                    JObject employeeTarget = (JObject)employeeList[Username.Text];

                    string EmployeeJSON = employeeTarget.ToString();

                    //Taken out temporarily
                    //string EmployeeJSON = employeeList[Username.Text][Password.Text].ToString();

                    Employee foundEmployee = new Employee();
                    Newtonsoft.Json.JsonConvert.PopulateObject(EmployeeJSON, foundEmployee);
                    FirstName.Text = foundEmployee.FirstName;
                    LastName.Text = foundEmployee.LastName;
                    Username.Text = foundEmployee.EmailAddress;
                    PhoneNumber.Text = foundEmployee.CellNumber;
                    Address.Text = foundEmployee.Address;
                //    EmployeeType.Text = foundEmployee.employeeType;
                    TestStatus.Text = "SUCCESS - EMPLOYEE FOUND";
                }
                catch { TestStatus.Text = "ERROR - EMPLOYEE DOES NOT EXIST"; }
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

        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Employees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    
}