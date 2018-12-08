﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPE361_Project
{
    public class ClockInfo
    {
        public string ClockedTimes;
        public string ClockedTypes;
        public ClockInfo() { ClockedTimes = null; ClockedTypes = null; }
        public ClockInfo(string clockedTime, string clockedType)
        {
            ClockedTimes = clockedTime; ClockedTypes = clockedType;
        }
    }
    class Employee
    {
            string FirstName { get; }
            string LastName { get; }
            string EmailAddress { get; }
            string CellNumber { get; }
            bool IsAdmin { get; }
            bool IsManager { get; }
    }
}
