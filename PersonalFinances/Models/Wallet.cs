using System.IO;
namespace PersonalFinances
{
    class Wallet : Notifier
    {
        public string Title { get; set; }
        public string Currency { get; set; }

        string balance = "";
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

        public void Save(BinaryWriter write)
        {
            write.Write(Title);
            write.Write(Currency);
            write.Write(Balance);
        }
        public void Download(BinaryReader read)
        {
            Title = read.ReadString();
            Currency = read.ReadString();
            Balance = read.ReadString();
        }
    }
}