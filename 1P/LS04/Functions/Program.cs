using System;
using static System.Console;

namespace Functions
{
    class Program
    {
        #region TimesTable Example (Void Function)
        static void TimesTable(byte number)
        {
            WriteLine($"This is the number {number} times table");
            for (int row = 1; row < number; row++)
            {
                WriteLine($"{row} x {number} = {row * number}");
            }
        }

        static void RunTimesTable()
        {
            bool isNumber;
            do
            {
            Write("Enter a number between 0 and 255 : ");
            isNumber = byte.TryParse(ReadLine(), out byte number);
            if (isNumber)
            {
                TimesTable(number);
            }
            else
            {
                WriteLine("You did not enter a valid number :(");
            }
            }while(!isNumber);
        }   
        #endregion

        #region Functions that return value
            /// <summary>
            /// Function that calculates taxes with param amount expressed in decimal.
            /// </summary>
            /// <param name="amount">Amount from the user to calculate tax</param>
            /// <param name="twoLetterRegionCode">Input from user to know which region enters in the switch case</param>
            /// <returns>Once the amount is validated and the region is selected in the switch, return the addition of the two of them</returns>
            static decimal CalculateTax(decimal amount, string twoLetterRegionCode)
            {
                decimal rate = 0.0M;
                switch (twoLetterRegionCode)
                {
                    case "CH" :
                        rate = 0.08M;
                        break;
                    
                    case "JL" :
                    case "DF" :
                        rate = 0.25M;
                    break;

                    case "TB" :
                    case "VZ" :
                        rate = 0.2M;
                    break;

                    default:
                        rate = 0.06M;
                    break;
                }
                return amount * rate;
            }

            /// <summary>
            /// Function that validates amount from user and gets region code from input user , and then call Calculate tax with those two params
            /// </summary>
            static void RunCalculateTax()
            {
                Write ("Enter an amount : ");
                string amountInText = ReadLine();
                Write("Enter a two letter region code : ");
                string region = ReadLine();
                if(decimal.TryParse(amountInText, out decimal amount))
                {
                    decimal taxToPay = CalculateTax(amount, region);
                    WriteLine($"You must pay {taxToPay} in sales tax.");
                }
                else
                {
                    WriteLine("You did not enter a valid amount... don't cheat");
                }
            }
        #endregion
        
        #region Writing Math functions
            static string CardinalToOrdinal(int number)
            {
                switch (number)
                {
                    case 11:
                    case 12:
                    case 13:
                        return $"{number}th";
                    default:
                    int lastDigit = number % 10;
                    string suffix = lastDigit switch
                    {
                        1 => "st",
                        2 => "nd",
                        3 => "rd",
                        _ => "th"
                    };
                    return $"{number}{suffix}";
                }
            }

            static void RunCardinalToOrdinal()
            {
                for (int number = 1; number <= 100; number++)
                {
                    Write($"{CardinalToOrdinal(number)} ");
                }
                WriteLine();
            }
        #endregion
        
        #region Recursion
            // 5!
            static int Factorial(int number)
            {
                if(number < 1)
                {
                    return 0;
                }
                else if (number == 1)
                {
                    return 1;
                }
                else
                {
                    checked
                    {
                    return number * Factorial(number - 1);
                    }
                }
            }

            static void RunFactorial()
            {
                for (int i = 1; i <= 14; i++)
                {
                    try
                    {
                        WriteLine($"{i}! = {Factorial(i):N0}");
                    }
                    catch (System.OverflowException)
                    {
                        WriteLine($"{i}! is too big for a 32-bit integer");
                    }
                    catch (System.Exception)
                    {
                        WriteLine("Something went wrong ...");
                    }
                }
            }
        #endregion
        
        //F#
        // Modularity
        // Immutability
        // Maintainability

        #region Imperative Fibonacci
            static int FibImperative(int term)
            {
                if(term == 1)
                {
                    return 0;
                }
                else if (term == 2)
                {
                    return 1;
                }
                else
                {
                    return FibImperative(term - 1) + FibImperative(term - 2);
                }
            }
            static void RunFibImperative()
            {
                for (int i = 1; i <= 30; i++)
                {
                    WriteLine($"The {CardinalToOrdinal(i)} term of the Fibonacci sequence is {FibImperative(term : i):N0}");
                }
            }

            static int FibFunctional(int term) =>
            term switch
            {
                1 => 0,
                2 => 1,
                _ => FibFunctional(term - 1) + FibFunctional(term - 2)
            };

            static void RunFibFunctional()
            {
                 for (int i = 1; i <= 30; i++)
                {
                    WriteLine($"The {CardinalToOrdinal(i)} term of the Fibonacci sequence is {FibFunctional(term : i):N0}");
                }
            }
        #endregion
        static void Main(string[] args)
        {
            //RunTimesTable();
           //RunCalculateTax();
           //RunCardinalToOrdinal();
           //RunFactorial();
           //RunFibImperative();
           RunFibFunctional();
        }
    }
}
