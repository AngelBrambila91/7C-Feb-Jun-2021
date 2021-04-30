using System;
using System.Security.Cryptography;
using CryptographyLib;
using static System.Console;
namespace EncryptionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Enter a message that you want to encrypt : ");
            string message = ReadLine();
            Write("Enter a password : ");
            string password = ReadLine();
            string cryptoText = Protector.Encrypt(message, password);
            WriteLine($"Encrypted text : {cryptoText}");
            Write("Enter the password");
            string getPassword = ReadLine();
            try
            {
                string clearText = Protector.Decrypt(cryptoText, getPassword);
                WriteLine($"Decrypted text : {clearText}");
            }
            catch (CryptographicException ex)
            {
                WriteLine($"You entered the wrong password ... UnU\n More Details : {ex.Message}");
            }
            catch (Exception ex)
            {
                WriteLine($"Some other thing went wrong {ex.Message}");
            }

        }
    }
}
