using System;
using System.Security.Cryptography;

namespace HorseRaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Horse Racing Game!\n\n");
            Console.Write("Enter your name: ");
            string newUser = Console.ReadLine();

            var Person = new User(newUser);
            Console.WriteLine($"\nNew user: {Person.name}\nBalance: {Person.initialBalance}\n\n");

            Console.Write("Enter your bet: ");
            decimal betamount = Convert.ToDecimal(Console.ReadLine());

            var Bet = new Money(Person.totalBalance, betamount);
        }
    }
}
