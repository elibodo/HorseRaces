using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace HorseRaces
{
    class Money
    {
        public decimal totalBalance { get; set; }
        public decimal bet { get; }
        public decimal winLossAmount { get; set; }

        public Money(decimal balance, decimal betAmount)
        {
            this.totalBalance = balance;
            this.bet = betAmount;
        }
        public void Bet(decimal amount)
        {
            if (amount > totalBalance)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Bet amount is more that your balance");
            }
        }

        public void Loss(decimal lossAmount)
        {
            this.totalBalance -= lossAmount;
        }

        public void Win(decimal winAmount)
        {
            this.totalBalance += winAmount;
        }
    }
}
