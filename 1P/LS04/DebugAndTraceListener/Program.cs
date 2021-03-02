using System;
using System.Diagnostics;
using System.IO;

namespace DebugAndTraceListener
{
    class Program
    {
        static void Main(string[] args)
        {   
            Trace.Listeners.Add(new TextWriterTraceListener(
                File.CreateText("log.txt")
            ));
            Trace.AutoFlush = true;
            Debug.WriteLine("Debug Says , IM WATCHING YOU!!");
            Trace.WriteLine("Trace says, Hello there!");
        }

    }
}
