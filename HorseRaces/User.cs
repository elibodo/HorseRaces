﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Dynamic;
using System.Text;

namespace HorseRaces
{
    class User
    {
        public string name { get; set; }
        public decimal initialBalance { get; }
        public decimal totalBalance { get; set; }

        public static decimal newUserBalance = 1000;


        public User(string user)
        {
            this.name = user;
            this.initialBalance = newUserBalance;
        }

        public void UpdateBalance(decimal amount)
        {
            this.totalBalance += amount;
        }
    }
}