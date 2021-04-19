using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using static System.Console;
using static System.Environment;
using static System.IO.Path;

namespace WorkingWithSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            // create an complex object
            var people = new List<Person>
            {
                new Person(30000M) { 
                    FirstName = "Luis",
                    LastName = "Villalobos",
                    DateOfBirth = new DateTime(1999,3,14)
                    },
                new Person(30000M) { 
                    FirstName = "Diego",
                    LastName = "Cortez",
                    DateOfBirth = new DateTime(1999,4,15)
                    },
                new Person(30000M) { 
                    FirstName = "Ana",
                    LastName = "Prian",
                    DateOfBirth = new DateTime(1999,5,16),
                    Children = new HashSet<Person> 
                    {
                        new Person(0M) {
                        FirstName = "Sofia",
                        LastName = "Zeta",
                        DateOfBirth = new DateTime(2021,3,14)
                    }
                    }
                    }
            };

            // create an object to format the Lsit of persons
            var xs = new XmlSerializer(typeof(List<Person>));
            // create file to write
            string path = Combine(CurrentDirectory, "people.xml");
            using (FileStream stream = File.Create(path))
            {
                xs.Serialize(stream, people);
            }
            WriteLine($"Written {new FileInfo(path).Length} bytes of XML to {path}");
            // Read the file
            WriteLine(File.ReadAllText(path));


            // deserialize
            using (FileStream xmlLoad = File.Open(path, FileMode.Open))
            {
                var loadPeople = (List<Person>)xs.Deserialize(xmlLoad);
                foreach (var item in loadPeople)
                {
                    WriteLine($"{item.LastName} has {item.Children.Count} Children");
                }
            }
        }
    }
}
