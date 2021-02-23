using System;
using static System.Console;
namespace HandlingExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            #region try Catch
            Write("Before Parsing");
            Write("What's your age?");
            string input = ReadLine();
                try
                {
                    int age = int.Parse(input);
                }
                catch(FormatException)
                {
                    WriteLine("The age you entered is not a valid number format");
                }
                catch(OverflowException)
                {
                    WriteLine("You age is a valid number but it is either too big or small");
                }
                catch (Exception ex)
                {
                    WriteLine($"{ex.GetType()} says {ex.Message}");
                }
                WriteLine("After Parsing");
            #endregion

            #region Checking overflow
                // checked
                try
                {
                checked
                {
                int x = int.MaxValue - 1;
                WriteLine($"Initial Value {x}");
                x++;
                WriteLine($"After incrementing {x}");
                x++;
                WriteLine($"After incrementing {x}");
                x++;
                WriteLine($"After incrementing {x}");
                }
                }
                catch (OverflowException)
                {
                    WriteLine("The code overflowed but i caught the exception , got your back buddy o(*￣▽￣*)ブo");
                }
                
            #endregion
        }
    }
}
