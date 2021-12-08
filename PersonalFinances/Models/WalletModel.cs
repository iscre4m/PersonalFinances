﻿namespace PersonalFinances
{
    class WalletModel : Notifier
    {
        public string Title { get; }
        public string Currency { get; private set; }

        public double Balance { get; private set; }

        public WalletModel(string name, string currency, double balance)
        {
            Title = name;
            Currency = currency;
            Balance = balance;
        }

        public void Withdraw(double sum)
        {
            Balance -= sum;
        }

        public void Replenish(double sum)
        {
            Balance += sum;
        }

        public override string ToString()
        {
            return Title + ' ' + Currency;
        }
    }
}