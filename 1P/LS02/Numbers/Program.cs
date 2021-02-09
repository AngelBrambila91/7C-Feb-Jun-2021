using System;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            uint naturalNumber = 23;
            int integerNumber = -4;
            float realNumber = 2.114F;
            double anotherRealNumber = 2.3;

            int decimalNotation = 2_000_000;
            int binaryNotation = 0b_0001_1110_1000_0100_1000_0000;
            int hexadecimalNotation = 0x_001E_8480;

            //2.14
            // 

            Console.WriteLine($"{decimalNotation == binaryNotation}");
            Console.WriteLine($"{decimalNotation == hexadecimalNotation}");

            Console.WriteLine($"int uses {sizeof(int)}, bytes and can store numbers in the range {int.MinValue:N0} to {int.MaxValue:N0}");
            // Expression Format : expression : format
            Console.WriteLine($"double uses {sizeof(double)}, bytes and can store numbers in the range {double.MinValue:N0} to {double.MaxValue:N0}");
            Console.WriteLine($"decimal uses {sizeof(decimal)}, bytes and can store numbers in the range {decimal.MinValue:N0} to {decimal.MaxValue:N0}");

            Console.WriteLine("Using Doubles :");
            double a = 0.1;
            double b = 0.2;
            if(a + b == 0.3)
            {
                Console.WriteLine($"{a} + {b} equals {a + b}");
            }
            else
            {
                Console.WriteLine($"{a} + {b} does NOT equal {a + b}");
            }

            Console.WriteLine("Using Decimal :");
            decimal c = 0.1M;
            decimal d = 0.2M;
            if(c + d == 0.3M)
            {
                Console.WriteLine($"{c} + {d} equals {c + d}");
            }
            else
            {
                Console.WriteLine($"{c} + {d} does NOT equal {c + d}");
            }

            // Booleans
            bool happy = true;
            bool sad = false;
        }
    }
}
