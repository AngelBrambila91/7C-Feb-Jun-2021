using System;
using System.IO;
using System.Xml;
using static System.Console;
using static System.IO.Path;
using static System.Environment;
using System.Text;
// GZIP
using System.IO.Compression;

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
            WorkWithCompression();

            // Econding
            /*
            ASCII
            UTF-8
            UTF-7
            UTF-16
            UTF-32
            ANSI/ISO
            */
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
            FileStream xmlFileStream = null;
            XmlWriter xml = null;
            try
            {
            // define an xml file to write
            string xmlFile = Combine(CurrentDirectory, "streams.xml");
            // creat ea file stream
            xmlFileStream = File.Create(xmlFile);
            // XML helper
            xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings { Indent = true });
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
            catch (Exception ex)
            {
                // if  path doesn't exists
                WriteLine($"{ex.GetType()} sasys {ex.Message}");
            }
            finally
            {
                if(xml != null)
                {
                    xml.Dispose();
                    WriteLine("XML Resource has been disposed");
                }
                if(xmlFileStream != null)
                {
                    xmlFileStream.Dispose();
                    WriteLine("XML FileStream Resource has been disposed");
                }
            }
        }
    
        static void WorkWithCompression()
        {
            // Compress XML Output
            string gzipFilePath = Combine(CurrentDirectory, "streams.gzip");
            FileStream gzipFile = File.Create(gzipFilePath);
            using (GZipStream compressor = new GZipStream(gzipFile, CompressionMode.Compress))
            {
                using (XmlWriter xmlGzip = XmlWriter.Create(compressor))
                {
                xmlGzip.WriteStartDocument();
                // Define root Element
                xmlGzip.WriteStartElement("Students");
                foreach (string item in names)
                {
                xmlGzip.WriteElementString("Student", item);
                }
                foreach (string item in names)
                {
                xmlGzip.WriteElementString("AnotherPeople", item);
                }
                xmlGzip.WriteStartElement("Info");
                foreach (string item in names)
                {
                xmlGzip.WriteElementString("Name", item);
                xmlGzip.WriteElementString("Phone", "");
                xmlGzip.WriteElementString("Address", "");
                }
                xmlGzip.WriteEndDocument();
                }
            }
            WriteLine($"{gzipFilePath} contains {new FileInfo(gzipFilePath).Length} bytes");
            WriteLine("The compressed contents :");
            WriteLine(File.ReadAllText(gzipFilePath));
            // read the compress file
            WriteLine("Readig the compressed XML File");
            gzipFile = File.Open(gzipFilePath, FileMode.Open);
            // using decompressor
            using (GZipStream decompressor = new GZipStream(gzipFile, CompressionMode.Decompress))
            {
                using (XmlReader reader = XmlReader.Create(decompressor))
                {
                    while(reader.Read()) 
                    {
                        // Check element by string
                        if((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Student"))
                        {
                            reader.Read(); // Get text inside Element
                            WriteLine($"{reader.Value}");
                        } 
                    }
                }
            }

        }
    }
}
