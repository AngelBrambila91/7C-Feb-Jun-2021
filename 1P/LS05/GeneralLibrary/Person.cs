using System;
using System.Collections.Generic;

namespace GeneralLibrary
{
    public class Person : object
    {
        // Member Variables
        /*
        Fileds: 
            - Constant : Data can never change
            - Read - Only : Data can never change after class is instantiated, BUT i can change data from constructor
            - Event : 
        
        Methods :
            - Constructor : when the new keyword is called
            - Property : 
            - Indexer : 
            - Operator : 
        */
        // Fields
        public string Name;
        public DateTime DateOfBirth;
        public WondersOfTheWorld FavoriteWonder;
        public List<Person> Children = new List<Person>();
        public const string Species = "Homo Sapiens";
        public readonly string HomePlanet = "Earth";
        public readonly DateTime Instantiated;
        /*
        private : Only inside the class is accesible
        internal : Only accesible inside the same assembly
        protected : Only accesible from any type that inherits
        public : member is accesible everywhere
        internal protected:
        private protected:
        */
        // Contructors
        public Person()
        {
            Name = "Unkown";
            Instantiated = DateTime.Now;
        }

        public Person(string initialName, string homePlanet)
        {
            Name = initialName;
            HomePlanet = homePlanet;
            Instantiated = DateTime.Now;
        }
    }
}
