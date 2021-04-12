using System;
using static System.Console;
namespace GeneralLibrary
{
    public class Singer
    {
        // virtual allows this method to ve overriden
        public virtual void Sing()
        {
            WriteLine("Singing ....");
        }
    }

    public class LadyGaga : Singer
    {
        public sealed override void Sing()
        {
            WriteLine(" Po Po Po po ker face.... ");
        }
    }
}