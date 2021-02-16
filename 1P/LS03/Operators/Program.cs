using System;
using static System.Console;

namespace Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Increment    
            // var resultOfOperation = firstIOperand operator secondOperator;
            int x = 5;
            int incrementedByOne = x++;
            Type typeOfAnyInteger = typeof(int);
            int howManyBytesInAnInt = sizeof(int);

            int a  = 3;
            int b = a++;
            WriteLine($"a is {a} , b is {b}");

            int c = 3;
            int d = ++c;
            WriteLine($"c is {c} , b is {d}");
            #endregion
            
            #region Binary Arithmetic Operators
                int e = 11;
                int f = 3;
                WriteLine($"e is {e}, f is {f}");
                WriteLine($"e + f = {e + f}");
                WriteLine($"e - f = {e - f}");
                WriteLine($"e * f = {e * f}");
                WriteLine($"e / f = {e / f}");
                WriteLine($"e % f = {e % f}");

                double g = 11.0;
                WriteLine($"g / f = {g / f}");
            #endregion

            #region Assignment Operators
                int p = 6;
                p += 3; // p = p + 3;
                p -= 3;
                p *= 3;
                p /= 3;
            #endregion

            #region Logical Operators
                bool h = true;
                bool i = false;
                WriteLine($"AND |h  | i");
                WriteLine($"h   | {h & h, -5} | {h & i, -5}");
                WriteLine($"i   | {i & h, -5} | {i & i, -5}");
                WriteLine();

                WriteLine($"OR |h  | i");
                WriteLine($"h   | {h | h, -5} | {h | i, -5}");
                WriteLine($"i   | {i | h, -5} | {i | i, -5}");
                WriteLine();

                WriteLine($"XOR |h  | i");
                WriteLine($"h   | {h ^ h, -5} | {h ^ i, -5}");
                WriteLine($"i   | {i ^ h, -5} | {i ^ i, -5}");
                WriteLine();
            #endregion


            #region Conditional Operators
                WriteLine($"h & Do Stuff() = {h & DoStuff()}");
                WriteLine($"i & Do Stuff() = {i & DoStuff()}");
                
                WriteLine($"h && Do Stuff() = {h && DoStuff()}");
                WriteLine($"i && Do Stuff() = {i && DoStuff()}");
            #endregion
        }
        private static bool DoStuff()
        {
            WriteLine("I'm doing stuff ...");
            return true;
        }
    }
}
