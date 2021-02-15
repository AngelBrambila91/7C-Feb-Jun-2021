#nullable enable // this activa reference nullable 
using System;
using static System.Console;

namespace NullHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Working With Nullables
            int thisCannotBeNull = 4;
            //thisCannotBeNull = null;
            int? thisCouldBeNull = null;
            WriteLine(thisCouldBeNull);
            WriteLine(thisCouldBeNull.GetValueOrDefault());
            thisCouldBeNull = 7;
            WriteLine(thisCouldBeNull);
            WriteLine(thisCouldBeNull.GetValueOrDefault());
            #endregion

            var address = new Address();
            address.Building = null;
            address.Street = null;
            address.City = "Mexico";
            address.Region = null;

            #region Checking for Null
                if(thisCouldBeNull != null)
                {
                    int length = thisCouldBeNull.Length; // throw exception
                }
            #endregion
        }
    }
}
