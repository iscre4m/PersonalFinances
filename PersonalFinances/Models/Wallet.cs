namespace PersonalFinances
{
    class Wallet
    {
        public string Title { get; set; }
        public string Currency { get; set; }
        public string Balance { get; set; }

        public OperationsCapacitor OperationsCapacitor { get; } = new();
        public WalletOperationsModel WalletOperationsModel { get; } = new();

        public Wallet(string title = "",
                      string currency = "UAH",
                      string balance = "0")
        {
            Title = title;
            Currency = currency;
            Balance = balance;
        }

        public void Replenish(double sum) => Balance = (double.Parse(Balance) + sum).ToString();

        public void Withdraw(double sum) => Balance = (double.Parse(Balance) - sum).ToString();

        public override string ToString() => Title + ' ' + Currency;
    }
}