    using System;
    using static System.Console;

namespace BitwiseOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10; // 0000 1010
            int b = 6;  // 0000 0110
            WriteLine($"a = {a}");
            WriteLine($"b = {b}");
            WriteLine($"a & b  = {a & b}"); // 2 - bit column only
            WriteLine($"a | b  = {a | b}"); // 8, 4 and 2 bit column only
            WriteLine($"a ^ b  = {a ^ b}"); // 8 and 4 bit column only

            #region Binary Shift
                // 0000 1010 left-shift
                WriteLine($"a << 3 = {a  << 3}");
                WriteLine($" a * 2 = {a * 2}");
                WriteLine($"b >> 1 = {b >> 1}");
            #endregion

            int age = 47;
            // How many operators in the following statement?
            char firstDigit = age.ToString()[0];
            // = asignment operator
            // [] index acces operator
            // . member acces operator
            // () Invocation operator

        }
    }
}
