using System;
using System.IO;
using System.Xml;

namespace Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            
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
        }
    }
}
