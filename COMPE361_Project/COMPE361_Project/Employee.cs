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
    public class Employee : IComparable<Employee>

    {
        public Employee(string firstName = null, string lastName = null, string emailAddress = null, string cellNumber = null, string address = null, bool admin = false, bool manager = false, DateTime clockin = default(DateTime))
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            CellNumber = cellNumber;
            Address = address;
            IsAdmin = admin;
            IsManager = manager;
            ClockIn = clockin;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string CellNumber { get; set; }
        public string Address { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsManager { get; set; }
        public string employeeType { get; set; }
        public DateTime ClockIn { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName + "\r\n" + EmailAddress + "\r\n" + CellNumber + "\r\n" + IsAdmin + " " + IsManager + " " + ClockIn;
        }
        public int CompareTo(Employee obj)
        {
            if (obj == null)
            {
                return -1;
            }

            if (this.FirstName == obj.FirstName &&
                   this.LastName == obj.LastName &&
                   this.EmailAddress == obj.EmailAddress &&
                   this.CellNumber == obj.CellNumber &&
                   this.IsAdmin == obj.IsAdmin &&
                   this.IsManager == obj.IsManager)
                return 1;
            return 0;
        }
        //DateTime LastClockIn;
        //DateTime LastClockOut;
    }
}
