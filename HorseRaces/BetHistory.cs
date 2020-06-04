using System;
using System.Collections.Generic;
using System.Text;

namespace HorseRaces
{
    public class BetHistory
    {
        public decimal CurrentBalance { get; }
        public decimal Bet { get; }
        public string Outcome { get; }
        public decimal NewBalance { get; }

        public BetHistory(decimal balance, decimal bet, string outcome, decimal newBalance)
        {
            this.CurrentBalance = balance;
            this.Bet = bet;
            this.Outcome = outcome;
            this.NewBalance = newBalance;
        }
    }
}
