using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPE361_Project
{
    public class ProgramParams
    {
        public Employee FoundEmployee { get; set; }
    }
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string CellNumber { get; set; }
        public string Address { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsManager { get; set; }
        //DateTime LastClockIn;
        //DateTime LastClockOut;
    }
}
