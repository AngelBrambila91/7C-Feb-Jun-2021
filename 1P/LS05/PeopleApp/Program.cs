using System;
using GeneralLibrary;
using static System.Console;

namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region POO Stuff
                
            var baltazar = new Person();
            baltazar.Name = "Baltazar";
            WriteLine(baltazar.ToString());

            var leo = new Person();
            leo.Name = "Leonardo";
            leo.DateOfBirth = new DateTime(1990, 12, 22);
            WriteLine($"{leo.Name} was born in {leo.DateOfBirth: d MMMM yyyy}");

            var layla = new Person
            {
                Name = "Layla",
                DateOfBirth = new DateTime(1980, 3, 7),
                FavoriteWonder = WondersOfTheWorld.ColossusOfRhodes
            };
            WriteLine($"{layla.Name} was born in {layla.DateOfBirth: d MMMM yyyy}");
            baltazar.FavoriteWonder = WondersOfTheWorld.HangingGardensOfBabylon;
            
            baltazar.Children.Add(new Person
            {Name = "Alfred"});
            baltazar.Children.Add(new Person
            {Name = "Sakura Kinomot Desu"});

            WriteLine($"{baltazar.Name} has {baltazar.Children.Count} children :");
            for (int child = 0; child < baltazar.Children.Count; child++)
            {
                WriteLine($"{baltazar.Children[child].Name}");
            }

            BankAccount.InterestRate = 0.012M;
            var leoAccount = new BankAccount();
            leoAccount.AccountName = "Mister Leo";
            leoAccount.Balance = 3400;
            WriteLine($"{leoAccount.AccountName} earned {leoAccount.Balance * BankAccount.InterestRate:C} interest");

            var laylaAccount = new BankAccount();
            laylaAccount.AccountName = "Miss Layla";
            laylaAccount.Balance = 3400;
            WriteLine($"{laylaAccount.AccountName} earned {laylaAccount.Balance * BankAccount.InterestRate:C} interest");

            var blankPerson = new Person();
            WriteLine($"{blankPerson.Name} of {blankPerson.HomePlanet} was created {blankPerson.Instantiated}");

            var martian = new Person("Marvin", "Mars");
            WriteLine($"{martian.Name} of {martian.HomePlanet} was created {martian.Instantiated}");
            #endregion

            #region Procreate
                var ana = new Person { Name = "Ana" };
                var tiberio = new Person { Name = "Tiberio" };
                var vicente = new Person { Name = "Vicente" };
                // call instance method
                var baby1 = ana.ProceateWith(tiberio);
                baby1.Name = "NoPalindromo";
                // static call
                var baby2 = Person.Procreate(vicente, ana);

                // ussing overload operator
                var baby3  = ana * tiberio;
                WriteLine($"{ana.Name} has {ana.Children.Count} children");
                WriteLine($"{tiberio.Name} has {tiberio.Children.Count} children");
                WriteLine($"{vicente.Name} has {vicente.Children.Count} children");
                WriteLine($"{ana.Name}'s first child is named \"{ana.Children[1].Name}\".");
            #endregion

            #region TestLocal Functions
                WriteLine($"5! is {Person.Factorial(5)}");
            #endregion
            
            ana.Shout = Ana_Shout;
            ana.Poke();
            ana.Poke();
            ana.Poke();
            ana.Poke();
            ana.Poke();

        }
        #region Using Delegates
            private static void Ana_Shout(object sender, EventArgs e)
            {
                Person p = (Person)sender;
                WriteLine($"{p.Name} is this angry : {p.AngerLevel}");
            }

        #endregion
    }
}
