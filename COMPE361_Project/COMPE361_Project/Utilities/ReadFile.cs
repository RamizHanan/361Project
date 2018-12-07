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
    class FileReader
    {
        //Create temporary files
        Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        Windows.Storage.StorageFile employeeFile;
        public async void AddEmployee(string username, string password, Employee newEmployee)
        {
            employeeFile = await storageFolder.GetFileAsync("testEmployeeFileRead.json");
            
        }
    }
}
