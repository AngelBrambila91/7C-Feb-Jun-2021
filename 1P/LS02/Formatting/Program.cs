using System;
using static System.Console;

namespace Formatting
{
    class Program
    {
        static void Main(string[] args)
        {
              #region Format by Positional Arguments
                  int numberOfApples = 12;
                  decimal pricePerApple = 0.35M;
                  WriteLine(
                      format: "{0} apples costs {1:C}",
                      arg0 : numberOfApples,
                      arg1 : pricePerApple * numberOfApples
                  );

                  string formatted = string.Format(
                      format: "{0} apples costs {1:C}",
                      arg0 : numberOfApples,
                      arg1 : pricePerApple * numberOfApples
                  );
                  //WriteToFile(formatted);
              #endregion

              #region Interpolated strings
                  WriteLine($"{numberOfApples} apples costs {pricePerApple * numberOfApples:C}"); // { expression, {aligment}: format type}

                  string applesText = "Apples";
                  int applesCount = 1234;
                  string bananasText = "Bananas";
                  int bananasCount = 56789;
              #endregion

              #region Alignment
                WriteLine(
                      format: "{0, -8}{1, 6:N0}",
                      arg0 : "Name",
                      arg1 : "Count"
                  );

                  WriteLine(
                      format: "{0, -8} {1, 6:N0}",
                      arg0 : applesText,
                      arg1 : applesCount
                  );

                  WriteLine(
                      format: "{0, -8} {1,6:N0}",
                      arg0 : bananasText,
                      arg1 : bananasCount
                  );

                WriteLine($"{applesText, -8} {applesCount,6} \n{bananasText, -8:N0} {bananasCount,6}");
              #endregion

              #region Input From User
                  Write("Type your first name and press ENTER : ");
                  string firstName = ReadLine();
                  Write ("Type your age and press ENTER : ");
                  string? age = ReadLine();
                  WriteLine($"Hello {firstName}, you look good for {age}");
              #endregion

              #region Getting key input
              // Keylogger
                  Write ("Press any key combination : ");
                  ConsoleKeyInfo key = ReadKey();
                  WriteLine();
                  WriteLine($"Key : {key.Key}, Char :  {key.KeyChar}, Modifiers : {key.Modifiers}");
              #endregion
        }
    }
}
