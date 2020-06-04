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
            // Enter name
            Console.Write("Enter your name: ");
            string newUser = Console.ReadLine();

            // Show user info
            var Person = new User(newUser);
            Console.WriteLine($"\nNew user: {Person.name}\n" +
                                $"Balance:  {Person.balance}");

            // Declare variables
            decimal money = Person.balance;
            bool game = true;
            string allBets = "";

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
                    Console.Write("\nPlace Bet on Horse '1', '2', or '3': ");
                    horse = Console.ReadLine();
                    checkInt = IntegerCheck(horse);
                }
                int horseNumber = Convert.ToInt32(horse);

                // Gets the bet and checks if it is a decimal 
                while (checkDecimal == false)
                {
                    Console.Write("\nEnter your bet: ");
                    userbet = Console.ReadLine();
                    checkDecimal = DecimalCheck(userbet,money);
                }
                decimal betamount = Convert.ToDecimal(userbet);

                // Gets winning horse number
                int winningNumber = RandomHorse();

                // Initializing the constructor for the Money class
                var Bet = new Money(money, betamount);

                // Printing info
                money = Bet.Bet(horseNumber,winningNumber,money);

                //allBets = Bet.AllBets();

                Console.WriteLine("Do you want to bet again?");
                while (playAgain != "y" && playAgain != "n")
                {
                    Console.Write("Type 'y' or 'n': ");
                    playAgain = Console.ReadLine();
                }

                if (playAgain == "y") { game = true; }
                else
                {
                    //Console.WriteLine(Bet.AllBets());
                    Bet.showstuff();
                    game = false;
                }
            }
        }

        static bool DecimalCheck(string bet, decimal balance)
        {
            try
            {
                decimal betAmount = Convert.ToDecimal(bet);
                if (betAmount > 0 && balance >= betAmount) { return true; }
                else { return false; }
            }
            catch
            {
;                return false;
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
