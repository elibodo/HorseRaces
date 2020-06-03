using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace HorseRaces
{
    class Program
    {
        static void Main(string[] args)
        {
            // Introduces the player to the game. And explains what is going on
            Console.WriteLine("Horse Racing Game!\n\n");
            Console.WriteLine("After entering your name you will be prompted to choose a horse to bet on and place a bet." +
                "\nYou have three options Horse 1, 2, or 3. " +
                "Each bet will payout 2-1. Meaning if you bet $1 you will get $2 if you win.\n\n");

            Game();
        }

        static int RandomHorse()
        {
            int[] numberArray = new[] { 1, 2, 3 };
            Random randomNumber = new Random();
            int number = randomNumber.Next(numberArray.Length);
            int horse = numberArray[number];
            return horse;
        }

        static bool BetOutcome(int horse, int selectedHorse)
        {
            if (horse == selectedHorse) { return true; }
            else { return false; }
        }

        static void Game()
        {
            // Enter name
            Console.Write("Enter your name: ");
            string newUser = Console.ReadLine();

            // Show user info
            var Person = new User(newUser);
            Console.WriteLine($"\nNew user: {Person.name}\nBalance: {Person.balance}");

            decimal money = Person.balance;
            bool game = true;
            while (game == true)
            {
                // Choose which horse to bet on. Makes the user choose 1, 2, or 3 
                Console.WriteLine("\n\nDo you want to bet on Horse 1, 2, or 3?");
                string horse = "";
                bool checkInt = false;
                while (checkInt == false)
                {
                    Console.Write("Type either '1' or '2' or '3': ");
                    horse = Console.ReadLine();
                    checkInt = IntegerCheck(horse);
                }
                int horseNumber = Convert.ToInt32(horse);

                // Gets the bet and checks if it is a decimal 
                string userbet = "";
                bool checkDecimal = false;
                while (checkDecimal == false)
                {
                    Console.Write("\n\nEnter your bet: ");
                    userbet = Console.ReadLine();
                    checkDecimal = DecimalCheck(userbet);
                }
                decimal betamount = Convert.ToDecimal(userbet);
                var Bet = new Money(money, betamount);

                // Gets winning horse and checks if you won
                int winningNumber = RandomHorse();
                bool win = BetOutcome(winningNumber, horseNumber);

                // Calls money class if win/loss
                if (win == true) { money = Bet.Win(betamount * 2); }
                else { money = Bet.Loss(betamount); }

                // Printing info. test info
                Console.WriteLine($"Winning number: {winningNumber}");
                Console.WriteLine(money);
            }
        }

        static bool DecimalCheck(string bet)
        {
            try
            {
                decimal betAmount = Convert.ToDecimal(bet);
                return true;
            }
            catch
            {
                return false;
            }
        }

        static bool IntegerCheck(string horse)
        {
            try
            {
                int selectedHorse = Convert.ToInt32(horse);
                if (selectedHorse > 3 || selectedHorse < 1) { return false; }
                else { return true; }
            }
            catch
            {
                return false;
            }
        }
    }
}
