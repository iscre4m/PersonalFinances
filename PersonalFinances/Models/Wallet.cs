namespace PersonalFinances
{
    class Wallet
    {
        public string Title { get; }
        public string Currency { get; private set; }
        public double Balance { get; private set; }

        public Wallet(string name,
                           string currency,
                           double balance)
        {
            Title = name;
            Currency = currency;
            Balance = balance;
        }

        public void Replenish(double sum) => Balance += sum;

        public void Withdraw(double sum) => Balance -= sum;

        public override string ToString() => Title + ' ' + Currency;
    }
}