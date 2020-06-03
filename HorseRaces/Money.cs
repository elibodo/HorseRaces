using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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

        public decimal Loss(decimal lossAmount)
        {
            this.totalBalance -= lossAmount;
            //Balance(this.totalBalance);
            return this.totalBalance;
        }

        public decimal Win(decimal winAmount)
        {
            this.totalBalance += winAmount;
            //Balance(this.totalBalance);
            return this.totalBalance;
        }
    }
}
