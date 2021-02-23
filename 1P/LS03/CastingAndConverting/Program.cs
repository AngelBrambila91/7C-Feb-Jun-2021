using System;
using static System.Console;
using static System.Convert;

namespace CastingAndConverting
{
    class Program
    {
        static void Main(string[] args)
        {
            //casting
            #region Implicit casting
                int a = 10;
                double b = a;
                WriteLine(b);

                double c = 9.8;
                int d = (int)c;
                WriteLine(d);

                long e = 10;
                int f = (int)e;
                WriteLine($"e is {e:N0} and f is {f:N0}");
                e = long.MaxValue;
                f = (int)e;
                WriteLine($"e is {e:N0} and f is {f:N0}");

                e = 5_000_000_000;
                f = (int)e;
                WriteLine($"e is {e:N0} and f is {f:N0}");
            #endregion

            #region Convert
                double g = 9.8;
                int h = ToInt32(g);
                WriteLine($"g is {g} and h is {h}");
                // British system
                double [] doubles = new []
                {
                    9.49, 9.5, 9.51, 10.49, 10.5, 10.51
                };
                foreach (double n in doubles)
                {
                    WriteLine($"ToInt({n}) is {ToInt32(n)}");
                }

            //Bankers Rounding
            foreach (double n in doubles)
            {
                WriteLine($"Math.Round({n}), 0, MidpointRounding.AwayFromZero si {Math.Round(value : n, digits : 0, mode: MidpointRounding.AwayFromZero)}");
                
            }
            #endregion


            #region To String
                int number = 12;
                WriteLine(number.ToString());
                bool boolean = true;
                WriteLine(boolean.ToString());
                DateTime now = DateTime.Now;
                WriteLine(now.ToString());
                object me = new object();
                WriteLine(me.ToString());
            #endregion

            #region Binary To String
                byte[] binaryObject = new byte[128];
                new Random().NextBytes(binaryObject);
                WriteLine("Binary Object as bytes");
                for (int index = 0; index < binaryObject.Length; index++)
                {
                    Write($"{binaryObject[index]:X} ");
                }
                string encoded = ToBase64String(binaryObject);
                WriteLine($"Binary Object as Base 64 : {encoded}");
            #endregion

            #region Parse
                int age = int.Parse("29");
                DateTime birthday = DateTime.Parse("2 August 1991");
                WriteLine($"I was born {age} years ago");
                WriteLine($"My birthday is {birthday}");
                WriteLine($"My birthday is {birthday:D}");
            #endregion

            #region TryParse
                Write("How many eggs are there?");
                int count;
                string input = ReadLine();
                if (int.TryParse(input, out count))
                {
                    WriteLine($"There are {count} eggs");
                }
                else
                {
                    WriteLine("I could not parse the input");
                }
            #endregion
        }
    }
}
