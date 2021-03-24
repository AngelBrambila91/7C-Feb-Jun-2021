using System;
using System.Collections.Generic;
using static System.Console;

namespace GeneralLibrary
{
    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            // Compare Name Lengths
            int result = x.Name.Length.CompareTo(y.Name.Length);
            // if they're equal
            if(result == 0)
            {
                return x.Name.CompareTo(y.Name);
            }
            else
            {
                return result;
            }
        }
    }
}