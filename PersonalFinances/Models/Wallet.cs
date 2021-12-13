namespace PersonalFinances
{
    class Wallet
    {
        public string Title { get; set; }
        public string Currency { get; set; }
        public string Balance { get; set; }

        public Wallet()
        {
            Title = "";
            Currency = "UAH";
            Balance = "0";
        }

        public Wallet(string title,
                      string currency,
                      string balance)
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