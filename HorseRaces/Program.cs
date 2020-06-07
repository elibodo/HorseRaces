using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace HorseRaces
{
    class Program
    {
        static void Main(string[] args)
        {
            // Introduces the player to the game. And explains what is going on
            Console.WriteLine("Horse Racing Game!\n\n");
            Console.WriteLine("After entering your name you will be prompted to choose a horse to bet on and then you can place a bet." +
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

        static void Game()
        {
            string newUser = "";
            bool name = false;
            while (name == false)
            {
                Console.Write("Enter your name: ");
                newUser = Console.ReadLine();
                if (newUser != "") { name = true; }
            }

            // Show user info
            var Person = new User(newUser);
            Console.WriteLine($"\nNew user: {Person.name}\n" +
                                $"Balance:  {Person.balance}\n");


            var Bet = new Money(Person.balance);

            // Declare variables
            decimal money = Person.balance;
            bool game = true;
            decimal maxBalance = 0;

            while (game == true)
            {
                string horse = "";
                bool checkInt = false;
                string userbet = "";
                bool checkDecimal = false;
                string playAgain = "";

                // Choose which horse to bet on. Makes the user choose 1, 2, or 3 
                while (checkInt == false)
                {
                    Console.Write("Place Bet on Horse '1', '2', or '3': ");
                    horse = Console.ReadLine();
                    checkInt = IntegerCheck(horse);
                }
                int horseNumber = Convert.ToInt32(horse);

                // Gets the bet and checks if it is a decimal
                Console.WriteLine();
                while (checkDecimal == false)
                {
                    Console.Write("Enter your bet: ");
                    userbet = Console.ReadLine();
                    checkDecimal = DecimalCheck(userbet,money);
                }
                decimal betamount = Convert.ToDecimal(userbet);

                // Gets winning horse number
                int winningNumber = RandomHorse();

                // Printing info
                money = Bet.Bet(horseNumber,winningNumber,money,betamount);

                if (money > maxBalance) { maxBalance = money; }

                if (money <= 0) { break; }

                Console.WriteLine("Do you want to bet again?");
                while (playAgain != "y" && playAgain != "n")
                {
                    Console.Write("Type 'y' or 'n': ");
                    playAgain = Console.ReadLine();
                }

                Console.WriteLine("\n\n\n");
                if (playAgain == "y") { game = true; }
                else { game = false; }
                
            }
            Console.WriteLine($"\nPlayer: {Person.name}\nMax Balance: {maxBalance}\n");
            Bet.AllBets();
        }

        static bool DecimalCheck(string bet, decimal balance)
        {
            string message = "Bet needs to be a number greater than 0 and less than your balance.";
            try
            {
                decimal betAmount = Convert.ToDecimal(bet);
                if (betAmount > 0 && balance >= betAmount) { return true; }
                else
                {
                    Console.WriteLine(message);
                    return false;
                }
            }
            catch
            {
                Console.WriteLine(message);
;               return false;
            }
        }

        static bool IntegerCheck(string horse)
        {
            string message = "Type '1', '2', or '3'.";
            try
            {
                int selectedHorse = Convert.ToInt32(horse);
                if (selectedHorse > 3 || selectedHorse < 1)
                {
                    Console.WriteLine(message);
                    return false;
                }
                else { return true; }
            }
            catch
            {
                Console.WriteLine(message);
                return false;
            }
        }
    }
}
