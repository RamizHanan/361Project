using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPE361_Project
{
    class Employee
    {
        string FirstName { get; }
        string LastName { get; }
        string EmailAddress { get; }
        string CellNumber { get;  }
        string EmployeeID { get;  }
        bool IsAdmin { get; }
        string UserName { get; }
        protected string Password { get; }
        DateTime LastClockIn;
        DateTime LastClockOut;
    }
}
