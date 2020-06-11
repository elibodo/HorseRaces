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

            // Runs the game
            Game();
        }

        static int RandomHorse()
        {
            // Creates a random number from 1 to 3 and returns it
            int[] numberArray = new[] { 1, 2, 3 };
            Random randomNumber = new Random();
            int number = randomNumber.Next(numberArray.Length);
            int horse = numberArray[number];
            return horse;
        }

        static void Game()
        {
            // Gets the name from the user and checks if they have entered it
            string newUser = "";
            bool name = false;
            while (name == false)
            {
                Console.Write("Enter your name: ");
                newUser = Console.ReadLine();
                if (newUser != "") { name = true; }
            }

            // Creates a new user object and prints the name and starting balance
            var Person = new User(newUser);
            Console.WriteLine($"\nNew user: {Person.name}\n" +
                                $"Balance:  {Person.balance}\n");


            // New bet object
            var Bet = new Money(Person.balance);

            // Declare variables
            decimal money = Person.balance;
            bool game = true;
            decimal maxBalance = 1000;

            // Game will run until the user runs out of money or if the user decides to quit
            while (game == true)
            {
                // Declaring variables
                string horse = "";
                bool checkInt = false;
                string userbet = "";
                bool checkDecimal = false;
                string playAgain = "";

                // Choose which horse to bet on
                // Calls IntegerCheck to verify the input
                while (checkInt == false)
                {
                    Console.Write("Place Bet on Horse '1', '2', or '3': ");
                    horse = Console.ReadLine();
                    checkInt = IntegerCheck(horse);
                }
                int horseNumber = Convert.ToInt32(horse);


                // Gets the bet from the user
                // Calls DecimalCheck to verify the input 
                Console.WriteLine();
                while (checkDecimal == false)
                {
                    Console.Write("Enter your bet: ");
                    userbet = Console.ReadLine();
                    checkDecimal = DecimalCheck(userbet,money);
                }
                decimal betamount = Convert.ToDecimal(userbet);


                // Gets winning horse number from method: RandomHorse
                int winningNumber = RandomHorse();

                // Calls a method from the money class
                // Determines if the user won or loss and prints information
                money = Bet.Bet(horseNumber,winningNumber,money,betamount);

                // Gets the new max balance
                if (money > maxBalance) { maxBalance = money; }

                // Breaks out of the Game method if the user is out of money
                if (money <= 0) { break; }

                // User asked if they want to play again
                // Game runs again if user entered 'y'
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
            // Prints the players name and their max balance while playing
            Console.WriteLine($"\nPlayer: {Person.name}\nMax Balance: {maxBalance}\n");

            // Calles a method from the money class to print information
            Bet.AllBets();
        }

        static bool DecimalCheck(string bet, decimal balance)
        {
            // Checks if the bet is more than 0 and less than or equal to their total balance
            // Prints out what to do if the information that they entered is incorrect
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
            // Checks if the user entered either '1', '2', or '3'
            // Prints out what to do if the information that they entered is incorrect
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
