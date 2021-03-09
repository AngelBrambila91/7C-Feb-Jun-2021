using System;
using GeneralLibrary;
using static System.Console;

namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}
