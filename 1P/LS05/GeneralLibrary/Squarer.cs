using System;
using System.Threading;
namespace GeneralLibrary
{
    public class Squarer
    {
        public static double Square<T> (T input) where T : IConvertible
        {
            // Converting ...
            double d = input.ToDouble(Thread.CurrentThread.CurrentCulture);
            return d * d;
        }
    }
}