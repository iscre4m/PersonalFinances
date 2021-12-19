using System.IO;
namespace PersonalFinances
{
    class Wallet : Notifier
    {
        public string Title { get; set; }
        public string Currency { get; set; }

        string balance = "0";
        public string Balance
        {
            get => balance;
            set
            {
                if (value != balance)
                {
                    balance = value;
                    OnPropertyChanged("Balance");
                }
            }
        }

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

        public void Save(BinaryWriter writer)
        {
            writer.Write(Title);
            writer.Write(Currency);
            writer.Write(Balance);
        }

        public void Load(BinaryReader reader)
        {
            Title = reader.ReadString();
            Currency = reader.ReadString();
            Balance = reader.ReadString();
        }
    }
}