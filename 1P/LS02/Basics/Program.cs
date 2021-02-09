using System;
using System.Linq;
using System.Reflection;
//#error No se que hago en el ceti
namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            // statements
            // var totalPrice = subtotal + sales;

            /*
            Todo esto va a estar comentadoe
            */
            // int cont2 = 0;
            // {
            //     int cont2 = 0;
            // } // reglas de ambito  // scope rules
            // cont2++;

            // loop through the assemblies that this app references 
            foreach (var r in Assembly.GetEntryAssembly()
              .GetReferencedAssemblies())
            {
                // load the assembly so we can read its details
                var a = Assembly.Load(new AssemblyName(r.FullName));
                // declare a variable to count the number of methods
                int methodCount = 0; 
                // loop through all the types in the assembly
                foreach (var t in a.DefinedTypes)
                {
                    // add up the counts of methods
                    methodCount += t.GetMethods().Count();
                }
                // output the count of types and their methods
                Console.WriteLine(
                  "{0:N0} types with {1:N0} methods in {2} assembly.",
                  arg0: a.DefinedTypes.Count(),
                  arg1: methodCount,
                  arg2: r.Name);
            }
            // Camel case I.G : cost, orderDetail, dateOfBirth used for, local variables , private fields
            // Title Case I.G : String, Int32, Cost, DateOfBirth, Run , Types, non local variables, methods


            // Literal values
            // Dynamic Values
            char letter = 'A';
            char digit = '1';
            char symbol = '$';
            //char userChoice = GetKeyStroke();

            string firstName = "Angel";
            string lastName = "Brambila";
            //string address = GetAddressFromDataBase(id : 563);

            string fullName = "Angel\tBrambila";
            Console.WriteLine(fullName);
            string filePath = @"C:\televesion\tony\bravia.txt"; // @ is called verbatim
            Console.WriteLine(filePath);
            

        }
    }
}
