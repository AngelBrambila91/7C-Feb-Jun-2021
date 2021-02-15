using System;
using System.IO;
using System.Xml;

namespace Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            #region object , var and dynamic
            object height = 1.88;
            object name = "Diego";
            Console.WriteLine($"{name} is {height} meters tall.");
            //int lenght = name.Lenght; // compile error
            int lenght = ((string)name).Length;
            Console.WriteLine($"{name} has {lenght} characters");
            dynamic anotherName = "Estela";
            int eLength = anotherName.Length;
            Console.WriteLine($"{anotherName} has {eLength} characters");

            var xml1 = new XmlDocument();
            var number = 1.2M;
            var lastName = "Torpedo";
            XmlDocument xml2 = new XmlDocument();
            var file1 = File.CreateText(@"E:/something.txt");
            //StreamWriter file2 = File.Create(@"E:/something.txt");
            Console.WriteLine($"{number.GetType()}");
            #endregion

            #region Default
                Console.WriteLine($"default (int) = {default(int)}");
                Console.WriteLine($"default (bool) = {default(bool)}");
                Console.WriteLine($"default (DateTime) = {default(DateTime)}");
                Console.WriteLine($"default (string) = {default(string)}"); // const char  * [][]
            #endregion

            #region Arrays
                string [] names;
                names = new string[4];
                names [0] = "Baltazar";
                names [1] = "Diegito";
                names [2] =  "Estela";
                names [3] = "Luis Adrian";

                for (int i = 0; i < names.Length; i++)
                {
                    Console.WriteLine(names[i]);
                }
            #endregion
        }
    }
}
