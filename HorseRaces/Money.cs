using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace HorseRaces
{
    public class Money
    {
        public decimal NewBalance { get; set;}
        public decimal CurrentBalance { get; set;}
        public decimal BetAmount { get; set; }
        public string Outcome { get; set; }

        private List<BetHistory> History = new List<BetHistory>();

        public Money(decimal balance)
        {
            this.NewBalance = balance;
        }

        public decimal Bet(int guessNumber, int winningNumber, decimal balance, decimal bet)
        {
            this.BetAmount = bet;
            this.CurrentBalance = balance;
            if (guessNumber == winningNumber)
            {
                NewBalance = Win(BetAmount);
                Outcome = "Win";
            }
            else
            {
                NewBalance = Loss(BetAmount);
                Outcome = "Loss";
            }
            Console.WriteLine($"\nWinning Number:  {winningNumber}\n" +
                              $"       Outcome:  {Outcome}\n" +
                              $"       Balance:  {NewBalance}\n");

            var newBet = new BetHistory(CurrentBalance, BetAmount, Outcome, NewBalance);
            History.Add(newBet);
            return NewBalance;
        }

        private decimal Loss(decimal bet)
        {
            this.NewBalance -= bet;
            return NewBalance;
        }

        private decimal Win(decimal bet)
        {
            this.NewBalance += (bet * 2);
            return NewBalance;
        }
        public void AllBets()
        {
            // Prints information from the list: History
            int betnum = 0;
            StringBuilder Bets = new StringBuilder();
            Bets.AppendLine("Bet Number\tInitial Balance\t\tBet\t\tOutcome\t\tNew Balance");
            Bets.AppendLine("----------\t---------------\t\t---\t\t-------\t\t-----------");
            foreach (var item in History)
            {
                betnum++;
                Bets.AppendLine($"{betnum}\t\t{item.CurrentBalance}\t\t\t{item.Bet}\t\t{item.Outcome}\t\t{item.NewBalance}");
            }
            Console.WriteLine(Bets);
        }
    }
}
