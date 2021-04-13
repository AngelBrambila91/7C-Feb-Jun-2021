using System;
using System.IO;
using System.Xml;
using static System.Console;
using static System.IO.Path;
using static System.Environment;

namespace WorkingWithStreams
{
    class Program
    {
            // array of data
            static string[] names = new string [] {
                "Luis", "Ana", "Vicente", "Tiberio", "Layla", "Rivas" , "Diego1" , "Diego2"
            };
        static void Main(string[] args)
        {
            //WorkWithText();
            WorkWithXml();
        }
        static void WorkWithText()
        {
            string textFile = Combine(CurrentDirectory, "streams.txt");
            // create a file
            StreamWriter text = File.CreateText(textFile);
            foreach (string item in names)
            {
                text.WriteLine(item);
            }
            text.Close();
            // Info file
            WriteLine($"{textFile} contains {new FileInfo(textFile).Length}");
            WriteLine(File.ReadAllText(textFile));
        }

        static void WorkWithXml()
        {
            // define an xml file to write
            string xmlFile = Combine(CurrentDirectory, "streams.xml");
            // creat ea file stream
            FileStream xmlFileStream = File.Create(xmlFile);
            // XML helper
            XmlWriter xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings { Indent = true });
            // Start of the document
            xml.WriteStartDocument();
            // Define root Element
            xml.WriteStartElement("Students");
            foreach (string item in names)
            {
                xml.WriteElementString("Student", item);
            }
            foreach (string item in names)
            {
                xml.WriteElementString("AnotherPeople", item);
            }

            xml.WriteStartElement("Info");
            foreach (string item in names)
            {
                xml.WriteElementString("Name", item);
                xml.WriteElementString("Phone", "");
                xml.WriteElementString("Address", "");
            }
            xml.WriteEndDocument();
            xml.Close();
            xmlFileStream.Close();
            // Info file
            WriteLine($"{xmlFile} contains {new FileInfo(xmlFile).Length}");
            WriteLine(File.ReadAllText(xmlFile));
        }
    }
}
