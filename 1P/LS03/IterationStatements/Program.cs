using System;
using static System.Console;
using System.Collections;

namespace IterationStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            #region while
                int x = 0; // initialize
                while (x < 10) // condition
                {
                    WriteLine(x);
                    x++; // iteration
                }
            #endregion

            #region do while
                string password = string.Empty;
                do
                {
                    Write("Enter your password : ");
                    password = ReadLine();
                } while (password != "1");
                WriteLine("Correct!");
            #endregion

            #region for
            for (int y = 1; y <= 10; y++)
            {
                WriteLine(y);
            }    
            #endregion
            
            #region foreach
                string [] names = { "Diego", "Rivas", "Estela", "El otro" };
                foreach (var name in names)
                {
                    WriteLine($"{name} has {name.Length} characters");
                }

            IEnumerator e = names.GetEnumerator();
            while(e.MoveNext())
            {
                string name = (string)e.Current;
                WriteLine($"{name} has {name.Length} characters");
            }
            #endregion
        }
    }
}
