namespace PersonalFinances
{
    abstract class Wallet : Notifier, IWallet
    {
        public string Name { get; }
        public string Currency { get; protected set; }

        public double Balance { get; protected set; }

        protected Wallet(string name, string currency, double balance)
        {
            Name = name;
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
    }
}