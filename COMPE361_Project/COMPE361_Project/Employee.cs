using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPE361_Project
{
    class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string CellNumber { get; set; }
        public bool IsAdmin { get; set; }
        public string Password { get; set; }
        DateTime LastClockIn;
        DateTime LastClockOut;
    }
}
