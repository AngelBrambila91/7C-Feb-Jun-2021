using System;
using static System.Console;
using System.IO;
namespace SelectionStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            #region IF
                // if(expression1)
                // {
                //     // runs if expression 1 is true
                // }
                // else if (expression2)
                // {
                //     // runs if expression1 is false and expression2 is true    
                // }
                // else
                // {
                //     // runs if all expressions are false
                // }
            #endregion

            #region getting args
                if(args.Length == 0)
                {
                    WriteLine("There are no arguments");
                }
                else
                {
                    WriteLine("There is at least one argument");
                }
            #endregion

            #region Pattern Match if
                object o = 3;
                int j = 4;
                if ( o is int i) // Pattern Matching
                {
                    WriteLine($"{i} x {j} = {i * j}");
                }
                else
                {
                    WriteLine("o is not an int so it cannot multiply");
                }
            #endregion

            #region switch
                // break gets out of case
                // goto case jump to an specific case
                // case
                // return
                MyFirstLabel_Label:
                var number = (new Random()).Next(1,7);
                WriteLine($"My random number is {number}");
                switch (number)
                {
                    case 1:
                    WriteLine("One");
                    break;
                    
                    case 2:
                    WriteLine("Two");
                    goto case 1;
                    
                    case 3:
                    case 4:
                    WriteLine("Three or four");
                    goto case 1;

                    case 5:
                    // go to sleep
                    System.Threading.Thread.Sleep(500);
                    goto MyFirstLabel_Label;
                    default:
                    WriteLine("Default");
                    break;
                }
            #endregion

            // #region Pattern Matching Switch
                string path = @"C:\Code";
                Write("Press R for Readonly or W for Write");
                ConsoleKeyInfo key = ReadKey();
                WriteLine();
                Stream s = null;
                if(key.Key == ConsoleKey.R)
                {
                    s = File.Open(
                        Path.Combine(path, "file.txt"),
                        FileMode.OpenOrCreate,
                        FileAccess.Read
                    );
                }
                else
                {
                    s = File.Open(
                        Path.Combine(path, "file.txt"),
                        FileMode.OpenOrCreate,
                        FileAccess.Write
                    );
                }
                string message = string.Empty;
            //     // Pattern matching
            //     switch (s)
            //     {
            //         case FileStream writeableFile when s.CanWrite:
            //             message = "the stream is a file that I can write to";
            //             break;

            //         case FileStream readOnlyFile:
            //             message = "The stream is a read-only file";
            //             break;
                    
            //         case MemoryStream ms:
            //             message = "The stream is a memory address";
            //             break;

            //         default:
            //             message = "The stream is some other type";
            //             break;
                    
            //         case null:
            //         message = "The stream is null";
            //         break;
            //     }
            //     WriteLine(message);
            // #endregion

            #region Switch Simplified
                message = s switch
                {
                    FileStream writeablefile when s.CanWrite
                    => "The stream is a file that I can write to",
                    FileStream readOnlyFile
                    => "The stream is a read-only file",
                    MemoryStream ms
                    => "The stream is a memory address",
                    null
                    => "The stream is null",
                    _ // default
                    => "The stream is some other type"
                };
                WriteLine(message);
            #endregion
        }
    }
}