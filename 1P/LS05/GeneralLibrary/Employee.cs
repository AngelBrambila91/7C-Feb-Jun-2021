using System;
using static System.Console;

namespace GeneralLibrary
{
    public class Employee : Person
    {
        public string EmployeeCode { get; set; }
        public DateTime HireDate { get; set; }

        public new void WriteToConsole()// hiding members
        {
            WriteLine($"{Name} was born in {DateOfBirth:dd/MM/yy} and hired on {HireDate:dd/MM/yy}");
        }
    }
}