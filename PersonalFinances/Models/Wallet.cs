﻿namespace PersonalFinances
{
    class Wallet : Notifier, IWallet
    {
        public string Title { get; }
        public string Currency { get; private set; }

        public double Balance { get; private set; }

        public Wallet(string name, string currency, double balance)
        {
            Title = name;
            Currency = currency;
            Balance = balance;
        }

        public void Withdraw(double sum)
        {
            if (Balance - sum >= 0)
            {
                Balance -= sum;
            }
        }

        public void Replenish(double sum)
        {
            Balance += sum;
        }

        public override string ToString()
        {
            return Title + ' ' + Balance.ToString() + ' ' + Currency;
        }
    }
}